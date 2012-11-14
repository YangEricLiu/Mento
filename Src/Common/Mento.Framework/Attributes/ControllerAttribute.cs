using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Framework.Attributes
{
    /// <summary>
    /// Marks that a class contains commands
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ControllerAttribute : Attribute
    {
        /// <summary>
        /// Constructor of ControllerAttribute
        /// </summary>
        public ControllerAttribute()
        {
        }
    }
}
