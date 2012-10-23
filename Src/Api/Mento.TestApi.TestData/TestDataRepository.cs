using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using Mento.Framework.Constants;
using System.Xml.Linq;
using Mento.Utility;

namespace Mento.TestApi.TestData
{
    internal static class TestDataRepository
    {
        private static Dictionary<string, string> _dataMapping;
        private static Dictionary<string, string> DataMapping
        {
            get 
            {
                if (_dataMapping == null)
                {
                    string mappingFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings[ConfigurationKey.SCRIPT_DATA_MAPPINGFILE]);

                    if (File.Exists(mappingFile))
                    {
                        XDocument xdoc = XDocument.Load(mappingFile);

                        var query = from element in xdoc.Element("relation").Elements("script")
                                    select new string[]
                                    { 
                                        element.Attributes().Where(e=>e.Name.ToString().ToLower()=="caseid").Single().Value,
                                        element.Attributes().Where(e=>e.Name.ToString().ToLower()=="testdata").Single().Value,
                                    };

                        _dataMapping = query.ToDictionary(x => x[0], x => x[1]);
                    }
                }

                return _dataMapping;
            }
        }

        public static T GetTestData<T>(string testCaseID,string testScriptFullName)
        {
            //search dictionary first, if not exist mapping relation, search test data using the input test case id
            string testDataID = testCaseID;
            if (DataMapping.Keys.Contains(testCaseID))
            {
                testDataID = DataMapping[testCaseID];
            }

            string testDataFileName = GetTestDataFileName(testDataID, testScriptFullName);

            return Deserialize<T>(testDataFileName);
        }

        private static string GetTestDataFileName(string testDataID, string testScriptFullName)
        { 
            //get test script namespace by caseid
            string[] Namespaces = testScriptFullName.Split('.');

            //replace "Automation" with "Data"

            //add file name
            if (Namespaces.Length > 1)
            {
                StringBuilder pathBuilder = new StringBuilder();

                Namespaces[0] = "Data";
                Namespaces[Namespaces.Length - 1] = testDataID;

                for (int i = 0; i < Namespaces.Length; i++)
                {
                    pathBuilder.Append(Namespaces[i]);
                    if (i == Namespaces.Length - 1)
                    {
                        pathBuilder.Append(".json");
                    }
                    else
                    {
                        pathBuilder.Append("\\");
                    }
                }

                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathBuilder.ToString());
            }
            
            return String.Empty;
        }

        private static T Deserialize<T>(string fileName)
        {
            if (File.Exists(fileName))
            {
                string content = File.ReadAllText(fileName, Encoding.UTF8);

                return JsonHelper.String2Object<T>(content);
            }

            return default(T);
        }
    }
}