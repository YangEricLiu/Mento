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
    [ManualCaseID("TC-J1-SmokeTest")]
    public class TimeManagementSuite: TestSuiteBase
    {
        private TimeSettingsWorkday TimeSettingsWorkday = JazzFunction.TimeSettingsWorkday;
        private TimeSettingsWorktime TimeSettingsWorktime = JazzFunction.TimeSettingsWorktime;
        [SetUp]
        public void CaseSetUp()
        {            
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateHome();
            //BrowserHandler.Refresh();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-027")]
        [MultipleTestDataSource(typeof(WorkdayCalendarData[]), typeof(TimeManagementSuite), "TC-J1-SmokeTest-027")]
        public void AddWorkdayCalendar(WorkdayCalendarData testData)
        {
            TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
            TimeSettingsWorkday.PrepareToAddWorkdayCalendar();

            TimeSettingsWorkday.FillInName(testData.InputData.Name);

            //Click '+' icon to add a special date record
            TimeSettingsWorkday.ClickAddSpecialDateButton();
            TimeManager.ShortPause();

            //Click '+' icon again to add second special date record
            TimeSettingsWorkday.ClickAddSpecialDateButton();
            TimeManager.ShortPause();

            //Amy's note: due to the order of dynamic element will be different if click the '+' icon after the first record has been input. That is why click + icon twice continuaslly: the implementation for finding element(xpath for 'ComboBoxItem' in ControlLocatorMap.xml) needs to be enhanced later..
            
            //Input special date type, start month,  start date, end month, end date for the first record
            TimeSettingsWorkday.SelectSpecialDateType(testData.InputData.SpecialDateType[0], testData.InputData.RecordGroupPosition[0]);
            TimeManager.ShortPause();
            TimeSettingsWorkday.SelectStartMonth(testData.InputData.StartMonth[0], testData.InputData.RecordGroupPosition[0]);
            TimeManager.ShortPause();
            TimeSettingsWorkday.SelectStartDate(testData.InputData.StartDate[0], testData.InputData.RecordGroupPosition[0]);
            TimeManager.ShortPause();
            TimeSettingsWorkday.SelectEndMonth(testData.InputData.EndMonth[0], testData.InputData.RecordGroupPosition[0]);
            TimeManager.ShortPause();
            TimeSettingsWorkday.SelectEndDate(testData.InputData.EndDate[0], testData.InputData.RecordGroupPosition[0]);
            TimeManager.ShortPause();

            //Input special date type, start month,  start date, end month, end date for the second record
            TimeSettingsWorkday.SelectSpecialDateType(testData.InputData.SpecialDateType[1], testData.InputData.RecordGroupPosition[1]);
            TimeManager.ShortPause();
            TimeSettingsWorkday.SelectStartMonth(testData.InputData.StartMonth[1], testData.InputData.RecordGroupPosition[1]);
            TimeManager.ShortPause();
            TimeSettingsWorkday.SelectStartDate(testData.InputData.StartDate[1], testData.InputData.RecordGroupPosition[1]);
            TimeManager.ShortPause();
            TimeSettingsWorkday.SelectEndMonth(testData.InputData.EndMonth[1], testData.InputData.RecordGroupPosition[1]);
            TimeManager.ShortPause();
            TimeSettingsWorkday.SelectEndDate(testData.InputData.EndDate[1], testData.InputData.RecordGroupPosition[1]);
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

            TimeSettingsWorktime.FillInName(testData.InputData.Name);

            //Click '添加工作时间' link button to add one more time range record
            TimeSettingsWorktime.ClickAddMoreRangesButton();
            TimeManager.ShortPause();

            //Input start time,  end time for the first record
            TimeSettingsWorktime.SelectStartTime(testData.InputData.StartTime[0], testData.InputData.RecordGroupPosition[0]);
            TimeManager.ShortPause();
            TimeSettingsWorktime.SelectEndTime(testData.InputData.EndTime[0], testData.InputData.RecordGroupPosition[0]);
            TimeManager.ShortPause();

            //Input start time,  end time for the second record
            TimeSettingsWorktime.SelectStartTime(testData.InputData.StartTime[1], testData.InputData.RecordGroupPosition[1]);
            TimeManager.ShortPause();
            TimeSettingsWorktime.SelectEndTime(testData.InputData.EndTime[1], testData.InputData.RecordGroupPosition[1]);
            TimeManager.ShortPause();

            TimeSettingsWorktime.ClickSaveButton();
            TimeManager.MediumPause();

            Assert.AreEqual(testData.ExpectedData.Name, TimeSettingsWorktime.GetNameValue());
            
        }
    }
}
