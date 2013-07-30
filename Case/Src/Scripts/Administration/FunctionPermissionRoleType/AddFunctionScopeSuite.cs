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
    public class AddFunctionScopeSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-FunctionPermissionRoleType-AddFunctionScope-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(RoleTypePermissionData[]), typeof(AddFunctionScopeSuite), "TC-J1-FVT-FunctionPermissionRoleType-AddFunctionScope-1")]
        public void AddFunctionScope(RoleTypePermissionData input)
        {
            int i = 0;
            int j = 0;
            string[] publicPermission = { "仪表盘与小组件查看", "仪表盘与小组件编辑", "个人信息管理", "报警信息查看" };
            // Click "+角色" to add a new role type
            RoleTypeSettings.ClickAddFunctionRoleType();
            TimeManager.ShortPause();
            //Fill input data
            RoleTypeSettings.FillInName(input.InputData.CommonName);
            TimeManager.ShortPause();
            //Check permission items
            while(j<input.InputData.NameList.Length)
            {
                RoleTypeSettings.Check(input.InputData.NameList[j]);
                j++;
            }
            // Click "保存" button without input FunctionRoleType and function scope.
            RoleTypeSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            //Verify 
            while (i <publicPermission.Length)
            {
                RoleTypeSettings.IsPublicPermissionItemChecked(publicPermission[j]);
                i++;
            }
            j = 0;
            while(j<input.InputData.NameList.Length)
            {
                RoleTypeSettings.IsCustomerizePermissionItemChecked(input.InputData.NameList[j]);
                j++;
            }
        }
        
        [Test]
        [CaseID("TC-J1-FVT-FunctionPermissionRoleType-AddFunctionScope-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(RoleTypePermissionData[]), typeof(AddFunctionScopeSuite), "TC-J1-FVT-FunctionPermissionRoleType-AddFunctionScope-2")]
        public void AddFUnctionScopeCancel(RoleTypePermissionData input)
        {
            string roleTypeName = "RoleTypeForAdd";
            int i = 0;
            //Check permission items
            while (i < input.InputData.NameList.Length)
            {
                // Click "+角色" to add a new role type
                RoleTypeSettings.ClickAddFunctionRoleType();
                TimeManager.ShortPause();
                //Fill input data
                RoleTypeSettings.FillInName(input.InputData.CommonName);
                TimeManager.ShortPause();
                RoleTypeSettings.Check(input.InputData.NameList[i]);
                // Click "保存" button without input FunctionRoleType and function scope.
                RoleTypeSettings.ClickCancelButton();
                TimeManager.ShortPause();
                //Verify
                Assert.IsFalse(RoleTypeSettings.IsRoleTypeOnListByName(roleTypeName));
                i++;
            }
            
        }

    }
}
