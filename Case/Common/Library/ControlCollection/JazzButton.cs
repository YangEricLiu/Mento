using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzButton : JazzControlCollection
    {
        #region Login buttons
        public static Button LoginSubmitButton = GetControl<Button>(JazzControlLocatorKey.ButtonLoginSubmit);
        #endregion

        #region EnergyView buttons
        public static Button EnergyViewSelectHierarchyButton = GetControl<Button>(JazzControlLocatorKey.ButtonSelectHierarchy);

        public static TabButton EnergyViewALLTagsTab = GetControl<TabButton>(JazzControlLocatorKey.TabButtonEnergyViewALLTagsTab);
        public static TabButton EnergyViewSystemDimensionTagsTab = GetControl<TabButton>(JazzControlLocatorKey.TabButtonEnergyViewSystemDimensionTagsTab);
        public static TabButton EnergyViewAreaDimensionTagsTab = GetControl<TabButton>(JazzControlLocatorKey.TabButtonEnergyViewAreaDimensionTagsTab);

        public static SplitButton EnergyViewViewDataButton = GetControl<SplitButton>(JazzControlLocatorKey.SplitButtonEnergyViewViewData);
        public static MenuButton EnergyViewMoreButton = GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonEnergyViewMore);
        #endregion

        #region Navigator buttons
        //level 1
        public static Button NavigatorHomePageButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorHomePage);//{NavigationTarget.HomePage,new NavigatorItem( NavigationTarget.HomePage, null, "header-btn-homepage-btnEl",ByType.ID)},
        public static Button NavigatorEnergyViewButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorEnergyView);//{NavigationTarget.EnergyView, new NavigatorItem(NavigationTarget.EnergyView, null,"header-btn-energyservice-btnEl",ByType.ID)},
        public static Button NavigatorSettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorSettings);//{NavigationTarget.Settings, new NavigatorItem(NavigationTarget.Settings,null,"header-btn-setting-btnEl",ByType.ID)},
        public static Button NavigatorPlatformSettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorPlatformSettings);//{NavigationTarget.PlatformSettings, new NavigatorItem(NavigationTarget.PlatformSettings,NavigationTarget.Settings,"setting-tab-platformsetting-btn-btnEl",ByType.ID)},

        //level 2
        public static Button NavigatorEnergyAnalysisButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorEnergyAnalysis);
        public static Button NavigatorCarbonUsageButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorCarbonUsage);
        public static Button NavigatorCostButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorCost);
        public static Button NavigatorKPIButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorKPI);

        public static Button NavigatorTimeSettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTimeSettings);
        public static Button NavigatorCarbonSettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorCarbonSettings);
        public static Button NavigatorPriceSettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorPriceSettings);
        public static Button NavigatorCustomerManagementButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorCustomerManagement);
        public static Button NavigatorUserManagementButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorUserManagement);

        public static Button NavigatorTagSettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTagSettings);//{NavigationTarget.TagSettings, new NavigatorItem(NavigationTarget.TagSettings,NavigationTarget.Settings,"setting-tab-tagmrg-btn-btnEl",ByType.ID)},
        public static Button NavigatorHierarchySettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorHierarchySettings);//{NavigationTarget.HierarchySettings, new NavigatorItem(NavigationTarget.HierarchySettings,NavigationTarget.Settings,"setting-tab-hiersetting-btn-btnEl",ByType.ID)},
        public static Button NavigatorAssociationSettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorAssociationSettings);//{NavigationTarget.AssociationSettings, new NavigatorItem(NavigationTarget.AssociationSettings,NavigationTarget.Settings,"setting-tab-tagassoc-btn-btnEl",ByType.ID)},

        //level 3
        //--Time
        public static Button NavigatorTimeSettingsWorkdayButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTimeSettingsWorkday);//{NavigationTarget.PlatformWorkday, new NavigatorItem(NavigationTarget.PlatformWorkday,NavigationTarget.PlatformSettings,"st-menu-workday-btnEl",ByType.ID)},
        public static Button NavigatorTimeSettingsWorktimeButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTimeSettingsWorktime);//{NavigationTarget.PlatformWorktime, new NavigatorItem(NavigationTarget.PlatformWorktime,NavigationTarget.PlatformSettings,"st-menu-worktime-btnInnerEl",ByType.ID)},
        public static Button NavigatorTimeSettingsSeasonButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTimeSettingsSeason);//{NavigationTarget.PlatformSeason, new NavigatorItem(NavigationTarget.PlatformSeason,NavigationTarget.PlatformSettings,"st-menu-coldwarm-btnEl",ByType.ID)},
        public static Button NavigatorTimeSettingsDaynightButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTimeSettingsDaynight);//{NavigationTarget.PlatformDaynight, new NavigatorItem(NavigationTarget.PlatformDaynight,NavigationTarget.PlatformSettings,"st-menu-daynight-btnEl",ByType.ID)},
        //--Carbon
        public static Button NavigatorCarbonSettingsCarbonButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorCarbonSettingsCarbon);//{NavigationTarget.PlatformCarbon, new NavigatorItem(NavigationTarget.PlatformCarbon,NavigationTarget.PlatformSettings,"st-menu-carbon-btnEl",ByType.ID)},
        //--Price
        public static Button NavigatorPriceSettingsPriceButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorPriceSettingsPrice);//{NavigationTarget.PlatformPrice, new NavigatorItem(NavigationTarget.PlatformPrice,NavigationTarget.PlatformSettings,"st-menu-price-btnEl",ByType.ID)},
        //--Customer
        public static Button NavigatorCustomerManagementCustomerButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorCustomerManagementCustomer);//{NavigationTarget.PlatformPrice, new NavigatorItem(NavigationTarget.PlatformPrice,NavigationTarget.PlatformSettings,"st-menu-price-btnEl",ByType.ID)},
        //--User
        public static Button NavigatorUserManagementUserButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorUserManagementUser);//{NavigationTarget.PlatformPrice, new NavigatorItem(NavigationTarget.PlatformPrice,NavigationTarget.PlatformSettings,"st-menu-price-btnEl",ByType.ID)},
        public static Button NavigatorUserManagementUserTypePermissionButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorUserManagementUserTypePermission);//{NavigationTarget.PlatformPrice, new NavigatorItem(NavigationTarget.PlatformPrice,NavigationTarget.PlatformSettings,"st-menu-price-btnEl",ByType.ID)},
        //--Tag
        public static Button NavigatorTagSettingsPButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTagSettingsP);//{NavigationTarget.TagSettingsP, new NavigatorItem(NavigationTarget.TagSettingsP,NavigationTarget.TagSettings,"st-menu-ptagmgr-btnEl",ByType.ID)},
        public static Button NavigatorTagSettingsVButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTagSettingsV);//{NavigationTarget.TagSettingsV, new NavigatorItem(NavigationTarget.TagSettingsV,NavigationTarget.TagSettings,"st-menu-vtagmgr-btnEl",ByType.ID)},
        public static Button NavigatorTagSettingsKPIButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTagSettingsKPI);//{NavigationTarget.TagSettingsKPI, new NavigatorItem(NavigationTarget.TagSettingsKPI, NavigationTarget.TagSettings,"st-menu-kpimgr-btnEl",ByType.ID)},
        //--Hierarchy
        public static Button NavigatorHierarchySettingsHierarchyButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorHierarchySettingsHierarchy);//{NavigationTarget.HierarchySettingsHierarchy, new NavigatorItem(NavigationTarget.HierarchySettingsHierarchy, NavigationTarget.HierarchySettings,"st-menu-hierarchy-btnEl",ByType.ID)},
        public static Button NavigatorHierarchySettingsSystemDimensionButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorHierarchySettingsSystemDimension);//{NavigationTarget.HierarchySettingsSystemDimension, new NavigatorItem(NavigationTarget.HierarchySettingsSystemDimension,NavigationTarget.HierarchySettings,"st-menu-systemdimension-btnEl",ByType.ID)},
        public static Button NavigatorHierarchySettingsAreaDimensionButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorHierarchySettingsAreaDimension);//{NavigationTarget.HierarchySettingsAreaDimension, new NavigatorItem(NavigationTarget.HierarchySettingsAreaDimension,NavigationTarget.HierarchySettings,"st-menu-areadimension-btnEl",ByType.ID)},
        //--Association
        public static Button NavigatorAssociationHierarchyButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorAssociationHierarchy);//{NavigationTarget.AssociationHierarchy, new NavigatorItem(NavigationTarget.AssociationHierarchy, NavigationTarget.AssociationSettings,"st-menu-hierarchytags-btnEl",ByType.ID)},
        public static Button NavigatorAssociationSystemDimensionButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorAssociationSystemDimension);//{NavigationTarget.AssociationSystemDimension, new NavigatorItem(NavigationTarget.AssociationSystemDimension,NavigationTarget.AssociationSettings,"st-menu-systemdtags-btnEl",ByType.ID)},
        public static Button NavigatorAssociationAreaDimensionButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorAssociationAreaDimension);//{NavigationTarget.AssociationAreaDimension, new NavigatorItem(NavigationTarget.AssociationAreaDimension,NavigationTarget.AssociationSettings,"st-menu-areadtags-btnEl",ByType.ID)},
        #endregion

        #region Customer settings buttons
        #region Hierarchy settings buttons
        public static Button HierarchySettingsCreateChildHierarchyButton = GetControl<Button>(JazzControlLocatorKey.ButtonHierarchySettingsCreateChildHierarchy);
        public static Button HierarchySettingsModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonHierarchySettingsModify);
        public static Button HierarchySettingsSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonHierarchySettingsSave);
        public static Button HierarchySettingsCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonHierarchySettingsCancel);
        public static Button HierarchySettingsDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonHierarchySettingsDelete);

        #region Hierarchy property settings buttons
        public static TabButton CalendarPropertyTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonCalendarProperty);
        public static Button CalendarCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonCalendarCreate);
        public static Button CalendarSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonCalendarSave);
        public static Button CalendarUpdateButton = GetControl<Button>(JazzControlLocatorKey.ButtonCalendarUpdate);
        public static Button CalendarCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonCalendarCancel);
        public static Button WorkdayCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonWorkdayCreate);
        public static Button HeatingCoolingCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonHeatingCoolingCreate);
        public static Button DayNightCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonDayNightCreate);
        public static LinkButton WorktimeCreateButton = GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonWorktimeCreate, 1);

        public static TabButton PeopleAreaPropertyTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonPeopleAreaProperty);
        public static Button PeopleAreaCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonPeopleAreaCreate);
        public static Button PeopleAreaSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonPeopleAreaSave);
        public static Button PeopleCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonPeopleCreate);
        public static Button PeopleAreaUpdateButton = GetControl<Button>(JazzControlLocatorKey.ButtonPeopleAreaUpdate);
        public static Button PeopleAreaCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonPeopleAreaCancel);

        public static TabButton CostPropertyTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonCostProperty);
        public static Button CostCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonCostCreate);
        public static Button CostSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonCostSave);
        public static Button CostCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonCostCancel);
        public static Button CostUpdateButton  = GetControl<Button>(JazzControlLocatorKey.ButtonCostUpdate);
        public static Button ElectricCostCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonElectricCostCreate);
        public static Button GasCostCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonGasCostCreate);
        public static Button WaterCostCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonWaterCostCreate);
        public static Button HeatQCostCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonHeatQCostCreate);
        public static Button CoolQCostCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonCoolQCostCreate);
        public static Button LightWaterCostCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonLightWaterCostCreate);
        public static Button CoalCostCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonCoalCostCreate);
        public static Button PetrolCostCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonPetrolCostCreate);
        public static Button KeroseneCostCreate = GetControl<Button>(JazzControlLocatorKey.ButtonKeroseneCostCreate);
        public static Button DieselOilCostCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonDieselOilCostCreate);
        public static Button LowPressureSteamCostCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonLowPressureSteamCostCreate);
        #endregion
        #endregion

        #region PTag settings buttons
        public static Button PTagSettingsCreatePTagButton = GetControl<Button>(JazzControlLocatorKey.ButtonPTagSettingsCreatePTag);

        public static Button PTagSettingsModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonPTagSettingsModify);
        public static Button PTagSettingsSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonPTagSettingsSave);
        public static Button PTagSettingsCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonPTagSettingsCancel);
        public static Button PTagSettingsDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonPTagSettingsDelete);
        #endregion

        #region VTag settings buttons
        public static TabButton VTagSettingsBasicPropertyTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonVTagSettingsBasicProperty);
        public static TabButton VTagSettingsFormulaTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonVTagSettingsFormula);
        public static Button VTagSettingsFormulaUpdate = GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsFormulaUpdate);
        public static Button VTagSettingsFormulaSave = GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsFormulaSave);

        public static Button VTagSettingsCreateVTagButton = GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsCreateVTag);

        public static Button VTagSettingsModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsModify);
        public static Button VTagSettingsSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsSave);
        public static Button VTagSettingsCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsCancel);
        public static Button VTagSettingsDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsDelete);
        #endregion

        #region KPITag settings buttons
        public static TabButton KPITagSettingsBasicPropertyTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonKPITagSettingsBasicProperty);
        public static TabButton KPITagSettingsFormulaTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonKPITagSettingsFormula);
        public static Button KPITagSettingsFormulaUpdate = GetControl<Button>(JazzControlLocatorKey.ButtonKPITagSettingsFormulaUpdate);
        public static Button KPITagSettingsFormulaSave = GetControl<Button>(JazzControlLocatorKey.ButtonKPITagSettingsFormulaSave);

        public static Button KPITagSettingsCreateKPITagButton = GetControl<Button>(JazzControlLocatorKey.ButtonKPITagSettingsCreateKPITag);
        public static Button KPITagSettingsModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonKPITagSettingsModify);
        public static Button KPITagSettingsSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonKPITagSettingsSave);
        public static Button KPITagSettingsCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonKPITagSettingsCancel);
        public static Button KPITagSettingsDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonKPITagSettingsDelete);

        public static TabButton KPITargetPropertyTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonKPITargetProperty);
        public static TabButton KPIBaselinePropertyTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonKPIBaselineProperty);
        public static Button KPITargetBaselineCalculationRuleViewButton = GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineCalculationRuleView);
        public static Button KPITargetBaselineCalculationRuleCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineCalculationRuleCreate);
        public static Button KPITargetBaselineCalculationRuleBackButton = GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineCalculationRuleBack);
        public static Button KPITargetBaselineCalculationRuleModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineCalculationRuleModify);
        public static Button KPITargetBaselineCalculateTargetButton = GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineCalculateTarget);
        public static Button KPITargetBaselineCalculateBaselineButton = GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineCalculateBaseline);
        public static Button KPITargetBaselineReviseButton = GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineRevise);
        public static Button KPITargetBaselineSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineSave);
        public static Button KPITargetBaselineCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineCancel);
        public static Button KPITargetBaselineAddSpecialDatesButton = GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineAddSpecialDates);
        public static Button KPITargetBaselineDeleteSpecialDatesButton = GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineDeleteSpecialDates);
        #endregion

        #region System dimension settings buttons
        public static Button SystemDimensionSettingsShowHierarchyTreeButton = GetControl<Button>(JazzControlLocatorKey.ButtonDimensionShowHierarchyTree);

        public static Button SystemDimensionSettingsSetButton = GetControl<Button>(JazzControlLocatorKey.ButtonSystemDimensionSet);
        public static Button SystemDimensionSettingsDialogReturnButton = GetControl<Button>(JazzControlLocatorKey.ButtonSystemDimensionSettingsDialogReturn);
        #endregion

        #region Area dimension settings buttons
        public static Button AreaDimensionShowHierarchyTreeButton = SystemDimensionSettingsShowHierarchyTreeButton;
        public static Button AreaDimensionCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsCreate);

        public static Button AreaDimensionSettingsSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsSave);
        public static Button AreaDimensionSettingsCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsCancel);
        public static Button AreaDimensionSettingsModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsModify);
        public static Button AreaDimensionSettingsDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsDelete);
        #endregion

        #region Association
        public static Button AssociationSettingsTagAssociate = GetControl<Button>(JazzControlLocatorKey.ButtonAssociationSettingsTagAssociate);
        public static Button AssociationSettingsAssociate = GetControl<Button>(JazzControlLocatorKey.ButtonAssociationSettingsAssociate);
        public static Button AssociationSettingsDisassociate = GetControl<Button>(JazzControlLocatorKey.ButtonAssociationSettingsDisassociate);
        public static Button AssociationSettingCancel = GetControl<Button>(JazzControlLocatorKey.ButtonAssociationSettingsCancel);
        #endregion
        #endregion

        #region Platform settings buttons
        #region Workday buttons
        public static Button WorkdayCalendarCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonWorkdayCalendarCreate);
        public static Button WorkdayCalendarModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonWorkdayCalendarModify);
        public static Button WorkdayCalendarSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonWorkdayCalendarSave);
        public static Button WorkdayCalendarCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonWorkdayCalendarCancel);
        public static Button WorkdayCalendarDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonWorkdayCalendarDelete);
        public static Button WorkdayCalendarAddSpecialDatesButton = GetControl<Button>(JazzControlLocatorKey.ButtonWorkdayCalendarAddSpecialDates);
        #endregion
        #region Worktime buttons
        public static Button WorktimeCalendarCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonWorktimeCalendarCreate);
        public static Button WorktimeCalendarModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonWorktimeCalendarModify);
        public static Button WorktimeCalendarSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonWorktimeCalendarSave);
        public static Button WorktimeCalendarCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonWorktimeCalendarCancel);
        public static Button WorktimeCalendarDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonWorktimeCalendarDelete);
        public static LinkButton WorktimeCalendarAddMoreRangesButton = GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonWorktimeCalendarAddMoreRanges);
        #endregion
        #region HeatingCoolingSeason buttons
        public static Button HeatingCoolingSeasonCalendarCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonHeatingCoolingSeasonCalendarCreate);
        public static Button HeatingCoolingSeasonCalendarModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonHeatingCoolingSeasonCalendarModify);
        public static Button HeatingCoolingSeasonCalendarSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonHeatingCoolingSeasonCalendarSave);
        public static Button HeatingCoolingSeasonCalendarCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonHeatingCoolingSeasonCalendarCancel);
        public static Button HeatingCoolingSeasonCalendarDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonHeatingCoolingSeasonCalendarDelete);
        public static LinkButton HeatingCoolingSeasonCalendarAddMoreWarmRangesButton = GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonHeatingCoolingSeasonCalendarAddMoreWarmRanges);
        public static LinkButton HeatingCoolingSeasonCalendarAddMoreColdRangesButton = GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonHeatingCoolingSeasonCalendarAddMoreColdRanges);
        #endregion
        #region DayNight buttons
        public static Button DayNightCalendarCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonDayNightCalendarCreate);
        public static Button DayNightCalendarModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonDayNightCalendarModify);
        public static Button DayNightCalendarSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonDayNightCalendarSave);
        public static Button DayNightCalendarCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonDayNightCalendarCancel);
        public static Button DayNightCalendarDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonDayNightCalendarDelete);
        public static LinkButton DayNightCalendarAddMoreRangesButton = GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonDayNightCalendarAddMoreRanges);
        #endregion
        #region Carbonfactor buttons
        public static Button CarbonFactorCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonCarbonFactorCreate);
        public static Button CarbonFactorModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonCarbonFactorModify);
        public static Button CarbonFactorSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonCarbonFactorSave);
        public static Button CarbonFactorCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonCarbonFactorCancel);
        public static Button CarbonFactorDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonCarbonFactorDelete);
        public static LinkButton CarbonFactorAddMoreRangesButton = GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonCarbonFactorAddMoreRanges);
        
        #endregion

        #region User setting
        public static Button UserCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonUserCreate);
        public static Button UserRefreshButton = GetControl<Button>(JazzControlLocatorKey.ButtonUserRefresh);
        public static Button UserSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonUserSave);
        public static Button UserCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonUserCancel);
        public static Button UserDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonUserDelete);
        public static Button UserModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonUserModify);
        public static Button UserAssociatedCustomerLinkButton = GetControl<Button>(JazzControlLocatorKey.LinkButtonUserAssociatedCustomer);
        public static Button UserGeneratePasswordButton = GetControl<Button>(JazzControlLocatorKey.ButtonUserGeneratePassword);
        #endregion
        #endregion
    }
}