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
    public class WorkdayModifySuite : TestSuiteBase
    {
        private static TimeSettingsWorkday TimeSettingsWorkday = JazzFunction.TimeSettingsWorkday;
        [SetUp]
        public void CaseSetUp()
        {
            TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
        }

        #region TestCase1 ModifyValidWorkday
        /// <summary>
        /// Pre-condition: Prepare a Calendar1 with name '工休日未被引用ForModifyValid', make sure it is NOT being used by any hierarchy node.
        /// Pre-condition: Prepare a Calendar2 with name '工休日已被引用ForModifyValid', make sure it has been used by a hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorkday-Modify-101")]
        [CaseID("TC-J1-FVT-TimeManagementWorkday-Modify-101")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(WorkdayCalendarData[]), typeof(WorkdayModifySuite), "TC-J1-FVT-TimeManagementWorkday-Modify-101")]
        public void ModifyValidWorkday(WorkdayCalendarData testData)
        {
            //Select the calendar (Both of Calendar1 and Calendar2 can be modified).
            TimeSettingsWorkday.SelectCalendar(testData.InputData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button            
            TimeSettingsWorkday.ClickModifyButton();
            TimeManager.ShortPause();

            //Modify the Name, add more ranges
            TimeSettingsWorkday.FillInName(testData.ExpectedData.CommonName);
            TimeSettingsWorkday.AddSpecialDates(testData);

            //Click "Save" button
            TimeSettingsWorkday.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //verify modification is successful
            Assert.IsFalse(TimeSettingsWorkday.IsSaveButtonDisplayed());
            Assert.IsFalse(TimeSettingsWorkday.IsCancelButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorkday.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorkday.IsCalendarExist(testData.ExpectedData.CommonName));
            //Verify there are special dates added.
            Assert.AreEqual(testData.InputData.SpecialDate.Length, TimeSettingsWorkday.GetSpecialDateItemsNumber());
        }
        #endregion

        #region TestCase2 ModifyTimeRange
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorkday-Modify-102")]
        [CaseID("TC-J1-FVT-TimeManagementWorkday-Modify-102")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(WorkdayCalendarData[]), typeof(WorkdayModifySuite), "TC-J1-FVT-TimeManagementWorkday-Modify-102")]
        public void ModifyTimeRange(WorkdayCalendarData testData)
        {
            //Select a calendar which has special date ranges.
            TimeSettingsWorkday.SelectCalendar(testData.InputData.CommonName);
            TimeManager.ShortPause();
            
            //Click 'Modify' button.
            TimeSettingsWorkday.ClickModifyButton();
            TimeManager.ShortPause();

            //Change the type of 时间1 to be '非工作日'
            TimeSettingsWorkday.SelectSpecialDateType(testData.ExpectedData.SpecialDate[0].Type, 1);

            //Change the end date of 范围1
            TimeSettingsWorkday.SelectEndDate(testData.ExpectedData.SpecialDate[0].EndDate, 1);

            //Change the end month of 范围2
            TimeSettingsWorkday.SelectEndMonth(testData.ExpectedData.SpecialDate[1].EndMonth, 2);

            //Change the start month, start date of 范围3
            TimeSettingsWorkday.SelectStartMonth(testData.ExpectedData.SpecialDate[2].StartMonth, 3);
            TimeSettingsWorkday.SelectStartDate(testData.ExpectedData.SpecialDate[2].StartDate, 3);

            //Change the start month, start date of 范围4
            TimeSettingsWorkday.SelectStartMonth(testData.ExpectedData.SpecialDate[3].StartMonth, 4);
            TimeSettingsWorkday.SelectStartDate(testData.ExpectedData.SpecialDate[3].StartDate, 4);

            //Change the start date of 范围5
            TimeSettingsWorkday.SelectStartDate(testData.ExpectedData.SpecialDate[4].StartDate, 5);
            
            //Click 'Save' button
            TimeSettingsWorkday.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify modification is saved successfully.
            Assert.IsFalse(TimeSettingsWorkday.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorkday.IsModifyButtonDisplayed());

            //工休日日历每次保存后顺序都不同。。和开发协调优化。
            ////Verify time range1 remains as before.
            //Assert.AreEqual(testData.ExpectedData.SpecialDate[0].StartDate, TimeSettingsWorkday.GetStartDateValue(1));
            ////Verify time range2 is auto-rounding to be a new startmonth, startdate.
            //Assert.AreEqual(testData.ExpectedData.SpecialDate[1].StartMonth, TimeSettingsWorkday.GetStartMonthValue(2));
            //Assert.AreEqual(testData.ExpectedData.SpecialDate[1].StartDate, TimeSettingsWorkday.GetStartDateValue(2));
            ////Verify time range3 is auto-rounding to be a new endmonth, enddate.
            //Assert.AreEqual(testData.ExpectedData.SpecialDate[2].EndMonth, TimeSettingsWorkday.GetEndMonthValue(3));
            //Assert.AreEqual(testData.ExpectedData.SpecialDate[2].EndDate, TimeSettingsWorkday.GetEndDateValue(3));
            ////Verify time range4 remains as before.
            //Assert.AreEqual(testData.ExpectedData.SpecialDate[3].EndDate, TimeSettingsWorkday.GetEndDateValue(4));
            ////Verify time range5 remains as before.
            //Assert.AreEqual(testData.ExpectedData.SpecialDate[4].EndDate, TimeSettingsWorkday.GetEndDateValue(5));
        }
        #endregion

        #region TestCase3 ModifyToDeleteSpecialDate
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorkday-Modify-103")]
        [CaseID("TC-J1-FVT-TimeManagementWorkday-Modify-103")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(WorkdayCalendarData[]), typeof(WorkdayModifySuite), "TC-J1-FVT-TimeManagementWorkday-Modify-103")]
        public void ModifyToDeleteSpecialDate(WorkdayCalendarData testData)
        {
            //Select a calendar which has three special date ranges.
            TimeSettingsWorkday.SelectCalendar(testData.InputData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button.
            TimeSettingsWorkday.ClickModifyButton();
            TimeManager.ShortPause();

            //Click 'x' near one range, e.g. delete range1
            TimeSettingsWorkday.ClickDeleteRangeItemButton(1);

            //Click 'Save' button
            TimeSettingsWorkday.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify modification is saved successfully, and only two ranges left.
            Assert.IsFalse(TimeSettingsWorkday.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorkday.IsModifyButtonDisplayed());
            Assert.AreEqual(2, TimeSettingsWorkday.GetSpecialDateItemsNumber());

            //Click 'Modify' button again.
            TimeSettingsWorkday.ClickModifyButton();
            TimeManager.ShortPause();

            //Click 'x' near all the other two ranges
            TimeSettingsWorkday.ClickDeleteRangeItemButton(2);
            TimeSettingsWorkday.ClickDeleteRangeItemButton(1);            

            //Click 'Save' button
            TimeSettingsWorkday.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify modification is saved successfully, and no any special date range left.
            Assert.IsFalse(TimeSettingsWorkday.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorkday.IsModifyButtonDisplayed());
            Assert.AreEqual(0, TimeSettingsWorkday.GetSpecialDateItemsNumber());
            Assert.IsTrue(TimeSettingsWorkday.IsCalendarExist(testData.InputData.CommonName));
            
        }
        #endregion

        #region TestCase1 ModifyWorkdayCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorkday-Modify-001")]
        [CaseID("TC-J1-FVT-TimeManagementWorkday-Modify-001")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(WorkdayCalendarData[]), typeof(WorkdayModifySuite), "TC-J1-FVT-TimeManagementWorkday-Modify-001")]
        public void ModifyWorkdayCancelled(WorkdayCalendarData testData)
        {
            //Select a calendar which has two special date ranges.
            TimeSettingsWorkday.SelectCalendar(testData.ExpectedData.CommonName);
            TimeManager.ShortPause();

            //Click 'Modify' button.
            TimeSettingsWorkday.ClickModifyButton();
            TimeManager.ShortPause();

            //Click "Save" button directly without any change
            TimeSettingsWorkday.ClickSaveButton();
            TimeManager.ShortPause();

            //Click 'Modify' button again
            TimeSettingsWorkday.ClickModifyButton();
            TimeManager.ShortPause();

            ///Change name with valid input
            TimeSettingsWorkday.FillInName(testData.InputData.CommonName);

            //Click 'x' icon to delete one range
            TimeSettingsWorkday.ClickDeleteRangeItemButton(1);

            //Click "Cancel" button
            TimeSettingsWorkday.ClickCancelButton();
            TimeManager.ShortPause();

            //verify that the modification is cancelled and original information still displayes， there are still two ranges.
            Assert.IsFalse(TimeSettingsWorkday.IsSaveButtonDisplayed());
            Assert.IsFalse(TimeSettingsWorkday.IsCancelButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorkday.IsModifyButtonDisplayed());
            Assert.AreEqual(2, TimeSettingsWorkday.GetSpecialDateItemsNumber());
            Assert.IsTrue(TimeSettingsWorkday.IsCalendarExist(testData.ExpectedData.CommonName));
        }
        #endregion

        #region TestCase2 ModifyInvalidWorkday
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorkday-Modify-002")]
        [CaseID("TC-J1-FVT-TimeManagementWorkday-Modify-002")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(WorkdayCalendarData[]), typeof(WorkdayModifySuite), "TC-J1-FVT-TimeManagementWorkday-Modify-002")]
        public void ModifyInvalidWorkday(WorkdayCalendarData testData)
        {
            //Select a calendar.
            TimeSettingsWorkday.SelectCalendar("工休日ForModifyInvalid");
            TimeManager.ShortPause();

            //Click 'Modify' button.
            TimeSettingsWorkday.ClickModifyButton();
            TimeManager.ShortPause();
            
            //Change the end month, end date of range1 so that it is overlapped with range2
            TimeSettingsWorkday.SelectEndMonth(testData.InputData.SpecialDate[0].EndMonth, 1);
            TimeSettingsWorkday.SelectEndDate(testData.InputData.SpecialDate[0].EndDate, 1);

            //Change name to be a duplicated name; or null 
            TimeSettingsWorkday.FillInName(testData.InputData.CommonName);

            //Click "Save" button.
            TimeSettingsWorkday.ClickSaveButton();
            TimeManager.LongPause();            

            //verify that the saving is failed and error messages are displayed below the fields.
            Assert.IsTrue(TimeSettingsWorkday.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorkday.IsCancelButtonDisplayed());
            Assert.IsFalse(TimeSettingsWorkday.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorkday.IsNameInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(TimeSettingsWorkday.IsRangeInvalidMsgCorrect(testData.ExpectedData, 1));

            //Click 'Cancel' button to quit the modification.
            TimeSettingsWorkday.ClickCancelButton();
            TimeManager.ShortPause();
        }
        #endregion
    }
}
