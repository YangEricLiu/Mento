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
    [CreateTime("2013-06-18")]
    [ManualCaseID("TC-J1-FVT-CostConfiguration-Elec-Add")]
    public class AddElecCostPropertySuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Add-001-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(ElectricityComprehensiveCostData[]), typeof(AddElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Add-001-1")]
        public void AddToInputNothing(ElectricityComprehensiveCostData input)
        {
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Create();
            TimeManager.MediumPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Input nothing and save it
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //verify that "+成本属性" button displayed
            Assert.IsTrue(CostSettings.IsCostCreateButtonDisplayed());

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Input nothing and cancel it
            CostSettings.ClickCostCancelButton();
            TimeManager.ShortPause();

            //verify that "+成本属性" button displayed
            Assert.IsTrue(CostSettings.IsCostCreateButtonDisplayed());
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Add-001-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(ElectricityComprehensiveCostData[]), typeof(AddElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Add-001-2")]
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
        [MultipleTestDataSource(typeof(ElectricfixedCostData[]), typeof(AddElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Add-001-3")]
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
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Add-001-4")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(ElectricfixedCostData[]))]
        public void AddInvalidPriceFixed(ElectricfixedCostData input)
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

            //Click "+" before "电力" and Add effective date
            CostSettings.ClickElectricCostCreateButton();
            TimeManager.ShortPause();

            //click "Save" with nothing input
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //Input valid effective date and Select "固定电价" 
            CostSettings.SelectElectricEffectiveDate("2012-09", 1);
            CostSettings.SelectElectricPriceMode("固定电价", 1);
            
            //Input valid price and click "Save" button
            CostSettings.FillElectricPrice(input.InputData.DoubleNonNagtiveValue, 1);
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //verify that invalid check triggered
            Assert.IsTrue(CostSettings.IsElectricPriceInvalid(1));
            Assert.IsTrue(CostSettings.IsElectricPriceInvalidMsgCorrect(input.ExpectedData.DoubleNonNagtiveValue, 1));
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Elec-Add-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(ElectricfixedCostData[]), typeof(AddElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Add-101-1")]
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
        [MultipleTestDataSource(typeof(ElectricfixedCostData[]), typeof(AddElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Add-101-2")]
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
        [MultipleTestDataSource(typeof(ElectricityComprehensiveCostData[]), typeof(AddElecCostPropertySuite), "TC-J1-FVT-CostConfiguration-Elec-Add-001-5")]
        public void SaveNonInputForComp(ElectricityComprehensiveCostData input)
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
            CostSettings.SelectElectricEffectiveDate(input.InputData.EffectiveDate, 1);

            //verify that invalid check triggered
            Assert.IsTrue(CostSettings.IsEffectiveDateInvalid(1));
            Assert.IsTrue(CostSettings.IsEffectiveDateInvalidMsgCorrect(input.ExpectedData.EffectiveDate, 1));
        }
    }
}
