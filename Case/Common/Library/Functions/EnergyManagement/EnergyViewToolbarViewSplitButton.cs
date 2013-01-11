using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.EnergyView;

namespace Mento.ScriptCommon.Library.Functions
{
    internal class EnergyViewToolbarViewSplitButton
    {
        private static SplitButton ViewButton = JazzButton.EnergyViewViewDataButton;

        private static Dictionary<EnergyViewType, string[]> MenuItemDictionary = new Dictionary<EnergyViewType, string[]>()
        {
            {EnergyViewType.Line,new string[] { "趋势数据", "折线图" }},
            {EnergyViewType.Column,new string[] { "趋势数据", "柱状图" }},
            {EnergyViewType.List,new string[] { "趋势数据", "列表数据" }},
            {EnergyViewType.Distribute,new string[] { "分布数据" }},
        };

        //public EnergyViewType CurrentViewType
        //{
        //    get;
        //    set;
        //}

        public void Click()
        {
            ViewButton.Click();
        }

        public void SwitchViewType(EnergyViewType viewType)
        {
            ViewButton.Trigger();
            TimeManager.FlashPause();

            ViewButton.SelectItem(MenuItemDictionary[viewType]);
            //CurrentViewType = viewType;
        }
    }

}
