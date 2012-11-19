using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.Business.Plan.Entity;
using Mento.Business.Execution.DataAccess;
using Mento.Business.Script.BusinessLogic;
using Mento.Business.Plan.DataAccess;
using Mento.Business.Script.Entity;
using NUnit.Core;
using System.IO;
using Mento.Framework.Configuration;
using Mento.Framework.Constants;
using Mento.Framework.Execution;
using Mento.Framework.Exceptions;
using System.Data;

namespace Mento.Business.Plan.BusinessLogic
{
    public class ExecutionBL
    {
        private static ExecutionDA ExecutionDA = new ExecutionDA();
        private static PlanBL PlanBL = new PlanBL();

        private static ScriptBL ScriptBL = new ScriptBL();

        public ExecutionEntity[] ExportByPlanID(string planID)
        {
            PlanEntity plan = PlanBL.GetPlanByPlanID(planID);

            ExecutionEntity[] executions = ExecutionDA.RetrieveByPlanID(plan.ID);

            //TODO:
            //Export to excel
            string fileName = Path.Combine(ExportConfig.ResultExportDirectory, String.Format("{0}.xls", plan.PlanID));

            ExcelHelper.ExportToExcel<ExecutionEntity>(executions.ToList(), fileName, "ResultList");

            return executions;
        }

        public ExecutionEntity[] ExportByCaseID(string caseID)
        {
            ExecutionEntity[] executions = ExecutionDA.RetrieveByCaseID(caseID);

            //TODO:
            //Export to excel
            string fileName = Path.Combine(ExportConfig.ResultExportDirectory, String.Format("{0}.xls", caseID));
            
            ExcelHelper.ExportToExcel<ExecutionEntity>(executions.ToList(), fileName, "ResultList");

            return executions;
        }

        public void Execute(string planID, string url, string browser, string language)
        {
            PlanEntity plan = PlanBL.GetPlanByPlanID(planID);

            string workFolder = Path.Combine(ExecutionConfig.ExecutionDirectory, plan.PlanID);

            //initialize execution context
            InitializeExecutionContext(url,browser,language);

            //copy published script from publish directory to local
            if (!Directory.Exists(ExecutionConfig.ScriptDirectory) || ExecutionConfig.IsRefreshScriptsOnExecution)
                FileSystemHelper.CopySharedFiles(ExecutionConfig.PublishDirectory, ExecutionConfig.LocalNetworkDrive, ExecutionConfig.PublishServerUserName, ExecutionConfig.PublishServerPassword, ExecutionConfig.ScriptDirectory);
            
            //CreateExecutionRecordForPlan();
            long executionID = CreateExecutionRecord(plan);

            //call unit to execute the script list
            ExecuteScripts(plan, workFolder);

            //when execution finished, update endtime, destruct execution context
            ExecutionDA.UpdateEndTime(executionID, DateTime.Now);
            ExecutionContext.Destruct();

            //collect execute result, split result for every script
            

            //save result
        }


        #region Private methods
        private void ExecuteScripts(PlanEntity plan, string workFolder)
        {
            foreach (var groupItem in plan.ScriptList.GroupBy(s => s.Assembly))
            {
                StringBuilder Command = new StringBuilder();
                //make nunit project

                //add project parameter
                Command.Append("/run:");
                Command.Append(String.Join(ASCII.COMMA,groupItem.Select(s=>s.FullName).ToArray()));
                Command.Append(ASCII.SPACE);
                Command.Append(Path.Combine(workFolder,String.Format("../../script/{0}",groupItem.Key)));

                //add work parameter
                Command.Append(ASCII.SPACE);
                Command.Append("/work:");
                Command.Append(workFolder);

                //add nologo parameter
                Command.Append(ASCII.SPACE);
                Command.Append("/nologo");

                //add result parameter
                Command.Append(ASCII.SPACE);
                Command.Append("/result:");
                Command.Append(Path.Combine(workFolder, String.Format("result-{0}.xml", groupItem.Key)));

                //add process parameter
                Command.Append(ASCII.SPACE);
                Command.Append("/process:Single");
                
                NUnit.ConsoleRunner.Runner.Main(Command.ToString().Split(' '));
            }
        }

        private long CreateExecutionRecord(PlanEntity plan)
        {
            ExecutionEntity execution = new ExecutionEntity()
            {
                PlanID = plan.ID,
                Url = ExecutionContext.Url,
                Browser = ExecutionContext.Browser,
                Language = ExecutionContext.Language,
                CpuCount = HardwareHelper.GetCpuCount(),
                CpuFrequency = HardwareHelper.GetCpuFrequency(),
                MemorySize = HardwareHelper.GetTotalPhysicalMemory(),
                StartTime = DateTime.Now,
                EndTime = null,
                Owner = HardwareHelper.GetUserName(),
                ScreenResolution = HardwareHelper.GetScreenResolution(),
            };

            return ExecutionDA.Create(execution);
        }

        private void InitializeExecutionContext(string url, string browser, string language)
        {
            if (String.IsNullOrEmpty(url))
                url = ExecutionConfig.Url;
            if (String.IsNullOrEmpty(browser))
                browser = ExecutionConfig.Browser;
            if (String.IsNullOrEmpty(language))
                language = ExecutionConfig.Language;

            ExecutionContext.Initialize(url, browser, language);
        }

        #endregion
    }
}
