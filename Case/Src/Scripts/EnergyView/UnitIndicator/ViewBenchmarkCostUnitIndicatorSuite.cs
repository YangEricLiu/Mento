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
    [ManualCaseID("TC-J1-FVT-BenchmarkCostUnitIndicator-View-101"), CreateTime("2013-11-11"), Owner("Emma")]
    public class ViewBenchmarkCostUnitIndicatorSuite : TestSuiteBase
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
            JazzFunction.LoginPage.RefreshJazz("NancyCustomer1");
            TimeManager.LongPause();

            //HomePagePanel.ExitJazz();

            //JazzFunction.LoginPage.LoginWithOption("SchneiderElectricChina", "P@ssw0rdChina", "NancyCustomer1");
            //TimeManager.MediumPause();
        }

        private static UnitKPIPanel UnitKPIPanel = JazzFunction.UnitKPIPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        private static Widget Widget = JazzFunction.Widget;
        private static WidgetMaxChartDialog WidgetMaxChartDlg = JazzFunction.WidgetMaxChartDialog;

        [Test]
        [CaseID("TC-J1-FVT-BenchmarkCostUnitIndicator-View-101-1")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(ViewBenchmarkCostUnitIndicatorSuite), "TC-J1-FVT-BenchmarkCostUnitIndicator-View-101-1")]
        public void ViewBenchmarkCostUnitIndicator01(UnitIndicatorData input)
        {
            //Go to NancyCostCustomer2. Go to Function Unit indicator. 
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            //Select the 楼宇B from Hierarchy Tree. Click Function Type button, select Cost.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            EnergyViewToolbar.SelectIndustryConvertTarget(input.InputData.Industries[0]);
            TimeManager.MediumPause();

            //Select 单项 Commodity=电;行业基准值=严寒地区B区机房to display trend chart view.
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            //· 楼宇B 成本/单位面积 correctly.
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(UnitKPIPanel.IsTrendChartDrawn());

            //Change select 楼宇D 单项 Commodity=电 , Unit= 单位人口 to display Benchmark trend chart view. Select time range="去年"
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitPopulation);
            TimeManager.ShortPause();

            //2013/1/1 to 2013/12/31
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.ShortPause();
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            //·Warining message show not defined 单位人口.
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));

            //Select 楼宇D 空调/一层 总览 , Unit= 单位人口 to display trend chart view.
            UnitKPIPanel.SwitchTagTab(TagTabs.SystemDimensionTab);
            TimeManager.MediumPause();
            UnitKPIPanel.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.MediumPause();

            //·Warining message show not defined 单位人口.
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));

            UnitKPIPanel.SwitchTagTab(TagTabs.AreaDimensionTab);
            TimeManager.MediumPause();
            UnitKPIPanel.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.MediumPause();

            //·Warining message show not defined 单位人口.
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));

            //Select 楼宇A and Commodity=电 to view chart. Change different time range
            UnitKPIPanel.SwitchTagTab(TagTabs.HierarchyTag);
            TimeManager.MediumPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[4]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();      

            //a. 2012/07/01 -2012/07/01  hour
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Hour));

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());

            //b. 2012/07/01 3:30-2012/07/03 23:30 day
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Hour));

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());

            //c. 2012/07/10-2012/08/05 week
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());

            //d. 2012/01/01-2012/12/31=lastyear month
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());

            //e. 2011/01/01-2013/12/31 year
            EnergyViewToolbar.SetDateRange(ManualTimeRange[4].StartDate, ManualTimeRange[4].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
        }

        /*
        [Test]
        [CaseID("TC-J1-FVT-BenchmarkCostUnitIndicator-View-101-2")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(ViewBenchmarkCostUnitIndicatorSuite), "TC-J1-FVT-BenchmarkCostUnitIndicator-View-101-2")]
        public void ViewBenchmarkCostUnitIndicator02(UnitIndicatorData input)
        {
            //nothing
        }
        */

        [Test]
        [CaseID("TC-J1-FVT-BenchmarkCostUnitIndicator-View-101-3")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(ViewBenchmarkCostUnitIndicatorSuite), "TC-J1-FVT-BenchmarkCostUnitIndicator-View-101-3")]
        public void ViewBenchmarkCostUnitIndicator03(UnitIndicatorData input)
        {
            //Go to NancyOtherCustomer3. Go to Function Unit indicator. Select the BuildingPrecision from Hierarchy Tree. Click Function Type button, select Cost.
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();
            
            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            //Select the BuildingPrecision from Hierarchy Tree. 
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            //总览
            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.MediumPause();

            //2013/1/1 to 2013/12/31
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //·Basic chart view display as expected.
            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());

            //Select the BuildingMissingData from Hierarchy Tree. 
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[2]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //·Basic chart view display as expected.
            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());

            //Select the BuildingCostYearToDay from Hierarchy Tree. Click Function Type button, select Cost, , predefined time range=之前七天, 行业基准值=夏热冬冷地区轨道交通行业 to view chart.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            //Select Commodity=煤(Aggregate step=Month) to display trend chart view.
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectRatioIndustryConvertTarget(input.InputData.Industries[0]);
            TimeManager.ShortPause();

            //之前7天
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.messages[0]));
            JazzWindow.WindowMessageInfos.Quit();
            TimeManager.ShortPause();
            Assert.IsTrue(UnitKPIPanel.EntirelyNoChartDrawn());

            //Change time range to 昨天 and check Commodity=水.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Yesterday);
            TimeManager.ShortPause();

            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //· Warning message display show include tag step not support. 
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.messages[1]));
            JazzWindow.WindowMessageInfos.Quit();
            TimeManager.ShortPause();
            Assert.IsTrue(UnitKPIPanel.EntirelyNoChartDrawn());
        }

        [Test]
        [CaseID("TC-J1-FVT-BenchmarkCostUnitIndicator-View-101-4")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(ViewBenchmarkCostUnitIndicatorSuite), "TC-J1-FVT-BenchmarkCostUnitIndicator-View-101-4")]
        public void AllCommoditiesUnitCostBenchmarkView(UnitIndicatorData input)
        {
            //Go to UnitCost function. Navigate to NancyCustomer1 -> 园区测试多层级->BuildingMultipleCommodities.
            HomePagePanel.SelectCustomer("NancyCustomer1");
            TimeManager.ShortPause();
            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.LongPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //select time range=Select time range 2013/12/31 12:00 to 2014/10/31 8:00,
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Select 行业+区域=服装零售寒冷地区. Select 单项->低压蒸汽
            EnergyViewToolbar.SelectIndustryConvertTarget(input.InputData.Industries[0]);
            TimeManager.LongPause();
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.ShortPause();

            //change chart type to data view to view. Optional step=Month.
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Export to excel. Verify the export data value compared with the data view.
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            //Check · The excel value is equal to the data before export.
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Change to select commodity 柴油  to Data view
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            TimeManager.ShortPause();

            //Select time range 上周
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastWeek);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //change chart type to the data view.Optional step=Hour
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Export to excel. Verify the export data value compared with the data view.
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            //Check · The excel value is equal to the data before export.
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Change Commodity= 冷量.
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[2]);
            TimeManager.ShortPause();

            //Change to select time range 上月
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);
            TimeManager.ShortPause();

            //change chart type to trend chart  to view.
            EnergyViewToolbar.View(EnergyViewType.Line);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check ·  There is 1 Benchmark line in trend chart.
            Assert.AreEqual(5, EnergyAnalysis.GetLegendItemTexts().Length);//5 legends include:Calculated,Target,Baseline,Original and Benchmark(Cold region Clothing retail)
            //Assert.AreEqual(2, EnergyAnalysis.GetTrendChartLines());

            //Save to dashboard. Go to dashboard to verify the dashboard chart value.
            var dashboard = input.InputData.DashboardInfo[0];
            EnergyViewToolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);

            //On homepage, check the dashboards
            UnitKPIPanel.NavigateToAllDashBoards();
            HomePagePanel.SelectHierarchyNode(dashboard.HierarchyName);
            TimeManager.MediumPause();
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));

            //Check ·  There is 1 Benchmark line in trend chart.
            HomePagePanel.ClickOnWidget(dashboard.WigetName);
            //Assert.AreEqual(5, WidgetMaxChartDlg.GetLegendItemTexts().Length);//5 legends include:Calculated,Target,Baseline,Original and Benchmark(Cold region Clothing retail)
            //Assert.AreEqual(2, EnergyAnalysis.GetTrendChartLines());
        }
    }
}
