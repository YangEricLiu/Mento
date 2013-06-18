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
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.TestData;

namespace Mento.Script.Customer.HierarchyPropertyConfiguration
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2013-01-14")]
    [ManualCaseID("TC-J1-SmokeTest-019")]
    public class SmokeTestAddElectricityCompCostPropertySuite : TestSuiteBase
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
            JazzFunction.Navigator.NavigateHome();
        }

        /// <summary>
        /// Precondition: 1. make sure there is hierarchy path "自动化测试"/"AddCalendarProperty"/"AddPeopleProperty"
        ///               2. make sure there are 1 Toutriff "ElectricCost1"and 2 tags "ElecCost_P2", "ElecCost_P1"
        /// </summary>  
        ///
        [Test]
        [CaseID("TC-J1-SmokeTest-019-001")]
        [Priority("36")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(ElectricityComprehensiveCostData[]), typeof(SmokeTestAddElectricityCompCostPropertySuite), "TC-J1-SmokeTest-019-001")]
        public void AddCostforElectricComprehensive(ElectricityComprehensiveCostData input)
        {
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Create();
            TimeManager.MediumPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "电力"
            CostSettings.ClickElectricCostCreateButton();
            TimeManager.ShortPause();

            //select and input value, save it
            CostSettings.FillInComprehensiveCost(input.InputData);
            TimeManager.ShortPause();
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //Verify the input value displayed correct
            Assert.AreEqual(CostSettings.GetElectricCostEffectiveDateValue(), input.ExpectedData.EffectiveDate);
            Assert.AreEqual(CostSettings.GetElectricPriceMode(), input.ExpectedData.PriceMode);
            Assert.AreEqual(CostSettings.GetDemandCostTypeValue(), input.ExpectedData.DemandCostType);
            Assert.AreEqual(CostSettings.GetElectricTransformerCapacityValue(), input.ExpectedData.TransformerCapacity);
            Assert.AreEqual(CostSettings.GetElectricTransformerPriceValue(), input.ExpectedData.TransformerPrice);
            Assert.AreEqual(CostSettings.GetTouTariffIdValue(), input.ExpectedData.TouTariffId);
            Assert.AreEqual(CostSettings.GetFactorTypeValue(), input.ExpectedData.FactorType);
            Assert.AreEqual(CostSettings.GetRealTagIdValue(), input.ExpectedData.RealTagId);
            Assert.AreEqual(CostSettings.GetReactiveTagIdValue(), input.ExpectedData.ReactiveTagId);
            Assert.AreEqual(CostSettings.GetElectricPaddingCostValue(), input.ExpectedData.ElectricPaddingCost);
        }
    }
}
