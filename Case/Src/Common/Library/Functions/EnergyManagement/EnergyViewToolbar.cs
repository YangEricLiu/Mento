using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.EnergyView;
using Mento.Framework.Exceptions;

namespace Mento.ScriptCommon.Library.Functions
{
    public class EnergyViewToolbar
    {
        #region Controls
        //StartDatePicker
        private static DatePicker StartDatePicker = JazzDatePicker.EnergyUsageStartDateDatePicker;
        //StartTimeComboBox
        private static ComboBox StartTimeComboBox = JazzComboBox.EnergyViewStartTimeComboBox;

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
        private static Button AddTimeSpanButton = JazzButton.EnergyViewAddTimeSpanButton;//em-chartgrid-topbar-addInterval
        private static TimeSpanDialog TimeSpanDialog = new TimeSpanDialog();

        //RemoveAllTagButton
        private static Button RemoveAllButton = JazzButton.EnergyViewRemoveAllButton; //em-chartgrid-topbar-del

        //MoreMenu and more dialog
        private static EnergyViewToolbarMoreMenu MoreMenu = new EnergyViewToolbarMoreMenu();
        private static SaveToDashboardDialog DashboardDialog = new SaveToDashboardDialog();
        #endregion

        internal EnergyViewToolbar()
        {
        }

        public void SetTimeRange(DateTime startTime, DateTime endTime)
        {
            int startHour = startTime.Hour, startMinute = startTime.Minute, endHour = endTime.Hour, endMinute = endTime.Minute;

            if (startMinute != 0 || startMinute != 30 || endMinute != 0 || endMinute != 30)
            {
                throw new ApiException("Start time and end time must be multiple of half hour.");
            }

            StartDatePicker.SelectDateItem(startTime);
            StartTimeComboBox.SelectItem(String.Format("{0}:{1}", startHour, startMinute));

            EndDatePicker.SelectDateItem(endTime);
            EndTimeComboBox.SelectItem(String.Format("{0}:{1}", endHour, endMinute));
        }

        public void View(EnergyViewType viewType)
        {
            ViewButton.SwitchViewType(viewType);

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void ClickViewButton()
        {
            ViewButton.Click();

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void SelectCarbonConvertTarget(CarbonConvertTarget target)
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

        public void SelectRadioTypeConvertTarget(RadioTypeConvertTarget target)
        {
            ConvertTargetButton.SwitchRadioTypeMenuItem(target);
        }

        public void SelectRankTypeConvertTarget(RankTypeConvertTarget target)
        {
            ConvertTargetButton.SwitchRankTypeMenuItem(target);
        }

        public void RemoveAllTags()
        {
            RemoveAllButton.Click();
        }

        public void ShowPeakValley()
        {
            PeakValleyButton.Click();
        }

        public void AddTimeSpan(DateTime startTime)
        {
            AddTimeSpanButton.Click();

            TimeSpanDialog.InputStartTime(startTime);
            TimeSpanDialog.Confirm();

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void SelectMoreOption(EnergyViewMoreOption moreOption)
        {
            MoreMenu.SwitchMenuItem(moreOption);

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void SaveToDashboard(string widgetName, string[] hierarchyName, bool isCreateDashboard, string dashboardName)
        {
            MoreMenu.SwitchMenuItem(EnergyViewMoreOption.ToDashboard);
            TimeManager.FlashPause();

            DashboardDialog.Save(widgetName, hierarchyName, isCreateDashboard, dashboardName);
        }
    }
}
