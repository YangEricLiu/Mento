using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using Mento.Framework.Constants;
using System.Xml.Linq;
using Mento.Utility;
using System.Reflection;
using System.Text.RegularExpressions;
using Mento.TestApi.WebUserInterface;

namespace Mento.TestApi.TestData
{
    /// <summary>
    /// Test data repository which provides methods for loading test data
    /// </summary>
    internal static class TestDataRepository
    {
        private const string DATAFOLDERNAME = "Data";
        private const string GETTESTDATAMETHODNAME = "GetTestData";
        private const string TESTDATAINPUTPROPERTYNAME = "InputData";
        private const string TESTDATAEXPECTEDPROPERTYNAME = "ExpectedData";

        private static Dictionary<string, string> _dataMapping;
        private static Dictionary<string, string> DataMapping
        {
            get
            {
                if (_dataMapping == null)
                {
                    string mappingFile = PathHelper.GetAppAbsolutePath(ConfigurationManager.AppSettings[ConfigurationKey.SCRIPT_DATA_MAPPINGFILE]);

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
                    else
                    {
                        var errorMessage = String.Format("data mapping was not found at: {0}!", mappingFile);
                        throw new Exception(errorMessage);
                    }
                }

                return _dataMapping;
            }
        }

        /// <summary>
        /// Load test data for current test script
        /// </summary>
        /// <typeparam name="T">Generic type of the acquiring test data type</typeparam>
        /// <param name="testCaseID">Test case id of the current test script</param>
        /// <param name="testScriptFullName">The acquiring test script full name.</param>
        /// <returns>The test data instance</returns>
        public static T GetTestData<T>(string testCaseID, string testScriptFullName)
        {
            //search dictionary first, if not exist mapping relation, search test data using the input test case id
            string testDataID = testCaseID;

            if (DataMapping.Keys.Contains(testCaseID))
            {
                testDataID = DataMapping[testCaseID];
            }

            string testDataFileName = GetTestDataFileName(testDataID, testScriptFullName);

            T instance = Deserialize<T>(testDataFileName);

            SetCommonData<T>(testDataFileName, instance);

            return instance;
        }

        /// <summary>
        /// Load the acquiring multiple test data and return the specified element
        /// </summary>
        /// <param name="testDataType">The specified test data type</param>
        /// <param name="testSuiteType">Type of test suite of the target test scipt</param>
        /// <param name="testCaseID">Test case id of the target test script</param>
        /// <param name="dataIndex">Element index of the test data array, which will be passed to the test script as its parameter.</param>
        /// <returns>Object array that contains only the specified element</returns>
        public static object[] GetTestDataElement(Type testDataType, Type testSuiteType, string testCaseID, int dataIndex)
        {
            object[] parameters = new object[] { /*testCaseID*/testCaseID, /*testScriptFullName*/String.Format("{0}.{1}", testSuiteType.FullName, testCaseID) };

            object testData = DynamicCall(GETTESTDATAMETHODNAME, testDataType, parameters);

            return new object[] { ((Array)testData).GetValue(dataIndex) };
        }

        /// <summary>
        /// Load all test data from a test data file
        /// </summary>
        /// <param name="testDataType">The specified test data type</param>
        /// <param name="testSuiteType">Type of test suite of the target test scipt</param>
        /// <param name="testCaseID">Test case id of the target test script</param>
        /// <returns>Object array that contains all the loaded test data elements</returns>
        public static object[] GetTestDataElementArray(Type testDataType, Type testSuiteType, string testCaseID)
        {
            object[] parameters = new object[] { /*testCaseID*/testCaseID, /*testScriptFullName*/String.Format("{0}.{1}", testSuiteType.FullName, testCaseID) };

            object testData = DynamicCall(GETTESTDATAMETHODNAME, testDataType, parameters);

            return Object2Array(testData);
        }

        /// <summary>
        /// Load all test data from a test data file
        /// </summary>
        /// <param name="testDataType">The specified test data type</param>
        /// <param name="dataFileName">The specified test data file</param>
        /// <returns>Test data array</returns>
        public static object[] GetTestDataElementArray(Type testDataType, string dataFileName)
        {
            object[] parameters = new object[] { dataFileName };
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Static;

