using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.Utility;

namespace Mento.TestApi.WebUserInterface
{
    public class TreeView : JazzControlBase
    {
        public Locator GetTreeNodeLocator(string treeNodeName)
        {
            return this.GetVariableLocator(ElementKey.TreeNode, ManualElementName.treeNodeName, treeNodeName);
        }

        /// <summary>
        /// Judge if the tree node is expanded yet
        /// </summary>
        /// <param name="treeNodeName"></param>
        /// <returns>true if it is expanded, false if not</returns>
        public Boolean IsExpand(string treeNodeName)
        {
            var locator = this.GetVariableLocator(ElementKey.IsTreeNodeExpand, ManualElementName.treeNodeName, treeNodeName);

            return ElementLocator.IsElementPresent(locator);
        }

        /// <summary>
        /// Simulate the mouse focus on the tree node
        /// </summary>
        /// <param name="treeNodeName"></param>
        /// <returns></returns>
        public void FocusOnTreeNode(string treeNodeName)
        {
            var locator = GetTreeNodeLocator(treeNodeName);

            IWebElement nodeLocator = ElementLocator.FindElement(locator);
            ElementLocator.FocusOn(nodeLocator);
        }

        /// <summary>
        /// Simulate the mouse double click the tree node
        /// </summary>
        /// <param name="treeNodeName"></param>
        /// <returns></returns>
        public void DoubleClickTreeNode(string treeNodeName)
        {
            var locator = GetTreeNodeLocator(treeNodeName);

            IWebElement nodeLocator = ElementLocator.FindElement(locator);
            ElementLocator.DoubleClick(nodeLocator);
        }

        /// <summary>
        /// Expand the tree node if the node is collapsed
        /// </summary>
        /// <param name="treeNodeName"></param>
        /// <returns></returns>
        public void Expand(string treeNodeName)
        {
            FocusOnTreeNode(treeNodeName);
            if (!IsExpand(treeNodeName))
            {
                DoubleClickTreeNode(treeNodeName);
                ElementLocator.pause(1000);
            }
        }

        /// <summary>
        /// Collapse the tree node if the node is expanded
        /// </summary>
        /// <param name="treeNodeName"></param>
        /// <returns></returns>
        public void Collapse(string treeNodeName)
        {
            FocusOnTreeNode(treeNodeName);

            if (IsExpand(treeNodeName))
            {
                DoubleClickTreeNode(treeNodeName);
                ElementLocator.pause(1000);
            }
        }

        /// <summary>
        /// Judge if the tree node is present
        /// </summary>
        /// <param name="treeNodeName"></param>
        /// <returns>true if it is present, false if not</returns>
        public Boolean IsTreeNodePresent(string treeNodeName)
        {
            var locator = GetTreeNodeLocator(treeNodeName);

            return ElementLocator.IsElementPresent(locator);
        }

        /// <summary>
        /// Judge if the tree node is displayed, which check "style" attribute to determine visibility of an element.
        /// </summary>
        /// <param name="treeNodeName"></param>
        /// <returns>true if it is displayed, false if not</returns>
        public Boolean IsTreeNodeDisplayed(string treeNodeName)
        {
            var locator = GetTreeNodeLocator(treeNodeName);

            return ElementLocator.IsElementDisplayed(locator);
        }

        /// <summary>
        /// Judge if one node is the child node of anther
        /// </summary>
        /// <param name="nodeChild"></param>
        /// <param name="nodeParent"></param>
        /// <returns>True if the nodes are child-parent, false if not</returns>
        public Boolean IsNodesParentChild(string nodeChild, string nodeParent)
        {
            Boolean isChildExisted = false; 
            Boolean isChild = false;

            Collapse(nodeParent);

            var locatorChild = GetTreeNodeLocator(nodeChild);
            isChildExisted = ElementLocator.IsElementPresent(locatorChild);

            if (false == isChildExisted)
            {
                Expand(nodeParent);
                isChild = ElementLocator.IsElementPresent(locatorChild);
            }

            return isChild;
        }
    }
}
