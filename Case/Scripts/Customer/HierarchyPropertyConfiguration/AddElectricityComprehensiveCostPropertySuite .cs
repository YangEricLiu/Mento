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

        [Test]
        [CaseID("TC-J1-SmokeTest-019-001")]
        [Priority("36")]
        [Type("BVT")]
        public void AddCostforElectricComprehensive()
        {
            /// <summary>
            /// Precondition: 1. make sure there is hierarchy path "自动化测试"/"AddCalendarProperty"/"AddPeopleProperty"
            /// </summary>  
            ///
            HierarchySetting.ExpandNode("自动化测试");
            HierarchySetting.ExpandNode("AddCalendarProperty");
            HierarchySetting.FocusOnHierarchyNode("AddPeopleProperty");
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
