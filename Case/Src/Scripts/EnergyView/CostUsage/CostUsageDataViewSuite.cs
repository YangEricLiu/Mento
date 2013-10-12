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

namespace Mento.Script.EnergyView.CostUsage
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-CostUsage-DataView-001"), CreateTime("2013-08-16"), Owner("Emma")]
    public class CostUsageDataViewSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        private static CostPanel CostUsage = JazzFunction.CostPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-DataView-001-1")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostUsageDataViewSuite), "TC-J1-FVT-CostUsage-DataView-001-1")]
        public void CostUsageDataView(CostUsageData input)
        {
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            
            //Set date range
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 29), new DateTime(2012, 8, 4));
            TimeManager.ShortPause();
            
            //Check tag and view data view, hourly
            CostUsage.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CostUsage.IsNoDataInEnergyGrid());
            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Hour);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Save to dashboard
            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);

            //On homepage, check the dashboard
            CostUsage.NavigateToAllDashBoards();
            HomePagePanel.SelectHierarchyNode(dashboard.HierarchyName);
            TimeManager.LongPause();
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));
            Assert.IsTrue(HomePagePanel.CompareMinWidgetDataView(CostUsage.CostPath, input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0], dashboard.WigetName));
        
            //Uncheck "electricity" and check "water"
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CostUsage);
            TimeManager.MediumPause();

            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            
            //Set date range
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 29), new DateTime(2012, 8, 4));
            TimeManager.ShortPause();
            
            //Check tag and view data view, hourly
            CostUsage.SelectCommodity(input.InputData.commodityNames[1]);
            EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.IsTrue(CostUsage.IsDataViewDrawn());
            Assert.IsFalse(CostUsage.IsNoDataInEnergyGrid());
            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Hour);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Uncheck "water" and check "coal"
            CostUsage.DeSelectCommodity(input.InputData.commodityNames[1]);
            CostUsage.SelectCommodity(input.InputData.commodityNames[2]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.IsTrue(CostUsage.IsDataViewDrawn());
            Assert.IsFalse(CostUsage.IsNoDataInEnergyGrid());
            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Hour);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
        
            //Check "介质总览"
            CostUsage.SelectCommodity();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.IsTrue(CostUsage.IsDataViewDrawn());
            Assert.IsFalse(CostUsage.IsNoDataInEnergyGrid());
            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Hour);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewOfCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
        }

    }
}
