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
    public class CustomizedLabellingSettings
    {
        internal CustomizedLabellingSettings()
        {
        }
        #region common
        #region button
        private static Button CreatButton = JazzButton.CreatCustomizedLabellingButton;
        private static Button SaveButton = JazzButton.SaveCustomizedLabellingButton;
        private static Button UpdateButton = JazzButton.UpdateCustomizedLabellingButton;
        private static Button ModifyButton = JazzButton.ModifyCustomizedLabellingButton;
        private static Button DeleteButton = JazzButton.DeleteCustomizedLabellingButton;
        private static RadioButton ArrangementButton = JazzButton.AscendingCustomizedLabellingButton;
        #endregion

        #region combox
        private static ComboBox CommodityComboBox = JazzComboBox.CustomizedLabellingCommodityComboBox;
        private static ComboBox KPITypeComboBox = JazzComboBox.CustomizedLabellingTypeComboBox;
        private static ComboBox LabellingLevelComboBox = JazzComboBox.CustomizedLabellingLevelComboBox;
        #endregion

        #region textfield
        private static TextField NameTextField = JazzTextField.TextFieldCustomizedLabellingName;
        #endregion
        #endregion

        #region operation
        /// <summary>
        /// Navigate to CustomizedLabelling Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToCustomizedLabelling()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CustomizedLabelling);
            TimeManager.ShortPause();
        }

        /// <summary>
        /// Click "add CustomizedLabelling" button to add one ptag
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickAddCustomizedLabellingButton()
        {
            CreatButton.Click();
        }

        /// <summary>
        /// Click Save button 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            SaveButton.Click();
        }

        /// <summary>
        /// FillIn CustomizedLabellingName TextField
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void FillInNameTextField(string input)
        {
            NameTextField.Fill(input);
        }

        /// <summary>
        /// Select CustomizedLabellingCommodity combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectCommodityComboBox(string ItemName)
        {
            CommodityComboBox.SelectItem(ItemName);
        }

        /// <summary>
        /// Select KPIType combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectKPITypeComboBox(string ItemName)
        {
            KPITypeComboBox.SelectItem(ItemName);
        }

        /// <summary>
        /// Select LabellingLevel combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectLabellingLevelComboBox(string ItemName)
        {
            LabellingLevelComboBox.SelectItem(ItemName);
        }

        /// <summary>
        /// Get AscendingCustomizedLabellingButton 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetAscendingCustomizedLabellingButton()
        {
            return JazzButton.AscendingCustomizedLabellingButton.GetRadioButtonLabel();
        }
        #endregion

        #region GetValue
        /// <summary>
        /// Get CustomizedLabellingNameValue 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetNameTextFieldValue()
        {
            return NameTextField.GetValue();
        }
        #endregion
    }
}
