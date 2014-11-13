using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.ScriptCommon.Library.Functions;
using NUnit.Framework;
using Mento.Framework.Script;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.Library;
using Mento.TestApi.TestData;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.ClientAccess.UserProfile
{
    [TestFixture]
    [Owner("Nancy")]
    [CreateTime("2014-10-9")]
    public class UserProfileModifyValidSuite : TestSuiteBase
    {
        private static UserProfileDialog UserProfile = JazzFunction.UserProfileDialog;
        private static PersonalMgtMenu PersonalMgt = JazzFunction.PersonalMgtMenu;

        [SetUp]
        public void CaseSetUp()
        {
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
        }
        [Test]
        [CaseID("TC-J1-FVT-UserProfile-View-101-1")]
        [MultipleTestDataSource(typeof(UserProfileData[]), typeof(UserProfileModifyValidSuite), "TC-J1-FVT-UserProfile-View-101-1")]
        public void ViewProfile(UserProfileData input)
        {
            //Navigate to usr profile from PersonalMgtMenu.
            PersonalMgt.NavigatorToUserProfile();
            TimeManager.MediumPause();

            PersonalMgt.ClickViewUserProfile();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //View user profile
            Assert.AreEqual(input.ExpectedData.Name, UserProfile.GetNameValue());
            Assert.AreEqual(input.ExpectedData.RealName, UserProfile.GetRealNameValue());
            Assert.AreEqual(input.ExpectedData.Type, UserProfile.GetTypeValue());
            Assert.AreEqual(input.ExpectedData.Title, UserProfile.GetTitleValue());
            Assert.AreEqual(input.ExpectedData.Email, UserProfile.GetEmailValue());
            Assert.AreEqual(input.ExpectedData.Telephone, UserProfile.GetTelephoneValue());
            Assert.AreEqual(input.ExpectedData.Comments, UserProfile.GetCommentValue());

        }

        [Test]
        [CaseID("TC-J1-FVT-UserProfile-Modify-101-1")]
        [MultipleTestDataSource(typeof(UserProfileData[]), typeof(UserProfileModifyValidSuite), "TC-J1-FVT-UserProfile-Modify-101-1")]
        public void ModifyProfileToEmptyComments(UserProfileData input)
        {
            //Navigate to usr profile from PersonalMgtMenu.
            PersonalMgt.NavigatorToUserProfile();
            TimeManager.LongPause();
            TimeManager.LongPause();

            PersonalMgt.ClickViewUserProfile();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Modify the profile
            UserProfile.ClickModifyButton();
            TimeManager.LongPause();
            UserProfile.FillInUserProfile(input.InputData);
            UserProfile.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify the modify field saved successfully.
            Assert.AreEqual(input.ExpectedData.Name, UserProfile.GetNameValue());
            Assert.AreEqual(input.ExpectedData.RealName, UserProfile.GetRealNameValue());
            Assert.AreEqual(input.ExpectedData.Type, UserProfile.GetTypeValue());
            Assert.AreEqual(input.ExpectedData.Title, UserProfile.GetTitleValue());
            Assert.AreEqual(input.ExpectedData.Email, UserProfile.GetEmailValue());
            Assert.AreEqual(input.ExpectedData.Telephone, UserProfile.GetTelephoneValue());

            //Verify the comment is hidden when save with blank.
            UserProfile.IsCommentHidden();
        
        }

        [Test]
        [CaseID("TC-J1-FVT-UserProfile-Modify-101-2")]
        [MultipleTestDataSource(typeof(UserProfileData[]), typeof(UserProfileModifyValidSuite), "TC-J1-FVT-UserProfile-Modify-101-2")]
        public void ProfileUserIDAndRoleTypeDisable(UserProfileData input)
        {
            //Navigate to usr profile from PersonalMgtMenu.
            PersonalMgt.NavigatorToUserProfile();
            TimeManager.LongPause();
            TimeManager.LongPause();

            PersonalMgt.ClickViewUserProfile();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Modify the profile
            UserProfile.ClickModifyButton();
            TimeManager.LongPause();
            Assert.IsFalse(UserProfile.IsRoleTypeComboboxEnable());
            Assert.IsFalse(UserProfile.IsNameTextFieldEnable());

        }
        [Test]
        [CaseID("TC-J1-FVT-UserProfile-Modify-101-3")]
        [MultipleTestDataSource(typeof(UserProfileData[]), typeof(UserProfileModifyValidSuite), "TC-J1-FVT-UserProfile-Modify-101-3")]
        public void ModifyValidInput(UserProfileData input)
        {
            //Navigate to usr profile from PersonalMgtMenu.
            PersonalMgt.NavigatorToUserProfile();
            TimeManager.LongPause();
            TimeManager.LongPause();

            PersonalMgt.ClickViewUserProfile();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Modify the profile
            UserProfile.ClickModifyButton();
            TimeManager.LongPause();
            //Fillin each filed with common data.
            UserProfile.FillInRealName(input.InputData.RealName);
            TimeManager.MediumPause();
            UserProfile.FillInTelephone(input.InputData.Telephone);
            TimeManager.MediumPause();
            UserProfile.FillInEmail(input.InputData.Email);
            TimeManager.MediumPause();
            UserProfile.FillInComment(input.InputData.Comments);
            TimeManager.MediumPause();

            UserProfile.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify the modify field saved successfully.
            Assert.AreEqual(input.ExpectedData.RealName, UserProfile.GetRealNameValue());
            Assert.AreEqual(input.ExpectedData.Email, UserProfile.GetEmailValue());
            Assert.AreEqual(input.ExpectedData.Telephone, UserProfile.GetTelephoneValue());
            Assert.AreEqual(input.ExpectedData.Comments, UserProfile.GetCommentValue());

        }

    }
}