using System;
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

        private static Grid TOUTariffsList = JazzGrid.TOUTariffsList;

        private static TabButton PulsePeakPropertyTab = JazzButton.TOUPulsePeakPropertyTabButton;
        private static Button PulsePeakPropertyCreateButton = JazzButton.TOUPulsePeakPropertyCreateButton;
        private static Button PulsePeakPropertyPlusIconButton = JazzButton.TOUPulsePeakPropertyPlusIconButton;
        private static Button PulsePeakPropertyModifyButton = JazzButton.TOUPulsePeakPropertyModifyButton;
        private static Button PulsePeakPropertySaveButton = JazzButton.TOUPulsePeakPropertySaveButton;
        private static Button PulsePeakPropertyCancelButton = JazzButton.TOUPulsePeakPropertyCancelButton;
        private static LinkButton PulsePeakPropertyAddMorePulsePeakRangesButton = JazzButton.TOUPulsePeakPropertyAddMorePulsePeakRangesButton;
        
        private static TextField PulsePeakPropertyPriceValueTextField = JazzTextField.TOUPulsePeakPropertyPriceValueTextField;

        private static ComboBox PulsePeakPropertyStartMonthComboBox = JazzComboBox.TOUPulsePeakPropertyStartMonthComboBox;
        private static ComboBox PulsePeakPropertyStartDateComboBox = JazzComboBox.TOUPulsePeakPropertyStartDateComboBox;
        private static ComboBox PulsePeakPropertyEndMonthComboBox = JazzComboBox.TOUPulsePeakPropertyEndMonthComboBox;
        private static ComboBox PulsePeakPropertyEndDateComboBox = JazzComboBox.TOUPulsePeakPropertyEndDateComboBox;
        private static ComboBox PulsePeakPropertyStartTimeComboBox = JazzComboBox.TOUPulsePeakPropertyStartTimeComboBox;
        private static ComboBox PulsePeakPropertyEndTimeComboBox = JazzComboBox.TOUPulsePeakPropertyEndTimeComboBox;

        public void NavigatorToPriceSettings()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.PriceSettingsPrice);
            //TimeManager.ShortPause();
        }        
                
        public void FocusOnTOUTariff(string touTariffName)
        {
            TOUTariffsList.FocusOnRow(1, touTariffName);
        }

        public void SwitchToPulsePeakPropertyTab()
        {
            PulsePeakPropertyTab.Click();
        }
      
        public void PrepareToAddTOUPulsePeakProperty()
        {
            PulsePeakPropertyCreateButton.Click();
            PulsePeakPropertyPlusIconButton.Click();
        }

        public void FillInPulsePeakPropertyPriceValue(string price)
        {
            PulsePeakPropertyPriceValueTextField.Fill(price);
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
            PulsePeakPropertyAddMorePulsePeakRangesButton.ClickLink();
        }

        public void ClickPulsePeakPropertySaveButton()
        {
            PulsePeakPropertySaveButton.Click();
        }

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
        #endregion
    }
}
