using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;
using System.Collections;
using OpenQA.Selenium;

namespace Mento.ScriptCommon.Library.Functions
{
    internal class EnergyViewToolbarConvertTargetMenu
    {
        private static MenuButton CarbonConvertTargetButton = JazzButton.EnergyViewConvertTargetMenuButton;
        private static MenuButton FuncModeConvertTargetButton = JazzButton.FuncModeConvertMenuButton;
        private static MenuButton TagModeConvertTargetButton = JazzButton.TagModeConvertMenuButton;
        private static MenuButton UnitTypeConvertTargetButton = JazzButton.UnitTypeConvertMenuButton;
        private static MenuButton CarbonUnitTypeConvertTargetButton = JazzButton.CarbonUnitTypeConvertMenuButton;
        private static MenuButton RadioTypeConvertTargetButton = JazzButton.RadioTypeConvertMenuButton;
        private static MenuButton RankTypeConvertTargetButton = JazzButton.RankTypeConvertMenuButton;
        private static MenuButton IndustryConvertTargetButton = JazzButton.IndustryConvertMenuButton;
        private static MenuButton CarbonIndustryConvertTargetButton = JazzButton.CarbonIndustryConvertMenuButton;
        private static MenuButton LabellingIndustryConvertTargetButton = JazzButton.LabellingIndustryConvertMenuButton;
        private static MenuButton CustomerLabellingIndustryTargetButton = JazzButton.CustomerLabellingIndustryMenuButton;
        private static Dictionary<CarbonConvertTarget, string[]> CarbonMenuItems = new Dictionary<CarbonConvertTarget, string[]>()
        {
            {CarbonConvertTarget.StandardCoal,new string[]{"$@Common.CarbonUomType.StandardCoal"}},
            {CarbonConvertTarget.CO2,new string[]{"$@Common.CarbonUomType.CO2"}},
            {CarbonConvertTarget.Tree,new string[]{"$@Common.CarbonUomType.Tree"}},
        };

        private static Dictionary<FuncModeConvertTarget, string[]> FuncModeMenuItems = new Dictionary<FuncModeConvertTarget, string[]>()
        {
            {FuncModeConvertTarget.Energy,new string[]{"$@EM.Title.EnergyConsumption"}},
            {FuncModeConvertTarget.Carbon,new string[]{"$@EM.KpiModeCarbon"}},
            {FuncModeConvertTarget.Cost,new string[]{"$@EM.Title.CostUnit"}},
        };

        private static Dictionary<TagModeConvertTarget, string[]> TagModeMenuItems = new Dictionary<TagModeConvertTarget, string[]>()
        {
            {TagModeConvertTarget.SingleHierarchyTag,new string[]{"$@EM.SingleHier"}},
            {TagModeConvertTarget.MultipleHierarchyTag,new string[]{"$@EM.MultiHier"}},
        };

        private static Dictionary<LabellingConvertTarget, string[]> LabellingMenuItems = new Dictionary<LabellingConvertTarget, string[]>()
        {
            {LabellingConvertTarget.IndustryLablling,new string[]{"$@Setting.Labeling.Label.CustomizedLabeling"}},
            {LabellingConvertTarget.CustomerLablling,new string[]{"$@Setting.Labeling.Label.IndustryLabeling"}},

        };

        private static Dictionary<UnitTypeConvertTarget, string[]> UnitTypeMenuItems = new Dictionary<UnitTypeConvertTarget, string[]>()
        {
            {UnitTypeConvertTarget.UnitPopulation,new string[]{"$@EM.Unit.UnUnitTypeMenuItemstPopulation"}},
            {UnitTypeConvertTarget.UnitArea,new string[]{"$@EM.Unit.UnitArea"}},
            {UnitTypeConvertTarget.UnitHeatArea,new string[]{"$@EM.Unit.UnitWarmArea"}},
            {UnitTypeConvertTarget.UnitCoolArea,new string[]{"$@EM.Unit.UnitColdArea"}},
        };

        private static Dictionary<RadioTypeConvertTarget, string[]> RadioTypeMenuItems = new Dictionary<RadioTypeConvertTarget, string[]>()
        {
            {RadioTypeConvertTarget.DayNightRadio,new string[]{"$@EM.DayNightRatio"}},
            {RadioTypeConvertTarget.WorkNonRadio,new string[]{"$@EM.WorkHolidayRatio"}},
        };

        private static Dictionary<RankTypeConvertTarget, string[]> RankTypeMenuItems = new Dictionary<RankTypeConvertTarget, string[]>()
        { 
            {RankTypeConvertTarget.TotalRank,new string[]{"$@EM.Rank.TotalRank"}},
            {RankTypeConvertTarget.AverageRank,new string[]{"$@EM.Rank.RankByPeople"}},
            {RankTypeConvertTarget.UnitAreaRank,new string[]{"$@EM.Rank.RankByArea"}},
            {RankTypeConvertTarget.UnitHeatAreaRank,new string[]{"$@EM.Rank.RankByHeatArea"}},
            {RankTypeConvertTarget.UnitCoolAreaRank,new string[]{"$@EM.Rank.RankByCoolArea"}},
        };

