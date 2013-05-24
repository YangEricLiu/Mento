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

namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [Owner("Amy")]
    [CreateTime("2012-11-12")]
    [ManualCaseID("TC-J1-SmokeTest-002")]
    public class SmokeTestPtagConfigurationSuite : TestSuiteBase
    {
        private PTagSettings PTagSettings = JazzFunction.PTagSettings;

        [SetUp]
        public void CaseSetUp()
        {   
            PTagSettings.NavigatorToPtagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-002-001")]
        [Type("BVT")]
        [Priority("17")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(SmokeTestPtagConfigurationSuite), "TC-J1-SmokeTest-002-001")]
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

        [Test]
        [CaseID("TA-PtagConfiguration-002")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(SmokeTestPtagConfigurationSuite), "TA-PtagConfiguration-002")]
        public void ModifyPtag(PtagData testData)
        {
            //string tagName = "tagformodification";
            string tagName = "Amy_Ptag1_Code";
            PTagSettings.PrepareToModifyPtag(tagName);
            PTagSettings.FillInCode(testData.InputData.Code);
            PTagSettings.ClickSaveButton();

            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            PTagSettings.FocusOnPTag(tagName);
            Assert.AreEqual(testData.ExpectedData.Code, PTagSettings.GetCodeValue());            
        }
    }
}
