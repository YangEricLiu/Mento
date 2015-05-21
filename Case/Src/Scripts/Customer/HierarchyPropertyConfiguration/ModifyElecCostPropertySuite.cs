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
using Mento.TestApi.TestData.Attribute;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.HierarchyPropertyConfiguration
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2013-06-20")]
    [ManualCaseID("TC-J1-FVT-CostConfiguration-Elec-Modify")]
    public class ModifyElecCostPropertySuite : TestSuiteBase
    {
        private static HierarchySettings HierarchySetting = JazzFunction.HierarchySettings;
        private static HierarchyElectricCostSettings CostSettings = JazzFunction.HierarchyElectricCostSettings;

        [SetUp]
        public void CaseSetUp()
        {
            HierarchySetting.NavigatorToHierarchySetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            HierarchySetting.NavigatorToNonHierarchy();
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Modify-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(ElectricityComprehensiveCostData[]), typeof(ModifyElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Modify-101-1")]
        public void ModifyThenSave(ElectricityComprehensiveCostData input)
        {
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Update();
            TimeManager.MediumPause();

            //Click "修改" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Modify to duplicate date
            CostSettings.SelectElectricEffectiveDate("2012-05", 1);

            //verify that invalid check triggered
            Assert.IsTrue(CostSettings.IsEffectiveDateInvalid(1));
            Assert.IsTrue(CostSettings.IsEffectiveDateInvalidMsgCorrect(input.ExpectedData.EffectiveDate, 1));

            //Can't Save
            CostSettings.ClickCostSaveButton();
            TimeManager.LongPause();
            Assert.IsTrue(CostSettings.IsCostSaveButtonDisplayed());
            Assert.IsTrue(CostSettings.IsCostCancelButtonDisplayed());

            //Modify to non duplicate date
            CostSettings.SelectElectricEffectiveDate(input.InputData.EffectiveDate, 1);

            //Save successful
            CostSettings.ClickCostSaveButton();
            TimeManager.LongPause();
            Assert.IsFalse(CostSettings.IsCostSaveButtonDisplayed());
            Assert.IsFalse(CostSettings.IsCostCancelButtonDisplayed());
            Assert.IsTrue(CostSettings.IsCostUpdateButtonDisplayed());
            Assert.AreEqual(input.InputData.EffectiveDate, CostSettings.GetElectricCostEffectiveDateValue(1));
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Modify-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(ElectricityComprehensiveCostData[]), typeof(ModifyElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Modify-101-2")]
        public void ModifyCancelThenSave(ElectricityComprehensiveCostData input)
        {
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Update();
            TimeManager.MediumPause();

            //Click "修改" button
            CostSettings.ClickCostCreateButton();
            TimeManager.MediumPause();

            //Modify value and "Cancel"
            CostSettings.FillElectricPrice(input.InputData.ElectricPrice, 1);
            CostSettings.ClickCostCancelButton();
            TimeManager.ShortPause();
            Assert.IsFalse(CostSettings.IsCostSaveButtonDisplayed());
            Assert.IsFalse(CostSettings.IsCostCancelButtonDisplayed());
            Assert.IsTrue(CostSettings.IsCostUpdateButtonDisplayed());

            //verify not modify
            Assert.AreEqual(input.ExpectedData.ElectricPrice, CostSettings.GetElectricPriceValue(1));

            //modify again and save
            //Click "修改" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Modify value and "Save"
            CostSettings.FillElectricPrice(input.InputData.ElectricPrice, 1);
            CostSettings.ClickCostSaveButton();
            TimeManager.LongPause();
            Assert.IsFalse(CostSettings.IsCostSaveButtonDisplayed());
            Assert.IsFalse(CostSettings.IsCostCancelButtonDisplayed());
            Assert.IsTrue(CostSettings.IsCostUpdateButtonDisplayed());

            //verify modify
            Assert.AreEqual(input.InputData.ElectricPrice, CostSettings.GetElectricPriceValue(1));
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Modify-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(ElectricityComprehensiveCostData[]), typeof(ModifyElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Modify-101-3")]
        public void ModifyPriceModeToComp(ElectricityComprehensiveCostData input)
        {
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Update();
            TimeManager.MediumPause();

            //Click "修改" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Modify valid value
            CostSettings.SelectElectricPriceMode(input.InputData.PriceMode, 2);
            TimeManager.ShortPause();
            CostSettings.SelectDemandCostType(input.InputData.DemandCostType, 2);
            CostSettings.FillElectricTransformerCapacity(input.InputData.TransformerCapacity, 2);
            CostSettings.FillElectricTransformerPrice(input.InputData.TransformerPrice, 2);
            CostSettings.SelectTouTariffId(input.InputData.TouTariffId, 2);
            CostSettings.SelectFactorType(input.InputData.FactorType, 2);
            CostSettings.SelectRealTagId(input.InputData.RealTagId, 2);
            CostSettings.SelectReactiveTagId(input.InputData.ReactiveTagId, 2);
            CostSettings.FillElectricPaddingCost(input.InputData.ElectricPaddingCost, 2);

            //Click "Save" button
            CostSettings.ClickCostSaveButton();
            TimeManager.LongPause();

            //Verify added successful and padding cost not displayed
            Assert.AreEqual(input.ExpectedData.PriceMode, CostSettings.GetElectricPriceMode(2));
            Assert.AreEqual(input.ExpectedData.DemandCostType, CostSettings.GetDemandCostTypeValue(2));
            Assert.AreEqual(input.ExpectedData.TransformerCapacity, CostSettings.GetElectricTransformerCapacityValue(2));
            Assert.AreEqual(input.ExpectedData.TransformerPrice, CostSettings.GetElectricTransformerPriceValue(2));
            Assert.AreEqual(input.ExpectedData.TouTariffId, CostSettings.GetTouTariffIdValue(2));
            Assert.AreEqual(input.ExpectedData.FactorType, CostSettings.GetFactorTypeValue(2));
            Assert.AreEqual(input.ExpectedData.RealTagId, CostSettings.GetRealTagIdValue(2));
            Assert.AreEqual(input.ExpectedData.ReactiveTagId, CostSettings.GetReactiveTagIdValue(2));
            Assert.AreEqual(input.ExpectedData.ElectricPaddingCost, CostSettings.GetElectricPaddingCostValue(2));
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Modify-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(ElectricityComprehensiveCostData[]), typeof(ModifyElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Modify-101-4")]
        public void ModifyDemandCost(ElectricityComprehensiveCostData input)
        {
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Update();
            TimeManager.MediumPause();

            //Click "修改" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Modify valid TransformerCapacity and TransformerPrice value
            CostSettings.FillElectricTransformerCapacity(input.InputData.TransformerCapacity, 1);
            CostSettings.FillElectricTransformerPrice(input.InputData.TransformerPrice, 1);

            //Click "Save" button
            CostSettings.ClickCostSaveButton();
            TimeManager.LongPause();

            //Verify modify successful
            Assert.AreEqual(input.ExpectedData.TransformerCapacity, CostSettings.GetElectricTransformerCapacityValue(1));
            Assert.AreEqual(input.ExpectedData.TransformerPrice, CostSettings.GetElectricTransformerPriceValue(1));

            //Click "修改" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Modify value 
            CostSettings.SelectDemandCostType(input.InputData.DemandCostType, 2);
            CostSettings.SelectHourTagId(input.InputData.HourTagId, 2);
            CostSettings.FillElectricHourPrice(input.InputData.ElectricHourPrice, 2);
            CostSettings.SelectTouTariffId(input.InputData.TouTariffId, 2);
            CostSettings.SelectFactorType(input.InputData.FactorType, 2);
            CostSettings.SelectRealTagId(input.InputData.RealTagId, 2);
            CostSettings.SelectReactiveTagId(input.InputData.ReactiveTagId, 2);
            CostSettings.FillElectricPaddingCost(input.InputData.ElectricPaddingCost, 2);

            //Click "Save" button
            CostSettings.ClickCostSaveButton();
            TimeManager.LongPause();

            //Verify 
            Assert.AreEqual(input.ExpectedData.PriceMode, CostSettings.GetElectricPriceMode(2));
            Assert.AreEqual(input.ExpectedData.DemandCostType, CostSettings.GetDemandCostTypeValue(2));
            Assert.AreEqual(input.ExpectedData.HourTagId, CostSettings.GetHourTagIdValue(2));
            Assert.AreEqual(input.ExpectedData.ElectricHourPrice, CostSettings.GetElectricHourPriceValue(2));
            Assert.AreEqual(input.ExpectedData.TouTariffId, CostSettings.GetTouTariffIdValue(2));
            Assert.AreEqual(input.ExpectedData.FactorType, CostSettings.GetFactorTypeValue(2));
            Assert.AreEqual(input.ExpectedData.RealTagId, CostSettings.GetRealTagIdValue(2));
            Assert.AreEqual(input.ExpectedData.ReactiveTagId, CostSettings.GetReactiveTagIdValue(2));
            Assert.IsFalse(CostSettings.IsPaddingCostDisplayed(2));
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Modify-101-5")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(ElectricityComprehensiveCostData[]), typeof(ModifyElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Modify-101-5")]
        public void ModifyToDeleteCancel(ElectricityComprehensiveCostData input)
        {
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Update();
            TimeManager.MediumPause();

            //Click "修改" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //delete items and cancel
            CostSettings.ClickCostDeleteButton(2);
            CostSettings.ClickCostDeleteButton(1);

            //Verify all items are deleted
            Assert.AreEqual(0, CostSettings.GetElectricCostItemsNumber());

            //Click "Cancel" button
            CostSettings.ClickCostCancelButton();
            TimeManager.ShortPause();

            //Verify all items are deleted
            Assert.AreEqual(2, CostSettings.GetElectricCostItemsNumber());
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Modify-101-6")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(ElectricityComprehensiveCostData[]), typeof(ModifyElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Modify-101-6")]
        public void ModifyToDeleteAll(ElectricityComprehensiveCostData input)
        {
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Update();
            TimeManager.MediumPause();

            //Click "修改" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //delete all tems and save
            CostSettings.ClickCostDeleteButton(2);
            CostSettings.ClickCostDeleteButton(1);

            //Click "Save" button
            CostSettings.ClickCostSaveButton();
            TimeManager.LongPause();

            //Verify all items are deleted
            Assert.IsTrue(CostSettings.IsCostCreateButtonDisplayed());
        }
    }
}
