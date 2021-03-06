﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Framework.Log
{
    public class ScriptLog : LogBase
    {
        private const string LOGGERKEY = "Script";

        private ScriptLog() : base(LOGGERKEY) { }

        private static ILog _instance;
        public static ILog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ScriptLog();
                }
                return _instance;
            }
        }
    }
}
