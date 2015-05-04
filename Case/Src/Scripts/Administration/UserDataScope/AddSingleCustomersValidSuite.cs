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
    [CreateTime("2013-08-19")]
    [ManualCaseID("TC-J1-FVT-UserDataScope-Add-102")]
    public class AddSingleCustomersValidSuite : TestSuiteBase
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
            JazzFunction.TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Add-102-AddDataScope-1")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddSingleCustomersValidSuite), "TC-J1-FVT-UserDataScope-Add-102-AddDataScope-1")]
        public void CheckSingleCustomer(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            //Verify all customers checkbox is unchecked and "编辑数据权限" link is gray out and save button disable
            Assert.IsFalse(UserDataPermissionSettings.IsSaveButtonEnable());
            Assert.IsTrue(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
           
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            UserDataPermissionSettings.CheckHierarchyNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.SaveTreeWindow();
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
            TimeManager.ShortPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Add-102-AddDataScope-2")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddSingleCustomersValidSuite), "TC-J1-FVT-UserDataScope-Add-102-AddDataScope-2")]
        public void AddMultipleNodeAndView(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            //Verify all customers checkbox is unchecked and "编辑数据权限" link is gray out and save button disable

            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            UserDataPermissionSettings.CheckHierarchyNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.SaveTreeWindow();
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
            TimeManager.ShortPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Add-102-AddDataScope-3")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddSingleCustomersValidSuite), "TC-J1-FVT-UserDataScope-Add-102-AddDataScope-3")]
        public void LongNameNodeDisplay(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            //Verify all customers checkbox is unchecked and "编辑数据权限" link is gray out and save button disable

            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName);
            Assert.IsTrue(UserDataPermissionSettings.CheckHierarchyNode(input.InputData.HierarchyNodePath));

            UserDataPermissionSettings.CloseTreeWindow();
        }

     
    }
}
