using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;

namespace Mento.ScriptCommon.Library.Functions
{
    public class RankPanel : EnergyViewPanel
    {
        public string RankingPath = @"ConsumptionRanking\";
        #region Controls

        private static Button ConfirmHiearchyRank = JazzButton.ConfirmHierarchyRankButton;
        private static Button ClearHiearchyRank = JazzButton.ClearHierarchyRankButton;

        private static MenuButton CountSelectRank = JazzButton.CountSelectorRankingButton;

        private static Grid CommodityRank = JazzGrid.CommodityRankGrid;
        //private static Grid CommodityRankCarbon = JazzGrid.CommodityRankCarbonGrid;
        //private static Grid CommodityRankCost = JazzGrid.CommodityRankCostGrid;
        private static Button CommodityRankTen = JazzButton.CountSelectorRankingButtonTen;
        private static Grid SystemCommodityRank = JazzGrid.SystemCommodityRankCostGrid;

        //Select rank tree
        private static Button SelectHierarchyButton
        {
            get;
            set;
        }
        private static HierarchyTree HierarchyTree
        {
            get;
            set;
        }

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

        public void NavigateToCorporateRanking()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.Rank);
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

        internal RankPanel()
        {
            TagGrid = JazzGrid.EnergyAnalysisAllTagList;

            SelectHierarchyButton = JazzButton.RankSelectHierarchyButton;
            HierarchyTree = JazzTreeView.RankHierarchyTree;

            SelectSystemDimensionButton = JazzButton.RankSelectSystemDimensionButton;
            SystemDimensionTree = JazzTreeView.EnergyViewSystemDimensionTree;
        }

        #region Hierarchy operations

        public Boolean CheckHierarchyNode(string[] hierarchyNames)
        {
            try
            {
                SelectHierarchyButton.Click();
                TimeManager.LongPause();
                HierarchyTree.ExpandNodePath(hierarchyNames);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.MediumPause();
                HierarchyTree.CheckNode(hierarchyNames.Last());
                TimeManager.ShortPause();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void OnlyCheckHierarchyNode(string[] hierarchyNames)
        {
            HierarchyTree.ExpandNodePath(hierarchyNames);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            HierarchyTree.CheckNode(hierarchyNames.Last());
            TimeManager.ShortPause();
        }

        public Boolean UnCheckHierarchyNode(string[] hierarchyNames)
        {
            try
            {
                SelectHierarchyButton.Click();
                //if(JazzCheckBox.UserDataAllHierarchyNodeCheckBoxField.IsChecked())
                TimeManager.LongPause();
                HierarchyTree.ExpandNodePath(hierarchyNames);
                HierarchyTree.CheckNode(hierarchyNames.Last());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean OnlyUnCheckHierarchyNode(string[] hierarchyNames)
        {
            try
            {
                //if(JazzCheckBox.UserDataAllHierarchyNodeCheckBoxField.IsChecked())
                TimeManager.LongPause();
                HierarchyTree.ExpandNodePath(hierarchyNames);
                HierarchyTree.UncheckNode(hierarchyNames.Last());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

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

        public Boolean ClickSelectSystemDimensionButton()
        {
            try
            {
                SelectSystemDimensionButton.Click();
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

        public void ClickConfirmHiearchyButton()
        {
            ConfirmHiearchyRank.Click();
        }

        public void ClickTenRankButton()
        {
            CommodityRankTen.Click();
        }

        public void ClickClearHiearchyButton()
        {
            ClearHiearchyRank.Click();
        }

        public void SelectCommodity(string commodityName)
        {
            CommodityRank.CheckRowCheckbox(2, commodityName, false);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
        }

        public void SelectSystemCommodity(string commodityName)
        {
            SystemCommodityRank.CheckRowCheckbox(2, commodityName, false);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
        }
        /*
        public void SelectCommodityCarbon(string commodityName)
        {
            CommodityRank.CheckRowCheckbox(2, commodityName, false);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
        }

        public void SelectCommodityCost(string commodityName)
        {
            CommodityRankCost.CheckRowCheckbox(2, commodityName, false);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
        }
        */
        #endregion


        #region ranking panel

        public Boolean IsHierarchyNodeChecked(string hierarchyNode)
        {
            return HierarchyTree.IsNodeChecked(hierarchyNode);
        }


        public Boolean IsCommoditySelected(string commodityName)
        {
            return CommodityRank.IsRankingCommodityRowChecked(2, commodityName);
        }

        public Boolean IsSystemCommoditySelected(string commodityName)
        {
            return SystemCommodityRank.IsRankingCommodityRowChecked(2, commodityName);
        }

        public Boolean IsCommodityChecked(string commodityName)
        {
            return CommodityRank.IsRankingCommodityRowChecked(2, commodityName);
        }

        public Boolean IsCommodityExist(string commodityName)
        {
            return CommodityRank.IsRowExist(2,commodityName);
        }

        public void ClickSelectHierarchyButton()
        {
            SelectHierarchyButton.Click();
        }

        public Boolean IsNodeDisabled(string systemHierarchyNode)
        {
            return SystemDimensionTree.IsNodeDisabled(systemHierarchyNode);
        }

        public Boolean AreCommoditiesOnTheGrid(string[] commodityNames)
        {
            int i = 0;
            while(i<commodityNames.Length)
            {
                if(!(CommodityRank.IsRowExist(2, commodityNames[i])))
                {
                     return false;
                }
                i++;
            }
            return true;
        }

        public Boolean IsCommodityOnRankingPanel(string commodityName)
        {
            if (!(CommodityRank.IsRowExist(2, commodityName)))
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Export expected data table to excel file
        /// </summary>
        /// <param name="displayStep"></param>
        public void ExportRankingExpectedDataTableToExcel(string fileName)
        {
            //ExportExpectedDataTableToExcel(fileName, displayStep, RankingPath);
            ExportRankingExpectedDataTableToExcel(fileName, RankingPath);
        }

        /// <summary>
        /// Judge if there is data in data view
        /// </summary>
        public bool IsNoDataInEnergyGrid()
        {
            return EnergyDataGrid.IsNoRowOnGrid();
        }

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareDataViewOfCostUsage(string expectedFileName, string failedFileName)
        {
            return CompareDataViewOfEnergyAnalysis(expectedFileName, failedFileName, RankingPath);
        }

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareDataViewOfCarbonUsage(string expectedFileName, string failedFileName)
        {
            return CompareDataViewOfEnergyAnalysis(expectedFileName, failedFileName, RankingPath);
        }

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareDataViewOfEnergyAnalysis(string expectedFileName, string failedFileName)
        {
            return CompareDataViewOfEnergyAnalysis(expectedFileName, failedFileName, RankingPath);
        }

        /*
         /// <summary>
        /// Select Count Rank ,such as 10,20,50
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public void SelectCountRank(string countNum)
        {
            //CountSelectRank.RootElement.FindElement();
        }
        */


        /// <summary>
        /// Check whether the clear hierarchy button is enabled
        /// </summary>
        public Boolean IsClearHiearchyButtonEnabled()
        {
            return ClearHiearchyRank.IsEnabled();
        }

        /*
        /// <summary>
        /// Check whether the customer hiearchy node can be checked.
        /// </summary>
        public Boolean IsCustomerCheckEnabled(string[] HierarchyNode)
        {

            
            return true;
           
        }
        */
        #endregion

    }
}
