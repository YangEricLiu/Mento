using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class UserProfileDialog : Window
    {
        private static Locator Locator = new Locator("/div[@id='st-userprofile-personalinfo-window']", ByType.ID);
        private static Button ModifyButton = JazzButton.UserProfileModifyButton;
        private static Button SaveButton = JazzButton.UserProfileSaveButton;
        private static Button CancelButton = JazzButton.UserProfileCancelButton;
        private static Button CloseButton = JazzButton.UserProfileCloseButton;

        private static Label Title = UserProfileDialog.Title;

        private static TextField NameTextField = JazzTextField.UserProfileNameTextField;
        private static TextField RealNameTextField = JazzTextField.UserProfileRealNameTextField;
        private static TextField TelephoneTextField = JazzTextField.UserProfileTelephoneTextField;
        private static TextField EmailTextField = JazzTextField.UserProfileEmailTextField;
        private static TextField CommentTextField = JazzTextField.UserProfileCommentTextField;

        private static ComboBox UserProfileRoleTypeComboBox = JazzComboBox.UserProfileRoleTypeComboBox;
        private static ComboBox UserProfileTitleComboBox = JazzComboBox.UserProfileTitleComboBox;

        internal UserProfileDialog()
            : base(Locator)
        {
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
        /// Click close button to cancel add user
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCloseButton()
        {
            CloseButton.Click();
        }

        /// <summary>
        /// Click save button to cancel add user
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            SaveButton.Click();
        }

        /// <summary>
        /// Verify whether the Name field enable
        /// </summary>
        public Boolean IsNameTextFieldEnable()
        {
            return NameTextField.IsFieldEnabled();
        }

        /// <summary>
        /// Verify whether the RoleType combobox enable
        /// </summary>
        public Boolean IsRoleTypeComboboxEnable()
        {
            return UserProfileRoleTypeComboBox.IsComboBoxTextEnabled();
        }

        public Boolean IsCommentsInvalid()
        {
            return CommentTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of Comments field is correct
        /// </summary>
        /// <param name="output">ProfileExpectedData</param>
        /// <returns>whether the invalid message is true</returns>
        public Boolean IsCommentsInvalidMsgCorrect(string output)
        {
            return CommentTextField.GetInvalidTips().Contains(output);
        }

        public Boolean IsRealNameInvalid()
        {
            return RealNameTextField.IsTextFieldValueInvalid();
        }
        /// <summary>
        /// Judge whether invalid message of name field is correct
        /// </summary>
        /// <param name="output">ProfileExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsRealNameInvalidMsgCorrect(string output)
        {
            return RealNameTextField.GetInvalidTips().Contains(output);
        }

        public Boolean IsEmailInvalid()
        {
            return EmailTextField.IsTextFieldValueInvalid();
        }
        /// <summary>
        /// Judge whether invalid message of email field is correct
        /// </summary>
        /// <param name="output">ProfileExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsEmailInvalidMsgCorrect(string output)
        {
            return EmailTextField.GetInvalidTips().Contains(output);
        }

        public Boolean IsTelephoneInvalid()
        {
            return TelephoneTextField.IsTextFieldValueInvalid();
        }
        /// <summary>
        /// Judge whether invalid message of name field is correct
        /// </summary>
        /// <param name="output">ProfileExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsTelephoneInvalidMsgCorrect(string output)
        {
            return TelephoneTextField.GetInvalidTips().Contains(output);
        }

        /// <summary>
        /// Input realname comments etc. of all user field
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInUserProfile(UserProfileInputData input)
        {

            RealNameTextField.Fill(input.RealName);
            TelephoneTextField.Fill(input.Telephone);
            EmailTextField.Fill(input.Email);
            CommentTextField.Fill(input.Comments);
            UserProfileTitleComboBox.SelectItem(input.Title);

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
        /// Input Title of the new user 
        /// </summary>
        /// <param name="type">Title</param>
        /// <returns></returns>
        public void FillInType(string title)
        {
            UserProfileTitleComboBox.SelectItem(title);
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
            return UserProfileRoleTypeComboBox.GetValue();
        }

        /// <summary>
        /// Get the user Title expected value
        /// </summary>
        /// <param name = "Title">Title key</param>
        /// <returns>type value</returns>
        public string GetTitleValue()
        {
            return UserProfileTitleComboBox.GetValue();
        }

        /// <summary>
        /// Get the user RoleType expected value
        /// </summary>
        /// <param name = "Title">RoleType key</param>
        /// <returns>RoleType value</returns>
        public string GetRoleTypeValue()
        {
            return UserProfileRoleTypeComboBox.GetValue();
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
        /// Get the comment expected value
        /// </summary>
        /// <param>comment key</param>
        /// <returns>Comment value</returns>
        public string GetCommentValue()
        {
            return CommentTextField.GetValue();
        }

        /// <summary>
        /// Judge whether the textfield and its label are hidden
        /// </summary>
        /// <returns>True if it is hidden, false if not</returns>
        public Boolean IsCommentHidden()
        {
            return CommentTextField.IsTextFieldHidden();
        }

    }
}
