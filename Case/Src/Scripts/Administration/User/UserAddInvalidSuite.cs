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
    [CreateTime("2013-07-31")]
    [ManualCaseID("TC-J1-FVT-UserManagement-Add-001")]
    public class UserAddInvalidSuite : TestSuiteBase
    {
        private UserSettings UserSettings = JazzFunction.UserSettings;

        [SetUp]
        public void CaseSetUp()
        {
            UserSettings.NavigatorToUserSetting();
        }

        [TearDown]
        public void CaseTearDown()
        {
            
            JazzFunction.TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Add-001-1")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserAddInvalidSuite), "TC-J1-FVT-UserManagement-Add-001-1")]
        public void EmptyField(UserSettingsData input)
        {
            //Click "+用户"
            UserSettings.ClickAddUser();
            TimeManager.ShortPause();
            UserSettings.ClickSaveButton();
            TimeManager.ShortPause();
            //Verify
            Assert.IsTrue(UserSettings.IsCommonNameInvalid());
            Assert.IsTrue(UserSettings.IsCommonNameInvalidMsgCorrect(input.ExpectedData));

            Assert.IsTrue(UserSettings.IsRealNameInvalid());
            Assert.IsTrue(UserSettings.IsRealNameInvalidMsgCorrect(input.ExpectedData));

            Assert.IsTrue(UserSettings.IsEmailInvalid(input.ExpectedData));
            Assert.IsTrue(UserSettings.IsEmailInvalidMsgCorrect(input.ExpectedData));

            Assert.IsTrue(UserSettings.IsTelephoneInvalid());
            Assert.IsTrue(UserSettings.IsTelephoneInvalidMsgCorrect(input.ExpectedData));

            Assert.IsTrue(UserSettings.IsUserTypeInvalid());
            Assert.IsTrue(UserSettings.IsTypeInvalidMsgCorrect(input.ExpectedData));

            Assert.IsTrue(UserSettings.IsUserTitleInvalid());
            Assert.IsTrue(UserSettings.IsTitleInvalidMsgCorrect(input.ExpectedData));
        }

        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Add-001-2")]
        [IllegalInputValidation(typeof(UserSettingsData[]))]
        public void AddInvalidInput(UserSettingsData input)
        {
            //Click "+用户"
            UserSettings.ClickAddUser();
            TimeManager.ShortPause();
            UserSettings.FillInAddUser(input.InputData);
            TimeManager.MediumPause();
            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.IsFalse(UserSettings.IsUserOnList(input.InputData.CommonName));
            //Verify

            
            Assert.IsTrue(UserSettings.IsCommonNameInvalid());
            Assert.IsTrue(UserSettings.IsCommonNameInvalidMsgCorrect(input.ExpectedData));

            Assert.IsTrue(UserSettings.IsRealNameInvalid());
            Assert.IsTrue(UserSettings.IsRealNameInvalidMsgCorrect(input.ExpectedData));

            Assert.IsTrue(UserSettings.IsEmailInvalid(input.ExpectedData));
            Assert.IsTrue(UserSettings.IsEmailInvalidMsgCorrect(input.ExpectedData));
            //Assert.AreEqual("www", UserSettings.EmailInvalidMsg());

            Assert.IsTrue(UserSettings.IsTelephoneInvalid());
            Assert.IsTrue(UserSettings.IsTelephoneInvalidMsgCorrect(input.ExpectedData));

            Assert.IsFalse(UserSettings.IsCommentsInvalid(input.ExpectedData));
            /*
            UserSettings.IsUserTypeInvalid();
            UserSettings.IsTypeInvalidMsgCorrect(input.ExpectedData);

            UserSettings.IsUserTitleInvalid();
            UserSettings.IsTitleInvalidMsgCorrect(input.ExpectedData);
            */
        }
        
        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Add-001-3")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserAddInvalidSuite), "TC-J1-FVT-UserManagement-Add-001-3")]
        public void AddUserCancel(UserSettingsData input)
        {
            //Click "+用户"
            UserSettings.ClickAddUser();
            TimeManager.ShortPause();
            UserSettings.FillInAddUser(input.InputData);
            TimeManager.MediumPause();
            UserSettings.ClickCancelButton();
            TimeManager.ShortPause();

            Assert.IsFalse(UserSettings.IsUserOnList(input.InputData.CommonName));
        }
        
        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Add-001-4")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserAddInvalidSuite), "TC-J1-FVT-UserManagement-Add-001-4")]
        public void AddUserAlreadyExist(UserSettingsData input)
        {
            //Click "+用户"
            UserSettings.ClickAddUser();
            TimeManager.ShortPause();
            UserSettings.FillInAddUser(input.InputData);
            TimeManager.MediumPause();
            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            
            //Verify
            UserSettings.IsCommonNameInvalid();
            UserSettings.IsCommonNameInvalidMsgCorrect(input.ExpectedData);
        }
    }
}
