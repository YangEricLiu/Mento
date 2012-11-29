﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class SystemDimensionSettings
    {
        internal SystemDimensionSettings() { }

        private static HierarchyTree DimensionHierarchyTree = JazzTreeView.HierarchySettingsDimensionHierarchyTree;

        private static SystemDimensionTree SystemDimensionTree = JazzTreeView.HierarchySettingsSystemDimensionTree;

        private static Button ShowHierarchyTreeButton;
        private static Button SetSystemDimensionButton;

        private static SystemDimensionTree DialogSystemDimensionTree = JazzTreeView.HierarchySettingsDialogSystemDimensionTree;

        private static Button DialogReturnButton;


        public void ShowHierarchyTree()
        {
            ShowHierarchyTreeButton.Click();
        }

        public void ExpandHierarchyNodePath(string[] hierarchyNodePath)
        {
            DimensionHierarchyTree.ExpandNodePath(hierarchyNodePath);
        }

        public void ShowSystemDimensionDialog()
        {
            SetSystemDimensionButton.Click();
        }

        public void CheckSystemDimensionNodePath(string[] systemDimensionNodePath)
        {
            DialogSystemDimensionTree.CheckNodePath(systemDimensionNodePath);
        }

        public void CloseSystemDimensionDialog()
        {
            DialogReturnButton.Click();
        }
    }
}
