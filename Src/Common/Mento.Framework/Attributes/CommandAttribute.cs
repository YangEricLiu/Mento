using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Framework.Attributes
{
    /// <summary>
    /// Summary description for CommandAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CommandAttribute:Attribute
    {
        /// <summary>
        /// Real name of the command
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Construct a CommandAttribute.
        /// </summary>
        public CommandAttribute()
        { 
        }
    }
}
