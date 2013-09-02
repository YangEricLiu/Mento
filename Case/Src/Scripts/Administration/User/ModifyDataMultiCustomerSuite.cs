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
    [CreateTime("2013-08-13")]
    [ManualCaseID("TC-J1-FVT-UserDataScope-Modify-101")]
    public class ModifyMultiCustomerSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-UserDataScope-Modify-101-1")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyMultiCustomerSuite), "TC-J1-FVT-UserDataScope-Modify-101-1")]
        public void ModifyMultiToSingle(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            UserDataPermissionSettings.ClickModifyButton();
            // Check multiple customers 
            UserDataPermissionSettings.UnCheckCustomer(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.UnCheckCustomer(input.InputData.CustomerList[1]);
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[2]);
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
           // View the data permission  

            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@获取客户时的问题
            //Assert.IsTrue(UserDataPermissionSettings.IsCustomerView(input.InputData.CustomerList[2]));
            //Assert.IsFalse(UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[0]));
            //Assert.IsFalse(UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[1]));
            //UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[2]);

        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Modify-101-2")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyMultiCustomerSuite), "TC-J1-FVT-UserDataScope-Modify-101-2")]
        public void ModifyMultiCustomer(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            UserDataPermissionSettings.ClickModifyButton();
            // Check customerD and uncheck customerC
            UserDataPermissionSettings.UnCheckCustomer(input.InputData.CustomerList[2]);
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[3]);

            // Set Customer A hierarchy check node 
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.CheckHierarchySiteNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.CheckHierarchyNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.CheckHierarchyOrzNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.SaveTreeWindow();
            // Set Customer B hierarchy check node 
             UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[1]);
             UserDataPermissionSettings.CheckHierarchySiteNode(input.InputData.HierarchyNodePath);
             UserDataPermissionSettings.CheckHierarchyNode(input.InputData.HierarchyNodePath);
             UserDataPermissionSettings.CheckHierarchyOrzNode(input.InputData.HierarchyNodePath);
             UserDataPermissionSettings.SaveTreeWindow();

             UserDataPermissionSettings.ClickSaveButton();
             JazzMessageBox.LoadingMask.WaitLoading();
             TimeManager.ShortPause();
            // View the data permission  
             Assert.IsTrue(UserDataPermissionSettings.IsCustomerView(input.InputData.CustomerList[0]));
             Assert.IsTrue(UserDataPermissionSettings.IsCustomerView(input.InputData.CustomerList[1]));
             Assert.IsTrue(UserDataPermissionSettings.IsCustomerView(input.InputData.CustomerList[2]));
             Assert.IsFalse(UserDataPermissionSettings.IsCustomerView(input.InputData.CustomerList[3]));
            // view customer A 
             UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[0]);
             Assert.IsTrue(UserDataPermissionSettings.IsHierarchSiteNodeChecked(input.InputData.HierarchyNodePath));
             Assert.IsFalse(UserDataPermissionSettings.IsHierarchOrzNodeChecked(input.InputData.HierarchyNodePath));
             Assert.IsFalse(UserDataPermissionSettings.IsHierarchCustomerNodeChecked(input.InputData.HierarchyNodePath));
             UserDataPermissionSettings.CloseTreeWindow();
             // view customer B 
             UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[0]);
             Assert.IsFalse(UserDataPermissionSettings.IsHierarchSiteNodeChecked(input.ExpectedData.HierarchyNodePath));
             Assert.IsTrue(UserDataPermissionSettings.IsHierarchOrzNodeChecked(input.ExpectedData.HierarchyNodePath));
             Assert.IsTrue(UserDataPermissionSettings.IsHierarchCustomerNodeChecked(input.ExpectedData.HierarchyNodePath));
             UserDataPermissionSettings.CloseTreeWindow();
            // Tag association@@@@@@@@@@@@@@@@@@@  not finish

            // Check 客户名称 to check all the customerr names
             UserDataPermissionSettings.CheckAllCumstomerNames();
             UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[2]);
             UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.ExpectedData.HierarchyNodePath);
             UserDataPermissionSettings.ClickSaveButton();
             JazzMessageBox.LoadingMask.WaitLoading();
             TimeManager.ShortPause();
             Assert.IsFalse(UserDataPermissionSettings.IsAllCustomerNamesButtonEnable());
             Assert.IsFalse(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
            // @@@@@@@@@@@@@@@@@@@@@@@@@ check null  hierarchy node

        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Modify-101-3")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyMultiCustomerSuite), "TC-J1-FVT-UserDataScope-Modify-101-3")]
        public void ModifyToAllAndView(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            UserDataPermissionSettings.ClickModifyButton();

            //Check "全部平台客户及对应数据权限"
            UserDataPermissionSettings.CheckAllCustomerDatas();
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            // verify 
            Assert.IsTrue(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
            Assert.IsTrue(UserDataPermissionSettings.IsAllDataCheckboxChecked());
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Modify-101-4")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyMultiCustomerSuite), "TC-J1-FVT-UserDataScope-Modify-101-4")]
        public void ModifyMultiTheToAll(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            UserDataPermissionSettings.ClickModifyButton();

            //Check  customerA and customerB 
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[1]);

            // check hierarchy nodes of customerA.
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.CheckHierarchyOrzNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.CheckHierarchyNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.SaveTreeWindow();
            //Check "全部平台客户及对应数据权限"
            UserDataPermissionSettings.CheckAllCustomerDatas();
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            // verify 
            Assert.IsTrue(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
            Assert.IsTrue(UserDataPermissionSettings.IsAllDataCheckboxChecked());
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));

        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Modify-101-5")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyMultiCustomerSuite), "TC-J1-FVT-UserDataScope-Modify-101-5")]
        public void NodeTreeNotChange(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            UserDataPermissionSettings.ClickModifyButton();
            //Check  customerA and customerB 
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[1]);
            UserDataPermissionSettings.UnCheckCustomer(input.InputData.CustomerList[2]);

            // check hierarchy nodes of customerA.
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.CheckHierarchyOrzNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.CheckHierarchyNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.SaveTreeWindow();
            //Check "全部平台客户及对应数据权限"
            UserDataPermissionSettings.CheckAllCustomerDatas();
            //Uncheck 
            UserDataPermissionSettings.UnCheckAllData();

            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[0]);
            // verify 
            Assert.IsFalse(UserDataPermissionSettings.IsAllDataCheckboxChecked());
            Assert.IsTrue(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
            
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchSiteNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchOrzNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.HierarchyNodePath));
            
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Modify-101-6")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyMultiCustomerSuite), "TC-J1-FVT-UserDataScope-Modify-101-6")]
        public void NodeTreeChanged(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            UserDataPermissionSettings.ClickModifyButton();

            //Click Checkall(全选). Then select 配置数据权限 link from customerA.
            UserDataPermissionSettings.CheckAllCumstomerNames();
           //@@@@@@@@@@@@@@@@@@@@@@ ·All customers checked.·全部平台客户及对应数据权限 is unchecked.
            Assert.IsFalse(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());

            // Expand the hierarchy tree of customerA.

            //Check "全部平台客户及对应数据权限"
            UserDataPermissionSettings.CheckAllCustomerDatas();
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            // verify 
            Assert.IsFalse(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Modify-101-8")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyMultiCustomerSuite), "TC-J1-FVT-UserDataScope-Modify-101-8")]
        public void NodeTreeModifyValid(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            UserDataPermissionSettings.ClickModifyButton();
            TimeManager.ShortPause();
            //Check 全部层级节点数据权限 option and click "Cancel" from 配置数据权限 window.Then click “数据权限” of CustomerD again to check the hierarchy node checker.Close.
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            UserDataPermissionSettings.CheckAllHierarchyNode();
            UserDataPermissionSettings.CancelTreeWindow();
            TimeManager.ShortPause();
            //The datascope isn't modified and the same as before modify.
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchCustomerNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchOrzNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchSiteNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchyNodeChecked(input.ExpectedData.HierarchyNodePath));
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchSiteNodeChecked(input.InputData.CustomerList));
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.CustomerList));

            //Check 全部层级节点数据权限 option and click "确定" and go to 配置数据权限. 
            UserDataPermissionSettings.CheckAllHierarchyNode();
            UserDataPermissionSettings.SaveTreeWindow();
            TimeManager.ShortPause();
            //Click "Cancel" button from customer selection window to "save" datascope of user.
            //Go to view status of exist user 客户数据权限. Click 查看数据权限 of customerD.
            UserDataPermissionSettings.ClickCancelButton();
            TimeManager.MediumPause();
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            //The datascope isn't modified and the same as before modify.
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchCustomerNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchOrzNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchSiteNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchyNodeChecked(input.ExpectedData.HierarchyNodePath));
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchSiteNodeChecked(input.InputData.CustomerList));
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.CustomerList));
            UserDataPermissionSettings.CloseTreeWindow();
            //Modify again. Check 全部层级节点数据权限 option and click "确定". Click "Save" button.
            UserDataPermissionSettings.ClickModifyButton();
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            UserDataPermissionSettings.CheckAllHierarchyNode();
            UserDataPermissionSettings.SaveTreeWindow();
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            //Click 查看数据权限 of customerD.
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.CustomerList);
            UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.ExpectedData.HierarchyNodePath);
            UserDataPermissionSettings.CloseTreeWindow();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Modify-101-9")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyMultiCustomerSuite), "TC-J1-FVT-UserDataScope-Modify-101-9")]
        public void ModifyNodeTreeAndVerify(UserDataPermissionData input)
        {
            
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            UserDataPermissionSettings.ClickModifyButton();

            //Select customerD and select 全部层级节点数据权限 option and saved datascope successfully.
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            UserDataPermissionSettings.CheckAllHierarchyNode();
            UserDataPermissionSettings.SaveTreeWindow();
            TimeManager.ShortPause();
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            /*
            //Login with UserD.  Verify userD can select organizationA:siteA: from hierarchy tree and own datascope of buildingC: tagC:
            JazzFunction.UserProfile.NavigatorToUserProfile();
            JazzFunction.UserProfile.ExitJazz();
            JazzMessageBox.MessageBox.Confirm();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            JazzFunction.LoginPage.LoginWithOption(input.InputData.UserName,input.ExpectedData.UserName,input.InputData.CustomerName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CostUsage);
            Assert.IsTrue(JazzFunction.CostPanel.SelectHierarchy(input.InputData.HierarchyNodePath));
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationHierarchy);
            JazzFunction.AssociateSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            Assert.IsTrue(JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(input.InputData.CustomerList[0]));
            JazzFunction.UserProfile.NavigatorToUserProfile();
            JazzFunction.UserProfile.ExitJazz();
            JazzMessageBox.MessageBox.Confirm();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            JazzFunction.LoginPage.LoginToAdmin();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();   
             */
        }

    }
}
