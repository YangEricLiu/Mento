using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

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
    }
}
