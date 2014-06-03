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
    [CreateTime("2013-07-24")]
    [ManualCaseID("TC-J1-FVT-FunctionPermissionRoleType-AddRoleType")]
    public class ModifyFunctionScopeSuite : TestSuiteBase
    {
        private FunctionRoleTypePermissionSettings RoleTypeSettings = JazzFunction.FunctionRoleTypePermissionSettings;

        [SetUp]
        public void CaseSetUp()
        {
            RoleTypeSettings.NavigatorToFunctionPermissionSettings();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
        }

        [Test]
        [CaseID("TC-J1-FVT-FunctionPermissionRoleType-ModifyFunctionScope-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(RoleTypePermissionData[]), typeof(ModifyFunctionScopeSuite), "TC-J1-FVT-FunctionPermissionRoleType-ModifyFunctionScope-1")]
        public void PublicFunctionUncheck(RoleTypePermissionData input)
        {
            int i,j,s = 0;
            string[] publicPermission = {"仪表盘与小组件查看","仪表盘与小组件编辑","个人信息管理","地图信息查看" };
            string[] customerizePermission = { "仪表盘和小组件分享与共享", "“能效分析”功能", "“碳排放”功能", "“成本”功能", "“单位指标”功能", "“时段能耗比”功能", "“能效标识”功能", "“集团排名”功能", "数据导出", "“云能效”系统管理", "层级结构管理", "普通数据点管理", "数据点关联", "客户信息查看", "客户信息管理", "自定义能效标识" };
            while (s < input.InputData.NameList.Length)
            {
                // Focus a  role type
                RoleTypeSettings.FocusOnUserType(input.InputData.NameList[s]);
                RoleTypeSettings.ClickModifyButton();
                TimeManager.ShortPause();
                for (i = 0; i < 4; i++)
                {
                    Assert.IsTrue(RoleTypeSettings.IsPermissionItemDisabled(publicPermission[i]));
                }
                for (j = 0; j < customerizePermission.Length; j++)
                {
                    Assert.IsFalse(RoleTypeSettings.IsPermissionItemDisabled(customerizePermission[j]));
                }
                RoleTypeSettings.ClickCancelButton();
                s++;
            }
            
        }

        [Test]
        [CaseID("TC-J1-FVT-FunctionPermissionRoleType-ModifyFunctionScope-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(RoleTypePermissionData[]), typeof(ModifyFunctionScopeSuite), "TC-J1-FVT-FunctionPermissionRoleType-ModifyFunctionScope-2")]
        public void ModifyAndThenCancel(RoleTypePermissionData input)
        {
            string[] permissions = { "“能效分析”功能", "“碳排放”功能", "“成本”功能", "“云能效”系统管理", "层级结构管理", "普通数据点管理", "数据点关联", "客户信息查看", "客户信息管理", "“集团排名”功能", "“单位指标”功能", "“时段能耗比”功能" };
            // Focus a  role type
            RoleTypeSettings.FocusOnUserType(input.InputData.CommonName);
            RoleTypeSettings.ClickModifyButton();
            TimeManager.ShortPause();
            int i = 0;
            //Click some functions without "√" from function scope.
            while (i < input.InputData.NameList.Length)
            {
                RoleTypeSettings.UnCheck(input.InputData.NameList[i]);
                RoleTypeSettings.Check(input.InputData.NameList[i]);
                i++;
            }
            int j = 0;
            while (j < permissions.Length)
            {
                RoleTypeSettings.Check(permissions[j]);
                RoleTypeSettings.UnCheck(permissions[j]);
                j++;
            }
            // Click "保存" button without input FunctionRoleType and function scope.
            RoleTypeSettings.ClickCancelButton();
            TimeManager.ShortPause();
            //Verify
            // Verify pubic permissions checked
            Assert.IsTrue(RoleTypeSettings.ArePublicPermissionItemsChecked());
            // verify other permissions 
            i = 0;
            while (i < input.InputData.NameList.Length)
            {
                Assert.IsTrue(RoleTypeSettings.IsCustomerizePermissionItemChecked(input.InputData.NameList[i]));
                i++;
            }
            j = 0;
            while (j < input.InputData.NameList.Length)
            {
                Assert.IsFalse(RoleTypeSettings.IsCustomerizePermissionItemChecked(permissions[j]));
                j++;
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-FunctionPermissionRoleType-ModifyFunctionScope-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(RoleTypePermissionData[]), typeof(ModifyFunctionScopeSuite), "TC-J1-FVT-FunctionPermissionRoleType-ModifyFunctionScope-3")]
        public void ModifyFunctionScopeSuccess(RoleTypePermissionData input)
        {
           string[]  permissions = {"“能效分析”功能","“碳排放”功能","“成本”功能","“云能效”系统管理","层级结构管理","普通数据点管理","数据点关联","客户信息查看","客户信息管理","“集团排名”功能","“单位指标”功能","“时段能耗比”功能"};
            // Focus a  role type
            RoleTypeSettings.FocusOnUserType(input.InputData.CommonName);
            RoleTypeSettings.ClickModifyButton();
            
            TimeManager.ShortPause();
            int i = 0;
            while (i< input.InputData.NameList.Length)
            {
                RoleTypeSettings.UnCheck(input.InputData.NameList[i]);
                RoleTypeSettings.Check(input.InputData.NameList[i]);
               i++;
            }
            int j = 0;
            while(j<permissions.Length)
            {
                RoleTypeSettings.Check(permissions[j]);
                RoleTypeSettings.UnCheck(permissions[j]);
                j++;
            }
            // Click "保存" button without input FunctionRoleType and function scope.
            RoleTypeSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            //Verify
            // Verify pubic permissions checked
            Assert.IsTrue(RoleTypeSettings.ArePublicPermissionItemsChecked());
           // verify other permissions 
            i = 0;
            while(i<input.InputData.NameList.Length)
            {
                Assert.IsTrue(RoleTypeSettings.IsCustomerizePermissionItemChecked(input.InputData.NameList[i]));
                i++;
            }
            j = 0;
            while (j < input.InputData.NameList.Length)
            {
                Assert.IsFalse(RoleTypeSettings.IsCustomerizePermissionItemChecked(permissions[j]));
                j++;
            }
        }
       
    }
}
