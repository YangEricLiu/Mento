using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using System.Data;
using Mento.Framework.Configuration;
using Mento.ScriptCommon.TestData.EnergyView;
using Mento.TestApi.WebUserInterface;
using System.IO;

namespace Mento.ScriptCommon.Library.Functions
{
    public abstract class EnergyViewPanel
    {
        #region Controls
        //Select hierarchy button
        private static Button SelectHierarchyButton = JazzButton.EnergyViewSelectHierarchyButton;
        private static HierarchyTree HierarchyTree = JazzTreeView.EnergyViewHierarchyTree;

        private static ToggleButton EnergyDisplayStepHourButton = JazzButton.EnergyDisplayStepHourButton;
        private static ToggleButton EnergyDisplayStepDayButton = JazzButton.EnergyDisplayStepDayButton;
        private static ToggleButton EnergyDisplayStepWeekButton = JazzButton.EnergyDisplayStepWeekButton;
        private static ToggleButton EnergyDisplayStepMonthButton = JazzButton.EnergyDisplayStepMonthButton;
        private static ToggleButton EnergyDisplayStepYearButton = JazzButton.EnergyDisplayStepYearButton;
        private static Button MultipleHierarchyAddTagsButton = JazzButton.MultipleHierarchyAddTagsButton;
        //Select system dimension tree button
        private static Button SelectSystemDimensionButton = JazzButton.EnergyViewSelectSystemDimensionButton;
        private static SystemDimensionTree SystemDimensionTree = JazzTreeView.EnergyViewSystemDimensionTree;

        //Select area dimension tree button
        private static Button SelectAreaDimensionButton = JazzButton.EnergyViewSelectAreaDimensionButton;
        private static AreaDimensionTree AreaDimensionTree = JazzTreeView.EnergyViewAreaDimensionTree;

        private static Dictionary<DisplayStep, string> DisplayStepItem = new Dictionary<DisplayStep, string>()
        {
            {DisplayStep.Hour, "按小时"},
            {DisplayStep.Day, "按天"},
            {DisplayStep.Week, "按周"},
            {DisplayStep.Month, "按月"},
            {DisplayStep.Year, "按年"},
        };

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
        /// Navigate to all dashboard
        /// </summary>
        /// <param name="step"></param>
        public void NavigateToAllDashBoards()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AllDashboards);
        }

        /// <summary>
        /// Judge if supported display step button displayed on window
        /// </summary>
        /// <param name="step"></param>
        public bool IsStepButtonOnWindow(DisplayStep step)
        {
            Button stepButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonDisplayStepWindow, DisplayStepItem[step]);

            return stepButton.Exists();
        }

        /// <summary>
        /// Click display step button displayed on window
        /// </summary>
        /// <param name="name"></param>
        public void ClickStepButtonOnWindow(DisplayStep step)
        {
            Button stepButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonDisplayStepWindow, DisplayStepItem[step]);

            stepButton.Click();
        }

        /// <summary>
        /// Click giveup button displayed on window
        /// </summary>
        /// <param name="name"></param>
        public void ClickGiveupButtonOnWindow()
        {
            JazzButton.GiveUpStepWindowButton.Click();
        }

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

        /// <summary>
        /// Is display step button pressed
        /// </summary>
        /// <param name="step"></param>
        public bool IsDisplayStepPressed(DisplayStep step)
        {
            switch (step)
            {
                case DisplayStep.Hour:
                    //"Hourly" step
                    return EnergyDisplayStepHourButton.IsButtonPressed();
                case DisplayStep.Day:
                    //"Daily" step
                    return EnergyDisplayStepDayButton.IsButtonPressed();
                case DisplayStep.Week:
                    //"Weekly" step
                    return EnergyDisplayStepWeekButton.IsButtonPressed();
                case DisplayStep.Month:
                    //"Monthly" step
                    return EnergyDisplayStepMonthButton.IsButtonPressed();
                case DisplayStep.Year:
                    //"Year" step
                    return EnergyDisplayStepYearButton.IsButtonPressed();
                default:
                    return true;
            }
        }

        /// <summary>
        /// Is display step button displayed
        /// </summary>
        /// <param name="step"></param>
        public bool IsDisplayStepDisplayed(DisplayStep step)
        {
            switch (step)
            {
                case DisplayStep.Hour:
                    //"Hourly" step
                    return EnergyDisplayStepHourButton.Exists();
                case DisplayStep.Day:
                    //"Daily" step
                    return EnergyDisplayStepDayButton.Exists();
                case DisplayStep.Week:
                    //"Weekly" step
                    return EnergyDisplayStepWeekButton.Exists();
                case DisplayStep.Month:
                    //"Monthly" step
                    return EnergyDisplayStepMonthButton.Exists();
                case DisplayStep.Year:
                    //"Year" step
                    return EnergyDisplayStepYearButton.Exists();
                default:
                    return true;
            }
        }


        /// <summary>
        /// Click Multiple Hierarchy Add Tags button
        /// </summary>
        public void ClickMultipleHierarchyAddTagsButton()
        {
            MultipleHierarchyAddTagsButton.Click();
        }

        /// <summary>
        /// Judge if this button displayed
        /// </summary>
        public bool IsMultipleHierarchyAddTagsButtonDisplayed()
        {
            return MultipleHierarchyAddTagsButton.IsDisplayed();
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
            catch (Exception)
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

        /// <summary>
        /// Click "请选择区域维度" button in "区域数据点"
        /// </summary>
        public void ClickSelectAreaDimensionButton()
        {

            SelectAreaDimensionButton.Click();
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

        /// <summary>
        /// Export expected data table to excel file
        /// </summary>
        /// <param name="displayStep"></param>
        public void ExportExpectedDataTableToExcel(string fileName, DisplayStep displayStep, string path)
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
                string actualFileName = Path.Combine(path, fileName);
                JazzFunction.DataViewOperation.MoveExpectedDataViewToExcel(data, actualFileName, JazzFunction.DataViewOperation.sheetNameExpected);
            }
        }

        /// <summary>
        /// Export Ranking expected data table to excel file
        /// </summary>
        /// <param name="displayStep"></param>
        public void ExportRankingExpectedDataTableToExcel(string fileName, string path)
        {
            if (ExecutionConfig.isCreateExpectedDataViewExcelFile)
            {
                //display data view
                JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();

                //Load data view and get data table
                DataTable data = GetAllData();

                //Export to excel
                string actualFileName = Path.Combine(path, fileName);
                JazzFunction.DataViewOperation.MoveExpectedDataViewToExcel(data, actualFileName, JazzFunction.DataViewOperation.sheetNameExpected);
            }
        }

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareDataViewOfEnergyAnalysis(string expectedFileName, string failedFileName, string path)
        {
            string filePath = Path.Combine(path, expectedFileName);
            DataTable actualData = GetAllData();

            DataTable expectedDataTable = JazzFunction.DataViewOperation.ImportExpectedFileToDataTable(filePath, JazzFunction.DataViewOperation.sheetNameExpected);

            return JazzFunction.DataViewOperation.CompareDataTables(expectedDataTable, actualData, failedFileName);
        }

        #endregion
                
        #region Chart view operations

        public bool IsColumnDrawn()
        {
            return Chart.HasDrawnColumn();
        }

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