        internal EnergyViewToolbarConvertTargetMenu() { }

        public void SwitchIndustryMenuItem(string industry)
        {
            if (GetFuncModeConvertTargetButtonText().Contains("碳排放") || GetFuncModeConvertTargetButtonText().Contains("Carbon emission"))
            {
                CarbonIndustryConvertTargetButton.SelectOneItem(industry);
            }
            else
            {
                IndustryConvertTargetButton.SelectOneItem(industry);
            }      
        }

        public void SwitchRatioIndustryMenuItem(string industry)
        {
            IndustryConvertTargetButton.SelectOneItem(industry);
        }

        public void SwitchLabellingIndustryMenuItem(string industry)
        {
            LabellingIndustryConvertTargetButton.SelectOneItem(industry);
        }

        public void SwitchCustomerLabellingIndustryMenuItem(string customerLabelling)
        {
            TimeManager.LongPause();
            CustomerLabellingIndustryTargetButton.ClickAndHold();
            TimeManager.LongPause();
            TimeManager.LongPause();
            CustomerLabellingIndustryTargetButton.SelectOneItem(customerLabelling);
        }

        public string GetIndustryButtonText()
        {
            return IndustryConvertTargetButton.GetText();
        }

        public string GetIndustryLabellingButtonText()
        {
            return LabellingIndustryConvertTargetButton.GetText();
        }

        public void SwitchCarbonMenuItem(CarbonConvertTarget target)
        {
            CarbonConvertTargetButton.SelectItem(CarbonMenuItems[target]);
        }

        public void SwitchCarbonMenuItem(string target)
        {
            CarbonConvertTargetButton.SelectOneItem(target);
        }

        public void ClickFuncModeConvertTargetButton()
        {
            FuncModeConvertTargetButton.Click();
        }

        public string GetFuncModeConvertTargetButtonText()
        {
            return FuncModeConvertTargetButton.GetText();
        }

        public void SwitchFuncModeMenuItem(FuncModeConvertTarget target)
        {
            FuncModeConvertTargetButton.SelectItem(FuncModeMenuItems[target]);
        }

        public void SwitchTagModeMenuItem(TagModeConvertTarget target)
        {
            TagModeConvertTargetButton.SelectItem(TagModeMenuItems[target]);
        }

        public void SwitchLabellingMenuItem(LabellingConvertTarget target)
        {

            LabellingIndustryConvertTargetButton.SelectItem(LabellingMenuItems[target]);
           
        }

        public void SwitchUnitTypeMenuItem(UnitTypeConvertTarget target)
        {
            if (GetFuncModeConvertTargetButtonText().Contains("碳排放") || GetFuncModeConvertTargetButtonText().Contains("Carbon emission"))
            {
                CarbonUnitTypeConvertTargetButton.SelectItem(UnitTypeMenuItems[target]);
            }
            else
            {
                UnitTypeConvertTargetButton.SelectItem(UnitTypeMenuItems[target]);
            }        
        }

        public void SwitchCustomerLabellingMenuItem(string target)
        {
            if (LabellingIndustryConvertTargetButton.GetText().Equals("Customized labeling") || LabellingIndustryConvertTargetButton.GetText().Equals("自定义能效标识"))
            {
                CustomerLabellingIndustryTargetButton.SelectOneItem(target);
            }
            else
            {
                CustomerLabellingIndustryTargetButton.SelectOneItem(target);
            }
        }

        public void SwitchUnitTypeMenuItem(string target)
        {
            if (GetFuncModeConvertTargetButtonText().Contains("碳排放") || GetFuncModeConvertTargetButtonText().Contains("Carbon emission"))
            {
                CarbonUnitTypeConvertTargetButton.SelectOneItem(target);
            }
            else
            {
                UnitTypeConvertTargetButton.SelectOneItem(target);
            }
        }

        public void SwitchLabellingUnitTypeMenuItem(string target)
        {
            UnitTypeConvertTargetButton.SelectOneItem(target);
        }

        public string GetUnitTypeButtonText()
        {
            return UnitTypeConvertTargetButton.GetText();
        }

        public void SwitchRadioTypeMenuItem(RadioTypeConvertTarget target)
        {
            RadioTypeConvertTargetButton.SelectItem(RadioTypeMenuItems[target]);
        }

        public void SwitchRankTypeMenuItem(RankTypeConvertTarget target)
        {
            RankTypeConvertTargetButton.SelectItem(RankTypeMenuItems[target]);
        }

        public void ClickRankTypeConvertTargetButton()
        {
            RankTypeConvertTargetButton.Click();
        }
        
        public string GetCurrentTagModeButtonValue()
        {
            return TagModeConvertTargetButton.GetText();
        }
    }

    #region enum items
    
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

    public enum LabellingConvertTarget
    {
        IndustryLablling,
        CustomerLablling,
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

    #endregion
}
