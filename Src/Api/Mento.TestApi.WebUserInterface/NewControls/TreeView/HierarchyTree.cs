using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.Framework.Constants;

namespace Mento.TestApi.WebUserInterface.NewControls
{
    public class HierarchyTree : TreeView
    {
        private const string HIERARCHYTREEXPATH = "//table[@class='x-grid-table x-grid-table-resizer']";

        public HierarchyTree() : base(new Locator(HIERARCHYTREEXPATH, ByType.Xpath)) { }
    }
}
