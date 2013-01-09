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
    public class HeatingCoolingSeasonSuite : TestSuiteBase
    {
        private static TimeSettingsHeatingCoolingSeason TimeSettingsHeatingCoolingSeason = JazzFunction.TimeSettingsHeatingCoolingSeason;
        [SetUp]
        public void CaseSetUp()
        {
            TimeSettingsHeatingCoolingSeason.NavigatorToHeatingCoolingSeasonCalendarSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-030")]
        [MultipleTestDataSource(typeof(HeatingCoolingSeasonCalendarData[]), typeof(HeatingCoolingSeasonSuite), "TC-J1-SmokeTest-030")]
        public void AddHeatingCoolingSeasonTimeStrategy(HeatingCoolingSeasonCalendarData testData)
        {
            TimeSettingsHeatingCoolingSeason.PrepareToAddHeatingCoolingSeasonCalendar();
            TimeManager.ShortPause();

            TimeSettingsHeatingCoolingSeason.FillInName(testData.InputData.Name);

            //Input warm date range1
            TimeSettingsHeatingCoolingSeason.SelectWarmStartMonth(testData.InputData.WarmStartMonth[0], testData.InputData.WarmRecordGroupPosition[0]);
            TimeSettingsHeatingCoolingSeason.SelectWarmStartDate(testData.InputData.WarmStartDate[0], testData.InputData.WarmRecordGroupPosition[0]);
            TimeSettingsHeatingCoolingSeason.SelectWarmEndMonth(testData.InputData.WarmEndMonth[0], testData.InputData.WarmRecordGroupPosition[0]);
            TimeSettingsHeatingCoolingSeason.SelectWarmEndDate(testData.InputData.WarmEndDate[0], testData.InputData.WarmRecordGroupPosition[0]);

            //Click '添加采暖季' button to add one more warm date range record
            TimeSettingsHeatingCoolingSeason.ClickAddMoreWarmRangesButton();

            //Input warm date range2
            TimeSettingsHeatingCoolingSeason.SelectWarmStartMonth(testData.InputData.WarmStartMonth[1], testData.InputData.WarmRecordGroupPosition[1]);
            TimeSettingsHeatingCoolingSeason.SelectWarmStartDate(testData.InputData.WarmStartDate[1], testData.InputData.WarmRecordGroupPosition[1]);
            TimeSettingsHeatingCoolingSeason.SelectWarmEndMonth(testData.InputData.WarmEndMonth[1], testData.InputData.WarmRecordGroupPosition[1]);
            TimeSettingsHeatingCoolingSeason.SelectWarmEndDate(testData.InputData.WarmEndDate[1], testData.InputData.WarmRecordGroupPosition[1]);

            //Input cold date range1
            TimeSettingsHeatingCoolingSeason.SelectColdStartMonth(testData.InputData.ColdStartMonth[0], testData.InputData.ColdRecordGroupPosition[0]);
            TimeSettingsHeatingCoolingSeason.SelectColdStartDate(testData.InputData.ColdStartDate[0], testData.InputData.ColdRecordGroupPosition[0]);
            TimeSettingsHeatingCoolingSeason.SelectColdEndMonth(testData.InputData.ColdEndMonth[0], testData.InputData.ColdRecordGroupPosition[0]);
            TimeSettingsHeatingCoolingSeason.SelectColdEndDate(testData.InputData.ColdEndDate[0], testData.InputData.ColdRecordGroupPosition[0]);


            TimeSettingsHeatingCoolingSeason.ClickSaveButton();
            TimeManager.MediumPause();

            Assert.AreEqual(testData.InputData.Name, TimeSettingsHeatingCoolingSeason.GetNameValue());
        }
    }
}
