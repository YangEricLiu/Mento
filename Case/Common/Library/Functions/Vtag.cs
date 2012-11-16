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
using Mento.ScriptCommon.TestData.Administration.Tag.VtagManagement;

namespace Mento.ScriptCommon.Library.Functions
{

    public class Vtag
    {
        private Dictionary<string, Locator> ElementDictionary = ResourceManager.GetElementDictionary();

    /// <summary>
    /// The business logic for Vtag creation.
    /// </summary>
        
        private TextField textFieldInstance = ControlAccess.GetControl<TextField>();
        private ComboBox comboBoxInstance = ControlAccess.GetControl<ComboBox>();
        private Navigator navigatorInstance = ControlAccess.GetControl<Navigator>();
        private Grid tagInstance = ControlAccess.GetControl<Grid>();
        
       
        /// <summary>
        /// Click add vtag configue button
        /// </summary>
        /// <returns></returns>
        public void ClickVtagConfigButton()
        {
            var locator = ElementDictionary[ElementKey.VtagConfigButton];

            ElementLocator.FindElement(locator).Click();
        }

        /// <summary>
        /// Click add vtag add button
        /// </summary>
        /// <returns></returns>
        public void ClickAddVtagButton()
        {
            var locator = ElementDictionary[ElementKey.AddVtagButton];

            ElementLocator.FindElement(locator).Click();
        }
       
        /// <summary>
        /// Click add vtag save button
        /// </summary>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            var locator = ElementDictionary[ElementKey.VtagSaveButton];

            ElementLocator.FindElement(locator).Click();
        }

        /// <summary>
        /// Click cancel button to cancel add new Vtag
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCancelButton()
        {
            var locator = ElementDictionary[ElementKey.VtagCancelButton];

            ElementLocator.FindElement(locator).Click();
        }

        /// <summary>
        /// Input data
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void FillInAddVtagData(VtagInputData input)
        {
            
            textFieldInstance.FillIn(ElementKey.VtagName, input.Name);
            textFieldInstance.FillIn(ElementKey.VtagCode, input.Code);
            comboBoxInstance.DisplayItems(ElementKey.VtagCommodity);
            comboBoxInstance.SelectItem(input.Commodity);
            comboBoxInstance.DisplayItems(ElementKey.VtagUOM);
            comboBoxInstance.SelectItem(input.UOM);
            comboBoxInstance.DisplayItems(ElementKey.VtagCalculationStep);
            comboBoxInstance.SelectItem(input.Step);
            comboBoxInstance.DisplayItems(ElementKey.VtagCalculationType);
            comboBoxInstance.SelectItem(input.CalculationType);
            textFieldInstance.FillIn(ElementKey.VtagComment, input.Comment);

        }

        /// <summary>
        /// Input name of the new Vtag 
        /// </summary>
        /// <param name="name">Vtag name</param>
        /// <returns></returns>
        /// 
       
        public void FillInName(String name)
        {
            textFieldInstance.FillIn(ElementKey.VtagName, name);
        }

        /// <summary>
        /// Input code of the new Vtag 
        /// </summary>
        /// <param name="code">Vtag code</param>
        /// <returns></returns>
        public void FillInCode(string code)
        {
            textFieldInstance.FillIn(ElementKey.VtagCode, code);
        }

        /// <summary>
        /// Input comment of the new Vtag 
        /// </summary>
        /// <param name="comment">Vtag comment</param>
        /// <returns></returns>
        public void FillInComment(string comment)
        {
            textFieldInstance.FillIn(ElementKey.VtagComment, comment);
        }
        
        /// <summary>
        /// Select one tag
        /// </summary>
        /// <param name="VtagName">Vtag name</param>
        /// <returns></returns>
        public void FocusOnTag(string VtagName)
        {
            tagInstance.FocusOnRow(VtagName);
        }

        /// <summary>
        /// Get the Vtag Name actual value
        /// </summary>
        /// <returns></returns>
        public string GetVtagNameValue()
        {
            return textFieldInstance.GetValue(ElementKey.VtagName);
        }

        /// <summary>
        /// Get the Vtag Code actual value
        /// </summary>
        /// <returns></returns>
        public string GetVtagCodeValue()
        {
            return textFieldInstance.GetValue(ElementKey.VtagCode);
        }

        /// <summary>
        /// Get the Vtag Commodity actual value
        /// </summary>
        /// <returns></returns>
        public string GetVtagCommodityValue()
        {
            return textFieldInstance.GetValue(ElementKey.VtagCommodity);
        }

        /// <summary>
        /// Get the Vtag expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">Vtag commodity key</param>
        /// <returns>Key value</returns>
        public string GetVtagCommodityExpectedValue(string itemKey)
        {
            return comboBoxInstance.GetItemTypeLangValue(itemKey);
        }

        /// <summary>
        /// Get the Vtag UOM actual value
        /// </summary>
        /// <returns></returns>
        public string GetVtagUOMValue()
        {
            return textFieldInstance.GetValue(ElementKey.VtagUOM);
        }

        /// <summary>
        /// Get the Vtag expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">Vtag UOM key</param>
        /// <returns>Key value</returns>
        public string GetVtagUOMExpectedValue(string itemKey)
        {
            return comboBoxInstance.GetItemTypeLangValue(itemKey);
        }

        /// <summary>
        /// Get the Vtag CalculationStep actual value
        /// </summary>
        /// <returns></returns>
        public string GetVtagCalculationStepValue()
        {
            return textFieldInstance.GetValue(ElementKey.VtagCalculationStep);
        }

        /// <summary>
        /// Get the Vtag expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">Vtag calculation step key</param>
        /// <returns>Key value</returns>
        public string GetVtagCalculationStepExpectedValue(string itemKey)
        {
            return comboBoxInstance.GetItemTypeLangValue(itemKey);
        }

        /// <summary>
        /// Get the Vtag CalculationType actual value
        /// </summary>
        /// <returns></returns>
        public string GetVtagCalculationTypeValue()
        {
            return textFieldInstance.GetValue(ElementKey.VtagCalculationType);
        }

        /// <summary>
        /// Get the Vtag expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">Vtag calculation type key</param>
        /// <returns>Key value</returns>
        public string GetVtagCalculationTypeExpectedValue(string itemKey)
        {
            return comboBoxInstance.GetItemTypeLangValue(itemKey);
        }

        /// <summary>
        /// Get the Vtag Comment actual value
        /// </summary>
        /// <returns></returns>
        public string GetVtagCommentValue()
        {
            return textFieldInstance.GetValue(ElementKey.VtagComment);
        }
    }

}
