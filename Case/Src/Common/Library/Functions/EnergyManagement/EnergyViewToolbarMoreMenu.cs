using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;

namespace Mento.ScriptCommon.Library.Functions
{
    internal class EnergyViewToolbarMoreMenu
    {
        private static MenuButton MoreButton = JazzButton.EnergyViewMoreButton;

        private static Dictionary<EnergyViewMoreOption, string[]> MenuItems = new Dictionary<EnergyViewMoreOption, string[]>()
        {
            {EnergyViewMoreOption.Last7Days,new string[]{"默认时间","之前7天"}},
            {EnergyViewMoreOption.Today,new string[]{"默认时间","$@Common.DateRange.Today"}},
            {EnergyViewMoreOption.Yesterday,new string[]{"默认时间","$@Common.DateRange.Yesterday"}},
            {EnergyViewMoreOption.ThisWeek,new string[]{"默认时间","$@Common.DateRange.ThisWeek"}},
            {EnergyViewMoreOption.LastWeek,new string[]{"默认时间","$@Common.DateRange.LastWeek"}},
            {EnergyViewMoreOption.ThisMonth,new string[]{"默认时间","$@Common.DateRange.ThisMonth"}},
            {EnergyViewMoreOption.LastMonth,new string[]{"默认时间","$@Common.DateRange.LastMonth"}},
            {EnergyViewMoreOption.ThisYear,new string[]{"默认时间","$@Common.DateRange.ThisYear"}},
            {EnergyViewMoreOption.LastYear,new string[]{"默认时间","$@Common.DateRange.LastYear"}},

            {EnergyViewMoreOption.ToDashboard,new string[]{"至仪表盘"}},

            {EnergyViewMoreOption.ShowCalendarNon,new string[]{"显示日历", "无"}},
            {EnergyViewMoreOption.ShowCalendarNonWorkday,new string[]{"显示日历", "非工作时间"}},
            {EnergyViewMoreOption.ShowCalendarHeatCool,new string[]{"显示日历", "冷暖季"}},
        };

        internal EnergyViewToolbarMoreMenu() { }

        public void SwitchMenuItem(EnergyViewMoreOption moreOption)
        {
            MoreButton.SelectItem(MenuItems[moreOption]);
        }
    }

    public enum EnergyViewMoreOption
    {
        Last7Days,
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
    }

}
