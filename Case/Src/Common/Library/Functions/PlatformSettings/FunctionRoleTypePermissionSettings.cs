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

        private static Grid UserRoleTypeList = JazzGrid.UserTypePermissionList;
        private static TextField NameTextField = JazzTextField.FunctionRoleTypeNameTextField;
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

        #endregion

        #region item operation
        /// <summary>
        /// Input name of the new user 
        /// </summary>
        /// <param name="name">user name</param>
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
        public Boolean IsUserNameInvalidMsgCorrect(string message)
        {
            return NameTextField.GetInvalidTips().Contains(message);
        }
        #endregion
    }
}