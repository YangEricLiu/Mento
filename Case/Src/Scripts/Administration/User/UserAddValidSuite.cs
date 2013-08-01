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
            TimeManager.MediumPause();
            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.IsTrue(UserSettings.IsUserOnList(input.InputData.CommonName));
          
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
            Assert.IsTrue(UserSettings.IsUserOnList(input.InputData.CommonName));
            
        }
        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Add-101-3")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserAddValidSuite), "TC-J1-FVT-UserManagement-Add-101-3")]
        public void TitleDisplayItem(UserSettingsData input)
        {
            int i = 0;
            string[] titleList = { "能源工程顾问","技术人员","客户管理员","平台管理员","能源经理","能源工程师","部门经理","管理层","业务人员","销售人员" };
            //Click "+用户"
            UserSettings.ClickAddUser();
            TimeManager.ShortPause();
            while (i < titleList.Length)
            {
                Assert.IsTrue(UserSettings.FillInTitle(titleList[i]));
                i++;
            }
            Assert.IsTrue(UserSettings.AreTitleDisplayAllItem());
        }
        
    }
}
