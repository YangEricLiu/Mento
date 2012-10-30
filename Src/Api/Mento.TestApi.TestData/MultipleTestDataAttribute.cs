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
        public MultipleTestDataAttribute(Type testDataType, Type testSuiteType, string testCaseID, int dataIndex)
        {
            var testData = TestDataRepository.GetTestDataElement(testDataType, testSuiteType, testCaseID, dataIndex);

            ReflectionHelper.SetPrivateFieldValue(this, typeof(TestCaseAttribute), "arguments", testData);
        }
    }
}