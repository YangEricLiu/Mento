using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;

namespace Mento.ScriptCommon.Library
{
    /// <summary>
    /// Reference to Jazz function attitude.
    /// </summary>
    public static class JazzFunction
    {
        private static LoginPage _LoginPage;
        public static LoginPage LoginPage
        {
            get
            {
                if (_LoginPage == null)
                    _LoginPage = new LoginPage();

                return _LoginPage;
            }
        }

        private static DemoAccessSetting _Demo;
        public static DemoAccessSetting Demo
        {
            get
            {
                if (_Demo == null)
                    _Demo = new DemoAccessSetting();

                return _Demo;
            }
        }

        private static ContactUsSetting _ContactUsPage;
        public static ContactUsSetting ContactUsPage
        {
            get
            {
                if (_ContactUsPage == null)
                    _ContactUsPage = new ContactUsSetting();

                return _ContactUsPage;
            }
        }
        private static CommodifyUomSetting _CommodifyUomSetting;
        public static CommodifyUomSetting CommodifyUomSetting
        {
            get
            {
                if (_CommodifyUomSetting == null)
                    _CommodifyUomSetting = new CommodifyUomSetting();

                return _CommodifyUomSetting;
            }
        }

        private static Navigator _Navigator;
        public static Navigator Navigator
        {
            get
            {
                if (_Navigator == null)
                    _Navigator = new Navigator();

                return _Navigator;
            }
        }

        private static CustomizedLabellingSettings _CustomizedLabellingSettings;
        public static CustomizedLabellingSettings CustomizedLabellingSettings
        {
            get
            {
                if (_CustomizedLabellingSettings == null)
                    _CustomizedLabellingSettings = new CustomizedLabellingSettings();

                return _CustomizedLabellingSettings;
            }
        }

        private static PTagSettings _PTagSettings;
        public static PTagSettings PTagSettings
        {
            get
            {
                if (_PTagSettings == null)
                    _PTagSettings = new PTagSettings();

                return _PTagSettings;
            }
        }

        private static AbnormalData _AbnormalData;
        public static AbnormalData AbnormalData
        {
            get
            {
                if (_AbnormalData == null)
                    _AbnormalData = new AbnormalData();

                return _AbnormalData;
            }
        }

        private static PTagRawData _PTagRawData;
        public static PTagRawData PTagRawData
        {
            get
            {
                if (_PTagRawData == null)
                    _PTagRawData = new PTagRawData();

                return _PTagRawData;
            }
        }

        private static VTagSettings _VTagSettings;
        public static VTagSettings VTagSettings
        {
            get
            {
                if (_VTagSettings == null)
                    _VTagSettings = new VTagSettings();

                return _VTagSettings;
            }
        }
        private static VEERuleSettings _VEERuleSettings;
        public static VEERuleSettings VEERuleSettings
        {
            get
            {
                if (_VEERuleSettings == null)
                    _VEERuleSettings = new VEERuleSettings();

                return _VEERuleSettings;
            }
        }
        private static KPITagSettings _KPITagSettings;
        public static KPITagSettings KPITagSettings
        {
            get
            {
                if (_KPITagSettings == null)
                    _KPITagSettings = new KPITagSettings();

                return _KPITagSettings;
            }
        }

        private static TagTargetBaselineSettings _TagTargetBaselineSettings;
        public static TagTargetBaselineSettings TagTargetBaselineSettings
        {
            get
            {
                if (_TagTargetBaselineSettings == null)
                    _TagTargetBaselineSettings = new TagTargetBaselineSettings();

                return _TagTargetBaselineSettings;
            }
        }

        private static HierarchySettings _HierarchySettings;
        public static HierarchySettings HierarchySettings
        {
            get
            {
                if (_HierarchySettings == null)
                    _HierarchySettings = new HierarchySettings();

                return _HierarchySettings;
            }
        }


        private static AssociateSettings _AssociateSettings;
        public static AssociateSettings AssociateSettings
        {
            get
            {
                if (_AssociateSettings == null)
                    _AssociateSettings = new AssociateSettings();

                return _AssociateSettings;
            }
        }
		
        private static DisassociateSettings _DisassociateSettings;
        public static DisassociateSettings DisassociateSettings
        {
            get
            {
                if (_DisassociateSettings == null)
                    _DisassociateSettings = new DisassociateSettings();

                return _DisassociateSettings;
            }
        }

        private static SystemDimensionSettings _SystemDimensionSettings;
        public static SystemDimensionSettings SystemDimensionSettings
        {
            get
            {
                if (_SystemDimensionSettings == null)
                    _SystemDimensionSettings = new SystemDimensionSettings();

                return _SystemDimensionSettings;
            }
        }

