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
            return GetControl<Label>(key, positionIndex);
        }

        public static Label GetOneLabelByName(string key, string nameIndex)
        {
            return GetControl<Label>(key, nameIndex);
        }
        #endregion

        #region customer setting

        #region hierarchy calendar property
        public static Label WorkdayCalendarLabel = GetControl<Label>(JazzControlLocatorKey.LabelWorkdayCalendar);
        public static Label WorktimeCalendarLabel = GetControl<Label>(JazzControlLocatorKey.LabelWorktimeCalendar);
        public static Label HeatingCoolingCalendarLabel = GetControl<Label>(JazzControlLocatorKey.LabelHeatingCoolingCalendar);
        public static Label DayNightCalendarLabel = GetControl<Label>(JazzControlLocatorKey.LabelDayNightCalendar);

        public static Label WorkdayLabelTitle = GetControl<Label>(JazzControlLocatorKey.LabelTitleWorkday);
        public static Label HeatingCoolingLabelTitle = GetControl<Label>(JazzControlLocatorKey.LabelTitleHeatingCooling);
        public static Label DayNightLabelTitle = GetControl<Label>(JazzControlLocatorKey.LabelTitleDayNight);
        #endregion

        #region hierarchy population area

        public static Label AreaPropertyTitleLabel = GetControl<Label>(JazzControlLocatorKey.LabelAreaPropertyTitle);

        #endregion

        #region TargetBaseline
        public static Label CalendarInfoDisplayLabel = GetControl<Label>(JazzControlLocatorKey.LabelCalendarInfoDisplay);
        #endregion

        #region CustomizedLabellingSetting
        public static Label InputValueErrTipsLabel = GetControl<Label>(JazzControlLocatorKey.LabelInputValueErrTips);
        #endregion

        #endregion

        #region platform setting

        #region calendar
        public static Label PlatformWorkdayCalendarLabel = GetControl<Label>(JazzControlLocatorKey.LabelPlatformWorkdayCalendar);
        public static Label PlatformWorktimeCalendarLabel = GetControl<Label>(JazzControlLocatorKey.LabelPlatformWorktimeCalendar);
        public static Label PlatformDayNightCalendarLabel = GetControl<Label>(JazzControlLocatorKey.LabelPlatformDayNightCalendar);
        public static Label WidgetName = GetControl<Label>(JazzControlLocatorKey.WidgetName);
        #endregion

        # region benchmarkseting
        public static Label PlatformBenchMarkLabel = GetControl<Label>(JazzControlLocatorKey.LabelPlatformBenchMarkSetting);
        #endregion

        # region labelingseting
        public static Label PlatformLabelingLabel = GetControl<Label>(JazzControlLocatorKey.LabelPlatformLabelingSetting);
        #endregion
        #region CustomerMapInfo
        public static Label PlatformCustomerMapInfoLabel = GetControl<Label>(JazzControlLocatorKey.LabelPlatformCustomerMapInfo);
        #endregion

        #endregion

        #region DemoAccess
        public static Label LabelEmailSendedSuccessTips = GetControl<Label>(JazzControlLocatorKey.LabelEmailSendedSuccessTips);
        #endregion

        #region home page

        public static Label DashboardHeaderNameLabel = GetControl<Label>(JazzControlLocatorKey.LabelDashboardHeaderName);
        public static Label WidgetNameMinLabel = GetControl<Label>(JazzControlLocatorKey.LabelWidgetNameMin);
        public static Label WidgetNameMaxLabel = GetControl<Label>(JazzControlLocatorKey.LabelWidgetNameMax);
        public static Label EmptyDashboardLabel = GetControl<Label>(JazzControlLocatorKey.LabelEmptyDashboard);
        public static Label PopNotesLabel = GetControl<Label>(JazzControlLocatorKey.LabelPopNotes);
        public static Label DashboardFavoriteLevelLabel = GetControl<Label>(JazzControlLocatorKey.LabelDashboardFavoriteLevel);
        public static Label DashboardShareResourceCommonLabel = GetControl<Label>(JazzControlLocatorKey.LabelDashboardShareResourceCommon);
        public static Label DashboardShareResourceTimeLabel = GetControl<Label>(JazzControlLocatorKey.LabelDashboardShareResourceTime);
        public static Label DashboardShareResourceUserLabel = GetControl<Label>(JazzControlLocatorKey.LabelDashboardShareResourceUser);
        public static Label ShareWindowTitleLabel = GetControl<Label>(JazzControlLocatorKey.LabelShareWindowTitle);

        public static Label WidgetShareResourceCommonLabel = GetControl<Label>(JazzControlLocatorKey.LabelWidgetShareResourceCommon);
        public static Label WidgetShareResourceTimeLabel = GetControl<Label>(JazzControlLocatorKey.LabelWidgetShareResourceTime);
        public static Label WidgetShareResourceUserLabel = GetControl<Label>(JazzControlLocatorKey.LabelWidgetShareResourceUser);
        public static Label AnnotationTextLabel = GetControl<Label>(JazzControlLocatorKey.LabelAnnotationText);
        public static Label MaxWidgetCommentLabel = GetControl<Label>(JazzControlLocatorKey.LabelMaxWidgetComment);
        public static Label SaveDashboardDialogHierarchyLabel = GetControl<Label>(JazzControlLocatorKey.LabelSaveDashboardDialogHierarchy);
        #endregion

        #region Energy View


        #endregion

    }
}
