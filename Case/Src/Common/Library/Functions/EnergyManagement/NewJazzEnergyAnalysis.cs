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
using Mento.Utility;

namespace Mento.ScriptCommon.Library.Functions
{
    public class NewJazzEnergyAnalysis
    {
        public string extEAPath = ExecutionConfig.expectedDataViewExcelFileDirectory;
        public string actEAPath = ExecutionConfig.actualDataViewExcelFileDirectory;
        public string failedSheetName = "VerificationSheet";
        public string compSheetName = "Sheet1";

        #region Controls

        #endregion

        internal NewJazzEnergyAnalysis()
        {

        }

        #region common

        public void NavigateToEnergyAnalysis()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
        }
       
        #endregion      

        #region data view operation

        public bool NewJazz_CompareExcelFilesOfEnergyAnalysis(string expectedFileName, string actualFileName, string failedFileName)
        {
            bool isCompareEqual = true;

            if (ExecutionConfig.isCompareExpectedDataViewExcelFile)
            {
                string extFilePath = Path.Combine(extEAPath, expectedFileName);
                string actFilePath = Path.Combine(actEAPath, actualFileName);
                DataTable compDt = new DataTable();

                isCompareEqual =ExcelHelper.NewJazz_CompareExcelFilesToDataTable(extFilePath, actFilePath, compSheetName, out compDt);
                NewJazz_ExportFailedDataToExcel(compDt, failedFileName);
            }

            return isCompareEqual;
        }

        private void NewJazz_ExportFailedDataToExcel(DataTable data, string fileName)
        {
            DateTime today = new DateTime();
            today = DateTime.Now.ToLocalTime();
            string dashPath = today.ToString("yyyyMMddHH");

            string failTimePath = Path.Combine(ExecutionConfig.failedDataViewExcelFileDirectory, dashPath);
            string filePath = Path.Combine(failTimePath, fileName);

            ExcelHelper.NewJazz_ExportDataTableToExcel(data, filePath, failedSheetName);
        }

        #endregion
      

        #region private mothod


        #endregion
    }

}
