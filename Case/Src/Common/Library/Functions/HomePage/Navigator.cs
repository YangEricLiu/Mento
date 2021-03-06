﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                //JazzMessageBox.LoadingMask.WaitLoading();
                //JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                pathButtons[i].Click();

                //JazzMessageBox.LoadingMask.WaitLoading();
                //JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.MediumPause();
            }

            if (JazzMessageBox.MessageBox.Exists())
            {
                if (JazzMessageBox.MessageBox.GetMessage().Contains("服务器错误") || JazzMessageBox.MessageBox.GetMessage().Contains("Server error"))
                {
                    JazzMessageBox.MessageBox.OK();
                }
            }

            TimeManager.MediumPause();
        }

        /// <summary>
        /// Navigate to home page, which is considered as every test entry point
        /// </summary>
        public void NavigateHome()
        {
            NavigateToTarget(NavigationTarget.HomePage);

            JazzMessageBox.LoadingMask.WaitLoading();

            if (JazzMessageBox.MessageBox.Exists())
            {
                if (JazzMessageBox.MessageBox.GetMessage().Contains("地图不可用") || JazzMessageBox.MessageBox.GetMessage().Contains("Google map is unavailable"))
                {
                    JazzMessageBox.MessageBox.OK();
                }
            }

            if (JazzMessageBox.MessageBox.Exists())
            {
                if (JazzMessageBox.MessageBox.GetMessage().Contains("服务器错误") || JazzMessageBox.MessageBox.GetMessage().Contains("Server error"))
                {
                    JazzMessageBox.MessageBox.OK();
                }
            }

            TimeManager.MediumPause();
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
            {NavigationTarget.AlarmSettings, new NavigatorItem(NavigationTarget.AlarmSettings,null,JazzButton.AlarmSettings)},

            //level 2
            {NavigationTarget.EnergyAnalysis, new NavigatorItem(NavigationTarget.EnergyAnalysis,NavigationTarget.EnergyView,JazzButton.NavigatorEnergyAnalysisButton)},
            {NavigationTarget.CarbonUsage, new NavigatorItem(NavigationTarget.CarbonUsage,NavigationTarget.EnergyView,JazzButton.NavigatorCarbonUsageButton)},
            {NavigationTarget.CostUsage, new NavigatorItem(NavigationTarget.CostUsage,NavigationTarget.EnergyView,JazzButton.NavigatorCostButton)},
            {NavigationTarget.UnitKPI, new NavigatorItem(NavigationTarget.UnitKPI,NavigationTarget.EnergyView,JazzButton.NavigatorUnitKPIButton)},
            {NavigationTarget.EnergyRadio, new NavigatorItem(NavigationTarget.EnergyRadio,NavigationTarget.EnergyView,JazzButton.NavigatorEnergyRatioButton)},
            {NavigationTarget.Rank, new NavigatorItem(NavigationTarget.Rank,NavigationTarget.EnergyView,JazzButton.NavigatorRankButton)},
            {NavigationTarget.Labeling, new NavigatorItem(NavigationTarget.Labeling,NavigationTarget.EnergyView,JazzButton.NavigatorLabelingButton)},

            {NavigationTarget.TimeSettings, new NavigatorItem(NavigationTarget.TimeSettings,NavigationTarget.PlatformSettings,JazzButton.NavigatorTimeSettingsButton)},
            {NavigationTarget.CarbonSettings, new NavigatorItem(NavigationTarget.CarbonSettings,NavigationTarget.PlatformSettings,JazzButton.NavigatorCarbonSettingsButton)},
            {NavigationTarget.PriceSettings, new NavigatorItem(NavigationTarget.PriceSettings,NavigationTarget.PlatformSettings,JazzButton.NavigatorPriceSettingsButton)},
            {NavigationTarget.CustomerManagement, new NavigatorItem(NavigationTarget.CustomerManagement,NavigationTarget.PlatformSettings,JazzButton.NavigatorCustomerManagementButton)},
            {NavigationTarget.UserManagement, new NavigatorItem(NavigationTarget.UserManagement,NavigationTarget.PlatformSettings,JazzButton.NavigatorUserManagementButton)},
            {NavigationTarget.BenchMarkSettings, new NavigatorItem(NavigationTarget.BenchMarkSettings,NavigationTarget.PlatformSettings,JazzButton.NavigatorBenchMarkSettingButton)},
            {NavigationTarget.IndustryLabelingSettings, new NavigatorItem(NavigationTarget.IndustryLabelingSettings,NavigationTarget.PlatformSettings,JazzButton.NavigatorIndustryLabelingSettingButton)},
            {NavigationTarget.TagSettings, new NavigatorItem(NavigationTarget.TagSettings,NavigationTarget.Settings,JazzButton.NavigatorTagSettingsButton)},
            {NavigationTarget.HierarchySettings, new NavigatorItem(NavigationTarget.HierarchySettings,NavigationTarget.Settings,JazzButton.NavigatorHierarchySettingsButton)},
            {NavigationTarget.AssociationSettings, new NavigatorItem(NavigationTarget.AssociationSettings,NavigationTarget.Settings,JazzButton.NavigatorAssociationSettingsButton)},
            {NavigationTarget.CustomizedLabelling, new NavigatorItem(NavigationTarget.CustomizedLabelling,NavigationTarget.Settings,JazzButton.CustomerLabellingButton)},

            {NavigationTarget.Dashboards, new NavigatorItem(NavigationTarget.Dashboards,NavigationTarget.HomePage,JazzButton.HomepageToDashboardButton)},

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
            //--Customer
            {NavigationTarget.CustomerManagementCustomer, new NavigatorItem(NavigationTarget.CustomerManagementCustomer,NavigationTarget.CustomerManagement,JazzButton.NavigatorCustomerManagementCustomerButton)},
            //--User
            {NavigationTarget.UserManagementUser, new NavigatorItem(NavigationTarget.UserManagementUser,NavigationTarget.UserManagement,JazzButton.NavigatorUserManagementUserButton)},
            {NavigationTarget.UserManagementUserTypePermission, new NavigatorItem(NavigationTarget.UserManagementUserTypePermission,NavigationTarget.UserManagement,JazzButton.NavigatorUserManagementUserTypePermissionButton)},
            //--Tag
            {NavigationTarget.TagSettingsP, new NavigatorItem(NavigationTarget.TagSettingsP,NavigationTarget.TagSettings,JazzButton.NavigatorTagSettingsPButton)},
            {NavigationTarget.TagSettingsV, new NavigatorItem(NavigationTarget.TagSettingsV,NavigationTarget.TagSettings,JazzButton.NavigatorTagSettingsVButton)},
            {NavigationTarget.TagSettingsKPI, new NavigatorItem(NavigationTarget.TagSettingsKPI, NavigationTarget.TagSettings,JazzButton.NavigatorTagSettingsKPIButton)},
            {NavigationTarget.TagSettingsVEE, new NavigatorItem(NavigationTarget.TagSettingsVEE, NavigationTarget.TagSettings,JazzButton.NavigatorTagSettingsVEEButton)},
            {NavigationTarget.AbnormalRecord, new NavigatorItem(NavigationTarget.AbnormalRecord,NavigationTarget.TagSettings,JazzButton.NavigatorAbnormalRecordButton)},
            //--Hierarchy
            {NavigationTarget.HierarchySettingsHierarchy, new NavigatorItem(NavigationTarget.HierarchySettingsHierarchy, NavigationTarget.HierarchySettings,JazzButton.NavigatorHierarchySettingsHierarchyButton)},
            {NavigationTarget.HierarchySettingsSystemDimension, new NavigatorItem(NavigationTarget.HierarchySettingsSystemDimension,NavigationTarget.HierarchySettings,JazzButton.NavigatorHierarchySettingsSystemDimensionButton)},
            {NavigationTarget.HierarchySettingsAreaDimension, new NavigatorItem(NavigationTarget.HierarchySettingsAreaDimension,NavigationTarget.HierarchySettings,JazzButton.NavigatorHierarchySettingsAreaDimensionButton)},
            //--Association
            {NavigationTarget.AssociationHierarchy, new NavigatorItem(NavigationTarget.AssociationHierarchy, NavigationTarget.AssociationSettings,JazzButton.NavigatorAssociationHierarchyButton)},
            {NavigationTarget.AssociationSystemDimension, new NavigatorItem(NavigationTarget.AssociationSystemDimension,NavigationTarget.AssociationSettings,JazzButton.NavigatorAssociationSystemDimensionButton)},
            {NavigationTarget.AssociationAreaDimension, new NavigatorItem(NavigationTarget.AssociationAreaDimension,NavigationTarget.AssociationSettings,JazzButton.NavigatorAssociationAreaDimensionButton)},
            //Dashboard
            {NavigationTarget.MyFavirate, new NavigatorItem(NavigationTarget.MyFavirate,NavigationTarget.Dashboards,JazzButton.NavigatorMyFavirateButton)},
            {NavigationTarget.AllDashboards, new NavigatorItem(NavigationTarget.AllDashboards,NavigationTarget.Dashboards,JazzButton.NavigatorAllDashboardsButton)},
            {NavigationTarget.RecentView, new NavigatorItem(NavigationTarget.RecentView,NavigationTarget.Dashboards,JazzButton.NavigatorRecentViewButton)},    
            {NavigationTarget.MyShare, new NavigatorItem(NavigationTarget.MyShare,NavigationTarget.Dashboards,JazzButton.NavigatorMyShareButton)},    
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
        AlarmSettings = 112,

        //level 2
        //used different number to avoid conflict
        EnergyAnalysis=201,
        CarbonUsage = 202,
        CostUsage = 203,
        UnitKPI = 204,
        EnergyRadio = 205,
        Rank = 206,
        Labeling = 221,
        TimeSettings = 5,
        CarbonSettings = 6,
        PriceSettings = 7,
        CustomerManagement = 8,
        UserManagement = 9,
        TagSettings = 10,
        HierarchySettings = 11,
        AssociationSettings = 12,
        CustomizedLabelling = 31,
        BenchMarkSettings = 113,
        IndustryLabelingSettings=114,
		Dashboards = 300,
        //level 3
        //--Time
        TimeSettingsWorkday = 13,
        TimeSettingsWorktime = 14,
        TimeSettingsSeason = 15,
        TimeSettingsDaynight = 16,
        //--Carbon
        CarbonSettingsCarbon = 17,
        //--Price
        PriceSettingsPrice = 18,
        //--Customer
        CustomerManagementCustomer = 19,
        //--User
        UserManagementUser = 20,
        UserManagementUserTypePermission = 21,
        //--Tag
        TagSettingsP = 22,
        TagSettingsV = 23,
        TagSettingsKPI = 24,
        AbnormalRecord = 32,
        TagSettingsVEE = 33,
        //--Hierarchy
        HierarchySettingsHierarchy = 25,
        HierarchySettingsSystemDimension = 26,
        HierarchySettingsAreaDimension = 27,
        //--Association
        AssociationHierarchy = 28,
        AssociationSystemDimension = 29,
        AssociationAreaDimension = 30,

        //Dashboard
        MyFavirate = 207,
        AllDashboards = 208,
        RecentView = 209,
        MyShare = 210,
    }
}