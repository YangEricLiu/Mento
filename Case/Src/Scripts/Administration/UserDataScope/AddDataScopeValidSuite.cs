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

namespace Mento.Script.Administration.UserDataScope
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
            JazzFunction.LoginPage.RefreshJazz("“云能效”系统管理");
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

            UserDataPermissionSettings.ClickModifyButton();
            TimeManager.ShortPause();
            // check "客户名称"
            UserDataPermissionSettings.CheckAllCumstomerNames();

            // Select 配置数据权限 link from customerA ,view 客户数据权限 
            Assert.False(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);

            // All hierarchy nodes are unchecked
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesUnChecked(input.InputData.HierarchyNodePath));
            UserDataPermissionSettings.CancelTreeWindow();

            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
           
            //Verify 
            UserDataPermissionSettings.ClickModifyButton();
            TimeManager.LongPause();
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            //IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(path));
            TimeManager.MediumPause();

            Assert.IsFalse(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));
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
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            // check "全部平台客户及对应数据权限"
            Assert.IsTrue(UserDataPermissionSettings.CheckAllCustomerDatas());
            TimeManager.LongPause();
            Assert.IsTrue(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            // Select 配置数据权限 link from customerA ,view status of created user 客户数据权限 
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            // All hierarchy nodes are unchecked@@@@@@@@@@@
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
            TimeManager.ShortPause();

            //Check "全部平台客户及对应数据权限"
            UserDataPermissionSettings.CheckAllCustomerDatas();
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            // Verify the hierarchy nodes are checked
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
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

            // Verify the hierarchy nodes are still checked @@@Temporary scripts@@@
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.ExpectedData.HierarchyNodePath));
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
            Assert.IsFalse(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));

            UserDataPermissionSettings.CheckHierarchyNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.CheckHierarchyNode(input.ExpectedData.HierarchyNodePath);
            TimeManager.ShortPause();

            UserDataPermissionSettings.SaveTreeWindow();
            TimeManager.ShortPause();

            //Check then uncheck "全部平台客户及对应数据权限"
            UserDataPermissionSettings.CheckAllCumstomerNames();
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
            TimeManager.MediumPause();
            //Verify the hierarchy node all checked
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            //Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));
            //Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.ExpectedData.CustomerList));
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.ExpectedData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();

            // verify after save hierarchy tree
            TimeManager.MediumPause();
            UserDataPermissionSettings.UnCheckCustomer(input.InputData.CustomerName);
            // UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            TimeManager.MediumPause();
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);

            //Verify the hierarchy node all checked
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            //Verify the hierarchy node all checked
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));
            //Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.ExpectedData.CustomerList));
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.ExpectedData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
        }
        /*
        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Add-101-10")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddDataScopeValidSuite), "TC-J1-FVT-UserDataScope-Add-101-9")]
        public void AllHierarchyCheckedNewCreated(UserDataPermissionData input)
        {
            
        }
        */

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Add-101-11")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddDataScopeValidSuite), "TC-J1-FVT-UserDataScope-Add-101-11")]
        public void CheckAdminDataScope(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            Assert.IsFalse(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
            Assert.IsTrue(UserDataPermissionSettings.IsAllDataScopeCheckBoxDisabled());
            Assert.IsTrue(UserDataPermissionSettings.IsAllDataCheckboxChecked());
            
        }
    }
}
