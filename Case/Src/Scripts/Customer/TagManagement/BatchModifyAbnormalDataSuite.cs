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
    [CreateTime("2015-1-6")]
    [ManualCaseID("TC-J1-FVT-AbnormalData-BatchModify")]
    public class BatchModifyAbnormalDataSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-AbnormalData-BatchModify-101")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchModifyAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchModify-101")]
        public void ModifyAndSaveViaSaveButtonAboveLineChart(AbnormalRecordData input)
        {
            //Check the checkbox of some abnormal records
            AbnormalData.CheckRecordsByTagName(input.InputData.TagNames[0]);
            TimeManager.FlashPause();
            AbnormalData.CheckRecordsByTagName(input.InputData.TagNames[1]);
            TimeManager.FlashPause();

            //Click 批量操作 button.
            AbnormalData.ClickBatchOperationButton();
            TimeManager.FlashPause();

            //Check .Pop up a dropdown list with ”修改“,”修改撤回“,”忽略“.
            AbnormalData.IsExisted(input.InputData.TestData[0]);
            AbnormalData.IsExisted(input.InputData.TestData[1]);
            AbnormalData.IsExisted(input.InputData.TestData[2]);

            //Select 修改 item.
            AbnormalData.ClickBatchModifyButton();
            TimeManager.FlashPause();

            //
            //Navigate to Raw Data tab
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            //Set time range = 2014年01月01日00点00分-2014年1月7日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Check the line chart and rawdata grid exist
            Assert.IsTrue(AbnormalData.IsExisted(JazzControlLocatorKey.ChartVEERawData));
            Assert.IsTrue(AbnormalData.IsExisted(JazzControlLocatorKey.GridVEERawData));

            //Click the first row (2014年01月01日00点00分-00点15分), and input a valid modified value.
            VEERawDataGrid.FocusOnCell(3);
            TimeManager.LongPause();
            VEERawDataValueNumberField.Fill("1");
            TimeManager.LongPause();

            //Click another row (The second row:2014年01月01日00点15分-00点30分), and input a valid modified value.
            VEERawDataGrid.FocusOnCell(4);
            TimeManager.LongPause();
            VEERawDataValueNumberField.Fill("2");
            TimeManager.LongPause();
            VEERawDataGrid.FocusOnCell(5);
            TimeManager.LongPause();

            //Click "Save" button
            AbnormalData.ClickSaveRawDataButton();
            TimeManager.LongPause();

            //Verify the value 
            Assert.AreEqual("1", VEERawDataGrid.GetCellValue(3));
            Assert.AreEqual("2", VEERawDataGrid.GetCellValue(4));

            //Verify if the relevant Status fields as Modified.
            Assert.AreEqual(input.InputData.Comments, VEERawDataGrid.GetCellStatus(3));
            Assert.AreEqual(input.InputData.Comments, VEERawDataGrid.GetCellStatus(4));

        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchModify-102")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchModifyAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchModify-102")]
        public void SaveAndQueryWhenContainsNotSavedModifications(AbnormalRecordData input)
        {
            //Navigate to Raw Data tab
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            //Set time range = 2014年1月2日00点00分-2014年1月2日24点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Click a row and input a valid modified value.
            VEERawDataGrid.FocusOnCell(5);
            TimeManager.LongPause();
            VEERawDataValueNumberField.Fill("3");

            //Change Start Time or End Time with there is any modified field.
            AbnormalData.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            TimeManager.LongPause();

            //Click "Save and Switch" button in popup warning message with two options: Save and switch, Directly switch.
            AbnormalData.ClickSaveAndSwitchButton();
            TimeManager.LongPause();

            //Save the unsaved modifications into database and then go ahead with querying data
            Assert.AreEqual("3", VEERawDataGrid.GetCellValue(5));

        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchModify-103")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchModifyAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchModify-103")]
        public void QueryDirectlyWhenContainsNotSavedModifications(AbnormalRecordData input)
        {
            //Navigate to Raw Data tab
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            //Set time range = 2014年1月3日1点00分-2014年1月3日2点00分
            var ManualTimeRange = input.InputData.ManualTimeRange;
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Click and input a valid modified value.
            VEERawDataGrid.FocusOnCell(4);
            TimeManager.LongPause();
            VEERawDataValueNumberField.Fill("4.4");
            TimeManager.LongPause();

            //Change Start Time or End Time with there is any modified field.
            AbnormalData.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            TimeManager.LongPause();

            //Click 'Directly switch' button
            AbnormalData.ClickDirectlySwitchButton();
            TimeManager.LongPause();

            //Discard the unsaved modifications will keep the original value in those cell and go ahead with querying data directly
            Assert.AreNotEqual("4.4", VEERawDataGrid.GetCellValue(4));

        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchModify-104")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchModifyAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchModify-104")]
        public void VerifyCloseButtonInSaveAndQueryAndQueryDirectlyWindow(AbnormalRecordData input)
        {
            //Navigate to Raw Data tab
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            //Set time range
            var ManualTimeRange = input.InputData.ManualTimeRange;
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Click a row and input a valid modified value.
            VEERawDataGrid.FocusOnCell(6);
            TimeManager.LongPause();
            VEERawDataValueNumberField.Fill("5");

            //Change Start Time or End Time with there is any modified field. Click "Close" button in pop up dialog.
            AbnormalData.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            TimeManager.LongPause();
            AbnormalData.ClickCancelSwitchButton();
            TimeManager.LongPause();

            //The Save & QueryAndQueryDirectly Window can be closed correctly.The time will return to the prior without modification.
            Assert.AreEqual(ManualTimeRange[0].StartDate, AbnormalData.GetBaseStartDateValue());
            Assert.AreEqual(ManualTimeRange[0].EndDate, AbnormalData.GetBaseEndDateValue());
            Assert.AreEqual(ManualTimeRange[0].StartTime, AbnormalData.GetBaseStartTimeValue());
            Assert.AreEqual(ManualTimeRange[0].EndTime, AbnormalData.GetBaseEndTimeValue());

        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchModify-105")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchModifyAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchModify-105")]
        public void VerifyDifferenceValueNotEditable(AbnormalRecordData input)
        {
            //Navigate to Raw Data tab
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            AbnormalData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();
            Assert.AreEqual(false, VEERawDataGrid.IsCellEdit(4));
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchModify-106")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchModifyAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchModify-106")]
        public void VerifyDifferenceValueChangedAccordinglyAfterOriginalValueModified(AbnormalRecordData input)
        {
            //Navigate to Raw Data tab
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            //Set time range
            var ManualTimeRange = input.InputData.ManualTimeRange;
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Click and input two valid modified value.
            VEERawDataGrid.FocusOnCell(8);
            TimeManager.LongPause();
            VEERawDataValueNumberField.Fill("6");
            TimeManager.LongPause();

            VEERawDataGrid.FocusOnCell(9);
            TimeManager.LongPause();
            VEERawDataValueNumberField.Fill("7");
            TimeManager.LongPause();

            VEERawDataGrid.FocusOnCell(7);
            TimeManager.LongPause();

            //Click Switch button in Original Value now
            AbnormalData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();
            Assert.AreEqual("1", VEERawDataGrid.GetCellValue(9));

            //Click Left button to change display time range
            AbnormalData.ClickLeftButton();
            TimeManager.LongPause();

            //Modify one cell under Value Column
            VEERawDataGrid.FocusOnCell(10);
            TimeManager.LongPause();
            VEERawDataValueNumberField.Fill("8");
            TimeManager.LongPause();

            //Go to veify Save button can be used success
            AbnormalData.ClickSaveRawDataButton();
            TimeManager.LongPause();
            Assert.AreEqual("8", VEERawDataGrid.GetCellValue(10));
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchModify-109")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchModifyAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchModify-109")]
        public void ModifyDiffStatusCanBeSavedSuccess(AbnormalRecordData input)
        {
            //Navigate to Raw Data tab
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            //Set time range
            var ManualTimeRange = input.InputData.ManualTimeRange;
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Input the value from Null to valid status and click saved button
            VEERawDataGrid.FocusOnCell(7);
            TimeManager.LongPause();
            VEERawDataValueNumberField.Fill("5");
            AbnormalData.ClickSaveRawDataButton();
            TimeManager.LongPause();

            //The value can be saved in database successfully and without any error
            Assert.AreEqual("5", VEERawDataGrid.GetCellValue(7));

            //Input the value from valid to Null status and click saved button
            VEERawDataGrid.FocusOnCell(7);
            TimeManager.LongPause();
            VEERawDataValueNumberField.Fill(" ");
            AbnormalData.ClickSaveRawDataButton();
            TimeManager.LongPause();

            //The value can be saved in database successfully and without any error
            Assert.AreEqual(" ", VEERawDataGrid.GetCellValue(7));
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Switch to a tag that is not associate of any hierarchy node
            AbnormalData.FocusOnRecordByName("PTag_AutomationTest");
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading(); 
            TimeManager.LongPause();

            //Modify the value of tag
            VEERawDataGrid.FocusOnCell(3);
            TimeManager.LongPause();
            VEERawDataValueNumberField.Fill("1");
            AbnormalData.ClickSaveRawDataButton();
            TimeManager.LongPause();

            //The value can be saved in database successfully and without any error
            Assert.AreEqual("1", VEERawDataGrid.GetCellValue(3));
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchModify-001")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchModifyAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchModify-001")]
        public void VerifyCancelIconInGirdView(AbnormalRecordData input)
        {
            //Navigate to Raw Data tab
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            //Set time range
            var ManualTimeRange = input.InputData.ManualTimeRange;
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Get the original value
            string originalValue = VEERawDataGrid.GetCellValue(3);

            //Click the a row and input a valid modified value.
            VEERawDataGrid.FocusOnCell(3);
            TimeManager.LongPause();
            VEERawDataValueNumberField.Fill("1.11");

            //check change value as modified.
            VEERawDataGrid.FocusOnCell(4);
            TimeManager.ShortPause();
            Assert.AreEqual("1.11", VEERawDataGrid.GetCellValue(3));

            //Click Cancel icons in gird view to cancel the modifications.
            VEERawDataGrid.ClickDeleteXBtnInRowDataGrid(3);
            TimeManager.LongPause();

            //The modifications can be cancel successfully, the value will keep original value
            Assert.AreEqual(originalValue, VEERawDataGrid.GetCellValue(3));
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchModify-002")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchModifyAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchModify-002")]
        public void VerifyCancelButtonAboveLineChart(AbnormalRecordData input)
        {
            //Navigate to Raw Data tab
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            //Set time range
            var ManualTimeRange = input.InputData.ManualTimeRange;
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Get original value
            String originalString1 = VEERawDataGrid.GetCellValue(3);
            String originalString2 = VEERawDataGrid.GetCellValue(4);
            String originalString3 = VEERawDataGrid.GetCellValue(5);

            //Modify multiple raw data records under Value Column.
            VEERawDataGrid.FocusOnCell(3);
            TimeManager.ShortPause();
            VEERawDataValueNumberField.Fill("1.1");
            TimeManager.ShortPause();

            VEERawDataGrid.FocusOnCell(4);
            TimeManager.ShortPause();
            VEERawDataValueNumberField.Fill("2.2");
            TimeManager.ShortPause();

            VEERawDataGrid.FocusOnCell(5);
            TimeManager.ShortPause();
            VEERawDataValueNumberField.Fill("3.3");
            TimeManager.ShortPause();

            //Click Cancel button above the line chart.
            AbnormalData.ClickCancelRawDataButton();
            TimeManager.LongPause();

            //Those modifications can be cancel successfully, the value will keep originals
            Assert.AreEqual(originalString1, VEERawDataGrid.GetCellValue(3));
            Assert.AreEqual(originalString2, VEERawDataGrid.GetCellValue(4));
            Assert.AreEqual(originalString3, VEERawDataGrid.GetCellValue(5));
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchModify-003")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchModifyAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchModify-003")]
        public void ModifyWithInvalidValues(AbnormalRecordData input)
        {
            //Navigate to Raw Data tab
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            //Set time range
            var ManualTimeRange = input.InputData.ManualTimeRange;
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();
            
            //Click one row and input invalid modified value.
            VEERawDataGrid.FocusOnCell(3);
            TimeManager.ShortPause();
            VEERawDataValueNumberField.Fill("invalid123");
            TimeManager.ShortPause();

            //Will showing error message and current value cannot be saved
            Assert.AreNotEqual("invalid123", VEERawDataGrid.GetCellValue(3));
        }
    }
}
