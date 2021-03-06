﻿using System;
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
    //[Category("P4_Emma")]
    [ManualCaseID("TC-J1-FVT-SelectHierarchyNodesForRanking-101"), CreateTime("2013-10-17"), Owner("Greenie")]
    public class SelectHierarchyNodesForRanking : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            CorporateRanking.RankingCaseSetUp();
        }

        [TearDown]
        public void CaseTearDown()
        {
            CorporateRanking.RankingCaseTearDown();
        }

        private static RankPanel CorporateRanking = JazzFunction.RankPanel;
        private static UnitKPIPanel UnitIndicator = JazzFunction.UnitKPIPanel;
        private static  RatioPanel RatioIndicator= JazzFunction.RatioPanel;

        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        
        [Test]
        [CaseID("TC-J1-FVT-SelectHierarchyNodesForRanking-101-1")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(SelectHierarchyNodesForRanking), "TC-J1-FVT-SelectHierarchyNodesForRanking-101-1")]
        public void SelectHierarchyNodesForCoperateRanking(CorporateRankingData input)
        {
            CorporateRanking.ClickSelectHierarchyButton();
            TimeManager.LongPause();
            //Click Hierarchy Node Selector. ‘清空’ button is available since no any nodes selected.    
            Assert.IsFalse(CorporateRanking.IsClearHiearchyButtonEnabled());

            //•  Customer node is disabled for selection.  

            //•  Check the hierarchy node in checkbox.Uncheck one hierarchy node.
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            Assert.IsTrue(CorporateRanking.IsHierarchyNodeChecked(input.InputData.Hierarchies[0].Last()));
            CorporateRanking.OnlyUnCheckHierarchyNode(input.InputData.Hierarchies[0]);
            Assert.IsFalse(CorporateRanking.IsHierarchyNodeChecked(input.InputData.Hierarchies[0].Last()));
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            //Click '确定' button.
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //•  Display Total Consumption and all available Commodities under all selected hierarchy nodes with Radio Button.
            Assert.IsTrue(CorporateRanking.IsCommodityOnRankingPanel(input.InputData.commodityNames[0]));
            Assert.IsTrue(CorporateRanking.IsCommodityOnRankingPanel(input.InputData.commodityNames[1]));
            //Click Hierarchy Node Selector again.
            //•  Checkboxes of selected hierarchy nodes are displayed as checked.Other checkboxes are displayed as are unchecked.
            CorporateRanking.ClickSelectHierarchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            Assert.IsTrue(CorporateRanking.IsHierarchyNodeChecked(input.InputData.Hierarchies[0].Last()));
            Assert.IsFalse(CorporateRanking.IsHierarchyNodeChecked(input.InputData.Hierarchies[0][1]));

            //Click '清空' button.
            CorporateRanking.ClickClearHiearchyButton();
            //•  All hierarchy nodes are unchecked.The popup of hierarchy tree is still displayed.
            Assert.IsFalse(CorporateRanking.IsHierarchyNodeChecked(input.InputData.Hierarchies[0].Last()));

            //Click '确定' button.
            //•  The hierarchy tree is hidden.NO Total Consumption option and NO Commodities options displayed.
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-SelectHierarchyNodesForRanking-101-2")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(SelectHierarchyNodesForRanking), "TC-J1-FVT-SelectHierarchyNodesForRanking-101-2")]
        public void SelectFunctionType(CorporateRankingData input)
        {
            //Navigate to Energy Consumption Unit  (单位能耗指标) module.Click Function Type button.
            UnitIndicator.NavigateToUnitIndicator();
            TimeManager.LongPause();
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            TimeManager.LongPause();
            //Options 'Energy Consumption','Carbon Emission' and 'Cost' are displayed in dropdown list.
            //Selected option is Highlighted. 'Energy Consumption' is selected by default.
            //Select ‘Energy Consumption’ option.Display Hierarchy Mode button (SingleHierarchyNode is selected by default).
            //Display Hierarchy Tree Selector.Display tag selector which support tags under hierarchy node, system node, and area node.

            Assert.AreEqual(EnergyViewToolbar.GetFuncModeConvertTargetText(),input.ExpectedData.FuncModeConvertTargetTexts[0]);
            UnitIndicator.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.LongPause();
            Assert.AreEqual(EnergyViewToolbar.GetFuncModeConvertTargetText(), input.ExpectedData.FuncModeConvertTargetTexts[1]);
            //Select ‘Carbon Emission’ option.•  Display Hierarchy Tree Selector.
            //•  Display Commodity selector which only support commodity under hierarchy node--电，自来水
            UnitIndicator.SelectSingleCommodityUnitCarbon(input.InputData.commodityNames[0]);
            UnitIndicator.SelectSingleCommodityUnitCarbon(input.InputData.commodityNames[1]);

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            Assert.AreEqual(EnergyViewToolbar.GetFuncModeConvertTargetText(), input.ExpectedData.FuncModeConvertTargetTexts[2]);
            UnitIndicator.SelectSingleCommodityUnitCost(input.InputData.commodityNames[0]);
            UnitIndicator.SelectSingleCommodityUnitCost(input.InputData.commodityNames[1]);

            // Chart is not redrawn when switching the function type option.which no chart at all.s
            Assert.IsTrue(CorporateRanking.EntirelyNoChartDrawn());


            //Select ‘Cost’ option.•  Display Hierarchy Tree Selector.
            //•  Display Commodity selector which support commodity under hierarchy node, system node, and area node.
            UnitIndicator.SwitchTagTab(TagTabs.AreaDimensionTab);
            TimeManager.ShortPause();
            UnitIndicator.SelectAreaDimension(input.InputData.AreaDimensionPath);
            TimeManager.MediumPause();
            UnitIndicator.SelectSingleCommodityUnitCost(input.InputData.commodityNames[0]);
            
            //Navigate to Energy Ratio Indicator (时段能耗比) module.
            RatioIndicator.NavigateToRatio();
            TimeManager.MediumPause();

            //•  No function type dropdown list.•  Display Hierarchy Mode button (SingleHierarchyNode is selected by default).
            //•  Display Hierarchy Tree Selector.
            //•  Display tag selector which support commodity under hierarchy node, system node, and area node.


            //Navigate to Corporate Ranking (集团排名) module.•  Successfully navigate to the module.
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();

            //Click Function Type button.
            //•  Options 'Energy Consumption', 'Carbon Emission' and 'Cost' are displayed in dropdown list.
            //•  Selected option is Highlighted.
            //•  'Energy Consumption' is selected by default.

            //Select ‘Energy Consumption’ option.•  Display Hierarchy Tree Selector.
            //Display Commodity selector which support commodity under hierarchy node, system node, and area node..
            Assert.AreEqual(EnergyViewToolbar.GetFuncModeConvertTargetText(), input.ExpectedData.FuncModeConvertTargetTexts[0]);
            CorporateRanking.ClickSelectHierarchyButton();
            TimeManager.LongPause();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[1]);

            //Select ‘Carbon Emission’ option.
            //•  Display Hierarchy Tree Selector.
            //•  Display Commodity selector which only support commodity under hierarchy node.
            //•  Display Carbon Emission Type selector.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.LongPause();
            Assert.AreEqual(EnergyViewToolbar.GetFuncModeConvertTargetText(), input.ExpectedData.FuncModeConvertTargetTexts[1]);
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[1]);

            //Select ‘Cost’ option.•  Display Hierarchy Tree Selector.
            //•  Display Commodity selector which only support commodity under hierarchy node and system node (without area node).
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            Assert.AreEqual(EnergyViewToolbar.GetFuncModeConvertTargetText(), input.ExpectedData.FuncModeConvertTargetTexts[2]);
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[1]);     
        }

        [Test]
        [CaseID("TC-J1-FVT-SelectHierarchyNodesForRanking-101-3")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(SelectHierarchyNodesForRanking), "TC-J1-FVT-SelectHierarchyNodesForRanking-101-3")]
        public void SelectCarbonEmissionType(CorporateRankingData input)
        {
            //Navigate to Energy Consumption Unit Indicator(单位能耗指标) module.•  Successfully navigate to the module.
            UnitIndicator.NavigateToUnitIndicator();
            TimeManager.LongPause();

            //Select ‘Carbon Emission’ option from 'Function Type'.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.LongPause();

            //Click Carbon Consumption Type dropdown list.
            //•  Display options as 'Standard Coal Consumption', 'CO2 Emission' and 'Tree Consumption' in dropdown list.
            //•  'Standard Coal Consumption' option is selected by default.
            //•  Current selected option should be highlighted.
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.StandardCoal);
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.CO2);
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.Tree);
            //Select one option.•  Set consumption type as selected option.

            //Navigate to Corporate Ranking (集团排名) module.•  Successfully navigate to the module.
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();

            //Repeat steps as above.•  Carbon Consumption Type can be selected correctly.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.LongPause();

            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.StandardCoal);
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.CO2);
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.Tree);
        }

        [Test]
        [CaseID("TC-J1-FVT-SelectHierarchyNodesForRanking-101-4")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(SelectHierarchyNodesForRanking), "TC-J1-FVT-SelectHierarchyNodesForRanking-101-4")]
        public void SelectUnitIndicatorType(CorporateRankingData input)
        {
            //Navigate to Energy Consumption Unit Indicator(单位能耗指标) module.•  Successfully navigate to the module.
            UnitIndicator.NavigateToUnitIndicator();
            TimeManager.LongPause();

            //Click Indicator Type dropdown list.
            //•  Display options as Unit Person, Unit Total Area, Unit Cooling Area, and Unit Heating Area in dropdown list.
            //•  ‘Unit Person’ option is selected by default.
            //Select one option.•  Set indicator type as selected option.
            //•  Current selected option should be highlighted.
            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitArea);
            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitCoolArea);
            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitHeatArea);
            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitPopulation);
        }

        [Test]
        [CaseID("TC-J1-FVT-SelectHierarchyNodesForRanking-101-5")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(SelectHierarchyNodesForRanking), "TC-J1-FVT-SelectHierarchyNodesForRanking-101-5")]
        public void SelectRatioIndicatorType(CorporateRankingData input)
        {
            //Navigate to Energy Ratio Indicator(时段能耗比) module.
            RatioIndicator.NavigateToRatio();
            TimeManager.MediumPause();

            //Click Ratio Type dropdown list.
            //•  Display options as Day/Night Ratio and Workday/NonWorkDay Ratio in dropdown list.
            //•  ‘Day/Night Ratio’ option is selected by default.
            //Select one option.•  Set ratio type as selected option.
            //•  Current selected option should be highlighted.
            EnergyViewToolbar.SelectRadioTypeConvertTarget(RadioTypeConvertTarget.DayNightRadio);
            EnergyViewToolbar.SelectRadioTypeConvertTarget(RadioTypeConvertTarget.WorkNonRadio);
        }

        [Test]
        [CaseID("TC-J1-FVT-SelectHierarchyNodesForRanking-101-6")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(SelectHierarchyNodesForRanking), "TC-J1-FVT-SelectHierarchyNodesForRanking-101-6")]
        public void SelectRankingType(CorporateRankingData input)
        {
            //Navigate to Corporate Ranking (集团排名) module.
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();

            //Click Ranking Type dropdown list.
            //•  Display options as Total Ranking, Unit Person Ranking, Unit Area Ranking, Unit Cooling Area Ranking and Unit Heating Area Ranking.
            //•  ‘Total Ranking’ option is selected by default.
            //Select one option.Set Ranking type as selected option.Current selected option should be highlighted.
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.TotalRank);
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.UnitAreaRank);
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.UnitCoolAreaRank);
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.UnitHeatAreaRank);
        }

    }
}
