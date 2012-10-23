using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Mento.TestApi.TestData
{
    public static class TestContextExtend
    {
        public static T GetTestData<T>(this TestContext context)
        {
            return TestDataRepository.GetTestData<T>(context.Test.Properties["CaseID"].ToString(), context.Test.FullName);
        }
    }
}