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
    [CreateTime("2013-08-13")]
    [ManualCaseID("TC-J1-FVT-UserDataScope-Modify-101")]
    public class ModifyMultiCustomerSuite : TestSuiteBase
    {
        private UserDataScopePermission UserDataPermissionSettings = JazzFunction.UserDataScopePermission;

        [SetUp]
        public void CaseSetUp()
        {
            UserDataPermissionSettings.NavigatorToUserSetting();
            TimeManager.LongPause();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
            JazzFunction.LoginPage.RefreshJazz("$@Login.Label.SPManagement");
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Modify-101-1")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyMultiCustomerSuite), "TC-J1-FVT-UserDataScope-Modify-101-1")]
        public void ModifyMultiToSingle(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            TimeManager.ShortPause();
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.MediumPause();
            UserDataPermissionSettings.ClickModifyButton();
            TimeManager.ShortPause();
            // Check multiple customers 
            UserDataPermissionSettings.UnCheckCustomer(input.InputData.CustomerList[0]);
            TimeManager.ShortPause();
            UserDataPermissionSettings.UnCheckCustomer(input.InputData.CustomerList[1]);
            TimeManager.ShortPause();
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[2]);
            TimeManager.ShortPause();
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

           // View the data permission  
            Assert.IsFalse(UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[0]));
            Assert.IsFalse(UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[1]));
            
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[2]);
            TimeManager.ShortPause();
            UserDataPermissionSettings.CloseTreeWindow();
            TimeManager.ShortPause();

        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Modify-101-2")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyMultiCustomerSuite), "TC-J1-FVT-UserDataScope-Modify-101-2")]
        public void ModifyMultiCustomer(UserDataPermissionData input)   
        {
            // Focus on an exist UserForMultiCustomer, open datascope tab.
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            UserDataPermissionSettings.ClickModifyButton();

            // Check customerD and uncheck customerC
            UserDataPermissionSettings.UnCheckCustomer(input.InputData.CustomerList[2]);
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[3]);
            TimeManager.MediumPause();
            // Set Customer A hierarchy check node 
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[0]);
            TimeManager.ShortPause();
            Assert.IsTrue(UserDataPermissionSettings.CheckHierarchySiteNode(input.InputData.HierarchyNodePath));
            TimeManager.ShortPause();
            UserDataPermissionSettings.UnCheckHierarchyNode(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            UserDataPermissionSettings.UnCheckHierarchyOrzNode(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();
            UserDataPermissionSettings.SaveTreeWindow();
            TimeManager.ShortPause();

            // Set Customer B hierarchy check node 
             UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[1]);
             UserDataPermissionSettings.UnCheckHierarchySiteNode(input.ExpectedData.HierarchyNodePath);
             TimeManager.ShortPause();
             UserDataPermissionSettings.CheckHierarchyNode(input.ExpectedData.HierarchyNodePath);
             TimeManager.ShortPause();
             UserDataPermissionSettings.CheckHierarchyOrzNode(input.ExpectedData.HierarchyNodePath);
             TimeManager.ShortPause();
             UserDataPermissionSettings.SaveTreeWindow();

            //Save 
             UserDataPermissionSettings.ClickSaveButton();
             JazzMessageBox.LoadingMask.WaitLoading();
             TimeManager.LongPause();
             
            // view customer A 
             UserDataPermissionSettings.ClickModifyButton();
             TimeManager.LongPause();
             UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[0]);
             TimeManager.MediumPause();
             Assert.IsTrue(UserDataPermissionSettings.IsHierarchOrzNodeChecked(input.InputData.HierarchyNodePath));
             //Assert.IsFalse(UserDataPermissionSettings.IsHierarchOrzNodeChecked(input.InputData.HierarchyNodePath));
             //Assert.IsFalse(UserDataPermissionSettings.IsHierarchCustomerNodeChecked(input.InputData.HierarchyNodePath));
             UserDataPermissionSettings.CloseTreeWindow();

             // view customer B 
             UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[1]);
             Assert.IsTrue(UserDataPermissionSettings.IsHierarchSiteNodeChecked(input.ExpectedData.HierarchyNodePath));
             Assert.IsFalse(UserDataPermissionSettings.IsHierarchOrzNodeChecked(input.ExpectedData.HierarchyNodePath));
             Assert.IsFalse(UserDataPermissionSettings.IsHierarchCustomerNodeChecked(input.ExpectedData.HierarchyNodePath));
             UserDataPermissionSettings.CloseTreeWindow();
            // Tag association@@@@@@@@@@@@@@@@@@@  not finish

             //Save 
             UserDataPermissionSettings.ClickCancelButton();
             JazzMessageBox.LoadingMask.WaitLoading();
             TimeManager.LongPause();

            // Check 客户名称 to check all the customerr names
             UserDataPermissionSettings.ClickModifyButton();
             TimeManager.LongPause();
             TimeManager.LongPause();
             UserDataPermissionSettings.CheckAllCumstomerNames();
             UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[2]);
             Assert.IsFalse(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePathsArray[0]));
             UserDataPermissionSettings.CloseTreeWindow();
             TimeManager.ShortPause();
             UserDataPermissionSettings.ClickSaveButton();
             JazzMessageBox.LoadingMask.WaitLoading();
             TimeManager.ShortPause();
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
            Assert.IsTrue(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            // verify 
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
            TimeManager.ShortPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Modify-101-4")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyMultiCustomerSuite), "TC-J1-FVT-UserDataScope-Modify-101-4")]
        public void ModifyMultiToAll(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            UserDataPermissionSettings.ClickModifyButton();
            TimeManager.LongPause();
            //Check  customerA and customerB 
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[1]);

            // check hierarchy nodes of customerA.
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.CheckHierarchyOrzNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.CheckHierarchyBuildingNode(input.ExpectedData.HierarchyNodePath);
            UserDataPermissionSettings.SaveTreeWindow();

            //Check "全部平台客户及对应数据权限"
            UserDataPermissionSettings.CheckAllCustomerDatas();
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            // verify 
            Assert.IsTrue(UserDataPermissionSettings.IsAllDataCheckboxChecked());
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.ExpectedData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
            TimeManager.ShortPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Modify-101-5")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyMultiCustomerSuite), "TC-J1-FVT-UserDataScope-Modify-101-5")]
        public void NodeTreeNotChange(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            TimeManager.ShortPause();
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.MediumPause();
            UserDataPermissionSettings.ClickModifyButton();
            //Check  customerA and customerB 
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[1]);
            UserDataPermissionSettings.UnCheckCustomer(input.InputData.CustomerList[2]);

            // check hierarchy nodes of customerA.
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.CheckAllHierarchyNode();
            UserDataPermissionSettings.SaveTreeWindow();
            //Check "全部平台客户及对应数据权限"
            UserDataPermissionSettings.CheckAllCustomerDatas();
            //Uncheck 
            UserDataPermissionSettings.UnCheckAllData();

            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[0]);

            // verify 全部层级节点数据权限 checkbox is checked and all customer hierarchy tree is checked.
            Assert.IsFalse(UserDataPermissionSettings.IsAllDataCheckboxChecked());                       

            Assert.IsTrue(UserDataPermissionSettings.IsHierarchSiteNodeChecked(input.InputData.HierarchyNodePath));
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
            //UserDataPermissionSettings.CheckAllCumstomerNames();
           //@@@@ ·All customers checked.·全部平台客户及对应数据权限 is unchecked.
            Assert.IsTrue(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());

            //Uncheck 全选 then 选择CustomerA, Then select 配置数据权限 link from customerA.
            UserDataPermissionSettings.UnCheckAllData();
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            UserDataPermissionSettings.CheckHierarchyOrzNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.SaveTreeWindow();
            TimeManager.ShortPause();

            //全选 then Uncheck全选, 选择CustomerA Then select 配置数据权限 link from customerA again.
            //之前选择的hierarchy node of customerA still checked.
            UserDataPermissionSettings.CheckAllCumstomerNames();
            UserDataPermissionSettings.UnCheckAllData();
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);

            // verify 之前选择的hierarchy node of customerA still checked.
            Assert.IsFalse(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchSiteNodeChecked(input.InputData.HierarchyNodePath));
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
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchCustomerNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchOrzNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchSiteNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchyNodeChecked(input.ExpectedData.HierarchyNodePath));

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
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchCustomerNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchOrzNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchSiteNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchyNodeChecked(input.ExpectedData.HierarchyNodePath));
            //Assert.IsTrue(UserDataPermissionSettings.IsHierarchSiteNodeChecked(input.InputData.CustomerList));
            //Assert.IsFalse(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.CustomerList));
            UserDataPermissionSettings.CloseTreeWindow();
            
            //Modify again. Check 全部层级节点数据权限 option and click "确定". Click "Save" button.
            UserDataPermissionSettings.ClickModifyButton();
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            UserDataPermissionSettings.CheckAllHierarchyNode();
            UserDataPermissionSettings.SaveTreeWindow();
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            //Click 查看数据权限 of customerD.
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.CustomerList));
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.InputData.HierarchyNodePath));
            Assert.IsTrue(UserDataPermissionSettings.AreAllHierarchyNodesChecked(input.ExpectedData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Modify-101-9")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyMultiCustomerSuite), "TC-J1-FVT-UserDataScope-Modify-101-9")]
        public void ModifyNodeTreeAndVerify(UserDataPermissionData input)
        {
            
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            TimeManager.ShortPause();
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.MediumPause();
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
