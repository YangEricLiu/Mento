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

namespace Mento.Script.EnergyView.EnergyManagement
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-SaveToDashboard-101"), CreateTime("2014-07-09"), Owner("Emma")]
    public class SaveToDashboardSuite : TestSuiteBase
    {
        private static Widget Widget = JazzFunction.Widget;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        private static SaveToDashboardDialog SaveToDs = new SaveToDashboardDialog();
        private static RankPanel CorporateRanking = JazzFunction.RankPanel;
        private static CostPanel CostUsage = JazzFunction.CostPanel;
        private static CarbonUsagePanel CarbonUsage = JazzFunction.CarbonUsagePanel;
        private static RatioPanel RadioPanel = JazzFunction.RatioPanel;
        private static UnitKPIPanel UnitKPIPanel = JazzFunction.UnitKPIPanel;
        private static IndustryLabellingPanel IndustryLabellingPanel = JazzFunction.IndustryLabellingPanel;

        [SetUp]
        public void CaseSetUp()
        {
            HomePagePanel.NavigateToEnergyView();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.LoginPage.RefreshJazz("NancyCustomer1");
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-EA-1")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-EA-1")]
        public void EnergyAnalysisSingleHierarchySaveToDashboard(EnergyViewOptionData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfos;

            //A. Select Single Hierarchy node 楼宇A BuildingA_P1_Electricity.
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Check tag and view line chart , A. 之前七天, line chart
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //非工作时间
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ShowCalendarNonWorkday);
            TimeManager.LongPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last30Day);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, pie
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[2].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName)); 
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-EA-2")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-EA-2")]
        public void EnergyAnalysisMultiHierarchySaveToDashboard(EnergyViewOptionData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfos;

            //B. Select Multiple Hierarchy node 楼宇A BuildingA_P1_Electricity+楼宇B BuildingB_P1_Electricity+BuildingB_P2_Water. 
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            for (int i = 0; i < input.InputData.MultipleHierarchyAndtags.Length; i++)
            {
                MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[i].HierarchyPath);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.ShortPause();

                MultiHieCompareWindow.CheckTags(input.InputData.MultipleHierarchyAndtags[i].TagsName);
                TimeManager.ShortPause();
            }

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();

            //之前12月, line
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last12Month);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //本月, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisMonth);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //昨天, data view
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Yesterday);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName)); 
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-Cost-1")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-Cost-1")]
        public void CostBuildingATotalSaveToDashboard(CostUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfos;

            //Select 楼宇A总览
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //之前七天, line chart
            CostUsage.SelectCommodity();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //非工作时间
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ShowCalendarNonWorkday);
            TimeManager.LongPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last30Day);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, pie
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[2].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName)); 
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-Cost-2")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-Cost-2")]
        public void CostBuildingBElectricitySaveToDashboard(CostUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfos;

            //Select 楼宇B电
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            CostUsage.SelectCommodity(input.InputData.commodityNames);
            TimeManager.MediumPause();

            //之前12月, line
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last12Month);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //冷暖季
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ShowCalendarHeatCool);
            TimeManager.LongPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //本月, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisMonth);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //今年, pie
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //昨天, data view
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Yesterday);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[2].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName)); 
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-Cost-3")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-Cost-3")]
        public void CostSiteAElecWaterTotalSaveToDashboard(CostUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfos;

            //Select 园区A电+水
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            CostUsage.SelectCommodity(input.InputData.commodityNames);
            TimeManager.MediumPause();

            //今天, line
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Today);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //本周, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisWeek);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //上月, pie
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //去年, data view
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[2].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName)); 
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-Carbon-1")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-Carbon-1")]
        public void CarbonBuildingATotalSaveToDashboard(CarbonUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            CarbonUsage.NavigateToCarbonUsage();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfo;

            //Select 楼宇A总览
            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //之前七天, line chart
            CarbonUsage.SelectCommodity();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //非工作时间
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ShowCalendarNonWorkday);
            TimeManager.LongPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last30Day);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, pie
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[2].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName)); 
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-Carbon-2")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-Carbon-2")]
        public void CarbonBuildingBElectricitySaveToDashboard(CarbonUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            CarbonUsage.NavigateToCarbonUsage();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfo;

            //Select 楼宇B电
            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            CarbonUsage.SelectCommodity(input.InputData.commodityNames);
            TimeManager.MediumPause();

            //之前12月, line
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last12Month);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //冷暖季
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ShowCalendarHeatCool);
            TimeManager.LongPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            TimeManager.LongPause();

            //本月, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisMonth);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            TimeManager.LongPause();

            //今年, pie
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);
            TimeManager.LongPause();

            //昨天, data view
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Yesterday);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[2].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-Carbon-3")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-Carbon-3")]
        public void CarbonSiteAElecWaterTotalSaveToDashboard(CarbonUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            CarbonUsage.NavigateToCarbonUsage();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfo;

            //Select 园区A电+水
            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            CarbonUsage.SelectCommodity(input.InputData.commodityNames);
            TimeManager.MediumPause();

            //今天, line
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Today);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //本周, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisWeek);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //上月, pie
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //去年, data view
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[2].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-Ratio-1")]
        [MultipleTestDataSource(typeof(RatioData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-Ratio-1")]
        public void RatioSingleHierarchySaveToDashboard(RatioData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            RadioPanel.NavigateToRatio();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfo;

            //A. Select Single Hierarchy node 楼宇A BuildingA_P1_Electricity.
            RadioPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //昼夜比, A. 之前七天, line chart
            RadioPanel.CheckTag(input.InputData.tagNames[0]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //非工作时间
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ShowCalendarNonWorkday);
            TimeManager.LongPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last30Day);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[2].WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-Ratio-2")]
        [MultipleTestDataSource(typeof(RatioData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-Ratio-2")]
        public void RatioMultiHierarchySaveToDashboard(RatioData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            RadioPanel.NavigateToRatio();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfo;

            //B. Select Multiple Hierarchy node 楼宇A BuildingA_P1_Electricity+楼宇B BuildingB_P1_Electricity+BuildingB_P2_Water. 
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            for (int i = 0; i < input.InputData.MultipleHierarchyAndtags.Length; i++)
            {
                MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[i].HierarchyPath);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.ShortPause();

                MultiHieCompareWindow.CheckTags(input.InputData.MultipleHierarchyAndtags[i].TagsName);
                TimeManager.ShortPause();
            }

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();

            //公休比
            EnergyViewToolbar.SelectRadioTypeConvertTarget(RadioTypeConvertTarget.WorkNonRadio);
            TimeManager.ShortPause();

            //之前12月, line
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last12Month);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //本月, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisMonth);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickStepButtonOnWindow(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //今年, data view
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[2].WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-UnitIndicator-1")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-UnitIndicator-1")]
        public void UnitIndicatorSingleHierarchySaveToDashboard(UnitIndicatorData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfo;

            //A. Select Single Hierarchy node 楼宇A BuildingA_P1_Electricity.
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //单位人口, A. 之前七天, line chart
            UnitKPIPanel.CheckTag(input.InputData.tagNames[0]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Select 严寒地区B区通讯营业厅
            EnergyViewToolbar.SelectIndustryConvertTarget(input.InputData.Industry);
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last30Day);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[2].WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-UnitIndicator-2")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-UnitIndicator-2")]
        public void UnitIndicatorMultiHierarchySaveToDashboard(UnitIndicatorData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfo;

            //B. Select Multiple Hierarchy node 楼宇A BuildingA_P1_Electricity+楼宇B BuildingB_P1_Electricity+BuildingB_P2_Water. 
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            for (int i = 0; i < input.InputData.MultipleHierarchyAndtags.Length; i++)
            {
                MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[i].HierarchyPath);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.ShortPause();

                MultiHieCompareWindow.CheckTags(input.InputData.MultipleHierarchyAndtags[i].TagsName);
                TimeManager.ShortPause();
            }

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();

            //之前12月, line
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last12Month);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //本月, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisMonth);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //今年, data view
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[2].WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-UnitIndicatorCost-1")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-UnitIndicatorCost-1")]
        public void UnitIndicatorCostBuildingATotalSaveToDashboard(UnitIndicatorData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfo;

            //Select 楼宇A总览, Convert to cost
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.LongPause();

            //之前七天, line chart
            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //非工作时间
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ShowCalendarNonWorkday);
            TimeManager.LongPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last30Day);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-UnitIndicatorCost-2")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-UnitIndicatorCost-2")]
        public void UnitIndicatorCostBuildingBElectricitySaveToDashboard(UnitIndicatorData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfo;

            //Select 楼宇B电, Convert to cost
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.LongPause();

            UnitKPIPanel.SelectCommodityUnitCost(input.InputData.Commodity);
            TimeManager.MediumPause();

            //Select 严寒地区B区机房
            EnergyViewToolbar.SelectIndustryConvertTarget(input.InputData.Industry);
            TimeManager.MediumPause();

            //之前12月, line
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last12Month);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //冷暖季
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ShowCalendarHeatCool);
            TimeManager.LongPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //本月, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisMonth);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //昨天, data view
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Yesterday);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-UnitIndicatorCost-3")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-UnitIndicatorCost-3")]
        public void UnitIndicatorCostSiteAElecWaterTotalSaveToDashboard(UnitIndicatorData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfo;

            //Select 园区A电+水, Convert to cost
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            UnitKPIPanel.SelectCommodityUnitCost(input.InputData.Commodity);
            TimeManager.MediumPause();

            //今天, line
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Today);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //本周, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisWeek);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //去年, data view
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-UnitIndicatorCarbon-1")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-UnitIndicatorCarbon-1")]
        public void UnitIndicatorCarbonBuildingATotalSaveToDashboard(UnitIndicatorData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfo;

            //Select 楼宇A总览, Convert to cost
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.ShortPause();

            //之前七天, line chart
            UnitKPIPanel.SelectCommodityUnitCarbon();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //非工作时间
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ShowCalendarNonWorkday);
            TimeManager.LongPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last30Day);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-UnitIndicatorCarbon-2")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-UnitIndicatorCarbon-2")]
        public void UnitIndicatorCarbonBuildingBElectricitySaveToDashboard(UnitIndicatorData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfo;

            //Select 楼宇B电, Convert to cost
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.ShortPause();

            UnitKPIPanel.SelectCommodityUnitCarbon(input.InputData.Commodity);
            TimeManager.MediumPause();

            //Select 严寒地区B区机房
            EnergyViewToolbar.SelectIndustryConvertTarget(input.InputData.Industry);
            TimeManager.MediumPause();

            //之前12月, line
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last12Month);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //冷暖季
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ShowCalendarHeatCool);
            TimeManager.LongPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //本月, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisMonth);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //昨天, data view
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Yesterday);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-UnitIndicatorCarbon-3")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-UnitIndicatorCarbon-3")]
        public void UnitIndicatorCarbonSiteAElecWaterTotalSaveToDashboard(UnitIndicatorData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfo;

            //Select 园区A电+水, Convert to cost
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.ShortPause();

            UnitKPIPanel.SelectCommodityUnitCarbon(input.InputData.Commodity);
            TimeManager.MediumPause();

            //今天, line
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Today);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //本周, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisWeek);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //去年, data view
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-Labelling-1")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-Labelling-1")]
        public void LabellingSingleHierarchySaveToDashboard(IndustryLabellingData input)
        {
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            IndustryLabellingPanel.NavigateToIndustryLabelling();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfo;

            //Select 园区能耗标识 BuildingLabelling1
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Select Labellingtag1
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            //单位人口 2014全年
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValues[0]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            IndustryLabellingPanel.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //单位人口 2013全年
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[1].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[1].month);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValues[0]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //昼夜比 2014全年
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValues[1]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            IndustryLabellingPanel.Toolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //昼夜比 2013全年
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[1].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[1].month);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValues[1]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //工休比 2014全年
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValues[2]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            IndustryLabellingPanel.Toolbar.SaveToDashboard(dashboard[4].WigetName, dashboard[4].HierarchyName, dashboard[4].IsCreateDashboard, dashboard[4].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //工休比 2013全年
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[1].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[1].month);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValues[2]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[5].WigetName, dashboard[5].HierarchyName, dashboard[5].IsCreateDashboard, dashboard[5].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[2].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[4].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[5].WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-Labelling-2")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-Labelling-2")]
        public void LabellingMultiHierarchySaveToDashboard(IndustryLabellingData input)
        {
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            IndustryLabellingPanel.NavigateToIndustryLabelling();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfo;

            //Select Multiple Hierarchy node 园区能耗标识 BuildingLabelling1 Labellingtag1 + BuildingLabelling2 Labellingtag2 + BuildingLabelling3 Labellingtag3. 
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            for (int i = 0; i < input.InputData.MultipleHierarchyAndtags.Length; i++)
            {
                MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[i].HierarchyPath);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.ShortPause();

                MultiHieCompareWindow.CheckTags(input.InputData.MultipleHierarchyAndtags[i].TagsName);
                TimeManager.ShortPause();
            }

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();

            //单位人口 2014全年
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValues[0]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            IndustryLabellingPanel.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //单位人口 2013全年
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[1].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[1].month);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValues[0]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //昼夜比 2014全年
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValues[1]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            IndustryLabellingPanel.Toolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //昼夜比 2013全年
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[1].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[1].month);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValues[1]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //工休比 2014全年
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValues[2]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            IndustryLabellingPanel.Toolbar.SaveToDashboard(dashboard[4].WigetName, dashboard[4].HierarchyName, dashboard[4].IsCreateDashboard, dashboard[4].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //工休比 2013全年
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[1].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[1].month);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValues[2]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[5].WigetName, dashboard[5].HierarchyName, dashboard[5].IsCreateDashboard, dashboard[5].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[2].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[4].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[5].WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-CorporateRanking-1")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-CorporateRanking-1")]
        public void RankingHierarchySaveToDashboard(CorporateRankingData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfo;

            //Select the 楼宇A+B+C+D+园区A+B+组织A+B from Hierarchy Tree. 
            CorporateRanking.ClickSelectHierarchyButton();
            TimeManager.MediumPause();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[2]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[3]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[4]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[5]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[6]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[7]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, select Carbon.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Select default Ranking type=总排名, 之前30天, 电
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.LongPause();
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last30Day);
            TimeManager.MediumPause();

            //Select Column
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Select data list
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Click Function Type button, select Cost.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Select default Ranking type=总排名, 之前12月, 电
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.LongPause();
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last12Month);
            TimeManager.MediumPause();

            //Select Column
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.Toolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Select data list
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Click Function Type button, select Energy.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Energy);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Select default Ranking type=总排名, 2014年（今年）, 电
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.LongPause();
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);
            TimeManager.MediumPause();

            //Select Column
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.Toolbar.SaveToDashboard(dashboard[4].WigetName, dashboard[4].HierarchyName, dashboard[4].IsCreateDashboard, dashboard[4].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Select data list
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.Toolbar.SaveToDashboard(dashboard[5].WigetName, dashboard[5].HierarchyName, dashboard[5].IsCreateDashboard, dashboard[5].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[2].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[4].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[5].WigetName));
        }
    }
}
