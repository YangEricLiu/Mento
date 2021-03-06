﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;   
using System.Reflection;
using System.Data;
using System.Text.RegularExpressions;

namespace Mento.Utility
{
    /// <summary> 
    /// Excel Helper class,  
    /// </summary> 
    /// <remarks>Used to create file, insert data and so on</remarks> 
    public sealed class ExcelHelper : IDisposable
    {
        #region Constructor Function
        /// <summary>
        /// ExcelHandler constructor
        /// </summary>
        /// <param name="fileName">Excel file name, absolute path </param>
        /// <returns></returns>
        public ExcelHelper(string filePath)
            : this(filePath, false)
        { 
            
        }

        /// <summary>
        /// Create ExcelHandler constructor, given excel file name and whether create now file
        /// </summary>
        /// <param name="fileName">Excel file name, absolute path </param>
        /// <param name="createNew">Whether create new file </param>
        /// <returns></returns>
        public ExcelHelper(string filePath, Boolean createNew)
        {
            this.filePath = filePath;
            this._createNew = createNew;
        }
        #endregion

        #region Field and Attribute

        private static readonly object missing = Missing.Value;

        private string _filePath;
        /// <summary> 
        /// Excel file name 
        /// </summary> 
        public string filePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }
        /// <summary> 
        /// Whether create new excel file 
        /// </summary> 
        private bool _createNew;

        private Excel.Application _app;
        /// <summary> 
        /// Current excel app
        /// </summary> 
        public Excel.Application app
        {
            get { return _app; }
            set { _app = value; }
        }

        private Excel.Workbooks _allWorkbooks;
        /// <summary> 
        /// All the opened workbooks of current excel app
        /// </summary> 
        public Excel.Workbooks allWorkbooks
        {
            get { return _allWorkbooks; }
            set { _allWorkbooks = value; }
        }

        private Excel.Workbook _currentWorkbook;
        /// <summary> 
        /// Current workbook 
        /// </summary> 
        public Excel.Workbook currentWorkbook
        {
            get { return _currentWorkbook; }
            set { _currentWorkbook = value; }
        }

        private Excel.Worksheets _allWorksheets;
        /// <summary> 
        /// All the worksheet of current workbook 
        /// </summary> 
        public Excel.Worksheets allWorksheets
        {
            get { return _allWorksheets; }
            set { _allWorksheets = value; }
        }

        private Excel.Worksheet _currentWorksheet;
        /// <summary> 
        /// The current active worksheet
        /// </summary> 
        public Excel.Worksheet currentWorksheet
        {
            get { return _currentWorksheet; }
            set { _currentWorksheet = value; }
        } 

        #endregion

        #region Initialized Operation

