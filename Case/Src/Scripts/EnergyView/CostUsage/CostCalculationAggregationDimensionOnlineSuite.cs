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
    [ManualCaseID("TC-J1-FVT-CostCalculation-002"), CreateTime("2014-2-26"), Owner("Emma")]
    public class CostCalculationAggregationDimensionOnlineSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();

            HomePagePanel.SelectCustomer("NancyCustomer1");
            TimeManager.MediumPause();
        }

        private static CostPanel CostUsage = JazzFunction.CostPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [Test]
        [CaseID("TC-J1-FVT-CostCalculation-002-1")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostCalculationAggregationDimensionOnlineSuite), "TC-J1-FVT-CostCalculation-002-1")]
        public void CostCalculationAggregationDimensionOnline01(CostUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.LongPause();

            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            //Hierarchy list 组织A->园区A->楼宇A, then go to 介质单项.
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //go to 空调 System Dimension.
            CostUsage.SwitchTagTab(TagTabs.SystemDimensionTab);
            TimeManager.ShortPause();

            CostUsage.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Change manually defined time range to 2012/06/29-2012/07/04.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //"单项" = 电 +　自来水 + 煤
            CostUsage.SelectCommodity(input.InputData.commodityNames);
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //""
            CostUsage.ClickDisplayStep(input.InputData.DisplayStep);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CostUsage.IsNoDataInEnergyGrid());
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
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //""
            CostUsage.ClickDisplayStep(input.InputData.DisplayStep);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
        }

        [Test]
        [CaseID("TC-J1-FVT-CostCalculation-002-2")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostCalculationAggregationDimensionOnlineSuite), "TC-J1-FVT-CostCalculation-002-2")]
        public void CostCalculationAggregationDimensionOnline02(CostUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.LongPause();

            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            //Hierarchy list 组织A->园区A->楼宇A, then go to 介质单项.
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //go to 一层 Area Dimension
            CostUsage.SwitchTagTab(TagTabs.AreaDimensionTab);
            TimeManager.ShortPause();

            CostUsage.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Change manually defined time range to 2012/06/29-2012/07/04.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //"单项" = 电 +　自来水 + 煤
            CostUsage.SelectCommodity(input.InputData.commodityNames);
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //""
            CostUsage.ClickDisplayStep(input.InputData.DisplayStep);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CostUsage.IsNoDataInEnergyGrid());
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
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //""
            CostUsage.ClickDisplayStep(input.InputData.DisplayStep);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
        }

        [Test]
        [CaseID("TC-J1-FVT-CostCalculation-002-1-2")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostCalculationAggregationDimensionOnlineSuite), "TC-J1-FVT-CostCalculation-002-1-2")]
        public void CostCalculationAggregationDimensionOnline0102(CostUsageData input)
        {
            //Change Hierarchy list to 组织A->园区A->楼宇A, then go to 特殊 Dimension.
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.LongPause();

            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            //Hierarchy list 组织A->园区A->楼宇A, then go to 介质单项.
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //go to 特殊 System Dimension.
            CostUsage.SwitchTagTab(TagTabs.SystemDimensionTab);
            TimeManager.ShortPause();

            CostUsage.SelectSystemDimension(input.InputData.SystemDimensionPaths[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();


        }
    }
}