        private static AreaDimensionSettings _AreaDimensionSettings;
        public static AreaDimensionSettings AreaDimensionSettings
        {
            get
            {
                if (_AreaDimensionSettings == null)
                    _AreaDimensionSettings = new AreaDimensionSettings();

                return _AreaDimensionSettings;
            }
        }

        private static HierarchyCalendarSettings _HierarchyCalendarSettings;
        public static HierarchyCalendarSettings HierarchyCalendarSettings
        {
            get
            {
                if (_HierarchyCalendarSettings == null)
                    _HierarchyCalendarSettings = new HierarchyCalendarSettings();

                return _HierarchyCalendarSettings;
            }
        }

        private static AdministratorInfoSetting _AdministratorInfoSetting;
        public static AdministratorInfoSetting AdministratorInfoSetting
        {
            get
            {
                if (_AdministratorInfoSetting == null)
                    _AdministratorInfoSetting = new AdministratorInfoSetting();

                return _AdministratorInfoSetting;
            }
        }

        private static TimeSettingsWorkday _TimeSettingsWorkday;
        public static TimeSettingsWorkday TimeSettingsWorkday
        {
            get
            {
                if (_TimeSettingsWorkday == null)
                    _TimeSettingsWorkday = new TimeSettingsWorkday();

                return _TimeSettingsWorkday;
            }
        }

        private static TimeSettingsWorktime _TimeSettingsWorktime;
        public static TimeSettingsWorktime TimeSettingsWorktime
        {
            get
            {
                if (_TimeSettingsWorktime == null)
                    _TimeSettingsWorktime = new TimeSettingsWorktime();

                return _TimeSettingsWorktime;
            }
        }

        private static TimeSettingsHeatingCoolingSeason _TimeSettingsHeatingCoolingSeason;
        public static TimeSettingsHeatingCoolingSeason TimeSettingsHeatingCoolingSeason
        {
            get
            {
                if (_TimeSettingsHeatingCoolingSeason == null)
                    _TimeSettingsHeatingCoolingSeason = new TimeSettingsHeatingCoolingSeason();

                return _TimeSettingsHeatingCoolingSeason;
            }
        }

        private static TimeSettingsDayNight _TimeSettingsDayNight;
        public static TimeSettingsDayNight TimeSettingsDayNight
        {
            get
            {
                if (_TimeSettingsDayNight == null)
                    _TimeSettingsDayNight = new TimeSettingsDayNight();

                return _TimeSettingsDayNight;
            }
        }

        private static IndustryBenchmarkSetting _IndustryBenchmarkSetting;
        public static IndustryBenchmarkSetting IndustryBenchmarkSetting
        {
            get
            {
                if (_IndustryBenchmarkSetting == null)
                    _IndustryBenchmarkSetting = new IndustryBenchmarkSetting();

                return _IndustryBenchmarkSetting;
            }
        }

        private static IndustryLabelingSetting _IndustryLabelingSetting;
        public static IndustryLabelingSetting IndustryLabelingSetting
        {
            get
            {
                if (_IndustryLabelingSetting == null)
                    _IndustryLabelingSetting = new IndustryLabelingSetting();

                return _IndustryLabelingSetting;
            }
        }

        private static CarbonFactorSettings _CarbonFactorSettings;
        public static CarbonFactorSettings CarbonFactorSettings
        {
            get
            {
                if (_CarbonFactorSettings == null)
                    _CarbonFactorSettings = new CarbonFactorSettings();

                return _CarbonFactorSettings;
            }
        }

        private static TOUBasicTariffSettings _TOUBasicTariffSettings;
        public static TOUBasicTariffSettings TOUBasicTariffSettings
        {
            get
            {
                if (_TOUBasicTariffSettings == null)
                    _TOUBasicTariffSettings = new TOUBasicTariffSettings();

                return _TOUBasicTariffSettings;
            }
        }

        private static TOUPulsePeakTariffSettings _TOUPulsePeakTariffSettings;
        public static TOUPulsePeakTariffSettings TOUPulsePeakTariffSettings
        {
            get
            {
                if (_TOUPulsePeakTariffSettings == null)
                    _TOUPulsePeakTariffSettings = new TOUPulsePeakTariffSettings();

                return _TOUPulsePeakTariffSettings;
            }
        }

