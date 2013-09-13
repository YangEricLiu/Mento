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
    /// The business logic implement of User setting.
    /// </summary>
    public class FunctionRoleTypePermissionSettings
    {
        internal FunctionRoleTypePermissionSettings()
        {
        }

        #region controls
        private static Button CreatFunctionRoleType = JazzButton.CreatFunctionRoleType;
        private static Button SaveFunctionRoleType = JazzButton.SaveFunctionRoleType;
        private static Button ModifyFunctionRoleType = JazzButton.ModifyFunctionRoleType;
        private static Button DeleteFunctionRoleType = JazzButton.DeleteFunctionRoleType;
        private static Button CancelFunctionRoleType = JazzButton.CancelFunctionRoleType;

        private static Grid UserRoleTypeGrid = JazzGrid.UserTypePermissionList;
        private static TextField NameTextField = JazzTextField.FunctionRoleTypeNameTextField;
        private static CheckBoxField FunctionPermissionItem = JazzCheckBox.UserTypePermissionCheckBoxField;

        private static Container ContainerPermissionCustomerizeItems = JazzContainer.ContainerPermissionCustomerizeItems;
        private static Container ContainerPermissionPublicTypeItems = JazzContainer.ContainerPermissionPublicTypeItems;

        #endregion

        #region common action
        /// <summary>
        /// Navigate to Function Role Type Permission Setting
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToFunctionPermissionSettings()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UserManagementUserTypePermission);
        }
        
        /// <summary>
        /// click "add Function role type" button
        /// </summary>
        /// <param>Add Function role type button</param>
        /// <returns></returns>
        public void ClickAddFunctionRoleType()
        {
            CreatFunctionRoleType.Click();
        }


        /// <summary>
        /// click "Delete" button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickDeleteButton()
        {
            DeleteFunctionRoleType.Click();
        }


        /// <summary>
        /// Click save button to save new funtion role type
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            SaveFunctionRoleType.Click();
        }

        /// <summary>
        /// Click Modify button to modify a function role type
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickModifyButton()
        {
            ModifyFunctionRoleType.Click();
        }

        /// <summary>
        /// Click cancel button to cancel add user
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCancelButton()
        {
            CancelFunctionRoleType.Click();
        }
        /// <summary>
        /// Focus a user type
        /// </summary>
        /// <param "name"="name">role type name</param>
        /// <returns></returns>
        public void FocusOnUserType(string roletypeName)
        {
            UserRoleTypeGrid.FocusOnRow(1, roletypeName, false);
        }

        /// <summary>
        /// Verified whether the role type is existed  
        /// </summary>
        /// <param "name"="name">role type name</param>
        /// <returns></returns>
        public Boolean IsRoleTypeOnListByName(string roletypeName)
        {
                return UserRoleTypeGrid.IsRowExist(1, roletypeName);
        }

        /*
        public void GetRoleTypeOnListByName(string roletypeName)
        {
            UserRoleTypeGrid.GetRow(1, roletypeName);
        }
        */
        /// <summary>
        /// Check a certain function permission item
        /// </summary>
        /// <param "name"="name">permission name</param>
        /// <returns></returns>
        public void Check(string permission)
        {
            FunctionPermissionItem.Check(permission);
        }

        /// <summary>
        /// UnCheck a certain function permission item
        /// </summary>
        /// <param "name"="name">permission name</param>
        /// <returns></returns>
        public void UnCheck(string permission)
        {
            FunctionPermissionItem.Uncheck(permission);
        }

        /*
        /// <summary>
        /// Check a certain function permission item checked
        /// </summary>
        /// <param "name"="name">permission name</param>
        /// <returns></returns>
        public Boolean IsItemCheck(string permission)
        {
            try
            {
                FunctionPermissionItem.IsChecked(permission);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }
        */
        #endregion

        #region item operation
        /// <summary>
        /// Input name of the new user 
        /// </summary>
        /// <param name="name">role type name</param>
        /// <returns></returns>
        public void FillInName(string name)
        {
            NameTextField.Fill(name);
        }
        #endregion

        #region get value
        /// <summary>
        /// Get name expected value
        /// </summary>
        /// <param name = "name">name key</param>
        /// <returns>Name value</returns>
        public string GetNameValue()
        {
            return NameTextField.GetValue();
        }
        #endregion

        #region verification
        /// <summary>
        /// Judge whether the name textfield is invalid
        /// </summary>
        /// <returns>True if the name is invalid, false if not</returns>
        public Boolean IsUserNameInvalid()
        {
            return NameTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of name field is correct
        /// </summary>
        /// <param name="output">string ErrorMessage</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsUserNameInvalidMsgCorrect(RoleTypeExpectedData output)
        {
            return NameTextField.GetInvalidTips().Contains(output.CommonName);
        }
        /*
        /// <summary>
        /// Judge whether invalid message of name field is correct
        /// </summary>
        /// <param name="output">string ErrorMessage</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsPermissionItemChecked(string permissionItem)
        {
            return NotHiddenPermissionItem.GetContainerTexts().Contains(permissionItem);
        }
        */
        /// <summary>
        /// Judge whether permission item is checked
        /// </summary>
        /// <param name="output">string permission role type item name</param>
        /// <returns>whether the permission item is checked</returns>
        public Boolean IsPublicPermissionItemChecked(string permissionItem)
        {
            return ContainerPermissionPublicTypeItems.GetContainerTexts().Contains(permissionItem);
        }

        /// <summary>
        /// Judge whether public permission items are checked
        /// </summary>
        public Boolean ArePublicPermissionItemsChecked()
        {
            int i = 0;
            Boolean flag = true;
            string[] publicPermissions = { "仪表盘与小组件查看", "仪表盘与小组件编辑", "个人信息管理", "地图信息查看" };
            while (i < publicPermissions.Length && flag)
            {
                flag= ContainerPermissionPublicTypeItems.GetContainerTexts().Contains(publicPermissions[i]);
                i++;
            }
            return flag;
        }

        /// <summary>
        /// Judge whether permission item is checked
        /// </summary>
        /// <param name="output">string permission role type item name</param>
        /// <returns>whether the permission item is checked</returns>
        public Boolean IsCustomerizePermissionItemChecked(string permissionItem)
        {
            //return ContainerPermissionNotHiddenItems.IsContainerTextsExisted(permissionItem[i]);
            return ContainerPermissionCustomerizeItems.GetContainerTexts().Contains(permissionItem);
        }

        /// <summary>
        /// Judge whether permission item is checkable
        /// </summary>
        /// <param name="output">string permission role type item name</param>
        /// <returns>whether the permission item is enable</returns>
        public Boolean IsPermissionItemDisabled(string permissionItem)
        {
            return JazzCheckBox.UserTypePermissionCheckBoxField.IsDisabled(permissionItem);
        }
        
        #endregion
    }
}