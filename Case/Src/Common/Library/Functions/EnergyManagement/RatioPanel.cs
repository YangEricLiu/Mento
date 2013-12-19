using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;

namespace Mento.ScriptCommon.Library.Functions
{
    public class RatioPanel : EnergyViewPanel
    {
        public string RatioPath = @"RatioPath\";

        #region Controls
        //Select system dimension tree button
        private static Button SelectSystemDimensionButton
        {
            get;
            set;
        }
        private static SystemDimensionTree SystemDimensionTree
        {
            get;
            set;
        }


        //TagGrid
        private static Grid TagGrid
        {
            get;
            set;
        }

        protected override Chart Chart
        {
            get { return JazzChart.EnergyViewChart; }
        }

        protected override Grid EnergyDataGrid
        {
            get { return JazzGrid.EnergyAnalysisEnergyDataList; }
        }
        #endregion

        internal RatioPanel()
        {
            TagGrid = JazzGrid.RatioAllTagList;

            SelectSystemDimensionButton = JazzButton.EnergyViewSelectSystemDimensionButton;
            SystemDimensionTree = JazzTreeView.EnergyViewSystemDimensionTree;
        }

        public void NavigateToRatio()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyRadio);
        }

        # region Hierarchy Tree control

        public Boolean SelectSystemDimensionNode(string[] systemDimensionPath)
        {
            try
            {
                SelectSystemDimensionButton.Click();
                SystemDimensionTree.SelectNode(systemDimensionPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean SwitchSystemDimensionTab()
        {
            try
            {
                JazzButton.RankSystemDimensionTab.Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean SwitchHierarchyTab()
        {
            try
            {
                JazzButton.RankHierarchyTab.Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Tag operations
        
        public void CheckTag(string tagName)
        {
            TagGrid.CheckRowCheckbox(2, tagName);

            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
        }

        public void UncheckTag(string tagName)
        {
            TagGrid.UncheckRowCheckbox(2, tagName);

            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
        }

        public void CheckTags(string[] tagNames)
        {
            foreach (string tagName in tagNames)
            {
                TagGrid.CheckRowCheckbox(2, tagName);
            }
        }

        #endregion

        #region data operation

        /// <summary>
        /// Export expected data table to excel file
        /// </summary>
        /// <param name="displayStep"></param>
        public void ExportExpectedDataTableToExcel(string fileName, DisplayStep displayStep)
        {
            ExportExpectedDataTableToExcel(fileName, displayStep, RatioPath);
        }

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareDataViewRatio(string expectedFileName, string failedFileName)
        {
            return CompareDataViewOfEnergyAnalysis(expectedFileName, failedFileName, RatioPath);
        }

        public bool IsDataViewExisted()
        {
            return EnergyDataGrid.HasDrawnDataView();
        }

        #endregion
    }
}
