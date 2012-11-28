using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public abstract class Button : JazzControl
    {
        private const string BUTTONINPUTXPATH = "em/button";
        private static Locator ButtonInputLocator = new Locator(BUTTONINPUTXPATH, ByType.Xpath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locator">All ext button is wrappered with a div, the locator must be the div's locator</param>
        public Button(Locator locator)
            : base(locator)
        { 
        }

        /// <summary>
        /// Simulate the mouse click the button
        /// </summary>
        /// <returns></returns>
        public void Click()
        {
            this.RootElement.Click();
        }

        /// <summary>
        /// Simulate the mouse float the button
        /// </summary>
        public void Float()
        {
            ElementHandler.Float(this.RootElement);
        }
        
        /// <summary>
        /// Get the text value of the button
        /// </summary>
        /// <returns>the text value of this button</returns>
        public string GetText()
        {
            return this.RootElement.Text;
        }

        /// <summary>
        /// Judge if the button is enabled
        /// </summary>
        /// <returns>True if the button is enabl, false if not </returns>
        public bool IsEnabled()
        {
            return FindChild(ButtonInputLocator).Enabled;
        }
    }
}
