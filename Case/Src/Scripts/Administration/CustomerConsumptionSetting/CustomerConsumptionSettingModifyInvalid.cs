using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Administration;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Administration.CustomerConsumptionSetting
{
    [TestFixture]
    [Owner("Greenie")]
    [CreateTime("2013-09-27")]
    public class CustomerConsumptionSettingModifyInvalid : TestSuiteBase
    {
        private static CustomerManagement CustomerManageSetting = JazzFunction.CustomerManagement;
        [SetUp]
        public void CaseSetUp()
        {
            CustomerManageSetting.NavigateToCustmerSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
            //TimeManager.MediumPause();
        }

        #region TestCase1 ModifyCustomerConsumptionSettingCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-CustomerConsumptionSetting-Modify-001")]
        [CaseID("TC-J1-FVT-CustomerConsumptionSetting-Modify-001-1")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerConsumptionSettingModifyInvalid), "TC-J1-FVT-CustomerConsumptionSetting-Modify-001-1")]
        public void ModifyCustomerConsumptionSettingCancelled(CustomerManagementData input)
        {
            //Select an existing customer.
            CustomerManageSetting.FocusOnCustomer(input.InputData.Name);

            //Open 'Consumption Setting For Map' (地图页信息) tab.
            CustomerManageSetting.NavigateToCustmerMapPageInfoSetting();
            TimeManager.MediumPause();

            //Click 'Modify' button.
            CustomerManageSetting.ClickModifyMapPropertyButton();
            TimeManager.MediumPause();
            
            //Click Save button directly without any modification.
            CustomerManageSetting.ClickSaveMapPropertyButton();
            TimeManager.ShortPause();
            Assert.IsTrue(CustomerManageSetting.AreDefaultOptionsChecked());

            //Click 'Modify' button.
            CustomerManageSetting.ClickModifyMapPropertyButton();
            TimeManager.MediumPause();

            //Check one option.Uncheck one option.
            CustomerManageSetting.CheckMapInformation(input.InputData.MapOptions[0]);
            CustomerManageSetting.UnCheckMapInformation(input.InputData.MapOptions[1]);

            //But Click Cancel button.
            CustomerManageSetting.ClickCancelMapPropertyButton();
            TimeManager.ShortPause();
            //•   No 'Cancel' button on the page after cancelled.
            Assert.IsFalse(CustomerManageSetting.IsCancelMapPropertyButtonDisplayed());
            //•   The modification is cancelled and information remains as before.
            Assert.IsTrue(CustomerManageSetting.AreDefaultOptionsChecked());
        }
        #endregion

        #region TestCase2 ModifyWithSelectNoOption
        [Test]
        [ManualCaseID("TC-J1-FVT-CustomerConsumptionSetting-Modify-001")]
        [CaseID("TC-J1-FVT-CustomerConsumptionSetting-Modify-001-2")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerConsumptionSettingModifyInvalid), "TC-J1-FVT-CustomerConsumptionSetting-Modify-001-2")]
        public void ModifyWithSelectNoOption(CustomerManagementData input)
        {
            //Select an existing customer.
            CustomerManageSetting.FocusOnCustomer(input.InputData.Name);

            //Open 'Consumption Setting For Map' (地图页信息) tab.
            CustomerManageSetting.NavigateToCustmerMapPageInfoSetting();
            TimeManager.MediumPause();

            //Click 'Modify' button.
            CustomerManageSetting.ClickModifyMapPropertyButton();
            TimeManager.MediumPause();

            //Uncheck all selected options.
            Assert.IsTrue(CustomerManageSetting.UnCheckMapInformations(input.InputData.MapOptions));
            CustomerManageSetting.UnCheckMapInformations(input.ExpectedData.MapOptions);
            // Click Save button.
            CustomerManageSetting.ClickSaveMapPropertyButton();
            TimeManager.MediumPause();

            // Error message 'Please select one option at least' is displayed.   
            //Assert.IsTrue(CustomerManageSetting.IsInvalidMessageCorrect("请至少选择一项。"));
            //  The error message disappeared.
            Assert.IsTrue(CustomerManageSetting.IsMapInfoCheckBoxInvalidTipsDisplayed());

            //Check one option.
            CustomerManageSetting.CheckMapInformation(input.InputData.MapOptions[0]);
            Assert.IsFalse(CustomerManageSetting.IsMapInfoCheckBoxInvalidTipsDisplayed());
            // Saved successfully and no 'Save' button on the page after saved.
            CustomerManageSetting.ClickSaveMapPropertyButton();
            TimeManager.MediumPause();
            Assert.IsFalse(CustomerManageSetting.IsMapSaveButtonDisplayed());
        }
        #endregion

        #region TestCase3 OtherOptionDisabledAfterFiveChecked
        [Test]
        [ManualCaseID("TC-J1-FVT-CustomerConsumptionSetting-Modify-001")]
        [CaseID("TC-J1-FVT-CustomerConsumptionSetting-Modify-001-3")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerConsumptionSettingModifyInvalid), "TC-J1-FVT-CustomerConsumptionSetting-Modify-001-3")]
        public void OtherOptionDisabledAfterFiveChecked(CustomerManagementData input)
        {
            //Select an existing customer.
            CustomerManageSetting.FocusOnCustomer(input.InputData.Name);

            //Open 'Consumption Setting For Map' (地图页信息) tab.
            CustomerManageSetting.NavigateToCustmerMapPageInfoSetting();
            TimeManager.MediumPause();

            //Click 'Modify' button.
            CustomerManageSetting.ClickModifyMapPropertyButton();
            TimeManager.MediumPause();

            //5 options are selected. All the other options will be disabled.
            CustomerManageSetting.AreItemsChecked(input.InputData.MapOptions);
            Assert.IsTrue(CustomerManageSetting.AreItemsDisabled(input.ExpectedData.MapOptions));

            //Uncheck one option so that there are 4 options are selected now.All the other options are enabled
            CustomerManageSetting.UnCheckMapInformation(input.InputData.MapOptions[0]);
            Assert.IsTrue(CustomerManageSetting.AreAllOfItemsAbled());

            //Select another option. All the other options will be disabled again.
            CustomerManageSetting.CheckMapInformation(input.InputData.MapOptions[0]);
            Assert.IsTrue(CustomerManageSetting.AreItemsDisabled(input.ExpectedData.MapOptions));

            //Click Save button. Saved successfully and no 'Save' button on the page after saved.
            CustomerManageSetting.ClickSaveMapPropertyButton();
            TimeManager.ShortPause();
            Assert.IsFalse(CustomerManageSetting.IsMapSaveButtonDisplayed());
            Assert.IsTrue(CustomerManageSetting.AreItemsChecked(input.InputData.MapOptions));
        }
        #endregion

    }
}
