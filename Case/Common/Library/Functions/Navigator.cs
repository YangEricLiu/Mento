﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// Navigator control, able to navigate to a <see cref="NavigationTarget" /> item.
    /// </summary>
    public class Navigator
    {
        internal Navigator()
        {
        }

        /// <summary>
        /// Navigate to a specified target
        /// </summary>
        /// <param name="target">The specified target</param>
        public void NavigateToTarget(NavigationTarget target)
        {
            Button[] pathButtons = GetParentPathButtons(target);

            for (var i = 0; i < pathButtons.Length; i++)
            {
                JazzMessageBox.LoadingMask.WaitLoading();

                pathButtons[i].Click();

                JazzMessageBox.LoadingMask.WaitLoading();

                TimeManager.ShortPause();
            }
        }

        /// <summary>
        /// Navigate to home page, which is considered as every test entry point
        /// </summary>
        public void NavigateHome()
        {
            NavigateToTarget(NavigationTarget.EnergyView);

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        /// <summary>
        /// Get the array of locators on path of navigating to the target navigation item.
        /// </summary>
        /// <param name="target">The specified navigation target</param>
        /// <returns>Array of locators on path of navigating to the target navigation item</returns>
        private Button[] GetParentPathButtons(NavigationTarget target)
        {
            List<Button> pathButtons = new List<Button>();

            NavigationTarget? currentTarget = target;

            while (currentTarget.HasValue)
            {
                var targetItem = NavigatorItem.NavigationItems[currentTarget.Value];

                pathButtons.Add(targetItem.Button);

                currentTarget = targetItem.Parent;
            }

            pathButtons.Reverse();

            return pathButtons.ToArray();
        }
    }

    internal class NavigatorItem
    {
        public static Dictionary<NavigationTarget, NavigatorItem> NavigationItems = new Dictionary<NavigationTarget, NavigatorItem>()
        {
            //level 1
            {NavigationTarget.HomePage,new NavigatorItem(NavigationTarget.HomePage, null, JazzButton.NavigatorHomePageButton)},
            {NavigationTarget.EnergyView, new NavigatorItem(NavigationTarget.EnergyView, null,JazzButton.NavigatorEnergyViewButton)},
            {NavigationTarget.Settings, new NavigatorItem(NavigationTarget.Settings,null,JazzButton.NavigatorSettingsButton)},
            {NavigationTarget.PlatformSettings, new NavigatorItem(NavigationTarget.PlatformSettings,null,JazzButton.NavigatorPlatformSettingsButton)},

            //level 2
            {NavigationTarget.TimeSettings, new NavigatorItem(NavigationTarget.TimeSettings,NavigationTarget.PlatformSettings,JazzButton.NavigatorTimeSettingsButton)},
            {NavigationTarget.CarbonSettings, new NavigatorItem(NavigationTarget.CarbonSettings,NavigationTarget.PlatformSettings,JazzButton.NavigatorCarbonSettingsButton)},
            {NavigationTarget.PriceSettings, new NavigatorItem(NavigationTarget.PriceSettings,NavigationTarget.PlatformSettings,JazzButton.NavigatorPriceSettingsButton)},

            {NavigationTarget.TagSettings, new NavigatorItem(NavigationTarget.TagSettings,NavigationTarget.Settings,JazzButton.NavigatorTagSettingsButton)},
            {NavigationTarget.HierarchySettings, new NavigatorItem(NavigationTarget.HierarchySettings,NavigationTarget.Settings,JazzButton.NavigatorHierarchySettingsButton)},
            {NavigationTarget.AssociationSettings, new NavigatorItem(NavigationTarget.AssociationSettings,NavigationTarget.Settings,JazzButton.NavigatorAssociationSettingsButton)},

            //level 3
            //--Time
            {NavigationTarget.TimeSettingsWorkday, new NavigatorItem(NavigationTarget.TimeSettingsWorkday,NavigationTarget.TimeSettings,JazzButton.NavigatorTimeSettingsWorkdayButton)},
            {NavigationTarget.TimeSettingsWorktime, new NavigatorItem(NavigationTarget.TimeSettingsWorktime,NavigationTarget.TimeSettings,JazzButton.NavigatorTimeSettingsWorktimeButton)},
            {NavigationTarget.TimeSettingsSeason, new NavigatorItem(NavigationTarget.TimeSettingsSeason,NavigationTarget.TimeSettings,JazzButton.NavigatorTimeSettingsSeasonButton)},
            {NavigationTarget.TimeSettingsDaynight, new NavigatorItem(NavigationTarget.TimeSettingsDaynight,NavigationTarget.TimeSettings,JazzButton.NavigatorTimeSettingsDaynightButton)},
            //--Carbon
            {NavigationTarget.CarbonSettingsCarbon, new NavigatorItem(NavigationTarget.CarbonSettingsCarbon,NavigationTarget.CarbonSettings,JazzButton.NavigatorCarbonSettingsCarbonButton)},
            //--Price
            {NavigationTarget.PriceSettingsPrice, new NavigatorItem(NavigationTarget.PriceSettingsPrice,NavigationTarget.PriceSettings,JazzButton.NavigatorPriceSettingsPriceButton)},
            
            //--Tag
            {NavigationTarget.TagSettingsP, new NavigatorItem(NavigationTarget.TagSettingsP,NavigationTarget.TagSettings,JazzButton.NavigatorTagSettingsPButton)},
            {NavigationTarget.TagSettingsV, new NavigatorItem(NavigationTarget.TagSettingsV,NavigationTarget.TagSettings,JazzButton.NavigatorTagSettingsVButton)},
            {NavigationTarget.TagSettingsKPI, new NavigatorItem(NavigationTarget.TagSettingsKPI, NavigationTarget.TagSettings,JazzButton.NavigatorTagSettingsKPIButton)},
            //--Hierarchy
            {NavigationTarget.HierarchySettingsHierarchy, new NavigatorItem(NavigationTarget.HierarchySettingsHierarchy, NavigationTarget.HierarchySettings,JazzButton.NavigatorHierarchySettingsHierarchyButton)},
            {NavigationTarget.HierarchySettingsSystemDimension, new NavigatorItem(NavigationTarget.HierarchySettingsSystemDimension,NavigationTarget.HierarchySettings,JazzButton.NavigatorHierarchySettingsSystemDimensionButton)},
            {NavigationTarget.HierarchySettingsAreaDimension, new NavigatorItem(NavigationTarget.HierarchySettingsAreaDimension,NavigationTarget.HierarchySettings,JazzButton.NavigatorHierarchySettingsAreaDimensionButton)},
            //--Association
            {NavigationTarget.AssociationHierarchy, new NavigatorItem(NavigationTarget.AssociationHierarchy, NavigationTarget.AssociationSettings,JazzButton.NavigatorAssociationHierarchyButton)},
            {NavigationTarget.AssociationSystemDimension, new NavigatorItem(NavigationTarget.AssociationSystemDimension,NavigationTarget.AssociationSettings,JazzButton.NavigatorAssociationSystemDimensionButton)},
            {NavigationTarget.AssociationAreaDimension, new NavigatorItem(NavigationTarget.AssociationAreaDimension,NavigationTarget.AssociationSettings,JazzButton.NavigatorAssociationAreaDimensionButton)},
        };

        public NavigationTarget? Parent
        {
            get;
            set;
        }

        public NavigationTarget Self
        {
            get;
            set;
        }

        public Button Button
        {
            get;
            set;
        }

        public NavigatorItem(NavigationTarget self, NavigationTarget? parent, Button button)
        {
            this.Self = self;
            this.Parent = parent;
            this.Button = button;
        }
    }

    /// <summary>
    /// Navigation target
    /// </summary>
    public enum NavigationTarget
    {
        //level 1
        HomePage = 1,
        EnergyView = 2,
        Settings = 3,
        PlatformSettings = 4,

        //level 2
        TimeSettings = 5,
        CarbonSettings = 6,
        PriceSettings = 7,
        TagSettings = 8,
        HierarchySettings = 9,
        AssociationSettings = 10,
        
        //level 3
        //--Time
        TimeSettingsWorkday = 11,
        TimeSettingsWorktime = 12,
        TimeSettingsSeason = 13,
        TimeSettingsDaynight = 14,
        //--Carbon
        CarbonSettingsCarbon = 15,
        //--Price
        PriceSettingsPrice = 16,
        //--Tag
        TagSettingsP = 17,
        TagSettingsV = 18,
        TagSettingsKPI = 19,
        //--Hierarchy
        HierarchySettingsHierarchy = 20,
        HierarchySettingsSystemDimension = 21,
        HierarchySettingsAreaDimension = 22,
        //--Association
        AssociationHierarchy = 23,
        AssociationSystemDimension = 24,
        AssociationAreaDimension = 25,
    }
}