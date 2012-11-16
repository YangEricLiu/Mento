using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;

namespace Mento.ScriptCommon.Library.Functions
{
    public class Associate
    {
        private static Dictionary<string, Locator> ElementDictionary = ResourceManager.GetElementDictionary();

        private Navigator navigatorInstance = ControlAccess.GetControl<Navigator>();
        private TreeView treeViewInstance = ControlAccess.GetControl<TreeView>();
        private Grid gridInstance = ControlAccess.GetControl<Grid>();

        /// <summary>
        /// Navigate to hierarchy associate setting
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigateToHierarchyAssociate()
        {
            navigatorInstance.NavigateToTarget(NavigationTarget.AssociationHierarchy);
        }

        /// <summary>
        /// Click the check box in the front of tag
        /// </summary>
        /// <param name = "tagName">the tag name</param>
        /// <returns></returns>
        public void CheckedTag(string tagName)
        {
            gridInstance.CheckedGridRowCheckbox(tagName);
        }

        /// <summary>
        /// Click the "associate tags" button
        /// </summary>
        /// <returns></returns>
        public void ClickAssociateTagButton()
        { 
            var locator = ElementDictionary[ElementKey.AssociateTagButton];
            
            ElementLocator.FindElement(locator).Click();
        }

        /// <summary>
        /// Click the "associate" button
        /// </summary>
        /// <returns></returns>
        public void ClickAssociateButton()
        { 
            var locator = ElementDictionary[ElementKey.AssociateButton];
            ElementLocator.FindElement(locator).Click();
        }

        /// <summary>
        /// Judge if the associated tag is displayed
        /// </summary>
        /// <returns>True if the tag displayed, false if not</returns>
        public Boolean IsTagOnAssociategGridView(string tagName)
        {
            var locator = gridInstance.GetManualTagLocator(ElementKey.IsTagOnAssociateGrid, ManualElementName.tagName, tagName);
            
            return ElementLocator.IsElementPresent(locator);
        }
    }
}
