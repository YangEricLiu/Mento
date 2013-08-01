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
    public class UserManagementModifyValid : TestSuiteBase
    {
        private UserSettings UserSettings = JazzFunction.UserSettings;

        [SetUp]
        [Owner("Nancy")]
        [CreateTime("2013-01-08")]
        [ManualCaseID("TC-J1-FVT-UserManagement-Modify-001")]
        //Summary
        //Modify user valid and saved.
        //Use Data
        public void CaseSetUp()
        {
            UserSettings.NavigatorToUserSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]//TC-J1-FVT-UserManagement-Modify-101-1/2/3
        [CaseID("TC-J1-FVT-UserManagement-Modify-101-1"), CreateTime("2013-01-08"), Owner("Nancy")]
        [Priority("8")]
        //Modify user valid test: maxlength, not required field blank, leading and trailing space excluded verify. 
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserManagementModifyValid), "TC-J1-FVT-UserManagement-Add-101-1")]
        public void ModifyUserValid(UserSettingsData testData)
        {

            UserSettings.FocusOnUser(testData.InputData.OriginalName);
            UserSettings.ClickModifyButton();
            TimeManager.ShortPause();
            UserSettings.FillInUser(testData.InputData);
            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            UserSettings.FocusOnUser(testData.ExpectedData.AccountID);

            //Assert.AreEqual(testData.ExpectedData.Name, UserSettings.GetNameValue());
            Assert.AreEqual(testData.ExpectedData.RealName, UserSettings.GetRealNameValue());
            //Assert.AreEqual(testData.ExpectedData.Title, UserSettings.GetTitleValue());
            Assert.AreEqual(testData.ExpectedData.Email, UserSettings.GetEmailValue());
            //Assert.AreEqual(testData.ExpectedData.AssociatedCustomer, UserSettings.GetAssociatedCustomerValue());
            Assert.AreEqual(testData.ExpectedData.Comments, UserSettings.GetCommentValue());
            //Assert.AreEqual(testData.ExpectedData.Type, UserSettings.GetTypeValue());
            Assert.AreEqual(testData.ExpectedData.Telephone, UserSettings.GetTelephoneValue());   

        }

        [Test]//TC-J1-FVT-UserManagement-Modify-101-4
        [CaseID("TC-J1-FVT-UserManagement-Modify-101-2"), CreateTime("2013-01-08"), Owner("Nancy")]
        //Add user valid test: Blank comments is valid verify. 
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserManagementModifyValid), "TC-J1-FVT-UserManagement-Add-101-2")]
        public void ModifyUserNoComments(UserSettingsData testData)
        {

            UserSettings.FocusOnUser(testData.InputData.OriginalName);
            UserSettings.ClickModifyButton();
            TimeManager.ShortPause();
            UserSettings.FillInUser(testData.InputData);
            UserSettings.ClickSaveButton();
            TimeManager.LongPause();

            UserSettings.FocusOnUser(testData.ExpectedData.AccountID);
            Assert.IsTrue(UserSettings.IsUserCommentHidden());
        }
    }
}