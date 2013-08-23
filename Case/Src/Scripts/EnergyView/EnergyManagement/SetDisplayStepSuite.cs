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

        [Test]
        [CaseID("TC-J1-FVT-SetDisplayStep-001-1")]
        [MultipleTestDataSource(typeof(DisplayStepData[]), typeof(SetDisplayStepSuite), "TC-J1-FVT-SetDisplayStep-001-1")]
        public void EnergyAnalysisSetDisplayStep(DisplayStepData input)
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
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            TimeManager.LongPause();
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains("所选数据点不支持\"按小时\"的步长显示，换个步长试试。"));
            Assert.IsTrue(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Hour));
            EnergyAnalysis.ClickStepButtonOnWindow(DisplayStep.Day);
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));

            //Set date range "2012/07/01-2012/07/31", only check VD with line chart and data view
            EnergyViewToolbar.SetDateRange(timeRange[1].StartDate, timeRange[1].EndDate);
            TimeManager.ShortPause();
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[2]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));

            //Covnert to data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
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
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Week));

            //Select Start Time or End Time which cannot be covered with whole step. 
            //Set date range "2012/07/01 3:30-2012/07/03 23:30", only check VD with data view
            EnergyViewToolbar.SetDateRange(timeRange[2].StartDate, timeRange[2].EndDate);
            EnergyViewToolbar.SetTimeRange(timeRange[2].StartTime, timeRange[2].EndTime);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            ////Set date range "2012/07/15-2012/12/15", only check VM with data view
            EnergyViewToolbar.SetDateRange(timeRange[3].StartDate, timeRange[3].EndDate);
            TimeManager.ShortPause();

            EnergyAnalysis.UncheckTag(input.InputData.TagNames[1]);
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
        }


    }
}
