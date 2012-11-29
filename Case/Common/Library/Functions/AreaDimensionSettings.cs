using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class AreaDimensionSettings
    {
        internal AreaDimensionSettings() { }

        private static HierarchyTree DimensionHierarchyTree = JazzTreeView.HierarchySettingsDimensionHierarchyTree;

        private static AreaDimensionTree AreaDimensionTree = JazzTreeView.HierarchySettingsAreaDimensionTree;

        private static Button ShowHierarchyTreeButton = JazzButton.AreaDimensionShowHierarchyTreeButton;
        private static Button CreateAreaDimensionButton = JazzButton.AreaDimensionCreateButton;

        private static Button SaveButton = JazzButton.AreaDimensionSettingsSaveButton;
        private static Button CancelButton = JazzButton.AreaDimensionSettingsCancelButton;
        private static Button ModifyButton = JazzButton.AreaDimensionSettingsModifyButton;
        private static Button DeleteButton = JazzButton.AreaDimensionSettingsDeleteButton;

        private static TextField NameTextField = JazzTextField.AreaDimensionSettingsNameTextField;
        private static TextField CommentTextField = JazzTextField.AreaDimensionSettingsCommentTextField;


        public void ShowHierarchyTree()
        {
            ShowHierarchyTreeButton.Click();
        }

        public void ExpandHierarchyNodePath(string[] hierarchyNodePath)
        {
            DimensionHierarchyTree.ExpandNodePath(hierarchyNodePath);
        }

        public void FocusAreaDimensionNode(string[] areaDimensionNodePath)
        {
            AreaDimensionTree.ExpandNodePath(areaDimensionNodePath);
        }

        public void ClickCreateAreaDimensionButton()
        {
            CreateAreaDimensionButton.Click();
        }

        public void FillAreaDimensionData(string name, string comment)
        {
            NameTextField.Fill(name);
            CommentTextField.Fill(comment);
        }

        public void ClickSaveButton()
        {
            SaveButton.Click();
        }

        public bool IsShownSuccessMessage()
        {
            return JazzMessageBox.CreateSuccessMessageBox.Exists();
        }

        public void CloseSuccessMessage()
        {
            JazzMessageBox.CreateSuccessMessageBox.Close();
        }

        public string GetAreaDimensionName()
        {
            return NameTextField.GetValue();
        }

        public string GetAreaDimensionComment()
        {
            return CommentTextField.GetValue();
        }
    }
}
