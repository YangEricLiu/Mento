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
    [ManualCaseID("TC-J1-FVT-CostRanking-Calculate-UpdateRule-101"), CreateTime("2014-06-23"), Owner("Emma")]
    public class CalculateUpdateRuleCostRanking : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        private static RankPanel CorporateRanking = JazzFunction.RankPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [Test]
        [CaseID("TC-J1-FVT-CostRanking-Calculate-UpdateRule-101-1")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CalculateUpdateRuleCostRanking), "TC-J1-FVT-CostRanking-Calculate-UpdateRule-101-1")]
        public void CalculateUpdateRuleCostRanking01(CorporateRankingData input)
        {
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Go to UT tool. Go to Cost-> Ranking. Select NancyOtherCustomer3->BuildingRanking1+BuildingRanking2+…BuildingRanking30, Unit=总排名/单位人口， select different time range to view chart.
            string[] BuildingNames = { "BuildingRanking1", "BuildingRanking2", "BuildingRanking3", "BuildingRanking4", "BuildingRanking5", "BuildingRanking6", "BuildingRanking7", "BuildingRanking8", "BuildingRanking9", "BuildingRanking10", "BuildingRanking11", "BuildingRanking12", "BuildingRanking13", "BuildingRanking14", "BuildingRanking15", "BuildingRanking16", "BuildingRanking17", "BuildingRanking18", "BuildingRanking19", "BuildingRanking20", "BuildingRanking21", "BuildingRanking22", "BuildingRanking23", "BuildingRanking24", "BuildingRanking25", "BuildingRanking26", "BuildingRanking27", "BuildingRanking28", "BuildingRanking29", "BuildingRanking30" };
            int i = 0;
            CorporateRanking.ClickSelectHierarchyButton();
            while (i < 30)
            {
                input.InputData.Hierarchies[0][2] = BuildingNames[i];
                CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
                TimeManager.MediumPause();
                i++;
            }

            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Commodity='电'
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            //Time range = A. 2012/01/01 to 2013/03/01.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //Check tag and view data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //unit=人均排名
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);
            TimeManager.MediumPause();

            //Check tag and view data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
        }

        [Test]
        [CaseID("TC-J1-FVT-CostRanking-Calculate-UpdateRule-101-2")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CalculateUpdateRuleCostRanking), "TC-J1-FVT-CostRanking-Calculate-UpdateRule-101-2")]
        public void CalculateUpdateRuleCostRanking02(CorporateRankingData input)
        {
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Go to UT tool. Go to Ranking. Select NancyOtherCustomer3->BuildingMissingData, Unit=总排名, select different time range to view trend chart/data view.
            CorporateRanking.ClickSelectHierarchyButton();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            TimeManager.MediumPause();

            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Commodity='电'
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            //Time range = A. 2012/01/01 to 2013/03/01.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //Check tag and view data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
        }

        [Test]
        [CaseID("TC-J1-FVT-CostRanking-Calculate-UpdateRule-101-3")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CalculateUpdateRuleCostRanking), "TC-J1-FVT-CostRanking-Calculate-UpdateRule-101-3")]
        public void CalculateUpdateRuleCostRanking03(CorporateRankingData input)
        {
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Go to UT tool. Go to Ranking.Select NancyOtherCustomer3->BuildingLabellingNull, Unit=单位面积, select different time range to view chart. 
            CorporateRanking.ClickSelectHierarchyButton();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            TimeManager.MediumPause();

            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Commodity='电'
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            //Time range = A. 2012/01/01 to 2013/03/01.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //unit=单位面积
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.UnitAreaRank);
            TimeManager.MediumPause();

            //Check tag and view data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
        }
    }
}
