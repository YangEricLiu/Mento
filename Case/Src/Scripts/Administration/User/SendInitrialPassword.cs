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
    [ManualCaseID("TC-J1-FVT-UserManagement-SendInitialPasswordLink")]
    public class SendInitrialPassword : TestSuiteBase
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
            JazzFunction.TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserManagement-SendInitialPasswordLink-1")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(SendInitrialPassword), "TC-J1-FVT-UserManagement-SendInitialPasswordLink-1")]
        public void SendEmailAndInitialPasswordSuccess(UserSettingsData input)
        {
            //Click "+用户"
            UserSettings.ClickAddUser();
            TimeManager.ShortPause();
            UserSettings.FillInAddUser(input.InputData);
            TimeManager.MediumPause();
            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            Assert.IsTrue(UserSettings.IsEmailSendButtonDispalyed());
            Assert.IsTrue(UserSettings.IsEmailSendButtonEnabled());
            UserSettings.ClickEmailSendButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            Assert.AreEqual(input.ExpectedData.Message,JazzMessageBox.MessageBox.GetMessage());
            JazzMessageBox.MessageBox.OK();
        }
        
        [Test]
        [CaseID("TC-J1-FVT-UserManagement-SendInitialPasswordLink-2")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(SendInitrialPassword), "TC-J1-FVT-UserManagement-SendInitialPasswordLink-2")]
        public void SendEmailNotavailableToLoginUser(UserSettingsData input)
        {
            //focus a user
            UserSettings.FocusOnUser(input.InputData.CommonName);
            Assert.IsFalse(UserSettings.IsEmailSendButtonDispalyed());
        }
    }
}
