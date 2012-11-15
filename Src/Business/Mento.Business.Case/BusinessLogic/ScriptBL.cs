﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Business.Script.Entity;
using Mento.Business.Script.DataAccess;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using Mento.Framework.Script;
using Mento.Framework.Constants;
using Mento.Framework.Attributes;
using Mento.Framework.Configuration;
using System.Text.RegularExpressions;
using System.Runtime.Caching;
using Mento.Utility;
using System.Data;
using Microsoft.Office.Interop.Excel;


namespace Mento.Business.Script.BusinessLogic
{
    public class ScriptBL 
    {
        private static ScriptDA ScriptDA = new ScriptDA();
        private static Type[] PropertyTypes = new Type[] { typeof(CaseIDAttribute), typeof(ManualCaseIDAttribute), typeof(CreateTimeAttribute), typeof(OwnerAttribute) };


        public bool Synchronize(out Dictionary<MethodInfo, List<Type>> validationResult)
        {
            ScriptDA.DeleteAll();

            //from the publish location, get all script meta-data
            List<ScriptEntity> scripts;

            validationResult = this.ValidateScript(out scripts);

            if (validationResult.Count > 0)
            {
                return false;
            }
            else
            {
                //for each script meta-data, insert it into database
                foreach (var script in scripts)
                {
                    ScriptDA.Create(script);
                }

                return true;
            }
        }

        public ScriptEntity[] Export()
        {
            string excelFilePath = ExportConfig.GetExportLocationConfig(ConfigurationKey.SCRIPT_EXPORT_DIRECTORY);;
            //string excelFilePath = @"D:\backup\ScriptMetaData.xlsx";

            String[] headerList = new string[] { "CaseID", "ManualCaseID", "Name", 
                "SuiteName", "Type", "Priority", "Feature", "Module", "Owner", "CreateTime", "SyncTime" };

            System.Data.DataTable scriptsTable = ScriptDA.RetrieveToDataTable();

            //Open excel file which restore scripts data
            ExcelHelper handler = new ExcelHelper(excelFilePath, false);

            handler.OpenOrCreate();

            //Get Worksheet object 
            Worksheet sheet = handler.GetWorksheet("ScriptsData");

            //Import data from the start
            handler.ImportDataTable(sheet, headerList, scriptsTable);

            handler.Save();
            handler.Dispose();

            return ScriptDA.RetrieveAll();
        }

        /// <summary>
        /// Validate a list of suite, output the not existing suites
        /// </summary>
        /// <param name="suiteNameList"></param>
        /// <param name="notExistedList"></param>
        /// <returns></returns>
        public bool ValidateSuiteExistence(List<string> suiteNameList, out List<string> notExistingSuites)
        {
            var existingSuites = GetScriptsFromCache().Where(s => suiteNameList.Contains(s.SuiteName)).Select(s => s.SuiteName).Distinct();

            notExistingSuites = suiteNameList.Except(existingSuites).ToList();

            return notExistingSuites.Count == 0;
        }

        /// <summary>
        /// Validate a list of script, output the not existing scripts
        /// </summary>
        /// <param name="caseIDList"></param>
        /// <param name="notExistedList"></param>
        /// <returns></returns>
        public bool ValidateScriptExistence(List<string> caseIDList, out List<string> notExistingScripts)
        {
            var existingScripts = GetScriptsFromCache().Where(s => caseIDList.Contains(s.CaseID)).Select(s => s.CaseID).Distinct();

            notExistingScripts = caseIDList.Except(existingScripts).ToList();

            return notExistingScripts.Count == 0;
        }

        /// <summary>
        /// Get script list of a suite
        /// </summary>
        /// <param name="suiteName"></param>
        /// <returns></returns>
        public string[] GetScriptListBySuiteName(string suiteName)
        {
            return GetScriptsFromCache().Where(s => String.Equals(s.SuiteName, suiteName, StringComparison.OrdinalIgnoreCase)).Select(s => s.CaseID).ToArray();
        }

        #region private methods
        private ScriptEntity[] GetScriptsFromCache()
        {
            string AllScriptsCacheKey = "SCRIPT-ALLSCRIPTS";

            if (CacheHelper.Get(AllScriptsCacheKey) == null)
            {
                CacheHelper.Add(AllScriptsCacheKey, ScriptDA.RetrieveAll());
            }

            return (ScriptEntity[])CacheHelper.Get(AllScriptsCacheKey);
        }

