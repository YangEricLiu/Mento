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

namespace Mento.Script.EnergyView.EnergyManagement
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-SetDisplayStep-101"), CreateTime("2013-08-28"), Owner("Emma")]
    public class SetDisplayStepValidSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.MediumPause();

            EnergyAnalysis.NavigateToEnergyAnalysis();
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
        [CaseID("TC-J1-FVT-SetDisplayStep-101-1")]
        [MultipleTestDataSource(typeof(DisplayStepData[]), typeof(SetDisplayStepValidSuite), "TC-J1-FVT-SetDisplayStep-101-1")]
        public void SetDisplayStep1011(DisplayStepData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //1. Selected Time Range
            var timeRange = input.InputData.ManualTimeRange;

            for (int i = 0; i < timeRange.Length; i++)
            {
                EnergyViewToolbar.SetDateRange(timeRange[i].StartDate, timeRange[i].EndDate);
                EnergyViewToolbar.SetTimeRange(timeRange[i].StartTime, timeRange[i].EndTime);
                TimeManager.ShortPause();

                //Check tag and view data view
                EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
                //EnergyViewToolbar.View(EnergyViewType.List);//? If view list chart here, there is no chart display when change chart to line in next step. 
                EnergyViewToolbar.View(EnergyViewType.Column);
                EnergyViewToolbar.ClickViewButton();
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();

                //Optional step=day/hour/raw, and default is day 
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

                //Click all Optional Steps to change chart view.
                EnergyViewToolbar.View(EnergyViewType.Line);
                EnergyViewToolbar.ClickViewButton();
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();

                Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
                //Optional step=day/hour/raw, and default is day 
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

                //click "hour"
                EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Hour));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

                //click "Raw"
                EnergyAnalysis.ClickDisplayStep(DisplayStep.Min);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Min));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

                //back to intinial
                EnergyAnalysis.UncheckTag(input.InputData.TagNames[0]);
                EnergyViewToolbar.ClickViewButton();
                TimeManager.LongPause();
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-SetDisplayStep-101-2")]
        [MultipleTestDataSource(typeof(DisplayStepData[]), typeof(SetDisplayStepValidSuite), "TC-J1-FVT-SetDisplayStep-101-2")]
        public void SetDisplayStep1012(DisplayStepData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //1. Selected Time Range=2012/07/01 3:00-2012/07/01 15:00
            var timeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(timeRange[0].StartDate, timeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(timeRange[0].StartTime, timeRange[0].EndTime);
            TimeManager.ShortPause();

            //Check tag and view data view
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            EnergyViewToolbar.View(EnergyViewType.Column);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Optional step=raw/hour, and default is hour 
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            //Click all Optional Steps to change chart view.
            EnergyViewToolbar.View(EnergyViewType.Line);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
            //Optional step=raw/hour, and default is hour 
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            //The energy data is aggregated as expected
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

        }

        [Test]
        [CaseID("TC-J1-FVT-SetDisplayStep-101-3")]
        [MultipleTestDataSource(typeof(DisplayStepData[]), typeof(SetDisplayStepValidSuite), "TC-J1-FVT-SetDisplayStep-101-3")]
        public void SetDisplayStep1013(DisplayStepData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //1. Selected Time Range
            var timeRange = input.InputData.ManualTimeRange;
            for (int i = 0; i < timeRange.Length; i++)
            {
                EnergyViewToolbar.SetDateRange(timeRange[i].StartDate, timeRange[i].EndDate);
                TimeManager.ShortPause();

                //Check tag and view data view
                EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
                EnergyViewToolbar.View(EnergyViewType.Column);
                EnergyViewToolbar.ClickViewButton();
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();

                //Optional step=week/day/hour/raw, and default is day 
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

                //Click all Optional Steps to change chart view.
                EnergyViewToolbar.View(EnergyViewType.Line);
                EnergyViewToolbar.ClickViewButton();
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();

                Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
                //Optional step=week/day/hour/raw, and default is day 
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

                //click "week"
                EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();
                Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Week));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));
                
                //click "raw"
                EnergyAnalysis.ClickDisplayStep(DisplayStep.Min);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();
                Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Min));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));
                
                //back to intinial
                EnergyAnalysis.UncheckTag(input.InputData.TagNames[0]);
                EnergyViewToolbar.ClickViewButton();
                TimeManager.LongPause();
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-SetDisplayStep-101-4")]
        [MultipleTestDataSource(typeof(DisplayStepData[]), typeof(SetDisplayStepValidSuite), "TC-J1-FVT-SetDisplayStep-101-4")]
        public void SetDisplayStep1014(DisplayStepData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //1. Selected Time Range
            var timeRange = input.InputData.ManualTimeRange;
            for (int i = 0; i < timeRange.Length; i++)
            {
                EnergyViewToolbar.SetDateRange(timeRange[i].StartDate, timeRange[i].EndDate);
                TimeManager.ShortPause();

                //Check tag and view data view
                EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
                EnergyViewToolbar.View(EnergyViewType.Column);
                EnergyViewToolbar.ClickViewButton();
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();

                //Default is month
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

                //Click all Optional Steps to change chart view.
                EnergyViewToolbar.View(EnergyViewType.Line);
                EnergyViewToolbar.ClickViewButton();
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();

                Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
                //Default is month 
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

                //click "week"
                EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();
                Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Week));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

                //click "day"
                EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();
                Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

                //click "hour"
                EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();
                Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Hour));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

                //click "raw"
                EnergyAnalysis.ClickDisplayStep(DisplayStep.Min);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();
                Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Min));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

                //back to intinial
                EnergyAnalysis.UncheckTag(input.InputData.TagNames[0]);
                EnergyViewToolbar.ClickViewButton();
                TimeManager.LongPause();
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-SetDisplayStep-101-5")]
        [MultipleTestDataSource(typeof(DisplayStepData[]), typeof(SetDisplayStepValidSuite), "TC-J1-FVT-SetDisplayStep-101-5")]
        public void SetDisplayStep1015(DisplayStepData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //1. Selected Time Range
            var timeRange = input.InputData.ManualTimeRange;
            for (int i = 0; i < timeRange.Length; i++)
            {
                EnergyViewToolbar.SetDateRange(timeRange[i].StartDate, timeRange[i].EndDate);
                TimeManager.ShortPause();

                //Check tag and view data view
                EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
                EnergyViewToolbar.View(EnergyViewType.Column);
                EnergyViewToolbar.ClickViewButton();
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();

                //Default is month
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));//not repro:? There is no raw step in UI, but it can be found raw step in code.

                //Click all Optional Steps to change chart view.
                EnergyViewToolbar.View(EnergyViewType.Line);
                EnergyViewToolbar.ClickViewButton();
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();

                Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
                //Default is month 
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));

                //back to intinial
                EnergyAnalysis.UncheckTag(input.InputData.TagNames[0]);
                EnergyViewToolbar.ClickViewButton();
                TimeManager.LongPause();
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-SetDisplayStep-101-6")]
        [MultipleTestDataSource(typeof(DisplayStepData[]), typeof(SetDisplayStepValidSuite), "TC-J1-FVT-SetDisplayStep-101-6")]
        public void SetDisplayStep1016(DisplayStepData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //1. Selected Time Range
            var timeRange = input.InputData.ManualTimeRange;
            for (int i = 0; i < timeRange.Length; i++)
            {
                EnergyViewToolbar.SetDateRange(timeRange[i].StartDate, timeRange[i].EndDate);
                TimeManager.ShortPause();

                //Check tag and view data view
                EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
                EnergyViewToolbar.View(EnergyViewType.Column);
                EnergyViewToolbar.ClickViewButton();
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();

                //Default is month
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

                //Click all Optional Steps to change chart view.
                EnergyViewToolbar.View(EnergyViewType.Line);
                EnergyViewToolbar.ClickViewButton();
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();

                Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
                //Default is month 
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

                //click "year"
                EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();
                Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Year));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));

                //back to intinial
                EnergyAnalysis.UncheckTag(input.InputData.TagNames[0]);
                EnergyViewToolbar.ClickViewButton();
                TimeManager.LongPause();
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-SetDisplayStep-101-7")]
        [MultipleTestDataSource(typeof(DisplayStepData[]), typeof(SetDisplayStepValidSuite), "TC-J1-FVT-SetDisplayStep-101-7")]
        public void SetDisplayStep1017(DisplayStepData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //1. Selected Time Range
            var timeRange = input.InputData.ManualTimeRange;

            for (int i = 0; i < timeRange.Length; i++)
            {
                EnergyViewToolbar.SetDateRange(timeRange[i].StartDate, timeRange[i].EndDate);
                TimeManager.ShortPause();

                //Check tag and view data view
                EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
                EnergyViewToolbar.View(EnergyViewType.Stack);
                EnergyViewToolbar.ClickViewButton();
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();

                //Default is month
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

                //Click all Optional Steps to change chart view.
                EnergyViewToolbar.View(EnergyViewType.Line);
                EnergyViewToolbar.ClickViewButton();
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();

                Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
                //Default is month 
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

                //click "year"
                EnergyAnalysis.ClickDisplayStep(DisplayStep.Year);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();
                Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

                Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Year));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
                Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Min));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
                Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));

                //back to intinial
                EnergyAnalysis.UncheckTag(input.InputData.TagNames[0]);
                EnergyViewToolbar.ClickViewButton();
                TimeManager.LongPause();
            }

        }
    }
}
