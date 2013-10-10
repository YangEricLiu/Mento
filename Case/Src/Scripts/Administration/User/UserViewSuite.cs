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
    [ManualCaseID("TC-J1-FVT-UserManagement-View-101")]
    public class UserViewSuite : TestSuiteBase
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
            //JazzFunction.TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserManagement-View-101-1")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserDeleteSuite), "TC-J1-FVT-UserManagement-View-101-1")]
        public void ViewUser(UserSettingsData input)
        {
            //(1) All users related to this specific service provider are displayed.

            //(2) Users of other service provider are NOT displayed in the list.
            //Assert.IsFalse(UserSettings.IsUserOnList("PlatfromAdmin"));

            //(3) Built-in platform administrator is NOT visiable in the list as well.
            Assert.IsFalse(UserSettings.IsUserOnList("PlatfromAdmin"));
        }
    }
}
