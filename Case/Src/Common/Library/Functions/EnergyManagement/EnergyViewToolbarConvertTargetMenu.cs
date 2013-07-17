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
        private static MenuButton CarbonConvertTargetButton = JazzButton.EnergyViewConvertTargetMenuButton;
        private static MenuButton FuncModeConvertTargetButton = JazzButton.FuncModeConvertMenuButton;
        private static MenuButton TagModeConvertTargetButton = JazzButton.TagModeConvertMenuButton;
        private static MenuButton UnitTypeConvertTargetButton = JazzButton.UnitTypeConvertMenuButton;
        private static MenuButton RadioTypeConvertTargetButton = JazzButton.RadioTypeConvertMenuButton;
        private static MenuButton RankTypeConvertTargetButton = JazzButton.RankTypeConvertMenuButton;

        private static Dictionary<CarbonConvertTarget, string[]> CarbonMenuItems = new Dictionary<CarbonConvertTarget, string[]>()
        {
            {CarbonConvertTarget.StandardCoal,new string[]{"标煤"}},
            {CarbonConvertTarget.CO2,new string[]{"二氧化碳"}},
            {CarbonConvertTarget.Tree,new string[]{"树"}},
        };

        private static Dictionary<FuncModeConvertTarget, string[]> FuncModeMenuItems = new Dictionary<FuncModeConvertTarget, string[]>()
        {
            {FuncModeConvertTarget.Energy,new string[]{"能耗"}},
            {FuncModeConvertTarget.Carbon,new string[]{"碳排放"}},
            {FuncModeConvertTarget.Cost,new string[]{"成本"}},
        };

        private static Dictionary<TagModeConvertTarget, string[]> TagModeMenuItems = new Dictionary<TagModeConvertTarget, string[]>()
        {
            {TagModeConvertTarget.SingleHierarchyTag,new string[]{"单层级数据点"}},
            {TagModeConvertTarget.MultipleHierarchyTag,new string[]{"多层级数据点"}},
        };

        private static Dictionary<UnitTypeConvertTarget, string[]> UnitTypeMenuItems = new Dictionary<UnitTypeConvertTarget, string[]>()
        {
            {UnitTypeConvertTarget.UnitPopulation,new string[]{"单位人口"}},
            {UnitTypeConvertTarget.UnitArea,new string[]{"单位面积"}},
            {UnitTypeConvertTarget.UnitHeatArea,new string[]{"单位采暖面积"}},
            {UnitTypeConvertTarget.UnitCoolArea,new string[]{"单位供冷面积"}},
        };

        private static Dictionary<RadioTypeConvertTarget, string[]> RadioTypeMenuItems = new Dictionary<RadioTypeConvertTarget, string[]>()
        {
            {RadioTypeConvertTarget.DayNightRadio,new string[]{"昼夜比"}},
            {RadioTypeConvertTarget.WorkNonRadio,new string[]{"工休比"}},
        };

        private static Dictionary<RankTypeConvertTarget, string[]> RankTypeMenuItems = new Dictionary<RankTypeConvertTarget, string[]>()
        { 
            {RankTypeConvertTarget.TotalRank,new string[]{"总排名"}},
            {RankTypeConvertTarget.AverageRank,new string[]{"人均排名"}},
            {RankTypeConvertTarget.UnitAreaRank,new string[]{"单位面积排名"}},
            {RankTypeConvertTarget.UnitHeatAreaRank,new string[]{"单位采暖面积排名"}},
            {RankTypeConvertTarget.UnitCoolAreaRank,new string[]{"单位供冷面积排名"}},
        };

        internal EnergyViewToolbarConvertTargetMenu() { }

        public void SwitchCarbonMenuItem(CarbonConvertTarget target)
        {
            CarbonConvertTargetButton.SelectItem(CarbonMenuItems[target]);
        }

        public void SwitchFuncModeMenuItem(FuncModeConvertTarget target)
        {
            FuncModeConvertTargetButton.SelectItem(FuncModeMenuItems[target]);
        }

        public void SwitchTagModeMenuItem(TagModeConvertTarget target)
        {
            TagModeConvertTargetButton.SelectItem(TagModeMenuItems[target]);
        }

        public void SwitchUnitTypeMenuItem(UnitTypeConvertTarget target)
        {
            UnitTypeConvertTargetButton.SelectItem(UnitTypeMenuItems[target]);
        }

        public void SwitchRadioTypeMenuItem(RadioTypeConvertTarget target)
        {
            RadioTypeConvertTargetButton.SelectItem(RadioTypeMenuItems[target]);
        }

        public void SwitchRankTypeMenuItem(RankTypeConvertTarget target)
        {
            RankTypeConvertTargetButton.SelectItem(RankTypeMenuItems[target]);
        }
    }

    public enum CarbonConvertTarget
    { 
        StandardCoal,
        CO2,
        Tree,
    }

    public enum FuncModeConvertTarget
    { 
        Energy,
        Carbon,
        Cost,
    }

    public enum TagModeConvertTarget
    {
        SingleHierarchyTag,
        MultipleHierarchyTag,
    }

    public enum UnitTypeConvertTarget
    {
        UnitPopulation,
        UnitArea,
        UnitHeatArea,
        UnitCoolArea,
    }

    public enum RadioTypeConvertTarget
    {
        DayNightRadio,
        WorkNonRadio,
    }

    public enum RankTypeConvertTarget
    {
        TotalRank,
        AverageRank,
        UnitAreaRank,
        UnitHeatAreaRank,
        UnitCoolAreaRank,
    }
}
