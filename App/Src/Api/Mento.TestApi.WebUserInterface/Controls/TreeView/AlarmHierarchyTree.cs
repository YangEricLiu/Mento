﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.Framework.Constants;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class AlarmHierarchyTree : TreeView
    {
        //private const string HIERARCHYTREEXPATH = "//table[@class='x-grid-table x-grid-table-resizer']";

        public AlarmHierarchyTree(Locator locator) : base(locator) { }
    }
}
