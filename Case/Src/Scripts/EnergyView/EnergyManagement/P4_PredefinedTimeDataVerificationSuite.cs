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
    public class P4_PredefinedTimeDataVerificationSuite : TestSuiteBase
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

        [Test]
        [CaseID("TC-J1-FVT-PredefinedTimeDataVerification-DataView-101-1")]
        [MultipleTestDataSource(typeof(EnergyViewPredefinedData[]), typeof(P4_PredefinedTimeDataVerificationSuite), "TC-J1-FVT-PredefinedTimeDataVerification-DataView-101-1")]
        public void EnergyAnalysisPredefinedVerification(EnergyViewPredefinedData input)
        {
            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            //Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇A/C"]
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Tags = BAV1Root
            EnergyAnalysis.CheckTags(input.InputData.TagNames);
            TimeManager.ShortPause();

            //Time range = last 7 days
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsLast7DaysDataCorrect(input.ExpectedData.Last7DaysValue));

            //Time range = last month
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsLastMonthDailyDataCorrect(input.ExpectedData.Last7DaysValue));

            //Time range = this year
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.AreEqual(input.ExpectedData.LastMonthValue, EnergyAnalysis.IsLastMonthMonthlyDataCorrect());
        }

        [Test]
        [CaseID("TC-J1-FVT-PredefinedTimeDataVerification-DataView-101-2")]
        [MultipleTestDataSource(typeof(EnergyViewPredefinedData[]), typeof(P4_PredefinedTimeDataVerificationSuite), "TC-J1-FVT-PredefinedTimeDataVerification-DataView-101-2")]
        public void CarbonUsagePredefinedVerification(EnergyViewPredefinedData input)
        {
            CarbonUsage.NavigateToCarbonUsage();
            TimeManager.MediumPause();

            //Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇A/C"]
            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Commodity = Electricity
            CarbonUsage.SelectCommodity(input.InputData.commodityNames);
            TimeManager.ShortPause();

            //Time range = last 7 days
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsLast7DaysDataCorrect(input.ExpectedData.Last7DaysValue));

            //Time range = last month
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsLastMonthDailyDataCorrect(input.ExpectedData.Last7DaysValue));

            //Time range = this year
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.AreEqual(input.ExpectedData.LastMonthValue, EnergyAnalysis.IsLastMonthMonthlyDataCorrect());
        }

        [Test]
        [CaseID("TC-J1-FVT-PredefinedTimeDataVerification-DataView-101-3")]
        [MultipleTestDataSource(typeof(EnergyViewPredefinedData[]), typeof(P4_PredefinedTimeDataVerificationSuite), "TC-J1-FVT-PredefinedTimeDataVerification-DataView-101-3")]
        public void CostUsagePredefinedVerification(EnergyViewPredefinedData input)
        {
            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            //Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇A/C"]
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Commodity = Electricity
            CostUsage.SelectCommodity(input.InputData.commodityNames);
            TimeManager.ShortPause();

            //Time range = last 7 days
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsLast7DaysDataCorrect(input.ExpectedData.Last7DaysValue));

            //Time range = last month
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsLastMonthDailyDataCorrect(input.ExpectedData.Last7DaysValue));

            //Time range = this year
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.AreEqual(input.ExpectedData.LastMonthValue, EnergyAnalysis.IsLastMonthMonthlyDataCorrect());
        }

        [Test]
        [CaseID("TC-J1-FVT-PredefinedTimeDataVerification-DataView-101-4")]
        [MultipleTestDataSource(typeof(EnergyViewPredefinedData[]), typeof(P4_PredefinedTimeDataVerificationSuite), "TC-J1-FVT-PredefinedTimeDataVerification-DataView-101-4")]
        public void UnitIndicatorPredefinedVerification01(EnergyViewPredefinedData input)
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

            //Time range = last 7 days
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsLast7DaysDataCorrect(input.ExpectedData.Last7DaysValue));

            //Time range = last month
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsLastMonthDailyDataCorrect(input.ExpectedData.Last7DaysValue));

            //Time range = this year
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.AreEqual(input.ExpectedData.LastMonthValue, EnergyAnalysis.IsLastMonthMonthlyDataCorrect());
        }

        [Test]
        [CaseID("TC-J1-FVT-PredefinedTimeDataVerification-DataView-101-5")]
        [MultipleTestDataSource(typeof(EnergyViewPredefinedData[]), typeof(P4_PredefinedTimeDataVerificationSuite), "TC-J1-FVT-PredefinedTimeDataVerification-DataView-101-5")]
        public void UnitIndicatorPredefinedVerification02(EnergyViewPredefinedData input)
        {
            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            //Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇A/C"]
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.ShortPause();

            //电
            UnitKPIPanel.SelectSingleCommodityUnitCarbon(input.InputData.commodityNames[0]);
            TimeManager.MediumPause();

            //Time range = last 7 days
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsLast7DaysDataCorrect(input.ExpectedData.Last7DaysValue));

            //Time range = last month
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsLastMonthDailyDataCorrect(input.ExpectedData.Last7DaysValue));

            //Time range = this year
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.AreEqual(input.ExpectedData.LastMonthValue, EnergyAnalysis.IsLastMonthMonthlyDataCorrect());
        }

        [Test]
        [CaseID("TC-J1-FVT-PredefinedTimeDataVerification-DataView-101-6")]
        [MultipleTestDataSource(typeof(EnergyViewPredefinedData[]), typeof(P4_PredefinedTimeDataVerificationSuite), "TC-J1-FVT-PredefinedTimeDataVerification-DataView-101-6")]
        public void UnitIndicatorPredefinedVerification03(EnergyViewPredefinedData input)
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

            //Time range = last 7 days
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsLast7DaysDataCorrect(input.ExpectedData.Last7DaysValue));

            //Time range = last month
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsLastMonthDailyDataCorrect(input.ExpectedData.Last7DaysValue));

            //Time range = this year
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.AreEqual(input.ExpectedData.LastMonthValue, EnergyAnalysis.IsLastMonthMonthlyDataCorrect());
        }

        [Test]
        [CaseID("TC-J1-FVT-PredefinedTimeDataVerification-DataView-101-7")]
        [MultipleTestDataSource(typeof(EnergyViewPredefinedData[]), typeof(P4_PredefinedTimeDataVerificationSuite), "TC-J1-FVT-PredefinedTimeDataVerification-DataView-101-7")]
        public void RatioPredefinedVerification(EnergyViewPredefinedData input)
        {
            RadioPanel.NavigateToRatio();
            TimeManager.MediumPause();

            //Hierarchy = ["NancyCostCustomer2", "组织A", "园区A", "楼宇A/C"]
            RadioPanel.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Tags = BAV1Root
            RadioPanel.CheckTags(input.InputData.TagNames);
            TimeManager.ShortPause();

            //Time range = last 7 days
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsLast7DaysDataCorrect(input.ExpectedData.Last7DaysValue));

            //Time range = last month
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsLastMonthDailyDataCorrect(input.ExpectedData.Last7DaysValue));

            //Time range = this year
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.AreEqual(input.ExpectedData.LastMonthValue, EnergyAnalysis.IsLastMonthMonthlyDataCorrect());
        }

    }
}
