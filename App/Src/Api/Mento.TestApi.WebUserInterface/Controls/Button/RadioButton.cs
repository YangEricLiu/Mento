using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class RadioButton : Button
    {
        private static Locator RadioField = new Locator("../../../../self::node()", ByType.XPath);
        private static Locator RadioFieldLabel = new Locator("../../../../../self::node()/label", ByType.XPath);

        public RadioButton(Locator locator)
            : base(locator)
        { }

        public bool IsRadioButtonChecked()
        {
            return FindChild(RadioField).GetAttribute("class").Contains("x-form-cb-checked");
        }


        public bool IsRadioButtonDisabled()
        {
            return FindChild(RadioField).GetAttribute("class").Contains("x-item-disabled");
        }

        public string GetRadioButtonLabel()
        {
            return FindChild(RadioFieldLabel).Text;
        }
    }
}
