//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using NUnit.Framework;
//using Mento.Framework;
//using Mento.Utility;
//using Mento.TestApi.TestData;
//using Mento.TestApi.TestData.Attribute;
//using System.IO;
//using Mento.TestApi.WebUserInterface;
//using Mento.ScriptCommon.Library.Functions;
//using Mento.Framework.Attributes;
//using Mento.Framework.Script;
//using Mento.ScriptCommon.TestData.Administration;
//using Mento.ScriptCommon.Library;
//using Mento.TestApi.WebUserInterface.Controls;
//using Mento.TestApi.WebUserInterface.ControlCollection;

//namespace Mento.Script.Administration.CustomerManagementSetting
//{
//    [TestFixture]
//    [Owner("Cathy")]
//    [CreateTime("2014-09-10")]
//    public class CustomerModifyInvalidSuite : TestSuiteBase
//    {
//        private static CustomerManagement CustomerManageSetting = JazzFunction.CustomerManagement;
//        [SetUp]
//        public void CaseSetUp()
//        {
//            TimeManager.LongPause();
//            CustomerManageSetting.NavigateToCustomerSetting();
//            TimeManager.MediumPause();
//            TimeManager.LongPause();
//        }

//        [TearDown]
//        public void CaseTearDown()
//        {
//            CustomerManageSetting.NavigatorToTimeSettings();
//            TimeManager.MediumPause();
//            //JazzFunction.TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
//        }

//        #region Test case1 modify can be cancelled success
//            [Test]
//            [ManualCaseID("TC-J1-FVT-CustomerManagement-Modify-001")]
//            [CaseID("TC-J1-FVT-CustomerManagement-Modify-001")]
//            [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerModifyInvalidSuite), "TC-J1-FVT-CustomerManagement-Modify-001")]
//            public void ModifyInvalidCustomer1(CustomerManagementData input)
//            {

//                string Name = "CustomerForModifyCancelled";
//                CustomerManageSetting.FocusOnCustomer(Name);
//                TimeManager.LongPause();

//                CustomerManageSetting.ClickUpdateCustomer();
//                TimeManager.LongPause();
//                TimeManager.LongPause();
//                TimeManager.ShortPause();
//                CustomerManageSetting.ClickSaveButton();
//                TimeManager.LongPause();
//                TimeManager.LongPause();
//                TimeManager.ShortPause();

//                //Verify Save button disappear
//                Assert.IsFalse(CustomerManageSetting.IsSaveButtonDisplayed());

//                //Verify modify success
//                Assert.AreEqual(input.ExpectedData.CommonName,CustomerManageSetting.GetNameValue() );
//                Assert.AreEqual(input.ExpectedData.Code,CustomerManageSetting.GetCodeValue());
//                Assert.AreEqual(input.ExpectedData.Address,CustomerManageSetting.GetAddressValue());
//                Assert.AreEqual(input.ExpectedData.RealName,CustomerManageSetting.GetResponsiblePersonValue());
//                Assert.AreEqual(input.ExpectedData.Telephone,CustomerManageSetting.GetTelephoneValue());
//                Assert.AreEqual(input.ExpectedData.Email,CustomerManageSetting.GetEmailValue());
//                Assert.AreEqual(input.ExpectedData.Comments,CustomerManageSetting.GetCommentsValue());

//                CustomerManageSetting.ClickUpdateCustomer();
//                TimeManager.LongPause();
//                TimeManager.LongPause();
//                TimeManager.ShortPause();

//                CustomerManageSetting.FillInName(input.InputData.CommonName);
//                CustomerManageSetting.FillInCode(input.InputData.Code);
//                TimeManager.ShortPause();

//                CustomerManageSetting.ClickCancelButton();
//                JazzMessageBox.LoadingMask.WaitLoading();
//                TimeManager.LongPause();

