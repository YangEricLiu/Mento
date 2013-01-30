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
    /// The business logic implement of TOU basic tariff management.
    /// </summary>
    public class TOUBasicTariffSettings
    {
        internal TOUBasicTariffSettings()
        {
        }

        private static Grid TOUTariffsList = JazzGrid.TOUTariffsList;

        private static Button BasicPropertyCreateButton = JazzButton.TOUBasicPropertyCreateButton;
        private static Button BasicPropertyModifyButton = JazzButton.TOUBasicPropertyModifyButton;
        private static Button BasicPropertySaveButton = JazzButton.TOUBasicPropertySaveButton;
        private static Button BasicPropertyCancelButton = JazzButton.TOUBasicPropertyCancelButton;
        private static Button BasicPropertyDeleteButton = JazzButton.TOUBasicPropertyDeleteButton;
        private static LinkButton BasicPropertyAddMorePeakRangesButton = JazzButton.TOUBasicPropertyAddMorePeakRangesButton;
        private static LinkButton BasicPropertyAddMoreValleyRangesButton = JazzButton.TOUBasicPropertyAddMoreValleyRangesButton;
        
        private static TextField BasicPropertyNameTextField = JazzTextField.TOUBasicPropertyNameTextField;
        private static TextField BasicPropertyPlainPriceValueTextField = JazzTextField.TOUBasicPropertyPlainPriceValueTextField;
        private static TextField BasicPropertyPeakPriceValueTextField = JazzTextField.TOUBasicPropertyPeakPriceValueTextField;
        private static TextField BasicPropertyValleyPriceValueTextField = JazzTextField.TOUBasicPropertyValleyPriceValueTextField;
        
        private static ComboBox BasicPropertyPeakStartTimeComboBox = JazzComboBox.TOUBasicPropertyPeakStartTimeComboBox;
        private static ComboBox BasicPropertyPeakEndTimeComboBox = JazzComboBox.TOUBasicPropertyPeakEndTimeComboBox;
        private static ComboBox BasicPropertyValleyStartTimeComboBox = JazzComboBox.TOUBasicPropertyValleyStartTimeComboBox;
        private static ComboBox BasicPropertyValleyEndTimeComboBox = JazzComboBox.TOUBasicPropertyValleyEndTimeComboBox;
        
        public void NavigatorToPriceSettings()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.PriceSettingsPrice);
            //TimeManager.ShortPause();
        }        
                
        public void PrepareToAddTOUBasicProperty()
        {
            BasicPropertyCreateButton.Click();
        }

        public void FillInBasicPropertyName(string name)
        {
            BasicPropertyNameTextField.Fill(name);
        }

        public void FillInBasicPropertyPlainPriceValue(string price)
        {
            BasicPropertyPlainPriceValueTextField.Fill(price);
        }

        public void FillInBasicPropertyPeakPriceValue(string price)
        {
            BasicPropertyPeakPriceValueTextField.Fill(price);
        }

        public void FillInBasicPropertyValleyPriceValue(string price)
        {
            BasicPropertyValleyPriceValueTextField.Fill(price);
        }

        public void SelectBasicPropertyPeakStartTime(string time, int num)
        {
            ComboBox OneStartTime = GetOneBasicPropertyPeakStartTimeComboBox(num);
            OneStartTime.SelectItem(time); 
        }

        public void SelectBasicPropertyPeakEndTime(string time, int num)
        {
            ComboBox OneEndTime = GetOneBasicPropertyPeakEndTimeComboBox(num);
            OneEndTime.SelectItem(time);             
        }

        public void SelectBasicPropertyValleyStartTime(string time, int num)
        {
            ComboBox OneStartTime = GetOneBasicPropertyValleyStartTimeComboBox(num);
            OneStartTime.SelectItem(time);
        }

        public void SelectBasicPropertyValleyEndTime(string time, int num)
        {
            ComboBox OneEndTime = GetOneBasicPropertyValleyEndTimeComboBox(num);
            OneEndTime.SelectItem(time);
        }

        public void ClickAddMorePeakRangesButton()
        {
            BasicPropertyAddMorePeakRangesButton.ClickLink();
        }

        public void ClickAddMoreValleyRangesButton()
        {
            BasicPropertyAddMoreValleyRangesButton.ClickLink();
        }

        public void ClickBasicPropertySaveButton()
        {
            BasicPropertySaveButton.Click();
        }

        public string GetBasicPropertyNameValue()
        {
            return BasicPropertyNameTextField.GetValue();
        }

        public string GetBasicPropertyPlainPriceValue()
        {
            return BasicPropertyPlainPriceValueTextField.GetValue();
        }

        public string GetBasicPropertyPeakPriceValue()
        {
            return BasicPropertyPeakPriceValueTextField.GetValue();
        }

        public string GetBasicPropertyValleyPriceValue()
        {
            return BasicPropertyValleyPriceValueTextField.GetValue();
        }

        public string GetBasicPropertyPeakStartTimeValue(int num)
        {
            ComboBox OneStartTime = GetOneBasicPropertyPeakStartTimeComboBox(num);
            return OneStartTime.GetValue();
        }

        public string GetBasicPropertyPeakEndTimeValue(int num)
        {
            ComboBox OneEndTime = GetOneBasicPropertyPeakEndTimeComboBox(num);
            return OneEndTime.GetValue();
        }

        public string GetBasicPropertyValleyStartTimeValue(int num)
        {
            ComboBox OneStartTime = GetOneBasicPropertyValleyStartTimeComboBox(num);
            return OneStartTime.GetValue();
        }

        public string GetBasicPropertyValleyEndTimeValue(int num)
        {
            ComboBox OneEndTime = GetOneBasicPropertyValleyEndTimeComboBox(num);
            return OneEndTime.GetValue();
        }
        
        #region private method

        private ComboBox GetOneBasicPropertyPeakStartTimeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxTOUBasicPropertyPeakStartTime, positionIndex);
        }

        private ComboBox GetOneBasicPropertyPeakEndTimeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxTOUBasicPropertyPeakEndTime, positionIndex);
        }

        private ComboBox GetOneBasicPropertyValleyStartTimeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxTOUBasicPropertyValleyStartTime, positionIndex);
        }

        private ComboBox GetOneBasicPropertyValleyEndTimeComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxTOUBasicPropertyValleyEndTime, positionIndex);
        }
        #endregion
    }
}
