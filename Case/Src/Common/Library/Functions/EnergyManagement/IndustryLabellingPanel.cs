﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;
using OpenQA.Selenium;
using System.Data;
using Mento.ScriptCommon.TestData.EnergyView;

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

        public void LabellingCaseSetUp()
        {
            NavigateToIndustryLabelling();
            TimeManager.MediumPause();
        }

        public void LabellingCaseTearDown()
        {
            JazzFunction.LoginPage.RefreshJazz("NancyCustomer1");
            TimeManager.LongPause();
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
        }

        public bool IsTagChecked(string tagName)
        {
            return TagGrid.IsRowChecked(2, tagName);
        }

        public void UncheckTag(string tagName)
        {
            TagGrid.UncheckRowCheckbox(2, tagName);
        }

        public void CheckTags(string[] tagNames)
        {
            foreach (string tagName in tagNames)
            {
                TagGrid.CheckRowCheckbox(2, tagName);              
            }

            TimeManager.MediumPause();
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

        public string[] GetAllLabellingTooltips(string labellingInfo)
        { 
            var allTooltips = new List<string>();
            int tooltipsNum = GetLabellingNumber();

            for (int i = 0; i < tooltipsNum; i++)
            {
                allTooltips.Add(GetLabellingTooltip(i));
            }

            allTooltips.Add(labellingInfo);

            return allTooltips.ToArray();
        }

        public string[] GetAllLabellingTooltips()
        {
            var allTooltips = new List<string>();
            int tooltipsNum = GetLabellingNumber();

            for (int i = 0; i < tooltipsNum; i++)
            {
                allTooltips.Add(GetLabellingTooltip(i));
            }

            return allTooltips.ToArray();
        }

        #endregion

        #region compare labelling tooltips value

        /// <summary>
        /// Get Single Labelling Info
        /// </summary>
        /// <param name="hierarchyPath"></param>
        public string GetSingleLabellingInfo(string[] hierarchyPath, YearAndMonth Time, string IndustryType, string UnitType)
        {
            string labellingInfo = hierarchyPath[0];
            if (String.IsNullOrEmpty(UnitType))
            {
                UnitType = "单位人口";
            }

            if (String.IsNullOrEmpty(IndustryType))
            {
                IndustryType = JazzFunction.EnergyViewToolbar.GetLabellingIndustryButtonText();
            }

            for (int i = 1; i < hierarchyPath.Length; i++)
            {
                labellingInfo = labellingInfo + "/" + hierarchyPath[i];
            }

            labellingInfo = "\n" + labellingInfo + "\n" + Time.year.ToString() + "-" + Time.month.ToString() + "\n" + IndustryType + "\n" + UnitType;
            
            return labellingInfo;
        }

        /// <summary>
        /// Get Single Labelling Info
        /// </summary>
        /// <param name="hierarchyPath"></param>
        public string GetMultiLabellingInfo(MultipleHierarchyAndtags[] multipleHierarchyAndtags, YearAndMonth Time, string IndustryType, string UnitType)
        {
            string labellingInfo = multipleHierarchyAndtags[0].HierarchyPath[0];

            if (String.IsNullOrEmpty(UnitType))
            {
                UnitType = "单位人口";
            }

            if (String.IsNullOrEmpty(IndustryType))
            {
                IndustryType = JazzFunction.EnergyViewToolbar.GetLabellingIndustryButtonText();
            }

            for (int j = 0; j < multipleHierarchyAndtags.Length; j++)
            {
                for (int i = 1; i < multipleHierarchyAndtags[j].HierarchyPath.Length; i++)
                {
                    labellingInfo = labellingInfo + "/" + multipleHierarchyAndtags[j].HierarchyPath[i];
                }

                labellingInfo = " : " + multipleHierarchyAndtags[j].TagsName[0];

                for (int k = 1; k < multipleHierarchyAndtags[j].TagsName.Length; k++)
                {
                    labellingInfo = labellingInfo + "," + multipleHierarchyAndtags[j].TagsName[k];
                }

                labellingInfo = labellingInfo + "\n";
            }
                           
            labellingInfo = labellingInfo + "\n" + Time.year.ToString() + "-" + Time.month.ToString() + "\n" + IndustryType + "\n" + UnitType;

            return labellingInfo;
        }

        /// <summary>
        /// Export expected string data to excel file
        /// </summary>
        /// <param name="displayStep"></param>
        public void ExportExpectedStringToExcel(string fileName, string labellingInfo)
        {
            ExportExpectedStringToExcel(GetAllLabellingTooltips(labellingInfo), fileName, IndustryLabellingPath);
        }

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// /// <param name="failedFileName"></param>
        public bool CompareStringsOfEnergyAnalysis(string expectedFileName, string failedFileName)
        {
            return CompareStringDataOfEnergyAnalysis(GetAllLabellingTooltips(), expectedFileName, failedFileName, IndustryLabellingPath);
        }

        #endregion

    }
}
