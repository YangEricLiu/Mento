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
    [ManualCaseID("TC-J1-FVT-UserDataScope-Add-001")]
    public class AddDataScopeInvalidSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-UserDataScope-Add-001-1")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddDataScopeInvalidSuite), "TC-J1-FVT-UserDataScope-Add-001-1")]
        public void AddEmptyDataPermission(UserDataPermissionData input)
        {
           
            // Focus on a new created user, open datascope tab. 
            TimeManager.MediumPause();
            Assert.IsTrue(JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName));
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            //Verify all customers checkbox is unchecked and "编辑数据权限" link is gray out and save button disable
            Assert.IsFalse(UserDataPermissionSettings.IsSaveButtonEnable());
            Assert.IsTrue(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Add-001-2")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddDataScopeInvalidSuite), "TC-J1-FVT-UserDataScope-Add-001-2")]
        public void AddThenSwitch(UserDataPermissionData input)
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
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Add-001-3")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddDataScopeInvalidSuite), "TC-J1-FVT-UserDataScope-Add-001-3")]
        public void AddThenCancel(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            //Verify all customers checkbox is unchecked and "编辑数据权限" link is gray out and save button disable
            Assert.IsFalse(UserDataPermissionSettings.IsSaveButtonEnable());
            Assert.IsTrue(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
            //Check multiple customer checkbox from datascope.
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            UserDataPermissionSettings.CheckHierarchyNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.CheckHierarchyNode(input.ExpectedData.HierarchyNodePath);
            UserDataPermissionSettings.CancelTreeWindow();
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            // View the data permission 
            //@@@@@@@@@@@@@@@@
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsFalse(UserDataPermissionSettings.IsHierarchyNodeChecked(input.ExpectedData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
        }

    }
}