        private Dictionary<MethodInfo, List<Type>> ValidateScript(out List<ScriptEntity> scriptList)
        {
            string scriptPath = @"D:\publish\TA\Release0.1.0.0";

            Dictionary<MethodInfo, List<Type>> validationFaults = new Dictionary<MethodInfo, List<Type>>();
            scriptList = new List<ScriptEntity>();

            List<Type> testSuites = this.GetTestSuites(scriptPath);

            foreach (var testSuite in testSuites)
            {
                Dictionary<Type, string> suiteProperties = this.GetScriptProperties(testSuite.GetCustomAttributesData());

                foreach (var testScript in testSuite.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(m => m.GetCustomAttributes(typeof(TestAttribute), true).Count() > 0))
                {
                    List<Type> faults = new List<Type>();

                    Dictionary<Type, string> scriptProperties = this.GetScriptProperties(testScript.GetCustomAttributesData());

                    string CaseID = this.GetScriptePropertyValue(suiteProperties, scriptProperties, typeof(CaseIDAttribute));
                    string ManualCaseID = this.GetScriptePropertyValue(suiteProperties, scriptProperties, typeof(ManualCaseIDAttribute));
                    string CreateTimeString = this.GetScriptePropertyValue(suiteProperties, scriptProperties, typeof(CreateTimeAttribute));
                    string Owner = this.GetScriptePropertyValue(suiteProperties, scriptProperties, typeof(OwnerAttribute));

                    DateTime CreateTime;

                    if (String.IsNullOrEmpty(CaseID) || !Regex.IsMatch(CaseID, ValidationRegexPatterns.IDENTITYPATTERN))
                        faults.Add(typeof(CaseIDAttribute));
                    if (String.IsNullOrEmpty(ManualCaseID) || !Regex.IsMatch(ManualCaseID, ValidationRegexPatterns.IDENTITYPATTERN))
                        faults.Add(typeof(ManualCaseIDAttribute));
                    if (String.IsNullOrEmpty(CreateTimeString) || !DateTime.TryParse(CreateTimeString, out CreateTime))
                        faults.Add(typeof(CreateTimeAttribute));
                    if (String.IsNullOrEmpty(Owner))
                        faults.Add(typeof(OwnerAttribute));

                    if (faults.Count > 0)
                        validationFaults.Add(testScript, faults);
                    else
                        scriptList.Add(this.ConstructScriptEntity(CaseID, DateTime.Parse(CreateTimeString), ManualCaseID, Owner, testSuite, testScript));
                }
            }

            return validationFaults;
        }

        private ScriptEntity ConstructScriptEntity(string caseID,DateTime createTime,string manualCaseID,string owner,Type testSuite,MethodInfo testScript)
        {
            return new ScriptEntity()
            {
                CaseID = caseID,
                CreateTime = createTime,
                ManualCaseID = manualCaseID,
                Owner = owner,
                SuiteName = testSuite.Name,
                Feature = testSuite.Namespace.Split(ASCII.DOT.ToCharArray()[0]).LastOrDefault(),
                Module = testSuite.Namespace.Replace(Project.SCRIPTNAMESPACEPREFIX+ASCII.DOT,String.Empty).Split(ASCII.DOT.ToCharArray()[0]).FirstOrDefault(),
                Name = testScript.Name,
                SyncTime = DateTime.Now,
                Priority = 1,
                Type = 1,
            };
        }

        private Dictionary<Type, string> GetScriptProperties(IList<CustomAttributeData> attributeData)
        {
            var query = from data in attributeData
                        where PropertyTypes.Contains(data.Constructor.DeclaringType)
                        select new { Key = data.Constructor.DeclaringType, Value = data.ConstructorArguments[0].Value.ToString() };

            return query.ToDictionary(data => data.Key, data => data.Value);
        }

        private string GetScriptePropertyValue(Dictionary<Type, string> suiteProperties, Dictionary<Type, string> scriptProperties,Type propertyType)
        {
            return scriptProperties.ContainsKey(propertyType) ? scriptProperties[propertyType] : suiteProperties.ContainsKey(propertyType) ? suiteProperties[propertyType] : String.Empty;
        }

        private List<Type> GetTestSuites(string scriptPath)
        {
            List<Type> testSuites = new List<Type>();

            DirectoryInfo publishDirectory = new DirectoryInfo(scriptPath);
            if (!publishDirectory.Exists)
            {
                throw new Exception("the publish directory does not exist!");
            }

            foreach (var assembly in publishDirectory.GetFiles().Where(f => f.Name.StartsWith(Project.SCRIPTNAMESPACEPREFIX) && f.Name.EndsWith(FileExtensions.ASSEMBLY)))
            {
                testSuites.AddRange(Assembly.LoadFrom(assembly.FullName).GetTypes().Where(t => t.IsSubclassOf(typeof(TestSuiteBase))));
            }

            return testSuites;
        }
        #endregion
    }
}
