using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Mento.Utility;
using System.Configuration;
using Mento.Framework.Constants;
using System.Xml.Linq;

namespace Mento.TestApi.WebUserInterface
{
    public static class LocatorRepository
    {
        private static Dictionary<string, Locator> _LocatorDictionary;
        public static Dictionary<string, Locator> LocatorDictionary
        {
            get
            {
                if (_LocatorDictionary == null)
                {
                    _LocatorDictionary = GetLocatorDictionary();
                }

                return _LocatorDictionary;
            }
        }

        public static Locator GetLocator(string key)
        {
            return LocatorDictionary[key];
        }

        private static Dictionary<string, Locator> GetLocatorDictionary()
        {
            const string ELEMENTMAP_MODULE_NAME = "WebElement";
            const string ELEMENTMAP_ELEMENT_NAME = "WebElement";
            const string ELEMENTMAP_RESOURCE_NAME = "Element.ElementMap.xml";

            XDocument xdoc = XDocument.Load(ReflectionHelper.GetEmbeddedResource(typeof(LocatorRepository).Assembly, ELEMENTMAP_RESOURCE_NAME));

            var query = from element in xdoc.Element(ELEMENTMAP_MODULE_NAME).Elements(ELEMENTMAP_ELEMENT_NAME)
                        select new KeyValuePair<string, Locator>(
                            element.Attribute("key").Value,
                            new Locator(
                                LanguageResourceRepository.GetVariableValue(element.Attribute("value").Value),
                                EnumHelper.StringToEnum<ByType>(element.Attribute("type").Value)
                            )
                        );

            return query.ToDictionary(item=>item.Key,item=>item.Value);
        }
    }
}
