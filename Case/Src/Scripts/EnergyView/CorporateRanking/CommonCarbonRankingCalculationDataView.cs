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
    [ManualCaseID("TC-J1-FVT-CostRanking-Calculate-101"), CreateTime("2013-12-16"), Owner("Greenie")]
    public class CommonCarbonRankingCalculationDataView : TestSuiteBase
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

        // carbon ranking  data view 

        #region xxxxxxxxxxxx

        [Test]
        [CaseID("TC-J1-FVT-RankingBug-Calculate-107-4")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CommonCarbonRankingCalculationDataView), "TC-J1-FVT-RankingBug-Calculate-107-4")]
        public void CalcElecLastYearAverageCarbonRankingData(CorporateRankingData input)
        {
            //1.Go to Ranking, Select NancyCostCustomer2 -> 楼宇A, 
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
            CorporateRanking.ClickSelectHierarchyButton();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(input.ExpectedData.Hierarchies);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, function is '碳排放', 
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Time range ="Last Year"
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.MediumPause();

            //Select Commodity=电 to display data view ,Unit=‘人均排名’
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

            //2.Carbon ranking type = "Co2"

            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.CO2);
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

            //3.Carbon ranking type = "Tree"

            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.Tree);
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

        }

        [Test]
        [CaseID("TC-J1-FVT-RankingBug-Calculate-107-4")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CommonCarbonRankingCalculationDataView), "TC-J1-FVT-RankingBug-Calculate-107-4")]
        public void CalcWaterLastYearAverageCarbonRankingData(CorporateRankingData input)
        {
            //1.Go to Ranking, Select NancyCostCustomer2 -> 楼宇A, 
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
            CorporateRanking.ClickSelectHierarchyButton();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(input.ExpectedData.Hierarchies);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, function is '碳排放', 
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Time range ="Last Year"
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.MediumPause();

            //Select Commodity=电 to display data view ,Unit=‘人均排名’
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

            //2.Carbon ranking type = "Co2"

            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.CO2);
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

            //3.Carbon ranking type = "Tree"

            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.Tree);
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

        }

        [Test]
        [CaseID("TC-J1-FVT-RankingBug-Calculate-107-4")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CommonCarbonRankingCalculationDataView), "TC-J1-FVT-RankingBug-Calculate-107-4")]
        public void CalcCoalLastYearAverageCarbonRankingData(CorporateRankingData input)
        {
            //1.Go to Ranking, Select NancyCostCustomer2 -> 楼宇A, 
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
            CorporateRanking.ClickSelectHierarchyButton();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(input.ExpectedData.Hierarchies);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, function is '碳排放', 
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Time range ="Last Year"
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.MediumPause();

            //Select Commodity=电 to display data view ,Unit=‘人均排名’
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

            //2.Carbon ranking type = "Co2"

            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.CO2);
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

            //3.Carbon ranking type = "Tree"

            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.Tree);
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

        }

        #endregion

        #region yyyyyyyyyyyyyyyyyy

        [Test]
        [CaseID("TC-J1-FVT-RankingBug-Calculate-107-5")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CommonCarbonRankingCalculationDataView), "TC-J1-FVT-RankingBug-Calculate-107-5")]
        public void CalcSiteCarbonRankingDatat(CorporateRankingData input)
        {
            //1.Go to ranking, select '碳排放', select 楼A, 
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
            CorporateRanking.ClickSelectHierarchyButton();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(input.ExpectedData.Hierarchies);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, function is '碳排放', 
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Time range ="2012/1/1-2012/12/31"
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 1, 1), new DateTime(2012, 12, 31));
            TimeManager.MediumPause();

            //Select a commodity 水,  time range is This year, '总排名', 
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);

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

            //2.select '二氧化碳'
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.CO2);
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

            //3.select '树'
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.Tree);
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

            //Select a commodity 水,  time range is This year, '总排名', 
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);

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

            //2.select '二氧化碳'
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.CO2);
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

            //3.select '树'
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.Tree);
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



        }

        #endregion


    }

}
