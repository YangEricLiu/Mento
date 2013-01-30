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
    }
}
