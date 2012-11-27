using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using System.IO;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Customer;

namespace Mento.Script.Customer.Tag
{
    public class PtagConfiguration : TestSuiteBase
    {
        [TestFixtureSetUp]
        public void CaseFixtureSetUp()
        {
            ElementLocator.OpenJazz();
            FunctionWrapper.Login.Login();
        }

        [TestFixtureTearDown]
        public void CaseFixtureTearDown()
        {
            //ElementLocator.QuitJazz();
        }

        [SetUp]
        public void CaseSetUp()
        {
            FunctionWrapper.Ptag.NavigatorToPtagSetting();
            ElementLocator.Pause(2000);
        }

        [TearDown]
        public void CaseTearDown()
        {
            //
        }

        [Test]
        [CaseID("TA-PtagConfiguration-001"), CreateTime("2012-11-12"), Owner("Amy")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(PtagConfiguration), "TA-PtagConfiguration-001")]
        public void AddPtag(PtagData testData)
        {
            FunctionWrapper.Ptag.PrepareToAddPtag();
            FunctionWrapper.Ptag.FillInPtag(testData.InputData);
            FunctionWrapper.Ptag.ClickSaveButton();

            ElementLocator.Pause(500);
            FunctionWrapper.Ptag.FocusOnTag(testData.ExpectedData.Name);
            Assert.AreEqual(testData.ExpectedData.Name, FunctionWrapper.Ptag.GetNameValue());
            Assert.AreEqual(testData.InputData.Code, FunctionWrapper.Ptag.GetCodeValue());
            Assert.AreEqual(testData.InputData.MeterCode, FunctionWrapper.Ptag.GetMeterCodeValue());
            Assert.AreEqual(testData.InputData.ChannelId, FunctionWrapper.Ptag.GetChannelIdValue());
            Assert.AreEqual(FunctionWrapper.Ptag.GetCommodityExpectedValue(testData.InputData.CommodityId), FunctionWrapper.Ptag.GetCommodityValue());
            Assert.AreEqual(FunctionWrapper.Ptag.GetUomExpectedValue(testData.InputData.UomId), FunctionWrapper.Ptag.GetUomValue());
            Assert.AreEqual(FunctionWrapper.Ptag.GetCalculationTypeExpectedValue(testData.InputData.CalculationType), FunctionWrapper.Ptag.GetCalculationTypeValue());
            Assert.AreEqual(testData.InputData.Comment, FunctionWrapper.Ptag.GetCommentValue());
        }

        [Test]
        [CaseID("TA-PtagConfiguration-002"), CreateTime("2012-11-13"), Owner("Amy")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(PtagConfiguration), "TA-PtagConfiguration-002")]
        public void ModifyPtag(PtagData testData)
        {
            string tagName = "tagformodification";
            FunctionWrapper.Ptag.PrepareToModifyPtag(tagName);
            FunctionWrapper.Ptag.FillInCode(testData.InputData.Code);
            FunctionWrapper.Ptag.ClickSaveButton();

            FunctionWrapper.WaitForLoadingDisappeared(2000);
            ElementLocator.Pause(500);

            FunctionWrapper.Ptag.FocusOnTag(tagName);
            Assert.AreEqual(testData.ExpectedData.Code, FunctionWrapper.Ptag.GetCodeValue());            
        }
    }
}
