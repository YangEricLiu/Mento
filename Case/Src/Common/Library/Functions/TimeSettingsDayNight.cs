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
        private static LinkButton AddMoreRangesButton = JazzButton.DayNightCalendarAddMoreRangesButton;
        private static ComboBox StartTimeComboBox = JazzComboBox.DayNightCalendarStartTimeComboBox;
        private static ComboBox EndTimeComboBox = JazzComboBox.DayNightCalendarEndTimeComboBox;
        private static Label DayNightCalendarLabel = JazzLabel.PlatformDayNightCalendarLabel;
        
        /// <summary>
        /// Navigate to DayNight Calendar Setting Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToDaynightCalendarSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsDaynight);
            //TimeManager.ShortPause();
        }

        /// <summary>
        /// Click "add daynight calendar" button to add one daynight calendar
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void PrepareToAddDaynightCalendar()
        {
            CreateDaynightCalendarButton.Click();
        }
        
        /// <summary>
        /// Click "add more ranges" button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickAddMoreRangesButton()
        {
            AddMoreRangesButton.ClickLink();             
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

        /// <summary>
        /// Get Start Time value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetStartTimeValue(int num)
        {
            ComboBox OneStartTime = GetOneStartTimeComboBox(num);
            return OneStartTime.GetValue();
        }

        /// <summary>
        /// Get End Time value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetEndTimeValue(int num)
        {
            ComboBox OneEndTime = GetOneEndTimeComboBox(num);
            return OneEndTime.GetValue();
        }

        public string GetDayNightLabelValue()
        {
            return DayNightCalendarLabel.GetLabelTextValue();
        }

        public Boolean IsDayNightCalendarTextCorrect(string[] texts)
        {
            return DayNightCalendarLabel.IsLabelTextsExisted(texts);
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
