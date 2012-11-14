using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using Mento.Framework.Constants;

namespace Mento.Framework.Configuration
{
    public static class ExportConfig
    {
        public static string GetExportLocationConfig(string configKey)
        {
            var dictNameValueCollection = ConfigurationManager.GetSection(ConfigurationKey.EXPORT_LOCATION_CONFIGURATION) as NameValueCollection;

            return dictNameValueCollection[configKey];
        }
    }
}
