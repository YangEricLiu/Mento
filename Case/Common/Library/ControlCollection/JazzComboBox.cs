using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzComboBox : JazzControlCollection
    {
        public static ComboBox HierarchySettingsHierarchyTypeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHierarchySettingsHierarchyType);

        public static ComboBox PTagSettingsCommodityComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxPTagSettingsCommodity);
        public static ComboBox PTagSettingsUomComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxPTagSettingsUom);
        public static ComboBox PTagSettingsCalculationTypeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxPTagSettingsCalculationType);

        public static ComboBox VTagSettingsCommodityComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxVTagSettingsCommodity);
        public static ComboBox VTagSettingsUomComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxVTagSettingsUom);
        public static ComboBox VTagSettingsCalculationTypeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxVTagSettingsCalculationType);
        public static ComboBox VTagSettingsCalculationStepComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxVTagSettingsCalculationStep);

        public static ComboBox WorkdayEffectiveYearComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorkdayEffectiveYear);
        public static ComboBox WorkdayCalendarNameComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorkdayCalendarName);
    }
}
