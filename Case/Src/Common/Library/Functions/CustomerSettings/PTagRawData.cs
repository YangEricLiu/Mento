using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using OpenQA.Selenium;


namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of ptag rawdata configuration.
    /// </summary>
    public class PTagRawData
    {
        internal PTagRawData()
        {
        }

        #region ptag controls

        private static Grid PTagList = JazzGrid.PTagSettingsPTagList;

        //StartDatePicker
        private static DatePicker StartDatePicker = JazzDatePicker.PTagRawDataStartDateDatePicker;
        //StartTimeComboBox
        private static ComboBox StartTimeComboBox = JazzComboBox.PTagRawDataStartTimeComboBox;

        //EndDatePicker
        private static DatePicker EndDatePicker = JazzDatePicker.PTagRawDataEndDateDatePicker;
        //EndTimeComboBox
        private static ComboBox EndTimeComboBox = JazzComboBox.PTagRawDataEndTimeComboBox;

        private static TabButton RawDataTab = JazzButton.PTagRawDataTabButton;
        private static Button RawDataModifyButton = JazzButton.PTagRawDataModifyButton;
        private static Button RawDataSaveButton = JazzButton.PTagRawDataSaveButton;
        private static Button RawDataCancelButton = JazzButton.PTagRawDataCancelButton;
        private static Grid GridPTagRawData = JazzGrid.GridPTagRawData;

        private static Button RawDataSaveAndSwitchButton = JazzButton.PTagRawDataSaveAndSwitchButton;
        private static Button RawDataDirectlySwitchButton = JazzButton.PTagRawDataDirectlySwitchButton;
        private static Button RawDataCancelSwitchButton = JazzButton.PTagRawDataCancelSwitchButton;
        private static Button RawDataSwitchDifferenceValueButton = JazzButton.PTagRawDataSwitchDifferenceValueButton;
        private static Button RawDataLeftButton = JazzButton.PTagRawDataLeftButton;
        private static Button RawDataRightButton = JazzButton.PTagRawDataRightButton;

        //private static Window SwitchTimeWindow = JazzWindow.SwitchTimeWindow;
        private static Locator SwitchTimeWindow = JazzControlLocatorRepository.GetLocator(JazzControlLocatorKey.WindowSwitchTime);

        #endregion

        #region Ptag RawData Operation

        /// <summary>
        /// Click Raw Data tab button to edit Raw data of ptag.
        /// </summary>
        /// <returns></returns>
        public void SwitchToRawDataTab()
        {
            RawDataTab.Click();
        }

        /// <summary>
        /// Navigate to Ptag Configuration Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToEnergyView()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyView);
            TimeManager.ShortPause();
        }



        /// <summary>
        /// Navigate to Ptag Configuration Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToPtagSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsP);
            TimeManager.ShortPause();
        }

        /// <summary>
        /// Focus ptag by name
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean FocusOnPTagByName(string ptagName)
        {
            try
            {
                PTagList.FocusOnRow(1, ptagName);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Focus ptag by name
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean FocusOnPTagByCode(string ptagCode)
        {
            try
            {
                PTagList.FocusOnRow(2, ptagCode);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Basic Property Operations


        /// <summary>
        /// Click save button for RawData modified value
        /// </summary>
        public void ClickSaveRawDataButton()
        {
            RawDataSaveButton.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
        }

        /// <summary>
        /// Click "Cancel" Button
        /// </summary>
        public void ClickCancelRawDataButton()
        {
            RawDataCancelButton.Click();
        }

        /// <summary>
        /// Click "Modify Record" Button
        /// </summary>
        public void ClickModifyRawDataButton()
        {
            RawDataModifyButton.Click();
        }

        /// <summary>
        /// Click left button for reset time range
        /// </summary>
        public void ClickLeftButton()
        {
            RawDataLeftButton.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
        }

        /// <summary>
        /// Click right button for reset time range
        /// </summary>
        public void ClickRightButton()
        {
            RawDataRightButton.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
        }

        /// <summary>
        /// Click switch button for difference value in grid header
        /// </summary>
        public void ClickSwitchDifferenceValueButton()
        {
            RawDataSwitchDifferenceValueButton.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
        }

        /// <summary>
        /// Click 'Save and switch' button in popup time span after modified value without save in rawdata
        /// </summary>
        public void ClickSaveAndSwitchButton()
        {
            if (ElementHandler.Exists(SwitchTimeWindow))
            {
                RawDataSaveAndSwitchButton.Click();
                JazzMessageBox.LoadingMask.WaitLoading();
            }

        }

        /// <summary>
        /// Click 'Directly switch' button in popup time span after modified value without save in rawdata
        /// </summary>
        public void ClickDirectlySwitchButton()
        {
            if(ElementHandler.Exists(SwitchTimeWindow))
            {
                RawDataDirectlySwitchButton.Click();
                JazzMessageBox.LoadingMask.WaitLoading();
            }

        }

        /// <summary>
        /// Click 'Cancel switch' button in popup time span after modified value without save in rawdata
        /// </summary>
        public void ClickCancelSwitchButton()
        {
            if (ElementHandler.Exists(SwitchTimeWindow))
            {
                RawDataCancelSwitchButton.Click();
                JazzMessageBox.LoadingMask.WaitLoading();
            }

        }

        /// <summary>
        /// Set date range for PTag RawData
        /// </summary>
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

        public string GetBaseStartDateValue()
        {
            return StartDatePicker.GetValue();
        }

        public string GetBaseEndDateValue()
        {
            return EndDatePicker.GetValue();
        }

        public string GetBaseStartTimeValue()
        {
            return StartTimeComboBox.GetValue();
        }

        public string GetBaseEndTimeValue()
        {
            return EndTimeComboBox.GetValue();
        }

        public void ClickSwitchWindowSSBtn()
        {
            if (ElementHandler.Exists(SwitchTimeWindow))
            {
                RawDataSaveAndSwitchButton.Click();
                JazzMessageBox.LoadingMask.WaitLoading();
            }
        }

        public void ClickSwitchWindowDSBtn()
        {
            if (ElementHandler.Exists(SwitchTimeWindow))
            {
                RawDataDirectlySwitchButton.Click();
                JazzMessageBox.LoadingMask.WaitLoading();
            }
        }

        public void CloseSwitchTimeWindow()
        {
            if (ElementHandler.Exists(SwitchTimeWindow))
            {
                RawDataCancelButton.Click();
                JazzMessageBox.LoadingMask.WaitLoading();
            }
        }


        #endregion

        #region Verification

        /// <summary>
        /// Verify whether the UI element exist
        /// </summary>
        /// <returns>True if the UI elemrnt exist, false if not</returns>
        public bool IsExisted(string itemKey)
        {
            //Locator itemLocator = JazzControlLocatorRepository.GetLocator(JazzControlLocatorKey.GridPTagRawDataFirstRow);
            Locator itemLocator = JazzControlLocatorRepository.GetLocator(itemKey);
            return ElementHandler.Exists(itemLocator);
        }

        #endregion

    }
}
