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
        private static RadioButton ArrangementButton = JazzButton.CustomizedLabellingOrderButton;
        #endregion

        #region combox
        private static ComboBox CommodityComboBox = JazzComboBox.CustomizedLabellingCommodityComboBox;
        private static ComboBox KPITypeComboBox = JazzComboBox.CustomizedLabellingTypeComboBox;
        private static ComboBox LabellingLevelComboBox = JazzComboBox.CustomizedLabellingLevelComboBox;
        #endregion


        public static Grid CustomizedLabellingList = JazzGrid.CustomizedLabellingListGrid;
        #region grade
        private static Grade CustomizedLabellingGrade = JazzGrade.CustomizedLabellingGrade;
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
            return JazzButton.CustomizedLabellingOrderButton.GetRadioButtonLabel();
        }


        #endregion

        #region verify
        /// <summary>
        /// Focus Labeling
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void IslabelingNameExist(string labelingName)
        {
            CustomizedLabellingList.FocusOnRow(1, labelingName);
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

        /// <summary>
        /// Get CustomizedLabellingLevelLeftValue 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetLabellingLevelLeftValue(int num)
        {
           return CustomizedLabellingGrade.GetGradeItemLeftNumberValue(num);
        }

        /// <summary>
        /// FillIn CustomizedLabellingLevelLeftValue 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void FillInLabellingLevelLeftValue(int num, string value)
        {
             CustomizedLabellingGrade.FillGradeItemLeftNumberValue(num, value);
        }

        /// <summary>
        /// Get CustomizedLabellingLevelRightValue 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetLabellingLevelRightValue(int num)
        {
            return CustomizedLabellingGrade.GetGradeItemRightNumberValue(num);
        }

        /// <summary>
        /// FillIn CustomizedLabellingLevelRightValue 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void FillInLabellingLevelRightValue(int num, string value)
        {
            CustomizedLabellingGrade.FillGradeItemRightNumberValue(num, value);
        }
        #endregion
    }
}
