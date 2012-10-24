using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controllers
{
    public class TextField : ControllerBase
    {
        public static void FillIn(string textLocator, string content, byType type)
        {
            ElementLocator.FindElement(textLocator, type).Clear();
            ElementLocator.FindElement(textLocator, type).SendKeys(content);
        }

        public static void Append(string textLocator, string content, byType type)
        {
            ElementLocator.FindElement(textLocator, type).SendKeys(content);
        }

        public static string GetValue(string textLocator, byType type)
        {
            return ElementLocator.FindElement(textLocator, type).GetAttribute("value");
        }
    }
}
