using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;

namespace Mento.ScriptCommon.TestData.EnergyView
{
    public class ShareDashboardData : TestDataBase<ShareDashboardInput, ShareDashboardOutput>
    {
    }

    public class ShareDashboardInput : InputTestDataBase
    {
        public DashboardShareList[] DashboardInfo { get; set; }
        public TimeInterval[] TimeIntervalList { get; set; }
        public string CustomerName { get; set; }
        public string[] Hierarchies { get; set; }
        public string TagName { get; set; }
    }

    public class ShareDashboardOutput : ExpectedTestDataBase
    {
        public string[] TooltipTexts { get; set; }
    }

    public class DashboardShareList
    {
        public string WidgetName { get; set; }
        public string[] HierarchyName { get; set; }
        public string[] WidgetNames { get; set; }
        public string DashboardName { get; set; }
        public string[] ShareUsers { get; set; }
        public string[] ReceiveUsers { get; set; }
        public ReceiverUsersInfo[] Receivers { get; set; }
    }

    public class ReceiverUsersInfo
    {
        public string LoginName { get; set; }
        public string Password { get; set; }
    }
}
