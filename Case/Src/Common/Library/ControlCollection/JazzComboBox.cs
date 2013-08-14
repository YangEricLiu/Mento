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

        #region Login
        public static ComboBox LoginCustomerOptionComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxLoginCustomerOption);
        #endregion

        #region Energy view
        public static ComboBox EnergyViewStartTimeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxEnergyViewStartTime);
        public static ComboBox EnergyViewEndTimeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxEnergyViewEndTime);
        public static ComboBox EnergyViewSaveDashboardHierarchyComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxEnergyViewSaveDashboardHierarchy);
        public static ComboBox EnergyViewSaveDashboardDashboardComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxEnergyViewSaveDashboardDashboard);
        public static ComboBox BaseIntervalDialogStartTimeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxIntervalDialogBaseStartTime);
        public static ComboBox BaseIntervalDialogEndTimeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxIntervalDialogBaseEndTime);

        #endregion

        #region Customer settings
        #region Hierarchy property settings
        public static ComboBox HierarchySettingsHierarchyTypeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHierarchySettingsHierarchyType);

        public static ComboBox WorkdayEffectiveYearComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorkdayEffectiveYear, 1);
        public static ComboBox WorkdayCalendarNameComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorkdayCalendarName, 1);
        public static ComboBox WorktimeCalendarNameComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorktimeCalendarName, 1);

        public static ComboBox HeatingCoolingEffectiveYearComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHeatingCoolingEffectiveYear, 1);
        public static ComboBox HeatingCoolingCalendarNameComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHeatingCoolingCalendarName, 1);

        public static ComboBox DayNightEffectiveYearComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxDayNightEffectiveYear, 1);
        public static ComboBox DayNightCalendarNameComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxDayNightCalendarName, 1);

        public static ComboBox ElectricPriceModeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxElectricPriceMode, 1);
        public static ComboBox DemandCostTypeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxDemandCostType, 1);
        public static ComboBox TouTariffIdComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTouTariffId, 1);
        public static ComboBox FactorTypeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxFactorType, 1);
        public static ComboBox RealTagIdComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxRealTagId, 1);
        public static ComboBox ReactiveTagIdComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxReactiveTagId, 1);
        public static ComboBox HourTagIdComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHourTagId, 1);
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
        public static ComboBox KPITargetBaselineEffectiveYearComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxKPITargetBaselineEffectiveYear);
        public static ComboBox KPITargetBaselineWorkdayRuleEndTimeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxKPITargetBaselineWorkdayRuleEndTime);
        public static ComboBox KPITargetBaselineNonworkdayRuleEndTimeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxKPITargetBaselineNonworkdayRuleEndTime);
        public static ComboBox KPITargetBaselineSpecialdayRuleStartTimeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxKPITargetBaselineSpecialdayRuleStartTime);
        public static ComboBox KPITargetBaselineSpecialdayRuleEndTimeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxKPITargetBaselineSpecialdayRuleEndTime);        
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

        #region HeatingCoolingSeason
        public static ComboBox HeatingCoolingSeasonCalendarWarmStartMonthComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarWarmStartMonth, 1);
        public static ComboBox HeatingCoolingSeasonCalendarWarmStartDateComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarWarmStartDate, 1);
        public static ComboBox HeatingCoolingSeasonCalendarWarmEndMonthComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarWarmEndMonth, 1);
        public static ComboBox HeatingCoolingSeasonCalendarWarmEndDateComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarWarmEndDate, 1);
        public static ComboBox HeatingCoolingSeasonCalendarColdStartMonthComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarColdStartMonth, 1);
        public static ComboBox HeatingCoolingSeasonCalendarColdStartDateComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarColdStartDate, 1);
        public static ComboBox HeatingCoolingSeasonCalendarColdEndMonthComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarColdEndMonth, 1);
        public static ComboBox HeatingCoolingSeasonCalendarColdEndDateComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarColdEndDate, 1);
        #endregion

        #region DayNight
        public static ComboBox DayNightCalendarStartTimeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxDayNightCalendarStartTime, 1);
        public static ComboBox DayNightCalendarEndTimeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxDayNightCalendarEndTime, 1);
        #endregion

        #region Carbonfactor
        public static ComboBox CarbonFactorSourceComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxCarbonFactorSource, 1);
        public static ComboBox CarbonFactorDestinationComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxCarbonFactorDestination, 1);
        public static ComboBox CarbonFactorEffectiveYearComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxCarbonFactorEffectiveYear, 1);
        #endregion

        #region TOU
        public static ComboBox TOUBasicPropertyPeakStartTimeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUBasicPropertyPeakStartTime, 1);
        public static ComboBox TOUBasicPropertyPeakEndTimeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUBasicPropertyPeakEndTime, 1);
        public static ComboBox TOUBasicPropertyValleyStartTimeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUBasicPropertyValleyStartTime, 1);
        public static ComboBox TOUBasicPropertyValleyEndTimeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUBasicPropertyValleyEndTime, 1);
        public static ComboBox TOUPulsePeakPropertyStartMonthComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUPulsePeakPropertyStartMonth, 1);
        public static ComboBox TOUPulsePeakPropertyStartDateComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUPulsePeakPropertyStartDate, 1);
        public static ComboBox TOUPulsePeakPropertyEndMonthComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUPulsePeakPropertyEndMonth, 1);
        public static ComboBox TOUPulsePeakPropertyEndDateComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUPulsePeakPropertyEndDate, 1);
        public static ComboBox TOUPulsePeakPropertyStartTimeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUPulsePeakPropertyStartTime, 1);
        public static ComboBox TOUPulsePeakPropertyEndTimeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUPulsePeakPropertyEndTime, 1);
        #endregion

        #region User Setting
        public static ComboBox UserTypeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxUserType, 1);
        public static ComboBox UserAssociatedCustomerComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxUserAssociatedCustomer, 1);

        public static ComboBox UserTitleComboxBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboxBoxUserTitle, 1);
        #endregion

        #region User Profile
        public static ComboBox UserProfileTypeComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxUserProfileType, 1);
        public static ComboBox UserProfileAssociatedCustomerComboBox = GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxUserProfileAssociatedCustomer, 1);
        #endregion


        #endregion
    }
}
