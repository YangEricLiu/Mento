using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using System.Data;

namespace Mento.ScriptCommon.Library.Functions
{
    public abstract class EnergyViewPanel
    {
        #region Controls
        //Select hierarchy button
        private static Button SelectHierarchyButton = JazzButton.EnergyViewSelectHierarchyButton;
        private static HierarchyTree HierarchyTree = JazzTreeView.EnergyViewHierarchyTree;

        //Chart
        protected abstract Chart Chart
        {
            get;
        }

        //DataGrid
        protected abstract Grid EnergyDataGrid
        {
            get;
        }
        #endregion

        //Toolbar
        public EnergyViewToolbar Toolbar = new EnergyViewToolbar();

        #region Hierarchy operations
        public Boolean SelectHierarchy(string[] hierarchyNames)
        {
            try
            {
                SelectHierarchyButton.Click();
                HierarchyTree.SelectNode(hierarchyNames);
                return true;
            }
            catch (Exception)
            {
                return false;
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

    public enum TagTabs { HierarchyTag, SystemDimensionTab, AreaDimensionTab, }
}
