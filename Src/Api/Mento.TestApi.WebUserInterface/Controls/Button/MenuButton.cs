using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            throw new NotImplementedException(); 
        }

        private Locator GetMenuItemLocator(string itemResourceVariable)
        {
            return new Locator(LanguageResourceRepository.ReplaceLanguageVariables(String.Format(MenuItemLocatorFormat, itemResourceVariable)), ByType.XPath);
        }
    }
}
