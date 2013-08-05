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
    [ManualCaseID("TC-J1-FVT-UserManagement-Delete")]
    public class UserDeleteSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-UserManagement-Delete-1")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserDeleteSuite), "TC-J1-FVT-UserManagement-Delete-1")]
        public void DeleteUserSuccess(UserSettingsData input)
        {
            //focus a user
            UserSettings.FocusOnUser(input.InputData.CommonName);
            UserSettings.DeleteUser();
            Assert.AreEqual(JazzMessageBox.MessageBox.GetMessage(),input.ExpectedData.Message);
            JazzMessageBox.MessageBox.Confirm();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            Assert.IsFalse(UserSettings.IsUserOnList(input.InputData.CommonName));
        }
        
        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Delete-2")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserDeleteSuite), "TC-J1-FVT-UserManagement-Delete-2")]
        public void UserDeletehimselfFailed(UserSettingsData input)
        {
            //focus a user
            UserSettings.FocusOnUser(input.InputData.CommonName);
            Assert.IsFalse(UserSettings.IsDeleteButtonDisplay());
        }
        
        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Delete-3")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserDeleteSuite), "TC-J1-FVT-UserManagement-Delete-3")]
        public void DeleteBuildinUserSuccess(UserSettingsData input)
        {
            //focus a user
            UserSettings.FocusOnUser(input.InputData.CommonName);
            UserSettings.DeleteUser();
            Assert.AreEqual(JazzMessageBox.MessageBox.GetMessage(), input.ExpectedData.Message);
            JazzMessageBox.MessageBox.Confirm();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            Assert.IsFalse(UserSettings.IsUserOnList(input.InputData.CommonName));

        }
    }
}
