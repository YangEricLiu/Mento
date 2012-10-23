using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using Mento.Framework.Constants;
using System.Xml.Linq;

namespace Mento.TestApi.TestData
{
    public class TestDataRepository
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

        public static T GetTestData<T>(string testCaseID) where T : TestDataBase
        {
            //search dictionary first, if not exist mapping relation, search test data using the input test case id
            string testDataID = testCaseID;
            if (DataMapping.Keys.Contains(testCaseID))
            {
                testDataID = DataMapping[testCaseID];
            }

            return null;
        }

        private static string GetTestDataFileName(string testDataID)
        { 
            //get test script namespace by caseid
            return String.Empty;
        }
    }
}