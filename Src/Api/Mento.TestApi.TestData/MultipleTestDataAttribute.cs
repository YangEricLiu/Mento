using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Reflection;
using Mento.Utility;

namespace Mento.TestApi.TestData
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class MultipleTestDataAttribute : TestCaseAttribute
    {
        //Type inputDatatype,Type expectedDataType, int inputDataIndex, int expectedDataIndex
        public MultipleTestDataAttribute(Type testDataType, int inputDataIndex, int expectedDataIndex, Type testSuiteType, string testCaseID)
        {
            var testData = TestDataRepository.GetTestDataElement(testDataType, inputDataIndex, expectedDataIndex, testSuiteType, testCaseID);

            ReflectionHelper.SetPrivateFieldValue(this, typeof(TestCaseAttribute), "arguments", testData);
        }
    }
}