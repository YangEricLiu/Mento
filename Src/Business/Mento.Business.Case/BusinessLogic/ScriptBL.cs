using System;
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

namespace Mento.Business.Script.BusinessLogic
{
    public class ScriptBL 
    {
        private static ScriptDA ScriptDA = new ScriptDA();
        private static Type[] PropertyTypes = new Type[] { typeof(CaseIDAttribute), typeof(ManualCaseIDAttribute), typeof(CreateTimeAttribute), typeof(OwnerAttribute) };

        public void Synchronize()
        {
            ScriptDA.DeleteAll();

            //from the publish location, get all script meta-data
            string scriptPath = @"E:\works\kara\mento\Trunk\Case\ScriptHost\bin\Debug";

            DirectoryInfo publishDirectory = new DirectoryInfo(scriptPath);
            if(!publishDirectory.Exists)
            {
                throw new Exception("the publish directory does not exist!");
            }

            foreach (var scriptAssembly in publishDirectory.GetFiles().Where(f => f.Name.StartsWith(Project.SCRIPTNAMESPACEPREFIX) && f.Name.EndsWith(FileExtensions.ASSEMBLY)))
            {
            }

            //List<ScriptEntity> scripts;

            ////for each script meta-data, insert it into database
            //foreach (var script in scripts)
            //{
            //    ScriptDA.Create(script);
            //}
        }

        public ScriptEntity[] Export()
        {
            throw new NotImplementedException();

            ScriptEntity[] scripts = ScriptDA.RetrieveAll();

            //for each script in scripts, write it into an excel row

            return scripts;
        }
        
        private Dictionary<Type, string> GetScriptProperties(IList<CustomAttributeData> attributeData)
        {
            var query = from data in attributeData
                        where PropertyTypes.Contains(data.Constructor.DeclaringType)
                        select new { Key = data.Constructor.DeclaringType, Value = data.ConstructorArguments[0].Value.ToString() };

            return query.ToDictionary(data => data.Key, data => data.Value);
        }

        private Dictionary<string, List<string>> ValidateScript(List<Assembly> testAssemblies)
        {
            foreach (var assembly in testAssemblies)
            {
                foreach (var testSuite in Assembly.LoadFrom(scriptAssembly.FullName).GetTypes().Where(t => t.IsSubclassOf(typeof(TestSuiteBase))))
                {
                    Dictionary<Type, string> suitePropertyDictionary = this.GetScriptProperties(testSuite.GetCustomAttributesData());

                    string suiteManualCaseID = suitePropertyDictionary[typeof(CaseIDAttribute)];
                    string suiteCreateTime = suitePropertyDictionary[typeof(CreateTimeAttribute)];
                    string suiteOwner = suitePropertyDictionary[typeof(OwnerAttribute)];

                    foreach (var testMethod in testSuite.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(m => m.GetCustomAttributes(typeof(TestAttribute), true).Count() > 0))
                    {
                        Dictionary<Type, string> scriptPropertyDictionary = this.GetScriptProperties(testMethod.GetCustomAttributesData());

                        string CaseID = scriptPropertyDictionary[typeof(CaseIDAttribute)];

                        string scriptManualCaseID = scriptPropertyDictionary[typeof(ManualCaseIDAttribute)];
                        string scriptCreateTime = scriptPropertyDictionary[typeof(CreateTimeAttribute)];
                        string scriptOwner = scriptPropertyDictionary[typeof(OwnerAttribute)];

                        var script = new ScriptEntity()
                        {
                            CaseID = CaseID,
                            CreateTime = DateTime.Parse(String.IsNullOrEmpty(scriptCreateTime) ? suiteCreateTime : scriptCreateTime),
                            ManualCaseID = String.IsNullOrEmpty(scriptManualCaseID) ? suiteManualCaseID : scriptManualCaseID,
                            Owner = String.IsNullOrEmpty(scriptOwner) ? suiteOwner : scriptOwner,
                            SuiteName = testSuite.Name,
                            Feature = testSuite.Namespace.Split(ASCII.DOT.ToCharArray()[0]).Last(),
                            Module = scriptAssembly.Name.Split(ASCII.DOT.ToCharArray()[0]).Last(),
                            Name = testMethod.Name,
                            SyncTime = DateTime.Now,
                            Priority = 1,
                        };

                        ScriptDA.Create(script);
                    }
                }
            }
        }
    }
}
