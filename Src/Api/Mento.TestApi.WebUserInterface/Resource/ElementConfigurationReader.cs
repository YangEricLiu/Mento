using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Mento.Framework.Constants;
using Mento.Utility;
using Mento.Framework;
using System.Configuration;

namespace Mento.TestApi.WebUserInterface
{
    public static class ElementConfigurationReader
    {
        private static Dictionary<string, Locator> GetValueFromXML(string fileName, string moduleName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlNode xn = doc.SelectSingleNode(moduleName);

            XmlNodeList xnl = xn.ChildNodes;

            Dictionary<string, Locator> elementMap = new Dictionary<string, Locator>();

            foreach (XmlNode xn1 in xnl)
            {
                if (xn1 is XmlElement)
                {
                    XmlElement xe = (XmlElement)xn1;
                    Locator tmp = new Locator();

                    tmp.Value = xe.GetAttribute("value").ToString();
                    tmp.Type = EnumHelper.StringToEnum<ByType>(xe.GetAttribute("type").ToString());

                    elementMap.Add(xe.GetAttribute("key").ToString(), tmp);
                }
            }

            return elementMap;
        }

        public static Dictionary<string, Locator> GetElementMapValue(string languageFilePath)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            Dictionary<string, Locator> localValue = new Dictionary<string, Locator>();
            Dictionary<string, Locator> finalValue = new Dictionary<string, Locator>();

            string elementMapPath = PathHelper.GetAppAbsolutePath(ConfigurationManager.AppSettings[ConfigurationKey.ELEMENTMAP_PATH]);

            localValue = GetValueFromXML(elementMapPath, ConfigurationKey.ELEMENTMAP_MODULE_NAME);
            dict = LanguageResourceReader.GetFormatKeyValue(@languageFilePath);

            foreach (string key in localValue.Keys)
            {
                Locator newValue = localValue[key];

                foreach (string newKey in dict.Keys)
                {
                    if (newValue.Value.Contains(newKey))
                    {
                        newValue.Value = newValue.Value.Replace(newKey, dict[newKey]);
                    }
                }

                finalValue.Add(key, newValue);
            }

            return finalValue;
        }

        /*
        public static Dictionary<string, TypeValue> GetManualElementValue()
        {
            return GetValueFromXML(ConfigurationKey.ELEMENTMANUALMAP_PATH, ConfigurationKey.ELEMENTMANUALMAP_MODULE_NAME);
        }
        */
    }
}
