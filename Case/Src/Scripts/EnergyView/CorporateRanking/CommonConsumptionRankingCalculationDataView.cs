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
    [ManualCaseID("TC-J1-FVT-CostRanking-Calculate-101"), CreateTime("2013-12-16"), Owner("Greenie")]
    public class CommonConsumptionRankingCalculationDataView : TestSuiteBase
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

        // cost ranking  data view  bugs   on  V1.4

        #region xxxxx
        [Test]
        [CaseID("TC-J1-FVT-RankingBug-Calculate-107-1")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CommonConsumptionRankingCalculationDataView), "TC-J1-FVT-RankingBug-Calculate-107-1")]
        public void CalcTotalAverageCostRankingDataLastYear(CorporateRankingData input)
        {
            //1.Select the NancyCostCustomer2->园区A->楼A  and 楼B from Hierarchy Tree.
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

            //Click Function Type button, select Cost
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Time range 2012 whole year
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 1, 1), new DateTime(2012, 12, 31));
            TimeManager.MediumPause();

            //Select Commodity=介质总览 to display data view. Unit=单位人口.
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

            //2.Change tima range to 2011/1/1-2012/12/31 to display Data view.
            EnergyViewToolbar.SetDateRange(new DateTime(2011, 1, 1), new DateTime(2012, 12, 31));

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

        }
        #endregion

    

       



    }

}
