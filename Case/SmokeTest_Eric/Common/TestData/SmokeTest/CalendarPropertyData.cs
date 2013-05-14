using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.SmokeTest
{
    public class CalendarPropertyData : TestDataBase<CalendarPropertInputData, CalendarPropertExpectedData>
    {
    }

    public class CalendarPropertInputData : InputTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string WorkdayEffectiveDate { get; set; }
        public string WorkdayCalendarName { get; set; }
        public string WorktimeCalendarName { get; set; }
        public string HeatingCoolingEffectiveDate { get; set; }
        public string HeatingCoolingCalendarName { get; set; }
        public string DayNightEffectiveDate { get; set; }
        public string DayNightCalendarName { get; set; }
    }

    public class CalendarPropertExpectedData : ExpectedTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string WorkdayEffectiveDate { get; set; }
        public string WorkdayCalendarName { get; set; }
        public string WorktimeCalendarName { get; set; }
        public string HeatingCoolingEffectiveDate { get; set; }
        public string HeatingCoolingCalendarName { get; set; }
        public string DayNightEffectiveDate { get; set; }
        public string DayNightCalendarName { get; set; }
        public string[] WorkdayText { get; set; }
        public string[] WorktimeText { get; set; }
        public string[] HeatingCoolingText { get; set; }
        public string[] DayNightText { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}
