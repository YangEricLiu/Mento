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
    public class CustomerModifyInvalidSuite : TestSuiteBase
    {
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

         #region Test case1 modify can be cancelled success
            [Test]
            [ManualCaseID("TC-J1-FVT-CustomerManagement-Modify-001")]
            [CaseID("TC-J1-FVT-CustomerManagement-Modify-001")]
            [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerModifyInvalidSuite), "TC-J1-FVT-CustomerManagement-Modify-001")]
            public void ModifyInvalidCustomer1(CustomerManagementData input)
            {

                string Name = "CustomerForModifyCancelled";
                CustomerManageSetting.FocusOnCustomer(Name);
                TimeManager.LongPause();

                CustomerManageSetting.ClickUpdateCustomer();
                TimeManager.LongPause();
                TimeManager.LongPause();
                TimeManager.ShortPause();
                CustomerManageSetting.ClickSaveButton();
                TimeManager.LongPause();
                TimeManager.LongPause();
                TimeManager.ShortPause();

                //Verify Save button disappear
                Assert.IsFalse(CustomerManageSetting.IsSaveButtonDisplayed());

                //Verify modify success
                Assert.AreEqual(CustomerManageSetting.GetNameValue(), input.ExpectedData.CommonName);
                Assert.AreEqual(CustomerManageSetting.GetCodeValue(), input.ExpectedData.Code);
                Assert.AreEqual(CustomerManageSetting.GetAddressValue(), input.ExpectedData.Address);
                Assert.AreEqual(CustomerManageSetting.GetResponsiblePersonValue(), input.ExpectedData.RealName);
                Assert.AreEqual(CustomerManageSetting.GetTelephoneValue(), input.ExpectedData.Telephone);
                Assert.AreEqual(CustomerManageSetting.GetEmailValue(), input.ExpectedData.Email);
                Assert.AreEqual(CustomerManageSetting.GetCommentsValue(), input.ExpectedData.Comments);

                CustomerManageSetting.ClickUpdateCustomer();
                TimeManager.LongPause();
                TimeManager.LongPause();
                TimeManager.ShortPause();

                CustomerManageSetting.FillInName(input.InputData.CommonName);
                CustomerManageSetting.FillInCode(input.InputData.Code);
                TimeManager.ShortPause();

                CustomerManageSetting.ClickCancelButton();
                JazzMessageBox.LoadingMask.WaitLoading();
                TimeManager.LongPause();

                //Verify modify success
                Assert.AreEqual(CustomerManageSetting.GetNameValue(), input.ExpectedData.CommonName);
                Assert.AreEqual(CustomerManageSetting.GetCodeValue(), input.ExpectedData.Code);
                Assert.AreEqual(CustomerManageSetting.GetAddressValue(), input.ExpectedData.Address);
                Assert.AreEqual(CustomerManageSetting.GetResponsiblePersonValue(), input.ExpectedData.RealName);
                Assert.AreEqual(CustomerManageSetting.GetTelephoneValue(), input.ExpectedData.Telephone);
                Assert.AreEqual(CustomerManageSetting.GetEmailValue(), input.ExpectedData.Email);
                Assert.AreEqual(CustomerManageSetting.GetCommentsValue(), input.ExpectedData.Comments);
            }
     #endregion
  
     #region    Test case2 Some Fields not editable
         
            [Test]
            [ManualCaseID("TC-J1-FVT-CustomerManagement-Modify-002")]
            [CaseID("TC-J1-FVT-CustomerManagement-Modify-002")]
            [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerModifyInvalidSuite), "TC-J1-FVT-CustomerManagement-Modify-002")]
            public void VerifyCustomerAdmin(CustomerManagementData input)
            {
                if (input.InputData.CommonName == "CustomerForFieldsNotEditable1")
                {
                    String s1 = "未选择";
                    CustomerManageSetting.FocusOnCustomer(input.InputData.CommonName);
                    TimeManager.LongPause();

                    //Verify CustomerAdmin is "未选择".
                    Assert.AreEqual(CustomerManageSetting.GetCustomerAdminTexts(), s1);          

                }

                else if (input.InputData.CommonName == "CustomerForFieldsNotEditable2")
                {
                    String s2 = "User_CustomerManager";
                    CustomerManageSetting.FocusOnCustomer(input.InputData.CommonName);
                    TimeManager.LongPause();

                    //Verify CustomerAdmin is "User_CustomerManager1".
                    Assert.AreEqual(CustomerManageSetting.GetCustomerAdminTexts(), s2);

                    CustomerManageSetting.ClickUpdateCustomer();
                    TimeManager.LongPause();
                    TimeManager.LongPause();
                    TimeManager.ShortPause();

                    //Verify OperationTime disabled and not editable
                    Assert.IsFalse(CustomerManageSetting.IsOperationtimeEnable());

                    //Verify CustomerAdminContainer missing
                    Assert.IsFalse(CustomerManageSetting.IsCustomerAdminDisplayed());
                }
                else
                {
                    String s3 = "User_CustomerManager1，User_CustomerManager2";
                    CustomerManageSetting.FocusOnCustomer(input.InputData.CommonName);
                    TimeManager.LongPause();

                    //Verify CustomerAdmin is "User_CustomerManager1,User_CustomerManager2".
                    Assert.AreEqual(CustomerManageSetting.GetCustomerAdminTexts(), s3);
                    CustomerManageSetting.ClickUpdateCustomer();
                    TimeManager.LongPause();
                    TimeManager.LongPause();
                    TimeManager.ShortPause();

                    //Verify OperationTime disabled and not editable
                    Assert.IsFalse(CustomerManageSetting.IsOperationtimeEnable());

                    //Verify CustomerAdminContainer missing
                    Assert.IsFalse(CustomerManageSetting.IsCustomerAdminDisplayed());
                }
            }
         
        #endregion
         

        #region Test case3 verify invalid message

        [Test]
        [ManualCaseID("TC-J1-FVT-CustomerManagement-Modify-003")]
        [CaseID("TC-J1-FVT-CustomerManagement-Modify-003")]
        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerModifyInvalidSuite), "TC-J1-FVT-CustomerManagement-Modify-003")]
        public void VerifyErrormessage2(CustomerManagementData input)
        {

            string Name = "CustomerForModifyInvalid";
            CustomerManageSetting.FocusOnCustomer(Name);
            TimeManager.LongPause();

            CustomerManageSetting.ClickUpdateCustomer();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.ShortPause();

            CustomerManageSetting.FillInName(input.InputData.CommonName);
            CustomerManageSetting.FillInCode(input.InputData.Code);
            CustomerManageSetting.FillInResponsiblePerson(input.InputData.RealName);
            CustomerManageSetting.FillInTelephone(input.InputData.Telephone);
            CustomerManageSetting.FillInEmail(input.InputData.Email);
            TimeManager.ShortPause();

            CustomerManageSetting.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Verify error message display
            Assert.IsTrue(CustomerManageSetting.IsNameInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(CustomerManageSetting.IsCodeInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(CustomerManageSetting.IsResponsiblePersonInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(CustomerManageSetting.IsTelephoneInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(CustomerManageSetting.IsEmailInvalidMsgCorrect(input.ExpectedData));
        }
        #endregion
       
        #region Test case4 verify invalid message

        [Test]
        [ManualCaseID("TC-J1-FVT-CustomerManagement-Modify-004")]
        [CaseID("TC-J1-FVT-CustomerManagement-Modify-004")]
        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerModifyInvalidSuite), "TC-J1-FVT-CustomerManagement-Modify-004")]
        public void VerifyDuplicateMsg(CustomerManagementData input)
        {

            string Name = "CustomerForModifyNameCodeInvalid";
            CustomerManageSetting.FocusOnCustomer(Name);
            TimeManager.LongPause();

            CustomerManageSetting.ClickUpdateCustomer();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.ShortPause();

            CustomerManageSetting.FillInName(input.InputData.CommonName);
            TimeManager.ShortPause();

            CustomerManageSetting.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();


            //Verify duplicate name error message display
            Assert.IsTrue(CustomerManageSetting.IsNameInvalidMsgCorrect(input.ExpectedData));
            TimeManager.LongPause();

            CustomerManageSetting.FillInName(Name);

            CustomerManageSetting.FillInCode(input.InputData.Code);

            CustomerManageSetting.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Verify duplicate code error message display
            Assert.IsTrue(CustomerManageSetting.IsCodeInvalidMsgCorrect(input.ExpectedData));
        }
        #endregion
        
        #region test case5 verify 必填项 error message

        [Test]
        [ManualCaseID("TC-J1-FVT-CustomerManagement-Modify-005")]
        [CaseID("TC-J1-FVT-CustomerManagement-Modify-005")]
        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerModifyInvalidSuite), "TC-J1-FVT-CustomerManagement-Modify-005")]
        public void ModifyRequiredMessage(CustomerManagementData input)
        {

            string Name = "CustomerForModifyRequiredFieldsEmpty";
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
            TimeManager.ShortPause();

            CustomerManageSetting.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Verify error message 必填项 display
            Assert.IsTrue(CustomerManageSetting.IsNameInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(CustomerManageSetting.IsCodeInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(CustomerManageSetting.IsAddressInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(CustomerManageSetting.IsResponsiblePersonInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(CustomerManageSetting.IsTelephoneInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(CustomerManageSetting.IsEmailInvalidMsgCorrect(input.ExpectedData));
        }
        #endregion

    }
}
