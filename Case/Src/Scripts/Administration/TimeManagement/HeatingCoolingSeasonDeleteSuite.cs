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
    public class HeatingCoolingSeasonDeleteSuite : TestSuiteBase
    {
        private static TimeSettingsHeatingCoolingSeason TimeSettingsHeatingCoolingSeason = JazzFunction.TimeSettingsHeatingCoolingSeason;
        private static TimeSettingsWorkday TimeSettingsWorkday = JazzFunction.TimeSettingsWorkday;
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

        #region TestCase1 DeleteHCSeasonSuccessful
        /// <summary>
        /// Pre-condition: Prepare a Calendar, make sure it is NOT being used by any hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementHCSeason-Delete-101")]
        [CaseID("TC-J1-FVT-TimeManagementHCSeason-Delete-101")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(HeatingCoolingSeasonCalendarData[]), typeof(HeatingCoolingSeasonDeleteSuite), "TC-J1-FVT-TimeManagementHCSeason-Delete-101")]
        public void DeleteHCSeasonSuccessful(HeatingCoolingSeasonCalendarData testData)
        {
            //Select the Calendar.
            TimeSettingsHeatingCoolingSeason.SelectCalendar(testData.InputData.CommonName);

            //Click 'Delete' button
            TimeManager.ShortPause();
            TimeSettingsHeatingCoolingSeason.ClickDeleteButton();

            //Click 'Delete' button on the confirmation window.
            TimeManager.ShortPause();
            TimeSettingsHeatingCoolingSeason.ClickMsgBoxDeleteButton();
            
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Verify that the Calendar is deleted successfully and NOT exists in the list.
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsCalendarExist(testData.InputData.CommonName));

            //Go to other tab(e.g. workday tab), then back again, verify that the deleted calendar NOT exists in the list.
            TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
            TimeSettingsHeatingCoolingSeason.NavigatorToHeatingCoolingSeasonCalendarSetting();
            TimeManager.MediumPause();
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsCalendarExist(testData.InputData.CommonName));
        
        }
        #endregion

        #region TestCase1 DeleteHCSeasonCancelled
        /// <summary>
        /// Pre-condition: Prepare a Calendar, make sure it is NOT being used by any hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementHCSeason-Delete-001")]
        [CaseID("TC-J1-FVT-TimeManagementHCSeason-Delete-001")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(HeatingCoolingSeasonCalendarData[]), typeof(HeatingCoolingSeasonDeleteSuite), "TC-J1-FVT-TimeManagementHCSeason-Delete-001")]
        public void DeleteHCSeasonCancelled(HeatingCoolingSeasonCalendarData testData)
        {
            //Select the Calendar.
            TimeSettingsHeatingCoolingSeason.SelectCalendar(testData.InputData.CommonName);        
            
            //Click 'Delete' button
            TimeManager.ShortPause();
            TimeSettingsHeatingCoolingSeason.ClickDeleteButton();

            //Click 'Give Up' button to cancel the deletion.
            TimeManager.ShortPause();
            TimeSettingsHeatingCoolingSeason.ClickMsgBoxGiveUpButton();

            //Select the Calendar again.
            TimeSettingsHeatingCoolingSeason.SelectCalendar(testData.InputData.CommonName);

            //Click 'Delete' button
            TimeManager.ShortPause();
            TimeSettingsHeatingCoolingSeason.ClickDeleteButton();

            //Click 'x' icon to close the deletion confirmation popup.
            TimeManager.ShortPause();
            TimeSettingsHeatingCoolingSeason.ClickMsgBoxCloseButton();

            //Verify that the Calendar is not deleted when cancel or close the window, and still exists in the list.
            TimeManager.ShortPause();
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsCalendarExist(testData.InputData.CommonName));

            //Go to other tab(e.g. workday tab), then back again, verify that the calendar still exists in the list.
            TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
            TimeSettingsHeatingCoolingSeason.NavigatorToHeatingCoolingSeasonCalendarSetting();
            TimeManager.MediumPause();
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsCalendarExist(testData.InputData.CommonName));
        }
        #endregion

        #region TestCase2 DeleteHCSeasonFailed
        /// <summary>
        /// Pre-condition: Prepare a Calendar, make sure it has been used by a hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementHCSeason-Delete-002")]
        [CaseID("TC-J1-FVT-TimeManagementHCSeason-Delete-002")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(HeatingCoolingSeasonCalendarData[]), typeof(HeatingCoolingSeasonDeleteSuite), "TC-J1-FVT-TimeManagementHCSeason-Delete-002")]
        public void DeleteHCSeasonFailed(HeatingCoolingSeasonCalendarData testData)
        {
            //Select the Calendar.
            TimeSettingsHeatingCoolingSeason.SelectCalendar(testData.InputData.CommonName);

            //Click 'Delete' button
            TimeManager.ShortPause();
            TimeSettingsHeatingCoolingSeason.ClickDeleteButton();
            
            //Verify that the message 'Are your sure to delete it?' is displayed on message box.
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(testData.ExpectedData.PopMessage[0]));

            //Click 'Delete' button to confirm the deletion.
            TimeManager.ShortPause();
            TimeSettingsHeatingCoolingSeason.ClickMsgBoxDeleteButton();
            TimeManager.LongPause();

            //Verify that error message like "Calendar has been used and can't be deleted" pops up.
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(testData.ExpectedData.PopMessage[1]));
            TimeManager.ShortPause();

            //Click 'OK' button to close the deletion failed message box.
            TimeManager.ShortPause();
            TimeSettingsHeatingCoolingSeason.ClickMsgBoxOKButton();
            
            //Verify that the Calendar is not deleted and still exists in the list.
            TimeManager.ShortPause();
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsCalendarExist(testData.InputData.CommonName));

            //Go to other tab(e.g. workday tab), then back again, verify that the calendar still exists in the list.
            TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
            TimeSettingsHeatingCoolingSeason.NavigatorToHeatingCoolingSeasonCalendarSetting();
            TimeManager.MediumPause();
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsCalendarExist(testData.InputData.CommonName));
        }
        #endregion
        
    }
}
