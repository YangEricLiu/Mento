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
        public Boolean IsExpand(string treeNodeName)
        {
            //string nodeExpandPath = DictDataLoad.dictElement[ElementKey.IsTreeNodeExpand].Value.Replace(ManualElementName.treeNodeName, treeNodeName);
            //ByType type = DictDataLoad.dictElement[ElementKey.TreeNode].Type;

            var locator = this.GetVariableLocator(ElementKey.IsTreeNodeExpand, ManualElementName.treeNodeName, treeNodeName);

            return ElementLocator.IsElementPresent(locator);
        }

        public void FocusOnTreeNode(string treeNodeName)
        {
            //string nodePath = DictDataLoad.dictElement[ElementKey.TreeNode].Value.Replace(ManualElementName.treeNodeName, treeNodeName);
            //ByType type = DictDataLoad.dictElement[ElementKey.TreeNode].Type;

            var locator = this.GetVariableLocator(ElementKey.TreeNode, ManualElementName.treeNodeName, treeNodeName);

            IWebElement nodeLocator = ElementLocator.FindElement(locator);
            ElementLocator.FocusOn(nodeLocator);
        }

        public void DoubleClickTreeNode(string treeNodeName)
        {
            //string nodePath = DictDataLoad.dictElement[ElementKey.TreeNode].Value.Replace(ManualElementName.treeNodeName, treeNodeName);
            //ByType type = DictDataLoad.dictElement[ElementKey.TreeNode].Type;

            var locator = this.GetVariableLocator(ElementKey.TreeNode, ManualElementName.treeNodeName, treeNodeName);

            IWebElement nodeLocator = ElementLocator.FindElement(locator);
            ElementLocator.DoubleClick(nodeLocator);
        }

        public void Expand(string treeNodeName)
        {
            FocusOnTreeNode(treeNodeName);

            if (!IsExpand(treeNodeName))
            {
                DoubleClickTreeNode(treeNodeName);
            }
        }

        public void Collapse(string treeNodeName)
        {
            FocusOnTreeNode(treeNodeName);

            if (IsExpand(treeNodeName))
            {
                DoubleClickTreeNode(treeNodeName);
            }
        }

        public Boolean IsNodesParentChild(string nodeChild, string nodeParent)
        {
            Boolean isChildExisted = false; 
            Boolean isChild = false;

            Collapse(nodeParent);
            var locatorChild = this.GetVariableLocator(ElementKey.TreeNode, ManualElementName.treeNodeName, nodeChild);
            isChildExisted = ElementLocator.IsElementPresent(locatorChild);

            if (!isChildExisted)
            {
                Expand(nodeParent);
                isChild = ElementLocator.IsElementPresent(locatorChild);
            }

            return isChild;
        }
    }
}
