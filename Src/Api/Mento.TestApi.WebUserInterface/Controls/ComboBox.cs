using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Utility;
using Mento.Framework;

namespace Mento.TestApi.WebUserInterface
{
    public class ComboBox : JazzControlBase
    {
        public void DisplayItems(string itemButton)
        {
            //string comboLocator = DictDataLoad.dictElement[itemButton].Value;
            //ByType type = DictDataLoad.dictElement[itemButton].Type;

            var locator = ElementDictionary[itemButton];

            ElementLocator.FindElement(locator).Click();
        }

        public void SelectItem(string item)
        {
            //string itemLocator = DictDataLoad.dictElement[item].Value;
            //ByType type = DictDataLoad.dictElement[item].Type;

            var locator = ElementDictionary[item];

            ElementLocator.FindElement(locator).Click();
        }
    }
}
