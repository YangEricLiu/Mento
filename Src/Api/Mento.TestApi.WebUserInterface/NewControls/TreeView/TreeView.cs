using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.Framework.Constants;

namespace Mento.TestApi.WebUserInterface.NewControls
{
    public abstract class TreeView : JazzControl
    {
        protected const string TREENODEVARIABLENAME = "nodeText";
        private const string TREENODEXPATH = "tbody/tr[contains(@class,'x-grid-row') and td/div[text()='$#" + TREENODEVARIABLENAME + "']]";
        private const string TREENODEIMGSXPATH = "td/div/img";
        private const string TREENODEEXPANDCLASS = "x-grid-tree-node-expanded";


        public TreeView(Locator rootLocator, ISearchContext parentContainer = null) : base(rootLocator, parentContainer: parentContainer) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeText"></param>
        public void ClickNode(string nodeText)
        {
            this.GetTreeNodeElement(nodeText).Click();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeText"></param>
        public void ExpandNode(string nodeText)
        {
            //if the node is not expanded, click expand icon
            if (!IsNodeExpanded(nodeText))
            {
                ClickNodeExpander(nodeText);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodesText"></param>
        public void ExpandNodePath(string[] nodesText)
        {
            for (int i = 0; i < nodesText.Length; i++)
            {
                Locator nextNodeLocator = (i < nodesText.Length - 1) ? GetTreeNodeLocator(nodesText[i + 1]) : null;

                //click item
                ExpandNode(nodesText[i]);

                //wait the next item appear
                if (nextNodeLocator != null)
                    ElementHandler.Wait(nextNodeLocator, WaitType.ToAppear);

                ElementLocator.Pause(500);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeText"></param>
        public void CollapseNode(string nodeText)
        {
            //if the node is expanded, click expand icon
            if (IsNodeExpanded(nodeText))
            {
                ClickNodeExpander(nodeText);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeText"></param>
        public void FocusOnNode(string nodeText)
        {
            Locator nodeLocator = GetTreeNodeLocator(nodeText);

            ElementHandler.Focus(nodeLocator, parentElement: RootElement);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeText"></param>
        /// <returns></returns>
        public bool IsNodeExpanded(string nodeText)
        {
            IWebElement node = GetTreeNodeElement(nodeText);

            return node.GetAttribute("class").Split(' ').Contains(TREENODEEXPANDCLASS);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeText"></param>
        /// <returns></returns>
        public bool IsNodeDisplayed(string nodeText)
        {
            Locator nodeLocator = GetTreeNodeLocator(nodeText);

            return ElementHandler.Displayed(nodeLocator, parentElement: RootElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentNodeText"></param>
        /// <param name="childNodeText"></param>
        /// <returns></returns>
        public bool IsChildNodeOfParent(string parentNodeText, string childNodeText)
        {
            var parentElement = GetTreeNodeElement(parentNodeText);
            var childLocator = GetTreeNodeLocator(childNodeText);

            CollapseNode(parentNodeText);            

            //when parent node is collapsed, child node does not display
            if (!ElementHandler.Displayed(childLocator, parentElement: parentElement))
            {
                ExpandNode(parentNodeText);

                //when parent node is expanded, child node displays
                if (ElementHandler.Displayed(childLocator, parentElement: parentElement))
                    //and child identation is one level less than parent node
                    return GetNodeIndentation(parentNodeText) - 1 == GetNodeIndentation(childNodeText);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeText"></param>
        /// <returns></returns>
        public int GetNodeIndentation(string nodeText)
        {
            IWebElement node = GetTreeNodeElement(nodeText);

            Locator indentationIconLocator = new Locator("//img",ByType.Xpath);

            return node.FindElements(indentationIconLocator.ToBy()).Count - 1;
        }

        #region private methods
        protected virtual Locator GetTreeNodeLocator(string nodeText)
        {
            return Locator.GetVariableLocator(TREENODEXPATH, ByType.Xpath, TREENODEVARIABLENAME, nodeText);
        }

        protected virtual IWebElement GetTreeNodeElement(string nodeText)
        {
            return base.FindElement(GetTreeNodeLocator(nodeText));
        }

        private void ClickNodeExpander(string nodeText)
        {
            IWebElement node = GetTreeNodeElement(nodeText);

            GetExpanderElement(node).Click();
        }

        private IWebElement GetExpanderElement(IWebElement nodeElement)
        {
            Locator imageButtonsLocator = new Locator(TREENODEIMGSXPATH, ByType.Xpath);

            IWebElement[] imageButtons = nodeElement.FindElements(imageButtonsLocator.ToBy()).ToArray();

            return imageButtons[imageButtons.Length - 2];
        }
        #endregion
    }
}
