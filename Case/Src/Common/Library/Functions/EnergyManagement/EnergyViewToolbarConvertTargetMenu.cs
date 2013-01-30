using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    internal class EnergyViewToolbarConvertTargetMenu
    {
        private static MenuButton ConvertTargetButton = JazzButton.EnergyViewConvertTargetMenuButton;

        private static Dictionary<CarbonConvertTarget, string[]> MenuItems = new Dictionary<CarbonConvertTarget, string[]>()
        {
            {CarbonConvertTarget.StandardCoal,new string[]{"标煤"}},
            {CarbonConvertTarget.CO2,new string[]{"二氧化碳"}},
            {CarbonConvertTarget.Tree,new string[]{"树"}},
        };

        internal EnergyViewToolbarConvertTargetMenu() { }

        public void SwitchMenuItem(CarbonConvertTarget target)
        {
            ConvertTargetButton.SelectItem(MenuItems[target]);
        }
    }

    public enum CarbonConvertTarget
    { 
        StandardCoal,
        CO2,
        Tree,
    }

}
