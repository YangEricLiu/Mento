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

        private static Button ShowHierarchyTreeButton = JazzButton.SystemDimensionSettingsShowHierarchyTreeButton;
        private static Button SetSystemDimensionButton = JazzButton.SystemDimensionSettingsSetButton;

        private static SystemDimensionTree DialogSystemDimensionTree = JazzTreeView.HierarchySettingsDialogSystemDimensionTree;

        private static Button DialogReturnButton = JazzButton.SystemDimensionSettingsDialogReturnButton;


        public void ShowHierarchyTree()
        {
            ShowHierarchyTreeButton.Click();
        }

        public void ExpandHierarchyNodePath(string[] hierarchyNodePath)
        {
            DimensionHierarchyTree.ExpandNodePath(hierarchyNodePath);
        }

        public void SelectHierarchyNode(string hierarchyNodeName)
        {
            DimensionHierarchyTree.ClickNode(hierarchyNodeName);
        }

        public void SelectHierarchyNodePath(string[] hierarchyNodePath)
        {
            DimensionHierarchyTree.SelectNode(hierarchyNodePath);
        }

        public void ShowSystemDimensionDialog()
        {
            SetSystemDimensionButton.Click();
        }

        public void CheckSystemDimensionNodePath(string[] systemDimensionNodePath)
        {
            DialogSystemDimensionTree.CheckNodePath(systemDimensionNodePath);
        }

        public void UncheckSystemDimensionNodePath(string[] systemDimensionNodePath)
        {
            DialogSystemDimensionTree.UncheckNodePath(systemDimensionNodePath);
        }

        public void CloseSystemDimensionDialog()
        {
            DialogReturnButton.Click();
        }

        public void ExpandSystemDimensionNodePath(string[] systemDimensionNodePath)
        {
            SystemDimensionTree.ExpandNodePath(systemDimensionNodePath);
        }

        public void SelectSystemDimensionNode(string systemDimensionNodeName)
        {
            SystemDimensionTree.ClickNode(systemDimensionNodeName);
        }

        public Boolean SelectSystemDimensionNodePath(string[] systemDimensionNodePath)
        {
            try
            {
                SystemDimensionTree.SelectNode(systemDimensionNodePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean IsSystemDimensionNodeDisplayed(string nodeName)
        {
            return SystemDimensionTree.IsNodeDisplayed(nodeName);
        }
    }
}