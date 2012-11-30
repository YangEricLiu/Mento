using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface;
using Mento.Framework.Exceptions;

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
            if (!LocatorDictionary.Keys.Contains(key))
                throw new ApiException(String.Format("The jazz control locator key '{0}' was not found in JazzControlLocatorDictionary.", key));

            return LocatorDictionary[key];
        }
    }
}
