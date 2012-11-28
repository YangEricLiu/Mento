using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class FormulaField : TextField
    {
        private IWebElement _TextArea;
        protected IWebElement TextArea
        {
            get
            {
                if (this._TextArea == null)
                {
                    this._TextArea = FindChild(LocatorRepository.GetLocator(LocatorKey.FormulaTextArea));
                }

                return this._TextArea;
            }
        }
        
        public FormulaField() : base(LocatorRepository.GetLocator(LocatorKey.FormulaTextBox)) { }
        
        /// <summary>
        /// Simulate the mouse drag formula tag list to formula field
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public void DragTagIn(IWebElement tagRowElement)
        {
            ElementHandler.DragAndDrop(tagRowElement, this.TextArea);
        }

        /// <summary>
        /// Get the text value of formula field
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public string GetValue()
        {
            return this.TextArea.GetAttribute("value");
        }
    }
}
