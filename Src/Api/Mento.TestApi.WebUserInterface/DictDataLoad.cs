using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Utility;
using Mento.Framework.Execution;

namespace Mento.TestApi.WebUserInterface
{
    public static class DictDataLoad
    {
        public static Dictionary<string, TypeValue> dictElement = GetLanguageResource.GetLangResource(ExecutionContext.Language);
        //public static Dictionary<string, TypeValue> dictManualElement = XMLHelper.GetManualElementValue();
    }
}
