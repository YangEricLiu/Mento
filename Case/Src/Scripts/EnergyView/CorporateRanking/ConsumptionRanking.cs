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
    [ManualCaseID("TC-J1-FVT-ConsumptionRanking-View-101"), CreateTime("2013-10-25"), Owner("Greenie")]
    public class ConsumptionRanking : TestSuiteBase
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

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-View-101-1")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-View-101-1")]
        public void ViewRankingData(CorporateRankingData input)
        {
            //Select the 楼宇A from Hierarchy Tree.Click Function Type button, select Energy Consumption.
            TimeManager.MediumPause();
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);

            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Energy);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Select Commodity=电 from node,time range="2012/07/01-2012/07/03", to display chart view.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 1), new DateTime(2012, 7, 3));

            //Chart default display 总排名 Ranking· Default chart type=Column chart.
            //总排名 is default selected when switch from other function.
            //Only 1 column display.Commodity+UOM+BuildingName info from chart tooltip.
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

            //Select 人均排名 and view data.Change chart display 人均排名.
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();

            //Select Commodity=自来水 to view chart.
            //·Commodity=电 radio button change to uncheck.Commodity=自来水 radio button change check.
            //· Ranking change to display Commodity=水.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[1]);
            TimeManager.LongPause();

            Assert.IsTrue(CorporateRanking.IsCommodityChecked(input.InputData.commodityNames[1]));
            Assert.IsFalse(CorporateRanking.IsCommodityChecked(input.InputData.commodityNames[0]));

            //Select the 楼宇A+楼宇B+楼宇C+楼宇D from Hierarchy Tree and click 确定. 
            string[] hierarcy = {"NancyCostCustomer2","组织A","园区B","楼宇C"};
            string[] hierarcy2 = {"NancyCostCustomer2","组织B","园区C","楼宇D"};
            Assert.IsTrue(CorporateRanking.CheckHierarchyNode(input.ExpectedData.Hierarchies));
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            Assert.IsTrue(CorporateRanking.CheckHierarchyNode(hierarcy));
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            Assert.IsTrue(CorporateRanking.CheckHierarchyNode(hierarcy2));
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            //Click Function Type button, select Energy Consumption. 
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Energy);
            TimeManager.LongPause();

            //Select Commodity=电，rank type="总排名"，time range="2012/07/01-2012/07/03", to view chart.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 1), new DateTime(2012, 7, 3));
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //·Ranking chart display.
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
            TimeManager.LongPause();

            //Select 系统维度=空调; select Commodity=电, rank type="总排名"，range="2012/07/01-2012/07/03", to display Ranking.
            CorporateRanking.SwitchSystemDimensionTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            CorporateRanking.ClickSelectSystemDimensionButton();
            CorporateRanking.SelectSystemDimensionNode(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            CorporateRanking.SelectSystemCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 1), new DateTime(2012, 7, 3));

            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.TotalRank);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //·Ranking chart display.
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
            TimeManager.LongPause();

            //Change different time range to view data.
            //a. 2012/07/01-2012/07/31
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 1), new DateTime(2012, 7, 31));
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //·Ranking chart display.
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
            TimeManager.LongPause();

            //b. 2011/01-2013/05
            EnergyViewToolbar.SetDateRange(new DateTime(2011, 1,1), new DateTime(2013, 5,1));
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //·Ranking chart display.
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);
            TimeManager.LongPause();
            //·Export chart/data view display as expected.
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-View-101-2")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-View-101-2")]
        public void SaveToDashboard(CorporateRankingData input)
        {
            

            //Click "Save to dashboard"（保存到仪表盘）to save the Trend chart to dashboard.

            //·All chart, time range, rank order, 4 different column number buttons. 

            //Go to widget maximize view. Change time range, display order(ASC->DSEC) or set different display Column Numbers.

            //· Chart display as expected.

            //Change hierarchy node selection from H-tree again when chart view display. When click 确定.

            //· Commody radio buttons all unchecked.The chart will not redraw until click view chart button.

            //Click "清空" from hierarchy tree.

            //·All checked hierarchy node change to uncheck.
            //· The chart will not redraw to display blank until click view chart button.

            //Verify column chart x-aris display.


            //·Hierarchy node name display for each column.
            //When hierarchy node name to long, change to display short+"……"

        }


        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-View-101-3")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-View-101-3")]
        public void ConsumptionTotalRanking(CorporateRankingData input)
        {
            //Go to NancyOtherCustomer3. Go to Function "Corporate Ranking". 
            //Select the BuildingRanking1 to BuildingRanking50 from Hierarchy Tree. 
            
            JazzFunction.HomePage.SelectCustomer("NancyOtherCustomer3");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
            int i = 1;
            string[] NodePath = {"NancyOtherCustomer3","NancyOtherSite","" };
            CorporateRanking.ClickSelectHierarchyButton();
    
            while (i <= 50)
            {
                if(i!=10)
                {
                    NodePath[2] = "BuildingRankin10";
                    CorporateRanking.CheckHierarchyNode(NodePath);
    
                }
                else
                {
                    NodePath[2] = "BuildingRanking" + i;
                    CorporateRanking.CheckHierarchyNode(NodePath);

                }
                i++;
            }
            

            //Click Ranking Type button, select Energy Consumption, 
            //check Commodity=电,rank type="总排名"，time range="今年", to view data.
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Energy);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.TotalRank);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            //Ranking chart display.All first 20 columns show in 1 page.Default selected 20 button from chart.
            //·Ranking chart display.
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            EnergyViewToolbar.TimeSpan(TimeSpans.DeleteAllTimeSpans);

            //Click 50 button from chart.·All 1 to 50 columns show in 1 page.


            //Click 10 button from chart.· All 1 to 10 columns show in 1 page.


            //Drag scroll bar to begining.· All first 10 columns(1-10) show in 1 page.

            //Drag scroll bar to end.· All last 10 columns(41-50) show in 1 page.

            //Drag scroll bar to start from 40. Then click 20 button.· 20 columns(31-50) display. 


            //Drag scroll bar to let BuildingRanking3 be the first one on the focus page
            //( BuildingRanking3-BuildingRanking22).Click 10 button.


            //·Ranking chart display. 
            //The focus page should cover 10 buildings (BuildingRanking3 - BuildingRanking12).


            //Verify tooltip display.
            //· For the first column, the tooltip shows 4 things (ranking info, building name, commodity and UOM):
            //·"排名:1/50"
            //·BuildingRanking1.
            //·电:80.00KWH


            //Verify ASC/DESC order.


            //· Default display ASC order.· BuildingRanking1 first and BuildingRanking50 last.


            //Click DESC order button.


            //· Change to display DESC order.BuildingRanking50 first and BuildingRanking1 last.
        }


        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-View-101-4")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-View-101-4")]
        public void ViewCostYearBuildingData(CorporateRankingData input)
        {
            //·Change Ranking type=人均排名. Time range= "2013/01/03-2013/02/03".
            //·Ranking chart display. Should only see 5 columns (BuildingRanking1-4, BuildingRanking50)
            //Verify calendar display. ·No calendar display as expected.
            //Verify optional steps display.·No optional steps display as expected.
            //Verify navigator display.· No navigator display.

            //Click Hierarchy tree to add 1 more hierarchy node BuildingMultipleSteps, Commodity=电 ,to Ranking again.

            //· No more column adding since that BuildingMultipleSteps didn't have lighten Commodity=电 tag.
            //· The Ranking total building number is still 50 from Tooltip.


            //Click Hierarchy tree to add 1 more hierarchy node BuildingCostYearToDay from Hierarchy Tree
            //change Commodity=煤, time rang= "2012/07/31-2012/08/01" to view chart. 



            //· Chart Ranking change to display Commodity=煤. Only see one column BuildingCostYearToDay.



            //Change Commodity=电 again. Change different time range to view data.
            //a. 2013/01/01-2013/01/02
            //b. 2012/01/01-2013/01/31


            //· No warning message display show include tag step not support. 
            //· The chart contain 51 columns(BuildingRanking1-50 and BuildingCostYearToDay).


            //Change chart type=数据图 to view chart again.
            
            
            //The data view chart format refer to PRS standard.


            
        }


        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-View-101-5")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-View-101-5")]
        public void ViewZxhUserAConsumption(CorporateRankingData input)
        {
            string[] extendNode = { "NancyOtherCustomer3", "NancyNoCalendarSite", "BuildingNoPeopleProperty" };
            string[] extendNode2 = { "NancyOtherCustomer3", "NancyNoCalendarSite", "BuildingDayNight" };
            //Go to NancyOtherCustomer3. Go to Function "Corporate Ranking". 
            //click hierarchy tree to select 3 nodes: BuildingNoCalendarNoCost, NancyNoCalendarSite and BuildingNoPeopleProperty.
            JazzFunction.HomePage.SelectCustomer("NancyOtherCustomer3");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.LongPause();

            //Select the BuildingCostYeartoday from Hierarchy Tree.  
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(input.ExpectedData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(extendNode);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            // Commodity=电,time range="去年", Ranking Type="人均排名" to view Ranking.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.OpenMoreButton();
            TimeManager.ShortPause();
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            EnergyViewToolbar.ClickRankTypeConvertTarget();
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();


            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //·only see two chart columns (BuildingNoCalendarNoCost and NancyNoCalendarSite).
            //BuildingNoPeopleProperty does not attend Ranking since it defines no population property.
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Hierarchy tree to add 1 more Building node BuildingDayNight to view Ranking. 
            CorporateRanking.CheckHierarchyNode(extendNode2);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            //Commodity=电,time range="去年", Ranking Type="人均排名" to view Ranking.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.OpenMoreButton();
            TimeManager.ShortPause();
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            EnergyViewToolbar.ClickRankTypeConvertTarget();
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //only see two columns. 
            //BuildingNoPeopleProperty and BuildingDayNight do not attend Ranking since that they do not define the population property.
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Go to a Commodity different FunctionType and select different Unit to verify chart view title（查看功能=能效分析，碳排放，成本） 
            //select predefined time range=之前7天，今天，昨天，本周，上周，本月，上月，今年，去年.

            //· 时间+总/人均/单位面积/单位供冷面积/单位采暖面积用能排名，

            //· 时间+总/人均/单位面积/单位供冷面积/单位采暖面积碳排放排名，

            //· 时间+总/人均/单位面积/单位供冷面积/单位采暖面积成本排名。


            //Go to a Commodity different FunctionType and select different Unit to verify chart view title（查看功能=能效分析，碳排放，成本）
            //select manual defined time range=时间=2012/01/01-2012/12/31

            //· 自定义时间+总/人均/单位面积/单位供冷面积/单位采暖面积用能排名，
            //· 自定义时间+总/人均/单位面积/单位供冷面积/单位采暖面积碳排放排名，
            // · 自定义时间+总/人均/单位面积/单位供冷面积/单位采暖面积成本排名。


            //Go to NancyOtherCustomer3. Go to Function "Corporate Ranking". Select the BuildingNullTest from Hierarchy Tree. Click Ranking Type button, select Energy Consumption, check Commodity=电,rank type="总排名"，time range="今年"/2013/01/01-2013/01/07, to view data.
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-View-101-6")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-View-101-6")]
        public void ViewLastYearConsumption(CorporateRankingData input)
        {
            string[] extendNode = { "NancyOtherCustomer3", "NancyNoCalendarSite", "BuildingNoPeopleProperty" };
            string[] extendNode2 = { "NancyOtherCustomer3", "NancyNoCalendarSite", "BuildingDayNight" };
            //Go to NancyOtherCustomer3. Go to Function "Corporate Ranking". 
            //click hierarchy tree to select 3 nodes: BuildingNoCalendarNoCost, NancyNoCalendarSite and BuildingNoPeopleProperty.
            JazzFunction.HomePage.SelectCustomer("NancyOtherCustomer3");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.LongPause();

            //Select the BuildingCostYeartoday from Hierarchy Tree.  
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(input.ExpectedData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(extendNode);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            // Commodity=电,time range="去年", Ranking Type="人均排名" to view Ranking.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.OpenMoreButton();
            TimeManager.ShortPause();
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            EnergyViewToolbar.ClickRankTypeConvertTarget();
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();


            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //·only see two chart columns (BuildingNoCalendarNoCost and NancyNoCalendarSite).
            //BuildingNoPeopleProperty does not attend Ranking since it defines no population property.
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Hierarchy tree to add 1 more Building node BuildingDayNight to view Ranking. 
            CorporateRanking.CheckHierarchyNode(extendNode2);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            //Commodity=电,time range="去年", Ranking Type="人均排名" to view Ranking.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.OpenMoreButton();
            TimeManager.ShortPause();
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            EnergyViewToolbar.ClickRankTypeConvertTarget();
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //only see two columns. 
            //BuildingNoPeopleProperty and BuildingDayNight do not attend Ranking since that they do not define the population property.
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Go to a Commodity different FunctionType and select different Unit to verify chart view title（查看功能=能效分析，碳排放，成本） 
            //select predefined time range=之前7天，今天，昨天，本周，上周，本月，上月，今年，去年.

            //· 时间+总/人均/单位面积/单位供冷面积/单位采暖面积用能排名，

            //· 时间+总/人均/单位面积/单位供冷面积/单位采暖面积碳排放排名，

            //· 时间+总/人均/单位面积/单位供冷面积/单位采暖面积成本排名。


            //Go to a Commodity different FunctionType and select different Unit to verify chart view title（查看功能=能效分析，碳排放，成本）
            //select manual defined time range=时间=2012/01/01-2012/12/31

            //· 自定义时间+总/人均/单位面积/单位供冷面积/单位采暖面积用能排名，
            //· 自定义时间+总/人均/单位面积/单位供冷面积/单位采暖面积碳排放排名，
            // · 自定义时间+总/人均/单位面积/单位供冷面积/单位采暖面积成本排名。


            //Go to NancyOtherCustomer3. Go to Function "Corporate Ranking". Select the BuildingNullTest from Hierarchy Tree. Click Ranking Type button, select Energy Consumption, check Commodity=电,rank type="总排名"，time range="今年"/2013/01/01-2013/01/07, to view data.
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-View-101-7")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-View-101-7")]
        public void ViewNullTestBuildingData(CorporateRankingData input)
        {
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
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Energy);
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
            Assert.IsTrue(CorporateRanking.IsNoDataInEnergyGrid());
            //· Ranking chart display successfully.
            // Null data here @@@@@@@@@@
            /*
            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            */
        }
    }

}
