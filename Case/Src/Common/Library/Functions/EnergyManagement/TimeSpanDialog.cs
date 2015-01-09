using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.ScriptCommon.TestData.EnergyView;
using System.Collections;
using OpenQA.Selenium;

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
        private static Locator MutipleIntervalsTextLocator = new Locator("//table[contains(@id,'addintervalwindow')]/tbody/tr/td/div/div[1]/label[2]", ByType.XPath);

        private static Dictionary<CompareTimeType, string[]> MenuItemComparedTimeType = new Dictionary<CompareTimeType, string[]>()
        {
            {CompareTimeType.UserDefined,new string[] { "$@Common.DateRange.Customerize" }},
            {CompareTimeType.Relative,new string[] { "$@Common.DateRange.RelativedTime" }},
        };

        private static Dictionary<OriginalTimeType, string[]> MenuItemOriginalTimeType = new Dictionary<OriginalTimeType, string[]>()
        {
            {OriginalTimeType.UserDefined,new string[] { "$@Common.DateRange.Customerize" }},
            {OriginalTimeType.Last7days,new string[] { "$@Common.DateRange.Last7Day" }},
            {OriginalTimeType.Last30days,new string[] { "$@Common.DateRange.Last30Day" }},
            {OriginalTimeType.Last12months,new string[] { "$@Common.DateRange.Last12Month" }},
            {OriginalTimeType.Lastmonth,new string[] { "$@Common.DateRange.LastMonth" }},
            {OriginalTimeType.Lastweek,new string[] { "$@Common.DateRange.LastWeek" }},
            {OriginalTimeType.Lastyear,new string[] { "$@Common.DateRange.LastYear" }},
            {OriginalTimeType.Thismonth,new string[] { "$@Common.DateRange.ThisMonth" }},
            {OriginalTimeType.Thisweek,new string[] { "$@Common.DateRange.ThisWeek" }},
            {OriginalTimeType.Thisyear,new string[] { "$@Common.DateRange.ThisYear" }},
            {OriginalTimeType.Today,new string[] { "$@Common.DateRange.Today" }},
            {OriginalTimeType.Yesterday,new string[] { "$@Common.DateRange.Yesterday" }},
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
            //TimeTypeComboBox.Click();
            TimeManager.FlashPause();
            if (CompareTimeType.UserDefined == timeType)
                TimeTypeComboBox.SelectItem("$@Common.DateRange.Customerize");
                //UserDefinedTime.Click();
            else
                TimeTypeComboBox.SelectItem("$@Common.DateRange.RelativedTime");
                //RelativeTime.Click();
            //TimeTypeComboBox.GetValue();
        }

        public CompareTimeType GetCompareTimeType(int position)
        {
            ComboBox TimeTypeComboBox = GetCompareIntervalTypeComboBox(position);
            if (("Relative" == TimeTypeComboBox.GetValue()) ||( "相对时间" == TimeTypeComboBox.GetValue()))
            {
                return CompareTimeType.Relative;
            }
            else
            {
                return CompareTimeType.UserDefined;
            }

        }

        public void SelectOriginalTimeType(OriginalTimeType timeType)
        {
            ComboBox TimeTypeComboBox = GetOriginalTimeTypeComboBox();
            TimeManager.MediumPause();
            switch (timeType)
            {
                case OriginalTimeType.UserDefined:
                    TimeTypeComboBox.SelectItem("$@Common.DateRange.Customerize");
                    break;
                case OriginalTimeType.Last7days:
                    TimeTypeComboBox.SelectItem("$@Common.DateRange.Last7Day");
                    break;
                case OriginalTimeType.Last30days:
                    TimeTypeComboBox.SelectItem("$@Common.DateRange.Last30Day");
                    break;
                case OriginalTimeType.Last12months:
                    TimeTypeComboBox.SelectItem("$@Common.DateRange.Last12Month");
                    break;
                case OriginalTimeType.Lastmonth:
                    TimeTypeComboBox.SelectItem("$@Common.DateRange.LastMonth");
                    break;
                case OriginalTimeType.Lastweek:
                    TimeTypeComboBox.SelectItem("$@Common.DateRange.LastWeek");
                    break;
                case OriginalTimeType.Lastyear:
                    TimeTypeComboBox.SelectItem("$@Common.DateRange.LastYear");
                    break;
                case OriginalTimeType.Thismonth:
                    TimeTypeComboBox.SelectItem("$@Common.DateRange.ThisMonth");
                    break;
                case OriginalTimeType.Thisweek:
                    TimeTypeComboBox.SelectItem("$@Common.DateRange.ThisWeek");
                    break;
                case OriginalTimeType.Thisyear:
                    TimeTypeComboBox.SelectItem("$@Common.DateRange.ThisYear");
                    break;
                case OriginalTimeType.Today:
                    TimeTypeComboBox.SelectItem("$@Common.DateRange.Today");
                    break;
                case OriginalTimeType.Yesterday:
                    TimeTypeComboBox.SelectItem("$@Common.DateRange.Yesterday");
                    break;
                default:
                    break;
            }
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public OriginalTimeType GetOriginalTimeType()
        {
            ComboBox TimeTypeComboBox = GetOriginalTimeTypeComboBox();
            string strType = TimeTypeComboBox.GetValue();
            switch (strType)
            {
                //case "$@Common.DateRange.Customerize":
                //    return OriginalTimeType.UserDefined;
                //case "$@Common.DateRange.Last7Day":
                //    return OriginalTimeType.Last7days;
                //case "$@Common.DateRange.Last30Day":
                //    return OriginalTimeType.Last30days;
                //case "$@Common.DateRange.Last12Month":
                //    return OriginalTimeType.Last12months;
                //case "$@Common.DateRange.Today":
                //    return OriginalTimeType.Today;
                //case "$@Common.DateRange.Yesterday":
                //    return OriginalTimeType.Yesterday;
                //case "$@Common.DateRange.ThisWeek":
                //    return OriginalTimeType.Thisweek;
                //case "$@Common.DateRange.LastWeek":
                //    return OriginalTimeType.Lastweek;
                //case "$@Common.DateRange.ThisMonth":
                //    return OriginalTimeType.Thismonth;
                //case "$@Common.DateRange.LastMonth":
                //    return OriginalTimeType.Lastmonth;
                //case "$@Common.DateRange.ThisYear":
                //    return OriginalTimeType.Thisyear;
                //case "$@Common.DateRange.LastYear":
                //    return OriginalTimeType.Lastyear;
                case "User-defined":
                    return OriginalTimeType.UserDefined;
                case "Last 7 days":
                    return OriginalTimeType.Last7days;
                case "Last 30 days":
                    return OriginalTimeType.Last30days;
                case "Last 12 months":
                    return OriginalTimeType.Last12months;
                case "Today":
                    return OriginalTimeType.Today;
                case "Yesterday":
                    return OriginalTimeType.Yesterday;
                case "This week":
                    return OriginalTimeType.Thisweek;
                case "Last week":
                    return OriginalTimeType.Lastweek;
                case "This month":
                    return OriginalTimeType.Thismonth;
                case "Last month":
                    return OriginalTimeType.Lastmonth;
                case "This year":
                    return OriginalTimeType.Thisyear;
                case "Last year":
                    return OriginalTimeType.Lastyear;
                case " 自定义":
                    return OriginalTimeType.UserDefined;
                case "最近7天":
                    return OriginalTimeType.Last7days;
                case "最近30天":
                    return OriginalTimeType.Last30days;
                case "最近12月":
                    return OriginalTimeType.Last12months;
                case "今天":
                    return OriginalTimeType.Today;
                case "昨天":
                    return OriginalTimeType.Yesterday;
                case "本周":
                    return OriginalTimeType.Thisweek;
                case "上周":
                    return OriginalTimeType.Lastweek;
                case "本月":
                    return OriginalTimeType.Thismonth;
                case "上月":
                    return OriginalTimeType.Lastmonth;
                case "今年":
                    return OriginalTimeType.Thisyear;
                case "去年":
                    return OriginalTimeType.Lastyear;
                default:
                    return OriginalTimeType.Last7days;
                    //break;
            }

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
        
        public void InputAdditionRelativeValue(string time, int position)
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
            ComboBox AdditionEndTimeComboBox = GetAdditionEndComboBox(position);

            return AdditionEndTimeComboBox.GetValue();

            //Label AdditionEndTimeLabel = GetAdditionEndTimeLabel(position);

            //return AdditionEndTimeLabel.GetLabelTextValue();
        }

        public string GetAdditionRelativeValue(int position)
        {
            ComboBox AdditionRelativeComboBox = GetAdditionRelativeIntevalNumberComboBox(position);

            return AdditionRelativeComboBox.GetValue();
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

        public ArrayList GetRelativeIntervalsMenuItemsList(int position)
        {
            ComboBox AdditionRelativeComboBox = GetAdditionRelativeIntevalNumberComboBox(position);
            return AdditionRelativeComboBox.GetRelativeIntervalsMenulistItems();
        }

        public string GetComparedIntervalsText(int position)
        {
            IWebElement[] rawDataTooltips = FindChildren(MutipleIntervalsTextLocator);
            return rawDataTooltips[position-2].Text;
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

        private ComboBox GetOriginalTimeTypeComboBox()
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxTimeType, 1);
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
