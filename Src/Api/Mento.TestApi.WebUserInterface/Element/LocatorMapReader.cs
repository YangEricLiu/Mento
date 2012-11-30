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

            var query = from element in xdoc.Element(ELEMENTMAP_MODULE_NAME).XPathSelectElements("//"+ELEMENTMAP_ELEMENT_NAME)
                        select new KeyValuePair<string, Locator>(
                            element.Attribute("key").Value,
                            new Locator(
                                //need to find out all resource variables
                                LanguageResourceRepository.ReplaceLanguageVariables(element.Attribute("value").Value),
                                EnumHelper.StringToEnum<ByType>(element.Attribute("type").Value)
                            )
                        );

            return query.ToDictionary(item => item.Key, item => item.Value);
        }

    }
}
