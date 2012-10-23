using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Framework
{
    /// <summary>
    /// Logging severity.
    /// </summary>
    public enum LoggingSeverity
    {
        /// <summary>
        /// Log nothing.
        /// </summary>
        Off,

        /// <summary>
        /// Log fatal message.
        /// </summary>
        Fatal,

        /// <summary>
        /// Log error message.
        /// </summary>
        Error,

        /// <summary>
        /// Log warning message.
        /// </summary>
        Warning,

        /// <summary>
        /// Log information message.
        /// </summary>
        Information,

        /// <summary>
        /// Log the process of method invoking、input/output arguments、return value.
        /// </summary>
        Debug
    }
}
