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

        private static Grid CarbonFactorList = JazzGrid.CarbonFactorList;
        private static Button CreateCarbonFactorButton = JazzButton.CarbonFactorCreateButton;

        private static Button ModifyButton = JazzButton.CarbonFactorModifyButton;
        private static Button SaveButton = JazzButton.CarbonFactorSaveButton;
        private static Button CancelButton = JazzButton.CarbonFactorCancelButton;
        private static Button DeleteButton = JazzButton.CarbonFactorDeleteButton;

        private static TextField FactorValueTextField = JazzTextField.CarbonFactorValueTextField;
        private static Button AddMoreRangesButton = JazzButton.CarbonFactorAddMoreRangesButton;
        private static ComboBox SourceComboBox = JazzComboBox.CarbonFactorSourceComboBox;
        private static ComboBox DestinationComboBox = JazzComboBox.CarbonFactorDestinationComboBox;
        private static ComboBox EffectiveYearComboBox = JazzComboBox.CarbonFactorEffectiveYearComboBox;
        private static Button ButtonCarbonFactorRangeDelete = JazzButton.CarbonFactorRangeDeleteButton;

        #region Action
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
            //OneFactorValue.GetInvalidTipsForNumberField().Contains
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
        /// Click cancel button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCancelButton()
        {
            CancelButton.Click();
        }

        /// <summary>
        /// Click delete button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickDeleteButton()
        {
            DeleteButton.Click();
        }

        /// <summary>
        /// Click modify button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickModifyButton()
        {
            ModifyButton.Click();
        }

        #endregion

        #region Get control

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

        /// <summary>
        /// focus a certain carbon
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void FocusOnCarbonFactor(string carbonFactor)
        {

                CarbonFactorList.FocusOnRow(1, carbonFactor);
        }

        /// <summary>
        /// verify whether the carbonfactor exist the carbonfactor list
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsUserOnList(string carbonFactor)
        {
            return CarbonFactorList.IsRowExistOnCurrentPage(1, carbonFactor);
        }

        public void ButtonFactorRangeDelete(int position)
        {
            Button ButtonFactorRangeDelete = GetOneCarbonFactorRangeDelete(position);

            ButtonFactorRangeDelete.Click();
        }

        public void FillCarbonFactor_N(CarbonFactorInputData input, int position)
        {
            FillInFactorEffectiveYear_N(input.EffectiveYear, position);
            FillInFactorValue_N(input.FactorValue, position);
        }

        public void FillInFactorValue_N(string value, int position)
        {
            TextField OneFactorValue = GetOneCarbonFactorValue(position);

            OneFactorValue.Fill(value);
        }

        public void FillInFactorEffectiveYear_N(string year, int position)
        {
            ComboBox OneEffectiveYear = GetOneCarbonFactorEffectiveYear(position);

            OneEffectiveYear.SelectItem(year);
        }
        #endregion

        #region Comprehesive control
        public Boolean IsFactorSourceInvalid()
        {
            return SourceComboBox.IsComboBoxValueInvalid();
        }

        public Boolean IsFactorSourceInvalidMsgCorrect(string msg)
        {
            return SourceComboBox.GetInvalidTips().Contains(msg);
        }

        public Boolean IsFactorEffectiveYearInvalid_N(int position)
        {
            ComboBox OneCarbonFactorEffectiveYear = GetOneCarbonFactorEffectiveYear(position);

            return OneCarbonFactorEffectiveYear.IsComboBoxValueInvalid();
        }

        public Boolean IsFactorEffectiveYearInvalidMsgCorrect_N(string msg, int position)
        {
            ComboBox OneFactorEffectiveYear = GetOneCarbonFactorEffectiveYear(position);

            return OneFactorEffectiveYear.GetInvalidTips().Contains(msg);
        }

        public Boolean IsFactorValueInvalid_N(int position)
        {
            TextField OneFactorValue = GetOneCarbonFactorValue(position);

            return OneFactorValue.IsTextFieldValueInvalid();
        }

        public Boolean IsFactorValueInvalidMsgCorrect_N(string msg, int position)
        {
            TextField OneFactorValue = GetOneCarbonFactorValue(position);

            return OneFactorValue.GetInvalidTipsForNumberField().Contains(msg);
        }

        public string GetCarbonFactorEffectiveYear(int position)
        {
            ComboBox CarbonFactorEffectiveYear = GetOneCarbonFactorEffectiveYear(position);

            return CarbonFactorEffectiveYear.GetValue();
        }

        public string GetCarbonFactorValue(int position)
        {
            TextField CarbonFactorValue = GetOneCarbonFactorValue(position);

            return CarbonFactorValue.GetValue();
        }

        private ComboBox GetOneCarbonFactorEffectiveYear(int positionIndex)
        {
            return JazzComboBox.GetOneComboBox(JazzControlLocatorKey.ComboBoxCarbonFactorEffectiveYear, positionIndex);
        }

        private TextField GetOneCarbonFactorValue(int positionIndex)
        {
            return JazzTextField.GetOneTextField(JazzControlLocatorKey.TextFieldCarbonFactorValue, positionIndex);
        }

        private Button GetOneCarbonFactorRangeDelete(int positionIndex)
        {
            return JazzButton.GetOneButton(JazzControlLocatorKey.ButtonCarbonFactorRangeDelete, positionIndex);
        }
        #endregion

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