        /// <summary> 
        /// Initialized, open directly or create new excel file
        /// </summary> 
        public void OpenOrCreate()
        {
            //this.app = new Excel.Application();
            this.app = new Excel.Application();
            this.allWorkbooks = this.app.Workbooks;

            //Open existed excel file 
            if (!this._createNew) 
            {
                if (!File.Exists(this.filePath))
                {
                    throw new FileNotFoundException("Can't find the file,please check whether the path is correct！", this.filePath);
                }

                this.currentWorkbook = this.allWorkbooks.Open(this.filePath, Type.Missing, Type.Missing, Type.Missing, 
                    Type.Missing, Type.Missing, Type.Missing, Excel.XlPlatform.xlWindows, Type.Missing, Type.Missing, 
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            }
            //Create new excel file
            else 
            {
                if (File.Exists(this.filePath))
                {
                    File.Delete(this.filePath);
                }
                this.currentWorkbook = this.allWorkbooks.Add(Type.Missing);

            }

            this.allWorksheets = this.currentWorkbook.Worksheets as Excel.Worksheets;
            this.currentWorksheet = this.currentWorkbook.ActiveSheet as Excel.Worksheet;
            this.app.DisplayAlerts = false;
            this.app.Visible = false;
        }
        #endregion 

        #region Excel Sheet Operation

        /// <summary> 
        /// Get the reference of excel worksheet according to sheet name
        /// </summary> 
        /// <param name="sheetName"></param> 
        /// <returns></returns> 
        public Excel.Worksheet GetWorksheet(string sheetName)
        {
            int count = this.currentWorkbook.Sheets.Count;

            for (int i = 1; i < count; i++ )
            {
                if(sheetName == this.currentWorkbook.Sheets[i].Name)
                    return this.currentWorkbook.Sheets[sheetName] as Excel.Worksheet;

            }
            return this.AddWorksheet(sheetName, false);
        }

        /// <summary> 
        /// Get the reference of excel worksheet according to sheet name
        /// </summary> 
        /// <param name="sheetName"></param> 
        /// <returns></returns> 
        public Excel.Worksheet NewJazzGetWorksheet(string sheetName)
        {
            return this.currentWorkbook.Sheets[sheetName] as Excel.Worksheet;
        }

        /// <summary> 
        /// Get the reference of excel worksheet according to worksheet index
        /// </summary> 
        /// <param name="index"></param> 
        /// <returns></returns> 
        public Excel.Worksheet GetWorksheet(int index)
        {
            return this.currentWorkbook.Sheets.get_Item(index) as Excel.Worksheet;
        }

        /// <summary> 
        /// Add worksheet to current workbook and not activated, overload
        /// </summary> 
        /// <param name="sheetName"></param> 
        /// <returns></returns> 
        public Excel.Worksheet AddWorksheet(string sheetName)
        {
            return this.AddWorksheet(sheetName, false);
        }

        /// <summary> 
        /// Add worksheet to current workbook, then return 
        /// </summary> 
        /// <param name="sheetName">Sheet name</param> 
        /// <param name="activated">Whether to activate the sheet after create</param> 
        /// <returns></returns> 
        public Excel.Worksheet AddWorksheet(string sheetName, bool activated)
        {
            Excel.Worksheet sheet = this.currentWorkbook.Worksheets.Add(Type.Missing, Type.Missing, 1, Type.Missing) as Excel.Worksheet;
            sheet.Name = sheetName;
            if (activated)
            {
                sheet.Activate();
            }
            return sheet;
        }

        /// <summary> 
        /// Rename worksheet 
        /// </summary> 
        /// <param name="sheet">Worhsheet object</param> 
        /// <param name="newName">New name for worksheet</param> 
        /// <returns></returns> 
        public Excel.Worksheet RenameWorksheet(Excel.Worksheet sheet, string newName)
        {
            sheet.Name = newName;
            return sheet;
        }

        /// <summary> 
        /// Rename worksheet 
        /// </summary> 
        /// <param name="oldName">Old name</param> 
        /// <param name="newName">New name</param> 
        /// <returns></returns> 
        public Excel.Worksheet RenameWorksheet(string oldName, string newName)
        {
            Excel.Worksheet sheet = this.GetWorksheet(oldName);
            return this.RenameWorksheet(sheet, newName);
        }

        /// <summary> 
        /// Delete worksheet
        /// </summary> 
        /// <param name="sheetName">工作表名</param> 
        public void DeleteWorksheet(string sheetName)
        {
            if (this.currentWorkbook.Worksheets.Count <= 1)
            {
                throw new InvalidOperationException("Workbook at least have one visible worksheet");
            }
            this.GetWorksheet(sheetName).Delete();
        }

        /// <summary> 
        /// Delete worksheet except the para sheet
        /// 删除除参数sheet指定外的其余工作表 
        /// </summary> 
        /// <param name="sheet"></param> 
        public void DeleteWorksheetExcept(Excel.Worksheet sheet)
        {
            foreach (Excel.Worksheet ws in this.currentWorkbook.Worksheets)
            {
                if (sheet != ws)
                {
                    ws.Delete();
                }
            }
        } 

        #endregion

        #region Set Cell format

        /// <summary> 
        /// Auto format
        /// </summary> 
        /// <param name="range"></param> 
        public void AutoAdjustment(Excel.Range range)
        {
            range.WrapText = true;
            range.AutoFit();
        }

        /// <summary> 
        /// Set cell format
        /// </summary> 
        /// <remarks>Set to default</remarks> 
        /// <param name="range"></param> 
        public void SetRangeFormat(Excel.Range range)
        {
            this.SetRangeFormat(range, 11, Excel.Constants.xlAutomatic, Excel.Constants.xlColor1, Excel.Constants.xlLeft);
        }

        /// <summary> 
        /// Set cell format for range
        /// </summary> 
        /// <remarks>set to default</remarks> 
        /// <param name="sheet"></param> 
        /// <param name="rowNumber1"></param> 
        /// <param name="columnNumber1"></param> 
        /// <param name="rowNumber2"></param> 
        /// <param name="columNumber2"></param> 
        public void SetRangeFormat(Excel.Worksheet sheet, int rowNumber1, int columnNumber1, int rowNumber2, int columNumber2)
        {
            this.SetRangeFormat(sheet, rowNumber1, columnNumber1, rowNumber2, columNumber2, 11, Excel.Constants.xlAutomatic);
        }

        /// <summary> 
        /// Set cell format for range
        /// </summary> 
        /// <param name="sheet"></param> 
        /// <param name="rowNumber1">1st range row number</param> 
        /// <param name="columnNumber1">1st range column number</param> 
        /// <param name="rowNumber2">end range row number</param> 
        /// <param name="columnNumber2">end range column number</param> 
        /// <param name="fontSize"></param> 
        /// <param name="fontName"></param> 
        public void SetRangeFormat(Excel.Worksheet sheet, int rowNumber1, int columnNumber1, int rowNumber2, int columNumber2, object fontSize, object fontName)
        {
            this.SetRangeFormat(this.GetRange(sheet, rowNumber1, columnNumber1, rowNumber2, columNumber2), fontSize, fontName, Excel.Constants.xlColor1, Excel.Constants.xlLeft);
        }

        /// <summary> 
        /// Set cell format for range 
        /// </summary> 
        /// <param name="range">Range object</param> 
        /// <param name="fontSize">font size</param> 
        /// <param name="fontName">font name</param> 
        /// <param name="color">font color</param> 
        /// <param name="horizontalAlignment">horizontal alignment</param> 
        public void SetRangeFormat(Excel.Range range, object fontSize, object fontName, Excel.Constants color, Excel.Constants horizontalAlignment)
        {
            range.Font.Color = color;
            range.Font.Size = fontSize;
            range.Font.Name = fontName;
            range.HorizontalAlignment = horizontalAlignment;
        } 

        #endregion

        #region Cell and Range Operation

        /// <summary> 
        /// Set the value for cell
        /// </summary> 
        /// <param name="sheet">worksheet</param> 
        /// <param name="rowNumber">cell row number</param> 
        /// <param name="columnNumber">cell column number</param> 
        /// <param name="value">value for the cell</param> 
        public void SetCellValue(Excel.Worksheet sheet, int rowNumber, int columnNumber, object value)
        {
            sheet.Cells[rowNumber, columnNumber] = value;
        }

        /// <summary> 
        /// Get range object 
        /// </summary> 
        /// <param name="sheet">worksheet</param> 
        /// <param name="rowNumber1">1st cell row number</param> 
        /// <param name="columnNumber1">1st cell column number</param> 
        /// <param name="rowNumber2">end cell row number</param> 
        /// <param name="columnNumber2">end cell column number</param> 
        /// <returns></returns> 
        public Excel.Range GetRange(Excel.Worksheet sheet, int rowNumber1, int columnNumber1, int rowNumber2, int columnNumber2)
        {
            return sheet.get_Range(sheet.Cells[rowNumber1, columnNumber1], sheet.Cells[rowNumber2, columnNumber2]);
        }

        #endregion

        #region Import Data to Excel

        /// <summary> 
        /// Import Data to Excel
        /// </summary> 
        /// <remarks>To the start of worksheet</remarks> 
        /// <param name="sheet"></param> 
        /// <param name="headerTitle"></param> 
        /// <param name="showTitle"></param> 
        /// <param name="headers"></param> 
        /// <param name="table"></param> 
        public void ImportDataTable(Excel.Worksheet sheet, string headerTitle, bool showTitle, string[] headers, DataTable table)
        {
            this.ImportDataTable(sheet, headerTitle, showTitle, headers, 1, 1, table);
        }

        /// <summary> 
        /// Import Scripts Data to Excel 
        /// </summary> 
        /// <remarks>To the start of worksheet, not display title</remarks> 
        /// <param name="sheet"></param> 
        /// <param name="headers"></param> 
        /// <param name="table"></param> 
        public void ImportDataTable(Excel.Worksheet sheet, string[] headers, DataTable table)
        {
            this.ImportDataTable(sheet, null, false, headers, table);

        }

        /// <summary> 
        /// Import header Data to Excel 
        /// </summary> 
        /// <remarks>To the start of worksheet, not display title</remarks> 
        /// <param name="sheet"></param> 
        /// <param name="headers"></param> 
        /// <param name="table"></param> 
        public void ExportHeaderToExcelSheet(Excel.Worksheet sheet, CellsValue[] headers)
        {
            Excel.Range range;

            foreach (CellsValue cellValue in headers)
            {
                range = sheet.Range[sheet.Cells[cellValue.cellsIndex.firstRowIndex, cellValue.cellsIndex.firstColumnIndex], sheet.Cells[cellValue.cellsIndex.lastRowIndex, cellValue.cellsIndex.lastColumnIndex]];
                range.Merge(false);
                range.Value = cellValue.cellsValue;
            }

            sheet.get_Range("A1", "M1").ColumnWidth = 30;
        }

        /// <summary> 
        /// Import Scripts Data to Excel
        /// </summary> 
        /// <remarks>For each column, title is the same with</remarks> 
        /// <param name="sheet"></param> 
        /// <param name="table"></param> 
        public void ImportDataTable(Excel.Worksheet sheet, DataTable table)
        {
            List<string> headers = new List<string>();
            foreach (DataColumn column in table.Columns)
            {
                headers.Add(column.Caption);
            }
            this.ImportDataTable(sheet, headers.ToArray(), table);
        }


        /// <summary> 
        /// Import Scripts Data to Excel
        /// </summary> 
        /// <param name="sheet">work sheet</param> 
        /// <param name="headerTitle">header title</param> 
        /// <param name="showTitle">whether display title row</param> 
        /// <param name="headers">title for each column</param> 
        /// <param name="rowNumber">start row number</param> 
        /// <param name="columnNumber">start column number</param> 
        /// <param name="table">data from array</param> 
        public void ImportDataTable(Excel.Worksheet sheet, string headerTitle, bool showTitle, string[] headers, int rowNumber, int columnNumber, DataTable table)
        {
            int titleRowIndex = rowNumber;
            int headerRowIndex = rowNumber;
            Excel.Range titleRange = null;
            decimal tmp;

            /* In general, show title is false
            if (showTitle)
            {
                headerRowIndex++;
                //add title and set format 
                titleRange = this.GetRange(sheet, rowNumber, columnNumber, rowNumber, columnNumber + columns - 1);
                titleRange.Merge(missing);

                this.SetRangeFormat(titleRange, 16, Excel.Constants.xlAutomatic, Excel.Constants.xlColor1, Excel.Constants.xlCenter);
                titleRange.Value2 = headerTitle;
            }
             */

            //add table header
            if (headers != null)
            {
                int m = 0;
                foreach (string header in headers)
                {
                    this.SetCellValue(sheet, headerRowIndex, columnNumber + m, header);
                    m++;
                }
            }

            if (table != null)
            { 

            int columns = table.Columns.Count;
            int rows = table.Rows.Count;

            //add data for each row
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {               
                    sheet.Cells[headerRowIndex + i + 1, j + columnNumber] = table.Rows[i][j];

                    Excel.Range temp2 = (Excel.Range)sheet.Cells[headerRowIndex + i + 1, j + columnNumber];
                    string value = table.Rows[i][j].ToString();

                    if (value.Contains("年") && value.Contains("月"))
                    {
                        temp2.NumberFormat = "yyyy年mm月";
                    }

                    if (decimal.TryParse(value, out tmp))
                    {                       
                        SetCellNumberFormat(temp2, value);
                    }  
                }             
            }

            sheet.get_Range("A1", "M1").ColumnWidth = 30;
            }
        }

