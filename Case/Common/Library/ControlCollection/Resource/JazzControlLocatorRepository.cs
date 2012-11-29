using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public static class JazzControlLocatorRepository
    {
        private const string CONTROL_LOCATOR_MAP_RESOURCE_NAME = "ControlCollection.Resource.JazzControlLocatorMap.xml";

        private static Dictionary<string, Locator> _LocatorDictionary;
        public static Dictionary<string, Locator> LocatorDictionary
        {
            get 
            {
                if (_LocatorDictionary == null)
                {
                    _LocatorDictionary = LocatorMapReader.Read(typeof(JazzControlLocatorRepository).Assembly, CONTROL_LOCATOR_MAP_RESOURCE_NAME);
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
