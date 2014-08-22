using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class Button : JazzControl
    {
        protected IWebElement ButtonInput
        {
            get 
            {
                return FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.ButtonInput));
            }
        }

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
            ElementHandler.Click(this.RootElement);
            //this.RootElement.Click();
        }

        /// <summary>
        /// Simulate the mouse ClickAndHold the button
        /// </summary>
        /// <returns></returns>
        public void ClickAndHold()
        {
            ElementHandler.ClickAndHold(this.RootElement);
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
        /// <returns>True if the button is enable, false if not </returns>
        public bool IsEnabled()
        {
            return this.ButtonInput.Enabled;
        }

        public bool IsDisplayed()
        {
            return this.RootElement.Displayed;
        }

        /// <summary>
        /// Judge if the button is pressed
        /// </summary>
        /// <returns>True if the button is pressed, false if not </returns>
        public bool IsPressed()
        {
            return this.RootElement.GetAttribute("class").Contains("x-toggle x-btn-toggle x-btn-default-medium-toggle");
        }

        public bool IsExisted()
        {
            return ElementHandler.Exists(this._RootLocator);
        }

        
    }
}
