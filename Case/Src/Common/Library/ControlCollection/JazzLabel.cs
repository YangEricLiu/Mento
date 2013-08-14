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

        #endregion

        #region platform setting

        #region calendar
        public static Label PlatformWorkdayCalendarLabel = GetControl<Label>(JazzControlLocatorKey.LabelPlatformWorkdayCalendar);
        public static Label PlatformWorktimeCalendarLabel = GetControl<Label>(JazzControlLocatorKey.LabelPlatformWorktimeCalendar);
        public static Label PlatformDayNightCalendarLabel = GetControl<Label>(JazzControlLocatorKey.LabelPlatformDayNightCalendar);
        public static Label WidgetName = GetControl<Label>(JazzControlLocatorKey.WidgetName);
        #endregion

        #endregion

        #region home page

        public static Label DashboardHeaderNameLabel = GetControl<Label>(JazzControlLocatorKey.LabelDashboardHeaderName);
        public static Label WidgetNameMinLabel = GetControl<Label>(JazzControlLocatorKey.LabelWidgetNameMin);

        #endregion

        #region Energy View


        #endregion

    }
}
