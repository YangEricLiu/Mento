using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface
{
    public class TextField : ControllerBase
    {
        public void FillIn(string textLocator, string content, byType type)
        {
            ElementLocator.FindElement(textLocator, type).Clear();
            ElementLocator.FindElement(textLocator, type).SendKeys(content);
        }

        public void Append(string textLocator, string content, byType type)
        {
            ElementLocator.FindElement(textLocator, type).SendKeys(content);
        }

        public string GetValue(string textLocator, byType type)
        {
            return ElementLocator.FindElement(textLocator, type).GetAttribute("value");
        }
    }
}
