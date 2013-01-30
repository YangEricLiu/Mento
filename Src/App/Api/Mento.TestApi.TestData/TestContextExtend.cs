using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Mento.TestApi.TestData
{
    /// <summary>
    /// Extending class for <see cref="TestContext" />
    /// </summary>
    public static class TestContextExtend
    {
        private static Dictionary<string,object> _testData;

        /// <summary>
        /// Get test data for the current test script.
        /// </summary>
        /// <typeparam name="T">Generic type of the expected test data to be loaded.</typeparam>
        /// <param name="context"></param>
        /// <returns>Test data instance of the current test script.</returns>
        public static T GetTestData<T>(this TestContext context)
        {
            string testCaseID = context.Test.Properties["CaseID"].ToString();
            string testScriptName = context.Test.FullName;
            if (_testData == null)
            {
                _testData = new Dictionary<string, object>();
            }
            if (!_testData.Keys.Contains(testCaseID))
            {
                _testData.Add(testCaseID, TestDataRepository.GetTestData<T>(testCaseID, testScriptName));
            }

            return (T)_testData[testCaseID];
        }
    }
}