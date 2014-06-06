using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;

namespace Mento.ScriptCommon.TestData.EnergyView
{
    public class DisplayStepData : TestDataBase<DisplayStepInput, DisplayStepOnput>
    {
    }

    public class DisplayStepInput : InputTestDataBase
    {
        public string Customer { get; set; }
        
        public string[] Hierarchies { get; set; }

        public string[] AreaDimensionPath { get; set; }

        public string[] SystemDimensionPath { get; set; }

        public string[] TagNames { get; set; }

        public string[] failedFileName { get; set; }

        public EnergyViewType ViewType { get; set; }

        public DefaultTimeRange? DefaultTimeRange { get; set; }

        public DashboardInformation DashboardInfo { get; set; }

        public ManualTimeRange[] ManualTimeRange { get; set; }

        public string[] DisplayStep { get; set; }

        public string[] commodityNames { get; set; }

        public string[] OtherHierarchies { get; set; }
    }

    public class DisplayStepOnput : ExpectedTestDataBase
    {
        public string[] expectedFileName { get; set; }
        public string ClearAllMessage { get; set; }
        public string QuitMultipleMessage { get; set; }
        public string[] StepMessage { get; set; }
        public string[] messages { get; set; }
    }

    public class ManualTimeRange
    {
        public string StartDate;
        public string StartTime;
        public string EndDate;
        public string EndTime;  
    }
}
