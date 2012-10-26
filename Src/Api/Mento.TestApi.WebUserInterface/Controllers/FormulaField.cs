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
            string tagPath = DictDataLoad.dictManualElement[ElementKey.TagNameRow].value.Replace(ManualElementName.tagName, tagName);
            byType type1 = DictDataLoad.dictManualElement[ElementKey.TagNameRow].type;

            string formulaField = DictDataLoad.dictElement[ElementKey.FormulaField].value;
            byType type2 = DictDataLoad.dictElement[ElementKey.FormulaField].type;

            IWebElement tagElement = ElementLocator.FindElement(tagPath, type1);
            IWebElement formulaElement = ElementLocator.FindElement(formulaField, type2);

            ElementLocator.FocusOn(tagElement);
            ElementLocator.DragAndDrop(tagElement, formulaElement);
        }

        public string GetValue()
        {
            string formulaField = DictDataLoad.dictElement[ElementKey.FormulaField].value;
            byType type = DictDataLoad.dictElement[ElementKey.FormulaField].type;

            return ElementLocator.FindElement(formulaField, type).GetAttribute("value");
        }
    }
}
