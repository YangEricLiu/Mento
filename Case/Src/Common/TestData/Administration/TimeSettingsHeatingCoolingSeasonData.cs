using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;
using Mento.ScriptCommon.TestData.Common;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class HeatingCoolingSeasonCalendarData : TestDataBase<HeatingCoolingSeasonCalendarInputData, HeatingCoolingSeasonCalendarExpectedData>
    {
    }
    public class HeatingCoolingSeasonCalendarInputData : InputTestDataBase
    {
        public string CommonName { get; set; }
        public TimeRange[] WarmRange { get; set; }
        public TimeRange[] ColdRange { get; set; }

        public HeatingCoolingSeasonCalendarInputData(string CommonName, TimeRange[] WarmRange, TimeRange[] ColdRange)
        {
            this.CommonName = CommonName;
            this.WarmRange = WarmRange;
            this.ColdRange = ColdRange;
        }
    }

    public class HeatingCoolingSeasonCalendarExpectedData : ExpectedTestDataBase
    {
        public string CommonName { get; set; }
        public TimeRange[] WarmRange { get; set; }
        public TimeRange[] ColdRange { get; set; }
        public string PopMessage { get; set; }

        public HeatingCoolingSeasonCalendarExpectedData(string CommonName, TimeRange[] WarmRange, TimeRange[] ColdRange, string PopMessage)
        {
            this.CommonName = CommonName;
            this.WarmRange = WarmRange;
            this.ColdRange = ColdRange;
            this.PopMessage = PopMessage;
        }
    }
}
