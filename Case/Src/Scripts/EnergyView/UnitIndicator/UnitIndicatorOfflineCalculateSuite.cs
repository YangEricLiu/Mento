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

namespace Mento.Script.EnergyView.UnitIndicator
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-UnitIndicator-OfflineCalculate-101"), CreateTime("2013-11-18"), Owner("Emma")]
    public class UnitIndicatorOfflineCalculateSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
            //HomePagePanel.ExitJazz();

            //JazzFunction.LoginPage.LoginWithOption("SchneiderElectricChina", "P@ssw0rdChina", "NancyCustomer1");
            //TimeManager.MediumPause();
        }

        private static UnitKPIPanel UnitKPIPanel = JazzFunction.UnitKPIPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        private static RankPanel CorporateRanking = JazzFunction.RankPanel;

        [Test]
        [CaseID("TC-J1-FVT-UnitIndicator-OfflineCalculate-101-1")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(UnitIndicatorOfflineCalculateSuite), "TC-J1-FVT-UnitIndicator-OfflineCalculate-101-1")]
        public void UnitIndicatorOfflineCalculate01(UnitIndicatorData input)
        {
            //Go to NancyOtherCustomer3. Go to Function Unit indicator. Select the BuildingRanking50 from Hierarchy Tree. Click Function Type button, select Energy Consumption
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();
            
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //check Rankingtag50 to view chart;
            UnitKPIPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            //select time range=2013/01/01-2013/01/02,  optional step=hour; Unit=人口.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //check on data view, · 500/1000=0.5
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Select Cost, select time range=2013/01/01-2013/01/02, check Commodity=电 to view chart; optional step=hour; Unit=人口.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            TimeManager.LongPause();

            //check on data view, · 500*10/1000=5
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Select Carbon, select time range=2013/01/01-2013/01/02, check Commodity=电 to view chart; optional step=hour; Unit=人口.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.ShortPause();
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            TimeManager.LongPause();

            //check on data view· 500*7/1000=0.7
            UnitKPIPanel.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            UnitKPIPanel.CompareDataViewUnitIndicator(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Go to Function Ranking. Select the BuildingRanking1,BuildingRanking2 and BuildingRanking50 from Hierarchy Tree. Click Ranking Type button, select Energy consumption/Carbon/Cost, check Commodity=电, Ranking type=总排名/人口排名/总面积排名.
            UnitKPIPanel.NavigateToRanking();
            TimeManager.MediumPause();

            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[2]);

            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            CorporateRanking.SelectCommodity(input.InputData.Commodity[0]);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            TimeManager.LongPause();

            //· BuildingRanking50 is change from last to first by ASED. 
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

            //cost 人口排名
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            TimeManager.ShortPause();

            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //· BuildingRanking50 is change from last to first by ASED. 
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

            //carbon 面积排名
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            TimeManager.ShortPause();

            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.UnitAreaRank);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            TimeManager.LongPause();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //· BuildingRanking50 is change from last to first by ASED. 
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
        }

        [Test]
        [CaseID("TC-J1-FVT-UnitIndicator-OfflineCalculate-101-2")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(UnitIndicatorOfflineCalculateSuite), "TC-J1-FVT-UnitIndicator-OfflineCalculate-101-2")]
        public void UnitIndicatorOfflineCalculate02(UnitIndicatorData input)
        {
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            //Go to NancyOtherCustomer3. Go to Function Ranking. Select the BuildingRanking3 from Hierarchy Tree. 
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[2]);


        }
    }
}

