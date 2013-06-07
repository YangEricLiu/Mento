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

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of Hierarchy PeopleArea Settings.
    /// </summary>
    public class HierarchyPeopleAreaSettings
    {
        internal HierarchyPeopleAreaSettings()
        {
        }

        #region Controls
        private static TabButton PeopleAreaTab = JazzButton.PeopleAreaPropertyTabButton;
        private static Button PeopleAreaCreate = JazzButton.PeopleAreaCreateButton;
        private static Button PeopleAreaUpdate = JazzButton.PeopleAreaUpdateButton;
        private static Button PeopleAreaSave = JazzButton.PeopleAreaSaveButton;
        private static Button PeopleAreaCancel = JazzButton.PeopleAreaCancelButton; 
        private static TextField TotalAreaValue = JazzTextField.TotalAreaValueTextField;
        private static TextField HeatingAreaValue = JazzTextField.HeatingAreaValueTextField;
        private static TextField CoolingAreaValue = JazzTextField.CoolingAreaValueTextField;
        private static TextField PeopleNumber = JazzTextField.PeopleNumberTextField;

        private static Button PeopleCreate = JazzButton.PeopleCreateButton;
        private static MonthPicker PeopleEffectiveDate = JazzMonthPicker.PeopleEffectiveDateMonthPicker;
        private static Container PeopleItems = JazzContainer.PeopleItemsContainer;
        private static Label AreaPropertyTitle = JazzLabel.AreaPropertyTitleLabel;
        private static Container PeopleErrorTips = JazzContainer.PeopleErrorTipsContainer;
        #endregion

        #region People Area
        public void ClickPeopleAreaTab()
        {
            PeopleAreaTab.Click();
        }

        public bool IsPeopleAreaTabEnable()
        {
            return PeopleAreaTab.IsEnabled();
        }

        public bool IsPeopleAreaCreateButtonDisplayed()
        {
            return PeopleAreaCreate.IsDisplayed();
        }

        public void ClickPeopleAreaCreateButton()
        {
            if (PeopleAreaCreate.IsDisplayed())
            {
                PeopleAreaCreate.Click();
            }
            else if (PeopleAreaUpdate.IsDisplayed())
            {
                PeopleAreaUpdate.Click();
            }
        }

        public void ClickSaveButton()
        {
            PeopleAreaSave.Click();
            JazzMessageBox.LoadingMask.WaitLoading(maxtime: 2);
        }

        public bool IsSaveButtonDisplayed()
        {
            return PeopleAreaSave.IsDisplayed();
        }

        public void ClickCancelButton()
        {
            PeopleAreaCancel.Click();
        }

        public bool IsCancelButtonDisplayed()
        {
            return PeopleAreaCancel.IsDisplayed();
        }
        #endregion

        #region Area

        /// <summary>
        /// Input total, heating, cooling value
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInAreaValue(PeopleAreaPropertyInputData input)
        {
            InputTotalAreaValue(input.TotalArea);
            InputHeatingAreaValue(input.HeatingArea);
            InputCoolingAreaValue(input.CoolingArea);
        }

        /// <summary>
        /// Input total, heating, cooling value
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillValidOrInvalidAreaValue(PeopleAreaPropertyInputData input)
        {
            InputTotalAreaValue(input.IntegerValue);
            InputHeatingAreaValue(input.IntegerValue);
            InputCoolingAreaValue(input.IntegerValue);
        }

        public void InputTotalAreaValue(string value)
        {
            TotalAreaValue.Fill(value);
        }

        public bool IsTotalAreaInvalid()
        {
            return TotalAreaValue.IsTextFieldValueInvalid();
        }

        public bool IsTotalAreaInvalidMsgCorrect(string msg)
        {
            return TotalAreaValue.GetInvalidTipsForNumberField().Contains(msg);
        }

        public void InputHeatingAreaValue(string value)
        {
            HeatingAreaValue.Fill(value);
        }

        public bool IsHeatingAreaInvalid()
        {
            return HeatingAreaValue.IsTextFieldValueInvalid();
        }

        public bool IsHeatingAreaInvalidMsgCorrect(string msg)
        {
            return HeatingAreaValue.GetInvalidTipsForNumberField().Contains(msg);
        }

        public void InputCoolingAreaValue(string value)
        {
            CoolingAreaValue.Fill(value);
        }

        public bool IsCoolingAreaInvalid()
        {
            return CoolingAreaValue.IsTextFieldValueInvalid();
        }

        public bool IsCoolingAreaInvalidMsgCorrect(string msg)
        {
            return CoolingAreaValue.GetInvalidTipsForNumberField().Contains(msg);
        }

        public string GetTotalAreaValue()
        {
            return TotalAreaValue.GetValue();
        }

        public string GetHeatingAreaValue()
        {
            return HeatingAreaValue.GetValue();
        }

        public string GetCoolingAreaValue()
        {
            return CoolingAreaValue.GetValue();
        }

        public bool IsAreaPropertyTitleDisplay(string title)
        {
            return AreaPropertyTitle.IsLabelTextExisted(title);
        }
        #endregion

        #region People

        public void  ClickPeopleCreateButton()
        {
            PeopleCreate.Click();
        }

        /// <summary>
        /// Input DayNight Calendar value
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        /// 
        public void FillValidOrInvalidPeopleValue(PeopleAreaPropertyInputData input)
        {
            SelectEffectiveDate(input.PeopleEffectiveDate);
            InputPeopleNumber(input.IntegerValue);
        }

        /// <summary>
        /// Input DayNight Calendar value
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        /// 
        public void FillInPeopleValue(PeopleAreaPropertyInputData input)
        {
            SelectEffectiveDate(input.PeopleEffectiveDate);
            InputPeopleNumber(input.PeopleNumber);
        }

        public void FillInPeopleValue_N(PeopleAreaPropertyInputData input, int position)
        {
            SelectEffectiveDate_N(input.PeopleEffectiveDate, position);
            InputPeopleNumber_N(input.PeopleNumber, position);
        }


        public void SelectEffectiveDate(DateTime date)
        {
            PeopleEffectiveDate.SelectYearMonthItem(date);
        }

        public void SelectEffectiveDate(string date)
        {
            PeopleEffectiveDate.SelectYearMonthItem(date);
        }

        public void SelectEffectiveDate_N(string date, int position)
        {
            MonthPicker PeopleEffectiveDateN = JazzMonthPicker.GetOneMonthPicker(JazzControlLocatorKey.MonthPickerPeopleEffectiveDate, position);

            PeopleEffectiveDateN.SelectYearMonthItem(date);
        }

        public void InputPeopleNumber(string number)
        {
            PeopleNumber.Fill(number);
        }

        public void InputPeopleNumber_N(string number, int position)
        {
            TextField PeopleNumberN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldPeopleNumber, position);

            PeopleNumberN.Fill(number);
        }

        public bool IsPeopleNumberInvalid()
        {
            return PeopleNumber.IsTextFieldValueInvalid();
        }

        public bool IsPeopleNumberInvalid_N(int position)
        {
            TextField PeopleNumberN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldPeopleNumber, position);

            return PeopleNumberN.IsTextFieldValueInvalid();
        }

        public string GetEffectiveDateValue()
        {
            return PeopleEffectiveDate.GetValue();
        }

        public string GetEffectiveDateValue_N(int position)
        {
            MonthPicker PeopleEffectiveDateN = JazzMonthPicker.GetOneMonthPicker(JazzControlLocatorKey.MonthPickerPeopleEffectiveDate, position);

            return PeopleEffectiveDateN.GetValue();
        }

        public string GetPeopleNumberValue()
        {
            return PeopleNumber.GetValue();
        }

        public string GetPeopleNumberValue_N(int position)
        {
            TextField PeopleNumberN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldPeopleNumber, position);

            return PeopleNumberN.GetValue();
        }

        public bool IsPeopleNumberInvalidMsgCorrect(string msg)
        {
            return PeopleNumber.GetInvalidTipsForNumberField().Contains(msg);
        }

        public bool IsPeopleNumberInvalidMsgCorrect_N(string msg, int position)
        {
            TextField PeopleNumberN = JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldPeopleNumber, position);

            return PeopleNumberN.GetInvalidTipsForNumberField().Contains(msg);
        }

        public int GetPeopleItemsNumber()
        {
            return PeopleItems.GetElementNumber();
        }

        public void PeopleItemToView_N(int position)
        {
            string scriptString = "arguments[0].scrollIntoView();";

            MonthPicker PeopleEffectiveDateN = JazzMonthPicker.GetOneMonthPicker(JazzControlLocatorKey.MonthPickerPeopleEffectiveDate, position);

            PeopleEffectiveDateN.ExecuteJavaScriptOnControl(scriptString);
        }

        public bool IsEffectiveDateInvalid()
        {
            return PeopleEffectiveDate.IsMonthPickerValueInvalid();
        }

        public bool IsEffectiveDateInvalid_N(int position)
        {
            MonthPicker PeopleEffectiveDateN = JazzMonthPicker.GetOneMonthPicker(JazzControlLocatorKey.MonthPickerPeopleEffectiveDate, position);

            return PeopleEffectiveDateN.IsMonthPickerValueInvalid();
        }

        public bool IsEffectiveDateInvalidMsgCorrect(string msg)
        {
            return PeopleEffectiveDate.GetInvalidTips().Contains(msg);
        }

        public bool IsEffectiveDateInvalidMsgCorrect_N(string msg, int position)
        {
            MonthPicker PeopleEffectiveDateN = JazzMonthPicker.GetOneMonthPicker(JazzControlLocatorKey.MonthPickerPeopleEffectiveDate, position);

            return PeopleEffectiveDateN.GetInvalidTips().Contains(msg);
        }

        public string GetPeopleContainerErrorTips()
        {
            return PeopleErrorTips.GetContainerErrorTips();
        }
        #endregion
    }
}
