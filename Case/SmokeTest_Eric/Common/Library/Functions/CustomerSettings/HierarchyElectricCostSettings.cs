using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.SmokeTest;
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

        private static string TRANSFORMERCAPACITYMODE = "变压器容量模式";
        private static string TIMECAPACITYMODE = "时间容量模式";

        #region Controls
        private static TabButton CostProperty = JazzButton.CostPropertyTabButton;
        private static Button CostCreate = JazzButton.CostCreateButton;
        private static Button CostUpdate = JazzButton.CostUpdateButton;
        private static Button ElectricCostCreate = JazzButton.ElectricCostCreateButton;
        private static ComboBox ElectricPriceMode = JazzComboBox.ElectricPriceModeComboBox;
        private static MonthPicker ElectricCostEffectiveDate = JazzMonthPicker.ElectricCostEffectiveDateMonthPicker;
        private static TextField ElectricPrice = JazzTextField.ElectricPriceTextField;
        private static Button CostSave = JazzButton.CostSaveButton;
        private static ComboBox DemandCostType = JazzComboBox.DemandCostTypeComboBox;
        private static ComboBox TouTariffId = JazzComboBox.TouTariffIdComboBox;
        private static ComboBox FactorType = JazzComboBox.FactorTypeComboBox;
        private static ComboBox RealTagId = JazzComboBox.RealTagIdComboBox;
        private static ComboBox ReactiveTagId = JazzComboBox.ReactiveTagIdComboBox;
        private static ComboBox HourTagId = JazzComboBox.HourTagIdComboBox;
        private static TextField ElectricPaddingCost = JazzTextField.ElectricPaddingCostTextField;
        private static TextField ElectricTransformerCapacity = JazzTextField.ElectricTransformerCapacityTextField;
        private static TextField ElectricTransformerPrice = JazzTextField.ElectricTransformerPriceTextField;
        private static TextField ElectricHourPrice = JazzTextField.ElectricHourPriceTextField;
        #endregion

        #region electric cost property
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

        public void ClickCostSaveButton()
        {
            CostSave.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
        }
        #endregion

        #region fill in value

        /// <summary>
        /// Input comprehensive electric cost value
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInComprehensiveCost(ElectricComprehensiveCostInputData input)
        {
            ElectricCostEffectiveDate.SelectYearMonthItem(input.EffectiveDate);
            ElectricPriceMode.SelectItem(input.PriceMode);
            DemandCostType.SelectItem(input.DemandCostType);

            if (String.Equals(input.DemandCostType, TRANSFORMERCAPACITYMODE))
            {
                ElectricTransformerCapacity.Append(input.TransformerCapacity);
                ElectricTransformerPrice.Append(input.TransformerPrice);
            }
            else if (String.Equals(input.DemandCostType, TRANSFORMERCAPACITYMODE))
            {
                HourTagId.SelectItem(input.HourTagId);
                ElectricHourPrice.Append(input.ElectricHourPrice);
            }
            
            TouTariffId.SelectItem(input.TouTariffId);
            FactorType.SelectItem(input.FactorType);
            RealTagId.SelectItem(input.RealTagId);
            ReactiveTagId.SelectItem(input.ReactiveTagId);
            ElectricPaddingCost.Append(input.ElectricPaddingCost);
        }

        /// <summary>
        /// Input Fixed electric cost value
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInFixedCost(ElectricFixedCostInputData input)
        {
            ElectricCostEffectiveDate.SelectYearMonthItem(input.EffectiveDate);
            ElectricPriceMode.SelectItem(input.PriceMode);
            ElectricPrice.Append(input.Price);
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

        public void SelectDemandCostType(string type)
        {
            DemandCostType.SelectItem(type);
        }

        public void SelectTouTariffId(string tariffId)
        {
            TouTariffId.SelectItem(tariffId);
        }

        public void SelectFactorType(string factorType)
        {
            FactorType.SelectItem(factorType);
        }

        public void SelectRealTagId(string realTagId)
        {
            RealTagId.SelectItem(realTagId);
        }

        public void SelectReactiveTagId(string reactiveTagId)
        {
            ReactiveTagId.SelectItem(reactiveTagId);
        }

        public void SelectHourTagId(string hourTagId)
        {
            HourTagId.SelectItem(hourTagId);
        }

        public void FillElectricPaddingCost(string cost)
        {
            ElectricPaddingCost.Append(cost);
        }

        public void FillElectricTransformerCapacity(string capacity)
        {
            ElectricTransformerCapacity.Append(capacity);
        }

        public void FillElectricTransformerPrice(string price)
        {
            ElectricTransformerPrice.Append(price);
        }

        public void FillElectricHourPrice(string price)
        {
            ElectricHourPrice.Append(price);
        }

        #endregion

        #region get controls value
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

        public string GetDemandCostTypeValue()
        {
            return DemandCostType.GetValue();
        }

        public string GetTouTariffIdValue()
        {
            return TouTariffId.GetValue();
        }

        public string GetFactorTypeValue()
        {
            return FactorType.GetValue();
        }

        public string GetRealTagIdValue()
        {
            return RealTagId.GetValue();
        }

        public string GetReactiveTagIdValue()
        {
            return ReactiveTagId.GetValue();
        }

        public string GetHourTagIdValue()
        {
            return HourTagId.GetValue();
        }

        public string GetElectricPaddingCostValue()
        {
            return ElectricPaddingCost.GetValue();
        }

        public string GetElectricTransformerCapacityValue()
        {
            return ElectricTransformerCapacity.GetValue();
        }

        public string GetElectricTransformerPriceValue()
        {
            return ElectricTransformerPrice.GetValue();
        }

        public string GetElectricHourPriceValue()
        {
            return ElectricHourPrice.GetValue();
        }
        #endregion
    }
}
