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

namespace Mento.Script.EnergyView.Ratio
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-ConsumptionDayNightRatioIndustryBenchmark-View-101"), CreateTime("2013-12-27"), Owner("Emma")]
    public class ViewConsumptionDayNightRatioIndustryBenchmarkSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-ConsumptionDayNightRatioIndustryBenchmark-View-101-1")]
        [MultipleTestDataSource(typeof(RatioData[]), typeof(ViewConsumptionDayNightRatioIndustryBenchmarkSuite), "TC-J1-FVT-ConsumptionDayNightRatioIndustryBenchmark-View-101-1")]
        public void ViewConsumptionDayNightRatioIndustryBenchmark01(RatioData input)
        {
            //1. Go to NancyOtherCustomer3. 
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");

            //2. Go to Function Go to Energy Ratio Indicator. 
            RadioPanel.NavigateToRatio();

            //3. Select the "BuildingDayNight", 昼夜比(default).
            RadioPanel.SelectHierarchy(input.InputData.Hierarchies[0]);

            //4. Select "DayNightP"
            RadioPanel.CheckTag(input.InputData.tagNames[0]);

            //5. Select 行业基准值=严寒地区B区地区数据中心行业
            EnergyViewToolbar.SelectRatioIndustryConvertTarget(input.InputData.Industries[0]);
            
            //6. Change different time range, 
            //a. 2013/07/01-2013/07/03 day
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            //data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Step is "Day"
            RadioPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            RadioPanel.CompareDataViewRatio(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);


            //b. 2013/09/10-2013/11/05 week
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            //data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Step is "Week"
            RadioPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            RadioPanel.CompareDataViewRatio(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //c. 2013/01/01-2013/12/31 Month
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            TimeManager.ShortPause();

            //data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Step is "Month"
            RadioPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            RadioPanel.CompareDataViewRatio(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //d. 2011/01/01-2013/12/31 year
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
            TimeManager.ShortPause();

            //data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Step is "Year"
            RadioPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            RadioPanel.CompareDataViewRatio(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionDayNightRatioIndustryBenchmark-View-101-2")]
        [MultipleTestDataSource(typeof(RatioData[]), typeof(ViewConsumptionDayNightRatioIndustryBenchmarkSuite), "TC-J1-FVT-ConsumptionDayNightRatioIndustryBenchmark-View-101-2")]
        public void ViewConsumptionDayNightRatioIndustryBenchmark02(RatioData input)
        {
            //1. Go to NancyOtherCustomer
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");

            //2. Go to Function Go to Energy Ratio Indicator
            RadioPanel.NavigateToRatio();

            //3. Select the "BuildingCostYearToDay" 昼夜比(default)
            RadioPanel.SelectHierarchy(input.InputData.Hierarchies[0]);

            //4. Select P1_YearToDay+V1_YearToDay+V2_YearToDay to view chart.
            RadioPanel.CheckTag(input.InputData.tagNames[0]);
            RadioPanel.CheckTag(input.InputData.tagNames[1]);
            RadioPanel.CheckTag(input.InputData.tagNames[2]);

            EnergyViewToolbar.ClickViewButton();         
            TimeManager.LongPause();

            //5. Messagebox popup, default is 7 days, not support "month" step
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.messages[0]));
            JazzWindow.WindowMessageInfos.Quit();
            TimeManager.ShortPause();

            //6. All tags auto un-selected
            Assert.IsFalse(RadioPanel.IsTagChecked(input.InputData.tagNames[0]));
            Assert.IsFalse(RadioPanel.IsTagChecked(input.InputData.tagNames[1]));
            Assert.IsFalse(RadioPanel.IsTagChecked(input.InputData.tagNames[2]));
            Assert.IsTrue(RadioPanel.EntirelyNoChartDrawn());

            //7. Select the "BuildingWorkNonwork" from Hierarchy Tree, 昼夜比(default). 
            RadioPanel.SelectHierarchy(input.InputData.Hierarchies[2]);

            //8. Select "WorkNotworkP"
            RadioPanel.CheckTag(input.InputData.tagNames[4]);

            //9. 行业基准值=严寒地区B区地区办公建筑 to view chart.
            EnergyViewToolbar.SelectRatioIndustryConvertTarget(input.InputData.Industries[1]);

            //10. Select time range 2013/01/01 to 2013/01/07; Optional step=Day.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Step is "Day"
            RadioPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            RadioPanel.CompareDataViewRatio(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Select BuildingNullTest from Hierarchy Tree. select 昼夜比 option. Select NullTestTag1, 行业基准值=夏热冬冷地区机场行业 to view chart
            RadioPanel.SelectHierarchy(input.InputData.Hierarchies[3]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            RadioPanel.CheckTag(input.InputData.tagNames[5]);
            TimeManager.ShortPause();

            //Select time range 2013/01/01 to 2013/02/28; Optional step=Week.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Step is "Week"
            RadioPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            RadioPanel.CompareDataViewRatio(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Select a not lighten tag DayNightPNotlighten under BuildingDayNight, 行业基准值=严寒地区B区办公建筑 to view chart.
            RadioPanel.SelectHierarchy(input.InputData.Hierarchies[4]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            RadioPanel.CheckTag(input.InputData.tagNames[6]);
            TimeManager.ShortPause();

            EnergyViewToolbar.SelectRatioIndustryConvertTarget(input.InputData.Industries[2]);
            TimeManager.ShortPause();

            //Select time range 2013/01/01 to 2013/02/28; Optional step=Week.
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
        }
    }
}

