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
    [ManualCaseID("TC-J1-FVT-UserManagement-Modify-001")]
    public class UserModifyInvalidSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-UserManagement-Modify-001-1")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserModifyInvalidSuite), "TC-J1-FVT-UserManagement-Modify-001-1")]
        public void EmptyField(UserSettingsData input)
        {
            //focus a user
            UserSettings.FocusOnUser(input.InputData.CommonName);
            UserSettings.ClickModifyButton();
            TimeManager.ShortPause();
            Assert.IsFalse(UserSettings.IsNameFieldEnable(input.InputData.CommonName));
            UserSettings.FillInRealName(input.InputData.RealName);
            UserSettings.FillInEmail(input.InputData.Email);
            UserSettings.FillInTelephone(input.InputData.Telephone);
            //UserSettings.FillInType(input.InputData.Type);
            //UserSettings.FillInTitle(input.InputData.Title);
            TimeManager.ShortPause();
            UserSettings.ClickSaveButton();
            TimeManager.ShortPause();
         
            //Verify
            Assert.IsTrue(UserSettings.IsRealNameInvalid());
            Assert.IsTrue(UserSettings.IsRealNameInvalidMsgCorrect(input.ExpectedData));

            Assert.IsTrue(UserSettings.IsEmailInvalid(input.ExpectedData));
            Assert.IsTrue(UserSettings.IsEmailInvalidMsgCorrect(input.ExpectedData));

            Assert.IsTrue(UserSettings.IsTelephoneInvalid());
            Assert.IsTrue(UserSettings.IsTelephoneInvalidMsgCorrect(input.ExpectedData));
            /*
            Assert.IsTrue(UserSettings.IsUserTypeInvalid());
            Assert.IsTrue(UserSettings.IsTypeInvalidMsgCorrect(input.ExpectedData));

            Assert.IsTrue(UserSettings.IsUserTitleInvalid());
            Assert.IsTrue(UserSettings.IsTitleInvalidMsgCorrect(input.ExpectedData));
             */
        }

        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Modify-001-2")]
        [IllegalInputValidation(typeof(UserSettingsData[]))]
        public void ModifyInvalidInput(UserSettingsData input)
        {
            //focus a user
            string userName = "UserForCheckAll";
            UserSettings.FocusOnUser(userName);
            UserSettings.ClickModifyButton();
            TimeManager.ShortPause();

            Assert.IsFalse(UserSettings.IsNameFieldEnable(userName));
            UserSettings.FillInRealName(input.InputData.RealName);
            UserSettings.FillInEmail(input.InputData.Email);
            UserSettings.FillInTelephone(input.InputData.Telephone);
            //UserSettings.FillInType(input.InputData.Type);
            //UserSettings.FillInTitle(input.InputData.Title);

            TimeManager.ShortPause();
            UserSettings.ClickSaveButton();
            TimeManager.ShortPause();

            Assert.IsFalse(UserSettings.IsUserOnList(input.InputData.CommonName));
            //Verify

            Assert.IsTrue(UserSettings.IsRealNameInvalid());
            Assert.IsTrue(UserSettings.IsRealNameInvalidMsgCorrect(input.ExpectedData));

            Assert.IsTrue(UserSettings.IsEmailInvalid(input.ExpectedData));
            Assert.IsTrue(UserSettings.IsEmailInvalidMsgCorrect(input.ExpectedData));

            Assert.IsTrue(UserSettings.IsTelephoneInvalid());
            Assert.IsTrue(UserSettings.IsTelephoneInvalidMsgCorrect(input.ExpectedData));
            /*
            UserSettings.IsUserTypeInvalid();
            UserSettings.IsTypeInvalidMsgCorrect(input.ExpectedData);

            UserSettings.IsUserTitleInvalid();
            UserSettings.IsTitleInvalidMsgCorrect(input.ExpectedData);
            */
        }
        
        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Modify-001-3")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserModifyInvalidSuite), "TC-J1-FVT-UserManagement-Modify-001-3")]
        public void ModifyUserCancel(UserSettingsData input)
        {
            //focus a user
            UserSettings.FocusOnUser(input.InputData.CommonName);
            UserSettings.ClickModifyButton();
            TimeManager.ShortPause();

            Assert.IsFalse(UserSettings.IsNameFieldEnable(input.InputData.CommonName));
            UserSettings.FillInRealName(input.InputData.RealName);
            UserSettings.FillInEmail(input.InputData.Email);
            UserSettings.FillInTelephone(input.InputData.Telephone);
            UserSettings.FillInType(input.InputData.Type);
            UserSettings.FillInTitle(input.InputData.Title);

            TimeManager.ShortPause();
            UserSettings.ClickCancelButton();
            TimeManager.LongPause();

            Assert.IsTrue(UserSettings.FocusOnUser(input.InputData.CommonName));
            Assert.AreEqual(UserSettings.GetCommonNameValue(),input.ExpectedData.CommonName);
            Assert.AreEqual(UserSettings.GetRealNameValue(),input.ExpectedData.RealName);
            Assert.AreEqual(UserSettings.GetTitleValue(), input.ExpectedData.Title);
            Assert.AreEqual(UserSettings.GetTypeValue(), input.ExpectedData.Type);
            Assert.AreEqual(UserSettings.GetTelephoneValue(), input.ExpectedData.Telephone);
        }
        
        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Modify-001-4")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserModifyInvalidSuite), "TC-J1-FVT-UserManagement-Modify-001-4")]
        public void ModifyUserNameFailed(UserSettingsData input)
        {
            UserSettings.FocusOnUser(input.InputData.CommonName);
            UserSettings.ClickModifyButton();
            TimeManager.ShortPause();
            Assert.IsFalse(UserSettings.IsNameFieldEnable(input.InputData.CommonName));
        }
    }
}
