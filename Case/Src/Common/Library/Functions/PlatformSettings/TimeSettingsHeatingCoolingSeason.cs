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
        private static Button AddMoreColdWarmRangesButton = JazzButton.HeatingCoolingSeasonCalendarAddMoreColdWarmRangesButton;
        private static ComboBox ColdWarmStartMonthComboBox = JazzComboBox.HeatingCoolingSeasonCalendarColdWarmStartMonthComboBox;
        private static ComboBox ColdWarmStartDateComboBox = JazzComboBox.HeatingCoolingSeasonCalendarColdWarmStartDateComboBox;
        private static ComboBox ColdWarmEndMonthComboBox = JazzComboBox.HeatingCoolingSeasonCalendarColdWarmEndMonthComboBox;
        private static ComboBox ColdWarmEndDateComboBox = JazzComboBox.HeatingCoolingSeasonCalendarColdWarmEndDateComboBox;

        private static Container CalendarColdWarmItemsContainer = JazzContainer.CalendarColdWarmItemsContainer;

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

        public void ClickMsgBoxDeleteButton()
        {
            JazzMessageBox.MessageBox.Delete();
        }

        public void ClickMsgBoxGiveUpButton()
        {
            JazzMessageBox.MessageBox.GiveUp();
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
        /// Click "add more cold warm ranges" button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickAddMoreColdWarmRangesButton()
        {
            AddMoreColdWarmRangesButton.Click();             
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

        public void AddColdWarmRanges(HeatingCoolingSeasonCalendarData testData)
        {                       
            //Click '+' button if more than one cold warm record need to be entered
            //Amy's note: due to the order of dynamic element will be different if click the '+' icon after the first record has been input. That is why click + icon multiple times continuaslly here..       
            for (int elementPosition = GetColdWarmRangeItemsNumber(); elementPosition < testData.InputData.ColdWarmRange.Length; elementPosition++)
            {
                ClickAddMoreColdWarmRangesButton();
                TimeManager.ShortPause();
            }

            //Input cold warm record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.ColdWarmRange.Length; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                SelectColdWarmType(testData.InputData.ColdWarmRange[inputDataArrayPosition].Type, elementPosition);
                SelectColdWarmStartMonth(testData.InputData.ColdWarmRange[inputDataArrayPosition].StartMonth, elementPosition);
                SelectColdWarmStartDate(testData.InputData.ColdWarmRange[inputDataArrayPosition].StartDate, elementPosition);
                SelectColdWarmEndMonth(testData.InputData.ColdWarmRange[inputDataArrayPosition].EndMonth, elementPosition);
                SelectColdWarmEndDate(testData.InputData.ColdWarmRange[inputDataArrayPosition].EndDate, elementPosition);
            }
        }

        /// <summary>
        /// Select Cold Warm Type from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectColdWarmType(string coldWarmType, int num)
        {
            ComboBox OneColdWarmType = GetOneColdWarmTypeComboBox(num);
            OneColdWarmType.SelectItem(coldWarmType);
        }

        /// <summary>
        /// Select Cold Warm Start Month from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectColdWarmStartMonth(string month, int num)
        {
            ComboBox OneStartMonth = GetOneColdWarmStartMonthComboBox(num);
            OneStartMonth.SelectItem(month); 
        }

        /// <summary>
        /// Select Cold Warm Start Date from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectColdWarmStartDate(string date, int num)
        {
            ComboBox OneStartDate = GetOneColdWarmStartDateComboBox(num);
            OneStartDate.SelectItem(date);     
        }

        /// <summary>
        /// Select Cold Warm End Month from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectColdWarmEndMonth(string month, int num)
        {
            ComboBox OneEndMonth = GetOneColdWarmEndMonthComboBox(num);
            OneEndMonth.SelectItem(month);             
        }

        /// <summary>
        /// Select Cold Warm End Date from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectColdWarmEndDate(string date, int num)
        {
            ComboBox OneEndDate = GetOneColdWarmEndDateComboBox(num);
            OneEndDate.SelectItem(date);
        }
                

        public void ClickDeleteColdWarmRangeItemButton(int num)
        {
            Button OneDeleteRangeIcon = GetOneColdWarmDeleteRangeItemButton(num);
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

        public Boolean IsColdWarmRangeItemDeleteButtonDisplayed(int num)
        {
            Button OneDeleteRangeIcon = GetOneColdWarmDeleteRangeItemButton(num);
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

        public Boolean IsColdWarmRangeInvalidMsgCorrect(HeatingCoolingSeasonCalendarExpectedData output, int position)
        {
            int arrayPosition = position - 1;
            ComboBox OneEndMonthComboBox = GetOneColdWarmEndMonthComboBox(position);
            if (output.ColdWarmRange != null)
            {
                return OneEndMonthComboBox.GetInvalidTips().Contains(output.ColdWarmRange[arrayPosition].EndMonth);
                return OneEndMonthComboBox.GetInvalidTips().Contains(output.ColdWarmRange[arrayPosition].Type);
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
        /// Get the number of cold warm ranges
        /// </summary>
        /// <returns></returns>
        public int GetColdWarmRangeItemsNumber()
        {
            return CalendarColdWarmItemsContainer.GetElementNumber();
        }

        /// <summary>
        /// Get Cold Warm Start Month value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetColdWarmStartMonthValue(int num)
        {
            ComboBox OneStartMonth = GetOneColdWarmStartMonthComboBox(num);
            return OneStartMonth.GetValue();
        }

        /// <summary>
        /// Get Cold Warm Start Date value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetColdWarmStartDateValue(int num)
        {
            ComboBox OneStartDate = GetOneColdWarmStartDateComboBox(num);
            return OneStartDate.GetValue();
        }

        /// <summary>
        /// Get Cold Warm End Month value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetColdWarmEndMonthValue(int num)
        {
            ComboBox OneEndMonth = GetOneColdWarmEndMonthComboBox(num);
            return OneEndMonth.GetValue();
        }

        /// <summary>
        /// Get Cold Warm End Date value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetColdWarmEndDateValue(int num)
        {
            ComboBox OneEndDate = GetOneColdWarmEndDateComboBox(num);
            return OneEndDate.GetValue();
        }               

        #endregion

        #region private method

        private ComboBox GetOneColdWarmTypeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarColdWarmType, positionIndex);
        }

        private ComboBox GetOneColdWarmStartMonthComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarColdWarmStartMonth, positionIndex);
        }

        private ComboBox GetOneColdWarmStartDateComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarColdWarmStartDate, positionIndex);
        }

        private ComboBox GetOneColdWarmEndMonthComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarColdWarmEndMonth, positionIndex);
        }

        private ComboBox GetOneColdWarmEndDateComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxHeatingCoolingSeasonCalendarColdWarmEndDate, positionIndex);
        }              

        private Button GetOneColdWarmDeleteRangeItemButton(int positionIndex)
        {
            return JazzButton.GetOneButton(JazzControlLocatorKey.ButtonHeatingCoolingSeasonCalendarDeleteRangeItem, positionIndex);
        }
                
        #endregion
    }
}
