using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class VEEData : TestDataBase<VEEInputData, VEEExpectedData>
    {
    }
    public class VEEInputData : InputTestDataBase
    {
        public string[] CommonNameArray { get; set; }
        public string OriginalName { get; set; }
        public string CommonName { get; set; }
        public string SpikeGT { get; set; }
        public string SpikeLT { get; set; }
        public string Special { get; set; }
        public string ScanInterval { get; set; }
        public string[] ScanIntervalArray { get; set; }
        public string ScanDelay { get; set; }
        public string[] ScanDelayArray { get; set; }
        public string[] VEERules { get; set; }
        public string ScanText { get; set; }        
        public ManualTimeRange ManualTimeRange { get; set; }
    }

    public class VEEExpectedData : ExpectedTestDataBase
    {
        public string[] CommonNameArray { get; set; }
        public string OriginalName { get; set; }
        public string CommonName { get; set; }
        public string SpikeGT { get; set; }
        public string SpikeLT { get; set; }
        public string Special { get; set; }
        public string ScanInterval { get; set; }
        public string[] ScanIntervalArray { get; set; }
        public string ScanDelay { get; set; }
        public string[] ScanDelayArray { get; set; }
        public string ScanText { get; set; }
        public ManualTimeRange[] ManualTimeRange { get; set; }
    }
}
