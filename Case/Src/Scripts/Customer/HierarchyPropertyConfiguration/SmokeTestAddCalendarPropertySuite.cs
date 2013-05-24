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
    [CreateTime("2012-12-31")]
    [ManualCaseID("TC-J1-SmokeTest-017")]
    public class SmokeTestAddCalendarPropertySuite : TestSuiteBase
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

        /// <summary>
        /// Precondition: 1. make sure there is hierarchy path "自动化测试"/"AddCalendarProperty"
        ///               2. make sure there is workday calendar with name '工休日日历1'
        ///               3. make sure there is worktime calendar with name '工作时间日历1'
        ///               4. These data will prepare on previous cases
        /// </summary>  
        ///
        [Test]
        [CaseID("TC-J1-SmokeTest-017")]
        [Priority("34")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(CalendarPropertyData[]), typeof(SmokeTestAddCalendarPropertySuite), "TC-J1-SmokeTest-017")]
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

        /// <summary>
        /// Precondition: 1. make sure there is hierarchy path "自动化测试"/"AddCalendarProperty"
        ///               2. make sure there is heatingcooling calendar with name '冷暖季日历1'
        ///               3. These data will prepare on previous cases
        /// </summary> 
        [Test]
        [CaseID("TC-J1-SmokeTest-017")]
        [Priority("34")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(CalendarPropertyData[]), typeof(SmokeTestAddCalendarPropertySuite), "TC-J1-SmokeTest-017")]
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

        /// <summary>
        /// Precondition: 1. make sure there is hierarchy path "自动化测试"/"AddCalendarProperty"
        ///               2. make sure there is heatingcooling calendar with name '昼夜时间日历1'
        ///               3. These data will prepare on previous cases
        /// </summary> 
        [Test]
        [CaseID("TC-J1-SmokeTest-017-003")]
        [Priority("34")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(CalendarPropertyData[]), typeof(SmokeTestAddCalendarPropertySuite), "TC-J1-SmokeTest-017")]
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
