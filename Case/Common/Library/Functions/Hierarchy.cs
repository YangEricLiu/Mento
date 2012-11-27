using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Customer;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of hierarchy setting.
    /// </summary>
    public class Hierarchy
    {
        private static Dictionary<string, Locator> ElementDictionary = ResourceManager.GetElementDictionary();

        private TreeView treeViewInstance = ControlAccess.GetControl<TreeView>();
        private TextField textFieldInstance = ControlAccess.GetControl<TextField>();
        private ComboBox comboBoxInstance = ControlAccess.GetControl<ComboBox>();
        private Navigator navigatorInstance = ControlAccess.GetControl<Navigator>();

        /// <summary>
        /// Click one hierarchy node then click "add hierarchy" button
        /// </summary>
        /// <param name="treeNodeName">Hierarchy node name</param>
        /// <returns></returns>
        public void PrepareToAddNode(string treeNodeName)
        {
            var locator = ElementDictionary[ElementKey.AddHierarchyButton];

            treeViewInstance.FocusOnTreeNode(treeNodeName);

            ElementLocator.FindElement(locator).Click();
        }

        /// <summary>
        /// Click one hierarchy node
        /// </summary>
        /// <param name="treeNodeName">Hierarchy node name</param>
        /// <returns></returns>
        public void FocusOnHierarchyNode(string treeNodeName)
        {
            treeViewInstance.FocusOnTreeNode(treeNodeName);
        }

        /// <summary>
        /// Navigate to hierarchy setting
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToHSetting()
        {
            navigatorInstance.NavigateToTarget(NavigationTarget.Settings);
            ElementLocator.Pause(500);
            navigatorInstance.NavigateToTarget(NavigationTarget.HierarchySettings);
        }

        /// <summary>
        /// Click save button to add new hierarchy node
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            var locator = ElementDictionary[ElementKey.HierarchySaveButton];

            ElementLocator.FindElement(locator).Click();
        }

        /// <summary>
        /// Click cancel button to cancel add new hierarchy node
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCancelButton()
        {
            var locator = ElementDictionary[ElementKey.HierarchyCancelButton];

            ElementLocator.FindElement(locator).Click();
        }

        /// <summary>
        /// Input name, code type and comments of the new hierarchy node 
        /// </summary>
        /// <param name="treeNodeName">Parent hierarchy node name</param>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInHierarchyNode(string treeNodeName, HierarchyInputData input)
        {
            PrepareToAddNode(treeNodeName);

            textFieldInstance.FillIn(ElementKey.HierarchyName, input.Name);
            textFieldInstance.FillIn(ElementKey.HierarchyCode, input.Code);
            comboBoxInstance.DisplayItems(ElementKey.HierarchyType);
            comboBoxInstance.SelectItem(input.Type);
            textFieldInstance.FillIn(ElementKey.HierarchyComment, input.Comment);
        }

        /// <summary>
        /// Input name of the new hierarchy node 
        /// </summary>
        /// <param name="name">Hierarchy node name</param>
        /// <returns></returns>
        public void FillInName(string name)
        {
            textFieldInstance.FillIn(ElementKey.HierarchyName, name);
        }

        /// <summary>
        /// Input code of the new hierarchy node 
        /// </summary>
        /// <param name="code">Hierarchy node code</param>
        /// <returns></returns>
        public void FillInCode(string code)
        {
            textFieldInstance.FillIn(ElementKey.HierarchyCode, code);
        }

        /// <summary>
        /// Input type of the new hierarchy node 
        /// </summary>
        /// <param name="type">Hierarchy node type</param>
        /// <returns></returns>
        public void FillInType(string type)
        {
            comboBoxInstance.DisplayItems(ElementKey.HierarchyType);
            comboBoxInstance.SelectItem(type);
        }

        /// <summary>
        /// Input comment of the new hierarchy node 
        /// </summary>
        /// <param name="code">Hierarchy comment code</param>
        /// <returns></returns>
        public void FillInComment(string comment)
        {
            textFieldInstance.FillIn(ElementKey.HierarchyComment, comment);
        }

        /// <summary>
        /// After click save button, waiting for add successful message box pop up
        /// </summary>
        /// <param name="timeout">Waiting time</param>
        /// <returns></returns>
        public void WaitForCreateOKDisplay(int timeout)
        { 
            var locator = ElementDictionary[ElementKey.HierarchyCreateOKText];

            ElementLocator.WaitForElement(locator, timeout);
        }

        /// <summary>
        /// Confirm the add successful popup message box
        /// </summary>
        /// <returns></returns>
        public void ConfirmCreateOKMagBox()
        {
            var locator = ElementDictionary[ElementKey.HierarchyOKButton];

            ElementLocator.FindElement(locator).Click();
        }

        /// <summary>
        /// Judge whether the nodes are Child-Parent
        /// </summary>
        /// <param name="nodeChild">Child node name</param>
        /// <param name="nodeParent">Parent node name</param>
        /// <returns>True if the nodes are Child-Parent, false if not</returns>
        public Boolean IsNodesChildParent(string nodeChild, string nodeParent)
        {
            return treeViewInstance.IsNodesParentChild(nodeChild, nodeParent);
        }

        /// <summary>
        /// Judge whether the hierarchy is present
        /// </summary>
        /// <param name="treeNodeName">Hierarchy node name</param>
        /// <returns>True if the node is present, false if not</returns>
        public Boolean IsTreeNodePresent(string treeNodeName)
        {
            return treeViewInstance.IsTreeNodePresent(treeNodeName);
        }

        /// <summary>
        /// Collapse the hierarchy  node
        /// </summary>
        /// <param name = "treeNodeName">Hierarchy node name which will be collapsed</param>
        /// <returns></returns>
        public void CollapseNode(string treeNodeName)
        {
            treeViewInstance.Collapse(treeNodeName);
        }

        /// <summary>
        /// Expand the hierarchy  node
        /// </summary>
        /// <param name = "treeNodeName">Hierarchy node name which will be expanded</param>
        /// <returns></returns>
        public void ExpandNode(string treeNodeName)
        {
            treeViewInstance.Expand(treeNodeName);
        }

        /// <summary>
        /// Get the hierarchy type expected value, for language sencitive
        /// </summary>
        /// <param name = "itemKey">Hierarchy type key</param>
        /// <returns>Key value</returns>
        public string GetTypeExpectedValue(string itemKey)
        {
            return comboBoxInstance.GetItemTypeLangValue(itemKey);
        }

        /// <summary>
        /// Get the hierarchy code expected value
        /// </summary>
        /// <param name = "itemKey">Hierarchy name key</param>
        /// <returns>Name value</returns>
        public string GetNameValue()
        {
            return comboBoxInstance.GetValue(ElementKey.HierarchyName);
        }

        /// <summary>
        /// Get the hierarchy code expected value
        /// </summary>
        /// <param name = "itemKey">Hierarchy code key</param>
        /// <returns>Code value</returns>
        public string GetCodeValue()
        {
            return comboBoxInstance.GetValue(ElementKey.HierarchyCode);
        }

        /// <summary>
        /// Get the hierarchy code expected value
        /// </summary>
        /// <param name = "itemKey">Hierarchy code key</param>
        /// <returns>Code value</returns>
        public string GetTypeValue()
        {
            return comboBoxInstance.GetValue(ElementKey.HierarchyType);
        }

        /// <summary>
        /// Get the hierarchy comment expected value
        /// </summary>
        /// <param name = "itemKey">Hierarchy comment key</param>
        /// <returns>Comment value</returns>
        public string GetCommentValue()
        {
            return comboBoxInstance.GetValue(ElementKey.HierarchyComment);
        }
    }
}
