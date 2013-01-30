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

        private static DatePicker StartDatePicker = JazzDatePicker.EnergyUsageIntervalDialogStartDateDatePicker;
        private static ComboBox StartTimeComboBox = JazzComboBox.EnergyViewIntervalDialogStartTimeComboBox;
        private static DatePicker EndDatePicker = JazzDatePicker.EnergyUsageIntervalDialogEndDateDatePicker;
        private static ComboBox EndTimeComboBox = JazzComboBox.EnergyViewIntervalDialogEndTimeComboBox;
        
        public TimeSpanDialog() : base(Locator) { }

        public void InputStartTime(DateTime startTime)
        {
            int startHour = startTime.Hour, startMinute = startTime.Minute;

            StartDatePicker.SelectDateItem(startTime);

            StartTimeComboBox.SelectItem(String.Format("{0}:{1}", startHour, startMinute));

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public DateTime? GetEndTime()
        {
            string endDateString = EndDatePicker.GetValue();
            string endTimeString = EndTimeComboBox.GetValue();

            DateTime endTime;
            if (DateTime.TryParse(endDateString, out endTime) && endTimeString.Contains(":") && endTimeString.Split(':').Length == 2)
            {
                return new DateTime(endTime.Year, endTime.Month, endTime.Day, int.Parse(endTimeString.Split(':')[0]), int.Parse(endTimeString.Split(':')[1]), 0);
            }

            return null;
        }
    }
}
