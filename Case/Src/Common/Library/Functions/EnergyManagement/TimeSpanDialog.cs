using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class TimeSpanDialog : Window
    {
        private static Locator Locator = new Locator("//div[contains(@id,'addintervalwindow') and contains(@class,'x-window')]", ByType.XPath);

        #region controls

        private static DatePicker BaseStartDatePicker = JazzDatePicker.BaseIntervalDialogStartDatePicker;
        private static ComboBox BaseStartTimeComboBox = JazzComboBox.BaseIntervalDialogStartTimeComboBox;
        private static DatePicker BaseEndDatePicker = JazzDatePicker.BaseIntervalDialogEndDatePicker;
        private static ComboBox BaseEndTimeComboBox = JazzComboBox.BaseIntervalDialogEndTimeComboBox;
        private static LinkButton AddTimeSpanButton = JazzButton.IntervalDialogAddTimeSpanLinkButton;
        private static Button IntervalDialogConfirmButton = JazzButton.IntervalDialogConfirmButton;
        private static Button IntervalDialogGiveUpButton = JazzButton.IntervalDialogGiveUpButton;

        #endregion

        public TimeSpanDialog() : base(Locator) { }

        #region common       

        public void ClickConfirmButton()
        {
            IntervalDialogConfirmButton.Click();
        }

        public void ClickGiveUpButton()
        {
            IntervalDialogGiveUpButton.Click();
        }

        public void ClickAddTimeSpanButton()
        {
            AddTimeSpanButton.ClickLink();
        }

        public bool IsAddTimeSpanButtonDisabled()
        {
            return AddTimeSpanButton.IsLinkButtonDisabled();
        }

        public void ClickDeleteTimeSpanButton(int position)
        {
            Button DeleteTimeSpanButton = GetAdditionDeleteButton(position);

            DeleteTimeSpanButton.Click();
        }

        #endregion

        #region add time span
        
        public void InputBaseStartDate(string startTime)
        {
            BaseStartDatePicker.SelectDateItem(startTime);

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void InputBaseStartTime(string time)
        {
            BaseStartTimeComboBox.SelectItem(time);

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void InputBaseEndDate(string startTime)
        {
            BaseEndDatePicker.SelectDateItem(startTime);

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void InputBaseEndTime(string time)
        {
            BaseEndTimeComboBox.SelectItem(time);

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void InputAdditionStartDate(string startTime, int position)
        {
            DatePicker AdditionStartDatePicker = GetAdditionStartDatePicker(position);

            AdditionStartDatePicker.SelectDateItem(startTime);
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void InputAdditionStartTime(string time, int position)
        {
            ComboBox AdditionStartTimeComboBox = GetAdditionStartComboBox(position);

            AdditionStartTimeComboBox.SelectItem(time);
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        #endregion

        #region get value

        public string GetAdditionStartDateValue(int position)
        {
            DatePicker AdditionStartDatePicker = GetAdditionStartDatePicker(position);

            return AdditionStartDatePicker.GetValue();
        }

        public string GetAdditionStartTimeValue(int position)
        {
            ComboBox AdditionStartTimeComboBox = GetAdditionStartComboBox(position);

            return AdditionStartTimeComboBox.GetValue();
        }

        public string GetAdditionEndTimeValue(int position)
        {
            Label AdditionEndTimeLabel = GetAdditionEndTimeLabel(position);

            return AdditionEndTimeLabel.GetLabelTextValue();
        }

        public string GetBaseStartDateValue()
        {
            return BaseStartDatePicker.GetValue();
        }

        public string GetBaseEndDateValue()
        {
            return BaseEndDatePicker.GetValue();
        }

        public string GetBaseStartTimeValue()
        {
            return BaseStartTimeComboBox.GetValue();
        }

        public string GetBaseEndTimeValue()
        {
            return BaseEndTimeComboBox.GetValue();
        }

        #endregion

        #region private method

        private DatePicker GetAdditionStartDatePicker(int position)
        {
            return JazzDatePicker.GetOneDatePicker(JazzControlLocatorKey.DatePickerIntervalDialogAdditionStartDate, position);
        }

        private ComboBox GetAdditionStartComboBox(int position)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxIntervalDialogAdditionStartTime, position);
        }

        private Button GetAdditionDeleteButton(int position)
        {
            return JazzButton.GetOneButton(JazzControlLocatorKey.ButtonIntervalDialogDeleteTimeSpan, position);
        }

        private Label GetAdditionEndTimeLabel(int position)
        {
            return JazzLabel.GetOneLabel(JazzControlLocatorKey.LabelAdditionEndTime, position);
        }

        #endregion
    }
}
