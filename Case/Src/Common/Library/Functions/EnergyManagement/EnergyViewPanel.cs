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

        private static Button EnergyDisplayStepHourButton = JazzButton.EnergyDisplayStepHourButton;
        private static Button EnergyDisplayStepDayButton = JazzButton.EnergyDisplayStepDayButton;
        private static Button EnergyDisplayStepWeekButton = JazzButton.EnergyDisplayStepWeekButton;
        private static Button EnergyDisplayStepMonthButton = JazzButton.EnergyDisplayStepMonthButton;
        private static Button EnergyDisplayStepYearButton = JazzButton.EnergyDisplayStepYearButton;

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

        #region common

        /// <summary>
        /// Click display step button
        /// </summary>
        /// <param name="step"></param>
        public void ClickDisplayStep(DisplayStep step)
        {
            switch (step)
            {
                case DisplayStep.Hour:
                    //click "Hourly" step
                    EnergyDisplayStepHourButton.Click();
                    break;
                case DisplayStep.Day:
                    //click "Daily" step
                    EnergyDisplayStepDayButton.Click();
                    break;
                case DisplayStep.Week:
                    //click "Weekly" step
                    EnergyDisplayStepWeekButton.Click();
                    break;
                case DisplayStep.Month:
                    //click "Monthly" step
                    EnergyDisplayStepMonthButton.Click();
                    break;
                case DisplayStep.Year:
                    //click "Year" step
                    EnergyDisplayStepYearButton.Click();
                    break;
                default:
                    break;
            }
        }

        #endregion

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
        /// <summary>
        /// Judge if no data in energy data grid
        /// </summary>
        public bool IsNoDataInEnergyGrid()
        {
            return EnergyDataGrid.IsNoRowOnGrid();
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
        public bool IsDataViewDrawn()
        {
            return EnergyDataGrid.HasDrawnDataView();
        }
        public bool IsLegendDrawn()
        {
            return Chart.LegendExists();
        }

        public bool IsLegendItemExists(string legendName)
        {
            return Chart.LegendItemExists(legendName);
        }

        public bool IsScrollbarExist()
        {
            return Chart.IsScrollbarExists();
        }
        #endregion
    }

    public enum TagTabs { HierarchyTag, SystemDimensionTab, AreaDimensionTab, }
    public enum DisplayStep { Hour, Day, Week, Month, Year, Default}
}
