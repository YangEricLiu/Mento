using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.Framework.Constants;
using Mento.Framework.Configuration;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class DatePicker : JazzControl
    {
        private const string DATEPICKERITEMVARIABLENAME = "itemKey";
        private const string YEARWORD = "年";
        private const string MONTHWORD = "月";
        private Locator InvalidTips = new Locator("../../../../tbody/tr/td[contains(@class,'x-form-invalid-under')]", ByType.XPath);

        private static Dictionary<string, string> MonthItem = new Dictionary<string, string>()
        {
            {"January", "1" },
            {"February", "2" },
            {"March", "3" },
            {"April", "4" },
            {"May", "5" },
            {"June", "6" },
            {"July", "7" },
            {"August", "8" },
            {"September", "9" },
            {"October", "10" },
            {"November", "11" },
            {"December", "12" },
        };

        protected IWebElement SelectTrigger 
        {
            get 
            {
                return FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.DatePickerTrigger));
            }
        }

        protected IWebElement SelectInput
        {
            get
            {
                return FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.DatePickerInput));
            }
        }

        /// <summary>
        /// Return whether the value in date field is invalid
        /// </summary>
        /// <returns>True if invalid</returns>
        public bool IsDatePickerValueInvalid()
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
        /// Get the value of date picker
        /// </summary>
        /// <param name="key">date picker element key</param>
        /// <returns>date picker value</returns>
        public string GetValue()
        {
            return SelectInput.GetAttribute("value");
        }

        /// <summary>
        /// Simulate the mouse open date picker drop down menu
        /// </summary>
        /// <param name="itemButton"></param>
        /// <returns></returns>
        public void DisplayDatePickerItems()
        {
            this.SelectTrigger.Click();
        }

        public DatePicker(Locator locator) : base(locator) { }

        /// <summary>
        /// Select the date item from date picker
        /// </summary>
        /// <param name="date">DateTime type parameter</param>
        /// <returns></returns>
        public void SelectDateItem(DateTime date)
        {
            if (!String.IsNullOrEmpty(date.ToString()))
            {
                DisplayDatePickerItems();
                TimeManager.ShortPause();

                //SelectInnerYearMonthItem(date);
                NavigateToMonth(date);

                var locator = GetDatePickerDayLocator(date.Day.ToString());
                FindChild(locator).Click();
            }
        }

        /// <summary>
        /// Select the date item from date picker
        /// </summary>
        /// <param name="date">string type parameter, the date must be "xxxx-xx-xx"</param>
        /// <returns></returns>
        public void SelectDateItem(string date)
        {
            if (!String.IsNullOrEmpty(date))
            {
                DateTime dateTime = ConvertStringToDateTime(date);

                DisplayDatePickerItems();
                TimeManager.ShortPause();

                //SelectInnerYearMonthItem(date);
                NavigateToMonth(dateTime);

                var locator = GetDatePickerDayLocator(dateTime.Day.ToString());
                FindChild(locator).Click();
            }
        }
        /// <summary>
        /// Judge if the Container is enabled /add by Cathy
        /// </summary>
        /// <returns>True if the button is enable, false if not </returns>
        public bool IsEnabled()
        {
            return this.SelectInput.Enabled;
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
            int day = Convert.ToInt32(newDate[2]);

            return new DateTime(year, month, day);
        }

        private void  DisplayMonthPicker()
        {
            var locator = ControlLocatorRepository.GetLocator(ControlLocatorKey.InnerMonthPickerButton);

            FindChild(locator).Click();
        }

        private string GetDate()
        {
            var locator = ControlLocatorRepository.GetLocator(ControlLocatorKey.InnerMonthPickerButton);

            return FindChild(locator).Text;
        }

        private DateTime GetCurrentDate()
        {
            if (ExecutionConfig.Language == "CN")
            {
                string currentDate = GetDate();
                string dateValue = currentDate.Replace(YEARWORD, "-").Replace(MONTHWORD, "-");

                string[] date = dateValue.Split(new char[1] { '-' });
                int year = Convert.ToInt32(date[0]);
                int month = Convert.ToInt32(date[1]);

                return new DateTime(year, month, 1);
            }
            else
            {
                string currentDate = GetDate();
                string[] date = currentDate.Split(new char[1] { ' ' });
                int month = Convert.ToInt32(MonthItem[date[0]]);
                int year = Convert.ToInt32(date[1]);

                return new DateTime(year, month, 1);
            }      
        }
        
        private void NavigateToMonth(DateTime date)
        {
            DateTime currentDate = GetCurrentDate();

            int currentYear = Convert.ToInt32(currentDate.Year.ToString());
            int currentMonth = Convert.ToInt32(currentDate.Month.ToString());
            
            int numberYear = Convert.ToInt32(date.Year.ToString());
            int numberMonth = Convert.ToInt32(date.Month.ToString());
            int clickPrevTime = 0;
            int clickNextTime = 0;

            if (currentYear > numberYear)
            {
                clickPrevTime = (currentYear - numberYear) * 12;
                ClickNTimesDatePickerPreviousMonthButton(clickPrevTime);
            }
            else if (currentYear < numberYear)
            {
                clickNextTime = (numberYear - currentYear) * 12;
                ClickNTimesDatePickerNextMonthButton(clickNextTime);
            }

            if (currentMonth > numberMonth)
            {
                clickPrevTime = currentMonth - numberMonth;
                ClickNTimesDatePickerPreviousMonthButton(clickPrevTime);
            }
            else if (currentMonth < numberMonth)
            {
                clickNextTime = numberMonth - currentMonth;
                ClickNTimesDatePickerNextMonthButton(clickNextTime);
            }
        }

        private void ClickNTimesDatePickerPreviousMonthButton(int clickTime)
        {
            for (int i = 0; i < clickTime; i++)
            {
                ClickDatePickerPreviousMonthButton();
            }
        }

        private void ClickNTimesDatePickerNextMonthButton(int clickTime)
        {
            for (int i = 0; i < clickTime; i++)
            {
                ClickDatePickerNextMonthButton();
            }
        }
        /// <summary>
        /// Simulate the mouse select year and month item from monthpicker drop down list
        /// </summary>
        /// <param name="date">date</param>
        /// <returns></returns>
        private void SelectInnerYearMonthItem(DateTime date)
        {
            SelectInnerYearItem(date.Year.ToString());
            SelectInnerMonthItem(date.Month.ToString());

            ClickInnerMonthPickerConfirmButton();
        }

        /// <summary>
        /// Simulate the mouse select month item from monthpicker drop down list
        /// </summary>
        /// <param name="key">month picker month element key</param>
        /// <returns></returns>
        private void SelectInnerMonthItem(string itemKey)
        {
            string newItemKey = Project.LanguagePrefix + itemKey;

            var locator = GetInnerMonthPickerMonthLocator(newItemKey);

            if (!ElementHandler.Displayed(locator))
                DisplayMonthPicker();

            FindChild(locator).Click();
        }

        /// <summary>
        /// Simulate the mouse select year item from monthpicker drop down list
        /// </summary>
        /// <param name="key">month picker year element key</param>
        /// <returns></returns>
        private void SelectInnerYearItem(string itemKey)
        {
            var locator = GetInnerMonthPickerYearLocator(itemKey);

            if (!ElementHandler.Displayed(locator))
                DisplayMonthPicker();

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
                    ClickInnerMonthPreviousNavigator();
                    TimeManager.ShortPause();
                }
            }
            else if (number > 2018)
            {
                int nextNumber = ((number - 2018) / 10) + 1;

                for (int i = 0; i < nextNumber; i++)
                {
                    ClickInnerMonthNextNavigator();
                    TimeManager.ShortPause();
                }
            }
        }

        #region Protect Method
        
        protected virtual void ClickDatePickerPreviousMonthButton()
        {
            var locator = ControlLocatorRepository.GetLocator(ControlLocatorKey.DatePickerPreviousMonth);

            FindChild(locator).Click();
        }

        protected virtual void ClickDatePickerNextMonthButton()
        {
            var locator = ControlLocatorRepository.GetLocator(ControlLocatorKey.DatePickerNextMonth);

            FindChild(locator).Click();
        }

        protected virtual void ClickInnerMonthPreviousNavigator()
        {
            var locator = ControlLocatorRepository.GetLocator(ControlLocatorKey.InnerMonthPickerPreviousNavigator);

            FindChild(locator).Click();
        }

        protected virtual void ClickInnerMonthNextNavigator()
        {
            var locator = ControlLocatorRepository.GetLocator(ControlLocatorKey.InnerMonthPickerNextNavigator);

            FindChild(locator).Click();
        }

        protected virtual void ClickInnerMonthPickerConfirmButton()
        {
            var locator = ControlLocatorRepository.GetLocator(ControlLocatorKey.InnerMonthPickerConfirm);

            FindChild(locator).Click();
        }

        protected virtual void ClickInnerMonthPickerCanceLButton()
        {
            var locator = ControlLocatorRepository.GetLocator(ControlLocatorKey.InnerMonthPickerCancel);

            FindChild(locator).Click();
        }

        protected virtual Locator GetDatePickerDayLocator(string itemKey)
        {
            string itemRealValue = ComboBoxItemRepository.GetComboBoxItemRealValue(itemKey);

            return Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.DatePickerDayItem), DATEPICKERITEMVARIABLENAME, itemRealValue);
        }

        protected virtual Locator GetInnerMonthPickerYearLocator(string itemKey)
        {
            string itemRealValue = ComboBoxItemRepository.GetComboBoxItemRealValue(itemKey);

            return Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.InnerMonthPickerYearItem), DATEPICKERITEMVARIABLENAME, itemRealValue);
        }

        protected virtual Locator GetInnerMonthPickerMonthLocator(string itemKey)
        {
            string itemRealValue = ComboBoxItemRepository.GetComboBoxItemRealValue(itemKey);

            return Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.InnerMonthPickerMonthItem), DATEPICKERITEMVARIABLENAME, itemRealValue);
        }

        #endregion
    }
}
