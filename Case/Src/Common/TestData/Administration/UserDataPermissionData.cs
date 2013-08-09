using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class UserDataPermissionData : TestDataBase<UserInputData, UserExpectedData>
    {
    }

    public class UserDataPermissionInputData : InputTestDataBase
    {
        public string UserName { get; set; }
        public string CustomerName { get; set; }
        public string[] CustomerList { get; set; }
        public string[] HierarchyNodePath { get; set; }

        public UserDataPermissionInputData(string userName, string customerName, string[] customerList, string[] hierarchNodePath)
        {
            this.UserName = UserName;
            this.CustomerName = customerName;
            this.CustomerList = customerList;
            this.HierarchyNodePath = hierarchNodePath;
        }
    }
    public class UserDataPermissionExpectedData : ExpectedTestDataBase
        {
            public string UserName { get; set; }
            public string CustomerName { get; set; }
            public string[] CustomerList { get; set; }
            public string[] HierarchyNodePath { get; set; }

            public UserDataPermissionExpectedData(string userName, string customerName, string[] customerList, string[] hierarchNodePath)
            {
                this.UserName = userName;
                this.CustomerName = customerName;
                this.CustomerList = customerList;
                this.HierarchyNodePath = hierarchNodePath;
            }       
        }
}
