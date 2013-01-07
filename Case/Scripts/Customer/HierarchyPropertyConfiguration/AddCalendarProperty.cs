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

namespace Mento.Script.Customer.HierarchyPropertyConfiguration
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2012-12-31")]
    [ManualCaseID("TC-J1-SmokeTest-019")]
    public class AddCalendarProperty : TestSuiteBase
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
            BrowserHandler.Refresh();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-017")]
        public void AddCalendarforWorkday()
        {
            HierarchySettings.ExpandNode("自动化测试");
            HierarchySettings.FocusOnHierarchyNode("AddCalendarProperty");

            CalendarSettings.ClickCalendarTab();
            TimeManager.ShortPause();
            CalendarSettings.ClickCreateCalendarButton();
            TimeManager.ShortPause();

            CalendarSettings.ClickWorkdayCreateButton();
            TimeManager.ShortPause();

            CalendarSettings.SelectWorkdayEffectiveYear("2002", 1);
            CalendarSettings.SelectWorkdayCalendarName("foraddcalendar1", 1);
            TimeManager.ShortPause();
            //HPropertySettings.ClickAddWorktimeLinkButton();
            CalendarSettings.ClickSaveCalendarButton();
            TimeManager.MediumPause();

            Assert.AreEqual(CalendarSettings.GetWorkdayEffectiveYearValue(), "2002");
            Assert.AreEqual(CalendarSettings.GetWorkdayCalendarNameValue(), "foraddcalendar1");
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-018")]
        public void AddCalendarforHeatingCooling()
        {
            HierarchySettings.ExpandNode("自动化测试");
            HierarchySettings.FocusOnHierarchyNode("AddCalendarProperty");

            CalendarSettings.ClickCalendarTab();
            TimeManager.ShortPause();
            CalendarSettings.ClickCreateCalendarButton();
            TimeManager.ShortPause();

            CalendarSettings.ClickHeatingCoolingCreateButton();
            TimeManager.ShortPause();

            CalendarSettings.SelectHeatingCoolingEffectiveYear("2002", 1);
            CalendarSettings.SelectHeatingCoolingCalendarName("foraddcalendar3", 1);
            TimeManager.ShortPause();
            CalendarSettings.ClickSaveCalendarButton();
            TimeManager.MediumPause();

            Assert.AreEqual(CalendarSettings.GetHeatingCoolingEffectiveYearValue(), "2002");
            Assert.AreEqual(CalendarSettings.GetHeatingCoolingCalendarNameValue(), "foraddcalendar3");
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-019")]
        public void AddCalendarforDayNight()
        {
            HierarchySettings.ExpandNode("自动化测试");
            HierarchySettings.FocusOnHierarchyNode("AddCalendarProperty");

            CalendarSettings.ClickCalendarTab();
            TimeManager.ShortPause();
            CalendarSettings.ClickCreateCalendarButton();
            TimeManager.ShortPause();

            CalendarSettings.ClickDayNightCreateButton();
            TimeManager.ShortPause();

            CalendarSettings.SelectDayNightEffectiveYear("2002", 1);
            CalendarSettings.SelectDayNightCalendarName("foraddcalendar4", 1);
            TimeManager.ShortPause();
            CalendarSettings.ClickSaveCalendarButton();
            TimeManager.MediumPause();

            Assert.AreEqual(CalendarSettings.GetDayNightEffectiveYearValue(), "2002");
            Assert.AreEqual(CalendarSettings.GetDayNightCalendarNameValue(), "foraddcalendar4");
        }
    }
}
