﻿using System;
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
    [Category("P4_Emma")]
    [ManualCaseID("TC-J1-FVT-RankingBug-Calculate-107"), CreateTime("2013-12-16"), Owner("Greenie")]
    public class RankingDataviewAddForBug : TestSuiteBase
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

        // cost ranking  data view  bugs   on  V1.4

        #region assosiate to bug 3921. Ranking (Cost): 楼A/楼B  总览的值 2012 and 2011-2012
        [Test]
        [CaseID("TC-J1-FVT-RankingBug-Calculate-107-1")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(RankingDataviewAddForBug), "TC-J1-FVT-RankingBug-Calculate-107-1")]
        public void CalcTotalAverageCostRankingDataLastYear(CorporateRankingData input)
        {
            //1.Select the NancyCostCustomer2->园区A->楼A  and 楼B from Hierarchy Tree.
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
            CorporateRanking.ClickSelectHierarchyButton();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, select Cost
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Time range 2012 whole year
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.MediumPause();

            //Select Commodity=电 to display data view. Unit=单位人口.
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

            //2.Change tima range to 2011/1/1-2012/12/31 to display Data view.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);

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
        }
        #endregion

        #region assosiate to bug 3917. Ranking (Cost): There is no value for Total (总览).
        [Test]
        [CaseID("TC-J1-FVT-RankingBug-Calculate-107-2")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(RankingDataviewAddForBug), "TC-J1-FVT-RankingBug-Calculate-107-2")]
        public void CalcLastYearTotalCostRankingData(CorporateRankingData input)
        {
            //1.Select the NancyCostCustomer2->园区A->楼A from Hierarchy Tree.
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
            CorporateRanking.ClickSelectHierarchyButton();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, select Cost.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Time range ="2013"
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.MediumPause();

            //Select Commodity=介质总览 to display data view; 
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

            //2.Unit=人均排名.
            
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);

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

            //3.Unit=单位面积排名.
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.UnitAreaRank);

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
        [CaseID("TC-J1-FVT-RankingBug-Calculate-107-3")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(RankingDataviewAddForBug), "TC-J1-FVT-RankingBug-Calculate-107-3")]
        public void CalcThisYearTotalCostRankingData(CorporateRankingData input)
        {
            //1.Select the NancyCostCustomer2->园区A->楼A from Hierarchy Tree.
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
            CorporateRanking.ClickSelectHierarchyButton();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, select Cost.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Time range ="2013"
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.MediumPause();

            //Select Commodity=介质总览 to display data view; 
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

            //2.Unit=人均排名.
            
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);

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

            //3.Unit=单位面积排名.
            
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.UnitAreaRank);

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

        #endregion

        // carbon ranking  data view  bugs   on  V1.4

        #region xxxx
        [Test]
        [CaseID("TC-J1-FVT-RankingBug-Calculate-107-5")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(RankingDataviewAddForBug), "TC-J1-FVT-RankingBug-Calculate-107-5")]
        public void CalcElecLastYearAverageCarbonRankingData(CorporateRankingData input)
        {
            //1.Go to Ranking, Select NancyCostCustomer2 -> 楼宇A, 
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
            CorporateRanking.ClickSelectHierarchyButton();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, function is '碳排放', 
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Time range ="2012"
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.MediumPause();

            //Select Commodity=电 to display data view ,Unit=‘人均排名’
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

            //2.Carbon ranking type = "Co2"
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.CO2);
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

            //3.Carbon ranking type = "Tree"
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.Tree);
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
        }

        [Test]
        [CaseID("TC-J1-FVT-RankingBug-Calculate-107-6")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(RankingDataviewAddForBug), "TC-J1-FVT-RankingBug-Calculate-107-6")]
        public void CalcWaterLastYearAverageCarbonRankingData(CorporateRankingData input)
        {
            //1.Go to Ranking, Select NancyCostCustomer2 -> 楼宇A, 
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
            CorporateRanking.ClickSelectHierarchyButton();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, function is '碳排放', 
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Time range ="2012"
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.MediumPause();

            //Select Commodity=水 to display data view ,Unit=‘人均排名’
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[1]);
            
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

            //2.Carbon ranking type = "Co2"
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.CO2);
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

            //3.Carbon ranking type = "Tree"
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.Tree);
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
        }

        [Test]
        [CaseID("TC-J1-FVT-RankingBug-Calculate-107-7")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(RankingDataviewAddForBug), "TC-J1-FVT-RankingBug-Calculate-107-7")]
        public void CalcCoalLastYearAverageCarbonRankingData(CorporateRankingData input)
        {
            //1.Go to Ranking, Select NancyCostCustomer2 -> 楼宇A, 
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
            CorporateRanking.ClickSelectHierarchyButton();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, function is '碳排放', 
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Time range ="2012"
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate); 
            TimeManager.MediumPause();

            //Select Commodity=煤 to display data view ,Unit=‘人均排名’
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[2]);
            
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

            //2.Carbon ranking type = "Co2"
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.CO2);
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

            //3.Carbon ranking type = "Tree"
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.Tree);
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
        }

        #endregion

        #region auuuu
        [Test]
        [CaseID("TC-J1-FVT-RankingBug-Calculate-107-4")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(RankingDataviewAddForBug), "TC-J1-FVT-RankingBug-Calculate-107-4")]
        public void CalcSiteCarbonRankingData(CorporateRankingData input)
        {
            //1.Go to ranking, select '碳排放', select 楼A, 
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
            CorporateRanking.ClickSelectHierarchyButton();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Function Type button, function is '碳排放', 
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Time range ="2012/1/1-2012/12/31"
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.MediumPause();

            //Select a commodity 水,  time range is This year, '总排名', 
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

            //2.select '二氧化碳'
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.CO2);
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

            //3.select '树'
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.Tree);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //no data for tree
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            
        }

        #endregion

        // consumption ranking  data view  bugs   on  V1.4
    }

}
