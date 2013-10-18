using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class DashboardButton : Button
    {
        private static Locator DashboardFavorite = new Locator("../../div[contains(@id,'dashboardbutton')]", ByType.XPath);
        private static Locator DashboardUnreadIcon = new Locator("../../div[@id='hp-share-info-btn']", ByType.XPath);

        public DashboardButton(Locator locator)
            : base(locator)
        { }


        public void ClickLink()
        {
            ElementHandler.Click(this.RootElement);
        }

        public bool IsDashboardFavorited()
        {
            return FindChild(DashboardFavorite).GetAttribute("class").Contains("x-dsbd-btn-fav");
        }

        public string GetFavoriteLevelButtonValue()
        {
            return this.RootElement.Text;
        }

        public bool IsShareInfoUnread()
        {
            return FindChild(DashboardUnreadIcon).GetAttribute("class").Contains("x-button-unread");
        }

        public bool IsDashboardUnread()
        {
            return this.RootElement.GetAttribute("class").Contains("x-button-unread");
        }
    }
}
