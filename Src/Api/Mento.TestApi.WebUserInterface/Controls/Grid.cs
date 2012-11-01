using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.Utility;

namespace Mento.TestApi.WebUserInterface
{
    public class Grid : JazzControlBase
    {
        public void FocusOnRow(string cellName)
        {
            var locator = this.GetVariableLocator(ElementKey.IsTreeNodeExpand, ManualElementName.cellName, cellName);

            ElementLocator.FindElement(locator).Click();
        }

        public void FloatOnRow(string cellName)
        {
            var locator = this.GetVariableLocator(ElementKey.IsTreeNodeExpand, ManualElementName.cellName, cellName);

            ElementLocator.FloatOn(ElementLocator.FindElement(locator));
        }
    }
}
