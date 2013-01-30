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
    public class UserPasswordDialog : Window
    {
        private static Locator Locator = new Locator("/div[@id='st-userprofile-personalinfo-window']", ByType.ID);

        private static TextField OriginalPasswordTextField = JazzTextField.UserOriginalPasswordTextField;
        private static TextField NewPasswordTestField = JazzTextField.UserNewPasswordTextField;
        private static TextField ConfirmPasswordTextField = JazzTextField.UserConfirmPasswordTextField;

        private static ComboBox UserTypeComboBox = JazzComboBox.UserProfileTypeComboBox;
        private static ComboBox UserAssociatedCustomerComboBox = JazzComboBox.UserProfileAssociatedCustomerComboBox;

        internal UserPasswordDialog()
            : base(Locator)
        {
        }
        public void ClickCancelButton()
        {
            Cancel();
        }

        /// <summary>
        /// Click close button to cancel add user
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCloseButton()
        {
            Close();
        }

        /// <summary>
        /// Click save button to cancel add user
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            Confirm();
        }

        /// <summary>
        /// Input name, realname comments etc. of all user field
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInUserPassword(PasswordInputData input)
        {

            OriginalPasswordTextField.Fill(input.OriginalPassword);
            NewPasswordTestField.Fill(input.NewPassword);
            ConfirmPasswordTextField.Fill(input.ConfirmPassword);

        }

        /// <summary>
        /// Input originalpassword of the user 
        /// </summary>
        /// <param name="originalpassword">originalpassword</param>
        /// <returns></returns>
        public void FillInOriginalPassword(string originalpassword)
        {
            OriginalPasswordTextField.Fill(originalpassword);
        }

        /// <summary>
        /// Input newpassword of the user 
        /// </summary>
        /// <param name="newpassword">newpassword</param>
        /// <returns></returns>
        public void FillInNewPassword(string newpassword)
        {
            NewPasswordTestField.Fill(newpassword);
        }

        /// <summary>
        /// Input confirmpassword of the user 
        /// </summary>
        /// <param name="confirmpassword">confirmpassword</param>
        /// <returns></returns>
        public void FillInConfirmPassword(string confirmpassword)
        {
            ConfirmPasswordTextField.Fill(confirmpassword);
        }
    }
}
