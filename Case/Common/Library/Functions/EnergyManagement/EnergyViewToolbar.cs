﻿using System;
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
        //StartDatePicker
        //StartTimeComboBox
        //EndDatePicker
        //EndTimeComboBox

        //ViewButton
        private static EnergyViewToolbarViewSplitButton ViewButton = new EnergyViewToolbarViewSplitButton();
        //ConvertTargetSplitButton
        //PeakValleyButton

        //AddTimeSpanButton
        //RemoveAllTagButton
        //MoreMenu
        private static EnergyViewToolbarMoreMenu MoreMenu = new EnergyViewToolbarMoreMenu();


        public EnergyViewToolbar()
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

        public void SelectMoreOption(EnergyViewMoreOption moreOption)
        {
            MoreMenu.SwitchMenuItem(moreOption);

            JazzMessageBox.LoadingMask.WaitLoading();
        }
    }
}