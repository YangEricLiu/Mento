﻿using System;
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
    public class WorktimeSuite : TestSuiteBase
    {
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
        [CaseID("TC-J1-SmokeTest-028")]
        [MultipleTestDataSource(typeof(WorktimeCalendarData[]), typeof(WorktimeSuite), "TC-J1-SmokeTest-028")]
        public void AddWorktimeTimeStrategy(WorktimeCalendarData testData)
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

            Assert.AreEqual(testData.InputData.Name, TimeSettingsWorktime.GetNameValue());
        }       
    }
}
