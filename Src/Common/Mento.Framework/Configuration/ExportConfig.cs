using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using Mento.Framework.Constants;
using System.IO;

namespace Mento.Framework.Configuration
{
    public static class ExportConfig
    {
        private const string PLANEXPORTDIRECTORY = "resultExportDirectory";
        private const string SCRIPTEXPORTDIRECTORY = "scriptExportDirectory";
        private const string RESULTEXPORTDIRECTORY = "resultExportDirectory";

        private static string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public static string PlanExportDirectory
        {
            get
            {
                return Path.Combine(BaseDirectory, GetExportLocationConfig(PLANEXPORTDIRECTORY));
            }
        }

        public static string ScriptExportDirectory
        {
            get
            {
                return Path.Combine(BaseDirectory, GetExportLocationConfig(SCRIPTEXPORTDIRECTORY));
            }
        }

        public static string ResultExportDirectory
        {
            get
            {
                return Path.Combine(BaseDirectory, GetExportLocationConfig(RESULTEXPORTDIRECTORY));
            }
        }

        private static string GetExportLocationConfig(string configKey)
        {
            var dictNameValueCollection = ConfigurationManager.GetSection(ConfigurationKey.EXPORT_LOCATION_CONFIGURATION) as NameValueCollection;

            return dictNameValueCollection[configKey];
        }
    }
}
