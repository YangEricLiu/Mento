using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class ShareDashboard : TestDataBase<ShareDashboardInputData, ShareDashboardExpectedData>
    {
    }

    public class ShareDashboardInputData : InputTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string DashboardName { get; set; }
    }

    public class ShareDashboardExpectedData : ExpectedTestDataBase
    {

    }
}
