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
        public static DatePicker EnergyUsageIntervalDialogStartDateDatePicker = GetControl<DatePicker>(JazzControlLocatorKey.DatePickerIntervalDialogStartDate);
        public static DatePicker EnergyUsageIntervalDialogEndDateDatePicker = GetControl<DatePicker>(JazzControlLocatorKey.DatePickerIntervalDialogEndDate);

        public static DatePicker UnitKPIStartDatePicker = GetControl<DatePicker>(JazzControlLocatorKey.DatePickerUnitKPIStartDate);
        public static DatePicker UnitKPIEndDatePicker = GetControl<DatePicker>(JazzControlLocatorKey.DatePickerUnitKPIEndDate);
        #endregion

        #region Customer settings
        #region KPITag settings
        public static DatePicker KPITargetBaselineSpecialdayRuleStartDateDatePicker = GetControl<DatePicker>(JazzControlLocatorKey.DatePickerKPITargetBaselineSpecialdayRuleStartDate);
        public static DatePicker KPITargetBaselineSpecialdayRuleEndDateDatePicker = GetControl<DatePicker>(JazzControlLocatorKey.DatePickerKPITargetBaselineSpecialdayRuleEndDate);        
        #endregion
        #endregion

		#region Platform Setting
        #region Customer Management
        public static DatePicker OperationTimeDatePicker = GetControl<DatePicker>(JazzControlLocatorKey.DatePickerOperationTime);
        #endregion
        #endregion

    }
}
