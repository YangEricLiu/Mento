using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Runtime.InteropServices;
using Mento.Utility;

namespace Mento.ScriptCommon.Library.Functions
{
    public class DataViewOperation
    {
        #region Import Excel to Data Table

        /// <summary>
        /// Export a excel to data table
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        public DataTable ImportToDataTable(string filePath, string sheetName)
        {
            return ExcelHelper.ImportToDataTable(filePath, sheetName);
        }

        /// <summary>
        /// Export a excel to data table
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        public DataTable ImportToDataTable(string filePath, int sheetIndex)
        {
            return ExcelHelper.ImportToDataTable(filePath, sheetIndex);
        }

        #endregion

        #region Export Data table to Excel

        /// <summary>
        /// Export a data table to excel file
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        /// <param name="headers"></param>
        public void ExportDataTableToExcel(DataTable data, string filePath, string sheetName, string[] headers = null)
        {
            ExcelHelper.ExportToExcel(data, filePath, sheetName);
        }

        #endregion

        #region Compare Data Tables

        /// <summary>
        /// Compare 2 data table, throw exception for the first not equal value
        /// </summary>
        /// <param name="expectedDataTable"></param>
        /// <param name="actualDataTable"></param>
        public bool CompareDataTables(DataTable expectedDataTable, DataTable actualDataTable)
        {
            string formatString = "The value on row {0} column {1} not equal, expected is {2}, actual is {3}";

            if (expectedDataTable == null || actualDataTable == null) 
            { 
                return false; 
            }

            if (expectedDataTable.Rows.Count != actualDataTable.Rows.Count) 
            { 
                return false; 
            }

            if (expectedDataTable.Columns.Count != actualDataTable.Columns.Count) 
            { 
                return false; 
            }

            for (int i = 0; i < expectedDataTable.Rows.Count; i++) 
            {
                for (int j = 0; j < expectedDataTable.Columns.Count; j++) 
                {
                    if (expectedDataTable.Rows[i][j].ToString() != actualDataTable.Rows[i][j].ToString())
                    {
                        throw new Exception(String.Format(formatString, i, j, expectedDataTable.Rows[i][j].ToString(), actualDataTable.Rows[i][j]).ToString());
                        //return false; 
                    } 
                } 
            } 

            return true; 
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