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

        //public const string ELEMENTMANUALMAP_PATH = @"D:\Schneider\Mento\Trunk\Src\Common\Mento.Utility\appObject\ManualElementMap.xml";
        //public const string ELEMENTMANUALMAP_MODULE_NAME = "Locator";

        public const string LANGUAGE_CN_PATH = "languageResourcePath_CN";
        public const string LANGUAGE_EN_PATH = "languageResourcePath_EN";
        public const string COMBOBOX_ITEM_PATH = "comboBoxItemResourcePath";

        public const string FIREFOX_LOCATION = "firefoxLocation";

        public const string COMBOPATH = @"D:\Mento\Trunk\Case\Host\ScriptHost\Config\ComboBoxItemList-CN.xml";
        public const string COMBOMODULE = "ItemList";

        public const string EXECUTION_CONFIGURATION = "executionConfiguration";
        public const string EXPORT_LOCATION_CONFIGURATION = "exportLocationConfiguration";

        public const string ASSEMBLY_INITIALIZE_DATABASE = "assemblyInitializeDatabase";

     }
}
