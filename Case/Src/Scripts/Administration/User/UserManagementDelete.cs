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

namespace Mento.Script.Administration.User
{
    [TestFixture]
    public class UserManagementDelete : TestSuiteBase
    {
        private UserSettings UserSettings = JazzFunction.UserSettings;

        [SetUp]
        [Owner("Nancy")]
        [CreateTime("2013-01-08")]
        [ManualCaseID("TC-J1-SmokeTest")]
        //Summary
        //Add/Modify/Delete user validation
        //Use Data
        public void CaseSetUp()
        {
            UserSettings.NavigatorToUserSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        //Delete user cancel and success verify.
        [Test]
        [CaseID("SR-J1-User-002-TC-J1-FVT-UserManagement"), CreateTime("2013-01-08"), Owner("Nancy")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserManagementDelete), "TC-J1-FVT-UserManagement-Add-101-2")]
        //Delete user cancel and success verify.
        public void DeleteUser(UserSettingsData testData)
        {
            string deleteUser = "Nancy_EngineerBlankComment";
            UserSettings.FocusOnUser(deleteUser);
            UserSettings.DeleteUser();

            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains("您将同时删除该用户下的所有已配置仪表盘。"));
            JazzMessageBox.MessageBox.Cancel();

            UserSettings.DeleteUser();
            JazzMessageBox.MessageBox.Close();

            UserSettings.DeleteUser();
            JazzMessageBox.MessageBox.Confirm();
            TimeManager.ShortPause();
        }
    }
}