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
    public class ChartViewOperation
    {
        public string sheetNameFailed = "SheetNot";
        public string sheetNameExpected = "SheetExpected";

        #region Import Excel to Dictionary

        /// <summary>
        /// Export a excel to Dictionary
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        public Dictionary<string, string> ImportExpectedFileToDictionary(string fileName, string sheetName)
        {
            string filePath = Path.Combine(ExecutionConfig.expectedDataViewExcelFileDirectory, fileName);
            Dictionary<string, string> data = new Dictionary<string, string>();

            ExcelHelper.ImportToDictionary(filePath, sheetName, out data);

            return data;
        }
        #endregion

        #region Export expected dictionary data to Excel

        /// <summary>
        /// Export expected data to Excel
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        /// <param name="headers"></param>
        public void MoveExpectedDataToExcel(Dictionary<string, string> data, string fileName, string sheetName)
        { 
            string filePath = Path.Combine(ExecutionConfig.expectedDataViewExcelFileDirectory, fileName);

            ExcelHelper.ImportDictionaryToExcel(data, filePath, sheetName);
        }

        /// <summary>
        /// Export failed data to excel file
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        public void ExportFailedDataToExcel(Dictionary<string, string> data, string fileName, string sheetName)
        {
            DateTime today = new DateTime();
            today = DateTime.Now.ToLocalTime();
            string dashPath = today.ToString("yyyyMMddHH");

            string failTimePath = Path.Combine(ExecutionConfig.failedDataViewExcelFileDirectory, dashPath);
            string filePath = Path.Combine(failTimePath, fileName);

            ExcelHelper.ImportDictionaryToExcel(data, filePath, sheetName);
        }
        #endregion

        #region Import Excel to string

        /// <summary>
        /// Export a excel to string
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        public string[] ImportExpectedFileToString(string fileName, string sheetName)
        {
            string filePath = Path.Combine(ExecutionConfig.expectedDataViewExcelFileDirectory, fileName);
            string[] data = null;

            ExcelHelper.ImportToString(filePath, sheetName, out data);

            return data;
        }

        #endregion

        #region Export expected string data to Excel

        /// <summary>
        /// Export expected string data to Excel
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        /// <param name="headers"></param>
        public void MoveExpectedDataToExcel(string[] data, string fileName, string sheetName)
        {
            string filePath = Path.Combine(ExecutionConfig.expectedDataViewExcelFileDirectory, fileName);

            ExcelHelper.ImportStringToExcel(data, filePath, sheetName);
        }

        /// <summary>
        /// Export failed string data to excel file
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        public void ExportFailedDataToExcel(string[] data, string fileName, string sheetName)
        {
            DateTime today = new DateTime();
            today = DateTime.Now.ToLocalTime();
            string dashPath = today.ToString("yyyyMMddHH");

            string failTimePath = Path.Combine(ExecutionConfig.failedDataViewExcelFileDirectory, dashPath);
            string filePath = Path.Combine(failTimePath, fileName);

            ExcelHelper.ImportStringToExcel(data, filePath, sheetName);
        }
        #endregion

        #region Compare Dictionary

        /// <summary>
        /// Compare 2 Dictionary, throw exception for the first not equal value
        /// </summary>
        /// <param name="expectedDataTable"></param>
        /// <param name="actualDataTable"></param>
        /// <param name="fileName"></param>
        public bool CompareDictionarys(Dictionary<string, string> expectedDict, Dictionary<string, string> actualDict, string fileName)
        {
            bool areEqual = true;
            Dictionary<string, string> compareDict = new Dictionary<string, string>();

            if (expectedDict == null || actualDict == null) 
            {
                areEqual = false; 
            }

            if (expectedDict.Count != actualDict.Count) 
            {
                areEqual = false;
                throw new Exception(String.Format("The rows count not equal, expected is {0}, actual is {1}", expectedDict.Count, actualDict.Count));   
            }

            foreach (KeyValuePair<string, string> exDict in expectedDict)
            {
                if (!String.Equals(actualDict[exDict.Key], exDict.Value))
                {
                    areEqual = false;
                    string failedKey = exDict.Key;
                    string failedValue = "期望值:" + exDict.Value + "\n" + "实际值:" + actualDict[exDict.Key];

                    compareDict.Add(failedKey, failedValue);
                }               
            }

            if (!areEqual)
            {
                ExportFailedDataToExcel(compareDict, fileName, sheetNameFailed);
            }        

            return areEqual; 
        }

        #endregion

        #region Compare String

        /// <summary>
        /// Compare 2 string , throw exception for the first not equal value
        /// </summary>
        /// <param name="expectedDataTable"></param>
        /// <param name="actualDataTable"></param>
        /// <param name="fileName"></param>
        public bool CompareStrings(string[] expectedStr, string[] actualStr, string fileName)
        {
            bool areEqual = true;
            var compareStr = new List<string>();

            if (expectedStr == null || actualStr == null)
            {
                areEqual = false;
            }

            if (expectedStr.Length != actualStr.Length)
            {
                areEqual = false;
                throw new Exception(String.Format("The rows count not equal, expected is {0}, actual is {1}", expectedStr.Length, actualStr.Length));
            }

            for (int i = 0; i < expectedStr.Length; i++)
            {
                if (!String.Equals(expectedStr[i], actualStr[i]))
                {
                    areEqual = false;
                    string failedValue = "期望值:" + expectedStr[i] + "\n" + "实际值:" + actualStr[i];

                    compareStr.Add(failedValue);
                }
            }

            if (!areEqual)
            {

                ExportFailedDataToExcel(compareStr.ToArray(), fileName, sheetNameFailed);
            }

            return areEqual;
        }

        #endregion
    }
}