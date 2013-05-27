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

namespace Mento.Script.TestScript.HierarchyPropertyConfiguration
{
    [TestFixture]    
    [Owner("Eric")]
    [CreateTime("2013-05-14")]
    [ManualCaseID("TA-Smoke-Calendar-001")]
    public class AddCalendarPropertySuite : TestSuiteBase
    {
        private static HierarchySettings HierarchySettings = JazzFunction.HierarchySettings;
        private static HierarchyCalendarSettings CalendarSettings = JazzFunction.HierarchyCalendarSettings;

        [SetUp]
        public void CaseSetUp()
        {
            JazzBrowseManager.RefreshJazz();
            JazzFunction.LoginPage.SelectCustomer("Auto_Customer");
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettings);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            
        }

        [Test]
        [CaseID("TA-Smoke-Calendar-001-001")]
        [Owner("Eric")]
        [MultipleTestDataSource(typeof(CalendarPropertyData[]), typeof(AddCalendarPropertySuite), "TA-Smoke-Calendar-001-001")]
        public void AddCalendar(CalendarPropertyData input)
        {
            AddCalendarforWorkday(input);
            AddCalendarforHeatingCooling(input);
            AddCalendarforDayNight(input);
        }
        public void AddCalendarforWorkday(CalendarPropertyData input)
        { 
            //Select hierarchy node "AddCalendarProperty"
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Click calendar tab and create button "+日历属性"
            CalendarSettings.ClickCalendarTab();
            TimeManager.ShortPause();
            CalendarSettings.ClickCreateCalendarButton();
            TimeManager.ShortPause();

            //Click "+" button
            CalendarSettings.ClickWorkdayCreateButton();
            TimeManager.ShortPause();

            //Click "添加工作时间" linkbutton
            CalendarSettings.ClickAddWorktimeLinkButton();
            TimeManager.MediumPause();

            //Select effective year and workday calendar
            CalendarSettings.FillInWorkdayCalendarValue(input.InputData);
            TimeManager.MediumPause();

            CalendarSettings.ClickSaveCalendarButton();
            TimeManager.MediumPause();

            //Verify the calendar display correct and label text is right
            Assert.AreEqual(CalendarSettings.GetWorkdayEffectiveYearValue(), input.ExpectedData.WorkdayEffectiveDate);
            Assert.AreEqual(CalendarSettings.GetWorkdayCalendarNameValue(), input.ExpectedData.WorkdayCalendarName);
            Assert.AreEqual(CalendarSettings.GetWorktimeCalendarNameValue(), input.ExpectedData.WorktimeCalendarName);
            Assert.IsTrue(CalendarSettings.IsWorkdayCalendarTextCorrect(input.ExpectedData.WorkdayText));
            Assert.IsTrue(CalendarSettings.IsWorktimeCalendarTextCorrect(input.ExpectedData.WorktimeText));
        }
        public void AddCalendarforHeatingCooling(CalendarPropertyData input)
        {
            //Select hierarchy node "AddCalendarProperty"
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Click calendar tab and create button "+日历属性"
            CalendarSettings.ClickCalendarTab();
            TimeManager.ShortPause();
            CalendarSettings.ClickCreateCalendarButton();
            TimeManager.ShortPause();

            //Click "+" button
            CalendarSettings.ClickHeatingCoolingCreateButton();
            TimeManager.ShortPause();

            //Select effective year and HeatingCooling calendar, save it
            CalendarSettings.FillInHeatingCoolingCalendarValue(input.InputData);
            TimeManager.ShortPause();
            CalendarSettings.ClickSaveCalendarButton();
            TimeManager.MediumPause();

            //Verify the calendar display correct and label text is right
            Assert.AreEqual(CalendarSettings.GetHeatingCoolingEffectiveYearValue(), input.ExpectedData.HeatingCoolingEffectiveDate);
            Assert.AreEqual(CalendarSettings.GetHeatingCoolingCalendarNameValue(), input.ExpectedData.HeatingCoolingCalendarName);
            Assert.IsTrue(CalendarSettings.IsHeatingCoolingCalendarTextCorrect(input.ExpectedData.HeatingCoolingText));
        }
        public void AddCalendarforDayNight(CalendarPropertyData input)
        {
            //Select hierarchy node "AddCalendarProperty"
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Click calendar tab and create button "+日历属性"
            CalendarSettings.ClickCalendarTab();
            TimeManager.ShortPause();
            CalendarSettings.ClickCreateCalendarButton();
            TimeManager.ShortPause();

            //Click "+" button
            CalendarSettings.ClickDayNightCreateButton();
            TimeManager.ShortPause();

            //Select effective year and DayNight calendar, save it
            CalendarSettings.FillInDayNightCalendarValue(input.InputData);
            TimeManager.ShortPause();
            CalendarSettings.ClickSaveCalendarButton();
            TimeManager.MediumPause();

            //Verify the calendar display correct and label text is right
            Assert.AreEqual(CalendarSettings.GetDayNightEffectiveYearValue(), input.ExpectedData.DayNightEffectiveDate);
            Assert.AreEqual(CalendarSettings.GetDayNightCalendarNameValue(), input.ExpectedData.DayNightCalendarName);
            Assert.IsTrue(CalendarSettings.IsDayNightCalendarTextCorrect(input.ExpectedData.DayNightText));
        }
    }
}
