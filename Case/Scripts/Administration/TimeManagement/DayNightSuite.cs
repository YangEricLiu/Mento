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

            //Input 'Start Time' and 'End Time' for the record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.RecordNumber; elementPosition++)
            {
                //Click '添加白昼时间' button if more than one record need to be entered
                if (elementPosition > 1)
                {
                    TimeSettingsDayNight.ClickAddMoreRangesButton();
                    TimeManager.ShortPause();
                }

                int inputDataArrayPosition = elementPosition - 1;
                TimeSettingsDayNight.SelectStartTime(testData.InputData.StartTime[inputDataArrayPosition], elementPosition);
                TimeSettingsDayNight.SelectEndTime(testData.InputData.EndTime[inputDataArrayPosition], elementPosition);
            }

            TimeSettingsDayNight.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify the name
            Assert.AreEqual(testData.InputData.Name, TimeSettingsDayNight.GetNameValue());

            //Verify the label text
            Assert.IsTrue(TimeSettingsDayNight.IsDayNightCalendarTextCorrect(testData.ExpectedData.LabelText));

            //Verify 'Start Time' and 'End Time' of the record(s)
            for (int elementPosition = 1; elementPosition <= testData.InputData.RecordNumber; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                Assert.AreEqual(testData.InputData.StartTime[inputDataArrayPosition], TimeSettingsDayNight.GetStartTimeValue(elementPosition));
                Assert.AreEqual(testData.InputData.EndTime[inputDataArrayPosition], TimeSettingsDayNight.GetEndTimeValue(elementPosition));
            }
        }
    }
}
