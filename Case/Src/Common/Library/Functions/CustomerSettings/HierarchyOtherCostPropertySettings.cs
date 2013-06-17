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
    /// The business logic implement of Hierarchy other Cost Property Settings.
    /// </summary>
    public class HierarchyOtherCostPropertySettings
    {
        internal HierarchyOtherCostPropertySettings()
        {
        }

        #region Controls
        private static Button GasCostCreate = JazzButton.GasCostCreateButton;
        private static MonthPicker GasCostEffectiveDate = JazzMonthPicker.GasCostEffectiveDateMonthPicker;
        private static TextField GasCostPrice = JazzTextField.GasPriceTextField;
        private static Button WaterCostCreate = JazzButton.WaterCostCreateButton;
        private static MonthPicker WaterCostEffectiveYear = JazzMonthPicker.WaterCostEffectiveDateMonthPicker;
        private static TextField WaterCostPrice = JazzTextField.WaterPriceTextField;
        #endregion

        #region Gas Cost

        public void FillInGasCostValue(OtherCostInputData input)
        {
            GasCostEffectiveDate.SelectYearMonthItem(input.EffectiveDate);
            GasCostPrice.Append(input.Price);
        }

        public void ClickGasCostCreateButton()
        {
            GasCostCreate.Click();
        }

        public void SelectGasCostEffectiveDate(DateTime date)
        {
            GasCostEffectiveDate.SelectYearMonthItem(date);
        }

        public void FillGasCostPrice(string price)
        {
            GasCostPrice.Append(price);
        }

        public string GetGasCostEffectiveDate()
        {
            return GasCostEffectiveDate.GetValue();
        }

        public string GetGasCostPrice()
        {
            return GasCostPrice.GetValue();
        }
        #endregion

        #region Water Cost

        public void ClickWaterCostCreateButton()
        {
            WaterCostCreate.Click();
        }

        public void FillWaterCost_N(OtherCostInputData input, int position)
        {
            FillInWaterDate_N(input.EffectiveDate, position);
            FillInWaterPrice_N(input.Price, position);
        }

        public void FillInWaterPrice_N(string price, int position)
        {
            TextField OneWaterPrice = GetOneWaterPrice(position);

            OneWaterPrice.Fill(price);
        }

        public void FillInWaterDate_N(string price, int position)
        {
            MonthPicker OneWaterEffectiveYear = GetOneWaterEffectiveYear(position);

            OneWaterEffectiveYear.SelectYearMonthItem(price);
        }

        public Boolean IsWaterEffectiveYearInvalid_N(int position)
        {
            MonthPicker OneWaterEffectiveYear = GetOneWaterEffectiveYear(position);

            return OneWaterEffectiveYear.IsMonthPickerValueInvalid();
        }

        public Boolean IsWaterEffectiveYearInvalidMsgCorrect_N(string msg, int position)
        {
            MonthPicker OneWaterEffectiveYear = GetOneWaterEffectiveYear(position);

            return OneWaterEffectiveYear.GetInvalidTips().Contains(msg);
        }

        public Boolean IsWaterPriceInvalid_N(int position)
        {
            TextField OneWaterPrice = GetOneWaterPrice(position);

            return OneWaterPrice.IsTextFieldValueInvalid();
        }

        public Boolean IsWaterPriceInvalidMsgCorrect_N(string msg, int position)
        {
            TextField OneWaterPrice = GetOneWaterPrice(position);

            return OneWaterPrice.GetInvalidTipsForNumberField().Contains(msg);
        }

        private MonthPicker GetOneWaterEffectiveYear(int positionIndex)
        {
            return JazzMonthPicker.GetOneMonthPicker(JazzControlLocatorKey.MonthPickerWaterCostEffectiveDate, positionIndex);
        }

        private TextField GetOneWaterPrice(int positionIndex)
        {
            return JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldWaterPrice, positionIndex);
        }
        #endregion
    }
}
