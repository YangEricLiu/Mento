using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface
{
    public class TreeView : ControllerBase
    {
        public static Boolean IsExpand(string treeNodeName)
        {
            string nodeExpandPath = Ele.IsTreeNodeExpand.Replace(ManualElementName.treeNodeName, treeNodeName);

            return ElementLocator.IsElementPresent(nodeExpandPath, byType.Xpath);
        }

        public static void Expand(string treeNodeName)
        {
            string nodePath = Ele.TreeNode.Replace(ManualElementName.treeNodeName, treeNodeName);

            IWebElement nodeLocator = ElementLocator.FindElement(nodePath, byType.Xpath);

            ElementLocator.FocusOn(nodeLocator);

            if (!IsExpand(treeNodeName))
            {
                ElementLocator.DoubleClick(nodeLocator);
            }
        }

        public static void Collapse(string treeNodeName)
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
