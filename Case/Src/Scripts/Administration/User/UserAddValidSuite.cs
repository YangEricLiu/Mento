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
    [Owner("Greenie")]
    [CreateTime("2013-07-31")]
    [ManualCaseID("TC-J1-FVT-UserManagement-Add-101")]
    public class UserAddValidSuite : TestSuiteBase
    {
        private UserSettings UserSettings = JazzFunction.UserSettings;

        [SetUp]
        public void CaseSetUp()
        {
            UserSettings.NavigatorToUserSetting();
            TimeManager.LongPause();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Add-101-1")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserAddValidSuite), "TC-J1-FVT-UserManagement-Add-101-1")]
        public void AddValidUser(UserSettingsData input)
        {
            //Click "+用户"
            UserSettings.ClickAddUser();
            TimeManager.ShortPause();
            UserSettings.FillInAddUser(input.InputData);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.AreEqual(input.ExpectedData.AccountID,UserSettings.GetNameValue());
            Assert.AreEqual(input.ExpectedData.RealName,UserSettings.GetRealNameValue());
            Assert.AreEqual(input.ExpectedData.Type,UserSettings.GetTypeValue());
            Assert.AreEqual(input.ExpectedData.Email,UserSettings.GetEmailValue());
            Assert.AreEqual(input.ExpectedData.Telephone,UserSettings.GetTelephoneValue());
            Assert.AreEqual(input.ExpectedData.Comments,UserSettings.GetCommentValue());
            Assert.AreEqual(input.ExpectedData.Title,UserSettings.GetTitleValue());
     
            Assert.IsTrue(UserSettings.IsUserOnList(input.ExpectedData.AccountID));
          
        }

        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Add-101-2")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserAddValidSuite), "TC-J1-FVT-UserManagement-Add-101-2")]
        public void EmptyItemNotDisplay(UserSettingsData input)
        {
            //Click "+用户"
            UserSettings.ClickAddUser();
            TimeManager.ShortPause();
            UserSettings.FillInAddUser(input.InputData);
            TimeManager.MediumPause();
            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            Assert.IsTrue(UserSettings.IsUserCommentHidden());
            Assert.IsTrue(UserSettings.IsUserOnList(input.InputData.AccountID));
            
        }
        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Add-101-3")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserAddValidSuite), "TC-J1-FVT-UserManagement-Add-101-3")]
        public void TitleDisplayItem(UserSettingsData input)
        {
            int i = 0;
            //Click "+用户"
            UserSettings.ClickAddUser();
            TimeManager.ShortPause();
            while (i < input.InputData.titleList.Length)
            {
                Assert.IsTrue(UserSettings.FillInTitle(input.InputData.titleList[i]));
                i++;
            }
            //Assert.IsTrue(UserSettings.AreTitleDisplayAllItem());
        }
        
    }
}
