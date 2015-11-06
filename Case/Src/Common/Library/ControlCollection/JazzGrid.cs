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
            return GetControl<Grid>(key, nameIndex) ;
        }
        public static Grid GetOneGrid(string key, int positionIndex)
        {
            return GetControl<Grid>(key, positionIndex) ;
        }

        #endregion

        #region Energy view

        #region common

        public static Grid MultiHierarchySystemDimensionTagList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridMultiHierarchySystemDimensionTagList);}}
        public static Grid MultiHierarchyAreaDimensionTagList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridMultiHierarchyAreaDimensionTagList);}}
        public static Grid MultiHierarchyAllTagList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridMultiHierarchyAllTagList);}}

        #endregion

        #region energy analysis

        public static Grid EnergyAnalysisAllTagList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridEnergyAnalysisAllTagList);}}
        public static Grid EnergyAnalysisSystemDimensionTagList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridEnergyAnalysisSystemDimensionTagList);}}
        public static Grid EnergyAnalysisAreaDimensionTagList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridEnergyAnalysisAreaDimensionTagList);}}
        public static Grid EnergyAnalysisEnergyDataList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridEnergyAnalysisEnergyDataList);}}

        #endregion

        #region unit KPI

        public static Grid TotalCommodityCarbonGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridTotalCommodityCarbon);}}
        public static Grid TotalCommodityCostGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridTotalCommodityCost);}}
        public static Grid TotalCommodityUnitCarbonGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridTotalCommodityUnitCarbon);}}
        public static Grid TotalCommodityUnitCostGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridTotalCommodityUnitCost);}}

        public static Grid CommodityCarbonGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridCommodityCarbon);}}
        public static Grid CommodityCostGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridCommodityCost);}}
        public static Grid CommodityUnitCarbonGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridCommodityUnitCarbon);}}
        public static Grid CommodityUnitCostGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridCommodityUnitCost);}}

        public static Grid UnitKPIAllTagList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridUnitKPIAllTagList);}}
        public static Grid UnitKPIEnergyDataListGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridUnitKPIEnergyDataList);}}

        public static Grid UnitDataListGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridUnitDataList);}}

        #endregion

        #region radio

        public static Grid RatioAllTagList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridRadioAllTagList);}}
        public static Grid RadioDataListGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridRadioDataList);}}

        #endregion

        #region rank

        public static Grid CommodityRankGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridCommodityRank);}}
        //public static Grid CommodityRankCarbonGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridCommodityRankCarbon);}}
        //public static Grid CommodityRankCostGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridCommodityRankCost);}}

        public static Grid SystemCommodityRankCostGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridSystemDimensionCommodityRank);}}

        #endregion

        #region cost

        public static Grid TotalOtherCommodityCostGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridTotalOtherCommodityCost);}}
        public static Grid OtherCommodityCostGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridOtherCommodityCost);}}
        public static Grid CostDataListGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridCostDataList);}}

        #endregion

        #region carbon

        public static Grid CarbonDataListGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridCarbonDataList);}}
        
        #endregion

        #region Labelling

        public static Grid LabellingAllTagListGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridLabellingAllTagList);}}

        #endregion

        #endregion

        #region Customer settings
        public static Grid VTagSettingsFormulaEditPTagList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridVTagSettingsFormulaEditPTagList);}}
        public static Grid VTagSettingsVTagList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridVTagSettingsVTagList);}}

        public static Grid KPITagSettingsFormulaEditPTagList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridKPITagSettingsFormulaEditPTagList);}}
        public static Grid KPITagSettingsKPITagList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridKPITagSettingsKPITagList);}}

        public static Grid AssociationTagList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridAssociationTagList);}}

        public static Grid PTagSettingsPTagList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridPTagSettingsPTagList);}}

        public static Grid AbnormalRecordList { get { return GetControl<Grid>(JazzControlLocatorKey.GridAbnormalRecordList); } }

        public static Grid CustomizedLabellingListGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridCustomizedLabellingList);}}

        public static Grid GridPTagRawData{ get { return GetControl<Grid>(JazzControlLocatorKey.GridPTagRawData);}}

        public static Grid GridVEERawData { get { return GetControl<Grid>(JazzControlLocatorKey.GridVEERawData); } }
       
        public static Grid VEERuleSettingsVEERuleList { get { return GetControl<Grid>(JazzControlLocatorKey.GridVEERuleSettingsVEERuleList); } }

        public static Grid UserListGrid
        {
            get { return GetControl<Grid>(JazzControlLocatorKey.GridUserList); }
        }
        #endregion

        #region platform settings
        public static Grid UserTypePermissionList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridUserTypePermissionList);}}

        public static Grid CalendarsList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridCalendarsList);}}
        public static Grid TOUTariffsList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridTOUTariffsList);}}

        public static Grid DataPermissonList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridDataScopePermissionList);}}
        public static Grid CustomerList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridCustomersList);}}

        public static Grid DataPermissionCustomerList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridRowDataCustomerTextRow);}}
        public static Grid CarbonFactorList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridCarbonFactorsList);}}
        public static Grid PlatformCustomerList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridCustomersList);}}

        public static Grid BenchMarkList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridIndustryBenchmarkList);}}

        public static Grid LabelingList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridIndustryLabelingList);}}

        #endregion

        #region home page

        public static Grid HomepageMinWidgetDataViewGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridHomepageMinWidgetDataView);}}
        public static Grid ShareUserListGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridShareUserList);}}
        public static Grid GridShareInfoList{ get { return GetControl<Grid>(JazzControlLocatorKey.GridShareInfoList);}}
        public static Grid MaxWidgetDataViewGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridMaxWidgetDataView);}}
        public static Grid SendedUserListGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridSendedUserList);}}
        public static Grid EnjoyShareUserListGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridEnjoyShareUserList);}}
        public static Grid EnjoySendedUserListGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridEnjoySendedUserList);}}
        public static Grid SubscribeUserListGrid{ get { return GetControl<Grid>(JazzControlLocatorKey.GridSubscribeUserList);}}

        #endregion

        #region New Jazz Tag List

        public static Grid NewJazz_GetOneGrid(string key, int positionIndex)
        {
            return GetControl<Grid>(key, positionIndex);
        }

        public static Grid NewJazzTaglistGrid { get { return GetControl<Grid>(JazzControlLocatorKey.NewReactJSjazzGridTaglist); } }

        #endregion
    }
}
