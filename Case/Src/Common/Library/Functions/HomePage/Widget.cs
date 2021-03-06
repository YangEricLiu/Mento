﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Administration;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.Library;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.EnergyView;
using System.Data;
using System.IO;
using Mento.Framework.Configuration;
using OpenQA.Selenium;

namespace Mento.ScriptCommon.Library.Functions
{
    public class Widget : EnergyViewPanel
    {
        internal Widget()
        {
        } 

        #region controls
        
        private static Button DashboardHierarchyNameButton = JazzButton.DashboardHierarchyNameButton;
        private static Button ModifyWidgetNameSaveButton = JazzButton.ModifyWidgetNameSaveButton;
        private static Button ModifyWidgetNameCancelButton = JazzButton.ModifyWidgetNameCancelButton;
        private static Button DeleteWidgetCancelButton = JazzButton.DeleteWidgetCancelButton;
        private static Button DeleteWidgetConfirmButton = JazzButton.DeleteWidgetConfirmButton;
     
        private static TextField ModifyWidgetNameTextField = JazzTextField.TextFieldModifyWidgetName;

        private static ComboBox WidgetMaxDialogDefaultTime = JazzComboBox.WidgetMaxDialogDefaultTimeComboBox;
        private static ComboBox WidgetMaxDialogStartTime = JazzComboBox.WidgetMaxDialogStartTimeComboBox;
        private static ComboBox WidgetMaxDialogEndTime = JazzComboBox.WidgetMaxDialogEndTimeComboBox;
        private static ComboBox MaxWidgetLabelingYearComboBox = JazzComboBox.MaxWidgetLabelingYearComboBox;
        private static ComboBox MaxWidgetLabelingMonthComboBox = JazzComboBox.MaxWidgetLabelingMonthComboBox;
        private static ComboBox LabelingYearComboBox = JazzComboBox.LabelingYearComboBox;
        private static ComboBox LabelingMonthComboBox = JazzComboBox.LabelingMonthComboBox;

        private static DatePicker WidgetMaxDialogStartDate = JazzDatePicker.WidgetMaxDialogStartDatePicker;
        private static DatePicker WidgetMaxDialogEndDate = JazzDatePicker.WidgetMaxDialogEndDatePicker;

        private static Button WidgetMaxDialogViewButton = JazzButton.WidgetMaxDialogViewButton;
        private static Button WidgetMaxDialogCloseButton = JazzButton.WidgetMaxDialogCloseButton;
        private static Button WidgetMaxDialogPrevButton = JazzButton.WidgetMaxDialogPrevButton;
        private static Button WidgetMaxDialogNextButton = JazzButton.WidgetMaxDialogNextButton;
        private static Button MaxWidgetLabellingViewButton = JazzButton.MaxWidgetLabellingViewButton;

        private static Label WidgetMaxDialogName = JazzLabel.WidgetNameMaxLabel;
        private static Label WidgetShareResourceCommon = JazzLabel.WidgetShareResourceCommonLabel;
        private static Label WidgetShareResourceTime = JazzLabel.WidgetShareResourceTimeLabel;
        private static Label WidgetShareResourceUser = JazzLabel.WidgetShareResourceUserLabel;
        private static Tooltip ShareUserInfo = JazzTooltip.ShareUserTooltip;
        private static Chart MaxWidgetLabellingChart = JazzChart.MaxWidgetLabellingChart;
        private static LinkButton MaxWidgetAddCommentLinkButton = JazzButton.MaxWidgetAddCommentLinkButton;
        private static LinkButton MaxWidgetEditCommentLinkButton = JazzButton.MaxWidgetEditCommentLinkButton;
        private static TextField EditModifyCommentTextField = JazzTextField.EditModifyCommentTextField;
        private static Button SaveAnnotationWindowButton = JazzButton.SaveAnnotationWindowButton;
        private static Button QuitAnnotationWindowButton = JazzButton.QuitAnnotationWindowButton;
        private static Label MaxWidgetCommentLabel = JazzLabel.MaxWidgetCommentLabel;
        private static Button CloseWidgetRenameWindowButton = JazzButton.CloseWidgetRenameWindowButton;
        private static TextField MaxWidgetRightCommentTextField = JazzTextField.MaxWidgetRightCommentTextField;
        private static Button MaxWidgetRightCommentButton = JazzButton.MaxWidgetRightCommentButton;
        private static Container CommentsOnMaxwidgetContainer = JazzContainer.CommentsOnMaxwidgetContainer;
        private static Button NotConfigPeakValleyMessageCloseButton = JazzButton.NotConfigPeakValleyMessageCloseButton;
       
