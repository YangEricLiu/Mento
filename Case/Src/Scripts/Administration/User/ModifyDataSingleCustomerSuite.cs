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
    [ManualCaseID("TC-J1-FVT-UserDataScope-Modify-102")]
    public class ModifySingleCustomerSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-UserDataScope-Modify-102-1")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifySingleCustomerSuite), "TC-J1-FVT-UserDataScope-Modify-102-1")]
        public void ModifySingleToMultiply(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();

            TimeManager.ShortPause();
            UserDataPermissionSettings.ClickModifyButton();
            
            // Check multiple customers 
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[1]);
            UserDataPermissionSettings.UnCheckCustomer(input.InputData.CustomerName);
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.CheckHierarchyNode(input.InputData.HierarchyNodePath);
            UserDataPermissionSettings.CheckHierarchyNode(input.ExpectedData.CustomerList);
            UserDataPermissionSettings.SaveTreeWindow();
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[1]);
            UserDataPermissionSettings.CheckHierarchyNode(input.ExpectedData.HierarchyNodePath);
            UserDataPermissionSettings.SaveTreeWindow();
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.IsFalse(UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerName));
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[0]);
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.InputData.HierarchyNodePath));
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.ExpectedData.CustomerList));
            UserDataPermissionSettings.CloseTreeWindow();
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[1]);
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(input.ExpectedData.HierarchyNodePath));
            UserDataPermissionSettings.CloseTreeWindow();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Modify-102-2")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifySingleCustomerSuite), "TC-J1-FVT-UserDataScope-Modify-102-2")]
        public void ModifyEmptyInvalid(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            UserDataPermissionSettings.ClickModifyButton();
            Assert.IsTrue(UserDataPermissionSettings.IsSaveButtonEnable());
            // Check datascope
            
            UserDataPermissionSettings.UnCheckCustomer(input.InputData.CustomerName);
            // View the data permission     
            Assert.IsFalse(UserDataPermissionSettings.IsSaveButtonEnable());
           
        }
    }
}
