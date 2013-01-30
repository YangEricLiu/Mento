using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Mento.Utility;
using System.Configuration;
using Mento.Framework.Constants;
using System.Xml.Linq;
using Mento.Framework.Exceptions;

namespace Mento.TestApi.WebUserInterface.Controls
{
    internal static class ControlLocatorRepository
    {
        private const string ELEMENTMAP_RESOURCE_NAME = "Controls.ControlLocatorMap.xml";

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
            if (!LocatorDictionary.Keys.Contains(key))
                throw new ApiException(String.Format("The locator key '{0}' was not found in ControlLocatorDictionary.", key));

            return LocatorDictionary[key];
        }

    }
}
