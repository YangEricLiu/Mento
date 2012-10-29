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

namespace Mento.Business.Script.BusinessLogic
{
    public class ScriptBL 
    {
        private static ScriptDA ScriptDA = new ScriptDA();

        public void Synchronize()
        {
            //throw new NotImplementedException();

            //from the publish location, get all script meta-data
            string scriptPath = @"E:\works\kara\mento\Trunk\Case\ScriptHost\bin\Debug";

            DirectoryInfo publishDirectory = new DirectoryInfo(scriptPath);
            if(!publishDirectory.Exists)
            {
                throw new Exception("the publish directory does not exist!");
            }

            foreach (var scriptAssembly in publishDirectory.GetFiles().Where(f => f.Name.StartsWith(Project.SCRIPTNAMESPACEPREFIX) && f.Name.EndsWith(FileExtensions.ASSEMBLY)))
            {
                foreach (var type in Assembly.LoadFrom(scriptAssembly.FullName).GetTypes().Where(t => t.IsSubclassOf(typeof(TestSuiteBase))))
                {
                    string testSuite = type.Name;
                    string nameSpace = type.Namespace;

                    var query = from method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                where method.GetCustomAttributes(typeof(TestAttribute), true).Count() > 0
                                select method;

                    foreach (var testMethod in query)
                    {
                        var attributeData = testMethod.GetCustomAttributesData();

                        foreach (var data in attributeData)
                            Console.WriteLine(data);

                        //var script = new ScriptEntity() { 
                        //    CaseID
                        //};
 
                    }
                }
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
    }
}
