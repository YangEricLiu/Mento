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
    /// </summary>
    public class VEERuleSettings
    {
        internal VEERuleSettings()
        {
        }

        #region VEERule controls

        private static Grid VEERuleList = JazzGrid.VEERuleSettingsVEERuleList;
        private static DatePicker VEEScanStartDatePicker = JazzDatePicker.VEEScanStartDatePicker;
        private static Button CreateVEEButton = JazzButton.VEERuleSettingsCreateRuleButton;
        private static Button ModifyButton = JazzButton.VEERuleSettingsModifyButton;
        private static Button SaveButton = JazzButton.VEERuleSettingsSaveButton;
        private static Button CancelButton = JazzButton.VEERuleSettingsCancelButton;
        private static Button DeleteButton = JazzButton.VEERuleSettingsDeleteButton;

        private static TextField NameTextField = JazzTextField.VEESettingsNameTextField;
        private static TextField SpikeGTTextField = JazzTextField.VEESettingsSpikeGTTextField;
        private static TextField SpikeLTTextField = JazzTextField.VEESettingsSpikeLTTextField;
        private static TextField SpecilaValueTextField = JazzTextField.VEESpecilaValueTextField;
        //private static TextField ScanTextField = JazzTextField.ScanTextField;
        private static ComboBox ScanIntervalComboBox = JazzComboBox.VEEScanIntervalComboBox;
        private static ComboBox ScanDelayComboBox = JazzComboBox.VEEScanDelayComboBox;
        public static CheckBoxField CheckBoxVEERule = JazzCheckBox.VEERuleCheckBox;

        #endregion

        #region VEERule List Operation

        /// <summary>
        /// Navigate to VEE Configuration Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToTagSettingsVEE()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsVEE);
            TimeManager.ShortPause();
        }

        public void VEERuleSettingsCaseSetUp()
        {
            NavigatorToTagSettingsVEE();
            TimeManager.MediumPause();
        }

        public void VEERuleSettingsCaseTearDown()
        {
            JazzFunction.LoginPage.RefreshJazz("自动化测试");
            TimeManager.LongPause();
        }

        /// <summary>
        /// Navigate to EnergyView
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToEnergyView()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyView);
            TimeManager.ShortPause();
        }


        /// <summary>
        /// Click "add vee" button to add one vee
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickAddVEERuleButton()
        {
            CreateVEEButton.Click();
        }

        /// <summary>
        /// Focus VEE by name
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean FocusOnVEEByName(string veeName)
        {
            try
            {
                VEERuleList.FocusOnRow(1, veeName);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Focus vee by cofigurator
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean FocusOnVEEByConfigrator(string configurator)
        {
            try
            {
                VEERuleList.FocusOnRow(2, configurator);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Basic Property Operations

        /// <summary>
        /// Click save button for vee
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            JazzMessageBox.LoadingMask.WaitLoading();
            SaveButton.Click();
        }

        /// <summary>
        /// Judge "Save" display
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsSaveButtonDisplayed()
        {
            return SaveButton.IsDisplayed();
        }

        /// <summary>
        /// Click Delete button for vee
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickDeleteButton()
        {
            DeleteButton.Click();
        }

        /// <summary>
        /// Judge "Delete" display
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsDeleteButtonDisplayed()
        {
            return DeleteButton.IsDisplayed();
        }

        /// <summary>
        /// Click Cancel button for vee
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCancelButton()
        {
            CancelButton.Click();
        }

        /// <summary>
        /// Judge "Cancel" display
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsCancelButtonDisplayed()
        {
            return CancelButton.IsDisplayed();
        }

        /// <summary>
        /// Click "modify" button 
        /// </summary>
        /// <param>vee name</param>
        /// <returns></returns>
        public void ClickModifyButton()
        {
            ModifyButton.Click();
        }

        /// <summary>
        /// Judge "Save" display 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsModifyButtonDisplayed()
        {
            return ModifyButton.IsDisplayed();
        }

        #endregion

        #region VEE field operations

        /// <summary>
        /// Set Scan Start time
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SetScanStartDate(string startTime)
        {
           
           VEEScanStartDatePicker.SelectDateItem(startTime);

        }

        /// <summary>
        /// VEE name, Spike value, Special value
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInVEE(VEEInputData input)
        {
            NameTextField.Fill(input.CommonName);
            SpikeGTTextField.Fill(input.SpikeGT);
            SpikeLTTextField.Fill(input.SpikeLT);
            SpecilaValueTextField.Fill(input.Special);

        }

         /// <summary>
        /// Input interval and delay time
        /// </summary>
        /// <returns></returns>
        public void FillInIntervalAndDelay(string ScanInterval, string Delay)
        {
            ScanIntervalComboBox.SelectItem(ScanInterval);
            ScanDelayComboBox.SelectItem(Delay);
        }

        public void FillInName(string name)
        {
            NameTextField.Fill(name);
        }

        public void FillSpikeGT(string SpikeGT)
        {
            SpikeGTTextField.Fill(SpikeGT);
        }

        public void FillSpikeLT(string SpikeLT)
        {
            SpikeLTTextField.Fill(SpikeLT);
        }

        public void FillSpecial(string Special)
        {
            SpecilaValueTextField.Fill(Special);
        }

        /// <summary>
        /// Check vee rule checkbox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void CheckVEERule(string itemName)
        {
            CheckBoxVEERule.CommonCheck(itemName);
        }

        /// <summary>
        /// Check vee rules checkbox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void CheckVEERules(string[] itemName)
        {
            int i = 0;
            while (i < itemName.Length)
            {
                CheckBoxVEERule.CommonCheck(itemName[i]);
                i++;
            }
        }
        /// <summary>
        /// UnCheck vee rule checkbox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void UnCheckVEERule(string itemName)
        {
            CheckBoxVEERule.CommonUnCheck(itemName);
        }

        /// <summary>
        /// UnCheck Vee rules checkbox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void UnCheckVEERules(string[] itemName)
        {
            int i = 0;
            while (i < itemName.Length)
            {
                CheckBoxVEERule.CommonUnCheck(itemName[i]);
                i++;
            }
        }

        /// <summary>
        /// Check whether the the vee rule display. 
        /// </summary>
        /// <returns></returns>
        public Boolean IsVEERuleDisplay(string rulename)
        {
            return CheckBoxVEERule.IsCommonNotDisplayed(rulename);
        }

        /// <summary>
        /// Check whether the the vee rules display.
        /// </summary>
        /// <returns></returns>
        public Boolean AreVEERulesDisplay(string[] rulenames)
        {
            int i = 0;
            while (i < rulenames.Length)
            {
                if (CheckBoxVEERule.IsCommonNotDisplayed(rulenames[i]))
                    return false;
                i++;
            }
            return !(CheckBoxVEERule.IsCommonNotDisplayed(rulenames[i - 1]));
        }

        /// <summary>
        /// Check whether the the Vee rules Not display. 
        /// </summary>
        /// <returns></returns>
        public Boolean AreVEERulesNotDisplay(string[] rulenames)
        {
            int i = 0;
            while (i < rulenames.Length)
            {
                if (!(CheckBoxVEERule.IsCommonNotDisplayed(rulenames[i])))
                    return false;
                i++;
            }
            return CheckBoxVEERule.IsCommonNotDisplayed(rulenames[i - 1]);
        }

        /// <summary>
        /// Verify whether Rules checkbox unchecked.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean AreVEERulesUnChecked(string[] itemName)
        {
            int i = 0;
            while (i < itemName.Length)
            {
                if (CheckBoxVEERule.IsCommonChecked(itemName[i]))
                    return false;
                i++;
            }
            return true;
        }

        /// <summary>
        /// Verify whether VEE rule checkbox checked.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsVEERuleChecked(string itemName)
        {

            return CheckBoxVEERule.IsCommonChecked(itemName);
        }

        /// <summary>
        /// Verify whether VEE Rules checkbox checked.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean AreVEERulesChecked(string[] itemName)
        {
            int i = 0;
            while (i < itemName.Length)
            {
                if (CheckBoxVEERule.IsCommonUnChecked(itemName[i]))
                    return false;
                i++;
            }
            return true;
        }
        ///// <summary>
        ///// UnCheck the IsSpike checkbox
        ///// </summary>
        ///// <param name="name">name</param>
        ///// <returns></returns>
        //public void UncheckIsSpikeCheckbox(string name)
        //{
        //    JazzCheckBox.VEEIsSpikeCheckBox.CommonUnCheck(name);
        //}
        /// Check the IsNull checkbox
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        public void CheckIsNullCheckbox(string name)
        {
            JazzCheckBox.VEEIsNullCheckBox.CommonCheck(name);
        }

        /// <summary>
        /// UnCheck the IsNull checkbox
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        public void UncheckIsNullCheckbox(string name)
        {
            JazzCheckBox.VEEIsNullCheckBox.CommonUnCheck(name);
        }

        /// Check the IsNegative checkbox
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        public void CheckIsNegativeCheckbox(string name)
        {
            JazzCheckBox.VEEIsNegativeCheckBox.CommonCheck(name);
        }

        /// <summary>
        /// UnCheck the IsNegative checkbox
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        public void UncheckIsNegativeCheckbox(string name)
        {
            JazzCheckBox.VEEIsNegativeCheckBox.CommonUnCheck(name);
        }

        /// Check the IsSpecial checkbox
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        public void CheckIsSpecialCheckbox(string name)
        {
            JazzCheckBox.VEEIsSpecialCheckBox.CommonCheck(name);
        }

        /// <summary>
        /// UnCheck the IsNegative checkbox
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        public void UncheckIsSpecialCheckbox(string name)
        {
            JazzCheckBox.VEEIsSpecialCheckBox.CommonUnCheck(name);
        }
        ///// <summary>
        ///// Is IsSpike checkbox checked
        ///// </summary>
        ///// <param name="name">name</param>
        ///// <returns></returns>
        //public bool IsSpikeChecked(string name)
        //{
        //    return JazzCheckBox.VEEIsSpikeCheckBox.IsCommonChecked(name);
        //}

        /// <summary>
        /// Is IsNull checkbox checked
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        public bool IsNullChecked(string name)
        {
            return JazzCheckBox.VEEIsNullCheckBox.IsCommonChecked(name);
        }

        /// <summary>
        /// Is IsNegative checkbox checked
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        public bool IsNegativeChecked(string name)
        {
            return JazzCheckBox.VEEIsNegativeCheckBox.IsCommonChecked(name);
        }

        /// <summary>
        /// Is IsSpecial checkbox checked
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        public bool IsSpecialChecked(string name)
        {
            return JazzCheckBox.VEEIsSpecialCheckBox.IsCommonChecked(name);
        }

        #endregion

        #region Get Value

        /// <summary>
        /// Get the vee Name actual value
        /// </summary>
        /// <returns></returns>
        public string GetNameValue()
        {
            return NameTextField.GetValue();
        }

        /// <summary>
        /// Get the spikeGL actual value
        /// </summary>
        /// <returns></returns>
        public string GetSpikeGTValue()
        {
            return SpikeGTTextField.GetValue();
        }

        /// <summary>
        /// Get the spikeTL actual value
        /// </summary>
        /// <returns></returns>
        public string GetSpikeLTValue()
        {
            return SpikeLTTextField.GetValue();
        }
        /// <summary>
        /// Get the special actual value
        /// </summary>
        /// <returns></returns>
        public string GetSpecialValue()
        {
            return SpecilaValueTextField.GetValue();
        }
        /// <summary>
        /// Get the vee scan interval actual value
        /// </summary>
        /// <returns></returns>
        public string GetScanIntervalValue()
        {
            return ScanIntervalComboBox.GetValue();
        }

        /// <summary>
        /// Get the vee scan delay actual value
        /// </summary>
        /// <param name = "itemKey">Commodity key</param>
        /// <returns>Key value</returns>
        public string GetScanDelayValue()
        {
            return ScanDelayComboBox.GetValue();
        }
        #endregion 
    }
}
