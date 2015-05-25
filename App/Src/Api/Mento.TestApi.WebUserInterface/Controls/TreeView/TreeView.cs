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
        protected const string POPTREENODEEXPANDCLASS = "fa-minus-square-o";
        protected const string POPTREENODECALLAPSECLASS = "fa-plus-square-o";

        #region pop tree locator

        private Locator Pop_ExpandTreeArrowLocator = new Locator("../div[@class='pop-arrow']/div[@class='pop-has-child']/div", ByType.XPath);

        #endregion

        #region Pop tree operation

        public void Pop_SelectNode(string[] nodePath)
        {

            List<string> parentNodes = nodePath.ToList();

            Pop_ExpandNodePath(parentNodes.ToArray());
            Pop_ClickNode(nodePath.Last());
        }

        public void Pop_ExpandNode(string nodeText)
        {
            //if the node is not expanded, click expand icon
            if (!Pop_IsNodeExpanded(nodeText))
            {
                Pop_ClickNodeExpander(nodeText);

                //pause to wait animate finish
                TimeManager.MediumPause();
            }
        }

        public Boolean Pop_ClickNode(string nodeText)
        {
            // Greenie modified
            TimeManager.LongPause();
            if (this.Pop_GetTreeNodeElement(nodeText).Enabled)
            {
                TimeManager.LongPause();
                this.Pop_GetTreeNodeElement(nodeText).Click();
                return true;
            }
            else
            {
                return false;
            }
            //TimeManager.PauseShort();

            //GetControl<LoadingMask>().WaitLoading();
        }

        public void Pop_ExpandNodePath(string[] nodesText)
        {
            for (int i = 0; i < nodesText.Length; i++)
            {
                Locator nextNodeLocator = (i < nodesText.Length - 1) ? Pop_GetTreeNodeLocator(nodesText[i + 1]) : null;

                //wait the next item appear
                if (nextNodeLocator != null)
                {
                    Pop_ExpandNode(nodesText[i]);
                    TimeManager.LongPause();
                }
            }
        }

        public bool Pop_IsNodeExpanded(string nodeText)
        {
            IWebElement nodeElement = Pop_GetTreeNodeElement(nodeText);
            IWebElement nodeExpandArrow = ElementHandler.FindElement(Pop_ExpandTreeArrowLocator, container: nodeElement);

            return nodeExpandArrow.GetAttribute("class").Split(' ').Contains(POPTREENODEEXPANDCLASS);
        }

        protected virtual Locator Pop_GetTreeNodeLocator(string nodeText)
        {
            return Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.PopTreeNode), TREENODEVARIABLENAME, nodeText);
        }

        protected virtual IWebElement Pop_GetTreeNodeElement(string nodeText)
        {
            return base.FindChild(Pop_GetTreeNodeLocator(nodeText));
        }

        private void Pop_ClickNodeExpander(string nodeText)
        {
            IWebElement nodeElement = Pop_GetTreeNodeElement(nodeText);
            IWebElement nodeExpandArrow = ElementHandler.FindElement(Pop_ExpandTreeArrowLocator, container: nodeElement);

            nodeExpandArrow.Click();
        }

        #endregion

        #region Not Pop
        
        public TreeView(Locator rootLocator, ISearchContext parentContainer = null) : base(rootLocator, parentContainer: parentContainer) { }

        public void SelectNode(string[] nodePath)
        {

            List<string> parentNodes = nodePath.ToList();
            //parentNodes.Remove(nodePath.Last());

            ExpandNodePath(parentNodes.ToArray());
            ClickNode(nodePath.Last());
        }

        public Boolean ClickNode(string nodeText)
        {
            // Greenie modified
            TimeManager.LongPause();
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

        public void ExpandNode(string nodeText)
        {
            //if the node is not expanded, click expand icon
            if (!IsNodeExpanded(nodeText))
            {
                ClickNodeExpander(nodeText);

                //pause to wait animate finish
                TimeManager.MediumPause();
            }
        }

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

        public void FocusOnNode(string nodeText)
        {
            Locator nodeLocator = GetTreeNodeLocator(nodeText);

            ElementHandler.Focus(nodeLocator, container: RootElement);
        }
        
        public bool IsNodeExpanded(string nodeText)
        {
            IWebElement node = GetTreeNodeElement(nodeText);

            return node.GetAttribute("class").Split(' ').Contains(TREENODEEXPANDCLASS);
        }

        public bool IsNodeChecked(string nodeText)
        {
            IWebElement node = GetTreeNodeElement(nodeText);

            return GetCheckboxElement(node).GetAttribute("class").Contains(TREENODECHECKEDCLASS);
        }

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

        public int GetNodeIndentation(string nodeText)
        {
            IWebElement node = GetTreeNodeElement(nodeText);

            Locator indentationIconLocator = new Locator("img", ByType.TagName);

            return ElementHandler.FindElements(indentationIconLocator, container: node).Length;//.FindElements(indentationIconLocator.ToBy()).Count - 1;
        }

        #endregion

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
