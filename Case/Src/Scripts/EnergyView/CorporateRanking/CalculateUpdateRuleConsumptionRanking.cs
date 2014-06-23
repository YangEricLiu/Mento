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
    [ManualCaseID("TC-J1-FVT-ConsumptionRanking-Calculate-UpdateRule-101"), CreateTime("2014-06-23"), Owner("Emma"), System.Runtime.InteropServices.GuidAttribute("0A50232D-E9C0-4B01-921E-46061CDCF55A")]
    public class CalculateUpdateRuleConsumptionRanking : TestSuiteBase
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
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-Calculate-UpdateRule-101-1")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CalculateUpdateRuleConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-Calculate-UpdateRule-101-1")]
        public void CalculateUpdateRuleConsumptionRanking01(CorporateRankingData input)
        {
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();

            string[] BuildingNames = { "BuildingRanking1", "BuildingRanking2", "BuildingRanking3", "BuildingRanking4", "BuildingRanking5", "BuildingRanking6", "BuildingRanking7", "BuildingRanking8", "BuildingRanking9", "BuildingRankin10", "BuildingRanking11", "BuildingRanking12", "BuildingRanking13", "BuildingRanking14", "BuildingRanking15", "BuildingRanking16", "BuildingRanking17", "BuildingRanking18", "BuildingRanking19", "BuildingRanking20", "BuildingRanking21", "BuildingRanking22", "BuildingRanking23", "BuildingRanking24", "BuildingRanking25", "BuildingRanking26", "BuildingRanking27", "BuildingRanking28", "BuildingRanking29", "BuildingRanking30" };
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

            //Time range = A. 2013/1/1 to 2013/01/06
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //Check tag and view data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-Calculate-UpdateRule-101-2")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CalculateUpdateRuleConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-Calculate-UpdateRule-101-2")]
        public void CalculateUpdateRuleConsumptionRanking02(CorporateRankingData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();

            //Go to UT tool. Go to Ranking.Select NancyCostCustomer2->楼宇A, select 2013/01/01 to 2013/02/01 unit=单位供冷/单位采暖to Data view.
            CorporateRanking.ClickSelectHierarchyButton();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Commodity='电'
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            //Time range = A. 2013/1/1 to 2013/12/31
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //unit=单位供冷
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.UnitCoolAreaRank);
            TimeManager.MediumPause();

            //Check tag and view data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //unit=单位采暖
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.UnitHeatAreaRank);
            TimeManager.MediumPause();

            //Check tag and view data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-Calculate-UpdateRule-101-3")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CalculateUpdateRuleConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-Calculate-UpdateRule-101-3")]
        public void CalculateUpdateRuleConsumptionRanking03(CorporateRankingData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();

            //Go to NancyCostCustomer2->楼宇D/园区C/楼宇A/楼宇D空调， Unit=总排名， select time range to Data View. 
            CorporateRanking.ClickSelectHierarchyButton();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[1]);
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[2]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Switch to system dimension node
            CorporateRanking.SwitchSystemDimensionTab();
            CorporateRanking.SelectSystemDimensionNode(input.InputData.SystemDimensionPath);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Commodity='电'
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            //Time range = A. 2012/07/30 to 2012/08/01.
            var ManualTimeRange = input.InputData.ManualTimeRange;

            for (int i = 0; i < input.InputData.ManualTimeRange.Length; i++)
            {
                EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
                TimeManager.ShortPause();

                //Check tag and view data view
                EnergyViewToolbar.View(EnergyViewType.List);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.MediumPause();

                Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
                CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
                TimeManager.MediumPause();
                CorporateRanking.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-Calculate-UpdateRule-101-4")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CalculateUpdateRuleConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-Calculate-UpdateRule-101-4")]
        public void CalculateUpdateRuleConsumptionRanking04(CorporateRankingData input)
        {
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();

            //Go to UT tool. Go to Ranking. Select NancyOtherCustomer3->BuildingMissingData, Unit=总排名, select different time range to view data view.
            CorporateRanking.ClickSelectHierarchyButton();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Commodity='电'
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();
            var ManualTimeRange = input.InputData.ManualTimeRange;

            for (int i = 0; i < input.InputData.ManualTimeRange.Length; i++)
            {
                //Time range = A. 2012/07/30 to 2012/08/01
                EnergyViewToolbar.SetDateRange(ManualTimeRange[i].StartDate, ManualTimeRange[i].EndDate);
                TimeManager.ShortPause();

                //Check tag and view data view
                EnergyViewToolbar.View(EnergyViewType.List);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.MediumPause();

                Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
                CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[i]);
                TimeManager.MediumPause();
                CorporateRanking.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[i], input.InputData.failedFileName[i]);
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionRanking-Calculate-UpdateRule-101-5")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CalculateUpdateRuleConsumptionRanking), "TC-J1-FVT-ConsumptionRanking-Calculate-UpdateRule-101-5")]
        public void CalculateUpdateRuleConsumptionRanking05(CorporateRankingData input)
        {
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();

            //Go to UT tool. Go to Ranking.Select NancyOtherCustomer3->BuildingLabellingNull, Unit=单位面积, select different time range to data view.
            CorporateRanking.ClickSelectHierarchyButton();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //unit=单位面积
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.UnitAreaRank);
            TimeManager.MediumPause();

            //Commodity='电'
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();
            var ManualTimeRange = input.InputData.ManualTimeRange;

            for (int i = 0; i < input.InputData.ManualTimeRange.Length; i++)
            {
                //Time range = A. 2012/07/30 to 2012/08/01
                EnergyViewToolbar.SetDateRange(ManualTimeRange[i].StartDate, ManualTimeRange[i].EndDate);
                TimeManager.ShortPause();

                //Check tag and view data view
                EnergyViewToolbar.View(EnergyViewType.List);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.MediumPause();

                Assert.IsFalse(CorporateRanking.IsNoDataInEnergyGrid());
                CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[i]);
                TimeManager.MediumPause();
                CorporateRanking.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[i], input.InputData.failedFileName[i]);
            }
        }

    }
}
