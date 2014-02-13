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
        }

        private static UnitKPIPanel UnitKPIPanel = JazzFunction.UnitKPIPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        private static Widget Widget = JazzFunction.Widget;

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

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(4, UnitKPIPanel.GetTrendChartLines());

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
            Assert.AreEqual(2, UnitKPIPanel.GetTrendChartLines());
            Assert.AreEqual(24, UnitKPIPanel.GetTrendChartLinesMarkers());

            //b. 2012/07/01 3:30-2012/07/03 23:30 day
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Hour));

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(2, UnitKPIPanel.GetTrendChartLines());
            Assert.AreEqual(136, UnitKPIPanel.GetTrendChartLinesMarkers());

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(2, UnitKPIPanel.GetTrendChartLines());
            Assert.AreEqual(4, UnitKPIPanel.GetTrendChartLinesMarkers());

            //c. 2012/07/10-2012/08/05 week
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(2, UnitKPIPanel.GetTrendChartLines());
            Assert.AreEqual(52, UnitKPIPanel.GetTrendChartLinesMarkers());

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(2, UnitKPIPanel.GetTrendChartLines());
            Assert.AreEqual(6, UnitKPIPanel.GetTrendChartLinesMarkers());

            //d. 2012/01/01-2012/12/31=lastyear month
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(2, UnitKPIPanel.GetTrendChartLines());
            Assert.AreEqual(8, UnitKPIPanel.GetTrendChartLinesMarkers());

            //e. 2011/01/01-2013/05/30 year
            EnergyViewToolbar.SetDateRange(ManualTimeRange[4].StartDate, ManualTimeRange[4].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(3, UnitKPIPanel.GetTrendChartLines());
            Assert.AreEqual(14, UnitKPIPanel.GetTrendChartLinesMarkers());
        }

        [Test]
        [CaseID("TC-J1-FVT-BenchmarkCostUnitIndicator-View-101-2")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(ViewBenchmarkCostUnitIndicatorSuite), "TC-J1-FVT-BenchmarkCostUnitIndicator-View-101-2")]
        public void ViewBenchmarkCostUnitIndicator02(UnitIndicatorData input)
        {
            //Select multiple Commodities 电+水+煤 from 楼宇 node to display column chart view.
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitArea);
            TimeManager.ShortPause();
            UnitKPIPanel.SelectCommodityUnitCost(input.InputData.Commodity);
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));

            //2012/7/1 to 2013/11/1
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsColumnChartDrawn());
            Assert.AreEqual(3, UnitKPIPanel.GetColumnChartColumns());

            //·2 legand pereach commodity include  成本/单位面积 and 成本(Gray out).
            Assert.IsTrue(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[0].CaculationValue));
            Assert.IsFalse(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[0].OriginalValue));
            Assert.IsTrue(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[1].CaculationValue));
            Assert.IsFalse(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[1].OriginalValue));
            Assert.IsTrue(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[2].CaculationValue));
            Assert.IsFalse(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[2].OriginalValue));

            //Select multiple Commodities 电+水+煤 from 楼宇 Dimension 空调 node to display column chart view.
            UnitKPIPanel.SwitchTagTab(TagTabs.SystemDimensionTab);
            TimeManager.MediumPause();
            UnitKPIPanel.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitArea);
            TimeManager.ShortPause();
            UnitKPIPanel.SelectCommodityUnitCost(input.InputData.Commodity);
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsColumnChartDrawn());
            Assert.AreEqual(3, UnitKPIPanel.GetColumnChartColumns());

            //·2 legand pereach commodity include  成本/单位面积 and 成本(Gray out).
            Assert.IsTrue(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[0].CaculationValue));
            Assert.IsFalse(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[0].OriginalValue));
            Assert.IsTrue(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[1].CaculationValue));
            Assert.IsFalse(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[1].OriginalValue));
            Assert.IsTrue(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[2].CaculationValue));
            Assert.IsFalse(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[2].OriginalValue));
        }

        [Test]
        [CaseID("TC-J1-FVT-BenchmarkCostUnitIndicator-View-101-3")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(ViewBenchmarkCostUnitIndicatorSuite), "TC-J1-FVT-BenchmarkCostUnitIndicator-View-101-3")]
        public void ViewBenchmarkCostUnitIndicator03(UnitIndicatorData input)
        {
            //Go to NancyOtherCustomer3. Go to Function Unit indicator. Select the BuildingCostYearToDay from Hierarchy Tree. Click Function Type button, select Cost.
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

            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.MediumPause();

            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //·Basic chart view display as expected.
            //Emma's notes 2013-11-26, on Jazz 1.4, when there is data before/after the time range will display line, but not only point
            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(1, UnitKPIPanel.GetTrendChartLines());
            Assert.AreEqual(1, UnitKPIPanel.GetTrendChartLinesMarkers());

            //Select the BuildingMissingData from Hierarchy Tree. 
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[2]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //·Basic chart view display as expected.
            Assert.IsFalse(UnitKPIPanel.IsTrendChartDrawn());
        
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            //Select 单项 Commodity=电 to display trend chart view.
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            //Change different time range
            //a. Today/Yesterday
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Today);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(UnitKPIPanel.IsTrendChartDrawn());

            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Yesterday);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(1, UnitKPIPanel.GetTrendChartLines());
            Assert.AreEqual(21, UnitKPIPanel.GetTrendChartLinesMarkers());

            //b. This week/Last week
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisWeek);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(1, UnitKPIPanel.GetTrendChartLines());
            Assert.AreEqual(45, UnitKPIPanel.GetTrendChartLinesMarkers());

            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastWeek);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(1, UnitKPIPanel.GetTrendChartLines());
            Assert.AreEqual(168, UnitKPIPanel.GetTrendChartLinesMarkers());

            //c. This year/Last year
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(1, UnitKPIPanel.GetTrendChartLines());
            Assert.AreEqual(12, UnitKPIPanel.GetTrendChartLinesMarkers());

            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(2, UnitKPIPanel.GetTrendChartLines());
            Assert.AreEqual(14, UnitKPIPanel.GetTrendChartLinesMarkers());

            //自来水, last week, day default, hour display
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastWeek);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(2, UnitKPIPanel.GetTrendChartLines());
            Assert.AreEqual(14, UnitKPIPanel.GetTrendChartLinesMarkers());

            //Click "Save to dashboard"（保存到仪表盘）to save the Trend chart to dashboard. 
            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            
            //On homepage, check the dashboard
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard[0].DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));

            Assert.IsTrue(HomePagePanel.IsTrendChartDrawn(dashboard[0].WigetName));
            Assert.AreEqual(2, HomePagePanel.GetTrendChartLines(dashboard[0].WigetName));
            Assert.AreEqual(14, HomePagePanel.GetTrendChartLinesMarkers(dashboard[0].WigetName));

            //Go to widget maximize view. Change optional step.
            HomePagePanel.MaximizeWidget(dashboard[0].WigetName);
            TimeManager.LongPause();

            Assert.IsTrue(Widget.IsTrendChartDrawn());
            Assert.AreEqual(2, Widget.GetTrendChartLines());
            Assert.AreEqual(14, Widget.GetTrendChartLinesMarkers());

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            TimeManager.LongPause();

            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains("所选数据点不支持\"按小时\"的步长显示，换个步长试试。"));
            Assert.IsTrue(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Hour));
            EnergyAnalysis.ClickStepButtonOnWindow(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));

            Assert.IsTrue(Widget.IsTrendChartDrawn());
            Assert.AreEqual(2, Widget.GetTrendChartLines());
            Assert.AreEqual(14, Widget.GetTrendChartLinesMarkers());

            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();
        }

    }
}
