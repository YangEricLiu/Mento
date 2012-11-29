using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Mento.Utility;
using System.Configuration;
using Mento.Framework.Constants;
using System.Xml.Linq;

namespace Mento.TestApi.WebUserInterface.Controls
{
    internal static class ControlLocatorRepository
    {
        private const string ELEMENTMAP_RESOURCE_NAME = "Element.ControlLocatorMap.xml";

        private static Dictionary<string, Locator> _LocatorDictionary;
        public static Dictionary<string, Locator> LocatorDictionary
        {
            get
            {
                if (_LocatorDictionary == null)
                {
                    _LocatorDictionary = LocatorMapReader.Read(typeof(ControlLocatorRepository).Assembly, ELEMENTMAP_RESOURCE_NAME);
                }

                return _LocatorDictionary;
            }
        }

        public static Locator GetLocator(string key)
        {
            return LocatorDictionary[key];
        }

    }
}
