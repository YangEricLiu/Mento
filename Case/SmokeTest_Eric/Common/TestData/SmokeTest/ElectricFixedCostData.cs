using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.SmokeTest
{
    public class ElectricFixedCostData : TestDataBase<ElectricFixedCostInputData, ElectricFixedCostExpectedData>
    {
    }

    public class ElectricFixedCostInputData : InputTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string EffectiveDate { get; set; }
        public string PriceMode { get; set; }
        public string Price { get; set; }
    }

    public class ElectricFixedCostExpectedData : ExpectedTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string EffectiveDate { get; set; }
        public string PriceMode { get; set; }
        public string Price { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}
