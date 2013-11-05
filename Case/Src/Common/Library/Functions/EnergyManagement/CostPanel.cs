using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;

namespace Mento.ScriptCommon.Library.Functions
{
    public class CostPanel : EnergyViewPanel
    {
        public string CostPath = @"CostUsage\";

        #region controls
        
        #endregion

        private Grid CommodityGrid
        {
            get;
            set;
        }

        private Grid TotalCommotidyGrid
        {
            get;
            set;
        }

        protected override Chart Chart
        {
            get { return JazzChart.CostChart; }
        }

        protected override Grid EnergyDataGrid
        {
            get { return JazzGrid.CarbonDataListGrid; }
        }

        internal CostPanel()
        {  
            CommodityGrid = JazzGrid.CommodityCostGrid;
            TotalCommotidyGrid = JazzGrid.TotalCommodityCostGrid;
        }

        public void NavigateToCostUsage()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CostUsage);
        }

        #region left panel

        /// <summary>
        /// Switch among "层级", "系统维度", "区域维度"
        /// </summary>
        public void SwitchTagTab(TagTabs tab)
        {
            switch (tab)
            {
                case TagTabs.SystemDimensionTab:
                    //click system tab
                    JazzButton.RankSystemDimensionTab.Click();
                    CommodityGrid = JazzGrid.OtherCommodityCostGrid;
                    TotalCommotidyGrid = JazzGrid.TotalOtherCommodityCostGrid;
                    break;
                case TagTabs.AreaDimensionTab:
                    //click area tab
                    JazzButton.CostAreaDimensionTabButton.Click();
                    CommodityGrid = JazzGrid.OtherCommodityCostGrid;
                    TotalCommotidyGrid = JazzGrid.TotalOtherCommodityCostGrid;
                    break;
                case TagTabs.HierarchyTag:
                    //click all tab
                    JazzButton.RankHierarchyTab.Click();
                    CommodityGrid = JazzGrid.CommodityCostGrid;
                    TotalCommotidyGrid = JazzGrid.TotalCommodityCostGrid;
                    break;
                default:
                    //click all tab
                    JazzButton.RankHierarchyTab.Click();
                    CommodityGrid = JazzGrid.CommodityCostGrid;
                    TotalCommotidyGrid = JazzGrid.TotalCommodityCostGrid;
                    break;
            }
        }

        public void SelectCommodity(string[] commodityNames)
        {
            //total
            if (commodityNames == null || commodityNames.Length <= 0)
            {
                TotalCommotidyGrid.CheckRowCheckbox(2, "介质总览", false);
            }
            else //specified commodity
            {
                TotalCommotidyGrid.CheckRowCheckbox(2, "介质单项", false);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.MediumPause();

                foreach (var commodity in commodityNames)
                {
                    CommodityGrid.CheckRowCheckbox(2, commodity, false);
                    JazzMessageBox.LoadingMask.WaitLoading();
                }
            }
        }

        public void SelectCommodity(string commodityNames = null)
        {
            //total
            if (commodityNames == null)
            {
                TotalCommotidyGrid.CheckRowCheckbox(2, "介质总览", false);
            }
            else //specified commodity
            {
                TotalCommotidyGrid.CheckRowCheckbox(2, "介质单项", false);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.MediumPause();

                CommodityGrid.CheckRowCheckbox(2, commodityNames, false);
                JazzMessageBox.LoadingMask.WaitLoading();
            }
        }

        public void DeSelectCommodity(string[] commodityNames)
        {
            //total
            if (commodityNames == null || commodityNames.Length <= 0)
            {
                TotalCommotidyGrid.UncheckRowCheckbox(2, "介质总览", false);
            }
            else //specified commodity
            {
                TotalCommotidyGrid.UncheckRowCheckbox(2, "介质单项", false);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.MediumPause();

                foreach (var commodity in commodityNames)
                {
                    CommodityGrid.UncheckRowCheckbox(2, commodity, false);
                    JazzMessageBox.LoadingMask.WaitLoading();
                }
            }
        }

        public void DeSelectCommodity(string commodityNames = null)
        {
            //total
            if (commodityNames == null)
            {
                TotalCommotidyGrid.UncheckRowCheckbox(2, "介质总览", false);
            }
            else //specified commodity
            {
                TotalCommotidyGrid.UncheckRowCheckbox(2, "介质单项", false);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.MediumPause();

                CommodityGrid.UncheckRowCheckbox(2, commodityNames, false);
                JazzMessageBox.LoadingMask.WaitLoading();
            }
        }

        #endregion

        #region data view operation

        /// <summary>
        /// Export expected data table to excel file
        /// </summary>
        /// <param name="displayStep"></param>
        public void ExportExpectedDataTableToExcel(string fileName, DisplayStep displayStep)
        {
            ExportExpectedDataTableToExcel(fileName, displayStep, CostPath);
        }

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareDataViewOfCostUsage(string expectedFileName, string failedFileName)
        {
            return CompareDataViewOfEnergyAnalysis(expectedFileName, failedFileName, CostPath);
        }

        /// <summary>
        /// Judge if there is data in data view
        /// </summary>
        public bool IsNoDataInEnergyGrid()
        {
            return EnergyDataGrid.IsNoRowOnGrid();
        }

        /// <summary>
        /// Judge if there is data view
        /// </summary>
        public bool IsDataViewExisted()
        {
            return EnergyDataGrid.HasDrawnDataView();
        }

        #endregion

        #region cost chart

        public bool IsTrendChartDrawn()
        {
            return Chart.HasDrawnTrend();
        }

        public int GetTrendChartLines()
        {
            return Chart.GetTrendChartLines();
        }

        public bool IsColumnChartDrawn()
        {
            return Chart.HasDrawnColumn();
        }

        public int GetColumnChartColumns()
        {
            return Chart.GetColumnChartColumns();
        }

        public bool IsPieChartDrawn()
        {
            return Chart.HasDrawnPie();
        }

        public int GetPies()
        {
            return Chart.GetPieDistributions();
        }

        #endregion
    }
}
