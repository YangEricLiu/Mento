using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;

namespace Mento.ScriptCommon.TestData.EnergyView
{
    public class UnitIndicatorData : TestDataBase<UnitIndicatorInput, UnitIndicatorOutput>
    {
    }

    public class UnitIndicatorInput : InputTestDataBase
    { 
        public string[][] Hierarchies { get; set; }

        public string[] AreaDimensionPath { get; set; }

        public string[] SystemDimensionPath { get; set; }

        public string[] tagNames { get; set; }

        public string[] failedFileName { get; set; }

        public DashboardInformation[] DashboardInfo { get; set; }

        public UnitIndicatorLegend[] UnitIndicatorLegend { get; set; }

        public ManualTimeRange[] ManualTimeRange { get; set; }

        public string[] Commodity { get; set; }

        public string Industry { get; set; }

        public string[] Industries { get; set; }

        public string CarbonType { get; set; }

        public string UnitIndicatorType { get; set; }

        public MultipleHierarchyAndtags[] MultipleHierarchyAndtags { get; set; }
    }

    public class UnitIndicatorOutput : ExpectedTestDataBase
    {
        public string[] expectedFileName { get; set; }
        public string UnitTypeValue { get; set; }
        public string IndustryValue { get; set; }
        public UnitIndicatorLegend[] UnitIndicatorLegend { get; set; }
        public string[] popupNotes { get; set; }
        public string ClearAllMessage { get; set; }
        public string[] messages { get; set; }
        public string[] LegendTexts { get; set; }
    }

    public class UnitIndicatorLegend
    {
        public string CaculationValue { get; set; }
        public string OriginalValue { get; set; }
        public string TargetValue { get; set; }
        public string BaselineValue { get; set; }
        public string BenchmarkValue { get; set; }
    }
}
