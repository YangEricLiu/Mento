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
            return GetControl<ComboBox>(key, positionIndex) ;
        }
        #endregion

        #region Login
        public static ComboBox LoginCustomerOptionComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxLoginCustomerOption);}}
        #endregion

        #region Energy view
        public static ComboBox EnergyViewStartTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxEnergyViewStartTime);}}
        public static ComboBox EnergyViewEndTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxEnergyViewEndTime);}}
        public static ComboBox EnergyViewSaveDashboardHierarchyComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxEnergyViewSaveDashboardHierarchy);}}
        public static ComboBox EnergyViewSaveDashboardDashboardComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxEnergyViewSaveDashboardDashboard);}}
        public static ComboBox BaseIntervalDialogStartTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxIntervalDialogBaseStartTime);}}
        public static ComboBox BaseIntervalDialogEndTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxIntervalDialogBaseEndTime);}}
        public static ComboBox WidgetMaxDialogDefaultTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWidgetMaxDialogDefaultTime);}}
        public static ComboBox LabelingYearComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxLabelingYear);}}
        public static ComboBox LabelingMonthComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxLabelingMonth);}}
        public static ComboBox TimeTypeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTimeType);}}


        #endregion

        #region Customer settings
        #region Hierarchy property settings
        public static ComboBox HierarchySettingsHierarchyTypeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHierarchySettingsHierarchyType);}}
        public static ComboBox HierarchyIndustryIdComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHierarchyIndustryId);}}
        public static ComboBox HierarchyZoneIdComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHierarchyZoneId);}}

        public static ComboBox WorkdayEffectiveYearComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorkdayEffectiveYear, 1);}}
        public static ComboBox WorkdayCalendarNameComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorkdayCalendarName, 1);}}
        public static ComboBox WorktimeCalendarNameComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorktimeCalendarName, 1);}}

        public static ComboBox HeatingCoolingEffectiveYearComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHeatingCoolingEffectiveYear, 1);}}
        public static ComboBox HeatingCoolingCalendarNameComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHeatingCoolingCalendarName, 1);}}

        public static ComboBox DayNightEffectiveYearComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxDayNightEffectiveYear, 1);}}
        public static ComboBox DayNightCalendarNameComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxDayNightCalendarName, 1);}}

        public static ComboBox ElectricPriceModeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxElectricPriceMode, 1);}}
        public static ComboBox DemandCostTypeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxDemandCostType, 1);}}
        public static ComboBox TouTariffIdComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTouTariffId, 1);}}
        public static ComboBox FactorTypeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxFactorType, 1);}}
        public static ComboBox RealTagIdComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxRealTagId, 1);}}
        public static ComboBox ReactiveTagIdComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxReactiveTagId, 1);}}
        public static ComboBox HourTagIdComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHourTagId, 1);}}
        #endregion
        
        #region PTag settings
        public static ComboBox PTagSettingsCommodityComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxPTagSettingsCommodity);}}
        public static ComboBox PTagSettingsUomComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxPTagSettingsUom);}}
        public static ComboBox PTagSettingsCalculationTypeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxPTagSettingsCalculationType);}}
        #endregion

        #region VTag settings
        public static ComboBox VTagSettingsCommodityComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxVTagSettingsCommodity);}}
        public static ComboBox VTagSettingsUomComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxVTagSettingsUom);}}
        public static ComboBox VTagSettingsCalculationTypeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxVTagSettingsCalculationType);}}
        public static ComboBox VTagSettingsCalculationStepComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxVTagSettingsCalculationStep);}}
        #endregion
        
        #region KPITag settings
        public static ComboBox KPITagSettingsUomComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxKPITagSettingsUom);}}
        public static ComboBox KPITagSettingsCalculationTypeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxKPITagSettingsCalculationType);}}
        public static ComboBox KPITagSettingsCalculationStepComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxKPITagSettingsCalculationStep);}}
        public static ComboBox KPITargetBaselineEffectiveYearComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxKPITargetBaselineEffectiveYear);}}
        public static ComboBox KPITargetBaselineWorkdayRuleEndTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxKPITargetBaselineWorkdayRuleEndTime);}}
        public static ComboBox KPITargetBaselineNonworkdayRuleEndTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxKPITargetBaselineNonworkdayRuleEndTime);}}
        public static ComboBox KPITargetBaselineSpecialdayRuleStartTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxKPITargetBaselineSpecialdayRuleStartTime);}}
        public static ComboBox KPITargetBaselineSpecialdayRuleEndTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxKPITargetBaselineSpecialdayRuleEndTime);}}        
        #endregion

        #region CustomizedLabellingSetting
        public static ComboBox CustomizedLabellingCommodityComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxCustomizedLabellingCommodity);}}
        public static ComboBox CustomizedLabellingUomComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxCustomizedLabellingUom);}}
        public static ComboBox CustomizedLabellingTypeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxCustomizedLabellingType);}}
        public static ComboBox CustomizedLabellingLevelComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxCustomizedLabellingLevel);}}
        #endregion

        #region PTagRawData
        public static ComboBox PTagRawDataStartTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxPTagRawDataStartTime);}}
        public static ComboBox PTagRawDataEndTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxPTagRawDataEndTime);}}
        #endregion
        #endregion

        #region Platform settings
        #region Workday
        public static ComboBox WorkdayCalendarSpecialDateTypeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorkdayCalendarSpecialDateType, 1);}}
        public static ComboBox WorkdayCalendarStartMonthComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorkdayCalendarStartMonth, 1);}}
        public static ComboBox WorkdayCalendarStartDateComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorkdayCalendarStartDate, 1);}}
        public static ComboBox WorkdayCalendarEndMonthComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorkdayCalendarEndMonth, 1);}}
        public static ComboBox WorkdayCalendarEndDateComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorkdayCalendarEndDate, 1);}}
        #endregion 

        #region Worktime
        public static ComboBox WorktimeCalendarStartTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorktimeCalendarStartTime, 1);}}
        public static ComboBox WorktimeCalendarEndTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWorktimeCalendarEndTime, 1);}}
        #endregion

        #region HeatingCoolingSeason
        public static ComboBox HeatingCoolingSeasonCalendarColdWarmTypeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarColdWarmType, 1);}}
        public static ComboBox HeatingCoolingSeasonCalendarColdWarmStartMonthComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarColdWarmStartMonth, 1);}}
        public static ComboBox HeatingCoolingSeasonCalendarColdWarmStartDateComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarColdWarmStartDate, 1);}}
        public static ComboBox HeatingCoolingSeasonCalendarColdWarmEndMonthComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarColdWarmEndMonth, 1);}}
        public static ComboBox HeatingCoolingSeasonCalendarColdWarmEndDateComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarColdWarmEndDate, 1);}}
        #endregion

        #region DayNight
        public static ComboBox DayNightCalendarStartTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxDayNightCalendarStartTime, 1);}}
        public static ComboBox DayNightCalendarEndTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxDayNightCalendarEndTime, 1);}}
        #endregion

        #region Carbonfactor
        public static ComboBox CarbonFactorSourceComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxCarbonFactorSource, 1);}}
        public static ComboBox CarbonFactorDestinationComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxCarbonFactorDestination, 1);}}
        public static ComboBox CarbonFactorEffectiveYearComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxCarbonFactorEffectiveYear, 1);}}
        #endregion

        #region TOU
        public static ComboBox TOUBasicPropertyPeakStartTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUBasicPropertyPeakStartTime, 1);}}
        public static ComboBox TOUBasicPropertyPeakEndTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUBasicPropertyPeakEndTime, 1);}}
        public static ComboBox TOUBasicPropertyValleyStartTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUBasicPropertyValleyStartTime, 1);}}
        public static ComboBox TOUBasicPropertyValleyEndTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUBasicPropertyValleyEndTime, 1);}}
        public static ComboBox TOUPulsePeakPropertyStartMonthComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUPulsePeakPropertyStartMonth, 1);}}
        public static ComboBox TOUPulsePeakPropertyStartDateComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUPulsePeakPropertyStartDate, 1);}}
        public static ComboBox TOUPulsePeakPropertyEndMonthComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUPulsePeakPropertyEndMonth, 1);}}
        public static ComboBox TOUPulsePeakPropertyEndDateComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUPulsePeakPropertyEndDate, 1);}}
        public static ComboBox TOUPulsePeakPropertyStartTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUPulsePeakPropertyStartTime, 1);}}
        public static ComboBox TOUPulsePeakPropertyEndTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxTOUPulsePeakPropertyEndTime, 1);}}
        #endregion

        #region User Setting
        public static ComboBox UserTypeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxUserType, 1);}}
        public static ComboBox UserAssociatedCustomerComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxUserAssociatedCustomer, 1);}}

        public static ComboBox UserTitleComboxBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboxBoxUserTitle, 1);}}
        #endregion

        #region User Profile
        public static ComboBox UserProfileRoleTypeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxUserProfileRoleType, 1);}}
        public static ComboBox UserProfileTitleComboBox { get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxUserProfileTitle, 1); } }
        #endregion

        #region BenchMark
        public static ComboBox BenchmarkComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxBenchmark, 1);}}

        #endregion

        #region Labeling
        public static ComboBox IndustryComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxLabelingIndustry, 1);}}
        public static ComboBox ClimateRegionComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxLabelingClimateRegion, 1);}}
        public static ComboBox EnergyEfficiencyLabelingLevelComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxLabelingEnergyEfficiencyLabelingLevel, 1);}}
        public static ComboBox StartYearComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxLabelingStartYear, 1);}}
        public static ComboBox EndYearComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxLabelingEndYear, 1);}}

        #endregion

        #endregion

        #region Home Page

        public static ComboBox WidgetMaxDialogStartTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWidgetMaxDialogStartTime);}}
        public static ComboBox WidgetMaxDialogEndTimeComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxWidgetMaxDialogEndTime);}}

        public static ComboBox MaxWidgetLabelingYearComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxMaxWidgetLabelingYear);}}
        public static ComboBox MaxWidgetLabelingMonthComboBox{ get { return GetControl<ComboBox>(JazzControlLocatorKey.ComboBoxMaxWidgetLabelingMonth);}}

        #endregion
    }
}
 