using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Utility
{
    public class TypeTranslator
    {
        public static byType StringToEnum(string sourceString)
        {
            byType typeValue;

            typeValue = (byType)System.Enum.Parse(typeof(byType), sourceString, false);

            return typeValue;
        }
    }
}
