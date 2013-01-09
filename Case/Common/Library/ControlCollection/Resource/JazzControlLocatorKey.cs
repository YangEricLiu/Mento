using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public static class JazzControlLocatorKey
    {
        #region Button
        #region Login
        public static string ButtonLoginSubmit = "ButtonLoginSubmit";
        #endregion

        #region EnergyView
        public static string ButtonSelectHierarchy = "ButtonSelectHierarchy";

        public static string TabButtonEnergyViewALLTagsTab = "TabButtonEnergyViewALLTagsTab";
        public static string TabButtonEnergyViewSystemDimensionTagsTab = "TabButtonEnergyViewSystemDimensionTagsTab";
        public static string TabButtonEnergyViewAreaDimensionTagsTab = "TabButtonEnergyViewAreaDimensionTagsTab";

        public static string SplitButtonEnergyViewViewData = "SplitButtonEnergyViewViewData";
        #endregion

        #region Navigator
        //Navigator buttons
        //level 1
        public static string ButtonNavigatorHomePage = "ButtonNavigatorHomePage";
        public static string ButtonNavigatorEnergyView = "ButtonNavigatorEnergyView";
        public static string ButtonNavigatorSettings = "ButtonNavigatorSettings";
        public static string ButtonNavigatorPlatformSettings = "ButtonNavigatorPlatformSettings";

        //level 2

        public static string ButtonNavigatorEnergyAnalysis = "ButtonNavigatorEnergyAnalysis";
        public static string ButtonNavigatorCarbonUsage = "ButtonNavigatorCarbonUsage";
        public static string ButtonNavigatorCost = "ButtonNavigatorCost";
        public static string ButtonNavigatorKPI = "ButtonNavigatorKPI";
        public static string ButtonNavigatorTimeSettings = "ButtonNavigatorTimeSettings";
        public static string ButtonNavigatorCarbonSettings = "ButtonNavigatorCarbonSettings";
        public static string ButtonNavigatorPriceSettings = "ButtonNavigatorPriceSettings";
        public static string ButtonNavigatorCustomerManagement = "ButtonNavigatorCustomerManagement";
        public static string ButtonNavigatorUserManagement = "ButtonNavigatorUserManagement";
        public static string ButtonNavigatorTagSettings = "ButtonNavigatorTagSettings";
        public static string ButtonNavigatorHierarchySettings = "ButtonNavigatorHierarchySettings";
        public static string ButtonNavigatorAssociationSettings = "ButtonNavigatorAssociationSettings";

        //level 3
        //--Time
        public static string ButtonNavigatorTimeSettingsWorkday = "ButtonNavigatorTimeSettingsWorkday";
        public static string ButtonNavigatorTimeSettingsWorktime = "ButtonNavigatorTimeSettingsWorktime";
        public static string ButtonNavigatorTimeSettingsSeason = "ButtonNavigatorTimeSettingsSeason";
        public static string ButtonNavigatorTimeSettingsDaynight = "ButtonNavigatorTimeSettingsDaynight";
        //--Carbon
        public static string ButtonNavigatorCarbonSettingsCarbon = "ButtonNavigatorCarbonSettingsCarbon";
        //--Price
        public static string ButtonNavigatorPriceSettingsPrice = "ButtonNavigatorPriceSettingsPrice";
        //--Customer
        public static string ButtonNavigatorCustomerManagementCustomer = "ButtonNavigatorCustomerManagementCustomer";
        //--User
        public static string ButtonNavigatorUserManagementUser = "ButtonNavigatorUserManagementUser";
        public static string ButtonNavigatorUserManagementUserTypePermission = "ButtonNavigatorUserManagementUserTypePermission";
        //--Tag
        public static string ButtonNavigatorTagSettingsP = "ButtonNavigatorTagSettingsP";
        public static string ButtonNavigatorTagSettingsV = "ButtonNavigatorTagSettingsV";
        public static string ButtonNavigatorTagSettingsKPI = "ButtonNavigatorTagSettingsKPI";
        //--Hierarchy
        public static string ButtonNavigatorHierarchySettingsHierarchy = "ButtonNavigatorHierarchySettingsHierarchy";
        public static string ButtonNavigatorHierarchySettingsSystemDimension = "ButtonNavigatorHierarchySettingsSystemDimension";
        public static string ButtonNavigatorHierarchySettingsAreaDimension = "ButtonNavigatorHierarchySettingsAreaDimension";
        //--Association
        public static string ButtonNavigatorAssociationHierarchy = "ButtonNavigatorAssociationHierarchy";
        public static string ButtonNavigatorAssociationSystemDimension = "ButtonNavigatorAssociationSystemDimension";
        public static string ButtonNavigatorAssociationAreaDimension = "ButtonNavigatorAssociationAreaDimensionButton";
        #endregion

        #region Custormer settings
        #region PTag settings
        public static string ButtonPTagSettingsCreatePTag = "ButtonPTagSettingsCreatePTag";
        public static string ButtonPTagSettingsModify = "ButtonPTagSettingsModify";
        public static string ButtonPTagSettingsSave = "ButtonPTagSettingsSave";
        public static string ButtonPTagSettingsCancel = "ButtonPTagSettingsCancel";
        public static string ButtonPTagSettingsDelete = "ButtonPTagSettingsDelete";
        #endregion

        #region VTag settings
        public static string TabButtonVTagSettingsBasicProperty = "TabButtonVTagSettingsBasicProperty";
        public static string TabButtonVTagSettingsFormula = "TabButtonVTagSettingsFormula";

        public static string ButtonVTagSettingsFormulaUpdate = "ButtonVTagSettingsFormulaUpdate";
        public static string ButtonVTagSettingsFormulaSave = "ButtonVTagSettingsFormulaSave";

        public static string ButtonVTagSettingsCreateVTag = "ButtonVTagSettingsCreateVTag";

        public static string ButtonVTagSettingsModify = "ButtonVTagSettingsModify";
        public static string ButtonVTagSettingsSave = "ButtonVTagSettingsSave";
        public static string ButtonVTagSettingsCancel = "ButtonVTagSettingsCancel";
        public static string ButtonVTagSettingsDelete = "ButtonVTagSettingsDelete";
        #endregion

        #region KPI settings
        public static string TabButtonKPITagSettingsBasicProperty = "TabButtonKPITagSettingsBasicProperty";
        public static string TabButtonKPITagSettingsFormula = "TabButtonKPITagSettingsFormula";

        public static string ButtonKPITagSettingsFormulaUpdate = "ButtonKPITagSettingsFormulaUpdate";
        public static string ButtonKPITagSettingsFormulaSave = "ButtonKPITagSettingsFormulaSave";

        public static string ButtonKPITagSettingsCreateKPITag = "ButtonKPITagSettingsCreateKPITag";

        public static string ButtonKPITagSettingsModify = "ButtonKPITagSettingsModify";
        public static string ButtonKPITagSettingsSave = "ButtonKPITagSettingsSave";
        public static string ButtonKPITagSettingsCancel = "ButtonKPITagSettingsCancel";
        public static string ButtonKPITagSettingsDelete = "ButtonKPITagSettingsDelete";
        #endregion

        #region Hierarchy settings
        public static string ButtonHierarchySettingsCreateChildHierarchy = "ButtonHierarchySettingsCreateChildHierarchy";
        public static string ButtonHierarchySettingsModify = "ButtonHierarchySettingsModify";
        public static string ButtonHierarchySettingsSave = "ButtonHierarchySettingsSave";
        public static string ButtonHierarchySettingsCancel = "ButtonHierarchySettingsCancel";
        public static string ButtonHierarchySettingsDelete = "ButtonHierarchySettingsDelete";

        #region Hierarchy property settings buttons
        public static string TabButtonCalendarProperty = "TabButtonCalendarProperty";
        public static string ButtonCalendarCreate = "ButtonCalendarCreate";
        public static string ButtonCalendarSave = "ButtonCalendarSave";
        public static string ButtonCalendarCancel = "ButtonCalendarCancel";
        public static string ButtonWorkdayCreate = "ButtonWorkdayCreate";
        public static string ButtonHeatingCoolingCreate = "ButtonHeatingCoolingCreate";
        public static string ButtonDayNightCreate = "ButtonDayNightCreate";
        public static string LinkButtonWorktimeCreate = "LinkButtonWorktimeCreate";

        public static string TabButtonPeopleAreaProperty = "TabButtonPeopleAreaProperty";
        public static string ButtonPeopleAreaCreate = "ButtonPeopleAreaCreate";
        public static string ButtonPeopleAreaSave = "ButtonPeopleAreaSave";
        public static string ButtonPeopleAreaCancel = "ButtonPeopleAreaCancel";
        public static string ButtonPeopleCreate = "ButtonPeopleCreate";
        #endregion

        #endregion

        #region System dimension settings
        public static string ButtonDimensionShowHierarchyTree = "ButtonDimensionShowHierarchyTree";

        public static string ButtonSystemDimensionSet = "ButtonSystemDimensionSet";
        public static string ButtonSystemDimensionSettingsDialogReturn = "ButtonSystemDimensionSettingsDialogReturn";
        #endregion

        #region Area dimension settings
        public static string ButtonAreaDimensionSettingsCreate = "ButtonAreaDimensionSettingsCreate";
        public static string ButtonAreaDimensionSettingsSave = "ButtonAreaDimensionSettingsSave";
        public static string ButtonAreaDimensionSettingsCancel = "ButtonAreaDimensionSettingsCancel";
        public static string ButtonAreaDimensionSettingsModify = "ButtonAreaDimensionSettingsModify";
        public static string ButtonAreaDimensionSettingsDelete = "ButtonAreaDimensionSettingsDelete";
        #endregion

        #region Hierarchy association settings

        public static string ButtonAssociationSettingsTagAssociate = "ButtonAssociationSettingsTagAssociate";
        public static string ButtonAssociationSettingsAssociate = "ButtonAssociationSettingsAssociate";
        public static string ButtonAssociationSettingsDisassociate = "ButtonAssociationSettingsDisassociate";
        public static string ButtonAssociationSettingsCancel = "ButtonAssociationSettingsCancel";
        #endregion
        #endregion

        #region Platform settings
        #region workday
        public static string ButtonWorkdayCalendarCreate = "ButtonWorkdayCalendarCreate";
        public static string ButtonWorkdayCalendarModify = "ButtonWorkdayCalendarModify";
        public static string ButtonWorkdayCalendarSave = "ButtonWorkdayCalendarSave";
        public static string ButtonWorkdayCalendarCancel = "ButtonWorkdayCalendarCancel";
        public static string ButtonWorkdayCalendarDelete = "ButtonWorkdayCalendarDelete";
        public static string ButtonWorkdayCalendarAddSpecialDates = "ButtonWorkdayCalendarAddSpecialDates";
        #endregion
        #region worktime
        public static string ButtonWorktimeCalendarCreate = "ButtonWorktimeCalendarCreate";
        public static string ButtonWorktimeCalendarModify = "ButtonWorktimeCalendarModify";
        public static string ButtonWorktimeCalendarSave = "ButtonWorktimeCalendarSave";
        public static string ButtonWorktimeCalendarCancel = "ButtonWorktimeCalendarCancel";
        public static string ButtonWorktimeCalendarDelete = "ButtonWorktimeCalendarDelete";
        public static string ButtonWorktimeCalendarAddMoreRanges = "ButtonWorktimeCalendarAddMoreRanges";
        #endregion
        #region heatingcoolingseason
        public static string ButtonHeatingCoolingSeasonCalendarCreate = "ButtonHeatingCoolingSeasonCalendarCreate";
        public static string ButtonHeatingCoolingSeasonCalendarModify = "ButtonHeatingCoolingSeasonCalendarModify";
        public static string ButtonHeatingCoolingSeasonCalendarSave = "ButtonHeatingCoolingSeasonCalendarSave";
        public static string ButtonHeatingCoolingSeasonCalendarCancel = "ButtonHeatingCoolingSeasonCalendarCancel";
        public static string ButtonHeatingCoolingSeasonCalendarDelete = "ButtonHeatingCoolingSeasonCalendarDelete";
        public static string ButtonHeatingCoolingSeasonCalendarAddMoreWarmRanges = "ButtonHeatingCoolingSeasonCalendarAddMoreWarmRanges";
        public static string ButtonHeatingCoolingSeasonCalendarAddMoreColdRanges = "ButtonHeatingCoolingSeasonCalendarAddMoreColdRanges";
        #endregion
        #region daynight
        public static string ButtonDayNightCalendarCreate = "ButtonDayNightCalendarCreate";
        public static string ButtonDayNightCalendarModify = "ButtonDayNightCalendarModify";
        public static string ButtonDayNightCalendarSave = "ButtonDayNightCalendarSave";
        public static string ButtonDayNightCalendarCancel = "ButtonDayNightCalendarCancel";
        public static string ButtonDayNightCalendarDelete = "ButtonDayNightCalendarDelete";
        public static string ButtonDayNightCalendarAddMoreRanges = "ButtonDayNightCalendarAddMoreRanges";
        #endregion
        #endregion
        #endregion

        #region TextField
        #region Login
        public static string TextFieldLoginUserName = "TextFieldLoginUserName";
        public static string TextFieldLoginPassword = "TextFieldLoginPassword";
        #endregion

        #region Custormer settings
        #region Hierarchy settings
        public static string TextFieldHierarchySettingsName = "TextFieldHierarchySettingsName";
        public static string TextFieldHierarchySettingsCode = "TextFieldHierarchySettingsCode";
        public static string TextFieldHierarchySettingsComment = "TextFieldHierarchySettingsComment";
        

        #region Hierarchy peoperty settings
        public static string TextFieldTotalAreaValue = "TextFieldTotalAreaValue";
        public static string TextFieldHeatingAreaValue = "TextFieldHeatingAreaValue";
        public static string TextFieldCoolingAreaValue = "TextFieldCoolingAreaValue";
        public static string TextFieldPeopleNumber = "TextFieldPeopleNumber";
        #endregion
        #endregion

        #region PTag settings
        public static string TextFieldPTagSettingsName = "TextFieldPTagSettingsName";
        public static string TextFieldPTagSettingsCode = "TextFieldPTagSettingsCode";
        public static string TextFieldPTagSettingsMeterCode = "TextFieldPTagSettingsMeterCode";
        public static string TextFieldPTagSettingsChannel = "TextFieldPTagSettingsChannel";
        public static string TextFieldPTagSettingsComment = "TextFieldPTagSettingsComment";
        #endregion

        #region VTag settings
        public static string TextFieldVTagSettingsName = "TextFieldVTagSettingsName";
        public static string TextFieldVTagSettingsCode = "TextFieldVTagSettingsCode";
        public static string TextFieldVTagSettingsComment = "TextFieldVTagSettingsComment";
        public static string TextFieldVTagformula = "TextFieldVTagformula";
        #endregion

        #region KPITag settings
        public static string TextFieldKPITagSettingsName = "TextFieldKPITagSettingsName";
        public static string TextFieldKPITagSettingsCode = "TextFieldKPITagSettingsCode";
        public static string TextFieldKPITagSettingsComment = "TextFieldKPITagSettingsComment";
        public static string TextFieldKPIformula = "TextFieldKPIformula";
        #endregion

        #region Area dimension Settings
        public static string TextFieldAreaDimensionSettingsName = "TextFieldAreaDimensionSettingsName";
        public static string TextFieldAreaDimensionSettingsComment = "TextFieldAreaDimensionSettingsComment";
        #endregion
        #endregion

        #region Platform settings
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
        #endregion
        #endregion

        #region ComboBox
        #region Customer settings
        #region Hierarchy property settings
        public static string ComboBoxHierarchySettingsHierarchyType = "ComboBoxHierarchySettingsHierarchyType";

        public static string ComboBoxWorkdayEffectiveYear = "ComboBoxWorkdayEffectiveYear";
        public static string ComboBoxWorkdayCalendarName = "ComboBoxWorkdayCalendarName";

        public static string ComboBoxHeatingCoolingEffectiveYear = "ComboBoxHeatingCoolingEffectiveYear";
        public static string ComboBoxHeatingCoolingCalendarName = "ComboBoxHeatingCoolingCalendarName";

        public static string ComboBoxDayNightEffectiveYear = "ComboBoxDayNightEffectiveYear";
        public static string ComboBoxDayNightCalendarName = "ComboBoxDayNightCalendarName";
        #endregion

        #region PTag settings
        public static string ComboBoxPTagSettingsCommodity = "ComboBoxPTagSettingsCommodity";
        public static string ComboBoxPTagSettingsUom = "ComboBoxPTagSettingsUom";
        public static string ComboBoxPTagSettingsCalculationType = "ComboBoxPTagSettingsCalculationType";
        #endregion

        #region VTag settings
        public static string ComboBoxVTagSettingsCommodity = "ComboBoxVTagSettingsCommodity";
        public static string ComboBoxVTagSettingsUom = "ComboBoxVTagSettingsUom";
        public static string ComboBoxVTagSettingsCalculationType = "ComboBoxVTagSettingsCalculationType";
        public static string ComboBoxVTagSettingsCalculationStep = "ComboBoxVTagSettingsCalculationStep";
        #endregion

        #region KPITag settings
        public static string ComboBoxKPITagSettingsUom = "ComboBoxKPITagSettingsUom";
        public static string ComboBoxKPITagSettingsCalculationType = "ComboBoxKPITagSettingsCalculationType";
        public static string ComboBoxKPITagSettingsCalculationStep = "ComboBoxKPITagSettingsCalculationStep";
        #endregion
        #endregion

        #region Platform settings
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

        #region User Setting
        public static string ButtonUserCreate = "ButtonUserCreate";
        public static string ButtonUserRefresh = "ButtonUserRefresh";
        public static string ButtonUserSave = "ButtonUserSave";
        public static string ButtonUserCancel = "ButtonUserCancel";
        public static string ButtonUserDelete = "ButtonUserDelete";
        public static string ButtonUserModify = "ButtonUserModify";
        public static string LinkButtonUserAssociatedCustomer = "LinkButtonUserAssociatedCustomer";
        public static string ButtonUserGeneratePassword = "ButtonUserGeneratePassword";
        public static string TextFieldUserName = "TextFieldUserName";
        public static string TextFieldUserRealName = "TextFieldUserRealName";
        public static string TextFieldUserTelephone = "TextFieldUserTelephone";
        public static string TextFieldUserEmail = "TextFieldUserEmail";
        public static string TextFieldUserTitle = "TextFieldUserTitle";
        public static string TextFieldUserComment = "TextFieldUserComment";
        public static string ComboBoxUserType = "ComboBoxUserType";
        public static string ComboBoxUserAssociatedCustomer = "ComboBoxUserAssociatedCustomer";
        #endregion

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
        #endregion

        #region Grid
        #region EnergyView
        public static string GridEnergyAnalysisAllTagList = "GridEnergyAnalysisAllTagList";
        public static string GridEnergyAnalysisSystemDimensionTagList = "GridEnergyAnalysisSystemDimensionTagList";
        public static string GridEnergyAnalysisAreaDimensionTagList = "GridEnergyAnalysisAreaDimensionTagList";
        #endregion

        #region Customer settings
        public static string GridVTagSettingsFormulaEditPTagList = "GridVTagSettingsFormulaEditPTagList";
        public static string GridVTagSettingsVTagList = "GridVTagSettingsVTagList";
        public static string GridKPITagSettingsFormulaEditPTagList = "GridKPITagSettingsFormulaEditPTagList";
        public static string GridKPITagSettingsKPITagList = "GridKPITagSettingsKPITagList";
        public static string GridAssociationTagList = "GridAssociationTagList";
        public static string GridPTagSettingsPTagList = "GridPTagSettingsPTagList";
        public static string GridUserList = "GridUserList";
        #endregion
        #endregion
        #region CheckBoxField
        public static string CheckBoxFieldDayNightKPITag = "CheckBoxFieldDayNightKPITag";
       
        #endregion

        #region MonthPicker
        #region Hierarchy People Area property
        public static string MonthPickerPeopleEffectiveDate = "MonthPickerPeopleEffectiveDate";
        #endregion
        #endregion

        #region Label
        #region Hierarchy People Area property
        public static string LabelWorkdayCalendar = "LabelWorkdayCalendar";
        public static string LabelHeatingCoolingCalendar = "LabelHeatingCoolingCalendar";
        public static string LabelDayNightCalendar = "LabelDayNightCalendar";
        #endregion
        #endregion
    }
}
