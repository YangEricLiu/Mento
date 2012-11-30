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

        #region Navigator
        //Navigator buttons
        //level 1
        public static string ButtonNavigatorHomePage = "ButtonNavigatorHomePage";
        public static string ButtonNavigatorEnergyView = "ButtonNavigatorEnergyView";
        public static string ButtonNavigatorSettings = "ButtonNavigatorSettings";

        //level 2
        public static string ButtonNavigatorPlatformSettings = "ButtonNavigatorPlatformSettings";
        public static string ButtonNavigatorTagSettings = "ButtonNavigatorTagSettings";
        public static string ButtonNavigatorHierarchySettings = "ButtonNavigatorHierarchySettings";
        public static string ButtonNavigatorAssociationSettings = "ButtonNavigatorAssociationSettings";

        //level 3
        //--Platform
        public static string ButtonNavigatorPlatformWorkday = "ButtonNavigatorPlatformWorkday";
        public static string ButtonNavigatorPlatformWorktime = "ButtonNavigatorPlatformWorktime";
        public static string ButtonNavigatorPlatformSeason = "ButtonNavigatorPlatformSeason";
        public static string ButtonNavigatorPlatformDaynight = "ButtonNavigatorPlatformDaynight";
        public static string ButtonNavigatorPlatformCarbon = "ButtonNavigatorPlatformCarbon";
        public static string ButtonNavigatorPlatformPrice = "ButtonNavigatorPlatformPrice";
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

        public static string ButtonVTagSettingsCreateVTag="ButtonVTagSettingsCreateVTag";
        
        public static string ButtonVTagSettingsModify="ButtonVTagSettingsModify";
        public static string ButtonVTagSettingsSave="ButtonVTagSettingsSave";
        public static string ButtonVTagSettingsCancel="ButtonVTagSettingsCancel";
        public static string ButtonVTagSettingsDelete = "ButtonVTagSettingsDelete";
        #endregion

        #region Hierarchy settings
        public static string ButtonHierarchySettingsCreateChildHierarchy = "ButtonHierarchySettingsCreateChildHierarchy";
        public static string ButtonHierarchySettingsModify = "ButtonHierarchySettingsModify";
        public static string ButtonHierarchySettingsSave = "ButtonHierarchySettingsSave";
        public static string ButtonHierarchySettingsCancel = "ButtonHierarchySettingsCancel";
        public static string ButtonHierarchySettingsDelete = "ButtonHierarchySettingsDelete";
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
        #endregion

        #region VTag settings
        public static string TextFieldVTagSettingsName = "TextFieldVTagSettingsName";
        public static string TextFieldVTagSettingsCode = "TextFieldVTagSettingsCode";
        public static string TextFieldVTagSettingsComment = "TextFieldVTagSettingsComment";
        #endregion

        #region VTag settings
        public static string TextFieldPTagSettingsName = "TextFieldPTagSettingsName";
        public static string TextFieldPTagSettingsCode = "TextFieldPTagSettingsCode";
        public static string TextFieldPTagSettingsMeterCode = "TextFieldPTagSettingsMeterCode";
        public static string TextFieldPTagSettingsChannel = "TextFieldPTagSettingsChannel";
        public static string TextFieldPTagSettingsComment = "TextFieldPTagSettingsComment";
        #endregion

        #region Area dimension Settings
        public static string TextFieldAreaDimensionSettingsName = "TextFieldAreaDimensionSettingsName";
        public static string TextFieldAreaDimensionSettingsComment = "TextFieldAreaDimensionSettingsComment";
        #endregion
        #endregion
        #endregion

        #region ComboBox
        public static string ComboBoxHierarchySettingsHierarchyType = "ComboBoxHierarchySettingsHierarchyType";

        public static string ComboBoxPTagSettingsCommodity = "ComboBoxPTagSettingsCommodity";
        public static string ComboBoxPTagSettingsUom = "ComboBoxPTagSettingsUom";
        public static string ComboBoxPTagSettingsCalculationType = "ComboBoxPTagSettingsCalculationType";

        public static string ComboBoxVTagSettingsCommodity = "ComboBoxVTagSettingsCommodity";
        public static string ComboBoxVTagSettingsUom = "ComboBoxVTagSettingsUom";
        public static string ComboBoxVTagSettingsCalculationType = "ComboBoxVTagSettingsCalculationType";
        public static string ComboBoxVTagSettingsCalculationStep = "ComboBoxVTagSettingsCalculationStep";

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
        public static string GridVTagSettingsFormulaEditPTagList = "GridVTagSettingsFormulaEditPTagList";
        public static string GridVTagSettingsVTagList = "GridVTagSettingsVTagList";
        public static string GridAssociationTagList = "GridAssociationTagList";
        public static string GridPTagSettingsPTagList = "GridPTagSettingsPTagList";
        #endregion
    }
}
