using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzGrid : JazzControlCollection
    {
        #region get one grid

        public static Grid GetOneGrid(string key, string nameIndex)
        {
            return GetControl<Grid>(key, nameIndex);
        }

        #endregion

        #region Energy view

        #region common

        public static Grid MultiHierarchySystemDimensionTagList = GetControl<Grid>(JazzControlLocatorKey.GridMultiHierarchySystemDimensionTagList);
        public static Grid MultiHierarchyAreaDimensionTagList = GetControl<Grid>(JazzControlLocatorKey.GridMultiHierarchyAreaDimensionTagList);
        public static Grid MultiHierarchyAllTagList = GetControl<Grid>(JazzControlLocatorKey.GridMultiHierarchyAllTagList);

        #endregion

        #region energy analysis

        public static Grid EnergyAnalysisAllTagList = GetControl<Grid>(JazzControlLocatorKey.GridEnergyAnalysisAllTagList);
        public static Grid EnergyAnalysisSystemDimensionTagList = GetControl<Grid>(JazzControlLocatorKey.GridEnergyAnalysisSystemDimensionTagList);
        public static Grid EnergyAnalysisAreaDimensionTagList = GetControl<Grid>(JazzControlLocatorKey.GridEnergyAnalysisAreaDimensionTagList);
        public static Grid EnergyAnalysisEnergyDataList = GetControl<Grid>(JazzControlLocatorKey.GridEnergyAnalysisEnergyDataList);

        #endregion

        #region unit KPI

        public static Grid TotalCommodityCarbonGrid = GetControl<Grid>(JazzControlLocatorKey.GridTotalCommodityCarbon);
        public static Grid TotalCommodityCostGrid = GetControl<Grid>(JazzControlLocatorKey.GridTotalCommodityCost);
        public static Grid TotalCommodityUnitCarbonGrid = GetControl<Grid>(JazzControlLocatorKey.GridTotalCommodityUnitCarbon);
        public static Grid TotalCommodityUnitCostGrid = GetControl<Grid>(JazzControlLocatorKey.GridTotalCommodityUnitCost);

        public static Grid CommodityCarbonGrid = GetControl<Grid>(JazzControlLocatorKey.GridCommodityCarbon);
        public static Grid CommodityCostGrid = GetControl<Grid>(JazzControlLocatorKey.GridCommodityCost);
        public static Grid CommodityUnitCarbonGrid = GetControl<Grid>(JazzControlLocatorKey.GridCommodityUnitCarbon);
        public static Grid CommodityUnitCostGrid = GetControl<Grid>(JazzControlLocatorKey.GridCommodityUnitCost);

        public static Grid UnitKPIAllTagList = GetControl<Grid>(JazzControlLocatorKey.GridUnitKPIAllTagList);
        public static Grid UnitKPIEnergyDataListGrid = GetControl<Grid>(JazzControlLocatorKey.GridUnitKPIEnergyDataList);

        public static Grid UnitDataListGrid = GetControl<Grid>(JazzControlLocatorKey.GridUnitDataList);

        #endregion

        #region radio

        public static Grid RatioAllTagList = GetControl<Grid>(JazzControlLocatorKey.GridRadioAllTagList);
        public static Grid RadioDataListGrid = GetControl<Grid>(JazzControlLocatorKey.GridRadioDataList);

        #endregion

        #region rank

        public static Grid CommodityRankGrid = GetControl<Grid>(JazzControlLocatorKey.GridCommodityRank);
        //public static Grid CommodityRankCarbonGrid = GetControl<Grid>(JazzControlLocatorKey.GridCommodityRankCarbon);
        //public static Grid CommodityRankCostGrid = GetControl<Grid>(JazzControlLocatorKey.GridCommodityRankCost);

        public static Grid SystemCommodityRankCostGrid = GetControl<Grid>(JazzControlLocatorKey.GridSystemDimensionCommodityRank);

        #endregion

        #region cost

        public static Grid TotalOtherCommodityCostGrid = GetControl<Grid>(JazzControlLocatorKey.GridTotalOtherCommodityCost);
        public static Grid OtherCommodityCostGrid = GetControl<Grid>(JazzControlLocatorKey.GridOtherCommodityCost);
        public static Grid CostDataListGrid = GetControl<Grid>(JazzControlLocatorKey.GridCostDataList);

        #endregion

        #region carbon

        public static Grid CarbonDataListGrid = GetControl<Grid>(JazzControlLocatorKey.GridCarbonDataList);

        #endregion

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

        public static Grid CalendarsList = GetControl<Grid>(JazzControlLocatorKey.GridCalendarsList);
        public static Grid TOUTariffsList = GetControl<Grid>(JazzControlLocatorKey.GridTOUTariffsList);

        public static Grid DataPermissonList = GetControl<Grid>(JazzControlLocatorKey.GridDataScopePermissionList);
        public static Grid CustomerList = GetControl<Grid>(JazzControlLocatorKey.GridCustomersList);

        public static Grid DataPermissionCustomerList = GetControl<Grid>(JazzControlLocatorKey.GridRowDataCustomerTextRow);
        public static Grid CarbonFactorList = GetControl<Grid>(JazzControlLocatorKey.GridCarbonFactorsList);
        public static Grid PlatformCustomerList = GetControl<Grid>(JazzControlLocatorKey.GridCustomersList);

        public static Grid BenchMarkList = GetControl<Grid>(JazzControlLocatorKey.GridIndustryBenchmarkList);

        #endregion

        #region home page

        public static Grid HomepageMinWidgetDataViewGrid = GetControl<Grid>(JazzControlLocatorKey.GridHomepageMinWidgetDataView);
        public static Grid ShareUserListGrid = GetControl<Grid>(JazzControlLocatorKey.GridShareUserList);
        public static Grid GridShareInfoList = GetControl<Grid>(JazzControlLocatorKey.GridShareInfoList);
        public static Grid MaxWidgetDataViewGrid = GetControl<Grid>(JazzControlLocatorKey.GridMaxWidgetDataView);
        
        #endregion
    }
}
