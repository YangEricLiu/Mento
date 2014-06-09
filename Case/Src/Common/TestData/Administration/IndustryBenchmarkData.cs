using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class IndustryBenchmarkData : TestDataBase<BenchMarkInputData, BenchMarkExpectedData>
    {
    }

    public class BenchMarkInputData : InputTestDataBase
     {
         public string Industry { get; set; }
         public string[] ClimaticRegions { get; set; }
         public string[] Industrys { get; set; }
     }

    public class BenchMarkExpectedData : ExpectedTestDataBase
     {
         public string Industry { get; set; }
         public string[] ClimaticRegions { get; set; }
         public string[] Industrys { get; set; }
         public string[] InvalidMessage { get; set; }
     }
}
