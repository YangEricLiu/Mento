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
    [ManualCaseID("TC-J1-FVT-CarbonUsageDataVerification-DataView-101"), CreateTime("2013-12-20"), Owner("Emma")]
    public class CarbonUsageDataVerificationSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-CarbonUsageDataVerification-DataView-101-1")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(CarbonUsageDataVerificationSuite), "TC-J1-FVT-CarbonUsageDataVerification-DataView-101-1")]
        public void CarbonUsageDataVerification01(CarbonUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.MediumPause();

            CarbonUsage.NavigateToCarbonUsage();
            TimeManager.MediumPause();

            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Time range = 
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //Select "电"
            CarbonUsage.SelectCommodity(input.InputData.commodityNames[0]);

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            CarbonUsage.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
               
        }

    }
}
