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

namespace Mento.Script.Administration.CustomerManagementSetting
{
    [TestFixture]
    [Owner("Cathy")]
    [CreateTime("2014-09-23")]
    [ManualCaseID("TC-J1-FVT-CustomerManagement-Delete-001")]
    public class CustomerDeleteSuite : TestSuiteBase
    {
        private CustomerManagement CustomerManageSetting = JazzFunction.CustomerManagement;
        private UserSettings UserSettings = JazzFunction.UserSettings;
        //private static EnergyViewToolbarMoreMenu MoreMenu = new EnergyViewToolbarMoreMenu();

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
            CustomerManageSetting.NavigateToTimeSetting();
            TimeManager.MediumPause();
        }

        private static HomePage HomePagePanel = JazzFunction.HomePage;

        #region test case 1 Customer can be deleted successfully when users under it

        [Test]
        [ManualCaseID("TC-J1-FVT-CustomerManagement-Delete-001")]
        [CaseID("TC-J1-FVT-CustomerManagement-Delete-001")]
        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerDeleteSuite), "TC-J1-FVT-CustomerManagement-Delete-001")]
        public void DeleteCustomerSuccess1(CustomerManagementData input)
        {
            CustomerManageSetting.FocusOnCustomer(input.InputData.CommonName);
            TimeManager.LongPause();
            
            CustomerManageSetting.ClickDeleteButton();
            TimeManager.LongPause();

            CustomerManageSetting.ClickMsgBoxDeleteButton();
            TimeManager.LongPause();
            TimeManager.LongPause();


            Assert.IsFalse(CustomerManageSetting.IsCustomerOnList(input.InputData.CommonName));

            UserSettings.NavigatorToUserSetting();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            UserSettings.FocusOnUser("UserA");
            TimeManager.LongPause();
            Assert.IsTrue(UserSettings.IsUserOnList("UserA"));
            Assert.IsTrue(UserSettings.IsUserOnList("UserB"));
            Assert.IsTrue(UserSettings.IsUserOnList("UserC"));

            CustomerManageSetting.NavigateToCustomerSetting();
            TimeManager.LongPause();
            TimeManager.LongPause();
            
            //Re-select a deleted customer to display error message

            HomePagePanel.SelectCustomer(input.InputData.CommonName);
            Assert.AreEqual(JazzMessageBox.MessageBox.GetMessage(), input.ExpectedData.Message);
            CustomerManageSetting.ClickMsgBoxCloseButton();
            TimeManager.LongPause();
            JazzFunction.LoginPage.LoginWithOption("SchneiderElectricChina", "P@ssw0rdChina", "$@Login.Label.SPManagement");
            TimeManager.LongPause();

            //Assert.IsFalse(HomePagePanel.IsCustomerExistedInCustomerSelectionDialog(input.InputData.CommonName));

        }
        #endregion

        
        #region test case 2 Delete customer success when no user under it

        [Test]
        [ManualCaseID("TC-J1-FVT-CustomerManagement-Delete-002")]
        [CaseID("TC-J1-FVT-CustomerManagement-Delete-002")]
        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerDeleteSuite), "TC-J1-FVT-CustomerManagement-Delete-002")]
        public void DeleteCustomerSuccess2(CustomerManagementData input)
        {

            CustomerManageSetting.FocusOnCustomer(input.InputData.CommonName);
            TimeManager.LongPause();

            CustomerManageSetting.ClickDeleteButton();
            TimeManager.LongPause();

            Assert.AreEqual(JazzMessageBox.MessageBox.GetMessage(),input.ExpectedData.Message);

            CustomerManageSetting.ClickMsgBoxDeleteButton();
            TimeManager.LongPause();

            Assert.IsFalse(CustomerManageSetting.IsCustomerOnList(input.InputData.CommonName));     
        }
        #endregion
  
        #region test case 3 customer deletion can be cancelled correctly

        [Test]
        [ManualCaseID("TC-J1-FVT-CustomerManagement-Delete-003")]
        [CaseID("TC-J1-FVT-CustomerManagement-Delete-003")]
        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerDeleteSuite), "TC-J1-FVT-CustomerManagement-Delete-003")]
        public void VerifyDeleteCancel(CustomerManagementData input)
        {

            CustomerManageSetting.FocusOnCustomer(input.InputData.CommonName);
            TimeManager.LongPause();

            CustomerManageSetting.ClickDeleteButton();
            TimeManager.LongPause();

            Assert.AreEqual(JazzMessageBox.MessageBox.GetMessage(), input.ExpectedData.Message);

            CustomerManageSetting.ClickMsgBoxGiveUpButton();
            TimeManager.LongPause();
            TimeManager.LongPause();

            Assert.IsTrue(CustomerManageSetting.IsCustomerOnList(input.InputData.CommonName));

            CustomerManageSetting.FocusOnCustomer(input.InputData.CommonName);

            CustomerManageSetting.ClickDeleteButton();
            TimeManager.LongPause();

            CustomerManageSetting.ClickMsgBoxCloseButton();

            Assert.IsTrue(CustomerManageSetting.IsCustomerOnList(input.InputData.CommonName));

            HomePagePanel.SelectCustomer("custC");
            TimeManager.LongPause();
            TimeManager.LongPause();
            CustomerManageSetting.NavigatorToEnergyView();

            //go out page
            HomePagePanel.SelectCustomer("$@Login.Label.SPManagement");
            TimeManager.LongPause();
            TimeManager.LongPause();
        }
        
        #endregion

        #region test case 4 Ensure that the customer deletion can be success when customer contain Vee Special Rule.

        [Test]
        [ManualCaseID("TC-J1-FVT-CustomerManagement-Delete-004")]
        [CaseID("TC-J1-FVT-CustomerManagement-Delete-004")]
        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerDeleteSuite), "TC-J1-FVT-CustomerManagement-Delete-004")]
        public void VEECustomerDeleteLater(CustomerManagementData input)
        {
            CustomerManageSetting.FocusOnCustomer(input.InputData.CommonName);
            TimeManager.LongPause();

            CustomerManageSetting.ClickDeleteButton();
            TimeManager.LongPause();

            Assert.AreEqual(JazzMessageBox.MessageBox.GetMessage(), input.ExpectedData.Message);

            CustomerManageSetting.ClickMsgBoxDeleteButton();
            TimeManager.LongPause();

            Assert.IsFalse(CustomerManageSetting.IsCustomerOnList(input.InputData.CommonName));
        }

        #endregion
    }
}
