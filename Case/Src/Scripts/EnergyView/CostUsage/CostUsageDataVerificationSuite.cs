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
    //[Ignore("ignore")]
    [ManualCaseID("TC-J1-FVT-CostUsageDataVerification-DataView-101"), CreateTime("2013-12-23"), Owner("Amber")]
    public class CostUsageDataVerificationSuite : TestSuiteBase
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

            //HomePagePanel.ExitJazz();

            //JazzFunction.LoginPage.LoginWithOption("SchneiderElectricChina", "P@ssw0rdChina", "NancyCustomer1");
            //TimeManager.MediumPause();
        }

        private static CostPanel CostUsage = JazzFunction.CostPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [Test]
        [CaseID("TC-J1-FVT-CostUsageDataVerification-DataView-101-1")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostUsageDataVerificationSuite), "TC-J1-FVT-CostUsageDataVerification-DataView-101-1")]
        public void CostUsageDataVerification01(CostUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.LongPause();

            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Time range = 2012-1-1 to 2013-12-15
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();
            
            //"总览"
            CostUsage.SelectCommodity();
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //"Year"
            CostUsage.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //"Month"
            CostUsage.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //"单项" = 电 +　自来水 + 煤
            CostUsage.SelectCommodity(input.InputData.commodityNames[0]);
            CostUsage.SelectCommodity(input.InputData.commodityNames[1]);
            CostUsage.SelectCommodity(input.InputData.commodityNames[2]);
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //"Year"
            CostUsage.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //"Month"
            CostUsage.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

            //"单项" = 电 +　自来水
            CostUsage.DeSelectCommodity(input.InputData.commodityNames[2]);
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //"Week"
            CostUsage.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

            //"Day"
            CostUsage.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);

            //"单项" = 电
            CostUsage.DeSelectCommodity(input.InputData.commodityNames[1]);

            //ManualTimeRange[1]
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //"Hour"
            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);

            //ManualTimeRange[2]
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //"Hour"
            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);

            //ManualTimeRange[3]
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //"Hour"
            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[8], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[8], input.InputData.failedFileName[8]);

        }

        [Test]
        [CaseID("TC-J1-FVT-CostUsageDataVerification-DataView-101-2")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostUsageDataVerificationSuite), "TC-J1-FVT-CostUsageDataVerification-DataView-101-2")]
        public void CostUsageDataVerification02(CostUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.LongPause();

            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            //Hierarchy = NancyCostCustomer2/组织A/园区A/楼宇A or B
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            
            //Time range = 2012-1-1 to 2013-12-15
             var ManualTimeRange = input.InputData.ManualTimeRange;
             EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
             TimeManager.ShortPause();
             
              //"总览"
              CostUsage.SelectCommodity();
              EnergyViewToolbar.View(EnergyViewType.List);
              JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
              TimeManager.MediumPause();
              
                //"Year"
                CostUsage.ClickDisplayStep(DisplayStep.Year);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.MediumPause();

                CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
                TimeManager.MediumPause();
                CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

                //"Month"
                CostUsage.ClickDisplayStep(DisplayStep.Month);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.MediumPause();

                CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
                TimeManager.MediumPause();
                CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

                //"Week"
                CostUsage.ClickDisplayStep(DisplayStep.Week);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.MediumPause();

                CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
                TimeManager.MediumPause();
                CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
            
             //"Day"
             CostUsage.ClickDisplayStep(DisplayStep.Day);
             JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
             TimeManager.MediumPause();

             CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
             TimeManager.MediumPause();
             CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

             //TManualTimeRange[1]
             EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
             TimeManager.ShortPause();

             EnergyViewToolbar.View(EnergyViewType.List);
             JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
             TimeManager.MediumPause();

             //"Hour"
             CostUsage.ClickDisplayStep(DisplayStep.Hour);
             JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
             TimeManager.MediumPause();

             CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4], DisplayStep.Default);
             TimeManager.MediumPause();
             CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

             //ManualTimeRange[2]
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //"Hour"
            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);

            //ManualTimeRange[3]
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //"Hour"
            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);

            //Time range = 2012-1-1 to 2013-12-15
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();
           
            //"单项" = 电 +　自来水 + 煤
            CostUsage.SelectCommodity(input.InputData.commodityNames[0]);
            CostUsage.SelectCommodity(input.InputData.commodityNames[1]);
            CostUsage.SelectCommodity(input.InputData.commodityNames[2]);
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            
           //"Year"
           CostUsage.ClickDisplayStep(DisplayStep.Year);
           JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
           TimeManager.MediumPause();

           CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7], DisplayStep.Default);
           TimeManager.MediumPause();
           CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);

           //"Month"
           CostUsage.ClickDisplayStep(DisplayStep.Month);
           JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
           TimeManager.MediumPause();

           CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[8], DisplayStep.Default);
           TimeManager.MediumPause();
           CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[8], input.InputData.failedFileName[8]);
            
           //"Week"
           CostUsage.ClickDisplayStep(DisplayStep.Week);
           JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
           TimeManager.MediumPause();

           CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[9], DisplayStep.Default);
           TimeManager.MediumPause();
           CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[9], input.InputData.failedFileName[9]);

           //"Day"
           CostUsage.ClickDisplayStep(DisplayStep.Day);
           JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
           TimeManager.MediumPause();

           CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[10], DisplayStep.Default);
           TimeManager.MediumPause();
           CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[10], input.InputData.failedFileName[10]);

           //ManualTimeRange[1]
           EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
           TimeManager.ShortPause();

           EnergyViewToolbar.View(EnergyViewType.List);
           JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
           TimeManager.MediumPause();

           //"Hour"
           CostUsage.ClickDisplayStep(DisplayStep.Hour);
           JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
           TimeManager.MediumPause();

           CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[11], DisplayStep.Default);
           TimeManager.MediumPause();
           CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[11], input.InputData.failedFileName[11]);

           //ManualTimeRange[2]
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //"Hour"
            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[12], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[12], input.InputData.failedFileName[12]);

            //ManualTimeRange[3]
           EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
           TimeManager.ShortPause();

           EnergyViewToolbar.View(EnergyViewType.List);
           JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
           TimeManager.MediumPause();

           //"Hour"
           CostUsage.ClickDisplayStep(DisplayStep.Hour);
           JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
           TimeManager.MediumPause();

           CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[13], DisplayStep.Default);
           TimeManager.MediumPause();
           CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[13], input.InputData.failedFileName[13]);
          
        }
        
        [Test]
        [CaseID("TC-J1-FVT-CostUsageDataVerification-DataView-101-4")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostUsageDataVerificationSuite), "TC-J1-FVT-CostUsageDataVerification-DataView-101-4")]
        public void CostUsageDataVerification04(CostUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.LongPause();

            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            //Hierarchy = NancyCostCustomer2/组织A/园区A/楼宇B/空调
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            CostUsage.SwitchTagTab(TagTabs.SystemDimensionTab);
            TimeManager.ShortPause();

            CostUsage.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Time range = 2012-1-1 to 2013-12-15
            var ManualTimeRange = input.InputData.ManualTimeRange;
             EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
             TimeManager.ShortPause();
             
             //"总览"
             CostUsage.SelectCommodity();
             TimeManager.ShortPause();

             EnergyViewToolbar.View(EnergyViewType.List);
             JazzMessageBox.LoadingMask.WaitSubMaskLoading();
             TimeManager.LongPause();
             
             //"Year"
             CostUsage.ClickDisplayStep(DisplayStep.Year);
             JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
             TimeManager.LongPause();

             CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
             TimeManager.MediumPause();
             CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

             //"Month"
             CostUsage.ClickDisplayStep(DisplayStep.Month);
             JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
             TimeManager.LongPause();

             CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
             TimeManager.MediumPause();
             CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

             //"Week"
             CostUsage.ClickDisplayStep(DisplayStep.Week);
             JazzMessageBox.LoadingMask.WaitChartMaskerLoading(); 
             TimeManager.LongPause();

             CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
             TimeManager.MediumPause();
             CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

             //"Day"
             CostUsage.ClickDisplayStep(DisplayStep.Day);
             JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
             TimeManager.LongPause();

             CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
             TimeManager.MediumPause();
             CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

             //TimeRange = 2012-7-15  to 2012-8-15
             EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
             TimeManager.ShortPause();

             EnergyViewToolbar.View(EnergyViewType.List);
             JazzMessageBox.LoadingMask.WaitSubMaskLoading();
             TimeManager.LongPause();

             //"Hour"
             CostUsage.ClickDisplayStep(DisplayStep.Hour);
             JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
             TimeManager.LongPause();

             CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4], DisplayStep.Default);
             TimeManager.MediumPause();
             CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

             //TimeRange = 2013-1-10  to 2013-2-10
             EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
             EnergyViewToolbar.SetTimeRange(ManualTimeRange[2].StartTime, ManualTimeRange[2].EndTime);
             TimeManager.ShortPause();

             EnergyViewToolbar.View(EnergyViewType.List);
             JazzMessageBox.LoadingMask.WaitSubMaskLoading();
             TimeManager.LongPause();

             //"Hour"
             CostUsage.ClickDisplayStep(DisplayStep.Hour);
             JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
             TimeManager.LongPause();

             CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5], DisplayStep.Default);
             TimeManager.MediumPause();
             CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);

             //TimeRange = 2013-7-20  to 2013-8-20
             EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
             TimeManager.ShortPause();

             EnergyViewToolbar.View(EnergyViewType.List);
             JazzMessageBox.LoadingMask.WaitSubMaskLoading();
             TimeManager.LongPause();

             //"Hour"
             CostUsage.ClickDisplayStep(DisplayStep.Hour);
             JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
             TimeManager.LongPause();

             CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6], DisplayStep.Default);
             TimeManager.MediumPause();
             CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);
            
             //Time range = 2012-1-1 to 2013-12-15
             EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
             TimeManager.ShortPause();
             
            //"介质单项" = "电"+"自来水"+"煤"+"天燃气"
            CostUsage.SelectCommodity(input.InputData.commodityNames);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            
           //"Year"
           CostUsage.ClickDisplayStep(DisplayStep.Year);
           JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
           TimeManager.LongPause();

           CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7], DisplayStep.Default);
           TimeManager.MediumPause();
           CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);

           //"Month"
           CostUsage.ClickDisplayStep(DisplayStep.Month);
           JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
           TimeManager.LongPause();

           CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[8], DisplayStep.Default);
           TimeManager.MediumPause();
           CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[8], input.InputData.failedFileName[8]);

           //"Week"
           CostUsage.ClickDisplayStep(DisplayStep.Week);
           JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
           TimeManager.LongPause();

           CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[9], DisplayStep.Default);
           TimeManager.MediumPause();
           CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[9], input.InputData.failedFileName[9]);

           //"Day"
           CostUsage.ClickDisplayStep(DisplayStep.Day);
           JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
           TimeManager.LongPause();

           CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[10], DisplayStep.Default);
           TimeManager.MediumPause();
           CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[10], input.InputData.failedFileName[10]);

           //TimeRange = 2012-7-15  to 2012-8-15
           EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
           TimeManager.ShortPause();

           EnergyViewToolbar.View(EnergyViewType.List);
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.LongPause();

           //"Hour"
           CostUsage.ClickDisplayStep(DisplayStep.Hour);
           JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
           TimeManager.LongPause();

           CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[11], DisplayStep.Default);
           TimeManager.MediumPause();
           CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[11], input.InputData.failedFileName[11]);

           //TimeRange = 2013-1-10  to 2013-2-10
           EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
           EnergyViewToolbar.SetTimeRange(ManualTimeRange[2].StartTime, ManualTimeRange[2].EndTime);
           TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Hour"
            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[12], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[12], input.InputData.failedFileName[12]);

            //TimeRange = 2013-7-20  to 2013-8-20
           EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
           TimeManager.ShortPause();

           EnergyViewToolbar.View(EnergyViewType.List);
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.LongPause();

           //"Hour"
           CostUsage.ClickDisplayStep(DisplayStep.Hour);
           JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
           TimeManager.LongPause();

           CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[13], DisplayStep.Default);
           TimeManager.MediumPause();
           CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[13], input.InputData.failedFileName[13]);
       
        }
        
        [Test]
        [CaseID("TC-J1-FVT-CostUsageDataVerification-DataView-101-5")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostUsageDataVerificationSuite), "TC-J1-FVT-CostUsageDataVerification-DataView-101-5")]
        public void CostUsageDataVerification05(CostUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.LongPause();

            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            //Hierarchy = NancyCostCustomer2/组织A/园区A/楼宇B/一层
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            CostUsage.SwitchTagTab(TagTabs.AreaDimensionTab);
            TimeManager.ShortPause();

            CostUsage.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Time range = 2012-1-1 to 2013-12-15
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
           TimeManager.ShortPause();

           //"总览"
           CostUsage.SelectCommodity();
           TimeManager.ShortPause();

           EnergyViewToolbar.View(EnergyViewType.List);
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.LongPause();
           
          //"Year"
          CostUsage.ClickDisplayStep(DisplayStep.Year);
          JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
          TimeManager.LongPause();

          CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
          TimeManager.MediumPause();
          CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

          //"Month"
          CostUsage.ClickDisplayStep(DisplayStep.Month);
          JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
          TimeManager.LongPause();

          CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
          TimeManager.MediumPause();
          CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

          //"Week"
          CostUsage.ClickDisplayStep(DisplayStep.Week);
          JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
          TimeManager.LongPause();

          CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
          TimeManager.MediumPause();
          CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

          //"Day"
          CostUsage.ClickDisplayStep(DisplayStep.Day);
          JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
          TimeManager.LongPause();

          CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
          TimeManager.MediumPause();
          CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

          //Time range = 2012-7-15 to 2012-8-15
          EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
          TimeManager.ShortPause();

          EnergyViewToolbar.View(EnergyViewType.List);
          JazzMessageBox.LoadingMask.WaitSubMaskLoading();
          TimeManager.LongPause();

          //"Hour"
          CostUsage.ClickDisplayStep(DisplayStep.Hour);
          JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
          TimeManager.LongPause();

          CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4], DisplayStep.Default);
          TimeManager.MediumPause();
          CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);
           
           //Time range = 2013-1-15 to 2013-2-15
          EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
          EnergyViewToolbar.SetTimeRange(ManualTimeRange[2].StartTime, ManualTimeRange[2].EndTime);
          TimeManager.ShortPause();

           EnergyViewToolbar.View(EnergyViewType.List);
           JazzMessageBox.LoadingMask.WaitSubMaskLoading();
           TimeManager.LongPause();

           //"Hour"
           CostUsage.ClickDisplayStep(DisplayStep.Hour);
           JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
           TimeManager.LongPause();

           CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5], DisplayStep.Default);
           TimeManager.MediumPause();
           CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);
        
         //Time range = 2013-7-20 to 2013-8-20
         EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
         TimeManager.ShortPause();

         EnergyViewToolbar.View(EnergyViewType.List);
         JazzMessageBox.LoadingMask.WaitSubMaskLoading();
         TimeManager.LongPause();

         //"Hour"
         CostUsage.ClickDisplayStep(DisplayStep.Hour);
         JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
         TimeManager.LongPause();

         CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[6], DisplayStep.Default);
         TimeManager.MediumPause();
         CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[6], input.InputData.failedFileName[6]);

         //Time range = 2012-1-1 to 2013-12-15
         EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
         TimeManager.ShortPause();
         
            //"介质单项" = "电"+"自来水"+"煤"
            CostUsage.SelectCommodity(input.InputData.commodityNames);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
           
            //"Year"
            CostUsage.ClickDisplayStep(DisplayStep.Year);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[7], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[7], input.InputData.failedFileName[7]);

            //"Month"
            CostUsage.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[8], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[8], input.InputData.failedFileName[8]);

            //"Week"
            CostUsage.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[9], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[9], input.InputData.failedFileName[9]);

            //"Day"
            CostUsage.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[10], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[10], input.InputData.failedFileName[10]);

            //Time range = 2012-7-15 to 2012-8-15
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Hour"
            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[11], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[11], input.InputData.failedFileName[11]);
           
            //Time range = 2013-1-15 to 2013-2-15
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[2].StartTime, ManualTimeRange[2].EndTime);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Hour"
            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[12], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[12], input.InputData.failedFileName[12]);
            
            //Time range = 2013-7-20 to 2013-8-20
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //"Hour"
            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[13], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[13], input.InputData.failedFileName[13]);
            
        }
        
        [Test]
        [CaseID("TC-J1-FVT-CostUsageDataVerification-DataView-101-6")]
        [MultipleTestDataSource(typeof(CostUsageData[]), typeof(CostUsageDataVerificationSuite), "TC-J1-FVT-CostUsageDataVerification-DataView-101-6")]
        public void CostUsageDataVerification06(CostUsageData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.LongPause();

            CostUsage.NavigateToCostUsage();
            TimeManager.MediumPause();

            //Hierarchy = NancyCostCustomer2/组织A/园区B/楼宇C
            CostUsage.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //"介质单项"——“电”
            CostUsage.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //"Day"
            CostUsage.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Time range = 2013-7-15 to 2013-8-15
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //"Hour"
            CostUsage.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            CostUsage.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            CostUsage.CompareDataViewCostUsage(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
            }
         }
    }
