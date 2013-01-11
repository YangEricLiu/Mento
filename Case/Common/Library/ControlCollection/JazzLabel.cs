﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzLabel : JazzControlCollection
    {
        #region customer setting
        #region hierarchy calendar property
        public static Label WorkdayCalendarLabel = GetControl<Label>(JazzControlLocatorKey.LabelWorkdayCalendar);
        public static Label HeatingCoolingCalendarLabel = GetControl<Label>(JazzControlLocatorKey.LabelHeatingCoolingCalendar);
        public static Label DayNightCalendarLabel = GetControl<Label>(JazzControlLocatorKey.LabelDayNightCalendar);
        #endregion
        #endregion
        #region platform setting
        #region calendar
        public static Label PlatformWorkdayCalendarLabel = GetControl<Label>(JazzControlLocatorKey.LabelPlatformWorkdayCalendar);
        public static Label PlatformWorktimeCalendarLabel = GetControl<Label>(JazzControlLocatorKey.LabelPlatformWorktimeCalendar);
        public static Label PlatformDayNightCalendarLabel = GetControl<Label>(JazzControlLocatorKey.LabelPlatformDayNightCalendar);
        #endregion
        #endregion
    }
}
