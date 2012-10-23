using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Mento.Business.Script.Attribute
{
    /// <summary>
    /// Summary description for CaseIDAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CreateTimeAttribute : PropertyAttribute
    {
        /// <summary>
        /// Construct a MaxTimeAttribute, given a time in milliseconds.
        /// </summary>
        /// <param name="milliseconds">The maximum elapsed time in milliseconds</param>
        public CreateTimeAttribute(string createtime)
            : base(createtime) { }
    }
}
