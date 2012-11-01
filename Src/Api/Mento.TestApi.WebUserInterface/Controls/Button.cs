using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface
{
    public class Button : JazzControlBase
    {
        public void ClickButton(Locator buttonLocator)
        {
            ElementLocator.FindElement(buttonLocator).Click();
        }

        public void FloatOnButton(Locator buttonLocator)
        {
            ElementLocator.FloatOn(ElementLocator.FindElement(buttonLocator));
        }
    }
}
