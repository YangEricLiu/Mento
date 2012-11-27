using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.NewControls
{
    public class AreaDimensionTree : TreeView
    {
        private const string AREADIMENSIONTREEXPATH = "//table[@class='x-grid-table x-grid-table-resizer']";

        public AreaDimensionTree() : base(new Locator(AREADIMENSIONTREEXPATH, ByType.Xpath)) { }
    }
}