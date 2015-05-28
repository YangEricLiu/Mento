using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class SplitButton : Button
    {
        private static string MenuItemLocatorFormat = "//div[contains(@class,'x-menu-item') and a/span[text()='{0}']]";
        private static Locator TriggerLocator = new Locator("em", ByType.TagName);
        private static string Pop_MenuItemLocatorFormat = "//div[@class='pop-mainmenu-level-main']/div[contains(@class,'pop-mainmenu-level-sub')]/a[text()='{0}']";

        public SplitButton(Locator locator)
            : base(locator)
        { }

        #region Pop

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

        #region Not pop      

        public void Trigger()
        {
            var Trigger = this.FindChild(TriggerLocator);
            ElementHandler.Click(Trigger, this.RootElement.Size.Width - 5, 8);
        }

        public void SelectItem(string[] itemPath)
        {
            for (int i = 0; i < itemPath.Length; i++)
            {
                Locator itemLocator = GetMenuItemLocator(itemPath[i]);

                ElementHandler.Click(FindChild(itemLocator));

                TimeManager.LongPause();
            }
        }

        public bool IsSplitButtonDisabled()
        {
            return this.RootElement.GetAttribute("class").Contains("x-btn-disabled");
        }

        public bool IsMenuItemDisabled(string itemText)
        {
            Trigger();
            return GetMenuItem(itemText).GetAttribute("class").Contains("x-menu-item-disabled");
        }

        private IWebElement GetMenuItem(string itemResourceVariable)
        {
            return FindChild(GetMenuItemLocator(itemResourceVariable));
        }

        private Locator GetMenuItemLocator(string itemResourceVariable)
        {
            return new Locator(LanguageResourceRepository.ReplaceLanguageVariables(String.Format(MenuItemLocatorFormat, itemResourceVariable)), ByType.XPath);
        }

        #endregion
    }
}