        private static Button WidgetTemplateQuickCreateButton = JazzButton.WidgetTemplateQuickCreateButton;
        private static Button WidgetTemplateQuickCreateCloseButton = JazzButton.WidgetTemplateQuickCreateCloseButton;
        private static Button WidgetTemplateFilterButton = JazzButton.WidgetTemplateFilterButton;
        private static Button WidgetTemplateApplyFilterButton = JazzButton.WidgetTemplateApplyFilterButton;
        private static Button WidgetTemplateCancelFilterButton = JazzButton.WidgetTemplateCancelFilterButton; 
        private static Button WidgetTemplateClearFilterButton = JazzButton.WidgetTemplateClearFilterButton;
        private static Button WidgetTemplateCloseFilterButton = JazzButton.WidgetTemplateCloseFilterButton;
        private static Label WidgetTemplateCriteriaLabel = JazzLabel.WidgetTemplateCriteriaLabel;

        private static CheckBoxField CheckBoxWidgetTemplateTable = JazzCheckBox.WidgetTemplateTableCheckBox;
        
        private static Button SelectHierarchyButton = JazzButton.EnergyViewSelectHierarchyButton;
        private static MenuButton FuncModeConvertTargetButton = JazzButton.FuncModeConvertMenuButton;
        private static EnergyViewToolbarConvertTargetMenu ConvertTargetButton = new EnergyViewToolbarConvertTargetMenu();
        private static MenuButton RadioTypeConvertTargetButton = JazzButton.RadioTypeConvertMenuButton;
        private static MenuButton RankTypeConvertTargetButton = JazzButton.RankTypeConvertMenuButton;
        private static MenuButton CarbonConvertTargetButton = JazzButton.EnergyViewConvertTargetMenuButton;
        private static Button PeakValleyButton = JazzButton.EnergyViewPeakValleyButton;
        private static Button EnergyDisplayStepMonthButton = JazzButton.EnergyDisplayStepMonthButton;
        private static LinkButton CheckEnergyInfoLinkButton = JazzButton.CheckEnergyInfoLinkButton;
        private static MenuButton LabellingIndustryConvertMenuButton = JazzButton.LabellingIndustryConvertMenuButton;
        private static MenuButton EnergyViewConvertTargetMenuButton = JazzButton.EnergyViewConvertTargetMenuButton;
        private static DatePicker StartDatePicker = JazzDatePicker.EnergyUsageStartDateDatePicker;
        private static DatePicker EndDatePicker = JazzDatePicker.EnergyUsageEndDateDatePicker;
        private static Button RankSelectHierarchyButton = JazzButton.RankSelectHierarchyButton;
                
        protected override Chart Chart
        {
            get { return JazzChart.WidgetMaxDialogChart; }
        }

        protected override Grid EnergyDataGrid
        {
            get { return JazzGrid.MaxWidgetDataViewGrid; }
        }
        #endregion

        #region common

