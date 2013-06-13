using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.TestData;

namespace Mento.Script.Customer.HierarchyPropertyConfiguration
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2012-06-08")]
    [ManualCaseID("TC-J1-FVT-CalendarConfiguration-Modify")]
    public class ModifyCalendarPropertySuite : TestSuiteBase
    {
        private static HierarchySettings HierarchySettings = JazzFunction.HierarchySettings;
        private static HierarchyCalendarSettings CalendarSettings = JazzFunction.HierarchyCalendarSettings;

        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettings);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-CalendarConfiguration-Modify-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CalendarPropertyData[]), typeof(ModifyCalendarPropertySuite), "TC-J1-FVT-CalendarConfiguration-Modify-101-1")]
        public void ModifyWithoutChange(CalendarPropertyData input)
        {
            //Select hierarchy 
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Click calendar tab and create button "+日历属性"
            CalendarSettings.ClickCalendarTab();
            TimeManager.MediumPause();
            CalendarSettings.ClickCreateCalendarButton();
            TimeManager.ShortPause();
            
            //Modify nothing and Click "Save"
            CalendarSettings.ClickSaveCalendarButton();
            TimeManager.LongPause();

            //Verify the calendar display correct and label text is right--workday
            Assert.AreEqual(CalendarSettings.GetWorkdayEffectiveYearValue(), "2049");
            Assert.AreEqual(CalendarSettings.GetWorkdayCalendarNameValue(), input.ExpectedData.WorkdayCalendarName);
            Assert.IsTrue(CalendarSettings.IsWorkdayCalendarTextCorrect(input.ExpectedData.WorkdayText));
            
            Assert.AreEqual(CalendarSettings.GetWorkdayEffectiveYearValue_N(2), input.ExpectedData.WorkdayEffectiveDate);
            Assert.AreEqual(CalendarSettings.GetWorkdayCalendarNameValue_N(2), input.ExpectedData.WorkdayCalendarName);
            Assert.AreEqual(CalendarSettings.GetWorktimeCalendarNameValue_N(2), input.ExpectedData.WorktimeCalendarName);
            Assert.IsTrue(CalendarSettings.IsWorkdayCalendarTextCorrect_N(input.ExpectedData.WorkdayText, 2));
            Assert.IsTrue(CalendarSettings.IsWorktimeCalendarTextCorrect_N(input.ExpectedData.WorktimeText, 2));

            //Verify the calendar display correct and label text is right--Heating Cooling
            Assert.AreEqual(CalendarSettings.GetHeatingCoolingEffectiveYearValue(), "2015");
            Assert.AreEqual(CalendarSettings.GetHeatingCoolingCalendarNameValue(), input.ExpectedData.HeatingCoolingCalendarName);
            Assert.IsTrue(CalendarSettings.IsHeatingCoolingCalendarTextCorrect(input.ExpectedData.HeatingCoolingText));

            Assert.AreEqual(CalendarSettings.GetHeatingCoolingEffectiveYearValue_N(2), input.ExpectedData.HeatingCoolingEffectiveDate);
            Assert.AreEqual(CalendarSettings.GetHeatingCoolingCalendarNameValue_N(2), input.ExpectedData.HeatingCoolingCalendarName);
            Assert.IsTrue(CalendarSettings.IsHeatingCoolingCalendarTextCorrect_N(input.ExpectedData.HeatingCoolingText, 2));

            //Verify the calendar display correct and label text is right--DayNight
            Assert.AreEqual(CalendarSettings.GetDayNightEffectiveYearValue(), input.ExpectedData.DayNightEffectiveDate);
            Assert.AreEqual(CalendarSettings.GetDayNightCalendarNameValue(), input.ExpectedData.DayNightCalendarName);
            Assert.IsTrue(CalendarSettings.IsDayNightCalendarTextCorrect(input.ExpectedData.DayNightText));

            Assert.AreEqual(CalendarSettings.GetDayNightEffectiveYearValue_N(2), "2038");
            Assert.AreEqual(CalendarSettings.GetDayNightCalendarNameValue_N(2), input.ExpectedData.DayNightCalendarName);
            Assert.IsTrue(CalendarSettings.IsDayNightCalendarTextCorrect_N(input.ExpectedData.DayNightText, 2));
        }

        [Test]
        [CaseID("TC-J1-FVT-CalendarConfiguration-Modify-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CalendarPropertyData[]), typeof(ModifyCalendarPropertySuite), "TC-J1-FVT-CalendarConfiguration-Modify-101-2")]
        public void ModifyThenCancel(CalendarPropertyData input)
        {
            //Select hierarchy 
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Click calendar tab and create button "+日历属性"
            CalendarSettings.ClickCalendarTab();
            TimeManager.MediumPause();
            CalendarSettings.ClickCreateCalendarButton();
            TimeManager.ShortPause();

            //Modify nothing and Click "Save"
            CalendarSettings.ClickSaveCalendarButton();
            TimeManager.LongPause();

            //Verify the calendar display correct and label text is right--workday
            Assert.AreEqual(CalendarSettings.GetWorkdayEffectiveYearValue(), "2049");
            Assert.AreEqual(CalendarSettings.GetWorkdayCalendarNameValue(), input.ExpectedData.WorkdayCalendarName);
            Assert.IsTrue(CalendarSettings.IsWorkdayCalendarTextCorrect(input.ExpectedData.WorkdayText));

            Assert.AreEqual(CalendarSettings.GetWorkdayEffectiveYearValue_N(2), input.ExpectedData.WorkdayEffectiveDate);
            Assert.AreEqual(CalendarSettings.GetWorkdayCalendarNameValue_N(2), input.ExpectedData.WorkdayCalendarName);
            Assert.AreEqual(CalendarSettings.GetWorktimeCalendarNameValue_N(2), input.ExpectedData.WorktimeCalendarName);
            Assert.IsTrue(CalendarSettings.IsWorkdayCalendarTextCorrect_N(input.ExpectedData.WorkdayText, 2));
            Assert.IsTrue(CalendarSettings.IsWorktimeCalendarTextCorrect_N(input.ExpectedData.WorktimeText, 2));

            //Verify the calendar display correct and label text is right--Heating Cooling
            Assert.AreEqual(CalendarSettings.GetHeatingCoolingEffectiveYearValue(), "2015");
            Assert.AreEqual(CalendarSettings.GetHeatingCoolingCalendarNameValue(), input.ExpectedData.HeatingCoolingCalendarName);
            Assert.IsTrue(CalendarSettings.IsHeatingCoolingCalendarTextCorrect(input.ExpectedData.HeatingCoolingText));

            Assert.AreEqual(CalendarSettings.GetHeatingCoolingEffectiveYearValue_N(2), input.ExpectedData.HeatingCoolingEffectiveDate);
            Assert.AreEqual(CalendarSettings.GetHeatingCoolingCalendarNameValue_N(2), input.ExpectedData.HeatingCoolingCalendarName);
            Assert.IsTrue(CalendarSettings.IsHeatingCoolingCalendarTextCorrect_N(input.ExpectedData.HeatingCoolingText, 2));

            //Verify the calendar display correct and label text is right--DayNight
            Assert.AreEqual(CalendarSettings.GetDayNightEffectiveYearValue(), input.ExpectedData.DayNightEffectiveDate);
            Assert.AreEqual(CalendarSettings.GetDayNightCalendarNameValue(), input.ExpectedData.DayNightCalendarName);
            Assert.IsTrue(CalendarSettings.IsDayNightCalendarTextCorrect(input.ExpectedData.DayNightText));

            Assert.AreEqual(CalendarSettings.GetDayNightEffectiveYearValue_N(2), "2038");
            Assert.AreEqual(CalendarSettings.GetDayNightCalendarNameValue_N(2), input.ExpectedData.DayNightCalendarName);
            Assert.IsTrue(CalendarSettings.IsDayNightCalendarTextCorrect_N(input.ExpectedData.DayNightText, 2));
        }

    }
}
