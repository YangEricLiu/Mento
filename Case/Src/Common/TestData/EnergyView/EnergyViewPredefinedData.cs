using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;

namespace Mento.ScriptCommon.TestData.EnergyView
{
    public class EnergyViewPredefinedData : TestDataBase<EnergyViewPredefinedInput, EnergyViewPredefinedOutput>
    {
    }

    public class EnergyViewPredefinedInput : InputTestDataBase
    { 
        public string[] Hierarchies { get; set; }
        public string[] TagNames { get; set; }
        public string[] commodityNames { get; set; }

    }

    public class EnergyViewPredefinedOutput : ExpectedTestDataBase
    {
        public string Last7DaysValue { get; set; }
        public string LastMonthValue { get; set; }
    }
}
