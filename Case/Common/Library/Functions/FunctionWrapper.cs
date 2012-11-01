using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.ScriptCommon.Library.Functions
{
    public static class FunctionWrapper
    {
        private static Hierarchy _hierarchy;
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
