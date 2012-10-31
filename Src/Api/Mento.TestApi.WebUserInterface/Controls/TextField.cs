using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Utility;

namespace Mento.TestApi.WebUserInterface
{
    public class TextField : JazzControlBase
    {
        public void FillIn(string obj, string content)
        {
            //string textLocator = DictDataLoad.dictElement[obj].Value;
            //ByType type = DictDataLoad.dictElement[obj].Type;
            var locator = ElementDictionary[obj];

            ElementLocator.FindElement(locator).Clear();
            ElementLocator.FindElement(locator).SendKeys(content);
        }

        public void Append(string obj, string content)
        {
            //string textLocator = DictDataLoad.dictElement[obj].Value;
            //ByType type = DictDataLoad.dictElement[obj].Type;
            var locator = ElementDictionary[obj];

            ElementLocator.FindElement(locator).SendKeys(content);
        }

        public string GetValue(string obj)
        {
            //string textLocator = DictDataLoad.dictElement[obj].Value;
            //ByType type = DictDataLoad.dictElement[obj].Type;
            var locator = ElementDictionary[obj];

            return ElementLocator.FindElement(locator).GetAttribute("value");
        }
    }
}
