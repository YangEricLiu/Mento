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
    [CreateTime("2013-07-29")]
    [ManualCaseID("TC-J1-FVT-FunctionPermissionRoleType-Delete")]
    public class DeleteRoleTypeSuite : TestSuiteBase
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
            //JazzFunction.Navigator.NavigateHome();
            JazzFunction.TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
        }

        [Test]
        [CaseID("TC-J1-FVT-FunctionPermissionRoleType-Delete-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(RoleTypePermissionData[]), typeof(DeleteRoleTypeSuite), "TC-J1-FVT-FunctionPermissionRoleType-Delete-1")]
        public void DeleteRoleType(RoleTypePermissionData input)
        {
            // Focus a function role type to delete
            RoleTypeSettings.FocusOnUserType(input.InputData.CommonName);
            TimeManager.ShortPause();
            //Delete the role type
            RoleTypeSettings.ClickDeleteButton();
            JazzMessageBox.MessageBox.Cancel();
            TimeManager.ShortPause();
            //Verify whether role type exist
            RoleTypeSettings.FocusOnUserType(input.InputData.CommonName);
            Assert.IsTrue(RoleTypeSettings.IsRoleTypeOnListByName(input.InputData.CommonName));
            // Delete the role type 
            RoleTypeSettings.ClickDeleteButton();
            JazzMessageBox.MessageBox.Confirm();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(RoleTypeSettings.IsRoleTypeOnListByName(input.InputData.CommonName));
        }
        
        [Test]
        [CaseID("TC-J1-FVT-FunctionPermissionRoleType-Delete-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(RoleTypePermissionData[]), typeof(DeleteRoleTypeSuite), "TC-J1-FVT-FunctionPermissionRoleType-Delete-2")]
        public void DeleteRoleTypeFailedWhenAssociated(RoleTypePermissionData input)
        {
            // Focus a function role type to delete
            RoleTypeSettings.FocusOnUserType(input.InputData.CommonName);
            TimeManager.ShortPause();
            //Delete the role type
            RoleTypeSettings.ClickDeleteButton();
            JazzMessageBox.MessageBox.Confirm();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            JazzMessageBox.MessageBox.Close();
            Assert.IsTrue(RoleTypeSettings.IsRoleTypeOnListByName(input.InputData.CommonName));
        }

      
    }
}
