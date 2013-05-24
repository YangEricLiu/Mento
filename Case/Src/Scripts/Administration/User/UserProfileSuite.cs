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
    [Owner("Nancy")]
    [CreateTime("2013-01-15")]
    [ManualCaseID("TC-J1-SmokeTest-035")]
    public class UserProfileSuite : TestSuiteBase
    {
        public UserProfile UserProfile = JazzFunction.UserProfile;
        public UserSettings UserSettings = JazzFunction.UserSettings;

        [SetUp]
        public void CaseSetUp()
        {
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UserManagement);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-035-1"), CreateTime("2013-01-15"), Owner("Nancy")]
        [Priority("9")]
        [MultipleTestDataSource(typeof(UserProfileData[]), typeof(UserProfileSuite), "TC-J1-SmokeTest-035-1")]
        public void ViewUserProfile(UserProfileData testData)
        {

            UserProfile.NavigatorToUserProfile();
            TimeManager.MediumPause();
            UserProfile.ClickViewUserProfile();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Assert.AreEqual(testData.ExpectedData.Name, UserProfile.UserProfileDialog.GetNameValue());
            //Assert.AreEqual(testData.ExpectedData.RealName, UserProfile.UserProfileDialog.GetRealNameValue());
            //Assert.AreEqual(testData.ExpectedData.Title, UserProfile.UserProfileDialog.GetTitleValue());
            //Assert.AreEqual(testData.ExpectedData.Telephone, UserProfile.UserProfileDialog.GetTelephoneValue());
            //Assert.AreEqual(testData.ExpectedData.Email, UserProfile.UserProfileDialog.GetEmailValue());
            //Assert.AreEqual(testData.ExpectedData.Comment, UserProfile.UserProfileDialog.GetCommentValue());
            Assert.AreEqual(testData.ExpectedData.Type, UserProfile.UserProfileDialog.GetTypeValue());
            Assert.AreEqual(testData.ExpectedData.AssociatedCustomer, UserProfile.UserProfileDialog.GetAssociatedCustomerValue());

            UserProfile.UserProfileDialog.Close();
            TimeManager.ShortPause();
        }

        /*[Test]
        [CaseID("TC-J1-SmokeTest-035-2"), CreateTime("2013-01-15"), Owner("Nancy")]
        [MultipleTestDataSource(typeof(UserProfileData[]), typeof(UserProfileSuite), "TC-J1-SmokeTest-035-2")]
        public void ModifyUser(UserSettingsData testData)
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UserManagement);
            string modifyUserA = "Nancy_PlatformAdminUser";
            UserSettings.FocusOnUser(modifyUserA);

            UserSettings.ClickModifyButton();
            TimeManager.ShortPause();

            UserSettings.FillInName(testData.InputData.Name);
            UserSettings.FillInRealName(testData.InputData.RealName);
            UserSettings.FillInType(testData.InputData.Type);
            UserSettings.FillInAssociatedCustomer(testData.InputData.AssociatedCustomer); 
            UserSettings.FillInTitle(testData.InputData.Title);
            UserSettings.FillInTelephone(testData.InputData. Telephone);
            UserSettings.FillInEmail(testData.InputData.Email);
            UserSettings.FillInComment(testData.InputData.Comment);

            UserSettings.ClickSaveButton();

            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            UserProfile.NavigatorToUserProfile();
            TimeManager.MediumPause();
            UserProfile.ClickViewUserProfile();
            TimeManager.ShortPause();

            Assert.AreEqual(testData.ExpectedData.AssociatedCustomer, UserProfile.UserProfileDialog.GetAssociatedCustomerValue());
            Assert.AreEqual(testData.InputData.Comment, UserProfile.UserProfileDialog.GetCommentValue());
        }*/

        [Test]
        [CaseID("TC-J1-SmokeTest-035-3"), CreateTime("2013-01-15"), Owner("Nancy")]
        [MultipleTestDataSource(typeof(UserProfileData[]), typeof(UserProfileSuite), "TC-J1-SmokeTest-035-3")]
        public void ModifyUserProfile(UserProfileData testData)
        {
            UserProfile.NavigatorToUserProfile();
            TimeManager.MediumPause();
            UserProfile.ClickViewUserProfile();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            UserProfile.UserProfileDialog.ClickModifyButton();
            TimeManager.ShortPause();

            UserProfile.UserProfileDialog.FillInRealName(testData.InputData.RealName);
            UserProfile.UserProfileDialog.FillInTitle(testData.InputData.Title);
            UserProfile.UserProfileDialog.FillInTelephone(testData.InputData.Telephone);
            UserProfile.UserProfileDialog.FillInEmail(testData.InputData.Email);
            UserProfile.UserProfileDialog.FillInComment(testData.InputData.Comment);

            UserProfile.UserProfileDialog.ClickSaveButton();

            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.AreEqual(testData.ExpectedData.AssociatedCustomer, UserProfile.UserProfileDialog.GetAssociatedCustomerValue());
            Assert.AreEqual(testData.InputData.RealName, UserProfile.UserProfileDialog.GetRealNameValue());
            Assert.AreEqual(testData.InputData.Title, UserProfile.UserProfileDialog.GetTitleValue());
            Assert.AreEqual(testData.InputData.Telephone, UserProfile.UserProfileDialog.GetTelephoneValue());
            Assert.AreEqual(testData.InputData.Email, UserProfile.UserProfileDialog.GetEmailValue());
            Assert.AreEqual(testData.InputData.Comment, UserProfile.UserProfileDialog.GetCommentValue());
            Assert.AreEqual(testData.ExpectedData.Type, UserProfile.UserProfileDialog.GetTypeValue());
            Assert.AreEqual(testData.ExpectedData.AssociatedCustomer, UserProfile.UserProfileDialog.GetAssociatedCustomerValue());
        }
    }
}
