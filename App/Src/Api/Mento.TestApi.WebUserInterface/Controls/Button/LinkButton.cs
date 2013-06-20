using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class LinkButton : Button
    {
        public LinkButton(Locator locator)
            : base(locator)
        { }


        public void ClickLink()
        {
            ElementHandler.Click(this.RootElement);
        }

        public bool IsLinkButtonDisabled()
        {
            return this.RootElement.GetAttribute("class").Contains("x-item-disabled");
        }
    }
}
