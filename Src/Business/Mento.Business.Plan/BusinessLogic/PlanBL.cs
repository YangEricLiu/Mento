using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Business.Plan.DataAccess;
using System.IO;
using Mento.Framework.Exceptions;
using System.Xml.Linq;
using System.Xml.XPath;
using Mento.Business.Script.BusinessLogic;
using System.Text.RegularExpressions;
using Mento.Framework.Constants;
using Mento.Business.Plan.Entity;
using System.Transactions;
using Mento.Business.Script.Entity;
using Mento.Framework.Enumeration;
using Mento.Business.Execution.DataAccess;
using Mento.Framework;
using Mento.Utility;
using Mento.Framework.Configuration;
using Microsoft.Office.Interop.Excel;
using Mento.Business.Script.DataAccess;

namespace Mento.Business.Plan.BusinessLogic
{
    public class PlanBL
    {
        private static PlanDA PlanDA = new PlanDA();
        private static PlanScriptDA PlanScriptDA = new PlanScriptDA();

        private static ScriptBL ScriptBL = new ScriptBL();
        private static ScriptDA ScriptDA = new ScriptDA();

        public void Create(string planFile)
        {
            XDocument planDefinition = GetPlanXDocument(planFile);

            PlanEntity plan = GetPlanInformationFromXDocument(planDefinition);

            if (PlanDA.Retrieve(plan.PlanID) != null)
                throw new AppException(String.Format("the given plan '{0}' already exists", plan.PlanID));

            plan.Status = EntityStatus.Active;
            plan.UpdateTime = DateTime.Now;
            
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
            {
                long planID = PlanDA.Create(plan);

                plan.ID = planID;

                BuildPlanScriptReference(plan);

                ts.Complete();
            }
        }

        public void Update(string planID, string planFile)
        {
            //if plan does not exit, alert
            PlanEntity originalPlan = CheckPlanExists(planID);

            XDocument planDefinition = GetPlanXDocument(planFile);

            PlanEntity plan = GetPlanInformationFromXDocument(planDefinition);
            plan.ID = originalPlan.ID;
            plan.Status = originalPlan.Status;
            plan.UpdateTime = DateTime.Now;

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
            {
                PlanDA.Update(plan);

                BuildPlanScriptReference(plan);

                ts.Complete();
            }
        }

        public void Delete(string planID)
        {
            //if plan does not exit, alert
            PlanEntity originalPlan = CheckPlanExists(planID);

            originalPlan.Status = EntityStatus.Deleted;

            PlanDA.Update(originalPlan);
        }

        public PlanEntity[] Export(out string exportFilePath)
        {
            exportFilePath = Path.Combine(ExportConfig.PlanExportDirectory, "list.xls");

            String[] headerList = new string[] { "ID", "PlanID", "Name", "ProductVersion", "Owner", "UpdateTime", "Status" };

            System.Data.DataTable planTable = PlanDA.RetrieveAllToDataSet();

            ////Open excel file which restore scripts data
            //ExcelHelper handler = new ExcelHelper(planFilePath, true);

            //handler.OpenOrCreate();

            ////Get Worksheet object 
            //Worksheet sheet = handler.GetWorksheet("PlansData");

            ////Import data from the start
            //handler.ImportDataTable(sheet, headerList, scriptsTable);

            //handler.Save();
            //handler.Dispose();

            ExcelHelper.ExportToExcel(planTable, exportFilePath, "PlanList");

            return PlanDA.RetrieveAll();
        }

        public ScriptEntity[] Export(string planID, out string exportFilePath)
        {
            exportFilePath = string.Format("Plans-{0}.xls", planID);

            exportFilePath = Path.Combine(ExportConfig.PlanExportDirectory, exportFilePath);
            //String[] headerList = new string[] { "ID","CaseID", "ManualCaseID", "Name", "SuiteName", "Type", "Priority", "Feature", "Module", "Owner", "CreateTime", "SyncTime" };

            PlanEntity plan = GetPlanByPlanID(planID);

            System.Data.DataTable scriptsTable = ScriptDA.RetrieveByPlanIDToDataSet(plan.ID);

            //ExcelHelper handler = new ExcelHelper(excelFilePath, true);

            //handler.OpenOrCreate();
            //Worksheet sheet = handler.AddWorksheet(planID);
            ////Delete all sheet except special one
            //handler.DeleteWorksheetExcept(sheet);

            ////Import data from the start
            //handler.ImportDataTable(sheet, headerList, scriptsTable);

            //handler.Save();

            //handler.Dispose();

            ExcelHelper.ExportToExcel(scriptsTable, exportFilePath, "ScriptList");


            return ScriptDA.RetrieveByPlanID(plan.ID);
        }

        public PlanEntity GetPlanByExecutionID(long executionID, bool isGetScripts = true)
        {
            PlanEntity plan = PlanDA.RetrieveByExecutionID(executionID);
            if (plan == null)
            {
                throw new Exception(String.Format("plan '{0}' was not found.", plan.PlanID));
            }

            if (isGetScripts)
                plan.ScriptList = ScriptBL.GetScriptsByPlanID(plan.ID).ToList();

            return plan;
        }

