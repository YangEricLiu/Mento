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
        public string EAPiePath = @"EA\Pie\";

        #region Controls
        private static Container MultiHierarchyPanelContainer = JazzContainer.MultiHierarchyPanelContainer;

        protected override Chart Chart
        {
            get { return JazzChart.EnergyViewChart; }
        }

        protected override Grid EnergyDataGrid
        {
            get { return JazzGrid.EnergyAnalysisEnergyDataList; }
        }

        //TagGrid
        private static Grid TagGrid
        {
            get;
            set;
        }
        #endregion

        internal EnergyAnalysisPanel()
        {
            TagGrid = JazzGrid.EnergyAnalysisAllTagList;
        }

        #region common

        public void NavigateToEnergyAnalysis()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
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
                    //click all tab
                    JazzButton.EnergyViewALLTagsTab.Click();
                    TagGrid = JazzGrid.EnergyAnalysisAllTagList;
                    break;
                default:
                    //click all tab
                    JazzButton.EnergyViewALLTagsTab.Click();
                    TagGrid = JazzGrid.EnergyAnalysisAllTagList;
                    break;
            }
        }
        
        #endregion

        #region Tag operations

        /// <summary>
        /// Judge if no data on left multiple hierarchy tags panel
        /// </summary>
        public bool IsEmptyMultiHierarchyTagsPanel()
        {
            return MultiHierarchyPanelContainer.GetElementNumber() > 0 ? false : true;
        }

        /// <summary>
        /// Judge if all the grid tags unchecked
        /// </summary>
        public bool IsAllGridTagsUnchecked()
        {
            return TagGrid.IsAllGridTagsUnchecked();
        }

        /// <summary>
        /// Judge if all the left grid tags can not checked
        /// </summary>
        public bool IsNoEnabledCheckbox()
        {
            return TagGrid.IsNoEnabledCheckbox();
        }

        /// <summary>
        /// Judge if all the left grid tags can be checked
        /// </summary>
        public bool IsAllEnabledCheckbox()
        {
            return TagGrid.IsAllEnabledCheckbox();
        }

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
        /// Judge if tag on the tag list checked
        /// </summary>
        /// <param name="tagName"></param>
        public Boolean IsTagChecked(string tagName)
        {
            return TagGrid.IsRowChecked(2, tagName);
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
        /// Judge if the tag on the special container tag list
        /// </summary>
        /// <param name="title"></param>
        /// <param name="tagName"></param>
        public bool IsTagExistedOnSpecialContainer(string title, string tagName)
        {
            Grid oneSpecialGrid = GetSpecialGrid(title);

            return oneSpecialGrid.IsRowExist(1, tagName);

        }

        /// <summary>
        /// Judge if the tags on the special container tag list
        /// </summary>
        /// <param name="title"></param>
        /// <param name="tagNames"></param>
        public bool IsTagsExistedOnSpecialContainer(string title, string[] tagNames)
        {
            Grid oneSpecialGrid = GetSpecialGrid(title);
            bool isTrue = true;

            foreach (string tagName in tagNames)
            {
                isTrue = oneSpecialGrid.IsRowExist(1, tagName);
            }

            return isTrue;
        }

        #region chart

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

        #endregion

        #region data view operation

        /// <summary>
        /// Export expected data table to excel file
        /// </summary>
        /// <param name="displayStep"></param>
        public void ExportExpectedDataTableToExcel(string fileName, DisplayStep displayStep)
        {
            ExportExpectedDataTableToExcel(fileName, displayStep, EAPath);
        }

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareDataViewOfEnergyAnalysis(string expectedFileName, string failedFileName)
        {
            return CompareDataViewOfEnergyAnalysis(expectedFileName, failedFileName, EAPath);
        }

        #endregion

        #region Chart view operation 

        /// <summary>
        /// Export expected dictionary data to excel file
        /// </summary>
        /// <param name="displayStep"></param>
        public void ExportExpectedDictionaryToExcel(string[] hierarchyPaths, ManualTimeRange manualTimeRange, string fileName)
        {
            ExportExpectedDictionaryToExcel(hierarchyPaths, manualTimeRange, fileName, EAPiePath);
        }

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareDictionaryDataOfEnergyAnalysis(string expectedFileName, string failedFileName)
        {
            return CompareDictionaryDataOfEnergyAnalysis(expectedFileName, failedFileName, EAPiePath);
        }

        #region pie chart operation for mutiple hierarchy nodes

        /// <summary>
        /// Export expected dictionary data to excel file with data view header
        /// </summary>
        /// <param name="displayStep"></param>
        public void ExportExpectedDictionaryForMultipleHierarchyToExcel( ManualTimeRange manualTimeRange, string fileName)
        {
            ExportExpectedDictionaryToExcelMultiHiearachy(manualTimeRange, fileName, EAPiePath);
        }

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareDictionaryDataForMultipleHierarchyOfEnergyAnalysis(string expectedFileName, string failedFileName)
        {
            return CompareDictionaryDataMultipleHierarchyOfEnergyAnalysis(expectedFileName, failedFileName, EAPiePath);
        }
        #endregion

        #endregion

        #region private mothod

        public Grid GetSpecialGrid(string title)
        {
            return JazzGrid.GetOneGrid(JazzControlLocatorKey.GridEASelectedTagsList, title);
        }

        #endregion
    }

}
