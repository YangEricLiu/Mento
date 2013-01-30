using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml.Linq;
using Mento.Utility;
using System.IO;
using System.Xml.XPath;
using System.Text.RegularExpressions;
using Mento.Framework.Constants;
using Mento.Framework.Exceptions;

namespace Mento.TestApi.WebUserInterface
{
    public static class LocatorMapReader
    {
        public static Dictionary<string, Locator> Read(Assembly resourceAssembly,string resourceName)
        {
            return ReadXml(ReflectionHelper.GetEmbeddedResource(resourceAssembly, resourceName));
        }

        public static Dictionary<string, Locator> Read(string fileName)
        {
            return ReadXml(new FileStream(fileName, FileMode.Open));
        }

        private static Dictionary<string, Locator> ReadXml(Stream stream)
        {
            const string ELEMENTMAP_MODULE_NAME = "WebElement";
            const string ELEMENTMAP_ELEMENT_NAME = "add";

            XDocument xdoc = XDocument.Load(stream);

            Dictionary<string, Locator> dict = new Dictionary<string, Locator>();

            foreach (var element in xdoc.Element(ELEMENTMAP_MODULE_NAME).XPathSelectElements("//" + ELEMENTMAP_ELEMENT_NAME))
            {
                if (element.Attribute("key") == null || element.Attribute("value") == null || element.Attribute("type") == null)
                {
                    throw new ApiException(String.Format("Missing locator key, value or xpath attribute in locator map. source xml: {0}", element.ToString()));
                }
                if (String.IsNullOrEmpty(element.Attribute("key").Value) || String.IsNullOrEmpty(element.Attribute("value").Value) || String.IsNullOrEmpty(element.Attribute("type").Value))
                {
                    throw new ApiException(String.Format("Empty key, value or xpath in locator map. source xml: {0}", element.ToString()));
                }
                if (dict.ContainsKey(element.Attribute("key").Value))
                {
                    throw new ApiException(String.Format("Locator key already exists: {0}.", element.Attribute("key").Value));
                }

                dict.Add(element.Attribute("key").Value, new Locator(
                    //need to find out all resource variables
                    LanguageResourceRepository.ReplaceLanguageVariables(element.Attribute("value").Value),
                    EnumHelper.StringToEnum<ByType>(element.Attribute("type").Value)
                ));
            }

            return dict;
        }
    }
}
