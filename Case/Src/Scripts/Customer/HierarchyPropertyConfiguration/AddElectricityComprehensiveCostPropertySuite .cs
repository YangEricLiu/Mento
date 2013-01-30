﻿using System;
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
    public class AddElectricityComprehensiveCostPropertySuite : TestSuiteBase
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
        [MultipleTestDataSource(typeof(ElectricityComprehensiveCostData[]), typeof(AddElectricityComprehensiveCostPropertySuite), "TC-J1-SmokeTest-019-001")]
        public void AddCostforElectricComprehensive(ElectricityComprehensiveCostData testData)
        {
            HierarchySetting.ExpandNode("自动化测试");
            HierarchySetting.ExpandNode("AddCalendarProperty");
            HierarchySetting.SelectHierarchyNode("AddPeopleProperty");
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton();
            TimeManager.MediumPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "电力"
            CostSettings.ClickElectricCostCreateButton();
            TimeManager.ShortPause();

            //select and input value, save it
            CostSettings.FillInComprehensiveCost(testData.InputData);
            TimeManager.ShortPause();
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //Verify the input value displayed correct
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