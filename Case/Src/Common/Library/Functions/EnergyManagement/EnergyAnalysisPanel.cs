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
    public class EnergyAnalysisPanel : EnergyViewPanel
    {
        #region Controls
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

        protected override Chart Chart
        {
            get { return JazzChart.EnergyViewChart; }
        }

        protected override Grid EnergyDataGrid
        {
            get { return JazzGrid.EnergyAnalysisEnergyDataList; }
        }
        #endregion

        internal EnergyAnalysisPanel()
        {
            TagGrid = JazzGrid.EnergyAnalysisAllTagList;
        }

        #region Tag operations
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
                case TagTabs.HierarchyTag:
                default:
                    //click all tab
                    JazzButton.EnergyViewALLTagsTab.Click();
                    TagGrid = JazzGrid.EnergyAnalysisAllTagList;
                    break;
            }
        }

        public bool SelectSystemDimension(string[] systemDimensionPath)
        {
            try
            {
                SelectSystemDimensionButton.Click();

                SystemDimensionTree.SelectNode(systemDimensionPath);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }

        public Boolean SelectAreaDimension(string[] areaDimensionPath)
        {
            SelectAreaDimensionButton.Click();

            return AreaDimensionTree.SelectNode(areaDimensionPath);
        }

        public void CheckTags(string[] tagNames)
        {
            foreach (var tagName in tagNames)
            {
                TagGrid.CheckRowCheckbox(2, tagName);

                //JazzMessageBox.LoadingMask.WaitLoading();
                TimeManager.MediumPause();
            }
        }

        public void CheckTag(string tagName)
        {
                TagGrid.CheckRowCheckbox(2, tagName);
                TimeManager.ShortPause();
        }

        public void UncheckTags(string[] tagNames)
        {
            foreach (var tagName in tagNames)
            {
                TagGrid.UncheckRowCheckbox(2, tagName);

                JazzMessageBox.LoadingMask.WaitLoading();
                TimeManager.MediumPause();
            }
        }

        public Boolean IsTagOnListByName(string tagName)
        {
            return TagGrid.IsRowExist(2, tagName);
        }

        public string GetSelectedRowData(int cellIndex)
        {
            return TagGrid.GetSelectedRowData(cellIndex);
        }

        public bool FocusOnRowByName(string tagName)
        {
            try
            {
                TagGrid.FocusOnRow(2, tagName);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public string GetUomValue()
        {
            return Chart.GetUom();
        }

        public bool IsLegendItemExists(string legendName)
        {
            return Chart.LegendItemExists(legendName);
        }

        public void ClickLegendItem(string legendName)
        {
            Chart.ClickLegendItem(legendName);
        }
        #endregion
    }

}
