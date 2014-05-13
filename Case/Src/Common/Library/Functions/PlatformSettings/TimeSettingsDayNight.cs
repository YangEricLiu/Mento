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

        #region Controls
        private static Grid CalendarsList = JazzGrid.CalendarsList;

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
        private static Container CalendarItemsContainer = JazzContainer.CalendarItemsContainer;

        #endregion

        #region common action
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
        /// Click "add more ranges" button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickAddMoreRangesButton()
        {
            AddMoreRangesButton.ClickLink();             
        }

        public void AddTimeRanges(DayNightCalendarData testData)
        {
            for (int elementPosition = 1; elementPosition <= testData.InputData.TimeRange.Length; elementPosition++)
            {
                //Click '添加白昼时间' button if more than one record need to be entered
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

        public void ClickDeleteRangeItemButton(int num)
        {
            Button OneDeleteRangeIcon = GetOneDeleteRangeItemButton(num);
            OneDeleteRangeIcon.Click();
        }
        #endregion

        #region verification
        public Boolean IsWorktimeCalendarTextCorrect(string[] texts)
        {
            return DayNightCalendarLabel.IsLabelTextsExisted(texts);
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

        public Boolean IsNameInvalidMsgCorrect(DayNightCalendarExpectedData output)
        {
            if (output.CommonName != null)
            {
                return NameTextField.GetInvalidTips().Contains(output.CommonName);
            }
            else
                return true;
        }

        public Boolean IsRangeInvalidMsgCorrect(DayNightCalendarExpectedData output, int position)
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
        public Boolean IsPopMsgCorrect(DayNightCalendarExpectedData output)
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

        public string GetDayNightLabelValue()
        {
            return DayNightCalendarLabel.GetLabelTextValue();
        }

        public Boolean IsDayNightCalendarTextCorrect(string[] texts)
        {
            return DayNightCalendarLabel.IsLabelTextsExisted(texts);
        }

        #endregion

        #region private method

        private ComboBox GetOneStartTimeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxDayNightCalendarStartTime, positionIndex);
        }

        private ComboBox GetOneEndTimeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxDayNightCalendarEndTime, positionIndex);
        }

        private Button GetOneDeleteRangeItemButton(int positionIndex)
        {
            return JazzButton.GetOneButton(JazzControlLocatorKey.ButtonDayNightDeleteRangeItem, positionIndex);
        }
        #endregion
    }
}
