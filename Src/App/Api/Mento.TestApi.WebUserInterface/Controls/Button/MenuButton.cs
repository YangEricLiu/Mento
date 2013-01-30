using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class MenuButton : Button
    {
        private static string MenuItemLocatorFormat = "//div[contains(@class,'x-menu-item') and a/span[text()='{0}']]";

        public MenuButton(Locator locator) : base(locator) { }

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

        public bool IsItemChecked(string itemText)
        {
            return GetMenuItem(itemText).GetAttribute("class").Contains("x-menu-item-checked");
        }

        private void ToggleCheckItem(string itemText)
        {
            ElementHandler.Click(GetMenuItem(itemText), 15, 10);
        }

        private IWebElement GetMenuItem(string itemResourceVariable)
        {
            return FindChild(GetMenuItemLocator(itemResourceVariable));
        }

        private Locator GetMenuItemLocator(string itemResourceVariable)
        {
            return new Locator(LanguageResourceRepository.ReplaceLanguageVariables(String.Format(MenuItemLocatorFormat, itemResourceVariable)), ByType.XPath);
        }
    }
}
