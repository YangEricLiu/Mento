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
            PTagSettings.PTagSettingCaseSetUp();
        }

        [TearDown]
        public void CaseTearDown()
        {
            PTagSettings.PTagSettingCaseTearDown();
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

            //Check the line chart and rawdata grid exist
            Assert.IsTrue(PTagRawData.IsExisted(JazzControlLocatorKey.ChartPTagRawData));
            Assert.IsTrue(PTagRawData.IsExisted(JazzControlLocatorKey.GridPTagRawData));

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
            PTagRawDataGrid.FocusOnCell(4);
            TimeManager.LongPause();

            //Click "Save" button
            PTagRawData.ClickSaveRawDataButton();
            TimeManager.LongPause();

            //Verify the value 
            Assert.AreEqual("1", PTagRawDataGrid.GetCellValue(2));
            Assert.AreEqual("2", PTagRawDataGrid.GetCellValue(3));

            //Verify if the relevant Status fields as Modified.
            Assert.AreEqual(input.InputData.Comments, PTagRawDataGrid.GetCellStatus(2));
            Assert.AreEqual(input.InputData.Comments, PTagRawDataGrid.GetCellStatus(3));
        
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

            //Set time range
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Click a row and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(4);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("3");

            //Change Start Time or End Time with there is any modified field.
            PTagRawData.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            TimeManager.LongPause();

            //Click "Save and Switch" button in popup warning message with two options: Save and switch, Directly switch.
            PTagRawData.ClickSaveAndSwitchButton();
            TimeManager.LongPause();

            //Save the unsaved modifications into database and then go ahead with querying data
            Assert.AreEqual("3", PTagRawDataGrid.GetCellValue(4));

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

            //Set time range
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Click and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(3);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("4.1");
            TimeManager.LongPause();

            //Change Start Time or End Time with there is any modified field.
            PTagRawData.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            TimeManager.LongPause();

            //Click 'Directly switch' button
            PTagRawData.ClickDirectlySwitchButton();
            TimeManager.LongPause();

            //Discard the unsaved modifications will keep the original value in those cell and go ahead with querying data directly
            Assert.AreNotEqual("4.1", PTagRawDataGrid.GetCellValue(3));

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

            //Set time range
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Click a row and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(6);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("5");

            //Change Start Time or End Time with there is any modified field. Click "Close" button in pop up dialog.
            PTagRawData.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            TimeManager.LongPause();
            PTagRawData.CloseSwitchTimeWindow();
            TimeManager.LongPause();

            //The Save & QueryAndQueryDirectly Window can be closed correctly.The time will return to the prior without modification.
            Assert.AreEqual(ManualTimeRange[0].StartDate, PTagRawData.GetBaseStartDateValue());
            Assert.AreEqual(ManualTimeRange[0].EndDate, PTagRawData.GetBaseEndDateValue());
            Assert.AreEqual(ManualTimeRange[0].StartTime, PTagRawData.GetBaseStartTimeValue());
            Assert.AreEqual(ManualTimeRange[0].EndTime, PTagRawData.GetBaseEndTimeValue());

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

            PTagRawData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();
            Assert.AreEqual(false, PTagRawDataGrid.IsCellEdit(3));


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
            TimeManager.LongPause();

            //Set time range = 2014年01月02日00点00分-2014年01月08日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Click and input two valid modified value.
            PTagRawDataGrid.FocusOnCell(7);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("6");
            TimeManager.LongPause();

            PTagRawDataGrid.FocusOnCell(8);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("7");
            TimeManager.LongPause();

            PTagRawDataGrid.FocusOnCell(6);
            TimeManager.LongPause();

            //Click Switch button in Original Value now
            PTagRawData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();
            Assert.AreEqual("1", PTagRawDataGrid.GetCellValue(8));

            //Click Left button to change display time range
            PTagRawData.ClickLeftButton();
            TimeManager.LongPause();

            //Modify one cell under Value Column
            PTagRawDataGrid.FocusOnCell(9);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("8");
            TimeManager.LongPause();

            //Go to veify Save button can be used success
            PTagRawData.ClickSaveRawDataButton();
            TimeManager.LongPause();
            Assert.AreEqual("8", PTagRawDataGrid.GetCellValue(9));

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
            TimeManager.LongPause();

            //Set time range = 2014年01月05日00点00分-2014年01月08日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Get the original value
            string originalValue = PTagRawDataGrid.GetCellValue(2);

            //Click the a row and input a valid modified value.
            PTagRawDataGrid.FocusOnCell(2);
            TimeManager.LongPause();
            PtagRawDataValueNumberField.Fill("1.11");

            //check change value as modified.
            PTagRawDataGrid.FocusOnCell(3);
            TimeManager.ShortPause();
            Assert.AreEqual("1.11",PTagRawDataGrid.GetCellValue(2));

            //Click Cancel icons in gird view to cancel the modifications.
            PTagRawDataGrid.ClickDeleteXBtnInRowDataGrid(2);
            TimeManager.LongPause();

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

            //Set time range = 2014年01月06日00点00分-2014年01月08日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
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
            PtagRawDataValueNumberField.Fill(" ");
            PTagRawData.ClickSaveRawDataButton();
            TimeManager.LongPause();

            //The value can be saved in database successfully and without any error
            Assert.AreEqual(" ", PTagRawDataGrid.GetCellValue(6));
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Switch to a tag that is not associate of any hierarchy node
            PTagSettings.FocusOnPTagByName("PTag_AutomationTest");
            TimeManager.LongPause();
            PTagRawData.SwitchToRawDataTab();
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

            //Set time range = 2014年01月12日00点00分-2014年01月13日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Get original value
            String originalString1 = PTagRawDataGrid.GetCellValue(2);
            String originalString2 = PTagRawDataGrid.GetCellValue(3);
            String originalString3 = PTagRawDataGrid.GetCellValue(4);

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
            TimeManager.LongPause();

            //Those modifications can be cancel successfully, the value will keep originals
            Assert.AreEqual(originalString1, PTagRawDataGrid.GetCellValue(2));
            Assert.AreEqual(originalString2, PTagRawDataGrid.GetCellValue(3));
            Assert.AreEqual(originalString3, PTagRawDataGrid.GetCellValue(4));

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

            //Set time range = 2014年01月20日00点00分-2014年01月21日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            PTagRawData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            PTagRawData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Click one row and input invalid modified value.
            PTagRawDataGrid.FocusOnCell(2);
            TimeManager.ShortPause();
            PtagRawDataValueNumberField.Fill("invalid123");
            TimeManager.ShortPause();

            //Will showing error message and current value cannot be saved
            Assert.AreNotEqual("invalid123", PTagRawDataGrid.GetCellValue(2));

        }

    }
}
