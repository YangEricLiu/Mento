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
    public class TimeSettingsWorktime
    {
        internal TimeSettingsWorktime()
        {
        }

        //private static Grid PTagList = JazzGrid.PTagSettingsPTagList;

        private static Button CreateWorktimeCalendarButton = JazzButton.WorktimeCalendarCreateButton;

        private static Button ModifyButton = JazzButton.WorktimeCalendarModifyButton;
        private static Button SaveButton = JazzButton.WorktimeCalendarSaveButton;
        private static Button CancelButton = JazzButton.WorktimeCalendarCancelButton;
        private static Button DeleteButton = JazzButton.WorktimeCalendarDeleteButton;

        private static TextField NameTextField = JazzTextField.WorktimeCalendarNameTextField;
        private static LinkButton AddMoreRangesButton = JazzButton.WorktimeCalendarAddMoreRangesButton;
        private static ComboBox StartTimeComboBox = JazzComboBox.WorktimeCalendarStartTimeComboBox;
        private static ComboBox EndTimeComboBox = JazzComboBox.WorktimeCalendarEndTimeComboBox;
        private static Label WorktimeCalendarLabel = JazzLabel.PlatformWorktimeCalendarLabel;
        
        /// <summary>
        /// Navigate to Worktime Calendar Setting Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToWorktimeCalendarSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorktime);
            //TimeManager.ShortPause();
        }

        /// <summary>
        /// Click "add worktime" button to add one workday calendar
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void PrepareToAddWorktimeCalendar()
        {
            CreateWorktimeCalendarButton.Click();
        }
        
        /// <summary>
        /// Click "add more ranges" button
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

        public string GetWorktimeLabelValue()
        {
            return WorktimeCalendarLabel.GetLabelTextValue();
        }

        public Boolean IsWorktimeCalendarTextCorrect(string[] texts)
        {
            return WorktimeCalendarLabel.IsLabelTextsExisted(texts);
        }

        #region private method

        private ComboBox GetOneStartTimeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxWorktimeCalendarStartTime, positionIndex);
        }

        private ComboBox GetOneEndTimeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxWorktimeCalendarEndTime, positionIndex);
        }
        #endregion
    }
}
