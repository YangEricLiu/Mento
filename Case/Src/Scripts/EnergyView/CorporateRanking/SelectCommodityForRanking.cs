using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.Library;
using Mento.ScriptCommon.Library.Functions;
using Mento.TestApi.WebUserInterface;
using Mento.Framework.Script;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.ScriptCommon.TestData.EnergyView;
using Mento.TestApi.TestData;
using System.Data;
using Mento.Utility;

namespace Mento.Script.EnergyView.CorporateRanking
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-SelectCommodityForRanking-101"), CreateTime("2013-10-21"), Owner("Greenie")]
    public class SelectCommodityForRanking : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateHome();
        }

        private static RankPanel CorporateRanking = JazzFunction.RankPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [Test]
        [CaseID("TC-J1-FVT-SelectCommodityForRanking-101-1")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(SelectCommodityForRanking), "TC-J1-FVT-SelectCommodityForRanking-101-1")]
        public void SelectCostCommodity(CorporateRankingData input)
        {
            //Click Hierarchy Node Selector to select multiple hierarchy nodes, click 确定.
            CorporateRanking.ClickSelectHierarchyButton();
            TimeManager.LongPause();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(input.ExpectedData.Hierarchies);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Take Cost function type for example to verify below steps.
            //Select 'Cost'  from function type dropdown list.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //•  Display Total Consumption and all available Commodities under all selected hierarchy nodes with Radio Button.
            //•  In default, No any option is selected. 
            //Assert.IsTrue(CorporateRanking.AreCommoditiesOnTheGrid(input.InputData.commodityNames));
            int i = 0;
            while (i < input.InputData.commodityNames.Length)
            {
                Assert.IsTrue(CorporateRanking.IsCommodityOnRankingPanel(input.InputData.commodityNames[i]));
                Assert.IsFalse(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[i]));
                TimeManager.ShortPause();
                i++;
            }

            //Select Total Consumption option.Total Consumption option is checked.Commodity option is unchecked.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            Assert.IsTrue(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[0]));

            //Select Commodity option. This Commodity option is checked. Total Consumption option is unchecked.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[1]);
            Assert.IsFalse(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[0]));
            Assert.IsTrue(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[1]));

            //Click System Dimension tab.Click System Dimension Node Selector.
            CorporateRanking.SwitchSystemDimensionTab();
            TimeManager.ShortPause();
            //CorporateRanking.ClickSelectSystemDimensionButton();
            TimeManager.ShortPause();
            //•  Popup a system dimension tree which contains all available system dimension nodes under all selected hierarchy nodes.
            //•  In default, No any system dimension node is selected.Root node of System Dimension tree cannot be selected.
            //    not finish here
            //Assert.IsTrue(CorporateRanking.IsNodeDisabled(input.InputData.Hierarchies.First()));

            //Select one system dimension node.
            CorporateRanking.SelectSystemDimensionNode(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //•  Display Total Consumption and all available commodities under all selected hierarchy nodes with same dimension node with radio button.
            //•  In default, No any option is selected.
            //CorporateRanking.AreCommoditiesOnTheGrid(input.ExpectedData.commodityNames);
            int j = 0;
            while (j < input.InputData.commodityNames.Length)
            {
                Assert.IsTrue(CorporateRanking.IsCommodityOnRankingPanel(input.InputData.commodityNames[j]));
                TimeManager.ShortPause();
                
                j++;
            }

            Assert.IsFalse(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[0]));
            TimeManager.ShortPause();
            //Assert.IsFalse(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[1]));
            TimeManager.ShortPause();
            Assert.IsFalse(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[2]));
            TimeManager.ShortPause();
            Assert.IsFalse(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[3]));
            TimeManager.LongPause();

            //Select Total Consumption option.
            CorporateRanking.SelectSystemCommodity(input.InputData.commodityNames[0]);

            //•  Total Consumption option is checked.•  Commodity option is unchecked.
            Assert.IsTrue(CorporateRanking.IsSystemCommoditySelected(input.InputData.commodityNames[0]));
            Assert.IsFalse(CorporateRanking.IsSystemCommoditySelected(input.InputData.commodityNames[1]));

            //Select Commodity option.This Commodity option is checked.Total Consumption option is unchecked.
            CorporateRanking.SelectSystemCommodity(input.InputData.commodityNames[1]);
            Assert.IsFalse(CorporateRanking.IsSystemCommoditySelected(input.InputData.commodityNames[0]));
            Assert.IsTrue(CorporateRanking.IsSystemCommoditySelected(input.InputData.commodityNames[1]));
 
        }

        [Test]
        [CaseID("TC-J1-FVT-SelectCommodityForRanking-101-2")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(SelectCommodityForRanking), "TC-J1-FVT-SelectCommodityForRanking-101-2")]
        public void SelectCarbonCommodity(CorporateRankingData input)
        {
            //Click Hierarchy Node Selector to select multiple hierarchy nodes, click 确定.
            CorporateRanking.ClickSelectHierarchyButton();
            TimeManager.LongPause();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(input.ExpectedData.Hierarchies);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //2.Take carbon  function type for example to verify below steps.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //•  Display Total Consumption and all available Commodities under all selected hierarchy nodes with Radio Button.
            //•  In default, No any option is selected. 
            //Assert.IsTrue(CorporateRanking.AreCommoditiesOnTheGrid(input.InputData.commodityNames));

            int k = 0;
            while (k < input.InputData.commodityNames.Length)
            {
                Assert.IsTrue(CorporateRanking.IsCommodityOnRankingPanel(input.InputData.commodityNames[k]));
                TimeManager.ShortPause();
                Assert.IsFalse(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[k]));
                TimeManager.ShortPause();
                k++;
            }

            //Select Total Consumption option.•  Total Consumption option is checked.Commodity option is unchecked.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            Assert.IsTrue(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[0]));

            //Select Commodity option. This Commodity option is checked. Total Consumption option is unchecked.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[1]);
            Assert.IsFalse(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[0]));
            Assert.IsTrue(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[1]));

            //Click System Dimension tab.Click System Dimension Node Selector.
            Assert.IsFalse(CorporateRanking.SwitchSystemDimensionTab());

        }

        [Test]
        [CaseID("TC-J1-FVT-SelectCommodityForRanking-101-3")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(SelectCommodityForRanking), "TC-J1-FVT-SelectCommodityForRanking-101-3")]
        public void SelectEnergyCommodity(CorporateRankingData input)
        {
            //Click Hierarchy Node Selector to select multiple hierarchy nodes, click 确定.
            CorporateRanking.ClickSelectHierarchyButton();
            TimeManager.LongPause();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(input.ExpectedData.Hierarchies);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //3. Repeat above verifications for Energy  function type.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Energy);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //•  Display Total Consumption and all available Commodities under all selected hierarchy nodes with Radio Button.
            //•  In default, No any option is selected. 
            //Assert.IsTrue(CorporateRanking.AreCommoditiesOnTheGrid(input.InputData.commodityNames));
            TimeManager.ShortPause();
            Assert.IsFalse(CorporateRanking.IsCommodityOnRankingPanel(input.InputData.commodityNames[0]));
            Assert.IsTrue(CorporateRanking.IsCommodityOnRankingPanel(input.InputData.commodityNames[1]));
            Assert.IsTrue(CorporateRanking.IsCommodityOnRankingPanel(input.InputData.commodityNames[2]));
            Assert.IsTrue(CorporateRanking.IsCommodityOnRankingPanel(input.InputData.commodityNames[3]));
            Assert.IsFalse(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[1]));
            Assert.IsFalse(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[2]));
            Assert.IsFalse(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[3]));
            TimeManager.ShortPause();

            //Select Total Consumption option.•  Total Consumption option is checked.Commodity option is unchecked.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[1]);
            Assert.IsTrue(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[1]));

            //Select Commodity option. This Commodity option is checked. Total Consumption option is unchecked.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[2]);
            Assert.IsFalse(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[1]));
            Assert.IsTrue(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[2]));

            //Click System Dimension tab.Click System Dimension Node Selector.
            CorporateRanking.SwitchSystemDimensionTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //•  Popup a system dimension tree which contains all available system dimension nodes under all selected hierarchy nodes.
            //•  In default, No any system dimension node is selected.Root node of System Dimension tree cannot be selected.
            //    not finish here
            //Assert.IsTrue(CorporateRanking.IsNodeDisabled(input.InputData.Hierarchies.First()));

            //Select one system dimension node.
            CorporateRanking.SelectSystemDimensionNode(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //•  Display Total Consumption and all available commodities under all selected hierarchy nodes with same dimension node with radio button.
            //•  In default, No any option is selected.
            //CorporateRanking.AreCommoditiesOnTheGrid(input.ExpectedData.commodityNames);
            int l = 1;
            Assert.IsFalse(CorporateRanking.IsCommodityOnRankingPanel(input.InputData.commodityNames[0]));
            Assert.IsFalse(CorporateRanking.IsCommodityOnRankingPanel("准确"));
            while (l < input.InputData.commodityNames.Length)
            {
                Assert.IsTrue(CorporateRanking.IsCommodityOnRankingPanel(input.InputData.commodityNames[l]));
                TimeManager.ShortPause();
                Assert.IsFalse(CorporateRanking.IsSystemCommoditySelected(input.InputData.commodityNames[l]));
                TimeManager.ShortPause();
                l++;
            }
            //Select Total Consumption option.
            CorporateRanking.SelectSystemCommodity(input.InputData.commodityNames[1]);

            //•  Total Consumption option is checked.•  Commodity option is unchecked.
            Assert.IsTrue(CorporateRanking.IsSystemCommoditySelected(input.InputData.commodityNames[1]));
            Assert.IsFalse(CorporateRanking.IsSystemCommoditySelected(input.InputData.commodityNames[2]));

            //Select Commodity option.This Commodity option is checked.•  Total Consumption option is unchecked.
            CorporateRanking.SelectSystemCommodity(input.InputData.commodityNames[2]);
            Assert.IsFalse(CorporateRanking.IsSystemCommoditySelected(input.InputData.commodityNames[1]));
            Assert.IsTrue(CorporateRanking.IsSystemCommoditySelected(input.InputData.commodityNames[2]));
        }
    }
}
