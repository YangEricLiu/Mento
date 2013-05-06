using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzMonthPicker : JazzControlCollection
    {
        #region Get Position MonthPicker Method
        public static MonthPicker GetOneMonthPicker(string key, int positionIndex)
        {
            return GetControl<MonthPicker>(key, positionIndex);
        }
        #endregion

        #region customer setting
        #region hierarchy people area property
        public static MonthPicker PeopleEffectiveDateMonthPicker = GetControl<MonthPicker>(JazzControlLocatorKey.MonthPickerPeopleEffectiveDate, 1);
        public static MonthPicker ElectricCostEffectiveDateMonthPicker = GetControl<MonthPicker>(JazzControlLocatorKey.MonthPickerElectricCostEffectiveDate, 1);
        public static MonthPicker WaterCostEffectiveDateMonthPicker = GetControl<MonthPicker>(JazzControlLocatorKey.MonthPickerWaterCostEffectiveDate);
        public static MonthPicker GasCostEffectiveDateMonthPicker = GetControl<MonthPicker>(JazzControlLocatorKey.MonthPickerGasCostEffectiveDate, 2);
        public static MonthPicker HeatQCostEffectiveDateMonthPicker = GetControl<MonthPicker>(JazzControlLocatorKey.MonthPickerHeatQCostEffectiveDate, 2);
        public static MonthPicker CoolQCostEffectiveDateMonthPicker = GetControl<MonthPicker>(JazzControlLocatorKey.MonthPickerCoolQCostEffectiveDate, 2);
        public static MonthPicker LightWaterCostEffectiveDateMonthPicker = GetControl<MonthPicker>(JazzControlLocatorKey.MonthPickerLightWaterCostEffectiveDate, 2);
        public static MonthPicker CoalCostEffectiveDateMonthPicker = GetControl<MonthPicker>(JazzControlLocatorKey.MonthPickerCoalCostEffectiveDate, 2);
        public static MonthPicker PetrolCostEffectiveDateMonthPicker = GetControl<MonthPicker>(JazzControlLocatorKey.MonthPickerPetrolCostEffectiveDate, 2);
        public static MonthPicker KeroseneCostEffectiveDateMonthPicker = GetControl<MonthPicker>(JazzControlLocatorKey.MonthPickerKeroseneCostEffectiveDate, 2);
        public static MonthPicker DieselOilCostEffectiveDateMonthPicker = GetControl<MonthPicker>(JazzControlLocatorKey.MonthPickerDieselOilCostEffectiveDate, 2);
        public static MonthPicker LowPressureSteamCostEffectiveDateMonthPicker = GetControl<MonthPicker>(JazzControlLocatorKey.MonthPickerLowPressureSteamCostEffectiveDate, 2);
        #endregion
        #endregion
    }
}
