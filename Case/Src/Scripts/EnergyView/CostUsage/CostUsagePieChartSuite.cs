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

            CostUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
        
            //Go to 介质总览 to display Distribution chart.
            CostUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

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

            CostUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[1], input.ExpectedData.expectedFileName[2], input.InputData.SystemDimensionPath);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Go to 总览 of 组织A->空调.
            CostUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[1], input.ExpectedData.expectedFileName[3], input.InputData.SystemDimensionPath);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

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

            CostUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[1], input.ExpectedData.expectedFileName[4], input.InputData.AreaDimensionPath);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

            //Go to 总览 of 楼宇A->一层.
            CostUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[1], input.ExpectedData.expectedFileName[5], input.InputData.AreaDimensionPath);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
        }

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-Pie-101-2")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostUsagePieChartSuite), "TC-J1-FVT-CostUsage-Pie-101-2")]
        public void CostUsagePieChartForMoreTags(CostUsageData input)
        {
            //Go to Cost function.Navigate to NancyCustomer1 -> BuildingMultipleCommodities to select 总览 to view pie chart.
            JazzFunction.HomePage.SelectCustomer("NancyCustomer1");
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

            CostUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //select 总览 to view pie chart.
            CostUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[1]);
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

            CostUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[1], input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //select 总览 to view pie chart.
            CostUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[1], input.ExpectedData.expectedFileName[3]);
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

            CostUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[2], input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

            //select 总览 to view pie chart.
            CostUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CostUsage.IsDistributionChartDrawn());

            CostUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[2], input.ExpectedData.expectedFileName[5]);
            TimeManager.MediumPause();
            CostUsage.CompareDictionaryDataOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
        }
    }
}
