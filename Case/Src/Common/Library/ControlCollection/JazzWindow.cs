using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzWindow : JazzControlCollection
    {
        

        #region customer setting

        #region hierarchy cost property

        public static Window FactorWindow = GetControl<Window>(JazzControlLocatorKey.WindowFactor);

        #endregion

        #region TargetBaseline

        public static Window TBCalendarInfoWindow = GetControl<Window>(JazzControlLocatorKey.WindowTBCalendarInfo);

        #endregion

        #endregion

    }
}
