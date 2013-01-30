using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Mento.Framework.Attributes
{
    /// <summary>
    /// Summary description for CaseIDAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CaseIDAttribute : PropertyAttribute
    {
        /// <summary>
        /// Construct a CaseIDAttribute, given a case ID.
        /// </summary>
        /// <param name="caseid">Case ID string</param>
        public CaseIDAttribute(string caseid)
            : base(caseid) { }
    }
}
