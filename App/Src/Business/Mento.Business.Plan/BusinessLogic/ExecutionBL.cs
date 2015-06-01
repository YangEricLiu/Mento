using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using Mento.Business.Execution.DataAccess;
using Mento.Business.Plan.Entity;
using Mento.Business.Script.BusinessLogic;
using Mento.Framework.Configuration;
using Mento.Framework.Constants;
using Mento.Framework.DataAccess;
using Mento.Framework.Exceptions;
using Mento.Framework.Execution;
using Mento.Framework.Log;
using Mento.Utility;

namespace Mento.Business.Plan.BusinessLogic
{
    public class ExecutionBL
    {
        private static ExecutionDA ExecutionDA = new ExecutionDA();
        private static PlanBL PlanBL = new PlanBL();
        private static ResultBL ResultBL = new ResultBL();

        private static ScriptBL ScriptBL = new ScriptBL();

        public ExecutionEntity GetExecutionByID(long executionID)
        {
            ExecutionEntity entity = ExecutionDA.Retrieve(executionID);

            if (entity == null)
                throw new AppException(String.Format("Execution record '{0}' does not exist",executionID));

            return entity;
        }

        public DataTable ExportByPlanID(string planID, out string exportFilePath)
        {
            PlanEntity plan = PlanBL.GetPlanByPlanID(planID);

            ExecutionEntity[] executions = ExecutionDA.RetrieveByPlanID(plan.ID);

            //TODO:
            //Export to excel
            exportFilePath = Path.Combine(ExportConfig.ResultExportDirectory, String.Format("{0}.xls", plan.PlanID));

            DataTable dataTable = ExecutionArrayToDataTable(executions, plan: plan);
            ExcelHelper.ExportToExcel(dataTable, exportFilePath, "ResultList");

            return dataTable;
        }

        public DataTable ExportByCaseID(string caseID, out string exportFilePath)
        {
            ExecutionEntity[] executions = ExecutionDA.RetrieveByCaseID(caseID);

            //TODO:
            //Export to excel
            exportFilePath = Path.Combine(ExportConfig.ResultExportDirectory, String.Format("{0}.xls", caseID));

            DataTable dataTable = ExecutionArrayToDataTable(executions);
            ExcelHelper.ExportToExcel(dataTable, exportFilePath, "ResultList");

            return dataTable;
        }

        public List<ResultEntity> Execute(string planID, string url, string browser, string language)
        {
            PlanEntity plan = PlanBL.GetPlanByPlanID(planID);

            //initialize execution context
            InitializeExecutionContext(url, browser, language);

            //CreateExecutionRecordForPlan();
            long executionID = CreateExecutionRecord(plan);

            string workFolder = Path.Combine(ExecutionConfig.ExecutionDirectory, String.Format("{0}-{1}", plan.PlanID, executionID));

            //copy published script from publish directory to local
            if (!Directory.Exists(ExecutionConfig.ScriptDirectory) || Directory.GetFiles(ExecutionConfig.ScriptDirectory).Length <= 0 || ExecutionConfig.IsRefreshScriptsOnExecution)
                FileSystemHelper.DownloadSharedFiles(ExecutionConfig.PublishDirectory, ExecutionConfig.LocalNetworkDrive, ExecutionConfig.PublishServerUserName, ExecutionConfig.PublishServerPassword, ExecutionConfig.ScriptDirectory);

            //execute initialize sql script, for the prepared data is done by backup and restore database
            //JazzDatabaseOperator.Initialize();

            //call nunit to execute the script list
            ExecuteScripts(plan, workFolder);

            //when execution finished, update endtime, destruct execution context, destruct database
            ExecutionDA.UpdateEndTime(executionID, DateTime.Now);
            ExecutionContext.Destruct();
            //JazzDatabaseOperator.Destruct();

            //archive error image
            ArchiveExecutionResult(workFolder);

            //collect execute result, split result for every script
            List<ResultEntity> results = GetTestSuiteResults(workFolder, executionID);

            //save result
            foreach (var result in results)
            {
                //ResultBL.Create(result);
            }

            return results;
        }
        
