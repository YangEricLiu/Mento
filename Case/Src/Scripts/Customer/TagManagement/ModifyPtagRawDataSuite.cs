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

            //Click "Save" button
            PTagRawData.ClickSaveRawDataButton();

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
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();

            //Set time range = 2014年01月02日00点00分-2014年1月8日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Click the 3th row (2014年01月02日00点30分-00点45分), and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(input.InputData.RowID[0] + 1);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill(input.InputData.TestData[0]);

            //Change Start Time or End Time with there is any modified field.
            PTagRawData.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.LongPause();

            //Click "Save and Switch" button in popup warning message with two options: Save and switch, Directly switch.
            PTagRawData.ClickSaveAndSwitchButton();

            //Save the unsaved modifications into database and then go ahead with querying data.
            Assert.AreEqual(input.InputData.TestData[0], PTagRawDataGrid.GetCellValue(input.InputData.RowID[0] + 1));

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
            TimeManager.ShortPause();

            //Click the 4th row by default (2014年01月02日00点45分-01点00分), and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(input.InputData.RowID[0] + 1);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill(input.InputData.TestData[0]);

            //Change Start Time or End Time with there is any modified field.
            PTagRawData.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            //Click "DirectlySwitch" button in popup warning message with two options: Save and switch, Directly switch.
            PTagRawData.ClickDirectlySwitchButton();

            //Discard the unsaved modifications will keep the original value in those cell and go ahead with querying data directly.
            Assert.AreEqual(input.InputData.TestData[0], PTagRawDataGrid.GetCellValue(input.InputData.RowID[0] + 1));

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
            TimeManager.ShortPause();

            //Click the 5th row by default (2014年01月02日00点45分-01点00分), and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(input.InputData.RowID[0] + 1);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill(input.InputData.TestData[0]);

            //Change Start Time or End Time with there is any modified field.
            PTagRawData.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            //Click "DirectlySwitch" button in popup warning message with two options: Save and switch, Directly switch.
            PTagRawData.ClickCancelSwitchButton();

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

            //Click Switch button it is Original Value now

            //Click the 5th row by default (2014年01月02日00点45分-01点00分), and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(input.InputData.RowID[0] + 1);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill(input.InputData.TestData[0]);

            //Click "Save" button
            PTagRawData.ClickSaveRawDataButton();

            //Verify user can’t modify value if value is switched to Difference value
            Assert.AreNotEqual(input.InputData.TestData[0], PTagRawDataGrid.GetCellValue(input.InputData.RowID[0] + 1));

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
            TimeManager.ShortPause();

            //Click and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(input.InputData.RowID[0] + 1);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill(input.InputData.TestData[0]);

            //Click Switch button in Original Value now

            //Click Left button to change display time range
            TimeManager.ShortPause();

            //Modify one cell under Value Column

            //Go to veify Save button can be used success


        }

        [Test]
        [CaseID("TC-J1-FVT-PtagRawData-Modify-107")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyPtagRawDataSuite), "TC-J1-FVT-PtagRawData-Modify-107")]
        public void VerifyModifyHistoryInformation(PtagData input)
        {
            //Navigate to Raw Data tab
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagRawData.SwitchToRawDataTab();

            //Set time range = 2014年01月02日00点00分-2014年1月8日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //Click the 5th row by default (2014年01月02日00点45分-01点00分), and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(6);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("5");

            //Change Start Time or End Time with there is any modified field.
            PTagRawData.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            //Click "DirectlySwitch" button in popup warning message with two options: Save and switch, Directly switch.
            PTagRawData.ClickCancelSwitchButton();

            //Discard the unsaved modifications will keep the original value in those cell and go ahead with querying data directly.
            Assert.AreEqual("4", PTagRawDataGrid.GetCellValue(5));

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
            TimeManager.ShortPause();

            //Click the 5th row by default (2014年01月02日00点45分-01点00分), and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(6);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("5");

            //Change Start Time or End Time with there is any modified field.
            PTagRawData.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            //Click "DirectlySwitch" button in popup warning message with two options: Save and switch, Directly switch.
            PTagRawData.ClickCancelSwitchButton();

            //Discard the unsaved modifications will keep the original value in those cell and go ahead with querying data directly.
            Assert.AreEqual("4", PTagRawDataGrid.GetCellValue(5));

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
            TimeManager.ShortPause();

            //Click the 5th row by default (2014年01月02日00点45分-01点00分), and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(6);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("5");

            //Change Start Time or End Time with there is any modified field.
            PTagRawData.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            //Click "DirectlySwitch" button in popup warning message with two options: Save and switch, Directly switch.
            PTagRawData.ClickCancelSwitchButton();

            //Discard the unsaved modifications will keep the original value in those cell and go ahead with querying data directly.
            Assert.AreEqual("4", PTagRawDataGrid.GetCellValue(5));

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
            TimeManager.ShortPause();

            //Click the 5th row by default (2014年01月02日00点45分-01点00分), and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(6);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("5");

            //Change Start Time or End Time with there is any modified field.
            PTagRawData.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            //Click "DirectlySwitch" button in popup warning message with two options: Save and switch, Directly switch.
            PTagRawData.ClickCancelSwitchButton();

            //Discard the unsaved modifications will keep the original value in those cell and go ahead with querying data directly.
            Assert.AreEqual("4", PTagRawDataGrid.GetCellValue(5));

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
            TimeManager.ShortPause();

            //Click the 5th row by default (2014年01月02日00点45分-01点00分), and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(6);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("5");

            //Change Start Time or End Time with there is any modified field.
            PTagRawData.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            TimeManager.ShortPause();

            //Click "DirectlySwitch" button in popup warning message with two options: Save and switch, Directly switch.
            PTagRawData.ClickCancelSwitchButton();

            //Discard the unsaved modifications will keep the original value in those cell and go ahead with querying data directly.
            Assert.AreEqual("4", PTagRawDataGrid.GetCellValue(5));

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
