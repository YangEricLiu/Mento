using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Mento.TestApi.TestData
{
    public static class TestContextExtend
    {
        public static T GetTestData<T>(this TestContext context) where T : TestDataBase
        {
            object testName = context.Test.FullName;

            return (T)testName;
        }
    }
}