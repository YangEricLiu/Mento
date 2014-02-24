using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;

namespace Mento.ScriptCommon.TestData.EnergyView
{
    public class MaximizeWidgetData : TestDataBase<MaximizeWidgetInput, MaximizeWidgetOutput>
    {
    }

    public class MaximizeWidgetInput : InputTestDataBase
    { 
        public DefaultTimeRange? DefaultTimeRange { get; set; }
        public DashboardInformationList[] DashboardInfo { get; set; }
        public TimeInterval[] TimeIntervalList { get; set; }
        public string CustomerName { get; set; }
        public string[] newWidgetName { get; set; }
        public string[] Hierarchies { get; set; }
        public string TagName { get; set; }
    }

    public class MaximizeWidgetOutput : ExpectedTestDataBase
    {
        public string[] StepMessage { get; set; }
        public string[] newWidgetName { get; set; }
    }


    public class DashboardInformationList
    {
        public string[] WigetNames { get; set; }
        public string WidgetName { get; set; }
        public string[] HierarchyName { get; set; }
        public bool IsCreateDashboard { get; set; }
        public string DashboardName { get; set; }
        public string newDashboardName { get; set; }
        public string[] DashboardNames { get; set; }
        public string Comment { get; set; }
    }

    public class TimeInterval
    {
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
    }

}
