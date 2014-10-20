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

        public static Container PeopleItemsContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerPeopleItems);}}
        public static Container PeopleErrorTipsContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerPeopleErrorTips);}}
        public static Container WorkdayErrorTipsContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerWorkdayErrorTips);}}
        public static Container HCErrorTipsContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerHCErrorTips);}}
        public static Container DayNightErrorTipsContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerDayNightErrorTips);}}
        public static Container HierarchyBuildingPictureContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerHierarchyBuildingPicture);}}

        #endregion

        #region Hierarchy Cost Property

        public static Container WaterCostValueItemsContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerWaterCostValueItems);}}
        public static Container ElectricCostValueItemsContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerElectricCostValueItems);}}

        #endregion

        #region Associate

        public static Container AssociatedTagsContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerAssociatedTags);}}
        
        #endregion

        #region TargetBaseline

        public static Container TBCalendarInfoContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerTBCalendarInfo);}}
        public static Container TBWorkdayRuleContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerTBWorkdayRule);}}
        public static Container TBNonworkdayRuleContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerTBNonworkdayRule);}}
        public static Container TBSpecialdayRuleContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerTBSpecialdayRule);}}
        
        #endregion

        #endregion

        #region HomePage

        public static Container ContainerWidgetsToDashboard{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerWidgetsToDashboard);}}
        public static Container ShareWindowToContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerShareWindowTo);}}
        public static Container DashboardsContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerDashboards);}}
        public static Container ContainerWidgetsToMyShare{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerWidgetsToMyShare);}}
        public static Container WidgetsNamesToMyShareContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerWidgetsNamesToMyShare);}}
        public static Container CommentsOnMaxwidgetContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerCommentsOnMaxwidget);}}
        
        #endregion

        #region EnergyView

        #region energy analysis

        public static Container MultiHierarchyPanelContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerMultiHierarchyPanel);}}
        public static Container ExcludeTimeIntervalsContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerExcludeTimeIntervals);}}
        public static Container MultiHierarchysContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerMultiHierarchys);}}

        
        #endregion

        #endregion

        #region platform setting

        #region TimeManagment containers
        public static Container CalendarItemsContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerCalendarItems);}}
        public static Container CalendarColdWarmItemsContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerColdWarmCalendarItems);}}
        #endregion

        #region TOU containers
        public static Container TOU24HoursErrorTipsContainer{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerTOU24HoursErrorTips);}}
        #endregion
        
        #region UserRoleType
        public static Container ContainerPermissionCustomerizeItems{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerPermissionCustomerizeItems);}}

        public static Container ContainerPermissionPublicTypeItems{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerPermissionPublicTypeItems);}}

        #endregion

        #region User
        public static Container ContainerDisplayPermissionCustomerizeItems{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerDisplayPermissionCustomerizeItems);}}

        public static Container ContainerDisplayPermissionPublicTypeItems{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerDisplayPermissionPublicTypeItems);}}
        public static Container ContainerDisplayPermissionItems{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerDisplayPermissionItems);}}

        #endregion

        #region CustomerMapInfo
        public static Container ContainerCustomerMapInfo{ get { return GetControl<Container>(JazzControlLocatorKey.ContainerCustomerMapInfo);}}
        public static Container ContainerCustomerAdmin = GetControl<Container>(JazzControlLocatorKey.ContainerCustomerAdmin);
        
        #endregion

        #region BenchMark
        
        #endregion

        #endregion
     }
}