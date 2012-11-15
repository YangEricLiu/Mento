using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Mento.Framework.Attributes
{
    /// <summary>
    /// Summary description for ManualCaseIDAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ManualCaseIDAttribute : PropertyAttribute
    {
        /// <summary>
        /// Construct a ManualCaseIDAttribute, given a manual case id.
        /// </summary>
        /// <param name="manualcaseid">manual case id</param>
        public ManualCaseIDAttribute(string manualcaseid)
            : base(manualcaseid) { }
    }
}
