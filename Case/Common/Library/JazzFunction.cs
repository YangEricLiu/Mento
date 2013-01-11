﻿using System;
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

        public static TimeSettingsWorkday _TimeSettingsWorkday;
        public static TimeSettingsWorkday TimeSettingsWorkday
        {
            get
            {
                if (_TimeSettingsWorkday == null)
                    _TimeSettingsWorkday = new TimeSettingsWorkday();

                return _TimeSettingsWorkday;
            }
        }

        public static TimeSettingsWorktime _TimeSettingsWorktime;
        public static TimeSettingsWorktime TimeSettingsWorktime
        {
            get
            {
                if (_TimeSettingsWorktime == null)
                    _TimeSettingsWorktime = new TimeSettingsWorktime();

                return _TimeSettingsWorktime;
            }
        }

        public static TimeSettingsHeatingCoolingSeason _TimeSettingsHeatingCoolingSeason;
        public static TimeSettingsHeatingCoolingSeason TimeSettingsHeatingCoolingSeason
        {
            get
            {
                if (_TimeSettingsHeatingCoolingSeason == null)
                    _TimeSettingsHeatingCoolingSeason = new TimeSettingsHeatingCoolingSeason();

                return _TimeSettingsHeatingCoolingSeason;
            }
        }

        public static TimeSettingsDayNight _TimeSettingsDayNight;
        public static TimeSettingsDayNight TimeSettingsDayNight
        {
            get
            {
                if (_TimeSettingsDayNight == null)
                    _TimeSettingsDayNight = new TimeSettingsDayNight();

                return _TimeSettingsDayNight;
            }
        }

        public static CarbonFactorSettings _CarbonFactorSettings;
        public static CarbonFactorSettings CarbonFactorSettings
        {
            get
            {
                if (_CarbonFactorSettings == null)
                    _CarbonFactorSettings = new CarbonFactorSettings();

                return _CarbonFactorSettings;
            }
        }

        public static HierarchyPeopleAreaSettings _HierarchyPeopleAreaSettings;
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

        public static UserSettings _UserSettings;
        public static UserSettings UserSettings
        {
            get
            {
                if (_UserSettings == null)
                    _UserSettings = new UserSettings();

                return _UserSettings;
            }
        }
    }
}
