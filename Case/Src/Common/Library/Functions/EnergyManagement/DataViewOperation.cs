using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Runtime.InteropServices;
using Mento.Utility;
using Mento.Framework.Configuration;

namespace Mento.ScriptCommon.Library.Functions
{
    public class DataViewOperation
    {
        public string sheetNameFailed = "SheetNot";
        public string sheetNameExpected = "SheetExpected";

        #region Import Excel to Data Table

        /// <summary>
        /// Export a excel to data table
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        public DataTable ImportExpectedFileToDataTable(string fileName, string sheetName)
        {
            string filePath = Path.Combine(ExecutionConfig.expectedDataViewExcelFileDirectory, fileName);
            DataTable data = new DataTable();

            ExcelHelper.ImportToDataTable(filePath, sheetName, out data);

            return data;
        }

        /// <summary>
        /// Export a excel to data table
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        public DataTable ImportExpectedFileToDataTable(string fileName, int sheetIndex)
        {
            string filePath = Path.Combine(ExecutionConfig.expectedDataViewExcelFileDirectory, fileName);

            return ExcelHelper.ImportToDataTable(filePath, sheetIndex);
        }
        #endregion

        #region Export Data table to Excel

        /// <summary>
        /// Export expected data table to excel file
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        /// <param name="headers"></param>
        public void MoveExpectedDataViewToExcel(DataTable data, string fileName, string sheetName)
        { 
            string filePath = Path.Combine(ExecutionConfig.expectedDataViewExcelFileDirectory, fileName);

            ExcelHelper.ExportToExcel(data, filePath, sheetName);
        }

        /// <summary>
        /// Export expected data table to excel file with header sheet
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        /// <param name="headers"></param>
        public void MoveExpectedDataViewToExcelWithHeaderSheet(DataTable data, string fileName, string sheetName, ExcelHelper.CellsValue[] headersSheet2)
        {
            string filePath = Path.Combine(ExecutionConfig.expectedDataViewExcelFileDirectory, fileName);

            ExcelHelper.ExportToExcelWithHeaderSheet(data, filePath, sheetName, headersSheet2);
        }

        /// <summary>
        /// Export failed data table to excel file
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        public void ExportFailedDataToExcel(DataTable data, string fileName, string sheetName)
        {
            DateTime today = new DateTime();
            today = DateTime.Now.ToLocalTime();
            string dashPath = today.ToString("yyyyMMddHH");

            string failTimePath = Path.Combine(ExecutionConfig.failedDataViewExcelFileDirectory, dashPath);
            string filePath = Path.Combine(failTimePath, fileName);

            ExcelHelper.ExportToExcel(data, filePath, sheetName);
        }

        /// <summary>
        /// Export failed data table to excel file with new header sheet
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        public void ExportFailedDataToExcelWithHeaderSheet(DataTable data, string fileName, string sheetName, ExcelHelper.CellsValue[] headersSheet2)
        {
            DateTime today = new DateTime();
            today = DateTime.Now.ToLocalTime();
            string dashPath = today.ToString("yyyyMMddHH");

            string failTimePath = Path.Combine(ExecutionConfig.failedDataViewExcelFileDirectory, dashPath);
            string filePath = Path.Combine(failTimePath, fileName);

            ExcelHelper.ExportToExcelWithHeaderSheet(data, filePath, sheetName, headersSheet2);
        }

        #endregion

        #region Compare Data Tables

        /// <summary>
        /// Compare 2 data table, throw exception for the first not equal value
        /// </summary>
        /// <param name="expectedDataTable"></param>
        /// <param name="actualDataTable"></param>
        public bool CompareDataTables(DataTable expectedDataTable, DataTable actualDataTable, string fileName, ExcelHelper.CellsValue[] headersSheet)
        {
            bool areEqual = true;
            DataTable diversityTable = new DataTable();

            DataColumn rows = new DataColumn("行数", typeof(int));

            diversityTable.Columns.Add(rows);

            foreach (DataColumn column in expectedDataTable.Columns)
            {
                diversityTable.Columns.Add(column.ColumnName);
            }

            if (expectedDataTable == null || actualDataTable == null) 
            {
                areEqual = false; 
            }
            
            if (expectedDataTable.Rows.Count != actualDataTable.Rows.Count) 
            {
                areEqual = false;
                throw new Exception(String.Format("The rows count not equal, expected is {0}, actual is {1}", expectedDataTable.Rows.Count, actualDataTable.Rows.Count));   
            }

            for (int i = 0; i < expectedDataTable.Rows.Count; i++) 
            {
                for (int j = 0; j < expectedDataTable.Columns.Count; j++) 
                {
                    if (!String.Equals(expectedDataTable.Rows[i][j].ToString(), actualDataTable.Rows[i][j].ToString()))
                    {
                        areEqual = false;

                        DataRow myRow = diversityTable.NewRow();

                        myRow[0] = i + 2;

                        if ((j != 0) && (expectedDataTable.Columns[0].ColumnName.Contains("时间")))
                        {
                            myRow[1] = expectedDataTable.Rows[i][0].ToString();
                        }

                        if ((j != 0) && (expectedDataTable.Columns[0].ColumnName.Contains("名称")))
                        {
                            myRow[1] = expectedDataTable.Rows[i][0].ToString();
                        }

                        myRow[j + 1] = "期望值:" + expectedDataTable.Rows[i][j].ToString() + "\n" + "实际值:" + actualDataTable.Rows[i][j].ToString();

                        diversityTable.Rows.Add(myRow);
                    } 
                } 
            }

            if (!areEqual)
            {
                ExportFailedDataToExcelWithHeaderSheet(diversityTable, fileName, sheetNameFailed, headersSheet);
            }        

            return areEqual; 
        }

        #endregion

        #region use access enginine and not work and signed as private

        /// <summary>
        /// 导入Excel数据到DataTable
        /// </summary>
        /// <param name="strFileName">文件名称</param>
        /// <param name="isHead">是否包含表头</param>

        /// <param name="iSheet">要导入的sheet</param>
        /// <returns>datatable</returns>
        private DataTable GetDataTableFromExcel(string strFileName, bool isHead, int iSheet)
        {
            if (!strFileName.ToUpper().EndsWith(".XLS"))
            {
                return null;
            }

            DataTable dtReturn = new DataTable();
            string strConnection = string.Empty;
            if (isHead)
            {
                strConnection = "Provider=Microsoft.Ace.OlEDb.12.0;Password=;User ID=;Data Source=" + strFileName + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";  
            }
            else
                strConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\data1.xls;Extended Properties='Excel 12.0;HDR=NO;IMEX=0'";
            OleDbConnection connection = new OleDbConnection(strConnection);
            connection.Open();
            try
            {
                string str = "Select * from [Sheet" + iSheet + "$]";
                OleDbDataAdapter adapter = new OleDbDataAdapter(str, connection);
                adapter.Fill(dtReturn);

            }
            catch (Exception ex)
            {
                dtReturn = null;
            }
            finally
            {
                connection.Close();
            }

            return dtReturn;
        }

        #endregion

        

    }
}