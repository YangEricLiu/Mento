﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class LinkButton : Button
    {
        private static Locator linkButtonEnable = new Locator("../../div[contains(@id,'remlinkbutton')]", ByType.XPath);

        public LinkButton(Locator locator)
            : base(locator)
        { }


        public void ClickLink()
        {
            ElementHandler.Click(this.RootElement);
        }

        public bool IsLinkButtonDisabled()
        {
            return FindChild(linkButtonEnable).GetAttribute("class").Contains("x-item-disabled");
        }
    }
}
