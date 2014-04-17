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
        private Locator WidgetShareIconLocator = new Locator("../../../../../../self::node()", ByType.XPath);

        public string GetLabelTextValue()
        {
            return this.RootElement.Text;
        }

        public bool IsShareWidgetUnread()
        {
            return FindChild(WidgetShareIconLocator).GetAttribute("class").Contains("x-widget-unread");
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
                //Console.Out.WriteLine(text);
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

        public void Float()
        {
            ElementHandler.Float(this.RootElement);
        }

        public void Click()
        {
            ElementHandler.Click(this.RootElement);
        }

        public void DoubleClick()
        {
            ElementHandler.DoubleClick(this.RootElement);
        }
    }
}
