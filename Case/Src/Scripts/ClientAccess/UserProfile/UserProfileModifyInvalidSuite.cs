using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.ScriptCommon.Library.Functions;
using NUnit.Framework;
using Mento.Framework.Script;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.Library;
using Mento.Framework.Script;
using Mento.TestApi.TestData;
using Mento.TestApi.TestData.Attribute;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.ClientAccess.UserProfile
{
    [TestFixture]
    [Owner("Nancy")]
    [CreateTime("2014-10-9")]
    public class UserProfileModifyInvalidSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-UserProfile-Modify-001-1")]
        [MultipleTestDataSource(typeof(UserProfileData[]), typeof(UserProfileModifyInvalidSuite), "TC-J1-FVT-UserProfile-Modify-001-1")]
        public void ModifyUserProfileFailedWhenCancel(UserProfileData input)
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
            //Cancel modification by cancel button.
            UserProfile.ClickCancelButton();
            TimeManager.LongPause();

            //Verify the modify fields didn't save successfully.
            Assert.AreEqual(input.ExpectedData.RealName, UserProfile.GetRealNameValue());
            Assert.AreEqual(input.ExpectedData.Email, UserProfile.GetEmailValue());
            Assert.AreEqual(input.ExpectedData.Telephone, UserProfile.GetTelephoneValue());
            Assert.AreEqual(input.ExpectedData.Comments, UserProfile.GetCommentValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-UserProfile-Modify-001-2")]
        [MultipleTestDataSource(typeof(UserProfileData[]), typeof(UserProfileModifyInvalidSuite), "TC-J1-FVT-UserProfile-Modify-001-2")]
        public void ModifyUserProfileFailedWhenClose(UserProfileData input)
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
            //Cancel modification by close button.
            UserProfile.ClickCloseButton();
            TimeManager.LongPause();

            //Verify the modify fields didn't save successfully.
            Assert.AreEqual(input.ExpectedData.RealName, UserProfile.GetRealNameValue());
            Assert.AreEqual(input.ExpectedData.Email, UserProfile.GetEmailValue());
            Assert.AreEqual(input.ExpectedData.Telephone, UserProfile.GetTelephoneValue());
            Assert.AreEqual(input.ExpectedData.Comments, UserProfile.GetCommentValue());
        }
        
        [Test]
        [CaseID("TC-J1-FVT-UserProfile-Modify-001-2")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(UserProfileData[]))]
        public void ModifyIllegalUserProfile(UserProfileData input)
        {
            //Navigate to usr profile from PersonalMgtMenu.
            PersonalMgt.NavigatorToUserProfile();
            TimeManager.LongPause();
            TimeManager.LongPause();

            PersonalMgt.ClickViewUserProfile();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Modify the profile
            UserProfile.ClickModifyButton();
            TimeManager.LongPause();
            //Fillin each filed with common data.
            UserProfile.FillInRealName(input.InputData.RealName);
            UserProfile.FillInTelephone(input.InputData.Telephone);
            UserProfile.FillInEmail(input.InputData.Email);
            UserProfile.FillInComment(input.InputData.Comments);

            UserProfile.ClickSaveButton();
            TimeManager.MediumPause();

            //Verify the invalid message display correctly.
            Assert.IsFalse(UserProfile.IsCommentsInvalid());
            Assert.IsFalse(UserProfile.IsCommentsInvalid());
            Assert.IsFalse(UserProfile.IsCommentsInvalid());
            Assert.IsFalse(UserProfile.IsCommentsInvalid());
            TimeManager.MediumPause();

            Assert.IsTrue(UserProfile.IsTelephoneInvalidMsgCorrect(input.ExpectedData.Telephone));
            Assert.IsTrue(UserProfile.IsEmailInvalidMsgCorrect(input.ExpectedData.Email));
            Assert.IsTrue(UserProfile.IsRealNameInvalidMsgCorrect(input.ExpectedData.RealName));
            


        }

    }
}