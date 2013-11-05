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

namespace Mento.Script.EnergyView.CarbonUsage
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-CarbonUsage-TrendChart-002"), CreateTime("2013-08-21"), Owner("Emma")]
    public class CarbonUsageTrendChartSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            CarbonUsage.NavigateToCarbonUsage();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        private static CarbonUsagePanel CarbonUsage = JazzFunction.CarbonUsagePanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [Test]
        [CaseID("TC-J1-FVT-CarbonUsage-TrendChart-002-1")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(CarbonUsageTrendChartSuite), "TC-J1-FVT-CarbonUsage-TrendChart-002-1")]
        public void SingleCommodityTrendChart(CarbonUsageData input)
        {
            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range and change to data view
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 4, 1), new DateTime(2012, 4, 5));
            TimeManager.ShortPause();

            //Select "elec"
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CarbonUsage.IsTrendChartDrawn());
            Assert.AreEqual(1, CarbonUsage.GetTrendChartLines());
        
            //Add select "汽油"
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[1]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CarbonUsage.IsTrendChartDrawn());
            Assert.AreEqual(2, CarbonUsage.GetTrendChartLines());
        
            //Change to "CO2"
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.CO2);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CarbonUsage.IsTrendChartDrawn());
            Assert.AreEqual(2, CarbonUsage.GetTrendChartLines());

            //Add "Coal"
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[2]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CarbonUsage.IsTrendChartDrawn());
            Assert.AreEqual(3, CarbonUsage.GetTrendChartLines());

            //Add "Gas"
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[3]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CarbonUsage.IsTrendChartDrawn());
            Assert.AreEqual(4, CarbonUsage.GetTrendChartLines());

            //Change from "CO2" to "Tree"
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.Tree);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsTrendChartDrawn());
            //Assert.IsTrue(CarbonUsage.IsTrendChartDrawn());
            //Assert.AreEqual(4, CarbonUsage.GetTrendChartLines());

            //Add "heating"
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[4]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsTrendChartDrawn());
            //Assert.IsTrue(CarbonUsage.IsTrendChartDrawn());
            //Assert.AreEqual(4, CarbonUsage.GetTrendChartLines());

            //Add "Water"
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[5]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsTrendChartDrawn());
            //Assert.IsTrue(CarbonUsage.IsTrendChartDrawn());
            //Assert.AreEqual(4, CarbonUsage.GetTrendChartLines());

            //Change from "Tree" to "StandardCoal"
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.StandardCoal);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CarbonUsage.IsTrendChartDrawn());
            Assert.AreEqual(6, CarbonUsage.GetTrendChartLines());

            //Click "Save to dashboard" to save the Data view to Home page dashboard named "CarbonWidgetHomeDataview"
            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);

            //Change from "StandardCoal" to "CO2"
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.CO2);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CarbonUsage.IsTrendChartDrawn());
            Assert.AreEqual(6, CarbonUsage.GetTrendChartLines());
            EnergyViewToolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);

            //Change from "CO2" to "Tree"
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.Tree);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsTrendChartDrawn());
            //Assert.IsTrue(CarbonUsage.IsTrendChartDrawn());
            //Assert.AreEqual(4, CarbonUsage.GetTrendChartLines());
            EnergyViewToolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);

            //On homepage, check the dashboards
            CarbonUsage.NavigateToAllDashBoards();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            for (int i = 0; i < 3; i++)
            {
                HomePagePanel.ClickDashboardButton(dashboard[i].DashboardName);
                JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
                TimeManager.MediumPause();

                Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard[i].DashboardName));
                Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[i].WigetName));
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-CarbonUsage-TrendChart-002-2")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(CarbonUsageTrendChartSuite), "TC-J1-FVT-CarbonUsage-TrendChart-002-2")]
        public void TotalCommodityTrendChart(CarbonUsageData input)
        {
            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range and change to data view
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 4, 1), new DateTime(2012, 4, 5));
            TimeManager.ShortPause();

            //Select display chart type is "标煤"
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.StandardCoal);

            //Select "TotalEnergyConsumption(总览)" option from Energy commodity(能源介质) list to draw Data view.
            CarbonUsage.SelectCommodity();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CarbonUsage.IsTrendChartDrawn());
            Assert.AreEqual(1, CarbonUsage.GetTrendChartLines());

            //Change from default display "标煤" to "二氧化碳"
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.CO2);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(CarbonUsage.IsTrendChartDrawn());
            Assert.AreEqual(1, CarbonUsage.GetTrendChartLines());

            //Change from default display "二氧化碳" to "树"
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.Tree);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsTrendChartDrawn());
            //Assert.AreEqual(1, CarbonUsage.GetTrendChartLines());

            //Click "Save to dashboard" to save the Data view to Home page dashboard named "CarbonWidgetHomeDataview"
            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);

            //On homepage, check the dashboards
            CarbonUsage.NavigateToAllDashBoards();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard[0].DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-CarbonUsage-TrendChart-002-3")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(CarbonUsageTrendChartSuite), "TC-J1-FVT-CarbonUsage-TrendChart-002-3")]
        public void NofactorSingleCommodityTrendChart(CarbonUsageData input)
        {
            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range 
            EnergyViewToolbar.SetDateRange(new DateTime(2011, 4, 1), new DateTime(2011, 4, 5));
            TimeManager.ShortPause();

            //Select display chart type is "标煤", Select "TotalEnergyConsumption(总览)" option
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.StandardCoal);
            CarbonUsage.SelectCommodity();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //No trend chart
            Assert.IsFalse(CarbonUsage.IsTrendChartDrawn());

            //Change "标煤" to "CO2", Select "TotalEnergyConsumption(总览)" option
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.CO2);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //No trend chart
            Assert.IsFalse(CarbonUsage.IsTrendChartDrawn());

            //Change "CO2" to "Tree", Select "TotalEnergyConsumption(总览)" option
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.Tree);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //No trend chart
            Assert.IsFalse(CarbonUsage.IsTrendChartDrawn());

            //Check commodity=煤, Since that commodity=煤 defined Convert factor to "标煤" in 2011Year.
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.StandardCoal);
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //No trend chart
            Assert.IsFalse(CarbonUsage.IsTrendChartDrawn());

            //Change "标煤" to "CO2", Select "TotalEnergyConsumption(总览)" option
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.CO2);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //No trend chart
            Assert.IsFalse(CarbonUsage.IsTrendChartDrawn());

            //Change "CO2" to "Tree", Select "TotalEnergyConsumption(总览)" option
            EnergyViewToolbar.SelectCarbonConvertTarget(CarbonConvertTarget.Tree);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //No trend chart
            Assert.IsFalse(CarbonUsage.IsTrendChartDrawn());
        }
    }
}
