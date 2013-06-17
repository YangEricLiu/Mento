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
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettings);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Other-Add-001-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(OtherCostData[]), typeof(AddOtherCostPropertySuite), "TC-J1-FVT-CostConfiguration-Other-Add-001-1")]
        public void AllEmptyFields(OtherCostData input)
        { 
            //Select buidling node "AddPeopleProperty"
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton();
            TimeManager.MediumPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "水"
            OtherCostSettings.ClickWaterCostCreateButton();
            TimeManager.ShortPause();

            //Input Nothing and save
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //Verify the error message displayed
            Assert.IsTrue(OtherCostSettings.IsWaterEffectiveYearInvalid_N(2));
            Assert.IsTrue(OtherCostSettings.IsWaterPriceInvalid_N(2));
            Assert.IsTrue(OtherCostSettings.IsWaterEffectiveYearInvalidMsgCorrect_N(input.ExpectedData.EffectiveDate, 2));
            Assert.IsTrue(OtherCostSettings.IsWaterPriceInvalidMsgCorrect_N(input.ExpectedData.Price, 2));
        }

        [Test]
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
            CostSettings.ClickCostPropertyTabButton();
            TimeManager.MediumPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "水"
            OtherCostSettings.ClickWaterCostCreateButton();
            OtherCostSettings.FillInWaterPrice_N(input.InputData.DoubleNonNagtiveValue, 2);
            TimeManager.ShortPause();

            //Input Nothing and save
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //Verify the error message displayed
            Assert.IsTrue(OtherCostSettings.IsWaterPriceInvalid_N(2));
            Assert.IsTrue(OtherCostSettings.IsWaterPriceInvalidMsgCorrect_N(input.ExpectedData.DoubleNonNagtiveValue,2));
        }

        [Test]
        [CaseID("TC-J1-FVT-CostConfiguration-Other-Add-001-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(OtherCostData[]), typeof(AddOtherCostPropertySuite), "TC-J1-FVT-CostConfiguration-Other-Add-001-3")]
        public void AddThenCancel(OtherCostData input)
        {
            //Select buidling node "AddPeopleProperty"
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton();
            TimeManager.MediumPause();

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
    }
}
