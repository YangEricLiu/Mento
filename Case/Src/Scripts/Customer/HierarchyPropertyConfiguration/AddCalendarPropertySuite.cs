﻿using System;
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
    public class AddCalendarPropertySuite : TestSuiteBase
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
        [MultipleTestDataSource(typeof(CalendarPropertyData[]), typeof(AddCalendarPropertySuite), "TC-J1-SmokeTest-017")]
        public void AddCalendarforWorkday(CalendarPropertyData testData)
        { 
            string[] calendarText = new string[] { "默认工作日", "周一至周五", "工作日", "10月25日至10月31日", "休息日", "5月1日至5月7日" };
            string[] workTimecalendarText = new string[] { "非工作时间", "工作时间以外均为非工作时间", "工作时间", "08:30-12:00 13:00-17:30" };

            //Select hierarchy node "AddCalendarProperty"
            HierarchySettings.ExpandNode("自动化测试");
            HierarchySettings.SelectHierarchyNode("AddCalendarProperty");

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
            CalendarSettings.FillInWorkdayCalendarValue(testData.InputData);
            TimeManager.MediumPause();

            CalendarSettings.ClickSaveCalendarButton();
            TimeManager.MediumPause();

            //Verify the calendar display correct and label text is right
            Assert.AreEqual(CalendarSettings.GetWorkdayEffectiveYearValue(), "2002");
            Assert.AreEqual(CalendarSettings.GetWorkdayCalendarNameValue(), "工休日日历1");
            Assert.AreEqual(CalendarSettings.GetWorktimeCalendarNameValue(), "工作时间日历1");
            Assert.IsTrue(CalendarSettings.IsWorkdayCalendarTextCorrect(calendarText));
            Assert.IsTrue(CalendarSettings.IsWorktimeCalendarTextCorrect(workTimecalendarText));
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
        [MultipleTestDataSource(typeof(CalendarPropertyData[]), typeof(AddCalendarPropertySuite), "TC-J1-SmokeTest-017")]
        public void AddCalendarforHeatingCooling(CalendarPropertyData testData)
        {
            string[] calendarText = new string[] { "采暖季", "1月1日至3月15日 11月15日至12月31日", "供冷季", "5月31日至8月31日" };

            //Select hierarchy node "AddCalendarProperty"
            HierarchySettings.ExpandNode("自动化测试");
            HierarchySettings.SelectHierarchyNode("AddCalendarProperty");

            //Click calendar tab and create button "+日历属性"
            CalendarSettings.ClickCalendarTab();
            TimeManager.ShortPause();
            CalendarSettings.ClickCreateCalendarButton();
            TimeManager.ShortPause();

            //Click "+" button
            CalendarSettings.ClickHeatingCoolingCreateButton();
            TimeManager.ShortPause();

            //Select effective year and HeatingCooling calendar, save it
            CalendarSettings.FillInHeatingCoolingCalendarValue(testData.InputData);
            TimeManager.ShortPause();
            CalendarSettings.ClickSaveCalendarButton();
            TimeManager.MediumPause();

            //Verify the calendar display correct and label text is right
            Assert.AreEqual(CalendarSettings.GetHeatingCoolingEffectiveYearValue(), "2002");
            Assert.AreEqual(CalendarSettings.GetHeatingCoolingCalendarNameValue(), "冷暖季日历1");
            Assert.IsTrue(CalendarSettings.IsHeatingCoolingCalendarTextCorrect(calendarText));
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
        [MultipleTestDataSource(typeof(CalendarPropertyData[]), typeof(AddCalendarPropertySuite), "TC-J1-SmokeTest-017")]
        public void AddCalendarforDayNight(CalendarPropertyData testData)
        {
            string[] calendarText = new string[] { "黑夜时间", "白昼时间以外均为黑夜时间", "白昼时间", "05:30-18:00" };

            //Select hierarchy node "AddCalendarProperty"
            HierarchySettings.ExpandNode("自动化测试");
            HierarchySettings.SelectHierarchyNode("AddCalendarProperty");

            //Click calendar tab and create button "+日历属性"
            CalendarSettings.ClickCalendarTab();
            TimeManager.ShortPause();
            CalendarSettings.ClickCreateCalendarButton();
            TimeManager.ShortPause();

            //Click "+" button
            CalendarSettings.ClickDayNightCreateButton();
            TimeManager.ShortPause();

            //Select effective year and DayNight calendar, save it
            CalendarSettings.FillInDayNightCalendarValue(testData.InputData) ;
            TimeManager.ShortPause();
            CalendarSettings.ClickSaveCalendarButton();
            TimeManager.MediumPause();

            //Verify the calendar display correct and label text is right
            Assert.AreEqual(CalendarSettings.GetDayNightEffectiveYearValue(), "2002");
            Assert.AreEqual(CalendarSettings.GetDayNightCalendarNameValue(), "昼夜时间日历1");
            Assert.IsTrue(CalendarSettings.IsDayNightCalendarTextCorrect(calendarText));
        }
    }
}