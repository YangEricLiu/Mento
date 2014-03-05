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
    public class CustomerConsumptionSettingModifyValid : TestSuiteBase
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
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
            TimeManager.MediumPause();
        }

        #region TestCase1 ModifyCustomerConsumptionSettingValid
        [Test]
        [ManualCaseID("TC-J1-FVT-CustomerConsumptionSetting-Modify-101")]
        [CaseID("TC-J1-FVT-CustomerConsumptionSetting-Modify-101-1")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerConsumptionSettingModifyValid), "TC-J1-FVT-CustomerConsumptionSetting-Modify-101-1")]
        public void ModifyCustomerConsumptionSettingValid(CustomerManagementData input)
        {
            //Select an existing customer.
            CustomerManageSetting.FocusOnCustomer(input.InputData.Name);

            //Open 'Consumption Setting For Map' (地图页信息) tab.
            CustomerManageSetting.NavigateToCustmerMapPageInfoSetting();
            TimeManager.MediumPause();
            //Click 'Modify' button.
            CustomerManageSetting.ClickModifyMapPropertyButton();
            TimeManager.MediumPause();
            //Display all the Industry3 available selections including
            Assert.IsTrue(CustomerManageSetting.AreDefaultOptionsChecked());
            //CustomerManageSetting.AreItemsChecked(input.InputData.MapOptions);
            Assert.IsTrue(CustomerManageSetting.AreItemsUnChecked(input.ExpectedData.MapOptions));
            //Check one option.Uncheck one option.
            CustomerManageSetting.CheckMapInformation(input.InputData.MapOptions[0]);
            TimeManager.ShortPause();
            CustomerManageSetting.UnCheckMapInformation(input.InputData.MapOptions[1]);

            //•   Checked options are displayed in View mode.
            //•   Unchecked options are NOT displayed in View mode.
            CustomerManageSetting.ClickSaveMapPropertyButton();
            TimeManager.ShortPause();
            Assert.IsTrue(CustomerManageSetting.IsItemChecked(input.InputData.MapOptions[0]));
            Assert.IsTrue(CustomerManageSetting.IsItemUnChecked(input.InputData.MapOptions[1]));
        }
        #endregion

    }
}
