using System;
using System.Collections.Generic;
using System.Collections;
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

        #region Controls
        private static HierarchyTree HierarchyTree = JazzTreeView.HierarchySettingsHierarchyTree;

        private static Button CreateChildHierarchyButton = JazzButton.HierarchySettingsCreateChildHierarchyButton;

        private static Button ModifyButton = JazzButton.HierarchySettingsModifyButton;
        private static Button SaveButton = JazzButton.HierarchySettingsSaveButton;
        private static Button CancelButton = JazzButton.HierarchySettingsCancelButton;
        private static Button DeleteButton = JazzButton.HierarchySettingsDeleteButton;

        private static TextField NameTextField = JazzTextField.HierarchySettingsNameTextField;
        private static TextField codeTextField = JazzTextField.HierarchySettingscodeTextField;
        private static ComboBox HierarchyTypeComboBox = JazzComboBox.HierarchySettingsHierarchyTypeComboBox;
        private static ComboBox HierarchyIndustryIdComboBox = JazzComboBox.HierarchyIndustryIdComboBox;
        private static ComboBox HierarchyZoneIdComboBox = JazzComboBox.HierarchyZoneIdComboBox;
        private static TextField CommentTextField = JazzTextField.HierarchySettingsCommentTextField;
        #endregion

        #region common action

        /// <summary>
        /// Open type combobox list
        /// </summary>
        /// <returns></returns>
        public void DisplayTypeItems()
        {
            HierarchyTypeComboBox.DisplayItems();
        }

        /// <summary>
        /// Click one hierarchy node then click "add hierarchy" button
        /// </summary>
        /// <returns></returns>
        public void ClickCreateChildHierarchyButton()
        {
            CreateChildHierarchyButton.Click();
        }

        /// <summary>
        /// Click　"Modify" button
        /// </summary>
        /// <returns></returns>
        public void ClickModifyButton()
        {
            ModifyButton.Click();
        }

        /// <summary>
        /// Judge whether "Modify" button is displayed
        /// </summary>
        /// <returns></returns>
        public Boolean IsModifyButtonDisplayed()
        {
            return ModifyButton.IsDisplayed();
        }

        /// <summary>
        /// Click　"Delete" button
        /// </summary>
        /// <returns></returns>
        public void ClickDeleteButton()
        {
            DeleteButton.Click();
        }

        /// <summary>
        /// Judge whether "Delete" button is displayed
        /// </summary>
        /// <returns></returns>
        public Boolean IsDeleteButtonDisplayed()
        {
            return DeleteButton.IsDisplayed();
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
        /// Click one hierarchy node, and return true if successful 
        /// </summary>
        /// <param name="treeNodePath">Hierarchy node name</param>
        /// <returns></returns>
        public Boolean SelectHierarchyNodePath(string[] treeNodePath)
        {
            try
            {
                HierarchyTree.SelectNode(treeNodePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
        /// Navigate to hierarchy setting
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToNonHierarchy()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettings);
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
        /// Judge whether "Save" button is displayed
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsSaveButtonDisplayed()
        {
            return SaveButton.IsDisplayed();
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
        /// Judge whether "cancel" button is displayed
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsCancelButtonDisplayed()
        {
            return CancelButton.IsDisplayed();
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
        /// Confirm the add/modify successful popup message box
        /// </summary>
        /// <returns></returns>
        public void ConfirmCreateOKMagBox()
        {
            JazzMessageBox.MessageBox.OK();
        }

        /// <summary>
        /// Confirm the popup error message box
        /// </summary>
        /// <returns></returns>
        public void ConfirmErrorMsgBox()
        {
            JazzMessageBox.MessageBox.Confirm();
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        /// <summary>
        /// Cancel the popup error message box
        /// </summary>
        /// <returns></returns>
        public void CancelErrorMsgBox()
        {
            JazzMessageBox.MessageBox.Cancel();
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
        #endregion

        #region item operation
        /// <summary>
        /// Input name, code type and comments of the new hierarchy node 
        /// </summary>
        /// <param name="treeNodeName">Parent hierarchy node name</param>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInHierarchyNode(HierarchyInputData input)
        {
            NameTextField.Fill(input.CommonName);
            codeTextField.Fill(input.Code);
            HierarchyTypeComboBox.SelectItem(input.Type);
            TimeManager.LongPause();
            if (0 == String.Compare(input.Type, "Building"))
            {
                HierarchyIndustryIdComboBox.SelectItem(input.Industry);
                HierarchyZoneIdComboBox.SelectItem(input.Zone);
            }
            
            CommentTextField.Fill(input.Comments);
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
        public void FillIncode(string code)
        {
            codeTextField.Fill(code);
        }

        /// <summary>
        /// Input industry of the new hierarchy node 
        /// </summary>
        /// <param name="type">Hierarchy node industry</param>
        /// <returns></returns>
        public void FillInType(string type)
        {
            if (!String.IsNullOrEmpty(type))
            {
                HierarchyTypeComboBox.SelectItem(type);
            }
            
        }

        /// <summary>
        /// Input industry of the new hierarchy node 
        /// </summary>
        /// <param name="type">Hierarchy node industry</param>
        /// <returns></returns>
        public void FillInIndustry(string industry)
        {
            HierarchyIndustryIdComboBox.SelectItem(industry);
        }

        /// <summary>
        /// Input zone of the new hierarchy node 
        /// </summary>
        /// <param name="type">Hierarchy node zone</param>
        /// <returns></returns>
        public void FillInZone(string zone)
        {
            HierarchyZoneIdComboBox.SelectItem(zone);
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
        #endregion

        #region verification

        /// <summary>
        /// Judge whether the textfield and its label are hidden
        /// </summary>
        /// <returns>True if it is hidden, false if not</returns>
        public Boolean IsCommentHidden()
        {
            return CommentTextField.IsTextFieldHidden();
        }

        /// <summary>
        /// Judge whether the picture and its label are hidden
        /// </summary>
        /// <returns>True if it is hidden, false if not</returns>
        public Boolean IsPictureHidden()
        {
            return JazzContainer.HierarchyBuildingPictureContainer.Exists();
        }

        /// <summary>
        /// Judge whether the type list contains Orgnization
        /// </summary>
        /// <returns></returns>
        public Boolean IsTypeContainsOrgnization()
        {
            return GetTypeListValue().Contains(GetTypeExpectedValue("Orgnization"));
        }

        /// <summary>
        /// Judge whether the type list contains Site
        /// </summary>
        /// <returns></returns>
        public Boolean IsTypeContainsSite()
        {
            GetTypeListValue();
            return GetTypeListValue().Contains(GetTypeExpectedValue("Site")); 
        }

        /// <summary>
        /// Judge whether the type list contains Building
        /// </summary>
        /// <returns></returns>
        public Boolean IsTypeContainsBuilding()
        {
            GetTypeListValue();
            return GetTypeListValue().Contains(GetTypeExpectedValue("Building"));
        }

        /// <summary>
        /// Judge whether the child button is enable
        /// </summary>
        /// <returns>True if the button is enable, false if not</returns>
        public Boolean IsChildButtonEnable()
        {
            return CreateChildHierarchyButton.IsEnabled();
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
        /// Judge whether the name textfield is invalid
        /// </summary>
        /// <returns>True if the name is invalid, false if not</returns>
        public Boolean IsNameInvalid()
        {
            return NameTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of name field is correct
        /// </summary>
        /// <param name="output">HierarchyExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsNameInvalidMsgCorrect(HierarchyExpectedData output )
        {
            return NameTextField.GetInvalidTips().Contains(output.CommonName);
        }

        /// <summary>
        /// Judge whether invalid message of name field is correct
        /// </summary>
        /// <param name="output">string</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsNameInvalidMsgCorrect(string output)
        {
            return NameTextField.GetInvalidTips().Contains(output);
        }

        /// <summary>
        /// Judge whether the code textfield is invalid
        /// </summary>
        /// <returns>True if the code is invalid, false if not</returns>
        public Boolean IscodeInvalid()
        {
            return codeTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of code field is correct
        /// </summary>
        /// <param name="output">HierarchyExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IscodeInvalidMsgCorrect(HierarchyExpectedData output)
        {
            return codeTextField.GetInvalidTips().Contains(output.Code);
        }

        /// <summary>
        /// Judge whether invalid message of code field is correct
        /// </summary>
        /// <param name="output">string</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IscodeInvalidMsgCorrect(string output)
        {
            return codeTextField.GetInvalidTips().Contains(output);
        }

        /// <summary>
        /// Judge whether the name textfield is invalid
        /// </summary>
        /// <returns>True if the node is invalid, false if not</returns>
        public Boolean IsTypeInvalid()
        {
            return HierarchyTypeComboBox.IsComboBoxValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of type field is correct
        /// </summary>
        /// <param name="output">HierarchyExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsTypeInvalidMsgCorrect(HierarchyExpectedData output)
        {
            return HierarchyTypeComboBox.GetInvalidTips().Contains(output.Type);   
        }

        /// <summary>
        /// Judge whether invalid message of type field is correct
        /// </summary>
        /// <param name="output">string</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsTypeInvalidMsgCorrect(string output)
        {
            return HierarchyTypeComboBox.GetInvalidTips().Contains(output);
        }

        /// <summary>
        /// Judge whether the Comments textfield is invalid
        /// </summary>
        /// <returns>True if the Comments is invalid, false if not</returns>
        public Boolean IsCommentsInvalid()
        {
            return CommentTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of Comments field is correct
        /// </summary>
        /// <param name="output">HierarchyExpectedData</param>
        /// <returns>whether the invalid message is true</returns>
        public Boolean IsCommentsInvalidMsgCorrect(HierarchyExpectedData output)
        {
            return CommentTextField.GetInvalidTips().Contains(output.Comments);
        }

        /// <summary>
        /// Judge whether invalid message of Comments field is correct
        /// </summary>
        /// <param name="output">HierarchyExpectedData</param>
        /// <returns>whether the invalid message is true</returns>
        public Boolean IsCommentsInvalidMsgCorrect(string output)
        {
            return CommentTextField.GetInvalidTips().Contains(output);
        }

        /// <summary>
        /// Judge whether the Industry is invalid
        /// </summary>
        /// <returns>True if the node is invalid, false if not</returns>
        public Boolean IsIndustryInvalid()
        {
            return HierarchyIndustryIdComboBox.IsComboBoxValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of Industry field is correct
        /// </summary>
        /// <param name="output">HierarchyExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsIndustryInvalidMsgCorrect(HierarchyExpectedData output)
        {
            return HierarchyIndustryIdComboBox.GetInvalidTips().Contains(output.Type);
        }

        /// <summary>
        /// Judge whether invalid message of Industry field is correct
        /// </summary>
        /// <param name="output">string</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsIndustryInvalidMsgCorrect(string output)
        {
            return HierarchyIndustryIdComboBox.GetInvalidTips().Contains(output);
        }

        /// <summary>
        /// Judge whether the zone is invalid
        /// </summary>
        /// <returns>True if the node is invalid, false if not</returns>
        public Boolean IsZoneInvalid()
        {
            return HierarchyZoneIdComboBox.IsComboBoxValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of Zone field is correct
        /// </summary>
        /// <param name="output">HierarchyExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsZoneInvalidMsgCorrect(HierarchyExpectedData output)
        {
            return HierarchyZoneIdComboBox.GetInvalidTips().Contains(output.Type);
        }

        /// <summary>
        /// Judge whether invalid message of Industry field is correct
        /// </summary>
        /// <param name="output">string</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsZoneInvalidMsgCorrect(string output)
        {
            return HierarchyZoneIdComboBox.GetInvalidTips().Contains(output);
        }

        /// <summary>
        /// Return whether Name is enabled
        /// </summary>
        /// <returns>True if enabled</returns>
        public Boolean IsNameFieldEnabled()
        {
            return NameTextField.IsFieldEnabled();
        }

        /// <summary>
        /// Return whether code is enabled
        /// </summary>
        /// <returns>True if enabled</returns>
        public Boolean IscodeFieldEnabled()
        {
            return codeTextField.IsFieldEnabled();
        }

        /// <summary>
        /// Return whether type is enabled
        /// </summary>
        /// <returns>True if enabled</returns>
        public Boolean IsTypeFieldEnabled()
        {
            return HierarchyTypeComboBox.IsComboBoxTextEnabled();
        }

        /// <summary>
        /// Return whether industry is enabled
        /// </summary>
        /// <returns>True if enabled</returns>
        public Boolean IsIndustryFieldEnabled()
        {
            return HierarchyIndustryIdComboBox.IsComboBoxTextEnabled();
        }

        /// <summary>
        /// Return whether zone is enabled
        /// </summary>
        /// <returns>True if enabled</returns>
        public Boolean IsZoneFieldEnabled()
        {
            return HierarchyZoneIdComboBox.IsComboBoxTextEnabled();
        }

        /// <summary>
        /// Return whether comment is enabled
        /// </summary>
        /// <returns>True if enabled</returns>
        public Boolean IsCommentFieldEnabled()
        {
            return CommentTextField.IsFieldEnabled();
        }

        /// <summary>
        /// Return whether delete button is enabled
        /// </summary>
        /// <returns>True if enabled</returns>
        public Boolean IsDeleteButtonEnabled()
        {
            return DeleteButton.IsEnabled();
        }
        #endregion

        #region Get value
        /// <summary>
        /// Get the hierarchy type combobox list value
        /// </summary>
        /// <returns>type list value</returns>
        public ArrayList GetTypeListValue()
        {
            return HierarchyTypeComboBox.GetCurrentDropdownListItems();
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
        /// <returns>Name value</returns>
        public string GetNameValue()
        {
            return NameTextField.GetValue();
        }

        /// <summary>
        /// Get the hierarchy code expected value
        /// </summary>
        /// <returns>code value</returns>
        public string GetcodeValue()
        {
            return codeTextField.GetValue();
        }

        /// <summary>
        /// Get the hierarchy code expected value
        /// </summary>
        /// <returns>code value</returns>
        public string GetTypeValue()
        {
            return HierarchyTypeComboBox.GetValue();
        }

        /// <summary>
        /// Get the hierarchy industry expected value
        /// </summary>
        /// <returns>industry value</returns>
        public string GetIndustryValue()
        {
            return HierarchyIndustryIdComboBox.GetValue();
        }

        /// <summary>
        /// Get the hierarchy zone expected value
        /// </summary>
        /// <returns>zone value</returns>
        public string GetZoneValue()
        {
            return HierarchyZoneIdComboBox.GetValue();
        }

        /// <summary>
        /// Get the hierarchy comment expected value
        /// </summary>
        /// <returns>Comment value</returns>
        public string GetCommentValue()
        {
            return CommentTextField.GetValue();
        }
        #endregion
    }
}
