using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

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

        //Chart

        //DataGrid


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
                    TagGrid = JazzGrid.EnergyAnalysisSystemDimensionTagList;
                    break;
                case TagTabs.AreaDimensionTab:
                    //click area tab
                    TagGrid = JazzGrid.EnergyAnalysisAreaDimensionTagList;
                    break;
                case TagTabs.AllTag:
                default:
                    //click all tab
                    TagGrid = JazzGrid.EnergyAnalysisAllTagList;
                    break;
            }
        }

    }

    internal class EnergyViewToolbar
    {
        //StartDatePicker
        //StartTimePicker
        //EndDatePicker
        //EndTimePicker
        
        //ViewMenu
        //ConvertTargetSplitButton
        //PeakValleyButton

        //AddTimeSpanButton
        //RemoveAllTagButton
        //MoreMenu
 
    }
}
