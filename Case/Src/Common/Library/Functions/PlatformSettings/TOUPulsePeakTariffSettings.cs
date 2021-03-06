﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Administration;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;


namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of TOU Pulse Peak tariff management.
    /// </summary>
    public class TOUPulsePeakTariffSettings
    {
        internal TOUPulsePeakTariffSettings()
        {
        }

        #region Controls
        private static Grid TOUTariffsList = JazzGrid.TOUTariffsList;

        private static TabButton PulsePeakPropertyTab = JazzButton.TOUPulsePeakPropertyTabButton;
        private static Button PulsePeakPropertyCreateButton = JazzButton.TOUPulsePeakPropertyCreateButton;
        private static Button PulsePeakPropertyPlusIconButton = JazzButton.TOUPulsePeakPropertyPlusIconButton;
        private static Button PulsePeakPropertyModifyButton = JazzButton.TOUPulsePeakPropertyModifyButton;
        private static Button PulsePeakPropertySaveButton = JazzButton.TOUPulsePeakPropertySaveButton;
        private static Button PulsePeakPropertyCancelButton = JazzButton.TOUPulsePeakPropertyCancelButton;
        private static Button PulsePeakPropertyDeleteWholeRangeButton = JazzButton.TOUPulsePeakPropertyDeleteWholeRangeButton;
        private static Button PulsePeakPropertyDeleteRangeItemButton = JazzButton.TOUPulsePeakPropertyDeleteRangeItemButton;
        private static LinkButton PulsePeakPropertyAddMoreRangesButton = JazzButton.TOUPulsePeakPropertyAddMoreRangesButton;
        
        private static TextField PulsePeakPropertyPriceValueTextField = JazzTextField.TOUPulsePeakPropertyPriceValueTextField;

        private static ComboBox PulsePeakPropertyStartMonthComboBox = JazzComboBox.TOUPulsePeakPropertyStartMonthComboBox;
        private static ComboBox PulsePeakPropertyStartDateComboBox = JazzComboBox.TOUPulsePeakPropertyStartDateComboBox;
        private static ComboBox PulsePeakPropertyEndMonthComboBox = JazzComboBox.TOUPulsePeakPropertyEndMonthComboBox;
        private static ComboBox PulsePeakPropertyEndDateComboBox = JazzComboBox.TOUPulsePeakPropertyEndDateComboBox;
        private static ComboBox PulsePeakPropertyStartTimeComboBox = JazzComboBox.TOUPulsePeakPropertyStartTimeComboBox;
        private static ComboBox PulsePeakPropertyEndTimeComboBox = JazzComboBox.TOUPulsePeakPropertyEndTimeComboBox;
        #endregion

        #region common action
        public void NavigatorToPriceSettings()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.PriceSettingsPrice);
        }        
                
        public void FocusOnTOUTariff(string touTariffName)
        {
            TOUTariffsList.FocusOnRow(1, touTariffName, false);
        }

        public void SwitchToPulsePeakPropertyTab()
        {
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            PulsePeakPropertyTab.Click();
        }

        public void ClickPulsePeakPropertyCreateButton()
        {
            PulsePeakPropertyCreateButton.Click();
        }

        public Boolean IsPulsePeakPropertyCreateButtonDisplayed()
        {
            return PulsePeakPropertyCreateButton.IsDisplayed();
        }

        public void ClickPulsePeakPropertyPlusIcon()
        {
            PulsePeakPropertyPlusIconButton.Click();
        }

        public void ClickPulsePeakPropertyModifyButton()
        {
            PulsePeakPropertyModifyButton.Click();
        }

        public Boolean IsPulsePeakPropertyModifyButtonDisplayed()
        {
            return PulsePeakPropertyModifyButton.IsDisplayed();
        }
        
        public void ClickPulsePeakPropertySaveButton()
        {
            PulsePeakPropertySaveButton.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
        }

        public Boolean IsPulsePeakPropertySaveButtonDisplayed()
        {
            return PulsePeakPropertySaveButton.IsDisplayed();
        }

        public void ClickPulsePeakPropertyCancelButton()
        {
            PulsePeakPropertyCancelButton.Click();
        }

        public Boolean IsPulsePeakPropertyCancelButtonDisplayed()
        {
            return PulsePeakPropertyCancelButton.IsDisplayed();
        }

        public Boolean IsPulsePeakPropertyRangeItemDeleteButtonDisplayed(int num)
        {
            Button OneDeleteRangeIcon = GetOneDeletePulsePeakRangeItemButton(num);
            return OneDeleteRangeIcon.IsDisplayed();
        }

        #endregion

        #region item operation
        public void FillInPulsePeakPropertyPriceValue(string price)
        {
            PulsePeakPropertyPriceValueTextField.Fill(price);
        }

        public void AddPulsePeakRanges(TOUPulsePeakTariffData testData)
        {
            for (int elementPosition = 1; elementPosition <= testData.InputData.PulsePeakRange.Length; elementPosition++)
            {
                //Click '添加峰时范围' button if more than one record need to be entered
                if (elementPosition > 1)
                {
                    ClickAddMorePulsePeakRangesButton();
                    TimeManager.ShortPause();
                }
                int inputDataArrayPosition = elementPosition - 1;

                SelectPulsePeakPropertyStartMonth(testData.InputData.PulsePeakRange[inputDataArrayPosition].StartMonth, elementPosition);
                SelectPulsePeakPropertyStartDate(testData.InputData.PulsePeakRange[inputDataArrayPosition].StartDate, elementPosition);
                SelectPulsePeakPropertyEndMonth(testData.InputData.PulsePeakRange[inputDataArrayPosition].EndMonth, elementPosition);
                SelectPulsePeakPropertyEndDate(testData.InputData.PulsePeakRange[inputDataArrayPosition].EndDate, elementPosition);
                SelectPulsePeakPropertyStartTime(testData.InputData.PulsePeakRange[inputDataArrayPosition].StartTime, elementPosition);
                SelectPulsePeakPropertyEndTime(testData.InputData.PulsePeakRange[inputDataArrayPosition].EndTime, elementPosition);                
                TimeManager.ShortPause();
            }
        }

        public void SelectPulsePeakPropertyStartMonth(string month, int num)
        {
            ComboBox OneStartMonth = GetOnePulsePeakPropertyStartMonthComboBox(num);
            OneStartMonth.SelectItem(month);
        }

        public void SelectPulsePeakPropertyStartDate(string date, int num)
        {
            ComboBox OneStartDate = GetOnePulsePeakPropertyStartDateComboBox(num);
            OneStartDate.SelectItem(date);
        }

        public void SelectPulsePeakPropertyEndMonth(string month, int num)
        {
            ComboBox OneEndMonth = GetOnePulsePeakPropertyEndMonthComboBox(num);
            OneEndMonth.SelectItem(month);
        }

        public void SelectPulsePeakPropertyEndDate(string date, int num)
        {
            ComboBox OneEndDate = GetOnePulsePeakPropertyEndDateComboBox(num);
            OneEndDate.SelectItem(date);
        }

        public void SelectPulsePeakPropertyStartTime(string time, int num)
        {
            ComboBox OneStartTime = GetOnePulsePeakPropertyStartTimeComboBox(num);
            OneStartTime.SelectItem(time);
        }

        public void SelectPulsePeakPropertyEndTime(string time, int num)
        {
            ComboBox OneEndTime = GetOnePulsePeakPropertyEndTimeComboBox(num);
            OneEndTime.SelectItem(time);
        }

        public void ClickAddMorePulsePeakRangesButton()
        {
            PulsePeakPropertyAddMoreRangesButton.ClickLink();
        }

        public void ClickDeletePulsePeakWholeRangeButton()
        {
            PulsePeakPropertyDeleteWholeRangeButton.Click();
        }

        public void ClickDeletePulsePeakRangeItemButton(int num)
        {
            Button OneDeleteRangeIcon = GetOneDeletePulsePeakRangeItemButton(num);
            OneDeleteRangeIcon.Click();
        }
        #endregion

        #region verification
        /// <summary>
        /// Judge whether the Pulse Peak Price textfield is invalid
        /// </summary>
        /// <returns>True if the Pulse Peak Price is invalid, false if not</returns>
        public Boolean IsPulsePeakPriceInvalid()
        {
            return PulsePeakPropertyPriceValueTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of Pulse Peak Price field is correct
        /// </summary>
        /// <param name="output">TOUPulse PeakTariffExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsPulsePeakPriceInvalidMsgCorrect(TOUPulsePeakTariffExpectedData output)
        {
            if (output.Price != null)
            {
                return PulsePeakPropertyPriceValueTextField.GetInvalidTipsForNumberField().Contains(output.Price);
            }
            else
                return true;
        }

        /// <summary>
        /// Judge whether invalid message of pulse peak range is correct
        /// </summary>
        /// <param name="output">TOUPulsePeakTariffExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsPulsePeakRangeInvalidMsgCorrect(TOUPulsePeakTariffExpectedData output, int position)
        {
            int arrayPosition = position - 1;
            ComboBox OnePulsePeakPropertyStartTimeComboBox = GetOnePulsePeakPropertyStartTimeComboBox(position);
            return OnePulsePeakPropertyStartTimeComboBox.GetInvalidTips().Contains(output.PulsePeakRange[arrayPosition].StartTime);
        }
        #endregion
        #region Get value
        public string GetPulsePeakPropertyPriceValue()
        {
            return PulsePeakPropertyPriceValueTextField.GetValue();
        }

        public string GetPulsePeakPropertyStartMonthValue(int num)
        {
            ComboBox OneStartMonth = GetOnePulsePeakPropertyStartMonthComboBox(num);
            return OneStartMonth.GetValue();
        }

        public string GetPulsePeakPropertyStartDateValue(int num)
        {
            ComboBox OneStartDate = GetOnePulsePeakPropertyStartDateComboBox(num);
            return OneStartDate.GetValue();
        }

        public string GetPulsePeakPropertyEndMonthValue(int num)
        {
            ComboBox OneEndMonth = GetOnePulsePeakPropertyEndMonthComboBox(num);
            return OneEndMonth.GetValue();
        }

        public string GetPulsePeakPropertyEndDateValue(int num)
        {
            ComboBox OneEndDate = GetOnePulsePeakPropertyEndDateComboBox(num);
            return OneEndDate.GetValue();
        }

        public string GetPulsePeakPropertyStartTimeValue(int num)
        {
            ComboBox OneStartTime = GetOnePulsePeakPropertyStartTimeComboBox(num);
            return OneStartTime.GetValue();
        }

        public string GetPulsePeakPropertyEndTimeValue(int num)
        {
            ComboBox OneEndTime = GetOnePulsePeakPropertyEndTimeComboBox(num);
            return OneEndTime.GetValue();
        }
        #endregion

        #region private method

        private ComboBox GetOnePulsePeakPropertyStartMonthComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxTOUPulsePeakPropertyStartMonth, positionIndex);
        }

        private ComboBox GetOnePulsePeakPropertyStartDateComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxTOUPulsePeakPropertyStartDate, positionIndex);
        }

        private ComboBox GetOnePulsePeakPropertyEndMonthComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxTOUPulsePeakPropertyEndMonth, positionIndex);
        }

        private ComboBox GetOnePulsePeakPropertyEndDateComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxTOUPulsePeakPropertyEndDate, positionIndex);
        }

        private ComboBox GetOnePulsePeakPropertyStartTimeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxTOUPulsePeakPropertyStartTime, positionIndex);
        }

        private ComboBox GetOnePulsePeakPropertyEndTimeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxTOUPulsePeakPropertyEndTime, positionIndex);
        }

        private Button GetOneDeletePulsePeakRangeItemButton(int positionIndex)
        {
            return JazzButton.GetOneButton(JazzControlLocatorKey.ButtonTOUPulsePeakPropertyDeleteRangeItem, positionIndex);
        }
        #endregion
    }
}
