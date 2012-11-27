using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Mento.TestApi.WebUserInterface
{
    /// <summary>
    /// Navigator control, able to navigate to a <see cref="NavigationTarget" /> item.
    /// </summary>
    public class Navigator : JazzControlBase
    {
        private static Locator MaskLocator = new Locator("mainLoadingMask", ByType.ID);

        /// <summary>
        /// Navigate to a specified target
        /// </summary>
        /// <param name="target">The specified target</param>
        public void NavigateToTarget(NavigationTarget target)
        {
            Locator[] pathLocators = this.GetParentPathLocators(target);

            for (var i = 0; i < pathLocators.Length; i++)
            {
                IWebElement maskElement = null;

                try
                {
                    maskElement = ElementLocator.FindElement(MaskLocator);
                }
                catch
                { 
                }

                if (maskElement != null && !maskElement.GetCssValue("display").Equals("none",StringComparison.OrdinalIgnoreCase))
                {
                    ElementLocator.WaitForElementToDisappear(MaskLocator, 30);
                }

                var element = ElementLocator.FindElement(pathLocators[i]);

                element.Click();

                ElementLocator.Pause(300);
                //ElementLocator.WaitForElementToDisappear(MaskLocator, 30);
            }
        }

        /// <summary>
        /// Navigate to home page, which is considered as every test entry point
        /// </summary>
        public void NavigateHome()
        {
            NavigateToTarget(NavigationTarget.HomePage);
        }

        /// <summary>
        /// Get the array of locators on path of navigating to the target navigation item.
        /// </summary>
        /// <param name="target">The specified navigation target</param>
        /// <returns>Array of locators on path of navigating to the target navigation item</returns>
        private Locator[] GetParentPathLocators(NavigationTarget target)
        {
            List<Locator> pathLocators = new List<Locator>();

            NavigationTarget? currentTarget = target;

            while (currentTarget.HasValue)
            {
                var targetItem = NavigatorItem.NavigationItems[currentTarget.Value];

                pathLocators.Add(targetItem.Locator);

                currentTarget = targetItem.Parent;
            }

            pathLocators.Reverse();

            return pathLocators.ToArray();
        }
    }

    internal class NavigatorItem
    {
        public static Dictionary<NavigationTarget, NavigatorItem> NavigationItems = new Dictionary<NavigationTarget, NavigatorItem>()
        {
            //level 1
            {NavigationTarget.HomePage,new NavigatorItem( NavigationTarget.HomePage, null, "header-btn-homepage-btnEl",ByType.ID)},
            {NavigationTarget.EnergyView, new NavigatorItem(NavigationTarget.EnergyView, null,"header-btn-energyservice-btnEl",ByType.ID)},
            {NavigationTarget.Settings, new NavigatorItem(NavigationTarget.Settings,null,"header-btn-setting-btnEl",ByType.ID)},

            //level 2
            {NavigationTarget.PlatformSettings, new NavigatorItem(NavigationTarget.PlatformSettings,NavigationTarget.Settings,"setting-tab-platformsetting-btn-btnEl",ByType.ID)},
            {NavigationTarget.TagSettings, new NavigatorItem(NavigationTarget.TagSettings,NavigationTarget.Settings,"setting-tab-tagmrg-btn-btnEl",ByType.ID)},
            {NavigationTarget.HierarchySettings, new NavigatorItem(NavigationTarget.HierarchySettings,NavigationTarget.Settings,"setting-tab-hiersetting-btn-btnEl",ByType.ID)},
            {NavigationTarget.AssociationSettings, new NavigatorItem(NavigationTarget.AssociationSettings,NavigationTarget.Settings,"setting-tab-tagassoc-btn-btnEl",ByType.ID)},

            //level 3
            //--Platform
            {NavigationTarget.PlatformWorkday, new NavigatorItem(NavigationTarget.PlatformWorkday,NavigationTarget.PlatformSettings,"st-menu-workday-btnEl",ByType.ID)},
            {NavigationTarget.PlatformWorktime, new NavigatorItem(NavigationTarget.PlatformWorktime,NavigationTarget.PlatformSettings,"st-menu-worktime-btnInnerEl",ByType.ID)},
            {NavigationTarget.PlatformSeason, new NavigatorItem(NavigationTarget.PlatformSeason,NavigationTarget.PlatformSettings,"st-menu-coldwarm-btnEl",ByType.ID)},
            {NavigationTarget.PlatformDaynight, new NavigatorItem(NavigationTarget.PlatformDaynight,NavigationTarget.PlatformSettings,"st-menu-daynight-btnEl",ByType.ID)},
            {NavigationTarget.PlatformCarbon, new NavigatorItem(NavigationTarget.PlatformCarbon,NavigationTarget.PlatformSettings,"st-menu-carbon-btnEl",ByType.ID)},
            {NavigationTarget.PlatformPrice, new NavigatorItem(NavigationTarget.PlatformPrice,NavigationTarget.PlatformSettings,"st-menu-price-btnEl",ByType.ID)},
            //--Tag
            {NavigationTarget.TagSettingsP, new NavigatorItem(NavigationTarget.TagSettingsP,NavigationTarget.TagSettings,"st-menu-ptagmgr-btnEl",ByType.ID)},
            {NavigationTarget.TagSettingsV, new NavigatorItem(NavigationTarget.TagSettingsV,NavigationTarget.TagSettings,"st-menu-vtagmgr-btnEl",ByType.ID)},
            {NavigationTarget.TagSettingsKPI, new NavigatorItem(NavigationTarget.TagSettingsKPI, NavigationTarget.TagSettings,"st-menu-kpimgr-btnEl",ByType.ID)},
            //--Hierarchy
            {NavigationTarget.HierarchySettingsHierarchy, new NavigatorItem(NavigationTarget.HierarchySettingsHierarchy, NavigationTarget.HierarchySettings,"st-menu-hierarchy-btnEl",ByType.ID)},
            {NavigationTarget.HierarchySettingsSystemDimension, new NavigatorItem(NavigationTarget.HierarchySettingsSystemDimension,NavigationTarget.HierarchySettings,"st-menu-systemdimension-btnEl",ByType.ID)},
            {NavigationTarget.HierarchySettingsAreaDimension, new NavigatorItem(NavigationTarget.HierarchySettingsAreaDimension,NavigationTarget.HierarchySettings,"st-menu-areadimension-btnEl",ByType.ID)},
            //--Association
            {NavigationTarget.AssociationHierarchy, new NavigatorItem(NavigationTarget.AssociationHierarchy, NavigationTarget.AssociationSettings,"st-menu-hierarchytags-btnEl",ByType.ID)},
            {NavigationTarget.AssociationSystemDimension, new NavigatorItem(NavigationTarget.AssociationSystemDimension,NavigationTarget.AssociationSettings,"st-menu-systemdtags-btnEl",ByType.ID)},
            {NavigationTarget.AssociationAreaDimension, new NavigatorItem(NavigationTarget.AssociationAreaDimension,NavigationTarget.AssociationSettings,"st-menu-areadtags-btnEl",ByType.ID)},

            ////Amy update1 starts: if running case in R1.0, all navigator items above need to be replaced by below level 1 to level 3:
            ////level 1
            //{NavigationTarget.HomePage,new NavigatorItem( NavigationTarget.HomePage, null, "header-btn-homepage-btnEl",ByType.ID)},
            //{NavigationTarget.EnergyView, new NavigatorItem(NavigationTarget.EnergyView, null,"header-btn-energyservice-btnEl",ByType.ID)},
            //{NavigationTarget.Settings, new NavigatorItem(NavigationTarget.Settings,null,"header-btn-setting-btnEl",ByType.ID)},
            //{NavigationTarget.PlatformSettings, new NavigatorItem(NavigationTarget.PlatformSettings, null,"header-btn-pfsetting-btnEl",ByType.ID)},

            ////level 2
            //{NavigationTarget.TagSettings, new NavigatorItem(NavigationTarget.TagSettings,NavigationTarget.Settings,"setting-tab-tagmrg-btn-btnEl",ByType.ID)},
            //{NavigationTarget.HierarchySettings, new NavigatorItem(NavigationTarget.HierarchySettings,NavigationTarget.Settings,"setting-tab-hiersetting-btn-btnEl",ByType.ID)},
            //{NavigationTarget.AssociationSettings, new NavigatorItem(NavigationTarget.AssociationSettings,NavigationTarget.Settings,"setting-tab-tagassoc-btn-btnEl",ByType.ID)},

            //{NavigationTarget.PlatformTime, new NavigatorItem(NavigationTarget.PlatformTime,NavigationTarget.PlatformSettings,"st-menu-timecfg-btnEl",ByType.ID)},
            //{NavigationTarget.PlatformCarbon, new NavigatorItem(NavigationTarget.PlatformCarbon,NavigationTarget.PlatformSettings,"st-menu-carbon-lv1-btnEl",ByType.ID)},
            //{NavigationTarget.PlatformPrice, new NavigatorItem(NavigationTarget.PlatformPrice,NavigationTarget.PlatformSettings,"st-menu-price-lv1-btnEl",ByType.ID)},

            ////level 3
            ////--Tag
            //{NavigationTarget.TagSettingsP, new NavigatorItem(NavigationTarget.TagSettingsP,NavigationTarget.TagSettings,"st-menu-ptagmgr-btnEl",ByType.ID)},
            //{NavigationTarget.TagSettingsV, new NavigatorItem(NavigationTarget.TagSettingsV,NavigationTarget.TagSettings,"st-menu-vtagmgr-btnEl",ByType.ID)},
            //{NavigationTarget.TagSettingsKPI, new NavigatorItem(NavigationTarget.TagSettingsKPI, NavigationTarget.TagSettings,"st-menu-kpimgr-btnEl",ByType.ID)},
            ////--Hierarchy
            //{NavigationTarget.HierarchySettingsHierarchy, new NavigatorItem(NavigationTarget.HierarchySettingsHierarchy, NavigationTarget.HierarchySettings,"st-menu-hierarchy-btnEl",ByType.ID)},
            //{NavigationTarget.HierarchySettingsSystemDimension, new NavigatorItem(NavigationTarget.HierarchySettingsSystemDimension,NavigationTarget.HierarchySettings,"st-menu-systemdimension-btnEl",ByType.ID)},
            //{NavigationTarget.HierarchySettingsAreaDimension, new NavigatorItem(NavigationTarget.HierarchySettingsAreaDimension,NavigationTarget.HierarchySettings,"st-menu-areadimension-btnEl",ByType.ID)},
            ////--Association
            //{NavigationTarget.AssociationHierarchy, new NavigatorItem(NavigationTarget.AssociationHierarchy, NavigationTarget.AssociationSettings,"st-menu-hierarchytags-btnEl",ByType.ID)},
            //{NavigationTarget.AssociationSystemDimension, new NavigatorItem(NavigationTarget.AssociationSystemDimension,NavigationTarget.AssociationSettings,"st-menu-systemdtags-btnEl",ByType.ID)},
            //{NavigationTarget.AssociationAreaDimension, new NavigatorItem(NavigationTarget.AssociationAreaDimension,NavigationTarget.AssociationSettings,"st-menu-areadtags-btnEl",ByType.ID)},
            
            ////--Time
            //{NavigationTarget.Workday, new NavigatorItem(NavigationTarget.Workday,NavigationTarget.PlatformTime,"st-menu-workday-btnEl",ByType.ID)},
            //{NavigationTarget.Worktime, new NavigatorItem(NavigationTarget.Worktime,NavigationTarget.PlatformTime,"st-menu-worktime-btnInnerEl",ByType.ID)},
            //{NavigationTarget.Season, new NavigatorItem(NavigationTarget.Season,NavigationTarget.PlatformTime,"st-menu-coldwarm-btnEl",ByType.ID)},
            //{NavigationTarget.Daynight, new NavigatorItem(NavigationTarget.Daynight,NavigationTarget.PlatformTime,"st-menu-daynight-btnEl",ByType.ID)},
            ////--Carbon
            //{NavigationTarget.Carbon, new NavigatorItem(NavigationTarget.Carbon,NavigationTarget.PlatformCarbon,"st-menu-carbon-btnEl",ByType.ID)},
            ////--Price
            //{NavigationTarget.Price, new NavigatorItem(NavigationTarget.Price,NavigationTarget.PlatformPrice,"st-menu-price-btnEl",ByType.ID)},
            ////Amy update1 ends
        };

        public NavigationTarget? Parent
        {
            get;
            set;
        }

        public NavigationTarget Target
        {
            get;
            set;
        }

        public Locator Locator
        {
            get;
            set;
        }

        public NavigatorItem(NavigationTarget self, NavigationTarget? parent, string locatorValue, ByType locatorType)
        {
            this.Target = self;
            this.Parent = parent;
            this.Locator = new Locator(locatorValue, locatorType);
        }
    }

    /// <summary>
    /// Navigation target
    /// </summary>
    public enum NavigationTarget
    {
        HomePage = 1, //header-btn-homepage-btnEl
        EnergyView = 2, //header-btn-energyservice-btnEl
        Settings = 3,//header-btn-setting-btnEl

        PlatformSettings = 4, //setting-tab-platformsetting-btn-btnEl
        TagSettings = 5, //setting-tab-tagmrg-btn-btnEl
        HierarchySettings = 6, //setting-tab-hiersetting-btn-btnEl
        AssociationSettings = 7, //setting-tab-tagassoc-btn-btnEl

        //--Platform
        PlatformWorkday = 8, //st-menu-workday-btnEl
        PlatformWorktime = 9,//st-menu-worktime-btnInnerEl
        PlatformSeason = 10,//st-menu-coldwarm-btnEl
        PlatformDaynight = 11,//st-menu-daynight-btnEl
        PlatformCarbon = 12,//st-menu-carbon-btnEl
        PlatformPrice = 13,//st-menu-price-btnEl

        //--Tag
        TagSettingsP = 14,//st-menu-ptagmgr-btnEl
        TagSettingsV = 15,//st-menu-vtagmgr-btnEl
        TagSettingsKPI = 16, //st-menu-kpimgr-btnEl

        //--Hierarchy
        HierarchySettingsHierarchy = 17, //st-menu-hierarchy-btnEl
        HierarchySettingsSystemDimension = 18,//st-menu-systemdimension-btnEl
        HierarchySettingsAreaDimension = 19,//st-menu-areadimension-btnEl

        //--Association
        AssociationHierarchy = 20, //st-menu-hierarchytags-btnEl
        AssociationSystemDimension = 21,//st-menu-systemdtags-btnEl
        AssociationAreaDimension = 22,//st-menu-areadtags-btnEl


        ////Amy update2 starts: if running case in R1.0, all navigator target items above need to be replaced by below level 1 to level 3:
        ////level 1
        //HomePage = 1, //header-btn-homepage-btnEl
        //EnergyView = 2, //header-btn-energyservice-btnEl
        //Settings = 3, //header-btn-setting-btnEl
        //PlatformSettings = 4, //setting-tab-platformsetting-btn-btnEl
        
        ////level 2
        //TagSettings = 5, //setting-tab-tagmrg-btn-btnEl
        //HierarchySettings = 6, //setting-tab-hiersetting-btn-btnEl
        //AssociationSettings = 7, //setting-tab-tagassoc-btn-btnEl
        //PlatformTime = 8, //st-menu-timecfg-btnEl
        //PlatformCarbon = 9, //st-menu-carbon-lv1-btnEl
        //PlatformPrice = 10, //st-menu-price-lv1-btnEl

        ////level 3
        ////--Tag
        //TagSettingsP = 11, //st-menu-ptagmgr-btnEl
        //TagSettingsV = 12, //st-menu-vtagmgr-btnEl
        //TagSettingsKPI = 13, //st-menu-kpimgr-btnEl

        ////--Hierarchy
        //HierarchySettingsHierarchy = 14, //st-menu-hierarchy-btnEl
        //HierarchySettingsSystemDimension = 15, //st-menu-systemdimension-btnEl
        //HierarchySettingsAreaDimension = 16, //st-menu-areadimension-btnEl

        ////--Association
        //AssociationHierarchy = 17, //st-menu-hierarchytags-btnEl
        //AssociationSystemDimension = 18,//st-menu-systemdtags-btnEl
        //AssociationAreaDimension = 19,//st-menu-areadtags-btnEl

        ////--Time
        //Workday = 20, //st-menu-workday-btnEl
        //Worktime = 21, //st-menu-worktime-btnInnerEl
        //Season = 22, //st-menu-coldwarm-btnEl
        //Daynight = 23, //st-menu-daynight-btnEl
        //Carbon = 24, //st-menu-carbon-btnEl
        //Price = 25, //st-menu-price-btnEl
        ////Amy update2 ends
    }
}