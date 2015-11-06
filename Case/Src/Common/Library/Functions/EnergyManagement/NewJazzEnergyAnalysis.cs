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

        //Add new widget button
        private static Button NewWidget = JazzButton.NewWidgetButton;
        private static Button NewJazzHierarchyFoldingButton = JazzButton.EnergyViewHierarchyFoldingButton;

        //Select hierarchy button
        private static Button NewJazzSelectHierarchyButton = JazzButton.EnergyViewSelectHierarchyButton;
        private static HierarchyTree NewJazzHierarchyTree = JazzTreeView.NewJazzEnergyViewHierarchyTree;
        private static Grid NewJazzTaglistGrid = JazzGrid.NewJazzTaglistGrid;

        private static Dictionary<WidgetType, string> WidgetTypeItem = new Dictionary<WidgetType, string>()
        {
            {WidgetType.EnergyAnalysis, "能耗分析"},
            {WidgetType.UnitIndicator, "单位指标"},
            {WidgetType.Radio, "时段能耗比"},
            {WidgetType.Labeling, "能效标识"},
            {WidgetType.Ranking, "集团排名"},
        };

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
    
        #region tag operation

        public void NewJazz_CheckTags(string[] tagNames)
        {
            foreach (var tagName in tagNames)
            {
                NewJazzTaglistGrid.NewJazzCheckRowCheckbox(tagName);

                TimeManager.MediumPause();
            }
        }

        /// <summary>
        /// Check one tag on left region
        /// </summary>
        /// <param name="tagName"></param>
        public void NewJazz_CheckTag(string tagName)
        {
            NewJazzTaglistGrid.NewJazzCheckRowCheckbox(tagName);
            TimeManager.ShortPause();
        }

        /// <summary>
        /// Uncheck the tags on left region
        /// </summary>
        /// <param name="tagNames"></param>
        public void NewJazz_UncheckTags(string[] tagNames)
        {
            foreach (var tagName in tagNames)
            {
                NewJazzTaglistGrid.NewJazzUncheckRowCheckbox(tagName);

                TimeManager.MediumPause();
            }
        }

        /// <summary>
        /// Uncheck the tag on left region
        /// </summary>
        /// <param name="tagName"></param>
        public void NewJazz_UncheckTag(string tagName)
        {
            NewJazzTaglistGrid.NewJazzUncheckRowCheckbox(tagName);
            TimeManager.ShortPause();
        }

        #endregion

        #region data operation

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

        #region pre-operation

        public void ClickNewWidgetTypeButton(WidgetType type)
        {
            NewWidget.Click();
            TimeManager.ShortPause();

            Button EnergyAnalysisButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonWidgetTypeWindow, WidgetTypeItem[type]);
            EnergyAnalysisButton.Click();
        }

        public void NewJazz_SelectHierarchy(string[] hierarchyNames)
        {
            NewJazzHierarchyFoldingButton.Click();
            TimeManager.MediumPause();

            if (!NewJazzSelectHierarchyButton.IsExisted())
            {
                NewJazzHierarchyFoldingButton.Click();
                TimeManager.MediumPause();
            }

            NewJazzSelectHierarchyButton.Click();
            TimeManager.MediumPause();

            NewJazzHierarchyTree.NewJazzSelectNode(hierarchyNames);
        }

        
        #endregion


        #region private mothod


        #endregion
    }

}
