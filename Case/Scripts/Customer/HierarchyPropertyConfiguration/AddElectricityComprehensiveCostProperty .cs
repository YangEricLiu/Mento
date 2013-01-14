using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library;

namespace Mento.Script.Customer.HierarchyPropertyConfiguration
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2013-01-14")]
    [ManualCaseID("TC-J1-SmokeTest-019")]
    public class AddElectricityComprehensiveCostProperty : TestSuiteBase
    {
        private static HierarchySettings HierarchySetting = JazzFunction.HierarchySettings;
        private static HierarchyElectricCostSettings CostSettings = JazzFunction.HierarchyElectricCostSettings;

        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettings);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            BrowserHandler.Refresh();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-019-001")]
        [Priority("P1")]
        [Type("Smoke")]
        public void AddCostforElectricComprehensive()
        {
            HierarchySetting.ExpandNode("自动化测试");
            HierarchySetting.ExpandNode("AddCalendarProperty");
            HierarchySetting.FocusOnHierarchyNode("AddPeopleProperty");
            TimeManager.ShortPause();
            CostSettings.ClickCostPropertyTabButton();
            TimeManager.MediumPause();
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();
            CostSettings.ClickElectricCostCreateButton();
            TimeManager.ShortPause();
            CostSettings.SelectElectricEffectiveDate(new DateTime(2013, 1, 5));
            CostSettings.SelectElectricPriceMode("综合电价");

            CostSettings.SelectDemandCostType("变压器容量模式");
            CostSettings.FillElectricTransformerCapacity("10");
            CostSettings.FillElectricTransformerPrice("21");
            CostSettings.SelectTouTariffId("ElectricCost1");
            CostSettings.SelectFactorType("0.85");
            CostSettings.SelectRealTagId("ElecCost_P2");
            CostSettings.SelectReactiveTagId("ElecCost_P1");
            CostSettings.FillElectricPaddingCost("80");
            TimeManager.ShortPause();
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            Assert.AreEqual(CostSettings.GetElectricCostEffectiveDateValue(), "2013-01");
            Assert.AreEqual(CostSettings.GetElectricPriceMode(), "综合电价");
            Assert.AreEqual(CostSettings.GetDemandCostTypeValue(), "变压器容量模式");
            Assert.AreEqual(CostSettings.GetElectricTransformerCapacityValue(), "10");
            Assert.AreEqual(CostSettings.GetElectricTransformerPriceValue(), "21");
            Assert.AreEqual(CostSettings.GetTouTariffIdValue(), "ElectricCost1");
            Assert.AreEqual(CostSettings.GetFactorTypeValue(), "0.85");
            Assert.AreEqual(CostSettings.GetRealTagIdValue(), "ElecCost_P2");
            Assert.AreEqual(CostSettings.GetReactiveTagIdValue(), "ElecCost_P1");
            Assert.AreEqual(CostSettings.GetElectricPaddingCostValue(), "80");
        }
    }
}
