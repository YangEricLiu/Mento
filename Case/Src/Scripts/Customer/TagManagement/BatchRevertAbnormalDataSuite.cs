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
    [CreateTime("2015-1-9")]
    [ManualCaseID("TC-J1-FVT-AbnormalData-BatchRevert")]
    public class BatchRevertAbnormalDataSuite : TestSuiteBase
    {
        private static BatchModifyDialog BatchModifyDialog = JazzFunction.BatchModifyDialog;
        private AbnormalData AbnormalData = JazzFunction.AbnormalData;
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
        [CaseID("TC-J1-FVT-AbnormalData-BatchRevert-101"), ManualCaseID("TC-J1-FVT-AbnormalData-BatchRevert-101")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchRevertAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchRevert-101")]
        public void VerifyBatchRevokeFunction(AbnormalRecordData input)
        {
            //Click the checkbox of two record's time range 
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();
            AbnormalData.CheckRecordsByTagName(input.InputData.TagNames[0]);
            TimeManager.FlashPause();
            AbnormalData.CheckRecordsByTagName(input.InputData.TagNames[1]);
            TimeManager.FlashPause();

            //Click 批量操作 button and select 批量撤回 item.
            AbnormalData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            AbnormalData.ClickBatchRevertButton();
            TimeManager.FlashPause();

            //."原始数据修改批量撤回" window appear.
            Assert.AreEqual(input.ExpectedData.Messages[0], BatchModifyDialog.GetTitle());

            //.Select time range for batch ignore.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            BatchModifyDialog.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            BatchModifyDialog.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Click 撤回并保存 button
            BatchModifyDialog.ClickIgnoreAndSaveButton();
            TimeManager.ShortPause();
            BatchModifyDialog.ClickMessageBoxRevertAndSaveButton();
            TimeManager.LongPause();

            //Verify abnormal data modify correct in step3 change to prior raw data.
            //------------------------

        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchRevert-001"), ManualCaseID("TC-J1-FVT-AbnormalData-BatchRevert-001")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchRevertAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchRevert-001")]
        public void VerifyErrorMessageCheckInBatchRevertPage(AbnormalRecordData input)
        {
            //Click the checkbox of a record's time range and execute 批量修改
            AbnormalData.FocusOnRecordByName(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.ShortPause();
            AbnormalData.CheckRecordsByTagName(input.InputData.TagNames[0]);
            TimeManager.FlashPause();

            //+Modify some date for the abnormal record
            AbnormalData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            AbnormalData.ClickBatchModifyButton();
            TimeManager.FlashPause();
            var ManualTimeRange = input.InputData.ManualTimeRange;
            BatchModifyDialog.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            BatchModifyDialog.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();
            BatchModifyDialog.FillInModifyValueTextField("100");

            //Click "修改并保存" button.
            PTagRawData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            PTagRawData.ClickBatchRevertButton();
            TimeManager.FlashPause();

            //Click 批量操作 button and select 批量撤回 item.
            AbnormalData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            AbnormalData.ClickBatchRevertButton();
            TimeManager.FlashPause();

            //With no select time range and Click 撤回并保存 button
            BatchModifyDialog.ClickRevertAndSaveButton();
            TimeManager.ShortPause();

            //Verify error message for not select time range.
            Assert.AreEqual(input.ExpectedData.Messages[0], BatchModifyDialog.GetTimeRangeTooltip());

            //+Close the dialog
            BatchModifyDialog.ClickGiveUpButton();
            TimeManager.FlashPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-AbnormalData-BatchRevert-002"), ManualCaseID("TC-J1-FVT-AbnormalData-BatchRevert-002")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AbnormalRecordData[]), typeof(BatchRevertAbnormalDataSuite), "TC-J1-FVT-AbnormalData-BatchRevert-002")]
        public void VerifyCancelActionInBatchRevertPage(AbnormalRecordData input)
        {
            //Switch 客户配置-数据点配置-计量数据P
            PTagSettings.NavigatorToPtagSetting();
            TimeManager.MediumPause();

            //Check some abnormal record's time range.
            PTagSettings.FocusOnPTagByName(input.InputData.TagNames[0]);
            PTagSettings.CheckPTagByTagName(input.InputData.TagNames[0]);
            PTagSettings.CheckPTagByTagName(input.InputData.TagNames[1]);

            //Click raw data tab.
            PTagRawData.SwitchToRawDataTab();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();

            //Click 批量操作-批量撤回 button
            PTagRawData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            PTagRawData.ClickBatchRevertButton();
            TimeManager.FlashPause();

            //Select time range for batch revert
            var ManualTimeRange = input.InputData.ManualTimeRange;
            BatchModifyDialog.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            BatchModifyDialog.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Check Pop up 原始数据修改批量撤回 window.
            Assert.AreEqual(input.ExpectedData.Messages[0], BatchModifyDialog.GetTitle());

            //Click Cancel button
            BatchModifyDialog.ClickGiveUpButton();

            //The 原始数据修改批量撤回 window can be close success and step 4 change can not be modify success.
            //---------------------------
            //AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            //AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            //TimeManager.LongPause();

            //Click 批量操作-批量撤回 button
            PTagRawData.ClickBatchOperationButton();
            TimeManager.FlashPause();
            PTagRawData.ClickBatchRevertButton();
            TimeManager.FlashPause();

            //Select time range for batch revert
            BatchModifyDialog.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            BatchModifyDialog.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.LongPause();

            //Check Pop up 原始数据修改批量撤回 window.
            Assert.AreEqual(input.ExpectedData.Messages[0], BatchModifyDialog.GetTitle());

            //Click Close button
            BatchModifyDialog.ClickCloseButton();

            //The 原始数据修改批量撤回 window can be close success and step 4 change can not be modify success.
            //---------------------------
            //AbnormalData.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            //AbnormalData.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            //TimeManager.LongPause();

        }

    }
}
