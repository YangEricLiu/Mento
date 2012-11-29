using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class HierarchyAssociateSettings
    {
        internal HierarchyAssociateSettings()
        {
        }

        private HierarchyTree HierarchyTree = JazzTreeView.AssociationHierarchyTree;
        private Grid TagList = JazzGrid.AssociationTagList;

        public void ExpandHierarchyNodePath(string[] hierarchyNodePath)
        {
            HierarchyTree.ExpandNodePath(hierarchyNodePath);
            TimeManager.PauseShort();
        }

        /// <summary>
        /// Navigate to hierarchy associate setting
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigateToHierarchyAssociate()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationHierarchy);
        }

        /// <summary>
        /// Click the check box in the front of tag
        /// </summary>
        /// <param name = "tagName">the tag name</param>
        /// <returns></returns>
        public void CheckedTag(string tagName)
        {
            TagList.CheckRowCheckbox(3, tagName);
        }

        /// <summary>
        /// Click the "associate tags" button
        /// </summary>
        /// <returns></returns>
        public void ClickAssociateTagButton()
        {
            JazzButton.AssociationSettingsTagAssociate.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        /// <summary>
        /// Click the "associate" button
        /// </summary>
        /// <returns></returns>
        public void ClickAssociateButton()
        {
            JazzButton.AssociationSettingsAssociate.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        /// <summary>
        /// Judge if the associated tag is displayed
        /// </summary>
        /// <returns>True if the tag displayed, false if not</returns>
        public Boolean IsTagOnAssociategGridView(string tagName)
        {
            return TagList.IsRowExist(3, tagName);
        }
    }
}
