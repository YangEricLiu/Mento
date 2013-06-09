﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of Hierarchy Property Settings.
    /// </summary>
    public class HierarchyCalendarSettings
    {
        internal HierarchyCalendarSettings()
        {
        }

        #region Controls
        private static TabButton CalendarTab = JazzButton.CalendarPropertyTabButton;
        private static Button CalendarCreate = JazzButton.CalendarCreateButton;
        private static Button CalendarUpdate = JazzButton.CalendarUpdateButton;
        private static Button WorkdayCreate = JazzButton.WorkdayCreateButton;
        private static Button HeatingCoolingCreate = JazzButton.HeatingCoolingCreateButton;
        private static Button DayNightCreate = JazzButton.DayNightCreateButton;
        private static Button CalendarSave = JazzButton.CalendarSaveButton;
        private static Button CalendarCancel = JazzButton.CalendarCancelButton;
        private static ComboBox WorkdayEffectiveYearAdd = JazzComboBox.WorkdayEffectiveYearComboBox;
        private static ComboBox WorkdayCalendarNameAdd = JazzComboBox.WorkdayCalendarNameComboBox;
        private static ComboBox WorktimeCalendarName = JazzComboBox.WorktimeCalendarNameComboBox;
        private static ComboBox HeatingCoolingEffectiveYearAdd = JazzComboBox.HeatingCoolingEffectiveYearComboBox;
        private static ComboBox HeatingCoolingCalendarNameAdd = JazzComboBox.HeatingCoolingCalendarNameComboBox;
        private static ComboBox DayNightEffectiveYearAdd = JazzComboBox.DayNightEffectiveYearComboBox;
        private static ComboBox DayNightCalendarNameAdd = JazzComboBox.DayNightCalendarNameComboBox;
        private static LinkButton WorktimeAddCreate = JazzButton.WorktimeCreateButton;
        private static Label WorkdayCalendar = JazzLabel.WorkdayCalendarLabel;
        private static Label WorktimeCalendar = JazzLabel.WorktimeCalendarLabel;
        private static Label HeatingCoolingCalendar = JazzLabel.HeatingCoolingCalendarLabel;
        private static Label DayNightCalendar = JazzLabel.DayNightCalendarLabel;
        private static Container WorkdayErrorTips = JazzContainer.WorkdayErrorTipsContainer;
        private static Container HCErrorTips = JazzContainer.HCErrorTipsContainer;
        private static Container DayNightErrorTips = JazzContainer.DayNightErrorTipsContainer;
        #endregion

        #region Calendar 
        public void ClickCalendarTab()
        {
            CalendarTab.Click();
        }

        public bool IsCalendarTabEnable()
        {
            return CalendarTab.IsEnabled();
        }

        public void ClickCreateCalendarButton()
        {
            if (CalendarCreate.IsDisplayed())
            {
                CalendarCreate.Click();
            }
            else if (CalendarUpdate.IsDisplayed())
            {
                CalendarUpdate.Click();
            }
        }

        public bool IsCreateCalendarButtonDisplayed()
        {
            return CalendarCreate.IsDisplayed();
        }

        public void ClickSaveCalendarButton()
        {
            CalendarSave.Click();
        }

        public void ClickCancelCalendarButton()
        {
            CalendarCancel.Click();
        }
        #endregion

        #region Workday property
        public void ClickWorkdayCreateButton()
        {
            WorkdayCreate.Click();
        }

        /// <summary>
        /// Input Workday Calendar value
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInWorkdayCalendarValue(CalendarPropertInputData input)
        {
            SelectWorkdayEffectiveYear(input.WorkdayEffectiveDate);
            SelectWorkdayCalendarName(input.WorkdayCalendarName);

            if (!String.IsNullOrEmpty(input.WorktimeCalendarName))
            {
                WorktimeCalendarName.SelectItem(input.WorktimeCalendarName);
            }
        }

        public void FillInWorkdayCalendarValue_N(CalendarPropertInputData input, int position)
        {
            SelectWorkdayEffectiveYear_N(input.WorkdayEffectiveDate, position);
            SelectWorkdayCalendarName_N(input.WorkdayCalendarName, position);

            if (!String.IsNullOrEmpty(input.WorktimeCalendarName))
            {
                WorktimeCalendarName.SelectItem(input.WorktimeCalendarName);
            }
        }

        public void SelectWorkdayEffectiveYear(string year)
        {
            WorkdayEffectiveYearAdd.SelectItem(year);
        }

        public void SelectWorkdayCalendarName(string calendarName)
        {
            WorkdayCalendarNameAdd.SelectItem(calendarName);
        }

        public void SelectWorkdayEffectiveYear_N(string year, int position)
        {
            ComboBox OneWorkdayEffectiveYearAdd = GetOneWorkdayEffectiveYearComboBox(position);

            OneWorkdayEffectiveYearAdd.SelectItem(year);
        }

        public bool IsWorkdayEffectiveYearInvalid_N(int position)
        { 
            ComboBox OneWorkdayEffectiveYearAdd = GetOneWorkdayEffectiveYearComboBox(position);

            return OneWorkdayEffectiveYearAdd.IsComboBoxValueInvalid();
        }

        public bool IsWorkdayEffectiveYearInvalidMsgCorrect_N(string msg, int position)
        {
            ComboBox OneWorkdayEffectiveYearAdd = GetOneWorkdayEffectiveYearComboBox(position);

            return OneWorkdayEffectiveYearAdd.GetInvalidTips().Contains(msg);
        }

        public void SelectWorkdayCalendarName_N(string calendarName, int position)
        {
            ComboBox OneWorkdayCalendarNameAdd = GetOneWorkdayCalendarNameComboBox(position);

            OneWorkdayCalendarNameAdd.SelectItem(calendarName);
        }

        public bool IsWorkdayCalendarNameInvalid_N(int position)
        {
            ComboBox OneWorkdayCalendarNameAdd = GetOneWorkdayCalendarNameComboBox(position);

            return OneWorkdayCalendarNameAdd.IsComboBoxValueInvalid();
        }

        public bool IsWorkdayCalendarNameInvalidMsgCorrect_N(string msg, int position)
        {
            ComboBox OneWorkdayCalendarNameAdd = GetOneWorkdayCalendarNameComboBox(position);

            return OneWorkdayCalendarNameAdd.GetInvalidTips().Contains(msg);
        }

        public void ClickAddWorktimeLinkButton()
        {
            WorktimeAddCreate.ClickLink();
        }

        public void SelectWorktimeCalendarName(string calendarName)
        {
            WorktimeCalendarName.SelectItem(calendarName);
        }

        public void SelectWorktimeCalendarName_N(string calendarName, int position)
        {
            ComboBox OneWorktimeCalendarName = GetOneWorktimeCalendarNameComboBox(position);

            OneWorktimeCalendarName.SelectItem(calendarName);
        }

        public bool IsWorktimeCalendarNameInvalid_N(int position)
        {
            ComboBox OneWorktimeCalendarName = GetOneWorktimeCalendarNameComboBox(position);

            return OneWorktimeCalendarName.IsComboBoxValueInvalid();
        }

        public bool IsWorktimeCalendarNameInvalidMsgCorrect_N(string msg, int position)
        {
            ComboBox OneWorktimeCalendarName = GetOneWorktimeCalendarNameComboBox(position);

            return OneWorktimeCalendarName.GetInvalidTips().Contains(msg);
        }

        public string GetWorktimeCalendarNameValue()
        {
            return WorktimeCalendarName.GetValue();
        }

        public string GetWorkdayEffectiveYearValue()
        {
            return WorkdayEffectiveYearAdd.GetValue();
        }

        public string GetWorkdayCalendarNameValue()
        {
            return WorkdayCalendarNameAdd.GetValue();
        }

        public string GetWorkdayLabelValue()
        {
            return WorkdayCalendar.GetLabelTextValue();
        }

        public Boolean IsWorkdayCalendarTextCorrect(string[] texts)
        {
            return WorkdayCalendar.IsLabelTextsExisted(texts);
        }

        public Boolean IsWorktimeCalendarTextCorrect(string[] texts)
        {
            return WorktimeCalendar.IsLabelTextsExisted(texts);
        }

        public string GetWorkdayContainerErrorTips()
        {
            return WorkdayErrorTips.GetContainerErrorTips();
        }
        #endregion

        #region HeatingCooling property
        public void ClickHeatingCoolingCreateButton()
        {
            HeatingCoolingCreate.Click();
        }

        /// <summary>
        /// Input Workday Calendar value
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInHeatingCoolingCalendarValue(CalendarPropertInputData input)
        {
            HeatingCoolingEffectiveYearAdd.SelectItem(input.HeatingCoolingEffectiveDate);
            HeatingCoolingCalendarNameAdd.SelectItem(input.HeatingCoolingCalendarName);
        }

        public void FillInHeatingCoolingCalendarValue_N(CalendarPropertInputData input, int position)
        {
            SelectHeatingCoolingEffectiveYear_N(input.HeatingCoolingEffectiveDate, position);
            SelectHeatingCoolingCalendarName_N(input.HeatingCoolingCalendarName, position);
        }

        public void SelectHeatingCoolingEffectiveYear(string year)
        {
            HeatingCoolingEffectiveYearAdd.SelectItem(year);
        }

        public void SelectHeatingCoolingCalendarName(string calendarName)
        {
            HeatingCoolingCalendarNameAdd.SelectItem(calendarName);
        }

        public void SelectHeatingCoolingEffectiveYear_N(string year, int position)
        {
            ComboBox OneHeatingCoolingEffectiveYearAdd = GetOneHeatingCoolingEffectiveYearComboBox(position);

            OneHeatingCoolingEffectiveYearAdd.SelectItem(year);
        }

        public bool IsHCEffectiveYearInvalid_N(int position)
        {
            ComboBox OneHeatingCoolingEffectiveYearAdd = GetOneHeatingCoolingEffectiveYearComboBox(position);

            return OneHeatingCoolingEffectiveYearAdd.IsComboBoxValueInvalid();
        }

        public bool IsHCEffectiveYearInvalidMsgCorrect_N(string msg, int position)
        {
            ComboBox OneHeatingCoolingEffectiveYearAdd = GetOneHeatingCoolingEffectiveYearComboBox(position);

            return OneHeatingCoolingEffectiveYearAdd.GetInvalidTips().Contains(msg);
        }

        public void SelectHeatingCoolingCalendarName_N(string calendarName, int position)
        {
            ComboBox OneHeatingCoolingCalendarNameAdd = GetOneHeatingCoolingCalendarNameComboBox(position);

            OneHeatingCoolingCalendarNameAdd.SelectItem(calendarName);
        }

        public bool IsHCCalendarNameInvalid_N(int position)
        {
            ComboBox OneHeatingCoolingCalendarNameAdd = GetOneHeatingCoolingCalendarNameComboBox(position);

            return OneHeatingCoolingCalendarNameAdd.IsComboBoxValueInvalid();
        }

        public bool IsHCCalendarNameInvalidMsgCorrect_N(string msg, int position)
        {
            ComboBox OneHeatingCoolingCalendarNameAdd = GetOneHeatingCoolingCalendarNameComboBox(position);

            return OneHeatingCoolingCalendarNameAdd.GetInvalidTips().Contains(msg);
        }

        public string GetHeatingCoolingEffectiveYearValue()
        {
            return HeatingCoolingEffectiveYearAdd.GetValue();
        }

        public string GetHeatingCoolingCalendarNameValue()
        {
            return HeatingCoolingCalendarNameAdd.GetValue();
        }

        public string GetHeatingCoolingLabelValue()
        {
            return HeatingCoolingCalendar.GetLabelTextValue();
        }

        public Boolean IsHeatingCoolingCalendarTextCorrect(string[] texts)
        {
            return HeatingCoolingCalendar.IsLabelTextsExisted(texts);
        }

        public string GetHCContainerErrorTips()
        {
            return HCErrorTips.GetContainerErrorTips();
        }
        #endregion

        #region DayNight property
        public void ClickDayNightCreateButton()
        {
            DayNightCreate.Click();
        }

        /// <summary>
        /// Input DayNight Calendar value
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInDayNightCalendarValue(CalendarPropertInputData input)
        {
            DayNightEffectiveYearAdd.SelectItem(input.DayNightEffectiveDate);
            DayNightCalendarNameAdd.SelectItem(input.DayNightCalendarName);
        }

        public void FillInDayNightCalendarValue_N(CalendarPropertInputData input, int position)
        {
            SelectDayNightEffectiveYear_N(input.DayNightEffectiveDate, position);
            SelectDayNightCalendarName_N(input.DayNightCalendarName, position);
        }

        public void SelectDayNightEffectiveYear(string year)
        {
            DayNightEffectiveYearAdd.SelectItem(year);
        }

        public void SelectDayNightCalendarName(string calendarName)
        {
            DayNightCalendarNameAdd.SelectItem(calendarName);
        }

        public void SelectDayNightEffectiveYear_N(string year, int position)
        {
            ComboBox OneDayNightEffectiveYearAdd = GetOneDayNightEffectiveYearComboBox(position);

            OneDayNightEffectiveYearAdd.SelectItem(year);
        }

        public bool IsDayNightEffectiveYearInvalid_N(int position)
        {
            ComboBox OneDayNightEffectiveYearAdd = GetOneDayNightEffectiveYearComboBox(position);

            return OneDayNightEffectiveYearAdd.IsComboBoxValueInvalid();
        }

        public bool IsDayNightEffectiveYearInvalidMsgCorrect_N(string msg, int position)
        {
            ComboBox OneDayNightEffectiveYearAdd = GetOneDayNightEffectiveYearComboBox(position);

            return OneDayNightEffectiveYearAdd.GetInvalidTips().Contains(msg);
        }

        public void SelectDayNightCalendarName_N(string calendarName, int position)
        {
            ComboBox OneDayNightCalendarNameAdd = GetOneDayNightCalendarNameComboBox(position);

            OneDayNightCalendarNameAdd.SelectItem(calendarName);
        }

        public bool IsDayNightCalendarNameInvalid_N(int position)
        {
            ComboBox OneDayNightCalendarNameAdd = GetOneDayNightCalendarNameComboBox(position);

            return OneDayNightCalendarNameAdd.IsComboBoxValueInvalid();
        }

        public bool IsDayNightCalendarNameInvalidMsgCorrect_N(string msg, int position)
        {
            ComboBox OneDayNightCalendarNameAdd = GetOneDayNightCalendarNameComboBox(position);

            return OneDayNightCalendarNameAdd.GetInvalidTips().Contains(msg);
        }

        public string GetDayNightEffectiveYearValue()
        {
            return DayNightEffectiveYearAdd.GetValue();
        }

        public string GetDayNightCalendarNameValue()
        {
            return DayNightCalendarNameAdd.GetValue();
        }

        public string GetDayNightLabelValue()
        {
            return DayNightCalendar.GetLabelTextValue();
        }

        public Boolean IsDayNightCalendarTextCorrect(string[] texts)
        {
            return DayNightCalendar.IsLabelTextsExisted(texts);
        }

        public string GetDayNightContainerErrorTips()
        {
            return DayNightErrorTips.GetContainerErrorTips();
        }
        #endregion

        #region private method
        private ComboBox GetOneWorkdayEffectiveYearComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxWorkdayEffectiveYear, positionIndex);
        }

        private ComboBox GetOneWorkdayCalendarNameComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxWorkdayCalendarName, positionIndex);
        }

        private ComboBox GetOneWorktimeCalendarNameComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxWorktimeCalendarName, positionIndex);
        }


        private ComboBox GetOneHeatingCoolingEffectiveYearComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxHeatingCoolingEffectiveYear, positionIndex);
        }

        private ComboBox GetOneHeatingCoolingCalendarNameComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxHeatingCoolingCalendarName, positionIndex);
        }

        private ComboBox GetOneDayNightEffectiveYearComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxDayNightEffectiveYear, positionIndex);
        }

        private ComboBox GetOneDayNightCalendarNameComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxDayNightCalendarName, positionIndex);
        }
        #endregion
    }
}
