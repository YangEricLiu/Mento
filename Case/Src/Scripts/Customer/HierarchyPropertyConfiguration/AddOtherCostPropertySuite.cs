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
    [CreateTime("2013-06-13")]
    [ManualCaseID("TC-J1-FVT-CostConfiguration-Other-Add")]
    public class AddOtherCostPropertySuite : TestSuiteBase
    {
        private static HierarchySettings HierarchySetting = JazzFunction.HierarchySettings;
        private static HierarchyElectricCostSettings CostSettings = JazzFunction.HierarchyElectricCostSettings;
        private static HierarchyOtherCostPropertySettings OtherCostSettings = JazzFunction.HierarchyOtherCostPropertySettings;

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
        [Category("P4_Emma")]
        [CaseID("TC-J1-FVT-CostConfiguration-Other-Add-001-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(OtherCostData[]), typeof(AddOtherCostPropertySuite), "TC-J1-FVT-CostConfiguration-Other-Add-001-1")]
        public void AllEmptyFields(OtherCostData input)
        { 
            //Select buidling node "AddPeopleProperty"
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Create();
            TimeManager.ShortPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "水"
            OtherCostSettings.ClickWaterCostCreateButton();
            TimeManager.ShortPause();

            //Input Nothing and save
            CostSettings.ClickCostSaveButton();
            TimeManager.LongPause();

            //Verify the error message displayed
            Assert.IsTrue(OtherCostSettings.IsWaterEffectiveYearInvalid_N(2));
            Assert.IsTrue(OtherCostSettings.IsWaterPriceInvalid_N(2));
            Assert.IsTrue(OtherCostSettings.IsWaterEffectiveYearInvalidMsgCorrect_N(input.ExpectedData.EffectiveDate, 2));
            Assert.IsTrue(OtherCostSettings.IsWaterPriceInvalidMsgCorrect_N(input.ExpectedData.Price, 2));
        }

        [Test]
        [Category("P4_Emma")]
        [CaseID("TC-J1-FVT-CostConfiguration-Other-Add-001-2")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(OtherCostData[]))]
        public void AddInvalidCostPrice(OtherCostData input)
        {
            //Select buidling node "AddPeopleProperty"
            string[] hierarchyNodePath = { "自动化测试", "AutoSite002", "AutoBuilding002" };
            HierarchySetting.SelectHierarchyNodePath(hierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Create();
            TimeManager.ShortPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "水"
            OtherCostSettings.ClickWaterCostCreateButton();
            OtherCostSettings.FillInWaterPrice_N(input.InputData.DoubleNonNagtiveValue, 2);
            TimeManager.ShortPause();

            //Input Nothing and save
            CostSettings.ClickCostSaveButton();
            TimeManager.LongPause();

            //Verify the error message displayed
            Assert.IsTrue(OtherCostSettings.IsWaterPriceInvalid_N(2));
            Assert.IsTrue(OtherCostSettings.IsWaterPriceInvalidMsgCorrect_N(input.ExpectedData.DoubleNonNagtiveValue,2));
        }

        [Test]
        [Category("P4_Emma")]
        [CaseID("TC-J1-FVT-CostConfiguration-Other-Add-001-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(OtherCostData[]), typeof(AddOtherCostPropertySuite), "TC-J1-FVT-CostConfiguration-Other-Add-001-3")]
        public void AddThenCancel(OtherCostData input)
        {
            //Select buidling node "AddPeopleProperty"
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Create();
            TimeManager.ShortPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "水"
            OtherCostSettings.ClickWaterCostCreateButton();
            OtherCostSettings.FillWaterCost_N(input.InputData, 2);
            TimeManager.ShortPause();

            //Input Nothing and save
            CostSettings.ClickCostCancelButton();
            TimeManager.MediumPause();

            //Verify "+成本属性" button displayed
            Assert.IsTrue(CostSettings.IsCostCreateButtonDisplayed());
        }

        [Test]
        [Category("P2_Emma")]
        [CaseID("TC-J1-FVT-CostConfiguration-Other-Add-001-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(OtherCostData[]), typeof(AddOtherCostPropertySuite), "TC-J1-FVT-CostConfiguration-Other-Add-001-4")]
        public void AddExceedDate(OtherCostData input)
        {
            //Select buidling node "AddPeopleProperty"
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Create();
            TimeManager.ShortPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "水"
            OtherCostSettings.ClickWaterCostCreateButton();
            OtherCostSettings.FillInWaterDate_N(input.InputData.EffectiveDate, 2);
            TimeManager.ShortPause();

            //Input Nothing and save
            CostSettings.ClickCostSaveButton();
            TimeManager.LongPause();

            //Verify the error message displayed
            Assert.IsTrue(OtherCostSettings.IsWaterEffectiveYearInvalid_N(2));
            Assert.IsTrue(OtherCostSettings.IsWaterEffectiveYearInvalidMsgCorrect_N(input.ExpectedData.EffectiveDate, 2));
        }

        [Test]
        [Category("P2_Emma")]
        [CaseID("TC-J1-FVT-CostConfiguration-Other-Add-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(OtherCostData[]), typeof(AddOtherCostPropertySuite), "TC-J1-FVT-CostConfiguration-Other-Add-101-1")]
        public void AddValidCost(OtherCostData input)
        {
            //Select buidling node "AddPeopleProperty"
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Create();
            TimeManager.ShortPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "水"
            OtherCostSettings.ClickWaterCostCreateButton();
            OtherCostSettings.FillWaterCost_N(input.InputData, 2);
            TimeManager.ShortPause();

            //Input Nothing and save
            CostSettings.ClickCostSaveButton();
            TimeManager.LongPause();

            //Verify the cost is displayed correctly
            Assert.AreEqual(input.ExpectedData.EffectiveDate, OtherCostSettings.GetWaterDateValue(2));
            Assert.AreEqual(input.ExpectedData.Price, OtherCostSettings.GetWaterCostValue(2));
        }

        [Test]
        [Category("P3_Emma")]
        [CaseID("TC-J1-FVT-CostConfiguration-Other-Add-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(OtherCostData[]), typeof(AddOtherCostPropertySuite), "TC-J1-FVT-CostConfiguration-Other-Add-101-2")]
        public void AddDupCostThenRevise(OtherCostData input)
        {
            //Select buidling node "AddPeopleProperty"
            TimeManager.LongPause();
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Update();
            TimeManager.ShortPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "水", and input dup date
            OtherCostSettings.ClickWaterCostCreateButton();
            OtherCostSettings.FillInWaterDate_N("2012-11", 2);
            TimeManager.ShortPause();

            //Verify the error message displayed
            Assert.IsTrue(OtherCostSettings.IsWaterEffectiveYearInvalid_N(2));
            Assert.IsTrue(OtherCostSettings.IsWaterEffectiveYearInvalidMsgCorrect_N(input.ExpectedData.EffectiveDate, 2));

            //Input valid date and value
            OtherCostSettings.FillWaterCost_N(input.InputData, 2);
            TimeManager.ShortPause();

            //Input Nothing and save
            CostSettings.ClickCostSaveButton();
            TimeManager.LongPause();

            //Verify the cost is displayed correctly
            Assert.AreEqual(input.InputData.EffectiveDate, OtherCostSettings.GetWaterDateValue(2));
            Assert.AreEqual(input.InputData.Price, OtherCostSettings.GetWaterCostValue(2));
        }
    }
}
