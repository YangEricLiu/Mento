using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework.Attributes;
using Mento.TestApi.TestData.Attribute;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.TestData;

namespace Mento.Script.System.Example
{
    [TestFixture]
    [ManualCaseID("TC-J1-Example-001"), CreateTime("2013-02-04"), Owner("Aries")]
    public class IllegalTestSuite
    {
        //[CaseID("TC-J1-Example-001")]
        //[IllegalInputValidation(typeof(PtagData[]))]
        //public void Example1(PtagData data)
        //{
        //    Assert.IsFalse(String.IsNullOrEmpty(data.InputData.Name));
        //    Assert.IsFalse(String.IsNullOrEmpty(data.InputData.code));
        //}

        [CaseID("TC-J1-Example-002")]
        //[IllegalInputValidation(typeof(PtagData[]))]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(IllegalTestSuite), "TC-J1-Example-002")]
        public void Example2(PtagData data)
        {
            //Assert.IsTrue(data.InputData.Comments == "正在进行多时间段对比，请删除该数据点后重新选取");
            Assert.IsFalse(String.IsNullOrEmpty(data.InputData.Comments));
            //Assert.IsFalse(String.IsNullOrEmpty(data.InputData.Code));
        }

        [Test]
        public void AAAA()
        {
            Assert.AreEqual(1,1);
        }
    }
}
