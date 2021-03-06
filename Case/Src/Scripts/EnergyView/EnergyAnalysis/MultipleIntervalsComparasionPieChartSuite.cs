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

namespace Mento.Script.EnergyView.EnergyAnalysis
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-MultipleIntervalsComparasion-DistributionChart"), CreateTime("2014-09-23"), Owner("Linda")]
    public class MultipleIntervalsComparasionPieChartSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
            TimeManager.LongPause();
        }

        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static TimeSpanDialog TimeSpanDialog = JazzFunction.TimeSpanDialog;

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-PieChart-101"), ManualCaseID("TC-J1-FVT-MultipleIntervalsComparasion-DistributionChart-101")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(MultipleIntervalsComparasionPieChartSuite), "TC-J1-FVT-MultipleIntervalsComparasion-PieChart-101")]
        public void ViewSingleTagPiechartAndSaveToDashboard(TimeSpansData input)
        {
            //Select the BuildingBC node in Pre-condition from Hierarchy list
            HomePagePanel.SelectCustomer("NancyCustomer1");
            TimeManager.LongPause();
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Select a Vtag from All tag list or System dimension or Area dimension tab
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.MediumPause();

            //Set time range =2013/01/01 02:00 to 2013/02/13 12:00 
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.ShortPause();

            //Select char type 'Distribution Chart'.
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.Distribute);
            TimeManager.FlashPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check Distribution Chart is displayed.
            Assert.IsTrue(EnergyAnalysis.IsDistributionChartDrawn());

            //The legend displays tag name when there is first default time span only.
            Assert.AreEqual(input.InputData.TagNames[0], EnergyAnalysis.GetLegendItemTexts()[0]);

            //The value display for V(6) on hour level is 80*6=480. 
            //The UOM display is as defined in tag property.//No Uom display in pie chart
            EnergyAnalysis.ExportMulTimePieDataTableToExcel (input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareMultiTimeDataTableOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Click '添加对比时间',Enter start time for the comparision interval
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartTime(ManualTimeRange[1].StartTime, 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartDate(ManualTimeRange[1].StartDate, 2);
            TimeManager.LongPause();

            //Check the comparision interval '2013/3/3 00:00 to 2013/04/15 10:00' is added.
            Assert.AreEqual(ManualTimeRange[1].StartDate, TimeSpanDialog.GetAdditionStartDateValue(2));
            Assert.AreEqual(ManualTimeRange[1].StartTime, TimeSpanDialog.GetAdditionStartTimeValue(2));
            Assert.AreEqual(ManualTimeRange[1].EndDate, TimeSpanDialog.GetAdditionEndDateValue(2));
            Assert.AreEqual(ManualTimeRange[1].EndTime, TimeSpanDialog.GetAdditionEndTimeValue(2));

            //Click '确定'
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDistributionChartDrawn());

            //The Distribution Chart is generated by 2 time spans. 
            Assert.AreEqual(2, EnergyAnalysis.GetPieChartSpans());

            //One is for the first default time span, the other is for the comparision time span. 
            //The legend displays all time spans instead of tag name when there is comparision span.
            string[] legendsAc = EnergyAnalysis.GetLegendItemTexts();
            string[] legendsEx = { "", "" };
            legendsEx[0] = input.InputData.ManualTimeRange[0].StartDate + " " + input.InputData.ManualTimeRange[0].StartTime + input.InputData.ManualTimeRange[0].EndDate + " " + input.InputData.ManualTimeRange[0].EndTime;
            legendsEx[1] = input.InputData.ManualTimeRange[1].StartDate + " " + input.InputData.ManualTimeRange[1].StartTime + input.InputData.ManualTimeRange[1].EndDate + " " + input.InputData.ManualTimeRange[1].EndTime;
            Assert.AreEqual(legendsAc, legendsEx);

            //The Distribution Chart is generated by 2 time spans, check each part data value. The comparision has one day more data than the original.
            //First span: 2013年1月2-2013年2月12(42days)+2013年1月1日 2:00 to 24:00(10hours)+2014年2月13 0:00 to 12:00(12hours)
            //Second span: 2013/3/3 to 2013/4/14 (43days)+2013/4/15(10hours)
            EnergyAnalysis.ExportMulTimePieDataTableToExcel(input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareMultiTimeDataTableOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //change the start time 2013/1/1 00:00 to be 2013/6/1 23:00
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.InputBaseStartDate(ManualTimeRange[2].StartDate);
            TimeSpanDialog.InputBaseStartTime(ManualTimeRange[2].StartTime);

            //The compared Intervals Will not be cleared
            Assert.AreEqual(3, TimeSpanDialog.GetExcludeIntervals());
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDistributionChartDrawn());

            //Set the original  time interval to "上月"
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);
            TimeManager.MediumPause();

            //Check value and ...
            EnergyAnalysis.ExportMulTimePieDataTableToExcel(input.InputData.Hierarchies, ManualTimeRange[2], input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareMultiTimeDataTableOfEnergyAnalysis(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Calculate the month index of Feb
            int monthIndex = DateTime.Now.Month - 3;
            if (DateTime.Now.Month > 3)
                monthIndex = DateTime.Now.Month - 3;
            else
                monthIndex = DateTime.Now.Month + 9;

            //Click '添加对比时间' , select "相对时间" 之前第n个月(2月)
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.ClickAddTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.SelectCompareTimeType(CompareTimeType.Relative, 3);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionRelativeValue(monthIndex.ToString(), 3);//The compare interval number combox in relative is same with start time combox in user-defined

            //Click OK and draw chart button in below right.
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check
            EnergyAnalysis.ExportMulTimePieDataTableToExcel(input.InputData.Hierarchies, ManualTimeRange[3], input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareMultiTimeDataTableOfEnergyAnalysis(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

            //Add more compared span and click Draw button.Time interval is 2014/4/1 0:00 to 2014/5/3 24:00
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.ClickAddTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.SelectCompareTimeType(CompareTimeType.UserDefined, 4);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartDate(ManualTimeRange[3].StartDate, 4);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartTime(ManualTimeRange[3].StartTime, 4);
            TimeManager.ShortPause();
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check
            EnergyAnalysis.ExportMulTimePieDataTableToExcel(input.InputData.Hierarchies, ManualTimeRange[4], input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareMultiTimeDataTableOfEnergyAnalysis(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

            //Add multiple compared spans, until the number of total time spans is 5
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.ClickAddTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.SelectCompareTimeType(CompareTimeType.UserDefined, 5);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartDate(ManualTimeRange[4].StartDate, 5);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartTime(ManualTimeRange[4].StartTime, 5);
            TimeManager.ShortPause();
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check the Distribution Chart is generated by 5 time spans
            Assert.AreEqual(5, EnergyAnalysis.GetPieChartSpans());
            EnergyAnalysis.ExportMulTimePieDataTableToExcel(input.InputData.Hierarchies, ManualTimeRange[5], input.ExpectedData.expectedFileName[5]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareMultiTimeDataTableOfEnergyAnalysis(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);

            //Hide/re-show a compared span from legend area.
            //Check the compared time span is hiden/shown on the view. And the first time span can't be hiden.
            string[] legends = EnergyAnalysis.GetLegendItemTexts();
            EnergyAnalysis.ClickLegendItem(legends[1]);
            Assert.AreEqual(4, EnergyAnalysis.GetPieChartShowSpans());
            EnergyAnalysis.ClickLegendItem(legends[1]);
            Assert.AreEqual(5, EnergyAnalysis.GetPieChartShowSpans());

            //Click 'Save to dashboard'（保存到仪表盘）to save the Distribution Chart to Hierarchy node dashboard(Or Customized dashboard, or Home page dashboard). 
            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);
            TimeManager.LongPause();

            //Check the Distribution Chart is saved into dashboard successfully
            EnergyAnalysis.NavigateToAllDashBoards();
            HomePagePanel.SelectHierarchyNode(dashboard.HierarchyName);
            TimeManager.MediumPause();
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-PieChart-102"), ManualCaseID("TC-J1-FVT-MultipleIntervalsComparasion-DistributionChart-102")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(MultipleIntervalsComparasionPieChartSuite), "TC-J1-FVT-MultipleIntervalsComparasion-PieChart-102")]
        public void ViewSingleTagPiechartAndSaveToDashboard2(TimeSpansData input)
        {
            //Select the BuildingBC node in Pre-condition from Hierarchy list
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Select a Vtag from All tag list or System dimension or Area dimension tab
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.MediumPause();

            //Set time range
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.ShortPause();

            //Select char type 'Distribution Chart'.
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.Distribute);
            TimeManager.FlashPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check Distribution Chart is displayed.
            Assert.IsTrue(EnergyAnalysis.IsDistributionChartDrawn());

            //Click '添加对比时间',Enter start time for the comparision interval
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartDate(ManualTimeRange[1].StartDate, 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartTime(ManualTimeRange[1].StartTime, 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionEndDate(ManualTimeRange[1].EndDate, 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionEndTime(ManualTimeRange[1].EndTime, 2);
            TimeManager.LongPause();

            TimeSpanDialog.ClickAddTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartDate(ManualTimeRange[2].StartDate, 3);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartTime(ManualTimeRange[2].StartTime, 3);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionEndDate(ManualTimeRange[2].EndDate, 3);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionEndTime(ManualTimeRange[2].EndTime, 3);
            TimeManager.LongPause();

            //Click '确定'
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDistributionChartDrawn());

            //Data records for the time ranges are displayed in 3 time spans correctly.
            EnergyAnalysis.ExportMulTimePieDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDictionaryDataOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Click 'Save to dashboard'（保存到仪表盘）to save the Distribution Chart to Hierarchy node dashboard(Or Customized dashboard, or Home page dashboard). 
            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);
            TimeManager.LongPause();

            //Check the Distribution Chart is saved into dashboard successfully
            EnergyAnalysis.NavigateToAllDashBoards();
            HomePagePanel.SelectHierarchyNode(dashboard.HierarchyName);
            TimeManager.MediumPause();
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-PieChart-103"), ManualCaseID("TC-J1-FVT-MultipleIntervalsComparasion-DistributionChart-105")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(MultipleIntervalsComparasionPieChartSuite), "TC-J1-FVT-MultipleIntervalsComparasion-PieChart-103")]
        public void MultipleIntervalsAlignedCorrectlyEspeciallyWithMissingData(TimeSpansData input)
        {
            //NancyCostCustomer2>组织A>园区A>楼宇A 
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            //Select the BuildingBC node in Pre-condition from Hierarchy list
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Select a Vtag from All tag list or System dimension or Area dimension tab
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.MediumPause();

            //Set the original  time interval to "今年"
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Click '添加对比时间',Enter start time for the comparision interval
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.SelectCompareTimeType(CompareTimeType.UserDefined, 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartDate(ManualTimeRange[0].StartDate, 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartTime(ManualTimeRange[0].StartTime, 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionEndDate(ManualTimeRange[0].EndDate, 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionEndTime(ManualTimeRange[0].EndTime, 2);
            TimeManager.LongPause();

            //Click '确定'
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Select char type 'Distribution Chart'.
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.Distribute);
            TimeManager.FlashPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Data records for the time ranges are displayed in 3 time spans correctly.
            EnergyAnalysis.ExportMulTimePieDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDictionaryDataOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Click 'Save to dashboard'（保存到仪表盘）to save the Distribution Chart to Hierarchy node dashboard(Or Customized dashboard, or Home page dashboard). 
            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);
            TimeManager.LongPause();

            //Check the Distribution Chart is saved into dashboard successfully
            EnergyAnalysis.NavigateToAllDashBoards();
            HomePagePanel.SelectHierarchyNode(dashboard.HierarchyName);
            TimeManager.MediumPause();
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));
        }
    }
}
