using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Administration;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of User Data scope permission setting.
    /// </summary>
    public class UserDataScopePermission
    {
        internal UserDataScopePermission()
        {
        }

        #region controls
        private static Grid DataPermissonList = JazzGrid.DataPermissonList;

        private static Button ModifyButton = JazzButton.ModifyUserDataPermissionButton;
        private static Button SaveButton = JazzButton.SaveUserDataPermissionButton;
        private static Button CancelButton = JazzButton.CancelUserDataPermissionButton;
        private static Button CloseTreeViewButton = JazzButton.ClosePermissionTreeWindowButton;
        private static Button UserBasicPropertiesTab = JazzButton.TabButtonUserBasicProperties;
        private static Button UserDataPermissionTab = JazzButton.TabButtonUserDataPermission;
        private static Button TreeWindowSaveButton = JazzButton.TreeWindowSaveButton;
        private static Button TreeWindowCancelButton = JazzButton.TreeWindowCancelButton;
        private static TreeView UserDataPermissionTree = JazzTreeView.DataPermissionHierarchyTree;

        private static CheckBoxField SelectAllDataPermission = JazzCheckBox.UserSelectAllDataPermissionCheckBoxField;
        private static CheckBoxField CustomerName = JazzCheckBox.UserAllDataPermissionsCheckBoxField;

        private static HierarchyTree HierarchyTree
        {
            get;
            set;
        }

        #endregion

        #region common action
        /// <summary>
        /// Navigate to User setting
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToUserSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UserManagement);
        }

        /// <summary>
        /// Click save button to save new user
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            SaveButton.Click();
        }

        /// <summary>
        /// Click Modify button to cancel add user
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickModifyButton()
        {
            ModifyButton.Click();
        }

        /// <summary>
        /// Click cancel button to cancel add user
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCancelButton()
        {
            CancelButton.Click();
        }

        /// <summary>
        /// Check All Customer Data Permission 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void CheckAllCustomerDatas()
        {
            SelectAllDataPermission.Check("全部平台客户及对应数据权限");
        }

        /// <summary>
        /// Check Customer Name Data Permission 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void CheckAllCumstomerNames()
        {
            CustomerName.Check("客户名称");
        }

        /// <summary>
        /// Check Customer Name Data Permission 
        /// </summary>
        /// <param>Cumtomer name</param>
        /// <returns></returns>
        public void CheckCustomer(string customerName)
        {
            Boolean page = true;
            DataPermissonList.CheckDataPermissionRowCheckbox(4,customerName,page);
        }

        /// <summary>
        /// Click Edit Data Permission  scope  link button
        /// </summary>
        /// <param>Cumtomer name</param>
        /// <returns></returns>
        public void ClickEditDataPermission(string customerName)
        {
            Boolean page = true;
            DataPermissonList.ClickDataPermissionRow(4, customerName, page);
        }

        /// <summary>
        /// Check Whether the view and edit link button is enable 
        /// </summary>
        /// <param>Cumtomer name</param>
        /// <returns></returns>
        public Boolean IsEditDataPermissionEnable(string customerName)
        {
            Boolean page = true;
            return DataPermissonList.IsDataPermissionRowUnChecked(4,customerName,page);
        }

        /// <summary>
        /// Click Close hierarchy tree view button
        /// </summary>
        /// <returns></returns>
        public void CloseTreeWindow()
        {
            CloseTreeViewButton.Click();
        }

        /// <summary>
        /// Check  certain hierarchy node
        /// </summary>
        /// <returns></returns>
        public Boolean CheckHierarchyNode(string[] hierarchNodePaths)
        {
            try
            {
                TimeManager.LongPause();
                UserDataPermissionTree.ExpandNodePath(hierarchNodePaths);
                UserDataPermissionTree.CheckNode(hierarchNodePaths.Last());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Verify whether the node is checked
        /// </summary>
        /// <returns></returns>
        public Boolean IsHierarchyNodeChecked(string[] hierarchNodePaths)
        {
            UserDataPermissionTree.SelectNode(hierarchNodePaths);
            return UserDataPermissionTree.IsNodeChecked(hierarchNodePaths.Last());
        }

        /// <summary>
        /// Click tree window save button
        /// </summary>
        /// <returns></returns>
        public void SaveTreeWindow()
        {
            TreeWindowSaveButton.Click();
        }

        /// <summary>
        /// Click tree window  cancel button
        /// </summary>
        /// <returns></returns>
        public void CancelTreeWindow()
        {
            TreeWindowCancelButton.Click();
        }

        /// <summary>
        /// Switch to basic properties tab
        /// </summary>
        /// <returns></returns>
        public void SwitchToBasicPropertiesTab()
        {
            UserBasicPropertiesTab.Click();
        }

        /// <summary>
        /// Switch to  Data Permission  tab
        /// </summary>
        /// <returns></returns>
        public void SwitchToDataPermissionTab()
        {
            UserDataPermissionTab.Click();
        }

        #endregion

        #region get value

        #endregion

        #region verfication
        /// <summary>
        /// Verify whether the cancel button enable
        /// </summary>
        public Boolean IsCancelButtonEnable()
        {
            return CancelButton.IsEnabled();
        }

        /// <summary>
        /// Verify whether the save button enable
        /// </summary>
        public Boolean IsSaveButtonEnable()
        {
            return SaveButton.IsEnabled();
        }


        #endregion
    }
}