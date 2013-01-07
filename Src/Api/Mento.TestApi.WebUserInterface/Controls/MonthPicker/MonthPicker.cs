using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class MonthPicker : JazzControl
    {
        protected IWebElement SelectTrigger 
        {
            get 
            {
                return FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.MonthPickerTrigger));
            }
        }

        protected IWebElement SelectInput
        {
            get
            {
                return FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.MonthPickerInput));
            }
        }

        public MonthPicker(Locator locator) : base(locator) { }


        /// <summary>
        /// Simulate the mouse open monthpicker drop down menu
        /// </summary>
        /// <returns></returns>
        public void DisplayItems()
        {
            this.SelectTrigger.Click();
        }

        /// <summary>
        /// Simulate the mouse select year item from monthpicker drop down list
        /// </summary>
        /// <param name="key">combo box element key</param>
        /// <returns></returns>
        public void SelectYearItem(string itemKey)
        {
            var locator = GetMonthPickerYearLocator(itemKey);

            if (!ElementHandler.Displayed(locator))
                DisplayItems();

            FindChild(locator).Click();
        }

        /// <summary>
        /// Get the value of monthpicker
        /// </summary>
        /// <returns>Monthpicker value</returns>
        public string GetValue()
        {
            return SelectInput.GetAttribute("value");
        }

        protected virtual Locator GetMonthPickerYearLocator(string itemKey)
        {
            return null;
        }
    }
}
