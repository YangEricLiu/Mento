using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;

namespace Mento.ScriptCommon.TestData.EnergyView
{
    public class CarbonUsageData : TestDataBase<CarbonUsageInput, CarbonUsageOutput>
    {
    }

    public class CarbonUsageInput : InputTestDataBase
    { 
        public string[] Hierarchies { get; set; }

        public string[] AreaDimensionPath { get; set; }

        public string[] SystemDimensionPath { get; set; }

        public string[] commodityNames { get; set; }

        public string[] failedFileName { get; set; }

        public EnergyViewType ViewType { get; set; }

        public DefaultTimeRange? DefaultTimeRange { get; set; }

        public DashboardInformation[] DashboardInfo { get; set; }
    }

    public class CarbonUsageOutput : ExpectedTestDataBase
    {
        public string[] expectedFileName { get; set; }
        public string ClearAllMessage { get; set; }
        public string QuitMultipleMessage { get; set; }
        public string[] StepMessage { get; set; }
    }
}
