using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Execution;
using Mento.Framework;
using Mento.Utility;
using Mento.Framework.Constants;

namespace Mento.TestApi.WebUserInterface
{
    public class GetLanguageResource
    {
        public static Dictionary<string, TypeValue> GetLangResource(Language lang)
        { 
            switch (lang)
            {
                case Language.CN: return XMLHelper.GetElementMapValue(ConfigurationKey.CN_PATH);
                case Language.EN: return XMLHelper.GetElementMapValue(ConfigurationKey.EN_PATH);
                default: return null; 
            }
            
        }
    }
}
