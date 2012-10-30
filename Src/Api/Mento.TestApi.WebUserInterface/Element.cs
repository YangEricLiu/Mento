using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.Framework.Execution;

namespace Mento.TestApi.WebUserInterface
{
    public class Element
    {
        private static Dictionary<string, TypeValue> dictElement = GetLanguageResource.GetLangResource(ExecutionContext.Language);
        //private static Dictionary<string, TypeValue> dictManualElement = XMLHelper.GetManualElementValue();

        public static string LoginName
        {
            get
            {
                return dictElement[ElementKey.LoginName].value;
            }
        }

        public static string LoginPassword
        {
            get
            {
                return dictElement[ElementKey.LoginPassword].value;
            }
        }
    }
}
