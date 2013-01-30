using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.NewControls;
using Mento.TestApi.WebUserInterface;

namespace Mento.ScriptCommon.Library.Controls
{
    public class JazzButton : Mento.TestApi.WebUserInterface.NewControls.Button
    {
        public JazzButton(Locator buttonLocator)
            : base(buttonLocator) 
        {
        }
    }

    public static class JazzButtonNames
    {
        public static Locator DimensionSelectHierarchyButton = new Locator("st-assoc-hier-btn",ByType.ID);

        public static Locator SystemDimensionUpdateButton = new Locator("st-sys-tree-update", ByType.ID);

        public static Locator AreaDimensionCreateButton = new Locator("st-area-tree-add", ByType.ID);
        
    }
}
