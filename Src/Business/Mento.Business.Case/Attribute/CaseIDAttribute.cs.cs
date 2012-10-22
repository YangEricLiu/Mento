﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Business.Script.Attribute
{

        /// <summary>
        /// Summary description for CaseIDAttribute.
        /// </summary>
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
        public class CaseIDAttribute : PropertyAttribute
        {
            /// <summary>
            /// Construct a MaxTimeAttribute, given a time in milliseconds.
            /// </summary>
            /// <param name="milliseconds">The maximum elapsed time in milliseconds</param>
            public CaseIDAttribute(string caseid)
                : base(caseid) { }
        }
    
}
