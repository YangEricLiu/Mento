
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.ScriptCommon.TestData.EnergyView;


namespace Mento.ScriptCommon.Library.Functions
{
    public class CarbonUsagePanel : EnergyViewPanel
    {
        public string CarbonPath = @"CarbonUsage\";
        public string CarbonPiePath = @"CarbonUsage\Pie\";

        private static Grid CommodityGrid = JazzGrid.CommodityCarbonGrid;
        private static Grid TotalCommotidyGrid = JazzGrid.TotalCommodityCarbonGrid;

        protected override Chart Chart
        {
            get { return JazzChart.CarbonChart; }
        }

        protected override Grid EnergyDataGrid
        {
            get { return JazzGrid.CarbonDataListGrid; }
        }

        internal CarbonUsagePanel() { }

        public void NavigateToCarbonUsage()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CarbonUsage);
        }

        #region left region
        
        public void SelectCommodity(string[] commodityNames)
        {
            //total
            if (commodityNames == null || commodityNames.Length <= 0)
            {
                TotalCommotidyGrid.CheckRowCheckbox(2, "$@EM.TotalCommodity", false);
            }
            else //specified commodity
            {
                TotalCommotidyGrid.CheckRowCheckbox(2, "$@EM.SingleCommodity", false);
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
                TotalCommotidyGrid.CheckRowCheckbox(2, "$@EM.TotalCommodity", false);
            }
            else //specified commodity
            {
                TotalCommotidyGrid.CheckRowCheckbox(2, "$@EM.SingleCommodity", false);
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
                TotalCommotidyGrid.UncheckRowCheckbox(2, "$@EM.TotalCommodity", false);
            }
            else //specified commodity
            {
                TotalCommotidyGrid.UncheckRowCheckbox(2, "$@EM.SingleCommodity", false);
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
                TotalCommotidyGrid.UncheckRowCheckbox(2, "$@EM.TotalCommodity", false);
            }
            else //specified commodity
            {
                TotalCommotidyGrid.UncheckRowCheckbox(2, "$@EM.SingleCommodity", false);
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
            ExportExpectedDataTableToExcel(fileName, displayStep, CarbonPath);
        }

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareDataViewCarbonUsage(string expectedFileName, string failedFileName)
        {
            return CompareDataViewOfEnergyAnalysis(expectedFileName, failedFileName, CarbonPath);
        }

        public bool IsDataViewExisted()
        {
            return EnergyDataGrid.HasDrawnDataView();
        }

        #endregion

        #region pie chart operation

        /// <summary>
        /// Export expected data table to excel file
        /// </summary>
        /// <param name="displayStep"></param>
        public void ExportExpectedDictionaryToExcel(string[] hierarchyPaths, ManualTimeRange manualTimeRange, string fileName, string[] dimensionPaths = null)
        {
            ExportExpectedDictionaryToExcel(hierarchyPaths, manualTimeRange, fileName, CarbonPiePath, dimensionPaths);
        }

        /// <summary>
        /// Export expected data table to excel file for multime pie
        /// </summary>
        /// <param name="displayStep"></param>
        public void ExportMulTimePieDictionaryToExcel(string[] hierarchyPaths, ManualTimeRange manualTimeRange, string fileName, string[] dimensionPaths = null)
        {
            ExportMulTimePieDictionaryToExcel(hierarchyPaths, manualTimeRange, fileName, CarbonPiePath, dimensionPaths);
        }

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareDictionaryDataOfCarbonUsage(string expectedFileName, string failedFileName)
        {
            return CompareDictionaryDataOfEnergyAnalysis(expectedFileName, failedFileName, CarbonPiePath);
        }

        #endregion

        #region carbon chart

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

        public int GetPiesNumber()
        {
            return Chart.GetPieDistributions();
        }

        #endregion


    }
}
