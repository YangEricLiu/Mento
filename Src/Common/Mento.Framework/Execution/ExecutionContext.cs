using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Framework.Execution
{
    public static class ExecutionContext
    {
        public static Browser? Browser { get; set; }
        public static Language? Language { get; set; }
        public static string Url { get; set; }
    }
}