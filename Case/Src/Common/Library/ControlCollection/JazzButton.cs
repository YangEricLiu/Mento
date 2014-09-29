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
        #region Get Position Button Method
        public static Button GetOneButton(string key, int positionIndex)
        {
            return GetControl<Button>(key, positionIndex);
        }

        public static Button GetOneButton(string key, string nameIndex)
        {
            return GetControl<Button>(key, nameIndex);
        }

        public static LinkButton GetOneLinkButton(string key, int positionIndex)
        {
            return GetControl<LinkButton>(key, positionIndex);
        }

        public static LinkButton GetOneLinkButton(string key, string nameIndex)
        {
            return GetControl<LinkButton>(key, nameIndex);
        }

        public static DashboardButton GetOneDashboardButton(string key, string nameIndex)
        {
            return GetControl<DashboardButton>(key, nameIndex);
        }

        public static DashboardButton GetOneDashboardButton(string key, int positionIndex)
        {
            return GetControl<DashboardButton>(key, positionIndex);
        }
        #endregion

        #region Login buttons
        public static Button LoginSubmitButton = GetControl<Button>(JazzControlLocatorKey.ButtonLoginSubmit);
        public static Button LoginCustomerOptionConfirmButton = GetControl<Button>(JazzControlLocatorKey.ButtonLoginCustomerOptionConfirm);
        #endregion

        #region DemoAccess buttons
        public static Button DemoAccessButton = GetControl<Button>(JazzControlLocatorKey.ButtonDemoAccess);
        public static Button SendDemoAccessEmailButton = GetControl<Button>(JazzControlLocatorKey.ButtonSendDemoAccessEmail);
        public static Button ReturnHomepageButton = GetControl<Button>(JazzControlLocatorKey.ButtonReturnHomepage);
        #endregion

        #region ContactUs buttons
        public static Button ContactUsButton = GetControl<Button>(JazzControlLocatorKey.ButtonContactUs);
        public static Button ContactUsConfirmButton = GetControl<Button>(JazzControlLocatorKey.ButtonContactUsConfirm);
        public static Button ContactUsCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonContactUsCancel);
        public static Button ContactUsCloseButton = GetControl<Button>(JazzControlLocatorKey.ButtonContactUsClose);

        #endregion

        #region EnergyManagement buttons

        #region common

        public static Button WidgetSaveHierarchyButton = GetControl<Button>(JazzControlLocatorKey.ButtonWidgetSaveHierarchy);
        
        public static SplitButton EnergyViewViewDataButton = GetControl<SplitButton>(JazzControlLocatorKey.SplitButtonEnergyViewViewData);
        public static MenuButton EnergyViewMoreButton = GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonEnergyViewMore);
        public static SplitButton EnergyViewAddTimeSpanButton = GetControl<SplitButton>(JazzControlLocatorKey.ButtonEnergyViewAddTimeSpan);
        public static Button EnergyViewRemoveAllButton = GetControl<Button>(JazzControlLocatorKey.ButtonEnergyViewRemoveAll);
        public static MenuButton EnergyViewConvertTargetMenuButton = GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonEnergyViewConvertTarget);
        public static MenuButton FuncModeConvertMenuButton = GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonFuncModeConvert);
        public static MenuButton TagModeConvertMenuButton = GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonTagModeConvert);
        public static MenuButton UnitTypeConvertMenuButton = GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonUnitTypeConvert);
        public static MenuButton CarbonUnitTypeConvertMenuButton = GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonCarbonUnitTypeConvert);
        public static MenuButton RadioTypeConvertMenuButton = GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonRadioTypeConvert);
        public static MenuButton RankTypeConvertMenuButton = GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonRankTypeConvert);
        public static Button EnergyViewPeakValleyButton = GetControl<Button>(JazzControlLocatorKey.ButtonEnergyViewPeakValley);
        public static Button ButtonModifyWidgetName = GetControl<Button>(JazzControlLocatorKey.ButtonModifyWidgetName);
        public static Button ModifyWidgetNameSaveButton = GetControl<Button>(JazzControlLocatorKey.ModifyWidgetNameSaveButton);
        public static Button ModifyWidgetNameCancelButton = GetControl<Button>(JazzControlLocatorKey.ModifyWidgetNameCancelButton);
        public static Button ButtonDeleteWidget = GetControl<Button>(JazzControlLocatorKey.ButtonDeleteWidget);
        public static Button DeleteWidgetConfirmButton = GetControl<Button>(JazzControlLocatorKey.DeleteWidgetConfirmButton);
        public static Button DeleteWidgetCancelButton = GetControl<Button>(JazzControlLocatorKey.DeleteWidgetCancelButton);
        public static RadioButton CreateNewDashboardButton = GetControl<RadioButton>(JazzControlLocatorKey.RadioButtonCreateNewDashboard);
        public static Button DashboardHierarchyNameButton = GetControl<Button>(JazzControlLocatorKey.ButtonDashboardHierarchyName);
        public static RadioButton ExistedDashboardButton = GetControl<RadioButton>(JazzControlLocatorKey.RadioButtonExistedDashboard);

        public static ToggleButton EnergyDisplayStepRawButton = GetControl<ToggleButton>(JazzControlLocatorKey.ButtonEnergyDisplayStepRaw);
        public static ToggleButton EnergyDisplayStepHourButton = GetControl<ToggleButton>(JazzControlLocatorKey.ButtonEnergyDisplayStepHour);
        public static ToggleButton EnergyDisplayStepDayButton = GetControl<ToggleButton>(JazzControlLocatorKey.ButtonEnergyDisplayStepDay);
        public static ToggleButton EnergyDisplayStepWeekButton = GetControl<ToggleButton>(JazzControlLocatorKey.ButtonEnergyDisplayStepWeek);
        public static ToggleButton EnergyDisplayStepMonthButton = GetControl<ToggleButton>(JazzControlLocatorKey.ButtonEnergyDisplayStepMonth);
        public static ToggleButton EnergyDisplayStepYearButton = GetControl<ToggleButton>(JazzControlLocatorKey.ButtonEnergyDisplayStepYear);

        public static Button MultipleHierarchyTreeButton = GetControl<Button>(JazzControlLocatorKey.ButtonMultipleHierarchyTree);
        public static TabButton MultipleHierarchyAllTags = GetControl<TabButton>(JazzControlLocatorKey.TabButtonMultipleHierarchyAllTagsTab);
        public static TabButton MultipleHierarchySystemDimensionTab = GetControl<TabButton>(JazzControlLocatorKey.TabButtonMultipleHierarchySystemDimensionTab);
        public static TabButton MultipleHierarchyAreaDimensionTab = GetControl<TabButton>(JazzControlLocatorKey.TabButtonMultipleHierarchyAreaDimensionTab);
        public static Button MultipleHierarchySelectSystemDimensionButton = GetControl<Button>(JazzControlLocatorKey.ButtonMultipleHierarchySelectSystemDimension);
        public static Button MultipleHierarchySelectAreaDimensionButton = GetControl<Button>(JazzControlLocatorKey.ButtonMultipleHierarchySelectAreaDimension);
        public static Button MultipleHierarchyConfirmButton = GetControl<Button>(JazzControlLocatorKey.ButtonMultipleHierarchyConfirm);
        public static Button MultipleHierarchyGiveUpButton = GetControl<Button>(JazzControlLocatorKey.ButtonMultipleHierarchyGiveUp);
        public static Button MultipleHierarchyAddTagsButton = GetControl<Button>(JazzControlLocatorKey.ButtonMultipleHierarchyAddTags);

        public static LinkButton IntervalDialogAddTimeSpanLinkButton = GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonIntervalDialogAddTimeSpan);
        public static Button IntervalDialogConfirmButton = GetControl<Button>(JazzControlLocatorKey.ButtonIntervalDialogConfirm);
        public static Button IntervalDialogGiveUpButton = GetControl<Button>(JazzControlLocatorKey.ButtonIntervalDialogGiveUp);

        public static Button GiveUpStepWindowButton = GetControl<Button>(JazzControlLocatorKey.ButtonGiveUpStepWindow);
        #endregion

        #region Energy Analysis

        public static Button EnergyViewSelectHierarchyButton = GetControl<Button>(JazzControlLocatorKey.ButtonEnergyViewSelectHierarchy);
        public static Button EnergyViewSelectSystemDimensionButton = GetControl<Button>(JazzControlLocatorKey.ButtonEnergyViewSelectSystemDimension);
        public static Button EnergyViewSelectAreaDimensionButton = GetControl<Button>(JazzControlLocatorKey.ButtonEnergyViewSelectAreaDimension);
        public static TabButton EnergyViewALLTagsTab = GetControl<TabButton>(JazzControlLocatorKey.TabButtonEnergyViewALLTagsTab);
        public static TabButton EnergyViewSystemDimensionTagsTab = GetControl<TabButton>(JazzControlLocatorKey.TabButtonEnergyViewSystemDimensionTagsTab);
        public static TabButton EnergyViewAreaDimensionTagsTab = GetControl<TabButton>(JazzControlLocatorKey.TabButtonEnergyViewAreaDimensionTagsTab);

        #endregion

        #region Rank
        
        public static Button RankSelectSystemDimensionButton = GetControl<Button>(JazzControlLocatorKey.ButtonRankSelectSystemDimension);
        public static Button RankSelectHierarchyButton = GetControl<Button>(JazzControlLocatorKey.ButtonRankSelectHierarchy);                
        public static TabButton RankHierarchyTab = GetControl<TabButton>(JazzControlLocatorKey.TabButtonRankHierarchyTab);
        public static TabButton RankSystemDimensionTab = GetControl<TabButton>(JazzControlLocatorKey.TabButtonRankSystemDimensionTab);       
        public static Button ConfirmHierarchyRankButton = GetControl<Button>(JazzControlLocatorKey.ButtonConfirmHierarchyRank);
        public static Button ClearHierarchyRankButton = GetControl<Button>(JazzControlLocatorKey.ButtonClearHierarchyRank);

        public static MenuButton CountSelectorRankingButton = GetControl<MenuButton>(JazzControlLocatorKey.ButtonCountSelectorRanking);
        public static Button CountSelectorRankingButtonTen = GetControl<MenuButton>(JazzControlLocatorKey.ButtonRankingTen);

        #endregion

        #region cost

        public static TabButton CostAreaDimensionTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonCostAreaDimensionTab);
        public static TabButton CostHierarchyTab = GetControl<TabButton>(JazzControlLocatorKey.TabButtonCostHierarchyTab);
        public static TabButton CostSystemDimensionTab = GetControl<TabButton>(JazzControlLocatorKey.TabButtonCostSystemDimensionTab);       

        #endregion

        #region unit

        public static MenuButton IndustryConvertMenuButton = GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonIndustryConvert);
        public static TabButton UnitIndicatorALLTagsTab = GetControl<TabButton>(JazzControlLocatorKey.TabButtonUnitIndicatorALLTagsTab);
        public static TabButton UnitIndicatorSystemDimensionTagsTab = GetControl<TabButton>(JazzControlLocatorKey.TabButtonUnitIndicatorSystemDimensionTagsTab);
        public static TabButton UnitIndicatorAreaDimensionTagsTab = GetControl<TabButton>(JazzControlLocatorKey.TabButtonUnitIndicatorAreaDimensionTagsTab);
        public static MenuButton CarbonIndustryConvertMenuButton = GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonCarbonIndustryConvert);

        #endregion

        #region Labelling

        public static MenuButton LabellingIndustryConvertMenuButton = GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonLabellingIndustryConvert);
        public static MenuButton CustomerLabellingIndustryMenuButton = GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonCustomerLabellingIndustry);
        public static MenuButton IndustryLabellingIndustryMenuButton = GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonIndustryLabellingIndustry);

        #endregion

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
        public static Button NavigatorUnitKPIButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorUnitKPI);
        public static Button NavigatorEnergyRatioButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorEnergyRatio);
        public static Button NavigatorRankButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorRank);
        public static Button NavigatorLabelingButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorLabeling);
       
        public static Button NavigatorTimeSettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTimeSettings);
        public static Button NavigatorCarbonSettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorCarbonSettings);
        public static Button NavigatorPriceSettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorPriceSettings);
        public static Button NavigatorCustomerManagementButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorCustomerManagement);
        public static Button NavigatorUserManagementButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorUserManagement);

        public static Button NavigatorBenchMarkSettingButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorBenchMarkSettings);
        public static Button NavigatorIndustryLabelingSettingButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorIndustryLabelingSettings);

        public static Button NavigatorTagSettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTagSettings);//{NavigationTarget.TagSettings, new NavigatorItem(NavigationTarget.TagSettings,NavigationTarget.Settings,"setting-tab-tagmrg-btn-btnEl",ByType.ID)},
        public static Button NavigatorHierarchySettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorHierarchySettings);//{NavigationTarget.HierarchySettings, new NavigatorItem(NavigationTarget.HierarchySettings,NavigationTarget.Settings,"setting-tab-hiersetting-btn-btnEl",ByType.ID)},
        public static Button NavigatorAssociationSettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorAssociationSettings);//{NavigationTarget.AssociationSettings, new NavigatorItem(NavigationTarget.AssociationSettings,NavigationTarget.Settings,"setting-tab-tagassoc-btn-btnEl",ByType.ID)},
        public static Button CustomerLabellingButton = GetControl<Button>(JazzControlLocatorKey.ButtonCustomerLabelling);//{NavigationTarget.CustomizedLabelling, new NavigatorItem(NavigationTarget.CustomizedLabelling,NavigationTarget.Settings,JazzButton.CustomerLabellingButton)},

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
        //select customer
        public static Button NavigatorSelectedCustomerButton = GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsDelete);

        //Dashboards
        public static Button NavigatorMyFavirateButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorMyFavirate);
        public static Button NavigatorAllDashboardsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorAllDashboards);
        public static Button NavigatorRecentViewButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorRecentView);
        public static Button NavigatorMyShareButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorMyShare);

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

        public static LinkButton WorkdayDeleteButton = GetControl<LinkButton>(JazzControlLocatorKey.ButtonWorkdayDelete, 1);
        public static LinkButton HeatingCoolingDeleteButton = GetControl<LinkButton>(JazzControlLocatorKey.ButtonHeatingCoolingDelete, 1);
        public static LinkButton nDayNightDeleteButton = GetControl<LinkButton>(JazzControlLocatorKey.ButtonDayNightDelete, 1);

        public static TabButton PeopleAreaPropertyTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonPeopleAreaProperty);
        public static Button PeopleAreaCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonPeopleAreaCreate);
        public static Button PeopleAreaSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonPeopleAreaSave);
        public static Button PeopleCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonPeopleCreate);
        public static Button PeopleAreaUpdateButton = GetControl<Button>(JazzControlLocatorKey.ButtonPeopleAreaUpdate);
        public static Button PeopleAreaCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonPeopleAreaCancel);
        public static Button PeopleItemDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonDeletePeopleItem, 1);

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

        public static TabButton PTagRawDataTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonPTagRawData);
        public static Button PTagRawDataModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataModify);
        public static Button PTagRawDataSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataSave);
        public static Button PTagRawDataCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataCancel);
        public static Button PTagRawDataSaveAndSwitchButton = GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataSaveAndSwitch);
        public static Button PTagRawDataDirectlySwitchButton = GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataDirectlySwitch);
        public static Button PTagRawDataCancelSwitchButton = GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataCancelSwitch);
        public static Button PTagRawDataSwitchDifferenceValueButton = GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataSwitchDifferenceValue);
        public static Button PTagRawDataSwitchOriginalValueButton = GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataSwitchOriginalValue);
        public static Button PTagRawDataLeftButton = GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataLeft);
        public static Button PTagRawDataRightButton = GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataRight);

        #endregion

        #region VTag settings buttons
        public static TabButton VTagSettingsBasicPropertyTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonVTagSettingsBasicProperty);
        public static TabButton VTagSettingsFormulaTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonVTagSettingsFormula);
        public static Button VTagSettingsFormulaUpdateButton = GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsFormulaUpdate);
        public static Button VTagSettingsFormulaSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsFormulaSave);
        public static Button VTagSettingsFormulaCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsFormulaCancel);
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
        public static Button KPITagSettingsFormulaCancel = GetControl<Button>(JazzControlLocatorKey.ButtonKPITagSettingsFormulaCancel);

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
        public static Button SystemDimensionSettingsCloseButton = GetControl<Button>(JazzControlLocatorKey.ButtonSystemDimensionSettingsClose);
        #endregion

        #region Area dimension settings buttons
        public static Button AreaDimensionShowHierarchyTreeButton = SystemDimensionSettingsShowHierarchyTreeButton;
        public static Button AreaDimensionCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsCreate);

        public static Button AreaDimensionSettingsSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsSave);
        public static Button AreaDimensionSettingsCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsCancel);
        public static Button AreaDimensionSettingsModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsModify);
        public static Button AreaDimensionSettingsDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsDelete);
        // added 
        //public static Button AreaDimensionSettingsConfirmDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsConfirmDelete);
        //public static Button AreaDimensionSettingsCancelDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsCancelDelete);
        #endregion

        #region Association
        public static Button AssociationSettingsTagAssociate = GetControl<Button>(JazzControlLocatorKey.ButtonAssociationSettingsTagAssociate);
        public static Button AssociationSettingsAssociate = GetControl<Button>(JazzControlLocatorKey.ButtonAssociationSettingsAssociate);
        public static Button AssociationSettingsDisassociate = GetControl<Button>(JazzControlLocatorKey.ButtonAssociationSettingsDisassociate);
        public static Button AssociationSettingCancel = GetControl<Button>(JazzControlLocatorKey.ButtonAssociationSettingsCancel);
        #endregion

        #region TargetBaseline

        public static LinkButton TargetCalendarInfoLinkButton = GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonTargetCalendarInfo);
        public static LinkButton BaselineCalendarInfoLinkButton = GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonBaselineCalendarInfo);
        public static Button CloseTBCalendarWindowButton = GetControl<Button>(JazzControlLocatorKey.ButtonCloseTBCalendarWindow);
        public static Button DeleteSpecialdayItemButton = GetControl<Button>(JazzControlLocatorKey.ButtonDeleteSpecialdayItem);
        
        #endregion
        #region CustomizedLabellingSetting
        public static Button CreatCustomizedLabellingButton = GetControl<Button>(JazzControlLocatorKey.ButtonCustomizedLabellingCreat);
        public static Button SaveCustomizedLabellingButton = GetControl<Button>(JazzControlLocatorKey.ButtonCustomizedLabellingSave);
        public static Button DeleteCustomizedLabellingButton = GetControl<Button>(JazzControlLocatorKey.ButtonCustomizedLabellingDelete);
        public static Button ModifyCustomizedLabellingButton = GetControl<Button>(JazzControlLocatorKey.ButtonCustomizedLabellingModify);
        public static Button CancelCustomizedLabellingButton = GetControl<Button>(JazzControlLocatorKey.ButtonCustomizedLabellingCancel);
        public static RadioButton CustomizedLabellingAscendingOrderButton = GetControl<RadioButton>(JazzControlLocatorKey.ButtonCustomizedLabellingAscendingOrder);
        public static RadioButton CustomizedLabellingDescendingOrderButton = GetControl<RadioButton>(JazzControlLocatorKey.ButtonCustomizedLabellingDescendingOrder);
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
        public static Button WorkdayCalendarDeleteRangeItemButton = GetControl<Button>(JazzControlLocatorKey.ButtonWorkdayDeleteRangeItem);
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
        public static Button HeatingCoolingSeasonCalendarAddMoreColdWarmRangesButton = GetControl<Button>(JazzControlLocatorKey.LinkButtonHeatingCoolingSeasonCalendarAddMoreColdWarmRanges);
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
        public static Button CarbonFactorAddMoreRangesButton = GetControl<LinkButton>(JazzControlLocatorKey.ButtonCarbonFactorAddMoreRanges);
        public static Button CarbonFactorRangeDeleteButton = GetControl<LinkButton>(JazzControlLocatorKey.ButtonCarbonFactorRangeDelete);
        
        #endregion

        #region TOU buttons
        public static Button TOUBasicPropertyCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonTOUBasicPropertyCreate);
        public static Button TOUBasicPropertyModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonTOUBasicPropertyModify);
        public static Button TOUBasicPropertySaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonTOUBasicPropertySave);
        public static Button TOUBasicPropertyCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonTOUBasicPropertyCancel);
        public static Button TOUBasicPropertyDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonTOUBasicPropertyDelete);
        public static LinkButton TOUBasicPropertyAddMorePeakRangesButton = GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonTOUBasicPropertyAddMorePeakRanges);
        public static LinkButton TOUBasicPropertyAddMoreValleyRangesButton = GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonTOUBasicPropertyAddMoreValleyRanges);
        public static LinkButton TOUBasicPropertyDeletePeakRangeItemButton = GetControl<LinkButton>(JazzControlLocatorKey.ButtonTOUBasicPropertyDeletePeakRangeItem);
        public static LinkButton TOUBasicPropertyDeleteValleyRangeItemButton = GetControl<LinkButton>(JazzControlLocatorKey.ButtonTOUBasicPropertyDeleteValleyRangeItem);
        public static TabButton TOUPulsePeakPropertyTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonTOUPulsePeakProperty);
        public static Button TOUPulsePeakPropertyCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonTOUPulsePeakPropertyCreate);
        public static Button TOUPulsePeakPropertyPlusIconButton = GetControl<Button>(JazzControlLocatorKey.ButtonTOUPulsePeakPropertyPlusIcon);        
        public static Button TOUPulsePeakPropertyModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonTOUPulsePeakPropertyModify);
        public static Button TOUPulsePeakPropertySaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonTOUPulsePeakPropertySave);
        public static Button TOUPulsePeakPropertyCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonTOUPulsePeakPropertyCancel);
        public static Button TOUPulsePeakPropertyDeleteWholeRangeButton = GetControl<Button>(JazzControlLocatorKey.ButtonTOUPulsePeakPropertyDeleteWholeRange);
        public static Button TOUPulsePeakPropertyDeleteRangeItemButton = GetControl<Button>(JazzControlLocatorKey.ButtonTOUPulsePeakPropertyDeleteRangeItem);
        public static LinkButton TOUPulsePeakPropertyAddMoreRangesButton = GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonTOUPulsePeakPropertyAddMoreRanges);        
        #endregion

        #region Customer settings buttons
        public static Button AddCustomerButton = GetControl<Button>(JazzControlLocatorKey.ButtonAddCustomer);
        public static Button UploadLogoButton = GetControl<Button>(JazzControlLocatorKey.ButtonUploadLogo);
        public static Button SaveCustomerButton = GetControl<Button>(JazzControlLocatorKey.ButtonSaveCustomer);
        public static Button CancelCustomerButton = GetControl<Button>(JazzControlLocatorKey.ButtonCancelCustomer);
        public static Button DeleteCustomerButton = GetControl<Button>(JazzControlLocatorKey.ButtonDeleteCustomer);
        public static Button UpdateCustomerButton = GetControl<Button>(JazzControlLocatorKey.ButtonUpdateCustomer);

        public static Button SaveCustomerMapPropertyButton = GetControl<Button>(JazzControlLocatorKey.ButtonSaveCustomerMapProperty);
        public static Button CancelCustomerMapPropertyButton = GetControl<Button>(JazzControlLocatorKey.ButtonCancelCustomerMapProperty);
        public static Button ModifyCustomerMapPropertyButton = GetControl<Button>(JazzControlLocatorKey.ButtonModifyCustomerMapProperty);
        public static TabButton BasicPropertyTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonCustomerBasicProperty);
        public static TabButton MapPagePropertyTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonCustomerMapPageProperty);
        #endregion

        #region BenchMark
        public static Button AddBenchMarkButton = GetControl<Button>(JazzControlLocatorKey.ButtonAddBenchMark);
        public static Button SaveBenchMarkButton = GetControl<Button>(JazzControlLocatorKey.ButtonSaveBenchMark);
        public static Button ModifyBenchMarkButton = GetControl<Button>(JazzControlLocatorKey.ButtonModifyBenchMark);
        public static Button CancelBenchMarkButton = GetControl<Button>(JazzControlLocatorKey.ButtonCancelBenchMark);
        public static Button DeleteBenchMarkButton = GetControl<Button>(JazzControlLocatorKey.ButtonDeleteBenchMark);

        #endregion

        #region Labeling
        public static Button AddLabelingButton = GetControl<Button>(JazzControlLocatorKey.ButtonAddLabeling);
        public static Button CancelLabelingButton = GetControl<Button>(JazzControlLocatorKey.ButtonCancelLabeling);
        public static Button SaveLabelingButton = GetControl<Button>(JazzControlLocatorKey.ButtonSaveLabeling);
        public static Button ModifyLabelingButton = GetControl<Button>(JazzControlLocatorKey.ButtonModifyLabeling);
        public static Button DeleteLabelingButton = GetControl<Button>(JazzControlLocatorKey.ButtonDeleteLabeling);

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
        public static Button UserTypePermissionModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonUserTypePermissionModify);
        public static Button UserTypePermissionSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonUserTypePermissionSave);
        public static Button UserTypePermissionCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonUserTypePermissionCancel);
        public static Button UserTypePermissionRefreshButton = GetControl<Button>(JazzControlLocatorKey.ButtonUserTypePermissionRefresh);
        //public static Button TabButtonUserBasicProperties = GetControl<Button>(JazzControlLocatorKey.TabButtonUserBasicProperties);
        //public static Button TabButtonUserDataPermission = GetControl<Button>(JazzControlLocatorKey.TabButtonUserDataPermission);

        public static LinkButton LinkButtonUserViewFunctionDetail = GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonUserViewFunctionDetail);
        public static Button UserSendEmailButton = GetControl<Button>(JazzControlLocatorKey.ButtonUserSendEmail);
        public static Button UserTypePermissionDisplayCloseButton = GetControl<Button>(JazzControlLocatorKey.ButtonUserTypePermissionDisplayClose);

        #endregion

        #region User Profile
        public static Button UserProfileButton = GetControl<Button>(JazzControlLocatorKey.ButtonUserProfile);
        public static Button UserProfileViewMenuButton = GetControl<Button>(JazzControlLocatorKey.MenuButtonUserProfileView);
        public static Button UserProfileSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonUserProfileSave);
        public static Button UserProfileCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonUserProfileCancel);
        public static Button UserProfileModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonUserProfileModify);
        public static Button UserPasswordModifyMenuButton = GetControl<Button>(JazzControlLocatorKey.MenuButtonModifyUserPassword);
        public static Button ExitJazzMenuButton = GetControl<Button>(JazzControlLocatorKey.MenuButtonExitJazz);
        #endregion

        #region UserRoleType
        public static Button CreatFunctionRoleType = GetControl<Button>(JazzControlLocatorKey.ButtonCreatFunctionRoleType);
        public static Button ModifyFunctionRoleType = GetControl<Button>(JazzControlLocatorKey.ButtonModifyFunctionRoleType);
        public static Button CancelFunctionRoleType = GetControl<Button>(JazzControlLocatorKey.ButtonCancelFunctionRoleType);
        public static Button DeleteFunctionRoleType = GetControl<Button>(JazzControlLocatorKey.ButtonDeleteFunctionRoleType);
        public static Button SaveFunctionRoleType = GetControl<Button>(JazzControlLocatorKey.ButtonSaveFunctionRoleType);
        #endregion

        #region User Data Scope Permission
        public static Button ModifyUserDataPermissionButton = GetControl<Button>(JazzControlLocatorKey.ButtonModifyUserDataPermission);
        public static Button SaveUserDataPermissionButton = GetControl<Button>(JazzControlLocatorKey.ButtonSaveUserDataPermission);
        public static Button CancelUserDataPermissionButton = GetControl<Button>(JazzControlLocatorKey.ButtonCancelUserDataPermission);
        public static Button ClosePermissionTreeWindowButton = GetControl<Button>(JazzControlLocatorKey.ButtonClosePermissionTreeWindow);
        public static Button TabButtonUserBasicProperties = GetControl<Button>(JazzControlLocatorKey.TabButtonUserBasicProperties);
        public static Button TabButtonUserDataPermission = GetControl<Button>(JazzControlLocatorKey.TabButtonUserDataPermission);
        public static Button TreeWindowSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonTreeWindowSave);
        public static Button TreeWindowCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonTreeWindowCancel);

        public static Button UserSelectAllDataPermissionButton = GetControl<Button>(JazzControlLocatorKey.ButtonUserSelectAllDataPermission);
        public static Button UserCustomerNamesButton = GetControl<Button>(JazzControlLocatorKey.ButtonCustomerNames);
        public static Button CustomerNamesViewStatusButtons = GetControl<Button>(JazzControlLocatorKey.ButtonCustomerNamesViewStatus);
        public static LinkButton UserCustomerNamesLinkButton = GetControl<LinkButton>(JazzControlLocatorKey.ButtonCustomerNames);

        #endregion
        #endregion

        #region Home page buttons

        #region all dashboards

        public static Button AllDashboardsHierarchyTreeButton = GetControl<Button>(JazzControlLocatorKey.ButtonAllDashboardsHierarchyTree);
        public static MenuButton SelectCustomerMenuButton = GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonSelectCustomer);

        public static Button WidgetMaxDialogViewButton = GetControl<Button>(JazzControlLocatorKey.ButtonWidgetMaxDialogView);
        public static Button WidgetMaxDialogCloseButton = GetControl<Button>(JazzControlLocatorKey.ButtonWidgetMaxDialogClose);
        public static Button WidgetMaxDialogPrevButton = GetControl<Button>(JazzControlLocatorKey.ButtonWidgetMaxDialogPrev);
        public static Button WidgetMaxDialogNextButton = GetControl<Button>(JazzControlLocatorKey.ButtonWidgetMaxDialogNext);
        public static Button HomepageToDashboardButton = GetControl<Button>(JazzControlLocatorKey.ButtonHomepageToDashboard);
        public static Button MaxWidgetLabellingViewButton = GetControl<Button>(JazzControlLocatorKey.ButtonMaxWidgetLabellingView);

        public static Button DashboardShareButton = GetControl<Button>(JazzControlLocatorKey.ButtonDashboardShare);
        public static Button DashboardRenameButton = GetControl<Button>(JazzControlLocatorKey.ButtonDashboardRename);
        public static Button DashboardDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonDashboardDelete);

        public static Button RenameDashboardSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonRenameDashboardSave);
        public static Button RenameDashboardCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonRenameDashboardCancel);
        public static DashboardButton DashboardFavoriteLevelButton = GetControl<DashboardButton>(JazzControlLocatorKey.ButtonDashboardFavoriteLevel);
        public static DashboardButton DashboardShareInfoButton = GetControl<DashboardButton>(JazzControlLocatorKey.ButtonDashboardShareInfo);
        public static Button ShareWindowCloseButton = GetControl<Button>(JazzControlLocatorKey.ButtonShareWindowClose);

        public static Button ShareWindowShareButton = GetControl<Button>(JazzControlLocatorKey.ButtonShareWindowShare);
        public static Button ShareWindowEnjoyButton = GetControl<Button>(JazzControlLocatorKey.ButtonShareWindowEnjoy);
        public static Button ShareWindowGiveupButton = GetControl<Button>(JazzControlLocatorKey.ButtonShareWindowGiveup);

        public static TabButton ShareInfoReceivedTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonShareInfoReceived);
        public static TabButton ShareInfoSendedTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonShareInfoSended);

        public static LinkButton AnnotationEditLinkButton = GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonAnnotationEdit);
        public static LinkButton AnnotationAddLinkButton = GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonAnnotationAdd);

        public static LinkButton MaxWidgetEditCommentLinkButton = GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonMaxWidgetEditComment);
        public static LinkButton MaxWidgetAddCommentLinkButton = GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonMaxWidgetAddComment);     
        public static Button SaveAnnotationWindowButton = GetControl<Button>(JazzControlLocatorKey.ButtonSaveAnnotationWindow);
        public static Button QuitAnnotationWindowButton = GetControl<Button>(JazzControlLocatorKey.ButtonQuitAnnotationWindow);
        public static Button InviteOtherButton = GetControl<Button>(JazzControlLocatorKey.ButtonInviteOther);
        public static Button CloseSubcribeWindowButton = GetControl<Button>(JazzControlLocatorKey.ButtonCloseSubcribeWindow);
        public static Button WidgetConfirmCancelShareButton = GetControl<Button>(JazzControlLocatorKey.WidgetConfirmCancelShareButton);

        #endregion

        #region My Share

        public static Button CancelShareWidgetButton = GetControl<Button>(JazzControlLocatorKey.ButtonCancelShareWidget);
        public static Button CloseWidgetRenameWindowButton = GetControl<Button>(JazzControlLocatorKey.ButtonCloseWidgetRenameWindow);
        public static Button MaxWidgetRightCommentButton = GetControl<Button>(JazzControlLocatorKey.ButtonMaxWidgetRightComment);

        #endregion

        #endregion
    }
}