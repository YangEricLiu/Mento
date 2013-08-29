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

        #region Controls
        private static Grid CalendarsList = JazzGrid.CalendarsList;

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
        private static Container CalendarItemsContainer = JazzContainer.CalendarItemsContainer;

        #endregion

        #region common action
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
        /// Click "add worktime" button to add one worktime calendar
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void PrepareToAddWorktimeCalendar()
        {
            CreateWorktimeCalendarButton.Click();
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
        /// Fill in name field
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInName(string name)
        {
            NameTextField.Fill(name);
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

        public void AddTimeRanges(WorktimeCalendarData testData)
        {
            for (int elementPosition = 1; elementPosition <= testData.InputData.TimeRange.Length; elementPosition++)
            {
                //Click '添加工作时间' button if more than one record need to be entered
                if (elementPosition > 1)
                {
                    ClickAddMoreRangesButton();
                    TimeManager.ShortPause();
                }

                int inputDataArrayPosition = elementPosition - 1;
                SelectStartTime(testData.InputData.TimeRange[inputDataArrayPosition].StartTime, elementPosition);
                SelectEndTime(testData.InputData.TimeRange[inputDataArrayPosition].EndTime, elementPosition);
                TimeManager.ShortPause();
            }            
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

        public void ClickDeleteRangeItemButton(int num)
        {
            Button OneDeleteRangeIcon = GetOneDeleteRangeItemButton(num);
            OneDeleteRangeIcon.Click();
        }
        #endregion

        #region verification
        public Boolean IsWorktimeCalendarTextCorrect(string[] texts)
        {
            return WorktimeCalendarLabel.IsLabelTextsExisted(texts);
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

        public Boolean IsNameInvalidMsgCorrect(WorktimeCalendarExpectedData output)
        {
            if (output.CommonName != null)
            {
                return NameTextField.GetInvalidTips().Contains(output.CommonName);
            }
            else
                return true;
        }

        public Boolean IsRangeInvalidMsgCorrect(WorktimeCalendarExpectedData output, int position)
        {
            int arrayPosition = position - 1;
            ComboBox OneStartTimeComboBox = GetOneStartTimeComboBox(position);
            if (output.TimeRange != null)
            {
                return OneStartTimeComboBox.GetInvalidTips().Contains(output.TimeRange[arrayPosition].StartTime);
            }
            else
                return true;
        }

        /// <summary>
        /// Judge whether the pop message correct
        /// </summary>
        /// <param name="output">TOUBasicTariffExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsPopMsgCorrect(WorktimeCalendarExpectedData output)
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
        /// Get the number of the time ranges
        /// </summary>
        /// <returns></returns>
        public int GetTimeRangeItemsNumber()
        {
            return CalendarItemsContainer.GetElementNumber();
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
        #endregion

        #region private method

        private ComboBox GetOneStartTimeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxWorktimeCalendarStartTime, positionIndex);
        }

        private ComboBox GetOneEndTimeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxWorktimeCalendarEndTime, positionIndex);
        }

        private Button GetOneDeleteRangeItemButton(int positionIndex)
        {
            return JazzButton.GetOneButton(JazzControlLocatorKey.ButtonWorktimeDeleteRangeItem, positionIndex);
        }
        #endregion
    }
}
