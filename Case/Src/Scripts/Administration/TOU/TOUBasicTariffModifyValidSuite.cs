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
    public class TOUBasicTariffModifyValidSuite : TestSuiteBase
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

        #region TestCase1 ModifyTOUBasicFields
        /// <summary>
        /// Pre-condition: Prepare a TOUIndustry with name '价格未被引用ForModifyValid', make sure it is NOT being used by any hierarchy node.
        /// Pre-condition: Prepare a TOU2 with name '价格已被引用ForModifyValid', make sure it has been used by a hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-101")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-101")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffModifyValidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Modify-101")]
        public void ModifyTOUBasicFields(TOUBasicTariffData testData)
        {
            //Select the TOU (Both of TOUIndustry and TOU2 can be modified).
            TOUBasicTariffSettings.SelectTOU(testData.InputData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button            
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();
            TimeManager.ShortPause();
            
            //Modify the basic fields (Name, PlainPrice, PeakPrice, ValleyPrice) with new values
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.ExpectedData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.ExpectedData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.ExpectedData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.ExpectedData.ValleyPrice);            

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //verify modification is successful
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertySaveButtonDisplayed());
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertyCancelButtonDisplayed());
            Assert.IsTrue(TOUBasicTariffSettings.IsBasicPropertyModifyButtonDisplayed());
            TOUBasicTariffSettings.SelectTOU(testData.ExpectedData.CommonName);
            Assert.AreEqual(testData.ExpectedData.CommonName, TOUBasicTariffSettings.GetBasicPropertyNameValue());
            Assert.AreEqual(testData.ExpectedData.PlainPrice, TOUBasicTariffSettings.GetBasicPropertyPlainPriceValue());
            Assert.AreEqual(testData.ExpectedData.PeakPrice, TOUBasicTariffSettings.GetBasicPropertyPeakPriceValue());
            Assert.AreEqual(testData.ExpectedData.ValleyPrice, TOUBasicTariffSettings.GetBasicPropertyValleyPriceValue());

        }
        #endregion

        #region TestCase2 ModifyPlainPriceToBeEmpty
        /// <summary>
        /// Pre-condition: Prepare a TOU with name '价格ForModifyPlainPriceToEmpty', make sure its PlainPrice is Not empty, and 峰时范围 + 谷时范围 cover 24 hours.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-102")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-102")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffModifyValidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Modify-102")]
        public void ModifyPlainPriceToBeEmpty(TOUBasicTariffData testData)
        {
            //Select the TOU.
            TOUBasicTariffSettings.SelectTOU(testData.InputData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button            
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();
            TimeManager.ShortPause();

            //Modify plain price field to be empty
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify modification is successful and the plain price is not displayed in view mode.
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertySaveButtonDisplayed());
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertyCancelButtonDisplayed());
            Assert.IsTrue(TOUBasicTariffSettings.IsPlainPriceHidden());

            //Verify the plain price is displayed as null in edit mode.
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();
            TimeManager.ShortPause();
            Assert.AreEqual(testData.InputData.PlainPrice, TOUBasicTariffSettings.GetBasicPropertyPlainPriceValue());
        }
        #endregion

        #region TestCase3 ModifyTOUTimeRanges
        /// <summary>
        /// Pre-condition: Prepare a TOU with name '价格ForModifyTimeRanges', make sure it has been used by a hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-103")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-103")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffModifyValidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Modify-103")]
        public void ModifyTOUTimeRanges(TOUBasicTariffData testData)
        {
            //Select the TOU.
            TOUBasicTariffSettings.SelectTOU(testData.InputData.CommonName);

            //Click 'Modify' button
            TimeManager.ShortPause();
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();

            //Change start time of peak1,2
            TOUBasicTariffSettings.SelectBasicPropertyPeakStartTime(testData.ExpectedData.PeakRange[0].StartTime, 1);
            TOUBasicTariffSettings.SelectBasicPropertyPeakStartTime(testData.ExpectedData.PeakRange[1].StartTime, 2);
            
            //Change end time of valley1,2;
            TOUBasicTariffSettings.SelectBasicPropertyValleyEndTime(testData.ExpectedData.ValleyRange[0].EndTime, 1);
            TOUBasicTariffSettings.SelectBasicPropertyValleyEndTime(testData.ExpectedData.ValleyRange[1].EndTime, 2);
            
            //Change start/end time of valley3
            TOUBasicTariffSettings.SelectBasicPropertyValleyStartTime(testData.ExpectedData.ValleyRange[2].StartTime, 3);
            TOUBasicTariffSettings.SelectBasicPropertyValleyEndTime(testData.ExpectedData.ValleyRange[2].EndTime, 3);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //verify
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertySaveButtonDisplayed());
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertyCancelButtonDisplayed());
            Assert.AreEqual(testData.ExpectedData.PeakRange[0].StartTime, TOUBasicTariffSettings.GetBasicPropertyPeakStartTimeValue(1));
            Assert.AreEqual(testData.ExpectedData.PeakRange[0].EndTime, TOUBasicTariffSettings.GetBasicPropertyPeakEndTimeValue(1));
            Assert.AreEqual(testData.ExpectedData.PeakRange[1].StartTime, TOUBasicTariffSettings.GetBasicPropertyPeakStartTimeValue(2));
            Assert.AreEqual(testData.ExpectedData.PeakRange[1].EndTime, TOUBasicTariffSettings.GetBasicPropertyPeakEndTimeValue(2));
            Assert.AreEqual(testData.ExpectedData.ValleyRange[0].StartTime, TOUBasicTariffSettings.GetBasicPropertyValleyStartTimeValue(1));
            Assert.AreEqual(testData.ExpectedData.ValleyRange[0].EndTime, TOUBasicTariffSettings.GetBasicPropertyValleyEndTimeValue(1));
            Assert.AreEqual(testData.ExpectedData.ValleyRange[1].StartTime, TOUBasicTariffSettings.GetBasicPropertyValleyStartTimeValue(2));
            Assert.AreEqual(testData.ExpectedData.ValleyRange[1].EndTime, TOUBasicTariffSettings.GetBasicPropertyValleyEndTimeValue(2));
            Assert.AreEqual(testData.ExpectedData.ValleyRange[2].StartTime, TOUBasicTariffSettings.GetBasicPropertyValleyStartTimeValue(3));
            Assert.AreEqual(testData.ExpectedData.ValleyRange[2].EndTime, TOUBasicTariffSettings.GetBasicPropertyValleyEndTimeValue(3));
        }
        #endregion

        #region TestCase4 ModifyTOUToAddMoreTime
        /// <summary>
        /// Pre-condition: Prepare a TOU with name '价格ForModifyToAddMoreTime'.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-104")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-104")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffModifyValidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Modify-104")]
        public void ModifyTOUToAddMoreTime(TOUBasicTariffData testData)
        {
            //Select the TOU.
            TOUBasicTariffSettings.SelectTOU(testData.InputData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button            
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();

            //Click '添加峰时范围''添加谷时范围' links
            TOUBasicTariffSettings.ClickAddMorePeakRangesButton();
            TOUBasicTariffSettings.ClickAddMorePeakRangesButton();
            TOUBasicTariffSettings.ClickAddMoreValleyRangesButton();

            //add more ranges: add peak2,3, valley2.
            TOUBasicTariffSettings.SelectBasicPropertyPeakStartTime(testData.ExpectedData.PeakRange[1].StartTime, 2);
            TOUBasicTariffSettings.SelectBasicPropertyPeakEndTime(testData.ExpectedData.PeakRange[1].EndTime, 2);
            TOUBasicTariffSettings.SelectBasicPropertyPeakStartTime(testData.ExpectedData.PeakRange[2].StartTime, 3);
            TOUBasicTariffSettings.SelectBasicPropertyPeakEndTime(testData.ExpectedData.PeakRange[2].EndTime, 3);
            TOUBasicTariffSettings.SelectBasicPropertyValleyStartTime(testData.ExpectedData.ValleyRange[1].StartTime, 2);
            TOUBasicTariffSettings.SelectBasicPropertyValleyEndTime(testData.ExpectedData.ValleyRange[1].EndTime, 2);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //verify
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertySaveButtonDisplayed());
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertyCancelButtonDisplayed());
            Assert.AreEqual(testData.ExpectedData.PeakRange[1].StartTime, TOUBasicTariffSettings.GetBasicPropertyPeakStartTimeValue(2));
            Assert.AreEqual(testData.ExpectedData.PeakRange[1].EndTime, TOUBasicTariffSettings.GetBasicPropertyPeakEndTimeValue(2));
            Assert.AreEqual(testData.ExpectedData.PeakRange[2].StartTime, TOUBasicTariffSettings.GetBasicPropertyPeakStartTimeValue(3));
            Assert.AreEqual(testData.ExpectedData.PeakRange[2].EndTime, TOUBasicTariffSettings.GetBasicPropertyPeakEndTimeValue(3));
            Assert.AreEqual(testData.ExpectedData.ValleyRange[1].StartTime, TOUBasicTariffSettings.GetBasicPropertyValleyStartTimeValue(2));
            Assert.AreEqual(testData.ExpectedData.ValleyRange[1].EndTime, TOUBasicTariffSettings.GetBasicPropertyValleyEndTimeValue(2));
        }
        #endregion

        #region TestCase5 ModifyTOUToDeleteTimeRange
        /// <summary>
        /// Pre-condition: Prepare a TOU with name '价格ForModifyToDeleteTime', make sure it has been used by a hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-105")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-105")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffModifyValidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Modify-105")]
        public void ModifyTOUToDeleteTimeRange(TOUBasicTariffData testData)
        {
            //Select the TOU with ranges like peakIndustry,2,3 and valleyIndustry,2,3.
            TOUBasicTariffSettings.SelectTOU(testData.InputData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button            
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();

            //Click 'x' icons to delete some ranges (e.g. delete peak2 and valley2)
            TOUBasicTariffSettings.ClickDeletePeakRangeItemButton(2);
            TOUBasicTariffSettings.ClickDeleteValleyRangeItemButton(2);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //verify
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertySaveButtonDisplayed());
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertyCancelButtonDisplayed());

            //verify after delete peak2 and valley2, the original peak3 and valley3 items move up to the second position now.
            Assert.AreEqual(testData.InputData.PeakRange[2].StartTime, TOUBasicTariffSettings.GetBasicPropertyPeakStartTimeValue(2));
            Assert.AreEqual(testData.InputData.PeakRange[2].EndTime, TOUBasicTariffSettings.GetBasicPropertyPeakEndTimeValue(2));
            Assert.AreEqual(testData.InputData.ValleyRange[2].StartTime, TOUBasicTariffSettings.GetBasicPropertyValleyStartTimeValue(2));
            Assert.AreEqual(testData.InputData.ValleyRange[2].EndTime, TOUBasicTariffSettings.GetBasicPropertyValleyEndTimeValue(2));

        }
        #endregion

    }
}
