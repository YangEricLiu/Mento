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
    /// The business logic implement of UserTypePermission settings.
    /// </summary>
    public class UserTypePermissionSettings
    {
        internal UserTypePermissionSettings()
        {
        }

        private static Grid GridUserTypePermissionList = JazzGrid.UserTypePermissionList;

        private static Button ModifyButton = JazzButton.UserTypePermissionModifyButton;
        private static Button SaveButton = JazzButton.UserTypePermissionSaveButton;
        private static Button CancelButton = JazzButton.UserTypePermissionCancelButton;
        private static Button RefreshButton = JazzButton.UserTypePermissionRefreshButton;

        private static CheckBoxField CheckBoxFieldUserTypeCost = JazzCheckBox.CheckBoxFieldUserTypeCost;
        private static CheckBoxField CheckBoxFieldUserTypeEnergyUse = JazzCheckBox.CheckBoxFieldUserTypeEnergyUse;
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
        /// Navigate to UserTypePermission settings
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToUserTypePermissionSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UserManagementUserTypePermission);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
        }
        /// <summary>
        /// Click Modify button to modify user's permission
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickModifyButton()
        {
            ModifyButton.Click();
        }
        /// <summary>
        /// click "Refresh" button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickRefreshUserList()
        {
            RefreshButton.Click();
        }
        /// <summary>
        /// Click save button to save modify
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            SaveButton.Click();
        }
        /// <summary>
        /// Click cancel button to cancel modify
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCancelButton()
        {
            CancelButton.Click();
        }
        
        public void FocusOnUserType(string usertypeName)
        {
            GridUserTypePermissionList.FocusOnRow(1, usertypeName);
        }
        /// <summary>
        /// uncheck the energyuse permission 
        /// </summary>
        public void UserTypeEnergyUseUnCheck()
        {
            CheckBoxFieldUserTypeEnergyUse.Uncheck();
        }
        /// <summary>
        /// check the energyuse permission
        /// </summary>
        public void UserTypeEnergyUseCheck()
        {
            CheckBoxFieldUserTypeEnergyUse.Check();
        }
        /// <summary>
        /// uncheck the cost permission
        /// </summary>
        public void UserTypeCostUnCheck()
        {
            CheckBoxFieldUserTypeCost.Uncheck();
        }
        /// <summary>
        /// check the cost permission
        /// </summary>
        public void UserTypeCostCheck()
        {
            CheckBoxFieldUserTypeCost.Check();
        }
        /// <summary>
        /// judge wheather the user has or no a permission
        /// </summary>
        /// <returns></returns>
        public bool UserTypeEnergyUseIsChecked()
        {
            return CheckBoxFieldUserTypeEnergyUse.IsChecked();
        }
        
        public bool UserTypeCostIsChecked()
        {
            return CheckBoxFieldUserTypeCost.IsChecked();
        }

    }
}