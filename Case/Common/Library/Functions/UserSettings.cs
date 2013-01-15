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
    public class UserSettings
    {
        internal UserSettings()
        {
        }

        private static Grid GridUserList = JazzGrid.UserListGrid;

        private static Button CreateButton = JazzButton.UserCreateButton;
        private static Button RefreshButton = JazzButton.UserRefreshButton;

        private static Button ModifyButton = JazzButton.UserModifyButton;
        private static Button SaveButton = JazzButton.UserSaveButton;
        private static Button CancelButton = JazzButton.UserCancelButton;
        private static Button DeleteButton = JazzButton.UserDeleteButton;
        private static Button GeneratePasswordButton = JazzButton.UserGeneratePasswordButton;


        private static TextField NameTextField = JazzTextField.UserNameTextField;
        private static TextField RealNameTextField = JazzTextField.UserRealNameTextField;
        private static TextField TelephoneTextField = JazzTextField.UserTelephoneTextField;
        private static TextField EmailTextField = JazzTextField.UserEmailTextField;
        private static TextField TitleTextField = JazzTextField.UserTitleTextField;
        private static TextField CommentTextField = JazzTextField.UserCommentTextField;

        private static ComboBox UserTypeComboBox = JazzComboBox.UserTypeComboBox;
        private static ComboBox UserAssociatedCustomerComboBox = JazzComboBox.UserAssociatedCustomerComboBox;

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
        /// click "add user" button
        /// </summary>
        /// <param>Add user button</param>
        /// <returns></returns>
        public void ClickAddUser()
        {
            CreateButton.Click();
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
        /// click "Delete" button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void DeleteUser()
        {
            DeleteButton.Click();
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
        /// Click Generate password button to reset password for user
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickGeneratePasswordButton()
        {
            GeneratePasswordButton.Click();
        }

        /// <summary>
        /// Input name, realname comments etc. of all user field
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInUser(UserInputData input)
        {

            NameTextField.Fill(input.Name);
            RealNameTextField.Fill(input.RealName);
            UserTypeComboBox.SelectItem(input.Type);
            UserAssociatedCustomerComboBox.SelectItem(input.AssociatedCustomer); 
            TelephoneTextField.Fill(input.Telephone);
            EmailTextField.Fill(input.Email);
            TitleTextField.Fill(input.Title);
            CommentTextField.Fill(input.Comment);            

        }

        /// <summary>
        /// Input name of the new user 
        /// </summary>
        /// <param name="name">user name</param>
        /// <returns></returns>
        public void FillInName(string name)
        {
            //textFieldInstance.FillIn(ElementKey.HierarchyName, name);
            NameTextField.Fill(name);
        }

        /// <summary>
        /// Input realname of the new user 
        /// </summary>
        /// <param name="realname">user realname</param>
        /// <returns></returns>
        public void FillInRealName(string realname)
        {
            RealNameTextField.Fill(realname);
        }

        /// <summary>
        /// Input type of the new user 
        /// </summary>
        /// <param name="type">user type</param>
        /// <returns></returns>
        public void FillInType(string type)
        {
            UserTypeComboBox.SelectItem(type);
        }

        /// <summary>
        /// Input title of the new user 
        /// </summary>
        /// <param name="title">user title</param>
        /// <returns></returns>
        public void FillInTitle(string title)
        {
            TitleTextField.Fill(title);
        }
        
        /// <summary>
        /// Input telephone of the new user 
        /// </summary>
        /// <param name="telephone">user telephone</param>
        /// <returns></returns>
        public void FillInTelephone(string telephone)
        {
            TelephoneTextField.Fill(telephone);
        }

        /// <summary>
        /// Input  of the new user 
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns></returns>
        public void FillInEmail(string email)
        {
            EmailTextField.Fill(email);
        }

        /// <summary>
        /// Input comment of the new user 
        /// </summary>
        /// <param name="comment">user comment</param>
        /// <returns></returns>
        public void FillInComment(string comment)
        {
            CommentTextField.Fill(comment);
        }

        /// <summary>
        /// After click save button, waiting for add successful message box pop up
        /// </summary>
        /// <param name="timeout">Waiting time</param>
        /// <returns></returns>
        public void WaitForCreateOKDisplay(int timeout)
        {
            JazzMessageBox.MessageBox.WaitMeAppear();
        }

        public void ConfirmCreateOKMagBox()
        {
            JazzMessageBox.MessageBox.OK();
        }

        /// <summary>
        /// Get name expected value
        /// </summary>
        /// <param name = "name">name key</param>
        /// <returns>Name value</returns>
        public string GetNameValue()
        {
            return NameTextField.GetValue();
        }

        /// <summary>
        /// Get the realname expected value
        /// </summary>
        /// <param>realname key</param>
        /// <returns>realname value</returns>
        public string GetRealNameValue()
        {
            return RealNameTextField.GetValue();
        }

        /// <summary>
        /// Get the user type expected value
        /// </summary>
        /// <param name = "type">type key</param>
        /// <returns>type value</returns>
        public string GetTypeValue()
        {
            return UserTypeComboBox.GetValue();
        }

        /// <summary>
        /// Get the user associatedcustomer expected value
        /// </summary>
        /// <param name = "associatedcustomer">associatedcustomer key</param>
        /// <returns>type value</returns>
        public string GetAssociatedCustomerValue()
        {
            return UserAssociatedCustomerComboBox.GetValue();
        }

        /// <summary>
        /// Get the user title expected value
        /// </summary>
        /// <param name></param>
        /// <returns>type value</returns>
        public string GetTitleValue()
        {
            return TitleTextField.GetValue();
        }

        /// <summary>
        /// Get the comment expected value
        /// </summary>
        /// <param>comment key</param>
        /// <returns>Comment value</returns>
        public string GetCommentValue()
        {
            //return comboBoxInstance.GetValue(ElementKey.HierarchyComment);
            return CommentTextField.GetValue();
        } 

        public void FocusOnUser(string userName)
        {
            GridUserList.FocusOnRow(1, userName);    
        }
    }
}
