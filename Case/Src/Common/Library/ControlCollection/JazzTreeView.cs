using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzTreeView : JazzControlCollection
    {
        #region EnergyView
        public static SystemDimensionTree EnergyViewSystemDimensionTree { get { return GetControl<SystemDimensionTree>(JazzControlLocatorKey.SystemDimensionTreeEnergyView);}}

        public static HierarchyTree RankHierarchyTree { get { return GetControl<HierarchyTree>(JazzControlLocatorKey.HierarchyTreeRank);}}

        public static AreaDimensionTree EnergyViewAreaDimensionTree { get { return GetControl<AreaDimensionTree>(JazzControlLocatorKey.AreaDimensionTreeEnergyView);}}

        public static HierarchyTree EnergyViewHierarchyTree { get { return GetControl<HierarchyTree>(JazzControlLocatorKey.HierarchyTreeEnergyView);}}

        public static HierarchyTree WidgetSaveHierarchyTree { get { return GetControl<HierarchyTree>(JazzControlLocatorKey.WidgetSaveHierarchyTree);}}

        public static HierarchyTree MultipleHierarchyTree { get { return GetControl<HierarchyTree>(JazzControlLocatorKey.MultipleHierarchyTree);}}

        public static SystemDimensionTree MultipleSystemDimensionTree { get { return GetControl<SystemDimensionTree>(JazzControlLocatorKey.MultipleSystemDimensionTree);}}
        public static AreaDimensionTree MultipleAreaDimensionTree { get { return GetControl<AreaDimensionTree>(JazzControlLocatorKey.MultipleAreaDimensionTree);}}

        public static HierarchyTree RankingHierarchyTree { get { return GetControl<HierarchyTree>(JazzControlLocatorKey.CoperateRankingTree);}}
        
        #endregion

        #region HierarchySettings
        public static HierarchyTree HierarchySettingsHierarchyTree { get { return GetControl<HierarchyTree>(JazzControlLocatorKey.HierarchyTreeHierarchySettings);}}

        public static HierarchyTree HierarchySettingsDimensionHierarchyTree { get { return GetControl<HierarchyTree>(JazzControlLocatorKey.HierarchyTreeHierarchySettingsDimension);}}

        public static SystemDimensionTree HierarchySettingsSystemDimensionTree { get { return GetControl<SystemDimensionTree>(JazzControlLocatorKey.SystemDimensionTreeHierarchySettings);}}

        public static SystemDimensionTree HierarchySettingsDialogSystemDimensionTree { get { return GetControl<SystemDimensionTree>(JazzControlLocatorKey.SystemDimensionTreeHierarchySettingsDialog);}}

        public static AreaDimensionTree HierarchySettingsAreaDimensionTree { get { return GetControl<AreaDimensionTree>(JazzControlLocatorKey.AreaDimensionTreeHierarchySettings);}}
        #endregion

        #region Association
        public static HierarchyTree AssociationHierarchyTree { get { return GetControl<HierarchyTree>(JazzControlLocatorKey.HierarchyTreeAssociation);}}

        public static HierarchyTree AssociationDimensionHierarchyTree { get { return GetControl<HierarchyTree>(JazzControlLocatorKey.HierarchyTreeAssociationDimension);}}

        public static SystemDimensionTree AssociationSystemDimensionTree { get { return GetControl<SystemDimensionTree>(JazzControlLocatorKey.SystemDimensionTreeAssociation);}}

        public static AreaDimensionTree AssociationAreaDimensionTree { get { return GetControl<AreaDimensionTree>(JazzControlLocatorKey.AreaDimensionTreeAssociation);}}
        #endregion

        #region UserDataPermission
        public static HierarchyTree DataPermissionHierarchyTree { get { return GetControl<HierarchyTree>(JazzControlLocatorKey.DataPermissionHierarchyTree);}}

        #endregion

        #region HomePage

        public static HierarchyTree AllDashboardsTree { get { return GetControl<HierarchyTree>(JazzControlLocatorKey.AllDashboardsTree);}}

        #endregion
    }
}
