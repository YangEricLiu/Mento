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
        public ManualTimeRange[] ManualTimeRange { get; set; }
        public string[] TestData { get; set; }
        public string[] Uoms { get; set; }
        public string[] AbnormalTypes { get; set; }
        public string[] Comments { get; set; }
    }

    public class AbnormalExpectedData : ExpectedTestDataBase
    {
        public string[] Messages { get; set; }
    }



}
