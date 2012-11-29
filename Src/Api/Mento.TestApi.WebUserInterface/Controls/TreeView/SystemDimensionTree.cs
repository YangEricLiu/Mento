using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class SystemDimensionTree : TreeView
    {
        private const string SYSTEMDIMENSIONTREECSSSELECTOR = "table.x-grid-table,.x-grid-table-resizer";
        private const string DIALOGXPATH = "div.x-window";
        private const string CHECKBOXXPATHFORMAT = "//tr[contains(@class,'x-grid-row') and td/div[text()='$#" + TREENODEVARIABLENAME + "']]//input";

        public SystemDimensionTree(Locator locator) :
            base(locator) 
        {
        }

        public void CheckNode(string nodeText)
        {
            Locator checkboxLocator = Locator.GetVariableLocator(CHECKBOXXPATHFORMAT,ByType.Xpath,TREENODEVARIABLENAME,nodeText);
            
            if (ElementHandler.Exists(checkboxLocator))
            {
                IWebElement checkbox = FindChild(checkboxLocator);

                if (!String.Equals(checkbox.GetAttribute("aria-checked"), "true", StringComparison.OrdinalIgnoreCase))
                {
                    ClickCheckbox(checkbox);

                    GetControl<LoadingMask>().WaitLoading();
                }
            }
        }
        
        public void CheckNodePath(string[] nodePath)
        {
            foreach (string nodeText in nodePath)
            {
                CheckNode(nodeText);

                TimeManager.PauseShort();

                ExpandNode(nodeText);
            }
        }

        private void ClickCheckbox(IWebElement checkbox)
        {
            ElementHandler.Click(checkbox, 0, 5);
        }
    }
}
