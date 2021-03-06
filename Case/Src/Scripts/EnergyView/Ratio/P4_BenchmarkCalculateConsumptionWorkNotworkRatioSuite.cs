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

namespace Mento.Script.EnergyView.Ratio
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [Category("P4_Emma_Benchmark")]
    [ManualCaseID("TC-J1-FVT-BenchmarkConsumptionWorkNotworkRatio-Calculate-101"), CreateTime("2013-12-18"), Owner("Emma")]
    public class P4_BenchmarkCalculateConsumptionWorkNotworkRatioSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            RadioPanel.RatioCaseSetUp();
        }

        [TearDown]
        public void CaseTearDown()
        {
            RadioPanel.RatioCaseTearDown();
        }

        private static RatioPanel RadioPanel = JazzFunction.RatioPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;

        [Test]
        [CaseID("TC-J1-FVT-BenchmarkConsumptionWorkNotworkRatio-Calculate-101-1")]
        [MultipleTestDataSource(typeof(RatioData[]), typeof(P4_BenchmarkCalculateConsumptionWorkNotworkRatioSuite), "TC-J1-FVT-BenchmarkConsumptionWorkNotworkRatio-Calculate-101-1")]
        public void BenchmarkCalculateConsumptionWorkNotworkRatio01(RatioData input)
        {
            //Go to NancyOtherCustomer3. Go to Function Go to Energy Ratio Indicator. 
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            RadioPanel.NavigateToRatio();
            TimeManager.MediumPause();

            //Select the BuildingRanking1 from Hierarchy Tree, select 昼夜比 option. Select Rankingtag1 to view data
            RadioPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            RadioPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            //select 公休比 option
            EnergyViewToolbar.SelectRadioTypeConvertTarget(RadioTypeConvertTarget.WorkNonRadio);
            TimeManager.ShortPause();

            //Verify the calculation result of 行业基准值=全区域全行业.
            EnergyViewToolbar.SelectRatioIndustryConvertTarget(input.InputData.Industries[0]);

            //Time range 2013-1-1 to 2013-12-1
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Step is "Month"
            RadioPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            RadioPanel.CompareDataViewRatio(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Step is "Week"
            RadioPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            RadioPanel.CompareDataViewRatio(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);            
        }

        [Test]
        [CaseID("TC-J1-FVT-BenchmarkConsumptionWorkNotworkRatio-Calculate-101-2")]
        [MultipleTestDataSource(typeof(RatioData[]), typeof(P4_BenchmarkCalculateConsumptionWorkNotworkRatioSuite), "TC-J1-FVT-BenchmarkConsumptionWorkNotworkRatio-Calculate-101-2")]
        public void BenchmarkCalculateConsumptionWorkNotworkRatio02(RatioData input)
        {
            //Go to NancyOtherCustomer3. Go to Function Go to Energy Ratio Indicator.
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            RadioPanel.NavigateToRatio();
            TimeManager.MediumPause();

            //Select the BuildingWorkNonwork from Hierarchy Tree, select 公休比 option. Select 行业基准值=严寒地区B区地区办公建筑行业. Select WorkNotworkP to view chart.
            RadioPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //select 公休比 option
            EnergyViewToolbar.SelectRadioTypeConvertTarget(RadioTypeConvertTarget.WorkNonRadio);
            TimeManager.ShortPause();

            RadioPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.SelectRatioIndustryConvertTarget(input.InputData.Industries[0]);
            TimeManager.ShortPause();

            //Time range 2012-9-11 to 2013-4-21
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Step is "Month"
            RadioPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            RadioPanel.CompareDataViewRatio(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Step is "Week"
            RadioPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            RadioPanel.CompareDataViewRatio(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);


            //Select 行业基准值=严寒地区B区地区全行业. Select WorkNotworkP to view chart.
            EnergyViewToolbar.SelectRatioIndustryConvertTarget(input.InputData.Industries[1]);
            TimeManager.ShortPause();

            //2012-12-20 to 2013-2-8
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Step is "Week"
            RadioPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            RadioPanel.CompareDataViewRatio(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Go to NancyCustomer1. Go to Function Go to Energy Ratio Indicator. Select the BuildingMulCalculationType from Hierarchy Tree, select 昼夜比 option.
            HomePagePanel.SelectCustomer("NancyCustomer1");
            TimeManager.ShortPause();

            RadioPanel.NavigateToRatio();
            TimeManager.MediumPause();

            RadioPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            
            //Select 行业基准值=夏热冬暖地区商场行业. Select CalculationTypeMinIs0 to view chart.
            RadioPanel.CheckTag(input.InputData.tagNames[1]);
            TimeManager.ShortPause();

            EnergyViewToolbar.SelectRatioIndustryConvertTarget(input.InputData.Industries[2]);
            TimeManager.ShortPause();

            //Time range 2012-12-20 to 2013-2-8
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Step is "Week"
            RadioPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            RadioPanel.CompareDataViewRatio(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
        }
    }
}

