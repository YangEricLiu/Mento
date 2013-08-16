using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;

namespace Mento.ScriptCommon.TestData.EnergyView
{
    public class TimeSpansData : TestDataBase<TimeSpansInputData, TimeSpansOutputData>
    {
    }

    public class TimeSpansInputData : InputTestDataBase
    { 
        public string[] Hierarchies { get; set; }

        public string[] AreaDimensionPath { get; set; }

        public string[] SystemDimensionPath { get; set; }

        public string[] TagNames { get; set; }

        public string[] failedFileName { get; set; }

        public EnergyViewType ViewType { get; set; }

        public DefaultTimeRange? DefaultTimeRange { get; set; }

        public DashboardInformation DashboardInfo { get; set; }

        public string[] StartDate { get; set; }

        public string[] StartTime { get; set; }

        public string[] BaseStartDate { get; set; }

        public string[] BaseStartTime { get; set; }

        public string[] BaseEndDate { get; set; }

        public string[] BaseEndTime { get; set; }
    }

    public class TimeSpansOutputData : ExpectedTestDataBase
    {
        public string[] expectedFileName { get; set; }
        public string ClearAllMessage { get; set; }
        public string DeleteAllMessage { get; set; }
        public string[] StartDateValue { get; set; }
        public string[] StartTimeValue { get; set; }
        public string[] BaseStartDateValue { get; set; }
        public string[] BaseStartTimeValue { get; set; }
        public string[] BaseEndDateValue { get; set; }
        public string[] BaseEndTimeValue { get; set; }
        public string[] EndTimeValue { get; set; }
        public string[] ErrorMessage { get; set; }
    }

    public enum TimeSpans
    {
        DeleteAllTimeSpans,
    }
}
