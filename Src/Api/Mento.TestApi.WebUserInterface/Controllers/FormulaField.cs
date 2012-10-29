using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.Utility;

namespace Mento.TestApi.WebUserInterface
{
    public class FormulaField : TextField
    {
        public void DragTag(string tagName)
        {
            string tagPath = DictDataLoad.dictElement[ElementKey.TagNameRow].value.Replace(ManualElementName.tagName, tagName);
            ByType type1 = DictDataLoad.dictElement[ElementKey.TagNameRow].type;

            string formulaField = DictDataLoad.dictElement[ElementKey.FormulaField].value;
            ByType type2 = DictDataLoad.dictElement[ElementKey.FormulaField].type;

            IWebElement tagElement = ElementLocator.FindElement(tagPath, type1);
            IWebElement formulaElement = ElementLocator.FindElement(formulaField, type2);

            ElementLocator.FocusOn(tagElement);
            ElementLocator.DragAndDrop(tagElement, formulaElement);
        }

        public string GetValue()
        {
            string formulaField = DictDataLoad.dictElement[ElementKey.FormulaField].value;
            ByType type = DictDataLoad.dictElement[ElementKey.FormulaField].type;

            return ElementLocator.FindElement(formulaField, type).GetAttribute("value");
        }
    }
}
