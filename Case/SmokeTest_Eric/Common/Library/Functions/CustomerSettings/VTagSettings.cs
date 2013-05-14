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
using Mento.ScriptCommon.TestData.SmokeTest;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class VTagSettings
    {
        internal VTagSettings()
        {
        }

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
        private static TextField CodeTextField = JazzTextField.VTagSettingsCodeTextField;
        private static ComboBox CommodityComboBox = JazzComboBox.VTagSettingsCommodityComboBox;
        private static ComboBox UomComboBox = JazzComboBox.VTagSettingsUomComboBox;
        private static ComboBox CalculationTypeComboBox = JazzComboBox.VTagSettingsCalculationTypeComboBox;
        private static ComboBox CalculationStepComboBox = JazzComboBox.VTagSettingsCalculationStepComboBox;
        private static TextField CommentTextField = JazzTextField.VTagSettingsCommentTextField;

        private static Grid FormulaPTagList = JazzGrid.VTagSettingsFormulaEditPTagList;
        private static FormulaField FormulaField = JazzTextField.VFormulaField;

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
        public void FocusOnVTag(string vtagName)
        {
            VTagList.FocusOnRow(1, vtagName);
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
            NameTextField.Fill(input.Name);
            CodeTextField.Fill(input.Code);
            CommodityComboBox.SelectItem(input.Commodity);
            UomComboBox.SelectItem(input.UOM);
            CalculationStepComboBox.SelectItem(input.Step);
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
        public void FillInCode(string code)
        {
            CodeTextField.Fill(code);
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
        /// Get the VTag Code actual value
        /// </summary>
        /// <returns></returns>
        public string GetVTagCodeValue()
        {
            return CodeTextField.GetValue();
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
        /// Select one tag, open formula tab and click update button
        /// </summary>
        /// <param name="tagName">Tag name</param>
        /// <returns></returns>
        public void PrepareToAddFormula(string tagName)
        {
            FocusOnVTag(tagName);
            SwitchToFormulaTab();

            JazzMessageBox.LoadingMask.WaitLoading(maxtime: 2);
            TimeManager.ShortPause();

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
        #endregion
    }

}
