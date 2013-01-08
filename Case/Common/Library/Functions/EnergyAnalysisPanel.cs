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

    }

    internal class EnergyViewToolbar
    {
        //StartDatePicker
        //StartTimeComboBox
        //EndDatePicker
        //EndTimeComboBox

        //ViewMenu
        //ConvertTargetSplitButton
        //PeakValleyButton

        //AddTimeSpanButton
        //RemoveAllTagButton
        //MoreMenu
        public EnergyViewToolbar()
        {
            CurrentViewType = ViewType.Line;
        }

        public ViewType CurrentViewType
        {
            get;
            set;
        }

        public void SetTimeRange(DateTime startTime, DateTime endTime)
        {

        }

        public enum ViewType 
        { 
            Line, 
            Column, 
            List, 
            Distribute 
        }
        public void ChangeViewType(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Column:
                    CurrentViewType = ViewType.Column;
                    break;
                case ViewType.List:
                    CurrentViewType = ViewType.List;
                    break;
                case ViewType.Distribute:
                    CurrentViewType = ViewType.Distribute;
                    break;
                case ViewType.Line:
                default:
                    CurrentViewType = ViewType.Line;
                    break;
            }
        }


    }
}
