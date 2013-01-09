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
    public class TimeSettingsDayNight
    {
        internal TimeSettingsDayNight()
        {
        }

        //private static Grid PTagList = JazzGrid.PTagSettingsPTagList;

        private static Button CreateDaynightCalendarButton = JazzButton.DayNightCalendarCreateButton;

        private static Button ModifyButton = JazzButton.DayNightCalendarModifyButton;
        private static Button SaveButton = JazzButton.DayNightCalendarSaveButton;
        private static Button CancelButton = JazzButton.DayNightCalendarCancelButton;
        private static Button DeleteButton = JazzButton.DayNightCalendarDeleteButton;

        private static TextField NameTextField = JazzTextField.DayNightCalendarNameTextField;
        private static Button AddMoreRangesButton = JazzButton.DayNightCalendarAddMoreRangesButton;
        private static ComboBox StartTimeComboBox = JazzComboBox.DayNightCalendarStartTimeComboBox;
        private static ComboBox EndTimeComboBox = JazzComboBox.DayNightCalendarEndTimeComboBox;
        
        /// <summary>
        /// Navigate to Workday Calendar Setting Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToDaynightCalendarSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsDaynight);
            //TimeManager.ShortPause();
        }

        /// <summary>
        /// Click "add workday" button to add one workday calendar
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void PrepareToAddDaynightCalendar()
        {
            CreateDaynightCalendarButton.Click();
        }
        
        /// <summary>
        /// Click "add special dates" icon
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickAddMoreRangesButton()
        {
            AddMoreRangesButton.Click();             
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
        /// Select Start Time from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectStartTime(string time, int num)
        {
            ComboBox OneStartTime = GetOneStartTimeComboBox(num);
            OneStartTime.SelectItem(time); 
        }

        /// <summary>
        /// Select End Time from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectEndTime(string time, int num)
        {
            ComboBox OneEndTime = GetOneEndTimeComboBox(num);
            OneEndTime.SelectItem(time);             
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

        #region private method

        private ComboBox GetOneStartTimeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxDayNightCalendarStartTime, positionIndex);
        }

        private ComboBox GetOneEndTimeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxDayNightCalendarEndTime, positionIndex);
        }
        #endregion
    }
}
