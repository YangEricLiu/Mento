using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Framework.Constants
{
    /// <summary>
    /// Configuration Key.
    /// </summary>
    public static class ConfigurationKey
    {
        public const string MENTO_DATABASE_KEY = "Mento";
        public const string JAZZ_DATABASE_KEY = "Jazz";

        public const string LOGGING_SEVERITY = "loggingSeverity";

        public const string SCRIPT_DATA_MAPPINGFILE = "dataMapping";

        public const string ELEMENTMAP_PATH = "elementConfigPath";
        public const string ELEMENTMAP_MODULE_NAME = "WebElement";

        //public const string ELEMENTMANUALMAP_PATH = @"D:\Schneider\Mento\Trunk\Src\Common\Mento.Utility\appObject\ManualElementMap.xml";
        //public const string ELEMENTMANUALMAP_MODULE_NAME = "Locator";

        public const string LANGUAGE_CN_PATH = "languageResourcePath_CN";
        public const string LANGUAGE_EN_PATH = "languageResourcePath_EN";

        public const string FIREFOX_LOCATION = "firefoxLocation";
     }
}
