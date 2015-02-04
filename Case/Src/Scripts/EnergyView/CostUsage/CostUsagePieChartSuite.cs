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
    [ManualCaseID("TC-J1-FVT-CostUsage-Pie-101"), CreateTime("2014-05-29"), Owner("Emma")]
    public class CostUsagePieChartSuite : TestSuiteBase
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

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-Pie-101-1")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostUsagePieChartSuite), "TC-J1-FVT-CostUsage-Pie-101-1")]
        public void CostUsagePieChart(CostUsageData input)
        {
            //Go to Cost chart view. Navigate to Hierarchy list 组织A->园区A->楼宇A, then go to 介质单项.
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range 2012/07/29-2012/08/04  4:00 to 21:00
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.ShortPause();

            //Select all Commodities 电， 水 and 煤 to display Distribution chart.
            CostUsage.SelectCommodity(input.InputData.commodityNames);
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportMulTimeDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
        
            //Go to 介质总览 to display Distribution chart.
            CostUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportMulTimeDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Save to dashboard
            var dashboard = input.InputData.DashboardInfos;
            EnergyViewToolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            TimeManager.MediumPause();

            //Change Hierarchy list to 组织A, then go to 空调 System Dimension.
            CostUsage.SelectHierarchy(input.InputData.HierarchiesArray[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            CostUsage.SwitchTagTab(TagTabs.SystemDimensionTab);
            TimeManager.ShortPause();

            CostUsage.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Change manually defined time range to 2012/06/29-2012/07/04 21:00 to 24:00
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            TimeManager.ShortPause();

            //Select all Commodities 电， 水 and 煤 to display Distribution chart..
            CostUsage.SelectCommodity(input.InputData.commodityNames);
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportMulTimeDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[1], input.ExpectedData.expectedFileName[2], input.InputData.SystemDimensionPath);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Go to 总览 of 组织A->空调.
            CostUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportMulTimeDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[1], input.ExpectedData.expectedFileName[3], input.InputData.SystemDimensionPath);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

            EnergyViewToolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            TimeManager.MediumPause();

            //Change Hierarchy list to 楼宇A, then go to 一层 Area Dimension.
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            CostUsage.SwitchTagTab(TagTabs.AreaDimensionTab);
            TimeManager.ShortPause();

            CostUsage.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Change manually defined time range to 2012/06/29-2012/07/04 21:00 to 24:00
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            TimeManager.ShortPause();

            //Select all Commodities 电， 水 and 煤 to display Distribution chart..
            CostUsage.SelectCommodity(input.InputData.commodityNames);
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportMulTimeDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[1], input.ExpectedData.expectedFileName[4], input.InputData.AreaDimensionPath);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

            //Go to 总览 of 楼宇A->一层.
            CostUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportMulTimeDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[1], input.ExpectedData.expectedFileName[5], input.InputData.AreaDimensionPath);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);

            EnergyViewToolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);
            TimeManager.MediumPause();


        }

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-Pie-101-2")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostUsagePieChartSuite), "TC-J1-FVT-CostUsage-Pie-101-2")]
        public void CostUsagePieChartForMoreCommodities(CostUsageData input)
        {
            //Go to Cost function.Navigate to NancyCustomer1 -> BuildingMultipleCommodities to select 总览 to view pie chart.
            JazzFunction.HomePage.SelectCustomer("NancyCustomer1");
            TimeManager.MediumPause();
            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range 2010-12-29-2011-02-20  00:00 to 08:00
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.ShortPause();

            //select all commodities to view pie chart.
            CostUsage.SelectCommodity(input.InputData.commodityNames);
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportMulTimeDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //select 总览 to view pie chart.
            CostUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportMulTimeDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Set date range 2011-02-21-2012-07-04  08:00 to 16:00
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            TimeManager.ShortPause();

            //select all commodities to view pie chart.
            CostUsage.SelectCommodity(input.InputData.commodityNames);
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportMulTimeDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[1], input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //select 总览 to view pie chart.
            CostUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportMulTimeDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[1], input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

            //Set date range 2013-11-29-2014-05-04  16:00 to 24:00
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[2].StartTime, ManualTimeRange[2].EndTime);
            TimeManager.ShortPause();

            //select all commodities to view pie chart.
            CostUsage.SelectCommodity(input.InputData.commodityNames);
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportMulTimeDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[2], input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

            //select 总览 to view pie chart.
            CostUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportMulTimeDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[2], input.ExpectedData.expectedFileName[5]);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-RuleUpdate-Pie-101-1")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostUsagePieChartSuite), "TC-J1-FVT-CostUsage-RuleUpdate-Pie-101-1")]
        public void CostUsagePieChartRuleUpdate01(CostUsageData input)
        {
            //Go to NancyCostCustomer2->园区A/楼宇B 系统空调/区域一层， go to Cost 总览, select time range to view pie chart
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //go to 空调 System Dimension.
            CostUsage.SwitchTagTab(TagTabs.SystemDimensionTab);
            TimeManager.ShortPause();

            CostUsage.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //总览
            CostUsage.SelectCommodity();
            //CostUsage.SelectCommodity(input.InputData.commodityNames);

            //A. 2012/07/30 01:00 to 2012/08/01 23:00.
            var ManualTimeRange = input.InputData.ManualTimeRange;

            for (int i = 0; i < ManualTimeRange.Length; i++)
            {
                EnergyViewToolbar.SetDateRange(ManualTimeRange[i].StartDate, ManualTimeRange[i].EndDate);
                EnergyViewToolbar.SetTimeRange(ManualTimeRange[i].StartTime, ManualTimeRange[i].EndTime);
                TimeManager.ShortPause();

                EnergyViewToolbar.View(EnergyViewType.Distribute);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.MediumPause();

                Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

                CostUsage.ExportMulTimeDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[i], input.ExpectedData.expectedFileName[i]);
                TimeManager.MediumPause();
                CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[i], input.InputData.failedFileName[i]);
            }

            //go to 一层 Area Dimension
            CostUsage.SwitchTagTab(TagTabs.AreaDimensionTab);
            TimeManager.ShortPause();

            CostUsage.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //总览
            CostUsage.SelectCommodity();
            //CostUsage.SelectCommodity(input.InputData.commodityNames[0]);
            //CostUsage.SelectCommodity(input.InputData.commodityNames[1]);
            //CostUsage.SelectCommodity(input.InputData.commodityNames[2]);

            for (int i = 0; i < ManualTimeRange.Length; i++)
            {
                EnergyViewToolbar.SetDateRange(ManualTimeRange[i].StartDate, ManualTimeRange[i].EndDate);
                EnergyViewToolbar.SetTimeRange(ManualTimeRange[i].StartTime, ManualTimeRange[i].EndTime);
                TimeManager.ShortPause();

                EnergyViewToolbar.View(EnergyViewType.Distribute);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.MediumPause();

                Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

                CostUsage.ExportMulTimeDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[i], input.ExpectedData.expectedFileName[i + 5]);
                TimeManager.MediumPause();
                CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[i + 5], input.InputData.failedFileName[i + 5]);
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-RuleUpdate-Pie-101-2")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostUsagePieChartSuite), "TC-J1-FVT-CostUsage-RuleUpdate-Pie-101-2")]
        public void CostUsagePieChartRuleUpdate02(CostUsageData input)
        {
            //Go to NancyCostCustomer2->园区A/楼宇A 系统空调/区域一层， go to Cost 单项=电, select time range to view pie chart
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //go to 空调 System Dimension.
            CostUsage.SwitchTagTab(TagTabs.SystemDimensionTab);
            TimeManager.ShortPause();

            CostUsage.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //电
            CostUsage.SelectCommodity(input.InputData.commodityNames);

            //A. 2012/07/30 01:00 to 2012/08/01 23:00.
            var ManualTimeRange = input.InputData.ManualTimeRange;

            for (int i = 0; i < ManualTimeRange.Length; i++)
            {
                EnergyViewToolbar.SetDateRange(ManualTimeRange[i].StartDate, ManualTimeRange[i].EndDate);
                EnergyViewToolbar.SetTimeRange(ManualTimeRange[i].StartTime, ManualTimeRange[i].EndTime);
                TimeManager.ShortPause();

                EnergyViewToolbar.View(EnergyViewType.Distribute);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.MediumPause();

                Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

                CostUsage.ExportMulTimeDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[i], input.ExpectedData.expectedFileName[i]);
                TimeManager.MediumPause();
                CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[i], input.InputData.failedFileName[i]);
            }

            //go to 一层 Area Dimension
            CostUsage.SwitchTagTab(TagTabs.AreaDimensionTab);
            TimeManager.ShortPause();

            CostUsage.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //电
            CostUsage.SelectCommodity(input.InputData.commodityNames);

            for (int i = 0; i < ManualTimeRange.Length; i++)
            {
                EnergyViewToolbar.SetDateRange(ManualTimeRange[i].StartDate, ManualTimeRange[i].EndDate);
                EnergyViewToolbar.SetTimeRange(ManualTimeRange[i].StartTime, ManualTimeRange[i].EndTime);
                TimeManager.ShortPause();

                EnergyViewToolbar.View(EnergyViewType.Distribute);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.MediumPause();

                Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

                CostUsage.ExportMulTimeDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[i], input.ExpectedData.expectedFileName[i + 5]);
                TimeManager.MediumPause();
                CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[i + 5], input.InputData.failedFileName[i + 5]);
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-RuleUpdate-Pie-101-3")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostUsagePieChartSuite), "TC-J1-FVT-CostUsage-RuleUpdate-Pie-101-3")]
        public void CostUsagePieChartRuleUpdate03(CostUsageData input)
        {
            //Go to UT tool. Go to Cost.Select NancyOtherCustomer3->BuildingLabellingNull, select Commodity=电 to view pie chart
            JazzFunction.HomePage.SelectCustomer("NancyOtherCustomer3");
            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //select Commodity=电
            CostUsage.SelectCommodity(input.InputData.commodityNames);

            //Set date range A. 2012/12/31 20:00 to 2013/01/01 4:00.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            for (int i = 1; i < ManualTimeRange.Length; i++)
            {
                EnergyViewToolbar.SetDateRange(ManualTimeRange[i].StartDate, ManualTimeRange[i].EndDate);
                EnergyViewToolbar.SetTimeRange(ManualTimeRange[i].StartTime, ManualTimeRange[i].EndTime);
                TimeManager.ShortPause();

                EnergyViewToolbar.View(EnergyViewType.Distribute);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.MediumPause();

                Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

                CostUsage.ExportMulTimeDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[i], input.ExpectedData.expectedFileName[i - 1]);
                TimeManager.MediumPause();
                CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[i - 1], input.InputData.failedFileName[i - 1]);
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-RuleUpdate-Pie-101-4")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostUsagePieChartSuite), "TC-J1-FVT-CostUsage-RuleUpdate-Pie-101-4")]
        public void CostUsagePieChartRuleUpdate04(CostUsageData input)
        {
            //Go to UT tool. Go to Cost. Select NancyOtherCustomer3->BuildingMissingData, select Commodity=电， select different time range to view pie chart
            JazzFunction.HomePage.SelectCustomer("NancyOtherCustomer3");
            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //select Commodity=电
            CostUsage.SelectCommodity(input.InputData.commodityNames);

            //Set date range A. 2012/01/01 23:00 to 2013/03/01 3:00.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportMulTimeDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
        }
   }
}
