using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic for Vtag creation.
    /// </summary>
    public class Vtag
    {
        private static Dictionary<string, Locator> ElementDictionary = ResourceManager.GetElementDictionary();
        
 /*       private static Dictionary<string, Locator> ElementDictionary = ResourceManager.GetElementDictionary();

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
            var locator = ElementDictionary[ElementKey.];

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
        /// Input name, code type and comments of the new Vtag node 
        /// </summary>
        /// <param name="treeNodeName">Parent Vtag node name</param>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInVtagNode(string treeNodeName, VtagInputData input)
        {
            PrepareToAddNode(treeNodeName);

            textFieldInstance.FillIn(ElementKey.VtagName, input.Name);
            textFieldInstance.FillIn(ElementKey.VtagCode, input.Code);
            comboBoxInstance.DisplayItems(ElementKey.VtagType);
            comboBoxInstance.SelectItem(input.Type);
            textFieldInstance.FillIn(ElementKey.VtagComment, input.Comment);
        }

        /// <summary>
        /// Input name of the new Vtag node 
        /// </summary>
        /// <param name="name">Vtag node name</param>
        /// <returns></returns>

        public void FillInName(string name)
        {
            textFieldInstance.FillIn(ElementKey.VtagName, name);
        }

        /// <summary>
        /// Input code of the new Vtag node 
        /// </summary>
        /// <param name="code">Vtag node code</param>
        /// <returns></returns>
        public void FillInCode(string code)
        {
            textFieldInstance.FillIn(ElementKey.VtagCode, code);
        }

        /// <summary>
        /// Input type of the new Vtag node 
        /// </summary>
        /// <param name="type">Vtag node type</param>
        /// <returns></returns>
        public void FillInType(string type)
        {
            comboBoxInstance.DisplayItems(ElementKey.VtagType);
            comboBoxInstance.SelectItem(type);
        }

        /// <summary>
        /// Input comment of the new Vtag node 
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
