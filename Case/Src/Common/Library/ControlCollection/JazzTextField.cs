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

        public static TextField LoginUserNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldLoginUserName);
        public static TextField LoginPasswordTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldLoginPassword);
        #endregion

        #region DemoAccess
        public static TextField DemoAccessEmailAddressTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldDemoAccessEmailAddress);
        #endregion

        #region ContactUs
        public static TextField TextFieldContactUsName = GetControl<TextField>(JazzControlLocatorKey.TextFieldContactUsName);
        public static TextField TextFieldContactUsTelephone = GetControl<TextField>(JazzControlLocatorKey.TextFieldContactUsTelephone);
        public static TextField TextFieldContactUsCompany = GetControl<TextField>(JazzControlLocatorKey.TextFieldContactUsCompany);
        public static TextField TextFieldContactUsTitle = GetControl<TextField>(JazzControlLocatorKey.TextFieldContactUsTitle);
        public static TextField TextFieldContactUsDescriptionFields = GetControl<TextField>(JazzControlLocatorKey.TextFieldContactUsDescriptionFields);
        #endregion

        #region Energy view
        public static TextField EnergyViewSaveDashboardWidgetNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldEnergyViewSaveDashboardWidgetName);
        public static TextField EnergyViewSaveDashboardDashboardNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldEnergyViewSaveDashboardDashboardName);
        public static TextField TextFieldModifyWidgetName = GetControl<TextField>(JazzControlLocatorKey.TextFieldModifyWidgetName);
        public static TextField ModifyDashboardNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldModifyDashboardName);
        public static TextField WidgetAnnotationTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldWidgetAnnotation);

        #endregion

        #region Customer settings
        #region Hierarchy settings
        public static TextField HierarchySettingsNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldHierarchySettingsName);
        public static TextField HierarchySettingscodeTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldHierarchySettingsCode);
        public static TextField HierarchySettingsCommentTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldHierarchySettingsComment);

        #region Hierarchy property settings
        public static TextField TotalAreaValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldTotalAreaValue);
        public static TextField HeatingAreaValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldHeatingAreaValue);
        public static TextField CoolingAreaValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldCoolingAreaValue);

        public static TextField PeopleNumberTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldPeopleNumber, 1);
        public static TextField ElectricPriceTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldElectricPrice, 1);
        public static TextField ElectricPaddingCostTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldElectricPaddingCost, 1);
        public static TextField ElectricTransformerCapacityTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldElectricTransformerCapacity, 1);
        public static TextField ElectricTransformerPriceTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldElectricTransformerPrice, 1);
        public static TextField ElectricHourPriceTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldElectricHourPrice, 1);

        public static TextField WaterPriceTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldWaterPrice, 2);
        public static TextField GasPriceTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldGasPrice,2);
        public static TextField HeatQPriceTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldHeatQPrice, 2);
        public static TextField CoolQPriceTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldCoolQPrice, 2);
        public static TextField LightWaterPriceTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldLightWaterPrice, 2);
        public static TextField CoalPriceTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldCoalPrice, 2);
        public static TextField PetrolPriceTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldPetrolPrice, 2);
        public static TextField KerosenePriceTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKerosenePrice, 2);
        public static TextField DieselOilPriceTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldDieselOilPrice, 2);
        public static TextField LowPressureSteamPriceTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldLowPressureSteamPrice, 2);
        #endregion

        #endregion

        #region PTag settings
        public static TextField PTagSettingsNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldPTagSettingsName);
        public static TextField PTagSettingsCodeTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldPTagSettingsCode);
        public static TextField PTagSettingsMetercodeTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldPTagSettingsMeterCode);
        public static TextField PTagSettingsChannelTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldPTagSettingsChannel);
        public static TextField PTagSettingsCommentTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldPTagSettingsComment);
        #endregion

        #region PTag RawData
        public static TextField PTagRawDataFirstRow = GetControl<TextField>(JazzControlLocatorKey.GridPTagRawDataFirstRow);
        public static TextField PTagRawDataSecondRow = GetControl<TextField>(JazzControlLocatorKey.GridPTagRawDataSecondRow);
        public static TextField PTagRawDataFirstRowState = GetControl<TextField>(JazzControlLocatorKey.GridPTagRawDataFirstRowState);
        public static TextField PTagRawDataSecondRowState = GetControl<TextField>(JazzControlLocatorKey.GridPTagRawDataSecondRowState);
        public static TextField PtagRawDataValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldPtagRawDataValue);

        #endregion

        #region VTag settings
        public static TextField VTagSettingsNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldVTagSettingsName);
        public static TextField VTagSettingscodeTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldVTagSettingsCode);
        public static TextField VTagSettingsCommentTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldVTagSettingsComment);
        public static FormulaField VFormulaField = GetControl<FormulaField>(null);
        #endregion

        #region KPITag settings
        public static TextField KPITagSettingsNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITagSettingsName);
        public static TextField KPITagSettingscodeTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITagSettingsCode);
        public static TextField KPITagSettingsCommentTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITagSettingsComment);
        public static FormulaField KPIFormulaField = GetControl<FormulaField>(null);
        public static TextField KPITargetBaselineWorkdayRuleValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineWorkdayRuleValue);
        public static TextField KPITargetBaselineNonworkdayRuleValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineNonworkdayRuleValue);
        public static TextField KPITargetBaselineSpecialdayRuleValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineSpecialdayRuleValue);
        public static TextField KPITargetBaselineAnnualCalculationValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineAnnualCalculationValue);
        public static TextField KPITargetBaselineJanuaryCalculationValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineJanuaryCalculationValue);
        public static TextField KPITargetBaselineFebruaryCalculationValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineFebruaryCalculationValue);
        public static TextField KPITargetBaselineMarchCalculationValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineMarchCalculationValue);
        public static TextField KPITargetBaselineAprilCalculationValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineAprilCalculationValue);
        public static TextField KPITargetBaselineMayCalculationValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineMayCalculationValue);
        public static TextField KPITargetBaselineJuneCalculationValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineJuneCalculationValue);
        public static TextField KPITargetBaselineJulyCalculationValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineJulyCalculationValue);
        public static TextField KPITargetBaselineAugustCalculationValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineAugustCalculationValue);
        public static TextField KPITargetBaselineSeptemberCalculationValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineSeptemberCalculationValue);
        public static TextField KPITargetBaselineOctoberCalculationValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineOctoberCalculationValue);
        public static TextField KPITargetBaselineNovemberCalculationValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineNovemberCalculationValue);
        public static TextField KPITargetBaselineDecemberCalculationValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldKPITargetBaselineDecemberCalculationValue);

        public static TextField TargetNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldTargetName);
        public static TextField BaselineNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldBaselineName);

        #endregion

        #region Area dimension settings
        public static TextField AreaDimensionSettingsNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldAreaDimensionSettingsName);
        public static TextField AreaDimensionSettingsCommentTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldAreaDimensionSettingsComment);
        #endregion

        #region CustomizedLabellingSetting
        public static TextField TextFieldCustomizedLabellingName = GetControl<TextField>(JazzControlLocatorKey.TextFieldCustomizedLabellingName);
        #endregion
        #endregion

        #region Platform settings
        #region Workday
        public static TextField WorkdayCalendarNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldWorkdayCalendarName);
        #endregion

        #region Worktime
        public static TextField WorktimeCalendarNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldWorktimeCalendarName);
        #endregion

        #region HeatingCoolingSeason
        public static TextField HeatingCoolingSeasonCalendarNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldHeatingCoolingSeasonCalendarName);
        #endregion

        #region Daynight
        public static TextField DayNightCalendarNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldDayNightCalendarName);
        #endregion

        #region Carbonfactor
        public static TextField CarbonFactorValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldCarbonFactorValue, 1);
        #endregion

        #region TOU
        public static TextField TOUBasicPropertyNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldTOUBasicPropertyName, 1);
        public static TextField TOUBasicPropertyPlainPriceValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldTOUBasicPropertyPlainPriceValue, 1);
        public static TextField TOUBasicPropertyPeakPriceValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldTOUBasicPropertyPeakPriceValue, 1);
        public static TextField TOUBasicPropertyValleyPriceValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldTOUBasicPropertyValleyPriceValue, 1);
        public static TextField TOUPulsePeakPropertyPriceValueTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldTOUPulsePeakPropertyPriceValue, 1);        
        #endregion

        #region Customer settings
        public static TextField CustomerNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldCustomerName);
        public static TextField CustomercodeTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldCustomerCode);
        public static TextField CustomerAddressTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldCustomerAddress);
        public static TextField CustomerManagerTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldCustomerManager);
        public static TextField CustomerTelephoneTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldCustomerTelephone);
        public static TextField CustomerEmailTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldCustomerEmail);
        public static TextField CustomerCommentTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldCustomerComment);
        public static TextField UploadLogoTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldUploadLogo);
        #endregion

        #region User Setting
        public static TextField UserNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldUserName);
        public static TextField UserRealNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldUserRealName);
        public static TextField UserTelephoneTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldUserTelephone);
        public static TextField UserEmailTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldUserEmail);
        public static TextField UserTitleTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldUserTitle);
        public static TextField UserCommentTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldUserComment);
        #endregion

        #region UserFunctionRoleType
        public static TextField FunctionRoleTypeNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldFunctionRoleTypeName);
        #endregion

        #region User Profile
        public static TextField UserProfileNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldUserProfileName);
        public static TextField UserProfileRealNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldUserProfileRealName);
        public static TextField UserProfileTelephoneTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldUserProfileTelephone);
        public static TextField UserProfileEmailTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldUserProfileEmail);
        public static TextField UserProfileTitleTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldUserProfileTitle);
        public static TextField UserProfileCommentTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldUserProfileComment);
        public static TextField UserOriginalPasswordTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldUserOriginalPassword);
        public static TextField UserNewPasswordTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldUserNewPassword);
        public static TextField UserConfirmPasswordTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldUserConfirmPassword);
        #endregion
        #endregion

        #region homepage

        public static TextField ShareReceiveWindowCommentTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldShareReceiveWindowComment);
        public static TextField ReceiveWindowCommentTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldReceiveWindowComment);
        public static TextField EditModifyCommentTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldEditModifyComment);
        public static TextField MaxWidgetRightCommentTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldMaxWidgetRightComment);
        
        #endregion

    }
}
