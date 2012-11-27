using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Utility;
using Mento.Framework;
using Mento.Framework.Constants;

namespace Mento.TestApi.WebUserInterface
{
    /// <summary>
    /// Include the basic action of the button.
    /// </summary>
    /// <remarks>Inherited from control base class.</remarks>
    public class ComboBox : JazzControlBase
    {
        private Dictionary<string, string> itemList = ComboBoxItemListReader.GetValueXML(ConfigurationKey.COMBOPATH, ConfigurationKey.COMBOMODULE);

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
        /// <param name="key">combo box element key</param>
        /// <returns></returns>
        public void SelectItem(string key)
        {
            var locator = ElementDictionary[key];

            ElementLocator.FindElement(locator).Click();
        }

        /// <summary>
        /// Get the value of combo box
        /// </summary>
        /// <param name="key">combo box element key</param>
        /// <returns>Combo box value</returns>
        public string GetValue(string key)
        {
            var locator = ElementDictionary[key];

            return ElementLocator.FindElement(locator).GetAttribute("value");
        }

        /// <summary>
        /// Get the value of test data type key
        /// </summary>
        /// <param name="key">combo box element key</param>
        /// <returns>Key value</returns>
        public string GetItemTypeLangValue(string key)
        {
            return itemList[key];
        }
    }
}
