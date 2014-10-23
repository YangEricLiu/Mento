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
    [ManualCaseID("TC-J1-FVT-CarbonUsage-DataView-001"), CreateTime("2013-08-16"), Owner("Emma")]
    public class CarbonUsageDataViewSuite : TestSuiteBase
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
            //HomePagePanel.ExitJazz();

            //JazzFunction.LoginPage.LoginWithOption("SchneiderElectricChina", "P@ssw0rdChina", "NancyCustomer1");
            //TimeManager.MediumPause();
        }

        private static CarbonUsagePanel CarbonUsage = JazzFunction.CarbonUsagePanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [Test]
        [CaseID("TC-J1-FVT-CarbonUsage-DataView-001-1")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(CarbonUsageDataViewSuite), "TC-J1-FVT-CarbonUsage-DataView-001-1")]
        public void SingleCommodityDataView(CarbonUsageData input)
        {
            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range and change to data view
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 4, 1), new DateTime(2012, 4, 5));
            TimeManager.ShortPause();
            EnergyViewToolbar.View(EnergyViewType.List);

            //Select "elec"
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Hour);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
        
            //Add select "汽油"
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[1]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Hour);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
        
            //Change to "CO2"
            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonTypeCO2);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Hour);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[1]);

            //Add "Coal"
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[2]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Hour);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

            //Add "Cool"
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[3]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4], DisplayStep.Hour);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

            //Change from "CO2" to "Tree"
            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonTypeTree);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5], DisplayStep.Hour);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);

            //Add "heating"
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[4]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6], DisplayStep.Hour);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);

            //Add "Water"
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[5]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7], DisplayStep.Hour);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);

            //Change from "Tree" to "StandardCoal"
            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonTypeStandardCoal);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[8], DisplayStep.Hour);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[8], input.InputData.failedFileName[8]);

            //Click "Save to dashboard" to save the Data view to Home page dashboard named "CarbonWidgetHomeDataview"
            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);

            //Change from "StandardCoal" to "CO2"
            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonTypeCO2);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[9], DisplayStep.Hour);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[9], input.InputData.failedFileName[9]);
            EnergyViewToolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);

            //Change from "CO2" to "Tree"
            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonTypeTree);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[10], DisplayStep.Hour);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[10], input.InputData.failedFileName[10]);
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
                //HomePagePanel.CompareMinWidgetDataView(CarbonUsage.CarbonPath, input.ExpectedData.expectedFileName[i + 8], input.InputData.failedFileName[i + 8], dashboard[i].WigetName);
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-CarbonUsage-DataView-001-2")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(CarbonUsageDataViewSuite), "TC-J1-FVT-CarbonUsage-DataView-001-2")]
        public void TotalCommodityDataView(CarbonUsageData input)
        {
            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range and change to data view
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 4, 1), new DateTime(2012, 4, 5));
            TimeManager.ShortPause();
            EnergyViewToolbar.View(EnergyViewType.List);

            //Select display chart type is "标煤"
            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonTypeStandardCoal);

            //Select "TotalEnergyConsumption(总览)" option from Energy commodity(能源介质) list to draw Data view.
            CarbonUsage.SelectCommodity();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Hour);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Change from default display "标煤" to "二氧化碳"
            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonTypeCO2);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Hour);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Change from default display "二氧化碳" to "树"
            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonTypeTree);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Hour);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

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
        [CaseID("TC-J1-FVT-CarbonUsage-DataView-001-3")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(CarbonUsageDataViewSuite), "TC-J1-FVT-CarbonUsage-DataView-001-3")]
        public void NofactorSingleCommodityDataView(CarbonUsageData input)
        {
            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range and change to data view
            EnergyViewToolbar.SetDateRange(new DateTime(2011, 4, 1), new DateTime(2011, 4, 5));
            TimeManager.ShortPause();
            EnergyViewToolbar.View(EnergyViewType.List);

            //Select display chart type is "标煤", Select "TotalEnergyConsumption(总览)" option
            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonTypeStandardCoal);
            CarbonUsage.SelectCommodity();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //No data is displayed in Data view.
            Assert.IsTrue(CarbonUsage.IsNoDataInEnergyGrid());

            //Change "标煤" to "CO2", Select "TotalEnergyConsumption(总览)" option
            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonTypeCO2);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //No data is displayed in Data view.
            Assert.IsTrue(CarbonUsage.IsNoDataInEnergyGrid());

            //Change "CO2" to "Tree", Select "TotalEnergyConsumption(总览)" option
            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonTypeTree);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //No data is displayed in Data view.
            Assert.IsTrue(CarbonUsage.IsNoDataInEnergyGrid());

            //Set date range and change to data view
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 4, 1), new DateTime(2012, 4, 5));
            TimeManager.ShortPause();

            //Check commodity=煤, Since that commodity=煤 defined Convert factor to "标煤" in 2011Year.
            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonTypeStandardCoal);
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Data is displayed in Data view.
            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());

            //Change "标煤" to "CO2"
            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonTypeCO2);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //data is displayed in Data view.
            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());

            //Change "CO2" to "Tree"
            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonTypeTree);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //No data is displayed in Data view.
            Assert.IsTrue(CarbonUsage.IsNoDataInEnergyGrid());
        }

        [Test]
        [CaseID("TC-J1-FVT-CarbonUsage-DataView-101-1")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(CarbonUsageDataViewSuite), "TC-J1-FVT-CarbonUsage-DataView-101-1")]
        public void CarbonDataRows5507(CarbonUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            CarbonUsage.NavigateToCarbonUsage();
            TimeManager.MediumPause();

            //Hierarchy = NancyCostCustomer2/组织A/园区A
            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range and change to data view, 2010/7/1 00:00 to 2014/7/28 24:00
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //介质单项：电
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Year"
            CarbonUsage.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //"Month"
            CarbonUsage.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //"Week"
            CarbonUsage.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);


        }

        [Test]
        [CaseID("TC-J1-FVT-CarbonUsage-DataView-001-4")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(CarbonUsageDataViewSuite), "TC-J1-FVT-CarbonUsage-DataView-001-4")]
        public void CarbonUsageRawValueDisplayForTotal(CarbonUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.LongPause();
            CarbonUsage.NavigateToCarbonUsage();
            TimeManager.MediumPause();

            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range and change to data view
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 29), new DateTime(2012, 8, 4));
            TimeManager.ShortPause();

            //Go to 介质总览 to display Data view. Click Optional step=Raw step
            CarbonUsage.SelectCommodity();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            CarbonUsage.ClickDisplayStep(DisplayStep.Raw);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Check Raw chart display successfully.
            Assert.IsTrue(CarbonUsage.IsDisplayStepPressed(DisplayStep.Raw));
            Assert.IsTrue(CarbonUsage.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsTrue(CarbonUsage.IsDisplayStepDisplayed(DisplayStep.Day));

            //Check data
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

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
        [CaseID("TC-J1-FVT-CarbonUsage-DataView-001-5")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(CarbonUsageDataViewSuite), "TC-J1-FVT-CarbonUsage-DataView-001-5")]
        public void CarbonUsageRawValueDisplayForSingleCommodity(CarbonUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.LongPause();
            CarbonUsage.NavigateToCarbonUsage();
            TimeManager.MediumPause();

            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range and change to data view
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 7, 29), new DateTime(2012, 8, 4));
            TimeManager.ShortPause();

            //Go to 介质单项 电 to display Data view. Click Optional step=Raw step
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            CarbonUsage.ClickDisplayStep(DisplayStep.Raw);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Check Raw chart display successfully.
            Assert.IsTrue(CarbonUsage.IsDisplayStepPressed(DisplayStep.Raw));
            Assert.IsTrue(CarbonUsage.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsTrue(CarbonUsage.IsDisplayStepDisplayed(DisplayStep.Day));

            //Go to 介质单项 自来水 to display Data view. Click Optional step=Raw step
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[1]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Check Raw chart display successfully.
            Assert.IsTrue(CarbonUsage.IsDisplayStepPressed(DisplayStep.Raw));
            Assert.IsTrue(CarbonUsage.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsTrue(CarbonUsage.IsDisplayStepDisplayed(DisplayStep.Day));

            //Go to 介质单项 煤 to display Data view. Click Optional step=Raw step
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[2]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Check Warning message 
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.StepMessage[0]));
            CarbonUsage.ClickGiveupButtonOnWindow();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Check Commodity=煤 is unchecked.
            Assert.AreEqual(true, CarbonUsage.IsCommodityChecked(input.InputData.commodityNames[0]));
            Assert.AreEqual(true, CarbonUsage.IsCommodityChecked(input.InputData.commodityNames[1]));
            Assert.AreEqual(false, CarbonUsage.IsCommodityChecked(input.InputData.commodityNames[2]));

            //Check data
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

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
    }
}
