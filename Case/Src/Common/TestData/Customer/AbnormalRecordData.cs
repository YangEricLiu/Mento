using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class AbnormalRecordData : TestDataBase<AbnormalInputData, AbnormalExpectedData>
    {
    }
    public class AbnormalInputData : InputTestDataBase
    {
        public string[] TagNames { get; set; }
        public string RuleSet { get; set; }
        public string DataType { get; set; }
        public string Interval { get; set; }
        public string[] CommonNameArray { get; set; }
        public string Channel { get; set; }
        public string CalculationType { get; set; }
        public string Comments { get; set; }
        public string AccumulateText { get; set; }        
        public ManualTimeRange[] ManualTimeRange { get; set; }
        public int[] RowID { get; set; }
        public string[] TestData { get; set; }
        public string[] Uoms { get; set; }

    }

    public class AbnormalExpectedData : ExpectedTestDataBase
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
        public string Message { get; set; }
        public string[] MessageArray { get; set; }
        public string AccumulateText { get; set; }
    }

    //public class ManualTimeRange
    //{
    //    public string StartDate;
    //    public string StartTime;
    //    public string EndDate;
    //    public string EndTime;
    //}


}
