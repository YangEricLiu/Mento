using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;

namespace Mento.ScriptCommon.Library.Functions
{
    public class RatioPanel : EnergyViewPanel
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

        internal RatioPanel()
        {
            TagGrid = JazzGrid.RatioAllTagList;

            SelectSystemDimensionButton = JazzButton.EnergyViewSelectSystemDimensionButton;
            SystemDimensionTree = JazzTreeView.EnergyViewSystemDimensionTree;
        }

        public void NavigateToUnitIndicator()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyRadio);
        }

        # region Hierarchy Tree control

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

        #endregion
    }
}
