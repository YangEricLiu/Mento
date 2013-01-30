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
        private static TextField CustomerName = JazzTextField.CustomerNameTextField;
        private static TextField CustomerCode = JazzTextField.CustomerCodeTextField;
        private static TextField CustomerAddress = JazzTextField.CustomerAddressTextField;
        private static TextField CustomerManager = JazzTextField.CustomerManagerTextField;
        private static TextField CustomerTelephone = JazzTextField.CustomerTelephoneTextField;
        private static TextField CustomerEmail = JazzTextField.CustomerCommentTextField;
        private static TextField CustomerComment = JazzTextField.CustomerCommentTextField;
        private static DatePicker CustomerOperationTime = JazzDatePicker.OperationTimeDatePicker;
        private static TextField UploadLogoTextField = JazzTextField.UploadLogoTextField;
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
            CustomerCode.Fill(inputData.Code);
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
