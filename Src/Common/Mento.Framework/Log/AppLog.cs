using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Framework.Log
{
    public class AppLog : LogBase
    {
        private const string LOGGERKEY = "App";

        private AppLog() : base(LOGGERKEY) { }

        private static ILog _instance;
        public static ILog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppLog();
                }
                return _instance;
            }
        }
    }
}
