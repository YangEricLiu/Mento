using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;

namespace Mento.ScriptCommon.TestData.EnergyView
{
    public class EnergyViewOptionData : TestDataBase<EnergyViewOptionInput, EnergyViewOptionOutput>
    {
    }

    public class EnergyViewOptionInput : InputTestDataBase
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
    }

    public class EnergyViewOptionOutput : ExpectedTestDataBase
    {
        public string[] expectedFileName { get; set; }
        public string ClearAllMessage { get; set; }
    }


    public class DashboardInformation
    {
        public string WigetName { get; set; }
        public string[] HierarchyName { get; set; }
        public bool IsCreateDashboard { get; set; }
        public string DashboardName { get; set; }
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
