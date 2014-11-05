using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.EnergyView;
using Mento.Framework.Exceptions;
using Mento.ScriptCommon.Library.Functions.EnergyManagement;
using System.Collections;

namespace Mento.ScriptCommon.Library.Functions
{
    public class EnergyViewToolbar
    {
        #region Controls
        //StartDatePicker
        private static DatePicker StartDatePicker = JazzDatePicker.EnergyUsageStartDateDatePicker;
        //StartTimeComboBox
        private static ComboBox StartTimeComboBox = JazzComboBox.EnergyViewStartTimeComboBox;

        private static MenuButton IndustyLabellinglist = JazzButton.IndustryLabellingIndustryMenuButton;
        private static MenuButton CustomerIndustyLabellinglist = JazzButton.CustomerLabellingIndustryMenuButton;
        //EndDatePicker
        private static DatePicker EndDatePicker = JazzDatePicker.EnergyUsageEndDateDatePicker;
        //EndTimeComboBox
        private static ComboBox EndTimeComboBox = JazzComboBox.EnergyViewEndTimeComboBox;

        //ViewButton
        private static EnergyViewToolbarViewSplitButton ViewButton = new EnergyViewToolbarViewSplitButton();

        //ConvertTargetSplitButton
        private static EnergyViewToolbarConvertTargetMenu ConvertTargetButton = new EnergyViewToolbarConvertTargetMenu();

        //PeakValleyButton
        private static Button PeakValleyButton = JazzButton.EnergyViewPeakValleyButton;

        //AddTimeSpanButton and add time span dialog
        //private static Button AddTimeSpanButton = JazzButton.EnergyViewAddTimeSpanButton;//em-chartgrid-topbar-addInterval

        //RemoveAllTagButton
        private static Button RemoveAllButton = JazzButton.EnergyViewRemoveAllButton; //em-chartgrid-topbar-del

        //MoreMenu and more dialog
        private static EnergyViewToolbarMoreMenu MoreMenu = new EnergyViewToolbarMoreMenu();
        private static SaveToDashboardDialog DashboardDialog = new SaveToDashboardDialog();
        private static TimeSpanDialog TimeSpanDialog = new TimeSpanDialog();

        #endregion

        internal EnergyViewToolbar()
        {
        }

        public string GetStartDate()
        {
            return StartDatePicker.GetValue();
        }

        public string GetEndDate()
        {
            return EndDatePicker.GetValue();
        }

        public string GetStartTime()
        {
            return StartTimeComboBox.GetValue();
        }

        public string GetEndTime()
        {
            return EndTimeComboBox.GetValue();
        }

        public void SetDateRange(DateTime startTime, DateTime endTime)
        {
            int startHour = startTime.Hour, startMinute = startTime.Minute, endHour = endTime.Hour, endMinute = endTime.Minute;

            /*
            if (startMinute != 0 || startMinute != 30 || endMinute != 0 || endMinute != 30)
            {
                throw new ApiException("Start time and end time must be multiple of half hour.");
            }
            */

            StartDatePicker.SelectDateItem(startTime);
            //StartTimeComboBox.SelectItem(String.Format("{0}:{1}", startHour, startMinute));

            EndDatePicker.SelectDateItem(endTime);
            //EndTimeComboBox.SelectItem(String.Format("{0}:{1}", endHour, endMinute));
        }

        public void SetDateRange(string startTime, string endTime)
        {
            StartDatePicker.SelectDateItem(startTime);

            EndDatePicker.SelectDateItem(endTime);

            if (EndTimeComboBox.Exists() && EndTimeComboBox.IsDisplayed())
            {
                EndTimeComboBox.SelectItem("24:00");
            }
        }

        public void SetTimeRange(string startTime, string endTime)
        {
            StartTimeComboBox.SelectItem(startTime);

            EndTimeComboBox.SelectItem(endTime);
        }

        public bool View(EnergyViewType viewType)
        {
            try
            {
                ViewButton.SwitchViewType(viewType);
                return true;
            }
            catch (Exception x)
            {
                return false;
            }
        }

