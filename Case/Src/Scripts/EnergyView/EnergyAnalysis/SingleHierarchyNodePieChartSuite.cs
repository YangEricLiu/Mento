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

namespace Mento.Script.EnergyView.EnergyAnalysis 
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-SingleHierarchyNode-PieChart-101"), CreateTime("2014-05-29"), Owner("Emma")]
    public class SingleHierarchyNodePieChartSuite : TestSuiteBase
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
            JazzFunction.Navigator.NavigateHome();
        }

        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [Test]
        [CaseID("TC-J1-FVT-SingleHierarchyNode-PieChart-101-2")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyNodePieChartSuite), "TC-J1-FVT-SingleHierarchyNode-PieChart-101-2")]
        public void SingleHierarchyNodePieChart30tags(EnergyViewOptionData input)
        {
            //Select Totally 30 tags from BuildingPieVerify. (Not BuildingBC) node. 
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyAnalysis.SwitchTagTab(TagTabs.HierarchyTag);
            TimeManager.MediumPause();

            EnergyAnalysis.CheckTags(input.InputData.TagNames);
            Assert.IsTrue(EnergyAnalysis.IsNoEnabledCheckbox());

            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            // The distribution chart is generated by totally 30 tags.
            Assert.IsTrue(EnergyAnalysis.IsDistributionChartDrawn());

            EnergyAnalysis.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDictionaryDataOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);       
        }

        [Test]
        [CaseID("TC-J1-FVT-SingleHierarchyNode-PieChart-101-3")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyNodePieChartSuite), "TC-J1-FVT-SingleHierarchyNode-PieChart-101-3")]
        public void SingleHierarchyNodePieChart_5640(EnergyViewOptionData input)
        {
            //Go to NancyCustomer1-楼宇BC, go to energy usage, select a tag (e.g. V6_BuildingBC), 
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.LongPause();

            //select a time range, make sure the end date is today (e.g. Last 7 days)
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            // The distribution chart is generated by totally 30 tags.
            Assert.IsTrue(EnergyAnalysis.IsDistributionChartDrawn());
            var ManualTimeRange = input.InputData.ManualTimeRange;

            EnergyAnalysis.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDictionaryDataOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);       
        }
    }
}
