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

namespace Mento.Script.EnergyView.EnergyManagement
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-PredefinedTimeDataVerification-DataView-101"), CreateTime("2014-04-16"), Owner("Emma")]
    public class SmokeTestEnergyViewSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.LongPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static CarbonUsagePanel CarbonUsage = JazzFunction.CarbonUsagePanel;
        private static CostPanel CostUsage = JazzFunction.CostPanel;
        private static RatioPanel RadioPanel = JazzFunction.RatioPanel;
        private static UnitKPIPanel UnitKPIPanel = JazzFunction.UnitKPIPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        private static IndustryLabellingPanel IndustryLabellingPanel = JazzFunction.IndustryLabellingPanel;
        private static RankPanel CorporateRanking = JazzFunction.RankPanel;

        [Test]
        [CaseID("TC-J1-FVT-SmokeTestEnergyView-101-1")]
        [MultipleTestDataSource(typeof(SmokeTestEnergyViewData[]), typeof(SmokeTestEnergyViewSuite), "TC-J1-FVT-SmokeTestEnergyView-101-1")]
        public void SmokeTestEnergyAnalysis(SmokeTestEnergyViewData input)
        {
            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            //Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇A"]
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Tags = BAV1Root
            EnergyAnalysis.CheckTags(input.InputData.TagNames);
            TimeManager.ShortPause();

            //Time range = default
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Chart display correctly
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            //Select multiple tags Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇B"]
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[0].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            ////Tags = BBV1Root
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[0]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.LongPause();

            //Time range = default
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Chart display correctly
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
        }

        [Test]
        [CaseID("TC-J1-FVT-SmokeTestEnergyView-101-2")]
        [MultipleTestDataSource(typeof(SmokeTestEnergyViewData[]), typeof(SmokeTestEnergyViewSuite), "TC-J1-FVT-SmokeTestEnergyView-101-2")]
        public void SmokeTestCarbonUsage(SmokeTestEnergyViewData input)
        {
            CarbonUsage.NavigateToCarbonUsage();
            TimeManager.MediumPause();

            //Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇A"]
            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Commodity = Electricity
            CarbonUsage.SelectCommodity(input.InputData.commodityNames);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CarbonUsage.IsTrendChartDrawn());

            //总览
            CarbonUsage.SelectCommodity();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CarbonUsage.IsTrendChartDrawn());
        }

        [Test]
        [CaseID("TC-J1-FVT-SmokeTestEnergyView-101-3")]
        [MultipleTestDataSource(typeof(SmokeTestEnergyViewData[]), typeof(SmokeTestEnergyViewSuite), "TC-J1-FVT-SmokeTestEnergyView-101-3")]
        public void SmokeTestCostUsage(SmokeTestEnergyViewData input)
        {
            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            //Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇A"]
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Commodity = Electricity
            CostUsage.SelectCommodity(input.InputData.commodityNames);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsTrendChartDrawn());

            //总览
            CostUsage.SelectCommodity();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsTrendChartDrawn());
        }

        [Test]
        [CaseID("TC-J1-FVT-SmokeTestEnergyView-101-4")]
        [MultipleTestDataSource(typeof(SmokeTestEnergyViewData[]), typeof(SmokeTestEnergyViewSuite), "TC-J1-FVT-SmokeTestEnergyView-101-4")]
        public void SmokeTestUnitIndicatorConsumption(SmokeTestEnergyViewData input)
        {
            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            //Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇A/C"]
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Tags = BAV1Root
            UnitKPIPanel.CheckTags(input.InputData.TagNames);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());

            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            //Select multiple tags Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇B"]
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[0].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            //Tags = BBV1Root
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[0]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.LongPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
        }

        [Test]
        [CaseID("TC-J1-FVT-SmokeTestEnergyView-101-5")]
        [MultipleTestDataSource(typeof(SmokeTestEnergyViewData[]), typeof(SmokeTestEnergyViewSuite), "TC-J1-FVT-SmokeTestEnergyView-101-5")]
        public void SmokeTestUnitIndicatorCarbon(SmokeTestEnergyViewData input)
        {
            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            //Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇A"]
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.ShortPause();

            //电
            UnitKPIPanel.SelectSingleCommodityUnitCarbon(input.InputData.commodityNames[0]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());

            //总览
            UnitKPIPanel.SelectCommodityUnitCarbon();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
        }

        [Test]
        [CaseID("TC-J1-FVT-SmokeTestEnergyView-101-6")]
        [MultipleTestDataSource(typeof(SmokeTestEnergyViewData[]), typeof(SmokeTestEnergyViewSuite), "TC-J1-FVT-SmokeTestEnergyView-101-6")]
        public void SmokeTestUnitIndicatorCost(SmokeTestEnergyViewData input)
        {
            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            //Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇A/C"]
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            //电
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.commodityNames[0]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());

            //总览
            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
        }

        [Test]
        [CaseID("TC-J1-FVT-SmokeTestEnergyView-101-7")]
        [MultipleTestDataSource(typeof(SmokeTestEnergyViewData[]), typeof(SmokeTestEnergyViewSuite), "TC-J1-FVT-SmokeTestEnergyView-101-7")]
        public void SmokeTestRatio(SmokeTestEnergyViewData input)
        {
            RadioPanel.NavigateToRatio();
            TimeManager.MediumPause();

            //Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇A"]
            RadioPanel.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Tags = BAV1Root
            RadioPanel.CheckTags(input.InputData.TagNames);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(RadioPanel.IsTrendChartDrawn());

            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            //Select multiple tags Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇B"]
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[0].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            //Tags = BBV1Root
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[0]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.LongPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(RadioPanel.IsTrendChartDrawn());
        }

        [Test]
        [CaseID("TC-J1-FVT-SmokeTestEnergyView-101-8")]
        [MultipleTestDataSource(typeof(SmokeTestEnergyViewData[]), typeof(SmokeTestEnergyViewSuite), "TC-J1-FVT-SmokeTestEnergyView-101-8")]
        public void SmokeTestLabelling(SmokeTestEnergyViewData input)
        {
            //Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇A"]
            IndustryLabellingPanel.NavigateToIndustryLabelling();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Tags = BAV1Root
            IndustryLabellingPanel.CheckTags(input.InputData.TagNames);
            TimeManager.ShortPause();

            //全年
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            //Select multiple tags Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇B"]
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[0].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            //Tags = BBV1Root
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[0]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //全年
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-SmokeTestEnergyView-101-9")]
        [MultipleTestDataSource(typeof(SmokeTestEnergyViewData[]), typeof(SmokeTestEnergyViewSuite), "TC-J1-FVT-SmokeTestEnergyView-101-9")]
        public void SmokeTestRankingConsumption(SmokeTestEnergyViewData input)
        {
            //Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇A"]
            CorporateRanking.NavigateToCorporateRanking();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);

            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading(10);
            TimeManager.Pause(4000);

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Energy);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //电
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-SmokeTestEnergyView-101-10")]
        [MultipleTestDataSource(typeof(SmokeTestEnergyViewData[]), typeof(SmokeTestEnergyViewSuite), "TC-J1-FVT-SmokeTestEnergyView-101-10")]
        public void SmokeTestRankingCarbon(SmokeTestEnergyViewData input)
        {
            //Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇A"]
            CorporateRanking.NavigateToCorporateRanking();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);

            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading(10);
            TimeManager.Pause(4000);

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //电
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //总览
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[1]);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-SmokeTestEnergyView-101-11")]
        [MultipleTestDataSource(typeof(SmokeTestEnergyViewData[]), typeof(SmokeTestEnergyViewSuite), "TC-J1-FVT-SmokeTestEnergyView-101-11")]
        public void SmokeTestRankingCost(SmokeTestEnergyViewData input)
        {
            //Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇A"]
            CorporateRanking.NavigateToCorporateRanking();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);

            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading(10);
            TimeManager.Pause(4000);

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //电
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //总览
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[1]);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
        }

    }
}
