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

        public void HoverItem(string itemResourceVariable)
        {
            Locator itemLocator = GetMenuItemLocator(itemResourceVariable);

            ElementHandler.Focus(FindChild(itemLocator));
        }

        public void SelectItem(string itemResourceVariable)
        {
            Locator itemLocator = GetMenuItemLocator(itemResourceVariable);

            ElementHandler.Click(FindChild(itemLocator));
        }

        private Locator GetMenuItemLocator(string itemResourceVariable)
        {
            return new Locator(LanguageResourceRepository.ReplaceLanguageVariables(String.Format(MenuItemLocatorFormat, itemResourceVariable)), ByType.XPath);
        }
    }
}
