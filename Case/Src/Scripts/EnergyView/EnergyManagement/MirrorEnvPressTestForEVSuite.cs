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
    [ManualCaseID("TC-J1-FVT-MirrorEnvPressTestForEV-101"), CreateTime("2015-03-19"), Owner("Emma")]
    public class MirrorEnvPressTestForEVSuite : TestSuiteBase
    {
        private static Widget Widget = JazzFunction.Widget;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        private static SaveToDashboardDialog SaveToDs = new SaveToDashboardDialog();
        private static RankPanel CorporateRanking = JazzFunction.RankPanel;
        private static CostPanel CostUsage = JazzFunction.CostPanel;
        private static CarbonUsagePanel CarbonUsage = JazzFunction.CarbonUsagePanel;
        private static RatioPanel RadioPanel = JazzFunction.RatioPanel;
        private static UnitKPIPanel UnitKPIPanel = JazzFunction.UnitKPIPanel;
        private static IndustryLabellingPanel IndustryLabellingPanel = JazzFunction.IndustryLabellingPanel;

        [SetUp]
        public void CaseSetUp()
        {
            HomePagePanel.NavigateToEnergyView();
        }

        [TearDown]
        public void CaseTearDown()
        {
            TimeManager.MediumPause();
        }

        /* Energy Analysis */
        [Test]
        [CaseID("TC-J1-FVT-MirrorEnvPressTestForEV-101-1")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(MirrorEnvPressTestForEVSuite), "TC-J1-FVT-MirrorEnvPressTestForEV-101-1")]
        public void MirrorEnvPressTestForEA(EnergyViewOptionData input)
        {
            //能效分析,单层级
            EnergyAnalysis.NavigateToEnergyAnalysis();

            //A. Select Single Hierarchy node HM 中国/Area01/CN0101
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Check 3 tags
            EnergyAnalysis.CheckTags(input.InputData.TagNames);

            //之前30天, chart
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last30Day);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //之前7天, data sheet
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);        

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //小时步长
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
        }

        /* Carbon */
        [Test]
        [CaseID("TC-J1-FVT-MirrorEnvPressTestForEV-101-2")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(MirrorEnvPressTestForEVSuite), "TC-J1-FVT-MirrorEnvPressTestForEV-101-2")]
        public void MirrorEnvPressTestForCarbon(CarbonUsageData input)
        {
            //碳排放
            CarbonUsage.NavigateToCarbonUsage();

            //A. Select Single Hierarchy node HM 中国/Area01/CN0101
            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);

            //电
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[0]);

            //之前30天, chart
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last30Day);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //之前7天, data sheet
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //小时步长
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
        }

        /* Cost */
        [Test]
        [CaseID("TC-J1-FVT-MirrorEnvPressTestForEV-101-3")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(MirrorEnvPressTestForEVSuite), "TC-J1-FVT-MirrorEnvPressTestForEV-101-3")]
        public void MirrorEnvPressTestForCost(CostUsageData input)
        {
            //成本
            CostUsage.NavigateToCostUsage();

            //A. Select Single Hierarchy node HM 中国/Area01/CN0101
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);

            //电
            CostUsage.SelectCommodity(input.InputData.commodityNames[0]);

            //之前30天, chart
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last30Day);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //之前7天, data sheet
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //小时步长
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
        }

        /* UnitIndicator-Consumption */
        [Test]
        [CaseID("TC-J1-FVT-MirrorEnvPressTestForEV-101-4")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(MirrorEnvPressTestForEVSuite), "TC-J1-FVT-MirrorEnvPressTestForEV-101-4")]
        public void MirrorEnvPressTestForUnitIndicatorConsumption(UnitIndicatorData input)
        {
            //UnitIndicator
            UnitKPIPanel.NavigateToUnitIndicator();

            //A. Select Single Hierarchy node HM 中国/Area01/CN0101
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);

            //tags
            UnitKPIPanel.CheckTags(input.InputData.tagNames);

            //单位面积
            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitArea);

            //之前30天, chart
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last30Day);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //之前7天, data sheet
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //小时步长
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
        }

        /* UnitIndicator-Carbon */
        [Test]
        [CaseID("TC-J1-FVT-MirrorEnvPressTestForEV-101-5")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(MirrorEnvPressTestForEVSuite), "TC-J1-FVT-MirrorEnvPressTestForEV-101-5")]
        public void MirrorEnvPressTestForUnitIndicatorCarbon(UnitIndicatorData input)
        {
            //UnitIndicator
            UnitKPIPanel.NavigateToUnitIndicator();

            //A. Select Single Hierarchy node HM 中国/Area01/CN0101
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);

            //碳排放
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);

            //电
            UnitKPIPanel.SelectSingleCommodityUnitCarbon(input.InputData.Commodity[0]);

            //单位面积
            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitArea);

            //之前30天, chart
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last30Day);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //之前7天, data sheet
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //小时步长
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
        }

        /* UnitIndicator-Cost */
        [Test]
        [CaseID("TC-J1-FVT-MirrorEnvPressTestForEV-101-6")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(MirrorEnvPressTestForEVSuite), "TC-J1-FVT-MirrorEnvPressTestForEV-101-6")]
        public void MirrorEnvPressTestForUnitIndicatorCost(UnitIndicatorData input)
        {
            //UnitIndicator
            UnitKPIPanel.NavigateToUnitIndicator();

            //A. Select Single Hierarchy node HM 中国/Area01/CN0101
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);

            //成本
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);

            //电
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);

            //单位面积
            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitArea);

            //之前30天, chart
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last30Day);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //之前7天, data sheet
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //小时步长
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
        }

        /* Ratio */
        [Test]
        [CaseID("TC-J1-FVT-MirrorEnvPressTestForEV-101-7")]
        [MultipleTestDataSource(typeof(RatioData[]), typeof(MirrorEnvPressTestForEVSuite), "TC-J1-FVT-MirrorEnvPressTestForEV-101-7")]
        public void MirrorEnvPressTestForRatio(RatioData input)
        {
            //Ratio
            RadioPanel.NavigateToRatio();

            //A. Select Single Hierarchy node HM 中国/Area01/CN0101
            RadioPanel.SelectHierarchy(input.InputData.Hierarchies[0]);

            //电
            RadioPanel.CheckTags(input.InputData.tagNames);

            //之前30天, chart
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last30Day);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //之前7天, data sheet
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
        }

        /* Ratio */
        [Test]
        [CaseID("TC-J1-FVT-MirrorEnvPressTestForEV-101-8")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(MirrorEnvPressTestForEVSuite), "TC-J1-FVT-MirrorEnvPressTestForEV-101-8")]
        public void MirrorEnvPressTestForLabelling(IndustryLabellingData input)
        {
            //Labelling
            IndustryLabellingPanel.NavigateToIndustryLabelling();

            //A. Select Single Hierarchy node HM 中国/Area01/CN0101
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[0]);

            //电
            IndustryLabellingPanel.CheckTags(input.InputData.tagNames);
            TimeManager.LongPause();

            //2015全年
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[1].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[1].month);

            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValue);
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[0]);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //2014全年
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
        }

        /* Ranking */
        [Test]
        [CaseID("TC-J1-FVT-MirrorEnvPressTestForEV-101-9")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(MirrorEnvPressTestForEVSuite), "TC-J1-FVT-MirrorEnvPressTestForEV-101-9")]
        public void MirrorEnvPressTestForRanking(CorporateRankingData input)
        {
            CorporateRanking.NavigateToCorporateRanking();

            string[] BuildingNames = { "Area02", "Area03", "Area04", "Area05", "Area06", "Area07", "Area08", "Area09", "Area10", "Area11", "Area12", "Area13", "Area14", "Area15", "Area16", "Area17", "Area18", "Area19", "Area20" };
            int i = 0;
            CorporateRanking.ClickSelectHierarchyButton();
            while (i < 18)
            {
                input.InputData.Hierarchies[0][1] = BuildingNames[i];
                CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
                TimeManager.MediumPause();
                i++;
            }

            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Commodity='电'
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            //之前30天, chart
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last30Day);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //之前7天, data sheet
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
        }
    }
}
