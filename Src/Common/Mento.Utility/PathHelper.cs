using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Mento.Utility
{
    /// <summary>
    /// The path helper class.
    /// </summary>
    public static class PathHelper
    {
        /// <summary>
        /// Get the absolute path from relative path of APP
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <returns>The absolute path string</returns>
        public static string GetAppAbsolutePath(string relativePath)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
        }

    }
}
