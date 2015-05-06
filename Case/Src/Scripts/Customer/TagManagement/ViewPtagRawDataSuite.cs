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
    [CreateTime("2014-08-26")]
    [ManualCaseID("TC-J1-FVT-PtagRawData-View")]
    public class ViewPtagRawDataSuite : TestSuiteBase
    {
        private PTagSettings PTagSettings = JazzFunction.PTagSettings;
        private PTagRawData PTagRawData = JazzFunction.PTagRawData;
        private static Chart PTagRawDataLineChart = JazzChart.PTagRawDataLineChart;
        private static Grid PTagRawDataGrid = JazzGrid.GridPTagRawData;
        private static TextField PtagRawDataValueNumberField = JazzTextField.PtagRawDataValueTextField;

        [SetUp]
        public void CaseSetUp()
        {
            PTagSettings.PTagSettingCaseSetUp();
        }

        [TearDown]
        public void CaseTearDown()
        {
            PTagSettings.PTagSettingCaseTearDown();
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagRawData-View-103")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ViewPtagRawDataSuite), "TC-J1-FVT-PtagRawData-View-103")]
        public void ChangeTimeRangeViaLeftAndRightButton(PtagData input)
        {
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();

            //Set Start Time is Start Time is 04/11 00:00 and End Time is 04/15 24:00
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();
           
            //Click Left button
            PTagRawData.ClickLeftButton();
            TimeManager.LongPause();
            
            //Verify new Start Time is 04/06 00:00 and End time is 04/10 24:00..
            Assert.AreEqual("2014-04-06",PTagRawData.GetBaseStartDateValue());
            Assert.AreEqual("2014-04-10",PTagRawData.GetBaseEndDateValue());
            Assert.AreEqual("00:00",PTagRawData.GetBaseStartTimeValue());
            Assert.AreEqual("24:00",PTagRawData.GetBaseEndTimeValue());

            //Display raw data in selected time range
            Assert.AreEqual("6",PTagRawDataGrid.GetCellValue(2));

            //Set Start Time is Start Time is 04/11 00:00 and End Time is 04/15 24:00           
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Click Right button
            PTagRawData.ClickRightButton();
            TimeManager.LongPause();

            //Verify new Start Time is 04/16 00:00 and End time is 04/20 24:00.
            Assert.AreEqual("2014-04-16", PTagRawData.GetBaseStartDateValue());
            Assert.AreEqual("2014-04-20", PTagRawData.GetBaseEndDateValue());
            Assert.AreEqual("00:00", PTagRawData.GetBaseStartTimeValue());
            Assert.AreEqual("24:00", PTagRawData.GetBaseEndTimeValue());

            //Display raw data in selected time range.
            Assert.AreEqual("16",PTagRawDataGrid.GetCellValue(2));
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagRawData-View-104")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ViewPtagRawDataSuite), "TC-J1-FVT-PtagRawData-View-104")]
        public void ChangeTimeRangeViaTimeControlDropdown(PtagData input)
        {
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();

            //Set original Start Time is 04/11 10:00 and End Time is 04/15 06:00. 
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Display the raw data info in selected time range
            Assert.AreEqual(ManualTimeRange[0].StartDate, PTagRawData.GetBaseStartDateValue());
            Assert.AreEqual(ManualTimeRange[0].EndDate, PTagRawData.GetBaseEndDateValue());
            Assert.AreEqual(ManualTimeRange[0].StartTime, PTagRawData.GetBaseStartTimeValue());
            Assert.AreEqual(ManualTimeRange[0].EndTime, PTagRawData.GetBaseEndTimeValue());
            Assert.AreEqual("11",PTagRawDataGrid.GetCellValue(2));

            //After change Start Time to 04/07 10:00, the End Time should be changed to 04/13 10:00.
            PTagRawData.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            TimeManager.LongPause();

            //Display the raw data info in selected time range
            Assert.AreEqual(ManualTimeRange[1].StartDate, PTagRawData.GetBaseStartDateValue());
            Assert.AreEqual(ManualTimeRange[1].EndDate, PTagRawData.GetBaseEndDateValue());
            Assert.AreEqual(ManualTimeRange[1].StartTime, PTagRawData.GetBaseStartTimeValue());
            Assert.AreEqual(ManualTimeRange[1].EndTime, PTagRawData.GetBaseEndTimeValue());
            Assert.AreEqual("7", PTagRawDataGrid.GetCellValue(2));

            //Set Start Time is less than 2000-01-01 00:00, and end time is larger than 2049-12-31 24:00
            //(1999-12-31 23:00 ~ 2050-01-01 01:00)
            //PTagRawData.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            //PTagRawData.SetTimeRange(ManualTimeRange[2].StartTime, ManualTimeRange[2].EndTime);
            //TimeManager.LongPause();

            //The time controller for smaller than 2000-01-01 00:00 and larger than 2049-12-31 24:00 is not available for Start time
            //Assert.AreNotEqual(ManualTimeRange[2].StartDate, PTagRawData.GetBaseStartDateValue());
            //Assert.AreNotEqual(ManualTimeRange[2].EndDate, PTagRawData.GetBaseEndDateValue());

            Assert.False(PTagRawData.IsStartDateEnable(ManualTimeRange[2].StartDate));
            Assert.False(PTagRawData.IsEndDateEnable(ManualTimeRange[2].EndDate));
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagRawData-View-105")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ViewPtagRawDataSuite), "TC-J1-FVT-PtagRawData-View-105")]
        public void VerifyMissedRecordWillBeFilledForDisplaying(PtagData input)
        {
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();
            TimeManager.LongPause();

            //Ensure that missed records will be filled for displaying with TimeStamp is "Filled value based on selected type", Value is Null and Status is Null
            Assert.AreEqual(" ", PTagRawDataGrid.GetCellValue(2));
            Assert.AreEqual(" ", PTagRawDataGrid.GetCellValue(3));
            Assert.AreEqual(" ", PTagRawDataGrid.GetCellValue(4));
            Assert.AreEqual(" ", PTagRawDataGrid.GetCellValue(5));
            Assert.AreEqual(" ", PTagRawDataGrid.GetCellValue(6));

        }

        [Test]
        [CaseID("TC-J1-FVT-PtagRawData-View-106")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ViewPtagRawDataSuite), "TC-J1-FVT-PtagRawData-View-106")]
        public void SwitchBetweenDifferenceValueAndRawValue(PtagData input)
        {
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();
            TimeManager.LongPause();

            //Set time range = 2014年02月02日00点00分-2014年02月03日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Click the 1&2 row and input two valid modified value.
            PTagRawDataGrid.FocusOnCell(2);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("10");
            TimeManager.LongPause();
            PTagRawDataGrid.FocusOnCell(3);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("22");
            TimeManager.LongPause();

            //Click save button
            PTagRawData.ClickSaveRawDataButton();
            TimeManager.LongPause();

            //Switch to Difference Value and display them in both Line Chart and Grid View. 
            PTagRawData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();                             
            Assert.AreEqual("12", PTagRawDataGrid.GetCellValue(3));
            
            //Click Switch button it is Difference Value now.  
            PTagRawData.ClickSwitchOriginalValueButton();
            TimeManager.LongPause();
            Assert.AreEqual("10", PTagRawDataGrid.GetCellValue(2));
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagRawData-View-107")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ViewPtagRawDataSuite), "TC-J1-FVT-PtagRawData-View-107")]
        public void VerifyUOMChangeSuccessWhenDiffUOMTagChange(PtagData input)
        {
            //Navigate to Raw Data tab, Select a tag that UOM is KWH
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            TimeManager.LongPause();
            PTagRawData.SwitchToRawDataTab();
            TimeManager.LongPause();
            //The UOM display with KWH is grid view.
            Assert.AreEqual(PTagRawDataGrid.GetUomInRawDataGrid(), input.InputData.Uoms[0]);
            TimeManager.LongPause();

            //Select another tag that UOM is ton.
            PTagSettings.FocusOnPTagByName("Ptag_LR_Coal1");
            PTagRawData.SwitchToRawDataTab();
            TimeManager.LongPause();

            //The UOM display with Ton accordingly.
            Assert.AreEqual(PTagRawDataGrid.GetUomInRawDataGrid(), input.InputData.Uoms[1]);

        }

    }
}