        private static HierarchyPeopleAreaSettings _HierarchyPeopleAreaSettings;
        public static HierarchyPeopleAreaSettings HierarchyPeopleAreaSettings
        {
            get
            {
                if (_HierarchyPeopleAreaSettings == null)
                    _HierarchyPeopleAreaSettings = new HierarchyPeopleAreaSettings();

                return _HierarchyPeopleAreaSettings;
            }
        }
        private static BasicIndustryAndZoneSetting _BasicIndustryAndZoneSetting;
        public static BasicIndustryAndZoneSetting BasicIndustryAndZoneSetting
        {
            get
            {
                if (_BasicIndustryAndZoneSetting == null)
                    _BasicIndustryAndZoneSetting = new BasicIndustryAndZoneSetting();

                return _BasicIndustryAndZoneSetting;
            }
        }

        private static EnergyAnalysisPanel _EnergyAnalysisPanel;
        public static EnergyAnalysisPanel EnergyAnalysisPanel
        {
            get
            {
                if (_EnergyAnalysisPanel == null)
                    _EnergyAnalysisPanel = new EnergyAnalysisPanel();

                return _EnergyAnalysisPanel;
            }
        }


        private static NewJazzEnergyAnalysis _NewJazzEnergyAnalysis;
        public static NewJazzEnergyAnalysis NewJazzEnergyAnalysis
        {
            get
            {
                if (_NewJazzEnergyAnalysis == null)
                    _NewJazzEnergyAnalysis = new NewJazzEnergyAnalysis();

                return _NewJazzEnergyAnalysis;
            }
        }


        private static UserSettings _UserSettings;
        public static UserSettings UserSettings
        {
            get
            {
                if (_UserSettings == null)
                    _UserSettings = new UserSettings();

                return _UserSettings;
            }
        }
        //Greenie added

        private static UserDataScopePermission _UserDataScopePermission;
        public static UserDataScopePermission UserDataScopePermission
        {
            get
            {
                if (_UserDataScopePermission == null)
                    _UserDataScopePermission = new UserDataScopePermission();

                return _UserDataScopePermission;
            }
        }

        private static FunctionRoleTypePermissionSettings _FunctionRoleTypePermissionSettings;
        public static FunctionRoleTypePermissionSettings FunctionRoleTypePermissionSettings
        {
            get
            {
                if (_FunctionRoleTypePermissionSettings == null)
                    _FunctionRoleTypePermissionSettings = new FunctionRoleTypePermissionSettings();

                return _FunctionRoleTypePermissionSettings;
            }
        }

        private static UserTypePermissionSettings _UserTypePermissionSettings;
        public static UserTypePermissionSettings UserTypePermissionSettings
        {
            get
            {
                if (_UserTypePermissionSettings == null)
                    _UserTypePermissionSettings = new UserTypePermissionSettings();

                return _UserTypePermissionSettings;
            }
        }


        private static HierarchyElectricCostSettings _HierarchyElectricCostSettings;
        public static HierarchyElectricCostSettings HierarchyElectricCostSettings
        {
            get
            {
                if (_HierarchyElectricCostSettings == null)
                    _HierarchyElectricCostSettings = new HierarchyElectricCostSettings();

                return _HierarchyElectricCostSettings;
            }
        }

        private static HierarchyOtherCostPropertySettings _HierarchyOtherCostPropertySettings;
        public static HierarchyOtherCostPropertySettings HierarchyOtherCostPropertySettings
        {
            get
            {
                if (_HierarchyOtherCostPropertySettings == null)
                    _HierarchyOtherCostPropertySettings = new HierarchyOtherCostPropertySettings();

                return _HierarchyOtherCostPropertySettings;
            }
        }

        private static CustomerManagement _CustomerManagement;
        public static CustomerManagement CustomerManagement
        {
            get
            {
                if (_CustomerManagement == null)
                    _CustomerManagement = new CustomerManagement();

                return _CustomerManagement;
            }
        }

        private static UserProfileDialog _UserProfileDialog;
        public static UserProfileDialog UserProfileDialog
        {
            get
            {
                if (_UserProfileDialog == null)
                    _UserProfileDialog = new UserProfileDialog();

                return _UserProfileDialog;
            }

        }

        private static PersonalMgtMenu _PersonalMgtMenu;
        public static PersonalMgtMenu PersonalMgtMenu
        {
            get
            {
                if (_PersonalMgtMenu == null)
                    _PersonalMgtMenu = new PersonalMgtMenu();

                return _PersonalMgtMenu;
            }

        }

        private static Widget _Widget;
        public static Widget Widget
        {
            get
            {
                if (_Widget == null)
                    _Widget = new Widget();

                return _Widget;
            }

        }
        
        private static EnergyViewToolbarViewSplitButton _EnergyViewToolbarViewSplitButton;
        public static EnergyViewToolbarViewSplitButton EnergyViewToolbarViewSplitButton
        {
            get
            {
                if (_EnergyViewToolbarViewSplitButton == null)
                    _EnergyViewToolbarViewSplitButton = new EnergyViewToolbarViewSplitButton();

                return _EnergyViewToolbarViewSplitButton;
            }

        }

