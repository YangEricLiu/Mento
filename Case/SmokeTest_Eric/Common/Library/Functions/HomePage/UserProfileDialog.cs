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
    public class UserProfileDialog : Window
    {
        private static Locator Locator = new Locator("/div[@id='st-userprofile-personalinfo-window']", ByType.ID);
        private static Button ModifyButton = JazzButton.UserProfileModifyButton;
        private static Button SaveButton = JazzButton.UserProfileSaveButton;
        private static Button CancelButton = UserProfileDialog.CancelButton;
        private static Button CloseButton = UserProfileDialog.CloseButton;

        private static Label Title = UserProfileDialog.Title;

        private static TextField NameTextField = JazzTextField.UserProfileNameTextField;
        private static TextField RealNameTextField = JazzTextField.UserProfileRealNameTextField;
        private static TextField TelephoneTextField = JazzTextField.UserProfileTelephoneTextField;
        private static TextField EmailTextField = JazzTextField.UserProfileEmailTextField;
        private static TextField TitleTextField = JazzTextField.UserProfileTitleTextField;
        private static TextField CommentTextField = JazzTextField.UserProfileCommentTextField;

        private static ComboBox UserTypeComboBox = JazzComboBox.UserProfileTypeComboBox;
        private static ComboBox UserAssociatedCustomerComboBox = JazzComboBox.UserProfileAssociatedCustomerComboBox;

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
            CloseButton.Click();
        }

        /// <summary>
        /// Input name, realname comments etc. of all user field
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInUserProfile(UserProfileInputData input)
        {

            RealNameTextField.Fill(input.RealName);
            TelephoneTextField.Fill(input.Telephone);
            EmailTextField.Fill(input.Email);
            TitleTextField.Fill(input.Title);
            CommentTextField.Fill(input.Comment);

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

        public string UserProfileTitle()
        {
            return GetTitle();

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

    }
}
