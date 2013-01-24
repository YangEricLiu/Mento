using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class OtherCostData : TestDataBase<OtherCostInputData, ExpectedTestDataBase>
    {
    }

    public class OtherCostInputData : InputTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string EffectiveDate { get; set; }
        public string Price { get; set; }

        public OtherCostInputData(string[] hierarchyNodePath, string effectiveDate, string price)
        {
            this.HierarchyNodePath = hierarchyNodePath;
            this.EffectiveDate = effectiveDate;
            this.Price = price;
        }
    }
}
