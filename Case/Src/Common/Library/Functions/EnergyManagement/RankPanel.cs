using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;

namespace Mento.ScriptCommon.Library.Functions
{
    public class RankPanel : EnergyViewPanel
    {
        #region Controls

        private static Button ConfirmHiearchyRank = JazzButton.ConfirmHierarchyRankButton;
        private static Button ClearHiearchyRank = JazzButton.ClearHierarchyRankButton;

        private static Grid CommodityRank = JazzGrid.CommodityRankGrid;

        //Select rank tree
        private static Button SelectHierarchyButton
        {
            get;
            set;
        }
        private static HierarchyTree HierarchyTree
        {
            get;
            set;
        }

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

        internal RankPanel()
        {
            TagGrid = JazzGrid.EnergyAnalysisAllTagList;

            SelectHierarchyButton = JazzButton.RankSelectHierarchyButton;
            HierarchyTree = JazzTreeView.RankHierarchyTree;

            SelectSystemDimensionButton = JazzButton.RankSelectSystemDimensionButton;
            SystemDimensionTree = JazzTreeView.EnergyViewSystemDimensionTree;
        }

        #region Hierarchy operations
        public Boolean CheckHierarchyNode(string[] hierarchyNames)
        {
            try
            {
                SelectHierarchyButton.Click();
                HierarchyTree.ExpandNodePath(hierarchyNames);
                HierarchyTree.CheckNode(hierarchyNames.Last());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean SelectSystemDimensionNode(string[] systemDimensionPath)
        {
            try
            {
                SelectSystemDimensionButton.Click();
                SystemDimensionTree.SelectNode(systemDimensionPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean SwitchSystemDimensionTab()
        {
            try
            {
                JazzButton.RankSystemDimensionTab.Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean SwitchHierarchyTab()
        {
            try
            {
                JazzButton.RankHierarchyTab.Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ClickConfirmHiearchyButton()
        {
            ConfirmHiearchyRank.Click();
        }

        public void ClickClearHiearchyButton()
        {
            ClearHiearchyRank.Click();
        }

        public void SelectCommodity(string commodityName)
        {
            CommodityRank.CheckRowCheckbox(2, commodityName, false);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
        }
        #endregion
        
    }
}
