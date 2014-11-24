using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzLabel : JazzControlCollection
    {
        #region Get Position Label Method
        public static Label GetOneLabel(string key, int positionIndex)
        {
            return GetControl<Label>(key, positionIndex) ;
        }

        public static Label GetOneLabelByName(string key, string nameIndex)
        {
            return GetControl<Label>(key, nameIndex) ;
        }
        #endregion

        #region customer setting

        #region hierarchy calendar property
        public static Label WorkdayCalendarLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelWorkdayCalendar);}}
        public static Label WorktimeCalendarLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelWorktimeCalendar);}}
        public static Label HeatingCoolingCalendarLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelHeatingCoolingCalendar);}}
        public static Label DayNightCalendarLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelDayNightCalendar);}}

        public static Label WorkdayLabelTitle{ get { return GetControl<Label>(JazzControlLocatorKey.LabelTitleWorkday);}}
        public static Label HeatingCoolingLabelTitle{ get { return GetControl<Label>(JazzControlLocatorKey.LabelTitleHeatingCooling);}}
        public static Label DayNightLabelTitle{ get { return GetControl<Label>(JazzControlLocatorKey.LabelTitleDayNight);}}
        #endregion

        #region hierarchy population area

        public static Label AreaPropertyTitleLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelAreaPropertyTitle);}}

        #endregion

        #region TargetBaseline
        public static Label CalendarInfoDisplayLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelCalendarInfoDisplay);}}
        #endregion

        #region CustomizedLabellingSetting
        public static Label InputValueErrTipsLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelInputValueErrTips);}}
        #endregion

        #endregion

        #region platform setting

        #region calendar
        public static Label PlatformWorkdayCalendarLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelPlatformWorkdayCalendar);}}
        public static Label PlatformWorktimeCalendarLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelPlatformWorktimeCalendar);}}
        public static Label PlatformHeatingCoolingSeasonCalendarLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelPlatformHeatingCoolingSeasonCalendar);}}
        public static Label PlatformDayNightCalendarLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelPlatformDayNightCalendar);}}
        public static Label WidgetName{ get { return GetControl<Label>(JazzControlLocatorKey.WidgetName);}}
        #endregion

        #region TOU
        public static Label PlatformTOUBasicPropertyLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelPlatformTOUBasicProperty);}}
        #endregion

        # region benchmarkseting
        public static Label PlatformBenchMarkLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelPlatformBenchMarkSetting);}}
        #endregion

        # region labelingseting
        public static Label PlatformLabelingLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelPlatformLabelingSetting);}}
        #endregion
        #region CustomerMapInfo
        public static Label PlatformCustomerMapInfoLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelPlatformCustomerMapInfo);}}
        #endregion

        #endregion

        #region DemoAccess
        public static Label LabelEmailSendedSuccessTips{ get { return GetControl<Label>(JazzControlLocatorKey.LabelEmailSendedSuccessTips);}}
        #endregion

        #region home page

        public static Label DashboardHeaderNameLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelDashboardHeaderName);}}
        public static Label WidgetNameMinLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelWidgetNameMin);}}
        public static Label WidgetNameMaxLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelWidgetNameMax);}}
        public static Label EmptyDashboardLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelEmptyDashboard);}}
        public static Label PopNotesLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelPopNotes);}}
        public static Label DashboardFavoriteLevelLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelDashboardFavoriteLevel);}}
        public static Label DashboardShareResourceCommonLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelDashboardShareResourceCommon);}}
        public static Label DashboardShareResourceTimeLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelDashboardShareResourceTime);}}
        public static Label DashboardShareResourceUserLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelDashboardShareResourceUser);}}
        public static Label ShareWindowTitleLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelShareWindowTitle);}}

        public static Label WidgetShareResourceCommonLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelWidgetShareResourceCommon);}}
        public static Label WidgetShareResourceTimeLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelWidgetShareResourceTime);}}
        public static Label WidgetShareResourceUserLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelWidgetShareResourceUser);}}
        public static Label AnnotationTextLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelAnnotationText);}}
        public static Label MaxWidgetCommentLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelMaxWidgetComment);}}
        public static Label SaveDashboardDialogHierarchyLabel{ get { return GetControl<Label>(JazzControlLocatorKey.LabelSaveDashboardDialogHierarchy);}}

        public static Label QuickCreateWidgetNameMinLabel = GetControl<Label>(JazzControlLocatorKey.LabelQuickCreateWidgetNameMin);
        public static Label QuickCreateWidgetFieldLabel = GetControl<Label>(JazzControlLocatorKey.LabelQuickCreateWidgetField);
        //public static Label WidgetTemplateNameMinLabel = GetControl<Label>(JazzControlLocatorKey.LabelWidgetTemplateNameMin);
        public static Label WidgetTemplateCriteriaLabel = GetControl<Label>(JazzControlLocatorKey.LabelWidgetTemplateCriteria);
        
          
        #endregion

        #region Energy View


        #endregion

    }
}
