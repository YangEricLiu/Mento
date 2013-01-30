using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Framework.Attributes
{
    /// <summary>
    /// Summary description for ParameterAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class ParameterAttribute : Attribute
    {
        /// <summary>
        /// Short name of a parameter
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Construct a ParameterAttribute.
        /// </summary>
        public ParameterAttribute()
        { 
        }
    }
}