        #region Private methods
        private void ExecuteScripts(PlanEntity plan, string workFolder)
        {
            foreach (var groupItem in plan.ScriptList.GroupBy(s => s.Assembly))
            {
                try
                {
                    if (String.IsNullOrEmpty(groupItem.Key))
                        continue;

                    StringBuilder Command = new StringBuilder();
                    //make nunit project

                    //add project parameter
                    Command.Append("/run:");
                    Command.Append(String.Join(ASCII.COMMA.ToString(), groupItem.OrderBy(s => s.Priority).Select(s => s.FullName).ToArray()));
                    Command.Append(ASCII.SPACE);
                    Command.Append(Path.Combine(workFolder, String.Format("../../script/{0}", groupItem.Key)));

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
                catch (Exception ex)
                {
                    ConsoleHelper.WriteColorLine("Error: " + ex.Message, ConsoleColor.Red);
                    AppLog.Instance.LogError(ex.ToString());
                    continue;
                }
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

        private List<ResultEntity> GetTestSuiteResults(string workFolder, long executionID)
        {
            List<ResultEntity> fixtureResultList = new List<ResultEntity>();

            DirectoryInfo workDirectory = new DirectoryInfo(workFolder);
            if (!workDirectory.Exists)
                return fixtureResultList;

            foreach (FileInfo resultFile in workDirectory.GetFiles("result*.xml"))
            {
                XDocument resultXml = XDocument.Load(resultFile.FullName);

                foreach (XElement scriptElement in resultXml.XPathSelectElements("//test-suite[@type='TestFixture']/results").Elements())
                {
                    string caseID = scriptElement.XPathSelectElement("properties/property[@name='CaseID']").Attribute("value").Value;

                    if (String.IsNullOrEmpty(caseID))
                        continue;

                    ScriptExecutionStatus status = String.Equals(scriptElement.Attribute("executed").Value, "True", StringComparison.OrdinalIgnoreCase) ? String.Equals(scriptElement.Attribute("result").Value, "Success", StringComparison.OrdinalIgnoreCase) ? ScriptExecutionStatus.Passed : ScriptExecutionStatus.Failed : ScriptExecutionStatus.NotRun;
                    
                    ResultEntity result = new ResultEntity() { CaseID = caseID, Status = status, ExecutionID = executionID };

                    if (scriptElement.XPathSelectElement("results") != null) //multi cases
                    {
                        foreach (XElement caseElement in scriptElement.XPathSelectElement("results").Elements("test-case"))
                        {
                            result.ScriptName = caseElement.Attribute("name").Value;
                            if (status == ScriptExecutionStatus.Failed)
                            {
                                result.FailDetail = caseElement.XPathSelectElement("failure/stack-trace").Value;
                                result.FailReason = caseElement.XPathSelectElement("failure/message").Value;
                                result.ImageUrl = GetImageFileName(result.ScriptName, workFolder);
                            }

                            fixtureResultList.Add(result);
                        }
                    }
                    else if (scriptElement.XPathSelectElement("failure") != null) //single case
                    {
                        result.ScriptName = scriptElement.Attribute("name").Value;
                        if (status == ScriptExecutionStatus.Failed)
                        {
                            result.FailDetail = scriptElement.XPathSelectElement("failure/stack-trace").Value;
                            result.FailReason = scriptElement.XPathSelectElement("failure/message").Value;
                            result.ImageUrl = GetImageFileName(result.ScriptName, workFolder);
                        }

                        fixtureResultList.Add(result);
                    }
                    else
                    {
                        fixtureResultList.Add(result);
                    }
                }
            }

            return fixtureResultList;
        }

        private static void PrintAndLog(string message)
        {
            Console.WriteLine(message);
            AppLog.Instance.LogInformation(message);
        }

        private static void ArchiveExecutionResult(string workDirectory)
        {
            string workDirectoryName = workDirectory.TrimEnd('\\').Split('\\').Last();


            if (Directory.Exists(workDirectory))
                FileSystemHelper.UploadSharedFiles(ExecutionConfig.ExecutionArchiveDirectory, ExecutionConfig.LocalNetworkDrive, ExecutionConfig.PublishServerUserName, ExecutionConfig.PublishServerPassword, workDirectory);
        }

        private string GetImageFileName(string scriptName, string workFolder)
        {
            string fileName = scriptName.GetHashCode() + ".jpg";

            return workFolder.TrimEnd('\\').Split('\\').Last() + "\\" + fileName;
        }
        #endregion
    }
}
