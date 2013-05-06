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
    public class ModifyUserPasswordSuite : TestSuiteBase
    {
        public UserProfile UserProfile = JazzFunction.UserProfile;

        [SetUp]
        [Owner("Nancy")]
        [CreateTime("2013-01-23")]
        [ManualCaseID("TC-J1-SmokeTest-035")]
        public void CaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UserManagement);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-035-1"), CreateTime("2013-01-15"), Owner("Nancy")]
        [MultipleTestDataSource(typeof(UserPasswordData[]), typeof(ModifyUserPasswordSuite), "TC-J1-SmokeTest-035-4")]
        public void ModifyUserPassword(UserPasswordData testData)
        {

            UserProfile.NavigatorToUserProfile();
            TimeManager.MediumPause();
            UserProfile.ModifyUserPassword();
            //JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //UserProfile.UserPasswordDialog.FillInUserPassword(testData.InputData);

            UserProfile.UserPasswordDialog.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
        }
    }
}