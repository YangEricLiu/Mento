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

        #region Controls
        private static Grid CalendarsList = JazzGrid.CalendarsList;
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

        private static Container CalendarWarmItemsContainer = JazzContainer.CalendarWarmItemsContainer;
        private static Container CalendarColdItemsContainer = JazzContainer.CalendarColdItemsContainer;

        #endregion

        #region common action
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
        /// Select a calendar
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectCalendar(string calendarName)
        {
            CalendarsList.FocusOnRow(1, calendarName, false);
        }

        /// <summary>
        /// Click save button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            SaveButton.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
        }

        /// <summary>
        /// Click cancel button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCancelButton()
        {
            CancelButton.Click();
        }

        /// <summary>
        /// Click modify button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickModifyButton()
        {
            ModifyButton.Click();
        }

        /// <summary>
        /// Click delete button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickDeleteButton()
        {
            DeleteButton.Click();
        }

        public void ClickMsgBoxConfirmButton()
        {
            JazzMessageBox.MessageBox.Confirm();
        }

        public void ClickMsgBoxCancelButton()
        {
            JazzMessageBox.MessageBox.Cancel();
        }

        public void ClickMsgBoxCloseButton()
        {
            JazzMessageBox.MessageBox.Close();
        }

        public void ClickMsgBoxOKButton()
        {
            JazzMessageBox.MessageBox.OK();
        }

        #endregion

        #region item operation
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

        public void AddWarmRanges(HeatingCoolingSeasonCalendarData testData)
        {                       
            //Click '+' button if more than one warm record need to be entered
            //Amy's note: due to the order of dynamic element will be different if click the '+' icon after the first record has been input. That is why click + icon multiple times continuaslly here..       
            for (int elementPosition = 1; elementPosition < testData.InputData.WarmRange.Length; elementPosition++)
            {
                ClickAddMoreWarmRangesButton();
                TimeManager.ShortPause();
            }

            //Input warm record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.WarmRange.Length; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                SelectWarmStartMonth(testData.InputData.WarmRange[inputDataArrayPosition].StartMonth, elementPosition);
                SelectWarmStartDate(testData.InputData.WarmRange[inputDataArrayPosition].StartDate, elementPosition);
                SelectWarmEndMonth(testData.InputData.WarmRange[inputDataArrayPosition].EndMonth, elementPosition);
                SelectWarmEndDate(testData.InputData.WarmRange[inputDataArrayPosition].EndDate, elementPosition);
            }
        }

        public void AddColdRanges(HeatingCoolingSeasonCalendarData testData)
        {
            //Click '+' button if more than one warm record need to be entered
            //Amy's note: due to the order of dynamic element will be different if click the '+' icon after the first record has been input. That is why click + icon multiple times continuaslly here..       
            for (int elementPosition = 1; elementPosition < testData.InputData.ColdRange.Length; elementPosition++)
            {
                ClickAddMoreColdRangesButton();
                TimeManager.ShortPause();
            }

            //Input cold record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.ColdRange.Length; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                SelectColdStartMonth(testData.InputData.ColdRange[inputDataArrayPosition].StartMonth, elementPosition);
                SelectColdStartDate(testData.InputData.ColdRange[inputDataArrayPosition].StartDate, elementPosition);
                SelectColdEndMonth(testData.InputData.ColdRange[inputDataArrayPosition].EndMonth, elementPosition);
                SelectColdEndDate(testData.InputData.ColdRange[inputDataArrayPosition].EndDate, elementPosition);
            }
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

        public void ClickDeleteWarmRangeItemButton(int num)
        {
            Button OneDeleteRangeIcon = GetOneWarmDeleteRangeItemButton(num);
            OneDeleteRangeIcon.Click();
        }

        public void ClickDeleteColdRangeItemButton(int num)
        {
            Button OneDeleteRangeIcon = GetOneColdDeleteRangeItemButton(num);
            OneDeleteRangeIcon.Click();
        }
        #endregion

        #region verification
        public Boolean IsSaveButtonDisplayed()
        {
            return SaveButton.IsDisplayed();
        }

        public Boolean IsCancelButtonDisplayed()
        {
            return CancelButton.IsDisplayed();
        }

        public Boolean IsModifyButtonDisplayed()
        {
            return ModifyButton.IsDisplayed();
        }

        public Boolean IsDeleteButtonDisplayed()
        {
            return DeleteButton.IsDisplayed();
        }

        public Boolean IsCalendarExist(string calendarName)
        {
            return CalendarsList.IsRowExist(1, calendarName);
        }

        public Boolean IsWarmRangeItemDeleteButtonDisplayed(int num)
        {
            Button OneDeleteRangeIcon = GetOneWarmDeleteRangeItemButton(num);
            return OneDeleteRangeIcon.IsDisplayed();
        }

        public Boolean IsColdRangeItemDeleteButtonDisplayed(int num)
        {
            Button OneDeleteRangeIcon = GetOneColdDeleteRangeItemButton(num);
            return OneDeleteRangeIcon.IsDisplayed();
        }

        public Boolean IsNameInvalidMsgCorrect(HeatingCoolingSeasonCalendarExpectedData output)
        {
            if (output.CommonName != null)
            {
                return NameTextField.GetInvalidTips().Contains(output.CommonName);
            }
            else
                return true;
        }

        public Boolean IsWarmRangeInvalidMsgCorrect(HeatingCoolingSeasonCalendarExpectedData output, int position)
        {
            int arrayPosition = position - 1;
            ComboBox OneEndMonthComboBox = GetOneWarmEndMonthComboBox(position);
            if (output.WarmRange != null)
            {
                return OneEndMonthComboBox.GetInvalidTips().Contains(output.WarmRange[arrayPosition].EndMonth);
            }
            else
                return true;
        }

        public Boolean IsColdRangeInvalidMsgCorrect(HeatingCoolingSeasonCalendarExpectedData output, int position)
        {
            int arrayPosition = position - 1;
            ComboBox OneEndMonthComboBox = GetOneColdEndMonthComboBox(position);
            if (output.ColdRange != null)
            {
                return OneEndMonthComboBox.GetInvalidTips().Contains(output.ColdRange[arrayPosition].EndMonth);
            }
            else
                return true;
        }

        /// <summary>
        /// Judge whether the pop message correct
        /// </summary>
        /// <param name="output">TOUBasicTariffExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsPopMsgCorrect(HeatingCoolingSeasonCalendarExpectedData output)
        {
            if (output.PopMessage != null)
            {
                return GetMessageText().Contains(output.PopMessage);
            }
            else
                return true;
        }
        #endregion

        #region Get value
        /// <summary>
        /// Get message in the pop up message box. 
        /// </summary>
        /// <returns></returns>
        public string GetMessageText()
        {
            JazzMessageBox.LoadingMask.WaitLoading();
            return JazzMessageBox.MessageBox.GetMessage();
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
        /// Get the number of the warm ranges
        /// </summary>
        /// <returns></returns>
        public int GetWarmRangeItemsNumber()
        {
            return CalendarWarmItemsContainer.GetElementNumber();
        }

        /// <summary>
        /// Get the number of the cold ranges
        /// </summary>
        /// <returns></returns>
        public int GetColdRangeItemsNumber()
        {
            return CalendarColdItemsContainer.GetElementNumber();
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

        #endregion

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

        private Button GetOneWarmDeleteRangeItemButton(int positionIndex)
        {
            return JazzButton.GetOneButton(JazzControlLocatorKey.ButtonHeatingCoolingSeasonCalendarWarmDeleteRangeItem, positionIndex);
        }

        private Button GetOneColdDeleteRangeItemButton(int positionIndex)
        {
            return JazzButton.GetOneButton(JazzControlLocatorKey.ButtonHeatingCoolingSeasonCalendarColdDeleteRangeItem, positionIndex);
        }

        #endregion
    }
}
