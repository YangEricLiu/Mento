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
    [ManualCaseID("TC-J1-FVT-CarbonRanking-Calculate-UpdateRule-101"), CreateTime("2014-06-23"), Owner("Emma")]
    public class P1_CalculateUpdateRuleCarbonRanking : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
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
        [CaseID("TC-J1-FVT-CarbonRanking-Calculate-UpdateRule-101-1")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(P1_CalculateUpdateRuleCarbonRanking), "TC-J1-FVT-CarbonRanking-Calculate-UpdateRule-101-1")]
        public void CalculateUpdateRuleCarbonRanking01(CorporateRankingData input)
        {
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Go to UT tool. Go to Ranking. Select NancyOtherCustomer3->BuildingMissingData, Unit=总排名, select different time range to view data view.
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Commodity='电'
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            //Change manually defined time range to A. 2012/01/01 to 2013/03/01
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            CorporateRanking.CompareDataViewOfCarbonUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
        }

        [Test]
        [CaseID("TC-J1-FVT-CarbonRanking-Calculate-UpdateRule-101-2")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(P1_CalculateUpdateRuleCarbonRanking), "TC-J1-FVT-CarbonRanking-Calculate-UpdateRule-101-2")]
        public void CalculateUpdateRuleCarbonRanking02(CorporateRankingData input)
        {
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Go to UT tool. Go to Ranking.Select NancyOtherCustomer3->BuildingLabellingNull, Unit=单位面积, select different time range to view data view.
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies[0]);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //unit=单位面积
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.UnitAreaRank);
            TimeManager.MediumPause();

            //Commodity='电'
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            //Change manually defined time range to A. 2012/01/01 to 2013/03/01
            var ManualTimeRange = input.InputData.ManualTimeRange;

            for (int i = 0; i < input.InputData.ManualTimeRange.Length; i++)
            {
                EnergyViewToolbar.SetDateRange(ManualTimeRange[i].StartDate, ManualTimeRange[i].EndDate);

                EnergyViewToolbar.View(EnergyViewType.List);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.MediumPause();

                CorporateRanking.ExportRankingExpectedDataTableToExcel(input.ExpectedData.expectedFileName[i]);
                TimeManager.MediumPause();
                CorporateRanking.CompareDataViewOfCarbonUsage(input.ExpectedData.expectedFileName[i], input.InputData.failedFileName[i]);
            }
        }
    }
}
