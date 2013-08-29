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
    public class SmokeTestWorkdaySuite : TestSuiteBase
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
        [Priority("6")]
        [MultipleTestDataSource(typeof(WorkdayCalendarData[]), typeof(SmokeTestWorkdaySuite), "TC-J1-SmokeTest-027")]
        public void AddWorkdayTimeStrategy(WorkdayCalendarData testData)
        {
            TimeSettingsWorkday.PrepareToAddWorkdayCalendar();
            TimeManager.ShortPause();

            TimeSettingsWorkday.FillInName(testData.InputData.CommonName);

            //Click '+' icon each time when add a special date record
            //Amy's note: due to the order of dynamic element will be different if click the '+' icon after the first record has been input. That is why click + icon multiple times continuaslly here..        
            //for (int elementPosition = 1; elementPosition <= testData.InputData.RecordNumber; elementPosition++)
            //{
            //    TimeSettingsWorkday.ClickAddSpecialDateButton();
            //    TimeManager.ShortPause();
            //}

            //Input record(s) based on the input data file
            //for (int elementPosition = 1; elementPosition <= testData.InputData.RecordNumber; elementPosition++)
            //{
            //    int inputDataArrayPosition = elementPosition - 1;
            //    TimeSettingsWorkday.SelectSpecialDateType(testData.InputData.SpecialDateType[inputDataArrayPosition], elementPosition);
            //    TimeSettingsWorkday.SelectStartMonth(testData.InputData.StartMonth[inputDataArrayPosition], elementPosition);
            //    TimeSettingsWorkday.SelectStartDate(testData.InputData.StartDate[inputDataArrayPosition], elementPosition);
            //    TimeSettingsWorkday.SelectEndMonth(testData.InputData.EndMonth[inputDataArrayPosition], elementPosition);
            //    TimeSettingsWorkday.SelectEndDate(testData.InputData.EndDate[inputDataArrayPosition], elementPosition);
            //}

            TimeSettingsWorkday.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify the name
            Assert.AreEqual(testData.InputData.CommonName, TimeSettingsWorkday.GetNameValue());

            //Verify the label text
            Assert.IsTrue(TimeSettingsWorkday.IsWorkdayCalendarTextCorrect(testData.ExpectedData.LabelText));

            //Verify the record(s)
            //for (int elementPosition = 1; elementPosition <= testData.InputData.RecordNumber; elementPosition++)
            //{
            //    int inputDataArrayPosition = testData.InputData.RecordNumber - elementPosition; 
            //    Assert.AreEqual(testData.InputData.SpecialDateType[inputDataArrayPosition], TimeSettingsWorkday.GetSpecialDateTypeValue(elementPosition));
            //    Assert.AreEqual(testData.InputData.StartMonth[inputDataArrayPosition], TimeSettingsWorkday.GetStartMonthValue(elementPosition));
            //    Assert.AreEqual(testData.InputData.StartDate[inputDataArrayPosition], TimeSettingsWorkday.GetStartDateValue(elementPosition));
            //    Assert.AreEqual(testData.InputData.EndMonth[inputDataArrayPosition], TimeSettingsWorkday.GetEndMonthValue(elementPosition));
            //    Assert.AreEqual(testData.InputData.EndDate[inputDataArrayPosition], TimeSettingsWorkday.GetEndDateValue(elementPosition));
            //}
            
        }        
    }
}
