using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using Mento.Framework.Constants;

namespace Mento.Utility
{
    public class XMLHelper
    {
        private static Dictionary<string, TypeValue> GetValueFromXML(string fileName, string moduleName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlNode xn = doc.SelectSingleNode(moduleName);

            XmlNodeList xnl = xn.ChildNodes;

            Dictionary<string, TypeValue> elementMap = new Dictionary<string, TypeValue>();

            foreach (XmlNode xn1 in xnl)
            {
                if (xn1 is XmlElement)
                {
                    XmlElement xe = (XmlElement)xn1;
                    TypeValue tmp = new TypeValue();

                    tmp.value = xe.GetAttribute("value").ToString();
                    tmp.type = TypeTranslator.StringToEnum(xe.GetAttribute("type").ToString());

                    elementMap.Add(xe.GetAttribute("key").ToString(), tmp);
                }
            }

            return elementMap;
        }

        public static Dictionary<string, TypeValue> GetElementMapValue(string languageFilePath)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            Dictionary<string, TypeValue> localValue = new Dictionary<string, TypeValue>();
            Dictionary<string, TypeValue> finalValue = new Dictionary<string, TypeValue>();

            localValue = GetValueFromXML(ConfigurationKey.ELEMENTMAP_PATH, ConfigurationKey.ELEMENTMAP_MODULE_NAME);
            dict = JSHelper.GetFormatKeyValue(@languageFilePath);

            foreach (string key in localValue.Keys)
            {
                TypeValue newValue = localValue[key];

                foreach (string newKey in dict.Keys)
                {
                    if (newValue.value.Contains(newKey))
                    {
                        newValue.value = newValue.value.Replace(newKey, dict[newKey]);
                    }
                }

                finalValue.Add(key, newValue);
            }

            return finalValue;
        }

        public static Dictionary<string, TypeValue> GetManualElementValue()
        {
            return GetValueFromXML(ConfigurationKey.ELEMENTMANUALMAP_PATH, ConfigurationKey.ELEMENTMANUALMAP_MODULE_NAME);
        }

    }
}

