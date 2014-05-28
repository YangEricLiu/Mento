using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Data;

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
            int columns = table.Columns.Count;
            int rows = table.Rows.Count;

            int titleRowIndex = rowNumber;
            int headerRowIndex = rowNumber;
            Excel.Range titleRange = null;
            decimal tmp;

            if (showTitle)
            {
                headerRowIndex++;
                //add title and set format 
                titleRange = this.GetRange(sheet, rowNumber, columnNumber, rowNumber, columnNumber + columns - 1);
                titleRange.Merge(missing);

                this.SetRangeFormat(titleRange, 16, Excel.Constants.xlAutomatic, Excel.Constants.xlColor1, Excel.Constants.xlCenter);
                titleRange.Value2 = headerTitle;
            }

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
        /// Import Excel to Data Table
        /// </summary> 
        /// <remarks>To the start of worksheet</remarks> 
        /// <param name="workSheetIndex"></param> 
        public DataTable GetDataTableFromExcel(int workSheetIndex)
        {
            Excel.Worksheet mySheet = GetWorksheet(workSheetIndex);  //得到工作表

            return this.GetDataTableFromExcel(mySheet);
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
                    myRow[j - 1] = strValue;
                }
                dt.Rows.Add(myRow);
            }

            return dt;
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

        #region Import dictionary to data table

        /// <summary> 
        /// Import data table to dictionary
        /// </summary> 
        /// <remarks>To the start of worksheet</remarks> 
        /// <param name="workSheetName"></param> 
        public DataTable GetDataTableFromDictionary(Dictionary<string, string> dicts)
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
            handler.Dispose();
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
            if (headersSheet1 == null || headersSheet1.Length <= 0)
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

            //Get Worksheet object 
            Microsoft.Office.Interop.Excel.Worksheet sheet1 = handler.AddWorksheet(sheetName);
            Microsoft.Office.Interop.Excel.Worksheet sheet2 = handler.AddWorksheet("Header");

            //Import data from the start
            handler.ImportDataTable(sheet1, headersSheet1, data);
            handler.ExportHeaderToExcelSheet(sheet2, headersSheet2);

            handler.Save();
            handler.Dispose();
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

            //Get Worksheet object 
            Excel.Worksheet sheet = handler.GetWorksheet(sheetName);

            //Import data from the start
            dataOut = handler.GetDataTableFromExcel(sheetName);
            data = dataOut.Copy();

            handler.Dispose();
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

            handler.Dispose();
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
            Dictionary<string, string> dict = new Dictionary<string, string>();
            DataTable dataOut = new DataTable();

            handler.OpenOrCreate();

            //Get Worksheet object 
            Excel.Worksheet sheet = handler.GetWorksheet(sheetName);

            //Import data from the start
            dataOut = handler.GetDataTableFromExcel(sheetName);
            return handler.GetDictionaryFromDataTable(dataOut);
        }

        #endregion

        #region Export dictionary to Excel

        public static void ImportDictionaryToExcel(Dictionary<string, string> dict, string fileName, string sheetName, string[] headers = null)
        {
            FileInfo excelFile = new FileInfo(fileName);
            if (!excelFile.Directory.Exists)
                excelFile.Directory.Create();

            //Open excel file which restore scripts data
            ExcelHelper handler = new ExcelHelper(fileName, true);

            DataTable dt = new DataTable();
            dt = handler.GetDataTableFromDictionary(dict);

            handler.OpenOrCreate();

            //Get Worksheet object 
            Microsoft.Office.Interop.Excel.Worksheet sheet = handler.AddWorksheet(sheetName);

            //Import data from the start
            handler.ImportDataTable(sheet, headers, dt);

            handler.Save();
            handler.Dispose();
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
    }
}