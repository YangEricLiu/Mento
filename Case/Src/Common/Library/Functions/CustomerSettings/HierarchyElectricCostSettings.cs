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

        private static string TRANSFORMERCAPACITYMODE = "变压器容量模式";
        private static string TIMECAPACITYMODE = "时间容量模式";
        private static string FACTORTITLE = "功率因数";

        #region Controls
        private static TabButton CostProperty = JazzButton.CostPropertyTabButton;
        private static Button CostCreate = JazzButton.CostCreateButton;
        private static Button CostUpdate = JazzButton.CostUpdateButton;
        private static Button ElectricCostCreate = JazzButton.ElectricCostCreateButton;
        private static ComboBox ElectricPriceMode = JazzComboBox.ElectricPriceModeComboBox;
        private static MonthPicker ElectricCostEffectiveDate = JazzMonthPicker.ElectricCostEffectiveDateMonthPicker;
        private static TextField ElectricPrice = JazzTextField.ElectricPriceTextField;
        private static Button CostSave = JazzButton.CostSaveButton;
        private static Button CostCancel = JazzButton.CostCancelButton;
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
        private static Window FactorWindow = JazzWindow.FactorWindow;
        private static Container ElectricCostValueItems = JazzContainer.ElectricCostValueItemsContainer;
        #endregion

        #region electric cost property
        public void ClickCostPropertyTabButton_Create()
        {
            CostProperty.Click();
            CostCreate.WaitControlDisplayed(); 
        }

        public void ClickCostPropertyTabButton_Update()
        {
            CostProperty.Click();
            CostUpdate.WaitControlDisplayed();     
        }

        public bool IsCostPropertyTabButtonEnabled()
        {
            return CostProperty.IsEnabled();
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

        public Boolean IsCostCreateButtonDisplayed()
        {
            return CostCreate.IsDisplayed();
        }

        public Boolean IsCostUpdateButtonDisplayed()
        {
            return CostUpdate.IsDisplayed();
        }

        public void ClickElectricCostCreateButton()
        {
            ElectricCostCreate.Click();
        }

        public bool IsCostSaveButtonDisplayed()
        {
            return CostSave.IsDisplayed();
        }

        public void ClickCostSaveButton()
        {
            CostSave.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void ClickCostCancelButton()
        {
            CostCancel.Click();
        }

        public bool IsCostCancelButtonDisplayed()
        {
            return CostCancel.IsDisplayed();
        }

        public void ClickCostDeleteButton(int position)
        {
            Button OneDeleteButton = GetOneDeleteButton(position);

            OneDeleteButton.Click();
        }

        public int GetElectricCostItemsNumber()
        {
            return (ElectricCostValueItems.GetElementNumber() - 1);
        }
        #endregion

        #region actions

        #region fixed electricity

        /// <summary>
        /// Input fixed electric cost value
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInFixedCost(ElectricfixedCostInputData input)
        {
            ElectricCostEffectiveDate.SelectYearMonthItem(input.EffectiveDate);
            ElectricPriceMode.SelectItem(input.PriceMode);
            ElectricPrice.Append(input.Price);
        }

        public void FillInFixedCost(ElectricfixedCostInputData input, int position)
        {
            SelectElectricEffectiveDate(input.EffectiveDate, position);
            SelectElectricPriceMode(input.PriceMode, position);
            FillElectricPrice(input.Price, position);
        }

        public void SelectElectricEffectiveDate(string date)
        {
            ElectricCostEffectiveDate.SelectYearMonthItem(date);
        }

        public void SelectElectricEffectiveDate(string date, int position)
        {
            MonthPicker OneEffectiveDate = GetOneEffectiveDate(position);

            OneEffectiveDate.SelectYearMonthItem(date);
        }

        public bool IsEffectiveDateInvalid(int position)
        {
            MonthPicker OneEffectiveDate = GetOneEffectiveDate(position);

            return OneEffectiveDate.IsMonthPickerValueInvalid();
        }

        public bool IsEffectiveDateInvalidMsgCorrect(string msg, int position)
        {
            MonthPicker OneEffectiveDate = GetOneEffectiveDate(position);

            return OneEffectiveDate.GetInvalidTips().Contains(msg);
        }

        public void SelectElectricPriceMode(string priceMode)
        {
            ElectricPriceMode.SelectItem(priceMode);
        }

        public void SelectElectricPriceMode(string priceMode, int position)
        {
            ComboBox OnePriceMode = GetOnePriceMode(position);

            OnePriceMode.SelectItem(priceMode);
        }

        public bool IsPriceModeInvalid(int postion)
        {
            ComboBox OnePriceMode = GetOnePriceMode(postion);

            return OnePriceMode.IsComboBoxValueInvalid();
        }

        public bool IsPriceModeInvalidMsgCorrect(string msg, int position)
        {
            ComboBox OnePriceMode = GetOnePriceMode(position);

            return OnePriceMode.GetInvalidTips().Contains(msg);
        }

        public void FillElectricPrice(string price)
        {
            ElectricPrice.Fill(price);
        }

        public void FillElectricPrice(string price, int position)
        {
            TextField OneElectricPrice = GetOneElectricPrice(position);

            OneElectricPrice.Fill(price);
        }

        public bool IsElectricPriceInvalid(int position)
        {
            TextField OneElectricPrice = GetOneElectricPrice(position);

            return OneElectricPrice.IsTextFieldValueInvalid();
        }

        public bool IsElectricPriceInvalidMsgCorrect(string msg, int position)
        {
            TextField OneElectricPrice = GetOneElectricPrice(position);

            return OneElectricPrice.GetInvalidTipsForNumberField().Contains(msg);
        }

        #endregion

        #region comprehensive electricity

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

        public void SelectDemandCostType(string type)
        {
            DemandCostType.SelectItem(type);
        }

        public void SelectDemandCostType(string type, int position)
        {
            ComboBox OneDemandCostType = GetOneDemandCostType(position);

            OneDemandCostType.SelectItem(type);
        }

        public bool IsDemandCostTypeInvalid(int position)
        {
            ComboBox OneDemandCostType = GetOneDemandCostType(position);

            return OneDemandCostType.IsComboBoxValueInvalid();
        }

        public bool IsDemandCostTypeInvalidMsgCorrect(string msg, int position)
        {
            ComboBox OneDemandCostType = GetOneDemandCostType(position);

            return OneDemandCostType.GetInvalidTips().Contains(msg);
        }

        public void SelectTouTariffId(string tariffId)
        {
            TouTariffId.SelectItem(tariffId);
        }

        public void SelectTouTariffId(string tariffId, int position)
        {
            ComboBox OneTouTariffId = GetOneTouTariffId(position);

            OneTouTariffId.SelectItem(tariffId);
        }

        public void SelectFactorType(string factorType)
        {
            FactorType.SelectItem(factorType);
        }

        public void SelectFactorType(string factorType, int position)
        {
            ComboBox OneFactorType = GetOneFactorType(position);

            OneFactorType.SelectItem(factorType);
        }

        public void SelectRealTagId(string realTagId)
        {
            RealTagId.SelectItem(realTagId);
        }

        public void SelectRealTagId(string realTagId, int position)
        {
            ComboBox OneRealTagId = GetOneRealTagId(position);

            OneRealTagId.SelectItem(realTagId);
        }

        public void SelectReactiveTagId(string reactiveTagId)
        {
            ReactiveTagId.SelectItem(reactiveTagId);
        }

        public void SelectReactiveTagId(string reactiveTagId, int position)
        {
            ComboBox OneReactiveTagId = GetOneReactiveTagId(position);

            OneReactiveTagId.SelectItem(reactiveTagId);
        }

        public void SelectHourTagId(string hourTagId)
        {
            HourTagId.SelectItem(hourTagId);
        }

        public void SelectHourTagId(string hourTagId, int position)
        {
            ComboBox OneHourTagId = GetOneHourTagId(position);

            OneHourTagId.SelectItem(hourTagId);
        }

        public void FillElectricPaddingCost(string cost)
        {
            ElectricPaddingCost.Fill(cost);
        }

        public void FillElectricPaddingCost(string cost, int position)
        {
            TextField OneElectricPaddingCost = GetOneElectricPaddingCost(position);

            OneElectricPaddingCost.Fill(cost);
        }

        public bool IsElectricPaddingCostInvalid(int position)
        {
            TextField OneElectricPaddingCost = GetOneElectricPaddingCost(position);

            return OneElectricPaddingCost.IsTextFieldValueInvalid();
        }

        public bool IsElectricPaddingCostInvalidMsgCorrect(string msg, int position)
        {
            TextField OneElectricPaddingCost = GetOneElectricPaddingCost(position);

            return OneElectricPaddingCost.GetInvalidTipsForNumberField().Contains(msg);
        }

        public bool IsPaddingCostDisplayed(int position)
        {
            TextField OneElectricPaddingCost = GetOneElectricPaddingCost(position);

            return OneElectricPaddingCost.IsFieldDisplayed();
        }

        public void FillElectricTransformerCapacity(string capacity)
        {
            ElectricTransformerCapacity.Fill(capacity);
        }

        public void FillElectricTransformerCapacity(string capacity, int position)
        {
            TextField OneElectricTransformerCapacity = GetOneElectricTransformerCapacity(position);

            OneElectricTransformerCapacity.Fill(capacity);
        }

        public bool IsElectricTransformerCapacityInvalid(int position)
        {
            TextField OneElectricTransformerCapacity = GetOneElectricTransformerCapacity(position);

            return OneElectricTransformerCapacity.IsTextFieldValueInvalid();
        }

        public bool IsElectricTransformerCapacityInvalidMsgCorrect(string msg, int position)
        {
            TextField OneElectricTransformerCapacity = GetOneElectricTransformerCapacity(position);

            return OneElectricTransformerCapacity.GetInvalidTipsForNumberField().Contains(msg);
        }

        public void FillElectricTransformerPrice(string price)
        {
            ElectricTransformerPrice.Fill(price);
        }

        public void FillElectricTransformerPrice(string price, int position)
        {
            TextField OneElectricTransformerPrice = GetOneElectricTransformerPrice(position);

            OneElectricTransformerPrice.Fill(price);
        }

        public bool IsElectricTransformerPriceInvalid(int position)
        {
            TextField OneElectricTransformerPrice = GetOneElectricTransformerPrice(position);

            return OneElectricTransformerPrice.IsTextFieldValueInvalid();
        }

        public bool IsElectricTransformerPriceInvalidMsgCorrect(string msg, int position)
        {
            TextField OneElectricTransformerPrice = GetOneElectricTransformerPrice(position);

            return OneElectricTransformerPrice.GetInvalidTipsForNumberField().Contains(msg);
        }

        public void FillElectricHourPrice(string price)
        {
            ElectricHourPrice.Fill(price);
        }

        public void FillElectricHourPrice(string price, int position)
        {
            TextField OneElectricHourPrice = GetOneElectricHourPrice(position);

            OneElectricHourPrice.Fill(price);
        }

        public bool IsElectricHourPriceInvalid(int position)
        {
            TextField OneElectricHourPrice = GetOneElectricHourPrice(position);

            return OneElectricHourPrice.IsTextFieldValueInvalid();
        }

        public bool IsElectricHourPriceInvalidMsgCorrect(string msg, int position)
        {
            TextField OneElectricHourPrice = GetOneElectricHourPrice(position);

            return OneElectricHourPrice.GetInvalidTipsForNumberField().Contains(msg);
        }

        public bool IsFactorDisable(int position)
        {
            LinkButton OneFactor = GetOneFactor(position);

            return OneFactor.IsLinkButtonDisabled();
        }

        public void ClickFactorLinkButton(int position)
        {
            LinkButton OneFactor = GetOneFactor(position);

            OneFactor.ClickLink();
        }

        public bool IsFacorWindowDisplayed()
        {
            return FactorWindow.GetTitle().Contains(FACTORTITLE);
        }

        public void CloseFactorWindow()
        {
            FactorWindow.Close();
        }

        #endregion

        #endregion

        #region get controls value

        #region get fixed electricity value

        public string GetElectricCostEffectiveDateValue()
        {
            return ElectricCostEffectiveDate.GetValue();
        }

        public string GetElectricCostEffectiveDateValue(int position)
        {
            MonthPicker OneEffectiveDate = GetOneEffectiveDate(position);

            return OneEffectiveDate.GetValue();
        }

        public string GetElectricPriceValue()
        {
            return ElectricPrice.GetValue();
        }

        public string GetElectricPriceValue(int position)
        {
            TextField OneElectricPrice = GetOneElectricPrice(position);

            return OneElectricPrice.GetValue();
        }

        public string GetElectricPriceMode()
        {
            return ElectricPriceMode.GetValue();
        }

        public string GetElectricPriceMode(int position)
        {
            ComboBox OnePriceMode = GetOnePriceMode(position);

            return OnePriceMode.GetValue();
        }

        #endregion

        #region get comprehensice controls value
        
        public string GetDemandCostTypeValue()
        {
            return DemandCostType.GetValue();
        }

        public string GetDemandCostTypeValue(int position)
        {
            ComboBox OneDemandCostType = GetOneDemandCostType(position);

            return OneDemandCostType.GetValue();
        }

        public string GetTouTariffIdValue()
        {
            return TouTariffId.GetValue();
        }

        public string GetTouTariffIdValue(int position)
        {
            ComboBox OneTouTariffId = GetOneTouTariffId(position);

            return OneTouTariffId.GetValue();
        }

        public string GetFactorTypeValue()
        {
            return FactorType.GetValue();
        }

        public string GetFactorTypeValue(int position)
        {
            ComboBox OneFactorType = GetOneFactorType(position);

            return OneFactorType.GetValue();
        }

        public string GetRealTagIdValue()
        {
            return RealTagId.GetValue();
        }

        public string GetRealTagIdValue(int position)
        {
            ComboBox OneRealTagId = GetOneRealTagId(position);

            return OneRealTagId.GetValue();
        }

        public string GetReactiveTagIdValue()
        {
            return ReactiveTagId.GetValue();
        }

        public string GetReactiveTagIdValue(int position)
        {
            ComboBox OneReactiveTagId = GetOneReactiveTagId(position);

            return OneReactiveTagId.GetValue();
        }

        public string GetHourTagIdValue()
        {
            return HourTagId.GetValue();
        }

        public string GetHourTagIdValue(int position)
        {
            ComboBox OneHourTagId = GetOneHourTagId(position);

            return OneHourTagId.GetValue();
        }

        public string GetElectricPaddingCostValue()
        {
            return ElectricPaddingCost.GetValue();
        }

        public string GetElectricPaddingCostValue(int position)
        {
            TextField OneElectricPaddingCost = GetOneElectricPaddingCost(position);

            return OneElectricPaddingCost.GetValue();
        }

        public string GetElectricTransformerCapacityValue()
        {
            return ElectricTransformerCapacity.GetValue();
        }

        public string GetElectricTransformerCapacityValue(int position)
        {
            TextField OneElectricTransformerCapacity = GetOneElectricTransformerCapacity(position);

            return OneElectricTransformerCapacity.GetValue();
        }

        public string GetElectricTransformerPriceValue()
        {
            return ElectricTransformerPrice.GetValue();
        }

        public string GetElectricTransformerPriceValue(int position)
        {
            TextField OneElectricTransformerPrice = GetOneElectricTransformerPrice(position);

            return OneElectricTransformerPrice.GetValue();
        }

        public string GetElectricHourPriceValue()
        {
            return ElectricHourPrice.GetValue();
        }

        public string GetElectricHourPriceValue(int position)
        {
            TextField OneElectricHourPrice = GetOneElectricHourPrice(position);

            return OneElectricHourPrice.GetValue();
        }

        #endregion

        #endregion

        #region private method

        private MonthPicker GetOneEffectiveDate(int positionIndex)
        {
            return JazzMonthPicker.GetOneMonthPicker(JazzControlLocatorKey.MonthPickerElectricCostEffectiveDate, positionIndex + 1);
        }

        private ComboBox GetOnePriceMode(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxElectricPriceMode, positionIndex + 1);
        }

        private TextField GetOneElectricPrice(int positionIndex)
        {
            return JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldElectricPrice, positionIndex + 1);
        }

        private ComboBox GetOneDemandCostType(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxDemandCostType, positionIndex + 1);
        }

        private TextField GetOneElectricPaddingCost(int positionIndex)
        {
            return JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldElectricPaddingCost, positionIndex + 1);
        }

        private TextField GetOneElectricTransformerCapacity(int positionIndex)
        {
            return JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldElectricTransformerCapacity, positionIndex + 1);
        }

        private TextField GetOneElectricTransformerPrice(int positionIndex)
        {
            return JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldElectricTransformerPrice, positionIndex + 1);
        }

        private TextField GetOneElectricHourPrice(int positionIndex)
        {
            return JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldElectricHourPrice, positionIndex + 1);
        }

        private ComboBox GetOneTouTariffId(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxTouTariffId, positionIndex + 1);
        }

        private ComboBox GetOneFactorType(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxFactorType, positionIndex + 1);
        }

        private ComboBox GetOneRealTagId(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxRealTagId, positionIndex + 1);
        }

        private ComboBox GetOneReactiveTagId(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxReactiveTagId, positionIndex + 1);
        }

        private ComboBox GetOneHourTagId(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxHourTagId, positionIndex + 1);
        }

        private LinkButton GetOneFactor(int positionIndex)
        {
            return JazzButton.GetOneLinkButton(JazzControlLocatorKey.LinkButtonFactor, positionIndex + 1);
        }

        private Button GetOneDeleteButton(int positionIndex)
        {
            return JazzButton.GetOneLinkButton(JazzControlLocatorKey.ButtonElectricCostDelete, positionIndex + 1);
        }
        #endregion
    }
}
