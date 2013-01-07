﻿using System;
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
    public class KPITagSettings
    {
        internal KPITagSettings()
        {
        }

        private static Grid KPITagList = JazzGrid.KPITagSettingsKPITagList;

        private static TabButton BasicPropertyTab = JazzButton.KPITagSettingsBasicPropertyTabButton;
        private static TabButton FormulaTab = JazzButton.KPITagSettingsFormulaTabButton;

        private static Button CreateKPITagButton = JazzButton.KPITagSettingsCreateKPITagButton;

        private static Button ModifyButton = JazzButton.KPITagSettingsModifyButton;
        private static Button SaveButton = JazzButton.KPITagSettingsSaveButton;
        private static Button CancelButton = JazzButton.KPITagSettingsCancelButton;
        private static Button DeleteButton = JazzButton.KPITagSettingsDeleteButton;

        private static TextField NameTextField = JazzTextField.KPITagSettingsNameTextField;
        private static TextField CodeTextField = JazzTextField.KPITagSettingsCodeTextField;
        private static ComboBox UomComboBox = JazzComboBox.KPITagSettingsUomComboBox;
        private static ComboBox CalculationTypeComboBox = JazzComboBox.KPITagSettingsCalculationTypeComboBox;
        private static ComboBox CalculationStepComboBox = JazzComboBox.KPITagSettingsCalculationStepComboBox;
        private static TextField CommentTextField = JazzTextField.KPITagSettingsCommentTextField;

        private static Grid FormulaPTagList = JazzGrid.KPITagSettingsFormulaEditPTagList;
        private static FormulaField FormulaField = JazzTextField.KPIFormulaField;

        #region KPITag List Operations
        /// <summary>
        /// Navigate to KPITag settings
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToKPITagSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsKPI);
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
        public void ClickAddKPITagButton()
        {
            CreateKPITagButton.Click();
        }

        /// <summary>
        /// Select one tag
        /// </summary>
        /// <param name="vtagName">VTag name</param>
        /// <returns></returns>
        public void FocusOnKPITag(string kpitagName)
        {
            KPITagList.FocusOnRow(1, kpitagName);
        }
        #endregion

        #region Basic Property Operations
        /// <summary>
        /// Click add kpitag save button
        /// </summary>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            SaveButton.Click();
        }

        /// <summary>
        /// Click cancel button to cancel add new KPITag
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
        public void FillInAddKPItagData(KPIInputData input)
        {
            //textFieldInstance.FillIn(ElementKey.KPItagName, input.Name);
            //textFieldInstance.FillIn(ElementKey.KPItagCode, input.Code);
            //comboBoxInstance.SelectItem(input.Commodity);
            //comboBoxInstance.DisplayItems(ElementKey.KPItagUOM);
            //comboBoxInstance.SelectItem(input.UOM);
            //comboBoxInstance.DisplayItems(ElementKey.KPItagCalculationStep);
            //comboBoxInstance.SelectItem(input.Steps);
            //comboBoxInstance.DisplayItems(ElementKey.KPItagCalculationType);
            //comboBoxInstance.SelectItem(input.CalculationType);
            //textFieldInstance.FillIn(ElementKey.KPItagComment, input.Comment);

            NameTextField.Fill(input.Name);
            CodeTextField.Fill(input.Code);
            UomComboBox.SelectItem(input.Uom);
            CalculationStepComboBox.SelectItem(input.Steps);
            CalculationTypeComboBox.SelectItem(input.CalculationType);
            CommentTextField.Fill(input.Comment);
        }

        /// <summary>
        /// Input name of the new KPITag 
        /// </summary>
        /// <param name="name">KPITag name</param>
        /// <returns></returns>
        public void FillInName(String name)
        {
            NameTextField.Fill(name);
        }

        /// <summary>
        /// Input code of the new KPITag 
        /// </summary>
        /// <param name="code">KPITag code</param>
        /// <returns></returns>
        public void FillInCode(string code)
        {
            CodeTextField.Fill(code);
        }

        /// <summary>
        /// Input comment of the new KPITag 
        /// </summary>
        /// <param name="comment">KPITag comment</param>
        /// <returns></returns>
        public void FillInComment(string comment)
        {
            CommentTextField.Fill(comment);
        }

        /// <summary>
        /// Get the KPITag Name actual value
        /// </summary>
        /// <returns></returns>
        public string GetKPITagNameValue()
        {
            return NameTextField.GetValue();
        }

        /// <summary>
        /// Get the KPITag Code actual value
        /// </summary>
        /// <returns></returns>
        public string GetKPITagCodeValue()
        {
            return CodeTextField.GetValue();
        }

        /// <summary>
        /// Get the KPITag UOM actual value
        /// </summary>
        /// <returns></returns>
        public string GetKPITagUOMValue()
        {
            return UomComboBox.GetValue();
        }

        /// <summary>
        /// Get the KPITag expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">KPITag UOM key</param>
        /// <returns>Key value</returns>
        public string GetKPITagUOMExpectedValue(string itemKey)
        {
            return UomComboBox.GetActualValue(itemKey);
        }

        /// <summary>
        /// Get the KPITag CalculationStep actual value
        /// </summary>
        /// <returns></returns>
        public string GetKPITagCalculationStepValue()
        {
            return CalculationStepComboBox.GetValue();
        }

        /// <summary>
        /// Get the KPITag expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">KPITag calculation step key</param>
        /// <returns>Key value</returns>
        public string GetKPITagCalculationStepExpectedValue(string itemKey)
        {
            return CalculationTypeComboBox.GetActualValue(itemKey);
        }

        /// <summary>
        /// Get the KPITag CalculationType actual value
        /// </summary>
        /// <returns></returns>
        public string GetKPITagCalculationTypeValue()
        {
            return CalculationTypeComboBox.GetValue();
        }

        /// <summary>
        /// Get the KPITag expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">KPITag calculation type key</param>
        /// <returns>Key value</returns>
        public string GetKPITagCalculationTypeExpectedValue(string itemKey)
        {
            return CalculationTypeComboBox.GetActualValue(itemKey);
        }

        /// <summary>
        /// Get the KPITag Comment actual value
        /// </summary>
        /// <returns></returns>
        public string GetKPITagCommentValue()
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
            FocusOnKPITag(tagName);
            SwitchToFormulaTab();

            JazzMessageBox.LoadingMask.WaitLoading(maxtime: 2);
            TimeManager.ShortPause();

            JazzButton.KPITagSettingsFormulaUpdate.Click();
        }

        /// <summary>
        /// Click save button for formula
        /// </summary>
        /// <returns></returns>
        public void ClickSaveFormulaButton()
        {
            JazzButton.KPITagSettingsFormulaSave.Click();
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
