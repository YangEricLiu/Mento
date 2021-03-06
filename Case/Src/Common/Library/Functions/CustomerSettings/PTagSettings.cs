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
        private static TextField SlopeTextField = JazzTextField.PTagSettingsSlopeTextField;
        private static TextField OffsetTextField = JazzTextField.PTagSettingsOffsetTextField;
        private static ComboBox CommodityComboBox = JazzComboBox.PTagSettingsCommodityComboBox;
        private static ComboBox UomComboBox = JazzComboBox.PTagSettingsUomComboBox;
        private static ComboBox CalculationTypeComboBox = JazzComboBox.PTagSettingsCalculationTypeComboBox;
        private static ComboBox CollectCycleComboBox = JazzComboBox.PTagSettingsCollectCycleComboBox;
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
            TimeManager.ShortPause();
        }

        public void PTagSettingCaseSetUp()
        {
            NavigatorToPtagSetting();
            WaitPtagListDisplay(10);
            TimeManager.ShortPause();
        }

        public void PTagSettingCaseTearDown()
        {
            NavigatorToCustomizedLabeling();
            TimeManager.LongPause();
        }

        /// <summary>
        /// Navigate to Ptag Configuration Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToEnergyView()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyView);
            TimeManager.ShortPause();
        }

        public void NavigatorToCustomizedLabeling()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CustomizedLabelling);
            TimeManager.ShortPause();
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
                PTagList.FocusOnRow(2, ptagName);
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
                PTagList.FocusOnRow(3, ptagCode);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Check tags by tag names
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean CheckPTagByTagName(string tagName)
        {
            try
            {
                PTagList.CheckRowCheckbox(2, tagName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Check tags by tag codes
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean CheckPTagByCode(string tagCode)
        {
            try
            {
                PTagList.CheckRowCheckbox(3, tagCode);
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
            JazzMessageBox.LoadingMask.WaitLoading();
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
        public void FillInPtagVerification(PtagInputData input)
        {
            NameTextField.Fill(input.CommonName);
            CodeTextField.Fill(input.Code);
            MetercodeTextField.Fill(input.Meter);
            ChannelTextField.Fill(input.Channel);
            CommodityComboBox.SelectItem(input.Commodity);
            UomComboBox.SelectItem(input.Uom);
            CollectCycleComboBox.SelectItem(input.CollectCycle);
            CalculationTypeComboBox.SelectItem(input.CalculationType);
            SlopeTextField.Fill(input.DoubleNagtiveValue);
            OffsetTextField.Fill(input.DoubleNagtiveValue);
            CommentTextField.Fill(input.Comments);
        }

        public void FillInPtag(PtagInputData input)
        {
            NameTextField.Fill(input.CommonName);
            CodeTextField.Fill(input.Code);
            MetercodeTextField.Fill(input.Meter);
            ChannelTextField.Fill(input.Channel);
            CommodityComboBox.SelectItem(input.Commodity);
            UomComboBox.SelectItem(input.Uom);
            CollectCycleComboBox.SelectItem(input.CollectCycle);
            CalculationTypeComboBox.SelectItem(input.CalculationType);
            SlopeTextField.Fill(input.Slope);
            OffsetTextField.Fill(input.Offset);
            CommentTextField.Fill(input.Comments);
        }

        /// <summary>
        /// Check the IsAccumulated checkbox
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        public void CheckIsAccumulatedCheckbox(string name)
        {
            JazzCheckBox.PtagIsAccumulatedCheckBox.CommonCheck(name);
        }

        /// <summary>
        /// Check the IsAccumulated checkbox
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        public void UncheckIsAccumulatedCheckbox(string name)
        {
            JazzCheckBox.PtagIsAccumulatedCheckBox.CommonUnCheck(name);
        }

        /// <summary>
        /// Is IsAccumulated checkbox checked
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        public bool IsAccumulatedChecked(string name)
        {
            return JazzCheckBox.PtagIsAccumulatedCheckBox.IsCommonChecked(name);
        }

        /// <summary>
        /// Is IsAccumulated checkbox checked
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        public bool IsAccumulatedNotDisplayed(string name)
        {
            return JazzCheckBox.PtagIsAccumulatedCheckBox.IsCommonNotDisplayed(name);
        }

        /// <summary>
        /// Input code of the ptag
        /// </summary>
        /// <param name="code">code</param>
        /// <returns></returns>
        public void FillInCommodityAndUom(string commodity,string uom)
        {
            CommodityComboBox.SelectItem(commodity);
            UomComboBox.SelectItem(uom);
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

        public void FillInName(string name)
        {
            NameTextField.Fill(name);
        }

        #endregion

        #region Get Value

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
        /// Get the tag slope actual value
        /// </summary>
        /// <returns></returns>
        public string GetSlopeValue()
        {
            return SlopeTextField.GetValue();
        }

        /// <summary>
        /// Get the tag Offset actual value
        /// </summary>
        /// <returns></returns>
        public string GetOffsetValue()
        {
            return OffsetTextField.GetValue();
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
        /// Get the tag CollectCycle actual value
        /// </summary>
        /// <returns></returns>
        public string GetCollectCycleValue()
        {
            return CollectCycleComboBox.GetValue();
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
        /// Get the tag CollectCycle expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">Commodity key</param>
        /// <returns>Key value</returns>
        public string GetCollectCycleExpectedValue(string itemKey)
        {
            return CollectCycleComboBox.GetActualValue(itemKey);
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

        #endregion       

        #region Verification       

        public void WaitPtagListDisplay(int maxtime)
        {
            PTagList.WaitControlDisplayed(maxtime);
        }


        public void WaitPtagPropertyInfoDisplay(int maxtime)
        {
            NameTextField.WaitControlDisplayed(maxtime);
        }

        /// <summary>
        /// Judge whether the textfield and its label are hidden
        /// </summary>
        /// <returns>True if it is hidden, false if not</returns>
        public Boolean IsCommentHidden()
        {
            return CommentTextField.IsTextFieldHidden();
        }

        /// <summary>
        /// Judge whether the textfield and its label are hidden
        /// </summary>
        /// <returns>True if it is hidden, false if not</returns>
        public Boolean IsSlopeHidden()
        {
            return SlopeTextField.IsTextFieldHidden();
        }

        /// <summary>
        /// Judge whether the textfield and its label are hidden
        /// </summary>
        /// <returns>True if it is hidden, false if not</returns>
        public Boolean IsOffsetHidden()
        {
            return OffsetTextField.IsTextFieldHidden();
        }

        /// <summary>
        /// Return whether comment is enabled
        /// </summary>
        /// <returns>True if enabled</returns>
        public Boolean IsCommentFieldEnabled()
        {
            return CommentTextField.IsFieldEnabled();
        }

        /// <summary>
        /// Judge whether the name textfield is invalid
        /// </summary>
        /// <returns>True if the name is invalid, false if not</returns>
        public Boolean IsNameInvalid()
        {
            return NameTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of name field is correct
        /// </summary>
        /// <param name="output">PtagExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsNameInvalidMsgCorrect(PtagExpectedData output)
        {
            return NameTextField.GetInvalidTips().Contains(output.CommonName);
        }

        public Boolean IsNameInvalidMsgCorrect(string msg)
        {
            return NameTextField.GetInvalidTips().Contains(msg);
        }

        /// <summary>
        /// Judge whether the code textfield is invalid
        /// </summary>
        /// <returns>True if the code is invalid, false if not</returns>
        public Boolean IscodeInvalid()
        {
            return CodeTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of code field is correct
        /// </summary>
        /// <param name="output">PtagExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IscodeInvalidMsgCorrect(PtagExpectedData output)
        {
            return CodeTextField.GetInvalidTips().Contains(output.Code);
        }

        /// <summary>
        /// Judge whether the code textfield is invalid
        /// </summary>
        /// <returns>True if the code is invalid, false if not</returns>
        public Boolean IsMeterCodeInvalid()
        {
            return MetercodeTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of code field is correct
        /// </summary>
        /// <param name="output">PtagExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsMeterCodeInvalidMsgCorrect(PtagExpectedData output)
        {
            return MetercodeTextField.GetInvalidTips().Contains(output.Meter);
        }

        /// <summary>
        /// Judge whether the channel textfield is invalid
        /// </summary>
        /// <returns>True if the channel is invalid, false if not</returns>
        public Boolean IsChannelInvalid()
        {
            return ChannelTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether the Slope textfield is invalid
        /// </summary>
        /// <returns>True if the channel is invalid, false if not</returns>
        public Boolean IsSlopeInvalid()
        {
            return SlopeTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether the Offset textfield is invalid
        /// </summary>
        /// <returns>True if the channel is invalid, false if not</returns>
        public Boolean IsOffsetInvalid()
        {
            return OffsetTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of code field is correct
        /// </summary>
        /// <param name="output">PtagExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsChannelInvalidMsgCorrect(PtagExpectedData output)
        {
            return ChannelTextField.GetInvalidTipsForNumberField().Contains(output.Channel);
        }

        /// <summary>
        /// Judge whether invalid message of Slope field is correct
        /// </summary>
        /// <param name="output">PtagExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsSlopeInvalidMsgCorrect(PtagExpectedData output)
        {
            return SlopeTextField.GetInvalidTipsForNumberField().Contains(output.DoubleNagtiveValue);
        }

        /// <summary>
        /// Judge whether invalid message of Offset field is correct
        /// </summary>
        /// <param name="output">PtagExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsOffsetInvalidMsgCorrect(PtagExpectedData output)
        {
            return OffsetTextField.GetInvalidTipsForNumberField().Contains(output.DoubleNagtiveValue);
        }

        /// <summary>
        /// Judge whether the Comments textfield is invalid
        /// </summary>
        /// <returns>True if the Comments is invalid, false if not</returns>
        public Boolean IsCommentsInvalid()
        {
            return CommentTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of Comments field is correct
        /// </summary>
        /// <param name="output">PtagExpectedData</param>
        /// <returns>whether the invalid message is true</returns>
        public Boolean IsCommentsInvalidMsgCorrect(PtagExpectedData output)
        {
            return CommentTextField.GetInvalidTips().Contains(output.Comments);
        }

        /// <summary>
        /// Judge whether the Commodity textfield is invalid
        /// </summary>
        /// <returns>True if the Commodity is invalid, false if not</returns>
        public Boolean IsCommodityInvalid()
        {
            return CommodityComboBox.IsComboBoxValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of type field is correct
        /// </summary>
        /// <param name="output">PtagExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsCommodityInvalidMsgCorrect(PtagExpectedData output)
        {
            return CommodityComboBox.GetInvalidTips().Contains(output.Commodity);
        }

        /// <summary>
        /// Judge whether invalid message of type field is correct
        /// </summary>
        /// <param name="output">PtagExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsCommodityInvalidMsgCorrectByCommodity(string commodity)
        {
            return CommodityComboBox.GetInvalidTips().Contains(commodity);
        }

        /// <summary>
        /// Judge whether the UOM textfield is invalid
        /// </summary>
        /// <returns>True if the UOM is invalid, false if not</returns>
        public Boolean IsUomInvalid()
        {
            return UomComboBox.IsComboBoxValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of type field is correct
        /// </summary>
        /// <param name="output">PtagExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsUomInvalidMsgCorrect(PtagExpectedData output)
        {
            return UomComboBox.GetInvalidTips().Contains(output.Uom);
        }

        /// <summary>
        /// Judge whether the CalculationType textfield is invalid
        /// </summary>
        /// <returns>True if the CalculationType is invalid, false if not</returns>
        public Boolean IsCalculationTypeInvalid()
        {
            return CalculationTypeComboBox.IsComboBoxValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of type field is correct
        /// </summary>
        /// <param name="output">PtagExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsCalculationTypeInvalidMsgCorrect(PtagExpectedData output)
        {
            return CalculationTypeComboBox.GetInvalidTips().Contains(output.CalculationType);
        }

        /// <summary>
        /// Judge whether the CollectCycle textfield is invalid
        /// </summary>
        /// <returns>True if the CollectCycle is invalid, false if not</returns>
        public Boolean IsCollectCycleInvalid()
        {
            return CollectCycleComboBox.IsComboBoxValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of type field is correct
        /// </summary>
        /// <param name="output">PtagExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsCollectCycleInvalidMsgCorrect(PtagExpectedData output)
        {
            return CollectCycleComboBox.GetInvalidTips().Contains(output.CalculationType);
        }

        #endregion

    }
}
