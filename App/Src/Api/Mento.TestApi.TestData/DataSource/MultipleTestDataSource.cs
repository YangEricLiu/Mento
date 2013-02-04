using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.TestData
{
    /// <summary>
    /// Act as test data source, loads test data according to the set properties
    /// </summary>
    internal static class MultipleTestDataSource
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
