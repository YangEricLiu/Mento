﻿using System;
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
    [CreateTime("2014-08-18")]
    [ManualCaseID("TC-J1-FVT-PtagRawData-Modify")]
    public class ModifyPtagRawDataSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-PtagRawData-Modify-101")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyPtagRawDataSuite), "TC-J1-FVT-PtagRawData-Modify-101")]
        public void ModifyAndSaveViaSaveButtonAboveLineChart(PtagData input)
        {
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();
            TimeManager.ShortPause();

            //Set time range = 2014年01月01日00点00分-2014年1月7日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Check the line chart and rawdata grid exist
            //Assert.IsTrue(PTagRawData.IsExisted(JazzControlLocatorKey.ChartPTagRawData));
            //Assert.IsTrue(PTagRawData.IsExisted(JazzControlLocatorKey.GridPTagRawData));

            //Click the first row (2014年01月01日00点00分-00点15分), and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(2);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("1");
            TimeManager.LongPause();

            //Click another row (The second row:2014年01月01日00点15分-00点30分), and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(3);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("2");
            TimeManager.LongPause();

            //Click "Save" button
            PTagRawData.ClickSaveRawDataButton();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Verify the value 
            Assert.AreEqual("1", PTagRawDataGrid.GetCellValue(2));
            Assert.AreEqual("2", PTagRawDataGrid.GetCellValue(3));

            //Verify if the relevant Status fields as Modified.
            Assert.AreEqual("已修改", PTagRawDataGrid.GetCellStatus(2));
            Assert.AreEqual("已修改", PTagRawDataGrid.GetCellStatus(3));
        
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagRawData-Modify-102")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyPtagRawDataSuite), "TC-J1-FVT-PtagRawData-Modify-102")]
        public void SaveAndSwitchWhenContainsNotSavedModifications(PtagData input)
        {
            int[] RowID = new int[] {3};
            string[] TestData = new string[] {"3"};

            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();

            //Set time range = 2014年01月02日00点00分-2014年1月8日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click the 3th row (2014年01月02日00点30分-00点45分), and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(RowID[0] + 1);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill(TestData[0]);

            //Change Start Time or End Time with there is any modified field.
            PTagRawData.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            TimeManager.LongPause();

            //Click "Save and Switch" button in popup warning message with two options: Save and switch, Directly switch.
            PTagRawData.ClickSaveAndSwitchButton();
            TimeManager.LongPause();

            //Save the unsaved modifications into database and then go ahead with querying data.
            Assert.AreEqual(TestData[0], PTagRawDataGrid.GetCellValue(RowID[0] + 1));

        }

        [Test]
        [CaseID("TC-J1-FVT-PtagRawData-Modify-103")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyPtagRawDataSuite), "TC-J1-FVT-PtagRawData-Modify-103")]
        public void DirectlySwitchWhenContainsNotSavedModifications(PtagData input)
        {
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();

            //Set time range = 2014年01月02日00点00分-2014年1月8日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();
            TimeManager.LongPause();
           
            //Click the 4th row by default (2014年01月02日00点45分-01点00分), and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(input.InputData.RowID[0] + 1);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill(input.InputData.TestData[0]);
            TimeManager.LongPause();

            //Change Start Time or End Time with there is any modified field.
            PTagRawData.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            TimeManager.LongPause();

            //Click "DirectlySwitch" button in popup warning message with two options: Save and switch, Directly switch.
            PTagRawData.ClickDirectlySwitchButton();
            TimeManager.LongPause();

            //Discard the unsaved modifications will keep the original value in those cell and go ahead with querying data directly.
            Assert.AreNotEqual(input.InputData.TestData[0], PTagRawDataGrid.GetCellValue(input.InputData.RowID[0] + 1));

        }

        [Test]
        [CaseID("TC-J1-FVT-PtagRawData-Modify-104")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyPtagRawDataSuite), "TC-J1-FVT-PtagRawData-Modify-104")]
        public void VerifyCloseButtonInSaveAndQueryAndQueryDirectlyWindow(PtagData input)
        {
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();

            //Set time range = 2014年01月02日00点00分-2014年1月8日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click the 5th row by default (2014年01月02日00点45分-01点00分), and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(input.InputData.RowID[0] + 1);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill(input.InputData.TestData[0]);
            TimeManager.LongPause();

            //Change Start Time or End Time with there is any modified field.
            PTagRawData.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            TimeManager.LongPause();

            //Click "DirectlySwitch" button in popup warning message with two options: Save and switch, Directly switch.
            PTagRawData.ClickCancelSwitchButton();
            TimeManager.LongPause();

            //Discard the unsaved modifications will keep the original value in those cell and go ahead with querying data directly.
            Assert.AreNotEqual(input.InputData.TestData[0], PTagRawDataGrid.GetCellValue(input.InputData.RowID[0] + 1));

        }

        [Test]
        [CaseID("TC-J1-FVT-PtagRawData-Modify-105")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyPtagRawDataSuite), "TC-J1-FVT-PtagRawData-Modify-105")]
        public void VerifyDifferenceValueNotEditable(PtagData input)
        {
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();
            TimeManager.LongPause();

            //Click Switch button it is Original Value now
            //if (PTagRawDataGrid.GetCellValue(1) == "能耗累积值/千瓦时")
                PTagRawData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();

            //Click the one row and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(2);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("22");
            TimeManager.LongPause();

            //Click "Save" button
            PTagRawData.ClickSaveRawDataButton();
            TimeManager.LongPause();

            //Verify user can’t modify value if value is switched to Difference value
            Assert.AreNotEqual("22", PTagRawDataGrid.GetCellValue(2));

        }

        [Test]
        [CaseID("TC-J1-FVT-PtagRawData-Modify-106")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyPtagRawDataSuite), "TC-J1-FVT-PtagRawData-Modify-106")]
        public void VerifyDifferenceValueChangedAccordinglyAfterOriginalValueModified(PtagData input)
        {
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();

            //Set time range = 2014年01月02日00点00分-2014年1月8日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(7);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("6");

            //Click Switch button in Original Value now
            //if (PTagRawDataGrid.GetCellValue(1) == "能耗累积值/千瓦时")
                PTagRawData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();
            
            //Click Left button to change display time range
            PTagRawData.ClickLeftButton();
            TimeManager.LongPause();

            //Modify one cell under Value Column
            PTagRawDataGrid.FocusOnCell(2);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("1");

            //Go to veify Save button can be used success
            PTagRawData.ClickSaveRawDataButton();
            TimeManager.LongPause();
            Assert.AreEqual("1", PTagRawDataGrid.GetCellValue(2));

        }

        [Test]
        [CaseID("TC-J1-FVT-PtagRawData-Modify-001")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyPtagRawDataSuite), "TC-J1-FVT-PtagRawData-Modify-001")]
        public void VerifyCancelIconInGirdView(PtagData input)
        {
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();

            //Set time range = 2014年01月02日00点00分-2014年1月8日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Get the original value
            string originalValue = PTagRawDataGrid.GetCellValue(2);

            //Click the 5th row by default (2014年01月02日00点45分-01点00分), and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(2);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("1.11");

            //check change value as modified.
            TimeManager.ShortPause();
            Assert.AreEqual("1.11",PTagRawDataGrid.GetCellValue(2));

            //Click Cancel icons in gird view to cancel the modifications.
            PTagRawDataGrid.ClickDeleteRowXButton(2,"");

            //The modifications can be cancel successfully, the value will keep original value
            Assert.AreEqual(originalValue, PTagRawDataGrid.GetCellValue(2));

        }

        [Test]
        [CaseID("TC-J1-FVT-PtagRawData-Modify-110")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyPtagRawDataSuite), "TC-J1-FVT-PtagRawData-Modify-110")]
        public void ModifyDiffStatusCanBeSavedSuccess(PtagData input)
        {
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();

            //Set time range = 2014年01月02日00点00分-2014年1月8日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Input the value from Null to valid status and click saved button
            PTagRawDataGrid.FocusOnCell(6);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("5");
            PTagRawData.ClickSaveRawDataButton();
            TimeManager.LongPause();

            //The value can be saved in database successfully and without any error
            Assert.AreEqual("5", PTagRawDataGrid.GetCellValue(6));

            //Input the value from valid to Null status and click saved button
            PTagRawDataGrid.FocusOnCell(6);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("");
            PTagRawData.ClickSaveRawDataButton();
            TimeManager.LongPause();

            //The value can be saved in database successfully and without any error
            Assert.AreEqual("", PTagRawDataGrid.GetCellValue(6));

            //Switch to a tag that is not associate of any hierarchy node
            PTagSettings.FocusOnPTagByName("PTag_AutomationTest");
            PTagRawData.SwitchToRawDataTab();

            //Set time range = 2014年01月02日00点00分-2014年1月8日24点00分
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Modify the value of tag
            PTagRawDataGrid.FocusOnCell(2);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("1");
            PTagRawData.ClickSaveRawDataButton();
            TimeManager.LongPause();

            //The value can be saved in database successfully and without any error
            Assert.AreEqual("1", PTagRawDataGrid.GetCellValue(2));

        }

        [Test]
        [CaseID("TC-J1-FVT-PtagRawData-Modify-002")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyPtagRawDataSuite), "TC-J1-FVT-PtagRawData-Modify-002")]
        public void VerifyCancelButtonAboveLineChart(PtagData input)
        {
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();

            //Set time range = 2014年01月02日00点00分-2014年1月8日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Get original value
            String[] originalStrings = new string[] { };
            originalStrings[0] = PTagRawDataGrid.GetCellValue(2);
            originalStrings[1] = PTagRawDataGrid.GetCellValue(3);
            originalStrings[2] = PTagRawDataGrid.GetCellValue(4);

            //Modify multiple raw data records under Value Column.
            PTagRawDataGrid.FocusOnCell(2);
            TimeManager.ShortPause();
            PtagRawDataValueNumberField.Fill("1.1");
            TimeManager.ShortPause();

            PTagRawDataGrid.FocusOnCell(3);
            TimeManager.ShortPause();
            PtagRawDataValueNumberField.Fill("2.2");
            TimeManager.ShortPause();

            PTagRawDataGrid.FocusOnCell(4);
            TimeManager.ShortPause();
            PtagRawDataValueNumberField.Fill("3.3");
            TimeManager.ShortPause();

            //Click Cancel button above the line chart.
            PTagRawData.ClickCancelRawDataButton();

            //Those modifications can be cancel successfully, the value will keep originals
            Assert.AreEqual(originalStrings[0], PTagRawDataGrid.GetCellValue(2));
            Assert.AreEqual(originalStrings[1], PTagRawDataGrid.GetCellValue(3));
            Assert.AreEqual(originalStrings[2], PTagRawDataGrid.GetCellValue(4));

        }

        [Test]
        [CaseID("TC-J1-FVT-PtagRawData-Modify-003")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyPtagRawDataSuite), "TC-J1-FVT-PtagRawData-Modify-003")]
        public void ModifyWithInvalidValues(PtagData input)
        {
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();

            //Set time range = 2014年01月02日00点00分-2014年1月8日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click one row and input invalid modified value.
            PTagRawDataGrid.FocusOnCell(2);
            TimeManager.ShortPause();
            PtagRawDataValueNumberField.Fill("invalid123");
            TimeManager.ShortPause();

            //Will showing error message and current value cannot be saved
            Assert.AreNotEqual("invalid123", PTagRawDataGrid.GetCellValue(2));

        }

        [Test]
        [CaseID("TC-J1-FVT-PtagRawData-Modify-test")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyPtagRawDataSuite), "TC-J1-FVT-PtagRawData-Modify-102")]
        public void InputDataValueForPtagRaw(PtagData input)
        {
            PTagSettings.FocusOnPTagByName("C1Org1Build1_ptag1");
            PTagRawData.SwitchToRawDataTab();

            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            PTagRawDataGrid.FocusOnCell(2);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("5");

            //Click "Save" button
            PTagRawData.ClickSaveRawDataButton();

            Assert.AreEqual("5", PTagRawDataGrid.GetCellValue(2));
        }
    }
}
