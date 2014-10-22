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

namespace Mento.Script.EnergyView.EnergyAnalysis
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-MultipleIntervalsComparasion-DataView-101"), CreateTime("2013-08-13"), Owner("Emma")]
    public class MultipleIntervalsComparasionDataViewSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateHome();
            JazzFunction.LoginPage.RefreshJazz("NancyCustomer1");
            TimeManager.LongPause();

            //HomePagePanel.ExitJazz();

            //JazzFunction.LoginPage.LoginWithOption("SchneiderElectricChina", "P@ssw0rdChina", "NancyCustomer1");
            //TimeManager.MediumPause();
        }

        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static TimeSpanDialog TimeSpanDialog = JazzFunction.TimeSpanDialog;

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-DataView-101-1")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(MultipleIntervalsComparasionDataViewSuite), "TC-J1-FVT-MultipleIntervalsComparasion-DataView-101-1")]
        public void AddTimeSpanDataViewAndVerify(TimeSpansData input)
        {
            //"+时间段" button is disabled when there is no tag selected
            Assert.IsFalse(EnergyViewToolbar.IsTimeSpanButtonEnable());
            
            //Select one tag and view data view
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            
            //Set date range
            EnergyViewToolbar.SetDateRange(new DateTime(2013, 1, 1), new DateTime(2013, 1, 7));
            TimeManager.ShortPause();
            
            //Check tag and view data view
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());

            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[0], 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[0], 2);
            TimeManager.MediumPause();
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Change the Start Time in first date range
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.InputBaseStartDate(input.InputData.BaseStartDate[0]);
            TimeSpanDialog.InputBaseStartTime(input.InputData.BaseStartTime[0]);

            Assert.AreEqual(input.ExpectedData.EndTimeValue[0], TimeSpanDialog.GetAdditionEndTimeValue(2));
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Change the End Time in first date range, 
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.InputBaseEndDate(input.InputData.BaseEndDate[0]);
            TimeSpanDialog.InputBaseEndTime(input.InputData.BaseEndTime[0]);

            Assert.AreEqual(input.ExpectedData.EndTimeValue[1], TimeSpanDialog.GetAdditionEndTimeValue(2));
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Add multiple compared spans, until the number of total time spans is 5
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            for (int i = 1; i < 4; i++)
            {
                TimeSpanDialog.ClickAddTimeSpanButton();
                TimeManager.ShortPause();

                TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[0], i + 2);
                TimeManager.ShortPause();
                TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[0], i + 2);
                TimeManager.MediumPause();
            }

            Assert.IsTrue(TimeSpanDialog.IsAddTimeSpanButtonDisabled());

            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
        }

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-DataView-101-2")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(MultipleIntervalsComparasionDataViewSuite), "TC-J1-FVT-MultipleIntervalsComparasion-DataView-101-2")]
        public void AddTimeSpanDataViewAndSaveToDashboard(TimeSpansData input)
        {
            //Select one tag and view data view
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range
            EnergyViewToolbar.SetDateRange(input.InputData.BaseStartDate[0], input.InputData.BaseEndDate[0]);
            EnergyViewToolbar.SetTimeRange(input.InputData.BaseStartTime[0], input.InputData.BaseEndTime[0]);
            TimeManager.ShortPause();

            //Check tag and view data view
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());

            //Open time span dialog and add some more special time ranges to verify
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[0], 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[0], 2);
            TimeManager.MediumPause();

            for (int i = 1; i < 2; i++)
            {
                TimeSpanDialog.ClickAddTimeSpanButton();
                TimeManager.ShortPause();

                TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[i], i + 2);
                TimeManager.ShortPause();
                TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[i], i + 2);
                TimeManager.MediumPause();
            }

            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Save to dashboard
            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);

            //On homepage, check the dashboard
            EnergyAnalysis.NavigateToAllDashBoards();
            HomePagePanel.SelectHierarchyNode(dashboard.HierarchyName);
            TimeManager.MediumPause();
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));
            //Assert.IsTrue(HomePagePanel.CompareMinWidgetDataView(EnergyAnalysis.EAPath, input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0], dashboard.WigetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-DataView-101-3934")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(MultipleIntervalsComparasionDataViewSuite), "TC-J1-FVT-MultipleIntervalsComparasion-DataView-101-3934")]
        public void CheckStepDayDisplay3934(TimeSpansData input)
        {
            //Select NancyCostCustomer2->楼宇A
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //去年
            EnergyViewToolbar.SetDateRange(input.InputData.BaseStartDate[0], input.InputData.BaseEndDate[0]);
            TimeManager.ShortPause();

            //Check tag and view data view
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());

            //Open time span dialog and add some more special time ranges to verify
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[0], 2);
            TimeManager.ShortPause();

            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            //JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            //TimeManager.MediumPause();

            //EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            //TimeManager.MediumPause();
            //EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

        }

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-DataView-101-3949")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(MultipleIntervalsComparasionDataViewSuite), "TC-J1-FVT-MultipleIntervalsComparasion-DataView-101-3949")]
        public void CheckStepDayDisplayMissingData3949(TimeSpansData input)
        {
            //Select NancyCostCustomer2->楼宇A
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //去年
            EnergyViewToolbar.SetDateRange(input.InputData.BaseStartDate[0], input.InputData.BaseEndDate[0]);
            TimeManager.ShortPause();

            //Check tag and view data view
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());

            //Open time span dialog and add some more special time ranges to verify
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[0], 2);
            TimeManager.ShortPause();

            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

        }

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-DataView-101-3371")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(MultipleIntervalsComparasionDataViewSuite), "TC-J1-FVT-MultipleIntervalsComparasion-DataView-101-3371")]
        public void SP2_VerifyTheRecordsWithNullData3371(TimeSpansData input)
        {
            //From SP2, select Customer 'NancyOtherCustomer3' , 
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Span1:  2013-06-05 14:00 to 2013-08-16 18:00
            EnergyViewToolbar.SetDateRange(input.InputData.BaseStartDate[0], input.InputData.BaseEndDate[0]);
            EnergyViewToolbar.SetTimeRange(input.InputData.BaseStartTime[0], input.InputData.BaseEndTime[0]);
            TimeManager.ShortPause();

            //Check tag and view data view
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());

            //Open time span dialog and add some more special time ranges to verify
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            //Span2:  2013-06-01 00:00 to 2013-08-12 04:00
            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[0], 2);
            TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[0], 2);
            TimeManager.ShortPause();

            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

        }

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-DataView-101-3")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(MultipleIntervalsComparasionDataViewSuite), "TC-J1-FVT-MultipleIntervalsComparasion-DataView-101-3")]
        public void VerifyRawStepAndSwitchType(TimeSpansData input)
        {
            //NancyCostCustomer2>组织A>园区A>楼宇A 
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Select tag 'BuildingA_P1_Electricity',
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.MediumPause();

            //There are two time spans as below:
            //Span1:  去年
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.MediumPause();

            //Check tag and view data view
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());

            //Open time span dialog and add some more special time ranges to verify
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            //Span2:  2012-12-01 00:00 to 2013-12-01 24:00
            TimeSpanDialog.SelectCompareTimeType(CompareTimeType.UserDefined, 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[0], 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[0], 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionEndDate(input.InputData.EndDate[0], 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionEndTime(input.InputData.EndTime[0], 2);
            TimeManager.ShortPause();
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Select chart type 'DataView', click 查询数据.
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Verify data values of 'Month' step are displayed by default. And all data display correct
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Change step to Hour
            //EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            //JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            //TimeManager.MediumPause();

            ////The number of total pages are correct.
            ////Page1 of data values of 'Raw' step are displayed correctly.
            //EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            //TimeManager.MediumPause();
            //EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Switch back to line chart
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.Line);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Two lines display out, no data miss
            Assert.AreEqual(2, EnergyAnalysis.GetTrendChartLines());

            //Switch back to Data View
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Change back to data view and change step to Day
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //The number of total pages are correct.
            //Page1 of data values of 'Day' step are displayed correctly.
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Change back to data view and change step to Week
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //The number of total pages are correct.
            //Page1 of data values of 'Week' step are displayed correctly.
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

        }
    }
}
