using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzWindow : JazzControlCollection
    {
        #region energy view

            public static Window WindowMessageInfos {  get { return GetControl<Window>(JazzControlLocatorKey.WindowMessageInfos);}}

        #endregion

        #region customer setting

            #region hierarchy cost property

            public static Window FactorWindow { get { return GetControl<Window>(JazzControlLocatorKey.WindowFactor); } }

            #endregion

            #region TargetBaseline

            public static Window TBCalendarInfoWindow { get { return GetControl<Window>(JazzControlLocatorKey.WindowTBCalendarInfo); } }

            #endregion

            #region RawDataSwitch

            public static Window SwitchTimeWindow { get { return GetControl<Window>(JazzControlLocatorKey.WindowSwitchTime); } }
        
            #endregion
        
        #endregion

    }
}
