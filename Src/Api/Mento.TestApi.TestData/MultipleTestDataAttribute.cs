using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Reflection;
using Mento.Utility;

namespace Mento.TestApi.TestData
{
    /// <summary>
    /// Mark that the target test script is going to be run for one of the loaded test data
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class MultipleTestDataAttribute : TestCaseAttribute
    {
        /// <summary>
        /// Load the test data for the specified test script
        /// </summary>
        /// <param name="testDataType">The specified test data type</param>
        /// <param name="testSuiteType">Type of test suite of the target test scipt</param>
        /// <param name="testCaseID">Test case id of the target test script</param>
        /// <param name="dataIndex">Element index of the test data array, which will be passed to the test script as its parameter.</param>
        public MultipleTestDataAttribute(Type testDataType, Type testSuiteType, string testCaseID, int dataIndex)
        {
            var testData = TestDataRepository.GetTestDataElement(testDataType, testSuiteType, testCaseID, dataIndex);

            ReflectionHelper.SetPrivateFieldValue(this, typeof(TestCaseAttribute), "arguments", testData);
        }
    }
}