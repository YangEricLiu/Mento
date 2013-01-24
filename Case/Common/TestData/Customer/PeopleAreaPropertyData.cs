using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class PeopleAreaPropertyData : TestDataBase<PeopleAreaPropertyInputData, ExpectedTestDataBase>
    {
    }

    public class PeopleAreaPropertyInputData : InputTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string TotalArea { get; set; }
        public string HeatingArea { get; set; }
        public string CoolingArea { get; set; }
        public string PeopleEffectiveDate { get; set; }
        public string PeopleNumber { get; set; }

        public PeopleAreaPropertyInputData(string[] hierarchyNodePath, string totalArea, string heatingArea, string coolingArea, string peopleEffectiveDate, string peopleNumber)
        {
            this.HierarchyNodePath = hierarchyNodePath;
            this.TotalArea = totalArea;
            this.HeatingArea = heatingArea;
            this.CoolingArea = coolingArea;
            this.PeopleEffectiveDate = peopleEffectiveDate;
            this.PeopleNumber = peopleNumber;
        }
    }
}