//                //Verify modify success
//                Assert.AreEqual(input.ExpectedData.CommonName,CustomerManageSetting.GetNameValue());
//                Assert.AreEqual(input.ExpectedData.Code,CustomerManageSetting.GetCodeValue());
//                Assert.AreEqual(input.ExpectedData.Address,CustomerManageSetting.GetAddressValue());
//                Assert.AreEqual(input.ExpectedData.RealName,CustomerManageSetting.GetResponsiblePersonValue());
//                Assert.AreEqual(input.ExpectedData.Telephone,CustomerManageSetting.GetTelephoneValue());
//                Assert.AreEqual(input.ExpectedData.Email,CustomerManageSetting.GetEmailValue());
//                Assert.AreEqual(input.ExpectedData.Comments,CustomerManageSetting.GetCommentsValue());
//            }
//     #endregion
  
//        #region    Test case2 Some Fields not editable
         
//            [Test]
//            [ManualCaseID("TC-J1-FVT-CustomerManagement-Modify-002")]
//            [CaseID("TC-J1-FVT-CustomerManagement-Modify-002")]
//            [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerModifyInvalidSuite), "TC-J1-FVT-CustomerManagement-Modify-002")]
//            public void VerifyCustomerAdmin(CustomerManagementData input)
//            {
               
//                    CustomerManageSetting.FocusOnCustomer(input.InputData.CommonName);
//                    TimeManager.LongPause();

//                    //Verify CustomerAdmin is "未选择".
//                    Assert.AreEqual(input.ExpectedData.CustomerAdminName[0], CustomerManageSetting.GetCustomerAdminTexts());

//                    CustomerManageSetting.ClickUpdateCustomer();
//                    TimeManager.LongPause();
//                    TimeManager.LongPause();
//                    TimeManager.ShortPause();

//                    //Verify OperationTime disabled and not editable
//                    Assert.IsFalse(CustomerManageSetting.IsOperationtimeEnable());

//                    //Verify CustomerAdminContainer missing
//                    Assert.IsFalse(CustomerManageSetting.IsCustomerAdminDisplayed());
//            }
         
//        #endregion
         

//        #region Test case3 verify invalid message

//        [Test]
//        [ManualCaseID("TC-J1-FVT-CustomerManagement-Modify-003")]
//        [CaseID("TC-J1-FVT-CustomerManagement-Modify-003")]
//        [IllegalInputValidation(typeof(CustomerManagementData[]))]
//        public void VerifyErrormessage2(CustomerManagementData input)
//        {

//            string Name = "CustomerForModifyInvalid";
//            CustomerManageSetting.FocusOnCustomer(Name);
//            TimeManager.LongPause();

//            CustomerManageSetting.ClickUpdateCustomer();
//            TimeManager.LongPause();
//            TimeManager.LongPause();
//            TimeManager.ShortPause();

//            CustomerManageSetting.FillInName(input.InputData.CommonName);
//            CustomerManageSetting.FillInCode(input.InputData.Code);
//            CustomerManageSetting.FillInResponsiblePerson(input.InputData.RealName);
//            CustomerManageSetting.FillInTelephone(input.InputData.Telephone);
//            CustomerManageSetting.FillInEmail(input.InputData.Email);
//            TimeManager.ShortPause();

//            CustomerManageSetting.ClickSaveButton();
//            JazzMessageBox.LoadingMask.WaitLoading();
//            TimeManager.LongPause();
//            TimeManager.LongPause();
//            TimeManager.LongPause();

//            //Verify error message display
//            Assert.IsTrue(CustomerManageSetting.IsNameInvalidMsgCorrect(input.ExpectedData));
//            Assert.IsTrue(CustomerManageSetting.IsCodeInvalidMsgCorrect(input.ExpectedData));
//            Assert.IsTrue(CustomerManageSetting.IsResponsiblePersonInvalidMsgCorrect(input.ExpectedData));
//            Assert.IsTrue(CustomerManageSetting.IsTelephoneInvalidMsgCorrect(input.ExpectedData));
//            Assert.IsTrue(CustomerManageSetting.IsEmailInvalidMsgCorrect(input.ExpectedData));
//        }
//        #endregion
       
//        #region Test case4 verify invalid message

