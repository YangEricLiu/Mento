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
        private static BatchModifyDialog BatchModifyDialog = JazzFunction.BatchModifyDialog;

        private static RadioButton VEEAllDataRadioButton = JazzButton.VEEAllDataRadioButton;
        private static RadioButton VEEAbnormalRadioButton = JazzButton.VEEAbnormalRadioButton;
        private static RadioButton VEEModifyValueRadioButton = JazzButton.VEEModifyValueRadioButton;
        private static RadioButton VEEBackfillSourceRadioButton = JazzButton.VEEBackfillSourceRadioButton;

        private PTagSettings PTagSettings = JazzFunction.PTagSettings;
        private PTagRawData PTagRawData = JazzFunction.PTagRawData;

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
        [CaseID("TC-J1-FVT-AbnormalData-BatchModify-101"), ManualCaseID("TC-J1-FVT-AbnormalData-BatchModify-101")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchModifyAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchModify-101")]
        public void ModifyAndSaveViaSaveButtonAboveLineChart(AbnormalRecordData input)
        {
            //Check the checkbox of some abnormal records
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();
            AbnormalData.CheckRecordsByTagName(input.InputData.TagNames[0]);
            TimeManager.FlashPause();
            AbnormalData.CheckRecordsByTagName(input.InputData.TagNames[1]);
            TimeManager.FlashPause();

            //Click 批量操作 button.
            AbnormalData.ClickBatchOperationButton();
            TimeManager.FlashPause();

            //Check .Pop up a dropdown list with ”修改“,”修改撤回“,”忽略“.
            AbnormalData.IsExisted(JazzControlLocatorKey.ButtonVEEBatchModify);
            AbnormalData.IsExisted(JazzControlLocatorKey.ButtonVEEBatchRevert);
            AbnormalData.IsExisted(JazzControlLocatorKey.ButtonVEEBatchIgnore);

            //Select 修改 item.
            AbnormalData.ClickBatchModifyButton();
            TimeManager.FlashPause();

            //Check.Pop up a window name as "原始数据批量修改".
            Assert.AreEqual(input.InputData.TestData[3], BatchModifyDialog.GetTitle());

            //Check .TagA and tagB can be display in 已选源 part.

            //Check ."All data" is choose as default for "Abnormal type" and "Abnormal data record" radio button bottom can not list 5 checkboxs.
            Assert.IsTrue(VEEAllDataRadioButton.IsRadioButtonChecked());
            Assert.IsFalse(VEEAbnormalRadioButton.IsRadioButtonChecked());

            //Check .Backfill source display blank as default.
            Assert.IsTrue(VEEModifyValueRadioButton.IsRadioButtonChecked());
            Assert.AreEqual("", BatchModifyDialog.GetBackfillValue());

            //Choose a time range, such as 2014-1-1 00：00 to 2014-1-2 00：00
            var ManualTimeRange = input.InputData.ManualTimeRange;
            BatchModifyDialog.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            BatchModifyDialog.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Check The time can be select success.
            Assert.AreEqual(ManualTimeRange[0].StartDate, BatchModifyDialog.GetStartDateValue());
            Assert.AreEqual(ManualTimeRange[0].EndDate, BatchModifyDialog.GetEndDateValue());
            Assert.AreEqual(ManualTimeRange[0].StartTime, BatchModifyDialog.GetStartTimeValue());
            Assert.AreEqual(ManualTimeRange[0].EndTime, BatchModifyDialog.GetStartTimeValue());

            //Add modify value of 5 to input text field among "modify rule".
            BatchModifyDialog.FillInModifyValueTextField("5");

            //Click "modifyandsave"button.
            BatchModifyDialog.ClickModifyAndSaveButton();
            TimeManager.ShortPause();
            BatchModifyDialog.ClickMessageBoxModifyAndSaveButton();
            TimeManager.LongPause();

            //Check the abnormal record.
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //+The backfill value is difference value, so should check the difference value
            AbnormalData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();

            //+check record number is hours of time range * 4 
            for(int i = 0; i < 4; i++)
            {
                VEERawDataGrid.FocusOnCell(i + 3);
                TimeManager.MediumPause();
                Assert.AreEqual("5", VEERawDataValueNumberField.GetValue());
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchModify-102"), ManualCaseID("TC-J1-FVT-AbnormalData-BatchModify-102")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchModifyAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchModify-102")]
        public void VerifyForVtagRawDataCannotModify(AbnormalRecordData input)
        {
            //Click the checkbox of a record's time range that is Vtag.
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            //Click the input text field in grid and input a value for modify,then click save button
            VEERawDataGrid.FocusOnCell(3);
            TimeManager.LongPause();
            VEERawDataValueNumberField.Fill("3");

            AbnormalData.ClickSaveRawDataButton();
            TimeManager.LongPause();

            //Verify the data cannot be modify success.
            Assert.AreNotEqual("3", VEERawDataGrid.GetCellValue(3));

            //Select some ptags and vtags in checkbox.
            AbnormalData.CheckRecordsByTagName(input.InputData.TagNames[0]);
            TimeManager.FlashPause();
            AbnormalData.CheckRecordsByTagName(input.InputData.TagNames[1]);
            TimeManager.FlashPause();

            //Click 批量操作 button.
            AbnormalData.ClickBatchOperationButton();
            TimeManager.FlashPause();

            //Select 修改 item.
            AbnormalData.ClickBatchModifyButton();
            TimeManager.FlashPause();

            //Verify all ptags and vtags can be display proper in 已选源

            //+Choose a time range, such as 2014-1-1 00：00 to 2014-1-2 00：00
            var ManualTimeRange = input.InputData.ManualTimeRange;
            BatchModifyDialog.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            BatchModifyDialog.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //+Add modify value of 5 to input text field among "modify rule".
            BatchModifyDialog.FillInModifyValueTextField("5");

            //+Click "modifyandsave"button.
            BatchModifyDialog.ClickModifyAndSaveButton();
            TimeManager.ShortPause();
            BatchModifyDialog.ClickMessageBoxModifyAndSaveButton();
            TimeManager.LongPause();

            //.Verify ptags can be modify success.
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //+The backfill value is difference value, so should check the difference value
            AbnormalData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();

            //+check record number is hours of time range * 4 
            for (int i = 0; i < 4; i++)
            {
                VEERawDataGrid.FocusOnCell(i + 3);
                TimeManager.MediumPause();
                Assert.AreNotEqual("5", VEERawDataValueNumberField.GetValue());
            }

            //.Verify vtags value not change.
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[1]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //+The backfill value is difference value, so should check the difference value
            AbnormalData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();

            //+check record number is hours of time range * 4 
            for (int i = 0; i < 4; i++)
            {
                VEERawDataGrid.FocusOnCell(i + 3);
                TimeManager.MediumPause();
                Assert.AreEqual("5", VEERawDataValueNumberField.GetValue());
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchModify-103"), ManualCaseID("TC-J1-FVT-AbnormalData-BatchModify-103")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchModifyAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchModify-103")]
        public void SingleModifyReplaceByBatchModify(AbnormalRecordData input)
        {
            //Click the checkbox of a record's time range that is Ptag.
            AbnormalData.CheckRecordsByTagName(input.InputData.TagNames[0]);
            TimeManager.FlashPause();
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();

            //Modify time record is 2014-1-1 00:00-00:15
            var ManualTimeRange = input.InputData.ManualTimeRange;
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Click the input text field in grid and input a value 6 for modify without click save button
            VEERawDataGrid.FocusOnCell(3);
            TimeManager.LongPause();
            VEERawDataValueNumberField.Fill("6");
            TimeManager.LongPause();

            //Check .Value display in input text field
            Assert.AreNotEqual("6", VEERawDataGrid.GetCellValue(3));

            //Click 'Directly switch' button
            AbnormalData.ClickDirectlySwitchButton();
            TimeManager.LongPause();

            //Check some abnormal record's time ranges
            AbnormalData.CheckRecordsByTagName(input.InputData.TagNames[1]);
            TimeManager.FlashPause();

            //Click 批量操作 button and select 修改 item.
            AbnormalData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            AbnormalData.ClickBatchModifyButton();
            TimeManager.FlashPause();

            //Make sure 2014-1-1 00:00-00:15 record is abnormal data
            BatchModifyDialog.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            BatchModifyDialog.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Select time range for batch modify, click abnormal data for all data,click fixed value radio button and input value 5 for input field.
            BatchModifyDialog.FillInModifyValueTextField("5");

            //Click "修改并保存" button.
            BatchModifyDialog.ClickModifyAndSaveButton();
            TimeManager.ShortPause();
            BatchModifyDialog.ClickMessageBoxModifyAndSaveButton();
            TimeManager.LongPause();

            //--------------------Need update data-------------------------
            //Check 2014-1-1 00:00-00:15 value should be 5.
            for (int j = 0; j < 2; j++ )
            {
                AbnormalData.FocusOnRecordByName(input.InputData.TagNames[j]);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.ShortPause();
                AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
                AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
                TimeManager.LongPause();

                //+The backfill value is difference value, so should check the difference value
                AbnormalData.ClickSwitchDifferenceValueButton();
                TimeManager.LongPause();

                //+check record number is hours of time range * 4 
                for (int i = 0; i < 4; i++)
                {
                    VEERawDataGrid.FocusOnCell(i + 3);
                    TimeManager.MediumPause();
                    Assert.AreEqual("5", VEERawDataValueNumberField.GetValue());
                }
            }
                
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchModify-104"), ManualCaseID("TC-J1-FVT-AbnormalData-BatchModify-104")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchModifyAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchModify-104")]
        public void VerifyAddDataAndAverageBackFillValueModifyRule(AbnormalRecordData input)
        {
            //Click the checkbox of a record's time range that is Ptag.
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            AbnormalData.CheckRecordsByTagName(input.InputData.TagNames[0]);
            TimeManager.ShortPause();

            //Click 批量操作 button and select 修改 item.
            AbnormalData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            AbnormalData.ClickBatchModifyButton();
            TimeManager.FlashPause();

            //Select time range for batch modify
            var ManualTimeRange = input.InputData.ManualTimeRange;
            BatchModifyDialog.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            BatchModifyDialog.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //click abnormal data for "全部所选数据"//This select is by default
            //click average backfill modify radio button and select a backfill source.
            VEEBackfillSourceRadioButton.Click();
            TimeManager.FlashPause();
            BatchModifyDialog.InputBackfillSourceDate("2014-01-04");
            BatchModifyDialog.InputBackfillSourceTime("00:45");

            //Click "修改并保存" button.
            BatchModifyDialog.ClickModifyAndSaveButton();
            TimeManager.ShortPause();
            BatchModifyDialog.ClickMessageBoxModifyAndSaveButton();
            TimeManager.LongPause();

            //-------------Need update data------------------
            //.Verify all data in select time range canbe modify correct (include abnormal data and normal data) and the data not include in select time range cannot be modify success.
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //+The backfill value is difference value, so should check the difference value
            AbnormalData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();

            //+check record number is hours of time range * 4 
            for (int i = 0; i < 4; i++)
            {
                VEERawDataGrid.FocusOnCell(i + 3);
                TimeManager.MediumPause();
                Assert.AreEqual("5", VEERawDataValueNumberField.GetValue());
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchModify-105"), ManualCaseID("TC-J1-FVT-AbnormalData-BatchModify-105")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchModifyAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchModify-105")]
        public void VerifyNormalSpikeAbnormalSpkeAndFixedValueRule(AbnormalRecordData input)
        {
            //Click the checkbox of a record's time range that is Ptag.
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            AbnormalData.CheckRecordsByTagName(input.InputData.TagNames[0]);
            TimeManager.ShortPause();

            //Click 批量操作 button and select 修改 item.
            AbnormalData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            AbnormalData.ClickBatchModifyButton();
            TimeManager.FlashPause();

            //Select time range for batch modify
            var ManualTimeRange = input.InputData.ManualTimeRange;
            BatchModifyDialog.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            BatchModifyDialog.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //click abnormal data for "异常数据" radio button
            VEEAbnormalRadioButton.Click();
            TimeManager.FlashPause();

            //Select 正常峰，异常峰
            BatchModifyDialog.CheckAbnormalTypeCheckBox(input.InputData.AbnormalTypes[0]);
            TimeManager.FlashPause();
            BatchModifyDialog.CheckAbnormalTypeCheckBox(input.InputData.AbnormalTypes[1]);
            TimeManager.FlashPause();

            //click fixed value radio button and input value 5 for input field.
            BatchModifyDialog.FillInModifyValueTextField("5");

            //Click "修改并保存" button.
            BatchModifyDialog.ClickModifyAndSaveButton();
            TimeManager.ShortPause();
            BatchModifyDialog.ClickMessageBoxModifyAndSaveButton();
            TimeManager.LongPause();

            //Check Verify abnormal data can be modify to 5.
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //+The backfill value is difference value, so should check the difference value
            AbnormalData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();

            //+check record number is hours of time range * 4 
            for (int i = 0; i < 4; i++)
            {
                VEERawDataGrid.FocusOnCell(i + 3);
                TimeManager.MediumPause();
                Assert.AreEqual("5", VEERawDataValueNumberField.GetValue());
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchModify-106"), ManualCaseID("TC-J1-FVT-AbnormalData-BatchModify-106")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchModifyAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchModify-106")]
        public void VerifyNullNegativeSpecialAndAverageBackFillRule(AbnormalRecordData input)
        {
            //Click the checkbox of a record's time range that is Ptag.
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            AbnormalData.CheckRecordsByTagName(input.InputData.TagNames[0]);
            TimeManager.ShortPause();

            //Click 批量操作 button and select 修改 item.
            AbnormalData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            AbnormalData.ClickBatchModifyButton();
            TimeManager.FlashPause();

            //Select time range for batch modify
            var ManualTimeRange = input.InputData.ManualTimeRange;
            BatchModifyDialog.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            BatchModifyDialog.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //click abnormal data for "异常数据" radio button
            VEEAbnormalRadioButton.Click();
            TimeManager.FlashPause();

            //Select 空值，负值，特殊值
            BatchModifyDialog.CheckAbnormalTypeCheckBox(input.InputData.AbnormalTypes[0]);
            TimeManager.FlashPause();
            BatchModifyDialog.CheckAbnormalTypeCheckBox(input.InputData.AbnormalTypes[1]);
            TimeManager.FlashPause();
            BatchModifyDialog.CheckAbnormalTypeCheckBox(input.InputData.AbnormalTypes[2]);
            TimeManager.FlashPause();

            //Click average backfill modify radio button and select a backfill source.
            VEEBackfillSourceRadioButton.Click();
            TimeManager.FlashPause();
            BatchModifyDialog.InputBackfillSourceDate("2014-01-04");
            BatchModifyDialog.InputBackfillSourceTime("00:45");

            //Click "修改并保存" button.
            BatchModifyDialog.ClickModifyAndSaveButton();
            TimeManager.ShortPause();
            BatchModifyDialog.ClickMessageBoxModifyAndSaveButton();
            TimeManager.LongPause();

            //Check Verify abnormal data can be modify to success.
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //+The backfill value is difference value, so should check the difference value
            AbnormalData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();

            //---------------Need update data-----------------------
            //+check record number is hours of time range * 4 
            for (int i = 0; i < 4; i++)
            {
                VEERawDataGrid.FocusOnCell(i + 3);
                TimeManager.MediumPause();
                Assert.AreEqual("5", VEERawDataValueNumberField.GetValue());
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchModify-001"), ManualCaseID("TC-J1-FVT-AbnormalData-BatchModify-001")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchModifyAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchModify-001")]
        public void VerifyErrorMessageCheckInBatchModifyPage(AbnormalRecordData input)
        {
            //Switch 客户配置-数据点配置-计量数据P
            PTagSettings.NavigatorToPtagSetting();
            TimeManager.MediumPause();

            //Check some tags
            PTagSettings.FocusOnPTagByName(input.InputData.TagNames[0]);
            PTagSettings.CheckPTagByTagName(input.InputData.TagNames[0]);
            PTagSettings.CheckPTagByTagName(input.InputData.TagNames[1]);

            //Click raw data tab.
            PTagRawData.SwitchToRawDataTab();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //Click 批量操作 button and select 修改 item.
            PTagRawData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            PTagRawData.ClickBatchModifyButton();
            TimeManager.FlashPause();

            //Click close button near all tags in select tag source,//----------The "Modify and Save" button is gray out without any tag in select tag source
            //no select time range, //-------------time is blank by default
            //click abnormal data not check any checkbox,
            VEEAbnormalRadioButton.Click();
            //click fixed value radio button and without input any value for input field.//------------The radio button is checked by default, and the value is blank.

            //Click "modifyandsave"button.
            BatchModifyDialog.ClickModifyAndSaveButton();
            TimeManager.ShortPause();

            //Check error messages
            Assert.AreEqual(input.ExpectedData.Messages[0], BatchModifyDialog.GetTimeRangeTooltip());
            Assert.AreEqual(input.ExpectedData.Messages[1], BatchModifyDialog.GetAbnormalTypeTooltip());
            Assert.AreEqual(input.ExpectedData.Messages[2], BatchModifyDialog.GetBackfillValueTooltip());

            //Select a time range.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            BatchModifyDialog.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            BatchModifyDialog.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Check at least one abnormal type,such as normal spike.
            VEEAbnormalRadioButton.Click();
            BatchModifyDialog.CheckAbnormalTypeCheckBox(input.InputData.AbnormalTypes[0]);
            TimeManager.FlashPause();

            //Choose the Average Backfill rule,without select  backfill source.//---------by default--------
            //Click "modifyandsave"button.
            BatchModifyDialog.ClickModifyAndSaveButton();
            TimeManager.ShortPause();

            //Check error messages
            Assert.AreEqual(input.ExpectedData.Messages[2], BatchModifyDialog.GetBackfillValueTooltip());

            //+Close the dialog
            BatchModifyDialog.ClickGiveUpButton();
            TimeManager.FlashPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchModify-002"), ManualCaseID("TC-J1-FVT-AbnormalData-BatchModify-002")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchModifyAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchModify-002")]
        public void VerifyCancelButtonInBatchModifyPage(AbnormalRecordData input)
        {
            //Switch 客户配置-数据点配置-计量数据P
            PTagSettings.NavigatorToPtagSetting();
            TimeManager.MediumPause();

            //Check some tags
            PTagSettings.FocusOnPTagByName(input.InputData.TagNames[0]);
            PTagSettings.CheckPTagByTagName(input.InputData.TagNames[0]);
            PTagSettings.CheckPTagByTagName(input.InputData.TagNames[1]);

            //Click raw data tab.
            PTagRawData.SwitchToRawDataTab();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //Click 批量操作 button and select 修改 item.
            PTagRawData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            PTagRawData.ClickBatchModifyButton();
            TimeManager.FlashPause();

            //CheckPop up 原始数据批量修改 window.
            Assert.AreEqual(input.ExpectedData.Messages[0], BatchModifyDialog.GetTitle());

            //Select time range for batch modify, 
            var ManualTimeRange = input.InputData.ManualTimeRange;
            BatchModifyDialog.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            BatchModifyDialog.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //click abnormal data for all data,//-------------by default-------------
            //click fixed value radio button and input value 5 for input field.
            BatchModifyDialog.FillInModifyValueTextField("5");

            //Click Cancel button
            BatchModifyDialog.ClickGiveUpButton();

            //The window can be close success and changes can not be modify success.
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //+The backfill value is difference value, so should check the difference value
            AbnormalData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();

            //---------------Need update data-----------------------
            //+check record number is hours of time range * 4 
            for (int i = 0; i < 4; i++)
            {
                VEERawDataGrid.FocusOnCell(i + 3);
                TimeManager.MediumPause();
                Assert.AreNotEqual("5", VEERawDataValueNumberField.GetValue());
            }

            //Click 批量操作-修改 button
            PTagRawData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            PTagRawData.ClickBatchModifyButton();
            TimeManager.FlashPause();

            //CheckPop up 原始数据批量修改 window.
            Assert.AreEqual(input.ExpectedData.Messages[0], BatchModifyDialog.GetTitle());

            //Select time range for batch modify, 
            BatchModifyDialog.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            BatchModifyDialog.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //click abnormal data for all data,//-------by default------------
            //click fixed value radio button and input value 5 for input field.
            BatchModifyDialog.FillInModifyValueTextField("5");

            //Click Close button
            BatchModifyDialog.ClickCloseButton();

            //The window can be close success and changes can not be modify success.
            AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //+The backfill value is difference value, so should check the difference value
            AbnormalData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();

            //---------------Need update data-----------------------
            //+check record number is hours of time range * 4 
            for (int i = 0; i < 4; i++)
            {
                VEERawDataGrid.FocusOnCell(i + 3);
                TimeManager.MediumPause();
                Assert.AreNotEqual("5", VEERawDataValueNumberField.GetValue());
            }
    
        }

    }
}
