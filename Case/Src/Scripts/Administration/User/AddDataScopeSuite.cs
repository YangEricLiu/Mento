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
    public class AddDataScopeSuite : TestSuiteBase
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
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(AddDataScopeSuite), "TC-J1-FVT-UserDataScope-Add-101-1")]
        public void AddAndViewRootNode(UserDataPermissionData input)
        {
            string[] hierarchyNode = {"NancyCustomer1","GreenieSite","GreenieBuilding"};

            // Focus on a new created user, open datascope tab. 
            //JazzFunction.UserSettings.FocusOnUser(input.InputData.);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            //Verify all customers checkbox is unchecked and "编辑数据权限" link is gray out
            Assert.IsTrue(UserDataPermissionSettings.AreAllEditDataPermissionLinkButtonDisable());
            
            //UserDataPermissionSettings.IsHierarchyNodeChecked();
            
            /*
            UserDataPermissionSettings.ClickModifyButton();

            Assert.IsTrue(UserDataPermissionSettings.IsSelectAllCustomerNamesButtonEnable());

            UserDataPermissionSettings.CheckAllCumstomerNames();
            TimeManager.LongPause();

            UserDataPermissionSettings.ClickCancelButton();

            Assert.IsFalse(UserDataPermissionSettings.IsSelectAllCustomerNamesButtonEnable());
            //UserDataPermissionSettings.CheckAllCustomerDatas();

           
            UserDataPermissionSettings.CheckCustomer("NancyCustomer1");
            UserDataPermissionSettings.ClickEditDataPermission("NancyCustomer1");

            UserDataPermissionSettings.CheckHierarchyNode(hierarchyNode);
            //Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(hierarchyNode));
            UserDataPermissionSettings.SaveTreeWindow();
            TimeManager.ShortPause();
            
            
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            // View the customer data permission
            //Assert.IsTrue(UserDataPermissionSettings.IsEditDataPermissionEnable("NancyCustomer1"));
            UserDataPermissionSettings.ClickEditDataPermission("NancyCustomer1");
            Assert.IsTrue(UserDataPermissionSettings.IsHierarchyNodeChecked(hierarchyNode));
            UserDataPermissionSettings.CloseTreeWindow();
            */
        }


    }
}
