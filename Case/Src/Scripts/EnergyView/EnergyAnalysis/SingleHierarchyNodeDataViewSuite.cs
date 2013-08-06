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
    [ManualCaseID("TC-J1-FVT-SingleHierarchyNode-DataView-101"), CreateTime("2013-08-06"), Owner("Emma")]
    public class SingleHierarchyNodeDataViewSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
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



        [Test]
        [CaseID("TC-J1-FVT-SingleHierarchyNode-DataView-101-1")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyNodeDataViewSuite), "TC-J1-FVT-SingleHierarchyNode-DataView-101-1")]
        public void ViewDataViewOfTagThenClear(EnergyViewOptionData input)
        {
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
            //EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);

            //Verify tag value
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Uncheck v1, and select another tag under area dimension
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[0]);
            EnergyAnalysis.SwitchTagTab(TagTabs.AreaDimensionTab);
            EnergyAnalysis.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.CheckTag(input.InputData.TagNames[1]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());
            //EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Uncheck v2, and select another tag under system dimension
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[1]);
            EnergyAnalysis.SwitchTagTab(TagTabs.SystemDimensionTab);
            EnergyAnalysis.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.CheckTag(input.InputData.TagNames[2]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Uncheck v3, and clear all data
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[2]);
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
        }

    }
}
