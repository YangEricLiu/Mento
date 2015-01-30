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
    public class AbnormalData
    {
        internal AbnormalData()
        {
        }

        #region AbnormalData controls

        private static Grid AbnormalRecordList = JazzGrid.AbnormalRecordList;

        //StartDatePicker and StartTimeComboBox
        private static DatePicker StartDatePicker = JazzDatePicker.VEERawDataStartDateDatePicker;
        private static ComboBox StartTimeComboBox = JazzComboBox.VEERawDataStartTimeComboBox;

        //EndDatePicker and EndTimeComboBox
        private static DatePicker EndDatePicker = JazzDatePicker.VEERawDataEndDateDatePicker;
        private static ComboBox EndTimeComboBox = JazzComboBox.VEERawDataEndTimeComboBox;

        private static Grid GridVEERawData = JazzGrid.GridVEERawData;
        private static Button RawDataSaveButton = JazzButton.VEERawDataSaveButton;
        private static Button RawDataCancelButton = JazzButton.VEERawDataCancelButton;
        private static Button BatchOperationButton = JazzButton.VEEBatchOperationButton;
        private static MenuButton BatchModifyButton = JazzButton.VEEBatchModifyButton;
        private static MenuButton BatchRevertButton = JazzButton.VEEBatchRevertButton;
        private static MenuButton BatchIgnoreButton = JazzButton.VEEBatchIgnoreButton;

        private static Button VEERawDataSaveAndSwitchButton = JazzButton.VEERawDataSaveAndSwitchButton;
        private static Button VEERawDataDirectlySwitchButton = JazzButton.VEERawDataDirectlySwitchButton;
        private static Button VEERawDataCancelSwitchButton = JazzButton.VEERawDataCancelSwitchButton;
        private static Button VEERawDataSwitchDifferenceValueButton = JazzButton.VEERawDataSwitchDifferenceValueButton;
        private static Button VEERawDataSwitchOriginalValueButton = JazzButton.VEERawDataSwitchOriginalValueButton;
        private static Button VEERawDataLeftButton = JazzButton.VEERawDataLeftButton;
        private static Button VEERawDataRightButton = JazzButton.VEERawDataRightButton;

        private static Locator VEESwitchTimeWindow = JazzControlLocatorRepository.GetLocator(JazzControlLocatorKey.WindowVEESwitchTime);

        #endregion

        #region AbnormalData Operation

        /// <summary>
        /// Navigate to Abnormal Record Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToAbnormalRecord()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AbnormalRecord);
            TimeManager.ShortPause();
        }

        public void AbnormalDataCaseSetUp()
        {
            NavigatorToAbnormalRecord();
            TimeManager.MediumPause();
        }

        public void AbnormalDataCaseTearDown()
        {
            JazzFunction.LoginPage.RefreshJazz("自动化测试");
            TimeManager.LongPause();
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
        /// Focus abnormal record by tag name
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean FocusOnRecordByName(string tagName)
        {
            try
            {
                AbnormalRecordList.FocusOnRow(5, tagName);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Focus abnormal record by rule name
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean FocusOnRecordByRule(string rule)
        {
            try
            {
                AbnormalRecordList.FocusOnRow(2, rule);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Focus abnormal record by data type
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean FocusOnRecordByDataType(string dataType)
        {
            try
            {
                AbnormalRecordList.FocusOnRow(3, dataType);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Check abnormal records by tag names
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean CheckRecordsByTagName(string tagName)
        {
            try
            {
                AbnormalRecordList.CheckRowCheckbox(5, tagName);
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
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
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
        public void ClickBatchOperationButton()
        {
            BatchOperationButton.Click();
        }

        public void ClickBatchModifyButton()
        {
            BatchModifyButton.Click();
        }

        public void ClickBatchRevertButton()
        {
            BatchRevertButton.Click();
        }

        public void ClickBatchIgnoreButton()
        {
            BatchIgnoreButton.Click();
        }

        /// <summary>
        /// Click left button for reset time range
        /// </summary>
        public void ClickLeftButton()
        {
            VEERawDataLeftButton.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
        }

        /// <summary>
        /// Click right button for reset time range
        /// </summary>
        public void ClickRightButton()
        {
            VEERawDataRightButton.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
        }

        /// <summary>
        /// Click switch button for difference value in grid header
        /// </summary>
        public void ClickSwitchDifferenceValueButton()
        {
            VEERawDataSwitchDifferenceValueButton.Click();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
        }

        /// <summary>
        /// Click switch button for original value in grid header
        /// </summary>
        public void ClickSwitchOriginalValueButton()
        {
            VEERawDataSwitchOriginalValueButton.Click();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
        }

        /// <summary>
        /// Click 'Save and switch' button in popup time span after modified value without save in rawdata
        /// </summary>
        public void ClickSaveAndSwitchButton()
        {
            if (ElementHandler.Exists(VEESwitchTimeWindow))
            {
                VEERawDataSaveAndSwitchButton.Click();
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            }

        }

        /// <summary>
        /// Click 'Directly switch' button in popup time span after modified value without save in rawdata
        /// </summary>
        public void ClickDirectlySwitchButton()
        {
            if(ElementHandler.Exists(VEESwitchTimeWindow))
            {
                VEERawDataDirectlySwitchButton.Click();
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            }

        }

        /// <summary>
        /// Click 'Cancel switch' button in popup time span after modified value without save in rawdata
        /// </summary>
        public void ClickCancelSwitchButton()
        {
            if (ElementHandler.Exists(VEESwitchTimeWindow))
            {
                VEERawDataCancelSwitchButton.Click();
                JazzMessageBox.LoadingMask.WaitLoading();
            }

        }

        /// <summary>
        /// Set date range for abnormal record
        /// </summary>
        public void SetDateRange(string startTime, string endTime)
        {
            if (" " != startTime)
            { 
                StartDatePicker.SelectDateItem(startTime);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            }
            if (" " != endTime)
            { 
                EndDatePicker.SelectDateItem(endTime);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            }

            if (EndTimeComboBox.Exists() && EndTimeComboBox.IsDisplayed())
            {
                EndTimeComboBox.SelectItem("24:00");
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            }
        }

        public void SetTimeRange(string startTime, string endTime)
        {
            if (" " != startTime)
            { 
                StartTimeComboBox.SelectItem(startTime);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            }
            if (" " != endTime)
            { 
                EndTimeComboBox.SelectItem(endTime);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            }
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

        //public void ClickSwitchWindowSSBtn()
        //{
        //    if (ElementHandler.Exists(SwitchTimeWindow))
        //    {
        //        VEERawDataSaveAndSwitchButton.Click();
        //        JazzMessageBox.LoadingMask.WaitLoading();
        //    }
        //}

        //public void ClickSwitchWindowDSBtn()
        //{
        //    if (ElementHandler.Exists(SwitchTimeWindow))
        //    {
        //        VEERawDataDirectlySwitchButton.Click();
        //        JazzMessageBox.LoadingMask.WaitLoading();
        //    }
        //}

        //public void CloseSwitchTimeWindow()
        //{
        //    if (ElementHandler.Exists(SwitchTimeWindow))
        //    {
        //        VEERawDataCancelSwitchButton.Click();
        //        JazzMessageBox.LoadingMask.WaitLoading();
        //    }
        //}


        #endregion

        #region Verification

        /// <summary>
        /// Verify whether the UI element exist
        /// </summary>
        /// <returns>True if the UI elemrnt exist, false if not</returns>
        public bool IsExisted(string itemKey)
        {
            Locator itemLocator = JazzControlLocatorRepository.GetLocator(itemKey);
            return ElementHandler.Exists(itemLocator);
        }

        #endregion

    }
}
