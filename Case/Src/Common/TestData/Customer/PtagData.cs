using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class PtagData : TestDataBase<PtagInputData, PtagExpectedData>
    {
    }
    public class PtagInputData : InputTestDataBase
    {
        public string CommonName { get; set; }
        public string Code { get; set; }
        public string Meter { get; set; }
        public string Channel { get; set; }
        public string Commodity { get; set; }
        public string Uom { get; set; }
        public string CalculationType { get; set; }
        public string Comments { get; set; }
    }

    public class PtagExpectedData : ExpectedTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string CommonName { get; set; }
        public string Code { get; set; }
        public string Meter { get; set; }
        public string Channel { get; set; }
        public string Commodity { get; set; }
        public string Uom { get; set; }
        public string CalculationType { get; set; }
        public string Comments { get; set; }
    }
}
