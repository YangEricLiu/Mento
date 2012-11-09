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
        private Navigator navigatorInstance = ControlAccess.GetControl<Navigator>();
        private FormulaField formulaInstance = ControlAccess.GetControl<FormulaField>();

        /// <summary>
        /// Navigate to Vtag
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToVtagSetting()
        {
            navigatorInstance.NavigateToTarget(NavigationTarget.TagSettingsV);
            ElementLocator.Pause(2000);
        }

        public void FocusOnTag(string tagName)
        {
            tagInstance.FocusOnRow(tagName);
        }

        #region Formula Operation
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
            FocusOnTag(tagName);
            ClickFormulaTab();

            FunctionWrapper.WaitForLoadingDisappeared(2000);
            ElementLocator.Pause(500);

            Locator updateLocator = ElementDictionary[ElementKey.FormulaUpdateButton];
            ElementLocator.FindElement(updateLocator).Click();
        }

        /// <summary>
        /// Click save button for formula
        /// </summary>
        /// <returns></returns>
        public void ClickSaveFormulaButton()
        {
            var locator = ElementDictionary[ElementKey.FormulaSaveButton];

            ElementLocator.FindElement(locator).Click();
        }

        /// <summary>
        /// Simulate the mouse drag formula tag list to formula field
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public void DragTagToFormula(string tagName)
        {
            formulaInstance.DragTag(tagName);
        }

        /// <summary>
        /// Fill the text to formula field, clear the field first, then input text
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public void FillInFormulaField(string context)
        {
            formulaInstance.FillIn(ElementKey.FormulaField, context);
        }

        /// <summary>
        /// Append the text to formula field, not clear the field first, input text to the end
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public void AppendFormulaField(string context)
        {
            formulaInstance.Append(ElementKey.FormulaField, context);
        }

        /// <summary>
        /// Get the value from formula field
        /// </summary>
        /// <returns></returns>
        public string GetFormulaValue()
        {
            return formulaInstance.GetValue();
        }

        #endregion

        #region Associcate Tag



        #endregion

    }
}
