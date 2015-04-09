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
    [ManualCaseID("TC-J1-FVT-CostUsage-TOU-DataView-101"), CreateTime("2014-1-7"), Owner("Emma")]
    public class P1_CostUsageTOUDataViewSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.HomePage.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();
            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
            TimeManager.LongPause();
        }

        private static CostPanel CostUsage = JazzFunction.CostPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static WidgetMaxChartDialog WidgetMaxChart = JazzFunction.WidgetMaxChartDialog;

        [Test]
        [CaseID("TC-J1-FVT-CostUsage-TOU-DataView-101-1")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(P1_CostUsageTOUDataViewSuite), "TC-J1-FVT-CostUsage-TOU-DataView-101-1")]
        public void TOUDataViewVerification01(CostUsageData input)
        {
            //Select "NancyCostCustomer2/组织A/园区A/楼宇B"
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range = 2012-6-26 to 2012-8-5
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 6, 26), new DateTime(2012, 8, 5));
            TimeManager.MediumPause();
            
            //Select "电"
            CostUsage.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.ShortPause();

            //Click "峰谷展示"
            EnergyViewToolbar.ShowPeakValley();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //"Day"
            CostUsage.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
        }

    }
}
