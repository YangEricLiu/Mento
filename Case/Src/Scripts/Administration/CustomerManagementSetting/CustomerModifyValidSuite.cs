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
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Administration.CustomerManagementSetting
{
    [TestFixture]
    [Owner("Cathy")]
    [CreateTime("2014-09-10")]
    public class CustomerModifyValidSuite : TestSuiteBase
    {
        //private CustomerManagement CustomerManagement = JazzFunction.CustomerManagement;
        private static CustomerManagement CustomerManageSetting = JazzFunction.CustomerManagement;
        [SetUp]
        public void CaseSetUp()
        {
            TimeManager.LongPause();
            CustomerManageSetting.NavigateToCustomerSetting();
            TimeManager.MediumPause();
            TimeManager.LongPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
        }

        #region test case 1 customer modification for other fields except logo works
        [Test]
        [ManualCaseID("TC-J1-FVT-CustomerManagement-Modify-101")]
        [CaseID("TC-J1-FVT-CustomerManagement-Modify-101")]
        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerModifyValidSuite), "TC-J1-FVT-CustomerManagement-Modify-101")]
        public void ModifyValidCustomer(CustomerManagementData input)
        {

            string Name = "CustomerForModifyFieldsValid1";
            CustomerManageSetting.FocusOnCustomer(Name);
            TimeManager.LongPause();

            CustomerManageSetting.ClickUpdateCustomer();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.ShortPause();
            CustomerManageSetting.FillInName(input.InputData.CommonName);
            CustomerManageSetting.FillInCode(input.InputData.Code);
            CustomerManageSetting.FillInAddress(input.InputData.Address);
            CustomerManageSetting.FillInResponsiblePerson(input.InputData.RealName);
            CustomerManageSetting.FillInTelephone(input.InputData.Telephone);
            CustomerManageSetting.FillInEmail(input.InputData.Email);
            CustomerManageSetting.FillInComments(input.InputData.Comments);
            TimeManager.ShortPause();
            CustomerManageSetting.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Verify modify customer is exist.
            Assert.IsTrue(CustomerManageSetting.IsCustomerOnList(input.ExpectedData.CommonName));
            TimeManager.LongPause();

            //Verify modify success
            Assert.AreEqual(CustomerManageSetting.GetNameValue(), input.ExpectedData.CommonName);
            Assert.AreEqual(CustomerManageSetting.GetCodeValue(), input.ExpectedData.Code);
            Assert.AreEqual(CustomerManageSetting.GetAddressValue(), input.ExpectedData.Address);
            Assert.AreEqual(CustomerManageSetting.GetResponsiblePersonValue(), input.ExpectedData.RealName);
            Assert.AreEqual(CustomerManageSetting.GetTelephoneValue(), input.ExpectedData.Telephone);
            Assert.AreEqual(CustomerManageSetting.GetEmailValue(), input.ExpectedData.Email);
            Assert.AreEqual(CustomerManageSetting.GetCommentsValue(), input.ExpectedData.Comments);

            //Verify Save button disappear
            Assert.IsFalse(CustomerManageSetting.IsSaveButtonDisplayed());

            //Verify Customer Manager exist as before
            Assert.AreEqual(CustomerManageSetting.GetCustomerAdminTexts(), input.ExpectedData.CustomerAdmin);
        }

        #endregion

        #region test case 2 modification for not required fields are not displayed in view mode
        [Test]
        [ManualCaseID("TC-J1-FVT-CustomerManagement-Modify-102")]
        [CaseID("TC-J1-FVT-CustomerManagement-Modify-102")]
        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerModifyValidSuite), "TC-J1-FVT-CustomerManagement-Modify-102")]
        public void VerifyCommentField(CustomerManagementData input)
        {
                CustomerManageSetting.FocusOnCustomer(input.InputData.CommonName);
                TimeManager.LongPause();

                CustomerManageSetting.ClickUpdateCustomer();
                TimeManager.LongPause();
                TimeManager.LongPause();
                TimeManager.ShortPause();
                CustomerManageSetting.FillInComments(input.InputData.Comments);
                TimeManager.ShortPause();
                CustomerManageSetting.ClickSaveButton();
                JazzMessageBox.LoadingMask.WaitLoading();
                TimeManager.LongPause();
                TimeManager.LongPause();
                TimeManager.LongPause();

                //Verify modify success
                Assert.AreEqual(CustomerManageSetting.GetCommentsValue(), input.ExpectedData.Comments);
        }
        #endregion
        #region test case 3 modification for not required fields are not displayed in view mode
        [Test]
        [ManualCaseID("TC-J1-FVT-CustomerManagement-Modify-102")]
        [CaseID("TC-J1-FVT-CustomerManagement-Modify-102")]
        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerModifyValidSuite), "TC-J1-FVT-CustomerManagement-Modify-103")]
        public void VerifyCommentField1(CustomerManagementData input)
        {
                CustomerManageSetting.FocusOnCustomer(input.InputData.CommonName);
                TimeManager.LongPause();

                CustomerManageSetting.ClickUpdateCustomer();
                TimeManager.LongPause();
                TimeManager.LongPause();
                TimeManager.ShortPause();
                CustomerManageSetting.FillInComments(input.InputData.Comments);
                TimeManager.ShortPause();
                CustomerManageSetting.ClickSaveButton();
                JazzMessageBox.LoadingMask.WaitLoading();
                TimeManager.LongPause();
                TimeManager.LongPause();
                TimeManager.LongPause();

                //Verify Comment text field disappear
                Assert.IsTrue(CustomerManageSetting.IsCustomerCommentHidden());         
        }
        #endregion
    }
}
