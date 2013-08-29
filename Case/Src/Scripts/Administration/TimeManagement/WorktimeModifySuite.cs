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
    public class WorktimeModifySuite : TestSuiteBase
    {
        private static TimeSettingsWorktime TimeSettingsWorktime = JazzFunction.TimeSettingsWorktime;
        [SetUp]
        public void CaseSetUp()
        {
            TimeSettingsWorktime.NavigatorToWorktimeCalendarSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
        }

        #region TestCase1 ModifyValidWorktime
        /// <summary>
        /// Pre-condition: Prepare a Calendar1 with name '工作时间未被引用ForModifyValid', make sure it is NOT being used by any hierarchy node.
        /// Pre-condition: Prepare a Calendar2 with name '工作时间已被引用ForModifyValid', make sure it has been used by a hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorktime-Modify-101")]
        [CaseID("TC-J1-FVT-TimeManagementWorktime-Modify-101")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(WorktimeCalendarData[]), typeof(WorktimeModifySuite), "TC-J1-FVT-TimeManagementWorktime-Modify-101")]
        public void ModifyValidWorktime(WorktimeCalendarData testData)
        {
            //Select the calendar with one range only (Both of Calendar1 and Calendar2 can be modified)
            TimeSettingsWorktime.SelectCalendar(testData.InputData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button            
            TimeSettingsWorktime.ClickModifyButton();
            TimeManager.ShortPause();

            //Modify the Name, add more ranges
            TimeSettingsWorktime.FillInName(testData.ExpectedData.CommonName);
            TimeSettingsWorktime.AddTimeRanges(testData);

            //Click "Save" button
            TimeSettingsWorktime.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //verify modification is successful
            Assert.IsFalse(TimeSettingsWorktime.IsSaveButtonDisplayed());
            Assert.IsFalse(TimeSettingsWorktime.IsCancelButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorktime.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorktime.IsCalendarExist(testData.ExpectedData.CommonName));
            //Verify there are time ranges added.
            Assert.AreEqual(testData.InputData.TimeRange.Length, TimeSettingsWorktime.GetTimeRangeItemsNumber());
        }
        #endregion

        #region TestCase2 ModifyTimeRange
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorktime-Modify-102")]
        [CaseID("TC-J1-FVT-TimeManagementWorktime-Modify-102")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(WorktimeCalendarData[]), typeof(WorktimeModifySuite), "TC-J1-FVT-TimeManagementWorktime-Modify-102")]
        public void ModifyTimeRange(WorktimeCalendarData testData)
        {
            //Select a calendar which has time range ranges.
            TimeSettingsWorktime.SelectCalendar(testData.InputData.CommonName);
            TimeManager.ShortPause();
            
            //Click 'Modify' button.
            TimeSettingsWorktime.ClickModifyButton();
            TimeManager.ShortPause();
                        
            //Change the start time of 范围1
            TimeSettingsWorktime.SelectStartTime(testData.ExpectedData.TimeRange[0].StartTime, 1);
            //Change the start time of 范围2
            TimeSettingsWorktime.SelectStartTime(testData.ExpectedData.TimeRange[1].StartTime, 2);
            //Change the end time of 范围3
            TimeSettingsWorktime.SelectEndTime(testData.ExpectedData.TimeRange[2].EndTime, 3);
            //Change the end time of 范围4
            TimeSettingsWorktime.SelectEndTime(testData.ExpectedData.TimeRange[3].EndTime, 4);
            //Change the start time, end time of 范围5
            TimeSettingsWorktime.SelectStartTime(testData.ExpectedData.TimeRange[4].StartTime, 5);
            TimeSettingsWorktime.SelectEndTime(testData.ExpectedData.TimeRange[4].EndTime, 5);

            //Click 'Save' button
            TimeSettingsWorktime.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify modification is saved successfully.
            Assert.IsFalse(TimeSettingsWorktime.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorktime.IsModifyButtonDisplayed());

            //Verify time range1 is auto-rounding to be a new end time.
            Assert.AreEqual(testData.ExpectedData.TimeRange[0].EndTime, TimeSettingsWorktime.GetEndTimeValue(1));
            //Verify time range2 is auto-rounding to be a new end time.
            Assert.AreEqual(testData.ExpectedData.TimeRange[1].EndTime, TimeSettingsWorktime.GetEndTimeValue(2));
            //Verify time range3 is auto-rounding to be a new start time.
            Assert.AreEqual(testData.ExpectedData.TimeRange[2].StartTime, TimeSettingsWorktime.GetStartTimeValue(3));
            //Verify time range4 is auto-rounding to be a new start time.
            Assert.AreEqual(testData.ExpectedData.TimeRange[3].StartTime, TimeSettingsWorktime.GetStartTimeValue(4));
            //Verify time range5 is set to be a new start time, end time.
            Assert.AreEqual(testData.ExpectedData.TimeRange[4].StartTime, TimeSettingsWorktime.GetStartTimeValue(5));
            Assert.AreEqual(testData.ExpectedData.TimeRange[4].EndTime, TimeSettingsWorktime.GetEndTimeValue(5));
        }
        #endregion

        #region TestCase3 ModifyToDeleteTimeRange
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorktime-Modify-103")]
        [CaseID("TC-J1-FVT-TimeManagementWorktime-Modify-103")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(WorktimeCalendarData[]), typeof(WorktimeModifySuite), "TC-J1-FVT-TimeManagementWorktime-Modify-103")]
        public void ModifyToDeleteTimeRange(WorktimeCalendarData testData)
        {
            //Select a calendar which has three time range ranges.
            TimeSettingsWorktime.SelectCalendar(testData.InputData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button.
            TimeSettingsWorktime.ClickModifyButton();
            TimeManager.ShortPause();

            //Verify there is no 'x' icon near range1.
            Assert.IsFalse(TimeSettingsWorktime.IsRangeItemDeleteButtonDisplayed(1));

            //Click 'x' near one range, e.g. delete range2
            TimeSettingsWorktime.ClickDeleteRangeItemButton(2);

            //Click 'Save' button
            TimeSettingsWorktime.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify modification is saved successfully, and only two ranges left.
            Assert.IsFalse(TimeSettingsWorktime.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorktime.IsModifyButtonDisplayed());
            Assert.AreEqual((testData.InputData.TimeRange.Length - 1), TimeSettingsWorktime.GetTimeRangeItemsNumber());
        }
        #endregion

        #region TestCase1 ModifyWorktimeCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorktime-Modify-001")]
        [CaseID("TC-J1-FVT-TimeManagementWorktime-Modify-001")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(WorktimeCalendarData[]), typeof(WorktimeModifySuite), "TC-J1-FVT-TimeManagementWorktime-Modify-001")]
        public void ModifyWorktimeCancelled(WorktimeCalendarData testData)
        {
            //Select a calendar which has two time range ranges.
            TimeSettingsWorktime.SelectCalendar(testData.ExpectedData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button.
            TimeSettingsWorktime.ClickModifyButton();
            TimeManager.ShortPause();

            //Click "Save" button directly without any change
            TimeSettingsWorktime.ClickSaveButton();
            TimeManager.ShortPause();

            //Click 'Modify' button again
            TimeSettingsWorktime.ClickModifyButton();
            TimeManager.ShortPause();

            ///Change name with valid input
            TimeSettingsWorktime.FillInName(testData.InputData.CommonName);

            //Click 'x' icon to delete one range, e.g. delete range2
            TimeSettingsWorktime.ClickDeleteRangeItemButton(2);

            //Click "Cancel" button
            TimeSettingsWorktime.ClickCancelButton();
            TimeManager.ShortPause();

            //verify that the modification is cancelled and original information still displayes， there are still two ranges.
            Assert.IsFalse(TimeSettingsWorktime.IsSaveButtonDisplayed());
            Assert.IsFalse(TimeSettingsWorktime.IsCancelButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorktime.IsModifyButtonDisplayed());
            Assert.AreEqual(testData.InputData.TimeRange.Length, TimeSettingsWorktime.GetTimeRangeItemsNumber());
            Assert.IsTrue(TimeSettingsWorktime.IsCalendarExist(testData.ExpectedData.CommonName));
        }
        #endregion

        #region TestCase2 ModifyInvalidWorktime
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorktime-Modify-002")]
        [CaseID("TC-J1-FVT-TimeManagementWorktime-Modify-002")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(WorktimeCalendarData[]), typeof(WorktimeModifySuite), "TC-J1-FVT-TimeManagementWorktime-Modify-002")]
        public void ModifyInvalidWorktime(WorktimeCalendarData testData)
        {
            //Select a calendar.
            TimeSettingsWorktime.SelectCalendar("工作时间ForModifyInvalid");
            TimeManager.ShortPause();

            //Click 'Modify' button.
            TimeSettingsWorktime.ClickModifyButton();
            TimeManager.ShortPause();
            
            //Change the end time of range1 so that it is overlapped with range2
            TimeSettingsWorktime.SelectEndTime(testData.InputData.TimeRange[0].EndTime, 1);

            //Change name to be a duplicated name; or null 
            TimeSettingsWorktime.FillInName(testData.InputData.CommonName);

            //Click "Save" button.
            TimeSettingsWorktime.ClickSaveButton();
            TimeManager.LongPause();            

            //verify that the saving is failed and error messages are displayed below the fields.
            Assert.IsTrue(TimeSettingsWorktime.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorktime.IsCancelButtonDisplayed());
            Assert.IsFalse(TimeSettingsWorktime.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorktime.IsNameInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(TimeSettingsWorktime.IsRangeInvalidMsgCorrect(testData.ExpectedData, 1));

            //Click 'Cancel' button to quit the modification.
            TimeSettingsWorktime.ClickCancelButton();
            TimeManager.ShortPause();
        }
        #endregion
    }
}
