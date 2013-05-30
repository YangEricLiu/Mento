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
    /// <summary>
    /// The business logic implement of physical tag configuration.
    /// </summary>
    public class PTagSettings
    {
        internal PTagSettings()
        {
        }

        #region ptag controls
        
        private static Grid PTagList = JazzGrid.PTagSettingsPTagList;

        private static Button CreatePTagButton = JazzButton.PTagSettingsCreatePTagButton;

        private static Button ModifyButton = JazzButton.PTagSettingsModifyButton;
        private static Button SaveButton = JazzButton.PTagSettingsSaveButton;
        private static Button CancelButton = JazzButton.PTagSettingsCancelButton;
        private static Button DeleteButton = JazzButton.PTagSettingsDeleteButton;

        private static TextField NameTextField = JazzTextField.PTagSettingsNameTextField;
        private static TextField CodeTextField = JazzTextField.PTagSettingsCodeTextField;
        private static TextField MetercodeTextField = JazzTextField.PTagSettingsMetercodeTextField;
        private static TextField ChannelTextField = JazzTextField.PTagSettingsChannelTextField;
        private static ComboBox CommodityComboBox = JazzComboBox.PTagSettingsCommodityComboBox;
        private static ComboBox UomComboBox = JazzComboBox.PTagSettingsUomComboBox;
        private static ComboBox CalculationTypeComboBox = JazzComboBox.PTagSettingsCalculationTypeComboBox;
        private static TextField CommentTextField = JazzTextField.PTagSettingsCommentTextField;

        #endregion

        #region Ptag List Operation

        /// <summary>
        /// Navigate to Ptag Configuration Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToPtagSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsP);
            //TimeManager.ShortPause();
        }

        /// <summary>
        /// Click "add ptag" button to add one ptag
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickAddPtagButton()
        {
            CreatePTagButton.Click();
        }

        /// <summary>
        /// Focus ptag by name
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean FocusOnPTagByName(string ptagName)
        {
            try
            {
                PTagList.FocusOnRow(1, ptagName);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Focus ptag by name
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean FocusOnPTagByCode(string ptagCode)
        {
            try
            {
                PTagList.FocusOnRow(2, ptagCode);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Basic Property Operations

        /// <summary>
        /// Click save button for ptag
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            SaveButton.Click();
        }

        /// <summary>
        /// Judge "Save" display
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsSaveButtonDisplayed()
        {
            return SaveButton.IsDisplayed();
        }

        /// <summary>
        /// Click Delete button for ptag
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickDeleteButton()
        {
            DeleteButton.Click();
        }

        /// <summary>
        /// Judge "Delete" display
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsDeleteButtonDisplayed()
        {
            return DeleteButton.IsDisplayed();
        }

        /// <summary>
        /// Click Cancel button for ptag
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCancelButton()
        {
            CancelButton.Click();
        }

        /// <summary>
        /// Judge "Cancel" display
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsCancelButtonDisplayed()
        {
            return CancelButton.IsDisplayed();
        }

        /// <summary>
        /// Click "modify" button 
        /// </summary>
        /// <param>Tag name</param>
        /// <returns></returns>
        public void ClickModifyButton()
        {
            ModifyButton.Click();
        }

        /// <summary>
        /// Judge "Save" display 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsModifyButtonDisplayed()
        {
            return ModifyButton.IsDisplayed();
        }

        #endregion

        #region Ptag field operations

        /// <summary>
        /// Input name, code, metercode, channelid, commodityid, uomid, calculationtype and comment of the ptag
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInPtag(PtagInputData input)
        {
            NameTextField.Fill(input.CommonName);
            CodeTextField.Fill(input.Code);
            MetercodeTextField.Fill(input.Meter);
            ChannelTextField.Fill(input.Channel);
            CommodityComboBox.SelectItem(input.Commodity);
            UomComboBox.SelectItem(input.Uom);
            CalculationTypeComboBox.SelectItem(input.CalculationType);
            CommentTextField.Fill(input.Comments);
        }

        /// <summary>
        /// Input code of the ptag
        /// </summary>
        /// <param name="code">code</param>
        /// <returns></returns>
        public void FillIncode(string code)
        {
            CodeTextField.Fill(code);
        }

        /// <summary>
        /// Get the tag Name actual value
        /// </summary>
        /// <returns></returns>
        public string GetNameValue()
        {
            return NameTextField.GetValue();
        }

        /// <summary>
        /// Get the tag code actual value
        /// </summary>
        /// <returns></returns>
        public string GetCodeValue()
        {
            return CodeTextField.GetValue();
        }

        /// <summary>
        /// Get the tag Metercode actual value
        /// </summary>
        /// <returns></returns>
        public string GetMetercodeValue()
        {
            return MetercodeTextField.GetValue();
        }

        /// <summary>
        /// Get the tag ChannelId actual value
        /// </summary>
        /// <returns></returns>
        public string GetChannelIdValue()
        {
            return ChannelTextField.GetValue();
        }

        /// <summary>
        /// Get the tag Commodity actual value
        /// </summary>
        /// <returns></returns>
        public string GetCommodityValue()
        {
            return CommodityComboBox.GetValue();
        }

        /// <summary>
        /// Get the tag Commodity expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">Commodity key</param>
        /// <returns>Key value</returns>
        public string GetCommodityExpectedValue(string itemKey)
        {
            return CommodityComboBox.GetActualValue(itemKey);
        }

        /// <summary>
        /// Get the tag Uom actual value
        /// </summary>
        /// <returns></returns>
        public string GetUomValue()
        {
            return UomComboBox.GetValue();
        }

        /// <summary>
        /// Get the tag Uom expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">Uom key</param>
        /// <returns>Key value</returns>
        public string GetUomExpectedValue(string itemKey)
        {
            return UomComboBox.GetActualValue(itemKey);
        }

        /// <summary>
        /// Get the tag CalculationType actual value
        /// </summary>
        /// <returns></returns>
        public string GetCalculationTypeValue()
        {
            return CalculationTypeComboBox.GetValue();
        }

        /// <summary>
        /// Get the tag CalculationType expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">CalculationType key</param>
        /// <returns>Key value</returns>
        public string GetCalculationTypeExpectedValue(string itemKey)
        {
            return CalculationTypeComboBox.GetActualValue(itemKey);
        }

        /// <summary>
        /// Get the tag Comment actual value
        /// </summary>
        /// <returns></returns>
        public string GetCommentValue()
        {
            return CommentTextField.GetValue();
        }

        /// <summary>
        /// Judge whether the textfield and its label are hidden
        /// </summary>
        /// <returns>True if it is hidden, false if not</returns>
        public Boolean IsCommentHidden()
        {
            return CommentTextField.IsTextFieldHidden();
        }

        #endregion        
    }
}
