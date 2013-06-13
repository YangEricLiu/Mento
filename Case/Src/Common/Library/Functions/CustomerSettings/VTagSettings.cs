using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library.Functions;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class VTagSettings
    {
        internal VTagSettings()
        {
        }

        #region Vtag Controls
        
        private static Grid VTagList = JazzGrid.VTagSettingsVTagList;

        private static TabButton BasicPropertyTab = JazzButton.VTagSettingsBasicPropertyTabButton;
        private static TabButton FormulaTab = JazzButton.VTagSettingsFormulaTabButton;

        private static Button CreateVTagButton = JazzButton.VTagSettingsCreateVTagButton;

        private static Button ModifyButton = JazzButton.VTagSettingsModifyButton;
        private static Button SaveButton = JazzButton.VTagSettingsSaveButton;
        private static Button CancelButton = JazzButton.VTagSettingsCancelButton;
        private static Button DeleteButton = JazzButton.VTagSettingsDeleteButton;
        private static Button VTagSettingsFormulaUpdate = JazzButton.VTagSettingsFormulaUpdateButton;
        private static Button VTagSettingsFormulaSave = JazzButton.VTagSettingsFormulaSaveButton;

        private static TextField NameTextField = JazzTextField.VTagSettingsNameTextField;
        private static TextField codeTextField = JazzTextField.VTagSettingscodeTextField;
        private static ComboBox CommodityComboBox = JazzComboBox.VTagSettingsCommodityComboBox;
        private static ComboBox UomComboBox = JazzComboBox.VTagSettingsUomComboBox;
        private static ComboBox CalculationTypeComboBox = JazzComboBox.VTagSettingsCalculationTypeComboBox;
        private static ComboBox CalculationStepComboBox = JazzComboBox.VTagSettingsCalculationStepComboBox;
        private static TextField CommentTextField = JazzTextField.VTagSettingsCommentTextField;


        private static Grid FormulaPTagList = JazzGrid.VTagSettingsFormulaEditPTagList;
        private static Grid FormulaVTagList = JazzGrid.VTagSettingsFormulaEditPTagList;
        private static FormulaField FormulaField = JazzTextField.VFormulaField;

     
        #endregion

        #region VTag List Operations
        /// <summary>
        /// Navigate to VTag settings
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToVTagSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
            TimeManager.ShortPause();
        }

        /// <summary>
        /// Click Formula tab button to edit formula of vtag/KPI.
        /// </summary>
        /// <returns></returns>
        public void SwitchToBasicPropertyTab()
        {
            BasicPropertyTab.Click();
        }

        /// <summary>
        /// Click Formula tab button to edit formula of vtag/KPI.
        /// </summary>
        /// <returns></returns>
        public void SwitchToFormulaTab()
        {
            FormulaTab.Click();
        }

        /// <summary>
        /// Click add vtag add button
        /// </summary>
        /// <returns></returns>
        public void ClickAddVTagButton()
        {
            CreateVTagButton.Click();
        }

        /// <summary>
        /// Select one tag
        /// </summary>
        /// <param name="vtagName">VTag name</param>
        /// <returns></returns>
        public Boolean FocusOnVTagByName(string vtagName)
        {
            try
            {
                VTagList.FocusOnRow(1, vtagName);
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
        public Boolean FocusOnVTagByCode(string vtagCode)
        {
            try
            {
                VTagList.FocusOnRow(2, vtagCode);
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
        /// Click add vtag save button
        /// </summary>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            SaveButton.Click();
        }

        /// <summary>
        /// Click Delete vtag button
        /// </summary>
        /// <returns></returns>
        public void ClickDeleteButton()
        {
            DeleteButton.Click();
        }


        /// <summary>
        /// Judge "Save" display          ---- Greenie add
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsSaveButtonDisplayed()
        {
            return SaveButton.IsDisplayed();
        }

        /// <summary>
        /// Judge "Modify" display          ---- Greenie add
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsModifyButtonDisplayed()
        {
            return ModifyButton.IsDisplayed();
        }
        /// <summary>
        /// Judge "Delete" display          ---- Greenie add
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsDeleteButtonDisplayed()
        {
            return DeleteButton.IsDisplayed();
        }
        /// <summary>
        /// Judge "Cancel" display       ---- Greenie add
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsCancelButtonDisplayed()
        {
            return CancelButton.IsDisplayed();
        }


        /// <summary>
        /// Click cancel button to cancel add new VTag
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCancelButton()
        {
            CancelButton.Click();
        }

        /// <summary>
        /// Input data
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void FillInAddVTagData(VtagInputData input)
        {
            NameTextField.Fill(input.CommonName);
            codeTextField.Fill(input.Code);
            CommodityComboBox.SelectItem(input.Commodity);
            UomComboBox.SelectItem(input.UOM);
            CalculationStepComboBox.SelectItem(input.Step);
            //TimeManager.LongPause();
            CalculationTypeComboBox.SelectItem(input.CalculationType);
            CommentTextField.Fill(input.Comment);
        }

        /// <summary>
        /// Input name of the new VTag 
        /// </summary>
        /// <param name="name">VTag name</param>
        /// <returns></returns>
        public void FillInName(String name)
        {
            NameTextField.Fill(name);
        }

        /// <summary>
        /// Input code of the new VTag 
        /// </summary>
        /// <param name="code">VTag code</param>
        /// <returns></returns>
        public void FillIncode(string code)
        {
            codeTextField.Fill(code);
        }

        /// <summary>
        /// Input comment of the new VTag 
        /// </summary>
        /// <param name="comment">VTag comment</param>
        /// <returns></returns>
        public void FillInComment(string comment)
        {
            CommentTextField.Fill(comment);
        }
        
        /// <summary>
        /// Get the VTag Name actual value
        /// </summary>
        /// <returns></returns>
        public string GetVTagNameValue()
        {
            return NameTextField.GetValue();
        }

        /// <summary>
        /// Get the VTag code actual value
        /// </summary>
        /// <returns></returns>
        public string GetVTagcodeValue()
        {
            return codeTextField.GetValue();
        }

        /// <summary>
        /// Get the VTag Commodity actual value
        /// </summary>
        /// <returns></returns>
        public string GetVTagCommodityValue()
        {
            return CommodityComboBox.GetValue();
        }

        /// <summary>
        /// Get the VTag expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">VTag commodity key</param>
        /// <returns>Key value</returns>
        public string GetVTagCommodityExpectedValue(string itemKey)
        {
            return CommodityComboBox.GetActualValue(itemKey);
        }

        /// <summary>
        /// Get the VTag UOM actual value
        /// </summary>
        /// <returns></returns>
        public string GetVTagUOMValue()
        {
            return UomComboBox.GetValue();
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
        /// Get the VTag expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">VTag UOM key</param>
        /// <returns>Key value</returns>
        public string GetVTagUOMExpectedValue(string itemKey)
        {
            return UomComboBox.GetActualValue(itemKey);
        }

        /// <summary>
        /// Get the VTag CalculationStep actual value
        /// </summary>
        /// <returns></returns>
        public string GetVTagCalculationStepValue()
        {
            return CalculationStepComboBox.GetValue();
        }

        /// <summary>
        /// Get the VTag expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">VTag calculation step key</param>
        /// <returns>Key value</returns>
        public string GetVTagCalculationStepExpectedValue(string itemKey)
        {
            return CalculationTypeComboBox.GetActualValue(itemKey);
        }

        /// <summary>
        /// Get the VTag CalculationType actual value
        /// </summary>
        /// <returns></returns>
        public string GetVTagCalculationTypeValue()
        {
            return CalculationTypeComboBox.GetValue();
        }

        /// <summary>
        /// Get the VTag expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">VTag calculation type key</param>
        /// <returns>Key value</returns>
        public string GetVTagCalculationTypeExpectedValue(string itemKey)
        {
            return CalculationTypeComboBox.GetActualValue(itemKey);
        }

        /// <summary>
        /// Get the VTag Comment actual value
        /// </summary>
        /// <returns></returns>
        public string GetVTagCommentValue()
        {
            return CommentTextField.GetValue();
        }
        #endregion

        #region Formula Operations

        /// <summary>
        /// Click "Modify" formula Button
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public void ClickModifyFormulaButton()
        {
            VTagSettingsFormulaUpdate.Click();
        }

        /// <summary>
        /// Click save button for formula
        /// </summary>
        /// <returns></returns>
        public void ClickSaveFormulaButton()
        {
            VTagSettingsFormulaSave.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        /// <summary>
        /// Simulate the mouse drag formula tag list to formula field
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public void DragTagToFormula(string ptagName)
        {
            var ptagRow = FormulaPTagList.GetRow(1, ptagName);
            FormulaField.DragTagIn(ptagRow);
        }

        /// <summary>
        /// Judge whether tag on formula tag list
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public Boolean IsTagNameOnFormulaTagList(string tagName)
        {
            try
            {
                FormulaPTagList.GetRow(1, tagName);
                return true;
            }
            catch(Exception)
            {
                return false;
            }      
        }

        public void GotoPageOnFormulaTaglist(int pageIndex)
        {
            FormulaPTagList.GotoPage(pageIndex);
        }

        /// <summary>
        /// Fill the text to formula field, clear the field first, then input text
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public void FillInFormulaField(string context)
        {
            FormulaField.Fill(context);
        }

        /// <summary>
        /// Append the text to formula field, not clear the field first, input text to the end
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public void AppendFormulaField(string context)
        {
            FormulaField.Append(context);
        }

        /// <summary>
        /// Get the value from formula field
        /// </summary>
        /// <returns></returns>
        public string GetFormulaValue()
        {
            return FormulaField.GetValue();
        }

        public void ViewTagByName(string tagName)
        {
            string scriptString = "arguments[0].scrollIntoView();";

            var tagRow = FormulaPTagList.GetRow(1, tagName);

            FormulaPTagList.ExecuteJavaScriptOnControl(scriptString, tagRow);
        }

        public void ViewTagByCode(string tagCode)
        {
            string scriptString = "arguments[0].scrollIntoView();";

            var tagRow = FormulaPTagList.GetRow(2, tagCode);

            FormulaPTagList.ExecuteJavaScriptOnControl(scriptString, tagRow);
        }

        #endregion

        #region Verification

        /// <summary>
        /// Judge whether the textfield and its label are hidden
        /// </summary>
        /// <returns>True if it is hidden, false if not</returns>
        public Boolean IsCommentHidden()
        {
            return CommentTextField.IsTextFieldHidden();
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
        /// <param name="output">VtagExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsNameInvalidMsgCorrect(VtagOuputData output)
        {
            return NameTextField.GetInvalidTips().Contains(output.CommonName);
        }

        /// <summary>
        /// Judge whether the code textfield is invalid
        /// </summary>
        /// <returns>True if the code is invalid, false if not</returns>
        public Boolean IscodeInvalid()
        {
            return codeTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of code field is correct
        /// </summary>
        /// <param name="output">VtagExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IscodeInvalidMsgCorrect(VtagOuputData output)
        {
            return codeTextField.GetInvalidTips().Contains(output.Code);
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
        /// <param name="output">VtagExpectedData</param>
        /// <returns>whether the invalid message is true</returns>
        public Boolean IsCommentsInvalidMsgCorrect(VtagOuputData output)
        {
            return CommentTextField.GetInvalidTips().Contains(output.Comment);
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
        /// <param name="output">VtagExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsCommodityInvalidMsgCorrect(VtagOuputData output)
        {
            return CommodityComboBox.GetInvalidTips().Contains(output.Commodity);
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
        /// <param name="output">VtagExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsUomInvalidMsgCorrect(VtagOuputData output)
        {
            return UomComboBox.GetInvalidTips().Contains(output.UOM);
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
        /// <param name="output">VtagExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsCalculationTypeInvalidMsgCorrect(VtagOuputData output)
        {
            return CalculationTypeComboBox.GetInvalidTips().Contains(output.CalculationType);
        }

        /*
        /// <summary>
        /// Clear the FormulaField
        /// </summary>
        /// <param name="output">VtagExpectedData</param>
        /// <returns>Clear FormulaField </returns>
        public Boolean ClearFormulaBlank(VtagOuputData output)
        {
            //return FormulaField.GetValue().Remove();
        }
         */
        #endregion

    
    }

}
