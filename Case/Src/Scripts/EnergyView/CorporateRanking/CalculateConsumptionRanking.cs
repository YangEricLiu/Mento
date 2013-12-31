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
    [ManualCaseID("TC-J1-FVT-ConsumptionRanking-Calculate-101"), CreateTime("2013-12-16"), Owner("Greenie")]
    public class CalculateConsumptionRanking : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.HomePage.SelectCustomer("NancyOtherCustomer3");
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
        [CaseID("TC-J1-FVT-ConsumptionRanking-Calculate-101-1")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CalculateConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-Calculate-101-1")]
        public void CalcFiveBuildingConsumptionRanking(CorporateRankingData input)
        {
            //Go to Function Ranking. Select the BuildingRanking1 to 5 from Hierarchy Tree. 
            string[] hierarchyNodePath1 = {"NancyOtherCustomer3","NancyOtherSite","BuildingRanking3"};
            string[] hierarchyNodePath2 = { "NancyOtherCustomer3", "NancyOtherSite", "BuildingRanking4" };
            string[] hierarchyNodePath3 = { "NancyOtherCustomer3", "NancyOtherSite", "BuildingRanking5" };
            CorporateRanking.ClickSelectHierarchyButton();
            TimeManager.MediumPause();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(input.ExpectedData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(hierarchyNodePath1);
            CorporateRanking.OnlyCheckHierarchyNode(hierarchyNodePath2);
            CorporateRanking.OnlyCheckHierarchyNode(hierarchyNodePath3);

            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            //Click Ranking Type button, select Cost, check Commodity=电. 
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Energy);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();            
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.LongPause();

            // 1.Change different time range to view data.  a. 2013/01/01-2013/01/07
            EnergyViewToolbar.SetDateRange(new DateTime(2013, 1, 1), new DateTime(2013, 1, 7));

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

            // 2.Change different time range to view data.  b. This year
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //3.Select Ranking type=人均排名 and view data.
            EnergyViewToolbar.ClickRankTypeConvertTarget();
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
            TimeManager.LongPause();
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-Calculate-101-2")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CalculateConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-Calculate-101-2")]
        public void CalcSystemNodeConsumptionAverageRanking(CorporateRankingData input)
        {
            //1.Select the NancyCostCustomer2->楼宇A->空调 from Hierarchy Tree.
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            CorporateRanking.SwitchSystemDimensionTab();
            TimeManager.LongPause();

            CorporateRanking.SelectSystemDimensionNode(input.InputData.SystemDimensionPath);
            TimeManager.LongPause();

            //Click Function Type button, select EnergyConsumption, then go to 介质单项.
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Energy);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Change manually defined time range to 2012/07/01-2012/08/30.
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 1), new DateTime(2013,11,1));
            TimeManager.LongPause();
            TimeManager.LongPause();
            //Select Commodity=电 to display trend chart; Unit=单位人口.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.ClickRankTypeConvertTarget();
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);

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
        }


        #region BuildingCostYearToDay

        //commodity = '电'
        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-Calculate-101-3")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CalculateConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-Calculate-101-3")]
        public void CalcElecPreDefinedTimeTotalConsumptionRanking(CorporateRankingData input)
        {
            //Select the NancyOtherCustomer3, select BuildingCostYearToDay from Hierarchy Tree.
            
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, select Cost.
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Energy);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //1.Change pre-defined time range=去年2012 to view ranking.   
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

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

            //2.Change pre-defined time range=今年 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //3.Change pre-defined time range=上月 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //4.Change pre-defined time range= 本月 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisMonth);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //5.Change pre-defined time range=上周 to view ranking.   
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastWeek);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //6.Change pre-defined time range=本周 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisWeek);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //7.Change pre-defined time range=昨天 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Yesterday);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //8.Change pre-defined time range= 今天 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Today);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //9.Change pre-defined time range= 之前7天 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[8]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[8], input.InputData.failedFileName[8]);
            TimeManager.LongPause();
            TimeManager.LongPause();

        }

        //commodity = '水'
        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-Calculate-101-4")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CalculateConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-Calculate-101-4")]
        public void CalcWaterPreDefinedTimeTotalConsumptionRanking(CorporateRankingData input)
        {
            //Select the NancyOtherCustomer3, select BuildingCostYearToDay from Hierarchy Tree.
            //JazzFunction.HomePage.SelectCustomer("NancyCostCustomer3");
            //CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, select Cost.
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Energy);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //1.Change pre-defined time range=去年2012 to view ranking.   
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);

            //Select Commodity=自来水 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

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

            //2.Change pre-defined time range=今年 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //3.Change pre-defined time range=上月 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //4.Change pre-defined time range= 本月 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisMonth);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //5.Change pre-defined time range=上周 to view ranking.   
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastWeek);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //6.Change pre-defined time range=本周 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisWeek);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //7.Change pre-defined time range=昨天 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Yesterday);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //8.Change pre-defined time range= 今天 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Today);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //9.Change pre-defined time range= 之前7天 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[8]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[8], input.InputData.failedFileName[8]);
            TimeManager.LongPause();
            TimeManager.LongPause();

        }

        //commodity = '煤'
        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-Calculate-101-5")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CalculateConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-Calculate-101-5")]
        public void CalcCoalPreDefinedTimeTotalConsumptionRanking(CorporateRankingData input)
        {
            //Select the NancyOtherCustomer3, select BuildingCostYearToDay from Hierarchy Tree.
            //JazzFunction.HomePage.SelectCustomer("NancyCostCustomer3");
            //CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, select Cost.
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Energy);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            
            //1.Change pre-defined time range=去年2012 to view ranking.   
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);

            //Select Commodity=煤 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

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

            //2.Change pre-defined time range=今年 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisYear);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //3.Change pre-defined time range=上月 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //4.Change pre-defined time range= 本月 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisMonth);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //5.Change pre-defined time range=上周 to view ranking.   
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastWeek);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //6.Change pre-defined time range=本周 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisWeek);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //7.Change pre-defined time range=昨天 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Yesterday);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //8.Change pre-defined time range= 今天 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Today);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //9.Change pre-defined time range= 之前7天 to view ranking.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last7Days);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[8]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[8], input.InputData.failedFileName[8]);
            TimeManager.LongPause();
            TimeManager.LongPause();

        }

        #endregion


        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-Calculate-101-6")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CalculateConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-Calculate-101-6")]
        public void CalcAverageConsumptionRankingData(CorporateRankingData input)
        {
            //1.Select the NancyCostCustomer2->楼宇A from Hierarchy Tree. 
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, select Cost, then go to 介质单项.
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Energy);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Change manually defined time range to 2012/07/01-2012/08/31.
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 1), new DateTime(2012, 9, 30));

            //Select Commodity=电 to display trend chart; Optional step=week; Unit=单位人口.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.ClickRankTypeConvertTarget();
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);

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

        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-Calculate-101-7")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CalculateConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-Calculate-101-7")]
        public void CalcTotalBuildingAConsumptionRankingData(CorporateRankingData input)
        {
            //1.Select the NancyCostCustomer2->楼宇A from Hierarchy Tree. 
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, select Cost, then go to 介质单项.
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Energy);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Change manually defined time range to 2012/07/01-2012/08/31.
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 1), new DateTime(2012, 9, 30));

            //Select Commodity=电 to display trend chart; Optional step=week; Unit=单位人口.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.ClickRankTypeConvertTarget();
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.TotalRank);

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

        }

    }

}
