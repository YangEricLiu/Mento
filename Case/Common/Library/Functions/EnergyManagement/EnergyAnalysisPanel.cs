using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;
using System.Data;

namespace Mento.ScriptCommon.Library.Functions
{
    public class EnergyAnalysisPanel
    {
        internal EnergyAnalysisPanel()
        {
            TagGrid = JazzGrid.EnergyAnalysisAllTagList;
        }

        //Select hierarchy button
        private static Button SelectHierarchyButton = JazzButton.EnergyViewSelectHierarchyButton;

        //Hierarchy tree
        private static HierarchyTree HierarchyTree = JazzTreeView.EnergyViewHierarchyTree;
        private static SystemDimensionTree SystemDimensionTree = JazzTreeView.EnergyViewSystemDimensionTree;
        private static AreaDimensionTree AreaDimensionTree = JazzTreeView.EnergyViewAreaDimensionTree;

        //TagGrid
        private static Grid TagGrid
        {
            get;
            set;
        }

        //Toolbar
        public EnergyViewToolbar Toolbar = new EnergyViewToolbar();

        //Chart

        //DataGrid
        private static Grid EnergyDataGrid = JazzGrid.EnergyAnalysisEnergyDataList;


        public void SelectHierarchy(string[] hierarchyNames)
        {
            SelectHierarchyButton.Click();
            HierarchyTree.ExpandNodePath(hierarchyNames);
            HierarchyTree.ClickNode(hierarchyNames.Last());
        }

        public enum TagTabs { AllTag, SystemDimensionTab, AreaDimensionTab, }

        public void SwitchTagTab(TagTabs tab)
        {
            switch (tab)
            {
                case TagTabs.SystemDimensionTab:
                    //click system tab
                    JazzButton.EnergyViewSystemDimensionTagsTab.Click();
                    TagGrid = JazzGrid.EnergyAnalysisSystemDimensionTagList;
                    break;
                case TagTabs.AreaDimensionTab:
                    //click area tab
                    JazzButton.EnergyViewAreaDimensionTagsTab.Click();
                    TagGrid = JazzGrid.EnergyAnalysisAreaDimensionTagList;
                    break;
                case TagTabs.AllTag:
                default:
                    //click all tab
                    JazzButton.EnergyViewALLTagsTab.Click();
                    TagGrid = JazzGrid.EnergyAnalysisAllTagList;
                    break;
            }
        }

        public void CheckTags(string[] tagNames)
        {
            foreach (var tagName in tagNames)
            {
                TagGrid.CheckRowCheckbox(2, tagName);

                JazzMessageBox.LoadingMask.WaitLoading();
                TimeManager.MediumPause();
            }
        }

        public void UncheckTag(string tagName)
        { 
        }

        public void RemoveAllTag()
        { 
        }

        public int GetRecordCount()
        {
            return EnergyDataGrid.RecordCount;
        }

        public int GetPageCount()
        {
            return EnergyDataGrid.PageCount;
        }

        public DataTable GetCurrentPageData()
        {
            return EnergyDataGrid.GetCurrentPageData();
        }

        public DataTable GetAllData()
        {
            return EnergyDataGrid.GetAllData();
        }
    }

}
