using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Mento.Framework.Attributes
{
    /// <summary>
    /// Summary description for Priority Attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class PriorityAttribute : PropertyAttribute
    {
        /// <summary>
        /// Construct a PriorityAttribute, given a priority.
        /// </summary>
        /// <param name="priority">Priority</param>
        public PriorityAttribute(int priority)
            : base(priority) { }
    }
}
