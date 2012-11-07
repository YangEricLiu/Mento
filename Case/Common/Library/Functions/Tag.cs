using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of Tag(ptag/vtag/KPI).
    /// </summary>
    public class Tag
    {
        private static Dictionary<string, Locator> ElementDictionary = ResourceManager.GetElementDictionary();
        private Grid tagInstance = ControlAccess.GetControl<Grid>();

        /// <summary>
        /// Click Formula tab button to edit formula of vtag/KPI.
        /// </summary>
        /// <returns></returns>
        public void ClickFormulaTab()
        {
            Locator formulaLocator = ElementDictionary[ElementKey.FormulaTab];

            ElementLocator.FindElement(formulaLocator).Click();
        }

        /// <summary>
        /// Select one tag, open formula tab and click update button
        /// </summary>
        /// <param name="tagName">Tag name</param>
        /// <returns></returns>
        public void PrepareToAddFormula(string tagName)
        {
            tagInstance.FocusOnRow(tagName);
            ClickFormulaTab();

            Locator updateLocator = ElementDictionary[ElementKey.UpdateButton];
            ElementLocator.FindElement(updateLocator).Click();
        }
    }
}
