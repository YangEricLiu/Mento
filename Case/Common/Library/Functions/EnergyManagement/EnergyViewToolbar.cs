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
    public class EnergyViewToolbar
    {
        #region Controls
        //StartDatePicker
        //StartTimeComboBox
        //EndDatePicker
        //EndTimeComboBox

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

        }

        public void View(EnergyViewType viewType)
        {
            //if (ViewButton.CurrentViewType == viewType)
            //{
            //    ViewButton.Click();
            //}
            //else
            //{
                ViewButton.SwitchViewType(viewType);
            //}

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void SelectConvertTarget(CarbonConvertTarget target)
        {
            ConvertTargetButton.SwitchMenuItem(target);
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

        public void SaveToDashboard(string widgetName, string hierarchyName, bool isCreateDashboard, string dashboardName)
        {
            MoreMenu.SwitchMenuItem(EnergyViewMoreOption.ToDashboard);
            TimeManager.FlashPause();

            DashboardDialog.Save(widgetName, hierarchyName, isCreateDashboard, dashboardName);
        }

        public void ShowCalendar()
        {
            MoreMenu.CheckShowCanlendar();
        }

        public void HideCalendar()
        {
            MoreMenu.UncheckShowCanlendar();
        }
    }
}
