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

namespace Mento.Script.EnergyView.CarbonUsage
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TTC-J1-FVT-CarbonUsage-PieChart-003"), CreateTime("2014-05-29"), Owner("Emma")]
    public class CarbonUsagePieChartSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            CarbonUsage.NavigateToCarbonUsage();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        private static CarbonUsagePanel CarbonUsage = JazzFunction.CarbonUsagePanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;


        [Test]
        [CaseID("TC-J1-FVT-CarbonUsage-PieChart-003-1")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(CarbonUsagePieChartSuite), "TC-J1-FVT-CarbonUsage-PieChart-003-1")]
        public void CarbonUsagePieChart(CarbonUsageData input)
        {
            //case里面的层级节点没有，需要指定其他的层级节点
        }

        [Test]
        [CaseID("TC-J1-FVT-CarbonUsage-PieChart-003-2")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(CarbonUsagePieChartSuite), "TC-J1-FVT-CarbonUsage-PieChart-003-2")]
        public void CarbontUsagePieChartForMoreTags(CarbonUsageData input)
        {
            //Go to Carbon function.Navigate to NancyCustomer1 -> BuildingMultipleCommodities to select 总览 to view pie chart.
            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range 2010-12-29-2011-02-20  00:00 to 08:00
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.ShortPause();

            //select all commodities to view pie chart.
            CarbonUsage.SelectCommodity(input.InputData.commodityNames);
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CarbonUsage.IsDistributionChartDrawn());

            CarbonUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CarbonUsage.CompareDictionaryDataOfCarbonUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //select 总览 to view pie chart.
            CarbonUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CarbonUsage.IsDistributionChartDrawn());

            CarbonUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CarbonUsage.CompareDictionaryDataOfCarbonUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Set date range 2011-02-21-2012-07-04  08:00 to 16:00
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            TimeManager.ShortPause();

            //select all commodities to view pie chart.
            CarbonUsage.SelectCommodity(input.InputData.commodityNames);
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CarbonUsage.IsDistributionChartDrawn());

            CarbonUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[1], input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            CarbonUsage.CompareDictionaryDataOfCarbonUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //select 总览 to view pie chart.
            CarbonUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CarbonUsage.IsDistributionChartDrawn());

            CarbonUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[1], input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            CarbonUsage.CompareDictionaryDataOfCarbonUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

            //Set date range 2013-11-29-2014-05-04  16:00 to 24:00
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[2].StartTime, ManualTimeRange[2].EndTime);
            TimeManager.ShortPause();

            //select all commodities to view pie chart.
            CarbonUsage.SelectCommodity(input.InputData.commodityNames);
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CarbonUsage.IsDistributionChartDrawn());

            CarbonUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[2], input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            CarbonUsage.CompareDictionaryDataOfCarbonUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

            //select 总览 to view pie chart.
            CarbonUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CarbonUsage.IsDistributionChartDrawn());

            CarbonUsage.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[2], input.ExpectedData.expectedFileName[5]);
            TimeManager.MediumPause();
            CarbonUsage.CompareDictionaryDataOfCarbonUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
        }  
    }
   
}
