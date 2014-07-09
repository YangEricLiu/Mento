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
    public class WorkdayDeleteSuite : TestSuiteBase
    {
        private static TimeSettingsWorkday TimeSettingsWorkday = JazzFunction.TimeSettingsWorkday;
        private static TimeSettingsWorktime TimeSettingsWorktime = JazzFunction.TimeSettingsWorktime;
        [SetUp]
        public void CaseSetUp()
        {
            TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {

            TimeManager.MediumPause();
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorktime);
            //TimeManager.MediumPause();
        }

        #region TestCase1 DeleteWorkdaySuccessful
        /// <summary>
        /// Pre-condition: Prepare a Calendar, make sure it is NOT being used by any hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorkday-Delete-101")]
        [CaseID("TC-J1-FVT-TimeManagementWorkday-Delete-101")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(WorkdayCalendarData[]), typeof(WorkdayDeleteSuite), "TC-J1-FVT-TimeManagementWorkday-Delete-101")]
        public void DeleteWorkdaySuccessful(WorkdayCalendarData testData)
        {
            //Select the Calendar.
            TimeSettingsWorkday.SelectCalendar(testData.InputData.CommonName);

            //Click 'Delete' button
            TimeManager.ShortPause();
            TimeSettingsWorkday.ClickDeleteButton();

            //Click 'Delete' button on the confirmation window.
            TimeManager.ShortPause();
            TimeSettingsWorkday.ClickMsgBoxDeleteButton();
            
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Verify that the Calendar is deleted successfully and NOT exists in the list.
            Assert.IsFalse(TimeSettingsWorkday.IsCalendarExist(testData.InputData.CommonName));
            
            //Go to other tab(e.g. worktime tab), then back again, verify that the deleted calendar NOT exists in the list.
            TimeSettingsWorktime.NavigatorToWorktimeCalendarSetting();
            TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
            TimeManager.MediumPause();
            Assert.IsFalse(TimeSettingsWorkday.IsCalendarExist(testData.InputData.CommonName));
        }
        #endregion

        #region TestCase1 DeleteWorkdayCancelled
        /// <summary>
        /// Pre-condition: Prepare a Calendar, make sure it is NOT being used by any hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorkday-Delete-001")]
        [CaseID("TC-J1-FVT-TimeManagementWorkday-Delete-001")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(WorkdayCalendarData[]), typeof(WorkdayDeleteSuite), "TC-J1-FVT-TimeManagementWorkday-Delete-001")]
        public void DeleteWorkdayCancelled(WorkdayCalendarData testData)
        {
            //Select the Calendar.
            TimeSettingsWorkday.SelectCalendar(testData.InputData.CommonName);        
            
            //Click 'Delete' button
            TimeManager.ShortPause();
            TimeSettingsWorkday.ClickDeleteButton();

            //Click 'Give Up' button to cancel the deletion.
            TimeManager.ShortPause();
            TimeSettingsWorkday.ClickMsgBoxGiveUpButton();

            //Select the Calendar again.
            TimeSettingsWorkday.SelectCalendar(testData.InputData.CommonName);

            //Click 'Delete' button
            TimeManager.ShortPause();
            TimeSettingsWorkday.ClickDeleteButton();

            //Click 'x' icon to close the deletion confirmation popup.
            TimeManager.ShortPause();
            TimeSettingsWorkday.ClickMsgBoxCloseButton();

            //Verify that the Calendar is not deleted when cancel or close the window, and still exists in the list.
            TimeManager.ShortPause();
            Assert.IsTrue(TimeSettingsWorkday.IsCalendarExist(testData.InputData.CommonName));

            //Go to other tab(e.g. worktime tab), then back again, verify that the calendar still exists in the list.
            TimeSettingsWorktime.NavigatorToWorktimeCalendarSetting();
            TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
            TimeManager.MediumPause();
            Assert.IsTrue(TimeSettingsWorkday.IsCalendarExist(testData.InputData.CommonName));
        }
        #endregion

        #region TestCase2 DeleteWorkdayFailed
        /// <summary>
        /// Pre-condition: Prepare a Calendar, make sure it has been used by a hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorkday-Delete-002")]
        [CaseID("TC-J1-FVT-TimeManagementWorkday-Delete-002")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(WorkdayCalendarData[]), typeof(WorkdayDeleteSuite), "TC-J1-FVT-TimeManagementWorkday-Delete-002")]
        public void DeleteWorkdayFailed(WorkdayCalendarData testData)
        {
            //Select the Calendar.
            TimeSettingsWorkday.SelectCalendar(testData.InputData.CommonName);

            //Click 'Delete' button
            TimeManager.ShortPause();
            TimeSettingsWorkday.ClickDeleteButton();

            //Verify that the message 'Are your sure to delete it?' is displayed on message box.
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(testData.ExpectedData.PopMessage[0]));

            //Click 'Delete' button to confirm the deletion.
            TimeManager.ShortPause();
            TimeSettingsWorkday.ClickMsgBoxDeleteButton();
            TimeManager.LongPause();

            //Verify that error message like "Calendar has been used and can't be deleted" pops up.
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(testData.ExpectedData.PopMessage[1]));
            TimeManager.ShortPause();

            //Click 'OK' button to close the deletion failed message box.
            TimeManager.ShortPause();
            TimeSettingsWorkday.ClickMsgBoxOKButton();
            
            //Verify that the Calendar is not deleted and still exists in the list.
            TimeManager.ShortPause();
            Assert.IsTrue(TimeSettingsWorkday.IsCalendarExist(testData.InputData.CommonName));

            //Go to other tab(e.g. worktime tab), then back again, verify that the calendar still exists in the list.
            TimeSettingsWorktime.NavigatorToWorktimeCalendarSetting();
            TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
            TimeManager.MediumPause();
            Assert.IsTrue(TimeSettingsWorkday.IsCalendarExist(testData.InputData.CommonName));
        }
        #endregion
        
    }
}