            object testData = DynamicCall("Deserialize", testDataType, parameters, flags: flags);

            return Object2Array(testData);
        }

        #region Private methods
        /// <summary>
        /// Get test data file name with test case id and the test script namespace
        /// </summary>
        /// <param name="testDataID">The specified test case id</param>
        /// <param name="testScriptFullName">The acquiring test script full name.</param>
        /// <returns>The constructed path string of the test data file.</returns>
        private static string GetTestDataFileName(string testDataID, string testScriptFullName)
        {
            //replace test script namespace prefix with data folder name
            testScriptFullName = testScriptFullName.Replace(Project.SCRIPTNAMESPACEPREFIX, TestDataRepository.DATAFOLDERNAME);

            //add file name
            string[] Namespaces = testScriptFullName.Split(ASCII.DOT);
            if (Namespaces.Length > 1)
            {
                StringBuilder pathBuilder = new StringBuilder();

                Namespaces[Namespaces.Length - 1] = testDataID;

                for (int i = 0; i < Namespaces.Length; i++)
                {
                    pathBuilder.Append(Namespaces[i]);
                    if (i == Namespaces.Length - 1)
                    {
                        pathBuilder.Append(ASCII.DOT).Append(FileExtensions.JSON);
                    }
                    else
                    {
                        pathBuilder.Append(ASCII.BACKLASH);
                    }
                }

                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathBuilder.ToString());
            }

            return String.Empty;
        }

        /// <summary>
        /// Load test data from the input test data file and deserialize to the specified type
        /// </summary>
        /// <typeparam name="T">Generic type of the acquiring test data</typeparam>
        /// <param name="fileName">The test data file name</param>
        /// <returns>Test data instance</returns>
        private static T Deserialize<T>(string fileName)
        {
            Console.WriteLine(fileName);
            if (File.Exists(fileName))
            {
                string content = File.ReadAllText(fileName, Encoding.UTF8);

                //throw new Exception(LanguageResourceRepository.ResourceDictionary.Keys.First());

                //replace happens here
                //language key replace, if language resource has place holder, replace with parameter
                //commodity key replace
                //$@common.message.test
                //$@common.message.test|(a),(b),(c)
                //content = .ReplaceLanguageVariables(content);

                content = LanguageHelper.ReplaceRawTestData(content);

                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);
            }
            else
            {
                var errorMessage = String.Format("test data file was not found at: {0}!", fileName);
                throw new Exception(errorMessage);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="genericType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static object DynamicCall(string methodName, Type genericType, object[] parameters, BindingFlags flags = BindingFlags.Public | BindingFlags.Static)
        {
            return ReflectionHelper.MakeGenericDynamicCall(typeof(TestDataRepository), methodName, flags, genericType, parameters: parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrayObject"></param>
        /// <returns></returns>
        private static object[] Object2Array(object arrayObject)
        {
            if (!arrayObject.GetType().IsArray)
                return null;

            List<object> dataList = new List<object>();
            Array array = (Array)arrayObject;

            for (int i = 0; i < ((Array)arrayObject).Length; i++)
            {
                dataList.Add(new object[] { array.GetValue(i) });
            }

            return dataList.ToArray();
        }

        private static void SetCommonData<T>(string testDataFileName, T instance)
        {
            string usingPhrase = GetFirstUsingLine(testDataFileName);
            string[] testDataPropertyNames = new string[] { "InputData", "ExpectedData" };

            if (String.IsNullOrEmpty(usingPhrase))
                return;

            string commonDataFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\CommonInputData.json");
            CommonTestData[] commonTestData = Deserialize<CommonTestData[]>(commonDataFile);

            if (typeof(T).IsArray)
            {
                for (int i = 0; i < ((Array)(object)instance).Length; i++)
                {
                    if (i < commonTestData.Length)
                    {
                        var commonDataItem = commonTestData[i];
                        var testDataItem = ((Array)(object)instance).GetValue(i);

                        SetTestDataProperty(commonDataItem, testDataItem, testDataPropertyNames);
                    }
                }
            }
            else
            {
                if (commonTestData.Length > 0)
                {
                    var commonDataItem = commonTestData[0];
                    var testDataItem = instance;

                    SetTestDataProperty(commonDataItem, testDataItem, testDataPropertyNames);
                }
            }
        }

        private static void SetTestDataProperty(CommonTestData commonDataItem, object testDataItem, string[] propertyNames)
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;

            foreach (string propertyName in propertyNames)
            {
                var commonDataPropertyValue = commonDataItem.GetType().GetProperty(propertyName).GetValue(commonDataItem, null);
                if (commonDataPropertyValue != null)
                {
                    foreach (var commonProperty in commonDataPropertyValue.GetType().GetProperties(flags))
                    {
                        var testDataProperty = testDataItem.GetType().GetProperty(propertyName);
                        var testDataPropertyValue = testDataProperty.GetValue(testDataItem, null);

                        var testDataPropertyProperty = testDataProperty.PropertyType.GetProperty(commonProperty.Name, flags);
                        //var testDataPropertyProtertyValue = testDataPropertyProperty.GetValue(testDataPropertyValue, null);

                        if (testDataPropertyProperty != null)
                        {
                            testDataPropertyProperty.SetValue(testDataPropertyValue, commonProperty.GetValue(commonDataPropertyValue, null).ToString(), null);
                        }
                    }
                }
            }
        }

        private static string GetFirstUsingLine(string testDataFileName)
        {
            string result = String.Empty;

            using (StreamReader reader = new StreamReader(testDataFileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.Trim().StartsWith("/*using "))
                    {
                        result = line;
                        break;
                    }

                    if (line.Trim().Contains("[") || line.Trim().Contains("{"))
                        break;
                }

                reader.Close();
            }

            return result;
        }
        #endregion
    }

