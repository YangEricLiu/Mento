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
        public string[] Hierarchies { get; set; }
        public string[] TagNames { get; set; }
        public string[] commodityNames { get; set; }
        public MultipleHierarchyAndtags[] MultipleHierarchyAndtags { get; set; }
        public YearAndMonth[] YearAndMonth { get; set; }
    }

    public class SmokeTestEnergyViewDataOutput : ExpectedTestDataBase
    {
        
    }
}