        //  Greenie add 2013/06/18
        private static CostPanel _CostPanel;
        public static CostPanel CostPanel
        {
            get
            {
                if (_CostPanel == null)
                    _CostPanel = new CostPanel();

                return _CostPanel;
            }
        }

        //Emma add 2013/07/18
        private static UnitKPIPanel _UnitKPIPanel;
        public static UnitKPIPanel UnitKPIPanel
        {
            get
            {
                if (_UnitKPIPanel == null)
                    _UnitKPIPanel = new UnitKPIPanel();

                return _UnitKPIPanel;
            }
        
        }

        //Emma add 2014/02/28
        private static IndustryLabellingPanel _IndustryLabellingPanel;
        public static IndustryLabellingPanel IndustryLabellingPanel
        {
            get
            {
                if (_IndustryLabellingPanel == null)
                    _IndustryLabellingPanel = new IndustryLabellingPanel();

                return _IndustryLabellingPanel;
            }

        }

        private static EnergyViewToolbar _EnergyViewToolbar;
        public static EnergyViewToolbar EnergyViewToolbar
        {
            get
            {
                if (_EnergyViewToolbar == null)
                    _EnergyViewToolbar = new EnergyViewToolbar();

                return _EnergyViewToolbar;
            }
        }

        private static RatioPanel _RatioPanel;
        public static RatioPanel RatioPanel
        {
            get
            {
                if (_RatioPanel == null)
                    _RatioPanel = new RatioPanel();

                return _RatioPanel;
            }
        }

        private static RankPanel _RankPanel;
        public static RankPanel RankPanel
        {
            get
            {
                if (_RankPanel == null)
                    _RankPanel = new RankPanel();

                return _RankPanel;
            }
        }

        private static CarbonUsagePanel _CarbonUsagePanel;
        public static CarbonUsagePanel CarbonUsagePanel
        {
            get
            {
                if (_CarbonUsagePanel == null)
                    _CarbonUsagePanel = new CarbonUsagePanel();

                return _CarbonUsagePanel;
            }
        }

        private static DataViewOperation _DataViewOperation;
        public static DataViewOperation DataViewOperation
        {
            get
            {
                if (_DataViewOperation == null)
                    _DataViewOperation = new DataViewOperation();

                return _DataViewOperation;
            }
        }

        private static ChartViewOperation _ChartViewOperation;
        public static ChartViewOperation ChartViewOperation
        {
            get
            {
                if (_ChartViewOperation == null)
                    _ChartViewOperation = new ChartViewOperation();

                return _ChartViewOperation;
            }
        }

        private static HomePage _HomePage;
        public static HomePage HomePage
        {
            get
            {
                if (_HomePage == null)
                    _HomePage = new HomePage();

                return _HomePage;
            }
        }

        private static MutipleHierarchyCompareWindow _MutipleHierarchyCompareWindow;
        public static MutipleHierarchyCompareWindow MutipleHierarchyCompareWindow
        {
            get
            {
                if (_MutipleHierarchyCompareWindow == null)
                    _MutipleHierarchyCompareWindow = new MutipleHierarchyCompareWindow();

                return _MutipleHierarchyCompareWindow;
            }
        }

        private static TimeSpanDialog _TimeSpanDialog;
        public static TimeSpanDialog TimeSpanDialog
        {
            get
            {
                if (_TimeSpanDialog == null)
                    _TimeSpanDialog = new TimeSpanDialog();

                return _TimeSpanDialog;
            }
        }

        private static BatchModifyDialog _BatchModifyDialog;
        public static BatchModifyDialog BatchModifyDialog
        {
            get
            {
                if (_BatchModifyDialog == null)
                    _BatchModifyDialog = new BatchModifyDialog();

                return _BatchModifyDialog;
            }
        }

        private static WidgetMaxChartDialog _WidgetMaxChartDialog;
        public static WidgetMaxChartDialog WidgetMaxChartDialog
        {
            get
            {
                if (_WidgetMaxChartDialog == null)
                    _WidgetMaxChartDialog = new WidgetMaxChartDialog();

                return _WidgetMaxChartDialog;
            }
        }

        #region New Jazz

        private static FolderWidgetPanel _FolderWidgetPanel;
        public static FolderWidgetPanel FolderWidgetPanel
        {
            get
            {
                if (_FolderWidgetPanel == null)
                    _FolderWidgetPanel = new FolderWidgetPanel();

                return _FolderWidgetPanel;
            }
        }

        #endregion
    }
}
