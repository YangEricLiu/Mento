using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Mento.Framework.Attributes
{
    /// <summary>
    /// Summary description for CreateTimeAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class CreateTimeAttribute : PropertyAttribute
    {
        /// <summary>
        /// Construct a CreateTimeAttribute, given a create time.
        /// </summary>
        /// <param name="createtime">Case create time</param>
        public CreateTimeAttribute(string createtime)
            : base(createtime) { }
    }
}
