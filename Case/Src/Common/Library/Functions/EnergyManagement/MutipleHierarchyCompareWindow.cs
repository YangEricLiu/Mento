﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class MutipleHierarchyCompareWindow : Window
    {
        private static Locator Locator = new Locator("//div[contains(@id,'multihierwindow') and contains(@class,'x-window-default')]", ByType.XPath);

        internal MutipleHierarchyCompareWindow() : base(Locator) { }

        #region controls

        private static Button MultipleHierarchyTreeButton = JazzButton.MultipleHierarchyTreeButton;
        private static HierarchyTree MultipleHierarchyTree = JazzTreeView.MultipleHierarchyTree;

        #endregion

        #region tree operation

        public void SelectHierarchyNode(string[] nodePath)
        {
            MultipleHierarchyTreeButton.Click();
            TimeManager.ShortPause();
            MultipleHierarchyTree.SelectNode(nodePath);
        }


        #endregion
    }
}
