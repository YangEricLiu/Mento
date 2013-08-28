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

namespace Mento.Script.EnergyView.EnergyManagement
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-SetDisplayStep-001"), CreateTime("2013-08-22"), Owner("Emma")]
    public class SetDisplayStepSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.MediumPause();
            
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static CostPanel CostPanel = JazzFunction.CostPanel;
        private static CarbonUsagePanel CarbonPanel = JazzFunction.CarbonUsagePanel;

        [Test]
        [CaseID("TC-J1-FVT-SetDisplayStep-001-1")]
        [MultipleTestDataSource(typeof(DisplayStepData[]), typeof(SetDisplayStepSuite), "TC-J1-FVT-SetDisplayStep-001-1")]
        public void EnergyAnalysisSetDisplayStep123(DisplayStepData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range "2012/07/29-2012/08/03"
            var timeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(timeRange[0].StartDate, timeRange[0].EndDate);
            TimeManager.ShortPause();
            
            //Check tag and view trend chart
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            EnergyViewToolbar.ClickViewButton();
            TimeManager.LongPause();
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains("所选数据点不支持\"按小时\",\"按天\",\"按周\"的步长显示，换个步长试试。"));
            JazzWindow.WindowMessageInfos.Quit();
            TimeManager.ShortPause();

            //Display original view before selection. Uncheck V(M)
            Assert.IsFalse(EnergyAnalysis.IsTagChecked(input.InputData.TagNames[0]));
            Assert.IsFalse(EnergyAnalysis.IsTrendChartDrawn());

            //Set date range "2012/07/01-2012/07/31"
            EnergyViewToolbar.SetDateRange(timeRange[1].StartDate, timeRange[1].EndDate);
            TimeManager.ShortPause();

            //Check tag and view trend chart
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            EnergyViewToolbar.ClickViewButton();
            TimeManager.LongPause();
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains("所选数据点不支持\"按小时\",\"按天\",\"按周\"的步长显示，换个步长试试。"));
            JazzWindow.WindowMessageInfos.Quit();
            TimeManager.ShortPause();

            //Display original view before selection. Uncheck V(M)
            Assert.IsFalse(EnergyAnalysis.IsTagChecked(input.InputData.TagNames[0]));
            Assert.IsFalse(EnergyAnalysis.IsTrendChartDrawn());

            //For multiple data sources, one step in Optional Steps is not supported by one source.VD and VH
            EnergyViewToolbar.SetDateRange(timeRange[0].StartDate, timeRange[0].EndDate);
            TimeManager.ShortPause();
            EnergyAnalysis.CheckTag(input.InputData.TagNames[1]);
            EnergyAnalysis.CheckTag(input.InputData.TagNames[2]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            TimeManager.LongPause();
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains("所选数据点不支持\"按小时\"的步长显示，换个步长试试。"));
            Assert.IsTrue(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Hour));
            EnergyAnalysis.ClickStepButtonOnWindow(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));

            //Set date range "2012/07/01-2012/07/31", only check VD with line chart and data view
            EnergyViewToolbar.SetDateRange(timeRange[1].StartDate, timeRange[1].EndDate);
            TimeManager.ShortPause();
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[2]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));

            //Covnert to data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Week));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            TimeManager.LongPause();
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains("所选数据点不支持\"按小时\"的步长显示，换个步长试试。"));
            Assert.IsTrue(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Hour));
            TimeManager.MediumPause();
            EnergyAnalysis.ClickStepButtonOnWindow(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Week));       
        }

        [Test]
        [CaseID("TC-J1-FVT-SetDisplayStep-001-2")]
        [MultipleTestDataSource(typeof(DisplayStepData[]), typeof(SetDisplayStepSuite), "TC-J1-FVT-SetDisplayStep-001-1")]
        public void EnergyAnalysisSetDisplayStep4(DisplayStepData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range "2012/07/29-2012/08/03"
            var timeRange = input.InputData.ManualTimeRange;
            
            //4. Select Start Time or End Time which cannot be covered with whole step. 
            //Set date range "2012/07/01 3:30-2012/07/03 23:30", only check VD with data view
            EnergyViewToolbar.SetDateRange(timeRange[2].StartDate, timeRange[2].EndDate);
            EnergyViewToolbar.SetTimeRange(timeRange[2].StartTime, timeRange[2].EndTime);
            TimeManager.ShortPause();

            //Step as 1 day, and then 7/2 and 7/3 day data is loaded.).
            EnergyAnalysis.CheckTag(input.InputData.TagNames[1]);
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Delete all datas
            //Click  "删除所有" option then confirm
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.ClearAllMessage));
            JazzMessageBox.MessageBox.Clear();
            TimeManager.MediumPause();

            //4. Set date range "2012/07/15-2012/12/15", only check VM with data view
            EnergyViewToolbar.SetDateRange(timeRange[3].StartDate, timeRange[3].EndDate);
            TimeManager.ShortPause();

            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();

            //Step as 1 month, and then 8-12 month data is loaded.).
            EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
        }

        [Test]
        [CaseID("TC-J1-FVT-SetDisplayStep-001-3")]
        [MultipleTestDataSource(typeof(DisplayStepData[]), typeof(SetDisplayStepSuite), "TC-J1-FVT-SetDisplayStep-001-1")]
        public void EnergyAnalysisSetDisplayStep5(DisplayStepData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            var timeRange = input.InputData.ManualTimeRange;
            EnergyAnalysis.CheckTag(input.InputData.TagNames[2]);
            TimeManager.ShortPause();

            //5. Change time range from 2012/07/01 3:30-2012/07/01 15:30
            EnergyViewToolbar.SetDateRange(timeRange[4].StartDate, timeRange[4].EndDate);
            EnergyViewToolbar.SetTimeRange(timeRange[4].StartTime, timeRange[4].EndTime);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Only "hour" button display
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            //To 2012/07/29 3:30-2012/08/03 15:30
            EnergyViewToolbar.SetDateRange(timeRange[5].StartDate, timeRange[5].EndDate);
            EnergyViewToolbar.SetTimeRange(timeRange[5].StartTime, timeRange[5].EndTime);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Only "hour" and "Day" button display
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Hour));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            //To 2012/07/01-2012/07/31
            EnergyViewToolbar.SetDateRange(timeRange[6].StartDate, timeRange[6].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Only "Week" and "Day" button display
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            //To 2012/06/01-2012/08/31
            EnergyViewToolbar.SetDateRange(timeRange[7].StartDate, timeRange[7].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Only "Month" pressed, "Week" and "Day" button display
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            //To 2012/01/01-2012/12/31
            EnergyViewToolbar.SetDateRange(timeRange[8].StartDate, timeRange[8].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Only "Month" button display
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            //2008/01/01-2013/01/01
            EnergyViewToolbar.SetDateRange(timeRange[9].StartDate, timeRange[9].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Only "Week" and "Day" button display
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
        }

        [Test]
        [CaseID("TC-J1-FVT-SetDisplayStep-001-4")]
        [MultipleTestDataSource(typeof(DisplayStepData[]), typeof(SetDisplayStepSuite), "TC-J1-FVT-SetDisplayStep-001-1")]
        public void EnergyAnalysisSetDisplayStep6(DisplayStepData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            var timeRange = input.InputData.ManualTimeRange;
            EnergyAnalysis.CheckTag(input.InputData.TagNames[2]);
            TimeManager.ShortPause();
            
            //6. Switch from data view to trend chart view and original step is not supported.
            //To 2012/07/10-2012/08/05 
            EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.SetDateRange(timeRange[10].StartDate, timeRange[10].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Only "Week" and "Day" button display
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            //to chart view
            EnergyViewToolbar.View(EnergyViewType.Line);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Only "Week" and "Day" button display
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            //To 2012/01/01-2012/12/31
            EnergyViewToolbar.SetDateRange(timeRange[8].StartDate, timeRange[8].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.List);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Only "hour" "Week" "month" and "Day" button display
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            //change to line chart
            EnergyViewToolbar.View(EnergyViewType.Line);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Only "month" button display
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));
        }

        [Test]
        [CaseID("TC-J1-FVT-SetDisplayStep-001-5")]
        [MultipleTestDataSource(typeof(DisplayStepData[]), typeof(SetDisplayStepSuite), "TC-J1-FVT-SetDisplayStep-001-2")]
        public void CostSetDisplayStep8(DisplayStepData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CostUsage);
            TimeManager.MediumPause();

            //Select 组织A->园区A->楼宇B
            CostPanel.SelectHierarchy(input.InputData.Hierarchies);
            TimeManager.MediumPause();

            //Selected Time Range=2012/07/01-2012/07/31
            var timeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(timeRange[0].StartDate, timeRange[0].EndDate);
            TimeManager.MediumPause();

            //Commodity=电, Click "峰谷展示".
            CostPanel.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.MediumPause();
            EnergyViewToolbar.ShowPeakValley();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Optional step=day/week.
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            //Selected Time Range=2012/07/29-2012/08/04
            EnergyViewToolbar.SetDateRange(timeRange[1].StartDate, timeRange[1].EndDate);
            TimeManager.MediumPause();
            EnergyViewToolbar.ShowPeakValley();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            EnergyViewToolbar.ShowPeakValley();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Optional step=day/hour.
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            //Click optional step=hour button
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Showing message in dialog, No Optional step=hour in dialog.
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.StepMessage[0]));
            JazzMessageBox.MessageBox.Confirm();
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-SetDisplayStep-001-6")]
        [MultipleTestDataSource(typeof(DisplayStepData[]), typeof(SetDisplayStepSuite), "TC-J1-FVT-SetDisplayStep-001-3")]
        public void CostSetDisplayStep9(DisplayStepData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CostUsage);
            TimeManager.MediumPause();

            //Select 组织A->园区A->楼宇A
            CostPanel.SelectHierarchy(input.InputData.Hierarchies);
            TimeManager.MediumPause();

            //Select multiple commodities 电+煤.
            CostPanel.SelectCommodity(input.InputData.commodityNames[0]);
            CostPanel.SelectCommodity(input.InputData.commodityNames[1]);
            TimeManager.MediumPause();

            //Selected Time Range=2012/08/02-2012/08/06
            var timeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(timeRange[0].StartDate, timeRange[0].EndDate);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Click optional step=hour button
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            TimeManager.LongPause();

            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains("所选数据点不支持\"按小时\"的步长显示，换个步长试试。"));
            Assert.IsTrue(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Hour));
            TimeManager.MediumPause();
            EnergyAnalysis.ClickStepButtonOnWindow(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));

            //Select 组织A->园区A
            CostPanel.SelectHierarchy(input.InputData.OtherHierarchies);
            TimeManager.MediumPause();

            //Select commodity=电
            CostPanel.SelectCommodity(input.InputData.commodityNames[0]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Click optional step=hour button
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            TimeManager.LongPause();

            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains("所选数据点不支持\"按小时\"的步长显示，换个步长试试。"));
            Assert.IsTrue(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Hour));
            TimeManager.MediumPause();
            EnergyAnalysis.ClickStepButtonOnWindow(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));

            //Select 组织A->园区A->楼宇A
            CostPanel.SelectHierarchy(input.InputData.Hierarchies);
            TimeManager.MediumPause();

            //Select multiple commodities 电+煤.
            CostPanel.SelectCommodity(input.InputData.commodityNames[0]);
            CostPanel.SelectCommodity(input.InputData.commodityNames[1]);
            TimeManager.MediumPause();

            //Selected Time Range=2012/06/01-2012/08/31
            EnergyViewToolbar.SetDateRange(timeRange[1].StartDate, timeRange[1].EndDate);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Click optional step=hour button not display
            Assert.IsFalse(CostPanel.IsDisplayStepDisplayed(DisplayStep.Hour));
            TimeManager.LongPause();

            //Select 组织A->园区A
            CostPanel.SelectHierarchy(input.InputData.OtherHierarchies);
            TimeManager.MediumPause();

            //Select commodity=水
            CostPanel.SelectCommodity(input.InputData.commodityNames[2]);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Click optional step=hour button not display
            Assert.IsFalse(CostPanel.IsDisplayStepDisplayed(DisplayStep.Hour));
            TimeManager.LongPause();

            //Go to Energy Analysis-> Comparsion multiple tags. Select multiple tags  电BAV1Root+水BAV2Root+煤BAV3Root.
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            TimeManager.MediumPause();

            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.CheckTags(input.InputData.TagNames);
            EnergyViewToolbar.SetDateRange(timeRange[0].StartDate, timeRange[0].EndDate);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-SetDisplayStep-001-7")]
        [MultipleTestDataSource(typeof(DisplayStepData[]), typeof(SetDisplayStepSuite), "TC-J1-FVT-SetDisplayStep-001-4")]
        public void CostSetDisplayStep10To16(DisplayStepData input)
        {
            //10. Select NancyOtherSite->BuildingMultipleSteps
            CostPanel.SelectHierarchy(input.InputData.Hierarchies);
            TimeManager.MediumPause();

            //V(M), V(H)
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            EnergyAnalysis.CheckTag(input.InputData.TagNames[1]);
            TimeManager.ShortPause();

            //Selected Time Range=2012/07/01-2012/08/01
            var timeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(timeRange[0].StartDate, timeRange[0].EndDate);
            TimeManager.MediumPause();

            EnergyViewToolbar.View(EnergyViewType.Distribute);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Selected Time Range=2012/07/29-2012/08/03
            EnergyViewToolbar.SetDateRange(timeRange[1].StartDate, timeRange[1].EndDate);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //11. Select different aggregated step tags to display distribution chart.
            //V(M), P(H) 
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[1]);
            EnergyAnalysis.CheckTag(input.InputData.TagNames[2]);
            TimeManager.ShortPause();

            //Selected Time Range=2012/07/01-2012/07/31
            EnergyViewToolbar.SetDateRange(timeRange[2].StartDate, timeRange[2].EndDate);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Change chart type from distribution chart to trend chart.
            EnergyViewToolbar.View(EnergyViewType.Line);
            TimeManager.LongPause();
            TimeManager.LongPause();
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains("所选数据点不支持\"按小时\",\"按天\",\"按周\"的步长显示，换个步长试试。"));
            JazzWindow.WindowMessageInfos.Quit();
            TimeManager.ShortPause();

            //Back to default original status
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[0]);
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[2]);
            EnergyViewToolbar.View(EnergyViewType.Line);
            EnergyViewToolbar.ClickViewButton();
            TimeManager.LongPause();

            //12. Go to chart view with original default time range(7 days). Select a V(M) tag.
            EnergyViewToolbar.SetDateRange(timeRange[3].StartDate, timeRange[3].EndDate);
            TimeManager.MediumPause();
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            EnergyViewToolbar.ClickViewButton();
            TimeManager.LongPause();
            TimeManager.LongPause();
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains("所选数据点不支持\"按小时\",\"按天\",\"按周\"的步长显示，换个步长试试。"));
            JazzWindow.WindowMessageInfos.Quit();
            TimeManager.ShortPause();

            //Back to default original status
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[0]);
            EnergyViewToolbar.View(EnergyViewType.Line);
            EnergyViewToolbar.ClickViewButton();
            TimeManager.LongPause();

            //14.Select V(H) and go to data view in energy view. Click Option=hour.
            EnergyViewToolbar.SetDateRange(timeRange[3].StartDate, timeRange[3].EndDate);
            TimeManager.MediumPause();
            EnergyAnalysis.CheckTag(input.InputData.TagNames[1]);
            EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //VD, Selected Time Range=2012/01/01-2013/01/01
            EnergyAnalysis.CheckTag(input.InputData.TagNames[3]);
            EnergyViewToolbar.SetDateRange(timeRange[4].StartDate, timeRange[4].EndDate);
            TimeManager.MediumPause();
            EnergyViewToolbar.ClickViewButton();
            TimeManager.LongPause();
            TimeManager.LongPause();
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains("所选数据点不支持\"按小时\"的步长显示，换个步长试试。"));
            Assert.IsTrue(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Week));
            Assert.IsTrue(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Month));
            JazzWindow.WindowMessageInfos.Quit();
            TimeManager.ShortPause();

            //Back to default original status
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[3]);
            EnergyViewToolbar.View(EnergyViewType.Line);
            EnergyViewToolbar.ClickViewButton();
            TimeManager.LongPause();

            //16.Select V(H) and go to data view in energy view. Click Option=hour.
            EnergyViewToolbar.SetDateRange(timeRange[3].StartDate, timeRange[3].EndDate);
            TimeManager.MediumPause();
            EnergyAnalysis.CheckTag(input.InputData.TagNames[1]);
            EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Check other V(M) and click view chart again.
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            EnergyViewToolbar.ClickViewButton();
            TimeManager.LongPause();
            TimeManager.LongPause();
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains("所选数据点不支持\"按小时\",\"按天\",\"按周\"的步长显示，换个步长试试。"));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Month));
            JazzWindow.WindowMessageInfos.Quit();
            TimeManager.LongPause();

            Assert.IsFalse(EnergyAnalysis.IsTagChecked(input.InputData.TagNames[0]));
            Assert.IsTrue(EnergyAnalysis.IsTagChecked(input.InputData.TagNames[1]));
        }

        [Test]
        [CaseID("TC-J1-FVT-SetDisplayStep-001-8")]
        [MultipleTestDataSource(typeof(DisplayStepData[]), typeof(SetDisplayStepSuite), "TC-J1-FVT-SetDisplayStep-001-5")]
        public void CostSetDisplayStep17(DisplayStepData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CarbonUsage);
            TimeManager.MediumPause();

            //Go to Cost/Carbon. Select 总览 to display chart view.         
            CarbonPanel.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            //Selected Time Range=2012/07/29-2012/08/03
            var timeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(timeRange[0].StartDate, timeRange[0].EndDate);
            TimeManager.MediumPause();

            //Go to Cost/Carbon. Select 总览 to display chart view.
            CarbonPanel.SelectCommodity();
            EnergyViewToolbar.ClickViewButton();
            TimeManager.LongPause();
            TimeManager.LongPause();
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains("所选数据点不支持\"按小时\",\"按天\",\"按周\"的步长显示，换个步长试试。"));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Month));
            JazzWindow.WindowMessageInfos.Quit();
            TimeManager.LongPause();

            //Click "Cancel" button. Select 单项. Check Commodity=电, then click 查看数据.
            CarbonPanel.SelectCommodity(input.InputData.commodityNames[0]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
        }
    }
}
