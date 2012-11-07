using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// Reference to Jazz function attitude.
    /// </summary
    public static class FunctionWrapper
    {
        private static Hierarchy _hierarchy;
        /// <summary>
        /// Hierarchy function property
        /// </summary>
        public static Hierarchy Hierarchy
        {
            get
            {
                if (_hierarchy == null)
                {
                    _hierarchy = new Hierarchy();
                }
                return _hierarchy;
            }
        }

        private static Tag _tag;
        /// <summary>
        /// Tag function property
        /// </summary>
        public static Tag Tag
        {
            get
            {
                if (_tag == null)
                {
                    _tag = new Tag();
                }
                return _tag;
            }
        }

        private static LoginFunction _login;
        /// <summary>
        /// Login function property
        /// </summary>
        public static LoginFunction Login
        {
            get
            {
                if (_login == null)
                {
                    _login = new LoginFunction();
                }
                return _login;
            }
        }

    }
}
