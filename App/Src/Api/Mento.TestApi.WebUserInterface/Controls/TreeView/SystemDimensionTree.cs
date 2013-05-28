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
        private const string UNCHECKMESSAGE = "您将同时删除系统维度节点下所有的数据点关联关系。";
        private const string UNCHECKBOXCONFIRMBUTTON = "//span[text() = '是']";

        public SystemDimensionTree(Locator locator) :
            base(locator) 
        {
        }

        public void CheckNode(string nodeText)
        {
            Locator checkboxLocator = Locator.GetVariableLocator(CHECKBOXXPATHFORMAT,ByType.XPath,TREENODEVARIABLENAME,nodeText);

            if (ElementHandler.Exists(checkboxLocator))
            {
                IWebElement checkbox = FindChild(checkboxLocator);
                //Console.WriteLine("checkbox: " + nodeText + ", at point:" + checkbox.Location.X + "," + checkbox.Location.Y);

                if (!String.Equals(checkbox.GetAttribute("aria-checked"), "true", StringComparison.OrdinalIgnoreCase))
                {
                    ClickCheckbox(checkbox);
                    GetControl<LoadingMask>().WaitLoading();
                }
            }
        }

        public void UncheckNode(string nodeText)
        {
            Locator uncheckboxLocator = Locator.GetVariableLocator(CHECKBOXXPATHFORMAT, ByType.XPath, TREENODEVARIABLENAME, nodeText);
            Locator confirmUncheckboxButton = new Locator(UNCHECKBOXCONFIRMBUTTON, ByType.XPath);

            if (ElementHandler.Exists(uncheckboxLocator))
            {
                IWebElement checkbox = FindChild(uncheckboxLocator);
                //Console.WriteLine("checkbox: " + nodeText + ", at point:" + checkbox.Location.X + "," + checkbox.Location.Y);

                if (String.Equals(checkbox.GetAttribute("aria-checked"), "true", StringComparison.OrdinalIgnoreCase))
                {
                    ClickCheckbox(checkbox);

                    if (GetControl<MessageBox>().GetMessage().Contains(UNCHECKMESSAGE))
                    {
                        ElementHandler.FindElement(confirmUncheckboxButton).Click();

                        GetControl<LoadingMask>().WaitLoading();
                    }
                }
            }     
        }
        
        public void CheckNodePath(string[] nodePath)
        {
            foreach (string nodeText in nodePath)
            {
                CheckNode(nodeText);

                ExpandNode(nodeText);

                TimeManager.MediumPause();
            }
        }

        public void UncheckNodePath(string[] nodePath)
        {
            for (int i = 0; i < (nodePath.Length - 1); i++ )
            {
                ExpandNode(nodePath[i]);

                TimeManager.MediumPause();
            }

            for (int i = (nodePath.Length - 1); i > -1; i--)
            {
                UncheckNode(nodePath[i]);

                TimeManager.MediumPause();
            }
        }

        private void ClickCheckbox(IWebElement checkbox)
        {
            ElementHandler.Click(checkbox, 0, 5);
        }
    }
}
