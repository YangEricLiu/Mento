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
    [ManualCaseID("TC-J1-FVT-CostUnitIndicator-Calculate-101"), CreateTime("2013-11-14"), Owner("Emma")]
    public class CalculateCostUnitIndicatorSuite : TestSuiteBase
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
        }

        private static UnitKPIPanel UnitKPIPanel = JazzFunction.UnitKPIPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        private static Widget Widget = JazzFunction.Widget;

        [Test]
        [CaseID("TC-J1-FVT-CostUnitIndicator-Calculate-101-1")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(CalculateCostUnitIndicatorSuite), "TC-J1-FVT-CostUnitIndicator-Calculate-101-1")]
        public void CalculateCostUnitIndicator01(UnitIndicatorData input)
        {
            //Go to NancyCostCustomer2. Go to Function Unit indicator. Select the 楼宇A from Hierarchy Tree. Click Function Type button, select Cost, 
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            //Select the 楼宇A/楼宇B from Hierarchy Tree. Click Function Type button, select Cost.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            //then go to 介质单项. Select Commodity=电 to display trend chart; Optional step=hour; Unit=单位人口.
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            //Change manually defined time range to 2012/07/29-2012/08/04.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Select Commodity=水 to display trend chart; Optional step=hour; Unit=单位人口.
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Select Commodity=煤 to display trend chart; Optional step=hour; Unit=单位人口.
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[2]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Go to 介质总览 to display trend chart; Optional step=hour; Unit=单位人口.
            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUnitIndicator-Calculate-101-2")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(CalculateCostUnitIndicatorSuite), "TC-J1-FVT-CostUnitIndicator-Calculate-101-2")]
        public void CalculateCostUnitIndicator02(UnitIndicatorData input)
        {
            //Change Hierarchy list to 组织A->园区A->楼宇B, then go to 介质单项.
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            //Select Commodity=电 to display trend chart; Optional step=hour; Unit=单位人口/单位面积（人口=面积）.
            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitArea);
            TimeManager.ShortPause();
            
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            //Change manually defined time range to 2012/07/29-2012/08/04.
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
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Select Commodity=水 to display trend chart; Optional step=hour; Unit=单位人口/单位面积（人口=面积）.
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Select Commodity=煤 to display trend chart; Optional step=hour; Unit=单位人口/单位面积（人口=面积）.
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[2]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Go to 介质总览 to display trend chart; Optional step=hour; Unit=单位人口/单位面积（人口=面积）.
            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUnitIndicator-Calculate-101-3")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(CalculateCostUnitIndicatorSuite), "TC-J1-FVT-CostUnitIndicator-Calculate-101-3")]
        public void CalculateCostUnitIndicator03(UnitIndicatorData input)
        {
            //Change Hierarchy list to 组织A->园区A, then go to 介质单项.
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            //Change manually defined time range to 2012/07/29-2012/08/04.
            //Select Commodity=电 to display trend chart; Optional step=hour; Unit=单位人口.
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
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Select Commodity=水 to display trend chart; Optional step=hour; Unit=单位人口.
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Select Commodity=煤 to display trend chart; Optional step=hour; Unit=单位人口.
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[2]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Go to 介质总览 to display trend chart; Optional step=hour; Unit=单位人口.
            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUnitIndicator-Calculate-101-4")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(CalculateCostUnitIndicatorSuite), "TC-J1-FVT-CostUnitIndicator-Calculate-101-4")]
        public void CalculateCostUnitIndicator04(UnitIndicatorData input)
        {
            //Change Hierarchy list to 组织A, then go to 介质单项.
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            //Change manually defined time range to 2012/07/29-2012/08/04.
            //Select Commodity=电 to display trend chart; Optional step=hour; Unit=单位人口.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //· Can't display 单位人口 chart(Since that 楼宇C 2012 not defined 人口 and 面积 is Null).
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));
            Assert.IsFalse(UnitKPIPanel.IsTrendChartDrawn());

            //Select Commodity=水 to display trend chart; Optional step=hour; Unit=单位人口.
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //· Can't display 单位人口 chart(Since that 楼宇C 2012 not defined 人口 and 面积 is Null).
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));
            Assert.IsFalse(UnitKPIPanel.IsTrendChartDrawn());

            //Go to 总览 of 组织A.
            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //· Can't display 单位人口 chart(Since that 楼宇C 2012 not defined 人口 and 面积 is Null).
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));
            Assert.IsFalse(UnitKPIPanel.IsTrendChartDrawn());
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUnitIndicator-Calculate-101-5")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(CalculateCostUnitIndicatorSuite), "TC-J1-FVT-CostUnitIndicator-Calculate-101-5")]
        public void CalculateCostUnitIndicator05(UnitIndicatorData input)
        {
            //Change Hierarchy list to Customer is NancyCostCustomer2, then go to 介质单项.
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            //Change manually defined time range to 2012/07/29-2012/08/04.
            //Select Commodity=电 to display trend chart; Optional step=hour; Unit=单位人口.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //· Can't display 单位人口 chart(Since that 楼宇C 2012 not defined 人口 and 面积 is Null).
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));
            Assert.IsFalse(UnitKPIPanel.IsTrendChartDrawn());

            //Go to 总览.
            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //· Can't display 单位人口 chart(Since that 楼宇C 2012 not defined 人口 and 面积 is Null).
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));
            Assert.IsFalse(UnitKPIPanel.IsTrendChartDrawn());
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUnitIndicator-Calculate-101-6")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(CalculateCostUnitIndicatorSuite), "TC-J1-FVT-CostUnitIndicator-Calculate-101-6")]
        public void CalculateCostUnitIndicator06(UnitIndicatorData input)
        {
            //Navigate to Hierarchy list 组织A->园区A->楼宇A, then go to 一层 Area Dimension.
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            UnitKPIPanel.SwitchTagTab(TagTabs.AreaDimensionTab);
            TimeManager.MediumPause();

            UnitKPIPanel.SelectAreaDimension(input.InputData.AreaDimensionPath);
            TimeManager.MediumPause();

            //Select Commodity=电 to display trend chart; Optional step=hour; Unit=单位人口.
            //Change manually defined time range to 2012/07/29-2012/08/04.
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();
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
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Select Commodity=水 to display trend chart; Optional step=hour; Unit=单位人口.
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

            //Select Commodity=煤 to display trend chart; Optional step=hour; Unit=单位人口.
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[2]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

            //Go to 一层 总览.
            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUnitIndicator-Calculate-101-7")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(CalculateCostUnitIndicatorSuite), "TC-J1-FVT-CostUnitIndicator-Calculate-101-7")]
        public void CalculateCostUnitIndicator07(UnitIndicatorData input)
        {
            //Navigate to Hierarchy list 组织A->园区A->楼宇A, then go to 空调 System Dimension.
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            UnitKPIPanel.SwitchTagTab(TagTabs.SystemDimensionTab);
            TimeManager.MediumPause();

            UnitKPIPanel.SelectSystemDimension(input.InputData.SystemDimensionPath);
            TimeManager.MediumPause();

            //Select Commodity=电 to display trend chart; Optional step=hour; Unit=单位人口.
            //Change manually defined time range to 2012/07/29-2012/08/04.
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();
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
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Select Commodity=水 to display trend chart; Optional step=hour; Unit=单位人口.
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

            //Select Commodity=煤 to display trend chart; Optional step=hour; Unit=单位人口.
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[2]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

            //Go to 一层 总览.
            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUnitIndicator-Calculate-101-8")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(CalculateCostUnitIndicatorSuite), "TC-J1-FVT-CostUnitIndicator-Calculate-101-8")]
        public void CalculateCostUnitIndicator08(UnitIndicatorData input)
        {
            //Special calculation. Select the 楼宇A from Hierarchy Tree. Click Function Type button, select Cost, then go to 介质单项.
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            //Change manually defined time range to 2012/07/01-2012/08/31.
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //Select Commodity=电 to display trend chart; Optional step=week; Unit=单位人口.
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Go to 介质总览 to display trend chart; Optional step=Week; Unit=单位人口.
            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUnitIndicator-Calculate-101-9")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(CalculateCostUnitIndicatorSuite), "TC-J1-FVT-CostUnitIndicator-Calculate-101-9")]
        public void CalculateCostUnitIndicator09(UnitIndicatorData input)
        {
            //Special calculation. Select the 园区A from Hierarchy Tree. Click Function Type button, select Cost, then go to 介质单项.
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            //Change manually defined time range to 2012/07/01-2012/08/31.
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //Select Commodity=电 to display trend chart; Optional step=week; Unit=单位人口.
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Select Commodity=水 to display trend chart; Optional step=week; Unit=单位人口.
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Select Commodity=煤 to display trend chart; Optional step=week; Unit=单位人口.
            UnitKPIPanel.UnselectSingleCommodityUnitCost(input.InputData.Commodity[1]);
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[2]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Go to 介质总览 to display trend chart; Optional step=Week; Unit=单位人口.
            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

            //Select 楼宇B-〉空调. Select 总览， select time range 2012/08/01 to 2012/08/02, optional step=hour.To view chart,
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.SwitchTagTab(TagTabs.SystemDimensionTab);
            TimeManager.MediumPause();

            UnitKPIPanel.SelectSystemDimension(input.InputData.SystemDimensionPath);
            TimeManager.MediumPause();

            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.MediumPause();

            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);
        }
    }
}
