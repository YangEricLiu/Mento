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
    public class WorktimeAddSuite : TestSuiteBase
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

        #region TestCase1 AddValidWorktime
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorktime-Add-101")]
        [CaseID("TC-J1-FVT-TimeManagementWorktime-Add-101")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(WorktimeCalendarData[]), typeof(WorktimeAddSuite), "TC-J1-FVT-TimeManagementWorktime-Add-101")]
        public void AddValidWorktime(WorktimeCalendarData testData)
        {
            //Click '+ Calendar' button.
            TimeSettingsWorktime.PrepareToAddWorktimeCalendar();
            TimeManager.ShortPause();

            //Input valid name
            TimeSettingsWorktime.FillInName(testData.InputData.CommonName);

            //Add time ranges.
            TimeSettingsWorktime.AddTimeRanges(testData);

            //Click "Save" button
            TimeSettingsWorktime.ClickSaveButton();
            TimeManager.MediumPause();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify saved successfully.
            Assert.IsFalse(TimeSettingsWorktime.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorktime.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorktime.IsCalendarExist(testData.InputData.CommonName));

            //Verify the name
            Assert.AreEqual(testData.InputData.CommonName, TimeSettingsWorktime.GetNameValue());

            //Verify the label text
            Assert.IsTrue(TimeSettingsWorktime.IsWorktimeCalendarTextCorrect(testData.ExpectedData.LabelText));

            //Verify TimeRanges are added successfully.        
            Assert.AreEqual(testData.InputData.TimeRange.Length, TimeSettingsWorktime.GetTimeRangeItemsNumber());
            for (int elementPosition = 1; elementPosition <= testData.InputData.TimeRange.Length; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                Assert.AreEqual(testData.InputData.TimeRange[inputDataArrayPosition].StartTime, TimeSettingsWorktime.GetStartTimeValue(elementPosition));
                Assert.AreEqual(testData.InputData.TimeRange[inputDataArrayPosition].EndTime, TimeSettingsWorktime.GetEndTimeValue(elementPosition));
            }
        }
        #endregion

        #region TestCase1 AddWorktimeCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorktime-Add-001")]
        [CaseID("TC-J1-FVT-TimeManagementWorktime-Add-001")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(WorktimeCalendarData[]), typeof(WorktimeAddSuite), "TC-J1-FVT-TimeManagementWorktime-Add-001")]
        public void AddWorktimeCancelled(WorktimeCalendarData testData)
        {
            //Click '+ Calendar' button.
            TimeSettingsWorktime.PrepareToAddWorktimeCalendar();
            TimeManager.ShortPause();

            //Click "Cancel" button directly without any input.
            TimeSettingsWorktime.ClickCancelButton();
            TimeManager.ShortPause();

            //Click '+ Calendar' button again
            TimeSettingsWorktime.PrepareToAddWorktimeCalendar();
            TimeManager.ShortPause();

            //Input valid input
            TimeSettingsWorktime.FillInName(testData.InputData.CommonName);

            //Add time ranges.
            TimeSettingsWorktime.AddTimeRanges(testData);

            //Click "Cancel" button
            TimeSettingsWorktime.ClickCancelButton();
            TimeManager.ShortPause();

            //verify that the addition is cancelled and NOT exists in the list.
            Assert.IsFalse(TimeSettingsWorktime.IsCalendarExist(testData.InputData.CommonName));
            Assert.IsFalse(TimeSettingsWorktime.IsSaveButtonDisplayed());
            Assert.IsFalse(TimeSettingsWorktime.IsCancelButtonDisplayed());

            //Click '+ Calendar' button again
            TimeSettingsWorktime.PrepareToAddWorktimeCalendar();
            TimeManager.ShortPause();

            //verify that the previous input has been cleared.
            Assert.AreEqual(testData.ExpectedData.CommonName, TimeSettingsWorktime.GetNameValue());

            //Click "Cancel" button
            TimeSettingsWorktime.ClickCancelButton();
            TimeManager.ShortPause();
            Assert.IsFalse(TimeSettingsWorktime.IsCancelButtonDisplayed());
        }
        #endregion

        #region TestCase2 AddInvalidWorktime
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorktime-Add-002")]
        [CaseID("TC-J1-FVT-TimeManagementWorktime-Add-002")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(WorktimeCalendarData[]), typeof(WorktimeAddSuite), "TC-J1-FVT-TimeManagementWorktime-Add-002")]
        public void AddInvalidWorktime(WorktimeCalendarData testData)
        {
            //Click '+ Calendar' button.
            TimeSettingsWorktime.PrepareToAddWorktimeCalendar();
            TimeManager.ShortPause();

            //Input invalid inputs, e.g. required fields are null; duplicated name;  overlapped ranges
            TimeSettingsWorktime.AddTimeRanges(testData);
            TimeSettingsWorktime.FillInName(testData.InputData.CommonName);            

            //Click "Save" button.
            TimeSettingsWorktime.ClickSaveButton();
            TimeManager.LongPause();            

            //verify that the saving is failed and error messages are displayed below the fields.
            Assert.IsTrue(TimeSettingsWorktime.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorktime.IsCancelButtonDisplayed());
            Assert.IsFalse(TimeSettingsWorktime.IsModifyButtonDisplayed());
            TimeManager.MediumPause();
            Assert.IsTrue(TimeSettingsWorktime.IsNameInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(TimeSettingsWorktime.IsRangeInvalidMsgCorrect(testData.ExpectedData, 1));

            //Click 'Cancel' button to quit the addition.
            TimeSettingsWorktime.ClickCancelButton();
            TimeManager.ShortPause();
            Assert.IsFalse(TimeSettingsWorktime.IsCancelButtonDisplayed());
        }
        #endregion
    }
}
