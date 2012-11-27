using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Framework.Constants
{
    /// <summary>
    /// Script namespace prefix
    /// </summary>
    public static class Project
    {
        /// <summary>
        /// Script namespace prefix
        /// </summary>
        public const string SCRIPTNAMESPACEPREFIX = "Mento.Script";

        /// <summary>
        /// 
        /// </summary>
        public const string EXECUTIONTEMPCONFIGNAME = @"temp\executioncontext.xml";

        /// <summary>
        /// $#
        /// </summary>
        public static string VARIABLEPREFIX = String.Format("{0}{1}", ASCII.DOLLAR, ASCII.OCTOTHORPE);

        /// <summary>
        /// $@
        /// </summary>
        public static string LANGUAGEPREFIX = String.Format("{0}{1}", ASCII.DOLLAR, ASCII.AT);
    }
}