        /// <summary>
        /// Navigate To AllDashboard
        /// </summary>
        /// <returns></returns>
        public void NavigateToAllDashboard()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AllDashboards);
        }

        /// <summary>
        /// Navigate To MyFavorite
        /// </summary>
        /// <returns></returns>
        public void NavigateToMyFavorite()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.MyFavirate);
        }

        /// <summary>
        /// Navigate To Energy View
        /// </summary>
        /// <returns></returns>
        public void NavigateToEnergyView()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyView);
        }
        #endregion

        #region min widget operation

        /// <summary>
        /// check a widget is or no exist
        /// </summary>
        /// <returns></returns>
         public bool CheckWidgetIsExist()
        {
            return ElementHandler.Exists(JazzControlLocatorRepository.GetLocator(JazzControlLocatorKey.WidgetName));
        }
        
        /// <summary>
        /// click the dashboard hierarchy name linkbutton to midify the widget
        /// </summary>
         public void ClickDashboardHierarchyNameButton()
         {
             DashboardHierarchyNameButton.Click();
         }

        /// <summary>
        /// modify widget name and save it,expected is the new widget name
        /// </summary>
        /// <param name="expected"></param>
        public void FillNewWidgetName(string name)
         {
             ModifyWidgetNameTextField.Fill(name);
         }

        /// <summary>
        /// Judge if the name field invalid
        /// </summary>
        /// <param name="expected"></param>
        public bool IsWidgetNameFieldInvalid()
        {
            return ModifyWidgetNameTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Get name field invalid message
        /// </summary>
        public string GetWidgetNameFieldInvalidMsg()
        {
            return ModifyWidgetNameTextField.GetInvalidTips();
        }

        /// <summary>
        /// click save
        /// </summary>
        public void ClickSaveWidgetNameButton()
        {
            ModifyWidgetNameSaveButton.Click();
        }

        public void CloseRenameWidgetButton()
        {
            CloseWidgetRenameWindowButton.Click();
        }

        /// <summary>
        /// modify widget name but cancel it
        /// </summary>
         public void CancelModifyWidgetName()
         {
             ModifyWidgetNameCancelButton.Click();
         }
        
        /// <summary>
        /// Cancel delete widget
        /// </summary>
         public void CancelDeleteWidget()
         {
             DeleteWidgetCancelButton.Click();
         }

        /// <summary>
        /// confirm delete widget
        /// </summary>
         public void ConfirmDeleteWidget()
         {
             DeleteWidgetConfirmButton.Click();
         }
        #endregion

        #region max widget operation

        public void SelectStartDate(string startDate)
        {
            WidgetMaxDialogStartDate.SelectDateItem(startDate);
        }

        public string GetStartDate()
        {
            return WidgetMaxDialogStartDate.GetValue();
        }

        public void SelectEndDate(string endDate)
        {
            WidgetMaxDialogEndDate.SelectDateItem(endDate);
        }

        public string GetEndDate()
        {
            return WidgetMaxDialogEndDate.GetValue();
        }

        public void SelectStartTime(string startTime)
        {
            WidgetMaxDialogStartTime.SelectItem(startTime);
        }

        public void SelectEndTime(string endTime)
        {
            WidgetMaxDialogEndTime.SelectItem(endTime);
        }

        public void SetYearAndMonth(string year, string month)
        {
            MaxWidgetLabelingYearComboBox.SelectItem(year);
            MaxWidgetLabelingMonthComboBox.SelectItem(month);
        }

        public void SetYear(string year)
        {
            MaxWidgetLabelingYearComboBox.SelectItem(year);
        }

        public void SetMonth(string month)
        {
            MaxWidgetLabelingMonthComboBox.SelectItem(month);
        }

        public void ClickViewDataButton()
        {
            WidgetMaxDialogViewButton.Click();
        }

        public void ClickViewLabellingDataButton()
        {
            MaxWidgetLabellingViewButton.Click();
        }

        public void ClickPrevButton()
        {
            WidgetMaxDialogPrevButton.Click();
        }

        public void ClickNextButton()
        {
            WidgetMaxDialogNextButton.Click();
        }

        public void ClickCloseMaxDialogButton()
        {
            WidgetMaxDialogCloseButton.Click();
        }

        public string GetMaxWidgetName()
        {
            return WidgetMaxDialogName.GetLabelTextValue();
        }

        public bool IsPrevButtonEnable()
        {
            return WidgetMaxDialogPrevButton.IsEnabled();
        }

        public bool IsNextButtonEnable()
        {
            return WidgetMaxDialogNextButton.IsEnabled();
        }

        public bool IsShareResoureCommonExisted()
        {
            return WidgetShareResourceCommon.IsLabelExisted();
        }

        public bool IsShareResoureTimeExisted()
        {
            return WidgetShareResourceTime.IsLabelExisted();
        }

        public bool IsShareResoureUserExisted()
        {
            return WidgetShareResourceUser.IsLabelExisted();
        }

        public string GetShareResoureUser()
        {
            return WidgetShareResourceUser.GetLabelTextValue();
        }

        public string GetShareResoureTooltipTexts()
        {
            return ShareUserInfo.GetTooltipTexts();
        }

        public bool IsTextsExisted(string[] texts)
        {
            return ShareUserInfo.IsTooltipTextsExisted(texts);
        }

        public void FloatOnShareResoureUser()
        {
            WidgetShareResourceUser.Float();
            TimeManager.ShortPause();
        }

        public DataTable GetWidgetMaxDataViewAllData()
        {
            Grid dataGrid = JazzGrid.MaxWidgetDataViewGrid;

            return dataGrid.GetAllData();
        }

        public bool IsLabellingChartDrawn()
        {
            return MaxWidgetLabellingChart.HasLabellingChartDrawn();
        }

        public bool EntirelyNoLabellingChartDrawn()
        {
            return MaxWidgetLabellingChart.EntirelyNoLabellingChartDrawn();
        }

        public int GetLabellingNumber()
        {
            return MaxWidgetLabellingChart.GetLabellingNumber();
        }

        public string GetLabellingTooltip(int position)
        {
            return MaxWidgetLabellingChart.GetLabellingTooltip(position);
        }

        public string[] GetLabellingTooltip()
        {
            var allTooltips = new List<string>();
            int tooltipsNum = GetLabellingNumber();

            for (int i = 0; i < tooltipsNum; i++)
            {
                allTooltips.Add(GetLabellingTooltip(i));
            }

            return allTooltips.ToArray();
        }

        public bool CompareMaxWidgetStringData(string expectedFileName, string failedFileName, string path)
        {
            if (ExecutionConfig.isCompareExpectedDataViewExcelFile)
            {
                string filePath = Path.Combine(path, expectedFileName);

                string[] expectedStringDatas = JazzFunction.ChartViewOperation.ImportExpectedFileToString(filePath, JazzFunction.ChartViewOperation.sheetNameExpected);

                return JazzFunction.ChartViewOperation.CompareStrings(expectedStringDatas, GetLabellingTooltip(), failedFileName);
            }
            else
            {
                return true;
            }
        }

        public bool CompareMaxWidgetDataView(string basePath, string expectedFileName, string failedFileName)
        {
            if (ExecutionConfig.isCompareExpectedDataViewExcelFile)
            {
                string filePath = Path.Combine(basePath, expectedFileName);
                DataTable actualData = GetWidgetMaxDataViewAllData();
                Grid dataGrid = JazzGrid.MaxWidgetDataViewGrid;

                DataTable expectedDataTable = JazzFunction.DataViewOperation.ImportExpectedFileToDataTable(filePath, JazzFunction.DataViewOperation.sheetNameExpected);

                return JazzFunction.DataViewOperation.CompareDataTables(expectedDataTable, actualData, failedFileName, dataGrid.GetGridHeader(), true);
            }
            else
            {
                return true;
            }
        }

        public void ClickAddMaxWidgetCommentButton()
        {
            MaxWidgetAddCommentLinkButton.ClickLink();
        }

        public bool IsAddMaxWidgetCommentButtonDisplayed()
        {
            return MaxWidgetAddCommentLinkButton.IsDisplayed();
        }

        public void ClickEditMaxWidgetCommentButton()
        {
            MaxWidgetEditCommentLinkButton.ClickLink();
        }

        public bool IsEditMaxWidgetCommentButtonDisplayed()
        {
            return MaxWidgetEditCommentLinkButton.IsDisplayed();
        }

        public void EditAnnotationWindow(string comment)
        {
            EditModifyCommentTextField.Fill(comment);
        }

        public string GetAnnotationWindowText()
        {
            return EditModifyCommentTextField.GetValue();
        }

        public void ClickSaveAnnotationWindowButton()
        {
            SaveAnnotationWindowButton.Click();
        }

        public void ClickQuitAnnotationWindowButton()
        {
            QuitAnnotationWindowButton.Click();
        }

        public string GetMaxWidgetComment()
        {
            return MaxWidgetCommentLabel.GetLabelTextValue();
        }

        public void FillMaxWidgetRightComment(string text)
        {
            MaxWidgetRightCommentTextField.Fill(text);
        }

        public void ClickMaxWidgetRightCommentButton()
        {
            MaxWidgetRightCommentButton.Click();
        }

        public bool IsMaxWidgetRightCommentButtonEnable()
        {
            return MaxWidgetRightCommentButton.IsEnabled();
        }

        public int GetCommentNumberOnMaxWidgetRight()
        {
            return CommentsOnMaxwidgetContainer.GetElementNumber();
        }

        public string GetCommentOfOnePosition(int position)
        {
            return CommentsOnMaxwidgetContainer.GetSpecialElementText(position);
        }
        #endregion

        #region widget template operation

        //click 快速创建 button
        public void ClickWidgetTemplateQuickCreateButton()
        {
            WidgetTemplateQuickCreateButton.Click();
        }

        //Click close button
        public void ClickWidgetTemplateQuickCreateButtonCloseButton()
        {
            WidgetTemplateQuickCreateCloseButton.Click();
        }

        //Click widget filter button
        public void ClickWidgetTemplateFilterButton()
        {
            WidgetTemplateFilterButton.Click();
        }

        //Click widget apply filter button
        public void ClickWidgetTemplateApplyFilterButton()
        {
            WidgetTemplateApplyFilterButton.Click();
        }

        //Click widget cancel filter button
        public void ClickWidgetTemplateCancelFilterButton()
        {
            WidgetTemplateCancelFilterButton.Click();
        }

        //Check 行为 check box.
        public void CheckWidgetTemplateCheckBox(string name1, string name2)
        {
            CheckBoxWidgetTemplateTable.CheckInWidgetTemplate(name1, name2);

        }

        //Uncheck 行为 check box.
        public void UncheckWidgetTemplateCheckBox(string name1, string name2)
        {
            CheckBoxWidgetTemplateTable.UncheckInWidgetTemplate(name1, name2);
        }

        //判断目标对象checkbox 是否check status   
        public Boolean IsWidgetTemplateChecked(string name1, string name2)
        {
            return CheckBoxWidgetTemplateTable.IsWidgetTemplateChecked(name1, name2);
        }

        //判断目标对象其他checkbox 为 uncheck status   
        public Boolean IsWidgetTemplateUnChecked(string name1, string name2)
        {
            return CheckBoxWidgetTemplateTable.IsWidgetTemplateUnChecked(name1, name2);
        }

        //get text for electHierarchyButton
        public string GetSelectHierarchyButtonText()
        {
            return SelectHierarchyButton.GetText();
        }

        //click electHierarchyButton
        public void ClickSelectHierarchyButtonText()
        {
            SelectHierarchyButton.Click();
        }
        public string GetFuncModeConvertTargetButtonText()
        {
            return FuncModeConvertTargetButton.GetText();
        }
        public string GetUnitTypeButtonText()
        {
            return ConvertTargetButton.GetUnitTypeButtonText();
        }

        public string GetRadioTypeConvertTargetButtonText()
        {
            return RadioTypeConvertTargetButton.GetText();

        }

        public string GetCarbonConvertTargetButtonText()
        {
            return CarbonConvertTargetButton.GetText();

        }

        public bool IsPeakValleyButtonEnabled()
        {
            return PeakValleyButton.IsEnabled();

        }
        public bool IsPeakValleyButtonPressed()
        {
            return PeakValleyButton.IsPressed();

        }

        public Boolean IsPopMsgCorrect(string name)
        {
            if (name != null)
            {
                return GetMessageText().Contains(name);
            }
            else
                return true;
        }
        /// <summary>
        /// Get message in the pop up message box. 
        /// </summary>
        /// <returns></returns>
        public string GetMessageText()
        {
            JazzMessageBox.LoadingMask.WaitLoading();
            return JazzMessageBox.MessageBox.GetMessage();
        }
        //Click close button
        public void ClickNotConfigPeakValleyMessageCloseButton()
        {
            NotConfigPeakValleyMessageCloseButton.Click();
        }
        //Click link button
        public void ClickCheckEnergyInfoLinkButton()
        {
            CheckEnergyInfoLinkButton.Click();
        }
        //Click close button in criteria
        public void ClickWidgetTemplateCloseFilterButton(String name)
        {
            Button WidgetTemplateCloseFilterButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonWidgetTemplateCloseFilter, name);
            WidgetTemplateCloseFilterButton.Click();
        }

        //Click  'Clean Criteria' ('清空筛选条件') button
        public void ClickWidgetTemplateClearFilterButton()
        {
            WidgetTemplateClearFilterButton.Click();
        }
        /// <summary>
        /// Is WidgetTemplateQuickCreateButton button  display
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        public bool IsWidgetTemplateQuickCreateButtonExisted()
        {
            return JazzButton.WidgetTemplateQuickCreateButton.IsExisted();
        }
        /// <summary>
        /// Is clearfilter button  display
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        public bool IsClearFilterButtonExisted()
        {
            return JazzButton.WidgetTemplateClearFilterButton.IsExisted();
        }

        //verify label criteria exist
        public Boolean IsCriteriaLabelTextsCorrect(string[] names)
        {
            //Label WidgetField = JazzLabel.GetOneLabelByName(JazzControlLocatorKey.LabelWidgetTemplateCriteria, names[i]);
            return WidgetTemplateCriteriaLabel.IsLabelTextsExisted(names);
        }

        //verify label criteria exist
        public Boolean IsCriteriaLabelTextCorrect(string name)
        {
            Label WidgetField = JazzLabel.GetOneLabelByName(JazzControlLocatorKey.LabelWidgetTemplateCriteria, name);
            return WidgetField.IsLabelTextExisted(name);
        }
        //Get combox value for year
        public string GetComboxYearText()
        {
            return LabelingYearComboBox.GetValue();
        }
        //Get combox value for month
        public string GetComboxMonthText()
        {
            return LabelingMonthComboBox.GetValue();
        }
        //Get  value for labeling button
        public string GetMenuButtonLabellingIndustryConvertText()
        {
            return LabellingIndustryConvertMenuButton.GetText();
        }

        //Get  value for labeling button
        public string GetMenuButtonEnergyViewConvertTargetText()
        {
            return EnergyViewConvertTargetMenuButton.GetText();
        }

        //Get  value for StartDatePicker
        public string GetStartDatePickerText()
        {
            return StartDatePicker.GetValue();
        }
        //Get  value for EndDatePicker
        public string GetEndDatePickerText()
        {
            return EndDatePicker.GetValue();
        }
        //Get  value for RankSelectHierarchyButton
        public string GetRankSelectHierarchyButtonText()
        {
            return RankSelectHierarchyButton.GetText();
        }
        //Get  value for RankTypeConvertTargetButton 
        public string GetRankTypeConvertTargetButtonText()
        {
            return RankTypeConvertTargetButton.GetText();
        }
        #endregion

    }
}