using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;
using OpenQA.Selenium;
using System.Data;

namespace Mento.ScriptCommon.Library.Functions
{
    public class UnitKPIPanel : EnergyViewPanel
    {
        public string UnitIndicatorPath = @"UnitIndicator\";

        #region Controls

        private static Grid UnitCarbonCommodityGrid = JazzGrid.CommodityUnitCarbonGrid;
        private static Grid UnitCarbonTotalCommotidyGrid = JazzGrid.TotalCommodityUnitCarbonGrid;

        private static DatePicker UnitKPIStartDatePicker = JazzDatePicker.UnitKPIStartDatePicker;
        private static DatePicker UnitKPIEndDatePicker = JazzDatePicker.UnitKPIEndDatePicker;

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
            get { return JazzChart.UnitIndicatorChart; }
        }

        protected override Grid EnergyDataGrid
        {
            get { return JazzGrid.UnitKPIEnergyDataListGrid; }
        }

        private Grid UnitCostCommodityGrid
        {
            get;
            set;
        }

        private Grid UnitCostTotalCommotidyGrid
        {
            get;
            set;
        }

        #endregion

        internal UnitKPIPanel()
        {
            TagGrid = JazzGrid.UnitKPIAllTagList;

            SelectSystemDimensionButton = JazzButton.EnergyViewSelectSystemDimensionButton;
            SelectAreaDimensionButton = JazzButton.EnergyViewSelectAreaDimensionButton;

            SystemDimensionTree = JazzTreeView.EnergyViewSystemDimensionTree;
            AreaDimensionTree = JazzTreeView.EnergyViewAreaDimensionTree;

            UnitCostCommodityGrid = JazzGrid.CommodityUnitCostGrid;
            UnitCostTotalCommotidyGrid = JazzGrid.TotalCommodityUnitCostGrid;
        }

        #region Unit KPI common function

