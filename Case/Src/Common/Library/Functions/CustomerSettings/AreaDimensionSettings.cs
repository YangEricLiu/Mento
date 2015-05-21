using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;

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
        //added
        //private static Button ConfirmDeleteButton = JazzButton.AreaDimensionSettingsConfirmDeleteButton;
        //private static Button CancelDeleteButton = JazzButton.AreaDimensionSettingsCancelDeleteButton;

        private static TextField NameTextField = JazzTextField.AreaDimensionSettingsNameTextField;
        private static TextField CommentTextField = JazzTextField.AreaDimensionSettingsCommentTextField;


        public void NavigateToAreaDimensionSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            TimeManager.MediumPause();
        }

        public void NavigateToNonAreaDimensionSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettings);
            TimeManager.MediumPause();
        }

        public void ShowHierarchyTree()
        {
            ShowHierarchyTreeButton.Click();
        }

        public void ExpandHierarchyNodePath(string[] hierarchyNodePath)
        {
            DimensionHierarchyTree.ExpandNodePath(hierarchyNodePath);
        }

        public void SelectHierarchyNode(string hierarchyNodeName)
        {
            DimensionHierarchyTree.ClickNode(hierarchyNodeName);
        }

        public Boolean SelectHierarchyNodePath(string[] hierarchyNodePath)
        {
            // greenie modified
            try
            {
                DimensionHierarchyTree.SelectNode(hierarchyNodePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ExpandAreaDimensionNodePath(string[] areaDimensionNodePath)
        {
            AreaDimensionTree.ExpandNodePath(areaDimensionNodePath);
        }

        //greenie add
        public void ClickCancelButton()
        {
            CancelButton.Click();
        }


        public void ClickDeleteButton()
        {
            DeleteButton.Click();
        }
        //greenie add
        /*
        public void ClickCancelDeleteButton()
        {
            DeleteButton.Click();
        }
         */
        /// <summary>
        /// Confirm the popup error message box
        /// </summary>
        /// <returns></returns>
        public void ConfirmErrorMsgBox()
        {
            JazzMessageBox.MessageBox.Delete();
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void OKErrorMsgBox()
        {
            JazzMessageBox.MessageBox.OK();
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        /// <summary>
        /// Cancel the popup error message box
        /// </summary>
        /// <returns></returns>
        public void CancelErrorMsgBox()
        {
            JazzMessageBox.MessageBox.GiveUp();
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void SelectAreaDimensionNode(string areaDimensionNodeName)
        {
            AreaDimensionTree.ClickNode(areaDimensionNodeName);
        }

        public Boolean SelectAreaDimensionNodePath(string[] areaDimensionNodePath)
        {
            // greenie modified
            try
            {
                AreaDimensionTree.SelectNode(areaDimensionNodePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ClickCreateAreaDimensionButton()
        {
            CreateAreaDimensionButton.Click();
        }
        public void ClickModifyAreaDimensionButton()
        {
            ModifyButton.Click();
        }
        
        public Boolean IsCreateAreaDimensionButtonEnabled()
        {
            return CreateAreaDimensionButton.IsEnabled();
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
        public bool IsSaveButtonEnabled()
        {
            return SaveButton.IsEnabled();
        }
        public bool IsShownSuccessMessage()
        {
            return JazzMessageBox.MessageBox.Exists();
        }

        public void CloseSuccessMessage()
        {
            JazzMessageBox.MessageBox.OK();
        }

        public string GetAreaDimensionName()
        {
            return NameTextField.GetValue();
        }

        public string GetAreaDimensionComment()
        {
            return CommentTextField.GetValue();
        }

        public Boolean IsNameInvalidMsgCorrect(string correctMessage)
        {
            return NameTextField.GetInvalidTips().Contains(correctMessage);
        }


        public Boolean IsCommentsInvalidMsgCorrect(string correctMessage)
        {
            return CommentTextField.GetInvalidTips().Contains(correctMessage);
        }


    }
}
