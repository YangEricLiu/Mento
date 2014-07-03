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
    public class TimeSettingsWorkday
    {
        internal TimeSettingsWorkday()
        {
        }

        #region Controls
        private static Grid CalendarsList = JazzGrid.CalendarsList;
        private static Button CreateWorkdayCalendarButton = JazzButton.WorkdayCalendarCreateButton;
        private static Button ModifyButton = JazzButton.WorkdayCalendarModifyButton;
        private static Button SaveButton = JazzButton.WorkdayCalendarSaveButton;
        private static Button CancelButton = JazzButton.WorkdayCalendarCancelButton;
        private static Button DeleteButton = JazzButton.WorkdayCalendarDeleteButton;
        private static Button AddSpecialDateButton = JazzButton.WorkdayCalendarAddSpecialDatesButton;        
        
        private static ComboBox SpecialDateTypeComboBox = JazzComboBox.WorkdayCalendarSpecialDateTypeComboBox;
        private static ComboBox StartMonthComboBox = JazzComboBox.WorkdayCalendarStartMonthComboBox;
        private static ComboBox StartDateComboBox = JazzComboBox.WorkdayCalendarStartDateComboBox;
        private static ComboBox EndMonthComboBox = JazzComboBox.WorkdayCalendarEndMonthComboBox;
        private static ComboBox EndDateComboBox = JazzComboBox.WorkdayCalendarEndDateComboBox;

        private static Label WorkdayCalendarLabel = JazzLabel.PlatformWorkdayCalendarLabel;
        private static TextField NameTextField = JazzTextField.WorkdayCalendarNameTextField;
        private static Container CalendarItemsContainer = JazzContainer.CalendarItemsContainer;

        #endregion

        #region common action
        /// <summary>
        /// Navigate to Workday Calendar Setting Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToWorkdayCalendarSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
            //TimeManager.ShortPause();
        }

        /// <summary>
        /// Click "add workday" button to add one workday calendar
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void PrepareToAddWorkdayCalendar()
        {
            CreateWorkdayCalendarButton.Click();
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
        /// Fill in name field
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInName(string name)
        {
            NameTextField.Fill(name);
        }

        /// <summary>
        /// Click "add special dates" icon
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickAddSpecialDateButton()
        {
            AddSpecialDateButton.Click();
        }

        public void AddSpecialDates(WorkdayCalendarData testData)
        {
            //Click '+' icon each time when add a special date record
            //Amy's note: due to the order of dynamic element will be different if click the '+' icon after the first record has been input. That is why click + icon multiple times continuaslly here..        
            for (int elementPosition = 1; elementPosition <= testData.InputData.SpecialDate.Length; elementPosition++)
            {
                ClickAddSpecialDateButton();
                TimeManager.ShortPause();
            }

            //Input record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.SpecialDate.Length; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                SelectSpecialDateType(testData.InputData.SpecialDate[inputDataArrayPosition].Type, elementPosition);
                SelectStartMonth(testData.InputData.SpecialDate[inputDataArrayPosition].StartMonth, elementPosition);
                SelectStartDate(testData.InputData.SpecialDate[inputDataArrayPosition].StartDate, elementPosition);
                SelectEndMonth(testData.InputData.SpecialDate[inputDataArrayPosition].EndMonth, elementPosition);
                SelectEndDate(testData.InputData.SpecialDate[inputDataArrayPosition].EndDate, elementPosition);
                TimeManager.ShortPause();
            }
        }

        /// <summary>
        /// Select Special date type from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectSpecialDateType(string specialDateType, int num)
        {
            ComboBox OneSpecialDateType = GetOneSpecialDateTypeComboBox(num);
            OneSpecialDateType.SelectItem(specialDateType);            
        }

        /// <summary>
        /// Select Start Month from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectStartMonth(string month, int num)
        {
            ComboBox OneStartMonth = GetOneStartMonthComboBox(num);
            OneStartMonth.SelectItem(month); 
        }

        /// <summary>
        /// Select Start Date from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectStartDate(string date, int num)
        {
            ComboBox OneStartDate = GetOneStartDateComboBox(num);
            OneStartDate.SelectItem(date);     
        }

        /// <summary>
        /// Select End Month from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectEndMonth(string month, int num)
        {
            ComboBox OneEndMonth = GetOneEndMonthComboBox(num);
            OneEndMonth.SelectItem(month);             
        }

        /// <summary>
        /// Select End Date from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectEndDate(string date, int num)
        {
            ComboBox OneEndDate = GetOneEndDateComboBox(num);
            OneEndDate.SelectItem(date);
        }

        public void ClickDeleteRangeItemButton(int num)
        {
            Button OneDeleteRangeIcon = GetOneDeleteRangeItemButton(num);
            OneDeleteRangeIcon.Click();
        }        

        #endregion

        #region verification
        public Boolean IsWorkdayCalendarTextCorrect(string[] texts)
        {
            return WorkdayCalendarLabel.IsLabelTextsExisted(texts);
        }

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

        public Boolean IsRangeItemDeleteButtonDisplayed(int num)
        {
            Button OneDeleteRangeIcon = GetOneDeleteRangeItemButton(num);
            return OneDeleteRangeIcon.IsDisplayed();
        }

        public Boolean IsNameInvalidMsgCorrect(WorkdayCalendarExpectedData output)
        {
            if (output.CommonName != null)
            {
                return NameTextField.GetInvalidTips().Contains(output.CommonName);
            }
            else
                return true;
        }

        public Boolean IsTypeInvalidMsgCorrect(WorkdayCalendarExpectedData output, int position)
        {
            int arrayPosition = position - 1;
            ComboBox OneSpecialDateTypeComboBox = GetOneSpecialDateTypeComboBox(position);
            if (output.SpecialDate != null)
            {
                return OneSpecialDateTypeComboBox.GetInvalidTips().Contains(output.SpecialDate[arrayPosition].Type);
            }
            else
                return true;            
        }

        public Boolean IsRangeInvalidMsgCorrect(WorkdayCalendarExpectedData output, int position)
        {
            int arrayPosition = position - 1;
            ComboBox OneEndMonthComboBox = GetOneEndMonthComboBox(position);
            if (output.SpecialDate != null)
            {
                return OneEndMonthComboBox.GetInvalidTips().Contains(output.SpecialDate[arrayPosition].EndMonth);
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
        /// Get the number of the Date ranges
        /// </summary>
        /// <returns></returns>
        public int GetSpecialDateItemsNumber()
        {
            return CalendarItemsContainer.GetElementNumber();
        }

        /// <summary>
        /// Get Special date type value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetSpecialDateTypeValue(int num)
        {
            ComboBox OneSpecialDateType = GetOneSpecialDateTypeComboBox(num);
            return OneSpecialDateType.GetValue();
        }

        /// <summary>
        /// Get Start Month value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetStartMonthValue(int num)
        {
            ComboBox OneStartMonth = GetOneStartMonthComboBox(num);
            return OneStartMonth.GetValue();
        }

        /// <summary>
        /// Get Start Date value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetStartDateValue(int num)
        {
            ComboBox OneStartDate = GetOneStartDateComboBox(num);
            return OneStartDate.GetValue();
        }

        /// <summary>
        /// Get End Month value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetEndMonthValue(int num)
        {
            ComboBox OneEndMonth = GetOneEndMonthComboBox(num);
            return OneEndMonth.GetValue();
        }

        /// <summary>
        /// Get End Date value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetEndDateValue(int num)
        {
            ComboBox OneEndDate = GetOneEndDateComboBox(num);
            return OneEndDate.GetValue();
        }

        public string GetWorkdayLabelValue()
        {
            return WorkdayCalendarLabel.GetLabelTextValue();
        }      

        #endregion

        #region private method
        private ComboBox GetOneSpecialDateTypeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxWorkdayCalendarSpecialDateType, positionIndex);
        }

        private ComboBox GetOneStartMonthComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxWorkdayCalendarStartMonth, positionIndex);
        }

        private ComboBox GetOneStartDateComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxWorkdayCalendarStartDate, positionIndex);
        }

        private ComboBox GetOneEndMonthComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxWorkdayCalendarEndMonth, positionIndex);
        }

        private ComboBox GetOneEndDateComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxWorkdayCalendarEndDate, positionIndex);
        }

        private Button GetOneDeleteRangeItemButton(int positionIndex)
        {
            return JazzButton.GetOneButton(JazzControlLocatorKey.ButtonWorkdayDeleteRangeItem, positionIndex);
        }

        #endregion
    }
}
