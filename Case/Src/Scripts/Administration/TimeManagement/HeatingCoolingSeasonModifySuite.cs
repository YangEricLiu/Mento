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

namespace Mento.Script.Administration.TimeManagement
{
    [TestFixture]
    [Owner("Amy")]
    [CreateTime("2013-01-04")]
    public class HeatingCoolingSeasonModifySuite : TestSuiteBase
    {
        private static TimeSettingsHeatingCoolingSeason TimeSettingsHeatingCoolingSeason = JazzFunction.TimeSettingsHeatingCoolingSeason;
        [SetUp]
        public void CaseSetUp()
        {
            TimeSettingsHeatingCoolingSeason.NavigatorToHeatingCoolingSeasonCalendarSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {

            TimeManager.MediumPause();
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
            //TimeManager.MediumPause();
        }

        #region TestCase1 ModifyValidHCSeason
        /// <summary>
        /// Pre-condition: Prepare a CalendarIndustry with name '冷暖季未被引用ForModifyValid', make sure it is NOT being used by any hierarchy node.
        /// Pre-condition: Prepare a Calendar2 with name '冷暖季已被引用ForModifyValid', make sure it has been used by a hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementHCSeason-Modify-101")]
        [CaseID("TC-J1-FVT-TimeManagementHCSeason-Modify-101")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(HeatingCoolingSeasonCalendarData[]), typeof(HeatingCoolingSeasonModifySuite), "TC-J1-FVT-TimeManagementHCSeason-Modify-101")]
        public void ModifyValidHCSeason(HeatingCoolingSeasonCalendarData testData)
        {
            //Select the calendar (Both of CalendarIndustry and Calendar2 can be modified).
            TimeSettingsHeatingCoolingSeason.SelectCalendar(testData.InputData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button            
            TimeSettingsHeatingCoolingSeason.ClickModifyButton();
            TimeManager.ShortPause();

            //Modify the Name, add more ranges
            TimeSettingsHeatingCoolingSeason.FillInName(testData.ExpectedData.CommonName);
            TimeSettingsHeatingCoolingSeason.AddColdWarmRanges(testData);

            //Click "Save" button
            TimeSettingsHeatingCoolingSeason.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //verify modification is successful
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsSaveButtonDisplayed());
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsCancelButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsCalendarExist(testData.ExpectedData.CommonName));
            //Verify warm and cold ranges are added successfully.        
            Assert.AreEqual(testData.InputData.ColdWarmRange.Length, TimeSettingsHeatingCoolingSeason.GetColdWarmRangeItemsNumber());
        }
        #endregion

