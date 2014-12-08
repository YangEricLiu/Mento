using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.Framework.Constants;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public abstract class TreeView : JazzControl
    {
        protected const string TREENODEVARIABLENAME = "nodeText";
        protected const string TREENODEEXPANDCLASS = "x-grid-tree-node-expanded";
        protected const string TREENODECHECKEDCLASS = "x-tree-checkbox-checked";

        public TreeView(Locator rootLocator, ISearchContext parentContainer = null) : base(rootLocator, parentContainer: parentContainer) { }

        /// <summary>
        /// 1. expand to the disired node
        /// 2. click the node
        /// </summary>
        /// <param name="nodesText"></param>
        public void SelectNode(string[] nodePath)
        {

            List<string> parentNodes = nodePath.ToList();
            //parentNodes.Remove(nodePath.Last());

            ExpandNodePath(parentNodes.ToArray());
            ClickNode(nodePath.Last());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeText"></param>
        public Boolean ClickNode(string nodeText)
        {
            // Greenie modified
            TimeManager.ShortPause();
            if (this.GetTreeNodeElement(nodeText).Enabled)
            {
                TimeManager.LongPause();
                this.GetTreeNodeElement(nodeText).Click();
                return true;
            }
            else
            {
                return false;
            }
            //TimeManager.PauseShort();

            //GetControl<LoadingMask>().WaitLoading();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeText"></param>
        public void ExpandNode(string nodeText)
        {
            //if the node is not expanded, click expand icon
            //if (!IsNodeExpanded(nodeText))
            //{
            //    ClickNodeExpander(nodeText);

            //    //pause to wait animate finish
            //    TimeManager.MediumPause();
            //}

            //For a bug, it should click twice when the node is expanded
            ClickNodeExpander(nodeText);
            TimeManager.MediumPause();
            if (!IsNodeExpanded(nodeText))
            {
                ClickNodeExpander(nodeText);
                TimeManager.MediumPause();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeText"></param>
        public void CheckNode(string nodeText)
        {
            //if the node is not expanded, click expand icon
            if (!IsNodeChecked(nodeText))
            {
                ClickNodeCheckbox(nodeText);

                //pause to wait animate finish
                TimeManager.MediumPause();
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
                //ExpandNode(nodesText[i]);

                //wait the next item appear
                if (nextNodeLocator != null)
                {
                    ExpandNode(nodesText[i]);
                    ElementHandler.Wait(nextNodeLocator, WaitType.ToAppear, container: this.RootElement);
                    TimeManager.Pause(500);
                }
                TimeManager.Pause(500);
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

                //pause to wait animate finish
                TimeManager.MediumPause();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeText"></param>
        public void UncheckNode(string nodeText)
        {
            //if the node is expanded, click expand icon
            if (IsNodeChecked(nodeText))
            {
                ClickNodeCheckbox(nodeText);

                //pause to wait animate finish
                TimeManager.MediumPause();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeText"></param>
        public void FocusOnNode(string nodeText)
        {
            Locator nodeLocator = GetTreeNodeLocator(nodeText);

            ElementHandler.Focus(nodeLocator, container: RootElement);
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
        public bool IsNodeChecked(string nodeText)
        {
            IWebElement node = GetTreeNodeElement(nodeText);

            return GetCheckboxElement(node).GetAttribute("class").Contains(TREENODECHECKEDCLASS);
        }
        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeText"></param>
        /// <returns></returns>
        public bool IsNodeCheckerExisted(string nodeText)
        {
            IWebElement node = GetTreeNodeElement(nodeText);

            return GetCheckboxElement(node).GetAttribute("class").Contains(TREENODECHECKEDCLASS);
        }
        */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeText"></param>
        /// <returns></returns>
        public bool IsNodeDisplayed(string nodeText)
        {
            Locator nodeLocator = GetTreeNodeLocator(nodeText);

            return ElementHandler.Displayed(nodeLocator, container: RootElement);
        }

        public bool IsNodeDisabled(string nodeText)
        {
            IWebElement nodeElement= GetTreeNodeElement(nodeText);

            return nodeElement.GetAttribute("class").Contains("x-grid-tree-node-disabled");
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
            if (!ElementHandler.Displayed(childLocator, container: this.RootElement))
            {
                ExpandNode(parentNodeText);

                //when parent node is expanded, child node displays
                if (ElementHandler.Displayed(childLocator, container: this.RootElement))
                    //and child identation is one level less than parent node
                    return GetNodeIndentation(parentNodeText) + 1 == GetNodeIndentation(childNodeText);
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

            Locator indentationIconLocator = new Locator("img", ByType.TagName);

            return ElementHandler.FindElements(indentationIconLocator, container: node).Length;//.FindElements(indentationIconLocator.ToBy()).Count - 1;
        }

        #region private methods
        protected virtual Locator GetTreeNodeLocator(string nodeText)
        {
            return Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.TreeNode), TREENODEVARIABLENAME, nodeText);
        }

        protected virtual IWebElement GetTreeNodeElement(string nodeText)
        {
            return base.FindChild(GetTreeNodeLocator(nodeText));
        }

        private void ClickNodeExpander(string nodeText)
        {
            IWebElement node = GetTreeNodeElement(nodeText);

            GetExpanderElement(node).Click();
        }

        private IWebElement GetExpanderElement(IWebElement nodeElement)
        {
            Locator imageButtonsLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.TreeNodeImage);

            IWebElement[] imageButtons = ElementHandler.FindElements(imageButtonsLocator, nodeElement);// nodeElement.FindElements(imageButtonsLocator.ToBy()).ToArray();

            return imageButtons[imageButtons.Length - 2];
        }

        private void ClickNodeCheckbox(string nodeText)
        {
            IWebElement node = GetTreeNodeElement(nodeText);

            GetCheckboxElement(node).Click();
        }

        private IWebElement GetCheckboxElement(IWebElement nodeElement)
        {
            Locator checkboxInputLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.TreeNodeCheckbox);

            IWebElement checkboxInput = ElementHandler.FindElement(checkboxInputLocator, nodeElement);// nodeElement.FindElements(imageButtonsLocator.ToBy()).ToArray();

            return checkboxInput;
        }


        #endregion
    }
}
