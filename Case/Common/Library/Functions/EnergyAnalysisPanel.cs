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
        private static EnergyViewToolbar Toolbar = new EnergyViewToolbar();

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

        public void CheckTag(string tagName)
        {
            TagGrid.CheckRowCheckbox(2, tagName);

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void UncheckTag(string tagName)
        { 
        }

        public void RemoveAllTag()
        { 
        }

        public void ViewData(EnergyViewToolbar.ViewType viewType)
        {
            Toolbar.View(viewType);

            JazzMessageBox.LoadingMask.WaitLoading();
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

    public class EnergyViewToolbar
    {
        //StartDatePicker
        //StartTimeComboBox
        //EndDatePicker
        //EndTimeComboBox

        //ViewButton
        private static SplitButton ViewButton = JazzButton.EnergyViewViewDataButton;
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

        public void View(ViewType viewType)
        {
            if (this.CurrentViewType == viewType)
            {
                ViewButton.Click();
            }
            else
            {
                ChangeViewType(viewType);
            }
        }

        private void ChangeViewType(ViewType viewType)
        {
            ViewButton.Trigger();
            TimeManager.FlashPause();

            switch (viewType)
            {
                case ViewType.Column:
                    ViewButton.SelectItem(new string[] { "趋势数据", "柱状图" });
                    CurrentViewType = ViewType.Column;
                    break;
                case ViewType.List:
                    ViewButton.SelectItem(new string[] { "趋势数据", "列表数据" });
                    CurrentViewType = ViewType.List;
                    break;
                case ViewType.Distribute:
                    ViewButton.SelectItem(new string[] { "分布数据" });
                    CurrentViewType = ViewType.Distribute;
                    break;
                case ViewType.Line:
                default:
                    ViewButton.SelectItem(new string[] { "趋势数据", "折线图" });
                    CurrentViewType = ViewType.Line;
                    break;
            }
        }
    }
}
