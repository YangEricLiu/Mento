using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Administration;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Administration.TOU
{
    [TestFixture]
    [Owner("Amy")]
    [CreateTime("2013-03-13")]    
    public class TOUBasicTariffModifyInvalidSuite : TestSuiteBase
    {
        private static TOUBasicTariffSettings TOUBasicTariffSettings = JazzFunction.TOUBasicTariffSettings;
        [SetUp]
        public void CaseSetUp()
        {
            TOUBasicTariffSettings.NavigatorToPriceSettings();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
            //TimeManager.MediumPause();
        }

        #region TestCase1 ModifyTOUCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-001")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-001")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffModifyInvalidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Modify-001")]
        public void ModifyTOUCancelled(TOUBasicTariffData testData)
        {
            //Select a TOU
            TOUBasicTariffSettings.SelectTOU(testData.ExpectedData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();
            TimeManager.ShortPause();

            //Click "Save" button directly without any change
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //Click 'Modify' button
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();
            TimeManager.ShortPause();

            ///Change name with valid input
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);

            //Click 'x' icon to delete valley2
            TOUBasicTariffSettings.ClickDeleteValleyRangeItemButton(2);

            //Click "Cancel" button
            TOUBasicTariffSettings.ClickBasicPropertyCancelButton();
            TimeManager.MediumPause();

            //verify that the modification is cancelled and original information still displayes.
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertySaveButtonDisplayed());
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertyCancelButtonDisplayed());
            Assert.IsTrue(TOUBasicTariffSettings.IsBasicPropertyModifyButtonDisplayed());
            Assert.IsTrue(TOUBasicTariffSettings.IsTOUExist(testData.ExpectedData.CommonName));
            Assert.AreEqual(testData.InputData.ValleyRange[1].StartTime, TOUBasicTariffSettings.GetBasicPropertyValleyStartTimeValue(2));
            Assert.AreEqual(testData.InputData.ValleyRange[1].EndTime, TOUBasicTariffSettings.GetBasicPropertyValleyEndTimeValue(2));

            TimeManager.MediumPause();

        }
        #endregion

        #region TestCase2 ModifyWithRequiredFieldsEmpty
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-002")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-002")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffModifyInvalidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Modify-002")]
        public void ModifyWithRequiredFieldsEmpty(TOUBasicTariffData testData)
        {
            //Select a TOU
            TOUBasicTariffSettings.SelectTOU("价格ForModifyInvalid");
            TimeManager.ShortPause();

            //Click 'Modify' button            
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();
            TimeManager.ShortPause();

            //Change required fields to be empty.
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //Verify that Error message '必填项' is displayed below each required fields: '名称',  '峰时电价',  '谷时电价'. There is no message below '平时电价'.
            Assert.IsTrue(TOUBasicTariffSettings.IsNameInvalid());
            Assert.IsTrue(TOUBasicTariffSettings.IsNameInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsFalse(TOUBasicTariffSettings.IsPlainPriceInvalid());
            Assert.IsTrue(TOUBasicTariffSettings.IsPlainPriceInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(TOUBasicTariffSettings.IsPeakPriceInvalid());
            Assert.IsTrue(TOUBasicTariffSettings.IsPeakPriceInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(TOUBasicTariffSettings.IsValleyPriceInvalid());
            Assert.IsTrue(TOUBasicTariffSettings.IsValleyPriceInvalidMsgCorrect(testData.ExpectedData));

            TOUBasicTariffSettings.ClickBasicPropertyCancelButton();
            TimeManager.ShortPause();
        }
        #endregion

        #region TestCase3 ModifyWithDuplicatedName
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-003")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-003")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffModifyInvalidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Modify-003")]
        public void ModifyWithDuplicatedName(TOUBasicTariffData testData)
        {
            //Select a TOU
            TOUBasicTariffSettings.SelectTOU("价格ForModifyInvalid");
            TimeManager.ShortPause();

            //Click 'Modify' button            
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();
            TimeManager.ShortPause();

            //Input same Name just as the existing one, Other fields are all valid.
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();  

            //Verify that Error message is displayed below '名称' field.
            Assert.IsTrue(TOUBasicTariffSettings.IsNameInvalid());
            Assert.IsTrue(TOUBasicTariffSettings.IsNameInvalidMsgCorrect(testData.ExpectedData));

            TOUBasicTariffSettings.ClickBasicPropertyCancelButton();
            TimeManager.ShortPause();

        }
        #endregion

        #region TestCase4 ModifyWithConflictedRanges
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-004")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-004")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffModifyInvalidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Modify-004")]
        public void ModifyWithConflictedRanges(TOUBasicTariffData testData)
        {
            //Select a TOU
            TOUBasicTariffSettings.SelectTOU(testData.InputData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button            
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();
            TimeManager.ShortPause();

            //modify end time of peak rangeIndustry so that it is overlapped with valley rangeIndustry.
            TOUBasicTariffSettings.SelectBasicPropertyPeakEndTime(testData.InputData.PeakRange[0].EndTime, 1);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //Verify the messages below the fields. 
            Assert.IsTrue(TOUBasicTariffSettings.IsPeakRangeInvalidMsgCorrect(testData.ExpectedData, 1));
            Assert.IsTrue(TOUBasicTariffSettings.IsValleyRangeInvalidMsgCorrect(testData.ExpectedData, 1));

            TOUBasicTariffSettings.ClickBasicPropertyCancelButton();
            TimeManager.ShortPause();

        }
        #endregion

        #region TestCase5 ModifyToNotCover24Hours
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-005")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-005")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffModifyInvalidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Modify-005")]
        public void ModifyToNotCover24Hours(TOUBasicTariffData testData)
        {
            //Select TOUIndustry
            TOUBasicTariffSettings.SelectTOU("价格ForModifyToNotCover24h1");
            TimeManager.ShortPause();

            //Click 'Modify' button            
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();
            TimeManager.ShortPause();

            //Change plain price to be empty
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //Verify that Error message is displayed below time range field.
            Assert.IsTrue(TOUBasicTariffSettings.IsTOU24HoursMsgCorrect(testData.ExpectedData.PlainPrice));

            //Click "Cancel" button
            TOUBasicTariffSettings.ClickBasicPropertyCancelButton();
            TimeManager.MediumPause();

            //Select TOU2
            TOUBasicTariffSettings.SelectTOU("价格ForModifyToNotCover24h2");
            TimeManager.ShortPause();

            //Click 'Modify' button            
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();
            TimeManager.ShortPause();

            //Click 'x' icons to delete some ranges (e.g. delete valley2)
            TOUBasicTariffSettings.ClickDeleteValleyRangeItemButton(2);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //Verify that Error message is displayed below time range field.
            Assert.IsTrue(TOUBasicTariffSettings.IsTOU24HoursMsgCorrect(testData.ExpectedData.PlainPrice));

            //Click "Cancel" button
            TOUBasicTariffSettings.ClickBasicPropertyCancelButton();
            TimeManager.MediumPause();

            //Select TOU2 again
            TOUBasicTariffSettings.SelectTOU("价格ForModifyToNotCover24h2");
            TimeManager.ShortPause();

            //Click 'Modify' button            
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();
            TimeManager.ShortPause();

            //Change one range with new time so that all ranges didn't cover 24 hours. (e.g. Change start time of peak1)
            TOUBasicTariffSettings.SelectBasicPropertyPeakStartTime(testData.InputData.PeakRange[0].StartTime, 1);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //Verify that Error message is displayed below time range field.
            Assert.IsTrue(TOUBasicTariffSettings.IsTOU24HoursMsgCorrect(testData.ExpectedData.PlainPrice));

            //Click "Cancel" button
            TOUBasicTariffSettings.ClickBasicPropertyCancelButton();
            TimeManager.MediumPause();
        }
        #endregion

    }
}
