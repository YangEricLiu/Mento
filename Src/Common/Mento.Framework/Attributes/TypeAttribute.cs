using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Mento.Framework.Attributes
{
    /// <summary>
    /// Summary description for Type Attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class TypeAttribute : PropertyAttribute
    {
        /// <summary>
        /// Construct a TypeAttribute, given a type.
        /// </summary>
        /// <param name="type">Case type</param>
        public TypeAttribute(ScriptType type)
            : base(type) { }
    }

    public enum ScriptType
    {
        /// <summary>
        /// Smoke test
        /// </summary>
        BVT = 1,

        /// <summary>
        /// Function test
        /// </summary>
        BFT = 2,
    }
}
