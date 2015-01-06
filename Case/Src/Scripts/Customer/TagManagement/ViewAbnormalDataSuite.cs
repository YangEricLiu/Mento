using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using System.IO;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Customer;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [Owner("Linda")]
    [CreateTime("2014-12-30")]
    [ManualCaseID("TC-J1-FVT-AbnormalData-View")]
    public class ViewAbnormalDataSuite : TestSuiteBase
    {
        private AbnormalData AbnormalData = JazzFunction.AbnormalData;
        private static Grid VEERawDataGrid = JazzGrid.GridVEERawData;
        private static TextField VEERawDataValueNumberField = JazzTextField.VEERawDataValueTextField;

        [SetUp]
        public void CaseSetUp()
        {
            AbnormalData.NavigatorToAbnormalRecord();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-View-103")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(ViewAbnormalDataSuite), "TC-J1-FVT-AbnormalRecord-View-103")]
        public void ChangeTimeRangeViaLeftAndRightButton(AbnormalRecordData input)
        {
            //Navigate to Raw Data tab
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            //Set Start Time is Start Time is 04/11 00:00 and End Time is 04/15 24:00
            var ManualTimeRange = input.InputData.ManualTimeRange;
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading(); 
            TimeManager.ShortPause();

            //Click Left button
            AbnormalData.ClickLeftButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            //Verify new Start Time is 04/06 00:00 and End time is 04/10 24:00..
            Assert.AreEqual("2014-04-06", AbnormalData.GetBaseStartDateValue());
            Assert.AreEqual("2014-04-10", AbnormalData.GetBaseEndDateValue());
            Assert.AreEqual("00:00", AbnormalData.GetBaseStartTimeValue());
            Assert.AreEqual("24:00", AbnormalData.GetBaseEndTimeValue());

            //Display raw data in selected time range
            Assert.AreEqual("6", VEERawDataGrid.GetCellValue(3));//3 means the 1st row

            //Set Start Time is Start Time is 04/11 00:00 and End Time is 04/15 24:00           
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading(); 
            TimeManager.ShortPause();

            //Click Right button
            AbnormalData.ClickRightButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading(); 
            TimeManager.ShortPause();

            //Verify new Start Time is 04/16 00:00 and End time is 04/20 24:00.
            Assert.AreEqual("2014-04-16", AbnormalData.GetBaseStartDateValue());
            Assert.AreEqual("2014-04-20", AbnormalData.GetBaseEndDateValue());
            Assert.AreEqual("00:00", AbnormalData.GetBaseStartTimeValue());
            Assert.AreEqual("24:00", AbnormalData.GetBaseEndTimeValue());

            //Display raw data in selected time range.
            Assert.AreEqual("16", VEERawDataGrid.GetCellValue(3));
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-View-104")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(ViewAbnormalDataSuite), "TC-J1-FVT-AbnormalRecord-View-104")]
        public void ChangeTimeRangeViaTimeControlDropdown(AbnormalRecordData input)
        {
            //Navigate to Raw Data tab
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            //Set Start Time is 04/11 10:00 and End Time is 04/15 06:00
            var ManualTimeRange = input.InputData.ManualTimeRange;
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.ShortPause();

            //verify the value
            Assert.AreEqual("11", VEERawDataGrid.GetCellValue(3));

            //Change Start Time is 04/7 10:00 and End Time is 04/13 10:00
            AbnormalData.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            TimeManager.ShortPause();

            //Display raw data in selected time range
            Assert.AreEqual("7", VEERawDataGrid.GetCellValue(3));

            //Set Start Time is less than 2000-01-01 00:00, and end time is larger than 2049-12-31 24:00
            //(1999-12-31 23:00 ~ 2050-01-01 01:00)
            //AbnormalData.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            //AbnormalData.SetTimeRange(ManualTimeRange[2].StartTime, ManualTimeRange[2].EndTime);
            //TimeManager.LongPause();

            ////The time controller for smaller than 2000-01-01 00:00 and larger than 2049-12-31 24:00 is not available for Start time
            //Assert.AreNotEqual(ManualTimeRange[2].StartDate, AbnormalData.GetBaseStartDateValue());
            //Assert.AreNotEqual(ManualTimeRange[2].EndDate, AbnormalData.GetBaseEndDateValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-View-105")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(ViewAbnormalDataSuite), "TC-J1-FVT-AbnormalRecord-View-104")]
        public void VerifyMissedRecordWillBeFilledForDisplaying(AbnormalRecordData input)
        {
            //Navigate to Raw Data tab
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            //.Ensure that missed records will be filled for displaying with TimeStamp is "Filled value based on selected type", Value is Null and Status is Null.
            Assert.AreEqual(" ", VEERawDataGrid.GetCellValue(3));
            Assert.AreEqual(" ", VEERawDataGrid.GetCellValue(4));
            Assert.AreEqual(" ", VEERawDataGrid.GetCellValue(5));
            Assert.AreEqual(" ", VEERawDataGrid.GetCellValue(6));
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-View-106")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(ViewAbnormalDataSuite), "TC-J1-FVT-AbnormalRecord-View-106")]
        public void SwitchBetweenDifferenceValueAndRawValue(AbnormalRecordData input)
        {
            //Navigate to Raw Data tab
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            //Set time range = 2014年02月02日00点00分-2014年02月03日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Click the 1&2 row and input two valid modified value.
            VEERawDataGrid.FocusOnCell(3);
            TimeManager.LongPause();
            VEERawDataValueNumberField.Fill("10");
            TimeManager.LongPause();
            VEERawDataGrid.FocusOnCell(4);
            TimeManager.LongPause();
            VEERawDataValueNumberField.Fill("22");
            TimeManager.LongPause();

            //Click save button
            AbnormalData.ClickSaveRawDataButton();
            TimeManager.ShortPause();

            //Switch to Difference Value and display them in both Line Chart and Grid View. 
            AbnormalData.ClickSwitchDifferenceValueButton();
            TimeManager.ShortPause();
            Assert.AreEqual("12", VEERawDataGrid.GetCellValue(4));//the different value set to the second row

            //Click Switch button it is Difference Value now.  
            AbnormalData.ClickSwitchOriginalValueButton();
            TimeManager.ShortPause();
            Assert.AreEqual("10", VEERawDataGrid.GetCellValue(4));//the different value set to the second row
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-View-107")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(ViewAbnormalDataSuite), "TC-J1-FVT-AbnormalRecord-View-107")]
        public void VerifyUOMChangeSuccessWhenDiffUOMTagChange(AbnormalRecordData input)
        {
            //Navigate to Raw Data tab
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            //The UOM display with KWH is grid view.
            Assert.AreEqual(VEERawDataGrid.GetUomInRawDataGrid(), input.InputData.Uoms[0]);
            TimeManager.LongPause();

            //Select another tag that UOM is ton.
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[1]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            //The UOM display with Ton accordingly.
            Assert.AreEqual(VEERawDataGrid.GetUomInRawDataGrid(), input.InputData.Uoms[1]);
        }
    }
}
