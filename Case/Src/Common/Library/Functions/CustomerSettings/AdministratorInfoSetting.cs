using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class AdministratorInfoSetting
    {
        internal AdministratorInfoSetting()
        {
        }

        #region Controls
        private static TabButton AdministratorInfoPropertyTab = JazzButton.AdministratorInfoPropertyTabButton;
        private static Button AdministratorInfoCreate = JazzButton.AdministratorInfoCreateButton;
        private static Button AdministratorInfoAppend = JazzButton.AdministratorInfoAppendButton; 
        private static Button AdministratorInfoUpdate = JazzButton.AdministratorInfoUpdateButton;
        private static Button AdministratorInfoSave = JazzButton.AdministratorInfoSaveButton;
        private static Button AdministratorInfoCancel = JazzButton.AdministratorInfoCancelButton; 
        private static TextField TotalAreaValue = JazzTextField.TotalAreaValueTextField;
        private static TextField HeatingAreaValue = JazzTextField.HeatingAreaValueTextField;
        private static TextField CoolingAreaValue = JazzTextField.CoolingAreaValueTextField;
        private static TextField PeopleNumber = JazzTextField.PeopleNumberTextField;

        private static Button PeopleCreate = JazzButton.PeopleCreateButton;
        private static MonthPicker PeopleEffectiveDate = JazzMonthPicker.PeopleEffectiveDateMonthPicker;
        private static Container PeopleItems = JazzContainer.PeopleItemsContainer;
        private static Label AreaPropertyTitle = JazzLabel.AreaPropertyTitleLabel;
        private static Container PeopleErrorTips = JazzContainer.PeopleErrorTipsContainer;
        #endregion

        #region Administrator Info

        public void ClickAdministratorInfoTab()
        {
            AdministratorInfoPropertyTab.Click();
        }

        public bool IsAdministratorInfoTabEnable()
        {
            return AdministratorInfoPropertyTab.IsEnabled();
        }

        public bool IsAdministratorInfoCreateButtonDisplayed()
        {
            return AdministratorInfoCreate.IsDisplayed();
        }

        public void ClickAdministratorInfoCreateButton()
        {
            if (AdministratorInfoCreate.IsDisplayed())
            {
                AdministratorInfoCreate.Click();
            }
            else if (AdministratorInfoUpdate.IsDisplayed())
            {
                AdministratorInfoUpdate.Click();
            }
        }

        public bool IsAdministratorInfoCreateModifyButtonDisplayed()
        {
            return AdministratorInfoCreate.IsDisplayed() || AdministratorInfoUpdate.IsDisplayed();
        }

        public void ClickAdministratorInfoSaveButton()
        {
            AdministratorInfoSave.Click();
            JazzMessageBox.LoadingMask.WaitLoading(maxtime: 2);
        }

        public bool IsAdministratorInfoSaveButtonDisplayed()
        {
            return AdministratorInfoSave.IsDisplayed();
        }

        public void ClickAdministratorInfoCancelButton()
        {
            AdministratorInfoCancel.Click();
        }

        public bool IsAdministratorInfoCancelButtonDisplayed()
        {
            return AdministratorInfoCancel.IsDisplayed();
        }

        #endregion

        #region Operation

        public void ClickAdministratorInfoAppendButton()
        {
            AdministratorInfoAppend.Click();
        }

        public void ClickDeleteAdministratorInfoButton(int position)
        {
            Button deletePeopleItemN = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonAdministratorInfoDelete, position);

            deletePeopleItemN.Click();
        }

        public void FillInAdministratorInfo_N(AdministratorInfoInputData input, int positionIndex)
        {
            FillInRealName_N(input.RealName, positionIndex);
            FillInPosition_N(input.Position, positionIndex);
            FillInMobile_N(input.Mobile, positionIndex);
            FillInTelephone_N(input.Telephone, positionIndex);
            FillInEmail_N(input.Email, positionIndex);
        }


        public void FillInRealName_N(string realName, int positionIndex)
        {
            TextField realNameItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoRealName, positionIndex);
            realNameItemN.Fill(realName);
        }

        public string GetRealNameValue_N(int positionIndex)
        {
            TextField realNameItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoRealName, positionIndex);
            return realNameItemN.GetValue();
        }

        public bool IsRealNameInvalid_N(int positionIndex)
        {
            TextField realNameItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoRealName, positionIndex);
            return realNameItemN.IsTextFieldValueInvalid();
        }

        public string GetRealNameInvalidMsg_N(int positionIndex)
        {
            TextField realNameItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoRealName, positionIndex);
            return realNameItemN.GetInvalidTips();
        }

        public void FillInPosition_N(string position, int positionIndex)
        {
            TextField positionItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoPosition, positionIndex);
            positionItemN.Fill(position);
        }

        public string GetPositionValue_N(int positionIndex)
        {
            TextField positionItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoPosition, positionIndex);
            return positionItemN.GetValue();
        }

        public bool IsPositionInvalid_N(int positionIndex)
        {
            TextField positionItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoPosition, positionIndex);
            return positionItemN.IsTextFieldValueInvalid();
        }

        public string GetPositionInvalidMsg_N(int positionIndex)
        {
            TextField positionItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoPosition, positionIndex);
            return positionItemN.GetInvalidTips();
        }

        public void FillInMobile_N(string mobile, int positionIndex)
        {
            TextField mobileItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoMobile, positionIndex);
            mobileItemN.Fill(mobile);
        }

        public string GetMobileValue_N(int positionIndex)
        {
            TextField mobileItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoMobile, positionIndex);
            return mobileItemN.GetValue();
        }

        public bool IsMobileInvalid_N(int positionIndex)
        {
            TextField mobileItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoMobile, positionIndex);
            return mobileItemN.IsTextFieldValueInvalid();
        }

        public bool IsMobileHidden_N(int positionIndex)
        {
            TextField mobileItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoMobile, positionIndex);
            return mobileItemN.IsTextFieldHidden();
        }

        public string GetMobileInvalidMsg_N(int positionIndex)
        {
            TextField mobileItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoMobile, positionIndex);
            return mobileItemN.GetInvalidTips();
        }

        public void FillInTelephone_N(string telephone, int positionIndex)
        {
            TextField telephoneItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoTelephone, positionIndex);
            telephoneItemN.Fill(telephone);
        }

        public string GetTelephoneValue_N(int positionIndex)
        {
            TextField telephoneItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoTelephone, positionIndex);
            return telephoneItemN.GetValue();
        }

        public bool IsTelephoneInvalid_N(int positionIndex)
        {
            TextField telephoneItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoTelephone, positionIndex);
            return telephoneItemN.IsTextFieldValueInvalid();
        }

        public bool IsTelephoneHidden_N(int positionIndex)
        {
            TextField telephoneItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoTelephone, positionIndex);
            return telephoneItemN.IsTextFieldHidden();
        }

        public string GetTelephoneInvalidMsg_N(int positionIndex)
        {
            TextField telephoneItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoTelephone, positionIndex);
            return telephoneItemN.GetInvalidTips();
        }

        public void FillInEmail_N(string email, int positionIndex)
        {
            TextField emailItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoEmail, positionIndex);
            emailItemN.Fill(email);
        }

        public string GetEmailValue_N(int positionIndex)
        {
            TextField emailItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoEmail, positionIndex);
            return emailItemN.GetValue();
        }

        public bool IsEmailInvalid_N(int positionIndex)
        {
            TextField emailItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoEmail, positionIndex);
            return emailItemN.IsTextFieldValueInvalid();
        }

        public string GetEmailInvalidMsg_N(int positionIndex)
        {
            TextField emailItemN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldAdministratorInfoEmail, positionIndex);
            return emailItemN.GetInvalidTips();
        }

        #endregion
    }
}
