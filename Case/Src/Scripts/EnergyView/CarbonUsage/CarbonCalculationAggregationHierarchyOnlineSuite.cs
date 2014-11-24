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
    [ManualCaseID("TC-J1-FVT-StandCoalCalculation-001"), CreateTime("2014-2-26"), Owner("Emma")]
    public class CarbonCalculationAggregationHierarchyOnlineSuite : TestSuiteBase
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

            HomePagePanel.SelectCustomer("NancyCustomer1");
            TimeManager.MediumPause();
        }

        private static CarbonUsagePanel CarbonUsage = JazzFunction.CarbonUsagePanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [Test]
        [CaseID("TC-J1-FVT-StandCoalCalculation-001-1")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(CarbonCalculationAggregationHierarchyOnlineSuite), "TC-J1-FVT-StandCoalCalculation-001-1")]
        public void CarbonCalculationAggregationHierarchyOnline01(CarbonUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            CarbonUsage.NavigateToCarbonUsage();
            TimeManager.MediumPause();

            //Navigate to Hierarchy list 组织A->园区A->楼宇A, then go to 介质单项.
            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //"电" + "自来水" + "煤"
            CarbonUsage.SelectCommodity(input.InputData.commodityNames);
            TimeManager.ShortPause();

            //Change manually defined time range to 2012/07/29-2012/08/04.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();
           
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //"Hour"
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //介质总览
            CarbonUsage.SelectCommodity();
            TimeManager.ShortPause();

            //Change manually defined time range to 2012/07/29-2012/08/04.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //"Hour"
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
        }

        [Test]
        [CaseID("TC-J1-FVT-CarbonCalculation-001-3")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(CarbonCalculationAggregationHierarchyOnlineSuite), "TC-J1-FVT-CarbonCalculation-001-3")]
        public void CarbonUsageRawValueDisplayForHierarchy(CarbonUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            CarbonUsage.NavigateToCarbonUsage();
            TimeManager.MediumPause();

            //Navigate to Hierarchy list 组织A->园区A->楼宇A, then go to 介质单项.
            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //"电" + "自来水" + "煤"
            CarbonUsage.SelectCommodity(input.InputData.commodityNames);
            TimeManager.ShortPause();

            //Change manually defined time range to 2012/07/29-2012/08/04.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //"Raw"
            CarbonUsage.ClickDisplayStep(DisplayStep.Raw);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check value
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //介质总览
            CarbonUsage.SelectCommodity();
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //"Raw"
            CarbonUsage.ClickDisplayStep(DisplayStep.Raw);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check value
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
        }
    }
}
