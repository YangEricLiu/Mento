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

namespace Mento.Script.EnergyView.UnitIndicator
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-BenckmarkCostUnitIndicator-Calculate-101"), CreateTime("2013-12-17"), Owner("Emma")]
    public class BenchmarkCalculateCostUnitIndicatorSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateHome();
            HomePagePanel.ExitJazz();

            JazzFunction.LoginPage.LoginWithOption("SchneiderElectricChina", "P@ssw0rdChina", "NancyCustomer1");
            TimeManager.MediumPause();
        }

        private static UnitKPIPanel UnitKPIPanel = JazzFunction.UnitKPIPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        private static Widget Widget = JazzFunction.Widget;

        [Test]
        [CaseID("TC-J1-FVT-BenckmarkCostUnitIndicator-Calculate-101-1")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(BenchmarkCalculateCostUnitIndicatorSuite), "TC-J1-FVT-BenckmarkCostUnitIndicator-Calculate-101-1")]
        public void BenchmarkCalculateCostUnitIndicator01(UnitIndicatorData input)
        {
            //Select "NancyOtherCustomer3"
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            //Select "NancyOtherCustomer3/NancyOtherSite/BuildingRanking1"
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            // view 行业基准值=全区域全行业, Unit=单位人口， Commodity=电 to view data
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectIndustryConvertTarget(input.InputData.Industry);
            TimeManager.MediumPause();

            //Change manually defined time range to 2013/01/01-2013/12/16.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Time range = 2012-10-10 to 2013-3-15
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
        }

        [Test]
        [CaseID("TC-J1-FVT-BenckmarkCostUnitIndicator-Calculate-101-2")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(BenchmarkCalculateCostUnitIndicatorSuite), "TC-J1-FVT-BenckmarkCostUnitIndicator-Calculate-101-2")]
        public void BenchmarkCalculateCostUnitIndicator02(UnitIndicatorData input)
        {
            //Go to NancyCostCustomer2. Go to Function Unit indicator. 
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            //Select the 楼宇A from Hierarchy Tree. Click Function Type button, select Cost, 行业基准值=严寒地区B区通信营业厅行业 then go to 介质单项.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            //"电"
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectIndustryConvertTarget(input.InputData.Industry);
            TimeManager.MediumPause();

            //Time range is 2012/07/29-2012/08/04
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //"自来水"
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.ShortPause();
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //"煤"
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            TimeManager.ShortPause();
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[2]);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Change Hierarchy list to 组织A->园区A->楼宇B, then go to 介质单项.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            //"电", Select Commodity=电 to display trend chart; Optional step=hour; Unit=单位人口/单位面积（人口=面积）.行业基准值=严寒地区B区机房行业 to view chart.
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectIndustryConvertTarget("严寒地区B区机房");
            TimeManager.MediumPause();

            //"单位面积"
            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitArea);
            TimeManager.MediumPause();

            //Time range is 2012/07/29-2012/08/04
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
        }

        [Test]
        [CaseID("TC-J1-FVT-BenckmarkCostUnitIndicator-Calculate-101-3")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(BenchmarkCalculateCostUnitIndicatorSuite), "TC-J1-FVT-BenckmarkCostUnitIndicator-Calculate-101-3")]
        public void BenchmarkCalculateCostUnitIndicator03(UnitIndicatorData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            //Navigate to Hierarchy list 组织A->园区A->楼宇A, then go to 一层 Area Dimension.行业基准值=严寒地区B区通信营业厅行业 to view chart.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.SwitchTagTab(TagTabs.AreaDimensionTab);
            TimeManager.MediumPause();

            UnitKPIPanel.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            //"电"
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectIndustryConvertTarget(input.InputData.Industry);
            TimeManager.MediumPause();

            //Time range is 2012/07/29-2012/08/04
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //"自来水"
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.ShortPause();
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //"煤"
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            TimeManager.ShortPause();
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[2]);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
        }

        [Test]
        [CaseID("TC-J1-FVT-BenckmarkCostUnitIndicator-Calculate-101-4")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(BenchmarkCalculateCostUnitIndicatorSuite), "TC-J1-FVT-BenckmarkCostUnitIndicator-Calculate-101-4")]
        public void BenchmarkCalculateCostUnitIndicator04(UnitIndicatorData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            //Navigate to Hierarchy list 组织A->园区A->楼宇A, then go to 空调 System Dimension. 行业基准值=严寒地区B区通信营业厅行业 to view chart.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.SwitchTagTab(TagTabs.SystemDimensionTab);
            TimeManager.MediumPause();

            UnitKPIPanel.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            //"电"
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectIndustryConvertTarget(input.InputData.Industry);
            TimeManager.MediumPause();

            //Time range is 2012/07/29-2012/08/04
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //"自来水"
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.ShortPause();
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //"煤"
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            TimeManager.ShortPause();
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[2]);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
        }

        [Test]
        [CaseID("TC-J1-FVT-BenckmarkCostUnitIndicator-Calculate-101-5")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(BenchmarkCalculateCostUnitIndicatorSuite), "TC-J1-FVT-BenckmarkCostUnitIndicator-Calculate-101-5")]
        public void BenchmarkCalculateCostUnitIndicator05(UnitIndicatorData input)
        { 
            //SP1->NancyOtherCustomer3->园区能耗标识-〉BuildingLabelling1. 
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            //"电"
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectIndustryConvertTarget(input.InputData.Industry);
            TimeManager.MediumPause();

            //Time range=2009/01/01 to 2013/12/31.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //Optional step=月.
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Step is "Month"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Step is "Year"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
        }
    }
}
