using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Administration.Tag.VtagManagement;

namespace Mento.ScriptCommon.Library.Functions
{
    //Click Vtag config button
        public void ClickVtagConfigButton()
        {
            var locator = ElementDictionary[ElementKey.VtagConfigButton];

            ElementLocator.FindElement(locator).Click();
            FunctionWrapper.WaitForLoadingDisappeared(2000);
        }
        
        //Click Add Vtag button to pop up Vtag add window.
        public void ClickAddVtagButton()
        {
            var locator = ElementDictionary[ElementKey.AddVtagButton];

            ElementLocator.FindElement(locator).Click();
            FunctionWrapper.WaitForLoadingDisappeared(2000);
        }
    /// <summary>
    /// The business logic for Vtag creation.
    /// </summary>
    public class Vtag
    {
        private Dictionary<string, Locator> ElementDictionary = ResourceManager.GetElementDictionary();
        
        private TextField textFieldInstance = ControlAccess.GetControl<TextField>();
        private ComboBox comboBoxInstance = ControlAccess.GetControl<ComboBox>();
        private Navigator navigatorInstance = ControlAccess.GetControl<Navigator>();
        /// <summary>
        /// Click add vtag button
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// Click save button to add new Vtag node
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            var locator = ElementDictionary[ElementKey.VtagSaveButton];

            ElementLocator.FindElement(locator).Click();
        }

        /// <summary>
        /// Click cancel button to cancel add new Vtag node
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCancelButton()
        {
            var locator = ElementDictionary[ElementKey.VtagCancelButton];

            ElementLocator.FindElement(locator).Click();
        }

        /// <summary>
        /// Input name, code, commodity, uom, step, calculationstep and comment to add new Vtag
        public void FillInAddVtagData(string VtagInputData, VtagInputData input)
        {
            
            textFieldInstance.FillIn(ElementKey.VtagName, input.Name);
            textFieldInstance.FillIn(ElementKey.VtagCode, input.Code);
            comboBoxInstance.DisplayItems(ElementKey.VtagCommodity);
            comboBoxInstance.SelectItem(input.Commodity);
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
        /// Input code of the new Vtag node 
        /// </summary>
        /// <param name="code">Vtag code</param>
        /// <returns></returns>
        public void FillInCode(string code)
        {
            textFieldInstance.FillIn(ElementKey.VtagCode, code);
        }

        /// <summary>
        /// Input type of the new Vtag node 
        /// </summary>
        /// <param name="Commodity">Vtag commodity</param>
        /// <returns></returns>
        public void FillInCommodity(string Commodity)
        {
            comboBoxInstance.DisplayItems(ElementKey.VtagCommodity);
            comboBoxInstance.SelectItem(Commodity);
        }

        /// <summary>
        /// Input comment of the new Vtag 
        /// </summary>
        /// <param name="code">Vtag comment code</param>
        /// <returns></returns>
        public void FillInComment(string comment)
        {
            textFieldInstance.FillIn(ElementKey.VtagComment, comment);
        }

        /// <summary>
        /// After click save button, waiting for add successful message box pop up
        /// </summary>
        /// <param name="timeout">Waiting time</param>
        /// <returns></returns>
        public void WaitForCreateOKDisplay(int timeout)
        {
            var locator = ElementDictionary[ElementKey.VtagCreateOKText];

            ElementLocator.WaitForElement(locator, timeout);
        }*/
        
    }
}
