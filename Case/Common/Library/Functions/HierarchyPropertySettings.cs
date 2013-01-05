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
    public class HierarchyPropertySettings
    {
        internal HierarchyPropertySettings()
        {
        }

        private static TabButton CalendarTab = JazzButton.CalendarPropertyTabButton;
        private static Button CalendarCreate = JazzButton.CalendarCreateButton;
        private static Button WorkdayCreate = JazzButton.WorkdayCreateButton;
        private static Button HeatingCoolingCreate = JazzButton.HeatingCoolingCreateButton;
        private static Button DayNightCreate = JazzButton.DayNightCreateButton;
        private static ComboBox WorkdayEffectiveYearAdd = JazzComboBox.WorkdayEffectiveYearComboBox;
        private static ComboBox WorkdayCalendarNameAdd = JazzComboBox.WorkdayCalendarNameComboBox;
        private static LinkButton WorktimeAddCreate = JazzButton.WorktimeCreateButton;

        public void ClickCalendarTab()
        {
            CalendarTab.Click();
        }

        public void ClickCreateCalendarButton()
        {
            CalendarCreate.Click();
        }

        public void ClickWorkdayCreateButton()
        {
            WorkdayCreate.Click();
        }

        public void ClickHeatingCoolingCreateButton()
        {
            HeatingCoolingCreate.Click();
        }

        public void ClickDayNightCreateButton()
        {
            DayNightCreate.Click();
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

        #region private method
        private ComboBox GetOneWorkdayEffectiveYearComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxWorkdayEffectiveYear, positionIndex);
        }

        private ComboBox GetOneWorkdayCalendarNameComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxWorkdayCalendarName, positionIndex);
        }
        #endregion
    }
}
