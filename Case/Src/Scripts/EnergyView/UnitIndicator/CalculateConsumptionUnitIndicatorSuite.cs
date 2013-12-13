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
    [ManualCaseID("TC-J1-FVT-ConsumptionUnitIndicator-Calculate-101"), CreateTime("2013-11-14"), Owner("Emma")]
    public class CalculateConsumptionUnitIndicatorSuite : TestSuiteBase
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

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionUnitIndicator-Calculate-101-1")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(CalculateConsumptionUnitIndicatorSuite), "TC-J1-FVT-ConsumptionUnitIndicator-Calculate-101-1")]
        public void CalculateConsumptionUnitIndicator01(UnitIndicatorData input)
        {
            //Go to NancyCustomer1. Go to Function Unit indicator. Select the BuildingBC from Hierarchy Tree. Click Function Type button, select Energy Consumption.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Select 1 tag V（1）to display trend chart. Change different time range
            UnitKPIPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            //a. 2012/12/31 3:30-2013/01/01 15:30 hour
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //check on data view
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //b. 2012/07/01 3:30-2012/07/03 23:30 day
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //check on data view
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //c. 2012/07/10-2012/08/05 week
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //check on data view
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Select Unit=单位面积 and view data.
            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitArea);
            TimeManager.ShortPause();

            //a. 2012/12/31 3:30-2013/01/01 15:30 hour
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //check on data view
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

            //b. 2012/07/01 3:30-2012/07/03 23:30 day
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //check on data view
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

            //c. 2012/07/10-2012/08/05 week
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //check on data view
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);

            //Select multiple tags V(1) and V(3) from BuildingBC node and Dimension node to display column chart view. Unit=单位人口.
            UnitKPIPanel.SwitchTagTab(TagTabs.SystemDimensionTab);
            TimeManager.MediumPause();
            UnitKPIPanel.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            UnitKPIPanel.CheckTag(input.InputData.tagNames[1]);
            TimeManager.ShortPause();

            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitPopulation);
            TimeManager.ShortPause();

            //d. 2012/01/01-2012/12/31=lastyear month
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //check on data view
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);

            //e. 2011/01/01-2013/05/30 year
            EnergyViewToolbar.SetDateRange(ManualTimeRange[4].StartDate, ManualTimeRange[4].EndDate);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //check on data view
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);

            //Uncheck V(1) to view chart.
            UnitKPIPanel.SwitchTagTab(TagTabs.HierarchyTag);
            TimeManager.LongPause();
            UnitKPIPanel.UncheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //check on data view
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[8], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[8], input.InputData.failedFileName[8]);

            //e. 2011/01/01-2013/05/30 year
            EnergyViewToolbar.SetDateRange(ManualTimeRange[4].StartDate, ManualTimeRange[4].EndDate);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //check on data view
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[9], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[9], input.InputData.failedFileName[9]);

            //Go to NancyOtherCustomer3. Go to Function Unit indicator. Select the BuildingPrecision from Hierarchy Tree. Click Function Type button, select Energy Consumption. Verify precision display for Unit display.
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitArea);
            TimeManager.ShortPause();

            UnitKPIPanel.CheckTag(input.InputData.tagNames[2]);
            UnitKPIPanel.CheckTag(input.InputData.tagNames[3]);

            //2011/01/01-2013/05/30 year
            EnergyViewToolbar.SetDateRange(ManualTimeRange[4].StartDate, ManualTimeRange[4].EndDate);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //check on data view
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[10], DisplayStep.Default);
            TimeManager.MediumPause();
            //UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[10], input.InputData.failedFileName[10]);

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[2]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitPopulation);
            TimeManager.ShortPause();

            UnitKPIPanel.CheckTag(input.InputData.tagNames[4]);

            //2011/01/01-2013/05/30 year
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //check on data view
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[11], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[11], input.InputData.failedFileName[11]);
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionUnitIndicator-Calculate-101-3871")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(CalculateConsumptionUnitIndicatorSuite), "TC-J1-FVT-ConsumptionUnitIndicator-Calculate-101-3871")]
        public void CalculateConsumptionUnitIndicator3871(UnitIndicatorData input)
        {
            //Goto "NancyOtherCustomer3/NancyOtherSite/BuildingRanking2"
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.SwitchTagTab(TagTabs.HierarchyTag);
            TimeManager.MediumPause();

            UnitKPIPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Step is "Month"
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Step is "Year"
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
        }
    }
}

