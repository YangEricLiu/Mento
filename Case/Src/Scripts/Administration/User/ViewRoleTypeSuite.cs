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
    [ManualCaseID("TC-J1-FVT-UserManagement-ViewRoleType")]
    public class ViewRoleTypeSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-UserManagement-SendInitialPasswordLink-1")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(ViewRoleTypeSuite), "TC-J1-FVT-UserManagement-ViewRoleType-1")]
        public void ViewRoleType(UserSettingsData input)
        {
            int i = 0;
            //Click "+用户"
            UserSettings.ClickAddUser();
            TimeManager.ShortPause();
            while(i<input.InputData.TypeList.Length)
            {
                UserSettings.FillInType(input.InputData.TypeList[i]);
                //Assert.IsTrue(UserSettings.);
                i++;
            }
            
        }
        
        [Test]
        [CaseID("TC-J1-FVT-UserManagement-SendInitialPasswordLink-2")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(ViewRoleTypeSuite), "TC-J1-FVT-UserManagement-ViewRoleType-2")]
        public void ModifyAndViewRoleType(UserSettingsData input)
        {
            //focus a user
            UserSettings.FocusOnUser(input.InputData.CommonName);
            Assert.IsFalse(UserSettings.IsEmailSendButtonDispalyed());
        }

        [Test]
        [CaseID("TC-J1-FVT-UserManagement-SendInitialPasswordLink-3")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(ViewRoleTypeSuite), "TC-J1-FVT-UserManagement-ViewRoleType-3")]
        public void ModifyRoleTypeFunctionAndViewUser(UserSettingsData input)
        {
            //focus a user
            UserSettings.FocusOnUser(input.InputData.CommonName);
            Assert.IsFalse(UserSettings.IsEmailSendButtonDispalyed());
        }

    }
}
