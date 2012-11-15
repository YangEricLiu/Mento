using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.Utility;

namespace Mento.TestApi.WebUserInterface
{
    /// <summary>
    /// Include the basic action of the grid.
    /// </summary>
    /// <remarks>Inherited from control basic class.</remarks>
    public class Grid : JazzControlBase
    {
        public Locator GetManualTagLocator(string key, string manualKey, string cellName)
        {
            return this.GetVariableLocator(key, manualKey, cellName);
        }
        
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

        public Boolean IsGridRowChecked(string cellName)
        {
            var locator = this.GetVariableLocator(ElementKey.IsRowChecked, ManualElementName.cellName, cellName);

            return ElementLocator.IsElementPresent(locator);
        }
        
        
        /// <summary>
        /// Simulate mouse checked checkbox in the front of one grid row
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void CheckedGridRowCheckbox(string cellName)
        {
            var locator = this.GetVariableLocator(ElementKey.RowCheckBox, ManualElementName.cellName, cellName);

            if (!IsGridRowChecked(cellName))
            {
                ElementLocator.FindElement(locator).Click();
            }
        }

        /// <summary>
        /// Simulate mouse unchecked checkbox in the front of one grid row
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void UnCheckedGridRowCheckbox(string cellName)
        {
            var locator = this.GetVariableLocator(ElementKey.RowCheckBox, ManualElementName.cellName, cellName);

            if (IsGridRowChecked(cellName))
            {
                ElementLocator.FindElement(locator).Click();
            }
        }
    }
}
