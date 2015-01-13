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
        public static DatePicker GetOneDatePicker(string key, int positionIndex)
        {
            return GetControl<DatePicker>(key, positionIndex) ;
        }
        #endregion

        #region Energy View
        public static DatePicker EnergyUsageStartDateDatePicker{ get { return GetControl<DatePicker>(JazzControlLocatorKey.DatePickerEnergyUsageStartDate);}}
        public static DatePicker EnergyUsageEndDateDatePicker{ get { return GetControl<DatePicker>(JazzControlLocatorKey.DatePickerEnergyUsageEndDate);}}

        public static DatePicker UnitKPIStartDatePicker{ get { return GetControl<DatePicker>(JazzControlLocatorKey.DatePickerUnitKPIStartDate);}}
        public static DatePicker UnitKPIEndDatePicker{ get { return GetControl<DatePicker>(JazzControlLocatorKey.DatePickerUnitKPIEndDate);}}

        public static DatePicker BaseIntervalDialogStartDatePicker{ get { return GetControl<DatePicker>(JazzControlLocatorKey.DatePickerIntervalDialogBaseStartDate);}}
        public static DatePicker BaseIntervalDialogEndDatePicker{ get { return GetControl<DatePicker>(JazzControlLocatorKey.DatePickerIntervalDialogBaseEndDate);}}

        public static DatePicker WidgetMaxDialogStartDatePicker{ get { return GetControl<DatePicker>(JazzControlLocatorKey.DatePickerWidgetMaxDialogStartDate);}}
        public static DatePicker WidgetMaxDialogEndDatePicker{ get { return GetControl<DatePicker>(JazzControlLocatorKey.DatePickerWidgetMaxDialogEndDate);}}

        #endregion

        #region Customer settings
        #region KPITag settings
        public static DatePicker KPITargetBaselineSpecialdayRuleStartDateDatePicker{ get { return GetControl<DatePicker>(JazzControlLocatorKey.DatePickerKPITargetBaselineSpecialdayRuleStartDate);}}
        public static DatePicker KPITargetBaselineSpecialdayRuleEndDateDatePicker{ get { return GetControl<DatePicker>(JazzControlLocatorKey.DatePickerKPITargetBaselineSpecialdayRuleEndDate);}}        
        #endregion

        #region PTag RawData
        public static DatePicker PTagRawDataStartDateDatePicker{ get { return GetControl<DatePicker>(JazzControlLocatorKey.DatePickerPTagRawDataStartDate);}}
        public static DatePicker PTagRawDataEndDateDatePicker{ get { return GetControl<DatePicker>(JazzControlLocatorKey.DatePickerPTagRawDataEndDate);}}
        #endregion

        #region VEE RawData
        public static DatePicker VEERawDataStartDateDatePicker { get { return GetControl<DatePicker>(JazzControlLocatorKey.DatePickerPTagRawDataStartDate); } }
        public static DatePicker VEERawDataEndDateDatePicker { get { return GetControl<DatePicker>(JazzControlLocatorKey.DatePickerPTagRawDataEndDate); } }

        public static DatePicker BatchModifyStartDatePicker { get { return GetControl<DatePicker>(JazzControlLocatorKey.DatePickerBatchModifyStartDate); } }
        public static DatePicker BatchModifyEndDatePicker { get { return GetControl<DatePicker>(JazzControlLocatorKey.DatePickerBatchModifyEndDate); } }
        public static DatePicker BackfillSourceDatePicker { get { return GetControl<DatePicker>(JazzControlLocatorKey.DatePickerBackfillSource); } }
        #endregion

        #region VEE Rules
        public static DatePicker VEEScanStartDatePicker { get { return GetControl<DatePicker>(JazzControlLocatorKey.DateVEEScanStartDatePicker); } }
        #endregion
        #endregion

		#region Platform Setting
        #region Customer Management
        public static DatePicker OperationTimeDatePicker{ get { return GetControl<DatePicker>(JazzControlLocatorKey.DatePickerOperationTime);}}
        #endregion


        #endregion

    }
}
