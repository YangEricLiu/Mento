using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Mento.TestApi.WebUserInterface
{
    public class TreeView : ControllerBase
    {
        public Boolean IsExpand(string treeNodeName)
        {
            string nodeExpandPath = Ele.IsTreeNodeExpand.Replace(ManualElementName.treeNodeName, treeNodeName);

            return ElementLocator.IsElementPresent(nodeExpandPath, byType.Xpath);
        }

        public void Expand(string treeNodeName)
        {
            string nodePath = Ele.TreeNode.Replace(ManualElementName.treeNodeName, treeNodeName);

            IWebElement nodeLocator = ElementLocator.FindElement(nodePath, byType.Xpath);

            ElementLocator.FocusOn(nodeLocator);

            if (!IsExpand(treeNodeName))
            {
                ElementLocator.DoubleClick(nodeLocator);
            }
        }

        public void Collapse(string treeNodeName)
        {
            string nodePath = Ele.TreeNode.Replace(ManualElementName.treeNodeName, treeNodeName);

            IWebElement nodeLocator = ElementLocator.FindElement(nodePath, byType.Xpath);

            ElementLocator.FocusOn(nodeLocator);

            if (IsExpand(nodeName))
            {
                ElementLocator.DoubleClick(nodeLocator);
            }
        }

    }
}
