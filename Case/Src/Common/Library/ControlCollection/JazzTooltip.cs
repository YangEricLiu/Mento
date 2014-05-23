using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzTooltip : JazzControlCollection
    {

        #region home page

        public static Tooltip ShareUserTooltip = GetControl<Tooltip>(JazzControlLocatorKey.TooltipShareUser);

        #endregion

        #region Associate

        public static Tooltip AssociatedInfoTooltip = GetControl<Tooltip>(JazzControlLocatorKey.TooltipAssociatedInfo);

        #endregion

    }
}