        private void SetCellNumberFormat(Excel.Range cell, string value)
        {
            if (value.Contains(".")) //has decimals
            {
                var numbers = value.Split('.');

                if (numbers[1].Length == 1)
                {
                    cell.NumberFormat = "#,##0.0";
                }
            }
        }

        private void SetCellNumberFormat(Excel.Range cell, decimal? value)
        {
            if (!value.HasValue)
            {
                return;
            }

            if (Math.Floor(value.Value) < value.Value) //has decimals
            {
                var numbers = value.Value.ToString().Split('.');

                if (numbers[1].Length == 1)
                {
                    cell.NumberFormat = "#,##0.0";
                }          
            }
            else //int
            {
                cell.NumberFormat = "0";
            }
        }


        #endregion

        #region Import Excel to Data Table    


        /// <summary> 
        /// Import Excel to Data Table
        /// </summary> 
        /// <remarks>To the start of worksheet</remarks> 
        /// <param name="workSheetName"></param> 
        public DataTable GetDataTableFromExcel(string workSheetName)
        {
            Excel.Worksheet mySheet = GetWorksheet(workSheetName);  //得到工作表

            return this.GetDataTableFromExcel(mySheet);
        }

        /// <summary> 
        /// Import Excel header data to CellsValue
        /// </summary> 
        /// <remarks>To the start of worksheet</remarks> 
        /// <param name="workSheetName"></param> 
        public CellsValue[] GetHeaderDataFromExcel(string workSheetName, CellsValue[] actualHeaderDatas)
        {
            Excel.Worksheet mySheet = GetWorksheet(workSheetName);  //得到工作表

            return this.GetHeaderDataFromExcel(mySheet, actualHeaderDatas);
        }

        /// <summary> 
        /// Import Excel to Data Table
        /// </summary> 
        /// <remarks>To the start of worksheet</remarks> 
        /// <param name="workSheetIndex"></param> 
        public DataTable GetDataTableFromExcel(int workSheetIndex)
        {
            Excel.Worksheet mySheet = GetWorksheet(workSheetIndex);  //得到工作表

            return this.GetDataTableFromExcelWithoutNull(mySheet);
        }

        /// <summary> 
        /// Import Excel to Data Table
        /// </summary> 
        /// <remarks>To the start of worksheet</remarks> 
        /// <param name="mySheet"></param> 
        public DataTable GetDataTableFromExcel(Excel.Worksheet mySheet)
        {
            DataTable dt = new DataTable();

            for (int j = 1; j <= mySheet.Cells.CurrentRegion.Columns.Count; j++)
            {
                Excel.Range temp = (Excel.Range)mySheet.Cells[1, j];
                string strValue = temp.Text.ToString();

                dt.Columns.Add(strValue);
            }

            for (int i = 2; i <= mySheet.Cells.CurrentRegion.Rows.Count; i++)   //把工作表导入DataTable中
            {
                DataRow myRow = dt.NewRow();

                for (int j = 1; j <= mySheet.Cells.CurrentRegion.Columns.Count; j++)
                {
                    Excel.Range temp = (Excel.Range)mySheet.Cells[i, j];
                    string strValue = temp.Text.ToString();

                    //Just for v1.9
                    string strValue19 = " "; 
                  
                    //Just for v1.9
                    if (1 == j)
                    {
                        //Console.Out.WriteLine("#" + strValue);
                        if (Regex.IsMatch(strValue, @"\d{2}点-\d{2}点"))
                        {
                            if (strValue.Contains("23点-24点"))
                            {
                                strValue19 = strValue;
                                strValue19 = strValue19.Replace("年", "-").Replace("月", "-").Replace("日", "").Replace("23点-24点", "");
                                DateTime time19 = Convert.ToDateTime(strValue19);
                                time19 = time19.AddDays(1);
                                strValue19 = time19.ToString("yyyy年MM月dd日");
                                strValue = strValue19 + "00点";
                            }
                            else
                            {
                                strValue = Regex.Replace(strValue, @"\d{2}点-", "");
                            }
                            
                            //Console.Out.WriteLine(j.ToString() + strValue);
                        }
                        else if (Regex.IsMatch(strValue, @"\d{2}点\d{2}分\-\d{2}点\d{2}分"))
                        {
                            if (strValue.Contains("23点45分-24点00分"))
                            {
                                strValue19 = strValue;
                                strValue19 = strValue19.Replace("年", "-").Replace("月", "-").Replace("日", "").Replace(" 23点45分-24点00分", "");
                                DateTime time19 = Convert.ToDateTime(strValue19);
                                time19 = time19.AddDays(1);
                                strValue19 = time19.ToString("yyyy年MM月dd日");
                                strValue = strValue19 + " 00点00分";
                            }
                            else
                            {
                                strValue = Regex.Replace(strValue, @"\d{2}点\d{2}分\-", "");
                            }                 
                        }
                    }
                    myRow[j - 1] = strValue;
                }
                dt.Rows.Add(myRow);
            }

            return dt;
        }

        /// <summary> 
        /// Import Excel to Data Table
        /// </summary> 
        /// <remarks>To the start of worksheet</remarks> 
        /// <param name="mySheet"></param> 
        public DataTable GetDataTableFromExcelWithoutNull(Excel.Worksheet mySheet)
        {
            DataTable dt = new DataTable();
            int k = 1;

            for (int j = 1; j <= mySheet.Cells.CurrentRegion.Columns.Count; j++)
            {
                Excel.Range temp = (Excel.Range)mySheet.Cells[1, j];
                string strValue = temp.Text.ToString();

                dt.Columns.Add(strValue);
            }

            for (int i = 2; i <= mySheet.Cells.CurrentRegion.Rows.Count; i++)   //把工作表导入DataTable中
            {
                DataRow myRow = dt.NewRow();

                for (int j = 1; j <= mySheet.Cells.CurrentRegion.Columns.Count; j++)
                {
                    Excel.Range temp = (Excel.Range)mySheet.Cells[i, j];

                    string strValue = temp.Text.ToString();

                    if (j > 1 && String.IsNullOrEmpty(strValue.Trim()))
                    {
                        k++;
                    }

                    myRow[j - 1] = strValue;
                }

                if (k < mySheet.Cells.CurrentRegion.Columns.Count)
                {
                    dt.Rows.Add(myRow);
                }

                k = 1;              
            }

            return dt;
        }

        /// <summary> 
        /// Import Excel header data to CellsValue
        /// </summary> 
        /// <remarks>To the start of worksheet</remarks> 
        /// <param name="mySheet"></param> 
        public CellsValue[] GetHeaderDataFromExcel(Excel.Worksheet mySheet, CellsValue[] actualHeaderDatas)
        {
            var hdt = new List<CellsValue>();
            CellsValue tmphdt = new CellsValue();

            foreach (CellsValue actualHeaderData in actualHeaderDatas)
            {
                Excel.Range temp = (Excel.Range)mySheet.Cells[actualHeaderData.cellsIndex.firstRowIndex, actualHeaderData.cellsIndex.firstColumnIndex];
                string strValue = temp.Text.ToString();

                tmphdt.cellsIndex.firstRowIndex = actualHeaderData.cellsIndex.firstRowIndex;
                tmphdt.cellsIndex.firstColumnIndex = actualHeaderData.cellsIndex.firstColumnIndex;
                tmphdt.cellsIndex.lastRowIndex = actualHeaderData.cellsIndex.lastRowIndex;
                tmphdt.cellsIndex.lastColumnIndex = actualHeaderData.cellsIndex.lastColumnIndex;
                tmphdt.cellsValue = strValue;

                hdt.Add(tmphdt);
            }

            return hdt.ToArray();
        }

