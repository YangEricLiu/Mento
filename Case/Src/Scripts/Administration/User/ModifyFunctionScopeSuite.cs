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
            while (s < input.InputData.NameList.Length)
            {
                // Focus a  role type
                RoleTypeSettings.FocusOnUserType(input.InputData.NameList[s]);
                RoleTypeSettings.ClickModifyButton();
                TimeManager.ShortPause();
                for (i = 0; i < 4; i++)
                {
                    Assert.IsTrue(RoleTypeSettings.IsPermissionItemDisabled(input.InputData.publicPermission[i]));
                }
                for (j = 0; j < input.InputData.customerizePermission.Length; j++)
                {
                    Assert.IsFalse(RoleTypeSettings.IsPermissionItemDisabled(input.InputData.customerizePermission[j]));
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
            while (j < input.InputData.permissions.Length)
            {
                RoleTypeSettings.Check(input.InputData.permissions[j]);
                RoleTypeSettings.UnCheck(input.InputData.permissions[j]);
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
                Assert.IsFalse(RoleTypeSettings.IsCustomerizePermissionItemChecked(input.InputData.permissions[j]));
                j++;
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-FunctionPermissionRoleType-ModifyFunctionScope-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(RoleTypePermissionData[]), typeof(ModifyFunctionScopeSuite), "TC-J1-FVT-FunctionPermissionRoleType-ModifyFunctionScope-3")]
        public void ModifyFunctionScopeSuccess(RoleTypePermissionData input)
        {
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
            while (j < input.InputData.permissions.Length)
            {
                RoleTypeSettings.Check(input.InputData.permissions[j]);
                RoleTypeSettings.UnCheck(input.InputData.permissions[j]);
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
                Assert.IsFalse(RoleTypeSettings.IsCustomerizePermissionItemChecked(input.InputData.permissions[j]));
                j++;
            }
        }
       
    }
}
