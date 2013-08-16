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
    public class EnergyViewToolbarViewSplitButton
    {
        private static SplitButton ViewButton = JazzButton.EnergyViewViewDataButton;
        private static SplitButton AddTimeSpanButton = JazzButton.EnergyViewAddTimeSpanButton;

        private static Dictionary<EnergyViewType, string[]> MenuItemDictionary = new Dictionary<EnergyViewType, string[]>()
        {
            {EnergyViewType.Line,new string[] { "折线图" }},
            {EnergyViewType.Column,new string[] { "柱状图" }},
            {EnergyViewType.List,new string[] { "数据表" }},
            {EnergyViewType.Distribute,new string[] { "饼状图" }},
        };

        private static Dictionary<TimeSpans, string[]> TimeSpanMenuItemDictionary = new Dictionary<TimeSpans, string[]>()
        {
            {TimeSpans.DeleteAllTimeSpans,new string[] { "删除全部对比时间段" }},
        };

        //public EnergyViewType CurrentViewType
        //{
        //    get;
        //    set;
        //}

        internal EnergyViewToolbarViewSplitButton() { }

        public void ClickView()
        {
            ViewButton.Click();
        }

        public bool IsMenuItemDisabled(string textName)
        {
            return AddTimeSpanButton.IsMenuItemDisabled(textName);
        }

        public void SwitchViewType(EnergyViewType viewType)
        {
            ViewButton.Trigger();
            TimeManager.FlashPause();

            ViewButton.SelectItem(MenuItemDictionary[viewType]);
            //CurrentViewType = viewType;
        }

        public void ClickTimeSpan()
        {
            AddTimeSpanButton.Click();
        }

        public bool IsTimeSpanButtonDisabled()
        {
            return AddTimeSpanButton.IsSplitButtonDisabled();
        }

        public void SwitchTimeSpans(TimeSpans span)
        {
            AddTimeSpanButton.Trigger();
            TimeManager.FlashPause();

            ViewButton.SelectItem(TimeSpanMenuItemDictionary[span]);
            //CurrentViewType = viewType;
        }
    }

}
