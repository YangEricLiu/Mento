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
    [ManualCaseID("TC-J1-FVT-UserManagement-Modify-101")]
    public class UserModifyValidSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-UserManagement-Modify-101-1")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserModifyValidSuite), "TC-J1-FVT-UserManagement-Modify-101-1")]
        public void ModifyValidUser(UserSettingsData input)
        {
            string userName = "UserForCheckAll";
            Assert.IsTrue(UserSettings.FocusOnUser(userName));
            UserSettings.ClickModifyButton();
            TimeManager.ShortPause();
            UserSettings.FillInRealName(input.InputData.RealName);
            UserSettings.FillInEmail(input.InputData.Email);
            UserSettings.FillInTelephone(input.InputData.Telephone);
            //UserSettings.FillInType(input.InputData.Type);
            //UserSettings.FillInTitle(input.InputData.Title);
            UserSettings.FillInComment(input.InputData.Comments);
            TimeManager.ShortPause();
            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            Assert.IsTrue(UserSettings.IsUserOnList(userName));
            //Verify
            Assert.AreEqual(UserSettings.GetCommonNameValue(),userName);
            Assert.AreEqual(UserSettings.GetRealNameValue(), input.ExpectedData.RealName);
            //Assert.AreEqual(UserSettings.GetTitleValue(), input.ExpectedData.Title);
            //Assert.AreEqual(UserSettings.GetTypeValue(), input.ExpectedData.Type);
            Assert.AreEqual(UserSettings.GetEmailValue(),input.ExpectedData.Email);
            Assert.AreEqual(UserSettings.GetTelephoneValue(), input.ExpectedData.Telephone);
            Assert.AreEqual(UserSettings.GetCommentValue(), input.ExpectedData.Comments);
        }

        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Modify-101-2")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserModifyValidSuite), "TC-J1-FVT-UserManagement-Modify-101-2")]
        public void EmptyItemNotDisplay(UserSettingsData input)
        {
            //focus a user
            UserSettings.FocusOnUser(input.InputData.CommonName);
            UserSettings.ClickModifyButton();
            TimeManager.ShortPause();

            UserSettings.FillInRealName(input.InputData.RealName);
            UserSettings.FillInEmail(input.InputData.Email);
            UserSettings.FillInTelephone(input.InputData.Telephone);
            UserSettings.FillInType(input.InputData.Type);
            UserSettings.FillInTitle(input.InputData.Title);
            UserSettings.FillInComment(input.InputData.Comments);
            TimeManager.ShortPause();
            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            //Verify
            Assert.IsTrue(UserSettings.FocusOnUser(input.InputData.CommonName));
            Assert.AreEqual(UserSettings.GetCommonNameValue(), input.ExpectedData.CommonName);
            Assert.AreEqual(UserSettings.GetRealNameValue(), input.ExpectedData.RealName);
            Assert.AreEqual(UserSettings.GetTitleValue(), input.ExpectedData.Title);
            Assert.AreEqual(UserSettings.GetTypeValue(), input.ExpectedData.Type);
            Assert.AreEqual(UserSettings.GetTelephoneValue(), input.ExpectedData.Telephone);
            Assert.IsTrue(UserSettings.IsUserCommentHidden());
            
        }
        [Test]
        [CaseID("TC-J1-FVT-UserManagement-Modify-101-3")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserModifyValidSuite), "TC-J1-FVT-UserManagement-Modify-101-3")]
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
            //@@ Assert.IsTrue(UserSettings.AreTitleDisplayAllItem());
        }
    }
}
