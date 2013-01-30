﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of hierarchy setting.
    /// </summary>
    public class HierarchySettings
    {
        internal HierarchySettings()
        {
        }

        private static HierarchyTree HierarchyTree = JazzTreeView.HierarchySettingsHierarchyTree;

        private static Button CreateChildHierarchyButton = JazzButton.HierarchySettingsCreateChildHierarchyButton;

        private static Button ModifyButton = JazzButton.HierarchySettingsModifyButton;
        private static Button SaveButton = JazzButton.HierarchySettingsSaveButton;
        private static Button CancelButton = JazzButton.HierarchySettingsCancelButton;
        private static Button DeleteButton = JazzButton.HierarchySettingsDeleteButton;

        private static TextField NameTextField = JazzTextField.HierarchySettingsNameTextField;
        private static TextField CodeTextField = JazzTextField.HierarchySettingsCodeTextField;
        private static ComboBox HierarchyTypeComboBox = JazzComboBox.HierarchySettingsHierarchyTypeComboBox;
        private static TextField CommentTextField = JazzTextField.HierarchySettingsCommentTextField;

        /// <summary>
        /// Click one hierarchy node then click "add hierarchy" button
        /// </summary>
        /// <returns></returns>
        public void ClickCreateChildHierarchyButton()
        {
            CreateChildHierarchyButton.Click();
        }

        /// <summary>
        /// Click one hierarchy node
        /// </summary>
        /// <param name="treeNodeName">Hierarchy node name</param>
        /// <returns></returns>
        public void SelectHierarchyNode(string treeNodeName)
        {
            HierarchyTree.FocusOnNode(treeNodeName);
        }

        /// <summary>
        /// Navigate to hierarchy setting
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToHierarchySetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettings);
        }

        /// <summary>
        /// Click save button to add new hierarchy node
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            SaveButton.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        /// <summary>
        /// Click cancel button to cancel add new hierarchy node
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCancelButton()
        {
            CancelButton.Click();
        }

        /// <summary>
        /// Input name, code type and comments of the new hierarchy node 
        /// </summary>
        /// <param name="treeNodeName">Parent hierarchy node name</param>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInHierarchyNode(HierarchyInputData input)
        {
            NameTextField.Fill(input.Name);
            CodeTextField.Fill(input.Code);
            HierarchyTypeComboBox.SelectItem(input.Type);
            CommentTextField.Fill(input.Comment);
        }

        /// <summary>
        /// Input name of the new hierarchy node 
        /// </summary>
        /// <param name="name">Hierarchy node name</param>
        /// <returns></returns>
        public void FillInName(string name)
        {
            NameTextField.Fill(name);
        }

        /// <summary>
        /// Input code of the new hierarchy node 
        /// </summary>
        /// <param name="code">Hierarchy node code</param>
        /// <returns></returns>
        public void FillInCode(string code)
        {
            CodeTextField.Fill(code);
        }

        /// <summary>
        /// Input type of the new hierarchy node 
        /// </summary>
        /// <param name="type">Hierarchy node type</param>
        /// <returns></returns>
        public void FillInType(string type)
        {
            HierarchyTypeComboBox.SelectItem(type);
        }

        /// <summary>
        /// Input comment of the new hierarchy node 
        /// </summary>
        /// <param name="comment">Hierarchy comment code</param>
        /// <returns></returns>
        public void FillInComment(string comment)
        {
            CommentTextField.Fill(comment);
        }

        /// <summary>
        /// After click save button, waiting for add successful message box pop up
        /// </summary>
        /// <param name="timeout">Waiting time</param>
        /// <returns></returns>
        public void WaitForCreateOKDisplay(int timeout)
        {
            JazzMessageBox.MessageBox.WaitMeAppear();
        }

        /// <summary>
        /// After click save button, waiting for add successful message box pop up
        /// </summary>
        /// <returns></returns>
        public string GetMessageText()
        {
            return JazzMessageBox.MessageBox.GetMessage();
        }

        /// <summary>
        /// Confirm the add successful popup message box
        /// </summary>
        /// <returns></returns>
        public void ConfirmCreateOKMagBox()
        {
            JazzMessageBox.MessageBox.OK();
        }

        /// <summary>
        /// Judge whether the nodes are Child-Parent
        /// </summary>
        /// <param name="nodeChild">Child node name</param>
        /// <param name="nodeParent">Parent node name</param>
        /// <returns>True if the nodes are Child-Parent, false if not</returns>
        public bool IsNodesChildParent(string nodeChild, string nodeParent)
        {
            return HierarchyTree.IsChildNodeOfParent(nodeParent, nodeChild);
        }

        /// <summary>
        /// Judge whether the hierarchy is present
        /// </summary>
        /// <param name="treeNodeName">Hierarchy node name</param>
        /// <returns>True if the node is present, false if not</returns>
        public Boolean IsTreeNodePresent(string treeNodeName)
        {
            return HierarchyTree.IsNodeDisplayed(treeNodeName);
        }

        /// <summary>
        /// Collapse the hierarchy  node
        /// </summary>
        /// <param name = "treeNodeName">Hierarchy node name which will be collapsed</param>
        /// <returns></returns>
        public void CollapseNode(string treeNodeName)
        {
            HierarchyTree.CollapseNode(treeNodeName);
        }

        /// <summary>
        /// Expand the hierarchy  node
        /// </summary>
        /// <param name = "treeNodeName">Hierarchy node name which will be expanded</param>
        /// <returns></returns>
        public void ExpandNode(string treeNodeName)
        {
            HierarchyTree.ExpandNode(treeNodeName);
        }

        /// <summary>
        /// Expand the hierarchy node path
        /// </summary>
        /// <param name = "nodePath">Hierarchy nodes will be expanded</param>
        /// <returns></returns>
        public void ExpandHierarchyNodePath(string[] nodePath)
        {
            HierarchyTree.ExpandNodePath(nodePath);
        }

        /// <summary>
        /// Get the hierarchy type expected value, for language sencitive
        /// </summary>
        /// <param name = "itemKey">Hierarchy type key</param>
        /// <returns>Key value</returns>
        public string GetTypeExpectedValue(string itemKey)
        {
            return HierarchyTypeComboBox.GetActualValue(itemKey);
        }

        /// <summary>
        /// Get the hierarchy code expected value
        /// </summary>
        /// <param name = "itemKey">Hierarchy name key</param>
        /// <returns>Name value</returns>
        public string GetNameValue()
        {
            return NameTextField.GetValue();
        }

        /// <summary>
        /// Get the hierarchy code expected value
        /// </summary>
        /// <param name = "itemKey">Hierarchy code key</param>
        /// <returns>Code value</returns>
        public string GetCodeValue()
        {
            return CodeTextField.GetValue();
        }

        /// <summary>
        /// Get the hierarchy code expected value
        /// </summary>
        /// <param name = "itemKey">Hierarchy code key</param>
        /// <returns>Code value</returns>
        public string GetTypeValue()
        {
            return HierarchyTypeComboBox.GetValue();
        }

        /// <summary>
        /// Get the hierarchy comment expected value
        /// </summary>
        /// <param name = "itemKey">Hierarchy comment key</param>
        /// <returns>Comment value</returns>
        public string GetCommentValue()
        {
            return CommentTextField.GetValue();
        }
    }
}