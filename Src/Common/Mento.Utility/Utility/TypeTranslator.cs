using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Utility
{
    public class TypeTranslator
    {
        public static ByType StringToEnum(string sourceString)
        {
            ByType typeValue;

            typeValue = (ByType)System.Enum.Parse(typeof(ByType), sourceString, false);

            return typeValue;
        }
    }
}
