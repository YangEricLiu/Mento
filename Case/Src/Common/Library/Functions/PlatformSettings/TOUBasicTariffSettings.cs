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

        #region Controls
        private static Grid TOUTariffsList = JazzGrid.TOUTariffsList;

        private static Button BasicPropertyCreateButton = JazzButton.TOUBasicPropertyCreateButton;
        private static Button BasicPropertyModifyButton = JazzButton.TOUBasicPropertyModifyButton;
        private static Button BasicPropertySaveButton = JazzButton.TOUBasicPropertySaveButton;
        private static Button BasicPropertyCancelButton = JazzButton.TOUBasicPropertyCancelButton;
        private static Button BasicPropertyDeleteButton = JazzButton.TOUBasicPropertyDeleteButton;
        private static Button BasicPropertyDeletePeakRangeItemButton = JazzButton.TOUBasicPropertyDeletePeakRangeItemButton;
        private static Button BasicPropertyDeleteValleyRangeItemButton = JazzButton.TOUBasicPropertyDeleteValleyRangeItemButton;
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
        private static Label BasicPropertyLabel = JazzLabel.PlatformTOUBasicPropertyLabel;
        private static Container TOU24HoursErrorTips = JazzContainer.TOU24HoursErrorTipsContainer;

        #endregion

        #region common action

        public void NavigatorToTimeSettings()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettings);
        }

        public void NavigatorToPriceSettings()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.PriceSettingsPrice);
        }

        public void ClickBasicPropertyCreateButton()
        {
            BasicPropertyCreateButton.Click();
        }

        public void ClickBasicPropertySaveButton()
        {
            BasicPropertySaveButton.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
        }

        public Boolean IsBasicPropertySaveButtonDisplayed()
        {
            return BasicPropertySaveButton.IsDisplayed();
        }

        public void SelectTOU(string touName)
        {
            TOUTariffsList.FocusOnRow(1, touName, false);
        }

        public void ClickBasicPropertyModifyButton()
        {
            BasicPropertyModifyButton.Click();
        }

        public Boolean IsBasicPropertyModifyButtonDisplayed()
        {
            return BasicPropertyModifyButton.IsDisplayed();
        }

        public void ClickBasicPropertyCancelButton()
        {
            BasicPropertyCancelButton.Click();
        }

        public Boolean IsBasicPropertyCancelButtonDisplayed()
        {
            return BasicPropertyCancelButton.IsDisplayed();
        }

        public void ClickBasicPropertyDeleteButton()
        {
            BasicPropertyDeleteButton.Click();
        }

        public void ClickMsgBoxConfirmButton()
        {
            JazzMessageBox.MessageBox.Confirm();
        }

        public void ClickMsgBoxCancelButton()
        {
            JazzMessageBox.MessageBox.Cancel();
        }

        public void ClickMsgBoxDeleteButton()
        {
            JazzMessageBox.MessageBox.Delete();
        }

        public void ClickMsgBoxGiveUpButton()
        {
            JazzMessageBox.MessageBox.GiveUp();
        }

        public void ClickMsgBoxCloseButton()
        {
            JazzMessageBox.MessageBox.Close();
        }

        public void ClickMsgBoxOKButton()
        {
            JazzMessageBox.MessageBox.OK();
        }

        #endregion

        #region item operation
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

        public void AddPeakRanges(TOUBasicTariffData testData)
        {
            for (int elementPosition = 1; elementPosition <= testData.InputData.PeakRange.Length; elementPosition++)
            {
                //Click '添加峰时范围' button if more than one record need to be entered
                if (elementPosition > 1)
                {
                    ClickAddMorePeakRangesButton();
                    TimeManager.ShortPause();
                }
                int inputDataArrayPosition = elementPosition - 1;
                SelectBasicPropertyPeakStartTime(testData.InputData.PeakRange[inputDataArrayPosition].StartTime, elementPosition);
                SelectBasicPropertyPeakEndTime(testData.InputData.PeakRange[inputDataArrayPosition].EndTime, elementPosition);
                TimeManager.ShortPause();
            }
        }
                
        public void AddValleyRanges(TOUBasicTariffData testData)
        {
            for (int elementPosition = 1; elementPosition <= testData.InputData.ValleyRange.Length; elementPosition++)
            {
                //Click '添加谷时范围' button if more than one record need to be entered
                if (elementPosition > 1)
                {
                    ClickAddMoreValleyRangesButton();
                    TimeManager.ShortPause();
                }
                int inputDataArrayPosition = elementPosition - 1;
                SelectBasicPropertyValleyStartTime(testData.InputData.ValleyRange[inputDataArrayPosition].StartTime, elementPosition);
                SelectBasicPropertyValleyEndTime(testData.InputData.ValleyRange[inputDataArrayPosition].EndTime, elementPosition);
                TimeManager.ShortPause();
            }
        }

        public void ClickAddMorePeakRangesButton()
        {
            BasicPropertyAddMorePeakRangesButton.ClickLink();
        }

        public void ClickAddMoreValleyRangesButton()
        {
            BasicPropertyAddMoreValleyRangesButton.ClickLink();
        }

        public void ClickDeletePeakRangeItemButton(int num)
        {
            Button OneDeleteRangeIcon = GetOneBasicPropertyDeletePeakRangeItemButton(num);
            OneDeleteRangeIcon.Click();
        }

        public void ClickDeleteValleyRangeItemButton(int num)
        {
            Button OneDeleteRangeIcon = GetOneBasicPropertyDeleteValleyRangeItemButton(num);
            OneDeleteRangeIcon.Click();
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
        #endregion

        #region verification
        /// <summary>
        /// Judge whether the textfield and its label are hidden
        /// </summary>
        /// <returns>True if it is hidden, false if not</returns>
        public Boolean IsPlainPriceHidden()
        {
            return BasicPropertyPlainPriceValueTextField.IsTextFieldHidden();
        }

        /// <summary>
        /// Judge whether the name textfield is invalid
        /// </summary>
        /// <returns>True if the name is invalid, false if not</returns>
        public Boolean IsNameInvalid()
        {
            return BasicPropertyNameTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of name field is correct
        /// </summary>
        /// <param name="output">TOUBasicTariffExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsNameInvalidMsgCorrect(TOUBasicTariffExpectedData output)
        {
            return BasicPropertyNameTextField.GetInvalidTips().Contains(output.CommonName);            
        }
        
        /// <summary>
        /// Judge whether the Plain Price textfield is invalid
        /// </summary>
        /// <returns>True if the Plain Price is invalid, false if not</returns>
        public Boolean IsPlainPriceInvalid()
        {
            return BasicPropertyPlainPriceValueTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of Plain Price field is correct
        /// </summary>
        /// <param name="output">TOUBasicTariffExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsPlainPriceInvalidMsgCorrect(TOUBasicTariffExpectedData output)
        {
            if (output.PlainPrice != null)
            {
                return BasicPropertyPeakPriceValueTextField.GetInvalidTipsForNumberField().Contains(output.PlainPrice);
            }
            else
                return true;
        }

        /// <summary>
        /// Judge whether the Peak Price textfield is invalid
        /// </summary>
        /// <returns>True if the Peak Price is invalid, false if not</returns>
        public Boolean IsPeakPriceInvalid()
        {
            return BasicPropertyPeakPriceValueTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of Peak Price field is correct
        /// </summary>
        /// <param name="output">TOUBasicTariffExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsPeakPriceInvalidMsgCorrect(TOUBasicTariffExpectedData output)
        {
            if (output.PeakPrice != null)
            {
                return BasicPropertyPeakPriceValueTextField.GetInvalidTipsForNumberField().Contains(output.PeakPrice);
            }
            else
                return true;
        }
        
        /// <summary>
        /// Judge whether the Valley Price textfield is invalid
        /// </summary>
        /// <returns>True if the Valley Price is invalid, false if not</returns>
        public Boolean IsValleyPriceInvalid()
        {
            return BasicPropertyValleyPriceValueTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Judge whether invalid message of Valley Price field is correct
        /// </summary>
        /// <param name="output">TOUBasicTariffExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsValleyPriceInvalidMsgCorrect(TOUBasicTariffExpectedData output)
        {
            if (output.ValleyPrice != null)
            {
                return BasicPropertyValleyPriceValueTextField.GetInvalidTipsForNumberField().Contains(output.ValleyPrice);
            }
            else
                return true;
        }
        
        /// <summary>
        /// Judge whether invalid message of peak range is correct
        /// </summary>
        /// <param name="output">TOUBasicTariffExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsPeakRangeInvalidMsgCorrect(TOUBasicTariffExpectedData output, int position)
        {
            int arrayPosition = position - 1;
            ComboBox OneBasicPropertyPeakStartTimeComboBox = GetOneBasicPropertyPeakStartTimeComboBox(position);
            return OneBasicPropertyPeakStartTimeComboBox.GetInvalidTips().Contains(output.PeakRange[arrayPosition].StartTime);
        }

        /// <summary>
        /// Judge whether invalid message of valley range is correct
        /// </summary>
        /// <param name="output">TOUBasicTariffExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsValleyRangeInvalidMsgCorrect(TOUBasicTariffExpectedData output, int position)
        {
            int arrayPosition = position - 1;
            ComboBox OneBasicPropertyValleyStartTimeComboBox = GetOneBasicPropertyValleyStartTimeComboBox(position);
            return OneBasicPropertyValleyStartTimeComboBox.GetInvalidTips().Contains(output.ValleyRange[arrayPosition].StartTime);
        }

        /// <summary>
        /// Judge whether invalid message is correct when TOU didn't cover 24 hours and plain price is empty.
        /// </summary>
        /// <param name="output">TOUBasicTariffExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsTOU24HoursMsgCorrect(string output)
        {
            return TOU24HoursErrorTips.GetContainerErrorTips().Contains(output);
        }

        /// <summary>
        /// Judge whether the pop message correct
        /// </summary>
        /// <param name="output">TOUBasicTariffExpectedData</param>
        /// <returns>whether the invalid message is ture</returns>
        public Boolean IsPopMsgCorrect(TOUBasicTariffExpectedData output)
        {
            if (output.PopMessage != null)
            {
                return GetMessageText().Contains(output.PopMessage);
            }
            else
                return true;
        }

        /// <summary>
        /// Judge whether the label text '若设置平时电价，平时电价将充满峰时电价和谷时电价未覆盖的时间段。' is displayed correct
        /// </summary>
        /// <param name="output">TOUBasicTariffExpectedData</param>
        /// <returns>whether the label text is ture</returns>
        public Boolean IsTOUBasicPropertyTextCorrect(string[] texts)
        {
            return BasicPropertyLabel.IsLabelTextsExisted(texts);
        }

        public Boolean IsTOUExist(string touName)
        {
            return TOUTariffsList.IsRowExist(1, touName);
        }

        #endregion

        #region Get value
        /// <summary>
        /// Get message in the pop up message box. 
        /// </summary>
        /// <returns></returns>
        public string GetMessageText()
        {
            JazzMessageBox.LoadingMask.WaitLoading();
            return JazzMessageBox.MessageBox.GetMessage();
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
        #endregion
        
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

        private Button GetOneBasicPropertyDeletePeakRangeItemButton(int positionIndex)
        {
            return JazzButton.GetOneButton(JazzControlLocatorKey.ButtonTOUBasicPropertyDeletePeakRangeItem, positionIndex);
        }

        private Button GetOneBasicPropertyDeleteValleyRangeItemButton(int positionIndex)
        {
            return JazzButton.GetOneButton(JazzControlLocatorKey.ButtonTOUBasicPropertyDeleteValleyRangeItem, positionIndex);
        }

        #endregion
    }
}
