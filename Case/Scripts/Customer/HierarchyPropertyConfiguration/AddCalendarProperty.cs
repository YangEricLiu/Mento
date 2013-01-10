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
    [ManualCaseID("TC-J1-SmokeTest-017")]
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
        [CaseID("TC-J1-SmokeTest-017-001")]
        [Priority("P1")]
        [Type("Smoke")]
        public void AddCalendarforWorkday()
        {
            string[] calendarText = new string[] { "默认工作日：", "周一至周五" };
            
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
            Assert.IsTrue(CalendarSettings.IsWorkdayCalendarTextCorrect(calendarText));
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-017-002")]
        [Priority("P1")]
        [Type("Smoke")]
        public void AddCalendarforHeatingCooling()
        {
            string[] calendarText = new string[] { "采暖季：", "1月1日至2月1日", "供冷季：", "10月1日至11月1日" };

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
            Assert.IsTrue(CalendarSettings.IsHeatingCoolingCalendarTextCorrect(calendarText));
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-017-003")]
        [Priority("P1")]
        [Type("Smoke")]
        public void AddCalendarforDayNight()
        {
            string[] calendarText = new string[] { "黑夜时间：", "白昼时间以外均为黑夜时间", "白昼时间：", "06:00-17:00" };

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
            Assert.IsTrue(CalendarSettings.IsDayNightCalendarTextCorrect(calendarText));
        }
    }
}
