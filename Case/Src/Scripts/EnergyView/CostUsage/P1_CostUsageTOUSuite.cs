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

namespace Mento.Script.EnergyView.CostUsage
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-CostUsage-TOU-005"), CreateTime("2013-08-16"), Owner("Emma")]
    public class P1_CostUsageTOUSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();
            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
            TimeManager.LongPause();
        }

        private static CostPanel CostUsage = JazzFunction.CostPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static WidgetMaxChartDialog WidgetMaxChart = JazzFunction.WidgetMaxChartDialog;

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-TOU-DataView-005-1")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(P1_CostUsageTOUSuite), "TC-J1-FVT-CostUsage-TOU-Column-005-1")]
        public void TOUDataViewColumnWeek(CostUsageData input)
        {
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            CostUsage.SwitchTagTab(TagTabs.AreaDimensionTab);
            CostUsage.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            
            //Set date range
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 4), new DateTime(2012, 9, 3));
            TimeManager.MediumPause();
            
            //Check tag and view trendchart, hourly
            CostUsage.SelectCommodity(input.InputData.commodityNames[0]);
            JazzFunction.EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.IsTrue(CostUsage.IsTrendChartDrawn());
            //Assert.AreEqual(1, CostUsage.GetTrendChartLines());

            EnergyViewToolbar.ShowPeakValley();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            //Assert.IsTrue(CostUsage.IsTrendChartDrawn());

            JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Uncheck "电" and check "自来水"
            CostUsage.DeSelectCommodity(input.InputData.commodityNames[0]);
            CostUsage.SelectCommodity(input.InputData.commodityNames[1]);
            EnergyViewToolbar.ShowPeakValley();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(EnergyViewToolbar.IsPeakValleyButtonEnable());

            //Uncheck "自来水" and check "煤"
            CostUsage.DeSelectCommodity(input.InputData.commodityNames[1]);
            CostUsage.SelectCommodity(input.InputData.commodityNames[2]);
            Assert.IsFalse(EnergyViewToolbar.IsPeakValleyButtonEnable());
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-TOU-DataView-005-2")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(P1_CostUsageTOUSuite), "TC-J1-FVT-CostUsage-TOU-Column-005-2")]
        public void TOUDataViewColumnMonth(CostUsageData input)
        {
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            CostUsage.SwitchTagTab(TagTabs.AreaDimensionTab);
            CostUsage.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 6, 1), new DateTime(2012, 9, 1));
            TimeManager.MediumPause();

            //Check tag and view chart, hourly
            CostUsage.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.ShowPeakValley();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            //Assert.IsTrue(CostUsage.IsTrendChartDrawn());
            //Assert.AreEqual(3, CostUsage.GetTrendChartLines());

            CostUsage.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            //Assert.IsTrue(CostUsage.IsTrendChartDrawn());
            //Assert.AreEqual(3, CostUsage.GetTrendChartLines());

            JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Uncheck "电" and check "煤"
            CostUsage.DeSelectCommodity(input.InputData.commodityNames[0]);
            CostUsage.SelectCommodity(input.InputData.commodityNames[2]);
            EnergyViewToolbar.ShowPeakValley();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(EnergyViewToolbar.IsPeakValleyButtonEnable());
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-TOU-DataView-005-3")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(P1_CostUsageTOUSuite), "TC-J1-FVT-CostUsage-TOU-Column-005-3")]
        public void TOUDataViewColumnDisable(CostUsageData input)
        {
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            CostUsage.SwitchTagTab(TagTabs.AreaDimensionTab);
            CostUsage.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 23), new DateTime(2012, 7, 30));
            TimeManager.MediumPause();

            //Check tag and view data view, hourly
            CostUsage.SelectCommodity(input.InputData.commodityNames[0]);
            Assert.IsTrue(EnergyViewToolbar.IsPeakValleyButtonEnable());
            EnergyViewToolbar.ShowPeakValley();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.IsTrue(CostUsage.IsTrendChartDrawn());

            //Set date range less than 7 days
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 23), new DateTime(2012, 7, 25));
            TimeManager.MediumPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.StepMessage[0]));
            JazzMessageBox.MessageBox.OK();

            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 23), new DateTime(2012, 7, 23));
            EnergyViewToolbar.SetTimeRange("10:00", "24:00");
            TimeManager.MediumPause();
            EnergyViewToolbar.ClickViewButton();
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.StepMessage[0]));
            JazzMessageBox.MessageBox.OK();
            TimeManager.MediumPause();

            //Pick up another node which not set TOU
            string[] hierarhcyPath = { "NancyCostCustomer2", "组织A", "园区A", "楼宇A" };
            CostUsage.SelectHierarchy(hierarhcyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            CostUsage.SwitchTagTab(TagTabs.HierarchyTag);
            TimeManager.MediumPause();
            CostUsage.SelectCommodity(input.InputData.commodityNames[0]);
            Assert.IsTrue(EnergyViewToolbar.IsPeakValleyButtonEnable());
            EnergyViewToolbar.ShowPeakValley();
            TimeManager.LongPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.StepMessage[1]));
            JazzMessageBox.MessageBox.OK();

            //Make sure 楼宇B defined 工作日 calendar.
            //Select a tag under 楼宇B to display trend chart. 
            //Select time range is 1 month when calendar of 工作日 is defined. Go to 峰谷展示. Select 显示日历 from 更多.
            string[] hierarhcyPath2 = { "NancyCostCustomer2", "组织A", "园区A", "楼宇B" };
            CostUsage.SelectHierarchy(hierarhcyPath2);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            CostUsage.SwitchTagTab(TagTabs.HierarchyTag);
            TimeManager.MediumPause();
            CostUsage.SelectCommodity();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SetDateRange(new DateTime(2014, 6, 1), new DateTime(2014, 6, 30));
            EnergyViewToolbar.SetTimeRange("00:00", "24:00");

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ShowCalendarNonWorkday);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ShowCalendarHeatCool);
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);

            //On homepage, check the dashboard
            CostUsage.NavigateToAllDashBoards();
            HomePagePanel.SelectHierarchyNode(dashboard.HierarchyName);
            TimeManager.LongPause();
            TimeManager.LongPause();
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));

            HomePagePanel.MaximizeWidget(dashboard.WigetName);
            TimeManager.MediumPause();

            //Set date range less than 7 days
            WidgetMaxChart.InputEndDate(new DateTime(2012, 7, 25));
            TimeManager.ShortPause();
            WidgetMaxChart.ClickViewButton();
            TimeManager.LongPause();
            TimeManager.LongPause();
            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.StepMessage[0]));
            JazzMessageBox.MessageBox.OK();
            TimeManager.MediumPause();

            WidgetMaxChart.InputEndDate(new DateTime(2012, 7, 23));
            WidgetMaxChart.SelectStartTime("10:00");
            TimeManager.ShortPause();
            WidgetMaxChart.ClickViewButton();
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.StepMessage[0]));
            JazzMessageBox.MessageBox.OK();
            TimeManager.MediumPause();

            WidgetMaxChart.ClickCloseButton();
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-TOU-005-1")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(P1_CostUsageTOUSuite), "TC-J1-FVT-CostUsage-TOU-005-1")]
        public void TOUPieChart(CostUsageData input)
        {
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Change manually defined time range to 2012/07/04-2012/09/03.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            //Select Commodity=电， change to TOU pie chart.
            CostUsage.SelectCommodity(input.InputData.commodityNames);

            JazzFunction.EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            //Click "Save to dashboard"（保存到仪表盘）to save the Pie chart to Hierarchy node dashboard.
            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);

            //+On homepage, check the dashboard
            CostUsage.NavigateToAllDashBoards();
            HomePagePanel.SelectHierarchyNode(dashboard.HierarchyName);
            TimeManager.LongPause();
            TimeManager.LongPause();
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();

            //Check ·The Pie chart Save to dashboard successfully.
            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));
            HomePagePanel.MaximizeWidget(dashboard.WigetName);
            TimeManager.MediumPause();

        }

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-TOU-005-2")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(P1_CostUsageTOUSuite), "TC-J1-FVT-CostUsage-TOU-005-2")]
        public void TOUChart(CostUsageData input)
        {
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Change manually defined time range to 2012/07/04-2012/09/03.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            //Select Commodity=电， change to TOU chart.
            CostUsage.SelectCommodity(input.InputData.commodityNames);
            EnergyViewToolbar.ShowPeakValley();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(CostUsage.IsTrendChartDrawn());

            //Check value
            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //change to column chart view
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(CostUsage.IsColumnChartDrawn());

            //Try to click Optional step=Raw.
            CostUsage.ClickDisplayStep(DisplayStep.Min);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //· Warning message pop up show "峰谷不支持Raw"
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.StepMessage[0]));
            JazzMessageBox.MessageBox.OK();
            TimeManager.MediumPause();

            //Change other Optional step=Day/Week/Month
            CostUsage.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //· Pie chart display correctly. TOU column value are calculate correctly.
            Assert.IsTrue(CostUsage.IsColumnChartDrawn());

            //Change to Stack chart.
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.Stack);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //· Stack chart display correctly. 
            Assert.IsTrue(CostUsage.IsColumnChartDrawn());

            CostUsage.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //· Stack chart display correctly. 
            Assert.IsTrue(CostUsage.IsColumnChartDrawn()); 

            //Nancy add TOU pie chart, please make it work as well.
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(CostUsage.IsPieChartDrawn());

            //Click "Save to dashboard"（保存到仪表盘）to save the Pie chart to Hierarchy node dashboard.
            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);

            //+On homepage, check the dashboard
            CostUsage.NavigateToAllDashBoards();
            HomePagePanel.SelectHierarchyNode(dashboard.HierarchyName);
            TimeManager.LongPause();
            TimeManager.LongPause();
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();

            //Check ·The Pie chart Save to dashboard successfully.
            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));
            HomePagePanel.MaximizeWidget(dashboard.WigetName);
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-TOU-005-3")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(P1_CostUsageTOUSuite), "TC-J1-FVT-CostUsage-TOU-005-3")]
        public void TOUButtonStatus(CostUsageData input)
        {
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Change manually defined time range to 2014/07/29-2014/08/04.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            //Select Commodity=电
            CostUsage.SelectCommodity(input.InputData.commodityNames);

            //In step day and click 峰谷展示 button.
            EnergyViewToolbar.ShowPeakValley();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //· Warning message pop up show "峰谷不支持Raw"
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.StepMessage[0]));
            JazzMessageBox.MessageBox.OK();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyViewToolbar.IsPeakValleyButtonPressed());
        }
    }
}
