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
    [ManualCaseID("TC-J1-FVT-MultipleIntervalsComparasion-Set-101"), CreateTime("2013-08-13"), Owner("Emma")]
    public class SetComparedIntervalValidSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-Set-101-1")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(SetComparedIntervalValidSuite), "TC-J1-FVT-MultipleIntervalsComparasion-Set-101-1")]
        public void AddAndModifyComparedIntervals(TimeSpansData input)
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

            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            //Add Compared Interval' dialog is displayed with above original time range
            Assert.AreEqual(input.ExpectedData.BaseStartDateValue[0], TimeSpanDialog.GetBaseStartDateValue());
            Assert.AreEqual(input.ExpectedData.BaseEndDateValue[0], TimeSpanDialog.GetBaseEndDateValue());
            Assert.AreEqual(input.ExpectedData.BaseStartTimeValue[0], TimeSpanDialog.GetBaseStartTimeValue());
            Assert.AreEqual(input.ExpectedData.BaseEndTimeValue[0], TimeSpanDialog.GetBaseEndTimeValue());

            //Select Start Date Time  for the compared interval1.
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

            //Modify Start Date Time of original interval on the dialog. 
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.InputBaseStartDate(input.InputData.BaseStartDate[1]);
            TimeManager.ShortPause();
            TimeSpanDialog.InputBaseStartTime(input.InputData.BaseStartTime[1]);
            TimeManager.MediumPause();
            TimeSpanDialog.ClickGiveUpButton();

            //Modify End Date Time of original interval on the dialog. 
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.InputBaseEndDate(input.InputData.BaseEndDate[1]);
            TimeManager.ShortPause();
            TimeSpanDialog.InputBaseEndTime(input.InputData.BaseEndTime[1]);
            TimeManager.MediumPause();

            for (int j = 0; j < 4; j++)
            {
                Assert.AreEqual(input.ExpectedData.EndTimeValue[j], TimeSpanDialog.GetAdditionEndTimeValue(j+2));
            }

            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Modify Start Date Time of one compared interval on the dialog. the last to date from 2000 to 2003
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[4], 4);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[4], 4);
            TimeManager.MediumPause();
            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[4], 5);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[4], 5);
            TimeManager.MediumPause();

            for (int k = 0; k < 2; k++)
            {
                Assert.AreEqual(input.ExpectedData.StartDateValue[k], TimeSpanDialog.GetAdditionStartDateValue(k + 2));
                Assert.AreEqual(input.ExpectedData.StartTimeValue[k], TimeSpanDialog.GetAdditionStartTimeValue(k + 2));
                Assert.AreEqual(input.ExpectedData.EndTimeValue[k], TimeSpanDialog.GetAdditionEndTimeValue(k + 2));
            }

            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsNoEnabledCheckbox());

            //Make sure the date time range of original interval was selected from Relative Time selector. E.g. ‘Last Year’
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.MediumPause();

            Assert.AreEqual(input.ExpectedData.BaseStartDateValue[1], TimeSpanDialog.GetBaseStartDateValue());
            Assert.AreEqual(input.ExpectedData.BaseEndDateValue[1], TimeSpanDialog.GetBaseEndDateValue());
            Assert.AreEqual(input.ExpectedData.BaseStartTimeValue[1], TimeSpanDialog.GetBaseStartTimeValue());
            Assert.AreEqual(input.ExpectedData.BaseEndTimeValue[1], TimeSpanDialog.GetBaseEndTimeValue());

            for (int k = 0; k < 4; k++)
            {
                Assert.AreEqual(input.ExpectedData.StartDateValue[k+2], TimeSpanDialog.GetAdditionStartDateValue(k + 2));
                Assert.AreEqual(input.ExpectedData.StartTimeValue[k+2], TimeSpanDialog.GetAdditionStartTimeValue(k + 2));
                Assert.AreEqual(input.ExpectedData.EndTimeValue[k+4], TimeSpanDialog.GetAdditionEndTimeValue(k + 2));
            }

            TimeSpanDialog.ClickGiveUpButton();
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-Set-101-2")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(SetComparedIntervalValidSuite), "TC-J1-FVT-MultipleIntervalsComparasion-Set-101-2")]
        public void SetValidComparedIntervals(TimeSpansData input)
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
            Assert.IsTrue(EnergyViewToolbar.IsTimeSpanMenuItemDisabled("删除全部对比时间段"));

            //Add multiple compared intervals successfully again.
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.MediumPause();
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[0], 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[0], 2);
            TimeManager.MediumPause();
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Click 'Remove All Compared Intervals' button, then cancel
            EnergyViewToolbar.TimeSpan(TimeSpans.DeleteAllTimeSpans);
            TimeManager.ShortPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.ClearAllMessage));
            JazzMessageBox.MessageBox.GiveUp();
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.MediumPause();
            Assert.AreEqual(3, TimeSpanDialog.GetExcludeIntervals());
            TimeSpanDialog.ClickGiveUpButton();

            //Click 'Remove All Compared Intervals' button, then delete
            EnergyViewToolbar.TimeSpan(TimeSpans.DeleteAllTimeSpans);
            TimeManager.ShortPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.ClearAllMessage));
            JazzMessageBox.MessageBox.Delete();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsAllEnabledCheckbox());
            Assert.IsTrue(EnergyViewToolbar.IsTimeSpanMenuItemDisabled("删除全部对比时间段"));
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.MediumPause();
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            Assert.AreEqual(3, TimeSpanDialog.GetExcludeIntervals());

            //Add multiple compared intervals successfully again.
            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[0], 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[0], 2);
            TimeManager.MediumPause();
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(EnergyViewToolbar.IsMoreMenuItemDisabled("删除所有"));
            EnergyViewToolbar.OpenMoreButton();
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
            TimeManager.ShortPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.DeleteAllMessage));
            JazzMessageBox.MessageBox.GiveUp();
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            Assert.AreEqual(3, TimeSpanDialog.GetExcludeIntervals());
            TimeSpanDialog.ClickGiveUpButton();
            TimeManager.ShortPause();

            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
            TimeManager.ShortPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.DeleteAllMessage));
            JazzMessageBox.MessageBox.Clear();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(EnergyViewToolbar.IsTimeSpanButtonEnable());
        }
    }
}
