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
    [ManualCaseID("TC-J1-FVT-CostRanking-View-101"), CreateTime("2013-10-25"), Owner("Nancy")]
    public class CostRanking: TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateHome();
        }

        private static RankPanel CorporateRanking = JazzFunction.RankPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static string[] extendHierarchyNode1 = { "NancyCostCustomer2", "组织A", "园区B", "楼宇C" };
        private static string[] extendHierarchyNode2 = { "NancyCostCustomer2", "组织B", "园区C", "楼宇D" };

        [Test]
        [CaseID("TC-J1-FVT-CostRanking-View-101-1")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CostRanking), "TC-J1-FVT-CostRanking-View-101-1")]
        public void ViewTotalCostRankingData(CorporateRankingData input)
        {
            
            string[] noTagBuildingHierarchyNode= { "NancyCostCustomer2","RenameDashboardSuiteOrg","DeleteDashboardSuiteSite", "DeleteDashboardSuiteBuild"};
            string[] extendHierarchyNode = { "NancyCostCustomer2", "组织A", "园区A"};
            string[] notagHierarchyNode = { "NancyCostCustomer2", "MarkedDashboardSuiteOrg" };

            //Select the 楼宇A+楼宇B+楼宇C+楼宇D from Hierarchy Tree. 
            
            CorporateRanking.ClickSelectHierarchyButton();
            TimeManager.MediumPause();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(input.ExpectedData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(extendHierarchyNode1);
            CorporateRanking.OnlyCheckHierarchyNode(extendHierarchyNode2);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, select Cost.
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Select Ranking type=总排名; 
            //select time range=2012/07/02 to 2012/07/03 select 介质总览 to view data.
            
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[2]);
            TimeManager.LongPause();
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 2), new DateTime(2012, 7, 3));

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //·"楼宇B" and "楼宇D" can not attend ranking since they have not define cost for the tags they light.
            //use "DeleteDashboardSuiteBuild" instead  since this building have no tags.
            CorporateRanking.CheckHierarchyNode(noTagBuildingHierarchyNode);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            //No new building include in the data list.
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[1]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Select 单项 Commodity=电 to view data.·Ranking chart display.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.LongPause();
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 2), new DateTime(2012, 7, 3));

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            //CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Hierarchy tree to add 1 more hierarchy node NancyCostCustomer2/组织A/园区A
            CorporateRanking.CheckHierarchyNode(extendHierarchyNode);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //select Commodity=电, to view data.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 2), new DateTime(2012, 7, 3));
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //园区A is included in the ranking. And the chart is different from the last one.
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            //Assert.IsTrue(CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]));
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Change to 系统维度 tab, select 空调,select Commodity=电, to view chart again.
            CorporateRanking.SwitchSystemDimensionTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            CorporateRanking.ClickSelectSystemDimensionButton();
            CorporateRanking.SelectSystemDimension(input.InputData.SystemDimensionPath);
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

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            //Assert.IsTrue(CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]));
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Change different time range to view data. 
            //a. 2012/07/01 -2012/07/01    b. 2012/07/01 -2012/07/03 
            //c. 2012/07/10-2012/08/05     d. 2012/01/01-2012/12/31 lastyear   e. 2011/01/01-2013/05/30
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 1), new DateTime(2012, 7, 1));
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            //Assert.IsTrue(CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]));
            TimeManager.LongPause();
            TimeManager.LongPause();

            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 1), new DateTime(2012, 7, 3));
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            //Assert.IsTrue(CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]));
            TimeManager.LongPause();
            TimeManager.LongPause();

            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 10), new DateTime(2012, 8, 5));
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5]);
            TimeManager.MediumPause();
            //Assert.IsTrue(CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]));
            TimeManager.LongPause();
            TimeManager.LongPause();

            EnergyViewToolbar.SetDateRange(new DateTime(2012, 1, 1), new DateTime(2012, 12, 31));
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6]);
            TimeManager.MediumPause();
            //Assert.IsTrue(CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]));
            TimeManager.LongPause();
            TimeManager.LongPause();

            EnergyViewToolbar.SetDateRange(new DateTime(2011, 1, 1), new DateTime(2013, 5, 30));
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7]);
            TimeManager.MediumPause();
            //Assert.IsTrue(CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]));
            TimeManager.LongPause();
            TimeManager.LongPause();

            //楼宇C's population property is 201301.time range="2012/07/02 -2012/07/03",Change Ranking type=人均排名 to view chart.
            EnergyViewToolbar.ClickRankTypeConvertTarget();
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            //@@@@@@@@@@@@@@@@@@@@@@2
            /*
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[8]);
            TimeManager.MediumPause();
            //Assert.IsTrue(CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[8], input.InputData.failedFileName[8]));
            TimeManager.LongPause();
            TimeManager.LongPause();
             */
        }


        [Test]
        [CaseID("TC-J1-FVT-CostRanking-View-101-2")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CostRanking), "TC-J1-FVT-CostRanking-View-101-2")]
        public void ViewUnitAreaRankingData(CorporateRankingData input)
        {
            //Select 楼宇A+楼宇B+楼宇C, time range 2012/07/02 -2012/08/03, Commodity=电, Ranking type="单位面积" to view data.
            CorporateRanking.ClickSelectHierarchyButton();
            TimeManager.MediumPause();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(input.ExpectedData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(extendHierarchyNode1);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, select Cost.
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //time range 2012/07/02 -2012/08/03, Commodity=电, Ranking type="单位面积" to view data.  

            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.LongPause();
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 2), new DateTime(2012, 7, 3));

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Change chart type=数据表 to view chart again.The data view chart show UOM correctly.
            EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickRankTypeConvertTarget();
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.UnitAreaRank);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Ranking chart display. Only show two columns:楼宇A and 楼宇B. (楼宇C is not included in the ranking.)
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            //CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click "Export". Check the export function refer to SR-J1-Energy-014-Export Data Chart.

            //·Export chart/data view display as expected.


            //Click "Save to dashboard"（保存到仪表盘）to save the Trend chart to dashboard. 


        }

        [Test]
        [CaseID("TC-J1-FVT-CostRanking-View-101-3")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CostRanking), "TC-J1-FVT-CostRanking-View-101-3")]
        public void ViewUnitAreaCoalRankingData(CorporateRankingData input)
        {
            string[] extendNodes = { "NancyOtherCustomer3", "NancyOtherSite", "BuildingDayNight" };
            string[] extendNodes2 = { "NancyOtherCustomer3", "NancyNoCalendarSite", "BuildingNoCalendarNoCost" };
            //Go to NancyOtherCustomer3. Go to Function "Corporate Ranking". 
            JazzFunction.HomePage.SelectCustomer("NancyOtherCustomer3");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.LongPause();

            //Select the BuildingCostYearToDay from Hierarchy Tree. 
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Click Function Type button, select Cost, Commodity=煤, predefined time range="2012/06/01-2013/07/01" to view chart.
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);

            EnergyViewToolbar.SetDateRange(new DateTime(2012, 6, 1), new DateTime(2013, 7, 1));
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();


            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //· display blank chart.Still check Commodity=煤. Since no related data input.
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Check 1 more the BuildingNoTag from Hierarchy Tree, Commodity=煤, click to view chart.
            CorporateRanking.CheckHierarchyNode(input.ExpectedData.Hierarchies);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.ClickViewButton();

            //· No warning message, still blank ranking chart.
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            
            //Select Commodity=电，display 人均排名.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[1]);
            EnergyViewToolbar.ClickRankTypeConvertTarget();
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);
            EnergyViewToolbar.ClickViewButton();

            //·Ranking chart contain one column (BuildingCostYearToDay).
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Hierarchy tree to add 1 more Building node BuildingDayNight to view Ranking.  
            CorporateRanking.CheckHierarchyNode(extendNodes);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Commodity=电, predefined time range="2012/06/01-2013/07/01"，ranking type="总排名" to view chart.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[1]);
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 6, 1), new DateTime(2013, 7, 1));
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.TotalRank);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            TimeManager.MediumPause();

            //· · Only display one column(BuildingCostYearToDay 's data).·BuildingDayNight not attend Ranking since that no cost defined.
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
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
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Hierarchy tree to add 1 more Building node BuildingNoCalendarNoCost
            //Commodity=电, predefined time range="2012/06/01-2013/07/01"，ranking type="总排名" to view chart.
            CorporateRanking.CheckHierarchyNode(extendNodes2);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.TotalRank);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            TimeManager.MediumPause();

            //Only display one column(BuildingCostYearToDay 's data).
            //Other nodes do not attend Ranking since that no Cost defined .
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
            TimeManager.LongPause();
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-CostRanking-View-101-4")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CostRanking), "TC-J1-FVT-CostRanking-View-101-4")]
        public void ViewFiftyBuildingData(CorporateRankingData input)
        {
            
            //Go to NancyOtherCustomer3. Go to Function "Corporate Ranking". 
            JazzFunction.HomePage.SelectCustomer("NancyOtherCustomer3");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.LongPause();

            //Select the BuildingConvertStandardUOM and BuildingRanking50 from Hierarchy Tree. 
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(input.ExpectedData.Hierarchies);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Click Function Type button, select Cost, Commodity=柴油, time range=2013/01/01-2013/01/03 to view chart.
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);

            EnergyViewToolbar.SetDateRange(new DateTime(2013, 1, 1), new DateTime(2013, 1, 3));
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();


            //·  Only display one column (BuildingConvertStandardUOM 's data).
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            TimeManager.LongPause();

         }

        [Test]
        [CaseID("TC-J1-FVT-CostRanking-View-101-5")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CostRanking), "TC-J1-FVT-CostRanking-View-101-5")]
        public void ViewNullTestBuildingData(CorporateRankingData input)
        {
            string[] extendNodes = { "NancyOtherCustomer3", "NancyOtherSite", "BuildingConvertStandardUOM" };
            string[] extendNodes2 = { "NancyOtherCustomer3", "NancyNoCalendarSite", "BuildingNoCalendarNoCost" };
            //Go to NancyOtherCustomer3. Go to Function "Corporate Ranking". 
            JazzFunction.HomePage.SelectCustomer("NancyOtherCustomer3");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.LongPause();

            //Select the BuildingNullTest from Hierarchy Tree.  
             CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);

            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Click Ranking Type button, select Cost, check Commodity=电,rank type="总排名"，
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);

            //time range="今年"/2013/01/01-2013/01/07, to view data.
            EnergyViewToolbar.SetDateRange(new DateTime(2013, 1, 1), new DateTime(2013, 1, 7));
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //· Ranking chart display successfully.
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            TimeManager.LongPause();


            //check Commodity=电,rank type="单位面积"，time range="今年"/2013/01/01-2013/01/07, to view data.
            EnergyViewToolbar.ClickRankTypeConvertTarget();
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.UnitAreaRank);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();


            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //· Ranking chart display successfully.
            Assert.IsTrue(CorporateRanking.IsNoDataInEnergyGrid());
           
         }


        [Test]
        [CaseID("TC-J1-FVT-CostRanking-View-101-6")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CostRanking), "TC-J1-FVT-CostRanking-View-101-6")]
        public void ViewCostYearBuildingData(CorporateRankingData input)
        {

            //Go to NancyOtherCustomer3. Go to Function "Corporate Ranking". 
            JazzFunction.HomePage.SelectCustomer("NancyOtherCustomer3");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.LongPause();

            //Select the BuildingCostYeartoday from Hierarchy Tree.  
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);

            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Click Ranking Type button, select Cost, check Commodity=电,rank type="总排名"，
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);

            //Time range="2010/01/01-2012/12/31 to view data.
            EnergyViewToolbar.SetDateRange(new DateTime(2010, 1, 1), new DateTime(2012,12,31));
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();


            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //· Ranking chart display successfully.
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            TimeManager.LongPause();
        }

    }

}
