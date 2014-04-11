using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class UserDataPermissionData : TestDataBase<DataPermissionInputData, DataPermissionExpectedData>
    {
    }

    public class DataPermissionInputData : InputTestDataBase
    {
        public string UserName { get; set; }
        public string CustomerName { get; set; }
        public string[] CustomerList { get; set; }
        public string[] HierarchyNodePath { get; set; }
        public string[][] HierarchyNodePathsArray { get; set; }
    }
    public class DataPermissionExpectedData : ExpectedTestDataBase
        {
            public string UserName { get; set; }
            public string CustomerName { get; set; }
            public string[] CustomerList { get; set; }
            public string[] HierarchyNodePath { get; set; }
        }
}
