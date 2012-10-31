using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Mento.Utility
{
    public static class PathHelper
    {
        public static string GetAppAbsolutePath(string relativePath)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
        }
    }
}
