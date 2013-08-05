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
using System.Collections;

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

        #region controls
        private static Grid GridUserList = JazzGrid.UserListGrid;

        private static Button CreateButton = JazzButton.UserCreateButton;
        private static Button RefreshButton = JazzButton.UserRefreshButton;

        private static Button ModifyButton = JazzButton.UserModifyButton;
        private static Button SaveButton = JazzButton.UserSaveButton;
        private static Button CancelButton = JazzButton.UserCancelButton;
        private static Button DeleteButton = JazzButton.UserDeleteButton;
        private static Button GeneratePasswordButton = JazzButton.UserGeneratePasswordButton;
        
        private static Button EmailSendButton = JazzButton.UserSendEmailButton;
        private static LinkButton ViewFunctionDetailLinkButton = JazzButton.LinkButtonUserViewFunctionDetail;

        private static TextField CommonNameTextField = JazzTextField.UserNameTextField;
        private static TextField NameTextField = JazzTextField.UserNameTextField;
        private static TextField RealNameTextField = JazzTextField.UserRealNameTextField;
        private static TextField TelephoneTextField = JazzTextField.UserTelephoneTextField;
        private static TextField EmailTextField = JazzTextField.UserEmailTextField;
        private static TextField TitleTextField = JazzTextField.UserTitleTextField;
        private static TextField CommentTextField = JazzTextField.UserCommentTextField;

        private static ComboBox UserTypeComboBox = JazzComboBox.UserTypeComboBox;
        private static ComboBox UserAssociatedCustomerComboBox = JazzComboBox.UserAssociatedCustomerComboBox;

        private static ComboBox UserTitleComboxBox = JazzComboBox.UserTitleComboxBox;

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
        /// focus a certain user
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean FocusOnUser(string userName)
        {
            try
            {
                GridUserList.FocusOnRow(1, userName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// verify whether the user exist the user list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsUserOnList(string userName)
        {
           return GridUserList.IsRowExistOnCurrentPage(1,userName);
        }

        /// <summary>
        /// After click save button, waiting for add successful message box pop up
        /// </summary>
        /// <returns></returns>
        public string GetMessageText()
        {
            return JazzMessageBox.MessageBox.GetMessage();
        }

        /// <summary>
        /// Confirm the add successful popup message box
        /// </summary>
        /// <returns></returns>
        public void ConfirmMagBox()
        {
            JazzMessageBox.MessageBox.Confirm();
        }
        #endregion

        #region item operation
        /// <summary>
        /// Input name, realname comments etc. of all user field
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInUser(UserInputData input)
        {

           NameTextField.Fill(input.AccountID);
            RealNameTextField.Fill(input.RealName);
           UserTypeComboBox.SelectItem(input.Type);
           UserAssociatedCustomerComboBox.SelectItem(input.AssociatedCustomer);
            CommonNameTextField.Fill(input.CommonName);
            RealNameTextField.Fill(input.RealName);
            TelephoneTextField.Fill(input.Telephone);
            EmailTextField.Fill(input.Email);
            TitleTextField.Fill(input.Title);
            CommentTextField.Fill(input.Comments);

        }

        /// <summary>
        /// Input name, realname comments etc. of all user field
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInAddUser(UserInputData input)
        {

            CommonNameTextField.Fill(input.AccountID);
            RealNameTextField.Fill(input.RealName);
            TelephoneTextField.Fill(input.Telephone);
            EmailTextField.Fill(input.Email);
            CommentTextField.Fill(input.Comments);
            UserTitleComboxBox.SelectItem(input.Title);
            UserTypeComboBox.SelectItem(input.Type);
        }

        /// <summary>
        /// Input name of the new user 
        /// </summary>
        /// <param name="name">user name</param>
        /// <returns></returns>
        public void FillInCommonName(string name)
        {
            CommonNameTextField.Fill(name);
        }

        /// <summary>
        /// Input name of the new user 
        /// </summary>
        /// <param name="name">user name</param>
        /// <returns></returns>
        public void FillInName(string name)
        {
            NameTextField.Fill(name);
        }

        /// <summary>
        /// verfiy the namefield disalbe to input
        /// </summary>
        /// <param name="name">user name</param>
        /// <returns></returns>
        public Boolean IsNameFieldEnable(string name)
        {
           return NameTextField.IsFieldEnabled();
        }

        /// <summary>
        /// Input real name of the new user 
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
        /// Input associatedcustomer of the new user 
        /// </summary>
        /// <param name="associatedcustomer">user associatedcustomer</param>
        /// <returns></returns>
        public void FillInAssociatedCustomer(string associatedcustomer)
        {
            UserAssociatedCustomerComboBox.SelectItem(associatedcustomer);
        }

        /// <summary>
        /// Input title of the new user 
        /// </summary>
        /// <param name="title">user title</param>
        /// <returns></returns>
        public Boolean FillInTitle(string title)
        {
            try 
            {
                UserTitleComboxBox.SelectItem(title);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// get all the title items
        /// </summary>
        /// <returns></returns>
        public Boolean AreTitleDisplayAllItem()
        {
            int i = 0;
            string[] expectedTitleList = { "能源工程顾问", "技术人员", "客户管理员", "平台管理员", "能源经理", "能源工程师", "部门经理", "管理层", "业务人员", "销售人员" };
            ArrayList titleList = UserTitleComboxBox.GetCurrentDropdownListItems();
            return titleList.Equals(expectedTitleList);
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
        #endregion

        #region get value
        /// <summary>
        /// Get name expected value
        /// </summary>
        /// <param name = "name">name key</param>
        /// <returns>Name value</returns>
        public string GetCommonNameValue()
        {
            return CommonNameTextField.GetValue();
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
        /// Get the user email expected value
        /// </summary>
        /// <param name></param>
        /// <returns>email value</returns>
        public string GetEmailValue()
        {
            return EmailTextField.GetValue();
        }

        /// <summary>
        /// Get the user telephone expected value
        /// </summary>
        /// <param name></param>
        /// <returns>telephone value</returns>
        public string GetTelephoneValue()
        {
            return TelephoneTextField.GetValue();
        }
       
        /// <summary>
        /// Get the user title expected value
        /// </summary>
        /// <param name></param>
        /// <returns>title value</returns>
        public string GetTitleValue()
        {
            //return TitleTextField.GetValue();
            return UserTitleComboxBox.GetValue();
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

        /// <summary>
        /// Click sendEmailButton
        /// </summary>
        /// <returns>True if it is hidden, false if not</returns>
        public void ClickEmailSendButton()
        {
            EmailSendButton.Click();
        }

        #endregion

        #region verification
        /// <summary>
        /// Judge whether the name textfield is invalid
        /// </summary>
        /// <returns>True if the name is invalid, false if not</returns>
        public Boolean IsCommonNameInvalid()
        {
            return CommonNameTextField.IsTextFieldValueInvalid();
        }
        
        /// <summary>
        /// Judge whether invalid message of name field is correct
        /// </summary>
        /// <param name="output">UserExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsCommonNameInvalidMsgCorrect(UserExpectedData output)
        {
            return NameTextField.GetInvalidTips().Contains(output.AccountID);
        }

        /// <summary>
        /// Judge whether the  delete button is enabled
        /// </summary>
        /// <returns>True if the button is invalid, false if not</returns>
        public Boolean IsDeleteButtonEnabled()
        {
            return DeleteButton.IsEnabled();
        }

        /// <summary>
        /// Judge whether the  delete button is display
        /// </summary>
        /// <returns>True if the button is invalid, false if not</returns>
        public Boolean IsDeleteButtonDisplay()
        {
            return DeleteButton.IsDisplayed();
        }

        /// <summary>
        /// Judge whether the realname textfield is invalid
        /// </summary>
        /// <returns>True if the realname is invalid, false if not</returns>
        public Boolean IsRealNameInvalid()
        {
            return RealNameTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of realname field is correct
        /// </summary>
        /// <param name="output">UserExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsRealNameInvalidMsgCorrect(UserExpectedData output)
        {
            return RealNameTextField.GetInvalidTips().Contains(output.RealName);
        }

        /// <summary>
        /// Judge whether the telephone textfield is invalid
        /// </summary>
        /// <returns>True if the telehone is invalid, false if not</returns>
        public Boolean IsTelephoneInvalid()
        {
            return TelephoneTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of telephone field is correct
        /// </summary>
        /// <param name="output">UserExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsTelephoneInvalidMsgCorrect(UserExpectedData output)
        {
            return TelephoneTextField.GetInvalidTips().Contains(output.Telephone);
        }

        /// <summary>
        /// Judge whether the email textfield is invalid
        /// </summary>
        /// <returns>True if the email is invalid, false if not</returns>
        public Boolean IsEmailInvalid(UserExpectedData output)
        {
            return EmailTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of email field is correct
        /// </summary>
        /// <param name="output">UserExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsEmailInvalidMsgCorrect(UserExpectedData output)
        {
            string error = TelephoneTextField.GetInvalidTips();
            return EmailTextField.GetInvalidTips().Contains(output.Email);
        }

        public string EmailInvalidMsg()
        {
            return EmailTextField.GetInvalidTips();
        }

        /// <summary>
        /// Judge whether the usertype combobox is invalid
        /// </summary>
        /// <returns>True if the usertype is invalid, false if not</returns>
        public Boolean IsUserTypeInvalid()
        {
            return UserTypeComboBox.IsComboBoxValueInvalid();
        }
       
        /// <summary>
        /// Judge whether invalid message of type field is correct
        /// </summary>
        /// <param name="output">UserExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsTypeInvalidMsgCorrect(UserExpectedData output)
        {
            if (String.IsNullOrEmpty(output.Type))
            {
                return true;
            }
            else
            {
                return UserTypeComboBox.GetInvalidTips().Contains(output.Type);
            }
        }


        /// <summary>
        /// Judge whether the user title combobox is invalid
        /// </summary>
        /// <returns>True if the user title combobox  is invalid, false if not</returns>
        public Boolean IsUserTitleInvalid()
        {
            return UserTitleComboxBox.IsComboBoxValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of user title combox is correct
        /// </summary>
        /// <param name="output">UserExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsTitleInvalidMsgCorrect(UserExpectedData output)
        {
            if (String.IsNullOrEmpty(output.Title))
            {
                return true;
            }
            else
            {
                return UserTitleComboxBox.GetInvalidTips().Contains(output.Title);
            }
        }

        /// <summary>
        /// Judge whether the Comments textfield is invalid
        /// </summary>
        /// <returns>True if the Comments is invalid, false if not</returns>
        public Boolean IsCommentsInvalid(UserExpectedData output)
        {
            if (String.IsNullOrEmpty(output.Comments))
            {
                return true;
            }
            else
            {
                return CommentTextField.IsTextFieldValueInvalid();
            }
        }

        /// <summary>
        /// Judge whether invalid message of Comments field is correct
        /// </summary>
        /// <param name="output">UserExpectedData</param>
        /// <returns>whether the invalid message is true</returns>
        public Boolean IsCommentsInvalidMsgCorrect(UserExpectedData output)
        {
            /*if (String.IsNullOrEmpty(output.Comments))
            {
                return true;
            }
            else
            {*/
            return CommentTextField.GetInvalidTips().Contains(output.Comments);
        }

        /// <summary>
        /// Judge whether the textfield and its label are hidden
        /// </summary>
        /// <returns>True if it is hidden, false if not</returns>
        public Boolean IsUserCommentHidden()
        {
            return CommentTextField.IsTextFieldHidden();
        }

        /// <summary>
        /// Judge whether the sendEmailButton is enabled
        /// </summary>
        /// <returns>True if it is hidden, false if not</returns>
        public Boolean IsEmailSendButtonEnabled()
        {

            return EmailSendButton.IsEnabled();
        }

        /// <summary>
        /// Judge whether the sendEmailButton is displayed
        /// </summary>
        /// <returns>True if it is hidden, false if not</returns>
        public Boolean IsEmailSendButtonDispalyed()
        {

            return EmailSendButton.IsDisplayed();
        }

        /// <summary>
        /// Judge whether the view function permission is enabled
        /// </summary>
        /// <returns>True if it is enable, false if not</returns>
        public Boolean IsViewFunctionPermissionEnabled()
        {
            return ViewFunctionDetailLinkButton.IsEnabled();
        }

        /// <summary>
        /// Judge whether the view function permission is displayed
        /// </summary>
        /// <returns>True if it is display, false if not</returns>
        public Boolean IsViewFunctionPermissionDispalyed()
        {
            return ViewFunctionDetailLinkButton.IsDisplayed();
        }

        /// <summary>
        /// Click View function permission link button
        /// </summary>
        public void ClickViewFunctionPermissionLinkButton()
        {
            ViewFunctionDetailLinkButton.ClickLink();
        }
        /*
        /// <summary>
        /// Verify the permissions are same as permissionName
        /// </summary>
        public void VerifyPermission()
        {
            ViewFunctionDetailLinkButton.ClickLink();
        }
        */
        #endregion
    }
}