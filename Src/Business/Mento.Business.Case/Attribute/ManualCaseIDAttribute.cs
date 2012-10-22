using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Business.Script.Attribute
{
    /// <summary>
    /// Summary description for ManualCaseIDAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ManualCaseIDAttribute : PropertyAttribute
    {
        /// <summary>
        /// Construct a MaxTimeAttribute, given a time in milliseconds.
        /// </summary>
        /// <param name="milliseconds">The maximum elapsed time in milliseconds</param>
        public ManualCaseIDAttribute(string manualcaseid)
            : base(manualcaseid) { }
    }
}
