using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class MutipleHierarchyCompareWindow : Window
    {
        private static Locator Locator = new Locator("//div[contains(@id,'multihierwindow') and contains(@class,'x-window-default')]", ByType.XPath);

        internal MutipleHierarchyCompareWindow() : base(Locator) { }

        //TagGrid
        private static Grid TagGrid
        {
            get;
            set;
        }

        #region controls

        private static Button MultipleHierarchyTreeButton = JazzButton.MultipleHierarchyTreeButton;
        private static HierarchyTree MultipleHierarchyTree = JazzTreeView.MultipleHierarchyTree;
        private static Button SelectSystemDimensionButton = JazzButton.MultipleHierarchySelectSystemDimensionButton;
        private static Button SelectAreaDimensionButton = JazzButton.MultipleHierarchySelectAreaDimensionButton;
        private static SystemDimensionTree MultiSystemDimensionTree = JazzTreeView.MultipleSystemDimensionTree;
        private static AreaDimensionTree MultiAreaDimensionTree = JazzTreeView.MultipleAreaDimensionTree;
        private static Button MultipleHierarchyConfirmButton = JazzButton.MultipleHierarchyConfirmButton;
        private static Button MultipleHierarchyGiveUpButton = JazzButton.MultipleHierarchyGiveUpButton;
        
        #endregion

        #region common

        /// <summary>
        /// Click the confirm button
        /// </summary>
        public void ClickConfirmButton()
        {
            MultipleHierarchyConfirmButton.Click();
        }

        /// <summary>
        /// Click the give up button
        /// </summary>
        public void ClickGiveUpButton()
        {
            MultipleHierarchyGiveUpButton.Click();
        }

        /// <summary>
        /// Judge if the confirm button enabled
        /// </summary>
        public bool IsConfirmButtonEnable()
        {
            return MultipleHierarchyConfirmButton.IsEnabled();
        }
        #endregion

        #region tree operation

        /// <summary>
        /// Get hierarchy button value
        /// </summary>
        public string GetHierarchyButtonValue()
        {
            return MultipleHierarchyTreeButton.GetText();
        }

        /// <summary>
        /// Select the hierarchy node path
        /// </summary>
        /// <param name="nodePath"></param>
        public void SelectHierarchyNode(string[] nodePath)
        {
            MultipleHierarchyTreeButton.Click();
            TimeManager.ShortPause();
            MultipleHierarchyTree.SelectNode(nodePath);
        }

        /// <summary>
        /// Switch among "全部数据点", "系统数据点", "区域数据点"
        /// </summary>
        /// <param name="tab"></param>
        public void SwitchTagTab(TagTabs tab)
        {
            switch (tab)
            {
                case TagTabs.SystemDimensionTab:
                    //click system tab
                    JazzButton.MultipleHierarchySystemDimensionTab.Click();
                    TagGrid = JazzGrid.MultiHierarchySystemDimensionTagList;
                    break;
                case TagTabs.AreaDimensionTab:
                    //click area tab
                    JazzButton.MultipleHierarchyAreaDimensionTab.Click();
                    TagGrid = JazzGrid.MultiHierarchyAreaDimensionTagList;
                    break;
                case TagTabs.HierarchyTag:
                    JazzButton.MultipleHierarchyAllTags.Click();
                    TagGrid = JazzGrid.MultiHierarchyAllTagList;
                    break;
                default:
                    //click all tab
                    JazzButton.MultipleHierarchyAllTags.Click();
                    TagGrid = JazzGrid.MultiHierarchyAllTagList;
                    break;
            }
        }

        /// <summary>
        /// Select system dimension tree
        /// </summary>
        /// <param name="systemDimensionPath"></param>
        public bool SelectSystemDimension(string[] systemDimensionPath)
        {
            SelectSystemDimensionButton.Click();
            TimeManager.ShortPause();
            
            try
            {
                MultiSystemDimensionTree.SelectNode(systemDimensionPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Select area dimension tree
        /// </summary>
        /// <param name="areaDimensionPath"></param>
        public bool SelectAreaDimension(string[] areaDimensionPath)
        {
            SelectAreaDimensionButton.Click();
            try
            {
                MultiAreaDimensionTree.SelectNode(areaDimensionPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region tag operation

        /// <summary>
        /// Check the tags on left region
        /// </summary>
        /// <param name="tagNames"></param>
        public void CheckTags(string[] tagNames)
        {
            foreach (var tagName in tagNames)
            {
                TagGrid.CheckRowCheckbox(2, tagName);

                TimeManager.MediumPause();
            }
        }

        /// <summary>
        /// Check the tag on left region
        /// </summary>
        /// <param name="tagName"></param>
        public void CheckTag(string tagName)
        {
             TagGrid.CheckRowCheckbox(2, tagName);

             TimeManager.MediumPause();           
        }

        /// <summary>
        /// Uncheck the tags on left region
        /// </summary>
        /// <param name="tagNames"></param>
        public void UncheckTags(string[] tagNames)
        {
            foreach (var tagName in tagNames)
            {
                TagGrid.UncheckRowCheckbox(2, tagName);

                TimeManager.MediumPause();
            }
        }

        /// <summary>
        /// Uncheck the tag on left region
        /// </summary>
        /// <param name="tagName"></param>
        public void UncheckTag(string tagName)
        {
            TagGrid.UncheckRowCheckbox(2, tagName);
            TimeManager.ShortPause();
        }

        /// <summary>
        /// Judge if the tag is checked
        /// </summary>
        /// <param name="tagName"></param>
        public bool IsTagChecked(string tagName)
        {
            return TagGrid.IsRowChecked(2, tagName);
        }

        /// <summary>
        /// Judge if the tags are checked
        /// </summary>
        /// <param name="tagNames"></param>
        public bool IsTagsChecked(string[] tagNames)
        {
            bool isChecked = true;
            
            foreach (var tagName in tagNames)
            {
                isChecked = TagGrid.IsRowChecked(2, tagName);
            }

            return isChecked;
        }

        /// <summary>
        ///Judge if there is not enabled check box
        /// </summary>
        public bool IsNoEnabledCheckbox()
        {
            return TagGrid.IsNoEnabledCheckbox();
        }

        /// <summary>
        ///Judge if there is not disabled check box
        /// </summary>
        public bool IsAllEnabledCheckbox()
        {
            return TagGrid.IsAllEnabledCheckbox();
        }

        /// <summary>
        /// Judge if the tag on the special container tag list
        /// </summary>
        /// <param name="title"></param>
        /// <param name="tagName"></param>
        public bool IsTagExistedOnSpecialContainer(string title, string tagName)
        {
            Grid oneSpecialGrid = GetSpecialGrid(title);
            return oneSpecialGrid.IsRowExist(1, tagName);    
        }

        /// <summary>
        /// Judge if the tags on the special container tag list
        /// </summary>
        /// <param name="title"></param>
        /// <param name="tagNames"></param>
        public bool IsTagsExistedOnSpecialContainer(string title, string[] tagNames)
        {
            Grid oneSpecialGrid = GetSpecialGrid(title);
            bool isTrue = true;

            foreach (string tagName in tagNames)
            {
                isTrue = oneSpecialGrid.IsRowExist(1, tagName);
            }

            return isTrue;
        }

        /// <summary>
        /// Delete tag on the right container of multiple hierarchy window
        /// </summary>
        /// <param name="title"></param>
        /// <param name="tagName"></param>
        public void ClickDeleteXButton(string title, string tagName)
        {
            Grid oneSpecialGrid = GetSpecialGrid(title);
            oneSpecialGrid.ClickDeleteRowXButton(1, tagName);
        }

        /// <summary>
        /// Delete tags on the right container of multiple hierarchy window
        /// </summary>
        /// <param name="title"></param>
        /// <param name="tagNames"></param>
        public void ClickDeleteXButtons(string title, string[] tagNames)
        {
            Grid oneSpecialGrid = GetSpecialGrid(title);

            foreach (string tagName in tagNames)
            {
                oneSpecialGrid.ClickDeleteRowXButton(1, tagName);
            }
        }
        #endregion

        #region private method

        public Grid GetSpecialGrid(string title)
        {
            return JazzGrid.GetOneGrid(JazzControlLocatorKey.GridMultiSelectedTagsList, title);
        }

        #endregion
    }
}
