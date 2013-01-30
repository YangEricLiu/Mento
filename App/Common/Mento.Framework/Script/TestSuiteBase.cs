using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Execution;
using Mento.Framework.Constants;
using Mento.Framework.Configuration;
using System.IO;
using Mento.Framework.Log;

namespace Mento.Framework.Script
{
    /// <summary>
    /// Test suite base abstract class
    /// </summary>
    public abstract class TestSuiteBase
    {
        static TestSuiteBase()
        {
            //Amy comment: if running case in R1.0, below relevant clause needs to be commented out, and replace with another one.
            //ExecutionContext.Url = "https://223.4.20.20/0.5/Web/";
            ////ExecutionContext.Url = "https://10.177.0.36/Web/";
          
        }

        protected ILog Logger = ScriptLog.Instance;
    }
}
