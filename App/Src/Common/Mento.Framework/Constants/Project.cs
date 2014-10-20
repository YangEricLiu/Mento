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

        public static string LocalizationStringResourceName = "string.js";

        public static string LocalizationDatabaseResourceName = "DB.resx";
        public static string LocalizationAppResourceName = "App.resx";

        public static string LocalizationExtResourceName = "ext-lang.js";

        /// <summary>
        /// $#
        /// </summary>
        public static string VariablePrefix = String.Format("{0}{1}", ASCII.DOLLAR, ASCII.OCTOTHORPE);

        /// <summary>
        /// $@
        /// </summary>
        public static string LanguagePrefix = String.Format("{0}{1}", ASCII.DOLLAR, ASCII.AT);
    }
}
