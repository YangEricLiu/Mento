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
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-Set-101")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(SetComparedIntervalValidSuite), "TC-J1-FVT-MultipleIntervalsComparasion-Set-101")]
        public void AddAbsoluteComparedIntervalsWhenOriginalIsAbsolute(TimeSpansData input)
        {
            //Select one tag and view data view
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();

            //Get default original time from energy view toolbar
            string startDate = EnergyViewToolbar.GetStartDate();
            string startTime = EnergyViewToolbar.GetStartTime();
            string endDate = EnergyViewToolbar.GetEndDate();
            string endTime = EnergyViewToolbar.GetEndTime();

            //Click  'Add Compared Interval' button
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            //Check 'Add Compared Interval' dialog is displayed with above original time range
            Assert.AreEqual(startDate, TimeSpanDialog.GetBaseStartDateValue());
            Assert.AreEqual(startTime, TimeSpanDialog.GetBaseStartTimeValue());
            Assert.AreEqual(endDate, TimeSpanDialog.GetBaseEndDateValue());
            Assert.AreEqual(endTime, TimeSpanDialog.GetBaseEndTimeValue());

            //Check The original time type is relative
            Assert.AreEqual(OriginalTimeType.Last7days, TimeSpanDialog.GetOriginalTimeType());

            //Check The default compared interval time type is relative
            Assert.AreEqual(CompareTimeType.Relative, TimeSpanDialog.GetCompareTimeType(2));

            //Change original time type form dropdown list to absolute time
            TimeSpanDialog.SelectCompareTimeType(CompareTimeType.UserDefined, 1);
            TimeManager.ShortPause();

            //Check Original time range pick up window becomes editable.
            //And set Original time range to 2013/01/01 02:00 to 2013/02/13 12:00 
            TimeSpanDialog.InputBaseStartDate(input.InputData.BaseStartDate[0]);
            TimeManager.ShortPause();
            TimeSpanDialog.InputBaseStartTime(input.InputData.BaseStartTime[0]);
            TimeManager.ShortPause();
            TimeSpanDialog.InputBaseEndDate(input.InputData.BaseEndDate[0]);
            TimeManager.ShortPause();
            TimeSpanDialog.InputBaseEndTime(input.InputData.BaseEndTime[0]);
            TimeManager.LongPause();

            //Check the compared interval is clearly and time type is changed to absolute and grey out.
            Assert.AreEqual(CompareTimeType.UserDefined, TimeSpanDialog.GetCompareTimeType(2));

            //Check Original time range is set without error
            Assert.AreEqual(input.ExpectedData.BaseStartDateValue[0], TimeSpanDialog.GetBaseStartDateValue());
            Assert.AreEqual(input.ExpectedData.BaseEndDateValue[0], TimeSpanDialog.GetBaseEndDateValue());
            Assert.AreEqual(input.ExpectedData.BaseStartTimeValue[0], TimeSpanDialog.GetBaseStartTimeValue());
            Assert.AreEqual(input.ExpectedData.BaseEndTimeValue[0], TimeSpanDialog.GetBaseEndTimeValue());

            // Click 'Confirm and draw'
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            // Chart draw out without error.
            //Time range in time picker is correct 2013/01/01 02:00 to 2013/02/13 12:00 
            Assert.AreEqual(input.ExpectedData.BaseStartDateValue[0], EnergyViewToolbar.GetStartDate());
            Assert.AreEqual(input.ExpectedData.BaseEndDateValue[0], EnergyViewToolbar.GetEndDate());
            Assert.AreEqual(input.ExpectedData.BaseStartTimeValue[0], EnergyViewToolbar.GetStartTime());
            Assert.AreEqual(input.ExpectedData.BaseEndTimeValue[0], EnergyViewToolbar.GetEndTime());

            //Click  'Add Compared Interval' button
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            //Check 'Add Compared Interval' dialog is displayed with above original time range ('2013/01/01 02:00 to 2012/02/13 12:00').
            Assert.AreEqual(input.ExpectedData.BaseStartDateValue[0], TimeSpanDialog.GetBaseStartDateValue());
            Assert.AreEqual(input.ExpectedData.BaseEndDateValue[0], TimeSpanDialog.GetBaseEndDateValue());
            Assert.AreEqual(input.ExpectedData.BaseStartTimeValue[0], TimeSpanDialog.GetBaseStartTimeValue());
            Assert.AreEqual(input.ExpectedData.BaseEndTimeValue[0], TimeSpanDialog.GetBaseEndTimeValue());

            //Check The compared interval time type is changed to absolute and grey out
            Assert.AreEqual(CompareTimeType.UserDefined, TimeSpanDialog.GetCompareTimeType(2));

            //Select Start Date Time  for the compared interval1.
            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[0], 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[0], 2);
            TimeManager.MediumPause();

            //Select Start Date Time  for all the compared intervals.
            for (int i = 1; i <= 3; i++)
            {
                //Click 'Add Compared Interval' link button in the dialog multiple times.
                TimeSpanDialog.ClickAddTimeSpanButton();
                TimeManager.ShortPause();

                TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[i], i + 2);
                TimeManager.ShortPause();
                TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[i], i + 2);
                TimeManager.MediumPause();
            }

            Assert.IsTrue(TimeSpanDialog.IsAddTimeSpanButtonDisabled());

            //Click 'Yes & Draw' button
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check The 'Add Compared Interval' dialog is closed.
            //In tag picker panel, checkbox of other unselected tags((including switch to second page of the tags list, or switch to 系统/区域维度 tab, or switch to other hierarchy) are all disabled.
            Assert.IsFalse(EnergyAnalysis.IsAllEnabledCheckbox());

            //The chart is redrawn with above intervals correctly.
            string[] legendsAc = EnergyAnalysis.GetLegendItemTexts();
            string[] legendsEx = { "", "", "", "", "" };
            legendsEx[0] = input.InputData.BaseStartDate[0] + " " + input.InputData.BaseStartTime[0] + input.InputData.BaseEndDate[0] + " " + input.InputData.BaseEndTime[0];
            legendsEx[1] = input.InputData.StartDate[0] + " " + input.InputData.StartTime[0] + input.ExpectedData.EndDateValue[0] + " " + input.ExpectedData.EndTimeValue[0];
            legendsEx[2] = input.InputData.StartDate[1] + " " + input.InputData.StartTime[1] + input.ExpectedData.EndDateValue[1] + " " + input.ExpectedData.EndTimeValue[1];
            legendsEx[3] = input.InputData.StartDate[2] + " " + input.InputData.StartTime[2] + input.ExpectedData.EndDateValue[2] + " " + input.ExpectedData.EndTimeValue[2];
            legendsEx[4] = input.InputData.StartDate[3] + " " + input.InputData.StartTime[3] + input.ExpectedData.EndDateValue[3] + " " + input.ExpectedData.EndTimeValue[3];
            Assert.AreEqual(legendsAc, legendsEx);

            //The intervals set above are stored and displayed in the dialog when open next time. 
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            for (int i = 0; i < 4; i++ )
            {
                Assert.AreEqual(input.InputData.StartDate[i], TimeSpanDialog.GetAdditionStartDateValue(i + 2));
                Assert.AreEqual(input.InputData.StartTime[i], TimeSpanDialog.GetAdditionStartTimeValue(i + 2));
                Assert.AreEqual(input.ExpectedData.EndDateValue[i], TimeSpanDialog.GetAdditionEndDateValue(i + 2));
                Assert.AreEqual(input.ExpectedData.EndTimeValue[i], TimeSpanDialog.GetAdditionEndTimeValue(i + 2));
            }
            TimeSpanDialog.ClickGiveUpButton();

            //Change chart to pie chart
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.Distribute);
            TimeManager.FlashPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check The distribution chart is redrawn with above intervals correctly, even though some interval with no data.
            Assert.IsTrue(EnergyAnalysis.IsDistributionChartDrawn());
            EnergyAnalysis.ExportMulTimePieDictionaryToExcel(input.InputData.Hierarchies, input.InputData.ManualTimeRange[0], input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDictionaryDataOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
        }

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-Set-102")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(SetComparedIntervalValidSuite), "TC-J1-FVT-MultipleIntervalsComparasion-Set-102")]
        public void AddAbsoluteComparedIntervalsWhenOriginalIsRelative(TimeSpansData input)
        {
            //Select one tag and view data view
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();

            //Change original time range to 上月 from more list
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);
            TimeManager.MediumPause();

            //Get default original time from energy view toolbar
            string startDate = EnergyViewToolbar.GetStartDate();
            string startTime = EnergyViewToolbar.GetStartTime();
            string endDate = EnergyViewToolbar.GetEndDate();
            string endTime = EnergyViewToolbar.GetEndTime();

            //Click  'Add Compared Interval' button
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            //Check 'Add Compared Interval' dialog is displayed with above original time range
            Assert.AreEqual(startDate, TimeSpanDialog.GetBaseStartDateValue());
            Assert.AreEqual(startTime, TimeSpanDialog.GetBaseStartTimeValue());
            Assert.AreEqual(endDate, TimeSpanDialog.GetBaseEndDateValue());
            Assert.AreEqual(endTime, TimeSpanDialog.GetBaseEndTimeValue());

            //Check The default Original time type is relative
            Assert.AreEqual(OriginalTimeType.Lastmonth, TimeSpanDialog.GetOriginalTimeType());
            //Check The default compared interval time type is relative
            Assert.AreEqual(CompareTimeType.Relative, TimeSpanDialog.GetCompareTimeType(2));

            //Change compared time type to absolute time
            TimeSpanDialog.SelectCompareTimeType(CompareTimeType.UserDefined, 2);
            TimeManager.ShortPause();

            // Empty compared interval is displayed with blank Start Date Time and End Date Time.
            Assert.AreEqual("", TimeSpanDialog.GetAdditionStartDateValue(2));
            Assert.AreEqual("00:00", TimeSpanDialog.GetAdditionStartTimeValue(2));
            Assert.AreEqual("", TimeSpanDialog.GetAdditionEndDateValue(2));
            Assert.AreEqual("24:00", TimeSpanDialog.GetAdditionEndTimeValue(2));

            //Set Start time of the first compared interval, e.g. '2014-02-13 2:00'
            TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[0], 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[0], 2);
            TimeManager.ShortPause();
            
            //Check the end time are set automatically and keep the same time range with original time, but editable.(e.g, last month is June, then end time should be '2014-03-14 2:00')
            Assert.AreEqual(input.ExpectedData.EndDateValue[0], TimeSpanDialog.GetAdditionEndDateValue(2));
            Assert.AreEqual(input.ExpectedData.EndTimeValue[0], TimeSpanDialog.GetAdditionEndTimeValue(2));

            //Edit the end time to 2014-04-14 2:00
            TimeSpanDialog.InputAdditionEndDate(input.InputData.EndDate[0], 2);
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionEndTime(input.InputData.EndTime[0], 2);
            TimeManager.ShortPause();

            //Click 'Yes & Draw' button
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //The chart is redrawn with above intervals correctly.
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
            TimeManager.ShortPause();

            //Check •  In tag picker panel, checkbox of other unselected tags((including switch to second page of the tags list, or switch to 系统/区域维度 tab, or switch to other hierarchy) are all disabled.
            Assert.IsFalse(EnergyAnalysis.IsAllEnabledCheckbox());

            //Check 61 days data value are display out for both original and compared time interval.
            EnergyAnalysis.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, input.InputData.ManualTimeRange[0], input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDictionaryDataOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //The intervals set above are stored and displayed in the dialog when open next time. 
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            Assert.AreEqual(input.ExpectedData.StartDateValue[1], TimeSpanDialog.GetAdditionStartDateValue(2));
            Assert.AreEqual(input.ExpectedData.StartTimeValue[1], TimeSpanDialog.GetAdditionStartTimeValue(2));
            Assert.AreEqual(input.ExpectedData.EndDateValue[1], TimeSpanDialog.GetAdditionEndDateValue(2));
            Assert.AreEqual(input.ExpectedData.EndTimeValue[1], TimeSpanDialog.GetAdditionEndTimeValue(2));

            //Click 'Add Compared Interval' link button in the dialog multiple times.
            TimeSpanDialog.ClickAddTimeSpanButton();
            TimeManager.ShortPause();

            //Compared time interval are set for relative time.
            Assert.AreEqual(CompareTimeType.Relative, TimeSpanDialog.GetCompareTimeType(3));

            //Set all other 2 compared interval to 之前第xx月
            TimeSpanDialog.InputAdditionRelativeValue("5", 3);
            TimeManager.ShortPause();
            TimeSpanDialog.ClickAddTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionRelativeValue("10", 4);
            TimeManager.ShortPause();

            //Click 'Yes & Draw' button
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check •  In tag picker panel, checkbox of other unselected tags((including switch to second page of the tags list, or switch to 系统/区域维度 tab, or switch to other hierarchy) are all disabled.
            Assert.IsFalse(EnergyAnalysis.IsAllEnabledCheckbox());

            //The chart is redrawn with above intervals correctly.
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

            //The intervals set above are stored and displayed in the dialog when open next time. 
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            Assert.AreEqual(input.ExpectedData.StartDateValue[1], TimeSpanDialog.GetAdditionStartDateValue(2));
            Assert.AreEqual(input.ExpectedData.StartTimeValue[1], TimeSpanDialog.GetAdditionStartTimeValue(2));
            Assert.AreEqual(input.ExpectedData.EndDateValue[1], TimeSpanDialog.GetAdditionEndDateValue(2));
            Assert.AreEqual(input.ExpectedData.EndTimeValue[1], TimeSpanDialog.GetAdditionEndTimeValue(2));
            Assert.AreEqual(CompareTimeType.Relative, TimeSpanDialog.GetCompareTimeType(3));
            Assert.AreEqual("5", TimeSpanDialog.GetAdditionRelativeValue(3));
            Assert.AreEqual(CompareTimeType.Relative, TimeSpanDialog.GetCompareTimeType(4));
            Assert.AreEqual("10", TimeSpanDialog.GetAdditionRelativeValue(4));

            //Change step to Day(Raw)
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Raw);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Chart display out correctly.
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

        }

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-Set-103")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(SetComparedIntervalValidSuite), "TC-J1-FVT-MultipleIntervalsComparasion-Set-103")]
        public void AddRelativeComparedIntervalsWhenOriginalIsRelative(TimeSpansData input)
        {
            //Select one tag and view data view
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Open 'Single Hierarchy Node' function (单层级数据点), 
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();

            //Get default original time from energy view toolbar
            string startDate = EnergyViewToolbar.GetStartDate();
            string startTime = EnergyViewToolbar.GetStartTime();
            string endDate = EnergyViewToolbar.GetEndDate();
            string endTime = EnergyViewToolbar.GetEndTime();

            //Click  'Add Compared Interval' button
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            //Check 'Add Compared Interval' dialog is displayed with above original time range
            Assert.AreEqual(startDate, TimeSpanDialog.GetBaseStartDateValue());
            Assert.AreEqual(startTime, TimeSpanDialog.GetBaseStartTimeValue());
            Assert.AreEqual(endDate, TimeSpanDialog.GetBaseEndDateValue());
            Assert.AreEqual(endTime, TimeSpanDialog.GetBaseEndTimeValue());

            //Check the default Original time type is relative
            Assert.AreEqual(OriginalTimeType.Last7days, TimeSpanDialog.GetOriginalTimeType());

            //Check the default compared interval time type is relative
            Assert.AreEqual(CompareTimeType.Relative, TimeSpanDialog.GetCompareTimeType(2));

            //Open dropdown list of 第xx天 And check Option list is 1-10.
            Assert.AreEqual(input.InputData.RelativeIntervalsItems[0],TimeSpanDialog.GetRelativeIntervalsMenuItemsList(2));
                 
            //select 2
            TimeSpanDialog.InputAdditionRelativeValue("2", 2);
            TimeManager.ShortPause();

            //+get the text string in dialog
            string ActText = TimeSpanDialog.GetComparedIntervalsText(2);

            //+Calculate the first compared interval(start date and end date)
            DateTime StartCompareInterval = DateTime.Now.AddDays(-20);//含当日，故-20而不是-21
            DateTime EndCompareInterval = DateTime.Now.AddDays(-14);
            
            //+Format in Zh version："xxxx年xx月xx日 到 xxxx年xx月xx日"
            string ExpTextZh = StartCompareInterval.ToString("yyyy年MM月dd日") + " 到 " + EndCompareInterval.ToString("yyyy年MM月dd日");
            //+Format in En version: 10/29, 2014 To 11/04, 2014
            string ExpTextEn = StartCompareInterval.ToString("MM/dd, yyyy") + " To " + EndCompareInterval.ToString("MM/dd, yyyy");
            
            //Check Text displayed beside 之前第2个7天
            if ((ActText == ExpTextZh) || (ActText == ExpTextEn))
                Assert.Pass();
            else
                Assert.Fail();

            //Click 'Yes & Draw' button
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //The 'Add Compared Interval' dialog is closed.
            //In tag picker panel, checkbox of other unselected tags((including switch to second page of the tags list, or switch to 系统/区域维度 tab, or switch to other hierarchy) are all disabled.
            Assert.IsFalse(EnergyAnalysis.IsAllEnabledCheckbox());
            TimeManager.ShortPause();

            //Check Chart display out correctly.
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
            TimeManager.ShortPause();

            //Click  'Add Compared Interval' button again
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            //Check The original time interval and compared time interval keep the same with above.
            Assert.AreEqual(startDate, TimeSpanDialog.GetBaseStartDateValue());
            Assert.AreEqual(startTime, TimeSpanDialog.GetBaseStartTimeValue());
            Assert.AreEqual(endDate, TimeSpanDialog.GetBaseEndDateValue());
            Assert.AreEqual(endTime, TimeSpanDialog.GetBaseEndTimeValue());
            Assert.AreEqual("2", TimeSpanDialog.GetAdditionRelativeValue(2));

            //Check User can add 3 more relative time compared interval. 
            //Multiple new compared intervals are displayed with relative compared interval
            Assert.AreEqual(CompareTimeType.Relative, TimeSpanDialog.GetCompareTimeType(2));

            for (int i = 1; i <= 3; i++)
            {
                TimeSpanDialog.ClickAddTimeSpanButton();
                TimeManager.ShortPause();
                Assert.AreEqual(CompareTimeType.Relative, TimeSpanDialog.GetCompareTimeType(i + 2));
                TimeSpanDialog.InputAdditionRelativeValue((i * 2 + 1).ToString(), i + 2);
                TimeManager.ShortPause();
            }

            //Click 'Yes & Draw' button
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check •  The 'Add Compared Interval' dialog is closed.
            //•  In tag picker panel, checkbox of other unselected tags((including switch to second page of the tags list, or switch to 系统/区域维度 tab, or switch to other hierarchy) are all disabled.
            Assert.IsFalse(EnergyAnalysis.IsAllEnabledCheckbox());
            TimeManager.ShortPause();
            
            //Chart display out correctly.
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

            //Check The intervals set above are stored and displayed in the dialog when open next time. 
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            Assert.AreEqual(startDate, TimeSpanDialog.GetBaseStartDateValue());
            Assert.AreEqual(startTime, TimeSpanDialog.GetBaseStartTimeValue());
            Assert.AreEqual(endDate, TimeSpanDialog.GetBaseEndDateValue());
            Assert.AreEqual(endTime, TimeSpanDialog.GetBaseEndTimeValue());
            Assert.AreEqual("2", TimeSpanDialog.GetAdditionRelativeValue(2));
            Assert.AreEqual("3", TimeSpanDialog.GetAdditionRelativeValue(3));
            Assert.AreEqual("5", TimeSpanDialog.GetAdditionRelativeValue(4));
            Assert.AreEqual("7", TimeSpanDialog.GetAdditionRelativeValue(5));

            //Verify all the relative time interval for original time: 今天/昨天,本周/上周,本月/上月,今年/去年,之前30天，之前12月
            //Check The compared interval selection and text
            //今天/昨天 1-31
            TimeSpanDialog.SelectOriginalTimeType(OriginalTimeType.Today);
            Assert.AreEqual(input.InputData.RelativeIntervalsItems[1], TimeSpanDialog.GetRelativeIntervalsMenuItemsList(2));
            TimeSpanDialog.SelectOriginalTimeType(OriginalTimeType.Yesterday);
            Assert.AreEqual(input.InputData.RelativeIntervalsItems[1], TimeSpanDialog.GetRelativeIntervalsMenuItemsList(2));

            //本周/上周 1-10
            TimeSpanDialog.SelectOriginalTimeType(OriginalTimeType.Thisweek);
            Assert.AreEqual(input.InputData.RelativeIntervalsItems[0], TimeSpanDialog.GetRelativeIntervalsMenuItemsList(2));
            TimeSpanDialog.SelectOriginalTimeType(OriginalTimeType.Lastweek);
            Assert.AreEqual(input.InputData.RelativeIntervalsItems[0], TimeSpanDialog.GetRelativeIntervalsMenuItemsList(2));

            //本月/上月 1-24
            TimeSpanDialog.SelectOriginalTimeType(OriginalTimeType.Lastmonth);
            Assert.AreEqual(input.InputData.RelativeIntervalsItems[2], TimeSpanDialog.GetRelativeIntervalsMenuItemsList(2));
            TimeSpanDialog.SelectOriginalTimeType(OriginalTimeType.Thismonth);
            Assert.AreEqual(input.InputData.RelativeIntervalsItems[2], TimeSpanDialog.GetRelativeIntervalsMenuItemsList(2));

            //今年/去年 1-10
            TimeSpanDialog.SelectOriginalTimeType(OriginalTimeType.Thisyear);
            Assert.AreEqual(input.InputData.RelativeIntervalsItems[0], TimeSpanDialog.GetRelativeIntervalsMenuItemsList(2));
            TimeSpanDialog.SelectOriginalTimeType(OriginalTimeType.Lastyear);
            Assert.AreEqual(input.InputData.RelativeIntervalsItems[0], TimeSpanDialog.GetRelativeIntervalsMenuItemsList(2));

            //之前30天 1-24
            TimeSpanDialog.SelectOriginalTimeType(OriginalTimeType.Last30days);
            Assert.AreEqual(input.InputData.RelativeIntervalsItems[2], TimeSpanDialog.GetRelativeIntervalsMenuItemsList(2));

            //之前12月 1-10
            TimeSpanDialog.SelectOriginalTimeType(OriginalTimeType.Last12months);
            Assert.AreEqual(input.InputData.RelativeIntervalsItems[0], TimeSpanDialog.GetRelativeIntervalsMenuItemsList(2));
        }

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-Set-104")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(SetComparedIntervalValidSuite), "TC-J1-FVT-MultipleIntervalsComparasion-Set-104")]
        public void ModifyOriginalThenComparedIntervalsWillBeCleared(TimeSpansData input)
        {
            //Select one tag and view data view
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Open 'Single Hierarchy Node' function (单层级数据点), 
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();

            //Get default original time from energy view toolbar
            string startDate = EnergyViewToolbar.GetStartDate();
            string startTime = EnergyViewToolbar.GetStartTime();
            string endDate = EnergyViewToolbar.GetEndDate();
            string endTime = EnergyViewToolbar.GetEndTime();

            //Click  'Add Compared Interval' button
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            //Check 'Add Compared Interval' dialog is displayed with above original time range
            Assert.AreEqual(startDate, TimeSpanDialog.GetBaseStartDateValue());
            Assert.AreEqual(startTime, TimeSpanDialog.GetBaseStartTimeValue());
            Assert.AreEqual(endDate, TimeSpanDialog.GetBaseEndDateValue());
            Assert.AreEqual(endTime, TimeSpanDialog.GetBaseEndTimeValue());

            //Check the default Original time type is relative
            Assert.AreEqual(OriginalTimeType.Last7days, TimeSpanDialog.GetOriginalTimeType());

            //Check the default compared interval time type is relative
            Assert.AreEqual(CompareTimeType.Relative, TimeSpanDialog.GetCompareTimeType(2));

            //Check the multiple new compared intervals are displayed with blank time
            for (int i = 3; i <= 5; i++ )
            {
                //Click  'Add Compared Interval' link button in the dialog multiple times. And check the time is blank.
                TimeSpanDialog.ClickAddTimeSpanButton();
                TimeManager.FlashPause();
                Assert.AreEqual("", TimeSpanDialog.GetAdditionRelativeValue(i));
            }

            //Select Start Date Time for all the compared intervals.
            for (int i = 2; i <= 5; i++)
            {
                //Select the compared intervl as user-defined
                TimeSpanDialog.SelectCompareTimeType(CompareTimeType.UserDefined, i);

                //Set the start time and date
                TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[i-2], i);
                TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[i-2], i);

                //Check All end time are set automatically and keep the same time range with original time, but editable.
                Assert.AreEqual(input.ExpectedData.EndDateValue[i - 2], TimeSpanDialog.GetAdditionEndDateValue(i));
                Assert.AreEqual(input.ExpectedData.EndTimeValue[i - 2], TimeSpanDialog.GetAdditionEndTimeValue(i));

                //Check the end time is editable.
                TimeSpanDialog.InputAdditionEndDate(input.InputData.EndDate[i - 2], i);
                TimeSpanDialog.InputAdditionEndTime(input.InputData.EndTime[i - 2], i);

            }

            //Change original time type form dropdown list to absolute time, e.g: 2014-3-20 0:00 to 2014-4-20 24:00
            TimeSpanDialog.InputBaseStartDate(input.InputData.BaseStartDate[0]);
            TimeSpanDialog.InputBaseStartTime(input.InputData.BaseStartTime[0]);
            TimeSpanDialog.InputBaseEndDate(input.InputData.BaseEndDate[0]);
            TimeSpanDialog.InputBaseEndTime(input.InputData.BaseEndTime[0]);

            //Check All compared intervals will be cleared up
            Assert.AreEqual("", TimeSpanDialog.GetAdditionStartDateValue(2));
            Assert.AreEqual("", TimeSpanDialog.GetAdditionEndDateValue(2));
            Assert.AreEqual(3, TimeSpanDialog.GetExcludeIntervals());

            //Select Start Date Time for all the compared intervals again.
            //Input the first compared interval start time
            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[0], 2);
            TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[0], 2);

            //Check the first end time is correctly
            Assert.AreEqual(input.ExpectedData.EndDateValue[4], TimeSpanDialog.GetAdditionEndDateValue(2));
            Assert.AreEqual(input.ExpectedData.EndTimeValue[4], TimeSpanDialog.GetAdditionEndTimeValue(2));

            //Check the first end time is editable.
            TimeSpanDialog.InputAdditionEndDate(input.InputData.EndDate[4], 2);
            TimeSpanDialog.InputAdditionEndTime(input.InputData.EndTime[4], 2);

            //Set and check the 2th~4th compared intervals
            for (int i = 3; i <= 5; i++)
            {
                //Click 'Add Compared Interval' link button in the dialog multiple times
                TimeSpanDialog.ClickAddTimeSpanButton();
                TimeManager.FlashPause();

                //Set the start time and date
                TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[i - 2], i);
                TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[i - 2], i);

                //Check All end time are set automatically and keep the same time range with original time, but editable.
                Assert.AreEqual(input.ExpectedData.EndDateValue[i + 2], TimeSpanDialog.GetAdditionEndDateValue(i));
                Assert.AreEqual(input.ExpectedData.EndTimeValue[i + 2], TimeSpanDialog.GetAdditionEndTimeValue(i));

                //Check the end time is editable.
                TimeSpanDialog.InputAdditionEndDate(input.InputData.EndDate[i + 2], i);
                TimeSpanDialog.InputAdditionEndTime(input.InputData.EndTime[i + 2], i);

            }

            //Click 'Yes & Draw' button
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check •  In tag picker panel, checkbox of other unselected tags((including switch to second page of the tags list, or switch to 系统/区域维度 tab, or switch to other hierarchy) are all disabled.
            Assert.IsFalse(EnergyAnalysis.IsAllEnabledCheckbox());

            //Check Chart display out correctly.
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
            TimeManager.ShortPause();

            //Open More Menu list and change original time to "上月"
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);
            TimeManager.MediumPause();        

            //Check All compared intervals will not be cleared up
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            Assert.AreEqual(0, TimeSpanDialog.GetExcludeIntervals());

            //Delete the old compared intervals
            for (int i = 2; i <= 5; i++)
            {
                TimeSpanDialog.ClickDeleteTimeSpanButton(i);
                TimeManager.ShortPause();
            }

            //Click 'Add Compared Interval' button and set all the compared intervals again
            for (int i = 1; i <= 3; i++)
            {
                TimeSpanDialog.ClickAddTimeSpanButton();
                TimeManager.FlashPause();
                TimeSpanDialog.SelectCompareTimeType(CompareTimeType.Relative, i + 1);
                TimeManager.FlashPause();
                TimeSpanDialog.InputAdditionRelativeValue(i.ToString(), i + 1);
                TimeManager.ShortPause();
            }       

            //Click 'Yes & Draw' button
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
            TimeManager.ShortPause();

            //Open More Menu list and change original time to "去年"
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);
            TimeManager.MediumPause();  

            //Check All compared intervals will not be cleared up
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            Assert.AreEqual(1, TimeSpanDialog.GetExcludeIntervals());

            //Delete the old compared intervals
            for (int i = 2; i <= 4; i++)
            {
                TimeSpanDialog.ClickDeleteTimeSpanButton(i);
                TimeManager.ShortPause();
            }

            //Click  'Add Compared Interval' button and set all the compared intervals again
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            for (int i = 1; i <= 3; i++)
            {
                TimeSpanDialog.ClickAddTimeSpanButton();
                TimeManager.FlashPause();
                TimeSpanDialog.SelectCompareTimeType(CompareTimeType.Relative, i + 1);
                TimeManager.FlashPause();
                TimeSpanDialog.InputAdditionRelativeValue(i.ToString(), i + 1);
                TimeManager.ShortPause();
            }

            //Click 'Yes & Draw' button
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
            TimeManager.ShortPause();

            //From time control, change original time to 2013-3-20 0:00 to 2013-4-20 24:00
            EnergyViewToolbar.SetDateRange(input.InputData.BaseStartDate[0],input.InputData.BaseEndDate[0]);
            EnergyViewToolbar.SetTimeRange(input.InputData.BaseStartTime[0],input.InputData.BaseEndTime[0]);

            //Check the compared intervals will not be cleared up
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            Assert.AreEqual(1, TimeSpanDialog.GetExcludeIntervals());
            TimeSpanDialog.ClickGiveUpButton();
        }
 
        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-Set-106")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(SetComparedIntervalValidSuite), "TC-J1-FVT-MultipleIntervalsComparasion-Set-106")]
        public void ModifyComparedIntervalsWhenOriginalIsRelativeAndNotModified(TimeSpansData input)
        {
            //Select one tag and view data view
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Open 'Single Hierarchy Node' function (单层级数据点), 
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();

            // The time range is displayed as last 7 days by default, change to "上月"
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);
            TimeManager.MediumPause();

            //Click  'Add Compared Interval' button
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            //Get the original time
            string startDate = TimeSpanDialog.GetBaseStartDateValue();
            string startTime = TimeSpanDialog.GetBaseStartTimeValue();
            string endDate = TimeSpanDialog.GetBaseEndDateValue();
            string endTime = TimeSpanDialog.GetBaseEndTimeValue();
            
            //Calculate the month index of Feb
            int monthIndex;
            if (DateTime.Now.Month > 3)
                monthIndex = DateTime.Now.Month - 3;
            else
                monthIndex = DateTime.Now.Month + 9;

            //Click  'Add Compared Interval' link button in the dialog multiple times.(2,3,4月)
            for (int i = 2; i <= 4; i++)
            {
                TimeSpanDialog.ClickAddTimeSpanButton();
                TimeManager.FlashPause();

                //Check Multiple new empty compared intervals are displayed with blank Start Date Time and End Date Time.
                Assert.AreEqual("", TimeSpanDialog.GetAdditionRelativeValue(i + 1));

                //Set all the compared intervals to relative time.
                TimeSpanDialog.InputAdditionRelativeValue((monthIndex + i - 4).ToString(), i);
            }

            //Change type of the first compared interval from relative to absolute time. 
            TimeSpanDialog.SelectCompareTimeType(CompareTimeType.UserDefined, 2);

            //Check The original time range is not change in time pick menu
            Assert.AreEqual(startDate, TimeSpanDialog.GetBaseStartDateValue());
            Assert.AreEqual(startTime, TimeSpanDialog.GetBaseStartTimeValue());
            Assert.AreEqual(endDate, TimeSpanDialog.GetBaseEndDateValue());
            Assert.AreEqual(endTime, TimeSpanDialog.GetBaseEndTimeValue());

            //Select Start Date Time for of the first compared intervals, e.g:2012-3-15 0:00
            TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[0], 2);
            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[0], 2);

            //Check The end time is set automatically and keep the same time range with original time, End time of the first compared interval is: 2012-4-13 24:00. And it should be editable. 
            Assert.AreEqual(input.ExpectedData.EndDateValue[0], TimeSpanDialog.GetAdditionEndDateValue(2));
            Assert.AreEqual(input.ExpectedData.EndTimeValue[0], TimeSpanDialog.GetAdditionEndTimeValue(2));
            TimeSpanDialog.InputAdditionEndDate(input.InputData.EndDate[0], 2);
            TimeSpanDialog.InputAdditionEndTime(input.InputData.EndTime[0], 2);

            //Check The other compared interval keep as before.
            Assert.AreEqual(CompareTimeType.Relative, TimeSpanDialog.GetCompareTimeType(3));
            Assert.AreEqual((monthIndex - 1).ToString(), TimeSpanDialog.GetAdditionRelativeValue(3));
            Assert.AreEqual(CompareTimeType.Relative, TimeSpanDialog.GetCompareTimeType(4));
            Assert.AreEqual(monthIndex.ToString(), TimeSpanDialog.GetAdditionRelativeValue(4));

            //Change type and time of the second compared interval to absolute time: 2013-6-1 00:00 to 2012-7-15 24:00
            TimeSpanDialog.SelectCompareTimeType(CompareTimeType.UserDefined, 3);
            TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[1], 3);
            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[1], 3);
            TimeSpanDialog.InputAdditionEndDate(input.InputData.EndDate[1], 3);
            TimeSpanDialog.InputAdditionEndTime(input.InputData.EndTime[1], 3);

            //Check the display value
            Assert.AreEqual(startDate, TimeSpanDialog.GetBaseStartDateValue());
            Assert.AreEqual(startTime, TimeSpanDialog.GetBaseStartTimeValue());
            Assert.AreEqual(endDate, TimeSpanDialog.GetBaseEndDateValue());
            Assert.AreEqual(endTime, TimeSpanDialog.GetBaseEndTimeValue());
            Assert.AreEqual(input.ExpectedData.StartDateValue[0], TimeSpanDialog.GetAdditionStartDateValue(2));
            Assert.AreEqual(input.ExpectedData.StartTimeValue[0], TimeSpanDialog.GetAdditionStartTimeValue(2));
            Assert.AreEqual(input.ExpectedData.EndDateValue[0], TimeSpanDialog.GetAdditionEndDateValue(2));
            Assert.AreEqual(input.ExpectedData.EndTimeValue[0], TimeSpanDialog.GetAdditionEndTimeValue(2));
            Assert.AreEqual(input.ExpectedData.StartDateValue[1], TimeSpanDialog.GetAdditionStartDateValue(3));
            Assert.AreEqual(input.ExpectedData.StartTimeValue[1], TimeSpanDialog.GetAdditionStartTimeValue(3));
            Assert.AreEqual(input.ExpectedData.EndDateValue[1], TimeSpanDialog.GetAdditionEndDateValue(3));
            Assert.AreEqual(input.ExpectedData.EndTimeValue[1], TimeSpanDialog.GetAdditionEndTimeValue(3));
            Assert.AreEqual(CompareTimeType.Relative, TimeSpanDialog.GetCompareTimeType(4));
            Assert.AreEqual(monthIndex.ToString(), TimeSpanDialog.GetAdditionRelativeValue(4));

            //Click 'Yes & Draw' button
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check Chart display out correctly.
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
            TimeManager.ShortPause();

            //Open the above multiple interval comparasion
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            //Check The intervals set above are stored and displayed in the dialog when open next time. 
            Assert.AreEqual(startDate, TimeSpanDialog.GetBaseStartDateValue());
            Assert.AreEqual(startTime, TimeSpanDialog.GetBaseStartTimeValue());
            Assert.AreEqual(endDate, TimeSpanDialog.GetBaseEndDateValue());
            Assert.AreEqual(endTime, TimeSpanDialog.GetBaseEndTimeValue());
            Assert.AreEqual(input.ExpectedData.StartDateValue[0], TimeSpanDialog.GetAdditionStartDateValue(2));
            Assert.AreEqual(input.ExpectedData.StartTimeValue[0], TimeSpanDialog.GetAdditionStartTimeValue(2));
            Assert.AreEqual(input.ExpectedData.EndDateValue[0], TimeSpanDialog.GetAdditionEndDateValue(2));
            Assert.AreEqual(input.ExpectedData.EndTimeValue[0], TimeSpanDialog.GetAdditionEndTimeValue(2));
            Assert.AreEqual(input.ExpectedData.StartDateValue[1], TimeSpanDialog.GetAdditionStartDateValue(3));
            Assert.AreEqual(input.ExpectedData.StartTimeValue[1], TimeSpanDialog.GetAdditionStartTimeValue(3));
            Assert.AreEqual(input.ExpectedData.EndDateValue[1], TimeSpanDialog.GetAdditionEndDateValue(3));
            Assert.AreEqual(input.ExpectedData.EndTimeValue[1], TimeSpanDialog.GetAdditionEndTimeValue(3));
            Assert.AreEqual(CompareTimeType.Relative, TimeSpanDialog.GetCompareTimeType(4));
            Assert.AreEqual(monthIndex.ToString(), TimeSpanDialog.GetAdditionRelativeValue(4));

            //Change type of the second compared interval to relatived: 之前第*个月
            TimeSpanDialog.SelectCompareTimeType(CompareTimeType.Relative, 3);
            TimeSpanDialog.InputAdditionRelativeValue(monthIndex.ToString(), 3);

            //Check Text followed is 2014年2月
            if(("2014年2月" == TimeSpanDialog.GetComparedIntervalsText(3)) ||("02, 2014" == TimeSpanDialog.GetComparedIntervalsText(3)))
                Assert.Pass();
            else
                Assert.Fail();

            //Click 'Yes & Draw' button
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check Chart display out correctly.
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
            TimeManager.ShortPause();

            //Check the intervals are right in legends
            string[] legendsAc = EnergyAnalysis.GetLegendItemTexts();
            string[] legendsEx = { "", "", "", "" };
            legendsEx[0] = startDate + " " + startTime + endDate + " " + endTime;
            legendsEx[1] = input.ExpectedData.StartDateValue[0] + " " + input.ExpectedData.StartTimeValue[0] + input.ExpectedData.EndDateValue[0] + " " + input.ExpectedData.EndTimeValue[0];
            legendsEx[2] = input.ExpectedData.StartDateValue[2] + " " + input.ExpectedData.StartTimeValue[2] + input.ExpectedData.EndDateValue[2] + " " + input.ExpectedData.EndTimeValue[2];
            legendsEx[3] = input.ExpectedData.StartDateValue[2] + " " + input.ExpectedData.StartTimeValue[2] + input.ExpectedData.EndDateValue[2] + " " + input.ExpectedData.EndTimeValue[2];
            Assert.AreEqual(legendsAc, legendsEx);

        }

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-Set-107")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(SetComparedIntervalValidSuite), "TC-J1-FVT-MultipleIntervalsComparasion-Set-107")]
        public void ModifyComparedIntervalsWhenOriginalIsAbsoluteAndNotModified(TimeSpansData input)
        {
            //Select one tag and view data view
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Open 'Single Hierarchy Node' function (单层级数据点), 
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();

            //Set Original time range to 2013/01/01 02:00 to 2013/02/13 12:00 
            EnergyViewToolbar.SetDateRange(input.InputData.BaseStartDate[0], input.InputData.BaseEndDate[0]);
            EnergyViewToolbar.SetTimeRange(input.InputData.BaseStartTime[0], input.InputData.BaseEndTime[0]);

            //Click  'Add Compared Interval' button
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            //'Add Compared Interval' dialog is displayed with above original time range ('2013/01/01 02:00 to 2012/02/13 12:00')
            Assert.AreEqual(TimeSpanDialog.GetBaseStartDateValue(), input.InputData.BaseStartDate[0]);
            Assert.AreEqual(TimeSpanDialog.GetBaseStartTimeValue(), input.InputData.BaseStartTime[0]);
            Assert.AreEqual(TimeSpanDialog.GetBaseEndDateValue(), input.InputData.BaseEndDate[0]);
            Assert.AreEqual(TimeSpanDialog.GetBaseEndTimeValue(), input.InputData.BaseEndTime[0]);

            //The compared interval time type is changed to absolute and grey out
            Assert.AreEqual(CompareTimeType.UserDefined, TimeSpanDialog.GetCompareTimeType(2));
            Assert.AreEqual("", TimeSpanDialog.GetAdditionStartDateValue(2));
            Assert.AreEqual("00:00", TimeSpanDialog.GetAdditionStartTimeValue(2));
            Assert.AreEqual("", TimeSpanDialog.GetAdditionEndDateValue(2));
            Assert.AreEqual("24:00", TimeSpanDialog.GetAdditionEndTimeValue(2));

            for (int i = 3; i <= 5; i++)
            {
                //Click  'Add Compared Interval' link button in the dialog multiple times.
                TimeSpanDialog.ClickAddTimeSpanButton();
                TimeManager.FlashPause();

                //Multiple new empty compared intervals are displayed with blank Start Date Time and End Date Time.
                Assert.AreEqual("", TimeSpanDialog.GetAdditionStartDateValue(i));
                Assert.AreEqual("", TimeSpanDialog.GetAdditionEndDateValue(i));
            }

            //Select Start Date Time  for all the compared intervals.
            for (int i = 2; i <= 3; i++ )
            {
                TimeSpanDialog.SelectCompareTimeType(CompareTimeType.UserDefined, i);
                TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[i - 2], i);
                TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[i - 2], i);

                //Check All end time are set automatically and keep the same time range with original time, but editable.
                Assert.AreEqual(input.ExpectedData.EndDateValue[i - 2], TimeSpanDialog.GetAdditionEndDateValue(i));
                Assert.AreEqual(input.ExpectedData.EndTimeValue[i - 2], TimeSpanDialog.GetAdditionEndTimeValue(i));
                TimeSpanDialog.InputAdditionEndDate(input.InputData.EndDate[i - 2], i);
                TimeSpanDialog.InputAdditionEndTime(input.InputData.EndTime[i - 2], i);
            }

            //Change end time of the first compared interval from 2012-06-12 10:00 TO 2012-07-12 10:00
            TimeSpanDialog.InputAdditionEndDate(input.InputData.EndDate[2], 2);
            TimeSpanDialog.InputAdditionEndTime(input.InputData.EndTime[2], 2);

            //Check The original time range is not change in time pick menu
            Assert.AreEqual(TimeSpanDialog.GetBaseStartDateValue(), input.InputData.BaseStartDate[0]);
            Assert.AreEqual(TimeSpanDialog.GetBaseStartTimeValue(), input.InputData.BaseStartTime[0]);
            Assert.AreEqual(TimeSpanDialog.GetBaseEndDateValue(), input.InputData.BaseEndDate[0]);
            Assert.AreEqual(TimeSpanDialog.GetBaseEndTimeValue(), input.InputData.BaseEndTime[0]);

            //Check The end time of the first interval change to 2012-07-12 10:00 without error
            Assert.AreEqual(input.ExpectedData.EndDateValue[2], TimeSpanDialog.GetAdditionEndDateValue(2));
            Assert.AreEqual(input.ExpectedData.EndTimeValue[2], TimeSpanDialog.GetAdditionEndTimeValue(2));

            //Click 'Yes & Draw' button
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check •  In tag picker panel, checkbox of other unselected tags((including switch to second page of the tags list, or switch to 系统/区域维度 tab, or switch to other hierarchy) are all disabled.
            Assert.IsFalse(EnergyAnalysis.IsAllEnabledCheckbox());

            //Check Chart display out correctly.
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
            TimeManager.ShortPause();

            //Check the intervals are correctly in legends
            string[] legendsAc = EnergyAnalysis.GetLegendItemTexts();
            string[] legendsEx = { "", "", ""};
            legendsEx[0] = input.InputData.BaseStartDate[0] + " " + input.InputData.BaseStartTime[0] + input.InputData.BaseEndDate[0] + " " + input.InputData.BaseEndTime[0];
            legendsEx[1] = input.InputData.StartDate[0] + " " + input.InputData.StartTime[0] + input.ExpectedData.EndDateValue[2] + " " + input.ExpectedData.EndTimeValue[2];
            legendsEx[2] = input.InputData.StartDate[1] + " " + input.InputData.StartTime[1] + input.ExpectedData.EndDateValue[1] + " " + input.ExpectedData.EndTimeValue[1];
            Assert.AreEqual(legendsAc, legendsEx);

            //Open the above multiple interval comparasion
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            //Change start time of the second compared interval from 2012-02-29, 04:00 to 2012-02-14 04:00
            TimeSpanDialog.InputAdditionStartDate(input.InputData.StartDate[2], 3);
            TimeSpanDialog.InputAdditionStartTime(input.InputData.StartTime[2], 3);

            //Check The start and end time of are not changed in time pick up menu both for Original and Compared intervals.
            Assert.AreEqual(TimeSpanDialog.GetBaseStartDateValue(), input.InputData.BaseStartDate[0]);
            Assert.AreEqual(TimeSpanDialog.GetBaseStartTimeValue(), input.InputData.BaseStartTime[0]);
            Assert.AreEqual(TimeSpanDialog.GetBaseEndDateValue(), input.InputData.BaseEndDate[0]);
            Assert.AreEqual(TimeSpanDialog.GetBaseEndTimeValue(), input.InputData.BaseEndTime[0]);
            Assert.AreEqual(TimeSpanDialog.GetAdditionStartDateValue(2), input.InputData.StartDate[0]);
            Assert.AreEqual(TimeSpanDialog.GetAdditionStartTimeValue(2), input.InputData.StartTime[0]);
            Assert.AreEqual(TimeSpanDialog.GetAdditionEndDateValue(2), input.ExpectedData.EndDateValue[2]);
            Assert.AreEqual(TimeSpanDialog.GetAdditionEndTimeValue(2), input.ExpectedData.EndTimeValue[2]);

            //Click 'Yes & Draw' button
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check Chart display out correctly.
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
            TimeManager.ShortPause();

            //check the intervals are correctly in legends
            legendsAc = EnergyAnalysis.GetLegendItemTexts();
            legendsEx[0] = input.InputData.BaseStartDate[0] + " " + input.InputData.BaseStartTime[0] + input.InputData.BaseEndDate[0] + " " + input.InputData.BaseEndTime[0];
            legendsEx[1] = input.InputData.StartDate[0] + " " + input.InputData.StartTime[0] + input.ExpectedData.EndDateValue[2] + " " + input.ExpectedData.EndTimeValue[2];
            legendsEx[2] = input.InputData.StartDate[2] + " " + input.InputData.StartTime[2] + input.ExpectedData.EndDateValue[1] + " " + input.ExpectedData.EndTimeValue[1];
            Assert.AreEqual(legendsAc, legendsEx);

        }

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-Set-108")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(SetComparedIntervalValidSuite), "TC-J1-FVT-MultipleIntervalsComparasion-Set-108")]
        public void RemoveComparedIntervals(TimeSpansData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.LongPause();
            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            //Select one tag and view data view
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Open 'Single Hierarchy Node' function (单层级数据点), 
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();

            //上周, Click  'Add Compared Interval' button， select 之前第1个7天, click '确定并绘图'
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastWeek);
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionRelativeValue("1", 2);
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check The default step is Day
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Raw));

            //Click  'Add Compared Interval' button to open the dialog
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();

            //From the dialog, Click 'x' to delete one compared interval. Click 'Yes'
            TimeSpanDialog.ClickDeleteTimeSpanButton(2);
            Assert.AreEqual(4, TimeSpanDialog.GetExcludeIntervals());
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check The series for compared interval is removed from chart directly.
            Assert.IsTrue(1 >= EnergyAnalysis.GetTrendChartLines());

            //The default step should still be Day
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Raw));

            //Add compared intervals
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.SelectCompareTimeType(CompareTimeType.UserDefined, 2);
            TimeSpanDialog.InputAdditionStartDate("2012-01-01", 2);
            TimeSpanDialog.InputAdditionEndDate("2012-01-08", 2);
            TimeManager.FlashPause();
            TimeSpanDialog.ClickAddTimeSpanButton();
            TimeSpanDialog.SelectCompareTimeType(CompareTimeType.UserDefined, 3);
            TimeSpanDialog.InputAdditionStartDate("2012-02-01", 3);
            TimeSpanDialog.InputAdditionEndDate("2012-02-08", 3);
            TimeManager.FlashPause();
            TimeSpanDialog.ClickAddTimeSpanButton();
            TimeSpanDialog.SelectCompareTimeType(CompareTimeType.UserDefined, 4);
            TimeSpanDialog.InputAdditionStartDate("2012-03-01", 4);
            TimeSpanDialog.InputAdditionEndDate("2012-03-08", 4);
            TimeManager.FlashPause();
            TimeSpanDialog.ClickAddTimeSpanButton();
            TimeSpanDialog.SelectCompareTimeType(CompareTimeType.UserDefined, 5);
            TimeSpanDialog.InputAdditionStartDate("2012-04-01", 5);
            TimeSpanDialog.InputAdditionEndDate("2012-04-08", 5);
            TimeManager.FlashPause();

            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //------Need manual test:CloseLegendItem don't work well, the legend item can be clicked--------
            ////From the legend area, Click 'x' icon delete one compared interval.
            ////EnergyAnalysis.ClickLegendItem("2012-01-01 00:002012-01-08 24:00");
            //EnergyAnalysis.CloseLegendItem("2012-01-01 00:002012-01-08 24:00");
            //TimeManager.FlashPause();

            ////Check the series for compared interval is removed from chart directly.
            //Assert.AreEqual(4, EnergyAnalysis.GetLegendItemTexts().Length);

            //Check the removed interval is also disappered from the dialog.
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            //Assert.AreEqual(1, TimeSpanDialog.GetExcludeIntervals());

            //From the dialog, Click 'x' to delete ALL compared intervals one by one.Click 'Yes' button
            for (int i = 2; i <= 5; i++ )
            {
                TimeSpanDialog.ClickDeleteTimeSpanButton(i);
                TimeManager.FlashPause();
            }

            Assert.AreEqual(4, TimeSpanDialog.GetExcludeIntervals());
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check Checkbox of other unselected tags are enabled.
            Assert.IsTrue(EnergyAnalysis.IsAllEnabledCheckbox());
            //Check 'Remove All Compared Intervals' button is unavailable since all compared intervals are deleted.
            //Assert.IsTrue(TimeSpans.DeleteAllTimeSpans.);

            //Add some intervals. 
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            for (int i = 2; i <= 5; i++ )
            {
                TimeSpanDialog.SelectCompareTimeType(CompareTimeType.Relative, i);
                TimeSpanDialog.InputAdditionRelativeValue(i.ToString(),i);
                TimeManager.FlashPause();
                TimeSpanDialog.ClickAddTimeSpanButton();
                TimeManager.FlashPause();
            }

            //From the dialog, Click 'x' to delete ALL compared intervals one by one.
            for (int i = 2; i <= 5; i++ )
            {
                TimeSpanDialog.ClickDeleteTimeSpanButton(i);
                TimeManager.ShortPause();
                Assert.AreEqual(i - 1, TimeSpanDialog.GetExcludeIntervals());
                TimeManager.FlashPause();
            }

            //Click 'Yes' button
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check •  All compared intervals are removed directly without warning.
            //•  Checkbox of other unselected tags are enabled.
            Assert.IsTrue(EnergyAnalysis.IsAllEnabledCheckbox());
            //•  'Remove All Compared Intervals' button is unavailable since all compared intervals are deleted.
            //Assert.IsTrue(EnergyViewToolbar.IsTimeSpanMenuItemDisabled(input.ExpectedData.DeleteMessages[0]));

            //Check The default step should still be Day
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Raw));

            //Click '查看数据' button
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check All compared time series in chart are removed and only the tag's original series is displayed.
            Assert.AreEqual(1, EnergyAnalysis.GetLegendItemTexts().Length);
            Assert.AreEqual("BuildingA_P1_Electri...", EnergyAnalysis.GetLegendItemTexts()[0]);//tag name is too long to display in legend area

            //Add multiple compared intervals successfully again.
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionRelativeValue("1",2);
            TimeManager.FlashPause();
            for (int i = 3; i <= 5; i++)
            {
                TimeSpanDialog.ClickAddTimeSpanButton();
                TimeManager.FlashPause();
                TimeSpanDialog.InputAdditionRelativeValue((i - 1).ToString(), i);
                TimeManager.FlashPause();
            }
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Click 'Remove All Compared Intervals' button, then cancel
            EnergyViewToolbar.TimeSpan(TimeSpans.DeleteAllTimeSpans);
            TimeManager.ShortPause();

            //Popup message 'Clear all compared intervals?' for confirmation.
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.ClearAllMessage));

            //Click 'Cancel'.
            JazzMessageBox.MessageBox.GiveUp();
            TimeManager.MediumPause();

            //Check All compared intervals are still there and NOT cleared.
            Assert.AreEqual(5, EnergyAnalysis.GetLegendItemTexts().Length);
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.MediumPause();
            Assert.AreEqual(0, TimeSpanDialog.GetExcludeIntervals());
            TimeSpanDialog.ClickGiveUpButton();

            //Click 'Remove All Compared Intervals' button, then confrim
            EnergyViewToolbar.TimeSpan(TimeSpans.DeleteAllTimeSpans);
            TimeManager.ShortPause();

            //Popup message 'Clear all compared intervals?' for confirmation.
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.ClearAllMessage));

            //Click 'Delete'.
            JazzMessageBox.MessageBox.Delete();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check •  All compared intervals are removed.
            Assert.AreEqual(1, EnergyAnalysis.GetLegendItemTexts().Length);
            //•  All compared time series in chart are removed.
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.MediumPause();
            Assert.AreEqual(3, TimeSpanDialog.GetExcludeIntervals());
            TimeSpanDialog.ClickConfirmButton();
            TimeManager.ShortPause();
            //•  Checkbox of other unselected tags are enabled.
            Assert.IsTrue(EnergyAnalysis.IsAllEnabledCheckbox());
            //•  'Remove All Compared Intervals' button is unavailable since all compared intervals are deleted.
            //?Assert.IsTrue(EnergyViewToolbar.IsTimeSpanMenuItemDisabled(input.ExpectedData.DeleteMessages[0]));

            //Add multiple compared intervals successfully again.
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            TimeSpanDialog.InputAdditionRelativeValue("1", 2);
            TimeManager.FlashPause();
            for (int i = 3; i <= 5; i++)
            {
                TimeSpanDialog.ClickAddTimeSpanButton();
                TimeManager.FlashPause();
                TimeSpanDialog.InputAdditionRelativeValue((i - 1).ToString(), i);
                TimeManager.FlashPause();
            }

            //Remove the first and second compared intervals
            TimeSpanDialog.ClickDeleteTimeSpanButton(2);
            TimeSpanDialog.ClickDeleteTimeSpanButton(3);

            //Check The first and second compared intervals are removed.
            //Original and the third compared intervals are left.
            Assert.AreEqual(2, TimeSpanDialog.GetExcludeIntervals());
            Assert.AreNotEqual("", TimeSpanDialog.GetBaseStartDateValue());
            Assert.AreNotEqual("", TimeSpanDialog.GetBaseEndDateValue());
            Assert.AreEqual("3", TimeSpanDialog.GetAdditionRelativeValue(4));

            //This bug have not fixed
            //Click link '添加时间段' button some times and check the locations that new intervals added to
            for (int i = 4; i <= 5; i++ )
            {
                TimeSpanDialog.ClickAddTimeSpanButton();
                TimeManager.FlashPause();
                //Check The new intervals should added to below the last interval.
                //Assert.AreEqual("", TimeSpanDialog.GetAdditionRelativeValue(i));
            }
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check •  In 'More' menu, the 'Delete All' button is available.
            //Click 'Delete All' button from 'More' menu.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
            TimeManager.ShortPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.DeleteAllMessage));
            TimeManager.FlashPause();

            //Click 'Cancel' in popup message dialog.
            //JazzMessageBox.MessageBox.Cancel();
            JazzMessageBox.MessageBox.Close();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check •  All compared intervals are still there and NOT cleared.
            Assert.AreEqual(3,EnergyAnalysis.GetLegendItemTexts().Length);

            //Click 'Confrim' in popup message dialog.
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
            TimeManager.ShortPause();
            JazzMessageBox.MessageBox.Clear();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check •  The tag and all intervals are removed.
            //Assert.AreEqual(0, EnergyAnalysis.GetLegendItemTexts().Length);//No chart or legend, so, GetLegendItemTexts faild.It also can be verify in next step(no chart drawn).
            //•  Tag selection panel becomes avaible for multiple tags selection.
            //•  Checkbox of other unselected tags are enabled.
            Assert.IsTrue(EnergyAnalysis.IsAllEnabledCheckbox());
            //•  No any chart displayed.
            //Assert.IsFalse(EnergyAnalysis.IsTrendChartDrawn());
            //•  'Remove All Compared Intervals' button is unavailable since all compared intervals are deleted.
            //Assert.IsTrue(EnergyViewToolbar.IsTimeSpanMenuItemDisabled(input.ExpectedData.DeleteMessages[0]));

            //----------------Add some intervals to prepare for chart data------------------
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Click  'Add Compared Interval' button to open the dialog
            EnergyViewToolbar.ClickTimeSpanButton();
            TimeManager.ShortPause();
            for (int i = 2; i < 5; i++)
            {
                TimeSpanDialog.InputAdditionRelativeValue(i.ToString(), i);
                TimeManager.ShortPause();
                TimeSpanDialog.ClickAddTimeSpanButton();
                TimeManager.ShortPause();
            }
            TimeSpanDialog.ClickConfirmButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            //----------------------Prepared end----------------------------------------------

            //Save this widget to dashboard and check it
            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);

            //Check the Distribution Chart is saved into dashboard successfully
            EnergyAnalysis.NavigateToAllDashBoards();
            HomePagePanel.SelectHierarchyNode(dashboard.HierarchyName);
            TimeManager.MediumPause();
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));

        }

    }
}
