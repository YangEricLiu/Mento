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
    public class WorktimeDeleteSuite : TestSuiteBase
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
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
            //TimeManager.MediumPause();
        }

        #region TestCase1 DeleteWorktimeSuccessful
        /// <summary>
        /// Pre-condition: Prepare a Calendar, make sure it is NOT being used by any hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorktime-Delete-101")]
        [CaseID("TC-J1-FVT-TimeManagementWorktime-Delete-101")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(WorktimeCalendarData[]), typeof(WorktimeDeleteSuite), "TC-J1-FVT-TimeManagementWorktime-Delete-101")]
        public void DeleteWorktimeSuccessful(WorktimeCalendarData testData)
        {
            //Select the Calendar.
            TimeSettingsWorktime.SelectCalendar(testData.InputData.CommonName);

            //Click 'Delete' button
            TimeManager.ShortPause();
            TimeSettingsWorktime.ClickDeleteButton();

            //Click 'Confirm' button on the confirmation window.
            TimeManager.ShortPause();
            TimeSettingsWorktime.ClickMsgBoxConfirmButton();

            TimeManager.MediumPause();

            //Verify that the Calendar is deleted successfully and NOT exists in the list.
            Assert.IsFalse(TimeSettingsWorktime.IsCalendarExist(testData.InputData.CommonName));
        }
        #endregion

        #region TestCase1 DeleteWorktimeCancelled
        /// <summary>
        /// Pre-condition: Prepare a Calendar, make sure it is NOT being used by any hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorktime-Delete-001")]
        [CaseID("TC-J1-FVT-TimeManagementWorktime-Delete-001")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(WorktimeCalendarData[]), typeof(WorktimeDeleteSuite), "TC-J1-FVT-TimeManagementWorktime-Delete-001")]
        public void DeleteWorktimeCancelled(WorktimeCalendarData testData)
        {
            //Select the Calendar.
            TimeSettingsWorktime.SelectCalendar(testData.InputData.CommonName);        
            
            //Click 'Delete' button
            TimeManager.ShortPause();
            TimeSettingsWorktime.ClickDeleteButton();

            //Click 'Cancel' button to cancel the deletion.
            TimeManager.ShortPause();
            TimeSettingsWorktime.ClickMsgBoxCancelButton();

            //Select the Calendar again.
            TimeSettingsWorktime.SelectCalendar(testData.InputData.CommonName);

            //Click 'Delete' button
            TimeManager.ShortPause();
            TimeSettingsWorktime.ClickDeleteButton();

            //Click 'x' icon to close the deletion confirmation popup.
            TimeManager.ShortPause();
            TimeSettingsWorktime.ClickMsgBoxCloseButton();

            //Verify that the Calendar is not deleted when cancel or close the window, and still exists in the list.
            TimeManager.ShortPause();
            Assert.IsTrue(TimeSettingsWorktime.IsCalendarExist(testData.InputData.CommonName));
        }
        #endregion

        #region TestCase2 DeleteWorktimeFailed
        /// <summary>
        /// Pre-condition: Prepare a Calendar, make sure it has been used by a hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorktime-Delete-002")]
        [CaseID("TC-J1-FVT-TimeManagementWorktime-Delete-002")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(WorktimeCalendarData[]), typeof(WorktimeDeleteSuite), "TC-J1-FVT-TimeManagementWorktime-Delete-002")]
        public void DeleteWorktimeFailed(WorktimeCalendarData testData)
        {
            //Select the Calendar.
            TimeSettingsWorktime.SelectCalendar(testData.InputData.CommonName);

            //Click 'Delete' button
            TimeManager.ShortPause();
            TimeSettingsWorktime.ClickDeleteButton();

            //Click 'Confirm' button to confirm the deletion.
            TimeManager.ShortPause();
            TimeSettingsWorktime.ClickMsgBoxConfirmButton();
            TimeManager.LongPause();

            //Verify that error message like "Calendar has been used and can't be deleted" pops up.
            Assert.IsTrue(TimeSettingsWorktime.IsPopMsgCorrect(testData.ExpectedData));
            TimeManager.ShortPause();

            //Click 'Confirm' button to close the deletion failed message box.
            TimeManager.ShortPause();
            TimeSettingsWorktime.ClickMsgBoxConfirmButton();
            
            //Verify that the Calendar is not deleted and still exists in the list.
            TimeManager.ShortPause();
            Assert.IsTrue(TimeSettingsWorktime.IsCalendarExist(testData.InputData.CommonName));
        }
        #endregion
        
    }
}
