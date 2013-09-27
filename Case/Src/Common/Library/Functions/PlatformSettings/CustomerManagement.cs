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
            CustomerMapInfoCheckBoxField.Check(mapInfoType);
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

    }
}
