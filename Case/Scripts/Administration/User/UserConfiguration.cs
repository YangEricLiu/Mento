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
    public class UserConfiguration : TestSuiteBase
    {
        private UserSettings UserSettings = JazzFunction.UserSettings;

        [SetUp]
        [Owner("Nancy")]
        [CreateTime("2013-01-08")]
        [ManualCaseID("TC-J1-SmokeTest")]
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
        [CaseID("TC-J1-SmokeTest-034"), CreateTime("2013-01-08"), Owner("Nancy")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserConfiguration), "TC-J1-SmokeTest-034")]
        public void AddNewUser(UserSettingsData testData)
        {

            UserSettings.ClickAddUser();
            TimeManager.ShortPause();
            UserSettings.FillInUser(testData.InputData);
            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            UserSettings.FocusOnUser(testData.InputData.Name);
            Assert.AreEqual(testData.InputData.Name, UserSettings.GetNameValue());
            Assert.AreEqual(testData.InputData.RealName, UserSettings.GetRealNameValue());
            Assert.AreEqual(testData.InputData.Title, UserSettings.GetTitleValue());
            Assert.AreEqual(testData.InputData.Comment, UserSettings.GetCommentValue());
            Assert.AreEqual(testData.InputData.Type, UserSettings.GetTypeValue());
            Assert.AreEqual(testData.ExpectedData.AssociatedCustomer, UserSettings.GetAssociatedCustomerValue());
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-034-Modify"), CreateTime("2013-01-08"), Owner("Nancy")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserConfiguration), "TC-J1-SmokeTest-034-Modify")]
        public void ModifyUser(UserSettingsData testData)
        {
            string modifyUser = "Nancy_Consultant";
            UserSettings.FocusOnUser(modifyUser);

            UserSettings.ClickModifyButton();
            TimeManager.ShortPause();

            UserSettings.FillInName(testData.InputData.Name);
            UserSettings.FillInRealName(testData.InputData.RealName);
            UserSettings.FillInType(testData.InputData.Type);
            UserSettings.FillInTitle(testData.InputData.Title);
            UserSettings.FillInTelephone(testData.InputData. Telephone);
            UserSettings.FillInEmail(testData.InputData.Email);
            UserSettings.FillInComment(testData.InputData.Comment);

            UserSettings.ClickSaveButton();

            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            UserSettings.FocusOnUser(testData.InputData.Name);
            Assert.AreEqual(testData.ExpectedData.AssociatedCustomer, UserSettings.GetAssociatedCustomerValue());
            Assert.AreEqual(testData.InputData.Comment, UserSettings.GetCommentValue());
        }
    }
}
