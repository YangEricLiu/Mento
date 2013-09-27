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
    public class CustomerConsumptionSettingView : TestSuiteBase
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

        #region TestCase1 ViewCustomerConsumptionSetting
        [Test]
        [ManualCaseID("TC-J1-FVT-CustomerConsumptionSettingView-View-101")]
        [CaseID("TC-J1-FVT-CustomerConsumptionSettingView-View-101")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(CustomerConsumptionSettingView), "TC-J1-FVT-CustomerConsumptionSettingView-View-101")]
        public void ViewCustomerConsumptionSetting(CustomerManagementData input)
        {
            //1.Select an old existing customer which didn't defined consumption setting for map before.
            CustomerManageSetting.FocusOnCustomer(input.InputData.Name);

            //Open 'Consumption Setting For Map' (地图页信息) tab.
            CustomerManageSetting.NavigateToCustmerMapPageInfoSetting();
            TimeManager.MediumPause();
            CustomerManageSetting.ClickModifyMapPropertyButton();
            
            //Four options are checked by default.All checkboxes are disabled in View mode.
            CustomerManageSetting.CheckMapInformation("上月天然气总量");

        }
        #endregion

       
    }
}
