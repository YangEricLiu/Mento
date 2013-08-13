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

        public string[] MultiHieTagNames { get; set; }

        public string[] MultiSelectedHiearchyPath { get; set; }

        public string[][] MultipleHiearchyPath { get; set; }
    }

    public class TimeSpansOutputData : ExpectedTestDataBase
    {
        public string[] expectedFileName { get; set; }
        public string ClearAllMessage { get; set; }
        public string QuitMultipleMessage { get; set; }
    }

    public enum TimeSpans
    {
        DeleteAllTimeSpans,
    }
}
