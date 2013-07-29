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

namespace Mento.Script.Administration.FunctionPermissionRoleType
{
    [TestFixture]
    [Owner("Greenie")]
    [CreateTime("2013-07-24")]
    [ManualCaseID("TC-J1-FVT-FunctionPermissionRoleType-AddRoleType")]
    public class ModifyRoleTypeSuite : TestSuiteBase
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
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-FunctionPermissionRoleType-AddRoleType-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(RoleTypePermissionData[]), typeof(AddRoleTypeSuite), "TC-J1-FVT-FunctionPermissionRoleType-AddRoleType-1")]
        public void AllFieldsEmpty(RoleTypePermissionData input)
        {
            // Click "+角色" to add a new role type
            RoleTypeSettings.ClickAddFunctionRoleType();
            TimeManager.ShortPause();
            // Click "保存" button without input FunctionRoleType and function scope.
            RoleTypeSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            //Verify the error message 
            RoleTypeSettings.IsUserNameInvalid();
            Assert.IsTrue(RoleTypeSettings.IsUserNameInvalidMsgCorrect(input.ExpectedData));
        }
        
        [Test]
        [CaseID("TC-J1-FVT-FunctionPermissionRoleType-AddRoleType-2")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(RoleTypePermissionData[]))]
        public void AddInvalidRoleType(RoleTypePermissionData input)
        {
            // Click "+角色" to add a new role type
            RoleTypeSettings.ClickAddFunctionRoleType();
            TimeManager.ShortPause();
            //Fill input data
            RoleTypeSettings.FillInName(input.InputData.CommonName);
            TimeManager.ShortPause();
            // Click "保存" button without input FunctionRoleType and function scope.
            RoleTypeSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            //Verify the error message 
            Assert.IsTrue(RoleTypeSettings.IsUserNameInvalid());
            Assert.IsTrue(RoleTypeSettings.IsUserNameInvalidMsgCorrect(input.ExpectedData));
        }

        [Test]
        [CaseID("TC-J1-FVT-FunctionPermissionRoleType-AddRoleType-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(RoleTypePermissionData[]), typeof(AddRoleTypeSuite), "TC-J1-FVT-FunctionPermissionRoleType-AddRoleType-3")]
        public void AddRoleTypeAndCancel(RoleTypePermissionData input)
        {
            // Click "+角色" to add a new role type
            RoleTypeSettings.ClickAddFunctionRoleType();
            TimeManager.ShortPause();
            //Fill input data
            RoleTypeSettings.FillInName(input.InputData.CommonName);
            TimeManager.ShortPause();
            // Click "放弃" button without input FunctionRoleType and function scope.
            RoleTypeSettings.ClickCancelButton();
            //JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            //Verify the error message 
            Assert.IsTrue(RoleTypeSettings.IsUserNameInvalid());
            Assert.IsTrue(RoleTypeSettings.IsUserNameInvalidMsgCorrect(input.ExpectedData));
        }

        [Test]
        [CaseID("TC-J1-FVT-FunctionPermissionRoleType-AddRoleType-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(RoleTypePermissionData[]), typeof(AddRoleTypeSuite), "TC-J1-FVT-FunctionPermissionRoleType-AddRoleType-4")]
        public void AddRoleTypeToExist(RoleTypePermissionData input)
        {
           
            int i=0;
            int length = input.InputData.NameList.Length;
            while (i < length)
            {
                // Click "+角色" to add a new role type
                RoleTypeSettings.ClickAddFunctionRoleType();
                TimeManager.ShortPause();
                //Fill input data
                RoleTypeSettings.FillInName(input.InputData.NameList[i]);
                TimeManager.ShortPause();
                // Click "保存" button without input FunctionRoleType and function scope.
                RoleTypeSettings.ClickSaveButton();
                JazzMessageBox.LoadingMask.WaitLoading();
                TimeManager.ShortPause();
                //Verify the error message 
                Assert.IsTrue(RoleTypeSettings.IsUserNameInvalid());
                Assert.IsTrue(RoleTypeSettings.IsUserNameInvalidMsgCorrect(input.ExpectedData));
                TimeManager.ShortPause();
                RoleTypeSettings.ClickCancelButton();
                TimeManager.ShortPause();
                i = i + 1;
            }
        }
        
        [Test]
        [CaseID("TC-J1-FVT-FunctionPermissionRoleType-AddRoleType-5")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(RoleTypePermissionData[]), typeof(AddRoleTypeSuite), "TC-J1-FVT-FunctionPermissionRoleType-AddRoleType-5")]
        public void AddRoleTypeWithDefaultFunctionScope(RoleTypePermissionData input)
        {
            int i = 0;
            int j = 0;
            string[] publicPermission = { "仪表盘与小组件查看", "仪表盘与小组件编辑", "个人信息管理", "报警信息查看" };
            string[] roleTypePermission = { "仪表盘与小组件分享", "“能效分析”功能", "“碳排放”功能", "“成本”功能", "“单位指标”功能", "“时段能耗比”功能", "“集团排名”功能", "数据导出", "REM平台管理", "层级结构管理", "普通数据点管理", "数据点关联", "客户信息查看", "客户信息管理" };
            // Click "+角色" to add a new role type
            RoleTypeSettings.ClickAddFunctionRoleType();
            TimeManager.ShortPause();
            //Fill input data
            RoleTypeSettings.FillInName(input.InputData.CommonName);
            TimeManager.ShortPause();
            // Click "保存" button without input FunctionRoleType and function scope.
            RoleTypeSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            RoleTypeSettings.FocusOnUserType(input.InputData.CommonName);
            TimeManager.ShortPause();
            //Assert.IsTrue(RoleTypeSettings.IsPermissionItemChecked());
            
            // Verfiy the public permissions are checked
            /*
            while (i < 4)
            {
                Assert.IsTrue(RoleTypeSettings.IsPermissionItemCheckedNew(publicPermission));
                i++;
            }

            while (j< 10)
            {
                Assert.IsFalse(RoleTypeSettings.IsPermissionItemChecked(roleTypePermission[j]));
                j++;
            }*/
        }
    }
}
