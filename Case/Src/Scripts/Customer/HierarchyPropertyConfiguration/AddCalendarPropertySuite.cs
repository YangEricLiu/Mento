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
    [ManualCaseID("TC-J1-FVT-CalendarConfiguration-Add")]
    public class AddCalendarPropertySuite : TestSuiteBase
    {
        private static HierarchySettings HierarchySettings = JazzFunction.HierarchySettings;
        private static HierarchyCalendarSettings CalendarSettings = JazzFunction.HierarchyCalendarSettings;

        [SetUp]
        public void CaseSetUp()
        {
            HierarchySettings.NavigatorToHierarchySetting();
        }

        [TearDown]
        public void CaseTearDown()
        {
            HierarchySettings.NavigatorToNonHierarchy();
        }

        [Test]
        [CaseID("TC-J1-FVT-CalendarConfiguration-Add-001-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CalendarPropertyData[]), typeof(AddCalendarPropertySuite), "TC-J1-FVT-CalendarConfiguration-Add-001-1")]
        public void SaveWithoutInput(CalendarPropertyData input)
        { 
            //Select hierarchy 
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            
            //Hierarchy support calendar
            Assert.IsTrue(CalendarSettings.IsCalendarTabEnable());

            //Click "日历属性" tab button
            CalendarSettings.ClickCalendarTab();
            TimeManager.LongPause();
            CalendarSettings.ClickCreateCalendarButton();
            TimeManager.MediumPause();

            //Input nothing and click save
            CalendarSettings.ClickSaveCalendarButton();
            TimeManager.MediumPause();

            //"+日历属性" button display
            CalendarSettings.IsCreateCalendarButtonDisplayed();
        }

        [Test]
        [CaseID("TC-J1-FVT-CalendarConfiguration-Add-001-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CalendarPropertyData[]), typeof(AddCalendarPropertySuite), "TC-J1-FVT-CalendarConfiguration-Add-001-2")]
        public void AllEmptyFields(CalendarPropertyData input)
        {
            //Select hierarchy 
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Click calendar tab and create button "+日历属性"
            CalendarSettings.ClickCalendarTab();
            TimeManager.ShortPause();
            CalendarSettings.ClickCreateCalendarButton();
            TimeManager.ShortPause();

            //Click "+" button for '工休日'
            CalendarSettings.ClickWorkdayCreateButton();
            TimeManager.ShortPause();

            //Click "添加工作时间" linkbutton
            CalendarSettings.ClickAddWorktimeLinkButton();
            TimeManager.MediumPause();

            //Click "+" button for '冷暖季'
            CalendarSettings.ClickHeatingCoolingCreateButton();
            TimeManager.ShortPause();

            //Click "+" button for '昼夜时间'
            CalendarSettings.ClickDayNightCreateButton();
            TimeManager.ShortPause();

            //input nothing and click save
            CalendarSettings.ClickSaveCalendarButton();
            TimeManager.MediumPause();

            //verify empty fields will trigger invalid verification
            //workday and worktime
            Assert.IsTrue(CalendarSettings.IsWorkdayEffectiveYearInvalid_N(1));
            Assert.IsTrue(CalendarSettings.IsWorkdayEffectiveYearInvalidMsgCorrect_N(input.ExpectedData.WorkdayEffectiveDate, 1));
            Assert.IsTrue(CalendarSettings.IsWorkdayCalendarNameInvalid_N(1));
            Assert.IsTrue(CalendarSettings.IsWorkdayCalendarNameInvalidMsgCorrect_N(input.ExpectedData.WorkdayCalendarName, 1));
            Assert.IsTrue(CalendarSettings.IsWorktimeCalendarNameInvalid_N(1));
            Assert.IsTrue(CalendarSettings.IsWorktimeCalendarNameInvalidMsgCorrect_N(input.ExpectedData.WorktimeCalendarName, 1));
            //Heating Cooling
            Assert.IsTrue(CalendarSettings.IsHCEffectiveYearInvalid_N(1));
            Assert.IsTrue(CalendarSettings.IsHCEffectiveYearInvalidMsgCorrect_N(input.ExpectedData.HeatingCoolingEffectiveDate, 1));
            Assert.IsTrue(CalendarSettings.IsHCCalendarNameInvalid_N(1));
            Assert.IsTrue(CalendarSettings.IsHCCalendarNameInvalidMsgCorrect_N(input.ExpectedData.HeatingCoolingCalendarName, 1));
            //DayNight
            Assert.IsTrue(CalendarSettings.IsDayNightEffectiveYearInvalid_N(1));
            Assert.IsTrue(CalendarSettings.IsDayNightEffectiveYearInvalidMsgCorrect_N(input.ExpectedData.DayNightEffectiveDate, 1));      
            Assert.IsTrue(CalendarSettings.IsDayNightCalendarNameInvalid_N(1));
            Assert.IsTrue(CalendarSettings.IsDayNightCalendarNameInvalidMsgCorrect_N(input.ExpectedData.DayNightCalendarName, 1));
        }

        [Test]
        [CaseID("TC-J1-FVT-CalendarConfiguration-Add-001-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CalendarPropertyData[]), typeof(AddCalendarPropertySuite), "TC-J1-FVT-CalendarConfiguration-Add-001-3")]
        public void AllCanlendarThenCancel(CalendarPropertyData input)
        {
            //Select hierarchy 
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Click calendar tab and create button "+日历属性"
            CalendarSettings.ClickCalendarTab();
            TimeManager.MediumPause();
            CalendarSettings.ClickCreateCalendarButton();
            TimeManager.ShortPause();
             
            //Click "+" button for '工休日' and "添加工作时间"
            CalendarSettings.ClickWorkdayCreateButton();
            TimeManager.ShortPause();
            CalendarSettings.ClickAddWorktimeLinkButton();
            CalendarSettings.FillInWorkdayCalendarValue_N(input.InputData, 1);
            TimeManager.ShortPause();

            //Click "+" button for '冷暖季'
            CalendarSettings.ClickHeatingCoolingCreateButton();
            TimeManager.ShortPause();
            CalendarSettings.FillInHeatingCoolingCalendarValue_N(input.InputData, 1);
            TimeManager.ShortPause();

            //Click "+" button for '昼夜时间'
            CalendarSettings.ClickDayNightCreateButton();
            CalendarSettings.FillInDayNightCalendarValue_N(input.InputData, 1);
            TimeManager.ShortPause();

            //input nothing and click save
            CalendarSettings.ClickCancelCalendarButton();
            TimeManager.MediumPause();

            //"+日历属性" button display
            CalendarSettings.IsCreateCalendarButtonDisplayed();         
        }

        [Test]
        [CaseID("TC-J1-FVT-CalendarConfiguration-Add-001-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CalendarPropertyData[]), typeof(AddCalendarPropertySuite), "TC-J1-FVT-CalendarConfiguration-Add-001-4")]
        public void AllDupYearCalendar(CalendarPropertyData input)
        {
            //Select hierarchy 
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Click calendar tab and create button "+日历属性"
            CalendarSettings.ClickCalendarTab();
            TimeManager.MediumPause();
            CalendarSettings.ClickCreateCalendarButton();
            TimeManager.ShortPause();

            //Click "+" button for '工休日', click "Save" then check
            CalendarSettings.ClickWorkdayCreateButton();
            TimeManager.ShortPause();
            CalendarSettings.FillInWorkdayCalendarValue_N(input.InputData, 1);
            CalendarSettings.ClickSaveCalendarButton();
            TimeManager.ShortPause();

            Assert.IsTrue(CalendarSettings.GetWorkdayContainerErrorTips().Contains(input.ExpectedData.WorkdayEffectiveDate));
            CalendarSettings.ClickCancelCalendarButton();
            TimeManager.MediumPause();

            //Click "+" button for '冷暖季'
            CalendarSettings.ClickCreateCalendarButton();
            TimeManager.ShortPause();
            CalendarSettings.ClickHeatingCoolingCreateButton();
            CalendarSettings.FillInHeatingCoolingCalendarValue_N(input.InputData, 1);
            CalendarSettings.ClickSaveCalendarButton();
            TimeManager.ShortPause();

            Assert.IsTrue(CalendarSettings.GetHCContainerErrorTips().Contains(input.ExpectedData.HeatingCoolingEffectiveDate));
            CalendarSettings.ClickCancelCalendarButton();
            TimeManager.MediumPause();

            //Click "+" button for '昼夜时间'
            CalendarSettings.ClickCreateCalendarButton();
            TimeManager.ShortPause();
            CalendarSettings.ClickDayNightCreateButton();
            CalendarSettings.FillInDayNightCalendarValue_N(input.InputData, 1);
            CalendarSettings.ClickSaveCalendarButton();
            TimeManager.ShortPause();

            Assert.IsTrue(CalendarSettings.GetDayNightContainerErrorTips().Contains(input.ExpectedData.DayNightEffectiveDate));         
        }

        [Test]
        [CaseID("TC-J1-FVT-CalendarConfiguration-Add-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(CalendarPropertyData[]), typeof(AddCalendarPropertySuite), "TC-J1-FVT-CalendarConfiguration-Add-101-1")]
        public void AddMultipleCalendarAndCheck(CalendarPropertyData input)
        {
            //Select hierarchy 
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.LongPause();

            //Click calendar tab and create button "+日历属性"
            CalendarSettings.ClickCalendarTab();
            TimeManager.MediumPause();
            CalendarSettings.ClickCreateCalendarButton();
            TimeManager.ShortPause();

            //Click "+" button for '工休日', add 2 items, one of them not include worktime
            CalendarSettings.ClickWorkdayCreateButton();
            CalendarSettings.ClickAddWorktimeLinkButton();
            TimeManager.ShortPause();
            CalendarSettings.FillInWorkdayCalendarValue(input.InputData);
            TimeManager.ShortPause();

            CalendarSettings.ClickWorkdayCreateButton();
            CalendarSettings.SelectWorkdayEffectiveYear("2049");
            CalendarSettings.SelectWorkdayCalendarName(input.InputData.WorkdayCalendarName);
            TimeManager.ShortPause();
            
            //Click "+" button for '冷暖季' and add 2 items
            CalendarSettings.ClickHeatingCoolingCreateButton();
            CalendarSettings.FillInHeatingCoolingCalendarValue(input.InputData);
            TimeManager.ShortPause();

            CalendarSettings.ClickHeatingCoolingCreateButton();
            CalendarSettings.SelectHeatingCoolingEffectiveYear("2015");
            CalendarSettings.SelectHeatingCoolingCalendarName(input.InputData.HeatingCoolingCalendarName);
            TimeManager.ShortPause();

            //Click "+" button for '昼夜时间'
            CalendarSettings.ClickDayNightCreateButton();
            CalendarSettings.FillInDayNightCalendarValue(input.InputData);
            TimeManager.ShortPause();

            CalendarSettings.ClickDayNightCreateButton();
            CalendarSettings.SelectDayNightEffectiveYear("2038");
            CalendarSettings.SelectDayNightCalendarName(input.InputData.DayNightCalendarName);
            TimeManager.ShortPause();
            
            //Click "Save"
            CalendarSettings.ClickSaveCalendarButton();
            TimeManager.LongPause();

            //Verify the calendar display correct and label text is right--workday
            Assert.AreEqual(CalendarSettings.GetWorkdayEffectiveYearValue(), "2049");
            Assert.AreEqual(CalendarSettings.GetWorkdayCalendarNameValue(), input.ExpectedData.WorkdayCalendarName);
            //Assert.IsTrue(CalendarSettings.IsWorkdayCalendarTextCorrect(input.ExpectedData.WorkdayText));
            
            Assert.AreEqual(CalendarSettings.GetWorkdayEffectiveYearValue_N(2), input.ExpectedData.WorkdayEffectiveDate);
            Assert.AreEqual(CalendarSettings.GetWorkdayCalendarNameValue_N(2), input.ExpectedData.WorkdayCalendarName);
            Assert.AreEqual(CalendarSettings.GetWorktimeCalendarNameValue_N(2), input.ExpectedData.WorktimeCalendarName);
            //Assert.IsTrue(CalendarSettings.IsWorkdayCalendarTextCorrect_N(input.ExpectedData.WorkdayText, 2));
            //Assert.IsTrue(CalendarSettings.IsWorktimeCalendarTextCorrect_N(input.ExpectedData.WorktimeText, 2));

            //Verify the calendar display correct and label text is right--Heating Cooling
            Assert.AreEqual(CalendarSettings.GetHeatingCoolingEffectiveYearValue(), "2015");
            Assert.AreEqual(CalendarSettings.GetHeatingCoolingCalendarNameValue(), input.ExpectedData.HeatingCoolingCalendarName);
            //Assert.IsTrue(CalendarSettings.IsHeatingCoolingCalendarTextCorrect(input.ExpectedData.HeatingCoolingText));

            Assert.AreEqual(CalendarSettings.GetHeatingCoolingEffectiveYearValue_N(2), input.ExpectedData.HeatingCoolingEffectiveDate);
            Assert.AreEqual(CalendarSettings.GetHeatingCoolingCalendarNameValue_N(2), input.ExpectedData.HeatingCoolingCalendarName);
            //Assert.IsTrue(CalendarSettings.IsHeatingCoolingCalendarTextCorrect_N(input.ExpectedData.HeatingCoolingText, 2));

            //Verify the calendar display correct and label text is right--DayNight
            Assert.AreEqual(CalendarSettings.GetDayNightEffectiveYearValue(), input.ExpectedData.DayNightEffectiveDate);
            Assert.AreEqual(CalendarSettings.GetDayNightCalendarNameValue(), input.ExpectedData.DayNightCalendarName);
            //Assert.IsTrue(CalendarSettings.IsDayNightCalendarTextCorrect(input.ExpectedData.DayNightText));

            Assert.AreEqual(CalendarSettings.GetDayNightEffectiveYearValue_N(2), "2038");
            Assert.AreEqual(CalendarSettings.GetDayNightCalendarNameValue_N(2), input.ExpectedData.DayNightCalendarName);
            //Assert.IsTrue(CalendarSettings.IsDayNightCalendarTextCorrect_N(input.ExpectedData.DayNightText, 2));
        }

    }
}
