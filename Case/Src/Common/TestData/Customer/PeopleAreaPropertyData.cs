using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class PeopleAreaPropertyData : TestDataBase<PeopleAreaPropertyInputData, PeopleAreaPropertyExpectedData>
    {
    }

    public class PeopleAreaPropertyInputData : InputTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string PeopleItemNumber { get; set; }
        public string TotalArea { get; set; }
        public string HeatingArea { get; set; }
        public string CoolingArea { get; set; }
        public string PeopleEffectiveDate { get; set; }
        public string PeopleNumber { get; set; }
        public string IntegerValue { get; set; }
    }

    public class PeopleAreaPropertyExpectedData : ExpectedTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string PeopleItemNumber { get; set; }
        public string TotalArea { get; set; }
        public string HeatingArea { get; set; }
        public string CoolingArea { get; set; }
        public string PeopleEffectiveDate { get; set; }
        public string PeopleNumber { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string IntegerValue { get; set; }
    }
}
