using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class KPITargetData : TestDataBase<KPITargetInputData, KPITargetExpectedData>
    {
    }
    public class KPITargetInputData : InputTestDataBase
    {
        public string Name { get; set; }
        public int RecordNumber { get; set; }
        public string[] StartTime { get; set; }
        public string[] EndTime { get; set; }

        public KPITargetInputData(string name, int recordNumber, string[] startTime, string[] endTime)
        {
            this.Name = name;
            this.RecordNumber = recordNumber;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }

    public class KPITargetExpectedData : ExpectedTestDataBase
    {
        public string Name { get; set; }
        public string[] LabelText { get; set; }

        public KPITargetExpectedData(string name, string[] labelText)
        {
            this.Name = name;
            this.LabelText = labelText;
        }
    }
}
