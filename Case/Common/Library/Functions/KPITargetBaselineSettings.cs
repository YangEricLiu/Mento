using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library.Functions;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class KPITargetBaselineSettings
    {
        internal KPITargetBaselineSettings()
        {
        }

        private static Grid KPITagList = JazzGrid.KPITagSettingsKPITagList;

        private static TabButton BasicPropertyTab = JazzButton.KPITagSettingsBasicPropertyTabButton;
        private static TabButton TargetPropertyTab = JazzButton.KPITargetPropertyTabButton;
        private static TabButton BaselinePropertyTab = JazzButton.KPIBaselinePropertyTabButton;

        private static Button CalculationRuleViewButton = JazzButton.KPITargetBaselineCalculationRuleViewButton;
        private static Button CalculationRuleCreateButton = JazzButton.KPITargetBaselineCalculationRuleCreateButton;
        private static Button CalculationRuleBackButton = JazzButton.KPITargetBaselineCalculationRuleBackButton;        
        private static Button CalculateTarget = JazzButton.KPITargetBaselineCalculateTargetButton;
        private static Button CalculateBaseline = JazzButton.KPITargetBaselineCalculateBaselineButton;
        private static Button ReviseButton = JazzButton.KPITargetBaselineReviseButton;
        private static Button SaveButton = JazzButton.KPITagSettingsSaveButton;
        private static Button CancelButton = JazzButton.KPITagSettingsCancelButton;
        private static Button AddSpecialDatesButton = JazzButton.KPITargetBaselineAddSpecialDatesButton;
        private static Button DeleteSpecialDatesButton = JazzButton.KPITargetBaselineDeleteSpecialDatesButton;
                
        private static TextField WorkdayRuleValueTextField = JazzTextField.KPITargetBaselineWorkdayRuleValueTextField;
        private static TextField NonworkdayRuleValueTextField = JazzTextField.KPITargetBaselineNonworkdayRuleValueTextField;
        private static TextField SpecialdayRuleValueTextField = JazzTextField.KPITargetBaselineSpecialdayRuleValueTextField;
        private static TextField AnnualCalculationValueTextField = JazzTextField.KPITargetBaselineAnnualCalculationValueTextField;
        private static TextField JanuaryCalculationValueTextField = JazzTextField.KPITargetBaselineJanuaryCalculationValueTextField;
        private static TextField FebruaryCalculationValueTextField = JazzTextField.KPITargetBaselineFebruaryCalculationValueTextField;
        private static TextField MarchCalculationValueTextField = JazzTextField.KPITargetBaselineMarchCalculationValueTextField;
        private static TextField AprilCalculationValueTextField = JazzTextField.KPITargetBaselineAprilCalculationValueTextField;
        private static TextField MayCalculationValueTextField = JazzTextField.KPITargetBaselineMayCalculationValueTextField;
        private static TextField JuneCalculationValueTextField = JazzTextField.KPITargetBaselineJuneCalculationValueTextField;
        private static TextField JulyCalculationValueTextField = JazzTextField.KPITargetBaselineJulyCalculationValueTextField;
        private static TextField AugustCalculationValueTextField = JazzTextField.KPITargetBaselineAugustCalculationValueTextField;
        private static TextField SeptemberCalculationValueTextField = JazzTextField.KPITargetBaselineSeptemberCalculationValueTextField;
        private static TextField OctoberCalculationValueTextField = JazzTextField.KPITargetBaselineOctoberCalculationValueTextField;
        private static TextField NovemberCalculationValueTextField = JazzTextField.KPITargetBaselineNovemberCalculationValueTextField;
        private static TextField DecemberCalculationValueTextField = JazzTextField.KPITargetBaselineDecemberCalculationValueTextField;
        
        private static ComboBox EffectiveYear = JazzComboBox.KPITargetBaselineEffectiveYearComboBox;

        /// <summary>
        /// Navigate to KPITag settings
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToKPITagSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsKPI);
            TimeManager.ShortPause();
        }

        /// <summary>
        /// Select one tag
        /// </summary>
        /// <param name="kpitagName">kpitag name</param>
        /// <returns></returns>
        public void FocusOnKPITag(string kpitagName)
        {
            KPITagList.FocusOnRow(1, kpitagName);
        }

        /// <summary>
        /// Click Baseline Property tab button.
        /// </summary>
        /// <returns></returns>
        public void SwitchToBaselinePropertyTab()
        {
            BaselinePropertyTab.Click();
        }              
                       
        /// <summary>
        /// Click Target Property tab button.
        /// </summary>
        /// <returns></returns>
        public void SwitchToTargetPropertyTab()
        {
            TargetPropertyTab.Click();
        }

        /// <summary>
        /// Select one year
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectYear(string year)
        {
            EffectiveYear.SelectItem(year);
        }

        /// <summary>
        /// Click calculation rule view button
        /// </summary>
        /// <returns></returns>
        public void ViewCalculationRule()
        {
            JazzButton.KPITargetBaselineCalculationRuleViewButton.Click();
        }

        /// <summary>
        /// Click calculation rule add button
        /// </summary>
        /// <returns></returns>
        public void CreateCalculationRule()
        {
            JazzButton.KPITargetBaselineCalculationRuleCreateButton.Click();
        }

        /// <summary>
        /// Click calculation rule back button
        /// </summary>
        /// <returns></returns>
        public void BackFromCalculationRule()
        {
            JazzButton.KPITargetBaselineCalculationRuleBackButton.Click();
        }

        /// <summary>
        /// Click calculation rule modify button
        /// </summary>
        /// <returns></returns>
        public void ModifyCalculationRule()
        {
            JazzButton.KPITargetBaselineCalculationRuleModifyButton.Click();
        }

        

    }

}

