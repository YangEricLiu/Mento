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
        #endregion

        #region tree operation

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

        #endregion
    }
}
