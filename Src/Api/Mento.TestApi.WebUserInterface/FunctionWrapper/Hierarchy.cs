using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;

namespace Mento.TestApi.WebUserInterface
{
    public class Hierarchy
    {
        private TreeView controlInstance = ControlAccess.GetControl<TreeView>();

        private void PrepareToAddNode(string treeNodeName)
        {
            string nodePath = Element.TreeNode.Replace(ManualElementName.treeNodeName, treeNodeName);

            ElementLocator.FocusOn(ElementLocator.FindElement(nodePath, byType.Xpath));

            ElementLocator.FindElement(Element.AddHierarchyButton, byType.ID).Click();
        }

        public void AddHierarchynode(string treeNodeName, Array inputData)
        {
            PrepareToAddNode(treeNodeName);



        }
    }
}
