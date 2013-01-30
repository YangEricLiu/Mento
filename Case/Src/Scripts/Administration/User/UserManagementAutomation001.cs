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
    public class UserManagementAutomation001 : TestSuiteBase
    {
        private UserSettings UserSettings = JazzFunction.UserSettings;

        [SetUp]
        [Owner("Nancy")]
        [CreateTime("2013-01-08")]
        [ManualCaseID("TC-J1-SmokeTest")]
        //Summary
        //Add/Modify/Delete user validation
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

        [Test]
        [CaseID("SR-J1-User-002-TC-J1-FVT-UserManagement"), CreateTime("2013-01-08"), Owner("Nancy")]
        [Priority("8")]
        //Add user valid test: maxlength, not required field blank, leading and trailing space excluded verify. 
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserManagementAutomation001), "UserManagement-Automation-001-Test1")]
        public void AddNewUser(UserSettingsData testData)
        {

            UserSettings.ClickAddUser();
            TimeManager.ShortPause();
            UserSettings.FillInUser(testData.InputData);
            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            UserSettings.FocusOnUser(testData.ExpectedData.Name);

            Assert.AreEqual(testData.ExpectedData.Name, UserSettings.GetNameValue());
            Assert.AreEqual(testData.ExpectedData.RealName, UserSettings.GetRealNameValue());
            Assert.AreEqual(testData.ExpectedData.Title, UserSettings.GetTitleValue());
            Assert.AreEqual(testData.ExpectedData.Email, UserSettings.GetEmailValue());
            Assert.AreEqual(testData.ExpectedData.AssociatedCustomer, UserSettings.GetAssociatedCustomerValue());

            //If exist compare, if not exist, continue.
            Assert.AreEqual(testData.ExpectedData.Comment, UserSettings.GetCommentValue());
            //If exist compare, if not exist, continue.
            Assert.AreEqual(testData.ExpectedData.Type, UserSettings.GetTypeValue());
            //If exist compare, if not exist, continue.
            Assert.AreEqual(testData.ExpectedData.Telephone, UserSettings.GetTelephoneValue());
        }

        [Test]
        [CaseID("SR-J1-User-002-TC-J1-FVT-UserManagement"), CreateTime("2013-01-08"), Owner("Nancy")]
        [Priority("8")]
        //Add user valid test: maxlength, not required field blank, leading and trailing space excluded verify. 
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserManagementAutomation001), "UserManagement-Automation-001-Test2")]
        public void AddUserinvalid(UserSettingsData testData)
        {

            UserSettings.ClickAddUser();
            TimeManager.ShortPause();
            UserSettings.FillInUser(testData.InputData);
            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Input invalid Name one by one. Refer to KPI Target
            UserSettings.FillInName(testData.InputData.SpecialChar[1]);
            //not input, message is this field is required.
            //Redline and float message display
            UserSettings.FillInName(testData.InputData.SpecialChar[2]);
            //Redline and float message display
            UserSettings.FillInRealName(testData.InputData.SpecialChar[2]);
            //Redline and float message display
            UserSettings.FillInTitle(testData.InputData.SpecialChar[0]);
            //Redline and float message display
            UserSettings.FillInTelephone(testData.InputData.SpecialChar[2]);
            //Redline and float message display
            UserSettings.FillInEmail(testData.InputData.SpecialChar[0]);
            //Redline and float message display
            UserSettings.FillInComment(testData.InputData.SpecialChar[0]);
            //Redline and float message display

            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            UserSettings.FocusOnUser(testData.ExpectedData.Name);
            //Save failed, Cancel button still exist.      

        }

        [Test]
        [CaseID("SR-J1-User-002-TC-J1-FVT-UserManagement"), CreateTime("2013-01-08"), Owner("Nancy")]
        [Priority("8")]
        //Modify user valid test: maxlength, not required field blank, leading and trailing space excluded verify. 
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserManagementAutomation001), "UserManagement-Automation-001-Test1")]
        public void ModifyUser(UserSettingsData testData)
        {
            
            UserSettings.FocusOnUser(testData.InputData.OriginalName);            
            UserSettings.ClickModifyButton();
            TimeManager.ShortPause();
            UserSettings.FillInUser(testData.InputData);
            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            UserSettings.FocusOnUser(testData.ExpectedData.Name);

            Assert.AreEqual(testData.ExpectedData.Name, UserSettings.GetNameValue());
            Assert.AreEqual(testData.ExpectedData.RealName, UserSettings.GetRealNameValue());
            Assert.AreEqual(testData.ExpectedData.Title, UserSettings.GetTitleValue());
            Assert.AreEqual(testData.ExpectedData.Email, UserSettings.GetEmailValue());
            Assert.AreEqual(testData.ExpectedData.AssociatedCustomer, UserSettings.GetAssociatedCustomerValue());

            //If exist compare, if not exist, continue.
            Assert.AreEqual(testData.ExpectedData.Comment, UserSettings.GetCommentValue());
            //If exist compare, if not exist, continue.
            Assert.AreEqual(testData.ExpectedData.Type, UserSettings.GetTypeValue());
            //If exist compare, if not exist, continue.
            Assert.AreEqual(testData.ExpectedData.Telephone, UserSettings.GetTelephoneValue());
        }

        [Test]
        [CaseID("SR-J1-User-002-TC-J1-FVT-UserManagement"), CreateTime("2013-01-08"), Owner("Nancy")]
        [Priority("8")]
        //Modify user valid test: maxlength, not required field blank, leading and trailing space excluded verify. 
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserManagementAutomation001), "UserManagement-Automation-001-Test2")]
        public void ModifyUserinvalid(UserSettingsData testData)
        {
            
            UserSettings.FocusOnUser(testData.InputData.OriginalName);
            UserSettings.ClickModifyButton();
            TimeManager.ShortPause();
            UserSettings.FillInUser(testData.InputData);
            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Input invalid Name one by one. Refer to KPI Target
            UserSettings.FillInName(testData.InputData.SpecialChar[1]);
            //Redline and float message display
            UserSettings.FillInName(testData.InputData.SpecialChar[2]);
            //Redline and float message display
            UserSettings.FillInRealName(testData.InputData.SpecialChar[2]);
            //Redline and float message display
            UserSettings.FillInTitle(testData.InputData.SpecialChar[0]);
            //Redline and float message display
            UserSettings.FillInTelephone(testData.InputData.SpecialChar[2]);
            //Redline and float message display
            UserSettings.FillInEmail(testData.InputData.SpecialChar[0]);
            //Redline and float message display
            UserSettings.FillInComment(testData.InputData.SpecialChar[0]);
            //Redline and float message display

            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            UserSettings.FocusOnUser(testData.ExpectedData.Name);
            //Save failed, Cancel button still exist.      

        }
        //Delete user cancel and success verify.
        [Test]
        [CaseID("SR-J1-User-002-TC-J1-FVT-UserManagement"), CreateTime("2013-01-08"), Owner("Nancy")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserManagementAutomation001), "UserManagement-Automation-001-Test1")]
        //Delete user cancel and success verify.
        public void DeleteUser(UserSettingsData testData)
        {
            UserSettings.FocusOnUser(testData.InputData.OriginalName);
            UserSettings.ClickModifyButton();
            TimeManager.ShortPause();

            UserSettings.DeleteUser();
            //JazzMessageBox.MessageBox.Close();
            //Click Close button to cancel delete user. How to verify cancel success? 
            UserSettings.DeleteUser();
            JazzMessageBox.MessageBox.Cancel();
            //Click Cancel button to cancel delete user. How to verify cancel success? 
            UserSettings.DeleteUser();
            JazzMessageBox.MessageBox.Confirm();
            //JazzMessageBox.MessageBox.Close();
            //Click Confirm button to delete user. how to verify delete success?
            //Assert.IsTrue(testData.InputData.Name(Contains"Nancy"));
        }

        [Test]
        [CaseID("SR-J1-User-002-TC-J1-FVT-UserManagement"), CreateTime("2013-01-08"), Owner("Nancy")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserManagementAutomation001), "UserManagement-Automation-001-Test3")]
        //Add a customer admin and view from every where.
        //1.View the Customer admin userID from customer configue. 
        //2.Share dashboard. This new function add new testcase or add to this exist scenario to this test case?
        public void AddUserViewAll(UserSettingsData testData)
        {
            UserSettings.ClickAddUser();
            TimeManager.ShortPause();
            UserSettings.FillInUser(testData.InputData);
            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //1.View added Customer admin user from ……
        }

        //Add a specical consultant user with multiple customer associated and login with this user.
        //1. Add consultant should select multiple customer
        //2. Login consultant should select customer from login
        //3. Go to the select consultant to view chart. Whether to add in this testcase?       
        [Test]
        //[Test1]
        [CaseID("SR-J1-User-002-TC-J1-FVT-UserManagement"), CreateTime("2013-01-08"), Owner("Nancy")]
        [MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserManagementAutomation001), "UserManagement-Automation-001-Test4")]
        public void AddUserViewAllConsultant(UserSettingsData testData)
        {
            UserSettings.ClickAddUser();
            TimeManager.ShortPause();
            UserSettings.FillInUser(testData.InputData);
            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            

            //1.View added Customer admin user from  
        }
    }
}