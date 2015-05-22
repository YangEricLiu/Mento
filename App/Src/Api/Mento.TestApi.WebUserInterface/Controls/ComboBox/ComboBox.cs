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
        private Locator InvalidTips = new Locator("../../../../tbody/tr/td[contains(@class,'x-form-invalid-under')]",ByType.XPath);

        #region Pop

        protected IWebElement Pop_SelectTrigger
        {
            get
            {
                return FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.PopComboBoxTrigger));
            }
        }

        public void Pop_SelectItem(string itemKey)
        {

            TimeManager.MediumPause();
            if (!String.IsNullOrEmpty(itemKey))
            {
                var locator = Pop_GetComboBoxItemLocator(itemKey);

                if (!ElementHandler.Displayed(locator))
                    DisplayItems();

                FindChild(locator).Click();
            }
        }

        protected virtual Locator Pop_GetComboBoxItemLocator(string itemKey)
        {
            string itemRealValue = ComboBoxItemRepository.GetComboBoxItemRealValue(itemKey);

            return Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.PopComboBoxItem), COMBOBOXITEMVARIABLENAME, itemRealValue);
        }

        #endregion

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
        /// If combobox displayed
        /// </summary>
        /// <returns></returns>
        public bool IsDisplayed()
        {
            return ElementHandler.Displayed(this._RootLocator);
        }

        /// <summary>
        /// Simulate the mouse open combo box drop down menu
        /// </summary>
        /// <param name="itemButton"></param>
        /// <returns></returns>
        public void DisplayItems()
        {
            this.SelectTrigger.Click();
        }

        public void Click()
        {
            ElementHandler.Click(this.RootElement);
            //this.RootElement.Click();
        }

        /// <summary>
        /// Simulate the mouse select one item from drop down list
        /// </summary>
        /// <param name="key">combo box element key</param>
        /// <returns></returns>
        public void SelectItem(string itemKey)
        {
            
            TimeManager.MediumPause();
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
            DisplayItems();
            
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

        public bool IsComboBoxItemExisted(string itemKey)
        {
            Locator itemLocator = GetComboBoxItemLocator(itemKey);
            
            return ElementHandler.Exists(itemLocator);
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
            return FindChild(InvalidTips).Text;
        }

        /// <summary>
        /// Return whether combobox is enabled
        /// </summary>
        /// <returns>True if enabled</returns>
        public Boolean IsComboBoxTextEnabled()
        {
            return this.SelectInput.Enabled;
        }

        /// <summary>
        /// Return whether combobox list is empty
        /// </summary>
        /// <returns>True if enabled</returns>
        public Boolean IsComboxListEmpty()
        {
            return ElementHandler.Exists(ControlLocatorRepository.GetLocator(ControlLocatorKey.ComboBoxDropdownListItems), this.RootElement);
        }

        public void SelectItem(string[] p)
        {
            throw new NotImplementedException();
        }

        public ArrayList GetRelativeIntervalsMenulistItems()
        {
            this.Click();
            TimeManager.LongPause();
            ArrayList items = new ArrayList();
            foreach (IWebElement item in CurrentComboBoxDropdownListItems)
            {
                items.Add(item.Text);
            }

            return items;
        }
    }
}
