using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Mento.TestApi.TestData
{
    public static class TestContextExtend
    {
        private static object _testData;

        public static T GetTestData<T>(this TestContext context)
        {
            if (_testData == null)
                _testData = TestDataRepository.GetTestData<T>(context.Test.Properties["CaseID"].ToString(), context.Test.FullName);

            return (T)_testData;
        }
    }
}