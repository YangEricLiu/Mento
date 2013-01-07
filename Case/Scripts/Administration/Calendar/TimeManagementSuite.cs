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

namespace Mento.Script.Administration.Calendar
{
    [TestFixture]
    [Owner("Amy")]
    [CreateTime("2013-01-04")]
    [ManualCaseID("TC-J1-SmokeTest-027")]
    public class TimeManagementSuite: TestSuiteBase
    {
        private TimeSettingsWorkday TimeSettingsWorkday = JazzFunction.TimeSettingsWorkday;
        private TimeSettingsWorktime TimeSettingsWorktime = JazzFunction.TimeSettingsWorktime;
        [SetUp]
        public void CaseSetUp()
        {
            //TimeManagementSuite.NavigatorToWorkdayCalendarSetting();
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateHome();
            BrowserHandler.Refresh();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-027")]
        [MultipleTestDataSource(typeof(WorkdayCalendarData[]), typeof(TimeManagementSuite), "TC-J1-SmokeTest-027")]
        public void AddWorkdayCalendar(WorkdayCalendarData testData)
        {
            TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
            TimeSettingsWorkday.PrepareToAddWorkdayCalendar();
            TimeSettingsWorkday.FillInWorkdayCalendar(testData.InputData);

            TimeSettingsWorkday.ClickAddSpecialDateButton();
            TimeManager.ShortPause();

            TimeSettingsWorkday.SelectSpecialDateType("非工作日", 1);
            TimeManager.ShortPause();

            //Select start month
            TimeSettingsWorkday.SelectStartMonth("05", 1);
            TimeManager.ShortPause();

            //Select start date
            TimeSettingsWorkday.SelectStartDate("01", 1);
            TimeManager.ShortPause();

            //Select end month
            TimeSettingsWorkday.SelectEndMonth("05", 1);
            TimeManager.ShortPause();

            //Select end date
            TimeSettingsWorkday.SelectEndDate("07", 1);
            TimeManager.ShortPause();

            TimeSettingsWorkday.ClickSaveButton();
            TimeManager.MediumPause();

            Assert.AreEqual(testData.ExpectedData.Name, TimeSettingsWorkday.GetNameValue());
            // verify the text of  默认工作日 lable is displayed as '周一至周五'. this need to be added when the new control is complete.
            
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-028")]
        [MultipleTestDataSource(typeof(WorktimeCalendarData[]), typeof(TimeManagementSuite), "TC-J1-SmokeTest-028")]
        public void AddWorktimeCalendar(WorktimeCalendarData testData)
        {
            TimeSettingsWorktime.NavigatorToWorktimeCalendarSetting();
            TimeSettingsWorktime.PrepareToAddWorktimeCalendar();
            TimeManager.ShortPause();
            
            TimeSettingsWorktime.ClickAddMoreRangesButton();
            TimeManager.ShortPause();
            

            //TimeSettingsWorktime.FillInWorktimeCalendar(testData.InputData);

            //TimeSettingsWorktime.ClickAddMoreRangesButton();
            //TimeManager.ShortPause();

            ////Click 开始时间 combobox
            ////string selectStartMonthComboboxXpath = "//td[@id='st-calendar-items-container-bodyEl']/table[1]//div[1]//input[@name='StartFirstPart']";
            //string selectStartTimeComboboxXpath = "//td[@id='st-calendar-items-container-bodyEl']/table[1]//div[1]//input[@name='StartPart']";

            //ElementHandler.FindElement(new Locator(selectStartTimeComboboxXpath, ByType.XPath)).Click();
            //TimeManager.ShortPause();
            ////Select '05:30' from the time dropdown list 
            //string selectStartTimeValueXpath = "//div[contains(@class, 'x-boundlist-floating')][1]//ul/li[12]";
            //ElementHandler.FindElement(new Locator(selectStartTimeValueXpath, ByType.XPath)).Click();

            //Select start time
            //TimeSettingsWorktime.SelectStartTime("05:30", 1);
            //TimeManager.LongPause();

            //Select end time
            TimeSettingsWorktime.SelectEndTime("09:00", 1);
            TimeManager.ShortPause();

            //Select end time2
            TimeSettingsWorktime.SelectEndTime("09:30", 2);
            TimeManager.ShortPause();
            
            //TimeSettingsWorktime.ClickSaveButton();
            //TimeManager.MediumPause();

            //Assert.AreEqual(testData.ExpectedData.Name, TimeSettingsWorktime.GetNameValue());
            
        }
    }
}
