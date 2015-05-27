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
    [CreateTime("2013-06-17")]
    [ManualCaseID("TC-J1-FVT-CostConfiguration-Other-Modify")]
    public class ModifyOtherCostPropertySuite : TestSuiteBase
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
        [Category("P2_Emma")]
        [CaseID("TC-J1-FVT-CostConfiguration-Other-Modify-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(OtherCostData[]), typeof(ModifyOtherCostPropertySuite), "TC-J1-FVT-CostConfiguration-Other-Modify-101-1")]
        public void ModifyThenSave(OtherCostData input)
        {
            //Select buidling node "AddPeopleProperty"
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Update();
            TimeManager.ShortPause();

            //Click "修改" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //input dup date
            OtherCostSettings.FillInWaterDate_N("2013-01", 2);
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

        [Test]
        [Category("P4_Emma")]
        [CaseID("TC-J1-FVT-CostConfiguration-Other-Modify-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(OtherCostData[]), typeof(ModifyOtherCostPropertySuite), "TC-J1-FVT-CostConfiguration-Other-Modify-101-2")]
        public void ModifyCancelThenSave(OtherCostData input)
        {
            //Select buidling node "AddPeopleProperty"
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Update();
            TimeManager.ShortPause();

            //Click "修改" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Input dup date
            OtherCostSettings.FillWaterCost_N(input.InputData, 2);
            TimeManager.ShortPause();

            //Cancel
            CostSettings.ClickCostCancelButton();
            TimeManager.MediumPause();

            //Verify the cost is displayed correctly
            Assert.AreEqual(input.ExpectedData.EffectiveDate, OtherCostSettings.GetWaterDateValue(2));
            Assert.AreEqual(input.ExpectedData.Price, OtherCostSettings.GetWaterCostValue(2));

            //Click "修改" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

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

        [Test]
        [Category("P4_Emma")]
        [CaseID("TC-J1-FVT-CostConfiguration-Other-Modify-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(OtherCostData[]), typeof(ModifyOtherCostPropertySuite), "TC-J1-FVT-CostConfiguration-Other-Modify-101-4")]
        public void ModifyToDeleteCancel(OtherCostData input)
        {
            //Select buidling node "AddPeopleProperty"
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Update();
            TimeManager.ShortPause();

            //Click "修改" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Delete all the cost value and cancel
            OtherCostSettings.ClickWaterDeleteButton(3);
            OtherCostSettings.ClickWaterDeleteButton(2);
            TimeManager.ShortPause();

            //Cancel
            CostSettings.ClickCostCancelButton();
            TimeManager.MediumPause();

            //Verify the cost is not deleted and displayed correctly
            Assert.AreEqual(input.ExpectedData.CostDateValue[0].Date, OtherCostSettings.GetWaterDateValue(2));
            Assert.AreEqual(input.ExpectedData.CostDateValue[0].Value, OtherCostSettings.GetWaterCostValue(2));
            Assert.AreEqual(input.ExpectedData.CostDateValue[1].Date, OtherCostSettings.GetWaterDateValue(3));
            Assert.AreEqual(input.ExpectedData.CostDateValue[1].Value, OtherCostSettings.GetWaterCostValue(3));
        }

        [Test]
        [Category("P3_Emma")]
        [CaseID("TC-J1-FVT-CostConfiguration-Other-Modify-101-5")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(OtherCostData[]), typeof(ModifyOtherCostPropertySuite), "TC-J1-FVT-CostConfiguration-Other-Modify-101-5")]
        public void ModifyToDeleteAll(OtherCostData input)
        {
            //Select buidling node "AddPeopleProperty"
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton_Update();
            TimeManager.ShortPause();

            //Click "修改" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Delete one cost value and save
            OtherCostSettings.ClickWaterDeleteButton(3);
            TimeManager.ShortPause();

            //Save
            CostSettings.ClickCostSaveButton();
            TimeManager.LongPause();

            //Verify the cost is deleted and the left displayed correctly
            Assert.AreEqual(input.ExpectedData.EffectiveDate, OtherCostSettings.GetWaterDateValue(2));
            Assert.AreEqual(input.ExpectedData.Price, OtherCostSettings.GetWaterCostValue(2));

            //Click "修改" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Delete all cost value and save
            OtherCostSettings.ClickWaterDeleteButton(2);
            TimeManager.ShortPause();

            //Save
            CostSettings.ClickCostSaveButton();
            TimeManager.LongPause();

            //"+成本属性" button displayed
            Assert.IsTrue(CostSettings.IsCostCreateButtonDisplayed());
        }
    }
}
