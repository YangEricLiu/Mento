using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Collections;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class ComboBox : JazzControl
    {
        private const string COMBOBOXITEMVARIABLENAME = "itemKey";

        protected IWebElement SelectTrigger 
        {
            get 
            {
                return FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.ComboBoxTrigger));
            }
        }

        protected IWebElement SelectInput
        {
            get
            {
                return FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.ComboBoxInput));
            }
        }

        protected IWebElement[] CurrentComboBoxDropdownListItems
        {
            get
            {
                return FindChildren(ControlLocatorRepository.GetLocator(ControlLocatorKey.ComboBoxDropdownListItems));
            }
        }

        public ComboBox(Locator locator) : base(locator) { }


        /// <summary>
        /// Simulate the mouse open combo box drop down menu
        /// </summary>
        /// <param name="itemButton"></param>
        /// <returns></returns>
        public void DisplayItems()
        {
            this.SelectTrigger.Click();
        }

        /// <summary>
        /// Simulate the mouse select one item from drop down list
        /// </summary>
        /// <param name="key">combo box element key</param>
        /// <returns></returns>
        public void SelectItem(string itemKey)
        {
            if (!String.IsNullOrEmpty(itemKey))
            {
                var locator = GetComboBoxItemLocator(itemKey);

                if (!ElementHandler.Displayed(locator))
                    DisplayItems();

                FindChild(locator).Click();
            }
        }

        /// <summary>
        /// Get the items of current dropdown list
        /// </summary>
        /// <returns></returns>
        public ArrayList GetCurrentDropdownListItems()
        {
            ArrayList items = new ArrayList();
            
            foreach (IWebElement item in CurrentComboBoxDropdownListItems)
            { 
                items.Add(item.Text);
            }

            return items;
        }

        /// <summary>
        /// Get the value of combo box
        /// </summary>
        /// <param name="key">combo box element key</param>
        /// <returns>Combo box value</returns>
        public string GetValue()
        {
            return SelectInput.GetAttribute("value");
        }

        /// <summary>
        /// Get the value of test data type key
        /// </summary>
        /// <param name="key">combo box element key</param>
        /// <returns>Key value</returns>
        public string GetActualValue(string itemKey)
        {
            return ComboBoxItemRepository.GetComboBoxItemRealValue(itemKey);
        }

        protected virtual Locator GetComboBoxItemLocator(string itemKey)
        {
            string itemRealValue = ComboBoxItemRepository.GetComboBoxItemRealValue(itemKey);

            return Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.ComboBoxItem), COMBOBOXITEMVARIABLENAME, itemRealValue); 
        }
        /// <summary>
        /// Return whether the value in text field is invalid
        /// </summary>
        /// <returns>True if invalid</returns>
        public bool IsComboBoxValueInvalid()
        {
            string invalid = SelectInput.GetAttribute("aria-invalid");

            return String.Equals(invalid, "true", StringComparison.OrdinalIgnoreCase);
        }
        /// <summary>
        /// Return the invalid input tooltips info
        /// </summary>
        /// <returns>the invalid input tooltips info</returns>
        public string GetInvalidTips()
        {
            return this.SelectInput.GetAttribute("data-errorqtip");
        }
    }
}
