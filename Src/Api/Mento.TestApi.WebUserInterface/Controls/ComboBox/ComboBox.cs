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

        private IWebElement _SelectTrigger;
        protected IWebElement SelectTrigger 
        {
            get 
            {
                if (this._SelectTrigger == null)
                {
                    this._SelectTrigger = FindChild(LocatorRepository.GetLocator(LocatorKey.ComboBoxTrigger));
                }

                return this._SelectTrigger;
            }
        }

        private IWebElement _SelectInput;
        protected IWebElement SelectInput
        {
            get
            {
                if (this._SelectInput == null)
                {
                    this._SelectInput = FindChild(LocatorRepository.GetLocator(LocatorKey.ComboBoxInput));
                }

                return this._SelectInput;
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
            var locator = GetComboBoxItemLocator(itemKey);

            FindChild(locator).Click();
        }

        /// <summary>
        /// Get the value of combo box
        /// </summary>
        /// <param name="key">combo box element key</param>
        /// <returns>Combo box value</returns>
        public string GetValue(string key)
        {
            return SelectInput.GetAttribute("value");
        }

        /// <summary>
        /// Get the value of test data type key
        /// </summary>
        /// <param name="key">combo box element key</param>
        /// <returns>Key value</returns>
        [Obsolete]
        public string GetItemTypeLangValue(string itemKey)
        {
            return ComboBoxItemRepository.ComboBoxItemDictionary[itemKey];
        }

        protected virtual Locator GetComboBoxItemLocator(string itemKey)
        {
            string itemRealValue = ComboBoxItemRepository.ComboBoxItemDictionary[itemKey];

            return Locator.GetVariableLocator(LocatorRepository.GetLocator(LocatorKey.ComboBoxItem), COMBOBOXITEMVARIABLENAME, itemRealValue); 
        }
    }
}
