using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Administration;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;


namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of time management.
    /// </summary>
    public class TimeSettingsHeatingCoolingSeason
    {
        internal TimeSettingsHeatingCoolingSeason()
        {
        }

        //private static Grid PTagList = JazzGrid.PTagSettingsPTagList;

        private static Button CreateHeatingCoolingSeasonCalendarButton = JazzButton.HeatingCoolingSeasonCalendarCreateButton;

        private static Button ModifyButton = JazzButton.HeatingCoolingSeasonCalendarModifyButton;
        private static Button SaveButton = JazzButton.HeatingCoolingSeasonCalendarSaveButton;
        private static Button CancelButton = JazzButton.HeatingCoolingSeasonCalendarCancelButton;
        private static Button DeleteButton = JazzButton.HeatingCoolingSeasonCalendarDeleteButton;

        private static TextField NameTextField = JazzTextField.HeatingCoolingSeasonCalendarNameTextField;
        private static Button AddMoreWarmRangesButton = JazzButton.HeatingCoolingSeasonCalendarAddMoreWarmRangesButton;
        private static Button AddMoreColdRangesButton = JazzButton.HeatingCoolingSeasonCalendarAddMoreColdRangesButton;
        private static ComboBox WarmStartMonthComboBox = JazzComboBox.HeatingCoolingSeasonCalendarWarmStartMonthComboBox;
        private static ComboBox WarmStartDateComboBox = JazzComboBox.HeatingCoolingSeasonCalendarWarmStartDateComboBox;
        private static ComboBox WarmEndMonthComboBox = JazzComboBox.HeatingCoolingSeasonCalendarWarmEndMonthComboBox;
        private static ComboBox WarmEndDateComboBox = JazzComboBox.HeatingCoolingSeasonCalendarWarmEndDateComboBox;
        private static ComboBox ColdStartMonthComboBox = JazzComboBox.HeatingCoolingSeasonCalendarColdStartMonthComboBox;
        private static ComboBox ColdStartDateComboBox = JazzComboBox.HeatingCoolingSeasonCalendarColdStartDateComboBox;
        private static ComboBox ColdEndMonthComboBox = JazzComboBox.HeatingCoolingSeasonCalendarColdEndMonthComboBox;
        private static ComboBox ColdEndDateComboBox = JazzComboBox.HeatingCoolingSeasonCalendarColdEndDateComboBox;

        /// <summary>
        /// Navigate to HeatingCoolingSeason Calendar Setting Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToHeatingCoolingSeasonCalendarSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsSeason);
            //TimeManager.ShortPause();
        }

        /// <summary>
        /// Click "add HeatingCoolingSeason" button to add one HeatingCoolingSeason calendar
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void PrepareToAddHeatingCoolingSeasonCalendar()
        {
            CreateHeatingCoolingSeasonCalendarButton.Click();
        }
        
        /// <summary>
        /// Click "add more warm ranges" button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickAddMoreWarmRangesButton()
        {
            AddMoreWarmRangesButton.Click();             
        }

        /// <summary>
        /// Click "add more cold ranges" button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickAddMoreColdRangesButton()
        {
            AddMoreColdRangesButton.Click();
        }
        
        /// <summary>
        /// Fill in name field
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInName(string name)
        {
            NameTextField.Fill(name);
        }

        /// <summary>
        /// Select Warm Start Month from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectWarmStartMonth(string month, int num)
        {
            ComboBox OneStartMonth = GetOneWarmStartMonthComboBox(num);
            OneStartMonth.SelectItem(month); 
        }

        /// <summary>
        /// Select Warm Start Date from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectWarmStartDate(string date, int num)
        {
            ComboBox OneStartDate = GetOneWarmStartDateComboBox(num);
            OneStartDate.SelectItem(date);     
        }

        /// <summary>
        /// Select Warm End Month from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectWarmEndMonth(string month, int num)
        {
            ComboBox OneEndMonth = GetOneWarmEndMonthComboBox(num);
            OneEndMonth.SelectItem(month);             
        }

        /// <summary>
        /// Select Warm End Date from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectWarmEndDate(string date, int num)
        {
            ComboBox OneEndDate = GetOneWarmEndDateComboBox(num);
            OneEndDate.SelectItem(date);
        }

        /// <summary>
        /// Select Cold Start Month from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectColdStartMonth(string month, int num)
        {
            ComboBox OneStartMonth = GetOneColdStartMonthComboBox(num);
            OneStartMonth.SelectItem(month);
        }

        /// <summary>
        /// Select Cold Start Date from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectColdStartDate(string date, int num)
        {
            ComboBox OneStartDate = GetOneColdStartDateComboBox(num);
            OneStartDate.SelectItem(date);
        }

        /// <summary>
        /// Select Cold End Month from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectColdEndMonth(string month, int num)
        {
            ComboBox OneEndMonth = GetOneColdEndMonthComboBox(num);
            OneEndMonth.SelectItem(month);
        }

        /// <summary>
        /// Select Cold End Date from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectColdEndDate(string date, int num)
        {
            ComboBox OneEndDate = GetOneColdEndDateComboBox(num);
            OneEndDate.SelectItem(date);
        }

        /// <summary>
        /// Click save button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            SaveButton.Click();
        }
       
        /// <summary>
        /// Get the Name actual value
        /// </summary>
        /// <returns></returns>
        public string GetNameValue()
        {
            return NameTextField.GetValue();
        }

        /// <summary>
        /// Get Warm Start Month value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetWarmStartMonthValue(int num)
        {
            ComboBox OneStartMonth = GetOneWarmStartMonthComboBox(num);
            return OneStartMonth.GetValue();
        }

        /// <summary>
        /// Get Warm Start Date value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetWarmStartDateValue(int num)
        {
            ComboBox OneStartDate = GetOneWarmStartDateComboBox(num);
            return OneStartDate.GetValue();
        }

        /// <summary>
        /// Get Warm End Month value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetWarmEndMonthValue(int num)
        {
            ComboBox OneEndMonth = GetOneWarmEndMonthComboBox(num);
            return OneEndMonth.GetValue();
        }

        /// <summary>
        /// Get Warm End Date value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetWarmEndDateValue(int num)
        {
            ComboBox OneEndDate = GetOneWarmEndDateComboBox(num);
            return OneEndDate.GetValue();
        }

        /// <summary>
        /// Get Cold Start Month value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetColdStartMonthValue(int num)
        {
            ComboBox OneStartMonth = GetOneColdStartMonthComboBox(num);
            return OneStartMonth.GetValue();
        }

        /// <summary>
        /// Get Cold Start Date value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetColdStartDateValue(int num)
        {
            ComboBox OneStartDate = GetOneColdStartDateComboBox(num);
            return OneStartDate.GetValue();
        }

        /// <summary>
        /// Get Cold End Month value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetColdEndMonthValue(int num)
        {
            ComboBox OneEndMonth = GetOneColdEndMonthComboBox(num);
            return OneEndMonth.GetValue();
        }

        /// <summary>
        /// Get Cold End Date value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetColdEndDateValue(int num)
        {
            ComboBox OneEndDate = GetOneColdEndDateComboBox(num);
            return OneEndDate.GetValue();
        }

        #region private method

        private ComboBox GetOneWarmStartMonthComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarWarmStartMonth, positionIndex);
        }

        private ComboBox GetOneWarmStartDateComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarWarmStartDate, positionIndex);
        }

        private ComboBox GetOneWarmEndMonthComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarWarmEndMonth, positionIndex);
        }

        private ComboBox GetOneWarmEndDateComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarWarmEndDate, positionIndex);
        }

        private ComboBox GetOneColdStartMonthComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarColdStartMonth, positionIndex);
        }

        private ComboBox GetOneColdStartDateComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarColdStartDate, positionIndex);
        }

        private ComboBox GetOneColdEndMonthComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarColdEndMonth, positionIndex);
        }

        private ComboBox GetOneColdEndDateComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarColdEndDate, positionIndex);
        }
        #endregion
    }
}
