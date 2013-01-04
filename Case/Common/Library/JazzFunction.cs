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

        private static KPISettings _KPISettings;
        public static KPISettings KPISettings
        {
            get
            {
                if (_KPISettings == null)
                    _KPISettings = new KPISettings();

                return _KPISettings;
            }  
        }

        private static HierarchyPropertySettings _HierarchyPropertySettings;
        public static HierarchyPropertySettings HierarchyPropertySettings
        {
            get
            {
                if (_HierarchyPropertySettings == null)
                    _HierarchyPropertySettings = new HierarchyPropertySettings();

                return _HierarchyPropertySettings;
            }
        }
    }
}
