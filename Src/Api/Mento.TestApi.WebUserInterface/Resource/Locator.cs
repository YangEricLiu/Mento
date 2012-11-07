using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface
{
    /// <summary>
    /// Element locator string and location type
    /// </summary>
    public class Locator
    {
        /// <value>Value is element locator string</value>
        public string Value { get; set; }
        /// <value>Type is element location type, which is enumeration</value>
        public ByType Type { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Locator()
        { 
        }

        /// <summary>
        /// Another consturctor which initialize the 2 values
        /// </summary>
        /// <param name="value">Element locator string</param>
        /// <param name="byType">Element location type</param>
        public Locator(string value,ByType byType)
        {
            Value = value;
            Type = byType;
        }
    }
}
