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

namespace Mento.Script.EnergyView.CorporateRanking
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-CostRanking-View-101"), CreateTime("2013-10-25"), Owner("Greenie")]
    public class ViewCostRankingData: TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CorporateRanking.RankingCaseSetUp();
        }

        [TearDown]
        public void CaseTearDown()
        {
            CorporateRanking.RankingCaseTearDown();
        }

        private static RankPanel CorporateRanking = JazzFunction.RankPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static string[] extendHierarchyNode1 = { "NancyCostCustomer2", "组织A", "园区B", "楼宇C" };
        private static string[] extendHierarchyNode2 = { "NancyCostCustomer2", "组织B", "园区C", "楼宇D" };

        [Test]
        [CaseID("TC-J1-FVT-CostRanking-View-101-1")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ViewCostRankingData), "TC-J1-FVT-CostRanking-View-101-1")]
        public void ViewTotalCostRankingData(CorporateRankingData input)
        {
            //Select the 楼宇A+楼宇B+楼宇C+楼宇D from Hierarchy Tree. 
            
            CorporateRanking.ClickSelectHierarchyButton();
            TimeManager.MediumPause();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[2]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[3]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, select Cost.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Select Ranking type=总排名; 
            //select time range=2012/07/02 to 2012/07/03 select 介质总览 to view data.
            
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[2]);
            TimeManager.LongPause();
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate); 

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //·"楼宇B" and "楼宇D" can not attend ranking since they have not define cost for the tags they light.
            //use "DeleteDashboardSuiteBuild" instead  since this building have no tags.
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[4]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading(10);
            TimeManager.MediumPause();
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[2]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            //No new building include in the data list.
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[1]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Select 单项 Commodity=电 to view data.·Ranking chart display. + 园区A
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[5]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading(10);
            TimeManager.MediumPause();

            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.LongPause();
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate); 

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
           
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            
            //Click Hierarchy tree to add 1 more hierarchy node NancyCostCustomer2/组织A/园区A
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[5]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //select Commodity=电, to view data.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate); 
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            
            //园区A is included in the ranking. And the chart is different from the last one.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            
            //Change to 系统维度 tab, select 空调,select Commodity=电, to view chart again.
            CorporateRanking.SwitchSystemDimensionTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            CorporateRanking.SelectSystemDimensionNode(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            CorporateRanking.SelectSystemCommodity(input.InputData.commodityNames[0]);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Change different time range to view data. 
            //a. 2012/07/01 -2012/07/01      
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate); 
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //b. 2012/07/01 -2012/07/03 
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate); 
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //c. 2012/07/10-2012/08/05 
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //d. 2012/01/01-2012/12/31 lastyear 
            EnergyViewToolbar.SetDateRange(ManualTimeRange[4].StartDate, ManualTimeRange[4].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //e. 2011/01/01-2013/05/30
            EnergyViewToolbar.SetDateRange(ManualTimeRange[5].StartDate, ManualTimeRange[5].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //楼宇C's population property is 201301.time range="2012/07/02 -2012/07/03",Change Ranking type=人均排名 to view chart.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate); 
            
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            //@@@@@@@@@@@@@@@@@@@@@@2
            
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[8]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[8], input.InputData.failedFileName[8]);
            TimeManager.LongPause();
            TimeManager.LongPause();
        }


        [Test]
        [CaseID("TC-J1-FVT-CostRanking-View-101-2")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ViewCostRankingData), "TC-J1-FVT-CostRanking-View-101-2")]
        public void ViewUnitAreaRankingData(CorporateRankingData input)
        {
            //Select 楼宇D+楼宇B, time range 2012/07/02 -2012/08/03, Commodity=电, Ranking type="单位面积" to view data.
            CorporateRanking.ClickSelectHierarchyButton();
            TimeManager.MediumPause();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.OnlyCheckHierarchyNode(extendHierarchyNode1);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, select Cost.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //time range 2012/07/02 -2012/08/03, Commodity=电, Ranking type="单位面积" to view data.  

            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.LongPause();
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate); 

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Change chart type=数据表 to view chart again.The data view chart show UOM correctly.
            EnergyViewToolbar.View(EnergyViewType.List);
            
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.UnitAreaRank);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Ranking chart display. Only show two columns:楼宇D and 楼宇B. (楼宇C is not included in the ranking.)
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click "Export". Check the export function refer to SR-J1-Energy-014-Export Data Chart.

            //·Export chart/data view display as expected.


            //Click "Save to dashboard"（保存到仪表盘）to save the Trend chart to dashboard. 


        }

        [Test]
        [CaseID("TC-J1-FVT-CostRanking-View-101-3")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ViewCostRankingData), "TC-J1-FVT-CostRanking-View-101-3")]
        public void ViewUnitAreaCoalRankingData(CorporateRankingData input)
        {
            //Go to NancyOtherCustomer3. Go to Function "Corporate Ranking". 
            JazzFunction.HomePage.SelectCustomer("NancyOtherCustomer3");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.LongPause();

            //Select the BuildingCostYearToDay from Hierarchy Tree. 
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading(10);
            TimeManager.LongPause();

            //Click Function Type button, select Cost, Commodity=煤, predefined time range="2012/06/01-2013/07/01" to view chart.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate); 
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();


            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //· display blank chart.Still check Commodity=煤. Since no related data input.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Check 1 more the BuildingNoTag from Hierarchy Tree, Commodity=煤, click to view chart.
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.ClickViewButton();

            //· No warning message, still blank ranking chart.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            
            //Select Commodity=电，display 人均排名.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[1]);
            
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);
            EnergyViewToolbar.ClickViewButton();

            //·Ranking chart contain one column (BuildingCostYearToDay).
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Hierarchy tree to add 1 more Building node BuildingDayNight to view Ranking.  
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[2]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Commodity=电, predefined time range="2012/06/01-2013/07/01"，ranking type="总排名" to view chart.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[1]);
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate); 
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.TotalRank);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            TimeManager.MediumPause();

            //· · Only display one column(BuildingCostYearToDay 's data).·BuildingDayNight not attend Ranking since that no cost defined.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //change ranking type="人均排名" or "单位面积排名" to view chart.
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.UnitAreaRank);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            TimeManager.MediumPause();

            //Only display one column(BuildingCostYearToDay 's data). BuildingDayNight not attend Ranking. Since it define no cost or unit area property.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Hierarchy tree to add 1 more Building node BuildingNoCalendarNoCost
            //Commodity=电, predefined time range="2012/06/01-2013/07/01"，ranking type="总排名" to view chart.
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[3]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading(10);
            TimeManager.LongPause();

            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.TotalRank);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            TimeManager.MediumPause();

            //Only display one column(BuildingCostYearToDay 's data).
            //Other nodes do not attend Ranking since that no Cost defined .
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
            TimeManager.LongPause();
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-CostRanking-View-101-4")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ViewCostRankingData), "TC-J1-FVT-CostRanking-View-101-4")]
        public void ViewFiftyBuildingData(CorporateRankingData input)
        {
            
            //Go to NancyOtherCustomer3. Go to Function "Corporate Ranking". 
            JazzFunction.HomePage.SelectCustomer("NancyOtherCustomer3");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.LongPause();

            //Select the BuildingConvertStandardUOM and BuildingRanking50 from Hierarchy Tree. 
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading(10);
            TimeManager.LongPause();

            //Click Function Type button, select Cost, Commodity=柴油, time range=2013/01/01-2013/01/03 to view chart.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);

            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();


            //·  Only display one column (BuildingConvertStandardUOM 's data).
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            TimeManager.LongPause();

         }

        [Test]
        [CaseID("TC-J1-FVT-CostRanking-View-101-5")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ViewCostRankingData), "TC-J1-FVT-CostRanking-View-101-5")]
        public void ViewNullTestBuildingData(CorporateRankingData input)
        {
            //Go to NancyOtherCustomer3. Go to Function "Corporate Ranking". 
            JazzFunction.HomePage.SelectCustomer("NancyOtherCustomer3");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.LongPause();

            //Select the BuildingNullTest from Hierarchy Tree.  
             CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[0]);

            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading(10);
            TimeManager.LongPause();

            //Click Ranking Type button, select Cost, check Commodity=电,rank type="总排名"，
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);

            //time range="今年"/2013/01/01-2013/01/07, to view data.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //· Ranking chart display successfully.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //check Commodity=电,rank type="单位面积"，time range="今年"/2013/01/01-2013/01/07, to view data.
            
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.UnitAreaRank);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();


            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //· Ranking chart display successfully.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
         }

        [Test]
        [CaseID("TC-J1-FVT-CostRanking-View-101-6")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ViewCostRankingData), "TC-J1-FVT-CostRanking-View-101-6")]
        public void ViewCostYearBuildingData(CorporateRankingData input)
        {
            //Go to NancyOtherCustomer3. Go to Function "Corporate Ranking". 
            JazzFunction.HomePage.SelectCustomer("NancyOtherCustomer3");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.LongPause();

            //Select the BuildingCostYeartoday from Hierarchy Tree.  
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading(10);
            TimeManager.LongPause();

            //Commodity=电,rank type="总能耗"
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);      
            TimeManager.ShortPause();

            //Time range="2010/01/01-2012/12/31 to view data.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //· Ranking chart display successfully.
            //The Ranking building should display value BuildingCostYeartoday even if 2010/01 to 2012/05 not defined 成本电价.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            TimeManager.LongPause();
        }
    }
}
