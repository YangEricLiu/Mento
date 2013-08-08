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
        private static Button UserBasicPropertiesTab = JazzButton.TabButtonUserBasicProperties;
        private static Button UserDataPermissionTab = JazzButton.TabButtonUserDataPermission;

        private static TreeView UserDataPermissionTree = JazzTreeView.DataPermissionHierarchyTree;

        private static CheckBoxField SelectAllDataPermission = JazzCheckBox.UserSelectAllDataPermissionCheckBoxField;
        private static CheckBoxField CustomerName = JazzCheckBox.UserAllDataPermissionsCheckBoxField;

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
        public void CheckCustomerName(string customerName)
        {
            Boolean page = true;
            DataPermissonList.CheckRowCheckbox(1,customerName,page);
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