        public void NavigateToUnitIndicator()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UnitKPI);
        }

        public void NavigateToRanking()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.Rank);
        }

        #endregion

        #region Tag operations

        public void SwitchTagTab(TagTabs tab)
        {
            bool IsEnergyConsumption = JazzFunction.EnergyViewToolbar.GetFuncModeConvertTargetText().Contains("能耗");

            switch (tab)
            {
                case TagTabs.SystemDimensionTab:
                    //click system tab
                    if (IsEnergyConsumption)
                    {
                        JazzButton.EnergyViewSystemDimensionTagsTab.Click();
                    }
                    else
                    {
                        JazzButton.UnitIndicatorSystemDimensionTagsTab.Click();
                    }
                    UnitCostCommodityGrid = JazzGrid.OtherCommodityCostGrid;
                    UnitCostTotalCommotidyGrid = JazzGrid.TotalOtherCommodityCostGrid;
                    TagGrid = JazzGrid.EnergyAnalysisSystemDimensionTagList;
                    break;
                case TagTabs.AreaDimensionTab:
                    //click area tab
                    if (IsEnergyConsumption)
                    {
                        JazzButton.EnergyViewAreaDimensionTagsTab.Click();
                    }
                    else
                    { 
                        JazzButton.UnitIndicatorAreaDimensionTagsTab.Click();
                    }
                    UnitCostCommodityGrid = JazzGrid.OtherCommodityCostGrid;
                    UnitCostTotalCommotidyGrid = JazzGrid.TotalOtherCommodityCostGrid;
                    TagGrid = JazzGrid.EnergyAnalysisAreaDimensionTagList;
                    break;
                case TagTabs.HierarchyTag:
                    //click all tab
                    if (IsEnergyConsumption)
                    {
                        JazzButton.EnergyViewALLTagsTab.Click();
                    }
                    else
                    {
                        JazzButton.UnitIndicatorALLTagsTab.Click();
                    }
                    UnitCostCommodityGrid = JazzGrid.CommodityUnitCostGrid;
                    UnitCostTotalCommotidyGrid = JazzGrid.TotalCommodityUnitCostGrid;
                    TagGrid = JazzGrid.EnergyAnalysisAllTagList;
                    break;
                default:
                    //click all tab
                    if (IsEnergyConsumption)
                    {
                        JazzButton.EnergyViewALLTagsTab.Click();
                    }
                    else
                    {
                        JazzButton.UnitIndicatorALLTagsTab.Click();
                    }
                    UnitCostCommodityGrid = JazzGrid.CommodityUnitCostGrid;
                    UnitCostTotalCommotidyGrid = JazzGrid.TotalCommodityUnitCostGrid;
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

        public bool IsTagChecked(string tagName)
        {
            return TagGrid.IsRowChecked(2, tagName);
        }

        public void UncheckTag(string tagName)
        {
            TagGrid.UncheckRowCheckbox(2, tagName);

            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
        }

        public void CheckTags(string[] tagNames)
        {
            foreach (string tagName in tagNames)
            {
                TagGrid.CheckRowCheckbox(2, tagName);
            }
        }

        public bool IsAllTagsDisabled()
        {
            return TagGrid.IsNoEnabledCheckbox();
        }

        public bool IsCarbonSingleCommodityNotExisted()
        {
            UnitCarbonTotalCommotidyGrid.CheckRowCheckbox(2, "介质单项", false);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            return UnitCarbonCommodityGrid.IsNoRowOnGrid();
        }

        public void SelectCommodityUnitCarbon(string[] commodityNames = null)
        {
            //total
            if (commodityNames == null || commodityNames.Length <= 0)
            {
                UnitCarbonTotalCommotidyGrid.CheckRowCheckbox(2, "介质总览", false);
            }
            else //specified commodity
            {
                UnitCarbonTotalCommotidyGrid.CheckRowCheckbox(2, "介质单项", false);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.MediumPause();

                foreach (var commodity in commodityNames)
                {
                    UnitCarbonCommodityGrid.CheckRowCheckbox(2, commodity, false);
                    JazzMessageBox.LoadingMask.WaitLoading();
                }
            }
        }

        public void SelectSingleCommodityUnitCarbon(string commodity)
        {
            UnitCarbonTotalCommotidyGrid.CheckRowCheckbox(2, "介质单项", false);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            UnitCarbonCommodityGrid.CheckRowCheckbox(2, commodity, false);
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void UnselectSingleCommodityUnitCarbon(string commodity)
        {
            UnitCarbonCommodityGrid.UncheckRowCheckbox(2, commodity, false);
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public bool IsCostSingleCommodityNotExisted()
        {
            UnitCostTotalCommotidyGrid.CheckRowCheckbox(2, "介质单项", false);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            return UnitCostCommodityGrid.IsNoRowOnGrid();
        }

        public void SelectCommodityUnitCost(string[] commodityNames = null)
        {
            //total
            if (commodityNames == null || commodityNames.Length <= 0)
            {
                UnitCostTotalCommotidyGrid.CheckRowCheckbox(2, "介质总览", false);
            }
            else //specified commodity
            {
                UnitCostTotalCommotidyGrid.CheckRowCheckbox(2, "介质单项", false);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.MediumPause();

                foreach (var commodity in commodityNames)
                {
                    UnitCostCommodityGrid.CheckRowCheckbox(2, commodity, false);
                    JazzMessageBox.LoadingMask.WaitLoading();
                }
            }
        }

        public void SelectSingleCommodityUnitCost(string commodity)
        {
            UnitCostTotalCommotidyGrid.CheckRowCheckbox(2, "介质单项", false);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            UnitCostCommodityGrid.CheckRowCheckbox(2, commodity, false);
            JazzMessageBox.LoadingMask.WaitLoading();

        }

        public void UnselectSingleCommodityUnitCost(string commodity)
        {
            UnitCostCommodityGrid.UncheckRowCheckbox(2, commodity, false);
            JazzMessageBox.LoadingMask.WaitLoading();
        }
        #endregion

        #region energy view

        public void SetDateRange(DateTime startTime, DateTime endTime)
        {
            UnitKPIStartDatePicker.SelectDateItem(startTime);
            UnitKPIEndDatePicker.SelectDateItem(endTime);
        }

        public DataTable GetAllData()
        {
            return EnergyDataGrid.GetAllData();
        }

        #endregion

        #region unit chart

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

        public bool EntirelyNoChartDrawn()
        {
            return Chart.EntirelyNoChartDrawn();
        }

        #endregion

        #region data view operation

        /// <summary>
        /// Export expected data table to excel file
        /// </summary>
        /// <param name="displayStep"></param>
        public void ExportExpectedDataTableToExcel(string fileName, DisplayStep displayStep)
        {
            ExportExpectedDataTableToExcel(fileName, displayStep, UnitIndicatorPath);
        }

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareDataViewUnitIndicator(string expectedFileName, string failedFileName)
        {
            return CompareDataViewOfEnergyAnalysis(expectedFileName, failedFileName, UnitIndicatorPath);
        }

        public bool IsDataViewExisted()
        {
            return EnergyDataGrid.HasDrawnDataView();
        }

        #endregion
    }
}
