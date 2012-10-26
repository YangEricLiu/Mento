using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Utility;

namespace Mento.TestApi.TestData
{
    public class MultipleTestDataSourceAttribute : TestCaseSourceAttribute
    {
        public MultipleTestDataSourceAttribute(Type testDataType, Type testSuiteType, string testCaseID) :
            base(GetSourceType(testDataType, testSuiteType, testCaseID), "TestData")
        {
        }

        private static Type GetSourceType(Type testDataType, Type testSuiteType, string testCaseID)
        {
            MultipleTestDataSourceLoader.TestCaseID = testCaseID;
            MultipleTestDataSourceLoader.TestDataType = testDataType;
            MultipleTestDataSourceLoader.TestSuiteType = testSuiteType;

            return typeof(MultipleTestDataSourceLoader);
        }
    }

    public static class MultipleTestDataSourceLoader
    {
        public static Type TestDataType { get; set; }
        public static Type TestSuiteType { get; set; }
        public static string TestCaseID { get; set; }

        public static object[] TestData
        {
            get
            {
                return TestDataRepository.GetTestDataElementArray(TestDataType, TestSuiteType, TestCaseID);
            }
        }
    }
}