        public void ClickViewButton()
        {
            ViewButton.ClickView();

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public bool IsTimeSpanButtonEnable()
        {
            return !ViewButton.IsTimeSpanButtonDisabled();
        }

        public bool IsTimeSpanMenuItemDisabled(string text)
        {
            return ViewButton.IsMenuItemDisabled(text);
        }

        public void ClickTimeSpanButton()
        {
            ViewButton.ClickTimeSpan();

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public bool IsMoreMenuItemDisabled(string text)
        {
            return MoreMenu.IsMenuItemDisabled(text);
        }

        public void TimeSpan(TimeSpans span)
        {
            ViewButton.SwitchTimeSpans(span);

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void ClickFuncModeConvertTarget()
        {
            ConvertTargetButton.ClickFuncModeConvertTargetButton();
        }

        public string GetFuncModeConvertTargetText()
        {
            return ConvertTargetButton.GetFuncModeConvertTargetButtonText();
        }

        public void ClickRankTypeConvertTarget()
        {
            ConvertTargetButton.ClickRankTypeConvertTargetButton();
        }

        public void SelectIndustryConvertTarget(string industry)
        {
            ConvertTargetButton.SwitchIndustryMenuItem(industry);
        }

        public ArrayList GetBenchmarkMenulist(string buttonType)
        {
                return MoreMenu.GetBenchmarkMenuItemsList(buttonType);
        }

        public void SelectIndustryOrCustomerLabellingConvertTarget(int LabellingType, string Labelling)
        {
            if (1 == LabellingType)
                ConvertTargetButton.SwitchLabellingIndustryMenuItem(Labelling);
            else
                ConvertTargetButton.SwitchCustomerLabellingIndustryMenuItem(Labelling);
        }

        public ArrayList GetIndustryLabellingMenuListItems(string industry)
        {
            return MoreMenu.GetLabellingSecondLevelMenuItem(industry);
        }

        public void SelectRatioIndustryConvertTarget(string industry)
        {
            ConvertTargetButton.SwitchRatioIndustryMenuItem(industry);
        }

        public void SelectLabellingIndustryConvertTarget(string[] industry)
        {
            MoreMenu.SwitchLabellingIndustryMenuItem(industry);
        }

        public ArrayList GetIndustryLabellingDropdownListItems()
        {
            return null;
            //return IndustyLabellinglist.GetCurrentDropdownListItems();
        }

        public string GetLabellingIndustryButtonText()
        {
            return MoreMenu.GetLabellingIndustryValue();
        }

        public string GetIndustryButtonText()
        {
            return ConvertTargetButton.GetIndustryButtonText();
        }
        /* 
         * can be deleted
        public string GetIndustryLabellingButtonText()
        {
            return ConvertTargetButton.GetIndustryLabellingButtonText();
        }
        */
        public void SelectCarbonConvertTarget(CarbonConvertTarget target)
        {
            ConvertTargetButton.SwitchCarbonMenuItem(target);
        }

        public void SelectCarbonConvertTarget(string target)
        {
            ConvertTargetButton.SwitchCarbonMenuItem(target);
        }

        public void SelectFuncModeConvertTarget(FuncModeConvertTarget target)
        {
            ConvertTargetButton.SwitchFuncModeMenuItem(target);
        }

        public void SelectTagModeConvertTarget(TagModeConvertTarget target)
        {
            ConvertTargetButton.SwitchTagModeMenuItem(target);
        }

        public void SelectUnitTypeConvertTarget(UnitTypeConvertTarget target)
        {
            ConvertTargetButton.SwitchUnitTypeMenuItem(target);
        }

        public void SelectUnitTypeConvertTarget(string target)
        {
            ConvertTargetButton.SwitchUnitTypeMenuItem(target);
        }

        public void SelectLabellingUnitTypeConvertTarget(string target)
        {
            ConvertTargetButton.SwitchLabellingUnitTypeMenuItem(target);
        }

        public string GetUnitTypeButtonText()
        {
            return ConvertTargetButton.GetUnitTypeButtonText();
        }

        public void SelectRadioTypeConvertTarget(RadioTypeConvertTarget target)
        {
            ConvertTargetButton.SwitchRadioTypeMenuItem(target);
        }

        public void SelectRankTypeConvertTarget(RankTypeConvertTarget target)
        {
            ConvertTargetButton.SwitchRankTypeMenuItem(target);
        }

        public string GetCurrentTagModeButtonValue()
        {
            return ConvertTargetButton.GetCurrentTagModeButtonValue();
        }

        public void RemoveAllTags()
        {
            RemoveAllButton.Click();
        }

        public void ShowPeakValley()
        {
            PeakValleyButton.Click();
        }

        public bool IsPeakValleyButtonEnable()
        {
            return PeakValleyButton.IsEnabled();
        }

        public bool IsPeakValleyButtonPressed()
        {
            return PeakValleyButton.IsPressed();
        }

        public void SelectMoreOption(EnergyViewMoreOption moreOption)
        {
            MoreMenu.SwitchMenuItem(moreOption);

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void OpenMoreButton()
        {
            MoreMenu.OpenMoreButton();
        }

        public void OpenIndustryConvertButton()
        {
            MoreMenu.OpenIndustryConvertButton();
        }

        #region Dashboard

        public void SaveToDashboard(string widgetName, string[] hierarchyName, bool isCreateDashboard, string dashboardName)
        {
            MoreMenu.SwitchMenuItem(EnergyViewMoreOption.ToDashboard);
            TimeManager.FlashPause();

            DashboardDialog.Save(widgetName, hierarchyName, isCreateDashboard, dashboardName);
        }

        public void SaveToDashboardThenCancel(string widgetName, string[] hierarchyName, bool isCreateDashboard, string dashboardName)
        {
            MoreMenu.SwitchMenuItem(EnergyViewMoreOption.ToDashboard);
            TimeManager.FlashPause();

            DashboardDialog.SaveThenCancel(widgetName, hierarchyName, isCreateDashboard, dashboardName);
        }

        public void SaveToDashboardwithAnnotation(string widgetName, string[] hierarchyName, bool isCreateDashboard, string dashboardName, string comment)
        {
            MoreMenu.SwitchMenuItem(EnergyViewMoreOption.ToDashboard);
            TimeManager.FlashPause();

            DashboardDialog.SaveWithAnnotation(widgetName, hierarchyName, isCreateDashboard, dashboardName, comment);
        }

        public bool IsWidgetNameInvalid()
        {
            return DashboardDialog.IsWidgetNameInvalid();
        }

        public string GetWidgetNameInvalidMsg()
        {
            return DashboardDialog.GetWidgetNameInvalidMsg();
        }

        public void ClickCloseDashboardDialog()
        {
            DashboardDialog.Close();
        }

        public string GetExistedDashboardInvalidMsg()
        {
            return DashboardDialog.GetNewDashboardMsg();
        }
        #endregion
    }
}