    public static class LanguageHelper
    {
        private const string KEYFORMATSIMPLE = "\\$\\@(.+)\""; //$@common.message.test
        private const string KEYFORMATPARAMETERED = "\\$\\@(.+)\\|(\\(.+\\),?)+"; //$@common.message.test|(a),(b),(c)
        private const string INRESOURCEKEY = @"##(\w|\.)+##"; //##Common.Glossary.Dashboard##

        public static string ReplaceRawTestData(string raw)
        {
            MatchCollection parameteredMatches = MatchLanguageKeys(raw, KEYFORMATPARAMETERED);

            foreach (Match match in parameteredMatches)
            {
                string key = match.Groups[1].Value;
                string value = ResolveResourceValue(key);

                string[] parameters = match.Groups[2].Value.Split(',');
                for (int i = 0; i < parameters.Length; i++)
                {
                    string paramValue = parameters[i].Replace("(", "").Replace(")", "").Replace("\"", "\\\"");
                    value = Regex.Replace(value, @"\{" + i.ToString() + @"\}", paramValue);
                }

                raw = raw.Replace(match.Groups[0].Value, value);
            }

            MatchCollection simpleMatches = MatchLanguageKeys(raw, KEYFORMATSIMPLE);

            foreach (Match match in simpleMatches)
            {
                string key = match.Groups[1].Value;
                string value = ResolveResourceValue(key); //process value if it contains recursive definitions

                value = value.Replace("\"", "\\\"");

                raw = raw.Replace("$@" + key, value);
            }

            //throw new Exception(raw);
            return raw;
        }

        private static MatchCollection MatchLanguageKeys(string raw,string regex)
        {
            MatchCollection matches = Regex.Matches(raw, regex, RegexOptions.Multiline);

            return matches;
        }

        private static string ResolveResourceValue(string key)
        {
            string value = Lookup(key);

            MatchCollection matches = Regex.Matches(value, INRESOURCEKEY);

            foreach (Match match in matches)
            {
                string innerKey = match.Value.Replace("#", String.Empty);

                value = value.Replace(match.Value, ResolveResourceValue(innerKey));
            }

            return value;
        }

        private static string Lookup(string key)
        {
            return LanguageResourceRepository.ResourceDictionary[key.Replace("I18N.", String.Empty)]; 
        }
    }
}