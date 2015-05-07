using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;

namespace Mento.ScriptCommon.Library.Functions
{
    public class SystemDimensionSettings
    {
        internal SystemDimensionSettings() { }

        #region Controls

        private static HierarchyTree DimensionHierarchyTree = JazzTreeView.HierarchySettingsDimensionHierarchyTree;

        private static SystemDimensionTree SystemDimensionTree = JazzTreeView.HierarchySettingsSystemDimensionTree;

        private static Button ShowHierarchyTreeButton = JazzButton.SystemDimensionSettingsShowHierarchyTreeButton;
        private static Button SetSystemDimensionButton = JazzButton.SystemDimensionSettingsSetButton;

        private static SystemDimensionTree DialogSystemDimensionTree = JazzTreeView.HierarchySettingsDialogSystemDimensionTree;
       
        private static Button DialogReturnButton = JazzButton.SystemDimensionSettingsDialogReturnButton;
        private static Button DislogCloseButton = JazzButton.SystemDimensionSettingsCloseButton;

        #endregion

        #region common

        public void NavigateToSystemDimension()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
        }

        public void CloseSystemDimensionDialogIfNot()
        {
            if (DialogSystemDimensionTree.Exists())
            {
                ConfirmSystemDimensionDialog();
            }     
        }

        #endregion

        #region Tree Operations

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
            TimeManager.MediumPause();
        }

        #endregion

        #region System Tree Operations

        public void ShowSystemDimensionDialog()
        {
            SetSystemDimensionButton.Click();
        }

        public void CheckSystemDimensionNodePath(string[] systemDimensionNodePath)
        {
            DialogSystemDimensionTree.CheckNodePath(systemDimensionNodePath);
        }

        public void CheckSystemDimensionNode(string dimensionName)
        {
            DialogSystemDimensionTree.CheckNode(dimensionName);
        }

        public void UncheckSystemDimensionNodePath(string[] systemDimensionNodePath)
        {
            DialogSystemDimensionTree.UncheckNodePath(systemDimensionNodePath);
        }

        public void UncheckSystemDimensionNodeWithoutConfirm(string systemDimensionNode)
        {
            DialogSystemDimensionTree.UncheckNodeWithoutConfirm(systemDimensionNode);
        }

        public void ExpandSystemDimensionNodePath(string[] systemDimensionNodePath)
        {
            SystemDimensionTree.ExpandNodePath(systemDimensionNodePath);
        }

        public void ExpandDialogSystemDimensionNodePath(string[] systemDimensionNodePath)
        {
            DialogSystemDimensionTree.ExpandNodePath(systemDimensionNodePath);
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

        public void ConfirmSystemDimensionDialog()
        {
            DialogReturnButton.Click();
        }

        public void CloseSystemDimensionDialog()
        {
            DislogCloseButton.Click();
        }


   
        #endregion

        #region Verification
        public Boolean IsSystemDimensionNodeDisplayed(string nodeName)
        {
            return SystemDimensionTree.IsNodeDisplayed(nodeName);
        }
        #endregion
        
    }
}
