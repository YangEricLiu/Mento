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
    public class WorktimeSuite : TestSuiteBase
    {
        private static TimeSettingsWorktime TimeSettingsWorktime = JazzFunction.TimeSettingsWorktime;
        [SetUp]
        public void CaseSetUp()
        {
            TimeSettingsWorktime.NavigatorToWorktimeCalendarSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-028")]
        [MultipleTestDataSource(typeof(WorktimeCalendarData[]), typeof(WorktimeSuite), "TC-J1-SmokeTest-028")]
        public void AddWorktimeTimeStrategy(WorktimeCalendarData testData)
        {
            TimeSettingsWorktime.PrepareToAddWorktimeCalendar();
            TimeManager.ShortPause();

            TimeSettingsWorktime.FillInName(testData.InputData.Name);

            //Input 'Start Time' and 'End Time' for the record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.RecordNumber; elementPosition++)
            {
                //Click '添加工作时间' button if more than one record need to be entered
                if (elementPosition > 1)
                {                    
                    TimeSettingsWorktime.ClickAddMoreRangesButton();
                    TimeManager.ShortPause();
                }

                int inputDataArrayPosition = elementPosition - 1;
                TimeSettingsWorktime.SelectStartTime(testData.InputData.StartTime[inputDataArrayPosition], elementPosition);
                TimeSettingsWorktime.SelectEndTime(testData.InputData.EndTime[inputDataArrayPosition], elementPosition);                TimeManager.ShortPause();
            }

            TimeSettingsWorktime.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify the name
            Assert.AreEqual(testData.InputData.Name, TimeSettingsWorktime.GetNameValue());

            //Verify the label text
            Assert.IsTrue(TimeSettingsWorktime.IsWorktimeCalendarTextCorrect(testData.ExpectedData.LabelText));

            //Verify 'Start Time' and 'End Time' of the record(s)
            for (int elementPosition = 1; elementPosition <= testData.InputData.RecordNumber; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                Assert.AreEqual(testData.InputData.StartTime[inputDataArrayPosition], TimeSettingsWorktime.GetStartTimeValue(elementPosition));
                Assert.AreEqual(testData.InputData.EndTime[inputDataArrayPosition], TimeSettingsWorktime.GetEndTimeValue(elementPosition));
            }
        }       
    }
}
