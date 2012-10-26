using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Utility;

namespace Mento.TestApi.WebUserInterface
{
    public class TextField : ControllerBase
    {
        public void FillIn(string obj, string content)
        {
            string textLocator = DictDataLoad.dictElement[obj].value;
            byType type = DictDataLoad.dictElement[obj].type;

            ElementLocator.FindElement(textLocator, type).Clear();
            ElementLocator.FindElement(textLocator, type).SendKeys(content);
        }

        public void Append(string obj, string content)
        {
            string textLocator = DictDataLoad.dictElement[obj].value;
            byType type = DictDataLoad.dictElement[obj].type;

            ElementLocator.FindElement(textLocator, type).SendKeys(content);
        }

        public string GetValue(string obj)
        {
            string textLocator = DictDataLoad.dictElement[obj].value;
            byType type = DictDataLoad.dictElement[obj].type;

            return ElementLocator.FindElement(textLocator, type).GetAttribute("value");
        }
    }
}
