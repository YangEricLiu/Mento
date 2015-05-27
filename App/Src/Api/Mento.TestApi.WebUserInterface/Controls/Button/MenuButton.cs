using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Collections;


namespace Mento.TestApi.WebUserInterface.Controls
{
    public class MenuButton : Button
    {
        //for english version
        //private static string MenuItemLocatorFormat = "//div[contains(@id, 'menuitem') and a/span[contains(@class, 'x-menu-item-text') and contains(text(),'{0}')]]";

        //private static string MenuItemLocatorFormat = "//div[contains(@id, 'menuitem') and a/span[contains(@class, 'x-menu-item-text') and text()='{0}']]";
        private static string MenuItemLocatorFormat = "//div[contains(@id, 'menuitem')]/a/span[contains(@class, 'x-menu-item-text') and text()='{0}']";
        private static string MoreMenuItemLocatorFormat = "//div[contains(@id, 'menuitem') and a/span[contains(@class, 'x-menu-item-text') and text()='{0}']]";

        private static string Pop_MenuItemLocatorFormat = "//div[contains(@class,'mui-menu-item')]/span[text()='{0}']";

        public MenuButton(Locator locator) : base(locator) { }

        #region Pop operation

        public void Pop_SelectItem(string item)
        {
            this.Click();
            TimeManager.LongPause();

            Locator itemLocator = Pop_GetMenuItemLocator(item);
            ElementHandler.Click(FindChild(itemLocator));
        }

        private Locator Pop_GetMenuItemLocator(string itemResourceVariable)
        {
            return new Locator(LanguageResourceRepository.ReplaceLanguageVariables(String.Format(Pop_MenuItemLocatorFormat, itemResourceVariable)), ByType.XPath);
        }

        #endregion

        #region Not pop operation

        public void SelectItem(string[] itemPath)
        {
            this.Click();
            TimeManager.FlashPause();

            for (int i = 0; i < itemPath.Length; i++)
            {
                Locator itemLocator = GetMenuItemLocator(itemPath[i]);

                ElementHandler.Click(FindChild(itemLocator));

                TimeManager.ShortPause();
            }
        }

        public void SelectItemLabelling(string[] itemPath)
        {
            this.Click();
            TimeManager.MediumPause();

            for (int i = 0; i < itemPath.Length; i++)
            {
                Locator itemLocator = GetMenuItemLocator(itemPath[i]);
                if (i != (itemPath.Length - 1))
                {
                    ElementHandler.Float(FindChild(itemLocator));
                    ElementHandler.Float(FindChild(itemLocator));
                    TimeManager.MediumPause();
                }
                else
                {
                    ElementHandler.Click(FindChild(itemLocator));
                }
                
                TimeManager.ShortPause();
            }
        }

        public void Open()
        {
            this.Click();
            TimeManager.FlashPause();
        }

        public void SelectOneItem(string itemPath)
        {
            this.Click();
            TimeManager.FlashPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            Locator itemLocator = GetMenuItemLocator(itemPath);
            ElementHandler.Click(FindChild(itemLocator));

            TimeManager.ShortPause();
        }

        public void CheckItem(string itemText)
        {
            this.Click();
            TimeManager.FlashPause();

            if (!IsItemChecked(itemText))
            {
                ToggleCheckItem(itemText);
            }
        }

        public void UncheckItem(string itemText)
        {
            this.Click();
            TimeManager.FlashPause();

            if (IsItemChecked(itemText))
            {
                ToggleCheckItem(itemText);
            }
        }

        public ArrayList GetSecondLevelMenuListItems(string itemPath)
        {
            this.Click();
            Locator itemLocator = GetMenuItemLocator(itemPath);
            ElementHandler.Float(FindChild(itemLocator));
            ElementHandler.Float(FindChild(itemLocator));
            TimeManager.LongPause();
            ArrayList items = new ArrayList();
            foreach (IWebElement item in CurrentMenuButtonDropdownListItems)
            {
                items.Add(item.Text);
            }

            return items;
        }

        public ArrayList GetBenchmarkMenulistItems()
        {
            this.Click();
            TimeManager.LongPause();
            ArrayList items = new ArrayList();
            foreach (IWebElement item in CurrentMenuButtonDropdownListItems)
            {
                items.Add(item.Text);
            }

            return items;
        }

        public ArrayList GetUnitTypeMenulistItems()
        {
            this.Click();
            TimeManager.LongPause();
            ArrayList items = new ArrayList();
            foreach (IWebElement item in CurrentMenuButtonDropdownListItems)
            {
                items.Add(item.Text);
            }

            return items;
        }

        protected IWebElement[] CurrentMenuButtonDropdownListItems
        {
            get
            {
                return FindChildren(ControlLocatorRepository.GetLocator(ControlLocatorKey.MenuButtonDropdownListItems));
            }
        }

        public bool IsItemChecked(string itemText)
        {
            return GetMenuItem(itemText).GetAttribute("class").Contains("x-menu-item-checked");
        }

        public bool IsMenuItemDisabled(string itemText)
        {
            this.Click();
            TimeManager.MediumPause();
            return GetMenuItem(itemText).GetAttribute("class").Contains("x-menu-item-disabled");
        }

        public bool IsMoreMenuItemDisabled(string itemText)
        {
            this.Click();
            TimeManager.MediumPause();
            return GetMoreMenuItem(itemText).GetAttribute("class").Contains("x-menu-item-disabled");
        }

        public bool IsMenuItemExist(string itemText)
        {
            this.Click();
            return GetMenuItem(itemText).GetAttribute("class").Contains("x-menu-item-text");
        }

        private void ToggleCheckItem(string itemText)
        {
            ElementHandler.Click(GetMenuItem(itemText), 15, 10);
        }

        private IWebElement GetMenuItem(string itemResourceVariable)
        {
            return FindChild(GetMenuItemLocator(itemResourceVariable));
        }

        private IWebElement GetMoreMenuItem(string itemResourceVariable)
        {
            return FindChild(GetMoreMenuItemLocator(itemResourceVariable));
        }

        private Locator GetMenuItemLocator(string itemResourceVariable)
        {
            return new Locator(LanguageResourceRepository.ReplaceLanguageVariables(String.Format(MenuItemLocatorFormat, itemResourceVariable)), ByType.XPath);
        }

        private Locator GetMoreMenuItemLocator(string itemResourceVariable)
        {
            return new Locator(LanguageResourceRepository.ReplaceLanguageVariables(String.Format(MoreMenuItemLocatorFormat, itemResourceVariable)), ByType.XPath);
        }

        #endregion
    }
}
