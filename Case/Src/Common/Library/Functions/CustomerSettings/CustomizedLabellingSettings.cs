﻿using System;
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
        private static RadioButton AscendingButton = JazzButton.CustomizedLabellingAscendingOrderButton;
        private static RadioButton DescendingButton = JazzButton.CustomizedLabellingDescendingOrderButton;
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
        /// Click Update button 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickUpdateButton()
        {
            UpdateButton.Click();
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
        /// FillIn CustomizedLabellingLevelLeftValue 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void FillInLabellingLevelLeftValue(int num, string value)
        {
            CustomizedLabellingGrade.FillGradeItemLeftNumberValue(num, value);
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

        /// <summary>
        /// Change CustomizedLabellingCommodity combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectCommodityComboBox(string ItemName)
        {
            CommodityComboBox.SelectItem(ItemName);
        }

        /// <summary>
        /// Select CustomizedLabellingLevel combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectCustomizedLabellingLevelComboBox(string ItemName)
        {
            LabellingLevelComboBox.SelectItem(ItemName);
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
            return AscendingButton.GetRadioButtonText();
        }

        /// <summary>
        /// Get DecendingCustomizedLabellingButton 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetDescendingCustomizedLabellingButton()
        {
            return DescendingButton.GetRadioButtonText();
        }

        #endregion

        #region verify
        /// <summary>
        /// Verify if labeling exist in the labeling list.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void IslabelingNameExist(string labelingName)
        {
            CustomizedLabellingList.IsRowExist(1, labelingName);
        }


        /// <summary>
        ///check grade is empty
        /// </summary>
        /// <param></param>
        /// <returns></returns>

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
        /// Get CustomizedLabellingCommodityComboBox 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetCommodityComboBoxValue()
        {
            return CommodityComboBox.GetValue();
        }

        /// <summary>
        /// Get CustomizedLabellingKPITypeComboBox 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetKPITypeComboBoxValue()
        {
            return KPITypeComboBox.GetValue();
        }

        /// <summary>
        /// Get CustomizedLabellingLabellingLevelComboBox 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetLabellingLevelComboBoxValue()
        {
            return LabellingLevelComboBox.GetValue();
        }

        /// <summary>
        /// Get CustomizedLabellingFrontLabel 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetLabellingGradeFrontLabel()
        {
            return CustomizedLabellingGrade.GetFirstGradeItemLabel();
        }

        /// <summary>
        /// Get CustomizedLabellingLastLabel 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetLabellingGradeLastLabel()
        {
            return CustomizedLabellingGrade.GetLastGradeItemLabel();
        }

        /// <summary>
        /// Get CustomizedLabelling count 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public int GetLabellingGradeCount()
        {
            return CustomizedLabellingGrade.GetCurrentGradeItemsNumber();
        }

        /// <summary>
        /// Get CustomizedLabellingLevelLeftValue 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetLabellingGradeLeftValue(int num)
        {
           return CustomizedLabellingGrade.GetGradeItemLeftNumberValue(num);
        }

        /// <summary>
        /// Get CustomizedLabellingLevelRightValue 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetLabellingGradeRightValue(int num)
        {
            return CustomizedLabellingGrade.GetGradeItemRightNumberValue(num);
        }

        /// <summary>
        /// Get CustomizedLabellingUOMValue
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetLabellingUOMValue(int num)
        {
            return CustomizedLabellingGrade.GetGradeItemUOMValue(num);
        }

        /// <summary>
        /// Get CustomizedLabellingList's count
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public int GetCustomizedLabellingListCount()
        {
            return CustomizedLabellingList.GetCurrentRowsNumber();
        }

        /// <summary>
        /// Get CustomizedLabellingName  Invalid tips
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetLabellingNameInvalidTips()
        {
            return NameTextField.GetInvalidTips();
        }

        /// <summary>
        /// Get CustomizedLabellingGrade  Invalid tips
        /// </summary>
        /// <param></param>
        /// <returns></returns>
       /* public string GetLabellingGradeInvalidTips()
        {
            return CustomizedLabellingGrade.GetInvalidTips();
        }*/
        #endregion
    }
}
