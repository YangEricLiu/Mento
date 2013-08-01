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
    [CreateTime("2013-07-29")]
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
            JazzFunction.TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
        }

        [Test]
        [CaseID("TC-J1-FVT-FunctionPermissionRoleType-ModifyRoleType-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(RoleTypePermissionData[]), typeof(ModifyRoleTypeSuite), "TC-J1-FVT-FunctionPermissionRoleType-ModifyRoleType-1")]
        public void AllFieldsEmpty(RoleTypePermissionData input)
        {
            // Focus a  role type
            RoleTypeSettings.FocusOnUserType(input.InputData.CommonName);
            RoleTypeSettings.ClickModifyButton();
            TimeManager.ShortPause();
            RoleTypeSettings.FillInName("");
            RoleTypeSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            //Verify the error message 
            RoleTypeSettings.IsUserNameInvalid();
            Assert.IsTrue(RoleTypeSettings.IsUserNameInvalidMsgCorrect(input.ExpectedData));
        }
        
        [Test]
        [CaseID("TC-J1-FVT-FunctionPermissionRoleType-ModifyRoleType-2")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(RoleTypePermissionData[]))]
        public void ModifyInvalidRoleType(RoleTypePermissionData input)
        {
            string roleTypeName = "RoleTypeForModify";
            // Focus a  role type
            RoleTypeSettings.FocusOnUserType(roleTypeName);
            RoleTypeSettings.ClickModifyButton();
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
        [CaseID("TC-J1-FVT-FunctionPermissionRoleType-ModifyRoleType-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(RoleTypePermissionData[]), typeof(ModifyRoleTypeSuite), "TC-J1-FVT-FunctionPermissionRoleType-ModifyRoleType-3")]
        public void ModifyRoleTypeAndCancel(RoleTypePermissionData input)
        {
            string roleTypeName = "RoleTypeForModify";
            // Focus a  role type
            RoleTypeSettings.FocusOnUserType(roleTypeName);
            RoleTypeSettings.ClickModifyButton();
            TimeManager.ShortPause();
            // problem here@@@@@@@@@@@@@@
            //Fill input data
            RoleTypeSettings.FillInName(input.InputData.CommonName);
            TimeManager.ShortPause();
            // Click "放弃" button without input FunctionRoleType and function scope.
            RoleTypeSettings.ClickCancelButton();
            //JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            //Verify 
            Assert.IsFalse(RoleTypeSettings.IsRoleTypeOnListByName(input.InputData.CommonName));
        }

        [Test]
        [CaseID("TC-J1-FVT-FunctionPermissionRoleType-ModifyRoleType-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(RoleTypePermissionData[]), typeof(ModifyRoleTypeSuite), "TC-J1-FVT-FunctionPermissionRoleType-ModifyRoleType-4")]
        public void ModifyRoleToExist(RoleTypePermissionData input)
        {
           
            int i=0;
            int length = input.InputData.NameList.Length;
            while (i < length)
            {
                // Focus a  role type
                RoleTypeSettings.FocusOnUserType(input.InputData.CommonName);
                RoleTypeSettings.ClickModifyButton();
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
    }
}
