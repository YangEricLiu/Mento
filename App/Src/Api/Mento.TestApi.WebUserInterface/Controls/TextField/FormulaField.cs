using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Mento.TestApi.WebUserInterface.Controls
{
    /// <summary>
    /// FormulaField is a textarea
    /// </summary>
    public class FormulaField : TextField
    {        
        public FormulaField() : base(ControlLocatorRepository.GetLocator(ControlLocatorKey.FormulaTextBox)) { }
        
        /// <summary>
        /// Simulate the mouse drag formula tag list to formula field
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public void DragTagIn(IWebElement tagRowElement)
        {
            ElementHandler.DragAndDrop(tagRowElement, this.RootElement);
        }
        /// <summary>
        /// Return the invalid input tooltips info
        /// </summary>
        /// <returns>the invalid input tooltips info</returns>
        public string GetInvalidTips()
        {
            return this.RootElement.GetAttribute("data-errorqtip");
        }
    }
}
