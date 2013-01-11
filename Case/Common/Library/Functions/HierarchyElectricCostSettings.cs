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
    /// The business logic implement of Hierarchy Cost Property Settings.
    /// </summary>
    public class HierarchyElectricCostSettings
    {
        internal HierarchyElectricCostSettings()
        {
        }

        #region Controls
        private static TabButton CostProperty = JazzButton.CostPropertyTabButton;
        private static Button CostCreate = JazzButton.CostCreateButton;
        private static Button CostUpdate = JazzButton.CostUpdateButton;
        private static Button ElectricCostCreate = JazzButton.ElectricCostCreateButton;
        private static ComboBox ElectricPriceMode = JazzComboBox.ElectricPriceModeComboBox;
        private static MonthPicker ElectricCostEffectiveDate = JazzMonthPicker.ElectricCostEffectiveDateMonthPicker;
        private static TextField ElectricPrice = JazzTextField.ElectricPriceTextField;
        private static Button CostSave = JazzButton.CostSaveButton;
        
        #endregion

        #region cost property
        public void ClickCostPropertyTabButton()
        {
            CostProperty.Click();
        }

        public void ClickCostCreateButton()
        {
            if (CostCreate.IsDisplayed())
            {
                CostCreate.Click();
            }
            else if (CostUpdate.IsDisplayed())
            {
                CostUpdate.Click();
            }
        }

        public void ClickElectricCostCreateButton()
        {
            ElectricCostCreate.Click();
        }

        public void SelectElectricPriceMode(string priceMode)
        {
            ElectricPriceMode.SelectItem(priceMode);
        }

        public void SelectElectricEffectiveDate(DateTime date)
        {
            ElectricCostEffectiveDate.SelectYearMonthItem(date);
        }

        public void FillElectricPrice(string price)
        {
            ElectricPrice.Append(price);
        }

        public void ClickCostSaveButton()
        {
            CostSave.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public string GetElectricCostEffectiveDateValue()
        {
            return ElectricCostEffectiveDate.GetValue();
        }

        public string GetElectricPriceValue()
        {
            return ElectricPrice.GetValue();
        }

        public string GetElectricPriceMode()
        {
            return ElectricPriceMode.GetValue();
        }
        #endregion

    }
}
