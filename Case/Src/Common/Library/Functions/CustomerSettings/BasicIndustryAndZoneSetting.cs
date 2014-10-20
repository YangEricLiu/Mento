using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.ScriptCommon.TestData.Administration;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using System.Collections;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of customer management.
    /// </summary>
    public class BasicIndustryAndZoneSetting
    {
        internal BasicIndustryAndZoneSetting()
        {

        }

        #region Controls

        private static HierarchyTree HierarchyTree = JazzTreeView.HierarchySettingsHierarchyTree;
        private static Button ModifyButton = JazzButton.HierarchySettingsModifyButton;
        private static Button CancelButton = JazzButton.HierarchySettingsCancelButton;

        private static ComboBox HierarchyIndustryIdComboBox = JazzComboBox.HierarchyIndustryIdComboBox;
        private static ComboBox HierarchyZoneIdComboBox = JazzComboBox.HierarchyZoneIdComboBox;


        #endregion

        #region Common
        /// <summary>
        /// Navigate to hierarchy setting
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToHierarchySetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettings);
        }

        /// <summary>
        /// Click one hierarchy node, and return true if successful 
        /// </summary>
        /// <param name="treeNodePath">Hierarchy node name</param>
        /// <returns></returns>
        public Boolean SelectHierarchyNodePath(string[] treeNodePath)
        {
            try
            {
                HierarchyTree.SelectNode(treeNodePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Click modify button to add new hierarchy node
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickModifyButton()
        {
            ModifyButton.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
        }
        /// <summary>
        /// Click cancel button to cancel add new hierarchy node
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCancelButton()
        {
            CancelButton.Click();
        }
        /// <summary>
        /// Return industry ComboBox value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public ArrayList GetIndustryIdComboBoxList()
        {
            return HierarchyIndustryIdComboBox.GetCurrentDropdownListItems();
        }
        /// <summary>
        /// Return zone ComboBox value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public ArrayList GetZoneIdComboBoxList()
        {
            return HierarchyZoneIdComboBox.GetCurrentDropdownListItems();
        }
        #endregion
    }
}
