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


        #region Navigator buttons
        //level 1
        public static Button NavigatorHomePageButton;//{NavigationTarget.HomePage,new NavigatorItem( NavigationTarget.HomePage, null, "header-btn-homepage-btnEl",ByType.ID)},
        public static Button NavigatorEnergyViewButton;//{NavigationTarget.EnergyView, new NavigatorItem(NavigationTarget.EnergyView, null,"header-btn-energyservice-btnEl",ByType.ID)},
        public static Button NavigatorSettingsButton;//{NavigationTarget.Settings, new NavigatorItem(NavigationTarget.Settings,null,"header-btn-setting-btnEl",ByType.ID)},

        //level 2
        public static Button NavigatorPlatformSettingsButton;//{NavigationTarget.PlatformSettings, new NavigatorItem(NavigationTarget.PlatformSettings,NavigationTarget.Settings,"setting-tab-platformsetting-btn-btnEl",ByType.ID)},
        public static Button NavigatorTagSettingsButton;//{NavigationTarget.TagSettings, new NavigatorItem(NavigationTarget.TagSettings,NavigationTarget.Settings,"setting-tab-tagmrg-btn-btnEl",ByType.ID)},
        public static Button NavigatorHierarchySettingsButton;//{NavigationTarget.HierarchySettings, new NavigatorItem(NavigationTarget.HierarchySettings,NavigationTarget.Settings,"setting-tab-hiersetting-btn-btnEl",ByType.ID)},
        public static Button NavigatorAssociationSettingsButton;//{NavigationTarget.AssociationSettings, new NavigatorItem(NavigationTarget.AssociationSettings,NavigationTarget.Settings,"setting-tab-tagassoc-btn-btnEl",ByType.ID)},

        //level 3
        //--Platform
        public static Button NavigatorPlatformWorkdayButton;//{NavigationTarget.PlatformWorkday, new NavigatorItem(NavigationTarget.PlatformWorkday,NavigationTarget.PlatformSettings,"st-menu-workday-btnEl",ByType.ID)},
        public static Button NavigatorPlatformWorktimeButton;//{NavigationTarget.PlatformWorktime, new NavigatorItem(NavigationTarget.PlatformWorktime,NavigationTarget.PlatformSettings,"st-menu-worktime-btnInnerEl",ByType.ID)},
        public static Button NavigatorPlatformSeasonButton;//{NavigationTarget.PlatformSeason, new NavigatorItem(NavigationTarget.PlatformSeason,NavigationTarget.PlatformSettings,"st-menu-coldwarm-btnEl",ByType.ID)},
        public static Button NavigatorPlatformDaynightButton;//{NavigationTarget.PlatformDaynight, new NavigatorItem(NavigationTarget.PlatformDaynight,NavigationTarget.PlatformSettings,"st-menu-daynight-btnEl",ByType.ID)},
        public static Button NavigatorPlatformCarbonButton;//{NavigationTarget.PlatformCarbon, new NavigatorItem(NavigationTarget.PlatformCarbon,NavigationTarget.PlatformSettings,"st-menu-carbon-btnEl",ByType.ID)},
        public static Button NavigatorPlatformPriceButton;//{NavigationTarget.PlatformPrice, new NavigatorItem(NavigationTarget.PlatformPrice,NavigationTarget.PlatformSettings,"st-menu-price-btnEl",ByType.ID)},
        //--Tag
        public static Button NavigatorTagSettingsPButton;//{NavigationTarget.TagSettingsP, new NavigatorItem(NavigationTarget.TagSettingsP,NavigationTarget.TagSettings,"st-menu-ptagmgr-btnEl",ByType.ID)},
        public static Button NavigatorTagSettingsVButton;//{NavigationTarget.TagSettingsV, new NavigatorItem(NavigationTarget.TagSettingsV,NavigationTarget.TagSettings,"st-menu-vtagmgr-btnEl",ByType.ID)},
        public static Button NavigatorTagSettingsKPIButton;//{NavigationTarget.TagSettingsKPI, new NavigatorItem(NavigationTarget.TagSettingsKPI, NavigationTarget.TagSettings,"st-menu-kpimgr-btnEl",ByType.ID)},
        //--Hierarchy
        public static Button NavigatorHierarchySettingsHierarchyButton;//{NavigationTarget.HierarchySettingsHierarchy, new NavigatorItem(NavigationTarget.HierarchySettingsHierarchy, NavigationTarget.HierarchySettings,"st-menu-hierarchy-btnEl",ByType.ID)},
        public static Button NavigatorHierarchySettingsSystemDimensionButton;//{NavigationTarget.HierarchySettingsSystemDimension, new NavigatorItem(NavigationTarget.HierarchySettingsSystemDimension,NavigationTarget.HierarchySettings,"st-menu-systemdimension-btnEl",ByType.ID)},
        public static Button NavigatorHierarchySettingsAreaDimensionButton;//{NavigationTarget.HierarchySettingsAreaDimension, new NavigatorItem(NavigationTarget.HierarchySettingsAreaDimension,NavigationTarget.HierarchySettings,"st-menu-areadimension-btnEl",ByType.ID)},
        //--Association
        public static Button NavigatorAssociationHierarchyButton;//{NavigationTarget.AssociationHierarchy, new NavigatorItem(NavigationTarget.AssociationHierarchy, NavigationTarget.AssociationSettings,"st-menu-hierarchytags-btnEl",ByType.ID)},
        public static Button NavigatorAssociationSystemDimensionButton;//{NavigationTarget.AssociationSystemDimension, new NavigatorItem(NavigationTarget.AssociationSystemDimension,NavigationTarget.AssociationSettings,"st-menu-systemdtags-btnEl",ByType.ID)},
        public static Button NavigatorAssociationAreaDimensionButton;//{NavigationTarget.AssociationAreaDimension, new NavigatorItem(NavigationTarget.AssociationAreaDimension,NavigationTarget.AssociationSettings,"st-menu-areadtags-btnEl",ByType.ID)},
        #endregion


        #region Settings buttons
        #region Hierarchy settings buttons
        public static Button DimensionSelectHierarchyButton = GetControl<Button>(JazzControlLocatorKey.ButtonDimensionSelectHierarchy);

        public static Button SystemDimensionUpdateButton = GetControl<Button>(JazzControlLocatorKey.ButtonSystemDimensionUpdate);

        public static Button AreaDimensionCreateButton = GetControl<Button>(JazzControlLocatorKey.ButtonAreaDimensionCreate);
        #endregion

        #region Tag settings buttons
        public static TabButton VTagSettingsBasicPropertyTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonVTagSettingsBasicProperty);
        public static TabButton VTagSettingsFormulaTabButton = GetControl<TabButton>(JazzControlLocatorKey.TabButtonVTagSettingsFormula);
        public static Button VTagSettingsFormulaUpdate = GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsFormulaUpdate);
        public static Button VTagSettingsFormulaSave = GetControl<Button>(JazzControlLocatorKey.ButtonVTagSettingsFormulaSave);
        #endregion

        #region Association
        public static Button AssociationSettingsTagAssociate = GetControl<Button>(JazzControlLocatorKey.ButtonAssociationSettingsTagAssociate);
        public static Button AssociationSettingsAssociate = GetControl<Button>(JazzControlLocatorKey.ButtonAssociationSettingsAssociate);
        
        #endregion
        #endregion
    }
}