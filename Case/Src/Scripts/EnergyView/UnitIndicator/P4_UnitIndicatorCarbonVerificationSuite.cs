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
    [Category("P4_Emma")]
    [ManualCaseID("TC-J1-FVT-UnitIndicatorCarbonVerification-101"), CreateTime("2013-12-26"), Owner("Emma")]
    public class P4_UnitIndicatorCarbonVerificationSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            UnitKPIPanel.UnitIndicatorCaseSetUp();
        }

        [TearDown]
        public void CaseTearDown()
        {
            UnitKPIPanel.UnitIndicatorCaseTearDown();
        }


        private static UnitKPIPanel UnitKPIPanel = JazzFunction.UnitKPIPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        private static Widget Widget = JazzFunction.Widget;

        [Test]
        [CaseID("TC-J1-FVT-UnitIndicatorCarbonVerification-101-1")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(P4_UnitIndicatorCarbonVerificationSuite), "TC-J1-FVT-UnitIndicatorCarbonVerification-101-1")]
        public void UnitIndicatorCarbonVerification01(UnitIndicatorData input)
        {
            //Select "NancyOtherCustomer3"
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            //Select "NancyOtherCustomer3/NancyOtherSite/BuildingCostYearToDay"
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //select "碳排放"
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.ShortPause();

            //select "标煤"/"二氧化碳"/"树"
            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonType);
            TimeManager.ShortPause();

            //Select "总览"
            UnitKPIPanel.SelectCommodityUnitCarbon();
            TimeManager.MediumPause();

            //Time range = 2012-1-1 to 2013-12-18
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Year"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //"Month"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Select "煤"
            UnitKPIPanel.SelectSingleCommodityUnitCarbon(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            //select Benchmark = "夏热冬冷地区轨道交通"
            EnergyViewToolbar.SelectIndustryConvertTarget(input.InputData.Industry);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Year"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //"Month"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
        }

        [Test]
        [CaseID("TC-J1-FVT-UnitIndicatorCarbonVerification-101-2")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(P4_UnitIndicatorCarbonVerificationSuite), "TC-J1-FVT-UnitIndicatorCarbonVerification-101-2")]
        public void UnitIndicatorCarbonVerification02(UnitIndicatorData input)
        {
            //Select "NancyCostCustomer2"
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            //Select "NancyCostCustomer2/组织A/园区A/楼宇B"
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //select "碳排放"
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.ShortPause();

            //select "标煤"/"二氧化碳"/"树"
            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonType);
            TimeManager.ShortPause();

            //Select "总览"
            UnitKPIPanel.SelectCommodityUnitCarbon();
            TimeManager.MediumPause();
            
            //Time range = 2012-1-1 to 2013-12-18
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            
            //"Year"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //"Month"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //"Week"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
            
            //"Day"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
            
            //Time range = 2013-7-1 to 2013-8-4
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //"Hour"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);
            
            //Select "电"/"自来水"/"煤"
            UnitKPIPanel.SelectSingleCommodityUnitCarbon(input.InputData.Commodity[0]);
            TimeManager.MediumPause();
            
            //Time range = 2012-1-1 to 2013-12-18
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //select Benchmark = "严寒地区B区机房"
            EnergyViewToolbar.SelectIndustryConvertTarget(input.InputData.Industry);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            
            //"Year"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);

            //"Month"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);

            //"Week"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);
            
           
            //Time range = 2013-7-1 to 2013-8-4
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //"Day"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[8], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[8], input.InputData.failedFileName[8]);

            //"Hour"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[9], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[9], input.InputData.failedFileName[9]);
            }

        [Test]
        [CaseID("TC-J1-FVT-UnitIndicatorCarbonVerification-101-3")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(P4_UnitIndicatorCarbonVerificationSuite), "TC-J1-FVT-UnitIndicatorCarbonVerification-101-3")]
        public void UnitIndicatorCarbonVerification03(UnitIndicatorData input)
        {
            //Select "NancyOtherCustomer3"
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            //Select "NancyOtherCustomer3/NancyOtherSite/BuildingDayNight"
            //Select "NancyOtherCustomer3/NancyOtherSite/BuildingWorkNonwork"
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //select "碳排放"
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.ShortPause();

            //select "标煤"/"二氧化碳"
            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonType);
            TimeManager.ShortPause();

            //Time range = 2012-8-25 to 2013-2-10
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //Select "电"
            UnitKPIPanel.SelectSingleCommodityUnitCarbon(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            //select Benchmark = "严寒地区B区数据中心"/"严寒地区B区办公建筑"
            EnergyViewToolbar.SelectIndustryConvertTarget(input.InputData.Industry);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Week"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //"Day"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
        }
    }
}
