using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface
{
    /// <summary>
    /// Include the basic action of the button.
    /// </summary>
    /// <remarks>Inherited from control base class.</remarks>
    public class Button : JazzControlBase
    {
        /// <summary>
        /// Simulate the mouse click the button
        /// </summary>
        /// <param name="buttonLocator"></param>
        /// <returns></returns>
        public void ClickButton(Locator buttonLocator)
        {
            ElementLocator.FindElement(buttonLocator).Click();
        }

        /// <summary>
        /// Simulate the mouse float the button
        /// </summary>
        /// <param name="buttonLocator"></param>
        /// <returns></returns>
        public void FloatOnButton(Locator buttonLocator)
        {
            ElementLocator.FloatOn(ElementLocator.FindElement(buttonLocator));
        }

        /// <summary>
        /// Get the text value of the button
        /// </summary>
        /// <param name="buttonLocator"></param>
        /// <returns>the text value of this button</returns>
        public string GetButtonValue(Locator buttonLocator)
        {
            return ElementLocator.FindElement(buttonLocator).Text;
        }
    }
}
