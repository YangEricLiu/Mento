using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class Navigator : JazzControlBase
    {
        public void NavigateToTarget(NavigationTarget target)
        {
            Locator[] pathLocators = this.GetParentPathLocators(target);

            for (var i = 0; i < pathLocators.Length; i++)
            {
                var element = ElementLocator.FindElement(pathLocators[i]);

                element.Click();

                System.Threading.Thread.Sleep(50);

                ElementLocator.WaitForElementToDisappear(new Locator("mainLoadingMask", ByType.ID), 30);
            }
        }

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
            {NavigationTarget.HomePage,new NavigatorItem( NavigationTarget.HomePage, null, "header-btn-homepage-btnEl",ByType.ID)},
            {NavigationTarget.EnergyView, new NavigatorItem(NavigationTarget.EnergyView, null,"header-btn-energyservice-btnEl",ByType.ID)},
            {NavigationTarget.Settings, new NavigatorItem(NavigationTarget.Settings,null,"header-btn-setting-btnEl",ByType.ID)},

            {NavigationTarget.PlatformSettings, new NavigatorItem(NavigationTarget.PlatformSettings,NavigationTarget.Settings,"setting-tab-platformsetting-btn-btnEl",ByType.ID)},
            {NavigationTarget.TagSettings, new NavigatorItem(NavigationTarget.TagSettings,NavigationTarget.Settings,"setting-tab-tagmrg-btn-btnEl",ByType.ID)},
            {NavigationTarget.HierarchySettings, new NavigatorItem(NavigationTarget.HierarchySettings,NavigationTarget.Settings,"setting-tab-hiersetting-btn-btnEl",ByType.ID)},
            {NavigationTarget.AssociationSettings, new NavigatorItem(NavigationTarget.AssociationSettings,NavigationTarget.Settings,"setting-tab-tagassoc-btn-btnEl",ByType.ID)},
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

    public enum NavigationTarget
    {
        HomePage = 1, //header-btn-homepage-btnEl
        EnergyView = 2, //header-btn-energyservice-btnEl
        Settings = 3,//header-btn-setting-btnEl

        PlatformSettings = 4, //setting-tab-platformsetting-btn-btnEl
        TagSettings = 5, //setting-tab-tagmrg-btn-btnEl
        HierarchySettings = 6, //setting-tab-hiersetting-btn-btnEl
        AssociationSettings = 7 //setting-tab-tagassoc-btn-btnEl
    }
}