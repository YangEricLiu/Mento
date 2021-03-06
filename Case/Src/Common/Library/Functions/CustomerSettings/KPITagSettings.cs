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
        #region controls
        
        private static Grid KPITagList = JazzGrid.KPITagSettingsKPITagList;

        private static TabButton BasicPropertyTab = JazzButton.KPITagSettingsBasicPropertyTabButton;
        private static TabButton FormulaTab = JazzButton.KPITagSettingsFormulaTabButton;

        private static Button CreateKPITagButton = JazzButton.KPITagSettingsCreateKPITagButton;

        private static Button ModifyButton = JazzButton.KPITagSettingsModifyButton;
        private static Button SaveButton = JazzButton.KPITagSettingsSaveButton;
        private static Button CancelButton = JazzButton.KPITagSettingsCancelButton;
        private static Button DeleteButton = JazzButton.KPITagSettingsDeleteButton;
        private static Button FormulaCancel = JazzButton.KPITagSettingsFormulaCancel;
    
        private static TextField NameTextField = JazzTextField.KPITagSettingsNameTextField;
        private static TextField codeTextField = JazzTextField.KPITagSettingscodeTextField;
        private static TextField CommentTextField = JazzTextField.KPITagSettingsCommentTextField;
        private static ComboBox UomComboBox = JazzComboBox.KPITagSettingsUomComboBox;
        private static ComboBox CalculationTypeComboBox = JazzComboBox.KPITagSettingsCalculationTypeComboBox;
        private static ComboBox CalculationStepComboBox = JazzComboBox.KPITagSettingsCalculationStepComboBox;
        private Grid TagList = JazzGrid.KPITagSettingsKPITagList;
        private static Grid FormulaPTagList = JazzGrid.KPITagSettingsFormulaEditPTagList;
        private static FormulaField KPIFormulaField = JazzTextField.KPIFormulaField;
        private static CheckBoxField CheckBoxFieldDayNightKPITag = JazzCheckBox.CheckBoxFieldDayNightKPITag;

        #endregion

        #region KPITag List Operations
        /// <summary>
        /// Navigate to KPITag settings
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToKPITagSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsKPI);
            TimeManager.MediumPause();
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
        /// Select one tag through Tag name
        /// </summary>
        /// <param name="vtagName">KPITag name</param>
        /// <returns></returns>
        public void FocusOnKPITag(string kpitagName)
        {
            KPITagList.FocusOnRow(1, kpitagName);
        }
        /// <summary>
        /// Select one tag through Tag code
        /// </summary>
        /// <param name="kpitagName"></param>
        public void FocusOnKPITagcode(string kpitagcode)
        {
            KPITagList.FocusOnRow(2, kpitagcode);
        }
        /// <summary>
        /// Invalid code redline
        /// </summary>
        /// <param name="kpitagcode"></param>
        public bool Invalidcode()
        {
            return codeTextField.IsTextFieldValueInvalid();
        }
        /// <summary>
        /// Invalid name redline
        /// </summary>
        /// <returns></returns>
        public bool InvalidName()
        {
            return NameTextField.IsTextFieldValueInvalid();
        }
        /// <summary>
        /// Invalid UOM redline
        /// </summary>
        /// <returns></returns>
        public bool InvalidUOM()
        {
            return UomComboBox.IsComboBoxValueInvalid();
        }
        /// <summary>
        /// Invalid steps redline
        /// </summary>
        /// <returns></returns>
        public bool InvalidSteps()
        {
            return CalculationStepComboBox.IsComboBoxValueInvalid();
        }
        /// <summary>
        /// Invalid Type redline
        /// </summary>
        /// <returns></returns>
        public bool InvalidType()
        {
            return CalculationTypeComboBox.IsComboBoxValueInvalid();
        }
        #endregion

        #region Basic Property Operations
        /// <summary>
        /// After click confirm button,would display a messagebox
        /// </summary>
        /// <returns></returns>
        public string GetMessageText()
        {
            return JazzMessageBox.MessageBox.GetMessage();
        }
        /// <summary>
        /// Confirm messagebox
        /// </summary>
        /// <returns></returns>
        public void ConfirmMagBox()
        {
            JazzMessageBox.MessageBox.Confirm();
        }
        /// <summary>
        /// Confirm to delete
        /// </summary>
        /// <returns></returns>
        public void ConfirmDeleteMagBox()
        {
            JazzMessageBox.MessageBox.Confirm();
        }
        /// <summary>
        /// cancel to delete
        /// </summary>
        /// <returns></returns>
        public void CancelDeleteMagBox()
        {
            JazzMessageBox.MessageBox.Cancel();
        }
        /// <summary>
        /// Click modify kpitag  button
        /// </summary>
        /// <returns></returns>
       public void ClickModifyKPITagButton()
        {
            ModifyButton.Click();
        }
        public void ClickDeleteKPITagButton()
        {
            DeleteButton.Click();
        }
        
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
            //textFieldInstance.FillIn(ElementKey.KPItagcode, input.code);
            //comboBoxInstance.SelectItem(input.Commodity);
            //comboBoxInstance.DisplayItems(ElementKey.KPItagUOM);
            //comboBoxInstance.SelectItem(input.UOM);
            //comboBoxInstance.DisplayItems(ElementKey.KPItagCalculationStep);
            //comboBoxInstance.SelectItem(input.Steps);
            //comboBoxInstance.DisplayItems(ElementKey.KPItagCalculationType);
            //comboBoxInstance.SelectItem(input.CalculationType);
            //textFieldInstance.FillIn(ElementKey.KPItagComment, input.Comment);

            NameTextField.Fill(input.Name);
            codeTextField.Fill(input.code);
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
        public void FillIncode(string code)
        {
            codeTextField.Fill(code);
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
        /// Get the KPITag code actual value
        /// </summary>
        /// <returns></returns>
        public string GetKPITagcodeValue()
        {
            return codeTextField.GetValue();
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
        /// <summary>
        /// Get the KPITag name invalid message value
        /// </summary>
        /// <returns></returns>
        public string GetNameErrorMessageValue()
        {
            return NameTextField.GetInvalidTips();
        }
        /// <summary>
        /// Get the KPITag code invalid message value
        /// </summary>
        /// <returns></returns>
        public string GetcodeErrorMessageValue()
        {
            return codeTextField.GetInvalidTips();
        }
        /// <summary>
        /// Get the KPITag code invalid message value
        /// </summary>
        /// <returns></returns>
        public string GetCommentErrorMessageValue()
        {
            return CommentTextField.GetInvalidTips();
        }
        
        /// <summary>
        /// Get the KPITag Uom invalid message value
        /// </summary>
        /// <returns></returns>
        public string GetUomErrorMessageValue()
        {
            return UomComboBox.GetInvalidTips();
        }
        /// <summary>
        /// Get the KPITag step invalid message value
        /// </summary>
        /// <returns></returns>
        public string GetStepErrorMessageValue()
        {
            return CalculationStepComboBox.GetInvalidTips();
        }
        /// <summary>
        /// Get the KPITag type invalid message value
        /// </summary>
        /// <returns></returns>
        public string GetTypeErrorMessageValue()
        {
            return CalculationTypeComboBox.GetInvalidTips();
        }
        /// <summary>
        /// judge whether KPItag has been deleted
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public Boolean KPITagIsNotDeleted(string tagName)
        {
            return TagList.IsRowExist(3, tagName);
        }
        /// <summary>
        /// judge whether KPItag has been Created
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public Boolean KPITagIsExist(string tagcode)
        {
            return KPITagList.IsRowExist(2, tagcode);
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
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            SwitchToFormulaTab();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            JazzButton.KPITagSettingsFormulaUpdate.Click();
            //JazzMessageBox.LoadingMask.WaitLoading(maxtime: 2);
            //TimeManager.ShortPause();

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
        /// Click cancel modify formula button
        /// </summary>
        /// <returns></returns>
        public void ClickCancelFormula()
        {
            FormulaCancel.Click();
        }
        /// <summary>
        /// Simulate the mouse drag formula tag list to formula field
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public void DragTagToFormula(string ptagName)
        {
            var ptagRow = FormulaPTagList.GetRow(1, ptagName);
            KPIFormulaField.DragTagIn(ptagRow);
        }

        /// <summary>
        /// Fill the text to formula field, clear the field first, then input text
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public void FillInFormulaField(string context)
        {
            KPIFormulaField.Fill(context);
        }

        /// <summary>
        /// Append the text to formula field, not clear the field first, input text to the end
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public void AppendFormulaField(string context)
        {
            KPIFormulaField.Append(context);
        }

        /// <summary>
        /// Get the value from formula field
        /// </summary>
        /// <returns></returns>
        public string GetFormulaValue()
        {
            return KPIFormulaField.GetValue();

        }
        /// <summary>
        /// Get the KPITag formula invalid message value
        /// </summary>
        /// <returns></returns>
        public string GetFormulaErrorMessageValue()
        {
            return KPIFormulaField.GetInvalidTips();
        }
     
        #endregion
    }

}

