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
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
            //TimeManager.MediumPause();
        }

        #region TestCase1 ModifyValidHCSeason
        /// <summary>
        /// Pre-condition: Prepare a Calendar1 with name '冷暖季未被引用ForModifyValid', make sure it is NOT being used by any hierarchy node.
        /// Pre-condition: Prepare a Calendar2 with name '冷暖季已被引用ForModifyValid', make sure it has been used by a hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementHCSeason-Modify-101")]
        [CaseID("TC-J1-FVT-TimeManagementHCSeason-Modify-101")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(HeatingCoolingSeasonCalendarData[]), typeof(HeatingCoolingSeasonModifySuite), "TC-J1-FVT-TimeManagementHCSeason-Modify-101")]
        public void ModifyValidHCSeason(HeatingCoolingSeasonCalendarData testData)
        {
            //Select the calendar (Both of Calendar1 and Calendar2 can be modified).
            TimeSettingsHeatingCoolingSeason.SelectCalendar(testData.InputData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button            
            TimeSettingsHeatingCoolingSeason.ClickModifyButton();
            TimeManager.ShortPause();

            //Modify the Name, add more ranges
            TimeSettingsHeatingCoolingSeason.FillInName(testData.ExpectedData.CommonName);
            TimeSettingsHeatingCoolingSeason.AddWarmRanges(testData);
            TimeSettingsHeatingCoolingSeason.AddColdRanges(testData);

            //Click "Save" button
            TimeSettingsHeatingCoolingSeason.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //verify modification is successful
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsSaveButtonDisplayed());
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsCancelButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsCalendarExist(testData.ExpectedData.CommonName));
            //Verify warm and cold ranges are added successfully.        
            Assert.AreEqual(testData.InputData.WarmRange.Length, TimeSettingsHeatingCoolingSeason.GetWarmRangeItemsNumber());
            Assert.AreEqual(testData.InputData.ColdRange.Length, TimeSettingsHeatingCoolingSeason.GetColdRangeItemsNumber()); 
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

            //Change the start date of 采暖季1
            TimeSettingsHeatingCoolingSeason.SelectWarmStartDate(testData.ExpectedData.WarmRange[0].StartDate, 1);
            //Change the start month, start date of 采暖季2
            TimeSettingsHeatingCoolingSeason.SelectWarmStartMonth(testData.ExpectedData.WarmRange[1].StartMonth, 2);
            TimeSettingsHeatingCoolingSeason.SelectWarmStartDate(testData.ExpectedData.WarmRange[1].StartDate, 2);
            //Change the end date of 供冷季1
            TimeSettingsHeatingCoolingSeason.SelectColdEndDate(testData.ExpectedData.ColdRange[0].EndDate, 1);
            //Change the end month, end date of 供冷季2
            TimeSettingsHeatingCoolingSeason.SelectColdEndMonth(testData.ExpectedData.ColdRange[1].EndMonth, 2);
            TimeSettingsHeatingCoolingSeason.SelectColdEndDate(testData.ExpectedData.ColdRange[1].EndDate, 2);
                        
            //Click 'Save' button
            TimeSettingsHeatingCoolingSeason.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify modification is saved successfully.
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsModifyButtonDisplayed());

            //工休日和冷暖季日历每次保存后顺序都不同。。和开发协调优化。
            ////Verify time range1 remains as before.
            //Assert.AreEqual(testData.ExpectedData.SpecialDate[0].StartDate, TimeSettingsHeatingCoolingSeason.GetStartDateValue(1));
            ////Verify time range2 is auto-rounding to be a new startmonth, startdate.
            //Assert.AreEqual(testData.ExpectedData.SpecialDate[1].StartMonth, TimeSettingsHeatingCoolingSeason.GetStartMonthValue(2));
            //Assert.AreEqual(testData.ExpectedData.SpecialDate[1].StartDate, TimeSettingsHeatingCoolingSeason.GetStartDateValue(2));
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
            //Select a calendar which has two warm ranges, two cold ranges.
            TimeSettingsHeatingCoolingSeason.SelectCalendar(testData.InputData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button.
            TimeSettingsHeatingCoolingSeason.ClickModifyButton();
            TimeManager.ShortPause();

            //Verify there is no 'x' icon near range1.
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsWarmRangeItemDeleteButtonDisplayed(1));
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsColdRangeItemDeleteButtonDisplayed(1));

            //Click 'x' near some ranges, e.g. delete warm2, cold2.
            TimeSettingsHeatingCoolingSeason.ClickDeleteWarmRangeItemButton(2);
            TimeSettingsHeatingCoolingSeason.ClickDeleteColdRangeItemButton(2);

            //Click 'Save' button
            TimeSettingsHeatingCoolingSeason.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify modification is saved successfully, and only one warm range, one cold range left.
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsCalendarExist(testData.InputData.CommonName));
            Assert.AreEqual(1, TimeSettingsHeatingCoolingSeason.GetWarmRangeItemsNumber());
            Assert.AreEqual(1, TimeSettingsHeatingCoolingSeason.GetColdRangeItemsNumber());
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

            //Click 'x' icon to delete one range, e.g. delete warm2
            TimeSettingsHeatingCoolingSeason.ClickDeleteWarmRangeItemButton(2);

            //Click "Cancel" button
            TimeSettingsHeatingCoolingSeason.ClickCancelButton();
            TimeManager.ShortPause();

            //verify that the modification is cancelled and original information still displayes， there are still two warm ranges, one cold range.
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsSaveButtonDisplayed());
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsCancelButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsModifyButtonDisplayed());
            Assert.AreEqual(2, TimeSettingsHeatingCoolingSeason.GetWarmRangeItemsNumber());
            Assert.AreEqual(1, TimeSettingsHeatingCoolingSeason.GetColdRangeItemsNumber());
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
            //Select a calendar which has one warm range, one cold range.
            TimeSettingsHeatingCoolingSeason.SelectCalendar("冷暖季ForModifyInvalid");
            TimeManager.ShortPause();

            //Click 'Modify' button.
            TimeSettingsHeatingCoolingSeason.ClickModifyButton();
            TimeManager.ShortPause();
            
            //Change the start month of warm range so that it is overlapped with cold range
            TimeSettingsHeatingCoolingSeason.SelectWarmStartMonth(testData.InputData.WarmRange[0].StartMonth, 1);

            //Change name to be a duplicated name; or null 
            TimeSettingsHeatingCoolingSeason.FillInName(testData.InputData.CommonName);

            //Click "Save" button.
            TimeSettingsHeatingCoolingSeason.ClickSaveButton();
            TimeManager.LongPause();            

            //verify that the saving is failed and error messages are displayed below the fields.
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsCancelButtonDisplayed());
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsNameInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsWarmRangeInvalidMsgCorrect(testData.ExpectedData, 1));
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsColdRangeInvalidMsgCorrect(testData.ExpectedData, 1));

            //Click 'Cancel' button to quit the modification.
            TimeSettingsHeatingCoolingSeason.ClickCancelButton();
            TimeManager.ShortPause();
        }
        #endregion
    }
}
