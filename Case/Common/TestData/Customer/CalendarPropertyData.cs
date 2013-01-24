using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class CalendarPropertyData : TestDataBase<CalendarPropertInputData, ExpectedTestDataBase>
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

        public CalendarPropertInputData(string[] hierarchyNodePath, string workdayEffectiveDate, string workdayCalendarName, string worktimeCalendarName, string heatingCoolingEffectiveDate, string heatingCoolingCalendarName, string dayNightEffectiveDate, string dayNightCalendarName)
        {
            this.HierarchyNodePath = hierarchyNodePath;
            this.WorkdayEffectiveDate = workdayEffectiveDate;
            this.WorkdayCalendarName = workdayCalendarName;
            this.WorktimeCalendarName = worktimeCalendarName;
            this.HeatingCoolingEffectiveDate = heatingCoolingEffectiveDate;
            this.HeatingCoolingCalendarName = heatingCoolingCalendarName;
            this.DayNightEffectiveDate = dayNightEffectiveDate;
            this.DayNightCalendarName = dayNightCalendarName;
        }
    }
}
