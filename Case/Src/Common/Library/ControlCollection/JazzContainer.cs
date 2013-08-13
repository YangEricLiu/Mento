using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzContainer : JazzControlCollection
    {

        #region Customer settings Containers

        #region Hierarchy property settings containers

        public static Container PeopleItemsContainer = GetControl<Container>(JazzControlLocatorKey.ContainerPeopleItems);
        public static Container PeopleErrorTipsContainer = GetControl<Container>(JazzControlLocatorKey.ContainerPeopleErrorTips);
        public static Container WorkdayErrorTipsContainer = GetControl<Container>(JazzControlLocatorKey.ContainerWorkdayErrorTips);
        public static Container HCErrorTipsContainer = GetControl<Container>(JazzControlLocatorKey.ContainerHCErrorTips);
        public static Container DayNightErrorTipsContainer = GetControl<Container>(JazzControlLocatorKey.ContainerDayNightErrorTips);
        
        #endregion

        #region Hierarchy Cost Property

        public static Container WaterCostValueItemsContainer = GetControl<Container>(JazzControlLocatorKey.ContainerWaterCostValueItems);
        public static Container ElectricCostValueItemsContainer = GetControl<Container>(JazzControlLocatorKey.ContainerElectricCostValueItems);

        #endregion

        #region Associate

        public static Container AssociatedTagsContainer = GetControl<Container>(JazzControlLocatorKey.ContainerAssociatedTags);
        
        #endregion

        #region TargetBaseline

        public static Container TBCalendarInfoContainer = GetControl<Container>(JazzControlLocatorKey.ContainerTBCalendarInfo);
        public static Container TBWorkdayRuleContainer = GetControl<Container>(JazzControlLocatorKey.ContainerTBWorkdayRule);
        public static Container TBNonworkdayRuleContainer = GetControl<Container>(JazzControlLocatorKey.ContainerTBNonworkdayRule);
        public static Container TBSpecialdayRuleContainer = GetControl<Container>(JazzControlLocatorKey.ContainerTBSpecialdayRule);
        
        #endregion

        #endregion

        #region UserRoleType
        public static Container ContainerPermissionCustomerizeItems = GetControl<Container>(JazzControlLocatorKey.ContainerPermissionCustomerizeItems);

        public static Container ContainerPermissionPublicTypeItems = GetControl<Container>(JazzControlLocatorKey.ContainerPermissionPublicTypeItems);
       
        #endregion

        #region User
        public static Container ContainerDisplayPermissionCustomerizeItems = GetControl<Container>(JazzControlLocatorKey.ContainerDisplayPermissionCustomerizeItems);

        public static Container ContainerDisplayPermissionPublicTypeItems = GetControl<Container>(JazzControlLocatorKey.ContainerDisplayPermissionPublicTypeItems);
        public static Container ContainerDisplayPermissionItems = GetControl<Container>(JazzControlLocatorKey.ContainerDisplayPermissionItems);

        #endregion

        #region HomePage

        public static Container ContainerWidgetsToDashboard = GetControl<Container>(JazzControlLocatorKey.ContainerWidgetsToDashboard);

        #endregion

        #region EnergyView

        #region energy analysis

        public static Container MultiHierarchyPanelContainer = GetControl<Container>(JazzControlLocatorKey.ContainerMultiHierarchyPanel);

        #endregion

        #endregion
    }
}