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
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.TestScript.TagManagement
{
    [TestFixture]
    [Owner("Eric")]
    [CreateTime("2013-05-10")]
    [ManualCaseID("TA-Smoke-Tag-001")]
    public class PtagConfigurationSuite : TestSuiteBase
    {
        private PTagSettings PTagSettings = JazzFunction.PTagSettings;

        [SetUp]
        public void CaseSetUp()
        {
            JazzBrowseManager.RefreshJazz();
            JazzFunction.LoginPage.SelectCustomer("Auto_Customer");

            PTagSettings.NavigatorToPtagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            
        }

        [Test]
        [Owner("Eric")]
        [CaseID("TA-Smoke-Tag-001-001")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(PtagConfigurationSuite), "TA-Smoke-Tag-001-001")]
        public void AddPtag(PtagData testData)
        {
            PTagSettings.PrepareToAddPtag();
            PTagSettings.FillInPtag(testData.InputData);
            PTagSettings.ClickSaveButton();

            TimeManager.MediumPause();

            PTagSettings.FocusOnPTag(testData.ExpectedData.Name);
            Assert.AreEqual(testData.ExpectedData.Name, PTagSettings.GetNameValue());
            Assert.AreEqual(testData.InputData.Code, PTagSettings.GetCodeValue());
            Assert.AreEqual(testData.InputData.MeterCode, PTagSettings.GetMeterCodeValue());
            Assert.AreEqual(testData.InputData.ChannelId, PTagSettings.GetChannelIdValue());
            Assert.AreEqual(PTagSettings.GetCommodityExpectedValue(testData.InputData.Commodity), PTagSettings.GetCommodityValue());
            Assert.AreEqual(PTagSettings.GetUomExpectedValue(testData.InputData.Uom), PTagSettings.GetUomValue());
            Assert.AreEqual(PTagSettings.GetCalculationTypeExpectedValue(testData.InputData.CalculationType), PTagSettings.GetCalculationTypeValue());
            Assert.AreEqual(testData.InputData.Comment, PTagSettings.GetCommentValue());
        }
    }
}
