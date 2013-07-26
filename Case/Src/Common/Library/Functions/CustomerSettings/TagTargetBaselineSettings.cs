﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library.Functions;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class TagTargetBaselineSettings
    {
        internal TagTargetBaselineSettings()
        {
        }

        #region controls

        private static Grid PTagList = JazzGrid.PTagSettingsPTagList;
        private static Grid VTagList = JazzGrid.VTagSettingsVTagList;

        private static TabButton BasicPropertyTab = JazzButton.KPITagSettingsBasicPropertyTabButton;
        private static TabButton TargetPropertyTab = JazzButton.KPITargetPropertyTabButton;
        private static TabButton BaselinePropertyTab = JazzButton.KPIBaselinePropertyTabButton;

        private static Button CalculationRuleViewButton = JazzButton.KPITargetBaselineCalculationRuleViewButton;
        private static Button CalculationRuleCreateButton = JazzButton.KPITargetBaselineCalculationRuleCreateButton;
        private static Button CalculationRuleBackButton = JazzButton.KPITargetBaselineCalculationRuleBackButton;
        private static Button CalculationRuleModifyButton = JazzButton.KPITargetBaselineCalculationRuleModifyButton;
        private static Button CalculateTargetButton = JazzButton.KPITargetBaselineCalculateTargetButton;
        private static Button CalculateBaselineButton = JazzButton.KPITargetBaselineCalculateBaselineButton;
        private static Button ReviseButton = JazzButton.KPITargetBaselineReviseButton;
        private static Button SaveButton = JazzButton.KPITargetBaselineSaveButton;
        private static Button CancelButton = JazzButton.KPITargetBaselineCancelButton;
        private static Button AddSpecialDatesButton = JazzButton.KPITargetBaselineAddSpecialDatesButton;
        private static Button DeleteSpecialDatesButton = JazzButton.KPITargetBaselineDeleteSpecialDatesButton;
                
        private static TextField WorkdayRuleValueTextField = JazzTextField.KPITargetBaselineWorkdayRuleValueTextField;
        private static TextField NonworkdayRuleValueTextField = JazzTextField.KPITargetBaselineNonworkdayRuleValueTextField;
        private static TextField SpecialdayRuleValueTextField = JazzTextField.KPITargetBaselineSpecialdayRuleValueTextField;
        private static TextField AnnualCalculationValueTextField = JazzTextField.KPITargetBaselineAnnualCalculationValueTextField;
        private static TextField JanuaryCalculationValueTextField = JazzTextField.KPITargetBaselineJanuaryCalculationValueTextField;
        private static TextField FebruaryCalculationValueTextField = JazzTextField.KPITargetBaselineFebruaryCalculationValueTextField;
        private static TextField MarchCalculationValueTextField = JazzTextField.KPITargetBaselineMarchCalculationValueTextField;
        private static TextField AprilCalculationValueTextField = JazzTextField.KPITargetBaselineAprilCalculationValueTextField;
        private static TextField MayCalculationValueTextField = JazzTextField.KPITargetBaselineMayCalculationValueTextField;
        private static TextField JuneCalculationValueTextField = JazzTextField.KPITargetBaselineJuneCalculationValueTextField;
        private static TextField JulyCalculationValueTextField = JazzTextField.KPITargetBaselineJulyCalculationValueTextField;
        private static TextField AugustCalculationValueTextField = JazzTextField.KPITargetBaselineAugustCalculationValueTextField;
        private static TextField SeptemberCalculationValueTextField = JazzTextField.KPITargetBaselineSeptemberCalculationValueTextField;
        private static TextField OctoberCalculationValueTextField = JazzTextField.KPITargetBaselineOctoberCalculationValueTextField;
        private static TextField NovemberCalculationValueTextField = JazzTextField.KPITargetBaselineNovemberCalculationValueTextField;
        private static TextField DecemberCalculationValueTextField = JazzTextField.KPITargetBaselineDecemberCalculationValueTextField;
        
        private static ComboBox EffectiveYear = JazzComboBox.KPITargetBaselineEffectiveYearComboBox;
        private static ComboBox WorkdayRuleEndTime = JazzComboBox.KPITargetBaselineWorkdayRuleEndTimeComboBox;
        private static ComboBox NonworkdayRuleEndTime = JazzComboBox.KPITargetBaselineNonworkdayRuleEndTimeComboBox;
        private static ComboBox SpecialdayRuleStartTime = JazzComboBox.KPITargetBaselineSpecialdayRuleStartTimeComboBox;
        private static ComboBox SpecialdayRuleEndTime = JazzComboBox.KPITargetBaselineSpecialdayRuleEndTimeComboBox;

        private static DatePicker SpecialdayRuleStartDate = JazzDatePicker.KPITargetBaselineSpecialdayRuleStartDateDatePicker;
        private static DatePicker SpecialdayRuleEndDate = JazzDatePicker.KPITargetBaselineSpecialdayRuleEndDateDatePicker;

        private static Label CalendarInfoDisplay = JazzLabel.CalendarInfoDisplayLabel;

        private static LinkButton TargetCalendarInfo = JazzButton.TargetCalendarInfoLinkButton;
        private static LinkButton BaselineCalendarInfo = JazzButton.BaselineCalendarInfoLinkButton;
        private static Button CloseTBCalendarWindowButton = JazzButton.CloseTBCalendarWindowButton;

        private static Window TBCalendarInfoWindow = JazzWindow.TBCalendarInfoWindow;

        private static Container TBCalendarInfoContainer = JazzContainer.TBCalendarInfoContainer;

        #endregion

        #region common
        /// <summary>
        /// Navigate to tag settings
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToTagSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettings);
            TimeManager.ShortPause();
        }

        /// <summary>
        /// Select one ptag by ptag name
        /// </summary>
        /// <param name="ptagName">ptag name</param>
        /// <returns></returns>
        public void FocusOnPTagByName(string ptagName)
        {
            PTagList.FocusOnRow(1, ptagName);
        }

        /// <summary>
        /// Select one vtag by name
        /// </summary>
        /// <param name="vtagName">vtag name</param>
        /// <returns></returns>
        public void FocusOnVTagByName(string vtagName)
        {
            VTagList.FocusOnRow(1, vtagName);
        }

        /// <summary>
        /// Click Baseline Property tab button.
        /// </summary>
        /// <returns></returns>
        public void SwitchToBaselinePropertyTab()
        {
            BaselinePropertyTab.Click();
        }              
                       
        /// <summary>
        /// Click Target Property tab button.
        /// </summary>
        /// <returns></returns>
        public void SwitchToTargetPropertyTab()
        {
            TargetPropertyTab.Click();
        }

        /// <summary>
        /// Select one year for target/baseline
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectYear(string year)
        {
            EffectiveYear.SelectItem(year);
        }
               

        /// <summary>
        /// Click save button on target/baseline tab
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            SaveButton.Click();
            //JazzMessageBox.MessageBox.Yes();
        }

        /// <summary>
        /// Click cancel button on target/baseline tab
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCancelButton()
        {
            CancelButton.Click();
        }

        /// <summary>
        /// Get calendar info display field text
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetCalendarFieldLabelText()
        {
            return CalendarInfoDisplay.GetLabelTextValue();
        }

        /// <summary>
        /// Click target Calendar Info LinkButton
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickTargetCalendarInfoLinkButton()
        {
            TargetCalendarInfo.Click();
        }

        /// <summary>
        /// Click baseline Calendar Info LinkButton
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickBaselineCalendarInfoLinkButton()
        {
            BaselineCalendarInfo.Click();
        }

        /// <summary>
        /// Close calendar info window
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void CloseCalendarInfoWindow()
        {
            CloseTBCalendarWindowButton.Click();
        }
        #endregion

        #region configuration rule settings

        /// <summary>
        /// Click calculation rule view button
        /// </summary>
        /// <returns></returns>
        public void ClickViewCalculationRuleButton()
        {
            JazzMessageBox.LoadingMask.WaitLoading();
            CalculationRuleViewButton.Click();
        }

        /// <summary>
        /// Click calculation rule add button
        /// </summary>
        /// <returns></returns>
        public void ClickCreateCalculationRuleButton()
        {
            CalculationRuleCreateButton.Click();
        }

        /// <summary>
        /// Click calculation rule back button
        /// </summary>
        /// <returns></returns>
        public void ClickBackFromCalculationRuleButton()
        {
            CalculationRuleBackButton.Click();
        }

        /// <summary>
        /// Click calculation rule modify button
        /// </summary>
        /// <returns></returns>
        public void ClickModifyCalculationRuleButton()
        {
            CalculationRuleModifyButton.Click();
        }

        /// <summary>
        /// Select end time for workday rule
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectWorkdayRuleEndTime(string time, int num)
        {
            ComboBox OneEndTime = GetOneWorkdayRuleEndTimeComboBox(num);
            OneEndTime.SelectItem(time);
        }

        /// <summary>
        /// Select end time for Nonworkday rule
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectNonworkdayRuleEndTime(string time, int num)
        {
            ComboBox OneEndTime = GetOneNonworkdayRuleEndTimeComboBox(num);
            OneEndTime.SelectItem(time);
        }

        /// <summary>
        /// Fill in Workday rull value field
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInWorkdayRuleValue(string value, int num)
        {
            TextField OneWorkdayRuleValueValue = GetOneWorkdayRuleValueTextField(num);
            OneWorkdayRuleValueValue.Fill(value);
        }

        /// <summary>
        /// Fill in Nonworkday rull value field
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInNonworkdayRuleValue(string value, int num)
        {
            TextField OneNonworkdayRuleValueValue = GetOneNonworkdayRuleValueTextField(num);
            OneNonworkdayRuleValueValue.Fill(value);
        }

        /// <summary>
        /// Click "add more ranges" button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickAddSpecialDatesButton()
        {
            AddSpecialDatesButton.Click();
        }

        /// <summary>
        /// Select start date for special date rule 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectSpecialdayRuleStartDate(string yyyyMMDD, int num)
        {
            string[] yyyyMMDDArray = yyyyMMDD.Split(new char[1] { '-' });
            int year = Convert.ToInt32(yyyyMMDDArray[0]);
            int month = Convert.ToInt32(yyyyMMDDArray[1]);
            int day = Convert.ToInt32(yyyyMMDDArray[2]);

            DatePicker OneStartDate = GetOneSpecialdayRuleStartDateDatePicker(num);         
            OneStartDate.SelectDateItem(new DateTime(year, month, day));
        }

        /// <summary>
        /// Select end date for special date rule 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectSpecialdayRuleEndDate(string yyyyMMDD, int num)
        {
            string[] yyyyMMDDArray = yyyyMMDD.Split(new char[1] { '-' });
            int year = Convert.ToInt32(yyyyMMDDArray[0]);
            int month = Convert.ToInt32(yyyyMMDDArray[1]);
            int day = Convert.ToInt32(yyyyMMDDArray[2]);

            DatePicker OneEndDate = GetOneSpecialdayRuleEndDateDatePicker(num);
            OneEndDate.SelectDateItem(new DateTime(year, month, day));
        }

        /// <summary>
        /// Select start time for special date rule
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectSpecialdayRuleStartTime(string time, int num)
        {
            ComboBox OneStartTime = GetOneSpecialdayRuleStartTimeComboBox(num);
            OneStartTime.SelectItem(time);
        }

        /// <summary>
        /// Select end time for special date rule
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectSpecialdayRuleEndTime(string time, int num)
        {
            ComboBox OneEndTime = GetOneSpecialdayRuleEndTimeComboBox(num);
            OneEndTime.SelectItem(time);
        }

        /// <summary>
        /// Fill in special day rull value field
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInSpecialdayRuleValue(string value, int num)
        {
            TextField OneSpecialdayRuleValueValue = GetOneSpecialdayRuleValueTextField(num);
            OneSpecialdayRuleValueValue.Fill(value);
        }
        #endregion

        #region calculate values

        /// <summary>
        /// Click calculate target value button
        /// </summary>
        /// <returns></returns>
        public void ClickCalculateTargetButton()
        {
            JazzMessageBox.LoadingMask.WaitLoading();
            CalculateTargetButton.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
            JazzMessageBox.MessageBox.Yes();
            JazzMessageBox.LoadingMask.WaitLoading(maxtime:30);
        }

        /// <summary>
        /// Click calculate baseline value button
        /// </summary>
        /// <returns></returns>
        public void ClickCalculateBaselineButton()
        {
            JazzMessageBox.LoadingMask.WaitLoading();
            CalculateBaselineButton.Click();
        }
        #endregion

        #region revise calculation values

        /// <summary>
        /// Click revise target or baseline value button
        /// </summary>
        /// <returns></returns>
        public void ClickReviseButton()
        {
            JazzMessageBox.LoadingMask.WaitLoading();
            ReviseButton.Click();
        }
                
        public void FillInAnnualRevisedValue(string value)
        {
            AnnualCalculationValueTextField.Fill(value);            
        }

        public void FillInJanuaryRevisedValue(string value)
        {
            JanuaryCalculationValueTextField.Fill(value);
        }

        public void FillInFebruaryRevisedValue(string value)
        {
            FebruaryCalculationValueTextField.Fill(value);            
        }

        public void FillInMarchRevisedValue(string value)
        {
            MarchCalculationValueTextField.Fill(value);            
        }

        public void FillInAprilRevisedValue(string value)
        {
            AprilCalculationValueTextField.Fill(value);            
        }

        public void FillInMayRevisedValue(string value)
        {
            MayCalculationValueTextField.Fill(value);
        }

        public void FillInJuneRevisedValue(string value)
        {
            JuneCalculationValueTextField.Fill(value);
        }

        public void FillInJulyRevisedValue(string value)
        {
            JulyCalculationValueTextField.Fill(value);
        }

        public void FillInAugustRevisedValue(string value)
        {
            AugustCalculationValueTextField.Fill(value);
        }

        public void FillInSeptemberRevisedValue(string value)
        {
            SeptemberCalculationValueTextField.Fill(value);
        }

        public void FillInOctoberRevisedValue(string value)
        {
            OctoberCalculationValueTextField.Fill(value);
        }

        public void FillInNovemberRevisedValue(string value)
        {
            NovemberCalculationValueTextField.Fill(value);
        }

        public void FillInDecemberRevisedValue(string value)
        {
            DecemberCalculationValueTextField.Fill(value);
        }

        public string GetAnnualValue()
        {
            return AnnualCalculationValueTextField.GetValue();
        }

        public string GetJanuaryValue()
        {
            return JanuaryCalculationValueTextField.GetValue();
        }

        public string GetFebruaryValue()
        {
            return FebruaryCalculationValueTextField.GetValue();
        }

        public string GetMarchValue()
        {
            return MarchCalculationValueTextField.GetValue();
        }

        public string GetAprilValue()
        {
            return AprilCalculationValueTextField.GetValue();
        }

        public string GetMayValue()
        {
            return MayCalculationValueTextField.GetValue();
        }

        public string GetJuneValue()
        {
            return JuneCalculationValueTextField.GetValue();
        }

        public string GetJulyValue()
        {
            return JulyCalculationValueTextField.GetValue();
        }

        public string GetAugustValue()
        {
            return AugustCalculationValueTextField.GetValue();
        }

        public string GetSeptemberValue()
        {
            return SeptemberCalculationValueTextField.GetValue();
        }

        public string GetOctoberValue()
        {
            return OctoberCalculationValueTextField.GetValue();
        }

        public string GetNovemberValue()
        {
            return NovemberCalculationValueTextField.GetValue();
        }

        public string GetDecemberValue()
        {
            return DecemberCalculationValueTextField.GetValue();
        }
        #endregion

        #region Verification

        /// <summary>
        /// Judge if calendar info window existed
        /// </summary>
        /// <param></param>
        /// <returns>true if displayed, flase if not</returns>
        public bool IsCalendarInfoWindowDisplayed()
        {
            return TBCalendarInfoWindow.IsWindowExisted();
        }

        /// <summary>
        /// Judge if calendar info window include the strings
        /// </summary>
        /// <param name = 'info'>calendar info texts</param>
        /// <returns>true if contains, flase if not</returns>
        public bool IsCalendarInfoCorrect(string[] infos)
        {
            return TBCalendarInfoContainer.IsContainerTextsExisted(infos);
        }
        #endregion

        #region private method

        private ComboBox GetOneWorkdayRuleEndTimeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxKPITargetBaselineWorkdayRuleEndTime, positionIndex);
        }

        private ComboBox GetOneNonworkdayRuleEndTimeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxKPITargetBaselineNonworkdayRuleEndTime, positionIndex);
        }

        private ComboBox GetOneSpecialdayRuleStartTimeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxKPITargetBaselineSpecialdayRuleStartTime, positionIndex);
        }

        private ComboBox GetOneSpecialdayRuleEndTimeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxKPITargetBaselineSpecialdayRuleEndTime, positionIndex);
        }

        private TextField GetOneWorkdayRuleValueTextField(int positionIndex)
        {
            return JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldKPITargetBaselineWorkdayRuleValue, positionIndex);
        }

        private TextField GetOneNonworkdayRuleValueTextField(int positionIndex)
        {
            return JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldKPITargetBaselineNonworkdayRuleValue, positionIndex);
        }       

        private TextField GetOneSpecialdayRuleValueTextField(int positionIndex)
        {
            return JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldKPITargetBaselineSpecialdayRuleValue, positionIndex);
        }

        private DatePicker GetOneSpecialdayRuleStartDateDatePicker(int positionIndex)
        {
            return JazzDatePicker.GetOneMonthPicker(JazzControlLocatorKey.DatePickerKPITargetBaselineSpecialdayRuleStartDate, positionIndex);
        }

        private DatePicker GetOneSpecialdayRuleEndDateDatePicker(int positionIndex)
        {
            return JazzDatePicker.GetOneMonthPicker(JazzControlLocatorKey.DatePickerKPITargetBaselineSpecialdayRuleEndDate, positionIndex);
        }

        #endregion

    }

}

