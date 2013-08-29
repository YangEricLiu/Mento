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
    public class SmokeTestHeatingCoolingSeasonSuite : TestSuiteBase
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
        [Priority("6")]
        [MultipleTestDataSource(typeof(HeatingCoolingSeasonCalendarData[]), typeof(SmokeTestHeatingCoolingSeasonSuite), "TC-J1-SmokeTest-030")]
        public void AddHeatingCoolingSeasonTimeStrategy(HeatingCoolingSeasonCalendarData testData)
        {
            TimeSettingsHeatingCoolingSeason.PrepareToAddHeatingCoolingSeasonCalendar();
            TimeManager.ShortPause();

            TimeSettingsHeatingCoolingSeason.FillInName(testData.InputData.CommonName);

            //Click '+' button if more than one warm record need to be entered
            //Amy's note: due to the order of dynamic element will be different if click the '+' icon after the first record has been input. That is why click + icon multiple times continuaslly here..       
            for (int elementPosition = 1; elementPosition < testData.InputData.WarmRange.Length; elementPosition++)
            {
                TimeSettingsHeatingCoolingSeason.ClickAddMoreWarmRangesButton();
                TimeManager.ShortPause();
            }

            //Input warm record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.WarmRange.Length; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                TimeSettingsHeatingCoolingSeason.SelectWarmStartMonth(testData.InputData.WarmRange[inputDataArrayPosition].StartMonth, elementPosition);
                TimeSettingsHeatingCoolingSeason.SelectWarmStartDate(testData.InputData.WarmRange[inputDataArrayPosition].StartDate, elementPosition);
                TimeSettingsHeatingCoolingSeason.SelectWarmEndMonth(testData.InputData.WarmRange[inputDataArrayPosition].EndMonth, elementPosition);
                TimeSettingsHeatingCoolingSeason.SelectWarmEndDate(testData.InputData.WarmRange[inputDataArrayPosition].EndDate, elementPosition);
            }

            //Click '+' button if more than one cold record need to be entered
            //Amy's note: due to the order of dynamic element will be different if click the '+' icon after the first record has been input. That is why click + icon multiple times continuaslly here..       
            for (int elementPosition = 1; elementPosition < testData.InputData.ColdRange.Length; elementPosition++)
            {
                TimeSettingsHeatingCoolingSeason.ClickAddMoreColdRangesButton();
                TimeManager.ShortPause();
            }

            //Input cold record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.ColdRange.Length; elementPosition++)
            {                
                int inputDataArrayPosition = elementPosition - 1;
                TimeSettingsHeatingCoolingSeason.SelectColdStartMonth(testData.InputData.ColdRange[inputDataArrayPosition].StartMonth, elementPosition);
                TimeSettingsHeatingCoolingSeason.SelectColdStartDate(testData.InputData.ColdRange[inputDataArrayPosition].StartDate, elementPosition);
                TimeSettingsHeatingCoolingSeason.SelectColdEndMonth(testData.InputData.ColdRange[inputDataArrayPosition].EndMonth, elementPosition);
                TimeSettingsHeatingCoolingSeason.SelectColdEndDate(testData.InputData.ColdRange[inputDataArrayPosition].EndDate, elementPosition);
            }

            TimeSettingsHeatingCoolingSeason.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify the name
            Assert.AreEqual(testData.InputData.CommonName, TimeSettingsHeatingCoolingSeason.GetNameValue());

            //Verify the warm record(s)
            //for (int elementPosition = 1; elementPosition <= testData.InputData.WarmRecordNumber; elementPosition++)
            //{
            //    int inputDataArrayPosition = elementPosition - 1;
            //    Assert.AreEqual(testData.InputData.WarmStartMonth[inputDataArrayPosition], TimeSettingsHeatingCoolingSeason.GetWarmStartMonthValue(elementPosition));
            //    Assert.AreEqual(testData.InputData.WarmStartDate[inputDataArrayPosition], TimeSettingsHeatingCoolingSeason.GetWarmStartDateValue(elementPosition));
            //    Assert.AreEqual(testData.InputData.WarmEndMonth[inputDataArrayPosition], TimeSettingsHeatingCoolingSeason.GetWarmEndMonthValue(elementPosition));
            //    Assert.AreEqual(testData.InputData.WarmEndDate[inputDataArrayPosition], TimeSettingsHeatingCoolingSeason.GetWarmEndDateValue(elementPosition));
            //}

            //Verify the cold record(s)
            //for (int elementPosition = 1; elementPosition <= testData.InputData.ColdRecordNumber; elementPosition++)
            //{
            //    int inputDataArrayPosition = elementPosition - 1;
            //    Assert.AreEqual(testData.InputData.ColdStartMonth[inputDataArrayPosition], TimeSettingsHeatingCoolingSeason.GetColdStartMonthValue(elementPosition));
            //    Assert.AreEqual(testData.InputData.ColdStartDate[inputDataArrayPosition], TimeSettingsHeatingCoolingSeason.GetColdStartDateValue(elementPosition));
            //    Assert.AreEqual(testData.InputData.ColdEndMonth[inputDataArrayPosition], TimeSettingsHeatingCoolingSeason.GetColdEndMonthValue(elementPosition));
            //    Assert.AreEqual(testData.InputData.ColdEndDate[inputDataArrayPosition], TimeSettingsHeatingCoolingSeason.GetColdEndDateValue(elementPosition));
            //}
        }
    }
}
