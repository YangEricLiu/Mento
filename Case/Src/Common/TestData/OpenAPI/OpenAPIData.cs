using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;

namespace Mento.ScriptCommon.TestData.OpenAPI
{
    public class OpenAPIData : TestDataBase<OpenAPIInput, OpenAPIOutput>
    {
    }

    public class OpenAPIInput : InputTestDataBase
    {
        public string url { get; set; }

        //public string RequestBody { get; set; }

        //public string TestCasePath { get; set; }

        //public string CaseResultPath { get; set; }

        public string SheetName { get; set; }

        public string FailedFileName { get; set; }
    }

    public class OpenAPIOutput : ExpectedTestDataBase
    {
        public string ExpectedFileName { get; set; }
    }

}
