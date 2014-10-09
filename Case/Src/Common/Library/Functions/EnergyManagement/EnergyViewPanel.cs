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
using Mento.Utility;

namespace Mento.ScriptCommon.Library.Functions
{
    public abstract class EnergyViewPanel
    {
        #region Controls
        //Select hierarchy button
        private static Button SelectHierarchyButton = JazzButton.EnergyViewSelectHierarchyButton;
        private static HierarchyTree HierarchyTree = JazzTreeView.EnergyViewHierarchyTree;

        private static ToggleButton EnergyDisplayStepRawButton = JazzButton.EnergyDisplayStepRawButton;
        private static ToggleButton EnergyDisplayStepHourButton = JazzButton.EnergyDisplayStepHourButton;
        private static ToggleButton EnergyDisplayStepDayButton = JazzButton.EnergyDisplayStepDayButton;
        private static ToggleButton EnergyDisplayStepWeekButton = JazzButton.EnergyDisplayStepWeekButton;
        private static ToggleButton EnergyDisplayStepMonthButton = JazzButton.EnergyDisplayStepMonthButton;
        private static ToggleButton EnergyDisplayStepYearButton = JazzButton.EnergyDisplayStepYearButton;
        private static Button MultipleHierarchyAddTagsButton = JazzButton.MultipleHierarchyAddTagsButton;
        private static Container MultiHierarchysContainer = JazzContainer.MultiHierarchysContainer;
        //Select system dimension tree button
        private static Button SelectSystemDimensionButton = JazzButton.EnergyViewSelectSystemDimensionButton;
        private static SystemDimensionTree SystemDimensionTree = JazzTreeView.EnergyViewSystemDimensionTree;

        //Select area dimension tree button
        private static Button SelectAreaDimensionButton = JazzButton.EnergyViewSelectAreaDimensionButton;
        private static AreaDimensionTree AreaDimensionTree = JazzTreeView.EnergyViewAreaDimensionTree;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;

