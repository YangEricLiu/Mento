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
    [Owner("Emma")]
    [CreateTime("2013-05-30")]
    [ManualCaseID("TC-J1-FVT-PtagConfiguration-Modify-001")]
    public class ModifyInvalidPtagSuite : TestSuiteBase
    {
        private PTagSettings PTagSettings = JazzFunction.PTagSettings;

        [SetUp]
        public void CaseSetUp()
        {
            PTagSettings.PTagSettingCaseSetUp();
        }

        [TearDown]
        public void CaseTearDown()
        {
            PTagSettings.PTagSettingCaseTearDown();
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Modify-001-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyInvalidPtagSuite), "TC-J1-FVT-PtagConfiguration-Modify-001-1")]
        public void ModifyThenCancel(PtagData input)
        {
            //Click "Modify" button and input nothing to ptag field
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagSettings.ClickModifyButton();
            PTagSettings.FillInPtag(input.InputData);

            //Click "Cancel" button
            PTagSettings.ClickCancelButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify modify successful
            Assert.IsFalse(PTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(PTagSettings.IsCancelButtonDisplayed());

            //Verify that ptag not changed
            Assert.IsTrue(PTagSettings.FocusOnPTagByName(input.InputData.OriginalName));
            Assert.IsFalse(PTagSettings.FocusOnPTagByName(input.InputData.CommonName));

            //Verify the ptag not changed
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagSettings.WaitPtagPropertyInfoDisplay(10);
            TimeManager.MediumPause();
            Assert.AreEqual(input.ExpectedData.CommonName, PTagSettings.GetNameValue());
            Assert.AreEqual(input.ExpectedData.Code, PTagSettings.GetCodeValue());
            Assert.AreEqual(input.ExpectedData.Meter, PTagSettings.GetMetercodeValue());
            Assert.AreEqual(input.ExpectedData.Channel, PTagSettings.GetChannelIdValue());
            Assert.AreEqual(PTagSettings.GetCommodityExpectedValue(input.ExpectedData.Commodity), PTagSettings.GetCommodityValue());
            Assert.AreEqual(PTagSettings.GetUomExpectedValue(input.ExpectedData.Uom), PTagSettings.GetUomValue());
            Assert.AreEqual(PTagSettings.GetCalculationTypeExpectedValue(input.ExpectedData.CalculationType), PTagSettings.GetCalculationTypeValue());
            Assert.AreEqual(PTagSettings.GetCollectCycleExpectedValue(input.InputData.CollectCycle), PTagSettings.GetCollectCycleValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Modify-001-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyInvalidPtagSuite), "TC-J1-FVT-PtagConfiguration-Modify-001-2")]
        public void ModifySameNameUnderAssocoationNode(PtagData input)
        {
            //Click "Modify" button and input nothing to ptag field
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagSettings.ClickModifyButton();
            PTagSettings.FillInPtag(input.InputData);

            //Click "Save" button
            PTagSettings.ClickSaveButton();
            TimeManager.LongPause();

            //verify modify successful
            Assert.IsTrue(PTagSettings.IsSaveButtonDisplayed());
            Assert.IsTrue(PTagSettings.IsCancelButtonDisplayed());
            TimeManager.LongPause();
            //Verify the error message display "该名称已存在"
            Assert.IsTrue(PTagSettings.IsNameInvalid());
            Assert.IsTrue(PTagSettings.IsNameInvalidMsgCorrect(input.ExpectedData));
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Modify-001-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyInvalidPtagSuite), "TC-J1-FVT-PtagConfiguration-Modify-001-3")]
        public void ModifySameCommodityUnderAssocoationNode(PtagData input)
        {
            //Click "Modify" button and input nothing to ptag field
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagSettings.ClickModifyButton();
            PTagSettings.FillInPtag(input.InputData);

            //Click "Save" button
            PTagSettings.ClickSaveButton();
            TimeManager.ShortPause();

            //verify modify successful
            Assert.IsTrue(PTagSettings.IsSaveButtonDisplayed());
            Assert.IsTrue(PTagSettings.IsCancelButtonDisplayed());

            //Verify the error message display "对应节点下已存在相同介质的能耗数据点。"
            Assert.IsTrue(PTagSettings.IsCommodityInvalidMsgCorrect(input.ExpectedData));
        }
    }
}
