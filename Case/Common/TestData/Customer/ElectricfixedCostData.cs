using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class ElectricfixedCostData : TestDataBase<ElectricfixedCostInputData, ExpectedTestDataBase>
    {
    }

    public class ElectricfixedCostInputData : InputTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string EffectiveDate { get; set; }
        public string PriceMode { get; set; }
        public string Price { get; set; }

        public ElectricfixedCostInputData(string[] hierarchyNodePath, string effectiveDate, string priceMode, string price)
        {
            this.HierarchyNodePath = hierarchyNodePath;
            this.EffectiveDate = effectiveDate;
            this.PriceMode = priceMode;
            this.Price = price;
        }
    }
}
