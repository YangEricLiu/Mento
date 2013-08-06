using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;
using System.Data;
using Mento.Framework.Configuration;
using Mento.ScriptCommon.TestData.EnergyView;

namespace Mento.ScriptCommon.Library.Functions
{
    public class EnergyAnalysisPanel : EnergyViewPanel
    {
        public string EAPath = @"EA\";

        #region Controls
        //Select system dimension tree button
        private static Button SelectSystemDimensionButton = JazzButton.EnergyViewSelectSystemDimensionButton;
        private static SystemDimensionTree SystemDimensionTree = JazzTreeView.EnergyViewSystemDimensionTree;
        private static Button EnergyViewSelectAreaDimensionButton = JazzButton.EnergyViewSelectAreaDimensionButton;
        
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

        #region common

        /// <summary>
        /// Click "请选择区域维度" button in "区域数据点"
        /// </summary>
        public void ClickSelectAreaDimensionButton()
        {

            EnergyViewSelectAreaDimensionButton.Click();
        }

        /// <summary>
        /// Switch among "全部数据点", "系统数据点", "区域数据点"
        /// </summary>
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

        /// <summary>
        /// Select system dimension tree
        /// </summary>
        public bool SelectSystemDimension(string[] systemDimensionPath)
        {
            try
            {
                SelectSystemDimensionButton.Click();
                TimeManager.ShortPause();              
                SystemDimensionTree.SelectNode(systemDimensionPath);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }

        /// <summary>
        /// Select area dimension tree
        /// </summary>
        public bool SelectAreaDimension(string[] areaDimensionPath)
        {
            SelectAreaDimensionButton.Click();
            try
            {
                AreaDimensionTree.SelectNode(areaDimensionPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Tag operations

        /// <summary>
        /// Check the tags on left region
        /// </summary>
        /// <param name="tagNames"></param>
        public void CheckTags(string[] tagNames)
        {
            foreach (var tagName in tagNames)
            {
                TagGrid.CheckRowCheckbox(2, tagName);

                TimeManager.MediumPause();
            }
        }

        /// <summary>
        /// Check one tag on left region
        /// </summary>
        /// <param name="tagName"></param>
        public void CheckTag(string tagName)
        {
            TagGrid.CheckRowCheckbox(2, tagName);
            TimeManager.ShortPause();
        }

        /// <summary>
        /// Uncheck the tags on left region
        /// </summary>
        /// <param name="tagNames"></param>
        public void UncheckTags(string[] tagNames)
        {
            foreach (var tagName in tagNames)
            {
                TagGrid.UncheckRowCheckbox(2, tagName);

                TimeManager.MediumPause();
            }
        }

        /// <summary>
        /// Uncheck the tag on left region
        /// </summary>
        /// <param name="tagName"></param>
        public void UncheckTag(string tagName)
        {
            TagGrid.UncheckRowCheckbox(2, tagName);
            TimeManager.ShortPause();
        }

        /// <summary>
        /// Judge if tag on the tag list of left region
        /// </summary>
        /// <param name="tagName"></param>
        public Boolean IsTagOnListByName(string tagName)
        {
            return TagGrid.IsRowExist(2, tagName);
        }

        /// <summary>
        /// Get the data of selected row
        /// </summary>
        /// <param name="cellIndex"></param>
        public string GetSelectedRowData(int cellIndex)
        {
            return TagGrid.GetSelectedRowData(cellIndex);
        }

        /// <summary>
        /// Focus on the tag of left region
        /// </summary>
        /// <param name="tagName"></param>
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

        /// <summary>
        /// Get the value of UOM
        /// </summary>
        public string GetUomValue()
        {
            return Chart.GetUom();
        }

        /// <summary>
        /// Judge if legend name displayed
        /// </summary>
        /// <param name="legendName"></param>
        public bool IsLegendItemExists(string legendName)
        {
            return Chart.LegendItemExists(legendName);
        }

        /// <summary>
        /// Click legend name
        /// </summary>
        /// <param name="legendName"></param>
        public void ClickLegendItem(string legendName)
        {
            Chart.ClickLegendItem(legendName);
        }

        #endregion

        #region data view operation

        /// <summary>
        /// Export expected data table to excel file
        /// </summary>
        /// <param name="displayStep"></param>
        public void ExportExpectedDataTableToExcel(string fileName, DisplayStep displayStep)
        {
            if (ExecutionConfig.isCreateExpectedDataViewExcelFile)
            {
                //display data view
                JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();
                
                ClickDisplayStep(displayStep);

                //Load data view and get data table
                DataTable data = GetAllData();

                //Export to excel
                string actualFileName = Path.Combine(EAPath, fileName);
                JazzFunction.DataViewOperation.MoveExpectedDataViewToExcel(data, actualFileName, JazzFunction.DataViewOperation.sheetNameExpected);
            }
        }

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareDataViewOfEnergyAnalysis(string expectedFileName, string failedFileName)
        {
            string filePath = Path.Combine(EAPath, expectedFileName);
            DataTable actualData = GetAllData();

            DataTable expectedDataTable = JazzFunction.DataViewOperation.ImportExpectedFileToDataTable(filePath, JazzFunction.DataViewOperation.sheetNameExpected);

            return JazzFunction.DataViewOperation.CompareDataTables(expectedDataTable, actualData, failedFileName);
        }

        #endregion
    }

}
