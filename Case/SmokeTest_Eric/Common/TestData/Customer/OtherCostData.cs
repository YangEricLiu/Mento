using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class OtherCostData : TestDataBase<OtherCostInputData, OtherCostExpectedData>
    {
    }

    public class OtherCostInputData : InputTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string EffectiveDate { get; set; }
        public string Price { get; set; }
    }

    public class OtherCostExpectedData : ExpectedTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string EffectiveDate { get; set; }
        public string Price { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}
