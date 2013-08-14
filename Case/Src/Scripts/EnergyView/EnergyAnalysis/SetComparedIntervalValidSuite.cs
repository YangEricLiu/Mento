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
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-Set-101-1")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(SetComparedIntervalValidSuite), "TC-J1-FVT-MultipleIntervalsComparasion-Set-101-1")]
        public void AddAndModifyComparedIntervals(TimeSpansData input)
        {
            //Select one tag and view data view
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            
            //Set date range
            EnergyViewToolbar.SetDateRange(input.InputData.BaseStartDate[0], input.InputData.BaseEndDate[0]);
            EnergyViewToolbar.SetTimeRange(input.InputData.BaseStartTime[0], input.InputData.BaseEndTime[0]);
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

            //Change the Start Time in first date range
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.InputBaseStartDate(input.InputData.BaseStartDate[0]);
            TimeSpanDialog.InputBaseStartTime(input.InputData.BaseStartTime[0]);

            //Change the End Time in first date range, 
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.InputBaseEndDate(input.InputData.BaseEndDate[0]);
            TimeSpanDialog.InputBaseEndTime(input.InputData.BaseEndTime[0]);

            Assert.IsTrue(TimeSpanDialog.GetAdditionEndTimeValue(2).Contains(input.ExpectedData.EndTimeValue[1]));
            TimeSpanDialog.ClickConfirmButton();

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

        }
    }
}
