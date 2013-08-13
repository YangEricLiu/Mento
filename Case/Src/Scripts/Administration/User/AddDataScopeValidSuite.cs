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

    }
}
