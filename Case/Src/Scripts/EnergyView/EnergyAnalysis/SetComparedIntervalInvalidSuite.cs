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
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;

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
            EnergyViewToolbar.View(EnergyViewType.Line);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
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
            //Assert.IsTrue(EnergyViewToolbar.IsTimeSpanButtonEnable());

            //Keep V1 selected, add V_month, time range is 'previous 7 days', click '查询数据'.
            /*
            EnergyAnalysis.CheckTag(input.InputData.TagNames[3]);
            EnergyViewToolbar.View(EnergyViewType.Line);
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains("所选数据点不支持\"按小时\",\"按天\",\"按周\"的步长显示，换个步长试试。"));
            JazzMessageBox.MessageBox.Quit();
            Assert.IsFalse(EnergyAnalysis.IsTagChecked(input.InputData.TagNames[3]));
            Assert.IsTrue(EnergyViewToolbar.IsTimeSpanButtonEnable());
            */

            //Switch to 'Multiple Hierarchy Nodes' funtion (多层级数据点)
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.MediumPause();

            //Only select one tag, click 'Confirm' button.
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.Hierarchies);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();
            Assert.IsFalse(EnergyViewToolbar.IsTimeSpanButtonEnable());
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.SingleHierarchyTag);
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.ErrorMessage[0]));
            JazzMessageBox.MessageBox.Quit();
            TimeManager.MediumPause();

            //Select multiple tags, click 'Confirm' button.
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.MediumPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.Hierarchies);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[0]);
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[1]);
            TimeManager.ShortPause();
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();
            Assert.IsFalse(EnergyViewToolbar.IsTimeSpanButtonEnable());

            //Remove other tags, only one tag is left, click 'Confirm' button.
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.LongPause();
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.Hierarchies);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            MultiHieCompareWindow.UncheckTag(input.InputData.TagNames[1]);
            TimeManager.ShortPause();
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();
            Assert.IsFalse(EnergyViewToolbar.IsTimeSpanButtonEnable());
        }

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-Set-001-2")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(SetComparedIntervalInvalidSuite), "TC-J1-FVT-MultipleIntervalsComparasion-Set-001-2")]
        public void SetCompareIntervalInvalidInput(TimeSpansData input)
        {
            //Open 'Single Hierarchy Node' function (单层级数据点), 
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            
            //Only one tag is selected, and time range of first span is valid, Click  'Add Compared Interval' button
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();

            //Click  'Add Compared Interval' button
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            //One compared interval is empty, click 'Yes'
            TimeSpanDialog.ClickConfirmButton();
            Assert.IsTrue(TimeSpanDialog.GetAdditionStartDateInvalidMsg(2).Contains(input.ExpectedData.StartDateValue[0]));

            //Set Start time of compared interval to be Today, so that its End time will become future time, click 'Yes'
            DateTime today = new DateTime();
            today = DateTime.Now;
            TimeSpanDialog.InputAdditionStartDate(today, 2);
            TimeManager.ShortPause();
            TimeSpanDialog.ClickConfirmButton();
            TimeManager.ShortPause();
            Assert.IsTrue(TimeSpanDialog.GetAdditionStartDateInvalidMsg(2).Contains(input.ExpectedData.StartDateValue[1]));

            //the Start time of first interval so that start time of compared interval becomes earlier than 2000-01-01, click 'Yes'
            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[0], 2);
            TimeManager.MediumPause();
            TimeSpanDialog.InputBaseStartDate(input.InputData.BaseStartDate[0]);
            TimeManager.ShortPause();
            TimeSpanDialog.ClickConfirmButton();
            Assert.IsTrue(TimeSpanDialog.GetAdditionStartDateInvalidMsg(2).Contains(input.ExpectedData.StartDateValue[2]));
            //Click 'Cancel' after above message occurs.
            TimeSpanDialog.ClickGiveUpButton();
            TimeManager.ShortPause();
        }
    }
}