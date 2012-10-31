using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.ScriptCommon.Library.Functions
{
    public static class FunctionWrapper
    {
        public static Hierarchy hierarchy
        {
            get
            {
                return new Hierarchy();
            }
        }

        public static Tag tag
        {
            get
            {
                return new Tag();
            }
        }

    }
}
