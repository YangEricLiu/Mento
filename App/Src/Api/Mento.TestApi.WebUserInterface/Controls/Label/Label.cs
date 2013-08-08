using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controls
{
    /// <summary>
    /// Label display text
    /// </summary>
    public class Label : JazzControl
    {
        public Label(Locator locator) : base(locator) { }

        public string GetLabelTextValue()
        {
            return this.RootElement.Text;
        }

        public Boolean IsLabelTextsExisted(string[] labelTexts)
        {
            string allTexts = GetLabelTextValue();
            
            foreach (string text in labelTexts)
            {
                if (!allTexts.Contains(text))
                {
                    Console.Out.WriteLine(text);
                    return false;
                }
            }

            return true;
        }


        public Boolean IsLabelTextExisted(string labelText)
        {
            string text = GetLabelTextValue();

            if (!text.Contains(labelText))
            {
                Console.Out.WriteLine(text);
                return false;
            }

            return true;
        }

        public Boolean IsLabelDisplayed()
        {
            return this.RootElement.Displayed;
        }

        public bool IsLabelExisted()
        {
            return ElementHandler.Exists(this._RootLocator);
        }
    }
}
