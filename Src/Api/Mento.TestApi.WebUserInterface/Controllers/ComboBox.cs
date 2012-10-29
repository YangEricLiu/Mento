using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Utility;
using Mento.Framework;

namespace Mento.TestApi.WebUserInterface
{
    public class ComboBox : ControllerBase
    {
        public void DisplayItems(string itemButton)
        {
            string comboLocator = DictDataLoad.dictElement[itemButton].value;
            ByType type = DictDataLoad.dictElement[itemButton].type;
            
            ElementLocator.FindElement(comboLocator, type).Click();
        }

        public void SelectItem(string item)
        {
            string itemLocator = DictDataLoad.dictElement[item].value;
            ByType type = DictDataLoad.dictElement[item].type;

            ElementLocator.FindElement(itemLocator, type).Click();
        }
    }
}
