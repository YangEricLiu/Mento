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
    [ManualCaseID("TC-J1-FVT-CarbonUsageDataVerification-DataView-101"), CreateTime("2013-12-20"), Owner("Amber")]
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
            //JazzFunction.Navigator.NavigateHome();

            //HomePagePanel.SelectCustomer("NancyCustomer1");
            //TimeManager.MediumPause();

            HomePagePanel.ExitJazz();

            JazzFunction.LoginPage.LoginWithOption("SchneiderElectricChina", "P@ssw0rdChina", "NancyCustomer1");
            TimeManager.MediumPause();
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

            //Time range = 2012-1-1 to 2013-12-15
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonType);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

           //Select "介质总览"
            CarbonUsage.SelectCommodity();
            TimeManager.ShortPause();
           
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //"Year"
            CarbonUsage.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //"Month"
            CarbonUsage.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Select "介质单项" = "电"+"自来水"+"煤"
            CarbonUsage.SelectCommodity(input.InputData.commodityNames);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Year"
            CarbonUsage.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //"Month"
            CarbonUsage.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

            //Select "电"+"自来水"
            CarbonUsage.DeSelectCommodity(input.InputData.commodityNames[2]);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Week"
            CarbonUsage.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

            //"Day"
            CarbonUsage.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);

            //Select "电"
            CarbonUsage.DeSelectCommodity(input.InputData.commodityNames[1]);
            TimeManager.ShortPause();

            //ManualTimeRange[1]
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Hour"
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);

            //ManualTimeRange[2]
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Hour"
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);

            //ManualTimeRange[3]
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Hour"
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[8], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[8], input.InputData.failedFileName[8]);

        }

        [Test]
        [CaseID("TC-J1-FVT-CarbonUsageDataVerification-DataView-101-2")]
        [MultipleTestDataSource(typeof(CarbonUsageData[]), typeof(CarbonUsageDataVerificationSuite), "TC-J1-FVT-CarbonUsageDataVerification-DataView-101-2")]
        public void CarbonUsageDataVerification02(CarbonUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            CarbonUsage.NavigateToCarbonUsage();
            TimeManager.MediumPause();

            //Hierarchy = NancyCostCustomer2/组织A/园区A/楼宇A or B
            CarbonUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Time range = 2012-1-1 to 2013-12-15
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.SelectCarbonConvertTarget(input.InputData.CarbonType);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            
            //Select "介质总览"
            CarbonUsage.SelectCommodity();
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //"Year"
            CarbonUsage.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //"Month"
            CarbonUsage.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //"Week" 
            CarbonUsage.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //"Day"
            CarbonUsage.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

            //ManualTimeRange[1]
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Hour"
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

            //ManualTimeRange[2]
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[2].StartTime, ManualTimeRange[2].EndTime);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Hour"
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);

            //ManualTimeRange[3]
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[3].StartTime, ManualTimeRange[3].EndTime);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Hour"
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);

            //ManualTimeRange[0]
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //Select "介质单项"="电"+"自来水"+"煤"
            CarbonUsage.SelectCommodity(input.InputData.commodityNames);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Year"
            CarbonUsage.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);

            //"Month"
            CarbonUsage.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[8], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[8], input.InputData.failedFileName[8]);

            //"Week"
            CarbonUsage.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[9], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[9], input.InputData.failedFileName[9]);

            //"Day"
            CarbonUsage.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[10], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[10], input.InputData.failedFileName[10]);

            //ManualTimeRange[1]
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Hour"
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[11], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[11], input.InputData.failedFileName[11]);

            //ManualTimeRange[2]
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[2].StartTime, ManualTimeRange[2].EndTime);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Hour"
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[12], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[12], input.InputData.failedFileName[12]);

            //ManualTimeRange[3]
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[3].StartTime, ManualTimeRange[3].EndTime);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Hour"
            CarbonUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(CarbonUsage.IsNoDataInEnergyGrid());
            CarbonUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[13], DisplayStep.Default);
            TimeManager.MediumPause();
            CarbonUsage.CompareDataViewCarbonUsage(input.ExpectedData.expectedFileName[13], input.InputData.failedFileName[13]);

        }
    }
}
