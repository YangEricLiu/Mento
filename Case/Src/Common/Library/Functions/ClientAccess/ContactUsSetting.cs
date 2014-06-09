using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class ContactUsSetting
    {
        internal ContactUsSetting()
        {
        }

        #region Controls
        public static Button ContactUsButton = JazzButton.ContactUsButton;
        public static Button ContactUsConfirmButton = JazzButton.ContactUsConfirmButton;
        public static Button ContactUsCancelButton = JazzButton.ContactUsCancelButton;
        public static Button ContactUsCloseButton = JazzButton.ContactUsCloseButton;

        private static TextField TextFieldContactUsName = JazzTextField.TextFieldContactUsName;
        private static TextField TextFieldContactUsTelephone = JazzTextField.TextFieldContactUsTelephone;
        private static TextField TextFieldContactUsCompany = JazzTextField.TextFieldContactUsCompany;
        private static TextField TextFieldContactUsTitle = JazzTextField.TextFieldContactUsTitle;
        private static TextField TextFieldContactUsDescriptionFields = JazzTextField.TextFieldContactUsDescriptionFields;
        #endregion

        #region Verify
        /// <summary>
        /// Check the ContactUs could be visiable. 
        /// </summary>
        /// <returns></returns>
        public bool ContactUsButtonIsVisiable()
        {
            return ContactUsButton.IsExisted();
        }

        /// <summary>
        /// Verify Is ContactUsName TextField  Displayed
        /// </summary>
        public string GetTextFieldContactUsNameInvalidMsg()
        {
            return TextFieldContactUsName.GetInvalidTips();
        }

        /// <summary>
        /// Verify Is ContactUsTelephone TextField  Displayed
        /// </summary>
        public string GetTextFieldContactUsTelephoneInvalidMsg()
        {
            return TextFieldContactUsTelephone.GetInvalidTips();
        } 
        
        /// <summary>
        /// Verify Is ContactUsCompany TextField  Displayed
        /// </summary>
        public string GetTextFieldContactUsCompanyInvalidMsg()
        {
            return TextFieldContactUsCompany.GetInvalidTips();
        }

        /// <summary>
        /// Verify Is TextFieldContactUsTitle  Displayed
        /// </summary>
        public string GetTextFieldContactUsTitleInvalidMsg()
        {
            return TextFieldContactUsTitle.GetInvalidTips();
        }

        /// <summary>
        /// Verify Is TextFieldContactUsDescriptionFields  Displayed
        /// </summary>
        public string GetTextFieldContactUsDescriptionFieldsInvalidMsg()
        {
            return TextFieldContactUsDescriptionFields.GetInvalidTips();
        }
        #endregion

        #region GetInvalidValue
        /// <summary>
        /// Get the message about ContactUsInvalidName
        /// </summary>
        /// <returns></returns>
        public string getContactUsInvalidNameMessage()
        {
            return TextFieldContactUsName.GetInvalidTips();
        }

        /// <summary>
        /// Get the message about ContactUsInvalidTelephone
        /// </summary>
        /// <returns></returns>
        public string getContactUsInvalidTelephoneMessage()
        {
            return TextFieldContactUsTelephone.GetInvalidTips();
        }

        /// <summary>
        /// Get the message about ContactUsInvalidCompany
        /// </summary>
        /// <returns></returns>
        public string getContactUsInvalidCompanyMessage()
        {
            return TextFieldContactUsCompany.GetInvalidTips();
        }       
        
        /// <summary>
        /// Get the message about ContactUsInvalidTitle
        /// </summary>
        /// <returns></returns>
        public string getContactUsInvalidTitleMessage()
        {
            return TextFieldContactUsTitle.GetInvalidTips();
        }      
        
        /// <summary>
        /// Get the message about ContactUsInvalidDescriptionFields
        /// </summary>
        /// <returns></returns>
        public string getContactUsInvalidDescriptionFieldsMessage()
        {
            return TextFieldContactUsDescriptionFields.GetInvalidTips();
        }
        #endregion

        #region FillInTextField
        /// <summary>
        /// Fillin ContactUsName in the TextFieldContactUsName. 
        /// </summary>
        /// <returns></returns>
        public void FillInContactUsNameInfo(string itemName)
        {
            TextFieldContactUsName.Fill(itemName);
        }

        /// <summary>
        /// Fillin ContactUsTelephone in the TextFieldContactUsTelephone. 
        /// </summary>
        /// <returns></returns>
        public void FillInContactUsTelephoneInfo(string itemName)
        {
            TextFieldContactUsTelephone.Fill(itemName);
        }

        /// <summary>
        /// Fillin ContactUsCompany in the TextFieldContactUsCompany. 
        /// </summary>
        /// <returns></returns>
        public void FillInContactUsCompanyInfo(string itemName)
        {
            TextFieldContactUsCompany.Fill(itemName);
        }

        /// <summary>
        /// Fillin ContactUsTitle in the TextFieldContactUsTitle. 
        /// </summary>
        /// <returns></returns>
        public void FillInContactUsTitleInfo(string itemName)
        {
            TextFieldContactUsTitle.Fill(itemName);
        }

        /// <summary>
        /// Fillin ContactUsDescriptionFields in the TextFieldContactUsDescriptionFields. 
        /// </summary>
        /// <returns></returns>
        public void FillInContactUsDescriptionFieldsInfo(string itemName)
        {
            TextFieldContactUsDescriptionFields.Fill(itemName);
        }
        #endregion
    }
}
