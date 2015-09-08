using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;

namespace Mento.ScriptCommon.TestData.EnergyView
{
    public class SmokeTestEnergyViewData : TestDataBase<SmokeTestEnergyViewDataInput, SmokeTestEnergyViewDataOutput>
    {
    }

    public class SmokeTestEnergyViewDataInput : InputTestDataBase
    {
        public string Customer { get; set; }
        public string[] Hierarchies { get; set; }
        public string[] TagNames { get; set; }
        public string[] commodityNames { get; set; }
        public MultipleHierarchyAndtags[] MultipleHierarchyAndtags { get; set; }
        public YearAndMonth[] YearAndMonth { get; set; }
        public string[] failedFileName { get; set; }
        public ManualTimeRange[] ManualTimeRange { get; set; }
    }

    public class SmokeTestEnergyViewDataOutput : ExpectedTestDataBase
    {
        public string[] expectedFileName { get; set; }
    }
}
