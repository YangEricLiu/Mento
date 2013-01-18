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

        private static KPITargetBaselineSettings _KPITargetBaselineSettings;
        public static KPITargetBaselineSettings KPITargetBaselineSettings
        {
            get
            {
                if (_KPITargetBaselineSettings == null)
                    _KPITargetBaselineSettings = new KPITargetBaselineSettings();

                return _KPITargetBaselineSettings;
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

        private static UserProfile _UserProfile;
        public static UserProfile UserProfile
        {
            get
            {
                if (_UserProfile == null)
                    _UserProfile = new UserProfile();

                return _UserProfile;
            }

        }
    }
}
