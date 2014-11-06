using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;
using System.Collections;

namespace Mento.ScriptCommon.Library.Functions
{
    internal class EnergyViewToolbarMoreMenu
    {
        private static MenuButton MoreButton = JazzButton.EnergyViewMoreButton;
        private static MenuButton LabellingIndustryConvertButton = JazzButton.LabellingIndustryConvertMenuButton;
        private static MenuButton IndustryConvertTargetButton = JazzButton.IndustryConvertMenuButton;
        private static MenuButton CarbonIndustryConvertTargetButton = JazzButton.CarbonIndustryConvertMenuButton;
        private static MenuButton UnitTypeConvertTargetButton = JazzButton.UnitTypeConvertMenuButton;
        public static string MenuButtonCarbonIndustryConvert = "MenuButtonCarbonIndustryConvert";

        #region more button
        
        private static Dictionary<EnergyViewMoreOption, string[]> MenuItems = new Dictionary<EnergyViewMoreOption, string[]>()
        {
            {EnergyViewMoreOption.Last7Days,new string[]{"$@Common.Button.DefaultDate","$@Common.DateRange.Last7Day"}},
            {EnergyViewMoreOption.Last30Day,new string[]{"$@Common.Button.DefaultDate","$@Common.DateRange.Last30Day"}},
            {EnergyViewMoreOption.Last12Month,new string[]{"$@Common.Button.DefaultDate","$@Common.DateRange.Last12Month"}},
            {EnergyViewMoreOption.Today,new string[]{"$@Common.Button.DefaultDate","$@Common.DateRange.Today"}},
            {EnergyViewMoreOption.Yesterday,new string[]{"$@Common.Button.DefaultDate","$@Common.DateRange.Yesterday"}},
            {EnergyViewMoreOption.ThisWeek,new string[]{"$@Common.Button.DefaultDate","$@Common.DateRange.ThisWeek"}},
            {EnergyViewMoreOption.LastWeek,new string[]{"$@Common.Button.DefaultDate","$@Common.DateRange.LastWeek"}},
            {EnergyViewMoreOption.ThisMonth,new string[]{"$@Common.Button.DefaultDate","$@Common.DateRange.ThisMonth"}},
            {EnergyViewMoreOption.LastMonth,new string[]{"$@Common.Button.DefaultDate","$@Common.DateRange.LastMonth"}},
            {EnergyViewMoreOption.ThisYear,new string[]{"$@Common.Button.DefaultDate","$@Common.DateRange.ThisYear"}},
            {EnergyViewMoreOption.LastYear,new string[]{"$@Common.Button.DefaultDate","$@Common.DateRange.LastYear"}},

            {EnergyViewMoreOption.ToDashboard,new string[]{"$@Common.Button.ToDashboard"}},
            {EnergyViewMoreOption.DeleteAll,new string[]{"$@Common.Button.DeleteAll"}},

            {EnergyViewMoreOption.ShowCalendarNon,new string[]{"$@Common.Button.ShowCalendar", "$@Common.Button.Calendar.ShowNone"}},
            {EnergyViewMoreOption.ShowCalendarNonWorkday,new string[]{"$@Common.Button.ShowCalendar", "$@Common.Button.Calendar.ShowHoliday"}},
            {EnergyViewMoreOption.ShowCalendarHeatCool,new string[]{"$@Common.Button.ShowCalendar", "$@Common.Button.Calendar.ShowHC"}},
        };
        private static EnergyViewToolbarConvertTargetMenu ConvertTargetButton = new EnergyViewToolbarConvertTargetMenu();
        internal EnergyViewToolbarMoreMenu() { }

        public void SwitchMenuItem(EnergyViewMoreOption moreOption)
        {
            MoreButton.SelectItem(MenuItems[moreOption]);
        }

        public bool IsMenuItemDisabled(string text)
        {
            return MoreButton.IsMenuItemDisabled(text);
        }

        public void OpenMoreButton()
        {
            MoreButton.Open();
        }

        #endregion

        #region Labelling industry menu button
        
        public void OpenIndustryConvertButton()
        {
            LabellingIndustryConvertButton.Open();
        }

        public void SwitchLabellingIndustryMenuItem(string[] menuItems)
        {
            LabellingIndustryConvertButton.SelectItemLabelling(menuItems);
        }

        public void SwitchCustomerLabellingMenuItem(string[] menuItems)
        {
            LabellingIndustryConvertButton.SelectItemLabelling(menuItems);
        }

        public ArrayList GetLabellingSecondLevelMenuItem(string menuItems)
        {
            return LabellingIndustryConvertButton.GetSecondLevelMenuListItems(menuItems);
        }

        public ArrayList GetBenchmarkMenuItemsList(string buttonType)
        {
            if("Carbon" == buttonType)
                return CarbonIndustryConvertTargetButton.GetBenchmarkMenulistItems();
            else
                return IndustryConvertTargetButton.GetBenchmarkMenulistItems();
        }

        public ArrayList GetUnitTypeMenuItemsList()
        {
            return UnitTypeConvertTargetButton.GetUnitTypeMenulistItems();
        }

        public string GetLabellingIndustryValue()
        {
            return LabellingIndustryConvertButton.GetText();
        }
        #endregion
    }

    public enum EnergyViewMoreOption
    {
        Last7Days,
        Last30Day,
        Last12Month,
        Today,
        Yesterday,
        ThisWeek,
        LastWeek,
        ThisMonth,
        LastMonth,
        ThisYear,
        LastYear,

        ToDashboard,

        ShowCalendarNon,
        ShowCalendarNonWorkday,
        ShowCalendarHeatCool,

        DeleteAll,
    }

}
