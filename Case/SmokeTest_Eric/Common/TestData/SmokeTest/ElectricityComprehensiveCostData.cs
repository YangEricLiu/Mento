using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.SmokeTest
{
    public class ElectricityComprehensiveCostData : TestDataBase<ElectricComprehensiveCostInputData, ElectricComprehensiveCostExpectedData>
    {
    }

    public class ElectricComprehensiveCostInputData : InputTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string EffectiveDate { get; set; }
        public string PriceMode { get; set; }
        public string DemandCostType { get; set; }
        public string HourTagId { get; set; }
        public string ElectricHourPrice { get; set; }
        public string TransformerCapacity { get; set; }
        public string TransformerPrice { get; set; }
        public string TouTariffId { get; set; }
        public string FactorType { get; set; }
        public string RealTagId { get; set; }
        public string ReactiveTagId { get; set; }
        public string ElectricPaddingCost { get; set; }
    }

    public class ElectricComprehensiveCostExpectedData : ExpectedTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string EffectiveDate { get; set; }
        public string PriceMode { get; set; }
        public string DemandCostType { get; set; }
        public string HourTagId { get; set; }
        public string ElectricHourPrice { get; set; }
        public string TransformerCapacity { get; set; }
        public string TransformerPrice { get; set; }
        public string TouTariffId { get; set; }
        public string FactorType { get; set; }
        public string RealTagId { get; set; }
        public string ReactiveTagId { get; set; }
        public string ElectricPaddingCost { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}
