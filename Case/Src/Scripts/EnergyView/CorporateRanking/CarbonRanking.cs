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
    [ManualCaseID("TC-J1-FVT-CarbonRanking-View-101"), CreateTime("2013-10-25"), Owner("Nancy")]
    public class CarbonRanking: TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
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

        [Test]
        [CaseID("TC-J1-FVT-CarbonRanking-View-101-1")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CostRanking), "TC-J1-FVT-CarbonRanking-View-101-1")]
        public void ViewCarbonRankingData(CorporateRankingData input)
        {
            string[] extendHierarchyNode1 = {"NancyCostCustomer2","组织A","园区B","楼宇C"};
            string[] extendHierarchyNode2 = {"NancyCostCustomer2","组织B","园区C","楼宇D"};
            string[] extendHierarchyNode3= { "NancyCostCustomer2", "组织A", "园区A"};
            string[] extendHierarchyNode = { "NancyCostCustomer2", "组织A", "园区A"};
            string[] notagHierarchyNode = { "NancyCostCustomer2", "MarkedDashboardSuiteOrg" };
            //Select the 楼宇A+楼宇B+楼宇C+楼宇D from Hierarchy Tree. 
            //Click Function Type button, select Cost.
            CorporateRanking.ClickSelectHierarchyButton();
            //CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);
            // CorporateRanking.ClickConfirmHiearchyButton();
            TimeManager.MediumPause();
            CorporateRanking.OnlyCheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(input.ExpectedData.Hierarchies);
            CorporateRanking.OnlyCheckHierarchyNode(extendHierarchyNode1);
            CorporateRanking.OnlyCheckHierarchyNode(extendHierarchyNode2);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            EnergyViewToolbar.ClickFuncModeConvertTarget();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            //Select Ranking type=总排名; select time range=2012/07/02 to 2012/07/03 select 总览 to view data.
            //EnergyViewToolbar.SetDateRange();
            //Select 单项 Commodity=电 to view data.
            CorporateRanking.SelectSystemCommodity(input.InputData.commodityNames[0]);
            TimeManager.LongPause();
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 2), new DateTime(2012, 7, 3));

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

            //Click Hierarchy tree to add 1 more hierarchy node NancyCostCustomer2/组织A/园区A
            //select Commodity=电, to view data.
            CorporateRanking.CheckHierarchyNode(extendHierarchyNode);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 2), new DateTime(2012, 7, 3));

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CorporateRanking.SwitchSystemDimensionTab();
            CorporateRanking.ClickSelectSystemDimensionButton();
            CorporateRanking.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Change different time range to view data. 
            //a. 2012/07/01 -2012/07/01    b. 2012/07/01 -2012/07/03 
            //c. 2012/07/10-2012/08/05     d. 2012/01/01-2012/12/31 lastyear   e. 2011/01/01-2013/05/30
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 1), new DateTime(2012, 7, 1));
            EnergyViewToolbar.ClickViewButton();

            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 1), new DateTime(2012, 7, 3));
            EnergyViewToolbar.ClickViewButton();

            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 10), new DateTime(2012, 8, 5));
            EnergyViewToolbar.ClickViewButton();

            EnergyViewToolbar.SetDateRange(new DateTime(2012, 1, 1), new DateTime(2012, 12, 31));
            EnergyViewToolbar.ClickViewButton();

            EnergyViewToolbar.SetDateRange(new DateTime(2011, 1, 1), new DateTime(2013, 5, 3));
            EnergyViewToolbar.ClickViewButton();

            //Check 1 more the BuildingNoTag from Hierarchy Tree, Commodity=煤, click to view chart.
            CorporateRanking.CheckHierarchyNode(notagHierarchyNode);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();


            //Time range="2012/07/02 -2012/07/03",Change Ranking type=人均排名 to view chart.
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 2), new DateTime(2013, 7, 3));
            EnergyViewToolbar.SelectRankTypeConvertTarget(RankTypeConvertTarget.AverageRank);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
        }


        [Test]
        [CaseID("TC-J1-FVT-CarbonRanking-View-101-2")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(CostRanking), "TC-J1-FVT-CarbonRanking-View-101-2  ")]
        public void ViewCoalRankingData(CorporateRankingData input)
        {
            string[] extendHierarchyNode1 = { "NancyCostCustomer2", "组织A", "园区B", "楼宇C" };
            string[] extendHierarchyNode2 = { "NancyCostCustomer2", "组织B", "园区C", "楼宇D" };
            string[] extendHierarchyNode3 = { "NancyCostCustomer2", "组织A", "园区A" };
            string[] extendHierarchyNode = { "NancyCostCustomer2", "组织A", "园区A" };
            string[] notagHierarchyNode = { "NancyCostCustomer2", "MarkedDashboardSuiteOrg" };
            //Go to NancyOtherCustomer3. Go to Function "Corporate Ranking". 
            //Select the BuildingCostYearToDay from Hierarchy Tree. 
            //Click Function Type button, select Cost, Commodity=煤, predefined time range="2012/06/01-2013/07/01" to view chart.
            JazzFunction.HomePage.SelectCustomer("NancyOtherCustomer3");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.LongPause();
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);
            
        }
    }

}
