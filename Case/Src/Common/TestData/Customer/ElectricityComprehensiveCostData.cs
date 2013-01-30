using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class ElectricityComprehensiveCostData : TestDataBase<ElectricComprehensiveCostInputData, ExpectedTestDataBase>
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

        public ElectricComprehensiveCostInputData(string[] hierarchyNodePath, string effectiveDate, string priceMode, string demandCostType, string hourTagId, string electricHourPrice, string transformerCapacity, string transformerPrice, string touTariffId, string factorType, string realTagId, string reactiveTagId, string electricPaddingCost)
        {
            this.HierarchyNodePath = hierarchyNodePath;
            this.EffectiveDate = effectiveDate;
            this.PriceMode = priceMode;
            this.DemandCostType = demandCostType;
            this.HourTagId = hourTagId;
            this.ElectricHourPrice = electricHourPrice;
            this.TransformerCapacity = transformerCapacity;
            this.TransformerPrice = transformerPrice;
            this.TouTariffId = touTariffId;
            this.FactorType = factorType;
            this.RealTagId = realTagId;
            this.ReactiveTagId = reactiveTagId;
            this.ElectricPaddingCost = electricPaddingCost;
        }
    }
}
