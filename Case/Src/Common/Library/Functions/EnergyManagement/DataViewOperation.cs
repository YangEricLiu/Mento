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
        /// Compare 2 data table headers, export to another data table for any different
        /// </summary>
        /// <param name="expectedDataTable"></param>
        /// <param name="actualDataTable"></param>
        /// /// <param name="diversityTable"></param>
        public bool CompareTableColumnName(DataTable expectedDataTable, DataTable actualDataTable, out DataTable diversityTable)
        {
            bool areEqual = true;

            int com = 1;

            DataTable diversityTableTemp = new DataTable();
            DataColumn rows = new DataColumn("行数", typeof(int));
            DataColumn expectedValue = new DataColumn("期望值", typeof(string));
            DataColumn actualValue = new DataColumn("实际值", typeof(string));

            diversityTableTemp.Columns.Add(rows);
            diversityTableTemp.Columns.Add(expectedValue);
            diversityTableTemp.Columns.Add(actualValue);

            for (int i = 0; i < expectedDataTable.Columns.Count; i++)
            {
                if (!String.Equals(expectedDataTable.Columns[i].ColumnName, actualDataTable.Columns[i].ColumnName))
                {
                    areEqual = false;

                    DataRow myRow = diversityTableTemp.NewRow();

                    myRow[0] = com;
                    myRow[1] = expectedDataTable.Columns[i].ColumnName;
                    myRow[2] = actualDataTable.Columns[i].ColumnName;

                    diversityTableTemp.Rows.Add(myRow);
                }
            }

            diversityTable = diversityTableTemp.Copy();

            return areEqual;
            
        }

        /// <summary>
        /// Compare 2 data table, throw exception for the first not equal value
        /// </summary>
        /// <param name="expectedDataTable"></param>
        /// <param name="actualDataTable"></param>
        public bool CompareDataTables(DataTable expectedDataTable, DataTable actualDataTable)
        {
            bool areEqual = true;
            //string formatString = "The value on row {0} column {1} not equal, expected is {2}, actual is {3}";
            DataTable diversityTable = new DataTable();
            DataColumn rows = new DataColumn("行数", typeof(int));
            DataColumn expectedValue = new DataColumn("期望值", typeof(string));
            DataColumn actualValue = new DataColumn("实际值", typeof(string));

            diversityTable.Columns.Add(rows);
            diversityTable.Columns.Add(expectedValue);
            diversityTable.Columns.Add(actualValue);

            if (expectedDataTable == null || actualDataTable == null) 
            {
                areEqual = false; 
            }

            
            if (expectedDataTable.Rows.Count != actualDataTable.Rows.Count) 
            {
                areEqual = false;
                throw new Exception(String.Format("The rows count not equal, expected is {0}, actual is {1}", expectedDataTable.Rows.Count, actualDataTable.Rows.Count));   
            }

            if (expectedDataTable.Columns.Count != actualDataTable.Columns.Count) 
            {
                areEqual = false;
                throw new Exception(String.Format("The columns count not equal, expected is {0}, actual is {1}", expectedDataTable.Columns.Count, actualDataTable.Columns.Count)); 
            }

            if (!CompareTableColumnName(expectedDataTable, actualDataTable, out diversityTable))
            {
                areEqual = false;
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
                        myRow[1] = expectedDataTable.Rows[i][j].ToString();
                        myRow[2] = actualDataTable.Rows[i][j].ToString();

                        diversityTable.Rows.Add(myRow);
                    } 
                } 
            }

            if (!areEqual)
            {
                ExportDataTableToExcel(diversityTable, "D:\\dataOut1.xls", "SheetNot");
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