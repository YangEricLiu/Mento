﻿using System;
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

        #region Navigator buttons
        //level 1
        public static Button NavigatorHomePageButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorHomePage);//{NavigationTarget.HomePage,new NavigatorItem( NavigationTarget.HomePage, null, "header-btn-homepage-btnEl",ByType.ID)},
        public static Button NavigatorEnergyViewButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorEnergyView);//{NavigationTarget.EnergyView, new NavigatorItem(NavigationTarget.EnergyView, null,"header-btn-energyservice-btnEl",ByType.ID)},
        public static Button NavigatorSettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorSettings);//{NavigationTarget.Settings, new NavigatorItem(NavigationTarget.Settings,null,"header-btn-setting-btnEl",ByType.ID)},
        public static Button NavigatorPlatformSettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorPlatformSettings);//{NavigationTarget.PlatformSettings, new NavigatorItem(NavigationTarget.PlatformSettings,NavigationTarget.Settings,"setting-tab-platformsetting-btn-btnEl",ByType.ID)},

        //level 2
        public static Button NavigatorTimeSettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorTimeSettings);
        public static Button NavigatorCarbonSettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorCarbonSettings);
        public static Button NavigatorPriceSettingsButton = GetControl<Button>(JazzControlLocatorKey.ButtonNavigatorPriceSettings);
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

        #region Settings buttons
        #region Hierarchy settings buttons
        public static Button HierarchySettingsCreateChildHierarchyButton = GetControl<Button>(JazzControlLocatorKey.ButtonHierarchySettingsCreateChildHierarchy);
        public static Button HierarchySettingsModifyButton = GetControl<Button>(JazzControlLocatorKey.ButtonHierarchySettingsModify);
        public static Button HierarchySettingsSaveButton = GetControl<Button>(JazzControlLocatorKey.ButtonHierarchySettingsSave);
        public static Button HierarchySettingsCancelButton = GetControl<Button>(JazzControlLocatorKey.ButtonHierarchySettingsCancel);
        public static Button HierarchySettingsDeleteButton = GetControl<Button>(JazzControlLocatorKey.ButtonHierarchySettingsDelete);
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
        
        #endregion
        #endregion
    }
}