        public PlanEntity GetPlanByID(long planID, bool isGetScripts = true)
        {
            PlanEntity plan = PlanDA.Retrieve(planID);
            if (plan == null)
            {
                throw new Exception(String.Format("plan '{0}' was not found.", planID));
            }

            if (isGetScripts)
                plan.ScriptList = ScriptBL.GetScriptsByPlanID(plan.ID).ToList();

            return plan;
        }

        public PlanEntity GetPlanByPlanID(string planID)
        {
            PlanEntity plan = PlanDA.Retrieve(planID);
            if (plan == null)
            {
                throw new AppException(String.Format("plan '{0}' was not found.", planID));
            }
            plan.ScriptList = ScriptBL.GetScriptsByPlanID(plan.ID).ToList();

            return plan;
        }

        #region private methods
        private PlanEntity CheckPlanExists(string planID)
        {
            //if plan does not exit, alert
            var plan = PlanDA.Retrieve(planID);
            if (plan == null)
            {
                throw new AppException(String.Format("plan '{0}' does not exist", planID));
            }

            return plan;
        }

        private XDocument GetPlanXDocument(string planFile)
        {
            //validate file
            if (!File.Exists(planFile))
                throw new AppException("the provided plan file does not exist!");

            //validate xml
            try
            {
                return XDocument.Load(planFile);                
            }
            catch (Exception ex)
            {
                throw new AppException("the provided plan file is wrongly formated!", ex);
            }
        }

        private PlanEntity GetPlanInformationFromXDocument(XDocument xdoc)
        {
            PlanEntity plan = new PlanEntity();

            //validate content
            XElement root = xdoc.Element("plan");

            plan.PlanID = root.Element("id") == null ? String.Empty : root.Element("id").Value.Trim();
            plan.Name = root.Element("name") == null ? String.Empty : root.Element("name").Value.Trim();
            plan.ProductVersion = root.Element("version") == null ? String.Empty : root.Element("version").Value.Trim();
            plan.Owner = root.Element("owner") == null ? String.Empty : root.Element("owner").Value.Trim();
            plan.ScriptList = GetScriptListFromXDocument(xdoc);

            ValidatePlanEntity(plan);

            return plan;
        }

        private List<ScriptEntity> GetScriptListFromXDocument(XDocument xdoc)
        {
            XElement root = xdoc.Element("plan");
            Dictionary<string, List<string>> suiteList = new Dictionary<string, List<string>>();

            foreach (var suiteElement in root.Elements("suite"))
            {
                string suiteName = suiteElement.Attribute("name").Value.Trim();
                List<string> scripts = suiteElement.Elements("caseid").Select(e => e.Value.Trim()).Distinct().ToList();

                if (suiteList.Keys.Contains(suiteName) && suiteList[suiteName] != null)
                    suiteList[suiteName].AddRange(scripts);
                else
                    suiteList.Add(suiteName, scripts);
            }

            //validate suite names
            List<string> notExistingSuites;
            if (!ScriptBL.ValidateSuiteExistence(suiteList.Keys.ToList(), out notExistingSuites))
                throw new AppException(String.Format("Suite {0} does not exist", String.Join(ASCII.COMMA.ToString(), notExistingSuites.ToArray())));
            
            //get case list from suite list
            List<string> scriptList = suiteList.SelectMany(item => item.Value.Count() > 0 ? item.Value : ScriptBL.GetScriptListBySuiteName(item.Key).ToList()).ToList();

            return scriptList.Select(s => new ScriptEntity() { CaseID = s }).ToList();
        }

        private void ValidatePlanEntity(PlanEntity plan)
        {
            Dictionary<string, string> validationResult = new Dictionary<string, string>();
            List<string>  notExistingScripts;

            if (String.IsNullOrEmpty(plan.PlanID) || !Regex.IsMatch(plan.PlanID, ValidationRegexPatterns.IDENTITYPATTERN))
                validationResult.Add("PlanID", "can not be null and match identity rule");
            if (String.IsNullOrEmpty(plan.ProductVersion))
                validationResult.Add("ProductVersion", "can not be null");
            if (!ScriptBL.ValidateScriptExistence(plan.ScriptList.Select(s=>s.CaseID).ToList(), out notExistingScripts))
                validationResult.Add("CaseList", String.Join(ASCII.COMMA.ToString(), notExistingScripts.ToArray()) + "does not exist");

            if (validationResult.Count > 0)
            {
                throw new AppException(String.Join("\n", validationResult.Select(item => String.Format("{0}:{1}", item.Key, item.Value))));
            }
        }

        private void BuildPlanScriptReference(PlanEntity plan)
        {
            PlanScriptDA.Delete(plan.ID);

            foreach (var script in plan.ScriptList)
            {
                PlanScriptDA.Create(new PlanScriptEntity() { PlanID = plan.ID, CaseID = script.CaseID });
            }
        }
        #endregion
    }
}
