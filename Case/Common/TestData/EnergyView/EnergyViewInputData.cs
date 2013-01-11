using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;

namespace Mento.ScriptCommon.TestData.EnergyView
{
    public class EnergyViewOptionData : TestDataBase<EnergyViewOptionInput, ExpectedTestDataBase>
    {
    }

    public class EnergyViewOptionInput : InputTestDataBase
    { 
        public string[] Hierarchies { get; set; }

        public string[] TagNames { get; set; }

        public EnergyViewType ViewType { get; set; }

        public DefaultTimeRange? DefaultTimeRange { get; set; }
    }

    
    public enum EnergyViewType 
    { 
        Line, 
        Column, 
        List, 
        Distribute 
    }
        
    public enum DefaultTimeRange
    {
        Last7Days,
        Today,
        Yesterday,
        ThisWeek,
        LastWeek,
        ThisMonth,
        LastMonth,
        ThisYear,
        LastYear,
    }
}
