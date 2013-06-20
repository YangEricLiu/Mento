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
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettings);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
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

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Modify to duplicate date
            CostSettings.SelectElectricEffectiveDate("2012-05", 1);

            //verify that invalid check triggered
            Assert.IsTrue(CostSettings.IsEffectiveDateInvalid(1));
            Assert.IsTrue(CostSettings.IsEffectiveDateInvalidMsgCorrect(input.ExpectedData.EffectiveDate, 1));

            //Can't Save
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();
            Assert.IsTrue(CostSettings.IsCostSaveButtonDisplayed());
            Assert.IsTrue(CostSettings.IsCostCancelButtonDisplayed());

            //Modify to non duplicate date
            CostSettings.SelectElectricEffectiveDate(input.InputData.EffectiveDate, 1);

            //Save successful
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();
            Assert.IsFalse(CostSettings.IsCostSaveButtonDisplayed());
            Assert.IsFalse(CostSettings.IsCostCancelButtonDisplayed());
            Assert.IsFalse(CostSettings.IsCostUpdateButtonDisplayed());
            Assert.AreEqual(input.InputData.EffectiveDate, CostSettings.GetElectricCostEffectiveDateValue(1));
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Add-001-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(ElectricityComprehensiveCostData[]), typeof(ModifyElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Add-001-2")]
        public void AddExceedDate(ElectricityComprehensiveCostData input)
        {
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Create();
            TimeManager.MediumPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "电力" and Add effective date
            CostSettings.ClickElectricCostCreateButton();
            TimeManager.ShortPause();
            CostSettings.SelectElectricEffectiveDate(input.InputData.EffectiveDate, 1);

            //verify that invalid check triggered
            Assert.IsTrue(CostSettings.IsEffectiveDateInvalid(1));
            Assert.IsTrue(CostSettings.IsEffectiveDateInvalidMsgCorrect(input.ExpectedData.EffectiveDate, 1));
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Add-001-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(ElectricfixedCostData[]), typeof(ModifyElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Add-001-3")]
        public void EmptyFieldsForFixed(ElectricfixedCostData input)
        {
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Create();
            TimeManager.MediumPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "电力" and Add effective date
            CostSettings.ClickElectricCostCreateButton();
            TimeManager.ShortPause();

            //click "Save" with nothing input
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //Verify that error message display on effective date 
            Assert.IsTrue(CostSettings.IsEffectiveDateInvalid(1));
            Assert.IsTrue(CostSettings.IsEffectiveDateInvalidMsgCorrect(input.ExpectedData.EffectiveDate, 1));

            //Input valid effective date and click save with price mode empty
            CostSettings.SelectElectricEffectiveDate(input.InputData.EffectiveDate, 1);
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //verify that invalid check triggered
            Assert.IsTrue(CostSettings.IsPriceModeInvalid(1));
            Assert.IsTrue(CostSettings.IsPriceModeInvalidMsgCorrect(input.ExpectedData.PriceMode, 1));

            //Select "固定电价" and leave price empty then click "Save" button
            CostSettings.SelectElectricPriceMode(input.InputData.PriceMode, 1);
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //verify that invalid check triggered
            Assert.IsTrue(CostSettings.IsElectricPriceInvalid(1));
            Assert.IsTrue(CostSettings.IsElectricPriceInvalidMsgCorrect(input.ExpectedData.Price, 1));
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Add-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(ElectricfixedCostData[]), typeof(ModifyElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Add-101-1")]
        public void AddCancelSaveForFixed(ElectricfixedCostData input)
        {
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Create();
            TimeManager.MediumPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "电力" and fill in fixed value
            CostSettings.ClickElectricCostCreateButton();
            TimeManager.ShortPause();
            CostSettings.FillInFixedCost(input.InputData, 1);

            //Click "Cancel" Then check not add
            CostSettings.ClickCostCancelButton();
            TimeManager.ShortPause();

            //verify "+成本属性" button displayed
            Assert.IsTrue(CostSettings.IsCostCreateButtonDisplayed());

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "电力" and fill in fixed value again
            CostSettings.ClickElectricCostCreateButton();
            TimeManager.ShortPause();
            CostSettings.FillInFixedCost(input.InputData, 1);

            //Click "Save" Then check add
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //Verify the input value displayed correct
            Assert.AreEqual(CostSettings.GetElectricCostEffectiveDateValue(1), input.ExpectedData.EffectiveDate);
            Assert.AreEqual(CostSettings.GetElectricPriceMode(1), input.ExpectedData.PriceMode);
            Assert.AreEqual(CostSettings.GetElectricPriceValue(1), input.ExpectedData.Price);
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Add-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(ElectricfixedCostData[]), typeof(ModifyElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Add-101-2")]
        public void AddDupDateReviseForFixed(ElectricfixedCostData input)
        {
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Update();
            TimeManager.MediumPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "电力" and fill in fixed value of duplicate date
            CostSettings.ClickElectricCostCreateButton();
            TimeManager.ShortPause();
            CostSettings.SelectElectricEffectiveDate("2013-01", 1);

            //verify that invalid check triggered
            Assert.IsTrue(CostSettings.IsEffectiveDateInvalid(1));
            Assert.IsTrue(CostSettings.IsEffectiveDateInvalidMsgCorrect(input.ExpectedData.EffectiveDate, 1));
            TimeManager.MediumPause();

            //fill in fixed value again
            CostSettings.FillInFixedCost(input.InputData, 1);

            //Click "Save" Then check add
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //Verify the input value displayed correct
            Assert.AreEqual(CostSettings.GetElectricCostEffectiveDateValue(1), input.InputData.EffectiveDate);
            Assert.AreEqual(CostSettings.GetElectricPriceMode(1), input.InputData.PriceMode);
            Assert.AreEqual(CostSettings.GetElectricPriceValue(1), input.InputData.Price);
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Add-001-5")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(ElectricityComprehensiveCostData[]), typeof(ModifyElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Add-001-5")]
        public void SaveNonInputForComp(ElectricityComprehensiveCostData input)
        {
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Update();
            TimeManager.MediumPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "电力" and select "综合电价"
            CostSettings.ClickElectricCostCreateButton();
            TimeManager.ShortPause();
            CostSettings.SelectElectricEffectiveDate(input.InputData.EffectiveDate, 1);
            CostSettings.SelectElectricPriceMode(input.InputData.PriceMode, 1);

            //Click "Save" button
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //verify that invalid check triggered
            Assert.IsTrue(CostSettings.IsDemandCostTypeInvalid(1));
            Assert.IsTrue(CostSettings.IsDemandCostTypeInvalidMsgCorrect(input.ExpectedData.DemandCostType, 1));
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Add-001-6")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(ElectricityComprehensiveCostData[]), typeof(ModifyElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Add-001-6")]
        public void HierarchySupportCost(ElectricityComprehensiveCostData input)
        {
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            Assert.IsFalse(CostSettings.IsCostPropertyTabButtonEnabled());
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Add-001-7")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(ElectricityComprehensiveCostData[]))]
        public void AddInvalidPriceComp(ElectricityComprehensiveCostData input)
        {
            string[] hierarchyNodePath = { "自动化测试", "AutoSite002", "AutoBuilding002" };
            HierarchySetting.SelectHierarchyNodePath(hierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Create();
            TimeManager.MediumPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "电力" and select "综合电价", then select "变压器容量模式"
            CostSettings.ClickElectricCostCreateButton();
            TimeManager.ShortPause();
            CostSettings.SelectElectricEffectiveDate("2012-09", 1);
            CostSettings.SelectElectricPriceMode("综合电价", 1);
            TimeManager.MediumPause();
            CostSettings.SelectDemandCostType("变压器容量模式", 1);

            //Input invalid value to 3 textfields
            CostSettings.FillElectricTransformerCapacity(input.InputData.DoubleNonNagtiveValue, 1);
            TimeManager.ShortPause();
            CostSettings.FillElectricTransformerPrice(input.InputData.DoubleNonNagtiveValue, 1);
            TimeManager.ShortPause();
            CostSettings.FillElectricPaddingCost(input.InputData.DoubleNonNagtiveValue, 1);
            TimeManager.ShortPause();

            //Click "Save" button
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //verify it's invalid
            Assert.IsTrue(CostSettings.IsElectricTransformerCapacityInvalid(1));
            Assert.IsTrue(CostSettings.IsElectricTransformerCapacityInvalidMsgCorrect(input.ExpectedData.DoubleNonNagtiveValue, 1));
            Assert.IsTrue(CostSettings.IsElectricTransformerPriceInvalid(1));
            Assert.IsTrue(CostSettings.IsElectricTransformerPriceInvalidMsgCorrect(input.ExpectedData.DoubleNonNagtiveValue, 1));
            if (!(input.InputData.DoubleNonNagtiveValue.Contains("erty@#$%中文")))
            {
                Assert.IsTrue(CostSettings.IsElectricPaddingCostInvalid(1));
                Assert.IsTrue(CostSettings.IsElectricPaddingCostInvalidMsgCorrect(input.ExpectedData.DoubleNonNagtiveValue, 1));
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Add-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(ElectricityComprehensiveCostData[]), typeof(ModifyElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Add-101-3")]
        public void AddValidCompMode1(ElectricityComprehensiveCostData input)
        {
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Create();
            TimeManager.MediumPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "电力" and select "综合电价"
            CostSettings.ClickElectricCostCreateButton();
            TimeManager.ShortPause();

            //Fill in valid value
            CostSettings.SelectElectricEffectiveDate(input.InputData.EffectiveDate, 1);
            CostSettings.SelectElectricPriceMode(input.InputData.PriceMode, 1);
            CostSettings.SelectDemandCostType(input.InputData.DemandCostType, 1);
            CostSettings.FillElectricTransformerCapacity(input.InputData.TransformerCapacity, 1);
            CostSettings.FillElectricTransformerPrice(input.InputData.TransformerPrice, 1);
            CostSettings.SelectTouTariffId(input.InputData.TouTariffId, 1);

            //factor link is disabled when not selected, enabled when selected
            Assert.IsTrue(CostSettings.IsFactorDisable(1));
            CostSettings.SelectFactorType(input.InputData.FactorType, 1);
            TimeManager.ShortPause();
            Assert.IsFalse(CostSettings.IsFactorDisable(1));
            CostSettings.ClickFactorLinkButton(1);
            TimeManager.ShortPause();
            Assert.IsTrue(CostSettings.IsFacorWindowDisplayed());
            CostSettings.CloseFactorWindow();
            TimeManager.ShortPause();

            CostSettings.SelectRealTagId(input.InputData.RealTagId, 1);
            CostSettings.SelectReactiveTagId(input.InputData.ReactiveTagId, 1);

            //Click "Save" button
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //Verify added successful and padding cost not displayed
            Assert.AreEqual(input.ExpectedData.EffectiveDate, CostSettings.GetElectricCostEffectiveDateValue(1));
            Assert.AreEqual(input.ExpectedData.PriceMode, CostSettings.GetElectricPriceMode(1));
            Assert.AreEqual(input.ExpectedData.DemandCostType, CostSettings.GetDemandCostTypeValue(1));
            Assert.AreEqual(input.ExpectedData.TransformerCapacity, CostSettings.GetElectricTransformerCapacityValue(1));
            Assert.AreEqual(input.ExpectedData.TransformerPrice, CostSettings.GetElectricTransformerPriceValue(1));
            Assert.AreEqual(input.ExpectedData.FactorType, CostSettings.GetFactorTypeValue(1));
            Assert.AreEqual(input.ExpectedData.RealTagId, CostSettings.GetRealTagIdValue(1));
            Assert.AreEqual(input.ExpectedData.ReactiveTagId, CostSettings.GetReactiveTagIdValue(1));
            Assert.IsFalse(CostSettings.IsPaddingCostDisplayed(1));
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Add-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(ElectricityComprehensiveCostData[]), typeof(ModifyElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Add-101-4")]
        public void AddValidCompMode2(ElectricityComprehensiveCostData input)
        {
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Create();
            TimeManager.MediumPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "电力" and select "综合电价"
            CostSettings.ClickElectricCostCreateButton();
            TimeManager.ShortPause();

            //Fill in valid value
            CostSettings.SelectElectricEffectiveDate(input.InputData.EffectiveDate, 1);
            CostSettings.SelectElectricPriceMode(input.InputData.PriceMode, 1);
            CostSettings.SelectDemandCostType(input.InputData.DemandCostType, 1);
            CostSettings.SelectHourTagId(input.InputData.HourTagId, 1);
            CostSettings.FillElectricHourPrice(input.InputData.ElectricHourPrice, 1);
            CostSettings.SelectTouTariffId(input.InputData.TouTariffId, 1);

            //factor link is disabled when not selected, enabled when selected
            Assert.IsTrue(CostSettings.IsFactorDisable(1));
            CostSettings.SelectFactorType(input.InputData.FactorType, 1);
            TimeManager.ShortPause();
            Assert.IsFalse(CostSettings.IsFactorDisable(1));
            CostSettings.ClickFactorLinkButton(1);
            TimeManager.ShortPause();
            Assert.IsTrue(CostSettings.IsFacorWindowDisplayed());
            CostSettings.CloseFactorWindow();
            TimeManager.ShortPause();

            CostSettings.SelectRealTagId(input.InputData.RealTagId, 1);
            CostSettings.SelectReactiveTagId(input.InputData.ReactiveTagId, 1);
            CostSettings.FillElectricPaddingCost(input.InputData.ElectricPaddingCost, 1);

            //Click "Save" button
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //Verify added successful and padding cost not displayed
            Assert.AreEqual(input.ExpectedData.EffectiveDate, CostSettings.GetElectricCostEffectiveDateValue(1));
            Assert.AreEqual(input.ExpectedData.PriceMode, CostSettings.GetElectricPriceMode(1));
            Assert.AreEqual(input.ExpectedData.DemandCostType, CostSettings.GetDemandCostTypeValue(1));
            Assert.AreEqual(input.ExpectedData.HourTagId, CostSettings.GetHourTagIdValue(1));
            Assert.AreEqual(input.ExpectedData.ElectricHourPrice, CostSettings.GetElectricHourPriceValue(1));
            Assert.AreEqual(input.ExpectedData.FactorType, CostSettings.GetFactorTypeValue(1));
            Assert.AreEqual(input.ExpectedData.RealTagId, CostSettings.GetRealTagIdValue(1));
            Assert.AreEqual(input.ExpectedData.ReactiveTagId, CostSettings.GetReactiveTagIdValue(1));
            Assert.AreEqual(input.ExpectedData.ElectricPaddingCost, CostSettings.GetElectricPaddingCostValue(1));
        }
    }
}
