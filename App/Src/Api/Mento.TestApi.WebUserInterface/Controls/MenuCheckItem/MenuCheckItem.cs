using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Mento.TestApi.WebUserInterface.Controls
{
    /// <summary>
    /// CheckBox or text field for filter
    /// </summary>
    public class MenuCheckItem : JazzControl
    {
        protected const string ITEMNAME = "itemName";
        private static Locator MenuCheckSearchingCheckerLocator = new Locator("a/img[1]", ByType.XPath);
        private static Locator MenuCheckItemTriggerLocator = new Locator("div[contains(@class,'x-column-header-trigger')]", ByType.XPath);


        /// <summary>
        /// locator parameter must be root element of a MenuCheckItem
        /// </summary>
        /// <param name="locator"></param>
        public MenuCheckItem(Locator locator) : base(locator) { }

        public void CheckMenuAssociateItem(string itemKey)
        {
            if (!String.IsNullOrEmpty(itemKey))
            {
                FloatOnAssociateStatusButton();
                ClickMenuAssociateTrigger();
                FloatOnMenuCheckSearching();
                TimeManager.MediumPause();
                CheckMenuCheckExtraComp(itemKey);
            }
        }

        public void UncheckMenuAssociateItem(string itemKey)
        {
            if (!String.IsNullOrEmpty(itemKey))
            {
                FloatOnAssociateStatusButton();
                ClickMenuAssociateTrigger();
                FloatOnMenuCheckSearching();
                TimeManager.MediumPause();
                UncheckMenuCheckExtraComp(itemKey);
            }
        }

        public bool IsMenuAssociateItemChecked(string itemKey)
        {
            if (!String.IsNullOrEmpty(itemKey))
            {
                FloatOnAssociateStatusButton();
                ClickMenuAssociateTrigger();
                FloatOnMenuCheckSearching();
                TimeManager.MediumPause();
                return IsMenuCheckExtraCompChecked(itemKey);
            }
            else 
            {
                throw new Exception("string is empty");
            }
        }

        public void ClickMenuCheckItemTrigger(string itemName)
        {
            IWebElement MenuCheckItemItem = GetMenuCheckItemItemElement(itemName);
            IWebElement MenuCheckItemTrigger = ElementHandler.FindElement(MenuCheckItemTriggerLocator, container: MenuCheckItemItem);

            MenuCheckItemTrigger.Click();
        }

        public void ClickMenuAssociateTrigger()
        {
            IWebElement MenuAssociateStatusItem = GetMenuAssociateStatusElement();
            IWebElement MenuAssociateTrigger = ElementHandler.FindElement(MenuCheckItemTriggerLocator, container: MenuAssociateStatusItem);

            MenuAssociateTrigger.Click();
            TimeManager.MediumPause();
        }

        public void FloatOnMenuCheckSearching()
        {
            IWebElement MenuCheckSearching = GetMenuCheckSearchingElement();

            for (int i = 0; i < 10; i++)
            {
                ElementHandler.Float(MenuCheckSearching);
            }          
        }

        public void FloatOnAssociateStatusButton()
        {
            IWebElement MenuAssociateStatus = GetMenuAssociateStatusElement();

            ElementHandler.Float(MenuAssociateStatus);
        }

        public void CheckMenuCheckSearching()
        {
            IWebElement MenuCheckSearching = GetMenuCheckSearchingElement();

            if (!IsMenuCheckSearchingChecked())
            {
                IWebElement MenuCheckSearchingChecker = ElementHandler.FindElement(MenuCheckSearchingCheckerLocator, container: MenuCheckSearching);

                MenuCheckSearchingChecker.Click();
            }
        }

        public void UncheckMenuCheckSearching()
        {
            IWebElement MenuCheckSearching = GetMenuCheckSearchingElement();

            if (IsMenuCheckSearchingChecked())
            {
                IWebElement MenuCheckSearchingChecker = ElementHandler.FindElement(MenuCheckSearchingCheckerLocator, container: MenuCheckSearching);

                MenuCheckSearchingChecker.Click();
            }
        }

        public void CheckMenuCheckExtraComp(string itemName)
        {
            IWebElement MenuCheckExtraComp = GetMenuCheckExtraCompElement(itemName);

            if (!IsMenuCheckExtraCompChecked(itemName))
            {
                IWebElement MenuCheckExtraCompChecker = ElementHandler.FindElement(MenuCheckSearchingCheckerLocator, container: MenuCheckExtraComp);

                MenuCheckExtraCompChecker.Click();
            }
        }

        public void UncheckMenuCheckExtraComp(string itemName)
        {
            IWebElement MenuCheckExtraComp = GetMenuCheckExtraCompElement(itemName);

            if (IsMenuCheckExtraCompChecked(itemName))
            {
                IWebElement MenuCheckExtraCompChecker = ElementHandler.FindElement(MenuCheckSearchingCheckerLocator, container: MenuCheckExtraComp);

                MenuCheckExtraCompChecker.Click();
            }
        }

        public bool IsMenuCheckSearchingChecked()
        {
            IWebElement MenuCheckSearching = GetMenuCheckSearchingElement();

            return MenuCheckSearching.GetAttribute("class").Contains("x-menu-item-checked");
        }

        public bool IsMenuCheckExtraCompChecked(string itemName)
        {
            IWebElement MenuCheckExtraComp = GetMenuCheckExtraCompElement(itemName);

            return MenuCheckExtraComp.GetAttribute("class").Contains("x-menu-item-checked");
        }

        public IWebElement GetMenuCheckSearchingElement()
        {
            return FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.MenuCheckSearching));
        }

        public IWebElement GetMenuCheckExtraCompElement(string itemName)
        {
            return FindChild(Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.MenuCheckExtraComp), ITEMNAME, itemName));
        }

        public IWebElement GetMenuAssociateStatusElement()
        {
            return FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.MenuAssociateStatusItem));
        }

        #region common

        // Get MenuCheckItem
        private Locator GetMenuCheckItemItemLocator(string itemName)
        {
            return Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.MenuCheckItemItem), ITEMNAME, itemName);
        }

        private IWebElement GetMenuCheckItemItemElement(string itemName)
        {
            return FindChild(GetMenuCheckItemItemLocator(itemName));
        }

        #endregion
    }
}
