using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzDatePicker : JazzControlCollection
    {
        #region Get Position DatePicker Method
        public static DatePicker GetOneMonthPicker(string key, int positionIndex)
        {
            return GetControl<DatePicker>(key, positionIndex);
        }
        #endregion

        #region Energy View
        public static DatePicker EnergyUsageStartDateDatePicker = GetControl<DatePicker>(JazzControlLocatorKey.DatePickerEnergyUsageStartDate);
        public static DatePicker EnergyUsageEndDateDatePicker = GetControl<DatePicker>(JazzControlLocatorKey.DatePickerEnergyUsageEndDate);
        #endregion

        #region Platform Setting
        #region Customer Setting
        public static DatePicker OperationTimeDatePicker = GetControl<DatePicker>(JazzControlLocatorKey.DatePickerOperationTime);
        #endregion
        #endregion
    }
}
