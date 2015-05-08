using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.ScriptCommon.TestData.Administration;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of customer management.
    /// </summary>
    public class CustomerManagement
    {
        internal CustomerManagement()
        {

        }

        #region Controls
        private static Button AddCustomer = JazzButton.AddCustomerButton;
        private static Button UploadLogoButton = JazzButton.UploadLogoButton;
        private static Button SaveCustomer = JazzButton.SaveCustomerButton;
        private static Button SaveCustomerMapProperty = JazzButton.SaveCustomerMapPropertyButton;
        private static Button CancelCustomerMapProperty = JazzButton.CancelCustomerMapPropertyButton;
        private static Button ModifyCustomerMapProperty = JazzButton.ModifyCustomerMapPropertyButton;
        private static Button CancelCustomer = JazzButton.CancelCustomerButton;
        private static Button DeleteCustomer = JazzButton.DeleteCustomerButton;
        private static Button UpdateCustomer = JazzButton.UpdateCustomerButton;
        private static Grid CustomersList = JazzGrid.CustomerList;

        private static TabButton MapPagePropertyTab = JazzButton.MapPagePropertyTabButton;
        private static TabButton BasicPropertyTab = JazzButton.BasicPropertyTabButton;

        private static TextField CustomerName = JazzTextField.CustomerNameTextField;
        private static TextField CustomerCode = JazzTextField.CustomercodeTextField;
        private static TextField CustomerAddress = JazzTextField.CustomerAddressTextField;
        private static TextField CustomerResponsiblePerson = JazzTextField.CustomerResponsiblePersonTextField;
        private static TextField CustomerTelephone = JazzTextField.CustomerTelephoneTextField;
        private static TextField CustomerEmail = JazzTextField.CustomerEmailTextField;
        private static TextField CustomerComment = JazzTextField.CustomerCommentTextField;
        private static DatePicker CustomerOperationTime = JazzDatePicker.OperationTimeDatePicker;
        private static TextField UploadLogoTextField = JazzTextField.UploadLogoTextField;
        private static Container CustomerAdminContainer = JazzContainer.ContainerCustomerAdmin;

        private static Grid CustomerList = JazzGrid.CustomerList;

        private static CheckBoxField CustomerMapInfoCheckBoxField = JazzCheckBox.CustomerMapPropertyCheckBoxField;

        private static Container CustomerMapInfoContainer = JazzContainer.ContainerCustomerMapInfo;

        private static Label CustomerMapInfoLabel = JazzLabel.PlatformCustomerMapInfoLabel;

        #endregion

        #region Common

        /// <summary>
        /// Navigate to Time setting
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToTimeSettings()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettings);
        }

        public void NavigateToCustomerSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CustomerManagementCustomer);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
        }

        /// <summary>
        /// Click Modify button to update add user
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickUpdateCustomer()
        {
            UpdateCustomer.Click();
        }

        public void NavigateToCustmerBasicInfoSetting()
        {
            BasicPropertyTab.Click();
            TimeManager.ShortPause();
        }

        public void NavigateToCustmerMapPageInfoSetting()
        {
            MapPagePropertyTab.Click();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
        }

        public void ClickSaveMapPropertyButton()
        {
            SaveCustomerMapProperty.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
        }

        public void ClickCancelMapPropertyButton()
        {
            CancelCustomerMapProperty.Click();
            TimeManager.ShortPause();
        }

        public void ClickModifyMapPropertyButton()
        {
            ModifyCustomerMapProperty.Click();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
        }

        public bool FocusOnCustomer(string customerName)
        {
            try
            {
                CustomerList.FocusOnRow(1, customerName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Boolean FocusOnUser(string customerName)
        {
            try
            {
                CustomerList.FocusOnRow(1, customerName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public void CheckMapInformation(string mapInfoType)
        {
            CustomerMapInfoCheckBoxField.CommonCheck(mapInfoType);
        }

        public void UnCheckMapInformation(string mapInfoType)
        {
            CustomerMapInfoCheckBoxField.CommonUnCheck(mapInfoType);
        }

        /// <summary>
        /// Verify Is customer map info check box invalid Message Displayed
        /// </summary>
        public Boolean IsMapInfoCheckBoxInvalidTipsDisplayed()
        {
            return CustomerMapInfoLabel.IsLabelDisplayed();
        }

        /// <summary>
        /// UnCheck Map Information items
        /// </summary>
        public Boolean UnCheckMapInformations(string[] mapInfoType)
        {
            int i = 0;
            while (i < mapInfoType.Length)
            {
                if (CustomerMapInfoCheckBoxField.IsCommonUnCheck(mapInfoType[i]))
                {
                    i++;
                }
                else
                    return false;
                
            }
            return true;
        }
        #endregion


        #region Add Customer
        public void ClickAddCustomerButton()
        {
            AddCustomer.Click();
        }

        private void UploadLogoPicture(string picturePath)
        {
            UploadLogoButton.Click();
            TimeManager.LongPause();
            UploadLogoTextField.Append(picturePath);
        }

        public void FillInCustomerInfo(CustomerInputData inputData)
        {
            CustomerName.Fill(inputData.CommonName);
            CustomerCode.Fill(inputData.Code);
            UploadLogoPicture(inputData.LogoPath);
            CustomerAddress.Fill(inputData.Address);
            CustomerResponsiblePerson.Fill(inputData.RealName);
            CustomerTelephone.Fill(inputData.Telephone);
            CustomerEmail.Fill(inputData.Email);
            CustomerOperationTime.SelectDateItem(inputData.OperationTime);
            CustomerComment.Fill(inputData.Comments);
        }


        public void ClickSaveButton()
        {
            SaveCustomer.Click();
        }
        /// <summary>
        /// The button is for delete.
        /// </summary>
        public void ClickDeleteButton()
        {
            DeleteCustomer.Click();
        }

        /// <summary>
        /// The button is for delete in message box.
        /// </summary>
        public void ClickMsgBoxDeleteButton()
        {
            JazzMessageBox.MessageBox.Delete();
        }

        public void ClickMsgBoxGiveUpButton()
        {
            JazzMessageBox.MessageBox.GiveUp();
        }
        public void ClickMsgBoxCloseButton()
        {
            JazzMessageBox.MessageBox.Close();
        }


        /// <summary>
        /// The button is for Cancel.
        /// </summary>
        public void ClickCancelButton()
        {
            CancelCustomer.Click();
        }
        /// <summary>
        /// Navigate to EnergyView Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToEnergyView()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyView);
            TimeManager.ShortPause();
        }

        #endregion

        #region item operation
        /// <summary>
        /// Input name, realname comments etc. of all user field
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        /// 
        public void FillInName(string name)
        {
            CustomerName.Fill(name);
        }

        public void FillInCode(string code)
        {
            CustomerCode.Fill(code);
        }

        public void FillInAddress(string address)
        {
            CustomerAddress.Fill(address);
        }

        public void FillInResponsiblePerson(string responsiblePerson)
        {
            CustomerResponsiblePerson.Fill(responsiblePerson);
        }

        public void FillInTelephone(string telephone)
        {
            CustomerTelephone.Fill(telephone);
        }

        public void FillInEmail(string email)
        {
            CustomerEmail.Fill(email);
        }

        public void FillInComments(string comments)
        {
            CustomerComment.Fill(comments);
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
            return CustomerName.GetValue();
        }

        /// <summary>
        /// verify whether the customer exist the user list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsCustomerOnList(string customerName)
        {
            return CustomersList.IsRowExist(1, customerName);
        }

        public string GetCodeValue()
        {
            return CustomerCode.GetValue();
        }

        public string GetAddressValue()
        {
            return CustomerAddress.GetValue();
        }

        public string GetResponsiblePersonValue()
        {
            return CustomerResponsiblePerson.GetValue();
        }


        public string GetTelephoneValue()
        {
            return CustomerTelephone.GetValue();
        }

        public string GetEmailValue()
        {
            return CustomerEmail.GetValue();
        }

        /// <summary>
        /// return Comment value
        /// </summary>
        /// <returns></returns>
        public string GetCommentsValue()
        {
            return CustomerComment.GetValue();
        }

        /// <summary>
        /// return CustomerAdmin value
        /// </summary>
        /// <returns></returns>
        /// 
        public string GetCustomerAdminTexts()
        {
            return CustomerAdminContainer.GetContainerTexts();
        }
        #endregion

        #region Verify
        /// <summary>
        /// Verfiy whether the default map info options checked
        /// </summary>
        public Boolean AreDefaultOptionsChecked()
        {
            //string[] publicOption = { "二氧化碳排放总量", "成本总量", "用电总量", "用水总量" };
            string[] publicOption = { "$@Setting.CustomerManagement.Label.CarbonEmission", "$@Setting.CustomerManagement.Label.Cost", "$@Setting.CustomerManagement.Label.Electricity", "$@Setting.CustomerManagement.Label.Water" };

            int i = publicOption.Length, j;
            for (j = 0; j < i; j++)
            {
                if (!(CustomerMapInfoCheckBoxField.IsCommonChecked(publicOption[j])))
                    return false;
            }
            return CustomerMapInfoCheckBoxField.IsCommonChecked(publicOption[j - 1]);
        }

        /// <summary>
        /// Verfiy whether the check box all disabled
        /// </summary>
        public Boolean AreCheckBoxOptionDisabled()
        {
            return CustomerMapInfoCheckBoxField.IsAllItemDisabled();
        }
        /// <summary>
        /// Verfiy whether a certain item Checked
        /// </summary>
        public Boolean IsItemChecked(string itemName)
        {
            return CustomerMapInfoCheckBoxField.IsCommonChecked(itemName);
        }

        /// <summary>
        /// Verfiy whether a certain item UnChecked
        /// </summary>
        public Boolean IsItemUnChecked(string itemName)
        {
            return CustomerMapInfoCheckBoxField.IsCommonUnChecked(itemName);
        }

        /// <summary>
        /// Verfiy whether some  items Checked
        /// </summary>
        public Boolean AreItemsChecked(string[] itemNames)
        {
            int i = 0;
            while (i < itemNames.Length)
            {
                if (!(CustomerMapInfoCheckBoxField.IsCommonChecked(itemNames[i])))
                    return false;
                i++;
            }
            return true;
        }

        /// <summary>
        /// Verfiy whether some  items UnChecked
        /// </summary>
        public Boolean AreItemsUnChecked(string[] itemNames)
        {
            int i = 0;
            while (i < itemNames.Length)
            {
                if ((CustomerMapInfoCheckBoxField.IsCommonChecked(itemNames[i])))
                    return false;
                i++;
            }
            return true;
        }

        /// <summary>
        /// Verfiy whether  items disabled
        /// </summary>
        public Boolean AreItemsDisabled(string[] itemNames)
        {
            int i = 0;
            while (i < itemNames.Length)
            {
                if (!(CustomerMapInfoCheckBoxField.IsCommonDisabled(itemNames[i])))
                    return false;
                i++;
            }
            return true;
        }

        /// <summary>
        /// Verfiy whether  a item  disabled
        /// </summary>
        public Boolean IsItemDisabled(string itemName)
        {
            if ((CustomerMapInfoCheckBoxField.IsCommonDisabled(itemName)))
                return false;
            return true;
        }

        /// <summary>
        /// Verfiy whether  a item  disabled
        /// </summary>
        public Boolean AreAllOfItemsAbled()
        {
            string[] items = {"本月二氧化碳排放总量", "本月成本总量", "本月用电总量", "本月用水总量", "本月天然气总量", "本月软水总量", "本月汽油总量", "本月低压蒸汽总量", "本月柴油总量", "本月热量总量", "本月冷量总量", "本月煤总量", "本月煤油总量"};
            int i = 0;
            while (i < items.Length)
            {
                if (CustomerMapInfoCheckBoxField.IsCommonDisabled(items[i]))
                    return false;
                i++;
            }
            return true;
        }

        /*
        /// <summary>
        /// Verfiy whether All the check box all displayed
        /// </summary>
        public Boolean AreCheckBoxOptionDisplayed()
        {
            return CustomerMapInfoCheckBoxField.IsCommonChecked();
        }
         */
        /// <summary>
        /// Verfiy whether cancel button display
        /// </summary>
        public Boolean IsCancelMapPropertyButtonDisplayed()
        {
            return CancelCustomerMapProperty.IsDisplayed();
        }
        #endregion

        /// <summary>
        /// Verfiy whether 'Please select one option at least' displayed.
        /// </summary>
        public Boolean IsInvalidMessageCorrect(string errorTips)
        {
            return CustomerMapInfoContainer.GetContainerErrorTips().Equals(errorTips);
        }

        /// <summary>
        /// Verfiy whether 'Please select one option at least' displayed.
        /// </summary>
        public Boolean IsInvalidMessageDisplayed()
        {
            return CustomerMapInfoContainer.IsMapInfoContainerDisplayed();
        }

        /// <summary>
        /// Verfiy whether Save button displayed.
        /// </summary>
        public Boolean IsMapSaveButtonDisplayed()
        {
            return SaveCustomerMapProperty.IsDisplayed();
        }
        /// <summary>
        /// Verfiy Comment test field hidden.
        /// </summary>
        public Boolean IsCustomerCommentHidden()
        {
            return CustomerComment.IsTextFieldHidden();
        }

        /// <summary>
        /// Verfiy CustomerAdminContainer display.
        /// </summary>
        public Boolean IsCustomerAdminDisplayed()
        {
            return CustomerAdminContainer.IsMapInfoContainerDisplayed();
        }

        /// <summary>
        /// Verfiy Save button display.
        /// </summary>

        public bool IsSaveButtonDisplayed()
        {
            return SaveCustomer.IsDisplayed();
        }

        /// <summary>
        /// Verfiy Operationtime display.
        /// </summary>

        public bool IsOperationtimeEnable()
        {
            return CustomerOperationTime.IsEnabled();
        }

        /// <summary>
        /// Verfiy customer name error message display correct.
        /// </summary>

        public Boolean IsNameInvalidMsgCorrect(CustomerExpectedData output)
        {
            return CustomerName.GetInvalidTips().Contains(output.CommonName);
        }

        /// <summary>
        /// Verfiy customer name error message display correct.
        /// </summary>

        public Boolean IsCodeInvalidMsgCorrect(CustomerExpectedData output)
        {
            return CustomerCode.GetInvalidTips().Contains(output.Code);
        }

        /// <summary>
        /// Verfiy customer name error message display correct.
        /// </summary>

        public Boolean IsAddressInvalidMsgCorrect(CustomerExpectedData output)
        {
            return CustomerAddress.GetInvalidTips().Contains(output.Address);
        }

        /// <summary>
        /// Verfiy customer name error message display correct.
        /// </summary>

        public Boolean IsResponsiblePersonInvalidMsgCorrect(CustomerExpectedData output)
        {
            return CustomerResponsiblePerson.GetInvalidTips().Contains(output.RealName);
        }

        /// <summary>
        /// Verfiy customer name error message display correct.
        /// </summary>

        public Boolean IsTelephoneInvalidMsgCorrect(CustomerExpectedData output)
        {
            return CustomerTelephone.GetInvalidTips().Contains(output.Telephone);
        }

        /// <summary>
        /// Verfiy customer name error message display correct.
        /// </summary>

        public Boolean IsEmailInvalidMsgCorrect(CustomerExpectedData output)
        {
            return CustomerEmail.GetInvalidTips().Contains(output.Email);
        }
        
    }
}
