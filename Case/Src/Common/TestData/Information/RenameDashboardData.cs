using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;

namespace Mento.ScriptCommon.TestData.EnergyView
{
    public class RenameDashboardData : TestDataBase<RenameDashboardInput, RenameDashboardOutput>
    {
    }

    public class RenameDashboardInput : InputTestDataBase
    { 
        public DefaultTimeRange? DefaultTimeRange { get; set; }
        public DashboardInformationList[] DashboardInfo { get; set; }
        public TimeInterval[] TimeIntervalList { get; set; }
        public string CustomerName { get; set; }
        public string[] newWidgetName { get; set; }
        public string[] Hierarchies { get; set; }
        public string TagName { get; set; }
        public string[] DashboardNames { get; set; }
    }

    public class RenameDashboardOutput : ExpectedTestDataBase
    {
        public string[] newWidgetName { get; set; }
        public string[] newDashboardNames { get; set; }
        public string[] DeleteMessages { get; set; }
        public string DeleteCommonMessage { get; set; }
        public string NoneDashboardMessage { get; set; }
        public string NoFocusDashboardMessage { get; set; }
        public string NoneWidgetMessage { get; set; }
    }
}
