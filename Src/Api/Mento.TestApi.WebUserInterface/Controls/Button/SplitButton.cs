using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class SplitButton : Button
    {
        private static string MenuItemLocatorFormat = "//div[contains(@class,'x-menu-item') and a/span[text()='{0}']]";
        private static Locator TriggerLocator = new Locator("em", ByType.TagName);

        public SplitButton(Locator locator)
            : base(locator)
        { }

        public void Trigger()
        {
            var Trigger = this.FindChild(TriggerLocator);
            ElementHandler.Click(Trigger, this.RootElement.Size.Width - 5, 0);
        }

        public void SelectItem(string[] itemPath)
        {
            for (int i = 0; i < itemPath.Length; i++)
            {
                Locator itemLocator = GetMenuItemLocator(itemPath[i]);

                ElementHandler.Click(FindChild(itemLocator));

                TimeManager.ShortPause();
            }
        }

        private Locator GetMenuItemLocator(string itemResourceVariable)
        {
            return new Locator(LanguageResourceRepository.ReplaceLanguageVariables(String.Format(MenuItemLocatorFormat, itemResourceVariable)), ByType.XPath);
        }
    }
}
