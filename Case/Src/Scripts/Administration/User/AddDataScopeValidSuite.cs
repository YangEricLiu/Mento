using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using System.IO;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Administration;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.TestData.Attribute;

namespace Mento.Script.Administration.User
{
    [TestFixture]
    [Owner("Greenie")]
    [CreateTime("2013-08-07")]
    [ManualCaseID("TC-J1-FVT-UserDataScope-Add-101")]
    public class AddDataScopeValidSuite : TestSuiteBase
    {
        private UserDataScopePermission UserDataPermissionSettings = JazzFunction.UserDataScopePermission;

        [SetUp]
        public void CaseSetUp()
        {
            UserDataPermissionSettings.NavigatorToUserSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Add-101-1")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddDataScopeValidSuite), "TC-J1-FVT-UserDataScope-Add-101-1")]
        public void AddAndViewRootNode(UserDataPermissionData input)
        {
            //string[] hierarchyNode = {"NancyCustomer1","GreenieSite","GreenieBuilding"};
            string[] hierarchyNode = {""};
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            //Verify all customers checkbox is unchecked and "编辑数据权限" link is gray out and save button disable
            Assert.IsFalse(UserDataPermissionSettings.IsSaveButtonEnable());
            Assert.IsTrue(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
            
            //Check Customer A B C root node from datascope.
            int i = 0;
            while (i < input.InputData.CustomerList.Length)
            {
                UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[i]);
                UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[i]);
                hierarchyNode[0] = input.InputData.CustomerList[i];
                UserDataPermissionSettings.CheckHierarchyNode(hierarchyNode);
                UserDataPermissionSettings.SaveTreeWindow();
                TimeManager.ShortPause();
                i++;
            }
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            // View the data permission 
            int j = 0; 
            while (j < input.InputData.CustomerList.Length)
            {
                UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[j]);
                hierarchyNode[0] = input.InputData.CustomerList[j];
                Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(hierarchyNode));
                UserDataPermissionSettings.CloseTreeWindow();
                j++;
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Add-101-2")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddDataScopeValidSuite), "TC-J1-FVT-UserDataScope-Add-101-2")]
        public void AddMultipleNodeAndView(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            //Verify all customers checkbox is unchecked and "编辑数据权限" link is gray out and save button disable
            Assert.IsFalse(UserDataPermissionSettings.IsSaveButtonEnable());
            Assert.IsTrue(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
            //Check multiple customer checkbox from datascope.
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.CheckHierarchyNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.CheckHierarchyNode(input.ExpectedData.HierarchyNodePath);
            UserDataPermissionSettings.SaveTreeWindow();
            TimeManager.ShortPause();
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[1]);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[1]);
            // temp hierachy node  CustomerList
            UserDataPermissionSettings.CheckHierarchyNode(input.ExpectedData.CustomerList);
            UserDataPermissionSettings.SaveTreeWindow();
            TimeManager.ShortPause();

            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            // View the data permission 
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[0]);
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.ExpectedData.HierarchyNodePath));
            string[] HierarchyNode = { "customerA", "organizationA", "siteA" };
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchyNodeChecked(HierarchyNode));
            UserDataPermissionSettings.CloseTreeWindow();

            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[1]);
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.ExpectedData.CustomerList));
            UserDataPermissionSettings.CloseTreeWindow();

            // energy analysis
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Add-101-3")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddDataScopeValidSuite), "TC-J1-FVT-UserDataScope-Add-101-3")]
        public void CheckAllCustomerNamesThenView(UserDataPermissionData input)
        {

            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
                 
            // check "客户名称"
            UserDataPermissionSettings.CheckAllCumstomerNames();

            // Select 配置数据权限 link from customerA ,view 客户数据权限 
            Assert.False(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            // All hierarchy nodes are unchecked
            Assert.IsFalse(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
            UserDataPermissionSettings.ClickSaveButton();
           
            //Verify 
           // string[] path = { "customerA", "organizationA", "siteA"};
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            //IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(path));

            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Add-101-4")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddDataScopeValidSuite), "TC-J1-FVT-UserDataScope-Add-101-4")]
        public void CheckAllDataScopeThenView(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();

            // check "全部平台客户及对应数据权限"
            UserDataPermissionSettings.CheckAllCustomerDatas();
            Assert.IsTrue(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
            UserDataPermissionSettings.ClickSaveButton();
            // Select 配置数据权限 link from customerA ,view status of created user 客户数据权限 
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            // All hierarchy nodes are unchecked
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();         
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Add-101-5")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddDataScopeValidSuite), "TC-J1-FVT-UserDataScope-Add-101-5")]
        public void CheckSingleThenCheckAll(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            // Select 配置数据权限 link from customerA ,view status of created user 客户数据权限 
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);

            UserDataPermissionSettings.CheckHierarchyNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.CheckHierarchyNode(input.ExpectedData.HierarchyNodePath);
            UserDataPermissionSettings.SaveTreeWindow();

            //Check "全部平台客户及对应数据权限"
            UserDataPermissionSettings.CheckAllCustomerDatas();
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            // Verify the hierarchy nodes are checked
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Add-101-6")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddDataScopeValidSuite), "TC-J1-FVT-UserDataScope-Add-101-6")]
        public void CheckSingleThenUnCheckAll(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            // Select 配置数据权限 link from customerA ,view status of created user 客户数据权限 
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);

            UserDataPermissionSettings.CheckHierarchyNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.CheckHierarchyNode(input.ExpectedData.HierarchyNodePath);
            UserDataPermissionSettings.SaveTreeWindow();

            //Check then uncheck "全部平台客户及对应数据权限"
            UserDataPermissionSettings.CheckAllCustomerDatas();
            UserDataPermissionSettings.CheckAllCustomerDatas();
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);

            // Verify the hierarchy nodes are checked
            Assert.IsFalse(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
        }
        
        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Add-101-7")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddDataScopeValidSuite), "TC-J1-FVT-UserDataScope-Add-101-7")]
        public void CheckAllNamesThenUncheck(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            //Check the hierarchy node all uncheck
            UserDataPermissionSettings.CheckAllCumstomerNames();
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));

            UserDataPermissionSettings.CheckHierarchyNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.CheckHierarchyNode(input.ExpectedData.HierarchyNodePath);
            UserDataPermissionSettings.SaveTreeWindow();

            //Check then uncheck "全部平台客户及对应数据权限"
            UserDataPermissionSettings.CheckAllCustomerDatas();
 
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);

            // Verify the hierarchy nodes are checked
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.ExpectedData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
        }

        /*
        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Add-101-8")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddDataScopeValidSuite), "TC-J1-FVT-UserDataScope-Add-101-8")]
        public void CheckDataScopeAndVerify(UserDataPermissionData input)
        {
            // login out  and login in UserOwnAdmin
            string password = "P@ssw0rd";

            JazzFunction.HomePage.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(input.InputData.UserName,password,input.InputData.CustomerName);
            //JazzFunction.HomePage.SelectCustomer(input.InputData.CustomerName);
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UserManagement);
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CustomerManagement);
            //JazzFunction.CustomerManagement.ClickAddCustomerButton();

            //Problem here @@@@@@@@@@@@@@@2
            //JazzFunction.CustomerManagement.FillInCustomerInfo(data);

            //Creat customerNew 

            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.ExpectedData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            //Verify  the hierarchy node all checked
            Assert.IsFalse(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
            Assert.IsTrue(UserDataPermissionSettings.IsCheckAllDataChecked());

            JazzFunction.HomePage.ExitJazz();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            JazzFunction.LoginPage.LoginWithOption(input.ExpectedData.UserName,password,input.ExpectedData.UserName);
            TimeManager.LongPause();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CostUsage);
            JazzFunction.CostPanel.SelectHierarchy(input.ExpectedData.HierarchyNodePath);

            Assert.IsTrue(UserDataPermissionSettings.ClickEditDataPermission(input.ExpectedData.CustomerName));
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
        }
        */


        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Add-101-9")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddDataScopeValidSuite), "TC-J1-FVT-UserDataScope-Add-101-9")]
        public void CheckAllHierarchyData(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            UserDataPermissionSettings.ClickModifyButton();

            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            //Check "全部层级节点数据权限"
            UserDataPermissionSettings.CheckAllHierarchyNode();
            UserDataPermissionSettings.SaveTreeWindow();
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            //Verify the hierarchy node all checked
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();

            // verify after save hierarchy tree
            TimeManager.MediumPause();
            Assert.IsTrue(UserDataPermissionSettings.UnCheckCustomer(input.InputData.CustomerName));
            TimeManager.LongPause();
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);

            //Verify the hierarchy node all checked
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
            UserDataPermissionSettings.ClickCancelButton();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Add-101-10")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddDataScopeValidSuite), "TC-J1-FVT-UserDataScope-Add-101-9")]
        public void ten(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            //Check the hierarchy node all uncheck
            UserDataPermissionSettings.CheckAllCumstomerNames();
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));

            UserDataPermissionSettings.CheckHierarchyNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.CheckHierarchyNode(input.ExpectedData.HierarchyNodePath);
            UserDataPermissionSettings.SaveTreeWindow();

            //Check then uncheck "全部平台客户及对应数据权限"
            UserDataPermissionSettings.CheckAllCustomerDatas();

            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);

            // Verify the hierarchy nodes are checked
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.ExpectedData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Add-101-11")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddDataScopeValidSuite), "TC-J1-FVT-UserDataScope-Add-101-9")]
        public void CheckAdminDataScope(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
        }
    }
}
