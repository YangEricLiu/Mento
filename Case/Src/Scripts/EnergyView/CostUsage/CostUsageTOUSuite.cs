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
    public class CostUsageTOUSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        private static CostPanel CostUsage = JazzFunction.CostPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static WidgetMaxChartDialog WidgetMaxChart = JazzFunction.WidgetMaxChartDialog;

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-TOU-Column-005-1")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostUsageTOUSuite), "TC-J1-FVT-CostUsage-TOU-Column-005-1")]
        public void TOUColumnWeek(CostUsageData input)
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
            Assert.IsTrue(CostUsage.IsTrendChartDrawn());
            Assert.AreEqual(1, CostUsage.GetTrendChartLines());

            EnergyViewToolbar.ShowPeakValley();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(CostUsage.IsColumnChartDrawn());
            Assert.AreEqual(3, CostUsage.GetColumnChartColumns());

            CostUsage.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsColumnChartDrawn());
            Assert.AreEqual(3, CostUsage.GetColumnChartColumns());

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
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-TOU-Column-005-2")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostUsageTOUSuite), "TC-J1-FVT-CostUsage-TOU-Column-005-2")]
        public void TOUColumnMonth(CostUsageData input)
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
            Assert.IsTrue(CostUsage.IsColumnChartDrawn());
            Assert.AreEqual(3, CostUsage.GetColumnChartColumns());

            CostUsage.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(CostUsage.IsColumnChartDrawn());
            Assert.AreEqual(3, CostUsage.GetColumnChartColumns());

            //Uncheck "电" and check "煤"
            CostUsage.DeSelectCommodity(input.InputData.commodityNames[0]);
            CostUsage.SelectCommodity(input.InputData.commodityNames[2]);
            EnergyViewToolbar.ShowPeakValley();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(EnergyViewToolbar.IsPeakValleyButtonEnable());
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-TOU-Column-005-3")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostUsageTOUSuite), "TC-J1-FVT-CostUsage-TOU-Column-005-3")]
        public void TOUColumnDisable(CostUsageData input)
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

            Assert.IsTrue(CostUsage.IsColumnChartDrawn());
            Assert.AreEqual(3, CostUsage.GetColumnChartColumns());

            //Save to dashboard
            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);
            TimeManager.MediumPause();

            //Set date range less than 7 days
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 23), new DateTime(2012, 7, 25));
            TimeManager.MediumPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.StepMessage[0]));
            JazzMessageBox.MessageBox.Confirm();

            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 23), new DateTime(2012, 7, 23));
            EnergyViewToolbar.SetTimeRange("10:00", "24:00");
            TimeManager.MediumPause();
            EnergyViewToolbar.ClickViewButton();
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.StepMessage[0]));
            JazzMessageBox.MessageBox.Confirm();
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
            JazzMessageBox.MessageBox.Confirm();
            
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
            JazzMessageBox.MessageBox.Confirm();
            TimeManager.MediumPause();

            WidgetMaxChart.InputEndDate(new DateTime(2012, 7, 23));
            WidgetMaxChart.SelectStartTime("10:00");
            TimeManager.ShortPause();
            WidgetMaxChart.ClickViewButton();
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.StepMessage[0]));
            JazzMessageBox.MessageBox.Confirm();
            TimeManager.MediumPause();

            WidgetMaxChart.ClickCloseButton();
        }
    }
}
