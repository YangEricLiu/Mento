using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzComboBox : JazzControlCollection
    {
        #region Get Position ComboBox Method
        public static ComboBox GetOneComboBox(string key, int positionIndex)
        {
            return GetControl<ComboBox>(key, positionIndex);
        }
        #endregion

        #region Customer settings
        #region Hierarchy settings
        public static ComboBox HierarchySettingsHierarchyTypeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHierarchySettingsHierarchyType);

        public static ComboBox WorkdayEffectiveYearComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorkdayEffectiveYear, 1);
        public static ComboBox WorkdayCalendarNameComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorkdayCalendarName, 1);  
        #endregion
        
        #region PTag settings
        public static ComboBox PTagSettingsCommodityComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxPTagSettingsCommodity);
        public static ComboBox PTagSettingsUomComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxPTagSettingsUom);
        public static ComboBox PTagSettingsCalculationTypeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxPTagSettingsCalculationType);
        #endregion

        #region VTag settings
        public static ComboBox VTagSettingsCommodityComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxVTagSettingsCommodity);
        public static ComboBox VTagSettingsUomComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxVTagSettingsUom);
        public static ComboBox VTagSettingsCalculationTypeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxVTagSettingsCalculationType);
        public static ComboBox VTagSettingsCalculationStepComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxVTagSettingsCalculationStep);
        #endregion
        

        #region KPITag settings
        public static ComboBox KPITagSettingsUomComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxKPITagSettingsUom);
        public static ComboBox KPITagSettingsCalculationTypeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxKPITagSettingsCalculationType);
        public static ComboBox KPITagSettingsCalculationStepComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxKPITagSettingsCalculationStep);
        #endregion
        #endregion

        #region Platform settings
        #region Workday
        public static ComboBox WorkdayCalendarSpecialDateTypeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorkdayCalendarSpecialDateType, 1);
        public static ComboBox WorkdayCalendarStartMonthComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorkdayCalendarStartMonth, 1);
        public static ComboBox WorkdayCalendarStartDateComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorkdayCalendarStartDate, 1);
        public static ComboBox WorkdayCalendarEndMonthComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorkdayCalendarEndMonth, 1);
        public static ComboBox WorkdayCalendarEndDateComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorkdayCalendarEndDate, 1);
        #endregion

        #region Worktime
        public static ComboBox WorktimeCalendarStartTimeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorktimeCalendarStartTime, 1);
        public static ComboBox WorktimeCalendarEndTimeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorktimeCalendarEndTime, 1);
        #endregion

        #endregion
    }
}
