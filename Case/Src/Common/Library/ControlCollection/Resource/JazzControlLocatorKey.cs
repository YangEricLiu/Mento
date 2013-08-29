using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public static class JazzControlLocatorKey
    {
        #region Button

        #region login
        public static string ButtonLoginSubmit = "ButtonLoginSubmit";
        public static string ButtonLoginCustomerOptionConfirm = "ButtonLoginCustomerOptionConfirm";
        #endregion

        #region navigator
        public static string ButtonNavigatorHomePage = "ButtonNavigatorHomePage";
        public static string ButtonNavigatorEnergyView = "ButtonNavigatorEnergyView";
        public static string ButtonNavigatorSettings = "ButtonNavigatorSettings";
        public static string ButtonNavigatorPlatformSettings = "ButtonNavigatorPlatformSettings";

        public static string ButtonNavigatorEnergyAnalysis = "ButtonNavigatorEnergyAnalysis";
        public static string ButtonNavigatorCarbonUsage = "ButtonNavigatorCarbonUsage";
        public static string ButtonNavigatorCost = "ButtonNavigatorCost";
        public static string ButtonNavigatorUnitKPI = "ButtonNavigatorUnitKPI";
        public static string ButtonNavigatorEnergyRatio = "ButtonNavigatorEnergyRatio";
        public static string ButtonNavigatorRank = "ButtonNavigatorRank";
        public static string ButtonNavigatorTimeSettings = "ButtonNavigatorTimeSettings";
        public static string ButtonNavigatorCarbonSettings = "ButtonNavigatorCarbonSettings";
        public static string ButtonNavigatorPriceSettings = "ButtonNavigatorPriceSettings";
        public static string ButtonNavigatorCustomerManagement = "ButtonNavigatorCustomerManagement";
        public static string ButtonNavigatorUserManagement = "ButtonNavigatorUserManagement";
        public static string ButtonNavigatorTagSettings = "ButtonNavigatorTagSettings";
        public static string ButtonNavigatorHierarchySettings = "ButtonNavigatorHierarchySettings";
        public static string ButtonNavigatorMyFavirate = "ButtonNavigatorMyFavirate";
        public static string ButtonNavigatorAllDashboards = "ButtonNavigatorAllDashboards";
        public static string ButtonNavigatorRecentView = "ButtonNavigatorRecentView";

        public static string ButtonNavigatorAssociationSettings = "ButtonNavigatorAssociationSettings";
        public static string ButtonNavigatorTimeSettingsWorkday = "ButtonNavigatorTimeSettingsWorkday";
        public static string ButtonNavigatorTimeSettingsWorktime = "ButtonNavigatorTimeSettingsWorktime";
        public static string ButtonNavigatorTimeSettingsSeason = "ButtonNavigatorTimeSettingsSeason";
        public static string ButtonNavigatorTimeSettingsDaynight = "ButtonNavigatorTimeSettingsDaynight";
        public static string ButtonNavigatorCarbonSettingsCarbon = "ButtonNavigatorCarbonSettingsCarbon";
        public static string ButtonNavigatorPriceSettingsPrice = "ButtonNavigatorPriceSettingsPrice";
        public static string ButtonNavigatorCustomerManagementCustomer = "ButtonNavigatorCustomerManagementCustomer";
        public static string ButtonNavigatorUserManagementUser = "ButtonNavigatorUserManagementUser";
        public static string ButtonNavigatorUserManagementUserTypePermission = "ButtonNavigatorUserManagementUserTypePermission";
        public static string ButtonNavigatorTagSettingsP = "ButtonNavigatorTagSettingsP";
        public static string ButtonNavigatorTagSettingsV = "ButtonNavigatorTagSettingsV";
        public static string ButtonNavigatorTagSettingsKPI = "ButtonNavigatorTagSettingsKPI";
        public static string ButtonNavigatorHierarchySettingsHierarchy = "ButtonNavigatorHierarchySettingsHierarchy";
        public static string ButtonNavigatorHierarchySettingsSystemDimension = "ButtonNavigatorHierarchySettingsSystemDimension";
        public static string ButtonNavigatorHierarchySettingsAreaDimension = "ButtonNavigatorHierarchySettingsAreaDimension";
        public static string ButtonNavigatorAssociationHierarchy = "ButtonNavigatorAssociationHierarchy";
        public static string ButtonNavigatorAssociationSystemDimension = "ButtonNavigatorAssociationSystemDimension";
        public static string ButtonNavigatorAssociationAreaDimension = "ButtonNavigatorAssociationAreaDimension";
        public static string ButtonNavigatorSelectedCustomer = "ButtonNavigatorSelectedCustomer";
        #endregion

        #region User
        public static string ButtonUserCreate = "ButtonUserCreate";
        public static string ButtonUserRefresh = "ButtonUserRefresh";
        public static string ButtonUserSave = "ButtonUserSave";
        public static string ButtonUserCancel = "ButtonUserCancel";
        public static string ButtonUserModify = "ButtonUserModify";
        public static string ButtonUserDelete = "ButtonUserDelete";

        public static string ButtonUserSendEmail = "ButtonUserSendEmail";
        public static string LinkButtonUserViewFunctionDetail = "LinkButtonUserViewFunctionDetail";

        public static string ButtonUserGeneratePassword = "ButtonUserGeneratePassword";
        public static string ButtonUserTypePermissionModify = "ButtonUserTypePermissionModify";
        public static string ButtonUserTypePermissionRefresh = "ButtonUserTypePermissionRefresh";
        public static string ButtonUserTypePermissionSave = "ButtonUserTypePermissionSave";
        public static string ButtonUserTypePermissionCancel = "ButtonUserTypePermissionCancel";
        public static string LinkButtonUserAssociatedCustomer = "LinkButtonUserAssociatedCustomer";

        public static string ButtonUserTypePermissionDisplayClose = "ButtonUserTypePermissionDisplayClose";
        #endregion

        #region UserProfile
        public static string ButtonUserProfile = "ButtonUserProfile";
        public static string MenuButtonUserProfileView = "MenuButtonUserProfileView";
        public static string ButtonUserProfileModify = "ButtonUserProfileModify";
        public static string ButtonUserProfileCancel = "ButtonUserProfileCancel";
        public static string ButtonUserProfileSave = "ButtonUserProfileSave";
        public static string ButtonUserProfileClose = "ButtonUserProfileClose";
        public static string MenuButtonExitJazz = "MenuButtonExitJazz";
        public static string MenuButtonModifyUserPassword = "MenuButtonModifyUserPassword";

        #endregion

        #region UserFunctionRoleTypePermission
        public static string ButtonCreatFunctionRoleType = "ButtonCreatFunctionRoleType";
        public static string ButtonSaveFunctionRoleType = "ButtonSaveFunctionRoleType";
        public static string ButtonCancelFunctionRoleType = "ButtonCancelFunctionRoleType";
        public static string ButtonModifyFunctionRoleType = "ButtonModifyFunctionRoleType";
        public static string ButtonDeleteFunctionRoleType = "ButtonDeleteFunctionRoleType";
        #endregion

        #region energy management

        #region common

        public static string SplitButtonEnergyViewViewData = "SplitButtonEnergyViewViewData";
        public static string MenuButtonEnergyViewMore = "MenuButtonEnergyViewMore";
        public static string ButtonEnergyViewAddTimeSpan = "ButtonEnergyViewAddTimeSpan";
        public static string ButtonEnergyViewRemoveAll = "ButtonEnergyViewRemoveAll";
        public static string MenuButtonEnergyViewConvertTarget = "MenuButtonEnergyViewConvertTarget";
        public static string MenuButtonFuncModeConvert = "MenuButtonFuncModeConvert";
        public static string MenuButtonTagModeConvert = "MenuButtonTagModeConvert";
        public static string MenuButtonUnitTypeConvert = "MenuButtonUnitTypeConvert";
        public static string MenuButtonRadioTypeConvert = "MenuButtonRadioTypeConvert";
        public static string MenuButtonRankTypeConvert = "MenuButtonRankTypeConvert";
        public static string ButtonEnergyViewPeakValley = "ButtonEnergyViewPeakValley";
        public static string ButtonModifyWidgetName = "ButtonModifyWidgetName";
        public static string ModifyWidgetNameSaveButton = "ModifyWidgetNameSaveButton";
        public static string ModifyWidgetNameCancelButton = "ModifyWidgetNameCancelButton";
        public static string WidgetName = "WidgetName";
        public static string ButtonDeleteWidget = "ButtonDeleteWidget";
        public static string ButtonCreateNewDashboard = "ButtonCreateNewDashboard";
        public static string ButtonExistedDashboard = "ButtonExistedDashboard";
        public static string ButtonDashboardHierarchyName = "ButtonDashboardHierarchyName";
        public static string DeleteWidgetConfirmButton = "DeleteWidgetConfirmButton";
        public static string DeleteWidgetCancelButton = "DeleteWidgetCancelButton";

        public static string ButtonEnergyDisplayStepHour = "ButtonEnergyDisplayStepHour";
        public static string ButtonEnergyDisplayStepDay = "ButtonEnergyDisplayStepDay";
        public static string ButtonEnergyDisplayStepWeek = "ButtonEnergyDisplayStepWeek";
        public static string ButtonEnergyDisplayStepMonth = "ButtonEnergyDisplayStepMonth";
        public static string ButtonEnergyDisplayStepYear = "ButtonEnergyDisplayStepYear";

        public static string ButtonMultipleHierarchyTree = "ButtonMultipleHierarchyTree";
        public static string TabButtonMultipleHierarchyAllTagsTab = "TabButtonMultipleHierarchyAllTagsTab";
        public static string TabButtonMultipleHierarchyAreaDimensionTab = "TabButtonMultipleHierarchyAreaDimensionTab";
        public static string TabButtonMultipleHierarchySystemDimensionTab = "TabButtonMultipleHierarchySystemDimensionTab";
        public static string ButtonMultipleHierarchySelectSystemDimension = "ButtonMultipleHierarchySelectSystemDimension";
        public static string ButtonMultipleHierarchySelectAreaDimension = "ButtonMultipleHierarchySelectAreaDimension";
        public static string ButtonMultipleHierarchyConfirm = "ButtonMultipleHierarchyConfirm";
        public static string ButtonMultipleHierarchyGiveUp = "ButtonMultipleHierarchyGiveUp";
        public static string ButtonMultipleHierarchyAddTags = "ButtonMultipleHierarchyAddTags";

        public static string LinkButtonIntervalDialogAddTimeSpan = "LinkButtonIntervalDialogAddTimeSpan";
        public static string ButtonIntervalDialogDeleteTimeSpan = "ButtonIntervalDialogDeleteTimeSpan";
        public static string ButtonIntervalDialogConfirm = "ButtonIntervalDialogConfirm";
        public static string ButtonIntervalDialogGiveUp = "ButtonIntervalDialogGiveUp";

        public static string ButtonDisplayStepWindow = "ButtonDisplayStepWindow";

        #endregion

        #region energy analysis

        public static string ButtonEnergyViewSelectHierarchy = "ButtonEnergyViewSelectHierarchy";
        public static string ButtonEnergyViewSelectSystemDimension = "ButtonEnergyViewSelectSystemDimension";
        public static string ButtonEnergyViewSelectAreaDimension = "ButtonEnergyViewSelectAreaDimension";

        public static string TabButtonEnergyViewALLTagsTab = "TabButtonEnergyViewALLTagsTab";
        public static string TabButtonEnergyViewSystemDimensionTagsTab = "TabButtonEnergyViewSystemDimensionTagsTab";
        public static string TabButtonEnergyViewAreaDimensionTagsTab = "TabButtonEnergyViewAreaDimensionTagsTab";
        #endregion

        #region rank

        public static string ButtonRankSelectSystemDimension = "ButtonRankSelectSystemDimension";
        public static string ButtonRankSelectHierarchy = "ButtonRankSelectHierarchy";
        public static string ButtonWidgetSaveHierarchy = "ButtonWidgetSaveHierarchy";

        public static string TabButtonRankHierarchyTab = "TabButtonRankHierarchyTab";
        public static string TabButtonRankSystemDimensionTab = "TabButtonRankSystemDimensionTab";
        public static string ButtonConfirmHierarchyRank = "ButtonConfirmHierarchyRank";
        public static string ButtonClearHierarchyRank = "ButtonClearHierarchyRank";
        
        #endregion

        #region cost

        public static string TabButtonCostAreaDimensionTab = "TabButtonCostAreaDimensionTab";

        #endregion

        #endregion

        #region customersettings
        #region ptag
        public static string ButtonPTagSettingsCreatePTag = "ButtonPTagSettingsCreatePTag";
        public static string ButtonPTagSettingsSave = "ButtonPTagSettingsSave";
        public static string ButtonPTagSettingsCancel = "ButtonPTagSettingsCancel";
        public static string ButtonPTagSettingsModify = "ButtonPTagSettingsModify";
        public static string ButtonPTagSettingsDelete = "ButtonPTagSettingsDelete";
        #endregion

        #region vtag
        public static string TabButtonVTagSettingsBasicProperty = "TabButtonVTagSettingsBasicProperty";
        public static string TabButtonVTagSettingsFormula = "TabButtonVTagSettingsFormula";
        public static string ButtonVTagSettingsFormulaUpdate = "ButtonVTagSettingsFormulaUpdate";
        public static string ButtonVTagSettingsFormulaSave = "ButtonVTagSettingsFormulaSave";
        public static string ButtonVTagSettingsFormulaCancel = "ButtonVTagSettingsFormulaCancel";
        public static string ButtonVTagSettingsCreateVTag = "ButtonVTagSettingsCreateVTag";
        public static string ButtonVTagSettingsSave = "ButtonVTagSettingsSave";
        public static string ButtonVTagSettingsCancel = "ButtonVTagSettingsCancel";
        public static string ButtonVTagSettingsModify = "ButtonVTagSettingsModify";
        public static string ButtonVTagSettingsDelete = "ButtonVTagSettingsDelete";
        #endregion

        #region kpitag
        public static string TabButtonKPITagSettingsBasicProperty = "TabButtonKPITagSettingsBasicProperty";
        public static string TabButtonKPITagSettingsFormula = "TabButtonKPITagSettingsFormula";
        public static string ButtonKPITagSettingsFormulaUpdate = "ButtonKPITagSettingsFormulaUpdate";
        public static string ButtonKPITagSettingsFormulaSave = "ButtonKPITagSettingsFormulaSave";
        public static string ButtonKPITagSettingsFormulaCancel = "ButtonKPITagSettingsFormulaCancel";
        public static string ButtonKPITagSettingsCreateKPITag = "ButtonKPITagSettingsCreateKPITag";
        public static string ButtonKPITagSettingsSave = "ButtonKPITagSettingsSave";
        public static string ButtonKPITagSettingsCancel = "ButtonKPITagSettingsCancel";
        public static string ButtonKPITagSettingsModify = "ButtonKPITagSettingsModify";
        public static string ButtonKPITagSettingsDelete = "ButtonKPITagSettingsDelete";
        public static string TabButtonKPITargetProperty = "TabButtonKPITargetProperty";
        public static string TabButtonKPIBaselineProperty = "TabButtonKPIBaselineProperty";
        public static string ButtonKPITargetBaselineCalculationRuleView = "ButtonKPITargetBaselineCalculationRuleView";
        public static string ButtonKPITargetBaselineCalculationRuleCreate = "ButtonKPITargetBaselineCalculationRuleCreate";
        public static string ButtonKPITargetBaselineCalculationRuleBack = "ButtonKPITargetBaselineCalculationRuleBack";
        public static string ButtonKPITargetBaselineCalculationRuleModify = "ButtonKPITargetBaselineCalculationRuleModify";
        public static string ButtonKPITargetBaselineCalculateTarget = "ButtonKPITargetBaselineCalculateTarget";
        public static string ButtonKPITargetBaselineCalculateBaseline = "ButtonKPITargetBaselineCalculateBaseline";
        public static string ButtonKPITargetBaselineRevise = "ButtonKPITargetBaselineRevise";
        public static string ButtonKPITargetBaselineSave = "ButtonKPITargetBaselineSave";
        public static string ButtonKPITargetBaselineCancel = "ButtonKPITargetBaselineCancel";
        public static string ButtonKPITargetBaselineAddSpecialDates = "ButtonKPITargetBaselineAddSpecialDates";
        public static string ButtonKPITargetBaselineDeleteSpecialDates = "ButtonKPITargetBaselineDeleteSpecialDates";
        #endregion

        #region hierarchy
        public static string ButtonHierarchySettingsCreateChildHierarchy = "ButtonHierarchySettingsCreateChildHierarchy";
        public static string ButtonHierarchySettingsSave = "ButtonHierarchySettingsSave";
        public static string ButtonHierarchySettingsCancel = "ButtonHierarchySettingsCancel";
        public static string ButtonHierarchySettingsModify = "ButtonHierarchySettingsModify";
        public static string ButtonHierarchySettingsDelete = "ButtonHierarchySettingsDelete";
        #endregion

        #region hierarchycalendar
        public static string TabButtonCalendarProperty = "TabButtonCalendarProperty";
        public static string ButtonCalendarCreate = "ButtonCalendarCreate";
        public static string ButtonCalendarSave = "ButtonCalendarSave";
        public static string ButtonCalendarCancel = "ButtonCalendarCancel";
        public static string ButtonCalendarUpdate = "ButtonCalendarUpdate";
        public static string ButtonWorkdayCreate = "ButtonWorkdayCreate";
        public static string ButtonHeatingCoolingCreate = "ButtonHeatingCoolingCreate";
        public static string ButtonDayNightCreate = "ButtonDayNightCreate";
        public static string LinkButtonWorktimeCreate = "LinkButtonWorktimeCreate";
        public static string ButtonWorkdayDelete = "ButtonWorkdayDelete";
        public static string ButtonHeatingCoolingDelete = "ButtonHeatingCoolingDelete";
        public static string ButtonDayNightDelete = "ButtonDayNightDelete";
        #endregion

        #region hierarchypeoplearea
        public static string TabButtonPeopleAreaProperty = "TabButtonPeopleAreaProperty";
        public static string ButtonPeopleAreaCreate = "ButtonPeopleAreaCreate";
        public static string ButtonPeopleAreaSave = "ButtonPeopleAreaSave";
        public static string ButtonPeopleAreaCancel = "ButtonPeopleAreaCancel";
        public static string ButtonPeopleAreaUpdate = "ButtonPeopleAreaUpdate";
        public static string ButtonPeopleCreate = "ButtonPeopleCreate";
        public static string ButtonDeletePeopleItem = "ButtonDeletePeopleItem";
        #endregion

        #region hierarchycost
        public static string TabButtonCostProperty = "TabButtonCostProperty";
        public static string ButtonCostCreate = "ButtonCostCreate";
        public static string ButtonCostSave = "ButtonCostSave";
        public static string ButtonCostCancel = "ButtonCostCancel";
        public static string ButtonCostUpdate = "ButtonCostUpdate";
        public static string ButtonElectricCostCreate = "ButtonElectricCostCreate";
        public static string ButtonGasCostCreate = "ButtonGasCostCreate";
        public static string ButtonWaterCostCreate = "ButtonWaterCostCreate";
        public static string ButtonHeatQCostCreate = "ButtonHeatQCostCreate";
        public static string ButtonCoolQCostCreate = "ButtonCoolQCostCreate";
        public static string ButtonLightWaterCostCreate = "ButtonLightWaterCostCreate";
        public static string ButtonCoalCostCreate = "ButtonCoalCostCreate";
        public static string ButtonPetrolCostCreate = "ButtonPetrolCostCreate";
        public static string ButtonKeroseneCostCreate = "ButtonKeroseneCostCreate";
        public static string ButtonDieselOilCostCreate = "ButtonDieselOilCostCreate";
        public static string ButtonLowPressureSteamCostCreate = "ButtonLowPressureSteamCostCreate";
        public static string ButtonWaterCostDelete = "ButtonWaterCostDelete";
        public static string LinkButtonFactor = "LinkButtonFactor";
        public static string ButtonElectricCostDelete = "ButtonElectricCostDelete";    
        #endregion

        #region systemdimension
        public static string ButtonDimensionShowHierarchyTree = "ButtonDimensionShowHierarchyTree";
        public static string ButtonSystemDimensionSet = "ButtonSystemDimensionSet";
        public static string ButtonSystemDimensionSettingsDialogReturn = "ButtonSystemDimensionSettingsDialogReturn";
        public static string ButtonSystemDimensionSettingsClose = "ButtonSystemDimensionSettingsClose";
        #endregion

        #region areadimension
        public static string ButtonAreaDimensionSettingsCreate = "ButtonAreaDimensionSettingsCreate";
        public static string ButtonAreaDimensionSettingsSave = "ButtonAreaDimensionSettingsSave";
        public static string ButtonAreaDimensionSettingsCancel = "ButtonAreaDimensionSettingsCancel";
        public static string ButtonAreaDimensionSettingsModify = "ButtonAreaDimensionSettingsModify";
        public static string ButtonAreaDimensionSettingsDelete = "ButtonAreaDimensionSettingsDelete";
        // Greenie added
        public static string ButtonAreaDimensionSettingsConfirmDelete = "ButtonAreaDimensionSettingsConfirmDelete";
        public static string ButtonAreaDimensionSettingsCancelDelete = "ButtonAreaDimensionSettingsCancelDelete";
        #endregion

        #region hierarchyassociation
        public static string ButtonAssociationSettingsTagAssociate = "ButtonAssociationSettingsTagAssociate";
        public static string ButtonAssociationSettingsAssociate = "ButtonAssociationSettingsAssociate";
        #endregion

        #region hierarchydisassociation
        public static string ButtonAssociationSettingsDisassociate = "ButtonAssociationSettingsDisassociate";
        public static string ButtonAssociationSettingsCancel = "ButtonAssociationSettingsCancel";
        public static string ButtonAssociatedTagRemove = "ButtonAssociatedTagRemove";
        #endregion

        #region systemdimensionassociation
        #endregion

        #region areadimensionassociation
        #endregion

        #region TargetBaseline

        public static string LinkButtonTargetCalendarInfo = "LinkButtonTargetCalendarInfo";
        public static string LinkButtonBaselineCalendarInfo = "LinkButtonBaselineCalendarInfo";
        public static string ButtonCloseTBCalendarWindow = "ButtonCloseTBCalendarWindow";
        public static string ButtonDeleteSpecialdayItem = "ButtonDeleteSpecialdayItem"; 
        
        #endregion

        #endregion

        #region User Data Scope Permission
        public static string ButtonModifyUserDataPermission = "ButtonModifyUserDataPermission";
        public static string ButtonSaveUserDataPermission = "ButtonSaveUserDataPermission";
        public static string ButtonCancelUserDataPermission = "ButtonCancelUserDataPermission";
        public static string ButtonClosePermissionTreeWindow = "ButtonClosePermissionTreeWindow";
        public static string TabButtonUserDataPermission = "TabButtonUserDataPermission";
        public static string TabButtonUserBasicProperties = "TabButtonUserBasicProperties";
        public static string ButtonTreeWindowSave = "ButtonTreeWindowSave";
        public static string ButtonTreeWindowCancel = "ButtonTreeWindowCancel";
        public static string ButtonCustomerNamesViewStatus = "ButtonCustomerNamesViewStatus";

        #endregion

        #region platformsettings
        #region workday
        public static string ButtonWorkdayCalendarCreate = "ButtonWorkdayCalendarCreate";
        public static string ButtonWorkdayCalendarModify = "ButtonWorkdayCalendarModify";
        public static string ButtonWorkdayCalendarSave = "ButtonWorkdayCalendarSave";
        public static string ButtonWorkdayCalendarCancel = "ButtonWorkdayCalendarCancel";
        public static string ButtonWorkdayCalendarDelete = "ButtonWorkdayCalendarDelete";
        public static string ButtonWorkdayCalendarAddSpecialDates = "ButtonWorkdayCalendarAddSpecialDates";
        public static string ButtonWorkdayDeleteRangeItem = "ButtonWorkdayDeleteRangeItem";
        #endregion

        #region worktime
        public static string ButtonWorktimeCalendarCreate = "ButtonWorktimeCalendarCreate";
        public static string ButtonWorktimeCalendarModify = "ButtonWorktimeCalendarModify";
        public static string ButtonWorktimeCalendarSave = "ButtonWorktimeCalendarSave";
        public static string ButtonWorktimeCalendarCancel = "ButtonWorktimeCalendarCancel";
        public static string ButtonWorktimeCalendarDelete = "ButtonWorktimeCalendarDelete";
        public static string LinkButtonWorktimeCalendarAddMoreRanges = "LinkButtonWorktimeCalendarAddMoreRanges";
        public static string ButtonWorktimeDeleteRangeItem = "ButtonWorktimeDeleteRangeItem";
        #endregion

        #region heatingcoolingseason
        public static string ButtonHeatingCoolingSeasonCalendarCreate = "ButtonHeatingCoolingSeasonCalendarCreate";
        public static string ButtonHeatingCoolingSeasonCalendarModify = "ButtonHeatingCoolingSeasonCalendarModify";
        public static string ButtonHeatingCoolingSeasonCalendarSave = "ButtonHeatingCoolingSeasonCalendarSave";
        public static string ButtonHeatingCoolingSeasonCalendarCancel = "ButtonHeatingCoolingSeasonCalendarCancel";
        public static string ButtonHeatingCoolingSeasonCalendarDelete = "ButtonHeatingCoolingSeasonCalendarDelete";
        public static string ButtonHeatingCoolingSeasonCalendarAddMoreWarmRanges = "ButtonHeatingCoolingSeasonCalendarAddMoreWarmRanges";
        public static string ButtonHeatingCoolingSeasonCalendarAddMoreColdRanges = "ButtonHeatingCoolingSeasonCalendarAddMoreColdRanges";
        public static string ButtonHeatingCoolingSeasonCalendarWarmDeleteRangeItem = "ButtonHeatingCoolingSeasonCalendarWarmDeleteRangeItem";
        public static string ButtonHeatingCoolingSeasonCalendarColdDeleteRangeItem = "ButtonHeatingCoolingSeasonCalendarColdDeleteRangeItem";
        #endregion

        #region daynight
        public static string ButtonDayNightCalendarCreate = "ButtonDayNightCalendarCreate";
        public static string ButtonDayNightCalendarModify = "ButtonDayNightCalendarModify";
        public static string ButtonDayNightCalendarSave = "ButtonDayNightCalendarSave";
        public static string ButtonDayNightCalendarCancel = "ButtonDayNightCalendarCancel";
        public static string ButtonDayNightCalendarDelete = "ButtonDayNightCalendarDelete";
        public static string LinkButtonDayNightCalendarAddMoreRanges = "LinkButtonDayNightCalendarAddMoreRanges";
        public static string ButtonDayNightDeleteRangeItem = "ButtonDayNightDeleteRangeItem";
        #endregion

        #region carbonfactor
        public static string ButtonCarbonFactorCreate = "ButtonCarbonFactorCreate";
        public static string ButtonCarbonFactorModify = "ButtonCarbonFactorModify";
        public static string ButtonCarbonFactorSave = "ButtonCarbonFactorSave";
        public static string ButtonCarbonFactorCancel = "ButtonCarbonFactorCancel";
        public static string ButtonCarbonFactorDelete = "ButtonCarbonFactorDelete";
        public static string ButtonCarbonFactorAddMoreRanges = "ButtonCarbonFactorAddMoreRanges";
        #endregion

        #region TOU
        public static string ButtonTOUBasicPropertyCreate = "ButtonTOUBasicPropertyCreate";
        public static string ButtonTOUBasicPropertyModify = "ButtonTOUBasicPropertyModify";
        public static string ButtonTOUBasicPropertySave = "ButtonTOUBasicPropertySave";
        public static string ButtonTOUBasicPropertyCancel = "ButtonTOUBasicPropertyCancel";
        public static string ButtonTOUBasicPropertyDelete = "ButtonTOUBasicPropertyDelete";
        public static string LinkButtonTOUBasicPropertyAddMorePeakRanges = "LinkButtonTOUBasicPropertyAddMorePeakRanges";
        public static string LinkButtonTOUBasicPropertyAddMoreValleyRanges = "LinkButtonTOUBasicPropertyAddMoreValleyRanges";
        public static string ButtonTOUBasicPropertyDeletePeakRangeItem = "ButtonTOUBasicPropertyDeletePeakRangeItem";
        public static string ButtonTOUBasicPropertyDeleteValleyRangeItem = "ButtonTOUBasicPropertyDeleteValleyRangeItem";
        public static string TabButtonTOUPulsePeakProperty = "TabButtonTOUPulsePeakProperty";
        public static string ButtonTOUPulsePeakPropertyCreate = "ButtonTOUPulsePeakPropertyCreate";
        public static string ButtonTOUPulsePeakPropertyPlusIcon = "ButtonTOUPulsePeakPropertyPlusIcon";
        public static string ButtonTOUPulsePeakPropertyModify = "ButtonTOUPulsePeakPropertyModify";
        public static string ButtonTOUPulsePeakPropertySave = "ButtonTOUPulsePeakPropertySave";
        public static string ButtonTOUPulsePeakPropertyCancel = "ButtonTOUPulsePeakPropertyCancel";
        public static string LinkButtonTOUPulsePeakPropertyAddMoreRanges = "LinkButtonTOUPulsePeakPropertyAddMoreRanges";
        public static string ButtonTOUPulsePeakPropertyDeleteWholeRange = "ButtonTOUPulsePeakPropertyDeleteWholeRange";
        public static string ButtonTOUPulsePeakPropertyDeleteRangeItem = "ButtonTOUPulsePeakPropertyDeleteRangeItem";
        #endregion

        #region customermanagement
        public static string ButtonAddCustomer = "ButtonAddCustomer";
        public static string ButtonUploadLogo = "ButtonUploadLogo";
        public static string ButtonSaveCustomer = "ButtonSaveCustomer";
        public static string ButtonCancelCustomer = "ButtonCancelCustomer";
        public static string ButtonDeleteCustomer = "ButtonDeleteCustomer";
        public static string ButtonUpdateCustomer = "ButtonUpdateCustomer";
        #endregion

        #endregion

        #region Home page

        public static string ButtonAllDashboardsHierarchyTree = "ButtonAllDashboardsHierarchyTree";
        public static string ButtonHomePageDashboard = "ButtonHomePageDashboard";

        public static string ButtonWidgetMaxDialogView = "ButtonWidgetMaxDialogView";
        public static string ButtonWidgetMaxDialogClose = "ButtonWidgetMaxDialogClose";
        public static string ButtonWidgetMaxDialogPrev = "ButtonWidgetMaxDialogPrev";
        public static string ButtonWidgetMaxDialogNext = "ButtonWidgetMaxDialogNext";

        public static string ButtonWidgetMax = "ButtonWidgetMax";
        public static string ButtonWidgetShare = "ButtonWidgetShare";
        public static string ButtonWidgetRename = "ButtonWidgetRename";
        public static string ButtonWidgetDelete = "ButtonWidgetDelete";

        #endregion

        #endregion

        #region TextField
        #region login
        public static string TextFieldLoginUserName = "TextFieldLoginUserName";
        public static string TextFieldLoginPassword = "TextFieldLoginPassword";
        #endregion

        #region User
        public static string TextFieldUserName = "TextFieldUserName";
        public static string TextFieldUserRealName = "TextFieldUserRealName";
        public static string TextFieldUserTitle = "TextFieldUserTitle";
        public static string TextFieldUserTelephone = "TextFieldUserTelephone";
        public static string TextFieldUserEmail = "TextFieldUserEmail";
        public static string TextFieldUserComment = "TextFieldUserComment";
        #endregion

        #region UserProfile
        public static string TextFieldUserProfileTitle = "TextFieldUserProfileTitle";
        public static string TextFieldUserProfileEmail = "TextFieldUserProfileEmail";
        public static string TextFieldUserProfileTelephone = "TextFieldUserProfileTelephone";
        public static string TextFieldUserProfileComment = "TextFieldUserProfileComment";
        public static string TextFieldUserProfileName = "TextFieldUserProfileName";
        public static string TextFieldUserProfileRealName = "TextFieldUserProfileRealName";
        public static string TextFieldUserOriginalPassword = "TextFieldUserOriginalPassword";
        public static string TextFieldUserNewPassword = "TextFieldUserNewPassword";
        public static string TextFieldUserConfirmPassword = "TextFieldUserConfirmPassword";
        #endregion

        #region energyview
        public static string TextFieldEnergyViewSaveDashboardWidgetName = "TextFieldEnergyViewSaveDashboardWidgetName";
        public static string TextFieldEnergyViewSaveDashboardDashboardName = "TextFieldEnergyViewSaveDashboardDashboardName";
        public static string TextFieldModifyWidgetName = "TextFieldModifyWidgetName";
        #endregion

        #region customersettings
        #region hierarchysettings
        public static string TextFieldHierarchySettingsName = "TextFieldHierarchySettingsName";
        public static string TextFieldHierarchySettingsCode = "TextFieldHierarchySettingsCode";
        public static string TextFieldHierarchySettingsComment = "TextFieldHierarchySettingsComment";
        #endregion

        #region hierarchypeopertysettings
        public static string TextFieldTotalAreaValue = "TextFieldTotalAreaValue";
        public static string TextFieldHeatingAreaValue = "TextFieldHeatingAreaValue";
        public static string TextFieldCoolingAreaValue = "TextFieldCoolingAreaValue";
        public static string TextFieldPeopleNumber = "TextFieldPeopleNumber";
        public static string TextFieldElectricPrice = "TextFieldElectricPrice";
        public static string TextFieldElectricPaddingCost = "TextFieldElectricPaddingCost";
        public static string TextFieldElectricTransformerCapacity = "TextFieldElectricTransformerCapacity";
        public static string TextFieldElectricTransformerPrice = "TextFieldElectricTransformerPrice";
        public static string TextFieldElectricHourPrice = "TextFieldElectricHourPrice";
        public static string TextFieldWaterPrice = "TextFieldWaterPrice";
        public static string TextFieldGasPrice = "TextFieldGasPrice";
        public static string TextFieldHeatQPrice = "TextFieldHeatQPrice";
        public static string TextFieldCoolQPrice = "TextFieldCoolQPrice";
        public static string TextFieldLightWaterPrice = "TextFieldLightWaterPrice";
        public static string TextFieldCoalPrice = "TextFieldCoalPrice";
        public static string TextFieldPetrolPrice = "TextFieldPetrolPrice";
        public static string TextFieldKerosenePrice = "TextFieldKerosenePrice";
        public static string TextFieldDieselOilPrice = "TextFieldDieselOilPrice";
        public static string TextFieldLowPressureSteamPrice = "TextFieldLowPressureSteamPrice";
        #endregion

        #region ptagsettings
        public static string TextFieldPTagSettingsName = "TextFieldPTagSettingsName";
        public static string TextFieldPTagSettingsCode = "TextFieldPTagSettingsCode";
        public static string TextFieldPTagSettingsMeterCode = "TextFieldPTagSettingsMeterCode";
        public static string TextFieldPTagSettingsChannel = "TextFieldPTagSettingsChannel";
        public static string TextFieldPTagSettingsComment = "TextFieldPTagSettingsComment";
        #endregion

        #region vtagsettings
        public static string TextFieldVTagSettingsName = "TextFieldVTagSettingsName";
        public static string TextFieldVTagSettingsCode = "TextFieldVTagSettingsCode";
        public static string TextFieldVTagSettingsComment = "TextFieldVTagSettingsComment";
        public static string VFormulaField = "VFormulaField";
        #endregion

        #region kpitagsettings
        public static string TextFieldKPITagSettingsName = "TextFieldKPITagSettingsName";
        public static string TextFieldKPITagSettingsCode = "TextFieldKPITagSettingsCode";
        public static string TextFieldKPITagSettingsComment = "TextFieldKPITagSettingsComment";
        public static string KPIFormulaField = "KPIFormulaField";
        public static string TextFieldKPITargetBaselineWorkdayRuleValue = "TextFieldKPITargetBaselineWorkdayRuleValue";
        public static string TextFieldKPITargetBaselineNonworkdayRuleValue = "TextFieldKPITargetBaselineNonworkdayRuleValue";
        public static string TextFieldKPITargetBaselineSpecialdayRuleValue = "TextFieldKPITargetBaselineSpecialdayRuleValue";
        public static string TextFieldKPITargetBaselineAnnualCalculationValue = "TextFieldKPITargetBaselineAnnualCalculationValue";
        public static string TextFieldKPITargetBaselineJanuaryCalculationValue = "TextFieldKPITargetBaselineJanuaryCalculationValue";
        public static string TextFieldKPITargetBaselineFebruaryCalculationValue = "TextFieldKPITargetBaselineFebruaryCalculationValue";
        public static string TextFieldKPITargetBaselineMarchCalculationValue = "TextFieldKPITargetBaselineMarchCalculationValue";
        public static string TextFieldKPITargetBaselineAprilCalculationValue = "TextFieldKPITargetBaselineAprilCalculationValue";
        public static string TextFieldKPITargetBaselineMayCalculationValue = "TextFieldKPITargetBaselineMayCalculationValue";
        public static string TextFieldKPITargetBaselineJuneCalculationValue = "TextFieldKPITargetBaselineJuneCalculationValue";
        public static string TextFieldKPITargetBaselineJulyCalculationValue = "TextFieldKPITargetBaselineJulyCalculationValue";
        public static string TextFieldKPITargetBaselineAugustCalculationValue = "TextFieldKPITargetBaselineAugustCalculationValue";
        public static string TextFieldKPITargetBaselineSeptemberCalculationValue = "TextFieldKPITargetBaselineSeptemberCalculationValue";
        public static string TextFieldKPITargetBaselineOctoberCalculationValue = "TextFieldKPITargetBaselineOctoberCalculationValue";
        public static string TextFieldKPITargetBaselineNovemberCalculationValue = "TextFieldKPITargetBaselineNovemberCalculationValue";
        public static string TextFieldKPITargetBaselineDecemberCalculationValue = "TextFieldKPITargetBaselineDecemberCalculationValue";
        #endregion

        #region areadimensionsettings
        public static string TextFieldAreaDimensionSettingsName = "TextFieldAreaDimensionSettingsName";
        public static string TextFieldAreaDimensionSettingsComment = "TextFieldAreaDimensionSettingsComment";
        #endregion

        #endregion

        #region platformsettings
        #region workday
        public static string TextFieldWorkdayCalendarName = "TextFieldWorkdayCalendarName";
        #endregion

        #region worktime
        public static string TextFieldWorktimeCalendarName = "TextFieldWorktimeCalendarName";
        #endregion

        #region heatingcoolingseason
        public static string TextFieldHeatingCoolingSeasonCalendarName = "TextFieldHeatingCoolingSeasonCalendarName";
        #endregion

        #region daynight
        public static string TextFieldDayNightCalendarName = "TextFieldDayNightCalendarName";
        #endregion

        #region carbonfactor
        public static string TextFieldCarbonFactorValue = "TextFieldCarbonFactorValue";
        #endregion

        #region TOU
        public static string TextFieldTOUBasicPropertyName = "TextFieldTOUBasicPropertyName";
        public static string TextFieldTOUBasicPropertyPlainPriceValue = "TextFieldTOUBasicPropertyPlainPriceValue";
        public static string TextFieldTOUBasicPropertyPeakPriceValue = "TextFieldTOUBasicPropertyPeakPriceValue";
        public static string TextFieldTOUBasicPropertyValleyPriceValue = "TextFieldTOUBasicPropertyValleyPriceValue";
        public static string TextFieldTOUPulsePeakPropertyPriceValue = "TextFieldTOUPulsePeakPropertyPriceValue";
        #endregion

        #region customersetting
        public static string TextFieldCustomerName = "TextFieldCustomerName";
        public static string TextFieldCustomerCode = "TextFieldCustomerCode";
        public static string TextFieldCustomerAddress = "TextFieldCustomerAddress";
        public static string TextFieldCustomerManager = "TextFieldCustomerManager";
        public static string TextFieldCustomerTelephone = "TextFieldCustomerTelephone";
        public static string TextFieldCustomerEmail = "TextFieldCustomerEmail";
        public static string TextFieldCustomerComment = "TextFieldCustomerComment";
        public static string TextFieldUploadLogo = "TextFieldUploadLogo";
        #endregion
        #region FunctionRoleType
        public static string TextFieldFunctionRoleTypeName = "TextFieldFunctionRoleTypeName";
        #endregion

        #endregion

        #endregion

        #region ComboBox
        #region login
        public static string ComboBoxLoginCustomerOption = "ComboBoxLoginCustomerOption";
        #endregion

        #region User
        public static string ComboBoxUserType = "ComboBoxUserType";
        public static string ComboBoxUserAssociatedCustomer = "ComboBoxUserAssociatedCustomer";

        public static string ComboxBoxUserTitle = "ComboxBoxUserTitle";
        #endregion

        #region UserProfile
        public static string ComboBoxUserProfileType = "ComboBoxUserProfileType";
        public static string ComboBoxUserProfileAssociatedCustomer = "ComboBoxUserProfileAssociatedCustomer";
        #endregion

        #region energyview
        public static string ComboBoxEnergyViewStartTime = "ComboBoxEnergyViewStartTime";
        public static string ComboBoxEnergyViewEndTime = "ComboBoxEnergyViewEndTime";
        public static string ComboBoxEnergyViewSaveDashboardHierarchy = "ComboBoxEnergyViewSaveDashboardHierarchy";
        public static string ComboBoxEnergyViewSaveDashboardDashboard = "ComboBoxEnergyViewSaveDashboardDashboard";
        public static string ComboBoxIntervalDialogBaseStartTime = "ComboBoxIntervalDialogBaseStartTime";
        public static string ComboBoxIntervalDialogBaseEndTime = "ComboBoxIntervalDialogBaseEndTime";
        public static string ComboBoxIntervalDialogAdditionStartTime = "ComboBoxIntervalDialogAdditionStartTime";
        public static string ComboBoxWidgetMaxDialogDefaultTime = "ComboBoxWidgetMaxDialogDefaultTime";
        #endregion

        #region customersettings
        #region hierarchy
        public static string ComboBoxHierarchySettingsHierarchyType = "ComboBoxHierarchySettingsHierarchyType";
        #endregion

        #region hierarchyCalendarproperty
        public static string ComboBoxWorkdayEffectiveYear = "ComboBoxWorkdayEffectiveYear";
        public static string ComboBoxWorkdayCalendarName = "ComboBoxWorkdayCalendarName";
        public static string ComboBoxWorktimeCalendarName = "ComboBoxWorktimeCalendarName";
        public static string ComboBoxHeatingCoolingEffectiveYear = "ComboBoxHeatingCoolingEffectiveYear";
        public static string ComboBoxHeatingCoolingCalendarName = "ComboBoxHeatingCoolingCalendarName";
        public static string ComboBoxDayNightEffectiveYear = "ComboBoxDayNightEffectiveYear";
        public static string ComboBoxDayNightCalendarName = "ComboBoxDayNightCalendarName";
        #endregion

        #region hierarchyCostproperty
        public static string ComboBoxElectricPriceMode = "ComboBoxElectricPriceMode";
        public static string ComboBoxDemandCostType = "ComboBoxDemandCostType";
        public static string ComboBoxTouTariffId = "ComboBoxTouTariffId";
        public static string ComboBoxFactorType = "ComboBoxFactorType";
        public static string ComboBoxRealTagId = "ComboBoxRealTagId";
        public static string ComboBoxReactiveTagId = "ComboBoxReactiveTagId";
        public static string ComboBoxHourTagId = "ComboBoxHourTagId";
        #endregion

        #region ptag
        public static string ComboBoxPTagSettingsCommodity = "ComboBoxPTagSettingsCommodity";
        public static string ComboBoxPTagSettingsUom = "ComboBoxPTagSettingsUom";
        public static string ComboBoxPTagSettingsCalculationType = "ComboBoxPTagSettingsCalculationType";
        #endregion

        #region vtag
        public static string ComboBoxVTagSettingsCommodity = "ComboBoxVTagSettingsCommodity";
        public static string ComboBoxVTagSettingsUom = "ComboBoxVTagSettingsUom";
        public static string ComboBoxVTagSettingsCalculationType = "ComboBoxVTagSettingsCalculationType";
        public static string ComboBoxVTagSettingsCalculationStep = "ComboBoxVTagSettingsCalculationStep";
        #endregion

        #region kpitag
        public static string ComboBoxKPITagSettingsUom = "ComboBoxKPITagSettingsUom";
        public static string ComboBoxKPITagSettingsCalculationType = "ComboBoxKPITagSettingsCalculationType";
        public static string ComboBoxKPITagSettingsCalculationStep = "ComboBoxKPITagSettingsCalculationStep";
        public static string ComboBoxKPITargetBaselineEffectiveYear = "ComboBoxKPITargetBaselineEffectiveYear";
        public static string ComboBoxKPITargetBaselineWorkdayRuleEndTime = "ComboBoxKPITargetBaselineWorkdayRuleEndTime";
        public static string ComboBoxKPITargetBaselineNonworkdayRuleEndTime = "ComboBoxKPITargetBaselineNonworkdayRuleEndTime";
        public static string ComboBoxKPITargetBaselineSpecialdayRuleStartTime = "ComboBoxKPITargetBaselineSpecialdayRuleStartTime";
        public static string ComboBoxKPITargetBaselineSpecialdayRuleEndTime = "ComboBoxKPITargetBaselineSpecialdayRuleEndTime";
        #endregion

        #endregion

        #region platformsettings
        #region workday
        public static string ComboBoxWorkdayCalendarSpecialDateType = "ComboBoxWorkdayCalendarSpecialDateType";
        public static string ComboBoxWorkdayCalendarStartMonth = "ComboBoxWorkdayCalendarStartMonth";
        public static string ComboBoxWorkdayCalendarStartDate = "ComboBoxWorkdayCalendarStartDate";
        public static string ComboBoxWorkdayCalendarEndMonth = "ComboBoxWorkdayCalendarEndMonth";
        public static string ComboBoxWorkdayCalendarEndDate = "ComboBoxWorkdayCalendarEndDate";
        #endregion

        #region worktime
        public static string ComboBoxWorktimeCalendarStartTime = "ComboBoxWorktimeCalendarStartTime";
        public static string ComboBoxWorktimeCalendarEndTime = "ComboBoxWorktimeCalendarEndTime";
        #endregion

        #region HeatingCoolingSeason
        public static string ComboBoxHeatingCoolingSeasonCalendarWarmStartMonth = "ComboBoxHeatingCoolingSeasonCalendarWarmStartMonth";
        public static string ComboBoxHeatingCoolingSeasonCalendarWarmStartDate = "ComboBoxHeatingCoolingSeasonCalendarWarmStartDate";
        public static string ComboBoxHeatingCoolingSeasonCalendarWarmEndMonth = "ComboBoxHeatingCoolingSeasonCalendarWarmEndMonth";
        public static string ComboBoxHeatingCoolingSeasonCalendarWarmEndDate = "ComboBoxHeatingCoolingSeasonCalendarWarmEndDate";
        public static string ComboBoxHeatingCoolingSeasonCalendarColdStartMonth = "ComboBoxHeatingCoolingSeasonCalendarColdStartMonth";
        public static string ComboBoxHeatingCoolingSeasonCalendarColdStartDate = "ComboBoxHeatingCoolingSeasonCalendarColdStartDate";
        public static string ComboBoxHeatingCoolingSeasonCalendarColdEndMonth = "ComboBoxHeatingCoolingSeasonCalendarColdEndMonth";
        public static string ComboBoxHeatingCoolingSeasonCalendarColdEndDate = "ComboBoxHeatingCoolingSeasonCalendarColdEndDate";
        #endregion

        #region daynight
        public static string ComboBoxDayNightCalendarStartTime = "ComboBoxDayNightCalendarStartTime";
        public static string ComboBoxDayNightCalendarEndTime = "ComboBoxDayNightCalendarEndTime";
        #endregion

        #region carbonfactor
        public static string ComboBoxCarbonFactorSource = "ComboBoxCarbonFactorSource";
        public static string ComboBoxCarbonFactorDestination = "ComboBoxCarbonFactorDestination";
        public static string ComboBoxCarbonFactorEffectiveYear = "ComboBoxCarbonFactorEffectiveYear";
        #endregion

        #region TOU
        public static string ComboBoxTOUBasicPropertyPeakStartTime = "ComboBoxTOUBasicPropertyPeakStartTime";
        public static string ComboBoxTOUBasicPropertyPeakEndTime = "ComboBoxTOUBasicPropertyPeakEndTime";
        public static string ComboBoxTOUBasicPropertyValleyStartTime = "ComboBoxTOUBasicPropertyValleyStartTime";
        public static string ComboBoxTOUBasicPropertyValleyEndTime = "ComboBoxTOUBasicPropertyValleyEndTime";
        public static string ComboBoxTOUPulsePeakPropertyStartMonth = "ComboBoxTOUPulsePeakPropertyStartMonth";
        public static string ComboBoxTOUPulsePeakPropertyStartDate = "ComboBoxTOUPulsePeakPropertyStartDate";
        public static string ComboBoxTOUPulsePeakPropertyEndMonth = "ComboBoxTOUPulsePeakPropertyEndMonth";
        public static string ComboBoxTOUPulsePeakPropertyEndDate = "ComboBoxTOUPulsePeakPropertyEndDate";
        public static string ComboBoxTOUPulsePeakPropertyStartTime = "ComboBoxTOUPulsePeakPropertyStartTime";
        public static string ComboBoxTOUPulsePeakPropertyEndTime = "ComboBoxTOUPulsePeakPropertyEndTime";
        #endregion

        #endregion

        #region HomePage

        public static string ComboBoxWidgetMaxDialogStartTime = "ComboBoxWidgetMaxDialogStartTime";
        public static string ComboBoxWidgetMaxDialogEndTime = "ComboBoxWidgetMaxDialogEndTime";

        #endregion

        #endregion

        #region TreeView
        public static string HierarchyTreeEnergyView = "HierarchyTreeEnergyView";
        public static string HierarchyTreeHierarchySettings = "HierarchyTreeHierarchySettings";
        public static string HierarchyTreeHierarchySettingsDimension = "HierarchyTreeHierarchySettingsDimension";
        public static string HierarchyTreeAssociation = "HierarchyTreeAssociation";
        public static string HierarchyTreeAssociationDimension = "HierarchyTreeAssociationDimension";
        public static string SystemDimensionTreeEnergyView = "SystemDimensionTreeEnergyView";
        public static string SystemDimensionTreeHierarchySettings = "SystemDimensionTreeHierarchySettings";
        public static string SystemDimensionTreeHierarchySettingsDialog = "SystemDimensionTreeHierarchySettingsDialog";
        public static string SystemDimensionTreeAssociation = "SystemDimensionTreeAssociation";
        public static string AreaDimensionTreeEnergyView = "AreaDimensionTreeEnergyView";
        public static string AreaDimensionTreeHierarchySettings = "AreaDimensionTreeHierarchySettings";
        public static string AreaDimensionTreeAssociation = "AreaDimensionTreeAssociation";
        public static string HierarchyTreeRank = "HierarchyTreeRank";
        public static string WidgetSaveHierarchyTree = "WidgetSaveHierarchyTree";

        public static string DataPermissionHierarchyTree = "DataPermissionHierarchyTree";

        public static string AllDashboardsTree = "AllDashboardsTree";
        public static string MultipleHierarchyTree = "MultipleHierarchyTree";
        public static string MultipleSystemDimensionTree = "MultipleSystemDimensionTree";
        public static string MultipleAreaDimensionTree = "MultipleAreaDimensionTree";
        #endregion

        #region Grid

        #region energyview

        #region common

        public static string GridMultiHierarchyAllTagList = "GridMultiHierarchyAllTagList";
        public static string GridMultiHierarchySystemDimensionTagList = "GridMultiHierarchySystemDimensionTagList";
        public static string GridMultiHierarchyAreaDimensionTagList = "GridMultiHierarchyAreaDimensionTagList";
        public static string GridMultiSelectedTagsList = "GridMultiSelectedTagsList";

        #endregion

        #region energy analysis

        public static string GridEnergyAnalysisAllTagList = "GridEnergyAnalysisAllTagList";
        public static string GridEnergyAnalysisSystemDimensionTagList = "GridEnergyAnalysisSystemDimensionTagList";
        public static string GridEnergyAnalysisAreaDimensionTagList = "GridEnergyAnalysisAreaDimensionTagList";
        public static string GridEnergyAnalysisEnergyDataList = "GridEnergyAnalysisEnergyDataList";
        public static string GridEASelectedTagsList = "GridEASelectedTagsList";

        #endregion

        #region unit KPI

        public static string GridUnitKPIAllTagList = "GridUnitKPIAllTagList";
        public static string GridTotalCommodityUnitCarbon = "GridTotalCommodityUnitCarbon";
        public static string GridTotalCommodityUnitCost = "GridTotalCommodityUnitCost";
        public static string GridCommodityUnitCarbon = "GridCommodityUnitCarbon";
        public static string GridCommodityUnitCost = "GridCommodityUnitCost";
        public static string GridTotalCommodityCarbon = "GridTotalCommodityCarbon";
        public static string GridTotalCommodityCost = "GridTotalCommodityCost";
        public static string GridCommodityCarbon = "GridCommodityCarbon";
        public static string GridCommodityCost = "GridCommodityCost";
        public static string GridUnitKPIEnergyDataList = "GridUnitKPIEnergyDataList";
        #endregion

        #region radio

        public static string GridRadioAllTagList = "GridRadioAllTagList";

        #endregion

        #region rank

        public static string GridCommodityRank = "GridCommodityRank";
        public static string GridCommodityRankCarbon = "GridCommodityRankCarbon";
        public static string GridCommodityRankCost = "GridCommodityRankCost";

        #endregion

        #region cost

        public static string GridTotalOtherCommodityCost = "GridTotalOtherCommodityCost";
        public static string GridOtherCommodityCost = "GridOtherCommodityCost";

        #endregion

        #endregion

        #region customersettings
        public static string GridVTagSettingsFormulaEditPTagList = "GridVTagSettingsFormulaEditPTagList";
        public static string GridVTagSettingsVTagList = "GridVTagSettingsVTagList";
        public static string GridKPITagSettingsFormulaEditPTagList = "GridKPITagSettingsFormulaEditPTagList";
        public static string GridKPITagSettingsKPITagList = "GridKPITagSettingsKPITagList";
        public static string GridAssociationTagList = "GridAssociationTagList";
        public static string GridPTagSettingsPTagList = "GridPTagSettingsPTagList";
        #endregion

        #region platformsettings
        public static string GridUserList = "GridUserList";
        public static string GridUserTypePermissionList = "GridUserTypePermissionList";
        public static string GridCalendarsList = "GridCalendarsList";
        public static string GridTOUTariffsList = "GridTOUTariffsList";
        public static string GridDataScopePermissionList = "GridDataScopePermissionList";
        public static string GridCustomersList = "GridCustomersList";

        public static string GridRowDataCustomerTextRow = "GridDataScopePermissionCustomerList";
        #endregion

        #region home page

        public static string GridHomepageMinWidgetDataView = "GridHomepageMinWidgetDataView";

        #endregion

        #endregion

        #region DatePicker

        #region EnergyUsage
        public static string DatePickerEnergyUsageStartDate = "DatePickerEnergyUsageStartDate";
        public static string DatePickerEnergyUsageEndDate = "DatePickerEnergyUsageEndDate";

        public static string DatePickerUnitKPIStartDate = "DatePickerUnitKPIStartDate";
        public static string DatePickerUnitKPIEndDate = "DatePickerUnitKPIEndDate";

        public static string DatePickerIntervalDialogBaseStartDate = "DatePickerIntervalDialogBaseStartDate";
        public static string DatePickerIntervalDialogBaseEndDate = "DatePickerIntervalDialogBaseEndDate";
        public static string DatePickerIntervalDialogAdditionStartDate = "DatePickerIntervalDialogAdditionStartDate";

        public static string DatePickerWidgetMaxDialogStartDate = "DatePickerWidgetMaxDialogStartDate";
        public static string DatePickerWidgetMaxDialogEndDate = "DatePickerWidgetMaxDialogEndDate";

        #endregion

        #region CustomerSettings
        #region kpitag
        public static string DatePickerKPITargetBaselineSpecialdayRuleStartDate = "DatePickerKPITargetBaselineSpecialdayRuleStartDate";
        public static string DatePickerKPITargetBaselineSpecialdayRuleEndDate = "DatePickerKPITargetBaselineSpecialdayRuleEndDate";
        #endregion

        #endregion

        #region PlatformSettings
        #region customermanagement
        public static string DatePickerOperationTime = "DatePickerOperationTime";
        #endregion

        #endregion

        #endregion

        #region MonthPicker
        #region hierarchyproperty
        public static string MonthPickerPeopleEffectiveDate = "MonthPickerPeopleEffectiveDate";
        public static string MonthPickerElectricCostEffectiveDate = "MonthPickerElectricCostEffectiveDate";
        public static string MonthPickerWaterCostEffectiveDate = "MonthPickerWaterCostEffectiveDate";
        public static string MonthPickerGasCostEffectiveDate = "MonthPickerGasCostEffectiveDate";
        public static string MonthPickerHeatQCostEffectiveDate = "MonthPickerHeatQCostEffectiveDate";
        public static string MonthPickerCoolQCostEffectiveDate = "MonthPickerCoolQCostEffectiveDate";
        public static string MonthPickerLightWaterCostEffectiveDate = "MonthPickerLightWaterCostEffectiveDate";
        public static string MonthPickerCoalCostEffectiveDate = "MonthPickerCoalCostEffectiveDate";
        public static string MonthPickerPetrolCostEffectiveDate = "MonthPickerPetrolCostEffectiveDate";
        public static string MonthPickerKeroseneCostEffectiveDate = "MonthPickerKeroseneCostEffectiveDate";
        public static string MonthPickerDieselOilCostEffectiveDate = "MonthPickerDieselOilCostEffectiveDate";
        public static string MonthPickerLowPressureSteamCostEffectiveDate = "MonthPickerLowPressureSteamCostEffectiveDate";
        #endregion

        #endregion

        #region CheckBoxField
        public static string CheckBoxFieldDayNightKPITag = "CheckBoxFieldDayNightKPITag";
        public static string CheckBoxFieldUserTypeEnergyUse = "CheckBoxFieldUserTypeEnergyUse";
        public static string CheckBoxFieldUserTypeCost = "CheckBoxFieldUserTypeCost";

        public static string CheckBoxFieldUserTypePermission = "CheckBoxFieldUserTypePermission";

        public static string ButtonUserSelectAllDataPermission = "ButtonUserSelectAllDataPermission";
        public static string ButtonCustomerNames = "ButtonCustomerNames";
        public static string MenuButtonSelectCustomer = "MenuButtonSelectCustomer";

        public static string CheckBoxFieldUserAllHierarchyNode = "CheckBoxFieldUserDataAllHierarchyNode";
        public static string CheckBoxFieldUserAllDataScope = "CheckBoxFieldUserAllDataScope";
        
        #endregion

        #region Label
        #region CustomerSettings

        #region HierarchyCalendar
        public static string LabelWorkdayCalendar = "LabelWorkdayCalendar";
        public static string LabelWorktimeCalendar = "LabelWorktimeCalendar";
        public static string LabelHeatingCoolingCalendar = "LabelHeatingCoolingCalendar";
        public static string LabelDayNightCalendar = "LabelDayNightCalendar";

        public static string LabelTitleWorkday = "LabelTitleWorkday";
        public static string LabelTitleHeatingCooling = "LabelTitleHeatingCooling";
        public static string LabelTitleDayNight = "LabelTitleDayNight";
        #endregion

        #region HierarchyPopulationArea

        public static string LabelAreaPropertyTitle = "LabelAreaPropertyTitle";

        #endregion

        #region TargetBaseline
        public static string LabelCalendarInfoDisplay = "LabelCalendarInfoDisplay";
        #endregion

        #endregion

        #region PlatformSettings
        #region calendar
        public static string LabelPlatformWorkdayCalendar = "LabelPlatformWorkdayCalendar";
        public static string LabelPlatformWorktimeCalendar = "LabelPlatformWorktimeCalendar";
        public static string LabelPlatformDayNightCalendar = "LabelPlatformDayNightCalendar";
        #endregion

        #endregion

        #region Homepage

        public static string LabelDashboardHeaderName = "LabelDashboardHeaderName";
        public static string LabelWidgetNameMin = "LabelWidgetNameMin";
        
        #endregion

        #region Energy View

        public static string LabelAdditionEndTime = "LabelAdditionEndTime";

        #endregion

        #endregion

        #region Chart
        public static string ChartEnergyView = "ChartEnergyView";
        #endregion

        #region Window
        #region Login
        public static string WindowLoginOption = "WindowLoginOption";
        #endregion

        #region Hierarchy cost property
        public static string WindowFactor = "WindowFactor";
        #endregion

        #region TargetBaseline

        public static string WindowTBCalendarInfo = "WindowTBCalendarInfo";

        #endregion

        #region Energy view

        public static string WindowMessageInfos = "WindowMessageInfos";

        #endregion

        #endregion

        #region Container

        #region Hierarchy property settings
        public static string ContainerPeopleItems = "ContainerPeopleItems";
        public static string ContainerPeopleErrorTips = "ContainerPeopleErrorTips";
        public static string ContainerWorkdayErrorTips = "ContainerWorkdayErrorTips";
        public static string ContainerHCErrorTips = "ContainerHCErrorTips";
        public static string ContainerDayNightErrorTips = "ContainerDayNightErrorTips";
        #endregion

        #region Hierarchy Cost Property
        public static string ContainerWaterCostValueItems = "ContainerWaterCostValueItems";
        public static string ContainerElectricCostValueItems = "ContainerElectricCostValueItems";
        
        #endregion

        #region Associate
        public static string ContainerAssociatedTags = "ContainerAssociatedTags";
        
        #endregion

        #region TargetBaseline

        public static string ContainerTBCalendarInfo = "ContainerTBCalendarInfo";
        public static string ContainerTBWorkdayRule = "ContainerTBWorkdayRule";
        public static string ContainerTBNonworkdayRule = "ContainerTBNonworkdayRule";
        public static string ContainerTBSpecialdayRule = "ContainerTBSpecialdayRule"; 

        #endregion
       
        #region HomePage

        public static string ContainerWidgetsToDashboard = "ContainerWidgetsToDashboard";

        #endregion

        #region EnergyView

        #region Energy Analysis

        public static string ContainerMultiHierarchyPanel = "ContainerMultiHierarchyPanel";
        public static string ContainerExcludeTimeIntervals = "ContainerExcludeTimeIntervals";

        #endregion

        #endregion

        #region Platform setting

        #region TimeManagment
        public static string ContainerCalendarItems = "ContainerCalendarItems";
        public static string ContainerCalendarWarmItems = "ContainerCalendarWarmItems";
        public static string ContainerCalendarColdItems = "ContainerCalendarColdItems";
        #endregion

        #region TOU
        public static string ContainerTOU24HoursErrorTips = "ContainerTOU24HoursErrorTips";
        #endregion
        
        #region UserRoleType
        public static string ContainerPermissionCustomerizeItems = "ContainerPermissionCustomerizeItems";
        public static string ContainerPermissionPublicTypeItems = "ContainerPermissionPublicTypeItems";
        #endregion

        #region User
        public static string ContainerDisplayPermissionCustomerizeItems = "ContainerDisplayPermissionCustomerizeItems";
        public static string ContainerDisplayPermissionPublicTypeItems = "ContainerDisplayPermissionPublicTypeItems";
        public static string ContainerDisplayPermissionItems = "ContainerDisplayPermissionItems";
        #endregion
        
        #endregion

        #endregion

    }
}
