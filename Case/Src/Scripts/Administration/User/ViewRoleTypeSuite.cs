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
    [CreateTime("2013-08-01")]
    [ManualCaseID("TC-J1-FVT-UserManagement-ViewRoleType")]
    public class ViewRoleTypeSuite : TestSuiteBase
    {
        private UserSettings UserSettings = JazzFunction.UserSettings;

        [SetUp]
        public void CaseSetUp()
        {
            UserSettings.NavigatorToUserSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.LoginPage.RefreshJazz("EMOP系统管理");
        }

        [Test]
        [CaseID("TC-J1-FVT-UserManagement-ViewRoleType-1")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(ViewRoleTypeSuite), "TC-J1-FVT-UserManagement-ViewRoleType-1")]
        public void ViewRoleType(UserSettingsData input)
        {
            UserSettings.ClickAddUser();
            TimeManager.ShortPause();
            //int i = 0;
            //while (i < input.InputData.TypeList.Length)
            //{
                UserSettings.SelectFuctionRoleType(input.InputData.TypeList[0]);
                TimeManager.LongPause();
                //Assert.IsTrue(UserSettings.IsViewFunctionPermissionDispalyed());
                //Assert.IsTrue(UserSettings.IsViewFunctionPermissionEnabled());
                UserSettings.ClickViewFunctionPermissionLinkButton();
                //string a = "仪表盘与小组件查看\r\n仪表盘与小组件编辑\r\n个人信息管理\r\n报警信息查看仪表盘与小组件分享\r\n“能效分析”功能\r\n“碳排放”功能\r\n“成本”功能\r\n“单位指标”功能\r\n“时段能耗比”功能\r\n“集团排名”功能\r\n数据导出\r\nEMOP系统管理\r\n层级结构管理\r\n普通数据点管理\r\n数据点关联\r\n客户信息查看\r\n客户信息管理";
                Assert.AreEqual(input.ExpectedData.FunctionScopeList[0], UserSettings.GetPermissionItemsSameAsViewItems());
                UserSettings.ClickFunctionCloseButton();
               // i++;
            //}
        }
        
        [Test]
        [CaseID("TC-J1-FVT-UserManagement-ViewRoleType-2")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(ViewRoleTypeSuite), "TC-J1-FVT-UserManagement-ViewRoleType-2")]
        public void ModifyAndViewRoleType(UserSettingsData input)
        {
            UserSettings.ClickAddUser();
            TimeManager.ShortPause();

            UserSettings.SelectFuctionRoleType(input.InputData.TypeList[0]);
            Assert.IsTrue(UserSettings.IsViewFunctionPermissionDispalyed());
            Assert.IsTrue(UserSettings.IsViewFunctionPermissionEnabled());
            UserSettings.ClickViewFunctionPermissionLinkButton();
            //Assert.AreEqual(input.InputData.CommonName, UserSettings.GetPermissionItemsSameAsViewItems());
            UserSettings.ClickFunctionCloseButton();

            // select another new creat function role type
            UserSettings.SelectFuctionRoleType(input.InputData.CommonName);
            Assert.IsTrue(UserSettings.IsViewFunctionPermissionDispalyed());
            Assert.IsTrue(UserSettings.IsViewFunctionPermissionEnabled());
            UserSettings.ClickViewFunctionPermissionLinkButton();
            //Assert.AreEqual(input.ExpectedData.CommonName, UserSettings.GetPermissionItemsSameAsViewItems());
            UserSettings.ClickFunctionCloseButton();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserManagement-ViewRoleType-3")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(ViewRoleTypeSuite), "TC-J1-FVT-UserManagement-ViewRoleType-3")]
        public void ModifyRoleTypeFunctionAndViewUser(UserSettingsData input)
        {
            //focus a user
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UserManagementUserTypePermission);
            TimeManager.MediumPause();
            JazzFunction.UserTypePermissionSettings.FocusOnUserType("RoleTypeUsed");
            JazzFunction.UserTypePermissionSettings.ClickModifyButton();
            //modify the function role type
            JazzFunction.UserTypePermissionSettings.Check("仪表盘与小组件分享");
            JazzFunction.UserTypePermissionSettings.Check("“碳排放”功能");
            JazzFunction.UserTypePermissionSettings.Check("“能效分析”功能");
            JazzFunction.UserTypePermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //Verify
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UserManagementUser);
            UserSettings.FocusOnUser(input.InputData.CommonName);
            UserSettings.ClickViewFunctionPermissionLinkButton();
            TimeManager.ShortPause();
            //Assert.AreEqual(input.ExpectedData.CommonName, UserSettings.GetPermissionItemsSameAsViewItems());
            UserSettings.ClickFunctionCloseButton();
        }

    }
}
