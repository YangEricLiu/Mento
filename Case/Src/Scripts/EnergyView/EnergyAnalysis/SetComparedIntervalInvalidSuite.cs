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
    [ManualCaseID("TC-J1-FVT-MultipleIntervalsComparasion-Set-001"), CreateTime("2013-08-13"), Owner("Emma")]
    public class SetComparedIntervalInvalidSuite : TestSuiteBase
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
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static TimeSpanDialog TimeSpanDialog = JazzFunction.TimeSpanDialog;

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-Set-001-1")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(SetComparedIntervalInvalidSuite), "TC-J1-FVT-MultipleIntervalsComparasion-Set-001-1")]
        public void AddComparedIntervalButtonUnavailable(TimeSpansData input)
        {
            //Select one tag and view data view
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Select one tag (e.g. V1), but then uncheck it.
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();
            Assert.IsFalse(EnergyViewToolbar.IsTimeSpanButtonEnable());

            //Select V1, click 'Add Compared Interval' button, then close it directly.
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.ClickGiveUpButton();
            TimeManager.ShortPause();
            Assert.IsTrue(EnergyViewToolbar.IsTimeSpanButtonEnable());

            //Select multiple tags.
            EnergyAnalysis.CheckTag(input.InputData.TagNames[1]);
            Assert.IsFalse(EnergyViewToolbar.IsTimeSpanButtonEnable());

            //Uncheck the other tags, only one tag is left.
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[1]);
            Assert.IsTrue(EnergyViewToolbar.IsTimeSpanButtonEnable());

            //Keep V1 selected, add V2,  make sure V2's commodity is different with V1. select chart type '饼图'.
            EnergyAnalysis.CheckTag(input.InputData.TagNames[2]);
            EnergyViewToolbar.ClickViewButton();
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains("所选数据点介质不同，无法共同绘制饼状图！"));
            JazzMessageBox.MessageBox.Confirm();
            Assert.IsFalse(EnergyAnalysis.IsTagChecked(input.InputData.TagNames[2]));
            Assert.IsTrue(EnergyViewToolbar.IsTimeSpanButtonEnable());

            //Keep V1 selected, add V_month, time range is 'previous 7 days', click '查询数据'.
            EnergyAnalysis.CheckTag(input.InputData.TagNames[3]);
            EnergyViewToolbar.View(EnergyViewType.Line);
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains("所选数据点不支持\"按小时\",\"按天\",\"按周\"的步长显示，换个步长试试。"));
            JazzMessageBox.MessageBox.Quit();
            Assert.IsFalse(EnergyAnalysis.IsTagChecked(input.InputData.TagNames[3]));
            Assert.IsTrue(EnergyViewToolbar.IsTimeSpanButtonEnable());

            //Switch to 'Multiple Hierarchy Nodes' funtion (多层级数据点)
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.MediumPause();

            //Only select one tag, click 'Confirm' button.


            Assert.IsFalse(EnergyViewToolbar.IsTimeSpanButtonEnable());
            
        }

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-Set-001-2")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(SetComparedIntervalInvalidSuite), "TC-J1-FVT-MultipleIntervalsComparasion-Set-001-2")]
        public void SetCompareIntervalInvalidInput(TimeSpansData input)
        {
            //Select one tag and view data view
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range and pick up one tag, click "+时间段" button
            EnergyViewToolbar.SetDateRange(input.InputData.BaseStartDate[0], input.InputData.BaseEndDate[0]);
            EnergyViewToolbar.SetTimeRange(input.InputData.BaseStartTime[0], input.InputData.BaseEndTime[0]);
            TimeManager.ShortPause();
            
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();

            //Click  'Add Compared Interval' button
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
 
            //Add multiple valid compared intervals successfully.
            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[0], 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[0], 2);
            TimeManager.MediumPause();

            for (int i = 1; i < 4; i++)
            {
                //Click 'Add Compared Interval' link button in the dialog multiple times.
                TimeSpanDialog.ClickAddTimeSpanButton();
                TimeManager.ShortPause();

                TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[i], i + 2);
                TimeManager.ShortPause();
                TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[i], i + 2);
                TimeManager.MediumPause();
            }

            Assert.IsTrue(TimeSpanDialog.IsAddTimeSpanButtonDisabled());
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Click  'Add Compared Interval' button to open the dialog
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            //From the dialog, Click 'x' to delete one compared interval. Click 'Yes'
            TimeSpanDialog.ClickDeleteTimeSpanButton(5);
            TimeManager.ShortPause();
            Assert.AreEqual(1, TimeSpanDialog.GetExcludeIntervals());

            //From the dialog, Click 'x' to delete ALL compared intervals one by one.
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            for (int i = 2; i < 5; i++)
            {
                TimeSpanDialog.ClickDeleteTimeSpanButton(i);
                TimeManager.ShortPause();
            }

            Assert.AreEqual(4, TimeSpanDialog.GetExcludeIntervals());
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsAllEnabledCheckbox());
            //Assert.IsTrue(EnergyViewToolbar.IsTimeSpanMenuItemDisabled("删除全部对比时间段"));

            //Add multiple compared intervals successfully again.
            TimeSpanDialog.ClickAddTimeSpanButton();
            TimeManager.ShortPause();

            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[0], 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[0], 2);
            TimeManager.MediumPause();
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            //Assert.IsFalse(EnergyViewToolbar.IsTimeSpanMenuItemDisabled("删除全部对比时间段"));
            TimeSpanDialog.ClickAddTimeSpanButton();
            TimeManager.ShortPause();

            //Click 'Remove All Compared Intervals' button, then cancel
            EnergyViewToolbar.TimeSpan(TimeSpans.DeleteAllTimeSpans);
            TimeManager.ShortPause();
            Assert.AreEqual(input.ExpectedData.ClearAllMessage, JazzMessageBox.MessageBox.GetMessage());
            JazzMessageBox.MessageBox.GiveUp();

            TimeSpanDialog.ClickAddTimeSpanButton();
            TimeManager.ShortPause();
            Assert.AreEqual(3, TimeSpanDialog.GetExcludeIntervals());

            //Click 'Remove All Compared Intervals' button, then delete
            EnergyViewToolbar.TimeSpan(TimeSpans.DeleteAllTimeSpans);
            TimeManager.ShortPause();
            Assert.AreEqual(input.ExpectedData.ClearAllMessage, JazzMessageBox.MessageBox.GetMessage());
            JazzMessageBox.MessageBox.Delete();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsAllEnabledCheckbox());
            //Assert.IsTrue(EnergyViewToolbar.IsTimeSpanMenuItemDisabled("删除全部对比时间段"));
            TimeSpanDialog.ClickAddTimeSpanButton();
            TimeManager.ShortPause();
            Assert.AreEqual(4, TimeSpanDialog.GetExcludeIntervals());

            //Add multiple compared intervals successfully again.
            TimeSpanDialog.ClickAddTimeSpanButton();
            TimeManager.ShortPause();

            //Add multiple compared intervals successfully again.
            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[0], 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[0], 2);
            TimeManager.MediumPause();
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            //Assert.IsFalse(EnergyViewToolbar.IsMoreMenuItemDisabled("删除所有"));

            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
            TimeManager.ShortPause();
            Assert.AreEqual(input.ExpectedData.DeleteAllMessage, JazzMessageBox.MessageBox.GetMessage());
            JazzMessageBox.MessageBox.GiveUp();
            TimeManager.ShortPause();
            TimeSpanDialog.ClickAddTimeSpanButton();
            TimeManager.ShortPause();
            Assert.AreEqual(3, TimeSpanDialog.GetExcludeIntervals());

            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
            TimeManager.ShortPause();
            Assert.AreEqual(input.ExpectedData.DeleteAllMessage, JazzMessageBox.MessageBox.GetMessage());
            JazzMessageBox.MessageBox.Clear();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(EnergyViewToolbar.IsTimeSpanButtonEnable());
        }
    }
}
