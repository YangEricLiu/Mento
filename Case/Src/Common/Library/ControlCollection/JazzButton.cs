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
        public static Button LoginSubmitButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonLoginSubmit); }
        }
        public static Button LoginCustomerOptionConfirmButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonLoginCustomerOptionConfirm); }
        }
        #endregion

        #region DemoAccess buttons
        public static Button DemoAccessButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonDemoAccess); }
        }
        public static Button SendDemoAccessEmailButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonSendDemoAccessEmail);}
        }
        public static Button ReturnHomepageButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonReturnHomepage); }
        }
        #endregion

        #region ContactUs buttons
        public static Button ContactUsButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonContactUs);}
        }
        public static Button ContactUsConfirmButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonContactUsConfirm); }
        }
        public static Button ContactUsCancelButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonContactUsCancel);}
        }
        public static Button ContactUsCloseButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonContactUsClose);}
        }

        #endregion

        #region EnergyManagement buttons

        #region common

        public static Button WidgetSaveHierarchyButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonWidgetSaveHierarchy);}
        }
        
        public static SplitButton EnergyViewViewDataButton 
        {
            get { return  GetControl<SplitButton>(JazzControlLocatorKey.SplitButtonEnergyViewViewData);}
        }
        public static MenuButton EnergyViewMoreButton 
        {
            get { return GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonEnergyViewMore); }
        }
        public static SplitButton EnergyViewAddTimeSpanButton 
        {
            get { return  GetControl<SplitButton>(JazzControlLocatorKey.ButtonEnergyViewAddTimeSpan);}
        }
        public static Button EnergyViewRemoveAllButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonEnergyViewRemoveAll);}
        }
        public static MenuButton EnergyViewConvertTargetMenuButton 
        {
            get { return  GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonEnergyViewConvertTarget);}
        }
        public static MenuButton FuncModeConvertMenuButton 
        {
            get { return  GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonFuncModeConvert);}
        }
        public static MenuButton TagModeConvertMenuButton 
        {
            get { return  GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonTagModeConvert);}
        }
        public static MenuButton UnitTypeConvertMenuButton 
        {
            get { return  GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonUnitTypeConvert);}
        }
        public static MenuButton CarbonUnitTypeConvertMenuButton 
        {
            get { return  GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonCarbonUnitTypeConvert);}
        }
        public static MenuButton RadioTypeConvertMenuButton 
        {
            get { return  GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonRadioTypeConvert);}
        }
        public static MenuButton RankTypeConvertMenuButton 
        {
            get { return  GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonRankTypeConvert);}
        }
        public static Button EnergyViewPeakValleyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonEnergyViewPeakValley);}
        }
        public static Button ButtonModifyWidgetName 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonModifyWidgetName);}
        }
        public static Button ModifyWidgetNameSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ModifyWidgetNameSaveButton);}
        }
        public static Button ModifyWidgetNameCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ModifyWidgetNameCancelButton);}
        }
        public static Button ButtonDeleteWidget 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDeleteWidget);}
        }
        public static Button DeleteWidgetConfirmButton
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.DeleteWidgetConfirmButton);}
        }
        public static Button DeleteWidgetCancelButton
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.DeleteWidgetCancelButton);}
        }
        public static RadioButton CreateNewDashboardButton
        {
            get { return  GetControl<RadioButton>(JazzControlLocatorKey.RadioButtonCreateNewDashboard);}
        }
        public static Button DashboardHierarchyNameButton
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDashboardHierarchyName);}
        }
        public static RadioButton ExistedDashboardButton
        {
            get { return  GetControl<RadioButton>(JazzControlLocatorKey.RadioButtonExistedDashboard);}
        }

        public static ToggleButton EnergyDisplayStepRawButton
        {
            get { return  GetControl<ToggleButton>(JazzControlLocatorKey.ButtonEnergyDisplayStepRaw);}
        }
        public static ToggleButton EnergyDisplayStepHourButton
        {
            get { return  GetControl<ToggleButton>(JazzControlLocatorKey.ButtonEnergyDisplayStepHour);}
        }
        public static ToggleButton EnergyDisplayStepDayButton
        {
            get { return  GetControl<ToggleButton>(JazzControlLocatorKey.ButtonEnergyDisplayStepDay);}
        }
        public static ToggleButton EnergyDisplayStepWeekButton
        {
            get { return  GetControl<ToggleButton>(JazzControlLocatorKey.ButtonEnergyDisplayStepWeek);}
        }
        public static ToggleButton EnergyDisplayStepMonthButton
        {
            get { return  GetControl<ToggleButton>(JazzControlLocatorKey.ButtonEnergyDisplayStepMonth);}
        }
        public static ToggleButton EnergyDisplayStepYearButton
        {
            get { return  GetControl<ToggleButton>(JazzControlLocatorKey.ButtonEnergyDisplayStepYear);}
        }

        public static Button MultipleHierarchyTreeButton
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonMultipleHierarchyTree);}
        }
        public static TabButton MultipleHierarchyAllTags
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonMultipleHierarchyAllTagsTab);}
        }
        public static TabButton MultipleHierarchySystemDimensionTab
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonMultipleHierarchySystemDimensionTab);}
        }
        public static TabButton MultipleHierarchyAreaDimensionTab 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonMultipleHierarchyAreaDimensionTab);}
        }
        public static Button MultipleHierarchySelectSystemDimensionButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonMultipleHierarchySelectSystemDimension);}
        }
        public static Button MultipleHierarchySelectAreaDimensionButton
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonMultipleHierarchySelectAreaDimension);}
        }
        public static Button MultipleHierarchyConfirmButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonMultipleHierarchyConfirm);}
        }
        public static Button MultipleHierarchyGiveUpButton
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonMultipleHierarchyGiveUp);}
        }
        public static Button MultipleHierarchyAddTagsButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonMultipleHierarchyAddTags);}
        }

        public static LinkButton IntervalDialogAddTimeSpanLinkButton
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonIntervalDialogAddTimeSpan);}
        }
        public static Button IntervalDialogConfirmButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonIntervalDialogConfirm);}
        }
        public static Button IntervalDialogGiveUpButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonIntervalDialogGiveUp);}
        }

        public static Button GiveUpStepWindowButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonGiveUpStepWindow);}
        }

        public static Button UserDefinedTime
        {
            get { return GetControl<Button>(JazzControlLocatorKey.UserDefinedTime);}
        }
        public static Button RelativeTime
        {
            get { return GetControl<Button>(JazzControlLocatorKey.RelativeTime);}
        }
        #endregion

        #region Energy Analysis

        public static Button EnergyViewSelectHierarchyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonEnergyViewSelectHierarchy);}
        }
        public static Button EnergyViewSelectSystemDimensionButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonEnergyViewSelectSystemDimension); }
        }
        public static Button EnergyViewSelectAreaDimensionButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonEnergyViewSelectAreaDimension);}
        }
        public static TabButton EnergyViewALLTagsTab 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonEnergyViewALLTagsTab);}
        }
        public static TabButton EnergyViewSystemDimensionTagsTab 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonEnergyViewSystemDimensionTagsTab);}
        }
        public static TabButton EnergyViewAreaDimensionTagsTab 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonEnergyViewAreaDimensionTagsTab);}
        }

        #endregion

        #region Rank
        
        public static Button RankSelectSystemDimensionButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonRankSelectSystemDimension);}
        }
        public static Button RankSelectHierarchyButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonRankSelectHierarchy); }
        }          
        public static TabButton RankHierarchyTab 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonRankHierarchyTab);}
        }
        public static TabButton RankSystemDimensionTab 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonRankSystemDimensionTab);  }
        }     
        public static Button ConfirmHierarchyRankButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonConfirmHierarchyRank);}
        }
        public static Button ClearHierarchyRankButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonClearHierarchyRank);}
        }

        public static MenuButton CountSelectorRankingButton 
        {
            get { return  GetControl<MenuButton>(JazzControlLocatorKey.ButtonCountSelectorRanking);}
        }
        public static Button CountSelectorRankingButtonTen 
        {
            get { return  GetControl<MenuButton>(JazzControlLocatorKey.ButtonRankingTen);}
        }

        #endregion

        #region cost

        public static TabButton CostAreaDimensionTabButton 
        {
            get { return GetControl<TabButton>(JazzControlLocatorKey.TabButtonCostAreaDimensionTab); }
        }
        public static TabButton CostHierarchyTab 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonCostHierarchyTab);}
        }
        public static TabButton CostSystemDimensionTab 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonCostSystemDimensionTab);  }
        }     

        #endregion

        #region unit

        public static MenuButton IndustryConvertMenuButton 
        {
            get { return  GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonIndustryConvert);}
        }
        public static TabButton UnitIndicatorALLTagsTab 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonUnitIndicatorALLTagsTab);}
        }
        public static TabButton UnitIndicatorSystemDimensionTagsTab 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonUnitIndicatorSystemDimensionTagsTab);}
        }
        public static TabButton UnitIndicatorAreaDimensionTagsTab 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonUnitIndicatorAreaDimensionTagsTab);}
        }
        public static MenuButton CarbonIndustryConvertMenuButton 
        {
            get { return  GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonCarbonIndustryConvert);}
        }

        #endregion

        #region Labelling

        public static MenuButton LabellingIndustryConvertMenuButton 
        {
            get { return  GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonLabellingIndustryConvert);}
        }
        public static MenuButton CustomerLabellingIndustryMenuButton 
        {
            get { return  GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonCustomerLabellingIndustry);}
        }
        public static MenuButton IndustryLabellingIndustryMenuButton 
        {
            get { return  GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonIndustryLabellingIndustry);}
        }

        #endregion

        #endregion

        #region Navigator buttons
        //level 1
        public static Button NavigatorHomePageButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorHomePage);}
        }//{NavigationTarget.HomePage,new NavigatorItem( NavigationTarget.HomePage, null, "header-btn-homepage-btnEl",ByType.ID)},
        public static Button NavigatorEnergyViewButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorEnergyView);}
        }//{NavigationTarget.EnergyView, new NavigatorItem(NavigationTarget.EnergyView, null,"header-btn-energyservice-btnEl",ByType.ID)},
        public static Button NavigatorSettingsButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorSettings);}
        }//{NavigationTarget.Settings, new NavigatorItem(NavigationTarget.Settings,null,"header-btn-setting-btnEl",ByType.ID)},
        public static Button NavigatorPlatformSettingsButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorPlatformSettings);}
        }//{NavigationTarget.PlatformSettings, new NavigatorItem(NavigationTarget.PlatformSettings,NavigationTarget.Settings,"setting-tab-platformsetting-btn-btnEl",ByType.ID)},

        //level 2
        public static Button NavigatorEnergyAnalysisButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorEnergyAnalysis);}
        }
        public static Button NavigatorCarbonUsageButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorCarbonUsage);}
        }
        public static Button NavigatorCostButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorCost);}
        }
        public static Button NavigatorUnitKPIButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorUnitKPI);}
        }
        public static Button NavigatorEnergyRatioButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorEnergyRatio);}
        }
        public static Button NavigatorRankButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorRank);}
        }
        public static Button NavigatorLabelingButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorLabeling);}
        }
       
        public static Button NavigatorTimeSettingsButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTimeSettings);}
        }
        public static Button NavigatorCarbonSettingsButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorCarbonSettings);}
        }
        public static Button NavigatorPriceSettingsButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorPriceSettings);}
        }
        public static Button NavigatorCustomerManagementButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorCustomerManagement);}
        }
        public static Button NavigatorUserManagementButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorUserManagement);}
        }

        public static Button NavigatorBenchMarkSettingButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorBenchMarkSettings);}
        }
        public static Button NavigatorIndustryLabelingSettingButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorIndustryLabelingSettings);}
        }

        public static Button NavigatorTagSettingsButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTagSettings);}
        }//{NavigationTarget.TagSettings, new NavigatorItem(NavigationTarget.TagSettings,NavigationTarget.Settings,"setting-tab-tagmrg-btn-btnEl",ByType.ID)},
        public static Button NavigatorHierarchySettingsButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorHierarchySettings);}
        }//{NavigationTarget.HierarchySettings, new NavigatorItem(NavigationTarget.HierarchySettings,NavigationTarget.Settings,"setting-tab-hiersetting-btn-btnEl",ByType.ID)},
        public static Button NavigatorAssociationSettingsButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorAssociationSettings);}
        }//{NavigationTarget.AssociationSettings, new NavigatorItem(NavigationTarget.AssociationSettings,NavigationTarget.Settings,"setting-tab-tagassoc-btn-btnEl",ByType.ID)},
        public static Button CustomerLabellingButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCustomerLabelling);}
        }//{NavigationTarget.CustomizedLabelling, new NavigatorItem(NavigationTarget.CustomizedLabelling,NavigationTarget.Settings,JazzButton.CustomerLabellingButton)},

        //level 3
        //--Time
        public static Button NavigatorTimeSettingsWorkdayButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTimeSettingsWorkday);}
        }//{NavigationTarget.PlatformWorkday, new NavigatorItem(NavigationTarget.PlatformWorkday,NavigationTarget.PlatformSettings,"st-menu-workday-btnEl",ByType.ID)},
        public static Button NavigatorTimeSettingsWorktimeButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTimeSettingsWorktime);}
        }//{NavigationTarget.PlatformWorktime, new NavigatorItem(NavigationTarget.PlatformWorktime,NavigationTarget.PlatformSettings,"st-menu-worktime-btnInnerEl",ByType.ID)},
        public static Button NavigatorTimeSettingsSeasonButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTimeSettingsSeason);}
        }//{NavigationTarget.PlatformSeason, new NavigatorItem(NavigationTarget.PlatformSeason,NavigationTarget.PlatformSettings,"st-menu-coldwarm-btnEl",ByType.ID)},
        public static Button NavigatorTimeSettingsDaynightButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTimeSettingsDaynight);}
        }//{NavigationTarget.PlatformDaynight, new NavigatorItem(NavigationTarget.PlatformDaynight,NavigationTarget.PlatformSettings,"st-menu-daynight-btnEl",ByType.ID)},
        //--Carbon
        public static Button NavigatorCarbonSettingsCarbonButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorCarbonSettingsCarbon);}
        }//{NavigationTarget.PlatformCarbon, new NavigatorItem(NavigationTarget.PlatformCarbon,NavigationTarget.PlatformSettings,"st-menu-carbon-btnEl",ByType.ID)},
        //--Price
        public static Button NavigatorPriceSettingsPriceButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorPriceSettingsPrice);}
        }//{NavigationTarget.PlatformPrice, new NavigatorItem(NavigationTarget.PlatformPrice,NavigationTarget.PlatformSettings,"st-menu-price-btnEl",ByType.ID)},
        //--Customer
        public static Button NavigatorCustomerManagementCustomerButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorCustomerManagementCustomer);}
        }//{NavigationTarget.PlatformPrice, new NavigatorItem(NavigationTarget.PlatformPrice,NavigationTarget.PlatformSettings,"st-menu-price-btnEl",ByType.ID)},
        //--User
        public static Button NavigatorUserManagementUserButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorUserManagementUser);}
        }//{NavigationTarget.PlatformPrice, new NavigatorItem(NavigationTarget.PlatformPrice,NavigationTarget.PlatformSettings,"st-menu-price-btnEl",ByType.ID)},
        public static Button NavigatorUserManagementUserTypePermissionButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorUserManagementUserTypePermission);}
        }//{NavigationTarget.PlatformPrice, new NavigatorItem(NavigationTarget.PlatformPrice,NavigationTarget.PlatformSettings,"st-menu-price-btnEl",ByType.ID)},
        //--Tag
        public static Button NavigatorTagSettingsPButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTagSettingsP);}
        }//{NavigationTarget.TagSettingsP, new NavigatorItem(NavigationTarget.TagSettingsP,NavigationTarget.TagSettings,"st-menu-ptagmgr-btnEl",ByType.ID)},
        public static Button NavigatorTagSettingsVButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTagSettingsV);}
        }//{NavigationTarget.TagSettingsV, new NavigatorItem(NavigationTarget.TagSettingsV,NavigationTarget.TagSettings,"st-menu-vtagmgr-btnEl",ByType.ID)},
        public static Button NavigatorTagSettingsKPIButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTagSettingsKPI);}
        }//{NavigationTarget.TagSettingsKPI, new NavigatorItem(NavigationTarget.TagSettingsKPI, NavigationTarget.TagSettings,"st-menu-kpimgr-btnEl",ByType.ID)},
        //--Hierarchy
        public static Button NavigatorHierarchySettingsHierarchyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorHierarchySettingsHierarchy);}
        }//{NavigationTarget.HierarchySettingsHierarchy, new NavigatorItem(NavigationTarget.HierarchySettingsHierarchy, NavigationTarget.HierarchySettings,"st-menu-hierarchy-btnEl",ByType.ID)},
        public static Button NavigatorHierarchySettingsSystemDimensionButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorHierarchySettingsSystemDimension);}
        }//{NavigationTarget.HierarchySettingsSystemDimension, new NavigatorItem(NavigationTarget.HierarchySettingsSystemDimension,NavigationTarget.HierarchySettings,"st-menu-systemdimension-btnEl",ByType.ID)},
        public static Button NavigatorHierarchySettingsAreaDimensionButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorHierarchySettingsAreaDimension);}
        }//{NavigationTarget.HierarchySettingsAreaDimension, new NavigatorItem(NavigationTarget.HierarchySettingsAreaDimension,NavigationTarget.HierarchySettings,"st-menu-areadimension-btnEl",ByType.ID)},
        //--Association
        public static Button NavigatorAssociationHierarchyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorAssociationHierarchy);}
        }//{NavigationTarget.AssociationHierarchy, new NavigatorItem(NavigationTarget.AssociationHierarchy, NavigationTarget.AssociationSettings,"st-menu-hierarchytags-btnEl",ByType.ID)},
        public static Button NavigatorAssociationSystemDimensionButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorAssociationSystemDimension);}
        }//{NavigationTarget.AssociationSystemDimension, new NavigatorItem(NavigationTarget.AssociationSystemDimension,NavigationTarget.AssociationSettings,"st-menu-systemdtags-btnEl",ByType.ID)},
        public static Button NavigatorAssociationAreaDimensionButton 
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorAssociationAreaDimension); }//{NavigationTarget.AssociationAreaDimension, new NavigatorItem(NavigationTarget.AssociationAreaDimension,NavigationTarget.AssociationSettings,"st-menu-areadtags-btnEl",ByType.ID)},}
        }
        //select customer
        public static Button NavigatorSelectedCustomerButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsDelete);}
        }

        //Dashboards
        public static Button NavigatorMyFavirateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorMyFavirate);}
        }
        public static Button NavigatorAllDashboardsButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorAllDashboards);}
        }
        public static Button NavigatorRecentViewButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorRecentView);}
        }
        public static Button NavigatorMyShareButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorMyShare);}
        }

        #endregion

        #region Customer settings buttons
        #region Hierarchy settings buttons
        public static Button HierarchySettingsCreateChildHierarchyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonHierarchySettingsCreateChildHierarchy);}
        }
        public static Button HierarchySettingsModifyButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonHierarchySettingsModify); }
        }
        public static Button HierarchySettingsSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonHierarchySettingsSave);}
        }
        public static Button HierarchySettingsCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonHierarchySettingsCancel);}
        }
        public static Button HierarchySettingsDeleteButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonHierarchySettingsDelete);}
        }

        #region Hierarchy property settings buttons
        public static TabButton CalendarPropertyTabButton 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonCalendarProperty);}
        }
        public static Button CalendarCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCalendarCreate);}
        }
        public static Button CalendarSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCalendarSave);}
        }
        public static Button CalendarUpdateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCalendarUpdate);}
        }
        public static Button CalendarCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCalendarCancel);}
        }
        public static Button WorkdayCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonWorkdayCreate);}
        }
        public static Button HeatingCoolingCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonHeatingCoolingCreate);}
        }
        public static Button DayNightCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDayNightCreate);}
        }
        public static LinkButton WorktimeCreateButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonWorktimeCreate, 1);}
        }

        public static LinkButton WorkdayDeleteButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.ButtonWorkdayDelete, 1);}
        }
        public static LinkButton HeatingCoolingDeleteButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.ButtonHeatingCoolingDelete, 1);}
        }
        public static LinkButton nDayNightDeleteButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.ButtonDayNightDelete, 1);}
        }

        public static TabButton PeopleAreaPropertyTabButton 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonPeopleAreaProperty);}
        }
        public static Button PeopleAreaCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPeopleAreaCreate);}
        }
        public static Button PeopleAreaSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPeopleAreaSave);}
        }
        public static Button PeopleCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPeopleCreate);}
        }
        public static Button PeopleAreaUpdateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPeopleAreaUpdate);}
        }
        public static Button PeopleAreaCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPeopleAreaCancel);}
        }
        public static Button PeopleItemDeleteButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDeletePeopleItem, 1);}
        }

        public static TabButton CostPropertyTabButton 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonCostProperty);}
        }
        public static Button CostCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCostCreate);}
        }
        public static Button CostSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCostSave);}
        }
        public static Button CostCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCostCancel);}
        }
        public static Button CostUpdateButton  
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCostUpdate);}
        }
        public static Button ElectricCostCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonElectricCostCreate);}
        }
        public static Button GasCostCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonGasCostCreate);}
        }
        public static Button WaterCostCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonWaterCostCreate);}
        }
        public static Button HeatQCostCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonHeatQCostCreate);}
        }
        public static Button CoolQCostCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCoolQCostCreate);}
        }
        public static Button LightWaterCostCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonLightWaterCostCreate);}
        }
        public static Button CoalCostCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCoalCostCreate);}
        }
        public static Button PetrolCostCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPetrolCostCreate);}
        }
        public static Button KeroseneCostCreate 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKeroseneCostCreate);}
        }
        public static Button DieselOilCostCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDieselOilCostCreate);}
        }
        public static Button LowPressureSteamCostCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonLowPressureSteamCostCreate);}
        }
        #endregion
        #endregion

        #region PTag settings buttons
        public static Button PTagSettingsCreatePTagButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPTagSettingsCreatePTag);}
        }

        public static Button PTagSettingsModifyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPTagSettingsModify);}
        }
        public static Button PTagSettingsSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPTagSettingsSave);}
        }
        public static Button PTagSettingsCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPTagSettingsCancel);}
        }
        public static Button PTagSettingsDeleteButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPTagSettingsDelete);}
        }

        public static TabButton PTagRawDataTabButton
        {
            get { return GetControl<TabButton>(JazzControlLocatorKey.TabButtonPTagRawData); }
        }
        public static Button PTagRawDataModifyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataModify);}
        }
        public static Button PTagRawDataSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataSave);}
        }
        public static Button PTagRawDataCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataCancel);}
        }
        public static Button PTagRawDataSaveAndSwitchButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataSaveAndSwitch);}
        }
        public static Button PTagRawDataDirectlySwitchButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataDirectlySwitch);}
        }
        public static Button PTagRawDataCancelSwitchButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataCancelSwitch);}
        }
        public static Button PTagRawDataSwitchDifferenceValueButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataSwitchDifferenceValue);}
        }
        public static Button PTagRawDataSwitchOriginalValueButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataSwitchOriginalValue);}
        }
        public static Button PTagRawDataLeftButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataLeft);}
        }
        public static Button PTagRawDataRightButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonPTagRawDataRight);}
        }

        #endregion

        #region VTag settings buttons
        public static TabButton VTagSettingsBasicPropertyTabButton
        {
            get { return GetControl<TabButton>(JazzControlLocatorKey.TabButtonVTagSettingsBasicProperty); }
        }
        public static TabButton VTagSettingsFormulaTabButton 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonVTagSettingsFormula);}
        }
        public static Button VTagSettingsFormulaUpdateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsFormulaUpdate);}
        }
        public static Button VTagSettingsFormulaSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsFormulaSave);}
        }
        public static Button VTagSettingsFormulaCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsFormulaCancel);}
        }
        public static Button VTagSettingsCreateVTagButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsCreateVTag);}
        }

        public static Button VTagSettingsModifyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsModify);}
        }
        public static Button VTagSettingsSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsSave);}
        }
        public static Button VTagSettingsCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsCancel);}
        }
        public static Button VTagSettingsDeleteButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsDelete);}
        }
        #endregion

        #region KPITag settings buttons
        public static TabButton KPITagSettingsBasicPropertyTabButton
        {
            get { return GetControl<TabButton>(JazzControlLocatorKey.TabButtonKPITagSettingsBasicProperty); }
        }
        public static TabButton KPITagSettingsFormulaTabButton 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonKPITagSettingsFormula);}
        }
        public static Button KPITagSettingsFormulaUpdate 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITagSettingsFormulaUpdate);}
        }
        public static Button KPITagSettingsFormulaSave 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITagSettingsFormulaSave);}
        }
        public static Button KPITagSettingsFormulaCancel 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITagSettingsFormulaCancel);}
        }

        public static Button KPITagSettingsCreateKPITagButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITagSettingsCreateKPITag);}
        }
        public static Button KPITagSettingsModifyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITagSettingsModify);}
        }
        public static Button KPITagSettingsSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITagSettingsSave);}
        }
        public static Button KPITagSettingsCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITagSettingsCancel);}
        }
        public static Button KPITagSettingsDeleteButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITagSettingsDelete);}
        }

        public static TabButton KPITargetPropertyTabButton 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonKPITargetProperty);}
        }
        public static TabButton KPIBaselinePropertyTabButton 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonKPIBaselineProperty);}
        }
        public static Button KPITargetBaselineCalculationRuleViewButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineCalculationRuleView);}
        }
        public static Button KPITargetBaselineCalculationRuleCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineCalculationRuleCreate);}
        }
        public static Button KPITargetBaselineCalculationRuleBackButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineCalculationRuleBack);}
        }
        public static Button KPITargetBaselineCalculationRuleModifyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineCalculationRuleModify);}
        }
        public static Button KPITargetBaselineCalculateTargetButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineCalculateTarget);}
        }
        public static Button KPITargetBaselineCalculateBaselineButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineCalculateBaseline);}
        }
        public static Button KPITargetBaselineReviseButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineRevise);}
        }
        public static Button KPITargetBaselineSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineSave);}
        }
        public static Button KPITargetBaselineCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineCancel);}
        }
        public static Button KPITargetBaselineAddSpecialDatesButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineAddSpecialDates);}
        }
        public static Button KPITargetBaselineDeleteSpecialDatesButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonKPITargetBaselineDeleteSpecialDates);}
        }
        #endregion

        #region System dimension settings buttons
        public static Button SystemDimensionSettingsShowHierarchyTreeButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDimensionShowHierarchyTree);}
        }

        public static Button SystemDimensionSettingsSetButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonSystemDimensionSet); }
        }
        public static Button SystemDimensionSettingsDialogReturnButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonSystemDimensionSettingsDialogReturn);}
        }
        public static Button SystemDimensionSettingsCloseButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonSystemDimensionSettingsClose);}
        }
        #endregion

        #region Area dimension settings buttons
        public static Button AreaDimensionShowHierarchyTreeButton 
        {
            get { return  SystemDimensionSettingsShowHierarchyTreeButton;}
        }
        public static Button AreaDimensionCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsCreate);}
        }

        public static Button AreaDimensionSettingsSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsSave);}
        }
        public static Button AreaDimensionSettingsCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsCancel);}
        }
        public static Button AreaDimensionSettingsModifyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsModify);}
        }
        public static Button AreaDimensionSettingsDeleteButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsDelete);}
        }
        // added 
        //public static Button AreaDimensionSettingsConfirmDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsConfirmDelete);
        //public static Button AreaDimensionSettingsCancelDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionSettingsCancelDelete);
        #endregion

        #region Association
        public static Button AssociationSettingsTagAssociate 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonAssociationSettingsTagAssociate);}
        }
        public static Button AssociationSettingsAssociate 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonAssociationSettingsAssociate);}
        }
        public static Button AssociationSettingsDisassociate 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonAssociationSettingsDisassociate);}
        }
        public static Button AssociationSettingCancel 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonAssociationSettingsCancel);}
        }
        #endregion

        #region TargetBaseline

        public static LinkButton TargetCalendarInfoLinkButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonTargetCalendarInfo);}
        }
        public static LinkButton BaselineCalendarInfoLinkButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonBaselineCalendarInfo);}
        }
        public static Button CloseTBCalendarWindowButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCloseTBCalendarWindow);}
        }
        public static Button DeleteSpecialdayItemButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDeleteSpecialdayItem);}
        }
        
        #endregion
        #region CustomizedLabellingSetting
        public static Button CreatCustomizedLabellingButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCustomizedLabellingCreat);}
        }
        public static Button SaveCustomizedLabellingButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCustomizedLabellingSave);}
        }
        public static Button DeleteCustomizedLabellingButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCustomizedLabellingDelete);}
        }
        public static Button ModifyCustomizedLabellingButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCustomizedLabellingModify);}
        }
        public static Button CancelCustomizedLabellingButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCustomizedLabellingCancel);}
        }
        public static RadioButton CustomizedLabellingAscendingOrderButton 
        {
            get { return  GetControl<RadioButton>(JazzControlLocatorKey.ButtonCustomizedLabellingAscendingOrder);}
        }
        public static RadioButton CustomizedLabellingDescendingOrderButton 
        {
            get { return  GetControl<RadioButton>(JazzControlLocatorKey.ButtonCustomizedLabellingDescendingOrder);}
        }
        #endregion

        #endregion

        #region Platform settings buttons
        #region Workday buttons
        public static Button WorkdayCalendarCreateButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonWorkdayCalendarCreate); }
        }
        public static Button WorkdayCalendarModifyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonWorkdayCalendarModify);}
        }
        public static Button WorkdayCalendarSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonWorkdayCalendarSave);}
        }
        public static Button WorkdayCalendarCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonWorkdayCalendarCancel);}
        }
        public static Button WorkdayCalendarDeleteButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonWorkdayCalendarDelete);}
        }
        public static Button WorkdayCalendarAddSpecialDatesButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonWorkdayCalendarAddSpecialDates);}
        }
        public static Button WorkdayCalendarDeleteRangeItemButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonWorkdayDeleteRangeItem);}
        }
        #endregion

        #region Worktime buttons
        public static Button WorktimeCalendarCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonWorktimeCalendarCreate);}
        }
        public static Button WorktimeCalendarModifyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonWorktimeCalendarModify);}
        }
        public static Button WorktimeCalendarSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonWorktimeCalendarSave);}
        }
        public static Button WorktimeCalendarCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonWorktimeCalendarCancel);}
        }
        public static Button WorktimeCalendarDeleteButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonWorktimeCalendarDelete);}
        }
        public static LinkButton WorktimeCalendarAddMoreRangesButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonWorktimeCalendarAddMoreRanges);}
        }
        #endregion

        #region HeatingCoolingSeason buttons
        public static Button HeatingCoolingSeasonCalendarCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonHeatingCoolingSeasonCalendarCreate);}
        }
        public static Button HeatingCoolingSeasonCalendarModifyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonHeatingCoolingSeasonCalendarModify);}
        }
        public static Button HeatingCoolingSeasonCalendarSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonHeatingCoolingSeasonCalendarSave);}
        }
        public static Button HeatingCoolingSeasonCalendarCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonHeatingCoolingSeasonCalendarCancel);}
        }
        public static Button HeatingCoolingSeasonCalendarDeleteButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonHeatingCoolingSeasonCalendarDelete);}
        }
        public static Button HeatingCoolingSeasonCalendarAddMoreColdWarmRangesButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.LinkButtonHeatingCoolingSeasonCalendarAddMoreColdWarmRanges);}
        }
        #endregion

        #region DayNight buttons
        public static Button DayNightCalendarCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDayNightCalendarCreate);}
        }
        public static Button DayNightCalendarModifyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDayNightCalendarModify);}
        }
        public static Button DayNightCalendarSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDayNightCalendarSave);}
        }
        public static Button DayNightCalendarCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDayNightCalendarCancel);}
        }
        public static Button DayNightCalendarDeleteButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDayNightCalendarDelete);}
        }
        public static LinkButton DayNightCalendarAddMoreRangesButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonDayNightCalendarAddMoreRanges);}
        }
        #endregion

        #region Carbonfactor buttons
        public static Button CarbonFactorCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCarbonFactorCreate);}
        }
        public static Button CarbonFactorModifyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCarbonFactorModify);}
        }
        public static Button CarbonFactorSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCarbonFactorSave);}
        }
        public static Button CarbonFactorCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCarbonFactorCancel);}
        }
        public static Button CarbonFactorDeleteButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCarbonFactorDelete);}
        }
        public static Button CarbonFactorAddMoreRangesButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.ButtonCarbonFactorAddMoreRanges);}
        }
        public static Button CarbonFactorRangeDeleteButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.ButtonCarbonFactorRangeDelete);}
        }
        
        #endregion

        #region TOU buttons
        public static Button TOUBasicPropertyCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonTOUBasicPropertyCreate);}
        }
        public static Button TOUBasicPropertyModifyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonTOUBasicPropertyModify);}
        }
        public static Button TOUBasicPropertySaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonTOUBasicPropertySave);}
        }
        public static Button TOUBasicPropertyCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonTOUBasicPropertyCancel);}
        }
        public static Button TOUBasicPropertyDeleteButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonTOUBasicPropertyDelete);}
        }
        public static LinkButton TOUBasicPropertyAddMorePeakRangesButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonTOUBasicPropertyAddMorePeakRanges);}
        }
        public static LinkButton TOUBasicPropertyAddMoreValleyRangesButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonTOUBasicPropertyAddMoreValleyRanges);}
        }
        public static LinkButton TOUBasicPropertyDeletePeakRangeItemButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.ButtonTOUBasicPropertyDeletePeakRangeItem);}
        }
        public static LinkButton TOUBasicPropertyDeleteValleyRangeItemButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.ButtonTOUBasicPropertyDeleteValleyRangeItem);}
        }
        public static TabButton TOUPulsePeakPropertyTabButton 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonTOUPulsePeakProperty);}
        }
        public static Button TOUPulsePeakPropertyCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonTOUPulsePeakPropertyCreate);}
        }
        public static Button TOUPulsePeakPropertyPlusIconButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonTOUPulsePeakPropertyPlusIcon);    }
        }    
        public static Button TOUPulsePeakPropertyModifyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonTOUPulsePeakPropertyModify);}
        }
        public static Button TOUPulsePeakPropertySaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonTOUPulsePeakPropertySave);}
        }
        public static Button TOUPulsePeakPropertyCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonTOUPulsePeakPropertyCancel);}
        }
        public static Button TOUPulsePeakPropertyDeleteWholeRangeButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonTOUPulsePeakPropertyDeleteWholeRange);}
        }
        public static Button TOUPulsePeakPropertyDeleteRangeItemButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonTOUPulsePeakPropertyDeleteRangeItem);}
        }
        public static LinkButton TOUPulsePeakPropertyAddMoreRangesButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonTOUPulsePeakPropertyAddMoreRanges);  }
        }      
        #endregion

        #region Customer settings buttons
        public static Button AddCustomerButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonAddCustomer);}
        }
        public static Button UploadLogoButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUploadLogo);}
        }
        public static Button SaveCustomerButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonSaveCustomer);}
        }
        public static Button CancelCustomerButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCancelCustomer);}
        }
        public static Button DeleteCustomerButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDeleteCustomer);}
        }
        public static Button UpdateCustomerButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUpdateCustomer);}
        }

        public static Button SaveCustomerMapPropertyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonSaveCustomerMapProperty);}
        }
        public static Button CancelCustomerMapPropertyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCancelCustomerMapProperty);}
        }
        public static Button ModifyCustomerMapPropertyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonModifyCustomerMapProperty);}
        }
        public static TabButton BasicPropertyTabButton 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonCustomerBasicProperty);}
        }
        public static TabButton MapPagePropertyTabButton 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonCustomerMapPageProperty);}
        }
        #endregion

        #region BenchMark
        public static Button AddBenchMarkButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonAddBenchMark);}
        }
        public static Button SaveBenchMarkButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonSaveBenchMark);}
        }
        public static Button ModifyBenchMarkButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonModifyBenchMark);}
        }
        public static Button CancelBenchMarkButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCancelBenchMark);}
        }
        public static Button DeleteBenchMarkButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDeleteBenchMark);}
        }

        #endregion

        #region Labeling
        public static Button AddLabelingButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonAddLabeling);}
        }
        public static Button CancelLabelingButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCancelLabeling);}
        }
        public static Button SaveLabelingButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonSaveLabeling);}
        }
        public static Button ModifyLabelingButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonModifyLabeling);}
        }
        public static Button DeleteLabelingButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDeleteLabeling);}
        }

        #endregion

        #region User setting
        public static Button UserCreateButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUserCreate);}
        }
        public static Button UserRefreshButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUserRefresh);}
        }
        public static Button UserSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUserSave);}
        }
        public static Button UserCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUserCancel);}
        }
        public static Button UserDeleteButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUserDelete);}
        }
        public static Button UserModifyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUserModify);}
        }
        public static Button UserAssociatedCustomerLinkButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.LinkButtonUserAssociatedCustomer);}
        }
        public static Button UserGeneratePasswordButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUserGeneratePassword);}
        }
        public static Button UserTypePermissionModifyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUserTypePermissionModify);}
        }
        public static Button UserTypePermissionSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUserTypePermissionSave);}
        }
        public static Button UserTypePermissionCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUserTypePermissionCancel);}
        }
        public static Button UserTypePermissionRefreshButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUserTypePermissionRefresh);}
        }
        //public static Button TabButtonUserBasicProperties = GetControl<Button>(JazzControlLocatorKey.TabButtonUserBasicProperties);
        //public static Button TabButtonUserDataPermission = GetControl<Button>(JazzControlLocatorKey.TabButtonUserDataPermission);

        public static LinkButton LinkButtonUserViewFunctionDetail 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonUserViewFunctionDetail);}
        }
        public static Button UserSendEmailButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUserSendEmail);}
        }
        public static Button UserTypePermissionDisplayCloseButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUserTypePermissionDisplayClose);}
        }

        #endregion

        #region User Profile
        public static Button UserProfileButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUserProfile);}
        }
        public static Button UserProfileViewMenuButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.MenuButtonUserProfileView);}
        }
        public static Button UserProfileSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUserProfileSave);}
        }
        public static Button UserProfileCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUserProfileCancel);}
        }
        public static Button UserProfileCloseButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonUserProfileClose); }
        }
        public static Button UserProfileModifyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUserProfileModify);}
        }
        public static Button UserPasswordModifyMenuButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.MenuButtonModifyUserPassword);}
        }
        public static Button ExitJazzMenuButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.MenuButtonExitJazz);}
        }
        #endregion

        #region UserRoleType
        public static Button CreatFunctionRoleType 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCreatFunctionRoleType);}
        }
        public static Button ModifyFunctionRoleType 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonModifyFunctionRoleType);}
        }
        public static Button CancelFunctionRoleType 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCancelFunctionRoleType);}
        }
        public static Button DeleteFunctionRoleType 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDeleteFunctionRoleType);}
        }
        public static Button SaveFunctionRoleType 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonSaveFunctionRoleType);}
        }
        #endregion

        #region User Data Scope Permission
        public static Button ModifyUserDataPermissionButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonModifyUserDataPermission);}
        }
        public static Button SaveUserDataPermissionButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonSaveUserDataPermission);}
        }
        public static Button CancelUserDataPermissionButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCancelUserDataPermission);}
        }
        public static Button ClosePermissionTreeWindowButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonClosePermissionTreeWindow);}
        }
        public static Button TabButtonUserBasicProperties 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.TabButtonUserBasicProperties);}
        }
        public static Button TabButtonUserDataPermission 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.TabButtonUserDataPermission);}
        }
        public static Button TreeWindowSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonTreeWindowSave);}
        }
        public static Button TreeWindowCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonTreeWindowCancel);}
        }

        public static Button UserSelectAllDataPermissionButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonUserSelectAllDataPermission);}
        }
        public static Button UserCustomerNamesButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCustomerNames);}
        }
        public static Button CustomerNamesViewStatusButtons 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCustomerNamesViewStatus);}
        }
        public static LinkButton UserCustomerNamesLinkButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.ButtonCustomerNames);}
        }

        #endregion
        #endregion

        #region Home page buttons

        #region all dashboards

        public static Button AllDashboardsHierarchyTreeButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonAllDashboardsHierarchyTree); }
        }
        public static MenuButton SelectCustomerMenuButton 
        {
            get { return  GetControl<MenuButton>(JazzControlLocatorKey.MenuButtonSelectCustomer);}
        }

        public static Button WidgetMaxDialogViewButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonWidgetMaxDialogView);}
        }
        public static Button WidgetMaxDialogCloseButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonWidgetMaxDialogClose);}
        }
        public static Button WidgetMaxDialogPrevButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonWidgetMaxDialogPrev);}
        }
        public static Button WidgetMaxDialogNextButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonWidgetMaxDialogNext);}
        }
        public static Button HomepageToDashboardButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonHomepageToDashboard);}
        }
        public static Button MaxWidgetLabellingViewButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonMaxWidgetLabellingView);}
        }

        public static Button DashboardShareButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDashboardShare);}
        }
        public static Button DashboardRenameButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDashboardRename);}
        }
        public static Button DashboardDeleteButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonDashboardDelete);}
        }

        public static Button RenameDashboardSaveButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonRenameDashboardSave);}
        }
        public static Button RenameDashboardCancelButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonRenameDashboardCancel);}
        }
        public static DashboardButton DashboardFavoriteLevelButton 
        {
            get { return  GetControl<DashboardButton>(JazzControlLocatorKey.ButtonDashboardFavoriteLevel);}
        }
        public static DashboardButton DashboardShareInfoButton 
        {
            get { return  GetControl<DashboardButton>(JazzControlLocatorKey.ButtonDashboardShareInfo);}
        }
        public static Button ShareWindowCloseButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonShareWindowClose);}
        }

        public static Button ShareWindowShareButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonShareWindowShare);}
        }
        public static Button ShareWindowEnjoyButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonShareWindowEnjoy);}
        }
        public static Button ShareWindowGiveupButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonShareWindowGiveup);}
        }

        public static TabButton ShareInfoReceivedTabButton 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonShareInfoReceived);}
        }
        public static TabButton ShareInfoSendedTabButton 
        {
            get { return  GetControl<TabButton>(JazzControlLocatorKey.TabButtonShareInfoSended);}
        }

        public static LinkButton AnnotationEditLinkButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonAnnotationEdit);}
        }
        public static LinkButton AnnotationAddLinkButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonAnnotationAdd);}
        }

        public static LinkButton MaxWidgetEditCommentLinkButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonMaxWidgetEditComment);}
        }
        public static LinkButton MaxWidgetAddCommentLinkButton 
        {
            get { return  GetControl<LinkButton>(JazzControlLocatorKey.LinkButtonMaxWidgetAddComment); }
        }    
        public static Button SaveAnnotationWindowButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonSaveAnnotationWindow);}
        }
        public static Button QuitAnnotationWindowButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonQuitAnnotationWindow);}
        }
        public static Button InviteOtherButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonInviteOther);}
        }
        public static Button CloseSubcribeWindowButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCloseSubcribeWindow);}
        }
        public static Button WidgetConfirmCancelShareButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.WidgetConfirmCancelShareButton);}
        }
        public static Button WidgetTemplateQuickCreateButton
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonWidgetTemplateQuickCreate); }
        }   
        public static Button WidgetTemplateQuickCreateCloseButton 
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonWidgetTemplateQuickCreateClose); }
        }
        public static Button WidgetTemplateFilterButton 
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonWidgetTemplateFilter); }
        } 
        public static Button WidgetTemplateApplyFilterButton 
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonWidgetTemplateApplyFilter); }
        } 
        public static Button WidgetTemplateCancelFilterButton 
        {
            get { return GetControl<Button>(JazzControlLocatorKey.ButtonWidgetTemplateCancelFilter); }
        }
            
        #endregion

        #region My Share

        public static Button CancelShareWidgetButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCancelShareWidget);}
        }
        public static Button CloseWidgetRenameWindowButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonCloseWidgetRenameWindow);}
        }
        public static Button MaxWidgetRightCommentButton 
        {
            get { return  GetControl<Button>(JazzControlLocatorKey.ButtonMaxWidgetRightComment);}
        }

        #endregion

        #endregion
    }
}