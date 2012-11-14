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
       
        /// <summary>
        /// Click add vtag configue button
        /// </summary>
        /// <returns></returns>
        /// <summary>
        public void ClickVtagConfigButton()
        {
            var locator = ElementDictionary[ElementKey.VtagConfigButton];

            ElementLocator.FindElement(locator).Click();
            FunctionWrapper.WaitForLoadingDisappeared(1000);
        }

        /// <summary>
        /// Click add vtag add button
        /// </summary>
        /// <returns></returns>
        /// <summary>
        public void ClickAddVtagButton()
        {
            var locator = ElementDictionary[ElementKey.AddVtagButton];

            ElementLocator.FindElement(locator).Click();
            FunctionWrapper.WaitForLoadingDisappeared(1000);
        }
       
        /// <summary>
        /// Click add vtag save button
        /// </summary>
        /// <returns></returns>
        /// <summary>
        public void ClickSaveButton()
        {
            var locator = ElementDictionary[ElementKey.VtagSaveButton];

            ElementLocator.FindElement(locator).Click();
            FunctionWrapper.WaitForLoadingDisappeared(1000);
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
            FunctionWrapper.WaitForLoadingDisappeared(1000);
        }

        /// <summary>
        /// Input name, code, commodity, uom, step, calculationstep and comment to add new Vtag
        public void FillInAddVtagData(string VtagInputData, VtagInputData input)
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
       
        public void FillInName(string name)
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
        /// Input type of the new Vtag 
        /// </summary>
        /// <param name="Commodity">Vtag commodity</param>
        /// <returns></returns>
        public void FillInCommodity(string Commodity)
        {
            comboBoxInstance.DisplayItems(ElementKey.VtagCommodity);
            comboBoxInstance.SelectItem(Commodity);
        }

        /// <summary>
        /// Input type of the new Vtag 
        /// </summary>
        /// <param name="Commodity">Vtag commodity</param>
        /// <returns></returns>
        public void FillinVtagUOM(string UOM)
        {
            comboBoxInstance.DisplayItems(ElementKey.VtagUOM);
            comboBoxInstance.SelectItem(UOM);
        }

        /// <summary>
        /// Input type of the new Vtag 
        /// </summary>
        /// <param name="Commodity">Vtag Calculation type</param>
        /// <returns></returns>
        public void FillInVtagCalculationStep(string CalculationStep)
        {
            comboBoxInstance.DisplayItems(ElementKey.VtagCalculationStep);
            comboBoxInstance.SelectItem(CalculationStep); ;
        }

        /// <summary>
        /// Input CalculationStep of the new Vtag 
        /// </summary>
        /// <param name="Commodity">Vtag Calculation step</param>
        /// <returns></returns>
        public void FillInCalculationType(string VtagCalculationType)
        {
            comboBoxInstance.DisplayItems(ElementKey.VtagCalculationType);
            comboBoxInstance.SelectItem(VtagCalculationType); ;
        }

        /// <summary>
        /// Input comment of the new Vtag 
        /// </summary>
        /// <param name="code">Vtag comment</param>
        /// <returns></returns>
        public void FillInComment(string Comment)
        {
            textFieldInstance.FillIn(ElementKey.VtagComment, Comment);
        }
        
    }
}
