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
        public TimeRange[] ColdWarmRange { get; set; }

        public HeatingCoolingSeasonCalendarInputData(string CommonName, TimeRange[] ColdWarmRange)
        {
            this.CommonName = CommonName;
            this.ColdWarmRange = ColdWarmRange;
        }
    }

    public class HeatingCoolingSeasonCalendarExpectedData : ExpectedTestDataBase
    {
        public string CommonName { get; set; }
        public TimeRange[] ColdWarmRange { get; set; }
        public string[] LabelText { get; set; }
        public string PopMessage { get; set; }

        public HeatingCoolingSeasonCalendarExpectedData(string CommonName, TimeRange[] ColdWarmRange, string[] labelText, string PopMessage)
        {
            this.CommonName = CommonName;
            this.ColdWarmRange = ColdWarmRange;
            this.LabelText = labelText;
            this.PopMessage = PopMessage;
        }
    }
}
