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
    public class ViewConsumptionRankingData : TestSuiteBase
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

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-View-101-1")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ViewConsumptionRankingData), "TC-J1-FVT-ConsumptionRanking-View-101-1")]
        public void ViewRankingData(CorporateRankingData input)
        {
            //1. Select the 楼宇A from Hierarchy Tree.Click Function Type button, select Energy Consumption.
            TimeManager.MediumPause();
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[0]);

            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading(10);
            TimeManager.Pause(4000);

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Energy);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Select Commodity=电 from node,time range="2012/07/01-2012/07/03", to display chart view.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            //Chart default display 总排名 Ranking· Default chart type=Column chart.
            //总排名 is default selected when switch from other function.
            //Only 1 column display.Commodity+UOM+BuildingName info from chart tooltip.
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

            //2. Select 人均排名 and view data.Change chart display 人均排名.
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //3.Select Commodity=自来水 to view chart.
            //·Commodity=电 radio button change to uncheck.Commodity=自来水 radio button change check.
            //· Ranking change to display Commodity=水.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[1]);
            TimeManager.LongPause();

            Assert.IsTrue(CorporateRanking.IsCommodityChecked(input.InputData.commodityNames[1]));
            Assert.IsFalse(CorporateRanking.IsCommodityChecked(input.InputData.commodityNames[0]));

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

            //4.Select the 楼宇A+楼宇B+楼宇C+楼宇D from Hierarchy Tree and click 确定. 
            Assert.IsTrue(CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[1]));
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            Assert.IsTrue(CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[2]));
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            Assert.IsTrue(CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[3]));
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            //Click Function Type button, select Energy Consumption. 
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Energy);
            TimeManager.LongPause();

            //5.Select Commodity=电，rank type="总排名"，time range="2012/07/01-2012/07/03", to view chart.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //·Ranking chart display.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);
            TimeManager.LongPause();

            //6.Select 系统维度=空调; select Commodity=电, rank type="总排名"，range="2012/07/01-2012/07/03", to display Ranking.
            CorporateRanking.SwitchSystemDimensionTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            CorporateRanking.SelectSystemDimensionNode(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            CorporateRanking.SelectSystemCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.TotalRank);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //·Ranking chart display.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
            TimeManager.LongPause();

            //7.Change different time range to view data.
            //a. 2012/07/01-2012/07/31
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //·Ranking chart display.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);
            TimeManager.LongPause();

            //8. 2011/01-2013/05
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //·Ranking chart display.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);
            TimeManager.LongPause();
            //·Export chart/data view display as expected.
        }

        //Not Planned--Manual Test
        /*
        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-View-101-2")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ViewConsumptionRankingData), "TC-J1-FVT-ConsumptionRanking-View-101-2")]
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
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ViewConsumptionRankingData), "TC-J1-FVT-ConsumptionRanking-View-101-3")]
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
        */

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-View-101-3")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ViewConsumptionRankingData), "TC-J1-FVT-ConsumptionRanking-View-101-3")]
        public void ViewFiftyBuildingData(CorporateRankingData input)
        {
            //Select the BuildingRanking1 to BuildingRanking50 from Hierarchy Tree. 
            JazzFunction.HomePage.SelectCustomer("NancyOtherCustomer3");
            CorporateRanking.NavigateToCorporateRanking();
            string[] BuildingNames = { "BuildingRanking1", "BuildingRanking2", "BuildingRanking3", "BuildingRanking4", "BuildingRanking5", "BuildingRanking6", "BuildingRanking7", "BuildingRanking8", "BuildingRanking9", "BuildingRanking10", "BuildingRanking11", "BuildingRanking12", "BuildingRanking13", "BuildingRanking14", "BuildingRanking15", "BuildingRanking16", "BuildingRanking17", "BuildingRanking18", "BuildingRanking19", "BuildingRanking20", "BuildingRanking21", "BuildingRanking22", "BuildingRanking23", "BuildingRanking24", "BuildingRanking25", "BuildingRanking26", "BuildingRanking27", "BuildingRanking28", "BuildingRanking29", "BuildingRanking30", "BuildingRanking31", "BuildingRanking32", "BuildingRanking33", "BuildingRanking34", "BuildingRanking35", "BuildingRanking36", "BuildingRanking37", "BuildingRanking38", "BuildingRanking39", "BuildingRanking40", "BuildingRanking41", "BuildingRanking42", "BuildingRanking43", "BuildingRanking44", "BuildingRanking45", "BuildingRanking46", "BuildingRanking47", "BuildingRanking48", "BuildingRanking49", "BuildingRanking50" };
            int i = 0;
            CorporateRanking.ClickSelectHierarchyButton();
            while (i < 50)
            {
                input.InputData.Hierarchies[0][2] = BuildingNames[i];
                CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
                i++;
            }
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            TimeManager.ShortPause();
            //Click Ranking Type button, select Energy Consumption, 
            //check Commodity=电,rank type="总排名"，time range="去年", to view data.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading(60);
            TimeManager.MediumPause();
            //·Ranking chart display.
            
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.LongPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();           

            //·2.Change Ranking type=人均排名. Time range= "2013/01/03-2013/02/03".
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            //·Ranking chart display.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
            TimeManager.LongPause();

            //3.Click Hierarchy tree to add 1 more hierarchy node BuildingMultipleSteps, Commodity=电 ,to Ranking again.
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            //·Ranking chart display.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
            TimeManager.LongPause();

            //4.Click Hierarchy tree to add 1 more hierarchy node BuildingCostYearToDay from Hierarchy Tree 
            //change Commodity=煤, time rang= "2012/07/31-2012/08/01" to view chart. 
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[2]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[1]);
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading(30);
            TimeManager.LongPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            //·Ranking chart display.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
            TimeManager.LongPause();

            //5.Change Commodity=电 again. Change different time range to view data.
            //a. 2013/01/01-2013/01/02
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading(30);
            TimeManager.MediumPause();
            //·Ranking chart display.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);
            TimeManager.LongPause();

            //6.Change Commodity=电 again. Change different time range to view data.
            //b. 2012/09/01-2013/01/20
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.SetDateRange(ManualTimeRange[4].StartDate, ManualTimeRange[4].EndDate);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading(30);
            TimeManager.LongPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            //·Ranking chart display.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-View-101-4")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ViewConsumptionRankingData), "TC-J1-FVT-ConsumptionRanking-View-101-4")]
        public void ViewZxhUserAConsumption(CorporateRankingData input)
        {
            //Login with zxhUserA. 
            JazzFunction.HomePage.ExitJazz();
            TimeManager.MediumPause();
            JazzFunction.LoginPage.LoginWithOption("zxhUserA", "zxh123", "NancyOtherCustomer3");
            TimeManager.LongPause();
            //Go to NancyOtherCustomer3. Go to Function "Corporate Ranking". 
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.LongPause();
            string[] BuildingNames = { "BuildingRanking1", "BuildingRanking2", "BuildingRanking3", "BuildingRanking4", "BuildingRanking5", "BuildingRanking6", "BuildingRanking7", "BuildingRanking8", "BuildingRanking9", "BuildingRanking10", "BuildingRanking11", "BuildingRanking12", "BuildingRanking13", "BuildingRanking14", "BuildingRanking15", "BuildingRanking16", "BuildingRanking17", "BuildingRanking18", "BuildingRanking19", "BuildingRanking20", "BuildingRanking21", "BuildingRanking22", "BuildingRanking23", "BuildingRanking24", "BuildingRanking25", "BuildingRanking26", "BuildingRanking27", "BuildingRanking28", "BuildingRanking29", "BuildingRanking30", "BuildingRanking31", "BuildingRanking32", "BuildingRanking33", "BuildingRanking34", "BuildingRanking35", "BuildingRanking36", "BuildingRanking37", "BuildingRanking38", "BuildingRanking39", "BuildingRanking40", "BuildingRanking41", "BuildingRanking42", "BuildingRanking43", "BuildingRanking44", "BuildingRanking45", "BuildingRanking46", "BuildingRanking47", "BuildingRanking48", "BuildingRanking49", "BuildingRanking50" };

            //select BuildingRanking1 to BuildingRanking50,   
            int i = 0;
            CorporateRanking.ClickSelectHierarchyButton();
            while (i < 50)
            {
                input.InputData.Hierarchies[0][2] = BuildingNames[i];
                CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
                i++;
            }
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            TimeManager.ShortPause();

            // Commodity=电,time range="2012-1-1 to 2012-12-31", 
            // Commodity=电,time range="2012-1-1 to 2012-1-31", 
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.MediumPause();
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-View-101-5")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ViewConsumptionRankingData), "TC-J1-FVT-ConsumptionRanking-View-101-5")]
        public void ViewLastYearConsumption(CorporateRankingData input)
        {
            //Go to NancyOtherCustomer3. Go to Function "Corporate Ranking". 
            //click hierarchy tree to select 3 nodes: BuildingNoCalendarNoCost, NancyNoCalendarSite and BuildingNoPeopleProperty.
            JazzFunction.HomePage.SelectCustomer("NancyOtherCustomer3");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.LongPause();

            //Select the BuildingCostYeartoday from Hierarchy Tree.  
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[2]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading(10);
            TimeManager.LongPause();

            // Commodity=电,time range="2012-1-1 to 2012-12-31",, Ranking Type="人均排名" to view Ranking.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //·only see two chart columns (BuildingNoCalendarNoCost and NancyNoCalendarSite).
            //BuildingNoPeopleProperty does not attend Ranking since it defines no population property.
            TimeManager.LongPause();
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Hierarchy tree to add 1 more Building node BuildingDayNight to view Ranking. 
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[3]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading(10);
            TimeManager.LongPause();
            //Commodity=电,time range="去年", Ranking Type="人均排名" to view Ranking.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            //only see two columns. 
            //BuildingNoPeopleProperty and BuildingDayNight do not attend Ranking since that they do not define the population property.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            
            //3.Go to a Commodity different FunctionType and select different Unit to verify chart view title（查看功能=能效分析，碳排放，成本） 
            //select predefined time range=之前7天，今天，昨天，本周，上周，本月，上月，今年，去年.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.LongPause();
            //range = "2013-1-1 to 2013-1-7"
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.LongPause();
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            
            //range = "2013-2-1 to 2013-2-2"
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            TimeManager.LongPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            //昨天
            //range = "2013-3-1 to 2013-3-2"
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
            TimeManager.LongPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            //本月
            //range = "2013-4-1 to 2013-4-30"
            EnergyViewToolbar.SetDateRange(ManualTimeRange[4].StartDate, ManualTimeRange[4].EndDate);
            TimeManager.LongPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            //range = "2013-5-1 to 2013-5-31"
            EnergyViewToolbar.SetDateRange(ManualTimeRange[5].StartDate, ManualTimeRange[5].EndDate);
            TimeManager.LongPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            //本周
            //range = "2013-6-1 to 2013-6-7"
            EnergyViewToolbar.SetDateRange(ManualTimeRange[6].StartDate, ManualTimeRange[6].EndDate);
            TimeManager.LongPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            //上周
            //range = "2013-7-1 to 2013-7-7"
            EnergyViewToolbar.SetDateRange(ManualTimeRange[7].StartDate, ManualTimeRange[7].EndDate);
            TimeManager.LongPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[8]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[8], input.InputData.failedFileName[8]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            //今年
            //range = "2013-1-1 to 2013-12-31"
            EnergyViewToolbar.SetDateRange(ManualTimeRange[8].StartDate, ManualTimeRange[8].EndDate);
            TimeManager.LongPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[9]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[9], input.InputData.failedFileName[9]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            //去年
            //range = "2012-1-1 to 2012-12-31"
            EnergyViewToolbar.SetDateRange(ManualTimeRange[9].StartDate, ManualTimeRange[9].EndDate);
            TimeManager.LongPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[10]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[10], input.InputData.failedFileName[10]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //4.Go to a Commodity different FunctionType and select different Unit to verify chart view title（查看功能=能效分析，碳排放，成本）
            //select manual defined time range=时间=2012/01/01-2012/12/31
            //range = "2012-1-1 to 2012-12-31"
            EnergyViewToolbar.SetDateRange(ManualTimeRange[9].StartDate, ManualTimeRange[9].EndDate);
            TimeManager.LongPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[11]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[11], input.InputData.failedFileName[11]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            
            //range = "2012-1-1 to 2012-12-31"
            EnergyViewToolbar.SetDateRange(ManualTimeRange[9].StartDate, ManualTimeRange[9].EndDate);
            TimeManager.LongPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[12]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[12], input.InputData.failedFileName[12]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Energy);
            TimeManager.LongPause();
            //range = "2012-1-1 to 2012-12-31"
            EnergyViewToolbar.SetDateRange(ManualTimeRange[9].StartDate, ManualTimeRange[9].EndDate);
            TimeManager.LongPause();
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[13]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[13], input.InputData.failedFileName[13]);
            TimeManager.LongPause();
            TimeManager.LongPause();            
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-View-101-6")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ViewConsumptionRankingData), "TC-J1-FVT-ConsumptionRanking-View-101-6")]
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
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);

            //time range="今年"/2013/01/01-2013/01/07, to view data.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            //· Ranking chart display successfully.
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-View-101-7")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ViewConsumptionRankingData), "TC-J1-FVT-ConsumptionRanking-View-101-7")]
        public void ViewNullTestBuildingDataUnitArea(CorporateRankingData input)
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

            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            //rank type="单位面积"，
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.UnitAreaRank);
            //time range="今年"/2013/01/01-2013/01/07, to view data.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate); 
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            //· Ranking chart display successfully.
            //no data
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            TimeManager.LongPause();
            TimeManager.LongPause();  
            
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-View-101-8")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(ViewConsumptionRankingData), "TC-J1-FVT-ConsumptionRanking-View-101-8")]
        public void ClickTenRanking(CorporateRankingData input)
        {
            //Select NancyCostCustomer2->楼宇A. Last 7 days
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.LongPause();

            //Select the BuildingNullTest from Hierarchy Tree.  
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[0]);

            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading(10);
            TimeManager.LongPause();

            //Click Ranking Type button, select Cost, check Commodity=电,rank type="总排名"，
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);

            //time range="今年"/2013/01/01-2013/01/07, to view data.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate); ;
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            CorporateRanking.ClickTenRankButton();     
        }

    }

}