        private static Dictionary<DisplayStep, string> DisplayStepItem = new Dictionary<DisplayStep, string>()
        {
            {DisplayStep.Raw, "$@EM.UseRaw"},
            {DisplayStep.Hour, "$@EM.UseHour"},
            {DisplayStep.Day, "$@EM.UseDay"},
            {DisplayStep.Week, "$@EM.UseWeek"},
            {DisplayStep.Month, "$@EM.UseMonth"},
            {DisplayStep.Year, "$@EM.UseYear"},
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
        /// <param name="step">enum</param>
        public void ClickDisplayStep(DisplayStep step)
        {
            switch (step)
            {
                case DisplayStep.Raw:
                    //click "Raw" step
                    EnergyDisplayStepRawButton.Click();
                    break;
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
        /// Click display step button
        /// </summary>
        /// <param name="step">string</param>
        public void ClickDisplayStep(string step)
        {
            switch (step)
            {
                case "Hour":
                    //click "Hourly" step
                    EnergyDisplayStepHourButton.Click();
                    break;
                case "Day":
                    //click "Daily" step
                    EnergyDisplayStepDayButton.Click();
                    break;
                case "Week":
                    //click "Weekly" step
                    EnergyDisplayStepWeekButton.Click();
                    break;
                case "Month":
                    //click "Monthly" step
                    EnergyDisplayStepMonthButton.Click();
                    break;
                case "Year":
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
                case DisplayStep.Raw:
                    //"Hourly" step
                    return EnergyDisplayStepRawButton.IsButtonPressed();
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

        /*
        public DataTable GetAllData()
        {
            return EnergyDataGrid.GetAllData();
        }
        */

        public DataTable GetAllData()
        {
            return EnergyDataGrid.GetAllDataWithoutNull();
        }

        public ExcelHelper.CellsValue[] GetHeaderData()
        {
            ExcelHelper.CellsValue[] headersSheet = EnergyDataGrid.GetGridHeader();

            return headersSheet;
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
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();

                //Load data view and get data table

                DataTable data = GetAllData();
                ExcelHelper.CellsValue[] headersSheet = GetHeaderData();

                //Export to excel
                string actualFileName = Path.Combine(path, fileName);
                JazzFunction.DataViewOperation.MoveExpectedDataViewToExcelWithHeaderSheet(data, actualFileName, JazzFunction.DataViewOperation.sheetNameExpected, headersSheet);
            }
        }

        /// <summary>
        /// Export expected data table to excel file
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <param name="path">path</param>
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
                ExcelHelper.CellsValue[] headersSheet = GetHeaderData();

                //Export to excel
                string actualFileName = Path.Combine(path, fileName);
                JazzFunction.DataViewOperation.MoveExpectedDataViewToExcelWithHeaderSheet(data, actualFileName, JazzFunction.DataViewOperation.sheetNameExpected, headersSheet);
            }
        }

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareDataViewOfEnergyAnalysis(string expectedFileName, string failedFileName, string path)
        {
            if (ExecutionConfig.isCompareExpectedDataViewExcelFile)
            {
                string filePath = Path.Combine(path, expectedFileName);
                JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();

                DataTable actualData = GetAllData();
                ExcelHelper.CellsValue[] headersSheet = GetHeaderData();
                bool IsHeaderEqual;

                DataTable expectedDataTable = JazzFunction.DataViewOperation.ImportExpectedFileToDataTable(filePath, JazzFunction.DataViewOperation.sheetNameExpected);
                ExcelHelper.CellsValue[] expectedHeadersSheet = JazzFunction.DataViewOperation.ImportExpectedFileHeaderDataToCellsValue(filePath, JazzFunction.DataViewOperation.sheetNameHeader, headersSheet);
                ExcelHelper.CellsValue[] resultHeadersSheet = JazzFunction.DataViewOperation.CompareHeaderDatas(expectedHeadersSheet, headersSheet, out IsHeaderEqual);

                return JazzFunction.DataViewOperation.CompareDataTables(expectedDataTable, actualData, failedFileName, resultHeadersSheet, IsHeaderEqual);
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// On ranking function, import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareDataViewOfRanking(string expectedFileName, string failedFileName, string path)
        {
            if (ExecutionConfig.isCompareExpectedDataViewExcelFile)
            {
                string filePath = Path.Combine(path, expectedFileName);
                JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();

                DataTable actualData = GetAllData();
                ExcelHelper.CellsValue[] headersSheet = GetHeaderData();
                bool IsHeaderEqual;

                DataTable expectedDataTable = JazzFunction.DataViewOperation.ImportExpectedFileToDataTable(filePath, JazzFunction.DataViewOperation.sheetNameExpected);
                ExcelHelper.CellsValue[] expectedHeadersSheet = JazzFunction.DataViewOperation.ImportExpectedFileHeaderDataToCellsValue(filePath, JazzFunction.DataViewOperation.sheetNameHeader, headersSheet);
                ExcelHelper.CellsValue[] resultHeadersSheet = JazzFunction.DataViewOperation.CompareHeaderDatas(expectedHeadersSheet, headersSheet, out IsHeaderEqual);

                return JazzFunction.DataViewOperation.CompareDataTablesForRanking(expectedDataTable, actualData, failedFileName, resultHeadersSheet, IsHeaderEqual);
            }
            else
            {
                return true;
            }
        }

        #endregion
                
        #region Chart view operations

        #region common

        public bool EntirelyNoChartDrawn()
        {
            return Chart.EntirelyNoChartDrawn();
        }

        public bool IsScrollbarExist()
        {
            return Chart.IsScrollbarExists();
        }

        #endregion

        #region column chart

        public bool IsColumnDrawn()
        {
            return Chart.HasDrawnColumn();
        }

        public int GetColumnChartColumns()
        {
            return Chart.GetColumnChartColumns();
        }

        public int GetTotalColumns()
        {
            return Chart.GetTotalColumns();
        }

        #endregion

        #region Trend chart 

        public bool IsTrendChartDrawn()
        {
            return Chart.HasDrawnTrend();
        }

        public int GetTrendChartLines()
        {
            return Chart.GetTrendChartLines();
        }

        public int GetPieChartSpans()
        {
            return Chart.GetPieDistributions();
        }

        public int GetTrendChartLinesMarkers()
        {
            return Chart.GetTrendChartLinesMarkers();
        }

        #endregion

        #region Pie chart

        public bool IsDistributionChartDrawn()
        {
            return Chart.HasDrawnPie();
        }

        public int GetPiesNumber()
        {
            return Chart.GetPieDistributions();
        }

        public string[] GetPieDataLabelTexts()
        {
            return Chart.GetPieDataLabelTexts();
        }

        #endregion

        #region Data view
        
        public bool IsDataViewDrawn()
        {
            return EnergyDataGrid.HasDrawnDataView();
        }

        #endregion

        #region legend

        public string[] GetLegendItemTexts()
        {
            return Chart.GetLegendItemsTexts();
        }
        
        public bool IsLegendExists()
        {
            return Chart.LegendExists();
        }

        public bool IsLegendItemExists(string legendName)
        {
            return Chart.LegendItemExists(legendName);
        }

        public void ClickLegendItem(string legendName)
        {
            Chart.ClickLegendItem(legendName);
        }

        public void CloseLegendItem(string legendName)
        {
            Chart.CloseLegendItem(legendName);
        }

        public void HideLineCurveLegend(string legendName)
        {
            Chart.HideLineCurve(legendName);
        }

        public void ShowLineCurveLegend(string legendName)
        {
            Chart.ShowLineCurve(legendName);
        }

        public void HideColumnCurveLegend(string legendName)
        {
            Chart.HideColumnCurve(legendName);
        }

        public void ShowColumnCurveLegend(string legendName)
        {
            Chart.ShowColumnCurve(legendName);
        }

        public bool IsColumnLegendItemShown(string legendName)
        {
            return Chart.IsColumnLegendItemShown(legendName);
        }

        public bool IsLineLegendItemShown(string legendName)
        {
            return Chart.IsLineLegendItemShown(legendName);
        }

        public bool IsCloseLegendButtonExist(string legendName)
        {
            return Chart.IsCloseLegendButtonExist(legendName);
        }

        #endregion

        #region for pie chart verification

        public string GetActualHierarchyPath()
        {
            string dimendionPath = null;
            /*
            if (SelectSystemDimensionButton.Exists())
            {
                dimendionPath = "/" + SelectSystemDimensionButton.GetText();
            }
            
            if (SelectAreaDimensionButton.Exists())
            {
                dimendionPath = "/" + SelectAreaDimensionButton.GetText();
            }
            */
            return SelectHierarchyButton.GetText() + dimendionPath;
        }

        public string GetExpectedHierarchyPath(string[] hierarchyPaths, string[] dimensionPaths = null)
        {
            int hierarchyNum = hierarchyPaths.Length;
            string ExpectedHierarchyPath = hierarchyPaths[0];

            for (int i = 1; i < hierarchyNum; i++)
            {
                ExpectedHierarchyPath = ExpectedHierarchyPath + "/" + hierarchyPaths[i];
            }
            /*
            if (dimensionPaths != null)
            {
                for (int j = 0; j < dimensionPaths.Length; j++)
                {
                    ExpectedHierarchyPath = ExpectedHierarchyPath + "/" + dimensionPaths[j];
                }
            }
            */
            return ExpectedHierarchyPath;
        }

        public string GetActualTimeRange()
        {
            string ActualTimeRange = EnergyViewToolbar.GetStartDate() + " " + EnergyViewToolbar.GetStartTime() + " to " + EnergyViewToolbar.GetEndTime() + " " + EnergyViewToolbar.GetEndDate();

            return ActualTimeRange;
        }

        public string GetExpectedTimeRange(ManualTimeRange manualTimeRange)
        {
            string ExpectedTimeRange = null;
            
            if (String.IsNullOrEmpty(manualTimeRange.StartTime) || String.IsNullOrEmpty(manualTimeRange.EndTime))
            {
                ExpectedTimeRange = manualTimeRange.StartDate + " 00:00" + " to " +"24:00 " + manualTimeRange.EndDate;

            }
            else 
            {
                ExpectedTimeRange = manualTimeRange.StartDate + " " + manualTimeRange.StartTime + " to " + manualTimeRange.EndTime + " " + manualTimeRange.EndDate;
            }

            return ExpectedTimeRange;
        }

        public Dictionary<string, string> GetActualPieData()
        {
            Dictionary<string, string> actualPieDict = new Dictionary<string, string>();
            var pieValues = Chart.GetPieDataLegendAndTexts();

            actualPieDict.Add("Hierarchy", GetActualHierarchyPath());
            actualPieDict.Add("TimeRange", GetActualTimeRange());

            foreach (var pieValue in pieValues)
            {
                actualPieDict.Add(pieValue.tagOrCommodity, pieValue.valueAndUOM);
            }

            return actualPieDict;
        }

        public Dictionary<string, string> GetExpecedPieData(string[] hierarchyPaths, ManualTimeRange manualTimeRange, string[] dimensionPaths = null)
        {
            Dictionary<string, string> actualPieDict = new Dictionary<string, string>();
            var pieValues = Chart.GetPieDataLegendAndTexts();

            actualPieDict.Add("Hierarchy", GetExpectedHierarchyPath(hierarchyPaths, dimensionPaths));
            actualPieDict.Add("TimeRange", GetExpectedTimeRange(manualTimeRange));

            foreach (var pieValue in pieValues)
            {
                actualPieDict.Add(pieValue.tagOrCommodity, pieValue.valueAndUOM);
            }

            return actualPieDict;
        }

        public Dictionary<string, string> GetMulTimePieData(string[] hierarchyTag, ManualTimeRange manualTimeRange, string[] dimensionPaths = null)
        {
            Dictionary<string, string> actualPieDict = new Dictionary<string, string>();
            var pieValues = Chart.GetPieDataLegendAndTexts();

            actualPieDict.Add("Hierarchy", GetExpectedHierarchyPath(hierarchyTag, dimensionPaths));
            actualPieDict.Add("TimeRange", GetExpectedTimeRange(manualTimeRange));

            foreach (var pieValue in pieValues)
            {
                actualPieDict.Add(pieValue.tagOrCommodity, pieValue.valueAndUOM);
            }

            return actualPieDict;
        }

        /// <summary>
        /// Export expected data to excel file
        /// </summary>
        /// <param name="hierarchyPaths"></param>
        public void ExportExpectedDictionaryToExcel(string[] hierarchyPaths, ManualTimeRange manualTimeRange, string fileName, string path, string[] dimensionPaths = null)
        {
            if (ExecutionConfig.isCreateExpectedDataViewExcelFile)
            {
                Dictionary<string, string> expectedactualPieDict = GetExpecedPieData(hierarchyPaths, manualTimeRange, dimensionPaths);

                //Export to excel
                string actualFileName = Path.Combine(path, fileName);
                JazzFunction.ChartViewOperation.MoveExpectedDataToExcel(expectedactualPieDict, actualFileName, JazzFunction.DataViewOperation.sheetNameExpected);
            }
        }

        /// <summary>
        /// Export expected data to excel file
        /// </summary>
        /// <param name="hierarchyPaths"></param>
        public void ExportMulTimePieDictionaryToExcel(string[] hierarchyPaths, ManualTimeRange manualTimeRange, string fileName, string path, string[] dimensionPaths = null)
        {
            //if (ExecutionConfig.isCreateExpectedDataViewExcelFile)
            //{
            Dictionary<string, string> expectedactualPieDict = GetMulTimePieData(hierarchyPaths, manualTimeRange, dimensionPaths);

                //Export to excel
                string actualFileName = Path.Combine(path, fileName);
                JazzFunction.ChartViewOperation.MoveExpectedDataToExcel(expectedactualPieDict, actualFileName, JazzFunction.DataViewOperation.sheetNameExpected);
            //}
        }

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareDictionaryDataOfEnergyAnalysis(string expectedFileName, string failedFileName, string path)
        {
            if (ExecutionConfig.isCompareExpectedDataViewExcelFile)
            {
                string filePath = Path.Combine(path, expectedFileName);

                Dictionary<string, string> actualDict = GetActualPieData();

                Dictionary<string, string> expectedDict = JazzFunction.ChartViewOperation.ImportExpectedFileToDictionary(filePath, JazzFunction.ChartViewOperation.sheetNameExpected);

                return JazzFunction.ChartViewOperation.CompareDictionarys(expectedDict, actualDict, failedFileName);
            }
            else
            {
                return true;
            }
        }

        #region for labelling verification

        /// <summary>
        /// Export expected string data to excel file
        /// </summary>
        /// <param name="hierarchyPaths"></param>
        public void ExportExpectedStringToExcel(string[] datas, string fileName, string path)
        {
            if (ExecutionConfig.isCreateExpectedDataViewExcelFile)
            {
               //Export to excel
                string actualFileName = Path.Combine(path, fileName);
                JazzFunction.ChartViewOperation.MoveExpectedDataToExcel(datas, actualFileName, JazzFunction.DataViewOperation.sheetNameExpected);
            }
        }

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareStringDataOfEnergyAnalysis(string[] actualDatas, string expectedFileName, string failedFileName, string path)
        {
            if (ExecutionConfig.isCompareExpectedDataViewExcelFile)
            {
                string filePath = Path.Combine(path, expectedFileName);

                string[] expectedStringDatas = JazzFunction.ChartViewOperation.ImportExpectedFileToString(filePath, JazzFunction.ChartViewOperation.sheetNameExpected);

                return JazzFunction.ChartViewOperation.CompareStrings(expectedStringDatas, actualDatas, failedFileName);
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Multiple hierarchy left region

        public HierarchysAndTags[] GetActualHierarchysAndTags()
        {
            int hierarchyNum = MultiHierarchysContainer.GetElementNumber();
            var hietagsList = new List<HierarchysAndTags>();
            var hietagsVlaue = new HierarchysAndTags();

            for (int i = 1; i < hierarchyNum + 1; i++)
            {
                Label hierarchys = JazzLabel.GetOneLabel(JazzControlLocatorKey.LabelMultiHieararchy, i);
                Grid hierarchyTags = JazzGrid.GetOneGrid(JazzControlLocatorKey.GridMultiHieararchyTagsList, i);    

                hietagsVlaue.Hieararchy = hierarchys.GetLabelTextValue();
                hietagsVlaue.tags = hierarchyTags.GetRowsData(1);

                hietagsList.Add(hietagsVlaue);
            }

            return hietagsList.ToArray();
        }

        public HierarchysAndTags[] GetExpectedHierarchysAndTags(MultipleHierarchyAndtags[] expectedHierarchyDatas)
        {
            var hietagsList = new List<HierarchysAndTags>();
            var hietagsVlaue = new HierarchysAndTags();
            
            foreach (MultipleHierarchyAndtags expectedHierarchyData in expectedHierarchyDatas)
            {
                hietagsVlaue.Hieararchy = GetExpectedHierarchyPath(expectedHierarchyData.HierarchyPath);
                hietagsVlaue.tags = expectedHierarchyData.TagsName;

                hietagsList.Add(hietagsVlaue);
            }

            return hietagsList.ToArray();
        }

        public Dictionary<string, string> GetActualMultipleHierarchyPieData()
        {
            Dictionary<string, string> actualPieDict = new Dictionary<string, string>();
            var pieValues = Chart.GetPieDataLegendAndTexts();
            HierarchysAndTags[] HierarchysAndTagsLists = GetActualHierarchysAndTags();
         
            actualPieDict.Add("TimeRange", GetActualTimeRange());
            for (int i = 0; i < HierarchysAndTagsLists.Length; i++)
            {
                string taglist = ConvertTagsArrayToString(HierarchysAndTagsLists[i].tags);

                if (actualPieDict.ContainsKey(HierarchysAndTagsLists[i].Hieararchy))
                {
                    actualPieDict[HierarchysAndTagsLists[i].Hieararchy] = taglist;
                }
                else
                {
                    actualPieDict.Add(HierarchysAndTagsLists[i].Hieararchy, taglist);
                }
            }       

            foreach (var pieValue in pieValues)
            {
                actualPieDict.Add(pieValue.tagOrCommodity, pieValue.valueAndUOM);
            }

            return actualPieDict;
        }

        public Dictionary<string, string> GetExpecedMultipleHierarchyPieData(ManualTimeRange manualTimeRange, string[] dimensionPaths = null)
        {
            Dictionary<string, string> expectedPieDict = new Dictionary<string, string>();
            var pieValues = Chart.GetPieDataLegendAndTexts();
            HierarchysAndTags[] HierarchysAndTagsLists = GetActualHierarchysAndTags();

            expectedPieDict.Add("TimeRange", GetExpectedTimeRange(manualTimeRange));
            for (int i = 0; i < HierarchysAndTagsLists.Length; i++)
            {
                string taglist = ConvertTagsArrayToString(HierarchysAndTagsLists[i].tags);

                if (expectedPieDict.ContainsKey(HierarchysAndTagsLists[i].Hieararchy))
                {
                    expectedPieDict[HierarchysAndTagsLists[i].Hieararchy] = expectedPieDict[HierarchysAndTagsLists[i].Hieararchy] + "," + taglist;
                }
                else
                {
                    expectedPieDict.Add(HierarchysAndTagsLists[i].Hieararchy, taglist);
                }
            }   

            foreach (var pieValue in pieValues)
            {
                expectedPieDict.Add(pieValue.tagOrCommodity, pieValue.valueAndUOM);
            }

            return expectedPieDict;
        }


        /// <summary>
        /// Export expected data of multiple hierarchy nodes data to excel file
        /// </summary>
        /// <param name="displayStep"></param>
        public void ExportExpectedDictionaryToExcelMultiHiearachy(ManualTimeRange manualTimeRange, string fileName, string path, string[] dimensionPaths = null)
        {
            if (ExecutionConfig.isCreateExpectedDataViewExcelFile)
            {
                Dictionary<string, string> expectedactualPieDict = GetExpecedMultipleHierarchyPieData(manualTimeRange);

                //Export to excel
                string actualFileName = Path.Combine(path, fileName);
                JazzFunction.ChartViewOperation.MoveExpectedDataToExcel(expectedactualPieDict, actualFileName, JazzFunction.DataViewOperation.sheetNameExpected);
            }
        }

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareDictionaryDataMultipleHierarchyOfEnergyAnalysis(string expectedFileName, string failedFileName, string path)
        {
            if (ExecutionConfig.isCompareExpectedDataViewExcelFile)
            {
                string filePath = Path.Combine(path, expectedFileName);

                Dictionary<string, string> actualDict = GetActualMultipleHierarchyPieData();

                Dictionary<string, string> expectedDict = JazzFunction.ChartViewOperation.ImportExpectedFileToDictionary(filePath, JazzFunction.ChartViewOperation.sheetNameExpected);

                return JazzFunction.ChartViewOperation.CompareDictionarys(expectedDict, actualDict, failedFileName);
            }
            else
            {
                return true;
            }
        }

        private string ConvertTagsArrayToString(string[] tags)
        {
            string tagstring = tags[0];

            for (int i = 1; i < tags.Length; i++)
            {
                tagstring = tagstring + "," + tags[i];
            }

            return tagstring;
        }

        public struct HierarchysAndTags
        {
            public string Hieararchy;
            public string[] tags;
        }

        #endregion

        #endregion

        #endregion

        #region predefined time data verification

        private string[] GetDataRange()
        {
            DataTable data = GetAllData();
            var list = new List<string>();

            int rangeLength = data.Rows.Count;

            for (int i = rangeLength - 1; i >= 0; i--)
            {
                list.Add(data.Rows[i][1].ToString());
            }

            return list.ToArray();
        }

        public bool IsLast7DaysDataCorrect(string expectedValue)
        {
            var values = GetDataRange();
            int correctNum = 0;

            foreach (var value in values)
            {
                if (String.Equals(expectedValue, value))
                {
                    correctNum++;
                }
            }

            return correctNum > 1;
        }

        public string IsLastMonthMonthlyDataCorrect()
        {
            var values = GetDataRange();

            if (values.Length == 1)
            {
                throw new Exception("今年只有一个月，请手动验证去年12月的值");
            }

            //return String.Equals(expectedValue, values[1]);
            return values[1];
        }

        public bool IsLastMonthDailyDataCorrect(string expectedValue)
        {
            var values = GetDataRange();
            int correctNum = 0;

            foreach (var value in values)
            {
                if (String.Equals(expectedValue, value))
                {
                    correctNum++;
                }
            }

            return correctNum >= 27;
            //return correctNum == 27;
        }

        #endregion

    }

    public enum TagTabs { HierarchyTag, SystemDimensionTab, AreaDimensionTab, }
    public enum DisplayStep { Raw, Hour, Day, Week, Month, Year, Default}
}
