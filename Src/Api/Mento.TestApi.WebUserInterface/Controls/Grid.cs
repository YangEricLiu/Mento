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
        /// <summary>
        /// Simulate mouse focus on the row which "Name" is "cellName"
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void FocusOnRow(string cellName)
        {
            var locator = this.GetVariableLocator(ElementKey.RowCellName, ManualElementName.cellName, cellName);

            ElementLocator.FindElement(locator).Click();
        }

        /// <summary>
        /// Simulate mouse float on the row which "Name" is "cellName"
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void FloatOnRow(string cellName)
        {
            var locator = this.GetVariableLocator(ElementKey.RowCellName, ManualElementName.cellName, cellName);

            ElementLocator.FloatOn(ElementLocator.FindElement(locator));
        }
    }
}
