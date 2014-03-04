using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;
using OpenQA.Selenium;
using System.Data;

namespace Mento.ScriptCommon.Library.Functions
{
    public class IndustryLabellingPanel : EnergyViewPanel
    {
        public string IndustryLabellingPath = @"IndustryLabelling\";

        #region Controls

        private static ComboBox LabelingYearComboBox = JazzComboBox.LabelingYearComboBox;
        private static ComboBox LabelingMonthComboBox = JazzComboBox.LabelingMonthComboBox;

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

        //Select area dimension tree button
        private static Button SelectAreaDimensionButton
        {
            get;
            set;
        }
        private static AreaDimensionTree AreaDimensionTree
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
            get { return JazzChart.IndustryLabellingChart; }
        }

        //DataGrid
        protected override Grid EnergyDataGrid
        {
            get { return JazzGrid.UnitKPIEnergyDataListGrid; }
        }

        #endregion

        internal IndustryLabellingPanel()
        {
            TagGrid = JazzGrid.LabellingAllTagListGrid;

            SelectSystemDimensionButton = JazzButton.EnergyViewSelectSystemDimensionButton;
            SelectAreaDimensionButton = JazzButton.EnergyViewSelectAreaDimensionButton;

            SystemDimensionTree = JazzTreeView.EnergyViewSystemDimensionTree;
            AreaDimensionTree = JazzTreeView.EnergyViewAreaDimensionTree;
        }

        #region Labelling common function

        public void NavigateToIndustryLabelling()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.Labeling);
        }

        #endregion

        #region Tag operations

        public void SwitchTagTab(TagTabs tab)
        {
            switch (tab)
            {
                case TagTabs.SystemDimensionTab:
                    //click system tab
                    JazzButton.EnergyViewSystemDimensionTagsTab.Click();
                    TagGrid = JazzGrid.EnergyAnalysisSystemDimensionTagList;
                    break;
                case TagTabs.AreaDimensionTab:
                    //click area tab
                    JazzButton.EnergyViewAreaDimensionTagsTab.Click();
                    TagGrid = JazzGrid.EnergyAnalysisAreaDimensionTagList;
                    break;
                case TagTabs.HierarchyTag:
                    //click all tab
                    JazzButton.EnergyViewALLTagsTab.Click();
                    TagGrid = JazzGrid.EnergyAnalysisAllTagList;
                    break;
                default:
                    //click all tab
                    JazzButton.EnergyViewALLTagsTab.Click();
                    TagGrid = JazzGrid.EnergyAnalysisAllTagList;
                    break;
            }
        }

        public void SelectSystemDimension(string[] systemDimensionPath)
        {
            SelectSystemDimensionButton.Click();

            SystemDimensionTree.SelectNode(systemDimensionPath);
        }

        public void SelectAreaDimension(string[] areaDimensionPath)
        {
            SelectAreaDimensionButton.Click();

            AreaDimensionTree.SelectNode(areaDimensionPath);
        }

        public void CheckTag(string tagName)
        {
            TagGrid.CheckRowCheckbox(2, tagName);

            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
        }

        public bool IsTagChecked(string tagName)
        {
            return TagGrid.IsRowChecked(2, tagName);
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

        public bool IsAllTagsDisabled()
        {
            return TagGrid.IsNoEnabledCheckbox();
        }
        #endregion

        #region energy view

        public void SetYearAndMonth(string year, string month)
        {
            LabelingYearComboBox.SelectItem(year);
            LabelingMonthComboBox.SelectItem(month);
        }

        public void SetYear(string year)
        {
            LabelingYearComboBox.SelectItem(year);
        }

        public void SetMonth(string month)
        {
            LabelingMonthComboBox.SelectItem(month);
        }

        #endregion

        #region labelling chart

        public bool IsLabellingChartDrawn()
        {
            return Chart.HasLabellingChartDrawn();
        }

        public bool EntirelyNoLabellingChartDrawn()
        {
            return Chart.EntirelyNoLabellingChartDrawn();
        }

        public int GetLabellingNumber()
        {
            return Chart.GetLabellingNumber();
        }

        public string GetLabellingTooltip(int position)
        {
            return Chart.GetLabellingTooltip(position);
        }

        #endregion

    }
}
