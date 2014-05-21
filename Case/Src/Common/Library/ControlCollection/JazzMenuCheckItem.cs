using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzMenuCheckItem : JazzControlCollection
    {
        #region Associated 
        public static MenuCheckItem AssociateStatus = GetControl<MenuCheckItem>(JazzControlLocatorKey.AssociateStatusMenuCheckItem);
        #endregion     
    }
}
 