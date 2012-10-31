using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Utility
{
    public class EnumHelper
    {
        public static T StringToEnum<T>(string sourceString)
        {
            return (T)System.Enum.Parse(typeof(T), sourceString, false);
        }
    }
}
