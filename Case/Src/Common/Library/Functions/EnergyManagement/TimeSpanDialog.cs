using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.ScriptCommon.TestData.EnergyView;

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
        private static Container ExcludeTimeIntervalsContainer = JazzContainer.ExcludeTimeIntervalsContainer;
        private static ComboBox TimeTypeComboBox = JazzComboBox.TimeTypeComboBox;
        private static Button UserDefinedTime = JazzButton.UserDefinedTime;
        private static Button RelativeTime = JazzButton.RelativeTime;

        private static Dictionary<CompareTimeType, string[]> MenuItemTimeType = new Dictionary<CompareTimeType, string[]>()
        {
            {CompareTimeType.UserDefined,new string[] { "$@EM.EnergyAnalyse.AddIntervalWindow.UserDefined" }},
            {CompareTimeType.Relative,new string[] { "$@EM.EnergyAnalyse.AddIntervalWindow.Relative" }},
        };

        #endregion

        public TimeSpanDialog() : base(Locator) { }

        #region common       

        public int GetExcludeIntervals()
        {
            return ExcludeTimeIntervalsContainer.GetElementNumber();
        }

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

        //public void SelectCompareTimeType(CompareTimeType timeType)
        //{
        //    TimeTypeComboBox.Click();
        //    TimeManager.FlashPause();
        //    TimeTypeComboBox.SelectItem(MenuItemTimeType[timeType]);
        //}
        public void SelectCompareTimeType(CompareTimeType timeType, int position)
        {
            ComboBox TimeTypeComboBox = GetCompareIntervalTypeComboBox(position);
            TimeTypeComboBox.Click();
            TimeManager.FlashPause();
            if (CompareTimeType.UserDefined == timeType)
                UserDefinedTime.Click();
            else
                RelativeTime.Click();
            TimeTypeComboBox.GetValue();
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

        public void InputAdditionEndDate(string endTime, int position)
        {
            DatePicker AdditionEndDatePicker = GetAdditionEndDatePicker(position);

            AdditionEndDatePicker.SelectDateItem(endTime);
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void InputAdditionStartDate(DateTime startTime, int position)
        {
            DatePicker AdditionStartDatePicker = GetAdditionStartDatePicker(position);

            AdditionStartDatePicker.SelectDateItem(startTime);
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void InputAdditionStartTime(string time, int position)
        {
            ComboBox AdditionStartTimeComboBox = GetAdditionStartComboBox(position);
            
            TimeManager.MediumPause();
            AdditionStartTimeComboBox.SelectItem(time);
            JazzMessageBox.LoadingMask.WaitLoading();
        }
        
        public void InputAdditionRelativeIntervalnumber(string time, int position)
        {
            ComboBox AdditionRelativeIntervalNumberComboBox = GetAdditionRelativeIntevalNumberComboBox(position);

            TimeManager.MediumPause();
            AdditionRelativeIntervalNumberComboBox.SelectItem(time);
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void InputAdditionEndTime(string time, int position)
        {
            ComboBox AdditionEndTimeComboBox = GetAdditionEndComboBox(position);

            AdditionEndTimeComboBox.SelectItem(time);
            JazzMessageBox.LoadingMask.WaitLoading();
        }
        #endregion

        #region get value

        public string GetAdditionStartDateValue(int position)
        {
            DatePicker AdditionStartDatePicker = GetAdditionStartDatePicker(position);

            return AdditionStartDatePicker.GetValue();
        }

        public string GetAdditionEndDateValue(int position)
        {
            DatePicker AdditionEndDatePicker = GetAdditionEndDatePicker(position);

            return AdditionEndDatePicker.GetValue();
        }

        public string GetAdditionStartDateInvalidMsg(int position)
        {
            DatePicker AdditionStartDatePicker = GetAdditionStartDatePicker(position);

            return AdditionStartDatePicker.GetInvalidTips();
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

        private DatePicker GetAdditionEndDatePicker(int position)
        {
            return JazzDatePicker.GetOneDatePicker(JazzControlLocatorKey.DatePickerIntervalDialogAdditionEndDate, position);
        }

        private ComboBox GetAdditionStartComboBox(int position)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxIntervalDialogAdditionStartTime, position);
        }

        private ComboBox GetAdditionRelativeIntevalNumberComboBox(int position)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxIntervalDialogAdditionRelativeNumber, position);
        }

        private ComboBox GetCompareIntervalTypeComboBox(int position)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxTimeType, position);
        }

        private ComboBox GetAdditionEndComboBox(int position)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxIntervalDialogAdditionEndTime, position);
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
