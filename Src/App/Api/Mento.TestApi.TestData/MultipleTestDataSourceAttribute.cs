using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Utility;

namespace Mento.TestApi.TestData
{
    /// <summary>
    /// Mark that the target test script is going to be run for all of the loaded test data
    /// </summary>
    public class MultipleTestDataSourceAttribute : TestCaseSourceAttribute
    {
        /// <summary>
        /// Load the test data source for the specified test script
        /// </summary>
        /// <param name="testDataType">The specified test data type</param>
        /// <param name="testSuiteType">Type of test suite of the target test scipt</param>
        /// <param name="testCaseID">Test case id of the target test script</param>
        public MultipleTestDataSourceAttribute(Type testDataType, Type testSuiteType, string testCaseID) :
            base(GetSourceType(testDataType, testSuiteType, testCaseID), "TestData")
        {
        }

        /// <summary>
        /// Pass parameters to the data source type and get the source type
        /// </summary>
        /// <param name="testDataType">The specified test data type</param>
        /// <param name="testSuiteType">Type of test suite of the target test scipt</param>
        /// <param name="testCaseID">Test case id of the target test script</param>
        /// <returns>The test data source type</returns>
        private static Type GetSourceType(Type testDataType, Type testSuiteType, string testCaseID)
        {
            MultipleTestDataSourceLoader.TestCaseID = testCaseID;
            MultipleTestDataSourceLoader.TestDataType = testDataType;
            MultipleTestDataSourceLoader.TestSuiteType = testSuiteType;

            return typeof(MultipleTestDataSourceLoader);
        }
    }

    /// <summary>
    /// Act as test data source, loads test data according to the set properties
    /// </summary>
    internal static class MultipleTestDataSourceLoader
    {
        /// <summary>
        /// The specified test data type
        /// </summary>
        public static Type TestDataType { get; set; }

        /// <summary>
        /// Type of test suite of the target test scipt
        /// </summary>
        public static Type TestSuiteType { get; set; }

        /// <summary>
        /// Test case id of the target test script
        /// </summary>
        public static string TestCaseID { get; set; }

        /// <summary>
        /// Get test data according to the set properties
        /// </summary>
        public static object[] TestData
        {
            get
            {
                return TestDataRepository.GetTestDataElementArray(TestDataType, TestSuiteType, TestCaseID);
            }
        }
    }
}
