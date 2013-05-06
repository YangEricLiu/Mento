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
        public static SystemDimensionTree EnergyViewSystemDimensionTree = GetControl<SystemDimensionTree>(JazzControlLocatorKey.SystemDimensionTreeEnergyView);

        public static AreaDimensionTree EnergyViewAreaDimensionTree = GetControl<AreaDimensionTree>(JazzControlLocatorKey.AreaDimensionTreeEnergyView);

        public static HierarchyTree EnergyViewHierarchyTree = GetControl<HierarchyTree>(JazzControlLocatorKey.HierarchyTreeEnergyView);
        #endregion

        #region HierarchySettings
        public static HierarchyTree HierarchySettingsHierarchyTree = GetControl<HierarchyTree>(JazzControlLocatorKey.HierarchyTreeHierarchySettings);

        public static HierarchyTree HierarchySettingsDimensionHierarchyTree = GetControl<HierarchyTree>(JazzControlLocatorKey.HierarchyTreeHierarchySettingsDimension);

        public static SystemDimensionTree HierarchySettingsSystemDimensionTree = GetControl<SystemDimensionTree>(JazzControlLocatorKey.SystemDimensionTreeHierarchySettings);

        public static SystemDimensionTree HierarchySettingsDialogSystemDimensionTree = GetControl<SystemDimensionTree>(JazzControlLocatorKey.SystemDimensionTreeHierarchySettingsDialog);

        public static AreaDimensionTree HierarchySettingsAreaDimensionTree = GetControl<AreaDimensionTree>(JazzControlLocatorKey.AreaDimensionTreeHierarchySettings);
        #endregion

        #region Association
        public static HierarchyTree AssociationHierarchyTree = GetControl<HierarchyTree>(JazzControlLocatorKey.HierarchyTreeAssociation);

        public static HierarchyTree AssociationDimensionHierarchyTree = GetControl<HierarchyTree>(JazzControlLocatorKey.HierarchyTreeAssociationDimension);

        public static SystemDimensionTree AssociationSystemDimensionTree = GetControl<SystemDimensionTree>(JazzControlLocatorKey.SystemDimensionTreeAssociation);

        public static AreaDimensionTree AssociationAreaDimensionTree = GetControl<AreaDimensionTree>(JazzControlLocatorKey.AreaDimensionTreeAssociation);
        #endregion
    }
}
