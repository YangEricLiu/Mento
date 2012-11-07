using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Administration.Hierarchy.HierarchyManagement;

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
            var locator = ElementDictionary[ElementKey.SaveButton];

            ElementLocator.FindElement(locator).Click();
        }

        /// <summary>
        /// Click cancel button to cancel add new hierarchy node
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCancelButton()
        {
            var locator = ElementDictionary[ElementKey.CancelButton];

            ElementLocator.FindElement(locator).Click();
        }

        /// <summary>
        /// Input name, code type and comments of the new hierarchy node 
        /// </summary>
        /// <param name="treeNodeName">Hierarchy node name</param>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void AddHierarchyNode(string treeNodeName, HierarchyInputData input)
        {
            PrepareToAddNode(treeNodeName);

            textFieldInstance.FillIn(ElementKey.HierarchyName, input.Name);
            textFieldInstance.FillIn(ElementKey.HierarchyCode, input.Code);
            comboBoxInstance.DisplayItems(ElementKey.HierarchyType);
            comboBoxInstance.SelectItem(input.Type);
            textFieldInstance.FillIn(ElementKey.HierarchyComment, input.Comment);
        }

        /// <summary>
        /// After click save button, waiting for add successful message box pop up
        /// </summary>
        /// <param name="timeout">Waiting time</param>
        /// <returns></returns>
        public void WaitForCreateOKDisplay(int timeout)
        { 
            var locator = ElementDictionary[ElementKey.CreateOKText];

            ElementLocator.WaitForElement(locator, timeout);
        }

        /// <summary>
        /// Confirm the add successful popup message box
        /// </summary>
        /// <returns></returns>
        public void ConfirmCreateOKMagBox()
        {
            var locator = ElementDictionary[ElementKey.OKButton];

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
        /// Judge whether the hieraychy node is correct on view status
        /// </summary>
        /// <param name = "treeNodeName">Hierarchy node name which will be expanded</param>
        /// <param name = "input">Test data</param>
        /// <returns></returns>
        public void IsNodeValueCorrect(string treeNodeName, HierarchyInputData input)
        {
            FocusOnHierarchyNode(treeNodeName);

            Assert.AreEqual(textFieldInstance.GetValue(ElementKey.HierarchyName), input.Name);
            Assert.AreEqual(textFieldInstance.GetValue(ElementKey.HierarchyCode), input.Code);
            comboBoxInstance.GetValue(ElementKey.HierarchyType);
            Assert.AreEqual(textFieldInstance.GetValue(ElementKey.HierarchyComment), input.Comment);
        }
    }
}
