using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.Framework.Constants;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class MonthPicker : JazzControl
    {
        private const string MONTHPICKERITEMVARIABLENAME = "itemKey";

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
        /// Simulate the mouse select year and month item from monthpicker drop down list
        /// </summary>
        /// <param name="date">date</param>
        /// <returns></returns>
        public void SelectYearMonthItem(DateTime date)
        {
            SelectYearItem(date.Year.ToString());
            SelectMonthItem(date.Month.ToString());

            ClickConfirmButton();
        }

        /// <summary>
        /// Simulate the mouse select month item from monthpicker drop down list
        /// </summary>
        /// <param name="key">month picker month element key</param>
        /// <returns></returns>
        private void SelectMonthItem(string itemKey)
        {
            string newItemKey = Project.LanguagePrefix + itemKey;

            var locator = GetMonthPickerMonthLocator(newItemKey);

            if (!ElementHandler.Displayed(locator))
                DisplayItems();

            FindChild(locator).Click();
        }

        /// <summary>
        /// Simulate the mouse select year item from monthpicker drop down list
        /// </summary>
        /// <param name="key">month picker year element key</param>
        /// <returns></returns>
        private void SelectYearItem(string itemKey)
        {
            var locator = GetMonthPickerYearLocator(itemKey);

            if (!ElementHandler.Displayed(locator))
                DisplayItems();

            ImplementNavigatorNumber(itemKey);
            FindChild(locator).Click();
        }

        /// <summary>
        /// Navigate to the correct year 
        /// </summary>
        /// <param name="year">month picker year</param>
        /// <returns></returns>
        private void ImplementNavigatorNumber(string year)
        {
            int number = Convert.ToInt32(year);

            if (number < 2009)
            {
                int prevNumber = ((2009 - number) / 10) + 1;

                for (int i = 0; i < prevNumber; i++)
                {
                    ClickPreviousNavigator();
                    TimeManager.ShortPause();
                }
            }
            else if (number > 2018)
            {
                int nextNumber = ((number - 2018) / 10) + 1;

                for (int i = 0; i < nextNumber; i++)
                {
                    ClickNextNavigator();
                    TimeManager.ShortPause();
                }
            }
        }

        protected virtual void ClickPreviousNavigator()
        {
            var locator = ControlLocatorRepository.GetLocator(ControlLocatorKey.MonthPickerPreviousNavigator);

            FindChild(locator).Click();
        }

        protected virtual void ClickNextNavigator()
        {
            var locator = ControlLocatorRepository.GetLocator(ControlLocatorKey.MonthPickerNextNavigator);

            FindChild(locator).Click();
        }

        protected virtual void ClickConfirmButton()
        {
            var locator = ControlLocatorRepository.GetLocator(ControlLocatorKey.MonthPickerConfirm);

            FindChild(locator).Click();
        }

        protected virtual void ClickCanceLButton()
        {
            var locator = ControlLocatorRepository.GetLocator(ControlLocatorKey.MonthPickerCancel);

            FindChild(locator).Click();
        }

        /// <summary>
        /// Get the value of month picker
        /// </summary>
        /// <param name="key">month picker element key</param>
        /// <returns>month picker value</returns>
        public string GetValue()
        {
            return SelectInput.GetAttribute("value");
        }

        protected virtual Locator GetMonthPickerYearLocator(string itemKey)
        {
            string itemRealValue = ComboBoxItemRepository.GetComboBoxItemRealValue(itemKey);

            return Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.MonthPickerYearItem), MONTHPICKERITEMVARIABLENAME, itemRealValue); 
        }

        protected virtual Locator GetMonthPickerMonthLocator(string itemKey)
        {
            string itemRealValue = ComboBoxItemRepository.GetComboBoxItemRealValue(itemKey);

            return Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.MonthPickerMonthItem), MONTHPICKERITEMVARIABLENAME, itemRealValue); 
        }
    }
}
