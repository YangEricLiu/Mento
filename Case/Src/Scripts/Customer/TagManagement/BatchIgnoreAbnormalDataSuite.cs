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
    [CreateTime("2015-1-8")]
    [ManualCaseID("TC-J1-FVT-AbnormalData-BatchIgnore")]
    public class BatchIgnoreAbnormalDataSuite : TestSuiteBase
    {
        private static BatchModifyDialog BatchModifyDialog = JazzFunction.BatchModifyDialog;


        private AbnormalData AbnormalData = JazzFunction.AbnormalData;
        private static Grid VEERawDataGrid = JazzGrid.GridVEERawData;
        private static TextField VEERawDataValueNumberField = JazzTextField.VEERawDataValueTextField;
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
        [CaseID("TC-J1-FVT-AbnormalData-BatchIgnore-102"), ManualCaseID("TC-J1-FVT-AbnormalData-BatchIgnore-102")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchIgnoreAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchIgnore-102")]
        public void VerifyBatchIgnoreFunctionForAllAbnormals(AbnormalRecordData input)
        {
            //Check the checkbox of a record's time range
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();
            AbnormalData.CheckRecordsByTagName(input.InputData.TagNames[0]);
            TimeManager.FlashPause();

            //Click 批量操作-忽略 button.
            AbnormalData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            AbnormalData.ClickBatchIgnoreButton();
            TimeManager.FlashPause();

            //Verify Window of 异常数据记录批量忽略 display
            Assert.AreEqual(input.ExpectedData.Messages[0], BatchModifyDialog.GetTitle());

            //.Select time range for batch ignore.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            BatchModifyDialog.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            BatchModifyDialog.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //.Select 全部异常数据记录//---------by default-------
            //Click 忽略并保存
            BatchModifyDialog.ClickIgnoreAndSaveButton();
            TimeManager.ShortPause();
            BatchModifyDialog.ClickMessageBoxIgnoreAndSaveButton();
            TimeManager.LongPause();

            //.Verify all abnormal data in select time range can be ignore success and value still prior.
            //------------------------

        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchIgnore-103"), ManualCaseID("TC-J1-FVT-AbnormalData-BatchIgnore-103")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchIgnoreAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchIgnore-103")]
        public void VerifyBatchIgnoreFunctionForPeaks(AbnormalRecordData input)
        {
            //Check the checkbox of a record's time range
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();
            AbnormalData.CheckRecordsByTagName(input.InputData.TagNames[0]);
            TimeManager.FlashPause();

            //Click 批量操作-忽略 button.
            AbnormalData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            AbnormalData.ClickBatchIgnoreButton();
            TimeManager.FlashPause();

            //Verify Window of 异常数据记录批量忽略 display
            Assert.AreEqual(input.ExpectedData.Messages[0], BatchModifyDialog.GetTitle());

            //.Select time range for batch ignore.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            BatchModifyDialog.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            BatchModifyDialog.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //.Select 部分异常数据记录
            VEEAbnormalRadioButton.Click();

            //.Check 仅针对正常峰 /仅针对异常峰
            BatchModifyDialog.CheckAbnormalTypeCheckBox(input.InputData.AbnormalTypes[0]);
            TimeManager.FlashPause();
            BatchModifyDialog.CheckAbnormalTypeCheckBox(input.InputData.AbnormalTypes[1]);
            TimeManager.FlashPause();

            //Click 忽略并保存
            BatchModifyDialog.ClickIgnoreAndSaveButton();
            TimeManager.ShortPause();
            BatchModifyDialog.ClickMessageBoxIgnoreAndSaveButton();
            TimeManager.LongPause();

            //Verify the record in step 2 check disappear with 正常峰/异常峰.
            //---------------------
                
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchIgnore-104"), ManualCaseID("TC-J1-FVT-AbnormalData-BatchIgnore-104")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchIgnoreAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchIgnore-104")]
        public void VerifyBatchIgnoreFunctionForNegativeNullSpecial(AbnormalRecordData input)
        {
            //Check the checkbox of a record's time range
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();
            AbnormalData.CheckRecordsByTagName(input.InputData.TagNames[0]);
            TimeManager.FlashPause();

            //Click 批量操作-忽略 button.
            AbnormalData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            AbnormalData.ClickBatchIgnoreButton();
            TimeManager.FlashPause();

            //Verify Window of 异常数据记录批量忽略 display
            Assert.AreEqual(input.ExpectedData.Messages[0], BatchModifyDialog.GetTitle());

            //.Select time range for batch ignore.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            BatchModifyDialog.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            BatchModifyDialog.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //.Select 部分异常数据记录
            VEEAbnormalRadioButton.Click();

            //.Check 仅针对空值，仅针对负值 and 仅针对特殊值
            BatchModifyDialog.CheckAbnormalTypeCheckBox(input.InputData.AbnormalTypes[0]);
            TimeManager.FlashPause();
            BatchModifyDialog.CheckAbnormalTypeCheckBox(input.InputData.AbnormalTypes[1]);
            TimeManager.FlashPause();
            BatchModifyDialog.CheckAbnormalTypeCheckBox(input.InputData.AbnormalTypes[2]);
            TimeManager.FlashPause();

            //Click 忽略并保存
            BatchModifyDialog.ClickIgnoreAndSaveButton();
            TimeManager.ShortPause();
            BatchModifyDialog.ClickMessageBoxIgnoreAndSaveButton();
            TimeManager.LongPause();

            //Verify the record in step 2 check disappear with 空值/负值/特殊值.
            //-----------------

        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchIgnore-001"), ManualCaseID("TC-J1-FVT-AbnormalData-BatchIgnore-001")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchIgnoreAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchIgnore-001")]
        public void VerifyErrorMessageCheckInBatchIgnorePage(AbnormalRecordData input)
        {
            //Switch 客户配置-数据点配置-计量数据P
            PTagSettings.NavigatorToPtagSetting();
            TimeManager.MediumPause();

            //Check some the abnormal record's time range.
            PTagSettings.FocusOnPTagByName(input.InputData.TagNames[0]);
            PTagSettings.CheckPTagByTagName(input.InputData.TagNames[0]);
            PTagSettings.CheckPTagByTagName(input.InputData.TagNames[1]);

            //Click raw data tab.
            PTagRawData.SwitchToRawDataTab();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //Click 批量操作 button and select 忽略 item
            PTagRawData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            PTagRawData.ClickBatchIgnoreButton();
            TimeManager.FlashPause();

            //Click close button near all tags in select tag source,//----------The "Modify and Save" button is gray out without any tag in select tag source
            //no select time range, //-------------time is blank by default
            //click abnormal data not check any checkbox,
            VEEAbnormalRadioButton.Click();
            
            //Click "ignoreandsave"button.
            BatchModifyDialog.ClickIgnoreAndSaveButton();
            TimeManager.ShortPause();

            //Check error messages
            Assert.AreEqual(input.ExpectedData.Messages[0], BatchModifyDialog.GetTimeRangeTooltip());
            Assert.AreEqual(input.ExpectedData.Messages[1], BatchModifyDialog.GetAbnormalTypeTooltip());
            Assert.AreEqual(input.ExpectedData.Messages[2], BatchModifyDialog.GetBackfillValueTooltip());

            //+Close the dialog
            BatchModifyDialog.ClickGiveUpButton();
            TimeManager.FlashPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchIgnore-002"), ManualCaseID("TC-J1-FVT-AbnormalData-BatchIgnore-002")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchIgnoreAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchIgnore-002")]
        public void VerifyCancelActionInBatchIgnorePage(AbnormalRecordData input)
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

            //Click 批量操作 button and select 忽略 item.
            PTagRawData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            PTagRawData.ClickBatchIgnoreButton();
            TimeManager.FlashPause();

            //Select time range for batch ignore
            var ManualTimeRange = input.InputData.ManualTimeRange;
            BatchModifyDialog.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            BatchModifyDialog.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //click 全部异常数据记录 radio button in 异常数据记录批量忽略 window//-------------by default-------------
            //Click Cancel button
            BatchModifyDialog.ClickGiveUpButton();

            //异常数据记录批量忽略 window can be close success and the action in step 5 can not be success.
            //---------------------------
            //AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            //AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            //TimeManager.LongPause();

            //+The backfill value is difference value, so should check the difference value
            AbnormalData.ClickSwitchDifferenceValueButton();
            TimeManager.LongPause();

            //Click 批量操作 button and select 忽略 item.
            PTagRawData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            PTagRawData.ClickBatchIgnoreButton();
            TimeManager.FlashPause();

            //Select time range for batch ignore and click 全部异常数据记录 radio button in 异常数据记录批量忽略 window
            BatchModifyDialog.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            BatchModifyDialog.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();
            //Click Cancel button
            BatchModifyDialog.ClickGiveUpButton();

            //异常数据记录批量忽略 window can be close success and the action in step 5 can not be success.
            //---------------------------
            //AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            //AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            //TimeManager.LongPause();

        }

    }
}
