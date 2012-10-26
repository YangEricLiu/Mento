using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.Utility;

namespace Mento.TestApi.WebUserInterface
{
    public class TreeView : ControllerBase
    {
        public Boolean IsExpand(string treeNodeName)
        {
            string nodeExpandPath = DictDataLoad.dictManualElement[ElementKey.IsTreeNodeExpand].value.Replace(ManualElementName.treeNodeName, treeNodeName);
            byType type = DictDataLoad.dictManualElement[ElementKey.TreeNode].type;

            return ElementLocator.IsElementPresent(nodeExpandPath, type);
        }

        public void FocusOnTreeNode(string treeNodeName)
        {
            string nodePath = DictDataLoad.dictManualElement[ElementKey.TreeNode].value.Replace(ManualElementName.treeNodeName, treeNodeName);
            byType type = DictDataLoad.dictManualElement[ElementKey.TreeNode].type;

            IWebElement nodeLocator = ElementLocator.FindElement(nodePath, type);
            ElementLocator.FocusOn(nodeLocator);
        }

        public void DoubleClickTreeNode(string treeNodeName)
        {
            string nodePath = DictDataLoad.dictManualElement[ElementKey.TreeNode].value.Replace(ManualElementName.treeNodeName, treeNodeName);
            byType type = DictDataLoad.dictManualElement[ElementKey.TreeNode].type;

            IWebElement nodeLocator = ElementLocator.FindElement(nodePath, type);
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
    }
}
