using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controls
{
    /// <summary>
    /// CheckBoxField display whether the checkbox is checked
    /// </summary>
    public class CheckBoxField : JazzControl
    {
        private static string CHECKEDCLASS = "x-form-cb-checked";

        public CheckBoxField(Locator locator) : base(locator) { }

        public Boolean IsChecked()
        {
            return this.RootElement.GetAttribute("class").Contains(CHECKEDCLASS);
        }

        public void Check()
        {
            if (!IsChecked())
                this.RootElement.Click();
        }

        public void Uncheck()
        {
            if (IsChecked())
                this.RootElement.Click();
        }
    }
}
