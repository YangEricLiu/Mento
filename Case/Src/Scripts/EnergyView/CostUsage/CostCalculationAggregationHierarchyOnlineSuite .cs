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

namespace Mento.Script.EnergyView.CostUsage
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-CostCalculation-001"), CreateTime("2014-2-26"), Owner("Emma")]
    public class CostCalculationAggregationHierarchyOnlineSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.LongPause();
            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
            TimeManager.MediumPause();
        }

        private static CostPanel CostUsage = JazzFunction.CostPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [Test]
        [CaseID("TC-J1-FVT-CostCalculation-001-1")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostCalculationAggregationHierarchyOnlineSuite), "TC-J1-FVT-CostCalculation-001-1")]
        public void CostCalculationAggregationHierarchyOnline01(CostUsageData input)
        {
            //Hierarchy list 组织A->园区A->楼宇A, then go to 介质单项.
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Change manually defined time range to 2012/07/29-2012/08/04.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //"单项" = 电 +　自来水 + 煤
            CostUsage.SelectCommodity(input.InputData.commodityNames);
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //"Hour"
            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //介质总览
            CostUsage.SelectCommodity();
            TimeManager.ShortPause();

            //Change manually defined time range to 2012/07/29-2012/08/04.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //"Hour"
            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
        }

        [Test]
        [CaseID("TC-J1-FVT-CostCalculation-001-2")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostCalculationAggregationHierarchyOnlineSuite), "TC-J1-FVT-CostCalculation-001-2")]
        public void CostUsageRawValueDisplayForHierarchy(CostUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.LongPause();

            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            //Go to Cost chart view. Navigate to Hierarchy list, then go to 介质单项.
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Change manually defined time range to 2012/07/29-2012/08/04.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //"单项" = 电 +　自来水 + 煤 and display trend chart.
            CostUsage.SelectCommodity(input.InputData.commodityNames);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //"Min"
            CostUsage.ClickDisplayStep(DisplayStep.Min);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check value
            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //介质总览
            CostUsage.SelectCommodity();
            TimeManager.ShortPause();

            //"Min"
            //Water do not support min step for BuildingB and SiteA
            //if(input.InputData.Hierarchies.Contains("楼宇A"))
            //{
            CostUsage.ClickDisplayStep(DisplayStep.Min);
            //}
            //else
            //{
            //    CostUsage.ClickDisplayStep(DisplayStep.Hour);
            //}
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check value
            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
        }
    }
}
