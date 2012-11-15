using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Mento.Framework.Attributes
{
    /// <summary>
    /// Summary description for OwnerAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class OwnerAttribute : PropertyAttribute
    {
        /// <summary>
        /// Construct a OwnerAttribute, given a owner name.
        /// </summary>
        /// <param name="owner">owner name</param>
        public OwnerAttribute(string owner)
            : base(owner) { }
    }
}
