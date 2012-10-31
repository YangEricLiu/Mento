using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Execution;
using Mento.Framework;
using Mento.Utility;
using Mento.Framework.Constants;
using System.Configuration;

namespace Mento.TestApi.WebUserInterface
{
    public class ResourceManager
    {
        private static Dictionary<string, Locator> _elementDictionary;

        /// <summary>
        /// Get and cache the element dictionary from element configuration xml
        /// </summary>
        /// <returns>The element dictionary</returns>
        public static Dictionary<string, Locator> GetElementDictionary()
        {
            if (_elementDictionary == null)
            {
                if (ExecutionContext.Language.HasValue)
                {
                    string languageFilePath = String.Empty;
                    switch (ExecutionContext.Language.Value)
                    {
                        case Language.CN:
                            languageFilePath = ConfigurationManager.AppSettings[ConfigurationKey.LANGUAGE_CN_PATH];
                            break;
                        case Language.EN:
                            languageFilePath = ConfigurationManager.AppSettings[ConfigurationKey.LANGUAGE_EN_PATH];
                            break;
                        default:
                            break;
                    }

                    _elementDictionary = String.IsNullOrEmpty(languageFilePath) ? null : ElementConfigurationReader.GetElementMapValue(languageFilePath);
                }
            }

            return _elementDictionary;
        }
    }
}