        #endregion

        #region Import data table to dictionary

        /// <summary> 
        /// Import data table to dictionary
        /// </summary> 
        /// <remarks>To the start of worksheet</remarks> 
        /// <param name="workSheetName"></param> 
        public Dictionary<string, string> GetDictionaryFromDataTable(DataTable table)
        {
            int rows = table.Rows.Count;
            Dictionary<string, string> dict = new Dictionary<string, string>();

            //add data for dictionary
            for (int i = 0; i < rows; i++)
            {
                string key = table.Rows[i][0].ToString();
                string value = table.Rows[i][1].ToString();

                dict.Add(key, value);
            }

            return dict;
        }

        #endregion

        #region Import data table to string

        /// <summary> 
        /// Import data table to dictionary
        /// </summary> 
        /// <remarks>To the start of worksheet</remarks> 
        /// <param name="workSheetName"></param> 
        public string[] GetStringFromDataTable(DataTable table)
        {
            int rows = table.Rows.Count;
            var datas = new List<string>();

            //add data for dictionary
            for (int i = 0; i < rows; i++)
            {
                string value = table.Rows[i][0].ToString();

                datas.Add(value);
            }

            return datas.ToArray();
        }

        #endregion

        #region Import dictionary to data table

        /// <summary> 
        /// Import data table to dictionary
        /// </summary> 
        /// <remarks>To the start of worksheet</remarks> 
        /// <param name="workSheetName"></param> 
        public static DataTable GetDataTableFromDictionary(Dictionary<string, string> dicts)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("KEY");
            dt.Columns.Add("VALUE");

            foreach (KeyValuePair<string, string> dict in dicts)
            {
                DataRow myRow = dt.NewRow();
                myRow["KEY"] = dict.Key;
                myRow["VALUE"] = dict.Value;

                dt.Rows.Add(myRow);
            }

