﻿using System;
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
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Mento.Framework.DataAccess;

namespace Mento.Business.Plan.BusinessLogic
{
    public class ExecutionBL
    {
        private static ExecutionDA ExecutionDA = new ExecutionDA();
        private static PlanBL PlanBL = new PlanBL();
        private static ResultBL ResultBL = new ResultBL();

        private static ScriptBL ScriptBL = new ScriptBL();

        public DataTable ExportByPlanID(string planID)
        {
            PlanEntity plan = PlanBL.GetPlanByPlanID(planID);

            ExecutionEntity[] executions = ExecutionDA.RetrieveByPlanID(plan.ID);

            //TODO:
            //Export to excel
            string fileName = Path.Combine(ExportConfig.ResultExportDirectory, String.Format("{0}.xls", plan.PlanID));

            DataTable dataTable = ExecutionArrayToDataTable(executions, plan: plan);
            ExcelHelper.ExportToExcel(dataTable, fileName, "ResultList");

            return dataTable;
        }

        public DataTable ExportByCaseID(string caseID)
        {
            ExecutionEntity[] executions = ExecutionDA.RetrieveByCaseID(caseID);

            //TODO:
            //Export to excel
            string fileName = Path.Combine(ExportConfig.ResultExportDirectory, String.Format("{0}.xls", caseID));

            DataTable dataTable = ExecutionArrayToDataTable(executions);
            ExcelHelper.ExportToExcel(dataTable, fileName, "ResultList");

            return dataTable;
        }

        public void Execute(string planID, string url, string browser, string language)
        {
            PlanEntity plan = PlanBL.GetPlanByPlanID(planID);

            //initialize execution context
            InitializeExecutionContext(url, browser, language);

            //CreateExecutionRecordForPlan();
            long executionID = CreateExecutionRecord(plan);

            string workFolder = Path.Combine(ExecutionConfig.ExecutionDirectory, String.Format("{0}-{1}", plan.PlanID, executionID));
            
            //copy published script from publish directory to local
            if (!Directory.Exists(ExecutionConfig.ScriptDirectory) || ExecutionConfig.IsRefreshScriptsOnExecution)
                FileSystemHelper.CopySharedFiles(ExecutionConfig.PublishDirectory, ExecutionConfig.LocalNetworkDrive, ExecutionConfig.PublishServerUserName, ExecutionConfig.PublishServerPassword, ExecutionConfig.ScriptDirectory);
            
            //execute initialize sql script
            JazzDatabaseOperator.Initialize();

            //call unit to execute the script list
            ExecuteScripts(plan, workFolder);

            //when execution finished, update endtime, destruct execution context, destruct database
            ExecutionDA.UpdateEndTime(executionID, DateTime.Now);
            ExecutionContext.Destruct();
            JazzDatabaseOperator.Destruct();

            //collect execute result, split result for every script
            List<ResultEntity> results = GetTestSuiteResults(workFolder, executionID);

            //save result
            foreach (var result in results)
            {
                ResultBL.Create(result);
            }
        }
        
        #region Private methods
        private void ExecuteScripts(PlanEntity plan, string workFolder)
        {
            foreach (var groupItem in plan.ScriptList.GroupBy(s => s.Assembly))
            {
                if (String.IsNullOrEmpty(groupItem.Key))
                    continue;

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

        private DataTable ExecutionArrayToDataTable(ExecutionEntity[] executions,PlanEntity plan=null)
        {
            string[] headers = typeof(ExecutionEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(p => p.Name).ToArray();

            DataTable table = new DataTable();

            foreach (var column in headers)
                table.Columns.Add(column);

            foreach (ExecutionEntity execution in executions)
            {
                DataRow row = table.NewRow();

                foreach (var column in headers)
                {
                    if (String.Equals(column, "PlanID", StringComparison.OrdinalIgnoreCase))
                        row[column] = plan != null ? plan.PlanID : PlanBL.GetPlanByID(execution.PlanID, isGetScripts: false).PlanID;
                    else
                        row[column] = typeof(ExecutionEntity).GetProperty(column).GetValue(execution, null);
                }

                table.Rows.Add(row);
            }

            return table;
        }

        private List<ResultEntity> GetTestSuiteResults(string workFolder,long executionID)
        {
            List<ResultEntity> fixtureResultList = new List<ResultEntity>();

            DirectoryInfo workDirectory = new DirectoryInfo(workFolder);

            if(workDirectory.Exists)
                foreach (FileInfo resultFile in workDirectory.GetFiles("result*.xml"))
                {
                    XDocument resultXml = XDocument.Load(resultFile.FullName);

                    foreach (XElement scriptElement in resultXml.XPathSelectElements("//test-suite[@type='TestFixture']/results").Elements())
                    {
                        //string testFixtureName = fixtureElement.Attribute("name").Value;

                        //foreach (XElement scriptElement in fixtureElement.Element("results").Elements())
                        //{
                        //Console.WriteLine(scriptElement.Name);
                        string caseID = scriptElement.XPathSelectElement("properties/property[@name='CaseID']").Attribute("value").Value;
                        ScriptExecutionStatus status = String.Equals(scriptElement.Attribute("executed").Value, "True", StringComparison.OrdinalIgnoreCase) ? String.Equals(scriptElement.Attribute("result").Value, "Success", StringComparison.OrdinalIgnoreCase) ? ScriptExecutionStatus.Passed : ScriptExecutionStatus.Failed : ScriptExecutionStatus.NotRun;

                        ResultEntity result = new ResultEntity()
                        {
                            CaseID = caseID,
                            Status = status,
                            ExecutionID = executionID,
                            FailReason = status == ScriptExecutionStatus.Failed ? scriptElement.XPathSelectElement("failure/stack-trace").Value : String.Empty,
                            FailDetail = status == ScriptExecutionStatus.Failed ? scriptElement.XPathSelectElement("failure/message").Value : String.Empty,
                            //TODO:get image url from fail message
                            ImageUrl = "",
                        };

                        fixtureResultList.Add(result);
                        //}
                    }
                }

            return fixtureResultList;
        }
        #endregion
    }
}