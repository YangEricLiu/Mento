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
            //Verify that the message 'Are your sure to delete the role type?' is displayed on message box.
            //Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.Message[0]));
            Assert.AreEqual(input.ExpectedData.Message[0], JazzMessageBox.MessageBox.GetMessage());
            //Click GiveUp button to cancel the deletion.
            JazzMessageBox.MessageBox.GiveUp();
            TimeManager.ShortPause();
            //Verify the role type not deleted and still exists
            RoleTypeSettings.FocusOnUserType(input.InputData.CommonName);
            Assert.IsTrue(RoleTypeSettings.IsRoleTypeOnListByName(input.InputData.CommonName));
            // Delete the role type again
            RoleTypeSettings.ClickDeleteButton();
            //Verify that the message 'Are your sure to delete the role type?' is displayed on message box.
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.Message[0]));
            //Click Delete button to confirm the deletion.
            JazzMessageBox.MessageBox.Delete();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            //Verify the role type is deleted successfully and not exists
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
            //Verify that the message 'Are your sure to delete the role type?' is displayed on message box.
            //Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.Message[0]));
            Assert.AreEqual(input.ExpectedData.Message[0], JazzMessageBox.MessageBox.GetMessage());
            //Click Delete button to confirm the deletion.
            JazzMessageBox.MessageBox.Delete();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            //Verify that the message 'The role type has been used and can't be deleted.' is displayed on message box.            
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.Message[1]));
            //Close the message box.
            JazzMessageBox.MessageBox.Close();
            //Verify the role type not deleted and still exists
            Assert.IsTrue(RoleTypeSettings.IsRoleTypeOnListByName(input.InputData.CommonName));
        }  
    }
}
