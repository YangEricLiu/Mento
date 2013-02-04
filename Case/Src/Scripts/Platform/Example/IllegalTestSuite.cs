using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework.Attributes;
using Mento.TestApi.TestData.Attribute;
using Mento.ScriptCommon.TestData.Customer;

namespace Mento.Script.System.Example
{
    [TestFixture]
    [ManualCaseID("TC-J1-Example-001"), CreateTime("2013-02-04"), Owner("Aries")]
    public class IllegalTestSuite
    {
        [IllegalInputValidation(typeof(PtagData[]))]
        public void Example1(PtagData data)
        {
            Assert.IsFalse(String.IsNullOrEmpty(data.InputData.Name));
            Assert.IsFalse(String.IsNullOrEmpty(data.InputData.Code));
        }
    }
}
