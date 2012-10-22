using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Utility.Utility
{
    public class TypeTranslator
    {
        public static elementType StringToEnum(string sourceString)
        {
            elementType typeValue;

            typeValue = (elementType)System.Enum.Parse(typeof(elementType), sourceString, false);

            return typeValue;
        }
    }
}
