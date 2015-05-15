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
    [ManualCaseID("TC-J1-FVT-CostUsage-DataView-001"), CreateTime("2013-08-16"), Owner("Emma")]
    public class P1_CostUsageDataViewSuite : TestSuiteBase
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
            TimeManager.MediumPause();
        }

        private static CostPanel CostUsage = JazzFunction.CostPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysisPanel = JazzFunction.EnergyAnalysisPanel;

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-DataView-001-1")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(P1_CostUsageDataViewSuite), "TC-J1-FVT-CostUsage-DataView-001-1")]
        public void P1_CostUsageDataView(CostUsageData input)
        {
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            
            //Set date range
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 29), new DateTime(2012, 8, 4));
            EnergyViewToolbar.SetTimeRange("00:00", "16:00");
            TimeManager.ShortPause();
            
            //Check tag and view data view, hourly
            CostUsage.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Hour);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Save to dashboard
            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);
            TimeManager.LongPause();

            //On homepage, check the dashboard
            CostUsage.NavigateToAllDashBoards();
            HomePagePanel.SelectHierarchyNode(dashboard.HierarchyName);
            TimeManager.LongPause();
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));
            //Assert.IsTrue(HomePagePanel.CompareMinWidgetDataView(CostUsage.CostPath, input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0], dashboard.WigetName));
        
            //Uncheck "electricity" and check "water"
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CostUsage);
            TimeManager.MediumPause();

            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            
            //Set date range
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 29), new DateTime(2012, 8, 4));
            EnergyViewToolbar.SetTimeRange("00:00", "16:00");
            TimeManager.ShortPause();
            
            //Check tag and view data view, hourly
            CostUsage.SelectCommodity(input.InputData.commodityNames[1]);
            EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.IsTrue(CostUsage.IsDataViewDrawn());
            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Hour);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Uncheck "water" and check "coal"
            CostUsage.DeSelectCommodity(input.InputData.commodityNames[1]);
            CostUsage.SelectCommodity(input.InputData.commodityNames[2]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //Assert.IsTrue(CostUsage.IsDataViewDrawn());
            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Hour);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
        
            //Check "介质总览"
            CostUsage.SelectCommodity();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.IsTrue(CostUsage.IsDataViewDrawn());
            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Hour);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-DataView-001-3842")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(P1_CostUsageDataViewSuite), "TC-J1-FVT-CostUsage-DataView-001-3842")]
        public void CostUsageDataView3842(CostUsageData input)
        {
            //goto "NancyCostCustomer2/组织A/园区A/楼宇A"
            CostUsage.SelectHierarchy(input.InputData.HierarchiesArray[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range 2013-11-18 to 2013-11-24
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //Check "介质总览"
            CostUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Select "NancyOtherCustomer3"
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            //goto "NancyOtherCustomer3/NancyOtherSite/BuildingCostYearToDay"
            CostUsage.SelectHierarchy(input.InputData.HierarchiesArray[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range 2012-1-1 to 2013-12-10
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            //Check "介质总览"
            CostUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            CostUsage.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            CostUsage.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

        }

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-DataView-002")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(P1_CostUsageDataViewSuite), "TC-J1-FVT-CostUsage-DataView-002")]
        public void P1_CostUsageRawValueDisplayForTotal(CostUsageData input)
        {
            //Navigate to Energy Management. Go to Cost chart view. Navigate to Hierarchy list 组织B->园区C>楼宇D&空调.
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            CostUsage.SwitchTagTab(TagTabs.SystemDimensionTab);
            TimeManager.ShortPause();

            CostUsage.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Change manually defined time range to 2012/07/29-2012/08/04. 
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //Go to 介质总览 to display Data view. Click Optional step=Raw step.
            CostUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //change step to raw
            CostUsage.ClickDisplayStep(DisplayStep.Min);
            //JazzMessageBox.LoadingMask.WaitChartMaskerLoading();//弹出提示框，不需要Load Chart，无需等待时间太长
            TimeManager.MediumPause();

            //界面中支持分钟步长，没有信息框弹出
            //Check Warning message 
            //Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.StepMessage[0]));
            //CostUsage.ClickGiveupButtonOnWindow();
            //JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            //TimeManager.LongPause();

            ////Check display step is not raw but still day. 
            //Assert.AreEqual(true, CostUsage.IsDisplayStepPressed(DisplayStep.Day));
            //Assert.AreEqual(false, CostUsage.IsDisplayStepPressed(DisplayStep.Hour));
            //Assert.AreEqual(false, CostUsage.IsDisplayStepPressed(DisplayStep.Min));

            //check data
            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Click "Save to dashboard" to save the Data view to Home page dashboard named "CarbonWidgetHomeDataview"
            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);
            TimeManager.LongPause();

            //On homepage, check the dashboards
            CostUsage.NavigateToAllDashBoards();
            HomePagePanel.SelectHierarchyNode(dashboard.HierarchyName);
            TimeManager.MediumPause();
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));

        }

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-DataView-003")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(P1_CostUsageDataViewSuite), "TC-J1-FVT-CostUsage-DataView-003")]
        public void CostUsageRawValueDisplayForSingleCommodity(CostUsageData input)
        {
            //Change Hierarchy list to 组织A->园区A->楼宇A-〉空调, then go to 介质单项.
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            CostUsage.SwitchTagTab(TagTabs.SystemDimensionTab);
            TimeManager.ShortPause();

            CostUsage.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Change manually defined time range to 2012/07/29-2012/08/04. 
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //Select Commodity=电 to display Data view. Click Optional step=Raw step.
            CostUsage.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            CostUsage.ClickDisplayStep(DisplayStep.Min);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Check Raw chart display successfully.
            Assert.IsTrue(CostUsage.IsDisplayStepPressed(DisplayStep.Min));
            Assert.IsTrue(CostUsage.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsTrue(CostUsage.IsDisplayStepDisplayed(DisplayStep.Day));

            //Select Commodity=水 to display Data view.
            CostUsage.SelectCommodity(input.InputData.commodityNames[1]);
            EnergyViewToolbar.ClickViewButton();
            //JazzMessageBox.LoadingMask.WaitChartMaskerLoading();//弹出提示框，不需要Load Chart，无需等待时间太长
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Check Raw chart display successfully.Warning message and uncheck Commodity=水
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.StepMessage[0]));
            CostUsage.ClickGiveupButtonOnWindow();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Check commodity=水 is uncheck
            Assert.AreEqual(true, CostUsage.IsCommodityChecked(input.InputData.commodityNames[0]));
            Assert.AreEqual(false, CostUsage.IsCommodityChecked(input.InputData.commodityNames[1]));
            Assert.AreEqual(false, CostUsage.IsCommodityChecked(input.InputData.commodityNames[2]));

            //Select Commodity=煤 to display Data view.
            CostUsage.SelectCommodity(input.InputData.commodityNames[2]);
            EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            //JazzMessageBox.LoadingMask.WaitChartMaskerLoading();//弹出提示框，不需要Load Chart，无需等待时间太长
            TimeManager.LongPause();

            //Check Warning message 
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.StepMessage[0]));
            CostUsage.ClickGiveupButtonOnWindow();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Check Commodity=煤 is uncheck.
            Assert.AreEqual(true, CostUsage.IsCommodityChecked(input.InputData.commodityNames[0]));
            Assert.AreEqual(false, CostUsage.IsCommodityChecked(input.InputData.commodityNames[1]));
            Assert.AreEqual(false, CostUsage.IsCommodityChecked(input.InputData.commodityNames[2]));

            //check data
            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Click "Save to dashboard" to save the Data view to Home page dashboard named "CarbonWidgetHomeDataview"
            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);
            TimeManager.LongPause();

            //On homepage, check the dashboards
            CostUsage.NavigateToAllDashBoards();
            HomePagePanel.SelectHierarchyNode(dashboard.HierarchyName);
            TimeManager.MediumPause();
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-DataView-004")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(P1_CostUsageDataViewSuite), "TC-J1-FVT-CostUsage-DataView-004")]
        public void AllCommoditiesCostView(CostUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCustomer1");
            TimeManager.LongPause();
            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //select time range=Select time range 2013/12/31 12:00 to 2014/10/31 8:00
            EnergyViewToolbar.SetDateRange(input.InputData.ManualTimeRange[0].StartDate, input.InputData.ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(input.InputData.ManualTimeRange[0].StartTime, input.InputData.ManualTimeRange[0].EndTime);
            TimeManager.ShortPause();

            //Select 总览 to display Data view. Click Optional step=month
            CostUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            CostUsage.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Export to excel. Verify the export data value compared with the data view.
            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Keep select time range 2013/12/31 12:00 to 2014/10/31 8:00 to view pie chart.
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Check · There are 11 Commodities display pie chart view.
            CostUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, input.InputData.ManualTimeRange[0], input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Change chart type to Data view. Select time range 上周， change chart type to the data view.Optional step=Hour
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastWeek);
            TimeManager.ShortPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitLoading();
            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Export to excel. Verify the export data value compared with the data vgetlinesiew.
            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Hour);
            TimeManager.MediumPause();
            //Check· The excel value is equal to the data before export.
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Select time range 上月， change chart type to trend chart  to view.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);
            TimeManager.ShortPause();
            EnergyViewToolbar.View(EnergyViewType.Line);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //+Change the step to day,it will take little time to export excel or compare data
            CostUsage.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Check · There are 11 lines in trend chart.
            //Assert.AreEqual(11, EnergyAnalysisPanel.GetTrendChartLines());//It is not 11 lines when no data for some lines.
            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Save to dashboard. Go to dashboard to verify the dashboard chart value.
            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);
            TimeManager.LongPause();

            //On homepage, check the dashboards
            CostUsage.NavigateToAllDashBoards();
            HomePagePanel.SelectHierarchyNode(dashboard.HierarchyName);
            TimeManager.MediumPause();
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));

            //Check · There are 11 lines in trend chart.
            //HomePagePanel.ClickOnWidget(dashboard.WigetName);
            //TimeManager.ShortPause();
            //Assert.AreEqual(11, EnergyAnalysisPanel.GetTrendChartLines());//It is not 11 lines when no data for some lines.
        }
    }
}
