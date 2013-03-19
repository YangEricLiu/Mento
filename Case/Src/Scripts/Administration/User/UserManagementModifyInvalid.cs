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
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.TestData.Attribute;

namespace Mento.Script.Administration.User
{
    [TestFixture]
    public class UserManagementModifyInvalid : TestSuiteBase
    {
        private UserSettings UserSettings = JazzFunction.UserSettings;

        [SetUp]
        [Owner("Nancy")]
        [CreateTime("2013-03-13")]
        [ManualCaseID("TC-J1-FVT-UserManagement-Modify-001")]
        //Summary
        //Modify user invalid
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

        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Modify-001"), CreateTime("2013-01-08"), Owner("Nancy")]
        //Add user failed with redline when click save button directly.
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserManagementAddInvalid), "TC-J1-FVT-UserManagement-Add-001-1")]
        public void ModifyUserBlank(UserSettingsData testData)
        {

            UserSettings.FocusOnUser(testData.InputData.OriginalName);
            TimeManager.ShortPause();
            UserSettings.ClickModifyButton();
            TimeManager.ShortPause();
            UserSettings.FillInUser(testData.InputData);
            UserSettings.ClickSaveButton();

            Assert.IsTrue(UserSettings.IsUserNameInvalid());
            Assert.IsTrue(UserSettings.IsUserNameInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(UserSettings.IsRealNameInvalid());
            Assert.IsTrue(UserSettings.IsRealNameInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(UserSettings.IsTelephoneInvalid());
            Assert.IsTrue(UserSettings.IsTelephoneInvalidMsgCorrect(testData.ExpectedData));
            //Assert.IsTrue(UserSettings.IsEmailInvalid());
            //Assert.IsTrue(UserSettings.IsEmailInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(UserSettings.IsUserTypeInvalid());
            Assert.IsTrue(UserSettings.IsTypeInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsFalse(UserSettings.IsCommentsInvalid(testData.ExpectedData));

        }

        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Modify-001"), CreateTime("2013-01-08"), Owner("Nancy")]
        //Add user failed when input invalid chars to each field, redline display.
        [IllegalInputValidation(typeof(UserSettingsData[]))]
        public void ModifyUserInvalid(UserSettingsData testData)
        {

            UserSettings.FocusOnUser(testData.InputData.OriginalName);
            UserSettings.ClickModifyButton();
            TimeManager.ShortPause();
            UserSettings.FillInUser(testData.InputData);
            UserSettings.ClickSaveButton();

            Assert.IsTrue(UserSettings.IsUserNameInvalid());
            Assert.IsTrue(UserSettings.IsUserNameInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(UserSettings.IsRealNameInvalid());
            Assert.IsTrue(UserSettings.IsRealNameInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(UserSettings.IsTelephoneInvalid());
            Assert.IsTrue(UserSettings.IsTelephoneInvalidMsgCorrect(testData.ExpectedData));
            //Assert.IsTrue(UserSettings.IsEmailInvalid());
            //Assert.IsTrue(UserSettings.IsEmailInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(UserSettings.IsUserTypeInvalid());
            Assert.IsTrue(UserSettings.IsTypeInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsFalse(UserSettings.IsCommentsInvalid(testData.ExpectedData));

        }

        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Modify-101"), CreateTime("2013-01-08"), Owner("Nancy")]
        //Add user valid and canceled.
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserManagementAddValid), "TC-J1-FVT-UserManagement-Add-101-2")]
        public void AddUserCancel(UserSettingsData testData)
        {

            UserSettings.FocusOnUser(testData.InputData.OriginalName);
            UserSettings.ClickModifyButton();
            TimeManager.ShortPause();
            UserSettings.FillInUser(testData.InputData);
            UserSettings.ClickCancelButton();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Modify-101"), CreateTime("2013-01-08"), Owner("Nancy")]
        //Modify user accountid="Nancy_EngineerBlankComments" has already exist in user list.
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserManagementAddValid), "TC-J1-FVT-UserManagement-Add-101-2")]
        public void AddDuplicatedUser(UserSettingsData testData)
        {

            UserSettings.FocusOnUser(testData.InputData.OriginalName);
            UserSettings.ClickModifyButton();
            TimeManager.ShortPause();
            UserSettings.FillInUser(testData.InputData);
            UserSettings.ClickSaveButton();

            string msgText = UserSettings.GetMessageText();
            Assert.IsTrue(msgText.Contains("用户名重复"));
            TimeManager.ShortPause();
            UserSettings.ConfirmMagBox();
        }
    }
}