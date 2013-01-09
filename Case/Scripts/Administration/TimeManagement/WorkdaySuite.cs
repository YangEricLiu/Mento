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
    [ManualCaseID("TC-J1-SmokeTest")]
    public class WorkdaySuite : TestSuiteBase
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

        [Test]
        [CaseID("TC-J1-SmokeTest-027")]
        [MultipleTestDataSource(typeof(WorkdayCalendarData[]), typeof(WorkdaySuite), "TC-J1-SmokeTest-027")]
        public void AddWorkdayTimeStrategy(WorkdayCalendarData testData)
        {
            TimeSettingsWorkday.PrepareToAddWorkdayCalendar();
            TimeManager.ShortPause();

            TimeSettingsWorkday.FillInName(testData.InputData.Name);

            //Click '+' icon to add a special date record
            TimeSettingsWorkday.ClickAddSpecialDateButton();
            TimeManager.ShortPause();

            //Click '+' icon again to add second special date record
            TimeSettingsWorkday.ClickAddSpecialDateButton();
            TimeManager.ShortPause();

            //Amy's note: due to the order of dynamic element will be different if click the '+' icon after the first record has been input. That is why click + icon twice continuaslly: the implementation for finding element(xpath for 'ComboBoxItem' in ControlLocatorMap.xml) needs to be enhanced later..

            //Input date range1
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

            //Input date range2
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

            Assert.AreEqual(testData.InputData.Name, TimeSettingsWorkday.GetNameValue());
            // verify the text of  默认工作日 lable is displayed as '周一至周五'. this need to be added when the new control is complete.
            
        }        
    }
}
