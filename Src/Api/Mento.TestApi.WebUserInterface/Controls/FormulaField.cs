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
            //string tagPath = DictDataLoad.dictElement[ElementKey.TagNameRow].Value.Replace(ManualElementName.tagName, tagName);
            //ByType type1 = DictDataLoad.dictElement[ElementKey.TagNameRow].Type;

            //string formulaField = DictDataLoad.dictElement[ElementKey.FormulaField].Value;
            //ByType type2 = DictDataLoad.dictElement[ElementKey.FormulaField].Type;

            var tagLocator = this.GetVariableLocator(ElementKey.TagNameRow, "tagName", tagName);
            var formulaLocator = ElementDictionary[ElementKey.FormulaField];

            IWebElement tagElement = ElementLocator.FindElement(tagLocator);
            IWebElement formulaElement = ElementLocator.FindElement(formulaLocator);

            ElementLocator.FocusOn(tagElement);
            ElementLocator.DragAndDrop(tagElement, formulaElement);
        }

        public string GetValue()
        {
            //string formulaField = DictDataLoad.dictElement[ElementKey.FormulaField].Value;
            //ByType type = DictDataLoad.dictElement[ElementKey.FormulaField].Type;
            var formulaLocator = ElementDictionary[ElementKey.FormulaField];

            return ElementLocator.FindElement(formulaLocator).GetAttribute("value");
        }
    }
}
