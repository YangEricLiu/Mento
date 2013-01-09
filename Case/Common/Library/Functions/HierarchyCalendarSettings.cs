using System;
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
        private static Button WorkdayCreate = JazzButton.WorkdayCreateButton;
        private static Button HeatingCoolingCreate = JazzButton.HeatingCoolingCreateButton;
        private static Button DayNightCreate = JazzButton.DayNightCreateButton;
        private static Button CalendarSave = JazzButton.CalendarSaveButton;
        private static ComboBox WorkdayEffectiveYearAdd = JazzComboBox.WorkdayEffectiveYearComboBox;
        private static ComboBox WorkdayCalendarNameAdd = JazzComboBox.WorkdayCalendarNameComboBox;
        private static ComboBox HeatingCoolingEffectiveYearAdd = JazzComboBox.HeatingCoolingEffectiveYearComboBox;
        private static ComboBox HeatingCoolingCalendarNameAdd = JazzComboBox.HeatingCoolingCalendarNameComboBox;
        private static ComboBox DayNightEffectiveYearAdd = JazzComboBox.DayNightEffectiveYearComboBox;
        private static ComboBox DayNightCalendarNameAdd = JazzComboBox.DayNightCalendarNameComboBox;
        private static LinkButton WorktimeAddCreate = JazzButton.WorktimeCreateButton;
        private static Label WorkdayCalendar = JazzLabel.WorkdayCalendarLabel;
        private static Label HeatingCoolingCalendar = JazzLabel.HeatingCoolingCalendarLabel;
        private static Label DayNightCalendar = JazzLabel.DayNightCalendarLabel;
        #endregion

        #region Calendar 
        public void ClickCalendarTab()
        {
            CalendarTab.Click();
        }

        public void ClickCreateCalendarButton()
        {
            CalendarCreate.Click();
        }

        public void ClickSaveCalendarButton()
        {
            CalendarSave.Click();
        }
        #endregion

        #region Workday property
        public void ClickWorkdayCreateButton()
        {
            WorkdayCreate.Click();
        }

        public void SelectWorkdayEffectiveYear(string year)
        {
            WorkdayEffectiveYearAdd.SelectItem(year);
        }

        public void SelectWorkdayCalendarName(string calendarName)
        {
            WorkdayCalendarNameAdd.SelectItem(calendarName);
        }

        public void SelectWorkdayEffectiveYear(string year, int num)
        {
            ComboBox OneWorkdayEffectiveYearAdd = GetOneWorkdayEffectiveYearComboBox(num);

            OneWorkdayEffectiveYearAdd.SelectItem(year);
        }

        public void SelectWorkdayCalendarName(string calendarName, int num)
        {
            ComboBox OneWorkdayCalendarNameAdd = GetOneWorkdayCalendarNameComboBox(num);

            OneWorkdayCalendarNameAdd.SelectItem(calendarName);
        }

        public void ClickAddWorktimeLinkButton()
        {
            WorktimeAddCreate.Click();
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
        #endregion

        #region HeatingCooling property
        public void ClickHeatingCoolingCreateButton()
        {
            HeatingCoolingCreate.Click();
        }

        public void SelectHeatingCoolingEffectiveYear(string year)
        {
            HeatingCoolingEffectiveYearAdd.SelectItem(year);
        }

        public void SelectHeatingCoolingCalendarName(string calendarName)
        {
            HeatingCoolingCalendarNameAdd.SelectItem(calendarName);
        }

        public void SelectHeatingCoolingEffectiveYear(string year, int num)
        {
            ComboBox OneHeatingCoolingEffectiveYearAdd = GetOneHeatingCoolingEffectiveYearComboBox(num);

            OneHeatingCoolingEffectiveYearAdd.SelectItem(year);
        }

        public void SelectHeatingCoolingCalendarName(string calendarName, int num)
        {
            ComboBox OneHeatingCoolingCalendarNameAdd = GetOneHeatingCoolingCalendarNameComboBox(num);

            OneHeatingCoolingCalendarNameAdd.SelectItem(calendarName);
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
        #endregion

        #region DayNight property
        public void ClickDayNightCreateButton()
        {
            DayNightCreate.Click();
        }

        public void SelectDayNightEffectiveYear(string year)
        {
            DayNightEffectiveYearAdd.SelectItem(year);
        }

        public void SelectDayNightCalendarName(string calendarName)
        {
            DayNightCalendarNameAdd.SelectItem(calendarName);
        }

        public void SelectDayNightEffectiveYear(string year, int num)
        {
            ComboBox OneDayNightEffectiveYearAdd = GetOneDayNightEffectiveYearComboBox(num);

            OneDayNightEffectiveYearAdd.SelectItem(year);
        }

        public void SelectDayNightCalendarName(string calendarName, int num)
        {
            ComboBox OneDayNightCalendarNameAdd = GetOneDayNightCalendarNameComboBox(num);

            OneDayNightCalendarNameAdd.SelectItem(calendarName);
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
