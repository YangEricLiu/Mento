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

        #region Controls
        //Select hierarchy button
        private static Button SelectHierarchyButton = JazzButton.EnergyViewSelectHierarchyButton;
        private static HierarchyTree HierarchyTree = JazzTreeView.EnergyViewHierarchyTree;

        //Select system dimension tree button
        private static Button SelectSystemDimensionButton = JazzButton.EnergyViewSelectSystemDimensionButton;
        private static SystemDimensionTree SystemDimensionTree = JazzTreeView.EnergyViewSystemDimensionTree;

        //Select area dimension tree button
        private static Button SelectAreaDimensionButton = JazzButton.EnergyViewSelectAreaDimensionButton;
        private static AreaDimensionTree AreaDimensionTree = JazzTreeView.EnergyViewAreaDimensionTree;

        //TagGrid
        private static Grid TagGrid
        {
            get;
            set;
        }
        private static Grid CommodityGrid;
        private static Grid TotalCommotidyGrid;

        //Chart
        private static Chart Chart = JazzChart.EnergyViewChart;

        //DataGrid
        private static Grid EnergyDataGrid = JazzGrid.EnergyAnalysisEnergyDataList;
        #endregion

        //Toolbar
        public EnergyViewToolbar Toolbar = new EnergyViewToolbar();

        #region Hierarchy & tag operations
        public void SelectHierarchy(string[] hierarchyNames)
        {
            SelectHierarchyButton.Click();

            HierarchyTree.SelectNode(hierarchyNames);
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
                    CommodityGrid = null;
                    TotalCommotidyGrid = null;
                    break;
                case TagTabs.AreaDimensionTab:
                    //click area tab
                    JazzButton.EnergyViewAreaDimensionTagsTab.Click();
                    TagGrid = JazzGrid.EnergyAnalysisAreaDimensionTagList;
                    CommodityGrid = null;
                    TotalCommotidyGrid = null;
                    break;
                case TagTabs.AllTag:
                default:
                    //click all tab
                    JazzButton.EnergyViewALLTagsTab.Click();
                    TagGrid = JazzGrid.EnergyAnalysisAllTagList;
                    CommodityGrid = null;
                    TotalCommotidyGrid = null;
                    break;
            }
        }

        public void SelectSystemDimension(string[] systemDimensionPath)
        {
            SelectSystemDimensionButton.Click();

            SystemDimensionTree.SelectNode(systemDimensionPath);
        }

        public void SelectAreaDimension(string[] areaDimensionPath)
        {
            SelectAreaDimensionButton.Click();

            AreaDimensionTree.SelectNode(areaDimensionPath);
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

        public void UncheckTags(string[] tagNames)
        { 
        }

        public void SelectCommodity(string[] commodityNames = null)
        {
            //total
            if (commodityNames == null || commodityNames.Length <= 0)
            {
                TotalCommotidyGrid.CheckRowCheckbox(2, "介质总览");
            }
            else //specified commodity
            {
                TotalCommotidyGrid.CheckRowCheckbox(2, "介质单项");
                foreach (var commodity in commodityNames)
                {
                    CommodityGrid.CheckRowCheckbox(2, commodity);
                    JazzMessageBox.LoadingMask.WaitLoading();
                }
            }
        }
        #endregion

        #region Data view operations
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
        #endregion

        #region Chart view operations
        public bool IsTrendChartDrawn()
        {
            return Chart.HasDrawnTrend();
        }
        public bool IsDistributionChartDrawn()
        {
            return Chart.HasDrawnDistribute();
        }
        public bool IsLegendDrawn()
        {
            return Chart.LegendExists();
        }
        #endregion
    }

}
