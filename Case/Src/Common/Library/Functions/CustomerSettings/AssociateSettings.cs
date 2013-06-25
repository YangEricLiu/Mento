using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class AssociateSettings
    {
        internal AssociateSettings()
        {
        }

        #region controls

        private HierarchyTree HierarchyTree = JazzTreeView.AssociationHierarchyTree;
        private Grid TagList = JazzGrid.AssociationTagList;
        private Button AssociationSettingsCancel = JazzButton.AssociationSettingCancel;
        private Button Association = JazzButton.AssociationSettingsAssociate;
        private Button AssociationTag = JazzButton.AssociationSettingsTagAssociate;
        private Container AssociatedTags = JazzContainer.AssociatedTagsContainer;
       
        #endregion

        #region common

        public void ExpandHierarchyNodePath(string[] hierarchyNodePath)
        {
            HierarchyTree.ExpandNodePath(hierarchyNodePath);
            TimeManager.FlashPause();
        }

        public void SelectHierarchyNode(string hierarchyName)
        {
            HierarchyTree.ClickNode(hierarchyName);
            TimeManager.FlashPause();
        }

        public Boolean SelectHierarchyNodePath(string[] hierarchyNamePath)
        {
            try
            {
                HierarchyTree.SelectNode(hierarchyNamePath);
                TimeManager.FlashPause();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
        /// Navigate to systemdimension associate setting
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigateToSystemDimensionAssociate()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationSystemDimension);
        }

        /// <summary>
        /// Navigate to areadimension associate setting
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigateToAreaDimensionAssociate()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationAreaDimension);
        }

        /// <summary>
        /// Click the "associate tags" button
        /// </summary>
        /// <returns></returns>
        public void ClickAssociateTagButton()
        {
            AssociationTag.Click();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
        }

        public bool IsAssociateTagButtonDisplayed()
        {
            return AssociationTag.IsDisplayed();
        }

        /// <summary>
        /// Click the "Cancel" button
        /// </summary>
        /// <returns></returns>
        public void ClickCancelButton()
        {
            AssociationSettingsCancel.Click();
        }

        public bool IsCancelButtonDisplayed()
        {
            return AssociationSettingsCancel.IsDisplayed();
        }
        #endregion

        #region Actions

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
        /// Click the check box in the front of tags
        /// </summary>
        /// <param name = "tagNames">the tag name</param>
        /// <returns></returns>
        public void CheckedTags(string[] tagNames)
        {
            foreach (string tagName in tagNames)
            {
                TagList.CheckRowCheckbox(3, tagName);
            }          
        }

        public bool IsTagChecked(string tagName)
        {
            return TagList.IsRowChecked(3, tagName);
        }

        /// <summary>
        /// Click the "associate" button
        /// </summary>
        /// <returns></returns>
        public void ClickAssociateButton()
        {
            Association.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public bool IsAssociateButtonDisplayed()
        {
            return Association.IsDisplayed();
        }

        public void RemoveTag(string tagName)
        {
            Button tagRemoveButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonAssociatedTagRemove, tagName);

            tagRemoveButton.Click();
        }

        public void RemoveTags(string[] tagNames)
        {
            foreach (string tagName in tagNames)
            {
                Button tagRemoveButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonAssociatedTagRemove, tagName);

                tagRemoveButton.Click();
            }
        }

        public bool IsRemoveTagExisted(string tagName)
        {
            Button tagRemoveButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonAssociatedTagRemove, tagName);
            
            try 
            {   
                tagRemoveButton.IsDisplayed();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region verification

        /// <summary>
        /// Judge if the associated tag is displayed
        /// </summary>
        /// <returns>True if the tag displayed, false if not</returns>
        public Boolean IsTagOnAssociatedGridView(string tagName)
        {
            return TagList.IsRowExist(3, tagName);
        }

        #endregion
    }
}
