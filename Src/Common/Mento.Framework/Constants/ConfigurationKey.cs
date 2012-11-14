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

        public const string COMBOPATH = @"D:\Schneider\Mento\Trunk\Case\Host\ScriptHost\Config\ComboBoxItemList-CN.xml";
        public const string COMBOMODULE = "ItemList";

        public const string EXECUTION_CONFIGURATION = "executionConfiguration";
        public const string EXPORT_LOCATION_CONFIGURATION = "exportLocationConfiguration";

        public const string BROWSER = "browser";
        public const string LANGUAGE = "language";
        public const string URL = "url";
        public const string OS = "OS";
        public const string IE_VERSION = "IEVersion";
        public const string PLAN_ID = "planID";

        public const string PLAN_EXPORT_DIRECTORY = "planExportDirectory";
        public const string SCRIPT_EXPORT_DIRECTORY = "scriptExportDirectory";
        public const string RESULT_EXPORT_DIRECTORY = "resultExportDirectory";
     }
}