//        [Test]
//        [ManualCaseID("TC-J1-FVT-CustomerManagement-Modify-004")]
//        [CaseID("TC-J1-FVT-CustomerManagement-Modify-004")]
//        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerModifyInvalidSuite), "TC-J1-FVT-CustomerManagement-Modify-004")]
//        public void VerifyDuplicateMsg(CustomerManagementData input)
//        {

//            string Name = "CustomerForModifyNameCodeInvalid";
//            CustomerManageSetting.FocusOnCustomer(Name);
//            TimeManager.LongPause();

//            CustomerManageSetting.ClickUpdateCustomer();
//            TimeManager.LongPause();
//            TimeManager.LongPause();
//            TimeManager.ShortPause();

//            CustomerManageSetting.FillInName(input.InputData.CommonName);
//            TimeManager.ShortPause();

//            CustomerManageSetting.ClickSaveButton();
//            JazzMessageBox.LoadingMask.WaitLoading();
//            TimeManager.LongPause();


//            //Verify duplicate name error message display
//            Assert.IsTrue(CustomerManageSetting.IsNameInvalidMsgCorrect(input.ExpectedData));
//            TimeManager.LongPause();

//            CustomerManageSetting.FillInName(Name);

//            CustomerManageSetting.FillInCode(input.InputData.Code);

//            CustomerManageSetting.ClickSaveButton();
//            JazzMessageBox.LoadingMask.WaitLoading();
//            TimeManager.LongPause();

//            //Verify duplicate code error message display
//            Assert.IsTrue(CustomerManageSetting.IsCodeInvalidMsgCorrect(input.ExpectedData));
//        }
//        #endregion
        
//        #region test case5 verify 必填项 error message

//        [Test]
//        [ManualCaseID("TC-J1-FVT-CustomerManagement-Modify-005")]
//        [CaseID("TC-J1-FVT-CustomerManagement-Modify-005")]
//        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerModifyInvalidSuite), "TC-J1-FVT-CustomerManagement-Modify-005")]
//        public void ModifyRequiredMessage(CustomerManagementData input)
//        {

//            string Name = "CustomerForModifyRequiredFieldsEmpty";
//            CustomerManageSetting.FocusOnCustomer(Name);
//            TimeManager.LongPause();

//            CustomerManageSetting.ClickUpdateCustomer();
//            TimeManager.LongPause();
//            TimeManager.LongPause();
//            TimeManager.ShortPause();

//            CustomerManageSetting.FillInName(input.InputData.CommonName);
//            CustomerManageSetting.FillInCode(input.InputData.Code);
//            CustomerManageSetting.FillInAddress(input.InputData.Address);
//            CustomerManageSetting.FillInResponsiblePerson(input.InputData.RealName);
//            CustomerManageSetting.FillInTelephone(input.InputData.Telephone);
//            CustomerManageSetting.FillInEmail(input.InputData.Email);
//            TimeManager.ShortPause();

//            CustomerManageSetting.ClickSaveButton();
//            JazzMessageBox.LoadingMask.WaitLoading();
//            TimeManager.LongPause();
//            TimeManager.LongPause();
//            TimeManager.LongPause();

//            //Verify error message 必填项 display
//            Assert.IsTrue(CustomerManageSetting.IsNameInvalidMsgCorrect(input.ExpectedData));
//            Assert.IsTrue(CustomerManageSetting.IsCodeInvalidMsgCorrect(input.ExpectedData));
//            Assert.IsTrue(CustomerManageSetting.IsAddressInvalidMsgCorrect(input.ExpectedData));
//            Assert.IsTrue(CustomerManageSetting.IsResponsiblePersonInvalidMsgCorrect(input.ExpectedData));
//            Assert.IsTrue(CustomerManageSetting.IsTelephoneInvalidMsgCorrect(input.ExpectedData));
//            Assert.IsTrue(CustomerManageSetting.IsEmailInvalidMsgCorrect(input.ExpectedData));
//        }
//        #endregion

//    }
//}
