using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Utility;
using Mento.Framework;

namespace Mento.TestApi.WebUserInterface
{
    /// <summary>
    /// Include the basic action of the button.
    /// </summary>
    /// <remarks>Inherited from control base class.</remarks>
    public class ComboBox : JazzControlBase
    {
        /// <summary>
        /// Simulate the mouse open combo box drop down menu
        /// </summary>
        /// <param name="itemButton"></param>
        /// <returns></returns>
        public void DisplayItems(string itemButton)
        {
            var locator = ElementDictionary[itemButton];

            ElementLocator.FindElement(locator).Click();
        }

        /// <summary>
        /// Simulate the mouse select one item from drop down list
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void SelectItem(string item)
        {
            var locator = ElementDictionary[item];

            ElementLocator.FindElement(locator).Click();
        }
    }
}
