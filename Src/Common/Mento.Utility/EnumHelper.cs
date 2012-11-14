using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Utility
{
    /// <summary>
    /// Enumeration help
    /// </summary>
    public class EnumHelper 
    {
        /// <summary>
        /// Convert string to the specific enumeration
        /// </summary>
        /// <param name="sourceString">The string which will convert to specific enumeration</param>
        /// <returns></returns>
        public static T StringToEnum<T>(string sourceString)
        {
            return (T)System.Enum.Parse(typeof(T), sourceString, false);
        }
    }
}