            return dt;
        }

        #endregion

        #region Import string to data table

        /// <summary> 
        /// Import data table to string
        /// </summary> 
        /// <remarks>To the start of worksheet</remarks> 
        /// <param name="workSheetName"></param> 
        public DataTable GetDataTableFromString(string[] strDatas)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("VALUE");

            foreach (string strData in strDatas)
            {
                DataRow myRow = dt.NewRow();
                myRow["VALUE"] = strData;

                dt.Rows.Add(myRow);
            }

            return dt;
        }

        #endregion

        #region Save Excel file

        /// <summary> 
        /// Save Excel 
        /// </summary> 
        public void Save()
        {
            if (this._createNew)
            {
                this.SaveAs(this.filePath);
            }
            else
            {
                this.currentWorkbook.Save();
            }

            //this.SaveAs(this.FileName); 
        }

        /// <summary> 
        /// Save Excel 
        /// </summary> 
        /// <param name="filePath">file absolute path</param> 
        public void SaveAs(string filePath)
        {
            this.currentWorkbook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookNormal, missing, missing, missing,
            missing, Excel.XlSaveAsAccessMode.xlNoChange, missing, missing, missing, missing, missing);
        }

        #endregion 

        #region IDisposable Member
        /// <summary> 
        /// Destroy object
        /// </summary> 
        public void Dispose()
        {

            //this.CurrentWorkbook.Close(true, this.FileName, missing); 
            Marshal.FinalReleaseComObject(this.currentWorkbook);
            this.currentWorkbook = null;

            this.app.Quit();
            Marshal.FinalReleaseComObject(this.app);
            this.app = null;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);  
        public void KillExcelProcess()
        {
            Marshal.FinalReleaseComObject(this.currentWorkbook);
            this.currentWorkbook = null;
            this.app.Quit();

            IntPtr t = new IntPtr(this.app.Hwnd);
            int k = 0;
            GetWindowThreadProcessId(t, out k);
            //Console.Out.Write(k.ToString() + "\n");
            System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
            p.Kill();
            p.Dispose();
        }

        #endregion 

        #region Export data table to excel file
        
        /// <summary>
        /// Export a data table to excel file
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        /// <param name="headers"></param>
        public static void ExportToExcel(DataTable data, string fileName, string sheetName, string[] headers=null)
        {
            if (headers == null || headers.Length <= 0)
            {
                var columns = new List<string>();
                foreach (DataColumn column in data.Columns)
                    columns.Add(column.ColumnName);

                headers = columns.ToArray();
            }

            FileInfo excelFile = new FileInfo(fileName);
            if (!excelFile.Directory.Exists)
                excelFile.Directory.Create();

            //Open excel file which restore scripts data
            ExcelHelper handler = new ExcelHelper(fileName, true);

            handler.OpenOrCreate();

            //Get Worksheet object 
            Microsoft.Office.Interop.Excel.Worksheet sheet = handler.AddWorksheet(sheetName);

            //Import data from the start
            handler.ImportDataTable(sheet, headers, data);

            handler.Save();
            //handler.Dispose();
            handler.KillExcelProcess();
        }

        /// <summary>
        /// Export a data table to excel file with new header sheet
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        /// <param name="headers"></param>
        public static void ExportToExcelWithHeaderSheet(DataTable data, string fileName, string sheetName, CellsValue[] headersSheet2, string[] headersSheet1 = null)
        {
            if ((headersSheet1 == null || headersSheet1.Length <= 0) && (data != null))
            {
                var columns = new List<string>();
                foreach (DataColumn column in data.Columns)
                    columns.Add(column.ColumnName);

                headersSheet1 = columns.ToArray();
            }

            FileInfo excelFile = new FileInfo(fileName);
            if (!excelFile.Directory.Exists)
                excelFile.Directory.Create();

            //Open excel file which restore scripts data
            ExcelHelper handler = new ExcelHelper(fileName, true);

            handler.OpenOrCreate();

            if (data != null)
            {
                //Get Worksheet object 
                Microsoft.Office.Interop.Excel.Worksheet sheet1 = handler.AddWorksheet(sheetName);

                //Import data from the start
                handler.ImportDataTable(sheet1, headersSheet1, data);
            }

            //Get header data
            Microsoft.Office.Interop.Excel.Worksheet sheet2 = handler.AddWorksheet("Header");  
            handler.ExportHeaderToExcelSheet(sheet2, headersSheet2);

            handler.Save();
            //handler.Dispose();
            handler.KillExcelProcess();
        }
        #endregion

        #region Export excel file to data table
        
        /// <summary>
        /// Export a excel to data table
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        public static void ImportToDataTable(string filePath, string sheetName, out DataTable data)
        {
            //Open excel file which restore data view expected data
            ExcelHelper handler = new ExcelHelper(filePath);
            DataTable dataOut = new DataTable();

            handler.OpenOrCreate();

            try
            {
                //Get Worksheet object 
                Excel.Worksheet sheet = handler.GetWorksheet(sheetName);
                //Import data from the start
                dataOut = handler.GetDataTableFromExcel(sheetName);
                data = dataOut.Copy();
            }
            catch (Exception Ex)
            {
                data = null;
            }
            finally
            {
                //handler.Dispose();
                handler.KillExcelProcess();
            }     
        }

        /// <summary>
        /// Export a excel to data table
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        public static DataTable ImportToDataTable(string filePath, int sheetIndex)
        {
            //Open excel file which restore data view expected data
            ExcelHelper handler = new ExcelHelper(filePath);

            handler.OpenOrCreate();

            //Get Worksheet object 
            Excel.Worksheet sheet = handler.GetWorksheet(sheetIndex);

            //Import data from the start
            return handler.GetDataTableFromExcel(sheetIndex);
        }

        /// <summary>
        /// Export a excel Header Data to CellsValue
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        public static CellsValue[] ImportHeaderDataToCellsValue(string filePath, string sheetName, CellsValue[] actualHeaderDatas)
        {
            //Open excel file which restore data view expected data
            ExcelHelper handler = new ExcelHelper(filePath);
            var hdt = new List<CellsValue>();
            var hdtArray = hdt.ToArray();

            handler.OpenOrCreate();

            //Get Worksheet object 
            Excel.Worksheet sheet = handler.GetWorksheet(sheetName);

            //Import data from the start
            hdtArray = handler.GetHeaderDataFromExcel(sheetName, actualHeaderDatas);

            //handler.Dispose();
            handler.KillExcelProcess();
            return hdtArray;
        }

        /// <summary>
        /// Export a generic list to excel, ATTENTION: headers must be property name of the generic type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        /// <param name="headers"></param>
        public static void ExportToExcel<T>(List<T> data, string fileName, string sheetName, string[] headers = null)
        {
            if (headers == null || headers.Length <= 0)
                headers = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(p => p.Name).ToArray();
            
            DataTable table = new DataTable();

            foreach (var column in headers)
                table.Columns.Add(column);

            foreach (T dataItem in data)
            {
                DataRow row = table.NewRow();

                foreach (var column in headers)
                    row[column] = typeof(T).GetProperty(column).GetValue(dataItem, null);

                table.Rows.Add(row);
            }

            ExportToExcel(table, fileName, sheetName, headers);
        }
        #endregion

        #region Export excel to dictionary

        /// <summary>
        /// Export a excel to dictionary
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        public static void ImportToDictionary(string filePath, string sheetName, out Dictionary<string, string> dict)
        {
            //Open excel file which restore data view expected data
            ExcelHelper handler = new ExcelHelper(filePath);
            DataTable dataOut = new DataTable();

            handler.OpenOrCreate();

            //Get Worksheet object 
            Excel.Worksheet sheet = handler.GetWorksheet(sheetName);

            //Import data from the start
            dataOut = handler.GetDataTableFromExcel(sheetName);
            dict = handler.GetDictionaryFromDataTable(dataOut);

            //handler.Dispose();
            handler.KillExcelProcess();
        }

        /// <summary>
        /// Export a excel to dictionary
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        public static Dictionary<string, string> ImportToDictionary(string filePath, int sheetName)
        {
            //Open excel file which restore data view expected data
            ExcelHelper handler = new ExcelHelper(filePath);
            DataTable dataOut = new DataTable();

            handler.OpenOrCreate();

            //Get Worksheet object 
            Excel.Worksheet sheet = handler.GetWorksheet(sheetName);

            //Import data from the start
            dataOut = handler.GetDataTableFromExcel(sheetName);
            return handler.GetDictionaryFromDataTable(dataOut);
        }
   
        #endregion

        #region Export excel to string

        /// <summary>
        /// Export a excel to string
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        public static void ImportToString(string filePath, string sheetName, out string[] datas)
        {
            //Open excel file which restore data view expected data
            ExcelHelper handler = new ExcelHelper(filePath);
            DataTable dataOut = new DataTable();

            handler.OpenOrCreate();

            //Get Worksheet object 
            Excel.Worksheet sheet = handler.GetWorksheet(sheetName);

            //Import data from the start
            dataOut = handler.GetDataTableFromExcel(sheetName);
            datas = handler.GetStringFromDataTable(dataOut);

            //handler.Dispose();
            handler.KillExcelProcess();
        }

        /// <summary>
        /// Export a excel to string
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        public static string[] ImportToString(string filePath, int sheetName)
        {
            //Open excel file which restore data view expected data
            ExcelHelper handler = new ExcelHelper(filePath);
            DataTable dataOut = new DataTable();

            handler.OpenOrCreate();

            //Get Worksheet object 
            Excel.Worksheet sheet = handler.GetWorksheet(sheetName);

            //Import data from the start
            dataOut = handler.GetDataTableFromExcel(sheetName);
            return handler.GetStringFromDataTable(dataOut);
        }

        #endregion

        #region Export dictionary to Excel

        public static void ImportDictionaryToExcel(Dictionary<string, string> dict, string fileName, string sheetName, string[] headers = null)
        {
            DataTable dt = new DataTable();
            dt = GetDataTableFromDictionary(dict);

            //Import data from the start
            ExportToExcel(dt, fileName, sheetName);
        }

        /* Not use
        public static void ImportDictionaryToExcelwithHeaderSheet(Dictionary<string, string> dict, string fileName, string sheetName, string[] headers = null)
        {
            FileInfo excelFile = new FileInfo(fileName);
            if (!excelFile.Directory.Exists)
                excelFile.Directory.Create();

            //Open excel file which restore scripts data
            ExcelHelper handler = new ExcelHelper(fileName, true);

            DataTable dt = new DataTable();
            dt = GetDataTableFromDictionary(dict);

            handler.OpenOrCreate();

            //Get Worksheet object 
            Microsoft.Office.Interop.Excel.Worksheet sheet = handler.AddWorksheet(sheetName);

            //Import data from the start
            handler.ImportDataTable(sheet, headers, dt);

            handler.Save();
            handler.Dispose();
        }
        */

        #endregion

        #region Export string to excel file

        public static void ImportStringToExcel(string[] datas, string fileName, string sheetName, string[] headers = null)
        {
            FileInfo excelFile = new FileInfo(fileName);
            if (!excelFile.Directory.Exists)
                excelFile.Directory.Create();

            //Open excel file which restore scripts data
            ExcelHelper handler = new ExcelHelper(fileName, true);

            DataTable dt = new DataTable();
            dt = handler.GetDataTableFromString(datas);

            handler.OpenOrCreate();

            //Get Worksheet object 
            Microsoft.Office.Interop.Excel.Worksheet sheet = handler.AddWorksheet(sheetName);

            //Import data from the start
            handler.ImportDataTable(sheet, headers, dt);

            handler.Save();
            //handler.Dispose();
            handler.KillExcelProcess();
        }

        #endregion

        #region for failed excel file header

        public struct MergeCellsIndex
        {
            public int firstColumnIndex;
            public int firstRowIndex;
            public int lastColumnIndex;
            public int lastRowIndex;
        }

        public struct CellsValue
        {
            public MergeCellsIndex cellsIndex;
            public string cellsValue;
        }

        #endregion

        #region Import excel to OpenAPI cases

        public static OpenAPICases[] ImportToOpenAPICases(string filePath, string sheetName)
        {
            //Open excel file which restore data view expected data
            string actFilePath = Path.Combine("E:\\OpenAPITest", filePath);
            ExcelHelper handler = new ExcelHelper(actFilePath);

            var oac = new List<OpenAPICases>();
            OpenAPICases tmpoac = new OpenAPICases();

            handler.OpenOrCreate();

            //Get Worksheet object 
            Excel.Worksheet mySheet = handler.GetWorksheet(sheetName);

            for (int i = 2; i <= mySheet.Cells.CurrentRegion.Rows.Count; i++)
            {
                tmpoac = ImportToOpenAPICase(mySheet, i);

                oac.Add(tmpoac);
            }

            return oac.ToArray();
        }

        public static OpenAPICases ImportToOpenAPICase(Excel.Worksheet mySheet, int rowIndex)
        {
            int columnNum = 12;

            OpenAPICases tmpoac = new OpenAPICases();

            Excel.Range temp = (Excel.Range)mySheet.Cells[2, columnNum];
            string strValue = temp.Value.ToString();
            tmpoac.url = strValue;

            temp = (Excel.Range)mySheet.Cells[rowIndex, columnNum + 1];
            strValue = temp.Value.ToString();
            tmpoac.requestBody = strValue;

            /*
             * When use temp.Text.ToString(), just can get at most 8221 chars, so when there more than 8221 chars on cell, use 
             * temp.Value.ToString();
             */
            temp = (Excel.Range)mySheet.Cells[rowIndex, columnNum + 3];
            strValue = temp.Value.ToString();
            tmpoac.expectedResponseBody = strValue;

            //temp = (Excel.Range)mySheet.Cells[rowIndex, columnNum + 4];
            //strValue = temp.Value.ToString();
            //tmpoac.actualResponseBody = strValue;

            //temp = (Excel.Range)mySheet.Cells[rowIndex, columnNum + 5];
            //strValue = temp.Text.ToString();
            //tmpoac.result = strValue;

            //temp = (Excel.Range)mySheet.Cells[rowIndex, columnNum + 6];
            //strValue = temp.Value.ToString();
            //tmpoac.resultReport = strValue;

            return tmpoac;
        }

        #endregion

        #region Import OpenAPI cases to excel

        public static void ImportOpenAPICasesToExcel(OpenAPICases[] datas,string sourceFileName, string resultFileName, string sheetName)
        {
            //Copy to a new file when the file do not exist.  
            DateTime today = new DateTime();
            today = DateTime.Now.ToLocalTime();
            string dashPath = today.ToString("yyyyMMddHH");
            
            string tmpPath= Path.Combine("E:\\OpenAPITest", dashPath);

            string actSourceExcelFileName = Path.Combine("E:\\OpenAPITest", sourceFileName);
            string actResultFileName = Path.Combine(tmpPath, resultFileName);

            FileInfo sourceExcelFile = new FileInfo(actSourceExcelFileName);
            FileInfo resultExcelFile = new FileInfo(actResultFileName);
            
            
            string filePath = Path.Combine(tmpPath, sheetName);           
            int failedRowIndex = 2;

            if (!resultExcelFile.Directory.Exists)
                resultExcelFile.Directory.Create();
            if (!resultExcelFile.Exists)
                sourceExcelFile.CopyTo(actResultFileName);

            //Open excel file which restore scripts data
            ExcelHelper handler = new ExcelHelper(actResultFileName);

            handler.OpenOrCreate();

            //Get Worksheet object 
            Excel.Worksheet mySheet = handler.GetWorksheet(sheetName);

            for (int i = 0; i < datas.Count(); i++)
            {
                ImportOpenAPICaseToExcel(datas[i], mySheet, i + 2);

                if (datas[i].result.Contains("Fail:"))
                {
                    failedRowIndex = i + 2;               

                    string extFilePath = Path.Combine(filePath, failedRowIndex.ToString());

                    string requestFileName = Path.Combine(extFilePath, "RequestBody.txt");
                    string expFileName = Path.Combine(extFilePath, "ExpectResponseBody.txt");
                    string actFileName = Path.Combine(extFilePath, "ActualResponseBody.txt");

                    //将所有的出错case信息放到txt文件里面，方便比较
                    ImportFailedCaseToTXTFiles(requestFileName, datas[i].formatRequestBody);
                    Excel.Range temp = (Excel.Range)mySheet.Cells[failedRowIndex, 17];
                    string strValue = temp.Value.ToString();
                    ImportFailedCaseToTXTFiles(expFileName, strValue);
                    ImportFailedCaseToTXTFiles(actFileName, datas[i].formatActualResponseBody);
                }
            }
          
            mySheet.get_Range("J1", "U1").ColumnWidth = 40 ;
            mySheet.get_Range("O1", "P1").ColumnWidth = 80;
            mySheet.get_Range("A2", "U45").RowHeight = 120;

            handler.Save();
            handler.KillExcelProcess();
        }

        public static void ImportOpenAPICaseToExcel(OpenAPICases data, Excel.Worksheet sheet, int rowIndex)
        {
            int columnIndex = 12;

            sheet.Cells[rowIndex, columnIndex] = data.url;
            sheet.Cells[rowIndex, columnIndex + 1] = data.requestBody;
            sheet.Cells[rowIndex, columnIndex + 2] = data.formatRequestBody;
            sheet.Cells[rowIndex, columnIndex + 3] = data.expectedResponseBody;
            sheet.Cells[rowIndex, columnIndex + 4] = data.actualResponseBody;
            if (!String.IsNullOrEmpty(data.formatExpectedResponseBody))
            {
                sheet.Cells[rowIndex, columnIndex + 5] = data.formatExpectedResponseBody;
            }
            sheet.Cells[rowIndex, columnIndex + 6] = data.formatActualResponseBody;
            sheet.Cells[rowIndex, columnIndex + 7] = data.result;

            if (data.result.Contains("Fail:"))
                sheet.Cells[rowIndex, columnIndex + 7].Interior.ColorIndex = 3;

            sheet.Cells[rowIndex, columnIndex + 8] = data.resultReport;
        }

        public static void ImportFailedCaseToTXTFiles(string actualFileName, string data)
        {
            FileInfo actualFile = new FileInfo(actualFileName);
            if (!actualFile.Directory.Exists)
                actualFile.Directory.Create();

            if (!File.Exists(actualFileName))
            {

                FileStream fs1 = new FileStream(actualFileName, FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(data);//开始写入值

                sw.Close();
                fs1.Close();

            }
            else
            {
                FileStream fs = new FileStream(actualFileName, FileMode.Open, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(data);//开始写入值
                sr.Close();
                fs.Close();
            }
        }

        #endregion

        #region New Jazz -- Compare Excel Files

        //比较全部的数据
        static public Boolean NewJazz_CompareExcelFilesToDataTable(string expectedFilePath, string actualFilePath, string sheetName, out DataTable dtOut)
        {
            ExcelHelper expHandler = new ExcelHelper(expectedFilePath);
            ExcelHelper actHandler = new ExcelHelper(actualFilePath);
            Boolean isEqual = true;
            DataTable dt = new DataTable();

            expHandler.OpenOrCreate();
            actHandler.OpenOrCreate();

            Excel.Worksheet expSheet = expHandler.NewJazzGetWorksheet(sheetName);
            Excel.Worksheet actSheet = actHandler.NewJazzGetWorksheet(sheetName);

            Excel.Range currentCell = (Excel.Range)expSheet.Cells[1, 1];
            bool isMerge = (bool)currentCell.MergeCells;
            int mergeRows = 0;

            if (isMerge)
            {
                Excel.Range MergeArea = currentCell.MergeArea;
                mergeRows = MergeArea.Cells.Count;
            }

            int expRowsCount = expSheet.Cells.CurrentRegion.Rows.Count;
            int expColumnsCount = expSheet.Cells.CurrentRegion.Columns.Count;

            int actRowsCount = actSheet.Cells.CurrentRegion.Rows.Count;
            int actColumnsCount = actSheet.Cells.CurrentRegion.Columns.Count;

            for (int j = 0; j < expSheet.Cells.CurrentRegion.Columns.Count; j++)
            {
                dt.Columns.Add("C" + j.ToString());
            }

            int tempMergeRows = mergeRows;
            string compareMessage;

            if (!isMerge || mergeRows == 0)
                tempMergeRows = 3;

            //把期望文件title的最后一行的值放到list里面，判断是否有几列是相同的，这样可以判断是不是单位指标或者时间能耗比
            string titleContent = ":";
            Boolean UNRatio = false;

            for (int j = 2; j < (expColumnsCount + 1); j++)
            {
                Excel.Range extCella = (Excel.Range)expSheet.Cells[tempMergeRows, j];
                string extValuea = extCella.Text.ToString();
                Excel.Range extCellb = (Excel.Range)expSheet.Cells[tempMergeRows - 1, j];
                string extValueb = extCellb.Text.ToString();

                titleContent = titleContent + extValuea + extValueb;
            }

            if (Regex.Matches(titleContent, @"原始值").Count > 1)
            {              
                UNRatio = true;
            }
                

            //把actual的excel文件按照expected的excel文件的顺序重新生成
            if (!UNRatio)
            {
                NewJazz_AdvancedOrgnizeExcelFile(expSheet, actSheet);
            }
            else
            {
                NewJazz_UNRatio_AdvancedOrgnizeExcelFile(expSheet, actSheet);
            }
                    
            //在两个文件的行列数相等的情况的逐个单元格比较
            if (expRowsCount == actRowsCount && expColumnsCount == actColumnsCount)
            {
                for (int i = 1; i < (expRowsCount + 1); i++)
                {
                    DataRow myRow = dt.NewRow();

                    Excel.Range timeCell = (Excel.Range)expSheet.Cells[i, 1];
                    string timeValue = timeCell.Text.ToString();

                    for (int j = 1; j < (expColumnsCount + 1); j++)
                    {
                        //时间那项不比较一般都是第一列，头3行或者头两行，或者第一行
                        if (i <= mergeRows && j == 1)
                            continue;

                        Excel.Range extCell = (Excel.Range)expSheet.Cells[i, j];
                        string extValue = extCell.Text.ToString();

                        Excel.Range actCell = (Excel.Range)actSheet.Cells[i, j];
                        string actValue = actCell.Text.ToString();

                        //不管数据是否一致，表头都要放到datatable中
                        if (i <= tempMergeRows && extValue == actValue)
                        {
                            myRow[j - 1] = extValue;
                        }
                        else if (extValue != actValue)
                        {
                            myRow[0] = timeValue;
                            compareMessage = "期望值:" + extValue + "\n" + "实际值:" + actValue;
                            myRow[j - 1] = compareMessage;
                            isEqual = false;
                        }
                    }

                    dt.Rows.Add(myRow);
                }
            }

            expHandler.KillExcelProcess();
            actHandler.KillExcelProcess();

            int dtRows = dt.Rows.Count;

            //滤掉空行
            int m = tempMergeRows; 

            while (m < dtRows)
            {
                if (String.IsNullOrEmpty(dt.Rows[m][0].ToString().Trim()))
                {
                    dt.Rows[m]["C0"] = "d";
                }

                m++;
            }

            foreach (DataRow r in dt.Select("C0='d'"))
            {
                r.Delete();
            }


            dt.AcceptChanges();

            dtOut = dt.Copy();

            return isEqual;
        }


        //比较前面部分的数据,
        static public Boolean NewJazz_CompareExcelFilesToDataTableIndexOf(string expectedFilePath, string actualFilePath, string sheetName, int indexOf, out DataTable dtOut)
        {
            ExcelHelper expHandler = new ExcelHelper(expectedFilePath);
            ExcelHelper actHandler = new ExcelHelper(actualFilePath);
            Boolean isEqual = true;
            DataTable dt = new DataTable();

            expHandler.OpenOrCreate();
            actHandler.OpenOrCreate();

            Excel.Worksheet expSheet = expHandler.NewJazzGetWorksheet(sheetName);
            Excel.Worksheet actSheet = actHandler.NewJazzGetWorksheet(sheetName);

            Excel.Range currentCell = (Excel.Range)expSheet.Cells[1, 1];
            bool isMerge = (bool)currentCell.MergeCells;
            int mergeRows = 0;

            if (isMerge)
            {
                Excel.Range MergeArea = currentCell.MergeArea;
                mergeRows = MergeArea.Cells.Count;
            }

            int expRowsCount = expSheet.Cells.CurrentRegion.Rows.Count;
            int expColumnsCount = expSheet.Cells.CurrentRegion.Columns.Count;

            int actRowsCount = actSheet.Cells.CurrentRegion.Rows.Count;
            int actColumnsCount = actSheet.Cells.CurrentRegion.Columns.Count;

            for (int j = 0; j < expSheet.Cells.CurrentRegion.Columns.Count; j++)
            {
                dt.Columns.Add("C" + j.ToString());
            }

            int tempMergeRows = mergeRows;
            string compareMessage;

            if (!isMerge || mergeRows == 0)
                tempMergeRows = 3;

            //把期望文件title的最后一行的值放到list里面，判断是否有几列是相同的，这样可以判断是不是单位指标或者时间能耗比
            string titleContent = ":";
            Boolean UNRatio = false;

            for (int j = 2; j < (expColumnsCount + 1); j++)
            {
                Excel.Range extCella = (Excel.Range)expSheet.Cells[tempMergeRows, j];
                string extValuea = extCella.Text.ToString();
                Excel.Range extCellb = (Excel.Range)expSheet.Cells[tempMergeRows - 1, j];
                string extValueb = extCellb.Text.ToString();

                titleContent = titleContent + extValuea + extValueb;
            }

            if (Regex.Matches(titleContent, @"原始值").Count > 1)
                UNRatio = true;

            //把actual的excel文件按照expected的excel文件的顺序重新生成
            if (!UNRatio)
            {
                NewJazz_AdvancedOrgnizeExcelFile(expSheet, actSheet);
            }
            else
            {
                NewJazz_UNRatio_AdvancedOrgnizeExcelFile(expSheet, actSheet);
            }

            //在两个文件的行列数相等的情况的逐个单元格比较
            //除掉后面的几行，只比较前面的几行
            if (expRowsCount == actRowsCount && expColumnsCount == actColumnsCount)
            {
                for (int i = 1; i < (expRowsCount + 1 - indexOf); i++)
                {
                    DataRow myRow = dt.NewRow();

                    Excel.Range timeCell = (Excel.Range)expSheet.Cells[i, 1];
                    string timeValue = timeCell.Text.ToString();

                    for (int j = 1; j < (expColumnsCount + 1); j++)
                    {
                        //时间那项不比较一般都是第一列，头3行或者头两行，或者第一行
                        if (i <= mergeRows && j == 1)
                            continue;

                        Excel.Range extCell = (Excel.Range)expSheet.Cells[i, j];
                        string extValue = extCell.Text.ToString();

                        Excel.Range actCell = (Excel.Range)actSheet.Cells[i, j];
                        string actValue = actCell.Text.ToString();

                        //不管数据是否一致，表头都要放到datatable中
                        if (i <= tempMergeRows && extValue == actValue)
                        {
                            myRow[j - 1] = extValue;
                        }
                        else if (extValue != actValue)
                        {
                            myRow[0] = timeValue;
                            compareMessage = "期望值:" + extValue + "\n" + "实际值:" + actValue;
                            myRow[j - 1] = compareMessage;
                        }
                    }

                    dt.Rows.Add(myRow);
                }
            }

            expHandler.KillExcelProcess();
            actHandler.KillExcelProcess();

            int dtRows = dt.Rows.Count;

            //滤掉空行
            int m = tempMergeRows;

            while (m < dtRows)
            {
                if (String.IsNullOrEmpty(dt.Rows[m][0].ToString().Trim()))
                {
                    dt.Rows[m]["C0"] = "d";
                }

                m++;
            }

            foreach (DataRow r in dt.Select("C0='d'"))
            {
                r.Delete();
            }


            dt.AcceptChanges();

            dtOut = dt.Copy();

            return isEqual;
        }


        //把actual文件按照expected文件的列标顺序更新，方便比较
        private static void NewJazz_AdvancedOrgnizeExcelFile(Excel.Worksheet expSheet, Excel.Worksheet actSheet)
        {
            DataTable dt = new DataTable();

            Excel.Range currentCell = (Excel.Range)expSheet.Cells[1, 1];
            bool isMerge = (bool)currentCell.MergeCells;
            int mergeRows = 0;

            if (isMerge)
            {
                Excel.Range MergeArea = currentCell.MergeArea;
                mergeRows = MergeArea.Cells.Count;
            }

            int expRowsCount = expSheet.Cells.CurrentRegion.Rows.Count;
            int expColumnsCount = expSheet.Cells.CurrentRegion.Columns.Count;

            int actRowsCount = actSheet.Cells.CurrentRegion.Rows.Count;
            int actColumnsCount = actSheet.Cells.CurrentRegion.Columns.Count;

            int tempMergeRows = mergeRows;

            if (!isMerge || mergeRows == 0)
                tempMergeRows = 3;        

            //获取一个对应关系的映射表，字典
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            //期望文件从第二列开始
            for (int j = 2; j < (expColumnsCount + 1); j++)
            {
                int tmpEuqal = j;

                for (int c = 2; c < (actColumnsCount + 1); c++)
                {
                    Boolean columnEqual = true;

                    //去比较两个excel文件的表头部分，前3行或者前两行
                    for (int k = 1; k < (tempMergeRows + 1); k++)
                    {
                        Excel.Range extCell = (Excel.Range)expSheet.Cells[k, j];
                        string extValue = extCell.Text.ToString();

                        Excel.Range actCell = (Excel.Range)actSheet.Cells[k, c];
                        string actValue = actCell.Text.ToString();

                        if (!String.Equals(extValue, actValue))
                        {
                            columnEqual = false;
                            break;
                        }
                    }

                    if (columnEqual)
                    {
                        tmpEuqal = c;
                        break;
                    }
                }

                dictionary.Add(j, tmpEuqal);
            }

            dt.Columns.Add("1", typeof(string));

            for (int i = 1; i < (expRowsCount + 1); i++)
            {
                DataRow myRow = dt.NewRow();

                Excel.Range actCell = (Excel.Range)actSheet.Cells[i, 1];
                string actValue = actCell.Text.ToString();

                myRow[0] = actValue;
                dt.Rows.Add(myRow);
            }

            //把actual文件按照expected文件的列标顺序更新，方便比较
            for (int j = 2; j < (actColumnsCount + 1); j++)
            {
                dt.Columns.Add(j.ToString(), typeof(string));

                int actColumn = dictionary[j];

                for (int i = 1; i < (actRowsCount + 1); i++)
                {
                    Excel.Range actCell = (Excel.Range)actSheet.Cells[i, actColumn];
                    string actValue = actCell.Text.ToString();

                    dt.Rows[i - 1][j - 1] = actValue;
                }               
            }

            //再把datatable导入到actual excel 文件里面
            for (int i = 0; i < actRowsCount; i++)
            {
                for (int j = 1; j < actColumnsCount; j++)
                {
                    actSheet.Cells[i + 1, j + 1] = dt.Rows[i][j];
                }
            }
        }


        //专为单位指标和时间能耗比， 因为会有一些列的标题是重复的。把actual文件按照expected文件的列标顺序更新，方便比较
        private static void NewJazz_UNRatio_AdvancedOrgnizeExcelFile(Excel.Worksheet expSheet, Excel.Worksheet actSheet)
        {
            DataTable dt = new DataTable();

            Excel.Range currentCell = (Excel.Range)expSheet.Cells[1, 1];
            bool isMerge = (bool)currentCell.MergeCells;
            int mergeRows = 0;

            if (isMerge)
            {
                Excel.Range MergeArea = currentCell.MergeArea;
                mergeRows = MergeArea.Cells.Count;
            }

            int expRowsCount = expSheet.Cells.CurrentRegion.Rows.Count;
            int expColumnsCount = expSheet.Cells.CurrentRegion.Columns.Count;

            int actRowsCount = actSheet.Cells.CurrentRegion.Rows.Count;
            int actColumnsCount = actSheet.Cells.CurrentRegion.Columns.Count;

            int tempMergeRows = mergeRows;

            if (!isMerge || mergeRows == 0)
                tempMergeRows = 3;

            //获取一个对应关系的映射表，字典
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            //期望文件从第二列开始，这里，指针每次都要往后移动两位
            for (int j = 2; j < (expColumnsCount + 1); j++,j++)
            {
                int tmpEuqal = j;

                for (int c = 2; c < (actColumnsCount + 1); c++)
                {
                    Boolean columnEqual = true;

                    //去比较两个excel文件的表头部分，前3行或者前两行
                    for (int k = 1; k < (tempMergeRows + 1); k++)
                    {
                        Excel.Range extCell = (Excel.Range)expSheet.Cells[k, j];
                        string extValue = extCell.Text.ToString();

                        Excel.Range actCell = (Excel.Range)actSheet.Cells[k, c];
                        string actValue = actCell.Text.ToString();

                        if (!String.Equals(extValue, actValue))
                        {
                            columnEqual = false;
                            break;
                        }
                    }

                    if (columnEqual)
                    {
                        tmpEuqal = c;
                        break;
                    }
                }

                dictionary.Add(j, tmpEuqal);
                dictionary.Add(j + 1, tmpEuqal + 1);
            }

            dt.Columns.Add("1", typeof(string));

            for (int i = 1; i < (expRowsCount + 1); i++)
            {
                DataRow myRow = dt.NewRow();

                Excel.Range actCell = (Excel.Range)actSheet.Cells[i, 1];
                string actValue = actCell.Text.ToString();

                myRow[0] = actValue;
                dt.Rows.Add(myRow);
            }

            //把actual文件按照expected文件的列标顺序更新，方便比较
            for (int j = 2; j < (actColumnsCount + 1); j++)
            {
                dt.Columns.Add(j.ToString(), typeof(string));

                int actColumn = dictionary[j];

                for (int i = 1; i < (actRowsCount + 1); i++)
                {
                    Excel.Range actCell = (Excel.Range)actSheet.Cells[i, actColumn];
                    string actValue = actCell.Text.ToString();

                    dt.Rows[i - 1][j - 1] = actValue;
                }
            }

            //再把datatable导入到actual excel 文件里面
            for (int i = 0; i < actRowsCount; i++)
            {
                for (int j = 1; j < actColumnsCount; j++)
                {
                    actSheet.Cells[i + 1, j + 1] = dt.Rows[i][j];
                }
            }
        }

        //将datatable里面的数据导到excel里面
        public static void NewJazz_ExportDataTableToExcel(DataTable data, string fileName, string sheetName)
        {
            FileInfo excelFile = new FileInfo(fileName);
            if (!excelFile.Directory.Exists)
                excelFile.Directory.Create();

            //Open excel file which restore scripts data
            ExcelHelper handler = new ExcelHelper(fileName, true);

            handler.OpenOrCreate();

            //Get Worksheet object 
            Microsoft.Office.Interop.Excel.Worksheet sheet = handler.AddWorksheet(sheetName);

            //Import data from the start
            handler.NewJazz_ImportDataTable(sheet, data);

            handler.Save();
            //handler.Dispose();
            handler.KillExcelProcess();
        }


        private void NewJazz_ImportDataTable(Excel.Worksheet sheet, DataTable table)
        {
            if (table != null)
            {

                int columns = table.Columns.Count;
                int rows = table.Rows.Count;

                //add data for each row
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        sheet.Cells[i + 1, j + 1] = table.Rows[i][j];

                        Excel.Range colorCell = (Excel.Range)sheet.Cells[i + 1, j + 1];
                        string colorValue = colorCell.Text.ToString();

                        if (colorValue.Contains("期望值"))
                            colorCell.Interior.ColorIndex = 27;
                    }
                }

                sheet.get_Range("A1", "M1").ColumnWidth = 30;
            }
        }

        #endregion
    }

    #region For OpenAPI anylaze cases

    public struct OpenAPICases
    {
        public string url;
        public string requestBody;
        public string formatRequestBody;
        public string expectedResponseBody;
        public string actualResponseBody;
        public string formatExpectedResponseBody;
        public string formatActualResponseBody;
        public string result;
        public string resultReport;
    }
    #endregion
}