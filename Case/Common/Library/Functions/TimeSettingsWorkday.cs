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

        //private static Grid PTagList = JazzGrid.PTagSettingsPTagList;

        private static Button CreateWorkdayCalendarButton = JazzButton.WorkdayCalendarCreateButton;

        private static Button ModifyButton = JazzButton.WorkdayCalendarModifyButton;
        private static Button SaveButton = JazzButton.WorkdayCalendarSaveButton;
        private static Button CancelButton = JazzButton.WorkdayCalendarCancelButton;
        private static Button DeleteButton = JazzButton.WorkdayCalendarDeleteButton;

        private static TextField NameTextField = JazzTextField.WorkdayCalendarNameTextField;
        private static Button AddSpecialDateButton = JazzButton.WorkdayCalendarAddSpecialDatesButton;
        private static ComboBox SpecialDateTypeComboBox = JazzComboBox.WorkdayCalendarSpecialDateTypeComboBox;
        private static ComboBox StartMonthComboBox = JazzComboBox.WorkdayCalendarStartMonthComboBox;
        private static ComboBox StartDateComboBox = JazzComboBox.WorkdayCalendarStartDateComboBox;
        private static ComboBox EndMonthComboBox = JazzComboBox.WorkdayCalendarEndMonthComboBox;
        private static ComboBox EndDateComboBox = JazzComboBox.WorkdayCalendarEndDateComboBox;

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
        /// Click "add special dates" icon
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickAddSpecialDateButton()
        {
            AddSpecialDateButton.Click();             
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
        /// Input name, special date type, start month, start date, end month and end date of the special date range
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInWorkdayCalendar(WorkdayCalendarInputData input)
        {
            NameTextField.Fill(input.Name);            
        }
       
        /// <summary>
        /// Get the Name actual value
        /// </summary>
        /// <returns></returns>
        public string GetNameValue()
        {
            return NameTextField.GetValue();
        }

        public void FocusOnWorkdayCalendar(string workdayCalendarName)
        {
            //PTagList.FocusOnRow(1, workdayCalendarName);
        }

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

        #endregion
    }
}
