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
    [ManualCaseID("TC-J1-FVT-ConsumptionWorkNotworkRatio-View-101"), CreateTime("2014-2-12"), Owner("Emma")]
    public class ViewConsumptionWorkNotworkRatioSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            RadioPanel.NavigateToRatio();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
            //JazzFunction.LoginPage.RefreshJazz("NancyCustomer1");
            TimeManager.LongPause();
        }

        private static RatioPanel RadioPanel = JazzFunction.RatioPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionWorkNotworkRatio-View-101-1")]
        [MultipleTestDataSource(typeof(RatioData[]), typeof(ViewConsumptionWorkNotworkRatioSuite), "TC-J1-FVT-ConsumptionWorkNotworkRatio-View-101-1")]
        public void ViewConsumptionWorkNotworkRatio01(RatioData input)
        {
            //Go to NancyOtherCustomer3. Go to Function Go to Energy Ratio Indicator. 
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            RadioPanel.NavigateToRatio();
            TimeManager.MediumPause();

            //Go to NancyOtherCustomer3. Go to Function Go to Energy Ratio Indicator. Select the BuildingWorkNonwork from Hierarchy Tree, select 公休比 option. Select WorkNotworkP .行业基准值=严寒地区B区地区办公建筑行业 to view chart.
            RadioPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            RadioPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.SelectRadioTypeConvertTarget(RadioTypeConvertTarget.WorkNonRadio);
            TimeManager.ShortPause();

            //Change different time range, 
            var ManualTimeRange = input.InputData.ManualTimeRange;

            //2012/07/01 -2012/07/03  day
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            TimeManager.LongPause();
            TimeManager.LongPause();

            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.messages[0]));
            JazzWindow.WindowMessageInfos.Quit();
            TimeManager.ShortPause();

            Assert.IsFalse(RadioPanel.IsTagChecked(input.InputData.tagNames[0]));
            Assert.IsTrue(RadioPanel.EntirelyNoChartDrawn());

            //2013/01/01-2013/03/30 week
            RadioPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //4 legand show include 昼夜比, 目标值昼夜比; 基准值昼夜比 and 能耗(Gray out).
            Assert.IsTrue(RadioPanel.IsLineLegendItemShown(input.InputData.UnitIndicatorLegend[0].CaculationValue));
            Assert.IsTrue(RadioPanel.IsLineLegendItemShown(input.InputData.UnitIndicatorLegend[0].TargetValue));
            Assert.IsTrue(RadioPanel.IsLineLegendItemShown(input.InputData.UnitIndicatorLegend[0].BaselineValue));
            Assert.IsFalse(RadioPanel.IsLineLegendItemShown(input.InputData.UnitIndicatorLegend[0].OriginalValue));
            Assert.IsTrue(RadioPanel.IsLegendItemExists(input.InputData.UnitIndicatorLegend[0].OriginalValue));

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Step is "Week"
            RadioPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            RadioPanel.CompareDataViewRatio(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //2013/01/01-2013/12/31 curmonth/curday=thisyear month
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Step is "Month"
            RadioPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            RadioPanel.CompareDataViewRatio(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //2011/01/01-2013/12/31 year
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Step is "Year"
            RadioPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            RadioPanel.CompareDataViewRatio(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionWorkNotworkRatio-View-101-2")]
        [MultipleTestDataSource(typeof(RatioData[]), typeof(ViewConsumptionWorkNotworkRatioSuite), "TC-J1-FVT-ConsumptionWorkNotworkRatio-View-101-2")]
        public void ViewConsumptionWorkNotworkRatio02(RatioData input)
        {
            //Go to NancyOtherCustomer3. Go to Function Go to Energy Ratio Indicator. 
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            RadioPanel.NavigateToRatio();
            TimeManager.MediumPause();

            //Select the BuildingMultipleSteps from Hierarchy Tree, select 公休比 option. Select multiple VH_SiteS1+VD_SiteS1+VM_SiteS1 to view chart.(2013-01/01 to 2013/12/31)
            RadioPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectRadioTypeConvertTarget(RadioTypeConvertTarget.WorkNonRadio);
            TimeManager.ShortPause();

            RadioPanel.CheckTag(input.InputData.tagNames[0]);
            RadioPanel.CheckTag(input.InputData.tagNames[1]);
            RadioPanel.CheckTag(input.InputData.tagNames[2]);
            TimeManager.ShortPause();

            //2013/01/01-2013/12/31
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(RadioPanel.IsTrendChartDrawn());

            //·2 legand pereach commodity include  昼夜比 and 能耗.
            Assert.IsTrue(RadioPanel.IsLineLegendItemShown(input.InputData.UnitIndicatorLegend[0].CaculationValue));
            Assert.IsTrue(RadioPanel.IsLegendItemExists(input.InputData.UnitIndicatorLegend[0].OriginalValue));
            Assert.IsFalse(RadioPanel.IsLineLegendItemShown(input.InputData.UnitIndicatorLegend[0].OriginalValue));
            Assert.IsTrue(RadioPanel.IsLineLegendItemShown(input.InputData.UnitIndicatorLegend[1].CaculationValue));
            Assert.IsTrue(RadioPanel.IsLegendItemExists(input.InputData.UnitIndicatorLegend[1].OriginalValue));
            Assert.IsFalse(RadioPanel.IsLineLegendItemShown(input.InputData.UnitIndicatorLegend[1].OriginalValue));
            Assert.IsTrue(RadioPanel.IsLineLegendItemShown(input.InputData.UnitIndicatorLegend[2].CaculationValue));
            Assert.IsTrue(RadioPanel.IsLegendItemExists(input.InputData.UnitIndicatorLegend[2].OriginalValue));
            Assert.IsFalse(RadioPanel.IsLineLegendItemShown(input.InputData.UnitIndicatorLegend[2].OriginalValue));

            //· Check 3 tags at most
            Assert.IsTrue(RadioPanel.IsAllTagsDisabled());

            //Select the BuildingWorkNonwork from Hierarchy Tree, select 公休比 option. Select WorkNotworkP, 行业基准值=严寒地区B区地区办公建筑行业 to view chart.
            RadioPanel.SelectHierarchy(input.InputData.Hierarchies[2]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectRadioTypeConvertTarget(RadioTypeConvertTarget.WorkNonRadio);
            TimeManager.ShortPause();

            RadioPanel.CheckTag(input.InputData.tagNames[4]);
            TimeManager.ShortPause();

            //Select time range 2013/01/01 to 2013/04/28; Optional step=Week.
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


            //Go to NancyCustomer1, select BuildingBAD which is not define calendar. Select V(11), 行业基准值=夏热冬暖地区轨学校行业 to display 公休比.
            HomePagePanel.SelectCustomer("NancyCustomer1");
            TimeManager.ShortPause();

            RadioPanel.NavigateToRatio();
            TimeManager.MediumPause();

            RadioPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectRadioTypeConvertTarget(RadioTypeConvertTarget.WorkNonRadio);
            TimeManager.ShortPause();

            RadioPanel.CheckTag(input.InputData.tagNames[3]);
            TimeManager.ShortPause();

            //2014/2/1 to 2014/2/11
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            TimeManager.LongPause();

            //· Warning message show config calendar first.
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));

            Assert.IsFalse(EnergyViewToolbar.View(EnergyViewType.Distribute));
            TimeManager.ShortPause();
        }
    }
}

