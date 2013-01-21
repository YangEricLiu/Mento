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
        [Priority("6")]
        [MultipleTestDataSource(typeof(HeatingCoolingSeasonCalendarData[]), typeof(HeatingCoolingSeasonSuite), "TC-J1-SmokeTest-030")]
        public void AddHeatingCoolingSeasonTimeStrategy(HeatingCoolingSeasonCalendarData testData)
        {
            TimeSettingsHeatingCoolingSeason.PrepareToAddHeatingCoolingSeasonCalendar();
            TimeManager.ShortPause();

            TimeSettingsHeatingCoolingSeason.FillInName(testData.InputData.Name);
                      
            //Input warm record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.WarmRecordNumber; elementPosition++)
            {
                //Click '添加采暖季' button if more than one warm record need to be entered                    
                if (elementPosition > 1)
                {
                    TimeSettingsHeatingCoolingSeason.ClickAddMoreWarmRangesButton();
                    TimeManager.ShortPause();
                }

                int inputDataArrayPosition = elementPosition - 1;
                TimeSettingsHeatingCoolingSeason.SelectWarmStartMonth(testData.InputData.WarmStartMonth[inputDataArrayPosition], elementPosition);
                TimeSettingsHeatingCoolingSeason.SelectWarmStartDate(testData.InputData.WarmStartDate[inputDataArrayPosition], elementPosition);
                TimeSettingsHeatingCoolingSeason.SelectWarmEndMonth(testData.InputData.WarmEndMonth[inputDataArrayPosition], elementPosition);
                TimeSettingsHeatingCoolingSeason.SelectWarmEndDate(testData.InputData.WarmEndDate[inputDataArrayPosition], elementPosition);
            }

            //Input cold record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.ColdRecordNumber; elementPosition++)
            {
                //Click '添加供冷季' button if more than one cold record need to be entered                    
                if (elementPosition > 1)
                {
                    TimeSettingsHeatingCoolingSeason.ClickAddMoreColdRangesButton();
                    TimeManager.ShortPause();
                }

                int inputDataArrayPosition = elementPosition - 1;
                TimeSettingsHeatingCoolingSeason.SelectColdStartMonth(testData.InputData.ColdStartMonth[inputDataArrayPosition], elementPosition);
                TimeSettingsHeatingCoolingSeason.SelectColdStartDate(testData.InputData.ColdStartDate[inputDataArrayPosition], elementPosition);
                TimeSettingsHeatingCoolingSeason.SelectColdEndMonth(testData.InputData.ColdEndMonth[inputDataArrayPosition], elementPosition);
                TimeSettingsHeatingCoolingSeason.SelectColdEndDate(testData.InputData.ColdEndDate[inputDataArrayPosition], elementPosition);
            }

            TimeSettingsHeatingCoolingSeason.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify the name
            Assert.AreEqual(testData.InputData.Name, TimeSettingsHeatingCoolingSeason.GetNameValue());

            //Verify the warm record(s)
            for (int elementPosition = 1; elementPosition <= testData.InputData.WarmRecordNumber; elementPosition++)
            {
                int inputDataArrayPosition = testData.InputData.WarmRecordNumber - elementPosition; //Note: After saving, the second record will be displayed on top and become the first position. so inputDataArrayPosition doesn't equal to "elementPosition - 1" this time.
                Assert.AreEqual(testData.InputData.WarmStartMonth[inputDataArrayPosition], TimeSettingsHeatingCoolingSeason.GetWarmStartMonthValue(elementPosition));
                Assert.AreEqual(testData.InputData.WarmStartDate[inputDataArrayPosition], TimeSettingsHeatingCoolingSeason.GetWarmStartDateValue(elementPosition));
                Assert.AreEqual(testData.InputData.WarmEndMonth[inputDataArrayPosition], TimeSettingsHeatingCoolingSeason.GetWarmEndMonthValue(elementPosition));
                Assert.AreEqual(testData.InputData.WarmEndDate[inputDataArrayPosition], TimeSettingsHeatingCoolingSeason.GetWarmEndDateValue(elementPosition));
            }

            //Verify the cold record(s)
            for (int elementPosition = 1; elementPosition <= testData.InputData.ColdRecordNumber; elementPosition++)
            {
                int inputDataArrayPosition = testData.InputData.ColdRecordNumber - elementPosition;
                Assert.AreEqual(testData.InputData.ColdStartMonth[inputDataArrayPosition], TimeSettingsHeatingCoolingSeason.GetColdStartMonthValue(elementPosition));
                Assert.AreEqual(testData.InputData.ColdStartDate[inputDataArrayPosition], TimeSettingsHeatingCoolingSeason.GetColdStartDateValue(elementPosition));
                Assert.AreEqual(testData.InputData.ColdEndMonth[inputDataArrayPosition], TimeSettingsHeatingCoolingSeason.GetColdEndMonthValue(elementPosition));
                Assert.AreEqual(testData.InputData.ColdEndDate[inputDataArrayPosition], TimeSettingsHeatingCoolingSeason.GetColdEndDateValue(elementPosition));
            }
        }
    }
}
