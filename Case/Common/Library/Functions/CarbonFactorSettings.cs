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
    /// The business logic implement of carbon factor settings.
    /// </summary>
    public class CarbonFactorSettings
    {
        internal CarbonFactorSettings()
        {
        }

        //private static Grid PTagList = JazzGrid.PTagSettingsPTagList;

        private static Button CreateCarbonFactorButton = JazzButton.CarbonFactorCreateButton;

        private static Button ModifyButton = JazzButton.CarbonFactorModifyButton;
        private static Button SaveButton = JazzButton.CarbonFactorSaveButton;
        private static Button CancelButton = JazzButton.CarbonFactorCancelButton;
        private static Button DeleteButton = JazzButton.CarbonFactorDeleteButton;

        private static TextField FactorValueTextField = JazzTextField.CarbonFactorValueTextField;
        private static LinkButton AddMoreRangesButton = JazzButton.CarbonFactorAddMoreRangesButton;
        private static ComboBox SourceComboBox = JazzComboBox.CarbonFactorSourceComboBox;
        private static ComboBox DestinationComboBox = JazzComboBox.CarbonFactorDestinationComboBox;
        private static ComboBox EffectiveYearComboBox = JazzComboBox.CarbonFactorEffectiveYearComboBox;
        
        /// <summary>
        /// Navigate to Carbon Factor Settings Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToCarbonFactorSettings()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CarbonSettingsCarbon);
            //TimeManager.ShortPause();
        }

        /// <summary>
        /// Click "add carbon factor" button to add one carbon factor
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void PrepareToAddCarbonFactor()
        {
            CreateCarbonFactorButton.Click();
        }
        
        /// <summary>
        /// Click "add more ranges" icon
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickAddMoreRangesButton()
        {
            AddMoreRangesButton.Click();             
        }

        /// <summary>
        /// Select Factor Source from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectFactorSource(string source)
        {
            SourceComboBox.SelectItem(source);
        }

        /// <summary>
        /// Select EffectiveYear from the dropdown list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectEffectiveYear(string year, int num)
        {
            ComboBox OneEffectiveYear = GetOneEffectiveYearComboBox(num);
            OneEffectiveYear.SelectItem(year); 
        }

        /// <summary>
        /// Fill in factor value field
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInFactorValue(string value, int num)
        {
            TextField OneFactorValue = GetOneFactorValueTextField(num);
            OneFactorValue.Fill(value);
        }

        /// <summary>
        /// Click save button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            SaveButton.Click();
        }

        /// <summary>
        /// Get Factor Source value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetFactorSourceValue()
        {
            return SourceComboBox.GetValue();
        }

        /// <summary>
        /// Get Factor Destination value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetFactorDestinationValue()
        {
            return DestinationComboBox.GetValue();
        }
                    
        /// <summary>
        /// Get Effective Year value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string GetEffectiveYearValue(int num)
        {
            ComboBox OneEffectiveYear = GetOneEffectiveYearComboBox(num);
            return OneEffectiveYear.GetValue();
        }

        /// <summary>
        /// Get Factor Value
        /// </summary>
        /// <returns></returns>
        public string GetFactorValue(int num)
        {
            TextField OneFactorValue = GetOneFactorValueTextField(num);
            return OneFactorValue.GetValue();
        }

        #region private method

        private ComboBox GetOneEffectiveYearComboBox(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxCarbonFactorEffectiveYear, positionIndex);
        }
        private TextField GetOneFactorValueTextField(int positionIndex)
        {
            return JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldCarbonFactorValue, positionIndex);
        }
        #endregion
    }
}
