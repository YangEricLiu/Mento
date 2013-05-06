using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;

namespace Mento.ScriptCommon.Library.Functions
{
    public class KpiPanel : EnergyViewPanel
    {
        #region Controls
        //Select system dimension tree button
        private static Button SelectSystemDimensionButton
        {
            get;
            set;
        }
        private static SystemDimensionTree SystemDimensionTree
        {
            get;
            set;
        }

        //Select area dimension tree button
        private static Button SelectAreaDimensionButton
        {
            get;
            set;
        }
        private static AreaDimensionTree AreaDimensionTree
        {
            get;
            set;
        }

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

        internal KpiPanel()
        {
            TagGrid = JazzGrid.EnergyAnalysisAllTagList;

            SelectSystemDimensionButton = JazzButton.EnergyViewSelectSystemDimensionButton;
            SelectAreaDimensionButton = JazzButton.EnergyViewSelectAreaDimensionButton;

            SystemDimensionTree = JazzTreeView.EnergyViewSystemDimensionTree;
            AreaDimensionTree = JazzTreeView.EnergyViewAreaDimensionTree;
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

        public void CheckTag(string tagName)
        {
            TagGrid.CheckRowCheckbox(2, tagName);

            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
        }
        #endregion
    }
}
