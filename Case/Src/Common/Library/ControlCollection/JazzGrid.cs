using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzGrid : JazzControlCollection
    {
        #region Energy view
        public static Grid EnergyAnalysisAllTagList = GetControl<Grid>(JazzControlLocatorKey.GridEnergyAnalysisAllTagList);
        public static Grid EnergyAnalysisSystemDimensionTagList = GetControl<Grid>(JazzControlLocatorKey.GridEnergyAnalysisSystemDimensionTagList);
        public static Grid EnergyAnalysisAreaDimensionTagList = GetControl<Grid>(JazzControlLocatorKey.GridEnergyAnalysisAreaDimensionTagList);

        public static Grid EnergyAnalysisEnergyDataList = GetControl<Grid>(JazzControlLocatorKey.GridEnergyAnalysisEnergyDataList);

        public static Grid UnitKPIAllTagList = GetControl<Grid>(JazzControlLocatorKey.GridUnitKPIAllTagList);
        public static Grid RadioAllTagList = GetControl<Grid>(JazzControlLocatorKey.GridRadioAllTagList);
        #endregion

        #region Customer settings
        public static Grid VTagSettingsFormulaEditPTagList = GetControl<Grid>(JazzControlLocatorKey.GridVTagSettingsFormulaEditPTagList);
        public static Grid VTagSettingsVTagList = GetControl<Grid>(JazzControlLocatorKey.GridVTagSettingsVTagList);

        public static Grid KPITagSettingsFormulaEditPTagList = GetControl<Grid>(JazzControlLocatorKey.GridKPITagSettingsFormulaEditPTagList);
        public static Grid KPITagSettingsKPITagList = GetControl<Grid>(JazzControlLocatorKey.GridKPITagSettingsKPITagList);

        public static Grid AssociationTagList = GetControl<Grid>(JazzControlLocatorKey.GridAssociationTagList);

        public static Grid PTagSettingsPTagList = GetControl<Grid>(JazzControlLocatorKey.GridPTagSettingsPTagList);
        public static Grid UserListGrid
        {
            get { return GetControl<Grid>(JazzControlLocatorKey.GridUserList); }
        }
        #endregion

        #region platform settings
        public static Grid UserTypePermissionList = GetControl<Grid>(JazzControlLocatorKey.GridUserTypePermissionList);
        public static Grid TOUTariffsList = GetControl<Grid>(JazzControlLocatorKey.GridTOUTariffsList);
        #endregion
    }
}
