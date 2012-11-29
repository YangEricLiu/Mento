using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public static class JazzControlLocatorKey
    {
        #region Button
        public static string ButtonLoginSubmit = "ButtonLoginSubmit";

        public static string ButtonDimensionSelectHierarchy = "ButtonDimensionSelectHierarchy";
        public static string ButtonSystemDimensionUpdate = "ButtonSystemDimensionUpdate";
        public static string ButtonAreaDimensionCreate = "ButtonAreaDimensionCreate";

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
        public static string ButtonNavigatorAssociationAreaDimensionButton = "ButtonNavigatorAssociationAreaDimensionButton";

        public static string TabButtonVTagSettingsBasicProperty = "TabButtonVTagSettingsBasicProperty";
        public static string TabButtonVTagSettingsFormula = "TabButtonVTagSettingsFormula";

        public static string ButtonVTagSettingsFormulaUpdate = "ButtonVTagSettingsFormulaUpdate";
        public static string ButtonVTagSettingsFormulaSave = "ButtonVTagSettingsFormulaSave";


        public const string ButtonAssociationSettingsTagAssociate = "ButtonAssociationSettingsTagAssociate";
        public const string ButtonAssociationSettingsAssociate = "ButtonAssociationSettingsAssociate";
        
        #endregion

        #region TextField
        public static string TextFieldLoginUserName = "TextFieldLoginUserName";
        public static string TextFieldLoginPassword = "TextFieldLoginPassword";
        
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
        #endregion
    }
}
