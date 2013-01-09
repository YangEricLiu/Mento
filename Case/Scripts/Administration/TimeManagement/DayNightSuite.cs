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
    public class DayNightSuite : TestSuiteBase
    {
        private static TimeSettingsDayNight TimeSettingsDayNight = JazzFunction.TimeSettingsDayNight;
        [SetUp]
        public void CaseSetUp()
        {
            TimeSettingsDayNight.NavigatorToDaynightCalendarSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {   
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-029")]
        [MultipleTestDataSource(typeof(DayNightCalendarData[]), typeof(DayNightSuite), "TC-J1-SmokeTest-029")]
        public void AddDayNightTimeStrategy(DayNightCalendarData testData)
        {
            TimeSettingsDayNight.PrepareToAddDaynightCalendar();
            TimeManager.ShortPause();

            TimeSettingsDayNight.FillInName(testData.InputData.Name);
            
            //Input time range1
            TimeSettingsDayNight.SelectStartTime(testData.InputData.StartTime[0], testData.InputData.RecordGroupPosition[0]);
            TimeSettingsDayNight.SelectEndTime(testData.InputData.EndTime[0], testData.InputData.RecordGroupPosition[0]);

            TimeSettingsDayNight.ClickSaveButton();
            TimeManager.MediumPause();

            Assert.AreEqual(testData.InputData.Name, TimeSettingsDayNight.GetNameValue());
        }
    }
}
