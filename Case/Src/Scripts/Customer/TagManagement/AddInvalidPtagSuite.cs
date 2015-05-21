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
using Mento.TestApi.TestData.Attribute;

namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [Owner("Amy")]
    [CreateTime("2012-11-12")]
    [ManualCaseID("TC-J1-FVT-PtagConfiguration-Add-001")]
    public class AddInvalidPtagSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-PtagConfiguration-Add-001-1")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(PtagData[]))]
        public void AddInvalidPtag(PtagData input)
        {
            //Click "+" button and fill ptag field with invalid input
            PTagSettings.ClickAddPtagButton();
            PTagSettings.FillInPtagVerification(input.InputData);
            TimeManager.MediumPause();
            //Click "Save" button
            PTagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //verify add successful
            Assert.IsTrue(PTagSettings.IsSaveButtonDisplayed());
            Assert.IsTrue(PTagSettings.IsCancelButtonDisplayed());

            //Verify that the error message popup and the input field is invalid
            Assert.IsTrue(PTagSettings.IsNameInvalid());
            Assert.IsTrue(PTagSettings.IsNameInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(PTagSettings.IscodeInvalid());
            Assert.IsTrue(PTagSettings.IscodeInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(PTagSettings.IsMeterCodeInvalid());
            Assert.IsTrue(PTagSettings.IsMeterCodeInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(PTagSettings.IsChannelInvalid());
            Assert.IsTrue(PTagSettings.IsChannelInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(PTagSettings.IsSlopeInvalid());
            Assert.IsTrue(PTagSettings.IsSlopeInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(PTagSettings.IsOffsetInvalid());
            Assert.IsTrue(PTagSettings.IsOffsetInvalidMsgCorrect(input.ExpectedData));
            Assert.IsFalse(PTagSettings.IsCommentsInvalid());
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Add-001-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(AddInvalidPtagSuite), "TC-J1-FVT-PtagConfiguration-Add-001-2")]
        public void EmptyField(PtagData input)
        {
            //Click "+" button and fill nothing
            PTagSettings.ClickAddPtagButton();

            //Click "Save" button
            PTagSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //verify add successful
            Assert.IsTrue(PTagSettings.IsSaveButtonDisplayed());
            Assert.IsTrue(PTagSettings.IsCancelButtonDisplayed());

            //Verify that the error message popup and the input field is invalid
            Assert.IsTrue(PTagSettings.IsNameInvalid());
            Assert.IsTrue(PTagSettings.IsNameInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(PTagSettings.IscodeInvalid());
            Assert.IsTrue(PTagSettings.IscodeInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(PTagSettings.IsMeterCodeInvalid());
            Assert.IsTrue(PTagSettings.IsMeterCodeInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(PTagSettings.IsChannelInvalid());
            Assert.IsTrue(PTagSettings.IsChannelInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(PTagSettings.IsCommodityInvalid());
            Assert.IsTrue(PTagSettings.IsCommodityInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(PTagSettings.IsUomInvalid());
            Assert.IsTrue(PTagSettings.IsUomInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(PTagSettings.IsCalculationTypeInvalid());
            Assert.IsTrue(PTagSettings.IsCalculationTypeInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(PTagSettings.IsCollectCycleInvalid());
            Assert.IsTrue(PTagSettings.IsCollectCycleInvalidMsgCorrect(input.ExpectedData));
            Assert.IsFalse(PTagSettings.IsCommentsInvalid());
            Assert.IsFalse(PTagSettings.IsSlopeInvalid());
            Assert.IsFalse(PTagSettings.IsOffsetInvalid());
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Add-001-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(AddInvalidPtagSuite), "TC-J1-FVT-PtagConfiguration-Add-001-3")]
        public void AddSameCode(PtagData input)
        {
            //Click "+" button and fill ptag field with same code
            PTagSettings.ClickAddPtagButton();
            PTagSettings.FillInPtag(input.InputData);

            //Click "Save" button
            PTagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //Verify that the error message popup and the input field is invalid
            Assert.IsTrue(PTagSettings.IscodeInvalid());
            Assert.IsTrue(PTagSettings.IscodeInvalidMsgCorrect(input.ExpectedData));

            //verify add not successful
            Assert.IsTrue(PTagSettings.IsSaveButtonDisplayed());
            Assert.IsTrue(PTagSettings.IsCancelButtonDisplayed());
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Add-001-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(AddInvalidPtagSuite), "TC-J1-FVT-PtagConfiguration-Add-001-4")]
        public void AddThenCancel(PtagData input)
        {
            //Click "+" button and fill ptag field with same code
            PTagSettings.ClickAddPtagButton();
            PTagSettings.FillInPtag(input.InputData);

            //Click "Save" button
            PTagSettings.ClickCancelButton();
            TimeManager.MediumPause();

            //verify add successful
            Assert.IsFalse(PTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(PTagSettings.IsCancelButtonDisplayed());

            //Verify that tag not add
            Assert.IsFalse(PTagSettings.FocusOnPTagByName(input.InputData.CommonName));
        }
    }
}
