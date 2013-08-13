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
    [ManualCaseID("TC-J1-FVT-UserDataScope-Modify-001")]
    public class ModifyDataScopeInvalidSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-UserDataScope-Modify-001-1")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyDataScopeInvalidSuite), "TC-J1-FVT-UserDataScope-Modify-001-1")]
        public void ModifyThenSwitch(UserDataPermissionData input)
        {

            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            UserDataPermissionSettings.ClickModifyButton();

            // Check multiple customers 
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[1]);

            //Switch to function role type and back
            JazzFunction.FunctionRoleTypePermissionSettings.NavigatorToFunctionPermissionSettings();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UserManagementUser);
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();

           // View the data permission  
            Assert.IsTrue(UserDataPermissionSettings.IsCustomerUnchecked(input.InputData.CustomerList[0]));
            Assert.IsTrue(UserDataPermissionSettings.IsCustomerUnchecked(input.InputData.CustomerList[1]));
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);

            // View the data permission 
            //@@@@@@@@@@@@@@@@
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.ExpectedData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Modify-001-2")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyDataScopeInvalidSuite), "TC-J1-FVT-UserDataScope-Modify-001-2")]
        public void ModifyThenCancel(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            UserDataPermissionSettings.ClickModifyButton();

            // Check datascope
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            UserDataPermissionSettings.CheckHierarchyNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.CheckHierarchyNode(input.ExpectedData.HierarchyNodePath);
            UserDataPermissionSettings.CancelTreeWindow();
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            // View the data permission 
            //@@@@@@@@@@@@@@@@  lost a verify whole
            
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchyNodeChecked(input.ExpectedData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Modify-001-3")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyDataScopeInvalidSuite), "TC-J1-FVT-UserDataScope-Modify-001-3")]
        public void SaveTreeThenCancel(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            UserDataPermissionSettings.ClickModifyButton();

            // Check datascope
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            // uncheck
            UserDataPermissionSettings.CheckHierarchyNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.CheckHierarchyNode(input.ExpectedData.HierarchyNodePath);
            UserDataPermissionSettings.CheckHierarchyNode(input.ExpectedData.CustomerList);

            UserDataPermissionSettings.SaveTreeWindow();
            UserDataPermissionSettings.ClickCancelButton();
            UserDataPermissionSettings.ClickModifyButton();
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            // View the data permission 
            //@@@@@@@@@@@@@@@@  lost a verify whole

            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.ExpectedData.HierarchyNodePath));
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchyNodeChecked(input.ExpectedData.CustomerList));
            UserDataPermissionSettings.CloseTreeWindow();
        }
    }
}
