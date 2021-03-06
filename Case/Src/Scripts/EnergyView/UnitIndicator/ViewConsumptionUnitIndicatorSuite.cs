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
    [Category("P3_Emma")]
    [ManualCaseID("TC-J1-FVT-ConsumptionUnitIndicator-View-101"), CreateTime("2013-10-28"), Owner("Emma")]
    public class ViewConsumptionUnitIndicatorSuite : TestSuiteBase
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

        //忽略的原因是有predefine的时间段，值不确定
        [Test]
        [Ignore("ignore")]
        [CaseID("TC-J1-FVT-ConsumptionUnitIndicator-View-101-1")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(ViewConsumptionUnitIndicatorSuite), "TC-J1-FVT-ConsumptionUnitIndicator-View-101-1")]
        public void ViewConsumptionUnitIndicator01(UnitIndicatorData input)
        {
            //Go to Function Unit indicator. Select the BuildingBC from Hierarchy Tree. Click Function Type button, select Energy Consumption.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            Assert.AreEqual(input.ExpectedData.UnitTypeValue, EnergyViewToolbar.GetUnitTypeButtonText());
            Assert.AreEqual(input.ExpectedData.IndustryValue, EnergyViewToolbar.GetIndustryButtonText());

            //Select 1 tag V(1), time range="今年", to display trend chart view.(No population property on last year)
            UnitKPIPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();         
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            //Assert.AreEqual(1, UnitKPIPanel.GetTrendChartLines());

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //check on data view
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Select Unit=单位面积 and view data.
            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitArea);
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[0]);

            EnergyViewToolbar.View(EnergyViewType.Line);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            //Assert.AreEqual(1, UnitKPIPanel.GetTrendChartLines());

            //4 legand s//how include 能耗/单位面积; 目标值/单位面积; 基准值/单位面积 and 能耗(Gray out).
            Assert.IsTrue(UnitKPIPanel.IsLineLegendItemShown(input.InputData.UnitIndicatorLegend[0].CaculationValue));
            Assert.IsTrue(UnitKPIPanel.IsLineLegendItemShown(input.InputData.UnitIndicatorLegend[0].TargetValue));
            Assert.IsTrue(UnitKPIPanel.IsLineLegendItemShown(input.InputData.UnitIndicatorLegend[0].BaselineValue));
            Assert.IsFalse(UnitKPIPanel.IsLineLegendItemShown(input.InputData.UnitIndicatorLegend[0].OriginalValue));
            Assert.IsTrue(UnitKPIPanel.IsLegendItemExists(input.InputData.UnitIndicatorLegend[0].OriginalValue));

            /*tspan 找不到原始的那个数据点了；而且28版本的chrome对legend的支持不好，暂时跳过
            //能耗 chart default hiden. When click the gray out 能耗 legand, show 1 more能耗 chart.
            UnitKPIPanel.ShowLineCurveLegend(input.InputData.UnitIndicatorLegend[0].OriginalValue);
            TimeManager.ShortPause();
            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            */

            //Select BuildingBAD and check V(11), Unit= 单位人口 to display trend chart view.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitPopulation);
            UnitKPIPanel.CheckTag(input.InputData.tagNames[3]);
            TimeManager.ShortPause();    
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));

            //Change time range to 2012/01-2012/03, Unit= 单位人口 to view chart.
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 1, 1), new DateTime(2012, 3, 1));
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            TimeManager.ShortPause();

            //Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));
            Assert.AreEqual("2012-01-01", EnergyViewToolbar.GetStartDate());
            Assert.AreEqual("2012-03-01", EnergyViewToolbar.GetEndDate());

            //Select the BuildingBC from Hierarchy Tree.time range="去年". Select multiple tag V（1）+V(2) +V(3) to display trend chart view
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.CheckTag(input.InputData.tagNames[0]);
            UnitKPIPanel.CheckTag(input.InputData.tagNames[1]);
            UnitKPIPanel.CheckTag(input.InputData.tagNames[2]);
            TimeManager.ShortPause();
            //Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[1]));
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            //Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));
            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            //Assert.AreEqual(3, UnitKPIPanel.GetTrendChartLines());

            //2 legend pereach tag include 能耗/单位面积; and 能耗（Gray out）.)
            Assert.IsTrue(UnitKPIPanel.IsLineLegendItemShown(input.ExpectedData.UnitIndicatorLegend[0].CaculationValue));
            Assert.IsFalse(UnitKPIPanel.IsLineLegendItemShown(input.ExpectedData.UnitIndicatorLegend[0].OriginalValue));
            Assert.IsTrue(UnitKPIPanel.IsLineLegendItemShown(input.ExpectedData.UnitIndicatorLegend[1].CaculationValue));
            Assert.IsFalse(UnitKPIPanel.IsLineLegendItemShown(input.ExpectedData.UnitIndicatorLegend[1].OriginalValue));
            Assert.IsTrue(UnitKPIPanel.IsLineLegendItemShown(input.ExpectedData.UnitIndicatorLegend[2].CaculationValue));
            Assert.IsFalse(UnitKPIPanel.IsLineLegendItemShown(input.ExpectedData.UnitIndicatorLegend[2].OriginalValue));

            //Change different time range
            //a. 2012/07/01 3:30-2012/07/01 15:00 hour
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Hour));

            //b. 2012/07/01 3:30-2012/07/03 23:30 day
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Hour));

            //c. 2012/07/10-2012/08/05 week
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));

            //d. 2012/01/01-2012/12/31=lastyear month
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));

            //e. 2011/01/01-2013/05/30 year
            EnergyViewToolbar.SetDateRange(ManualTimeRange[4].StartDate, ManualTimeRange[4].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));
        }

        //2.0测试的时候忽略，这版主要是验证数据的正确性
        [Test]
        [Ignore("ignore")]
        [CaseID("TC-J1-FVT-ConsumptionUnitIndicator-View-101-2")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(ViewConsumptionUnitIndicatorSuite), "TC-J1-FVT-ConsumptionUnitIndicator-View-101-2")]
        public void NoCompareData_ViewConsumptionUnitIndicator02(UnitIndicatorData input)
        {
            //Select multiple tags V(1) and V(2) from BuildingBC node and Dimension node to display column chart view.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            UnitKPIPanel.SwitchTagTab(TagTabs.SystemDimensionTab);
            TimeManager.MediumPause();
            UnitKPIPanel.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            UnitKPIPanel.CheckTag(input.InputData.tagNames[1]);
            TimeManager.ShortPause();

            //·Chart display 单位面积.
            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitArea);
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //1.9.1没有值
            //Assert.IsTrue(UnitKPIPanel.IsColumnChartDrawn());
            //Assert.AreEqual(2, UnitKPIPanel.GetColumnChartColumns());
            
            //·2 legend pereach tag include 能耗/单位面积; and 能耗（Gray out）.
            Assert.IsTrue(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[0].CaculationValue));
            Assert.IsFalse(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[0].OriginalValue));
            Assert.IsTrue(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[1].CaculationValue));
            Assert.IsFalse(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[1].OriginalValue));
            
            //Change different time range
            //a. 2012/07/01 3:30-2012/07/01 15:00 hour
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Hour));

            //b. 2012/07/01 3:30-2012/07/03 23:30 day
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Hour));

            //c. 2012/07/10-2012/08/05 week
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Hour));

            //d. 2012/01/01-2012/12/31=lastyear month
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));

            //e. 2011/01/01-2013/05/30 year
            EnergyViewToolbar.SetDateRange(ManualTimeRange[4].StartDate, ManualTimeRange[4].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            //Select multiple tags from multiple hierarchy node BuildingBC and BuildingBAD and Dimension node to display column chart view.
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.SwitchTagTab(TagTabs.SystemDimensionTab);
            MultiHieCompareWindow.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            MultiHieCompareWindow.CheckTag(input.InputData.tagNames[1]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            MultiHieCompareWindow.CheckTag(input.InputData.tagNames[2]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //·Chart display 单位面积.
            Assert.IsTrue(UnitKPIPanel.IsColumnChartDrawn());
            //Assert.AreEqual(3, UnitKPIPanel.GetColumnChartColumns());

            //· 目标值/基准值 chart and legand will not display in chart.
            Assert.IsTrue(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[0].CaculationValue));
            Assert.IsFalse(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[0].OriginalValue));
            Assert.IsTrue(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[1].CaculationValue));
            Assert.IsFalse(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[1].OriginalValue));
            Assert.IsTrue(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[2].CaculationValue));
            Assert.IsFalse(UnitKPIPanel.IsColumnLegendItemShown(input.ExpectedData.UnitIndicatorLegend[2].OriginalValue));
            Assert.AreEqual(input.ExpectedData.UnitTypeValue, EnergyViewToolbar.GetUnitTypeButtonText());

            //Click "删除所有" and 确定
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.ClearAllMessage));
            JazzMessageBox.MessageBox.Clear();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.EntirelyNoChartDrawn());

            //· Chart display correctly without pop up message.
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.MediumPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            MultiHieCompareWindow.CheckTag(input.InputData.tagNames[2]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            #region Not use code, for save to dashboard which will test on manual for 2.0
            /*
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
             */
            #endregion
        }

        //忽略的原因是有predefine的时间段，值不确定
        [Test]
        [Ignore("ignore")]
        [CaseID("TC-J1-FVT-ConsumptionUnitIndicator-View-101-3")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(ViewConsumptionUnitIndicatorSuite), "TC-J1-FVT-ConsumptionUnitIndicator-View-101-3")]
        public void ViewConsumptionUnitIndicator03(UnitIndicatorData input)
        {
            //Go to NancyOtherCustomer3. Go to Function Unit indicator. 
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            //Select the BuildingPrecision from Hierarchy Tree.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.SwitchTagTab(TagTabs.HierarchyTag);
            TimeManager.LongPause();

            //Click Function Type button, select Energy Consumption. Verify precision display for Unit display.
            UnitKPIPanel.CheckTag(input.InputData.tagNames[0]);
            UnitKPIPanel.CheckTag(input.InputData.tagNames[1]);
            TimeManager.ShortPause();

            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.ShortPause();

            //·Basic chart view display as expected.
            //Line chart
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            //Assert.AreEqual(6, UnitKPIPanel.GetTrendChartLinesMarkers());

            //Column
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsColumnChartDrawn());
            //Assert.AreEqual(2, UnitKPIPanel.GetColumnChartColumns());

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Data View
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Select the BuildingMissingData from Hierarchy Tree. 
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //select tag PtagMissing. Time rang="去年
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.ShortPause();

            UnitKPIPanel.CheckTag(input.InputData.tagNames[2]);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();


            //Data View
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Line chart
            EnergyViewToolbar.View(EnergyViewType.Line);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            Assert.AreEqual(1, UnitKPIPanel.GetTrendChartLines());

            //Column
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsColumnChartDrawn());
            //Assert.AreEqual(1, UnitKPIPanel.GetColumnChartColumns());

            //Select the BuildingMultipleSteps from Hierarchy Tree. Select V(H)+V(D)+V(M) to display 单位人口.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[2]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            UnitKPIPanel.CheckTag(input.InputData.tagNames[3]);
            UnitKPIPanel.CheckTag(input.InputData.tagNames[4]);
            UnitKPIPanel.CheckTag(input.InputData.tagNames[5]);
            TimeManager.ShortPause();

            //Select time range, 去年
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.ShortPause();

            //Line chart
            EnergyViewToolbar.View(EnergyViewType.Line);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            //Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));

            Assert.IsFalse(UnitKPIPanel.IsTrendChartDrawn());

            //Column
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));

            Assert.IsFalse(UnitKPIPanel.IsColumnChartDrawn());

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();


            //Data View
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Select 1 tag V(12) from hierarchy node BuildingBAD, Unit=单位供冷面积 to display chart view.
            HomePagePanel.SelectCustomer("NancyCustomer1");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[3]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.CheckTag(input.InputData.tagNames[6]);
            TimeManager.ShortPause();

            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitCoolArea);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            //Assert.AreEqual(1, UnitKPIPanel.GetTrendChartLines());
            //Assert.AreEqual(7, UnitKPIPanel.GetTrendChartLinesMarkers());

            //Select 1 tag V(1) select time range =2012/01/01-2012/12/31, optional step=month, unit=单位人口 to view chart.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[4]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.CheckTag(input.InputData.tagNames[7]);
            TimeManager.ShortPause();

            //Select time range, 去年
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.ShortPause();

            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitPopulation);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            //Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
            //Assert.AreEqual(2, UnitKPIPanel.GetTrendChartLines());
            //Assert.AreEqual(14, UnitKPIPanel.GetTrendChartLinesMarkers());
        }

        //2.0测试的时候忽略，这版主要是验证数据的正确性
        [Test]
        [Ignore("ignore")]
        [CaseID("TC-J1-FVT-ConsumptionUnitIndicator-View-101-4")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(ViewConsumptionUnitIndicatorSuite), "TC-J1-FVT-ConsumptionUnitIndicator-View-101-4")]
        public void NoCompareData_ViewConsumptionUnitIndicator04(UnitIndicatorData input)
        {
            //Go to NancyCustomer1. Go to Function Unit indicator. Select the BuildingBC from Hierarchy Tree. Click Function Type button, select Energy Consumption.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            //select tag "P1_BuildingBC", time range="2011/10/31 00:00-2012/01/01 24:00",Unit= "单位面积", click to display trend chart view.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();
            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitArea);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //.show 3 optional steps: 天，周，月.
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            //·default step is "月".
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));

            //·display the chart as expected.
            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());

            //change optional steps. From 月->天->周 to view different charts.
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //we should see chart with data under these 3 steps.
            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //we should see chart with data under these 3 steps.
            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());

            #region Not use code, for save to dashboard which will test on manual for 2.0
            /*
            //change optional step to "月"，click “更多”->”至仪表盘”, select “层级节点” =” NancyCustomer1”
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            TimeManager.MediumPause();
            //Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));
            */
            #endregion
        }

        //忽略的原因是有predefine的时间段，值不确定；虽然没有验证值，但是单位采暖面积也是没有值的
        [Test]
        [Ignore("ignore")]
        [CaseID("TC-J1-FVT-ConsumptionUnitIndicator-View-101-5")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(ViewConsumptionUnitIndicatorSuite), "TC-J1-FVT-ConsumptionUnitIndicator-View-101-5")]
        public void ViewConsumptionUnitIndicator05(UnitIndicatorData input)
        {
            //Select one node “NancyCustomer1/园区测试多层级/楼宇BAD”  from Hierarchy Tree.  
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //In "全部数据点", select tag "V11_BuildingBC".
            UnitKPIPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            //Time range ="去年", Unit= "单位采暖面积", click to display trend chart view.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.ShortPause();
            EnergyViewToolbar.SelectUnitTypeConvertTarget(UnitTypeConvertTarget.UnitHeatArea);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //In step 6, warning message should popup "缺少供暖面积属性". 
            //Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));
        }

        //2.0测试的时候忽略，这版主要是验证数据的正确性
        [Test]
        [Ignore("ignore")]
        [CaseID("TC-J1-FVT-ConsumptionUnitIndicator-View-101-5467")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(ViewConsumptionUnitIndicatorSuite), "TC-J1-FVT-ConsumptionUnitIndicator-View-101-5467")]
        public void NoCompareData_ViewConsumptionUnitIndicator_5467(UnitIndicatorData input)
        {
            //Go to Unit indicator, select Energy->BuildingA_KT_P1_Electricity_ 之前七天 to view chart.
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            //Select the BuildingPrecision from Hierarchy Tree.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            UnitKPIPanel.SwitchTagTab(TagTabs.HierarchyTag);
            TimeManager.LongPause();

            //Click Function Type button, select Energy Consumption. Verify precision display for Unit display.
            UnitKPIPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(UnitKPIPanel.IsTrendChartDrawn());
        }
    }
}
