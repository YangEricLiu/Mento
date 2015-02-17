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
    [ManualCaseID("TC-J1-FVT-ConsumptionRanking-Calculate-101"), CreateTime("2013-12-16"), Owner("Greenie"), System.Runtime.InteropServices.GuidAttribute("0A50232D-E9C0-4B01-921E-46061CDCF55A")]
    public class CalculateConsumptionRanking : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.HomePage.SelectCustomer("NancyOtherCustomer3");
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
        [CaseID("TC-J1-FVT-ConsumptionRanking-Calculate-101-1")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CalculateConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-Calculate-101-1")]
        public void CalcFiveBuildingConsumptionRanking(CorporateRankingData input)
        {
            //Go to Function Ranking. Select the BuildingRanking1 to 5 from Hierarchy Tree. 
            CorporateRanking.ClickSelectHierarchyButton();
            TimeManager.MediumPause();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[2]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[3]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[4]);

            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            //Click Ranking Type button, select Cost, check Commodity=电. 
          
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.LongPause();

            // 1.Change different time range to view data.  a. 2013/01/01-2013/01/07
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

            // 2.Change different time range to view data.  b. This year = 2013-1-1 to 2013-12-31
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.MediumPause();

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

            //3.Select Ranking type=人均排名 and view data.
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);

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
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            CorporateRanking.SwitchSystemDimensionTab();
            TimeManager.LongPause();

            CorporateRanking.SelectSystemDimensionNode(input.InputData.SystemDimensionPath);
            TimeManager.LongPause();

            //Click Function Type button, select EnergyConsumption, then go to 介质单项.
            //Change manually defined time range to 2012/07/01-2013/11/1.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.LongPause();
            TimeManager.LongPause();
            //Select Commodity=电 to display trend chart; Unit=单位人口.
            CorporateRanking.SelectSystemCommodity(input.InputData.commodityNames[0]);
            
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);

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
        }


        #region BuildingCostYearToDay

        //commodity = '电'
        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-Calculate-101-3")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CalculateConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-Calculate-101-3")]
        public void CalcElecNonPreDefinedTimeTotalConsumptionRanking(CorporateRankingData input)
        {
            //Select the NancyOtherCustomer3, select BuildingCostYearToDay from Hierarchy Tree.
            
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, select Cost.
            //1.Change pre-defined time range=去年2012 to view ranking.   
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

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

            //2.Change pre-defined time range=2013 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
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

            //3.Change pre-defined time range=2014-1 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

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

            //4.Change pre-defined time range= 2014-2 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //5.Change pre-defined time range=2014-1-1 to 2014-1-7 to view ranking.   
            EnergyViewToolbar.SetDateRange(ManualTimeRange[4].StartDate, ManualTimeRange[4].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //6.Change pre-defined time range=2014-2-1 to 2014-2-7 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[5].StartDate, ManualTimeRange[5].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //7.Change pre-defined time range=2014-2-28 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[6].StartDate, ManualTimeRange[6].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //8.Change pre-defined time range= 2014-2-1 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[7].StartDate, ManualTimeRange[7].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //9.Change pre-defined time range= 2013-12-1 to 2013-12-31 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[8].StartDate, ManualTimeRange[8].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

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
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, select Cost.
            //1.Change pre-defined time range=去年2012 to view ranking.   
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            //Select Commodity=自来水 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

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

            //2.Change pre-defined time range=2013 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
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

            //3.Change pre-defined time range=2014-1 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

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

            //4.Change pre-defined time range= 2014-2 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //5.Change pre-defined time range=2014-1-1 to 2014-1-7 to view ranking.   
            EnergyViewToolbar.SetDateRange(ManualTimeRange[4].StartDate, ManualTimeRange[4].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //6.Change pre-defined time range=2014-2-1 to 2014-2-28 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[5].StartDate, ManualTimeRange[5].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //7.Change pre-defined time range=2014-2-28 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[6].StartDate, ManualTimeRange[6].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //8.Change pre-defined time range= 2014-2-1 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[7].StartDate, ManualTimeRange[7].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //9.Change pre-defined time range= 2013-12-1 to 2013-12-31 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[8].StartDate, ManualTimeRange[8].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

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
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, select Cost.
            //1.Change pre-defined time range=去年2012 to view ranking.   
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            //Select Commodity=煤 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

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

            //2.Change pre-defined time range=2013 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
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

            //3.Change pre-defined time range=2014-1 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

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

            //4.Change pre-defined time range= 2014-2 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //5.Change pre-defined time range=2014-1-1 to 2014-1-7 to view ranking.   
            EnergyViewToolbar.SetDateRange(ManualTimeRange[4].StartDate, ManualTimeRange[4].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //6.Change pre-defined time range=2014-2-1 to 2014-2-28 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[5].StartDate, ManualTimeRange[5].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //7.Change pre-defined time range=2014-2-28 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[6].StartDate, ManualTimeRange[6].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //8.Change pre-defined time range= 2014-2-1 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[7].StartDate, ManualTimeRange[7].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //9.Change pre-defined time range= 2013-12-1 to 2013-12-31 to view ranking.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[8].StartDate, ManualTimeRange[8].EndDate);

            //Select Commodity=电 to display trend chart;
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

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
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, select Cost, then go to 介质单项.
            //Change manually defined time range to 2012/07/01-2012/09/30.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            //Select Commodity=电 to display trend chart; Optional step=week; Unit=单位人口.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);

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
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, select Cost, then go to 介质单项.
            //Change manually defined time range to 2012/07/01-2012/09/30.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            //Select Commodity=电 to display trend chart; Optional step=week; Unit=单位人口.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
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
        }

    }

}
