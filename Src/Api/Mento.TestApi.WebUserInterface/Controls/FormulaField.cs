using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.Utility;

namespace Mento.TestApi.WebUserInterface
{
    /// <summary>
    /// Include the basic action of the formula field.
    /// </summary>
    /// <remarks>Inherited from control class TextField.</remarks>
    public class FormulaField : TextField
    {
        /// <summary>
        /// Simulate the mouse drag formula tag list to formula field
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public void DragTag(string tagName)
        {
            var tagLocator = this.GetVariableLocator(ElementKey.FormulaTagRow, ManualElementName.tagName, tagName);
            var formulaLocator = ElementDictionary[ElementKey.FormulaField];

            IWebElement tagElement = ElementLocator.FindElement(tagLocator);
            IWebElement formulaElement = ElementLocator.FindElement(formulaLocator);

            ElementLocator.FocusOn(tagElement);
            ElementLocator.DragAndDrop(tagElement, formulaElement);
        }

        /// <summary>
        /// Get the text value of formula field
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public string GetValue()
        {
            var formulaLocator = ElementDictionary[ElementKey.FormulaField];

            return ElementLocator.FindElement(formulaLocator).GetAttribute("value");
        }
    }
}
