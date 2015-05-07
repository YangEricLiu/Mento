using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public class JazzTextField : JazzControlCollection
    {
        #region Get Position TextField Method

        public static TextField GetOneTextField(string key, int positionIndex)
        {
            return GetControl<TextField>(key, positionIndex); 
        }

        #endregion

        #region Login

        public static TextField LoginUserNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldLoginUserName); }}
        public static TextField LoginPasswordTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldLoginPassword); }}

        public static TextField PopLoginUserNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.PopTextFieldLoginUserName); } }
        public static TextField PopLoginPasswordTextField { get { return GetControl<TextField>(JazzControlLocatorKey.PopTextFieldLoginPassword); } }
        #endregion

        #region DemoAccess
        public static TextField DemoAccessEmailAddressTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldDemoAccessEmailAddress); }}
        #endregion

        #region ContactUs
        public static TextField TextFieldContactUsName { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldContactUsName); }}
        public static TextField TextFieldContactUsTelephone { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldContactUsTelephone); }}
        public static TextField TextFieldContactUsCompany { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldContactUsCompany); }}
        public static TextField TextFieldContactUsTitle { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldContactUsTitle); }}
        public static TextField TextFieldContactUsDescriptionFields { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldContactUsDescriptionFields); }}
        #endregion

        #region Energy view
        public static TextField EnergyViewSaveDashboardWidgetNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldEnergyViewSaveDashboardWidgetName); }}
        public static TextField EnergyViewSaveDashboardDashboardNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldEnergyViewSaveDashboardDashboardName); }}
        public static TextField TextFieldModifyWidgetName { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldModifyWidgetName); }}
        public static TextField ModifyDashboardNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldModifyDashboardName); }}
        public static TextField WidgetAnnotationTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldWidgetAnnotation); }}

        #endregion

        #region Customer settings
        #region Hierarchy settings
        public static TextField HierarchySettingsNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldHierarchySettingsName); }}
        public static TextField HierarchySettingscodeTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldHierarchySettingsCode); }}
        public static TextField HierarchySettingsCommentTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldHierarchySettingsComment); }}

        #region Hierarchy property settings
        public static TextField TotalAreaValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldTotalAreaValue); }}
        public static TextField HeatingAreaValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldHeatingAreaValue); }}
        public static TextField CoolingAreaValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldCoolingAreaValue); }}

        public static TextField PeopleNumberTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldPeopleNumber, 1); }}
        public static TextField ElectricPriceTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldElectricPrice, 1); }}
        public static TextField ElectricPaddingCostTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldElectricPaddingCost, 1); }}
        public static TextField ElectricTransformerCapacityTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldElectricTransformerCapacity, 1); }}
        public static TextField ElectricTransformerPriceTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldElectricTransformerPrice, 1); }}
        public static TextField ElectricHourPriceTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldElectricHourPrice, 1); }}

        public static TextField WaterPriceTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldWaterPrice, 2); }}
        public static TextField GasPriceTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldGasPrice,2); }}
        public static TextField HeatQPriceTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldHeatQPrice, 2); }}
        public static TextField CoolQPriceTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldCoolQPrice, 2); }}
        public static TextField LightWaterPriceTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldLightWaterPrice, 2); }}
        public static TextField CoalPriceTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldCoalPrice, 2); }}
        public static TextField PetrolPriceTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldPetrolPrice, 2); }}
        public static TextField KerosenePriceTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKerosenePrice, 2); }}
        public static TextField DieselOilPriceTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldDieselOilPrice, 2); }}
        public static TextField LowPressureSteamPriceTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldLowPressureSteamPrice, 2); }}
        #endregion

        #endregion

        #region PTag settings
        public static TextField PTagSettingsNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldPTagSettingsName); }}
        public static TextField PTagSettingsCodeTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldPTagSettingsCode); }}
        public static TextField PTagSettingsMetercodeTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldPTagSettingsMeterCode); }}
        public static TextField PTagSettingsChannelTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldPTagSettingsChannel); }}
        public static TextField PTagSettingsCommentTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldPTagSettingsComment); }}
        public static TextField PTagSettingsSlopeTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldPTagSettingsSlope); }}
        public static TextField PTagSettingsOffsetTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldPTagSettingsOffset); }} 
        #endregion

        #region VEE settings
        public static TextField VEESettingsNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldVEESettingsName); } }
        public static TextField VEESettingsSpikeGTTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldVEESettingsSpikeGT); } }
        public static TextField VEESettingsSpikeLTTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldVEESettingsSpikeLT); } }
        public static TextField VEESpecilaValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldVEESpecilaValue); } }
        //public static TextField VEEScanTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldVEEScan); } }
       
        #endregion

        #region PTag RawData
       
        public static TextField PtagRawDataValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldPtagRawDataValue); }}

        #endregion

        #region VEE RawData

        public static TextField VEERawDataValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldVEERawDataValue); } }

        public static TextField BackfillValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldBackfillValue); } }

        #endregion

        #region VTag settings
        public static TextField VTagSettingsNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldVTagSettingsName); }}
        public static TextField VTagSettingscodeTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldVTagSettingsCode); }}
        public static TextField VTagSettingsCommentTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldVTagSettingsComment); }}
        public static FormulaField VFormulaField { get { return GetControl<FormulaField>(null); }}
        #endregion

        #region KPITag settings
        public static TextField KPITagSettingsNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITagSettingsName); }}
        public static TextField KPITagSettingscodeTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITagSettingsCode); }}
        public static TextField KPITagSettingsCommentTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITagSettingsComment); }}
        public static FormulaField KPIFormulaField { get { return GetControl<FormulaField>(null); }}
        public static TextField KPITargetBaselineWorkdayRuleValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineWorkdayRuleValue); }}
        public static TextField KPITargetBaselineNonworkdayRuleValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineNonworkdayRuleValue); }}
        public static TextField KPITargetBaselineSpecialdayRuleValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineSpecialdayRuleValue); }}
        public static TextField KPITargetBaselineAnnualCalculationValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineAnnualCalculationValue); }}
        public static TextField KPITargetBaselineJanuaryCalculationValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineJanuaryCalculationValue); }}
        public static TextField KPITargetBaselineFebruaryCalculationValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineFebruaryCalculationValue); }}
        public static TextField KPITargetBaselineMarchCalculationValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineMarchCalculationValue); }}
        public static TextField KPITargetBaselineAprilCalculationValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineAprilCalculationValue); }}
        public static TextField KPITargetBaselineMayCalculationValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineMayCalculationValue); }}
        public static TextField KPITargetBaselineJuneCalculationValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineJuneCalculationValue); }}
        public static TextField KPITargetBaselineJulyCalculationValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineJulyCalculationValue); }}
        public static TextField KPITargetBaselineAugustCalculationValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineAugustCalculationValue); }}
        public static TextField KPITargetBaselineSeptemberCalculationValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineSeptemberCalculationValue); }}
        public static TextField KPITargetBaselineOctoberCalculationValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineOctoberCalculationValue); }}
        public static TextField KPITargetBaselineNovemberCalculationValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineNovemberCalculationValue); }}
        public static TextField KPITargetBaselineDecemberCalculationValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineDecemberCalculationValue); }}

        public static TextField TargetNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldTargetName); }}
        public static TextField BaselineNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldBaselineName); }}

        #endregion

        #region Area dimension settings
        public static TextField AreaDimensionSettingsNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldAreaDimensionSettingsName); }}
        public static TextField AreaDimensionSettingsCommentTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldAreaDimensionSettingsComment); }}
        #endregion

        #region CustomizedLabellingSetting
        public static TextField TextFieldCustomizedLabellingName { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldCustomizedLabellingName); }}
        public static TextField TextFieldCustomizedLabellingComment { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldCustomizedLabellingComment); }}
        #endregion
        #endregion

        #region Platform settings
        #region Workday
        public static TextField WorkdayCalendarNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldWorkdayCalendarName); }}
        #endregion

        #region Worktime
        public static TextField WorktimeCalendarNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldWorktimeCalendarName); }}
        #endregion

        #region HeatingCoolingSeason
        public static TextField HeatingCoolingSeasonCalendarNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldHeatingCoolingSeasonCalendarName); }}
        #endregion

        #region Daynight
        public static TextField DayNightCalendarNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldDayNightCalendarName); }}
        #endregion

        #region Carbonfactor
        public static TextField CarbonFactorValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldCarbonFactorValue, 1); }}
        #endregion

        #region TOU
        public static TextField TOUBasicPropertyNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldTOUBasicPropertyName, 1); }}
        public static TextField TOUBasicPropertyPlainPriceValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldTOUBasicPropertyPlainPriceValue, 1); }}
        public static TextField TOUBasicPropertyPeakPriceValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldTOUBasicPropertyPeakPriceValue, 1); }}
        public static TextField TOUBasicPropertyValleyPriceValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldTOUBasicPropertyValleyPriceValue, 1); }}
        public static TextField TOUPulsePeakPropertyPriceValueTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldTOUPulsePeakPropertyPriceValue, 1); }}        
        #endregion

        #region Customer settings
        public static TextField CustomerNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldCustomerName); }}
        public static TextField CustomercodeTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldCustomerCode); }}
        public static TextField CustomerAddressTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldCustomerAddress); }}
        public static TextField CustomerResponsiblePersonTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldCustomerResponsiblePerson); } }
        public static TextField CustomerTelephoneTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldCustomerTelephone); }}
        public static TextField CustomerEmailTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldCustomerEmail); }}
        public static TextField CustomerCommentTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldCustomerComment); }}
        public static TextField UploadLogoTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldUploadLogo); }}
        #endregion

        #region User Setting
        public static TextField UserNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldUserName); }}
        public static TextField UserRealNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldUserRealName); }}
        public static TextField UserTelephoneTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldUserTelephone); }}
        public static TextField UserEmailTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldUserEmail); }}
        public static TextField UserTitleTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldUserTitle); }}
        public static TextField UserCommentTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldUserComment); }}
        #endregion

        #region UserFunctionRoleType
        public static TextField FunctionRoleTypeNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldFunctionRoleTypeName); }}
        #endregion

        #region User Profile
        public static TextField UserProfileNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldUserProfileName); }}
        public static TextField UserProfileRealNameTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldUserProfileRealName); }}
        public static TextField UserProfileTelephoneTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldUserProfileTelephone); }}
        public static TextField UserProfileEmailTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldUserProfileEmail); }}
        public static TextField UserProfileCommentTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldUserProfileComment); }}
        public static TextField UserOriginalPasswordTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldUserOriginalPassword); }}
        public static TextField UserNewPasswordTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldUserNewPassword); }}
        public static TextField UserConfirmPasswordTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldUserConfirmPassword); }}
        #endregion
        #endregion

        #region homepage

        public static TextField ShareReceiveWindowCommentTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldShareReceiveWindowComment); }}
        public static TextField ReceiveWindowCommentTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldReceiveWindowComment); }}
        public static TextField EditModifyCommentTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldEditModifyComment); }}
        public static TextField MaxWidgetRightCommentTextField { get { return GetControl<TextField>(JazzControlLocatorKey.TextFieldMaxWidgetRightComment); }}
        
        #endregion

    }
}
