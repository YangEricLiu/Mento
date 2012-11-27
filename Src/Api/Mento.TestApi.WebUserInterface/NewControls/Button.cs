using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.NewControls
{
    public abstract class Button : JazzControl
    {
        public Button(Locator locator)
            : base(locator)
        { 
        }

        public void Click()
        {
            RootElement.Click();
        }

        public bool IsEnabled()
        {
            return FindElement(new Locator("//button", ByType.Xpath)).Enabled;
        }
    }
}
