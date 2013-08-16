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

        private static Grid CommodityGrid = JazzGrid.CommodityCostGrid;
        private static Grid TotalCommotidyGrid = JazzGrid.TotalCommodityCostGrid;
        
        #endregion

        protected override Chart Chart
        {
            get { return JazzChart.EnergyViewChart; }
        }

        protected override Grid EnergyDataGrid
        {
            get { return JazzGrid.EnergyAnalysisEnergyDataList; }
        }

        internal CostPanel() { }

        #region left panel

        public void SwitchTagTab(TagTabs tab)
        {
            switch (tab)
            {
                case TagTabs.SystemDimensionTab:
                    //click system tab
                    break;
                case TagTabs.AreaDimensionTab:
                    //click area tab
                    break;
                case TagTabs.HierarchyTag:
                default:
                    //click all tab
                    break;
            }
        }

        public void SelectSystemDimension(string[] systemDimensionPath)
        {
            throw new NotImplementedException();
        }

        public void SelectAreaDimension(string[] areaDimensionPath)
        {
            throw new NotImplementedException();
        }

        public void SelectCommodity(string[] commodityNames = null)
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

        public void DeselectCommodity(string[] commodityNames)
        {
            throw new NotImplementedException();
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

        #endregion
    }
}
