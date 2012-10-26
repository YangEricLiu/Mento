﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using Mento.Framework.Constants;
using System.Xml.Linq;
using Mento.Utility;
using System.Reflection;

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

        public static object[] GetTestDataElement(Type testDataType, int inputDataIndex, int expectedDataIndex, Type testSuiteType, string testCaseID)
        {
            PropertyInfo InputTestDataProperty = testDataType.GetProperty("InputData", BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo ExpectedTestDataProperty = testDataType.GetProperty("ExpectedData", BindingFlags.Public | BindingFlags.Instance);

            //Type InputTestDataType = InputTestDataProperty.PropertyType.GetElementType();
            //Type ExpectedTestDataType = ExpectedTestDataProperty.PropertyType.GetElementType();

            //var inputTestData = Activator.CreateInstance(InputTestDataType, 1, 2);
            //var expectedTestData = Activator.CreateInstance(ExpectedTestDataType, 3);

            MethodInfo getTestDataMethod = typeof(TestDataRepository).GetMethod("GetTestData", BindingFlags.Public | BindingFlags.Static);

            MethodInfo genericGetTestDataMethod = getTestDataMethod.MakeGenericMethod(testDataType);

            //PropertyInfo CurrentContextProperty = typeof(TestContext).GetProperty("CurrentContext", BindingFlags.Public | BindingFlags.Static);

            object testData = genericGetTestDataMethod.Invoke(null, new object[] { /*testCaseID*/testCaseID, /*testScriptFullName*/String.Format("{0}.{1}", testSuiteType.FullName, testCaseID) });

            //var inputTestData = InputTestDataProperty.GetValue(testData, new object[] { inputDataIndex });
            //var expectedTestData = ExpectedTestDataProperty.GetValue(testData, new object[] { expectedDataIndex });
            var inputTestData = (Array)InputTestDataProperty.GetValue(testData, null);
            var expectedTestData = (Array)ExpectedTestDataProperty.GetValue(testData, null);

            return new object[] { inputTestData.GetValue(inputDataIndex), expectedTestData.GetValue(expectedDataIndex) };
        }
        
        public static object[] GetTestDataElementArray(Type testDataType, Type testSuiteType, string testCaseID)
        {
            PropertyInfo InputTestDataProperty = testDataType.GetProperty("InputData", BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo ExpectedTestDataProperty = testDataType.GetProperty("ExpectedData", BindingFlags.Public | BindingFlags.Instance);

            //Type InputTestDataType = InputTestDataProperty.PropertyType.GetElementType();
            //Type ExpectedTestDataType = ExpectedTestDataProperty.PropertyType.GetElementType();

            //var inputTestData = Activator.CreateInstance(InputTestDataType, 1, 2);
            //var expectedTestData = Activator.CreateInstance(ExpectedTestDataType, 3);

            MethodInfo getTestDataMethod = typeof(TestDataRepository).GetMethod("GetTestData", BindingFlags.Public | BindingFlags.Static);

            MethodInfo genericGetTestDataMethod = getTestDataMethod.MakeGenericMethod(testDataType);

            //PropertyInfo CurrentContextProperty = typeof(TestContext).GetProperty("CurrentContext", BindingFlags.Public | BindingFlags.Static);
            //LogHelper.LogDebug(String.Format("{0}-{1}", testSuiteType.Namespace, testCaseID));
            object testData = genericGetTestDataMethod.Invoke(null, new object[] { /*testCaseID*/testCaseID, /*testScriptFullName*/String.Format("{0}.{1}", testSuiteType.FullName, testCaseID) });

            //var inputTestData = InputTestDataProperty.GetValue(testData, new object[] { inputDataIndex });
            //var expectedTestData = ExpectedTestDataProperty.GetValue(testData, new object[] { expectedDataIndex });
            var inputTestData = (Array)InputTestDataProperty.GetValue(testData, null);
            var expectedTestData = (Array)ExpectedTestDataProperty.GetValue(testData, null);

            List<object> testDataList = new List<object>();

            for (int i = 0; i < Math.Max(inputTestData.Length, expectedTestData.Length); i++)
            {
                object inputObject = null, expectedObject = null;

                if (i < inputTestData.Length)
                    inputObject = inputTestData.GetValue(i);
                if (i < expectedTestData.Length)
                    expectedObject = expectedTestData.GetValue(i);

                testDataList.Add(new object[] { inputObject, expectedObject });
            }

            return testDataList.ToArray();
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


                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);

                //return JsonHelper.String2Object<T>(content);
            }

            return default(T);
        }
    }
}