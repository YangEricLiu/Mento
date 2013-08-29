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
    public class DayNightModifySuite : TestSuiteBase
    {
        private static TimeSettingsDayNight TimeSettingsDayNight = JazzFunction.TimeSettingsDayNight;
        [SetUp]
        public void CaseSetUp()
        {
            TimeSettingsDayNight.NavigatorToDaynightCalendarSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
        }

        #region TestCase1 ModifyValidDayNight
        /// <summary>
        /// Pre-condition: Prepare a Calendar1 with name '昼夜时间未被引用ForModifyValid', make sure it is NOT being used by any hierarchy node.
        /// Pre-condition: Prepare a Calendar2 with name '昼夜时间已被引用ForModifyValid', make sure it has been used by a hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementDayNight-Modify-101")]
        [CaseID("TC-J1-FVT-TimeManagementDayNight-Modify-101")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(DayNightCalendarData[]), typeof(DayNightModifySuite), "TC-J1-FVT-TimeManagementDayNight-Modify-101")]
        public void ModifyValidDayNight(DayNightCalendarData testData)
        {
            //Select the calendar with one range only (Both of Calendar1 and Calendar2 can be modified)
            TimeSettingsDayNight.SelectCalendar(testData.InputData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button            
            TimeSettingsDayNight.ClickModifyButton();
            TimeManager.ShortPause();

            //Modify the Name, add more ranges
            TimeSettingsDayNight.FillInName(testData.ExpectedData.CommonName);
            TimeSettingsDayNight.AddTimeRanges(testData);

            //Click "Save" button
            TimeSettingsDayNight.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //verify modification is successful
            Assert.IsFalse(TimeSettingsDayNight.IsSaveButtonDisplayed());
            Assert.IsFalse(TimeSettingsDayNight.IsCancelButtonDisplayed());
            Assert.IsTrue(TimeSettingsDayNight.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsDayNight.IsCalendarExist(testData.ExpectedData.CommonName));
            //Verify there are time ranges added.
            Assert.AreEqual(testData.InputData.TimeRange.Length, TimeSettingsDayNight.GetTimeRangeItemsNumber());
        }
        #endregion

        #region TestCase2 ModifyTimeRange
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementDayNight-Modify-102")]
        [CaseID("TC-J1-FVT-TimeManagementDayNight-Modify-102")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(DayNightCalendarData[]), typeof(DayNightModifySuite), "TC-J1-FVT-TimeManagementDayNight-Modify-102")]
        public void ModifyTimeRange(DayNightCalendarData testData)
        {
            //Select a calendar which has time range ranges.
            TimeSettingsDayNight.SelectCalendar(testData.InputData.CommonName);
            TimeManager.ShortPause();
            
            //Click 'Modify' button.
            TimeSettingsDayNight.ClickModifyButton();
            TimeManager.ShortPause();
                        
            //Change the start time of 范围1
            TimeSettingsDayNight.SelectStartTime(testData.ExpectedData.TimeRange[0].StartTime, 1);
            //Change the start time of 范围2
            TimeSettingsDayNight.SelectStartTime(testData.ExpectedData.TimeRange[1].StartTime, 2);
            //Change the end time of 范围3
            TimeSettingsDayNight.SelectEndTime(testData.ExpectedData.TimeRange[2].EndTime, 3);
            //Change the end time of 范围4
            TimeSettingsDayNight.SelectEndTime(testData.ExpectedData.TimeRange[3].EndTime, 4);
            //Change the start time, end time of 范围5
            TimeSettingsDayNight.SelectStartTime(testData.ExpectedData.TimeRange[4].StartTime, 5);
            TimeSettingsDayNight.SelectEndTime(testData.ExpectedData.TimeRange[4].EndTime, 5);

            //Click 'Save' button
            TimeSettingsDayNight.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify modification is saved successfully.
            Assert.IsFalse(TimeSettingsDayNight.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsDayNight.IsModifyButtonDisplayed());

            //Verify time range1 is auto-rounding to be a new end time.
            Assert.AreEqual(testData.ExpectedData.TimeRange[0].EndTime, TimeSettingsDayNight.GetEndTimeValue(1));
            //Verify time range2 is auto-rounding to be a new end time.
            Assert.AreEqual(testData.ExpectedData.TimeRange[1].EndTime, TimeSettingsDayNight.GetEndTimeValue(2));
            //Verify time range3 is auto-rounding to be a new start time.
            Assert.AreEqual(testData.ExpectedData.TimeRange[2].StartTime, TimeSettingsDayNight.GetStartTimeValue(3));
            //Verify time range4 is auto-rounding to be a new start time.
            Assert.AreEqual(testData.ExpectedData.TimeRange[3].StartTime, TimeSettingsDayNight.GetStartTimeValue(4));
            //Verify time range5 is set to be a new start time, end time.
            Assert.AreEqual(testData.ExpectedData.TimeRange[4].StartTime, TimeSettingsDayNight.GetStartTimeValue(5));
            Assert.AreEqual(testData.ExpectedData.TimeRange[4].EndTime, TimeSettingsDayNight.GetEndTimeValue(5));
        }
        #endregion

        #region TestCase3 ModifyToDeleteTimeRange
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementDayNight-Modify-103")]
        [CaseID("TC-J1-FVT-TimeManagementDayNight-Modify-103")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(DayNightCalendarData[]), typeof(DayNightModifySuite), "TC-J1-FVT-TimeManagementDayNight-Modify-103")]
        public void ModifyToDeleteTimeRange(DayNightCalendarData testData)
        {
            //Select a calendar which has three time range ranges.
            TimeSettingsDayNight.SelectCalendar(testData.InputData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button.
            TimeSettingsDayNight.ClickModifyButton();
            TimeManager.ShortPause();

            //Verify there is no 'x' icon near range1.
            Assert.IsFalse(TimeSettingsDayNight.IsRangeItemDeleteButtonDisplayed(1));

            //Click 'x' near one range, e.g. delete range2
            TimeSettingsDayNight.ClickDeleteRangeItemButton(2);

            //Click 'Save' button
            TimeSettingsDayNight.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify modification is saved successfully, and only two ranges left.
            Assert.IsFalse(TimeSettingsDayNight.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsDayNight.IsModifyButtonDisplayed());
            Assert.AreEqual((testData.InputData.TimeRange.Length - 1), TimeSettingsDayNight.GetTimeRangeItemsNumber());
        }
        #endregion

        #region TestCase1 ModifyDayNightCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementDayNight-Modify-001")]
        [CaseID("TC-J1-FVT-TimeManagementDayNight-Modify-001")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(DayNightCalendarData[]), typeof(DayNightModifySuite), "TC-J1-FVT-TimeManagementDayNight-Modify-001")]
        public void ModifyDayNightCancelled(DayNightCalendarData testData)
        {
            //Select a calendar which has two time range ranges.
            TimeSettingsDayNight.SelectCalendar(testData.ExpectedData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button.
            TimeSettingsDayNight.ClickModifyButton();
            TimeManager.ShortPause();

            //Click "Save" button directly without any change
            TimeSettingsDayNight.ClickSaveButton();
            TimeManager.ShortPause();

            //Click 'Modify' button again
            TimeSettingsDayNight.ClickModifyButton();
            TimeManager.ShortPause();

            ///Change name with valid input
            TimeSettingsDayNight.FillInName(testData.InputData.CommonName);

            //Click 'x' icon to delete one range, e.g. delete range2
            TimeSettingsDayNight.ClickDeleteRangeItemButton(2);

            //Click "Cancel" button
            TimeSettingsDayNight.ClickCancelButton();
            TimeManager.ShortPause();

            //verify that the modification is cancelled and original information still displayes， there are still two ranges.
            Assert.IsFalse(TimeSettingsDayNight.IsSaveButtonDisplayed());
            Assert.IsFalse(TimeSettingsDayNight.IsCancelButtonDisplayed());
            Assert.IsTrue(TimeSettingsDayNight.IsModifyButtonDisplayed());
            Assert.AreEqual(testData.InputData.TimeRange.Length, TimeSettingsDayNight.GetTimeRangeItemsNumber());
            Assert.IsTrue(TimeSettingsDayNight.IsCalendarExist(testData.ExpectedData.CommonName));
        }
        #endregion

        #region TestCase2 ModifyInvalidDayNight
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementDayNight-Modify-002")]
        [CaseID("TC-J1-FVT-TimeManagementDayNight-Modify-002")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(DayNightCalendarData[]), typeof(DayNightModifySuite), "TC-J1-FVT-TimeManagementDayNight-Modify-002")]
        public void ModifyInvalidDayNight(DayNightCalendarData testData)
        {
            //Select a calendar.
            TimeSettingsDayNight.SelectCalendar("昼夜时间ForModifyInvalid");
            TimeManager.ShortPause();

            //Click 'Modify' button.
            TimeSettingsDayNight.ClickModifyButton();
            TimeManager.ShortPause();
            
            //Change the end time of range1 so that it is overlapped with range2
            TimeSettingsDayNight.SelectEndTime(testData.InputData.TimeRange[0].EndTime, 1);

            //Change name to be a duplicated name; or null 
            TimeSettingsDayNight.FillInName(testData.InputData.CommonName);

            //Click "Save" button.
            TimeSettingsDayNight.ClickSaveButton();
            TimeManager.LongPause();            

            //verify that the saving is failed and error messages are displayed below the fields.
            Assert.IsTrue(TimeSettingsDayNight.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsDayNight.IsCancelButtonDisplayed());
            Assert.IsFalse(TimeSettingsDayNight.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsDayNight.IsNameInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(TimeSettingsDayNight.IsRangeInvalidMsgCorrect(testData.ExpectedData, 1));

            //Click 'Cancel' button to quit the modification.
            TimeSettingsDayNight.ClickCancelButton();
            TimeManager.ShortPause();
        }
        #endregion
    }
}
