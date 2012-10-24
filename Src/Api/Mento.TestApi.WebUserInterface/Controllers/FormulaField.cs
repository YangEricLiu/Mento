using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controllers
{
    public class FormulaField : TextField
    {
        public static void DragTag(string tagName, string formulaField)
        {
            string tagPath = Element.TagNameRow.Replace(ManualElementName.tagName, tagName);

            IWebElement tagElement = ElementLocator.FindElement(tagPath, byType.Name);
            IWebElement formulaElement = ElementLocator.FindElement(Element.FormulaField, byType.Name);

            ElementLocator.FocusOn(tagElement);
            ElementLocator.DragAndDrop(tagElement, formulaElement);

        }
    }
}
