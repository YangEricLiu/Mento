using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Execution;

namespace Mento.Framework.Script
{
    /// <summary>
    /// Test suite base abstract class
    /// </summary>
    public abstract class TestSuiteBase
    {
        static TestSuiteBase()
        {
            ExecutionContext.Browser = Browser.Chrome;

            ExecutionContext.Language = Language.CN;

            ExecutionContext.Url = "https://223.4.20.20/0.5/Web/";
        }
    }
}
