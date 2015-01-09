using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.ScriptCommon.TestData.Customer;
using System.Collections;
using OpenQA.Selenium;

using Mento.ScriptCommon.TestData.EnergyView;

namespace Mento.ScriptCommon.Library.Functions
{
    public class BatchModifyDialog : Window
    {
        private static Locator Locator = new Locator("//div[contains(@id,'batchmodifywindow') and contains(@class,'x-window')]", ByType.XPath);

        #region controls

        private static DatePicker StartDatePicker = JazzDatePicker.BatchModifyStartDatePicker;
        private static ComboBox StartTimeComboBox = JazzComboBox.BatchModifyStartTimeComboBox;
        private static DatePicker EndDatePicker = JazzDatePicker.BatchModifyEndDatePicker;
        private static ComboBox EndTimeComboBox = JazzComboBox.BatchModifyEndTimeComboBox;
        private static DatePicker BackfillSourceDatePicker = JazzDatePicker.BackfillSourceDatePicker;
        private static ComboBox BackfillSourceTimeComboBox = JazzComboBox.BackfillSourceTimeComboBox;
        private static Button ModifyAndSaveButton = JazzButton.BatchModifyModifyAndSaveButton;
        private static Button GiveupButton = JazzButton.BatchModifyGiveupButton;
        private static Button CloseButton = JazzButton.BatchModifyCloseButton;
        private static Button MsgModifyAndSaveButton = JazzButton.MsgBatchModifyModifyAndSaveButton;
        private static Button MsgGiveupButton = JazzButton.MsgBatchModifyGiveupButton;
        private static TextField BackfillValueTextField = JazzTextField.BackfillValueTextField;
        private static CheckBoxField AbnormalTypeCheckBoxGroup = JazzCheckBox.BatchModifyAbnormalTypeCheckBox;
        private static Locator TimeRangeTooltipLocator = new Locator("//div[contains(@id,'batchmodifywindow')]/div[contains(@id,'dateselector')]/following-sibling::label", ByType.XPath);
        private static Locator AbnormalTypeTooltipLocator = new Locator("//div[contains(@id,'batchmodifywindow')]/table[contains(@id,'checkboxgroup')]/following-sibling::label", ByType.XPath);
        private static Locator BackfillValueTooltipLocator = new Locator("//div[contains(@id,'batchmodifywindow')]/table[contains(@id,'radiogroup')]/tbody/tr/td/div[contains(@id,'radiogroup')]/div/label", ByType.XPath);

        private static Button IgnoreAndSaveButton = JazzButton.BatchIgnoreIgnoreAndSaveButton;
        private static Button RevertAndSaveButton = JazzButton.BatchRevertRevertAndSaveButton;
        private static Button MsgIgnoreAndSaveButton = JazzButton.MsgBatchIgnoreIgnoreAndSaveButton;
        private static Button MsgRevertAndSaveButton = JazzButton.MsgBatchRevertRevertAndSaveButton;
        #endregion

        public BatchModifyDialog() : base(Locator) { }

        #region common       

        public void ClickModifyAndSaveButton()
        {
            ModifyAndSaveButton.Click();
        }

        public void ClickIgnoreAndSaveButton()
        {
            IgnoreAndSaveButton.Click();
        }

        public void ClickRevertAndSaveButton()
        {
            IgnoreAndSaveButton.Click();
        }

        public void ClickGiveUpButton()
        {
            GiveupButton.Click();
        }

        public void ClickCloseButton()
        {
            CloseButton.Click();
        }

        public void ClickMessageBoxModifyAndSaveButton()
        {
            MsgModifyAndSaveButton.Click();
        }

        public void ClickMessageBoxIgnoreAndSaveButton()
        {
            MsgIgnoreAndSaveButton.Click();
        }
        public void ClickMessageBoxRevertAndSaveButton()
        {
            MsgRevertAndSaveButton.Click();
        }

        public void ClickMessageBoxGiveUpButton()
        {
            MsgGiveupButton.Click();
        }

        public void SetDateRange(string startTime, string endTime)
        {
            if (" " != startTime)
            {
                StartDatePicker.SelectDateItem(startTime);
                JazzMessageBox.LoadingMask.WaitLoading();
            }
            if (" " != endTime)
            {
                EndDatePicker.SelectDateItem(endTime);
                JazzMessageBox.LoadingMask.WaitLoading();
            }

        }

        public void SetTimeRange(string startTime, string endTime)
        {
            if (" " != startTime)
            {
                StartTimeComboBox.SelectItem(startTime);
                JazzMessageBox.LoadingMask.WaitLoading();
            }
            if (" " != endTime)
            {
                EndTimeComboBox.SelectItem(endTime);
                JazzMessageBox.LoadingMask.WaitLoading();
            }
        }

        public void CheckAbnormalTypeCheckBox(string type)
        {
            AbnormalTypeCheckBoxGroup.CommonCheck(type);
        }

        public string GetTimeRangeTooltip()
        {
            return FindChild(TimeRangeTooltipLocator).Text;
        }
        public string GetAbnormalTypeTooltip()
        {
            return FindChild(AbnormalTypeTooltipLocator).Text;
        }
        public string GetBackfillValueTooltip()
        {
            return FindChild(BackfillValueTooltipLocator).Text;
        }
        
        #endregion

        #region input

        public void InputBackfillSourceDate(string startTime)
        {
            BackfillSourceDatePicker.SelectDateItem(startTime);
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void InputBackfillSourceTime(string time)
        {           
            TimeManager.MediumPause();
            BackfillSourceTimeComboBox.SelectItem(time);
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void FillInModifyValueTextField(string input)
        {
            BackfillValueTextField.Fill(input);
        }
        #endregion

        #region get value

        public string GetBackfillSourceDateValue()
        {
            return BackfillSourceDatePicker.GetValue();
        }

        public string GetBackfillSourceTimeValue()
        {
            return BackfillSourceTimeComboBox.GetValue();
        }

        public string GetStartDateValue()
        {
            return StartDatePicker.GetValue();
        }

        public string GetEndDateValue()
        {
            return EndDatePicker.GetValue();
        }

        public string GetStartTimeValue()
        {
            return StartTimeComboBox.GetValue();
        }

        public string GetEndTimeValue()
        {
            return EndTimeComboBox.GetValue();
        }

        #endregion

        #region private method

        private ComboBox GetOriginalTimeTypeComboBox()
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxTimeType, 1);
        }

        public string GetBackfillValue()
        {
            return BackfillValueTextField.GetValue();
        }
        #endregion
    }
}