        #region TestCase2 ModifyTimeRange
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementHCSeason-Modify-102")]
        [CaseID("TC-J1-FVT-TimeManagementHCSeason-Modify-102")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(HeatingCoolingSeasonCalendarData[]), typeof(HeatingCoolingSeasonModifySuite), "TC-J1-FVT-TimeManagementHCSeason-Modify-102")]
        public void ModifyTimeRange(HeatingCoolingSeasonCalendarData testData)
        {
            //Select a calendar which has special date ranges.
            TimeSettingsHeatingCoolingSeason.SelectCalendar(testData.InputData.CommonName);
            TimeManager.ShortPause();
            
            //Click 'Modify' button.
            TimeSettingsHeatingCoolingSeason.ClickModifyButton();
            TimeManager.ShortPause();

            //Change the start date of 时间1
            TimeSettingsHeatingCoolingSeason.SelectColdWarmStartDate(testData.ExpectedData.ColdWarmRange[0].StartDate, 1);
            //Change the start month, start date of 时间2
            TimeSettingsHeatingCoolingSeason.SelectColdWarmStartMonth(testData.ExpectedData.ColdWarmRange[1].StartMonth, 2);
            TimeSettingsHeatingCoolingSeason.SelectColdWarmStartDate(testData.ExpectedData.ColdWarmRange[1].StartDate, 2);
            //Change the end date of 时间3
            TimeSettingsHeatingCoolingSeason.SelectColdWarmEndDate(testData.ExpectedData.ColdWarmRange[2].EndDate, 3);
            //Change the end month, end date of 时间4
            TimeSettingsHeatingCoolingSeason.SelectColdWarmEndMonth(testData.ExpectedData.ColdWarmRange[3].EndMonth, 4);
            TimeSettingsHeatingCoolingSeason.SelectColdWarmEndDate(testData.ExpectedData.ColdWarmRange[3].EndDate, 4);

            //Change type of 时间2 to be '供冷季'
            TimeSettingsHeatingCoolingSeason.SelectColdWarmType(testData.ExpectedData.ColdWarmRange[1].Type, 2);

            //Click 'Save' button
            TimeSettingsHeatingCoolingSeason.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify modification is saved successfully.
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsModifyButtonDisplayed());

            //工休日和冷暖季日历每次保存后顺序都不同。。和开发协调优化。
            ////Verify time rangeIndustry remains as before.
            //Assert.AreEqual(testData.ExpectedData.SpecialDate[0].StartDate, TimeSettingsHeatingCoolingSeason.GetStartDateValue(Industry));
            ////Verify time range2 is auto-rounding to be a new startmonth, startdate.
            //Assert.AreEqual(testData.ExpectedData.SpecialDate[Industry].StartMonth, TimeSettingsHeatingCoolingSeason.GetStartMonthValue(2));
            //Assert.AreEqual(testData.ExpectedData.SpecialDate[Industry].StartDate, TimeSettingsHeatingCoolingSeason.GetStartDateValue(2));
            ////Verify time range3 is auto-rounding to be a new endmonth, enddate.
            //Assert.AreEqual(testData.ExpectedData.SpecialDate[2].EndMonth, TimeSettingsHeatingCoolingSeason.GetEndMonthValue(3));
            //Assert.AreEqual(testData.ExpectedData.SpecialDate[2].EndDate, TimeSettingsHeatingCoolingSeason.GetEndDateValue(3));
            ////Verify time range4 remains as before.
            //Assert.AreEqual(testData.ExpectedData.SpecialDate[3].EndDate, TimeSettingsHeatingCoolingSeason.GetEndDateValue(4));
            ////Verify time range5 remains as before.
            //Assert.AreEqual(testData.ExpectedData.SpecialDate[4].EndDate, TimeSettingsHeatingCoolingSeason.GetEndDateValue(5));
        }
        #endregion

        #region TestCase3 ModifyToDeleteTimeRange
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementHCSeason-Modify-103")]
        [CaseID("TC-J1-FVT-TimeManagementHCSeason-Modify-103")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(HeatingCoolingSeasonCalendarData[]), typeof(HeatingCoolingSeasonModifySuite), "TC-J1-FVT-TimeManagementHCSeason-Modify-103")]
        public void ModifyToDeleteTimeRange(HeatingCoolingSeasonCalendarData testData)
        {
            //Select a calendar which has four cold warm ranges.
            TimeSettingsHeatingCoolingSeason.SelectCalendar(testData.InputData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button.
            TimeSettingsHeatingCoolingSeason.ClickModifyButton();
            TimeManager.ShortPause();

            //Verify there is no 'x' icon near range1.
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsColdWarmRangeItemDeleteButtonDisplayed(1));

            //Click 'x' near some ranges, e.g. delete range2,3,4.
            TimeSettingsHeatingCoolingSeason.ClickDeleteColdWarmRangeItemButton(4);
            TimeManager.ShortPause();
            TimeSettingsHeatingCoolingSeason.ClickDeleteColdWarmRangeItemButton(3);
            TimeManager.ShortPause();
            TimeSettingsHeatingCoolingSeason.ClickDeleteColdWarmRangeItemButton(2);
            TimeManager.ShortPause();

            //Click 'Save' button
            TimeSettingsHeatingCoolingSeason.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify modification is saved successfully, and only one range left.
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsCalendarExist(testData.InputData.CommonName));
            Assert.AreEqual(1, TimeSettingsHeatingCoolingSeason.GetColdWarmRangeItemsNumber());
        }
        #endregion

        #region TestCase1 ModifyHCSeasonCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementHCSeason-Modify-001")]
        [CaseID("TC-J1-FVT-TimeManagementHCSeason-Modify-001")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(HeatingCoolingSeasonCalendarData[]), typeof(HeatingCoolingSeasonModifySuite), "TC-J1-FVT-TimeManagementHCSeason-Modify-001")]
        public void ModifyHCSeasonCancelled(HeatingCoolingSeasonCalendarData testData)
        {
            //Select a calendar which has two warm ranges, one cold range.
            TimeSettingsHeatingCoolingSeason.SelectCalendar(testData.ExpectedData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button.
            TimeSettingsHeatingCoolingSeason.ClickModifyButton();
            TimeManager.ShortPause();

            //Click "Save" button directly without any change
            TimeSettingsHeatingCoolingSeason.ClickSaveButton();
            TimeManager.ShortPause();

            //Click 'Modify' button again
            TimeSettingsHeatingCoolingSeason.ClickModifyButton();
            TimeManager.ShortPause();

            ///Change name with valid input
            TimeSettingsHeatingCoolingSeason.FillInName(testData.InputData.CommonName);

            //Click 'x' icon to delete one range, e.g. delete range2
            TimeSettingsHeatingCoolingSeason.ClickDeleteColdWarmRangeItemButton(2);

            //Change type of 时间1 to be '供冷季'
            TimeSettingsHeatingCoolingSeason.SelectColdWarmType(testData.InputData.ColdWarmRange[0].Type, 1);

            //Click "Cancel" button
            TimeSettingsHeatingCoolingSeason.ClickCancelButton();
            TimeManager.ShortPause();

            //verify that the modification is cancelled and original information still displayes， there are still three cold warm ranges.
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsSaveButtonDisplayed());
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsCancelButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsModifyButtonDisplayed());
            Assert.AreEqual(3, TimeSettingsHeatingCoolingSeason.GetColdWarmRangeItemsNumber());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsCalendarExist(testData.ExpectedData.CommonName));
        }
        #endregion

        #region TestCase2 ModifyInvalidHCSeason
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementHCSeason-Modify-002")]
        [CaseID("TC-J1-FVT-TimeManagementHCSeason-Modify-002")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(HeatingCoolingSeasonCalendarData[]), typeof(HeatingCoolingSeasonModifySuite), "TC-J1-FVT-TimeManagementHCSeason-Modify-002")]
        public void ModifyInvalidHCSeason(HeatingCoolingSeasonCalendarData testData)
        {
            //Select a calendar which has two warm ranges.
            TimeSettingsHeatingCoolingSeason.SelectCalendar("冷暖季ForModifyInvalid");
            TimeManager.ShortPause();

            //Click 'Modify' button.
            TimeSettingsHeatingCoolingSeason.ClickModifyButton();
            TimeManager.ShortPause();                      
            
            //Change the end month and end date of range1 so that it is overlapped with cold range
            TimeSettingsHeatingCoolingSeason.SelectColdWarmEndMonth(testData.InputData.ColdWarmRange[0].EndMonth, 1);
            TimeSettingsHeatingCoolingSeason.SelectColdWarmEndDate(testData.InputData.ColdWarmRange[0].EndDate, 1);
            TimeManager.ShortPause();

            //Change the type of range2 to be ‘供冷季’ so that range2 will be conflict with range1 (interval less than 7 days)
            TimeSettingsHeatingCoolingSeason.SelectColdWarmType(testData.InputData.ColdWarmRange[1].Type, 2);
            TimeManager.ShortPause();

            //Change name to be a duplicated name; or null 
            TimeSettingsHeatingCoolingSeason.FillInName(testData.InputData.CommonName);
            TimeManager.ShortPause();

            //Click "Save" button.
            TimeSettingsHeatingCoolingSeason.ClickSaveButton();
            TimeManager.LongPause();            

            //verify that the saving is failed and error messages are displayed below the fields.
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsCancelButtonDisplayed());
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsNameInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsColdWarmRangeInvalidMsgCorrect(testData.ExpectedData, 1));
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsColdWarmRangeInvalidMsgCorrect(testData.ExpectedData, 2));

            //Click 'Cancel' button to quit the modification.
            TimeSettingsHeatingCoolingSeason.ClickCancelButton();
            TimeManager.ShortPause();
        }
        #endregion
    }
}
