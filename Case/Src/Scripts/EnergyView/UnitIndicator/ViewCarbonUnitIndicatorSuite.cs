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
    [ManualCaseID("TC-J1-FVT-CarbonUnitIndicator-View-101"), CreateTime("2013-11-13"), Owner("Emma")]
    public class ViewCarbonUnitIndicatorSuite : TestSuiteBase
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
            JazzFunction.Navigator.NavigateHome();
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

        [Test]
        [CaseID("TC-J1-FVT-CarbonUnitIndicator-View-101-1")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(ViewCarbonUnitIndicatorSuite), "TC-J1-FVT-CarbonUnitIndicator-View-101-1")]
        public void ViewCarbonUnitIndicator01(UnitIndicatorData input)
        {
            //Go to NancyCostCustomer2. Go to Function Unit indicator.
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();
            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            //Select one node NancyCostCustomer2/组织A/园区A/楼宇B from Hierarchy Tree. Click Function Type button, select Carbon.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.ShortPause();

            //Select 总览 to display trend chart view.Time range="去年".
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.ShortPause();
            UnitKPIPanel.SelectCommodityUnitCarbon();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(2, UnitKPIPanel.GetTrendChartLines());
            Assert.AreEqual(15, UnitKPIPanel.GetTrendChartLinesMarkers());

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Select Unit=单位面积, set time range=2012/07/01 00:00-2012/07/10 24:00,click to view data.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitArea);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.Line);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsLineLegendItemShown(input.InputData.UnitIndicatorLegend[0].CaculationValue));
            Assert.IsTrue(UnitKPIPanel.IsLineLegendItemShown(input.InputData.UnitIndicatorLegend[0].TargetValue));
            Assert.IsTrue(UnitKPIPanel.IsLineLegendItemShown(input.InputData.UnitIndicatorLegend[0].BaselineValue));
            Assert.IsFalse(UnitKPIPanel.IsLineLegendItemShown(input.InputData.UnitIndicatorLegend[0].OriginalValue));


            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(2, UnitKPIPanel.GetTrendChartLines());
            Assert.AreEqual(4, UnitKPIPanel.GetTrendChartLinesMarkers());

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Select 单项 Commodity=电 to display trend chart view.
            UnitKPIPanel.SelectSingleCommodityUnitCarbon(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.Line);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(2, UnitKPIPanel.GetTrendChartLines());
            Assert.AreEqual(17, UnitKPIPanel.GetTrendChartLinesMarkers());

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

            //Select 楼宇D 单项 Commodity=电 , Unit= 单位人口 to display trend chart view.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitPopulation);
            TimeManager.ShortPause();

            UnitKPIPanel.SelectSingleCommodityUnitCarbon(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            //·Warining message show not defined 单位人口.
            //· Check Commodity=电 and still display Carbon chart.
            EnergyViewToolbar.View(EnergyViewType.Line);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));
            Assert.IsFalse(UnitKPIPanel.IsTrendChartDrawn());

            //Select 楼宇D 总览 , Unit= 单位人口 to display trend chart view.
            UnitKPIPanel.SelectCommodityUnitCarbon();
            TimeManager.MediumPause();

            //·Warining message show not defined 单位人口.
            //· Check Commodity=电 and still display Carbon chart.
            EnergyViewToolbar.View(EnergyViewType.Line);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));
            Assert.IsFalse(UnitKPIPanel.IsTrendChartDrawn());

            //Change different time range, 楼宇B
            //a. 2012/07/01 3:30-2012/07/01 15:30 hour
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectCommodityUnitCarbon();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitArea);
            TimeManager.ShortPause();

            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

            //b. 2012/07/01 3:30-2012/07/03 23:30 day
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);

            //c. 2012/07/10-2012/08/05 week
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);

            //d. 2012/01/01-2012/12/31=lastyear month
            EnergyViewToolbar.SetDateRange(ManualTimeRange[4].StartDate, ManualTimeRange[4].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);

            //e. 2011/01/01-2013/05/30 year
            EnergyViewToolbar.SetDateRange(ManualTimeRange[5].StartDate, ManualTimeRange[5].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[8], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[8], input.InputData.failedFileName[8]);

            //Select multiple Commodities 电+水+煤 from 楼宇A node to display column chart view.
            UnitKPIPanel.SelectCommodityUnitCarbon(input.InputData.Commodity);
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[1]));

            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsColumnChartDrawn());
            Assert.AreEqual(3, UnitKPIPanel.GetColumnChartColumns());

            //·2 legand pereach commodity include  标煤/单位面积 and 标煤(Gray out).
            Assert.IsTrue(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[0].CaculationValue));
            Assert.IsFalse(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[0].OriginalValue));
            Assert.IsTrue(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[1].CaculationValue));
            Assert.IsFalse(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[1].OriginalValue));
            Assert.IsTrue(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[2].CaculationValue));
            Assert.IsFalse(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[2].OriginalValue));

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[9], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[9], input.InputData.failedFileName[9]);
        }

        [Test]
        [CaseID("TC-J1-FVT-CarbonUnitIndicator-View-101-2")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(ViewCarbonUnitIndicatorSuite), "TC-J1-FVT-CarbonUnitIndicator-View-101-2")]
        public void ViewCarbonUnitIndicator02(UnitIndicatorData input)
        {
            //Go to NancyOtherCustomer3. Go to Function Unit indicator. Select the BuildingCostYearToDay from Hierarchy Tree. Click Function Type button, select Carbon.
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();
            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            //Select the BuildingPrecision from Hierarchy Tree. 选择时间是2012/01/01-2012/01/31)
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.ShortPause();
            UnitKPIPanel.SelectCommodityUnitCarbon();
            TimeManager.MediumPause();

            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[2]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Month);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.ShortPause();

            //Select multiple Commodities 电+水+煤 
            UnitKPIPanel.SelectCommodityUnitCarbon(input.InputData.Commodity);
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[1]));

            //Change different time range
            //a. Today/Yesterday
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Today);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.messages[0]));
            EnergyAnalysis.ClickGiveupButtonOnWindow();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(UnitKPIPanel.EntirelyNoChartDrawn());

            UnitKPIPanel.SelectCommodityUnitCarbon(input.InputData.Commodity);
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Yesterday);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.messages[0]));
            EnergyAnalysis.ClickGiveupButtonOnWindow();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(UnitKPIPanel.EntirelyNoChartDrawn());

            //b. This week/Last week
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisWeek);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.messages[0]));
            EnergyAnalysis.ClickGiveupButtonOnWindow();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(UnitKPIPanel.EntirelyNoChartDrawn());

            UnitKPIPanel.SelectCommodityUnitCarbon(input.InputData.Commodity);
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastWeek);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.messages[0]));
            EnergyAnalysis.ClickGiveupButtonOnWindow();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(UnitKPIPanel.EntirelyNoChartDrawn());

            //c. This year/Last year
            UnitKPIPanel.SelectCommodityUnitCarbon(input.InputData.Commodity);
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);
            TimeManager.ShortPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.ShortPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

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

            //Assert.IsTrue(HomePagePanel.CompareMinWidgetDataView("UnitIndicator\\", input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3], dashboard[0].WigetName));

            //Go to widget maximize view. Change optional step.
            HomePagePanel.MaximizeWidget(dashboard[0].WigetName);
            TimeManager.LongPause();

            //Assert.IsTrue(Widget.CompareMaxWidgetDataView("UnitIndicator\\", input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]));

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            TimeManager.LongPause();

            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.messages[1]));
            Assert.IsTrue(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Day));
            EnergyAnalysis.ClickStepButtonOnWindow(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
            //Assert.IsTrue(Widget.CompareMaxWidgetDataView("UnitIndicator\\", input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]));

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            TimeManager.LongPause();

            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.messages[1]));
            Assert.IsTrue(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Day));
            EnergyAnalysis.ClickStepButtonOnWindow(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
            //Assert.IsTrue(Widget.CompareMaxWidgetDataView("UnitIndicator\\", input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]));

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            TimeManager.LongPause();

            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.messages[1]));
            Assert.IsTrue(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Day));
            EnergyAnalysis.ClickStepButtonOnWindow(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
            //Assert.IsTrue(Widget.CompareMaxWidgetDataView("UnitIndicator\\", input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]));

            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-CarbonUnitIndicator-View-101-3")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(ViewCarbonUnitIndicatorSuite), "TC-J1-FVT-CarbonUnitIndicator-View-101-3")]
        public void ViewCarbonUnitIndicator03(UnitIndicatorData input)
        {
            //Go to NancyOtherCustomer3. Go to Function Unit indicator. Select the BuildingCostYearToDay from Hierarchy Tree. 
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();
            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Click Function Type button, select Carbon, Commodity=煤, predefined time range=之前七天 to view chart.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.ShortPause();

            UnitKPIPanel.SelectSingleCommodityUnitCarbon(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.messages[0]));
            EnergyAnalysis.ClickGiveupButtonOnWindow();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(UnitKPIPanel.EntirelyNoChartDrawn());

            //Change time range to 昨天 and check Commodity=水.
            UnitKPIPanel.SelectSingleCommodityUnitCarbon(input.InputData.Commodity[1]);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Yesterday);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.messages[1]));
            EnergyAnalysis.ClickGiveupButtonOnWindow();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(UnitKPIPanel.EntirelyNoChartDrawn());

            //Select the BuildingNoTag from Hierarchy Tree. 
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Select 总览/单项 to display 单位人口.
            UnitKPIPanel.SelectCommodityUnitCarbon();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(UnitKPIPanel.EntirelyNoChartDrawn());
            Assert.IsTrue(UnitKPIPanel.IsCarbonSingleCommodityNotExisted());

            //Go to NancyOtherCustomer3. Go to Function Unit indicator. Select the BuildingCostYearToDay from Hierarchy Tree. Click Function Type button, select Carbon, then go to 介质单项.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Change manually defined time range to 2010/01/01-2013/05/04; Select Commodity=电 ; Optional step=year; Unit=单位人口.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            UnitKPIPanel.SelectSingleCommodityUnitCarbon(input.InputData.Commodity[2]);
            TimeManager.MediumPause();

            //·the part before 2011 November can't display chart since that 单位人口 start from 2011/11=100
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Change manually defined time range to 2011/01/01-2013/05/04; Select Commodity=水 ; Optional step=year; Unit=单位人口.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            UnitKPIPanel.SelectSingleCommodityUnitCarbon(input.InputData.Commodity[1]);
            TimeManager.MediumPause();

            //·the part before 2011 November can't display chart since that 单位人口 start from 2011/11=100
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Switch to 标煤 to CO2 view chart of Commodity=水.
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.CO2);
            TimeManager.MediumPause();

            //·2012 year can display chart of CO2 since that Carbon factor of CO2 to Tree start from 2012.
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Switch to 树 to view chart of Commodity=水.
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.Tree);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

            //Go to 介质总览 to display trend chart; Optional step=year; Unit=单位人口.
            UnitKPIPanel.SelectCommodityUnitCarbon();
            TimeManager.MediumPause();

            //·2012 year can display chart since that Carbon factor of CO2 to Tree start from 201201.
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);
            
            //Select one node NancyCostCustomer2/组织A/园区A/楼宇B from Hierarchy Tree. Select Commodity=电 or 总览, time range 2010/01/01 to 2013/01/01, optional step=year.
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();
            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[2]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.ShortPause();

            UnitKPIPanel.SelectCommodityUnitCarbon();
            TimeManager.MediumPause();

            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //· 2012Y has Carbon data in grid view.
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);

            UnitKPIPanel.SelectSingleCommodityUnitCarbon(input.InputData.Commodity[2]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //· 2012Y has Carbon data in grid view.
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);

        }

        [Test]
        [CaseID("TC-J1-FVT-CarbonUnitIndicator-View-101-3923")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(ViewCarbonUnitIndicatorSuite), "TC-J1-FVT-CarbonUnitIndicator-View-101-3923")]
        public void ViewCarbonUnitIndicator3923(UnitIndicatorData input)
        {
            //1. Go Unit Carbon, go to NancyOtherCustomer3=> BuildingLabeling1->Commodity=天然气.
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();
            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.ShortPause();

            UnitKPIPanel.SelectSingleCommodityUnitCarbon(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            //time range=2013-1-1 to 2013-12-4 to view chat
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            UnitKPIPanel.ClickLegendItem(input.ExpectedData.LegendTexts[0]);
            TimeManager.MediumPause();
            UnitKPIPanel.ClickLegendItem(input.ExpectedData.LegendTexts[0]);
            TimeManager.MediumPause();

            //The chart start from 2013/01 correctly, only display target value
            //so 1 line and 12 markers
            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(1, UnitKPIPanel.GetTrendChartLines());
            Assert.AreEqual(12, UnitKPIPanel.GetTrendChartLinesMarkers());
        }
    }
}
