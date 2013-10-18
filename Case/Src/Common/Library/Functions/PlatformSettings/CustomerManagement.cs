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

        private static TabButton MapPagePropertyTab = JazzButton.MapPagePropertyTabButton;
        private static TabButton BasicPropertyTab = JazzButton.BasicPropertyTabButton;

        private static TextField CustomerName = JazzTextField.CustomerNameTextField;
        private static TextField Customercode = JazzTextField.CustomercodeTextField;
        private static TextField CustomerAddress = JazzTextField.CustomerAddressTextField;
        private static TextField CustomerManager = JazzTextField.CustomerManagerTextField;
        private static TextField CustomerTelephone = JazzTextField.CustomerTelephoneTextField;
        private static TextField CustomerEmail = JazzTextField.CustomerCommentTextField;
        private static TextField CustomerComment = JazzTextField.CustomerCommentTextField;
        private static DatePicker CustomerOperationTime = JazzDatePicker.OperationTimeDatePicker;
        private static TextField UploadLogoTextField = JazzTextField.UploadLogoTextField;

        private static Grid CustomerList = JazzGrid.CustomerList;

        private static CheckBoxField CustomerMapInfoCheckBoxField = JazzCheckBox.CustomerMapPropertyCheckBoxField;

        private static Container CustomerMapInfoContainer = JazzContainer.ContainerCustomerMapInfo;

        private static Label CustomerMapInfoLabel = JazzLabel.PlatformCustomerMapInfoLabel;

        #endregion

        #region Common
        public void NavigateToCustmerSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CustomerManagementCustomer);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
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

        public void FocusOnCustomer(string customerName)
        {
            CustomerList.FocusOnRow(1,customerName);
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
                if (CustomerMapInfoCheckBoxField.CommonUnCheck(mapInfoType[i]))
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

        public void FillInCustomerInfo(CustomerInputData　inputData)
        {
            CustomerName.Fill(inputData.Name);
            Customercode.Fill(inputData.code);
            //UploadLogoPicture(inputData.LogoPath);
            CustomerAddress.Fill(inputData.Address);
            CustomerManager.Fill(inputData.ResponsiblePerson);
            CustomerTelephone.Fill(inputData.Telephone);
            CustomerEmail.Fill(inputData.Email);
            CustomerOperationTime.SelectDateItem(inputData.OperationTime);
            CustomerComment.Fill(inputData.Comment);
        }

        public void ClickSaveButton()
        {
            SaveCustomer.Click();
        }
        #endregion

        #region Verify
        /// <summary>
        /// Verfiy whether the default map info options checked
        /// </summary>
        public Boolean AreDefaultOptionsChecked()
        {
            string[] publicOption = { "上月二氧化碳排放总量", "上月成本总量", "上月用电总量", "上月用水总量" };
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
            string[] items = {"上月二氧化碳排放总量", "上月成本总量", "上月用电总量", "上月用水总量", "上月天然气总量", "上月软水总量", "上月汽油总量", "上月低压蒸汽总量", "上月柴油总量", "上月热量总量", "上月冷量总量", "上月煤总量", "上月煤油总量"};
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
    }
}
