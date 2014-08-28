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
    [ManualCaseID("TC-J1-FVT-PtagRawData-DiffValueCalc")]
    public class DiffValueCalcPtagRawDataSuite : TestSuiteBase
    {
        private PTagSettings PTagSettings = JazzFunction.PTagSettings;
        private PTagRawData PTagRawData = JazzFunction.PTagRawData;
        private static Chart PTagRawDataLineChart = JazzChart.PTagRawDataLineChart;
        private static Grid PTagRawDataGrid = JazzGrid.GridPTagRawData;
        private static TextField PtagRawDataValueNumberField = JazzTextField.PtagRawDataValueTextField;

        [SetUp]
        public void CaseSetUp()
        {
            PTagSettings.NavigatorToPtagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-DifferenceValueCalculation-101")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(DiffValueCalcPtagRawDataSuite), "TC-J1-FVT-DifferenceValueCalculation-101")]
        public void DifferenceValueCalcWithoutNullValue(PtagData input)
        {
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();

            //Set the time range to 2014-1-1 00:00 to 2014-1-7 24:00
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Switch button when it is Original Value now.  
            PTagRawData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Switch to Difference Value and display them in both Line Chart and Grid View. Verify the Difference Value is correct.
            Assert.AreEqual("20", PTagRawDataGrid.GetCellValue(2));
            Assert.AreEqual("23", PTagRawDataGrid.GetCellValue(3));
            Assert.AreEqual("19", PTagRawDataGrid.GetCellValue(4));
            Assert.AreEqual("38", PTagRawDataGrid.GetCellValue(5));
            Assert.AreEqual("19", PTagRawDataGrid.GetCellValue(6));

            //Go Energy Usage Analysis, select the tag and check Raw step.
            //Verify the data list in Raw step is the same as Difference Value as this tag is accumulated tag.
            //..............?
            
        }

        [Test]
        [CaseID("TC-J1-FVT-DifferenceValueCalculation-102")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(DiffValueCalcPtagRawDataSuite), "TC-J1-FVT-DifferenceValueCalculation-102")]
        public void DifferenceValueCalcWithNullValue(PtagData input)
        {
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();

            //Set the time range to 2014-1-2 00:00 to 2014-1-8 24:00
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Switch button when it is Original Value now.  
            PTagRawData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Switch to Difference Value and display them in both Line Chart and Grid View. Verify the Difference Value is correct.
            Assert.AreEqual("20", PTagRawDataGrid.GetCellValue(2));
            Assert.AreEqual("42", PTagRawDataGrid.GetCellValue(3));
            Assert.AreEqual("", PTagRawDataGrid.GetCellValue(4));
            Assert.AreEqual("38", PTagRawDataGrid.GetCellValue(5));
            Assert.AreEqual("19", PTagRawDataGrid.GetCellValue(6));

            //Go Energy Usage Analysis, select the tag and check Raw step.
            //Verify the data list in Raw step is the same as Difference Value as this tag is accumulated tag.
            //..............?
        }

        [Test]
        [CaseID("TC-J1-FVT-DifferenceValueCalculation-103")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(DiffValueCalcPtagRawDataSuite), "TC-J1-FVT-DifferenceValueCalculation-103")]
        public void DifferenceValueCalcWhenMeterReachesMaxValue(PtagData input)
        {
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();
            TimeManager.LongPause();

            //Set the time range to 2014-1-3 00:00 to 2014-1-9 24:00
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click Switch button when it is Original Value now.  
            PTagRawData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Switch to Difference Value and display them in both Line Chart and Grid View. Verify the Difference Value in  2014-1-1 00:15 is Null as the meter reaches its max value.
            Assert.AreEqual("100", PTagRawDataGrid.GetCellValue(2));
            Assert.AreEqual("", PTagRawDataGrid.GetCellValue(3));
            Assert.AreEqual("100", PTagRawDataGrid.GetCellValue(4));
            Assert.AreEqual("100", PTagRawDataGrid.GetCellValue(5));

            //Go Energy Usage Analysis, select the tag and check Raw step.
            //Verify the data list in Raw step is the same as Difference Value as this tag is accumulated tag.
            //..............?

        }

    }
}
