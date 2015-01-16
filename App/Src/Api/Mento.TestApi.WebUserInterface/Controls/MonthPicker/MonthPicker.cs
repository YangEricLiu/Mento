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
        private Locator InvalidTips = new Locator("../../../../tbody/tr/td[contains(@class,'x-form-invalid-under')]", ByType.XPath);

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
        /// Return whether the value in text field is invalid
        /// </summary>
        /// <returns>True if invalid</returns>
        public bool IsMonthPickerValueInvalid()
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
            return FindChild(InvalidTips).Text;
        }
        
        /// <summary>
        /// Get the value of month picker
        /// </summary>
        /// <param name="key">month picker element key</param>
        /// <returns>date picker value</returns>
        public string GetValue()
        {
            return SelectInput.GetAttribute("value");
        }

        /// <summary>
        /// Get the value of month picker, then convert to DateTime
        /// </summary>
        /// <returns>month picker value</returns>
        private DateTime GetCurrentMonth()
        {
            string currentMonth = GetValue();

            if (!String.IsNullOrEmpty(currentMonth))
            {
                return ConvertStringToDateTime(currentMonth);
            }

            return DateTime.Now;
        }

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
        /// <param name="date">DateTime type</param>
        /// <returns></returns>
        public void SelectYearMonthItem(DateTime date)
        {
            if (!String.IsNullOrEmpty(date.ToString()))
            {
                SelectYearItem(date.Year.ToString());
                SelectMonthItem(date.Month.ToString());

                ClickConfirmButton();
            }
        }

        /// <summary>
        /// Simulate the mouse select year and month item from monthpicker drop down list
        /// </summary>
        /// <param name="date">string type</param>
        /// <returns></returns>
        public void SelectYearMonthItem(string date)
        {
            if (!String.IsNullOrEmpty(date))
            {
                DateTime dateTime = ConvertStringToDateTime(date);

                SelectYearItem(dateTime.Year.ToString());
                SelectMonthItem(dateTime.Month.ToString());

                ClickConfirmButton();
            }
        }

        /// <summary>
        /// Convert string "xxxx-xx-xx" to DateTime
        /// </summary>
        /// <param name="date">string type parameter, the date must be "xxxx-xx-xx"</param>
        /// <returns></returns>
        private DateTime ConvertStringToDateTime(string date)
        {
            string[] newDate = date.Split(new char[] { '-' });

            int year = Convert.ToInt32(newDate[0]);
            int month = Convert.ToInt32(newDate[1]);

            return new DateTime(year, month, 1);
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
            DateTime currentDate = GetCurrentMonth();

            //Have to modify it to current year, will fix this before 2014/03/01
            //int currentYear = 2014;
            int currentYear = DateTime.Now.Year;

            if (!String.IsNullOrEmpty(GetValue()))
            {
                currentYear = Convert.ToInt32(currentDate.Year.ToString());
            }           

            if (number < currentYear)
            {
                int prevNumber = ((currentYear - number + 5) / 10);
                int i = 0;

                while (i < prevNumber)
                {
                    ClickPreviousNavigator();
                    TimeManager.ShortPause();

                    i++;
                }
            }
            else if (number > currentYear)
            {
                int nextNumber = ((number - currentYear + 4) / 10);
                int j = 0;

                while (j < nextNumber)
                {
                    ClickNextNavigator();
                    TimeManager.ShortPause();

                    j++;
                }
            }
            else if (number == currentYear)
            {
                return;
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
