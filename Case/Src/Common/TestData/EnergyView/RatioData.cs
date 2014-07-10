using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;

namespace Mento.ScriptCommon.TestData.EnergyView
{
    public class RatioData : TestDataBase<RatioInput, RatioOutput>
    {
    }

    public class RatioInput : InputTestDataBase
    { 
        public string[][] Hierarchies { get; set; }

        public string[] AreaDimensionPath { get; set; }

        public string[] SystemDimensionPath { get; set; }

        public string[] tagNames { get; set; }

        public string[] failedFileName { get; set; }

        public DashboardInformation[] DashboardInfo { get; set; }

        public UnitIndicatorLegend[] UnitIndicatorLegend { get; set; }

        public ManualTimeRange[] ManualTimeRange { get; set; }

        public string[] Industries { get; set; }

        public MultipleHierarchyAndtags[] MultipleHierarchyAndtags { get; set; }
    }

    public class RatioOutput : ExpectedTestDataBase
    {
        public string[] expectedFileName { get; set; }
        public string UnitTypeValue { get; set; }
        public string IndustryValue { get; set; }
        public UnitIndicatorLegend[] UnitIndicatorLegend { get; set; }
        public string[] popupNotes { get; set; }
        public string ClearAllMessage { get; set; }
        public string[] messages { get; set; }
    }
}
