using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzGrid : JazzControlCollection
    {
        public static Grid VTagSettingsFormulaEditPTagList = GetControl<Grid>(JazzControlLocatorKey.GridVTagSettingsFormulaEditPTagList);
        public static Grid VTagSettingsVTagList = GetControl<Grid>(JazzControlLocatorKey.GridVTagSettingsVTagList);

        public static Grid AssociationTagList = GetControl<Grid>(JazzControlLocatorKey.GridAssociationTagList);
    }
}
