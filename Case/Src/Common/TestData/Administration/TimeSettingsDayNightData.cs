using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;
using Mento.ScriptCommon.TestData.Common;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class DayNightCalendarData : TestDataBase<DayNightCalendarInputData, DayNightCalendarExpectedData>
    {
    }
    public class DayNightCalendarInputData : InputTestDataBase
    {
        public string CommonName { get; set; }
        public TimeRange[] TimeRange { get; set; }

        public DayNightCalendarInputData(string CommonName, TimeRange[] TimeRange)
        {
            this.CommonName = CommonName;
            this.TimeRange = TimeRange;
        }
    }

    public class DayNightCalendarExpectedData : ExpectedTestDataBase
    {
        public string CommonName { get; set; }
        public TimeRange[] TimeRange { get; set; }
        public string[] LabelText { get; set; }
        public string PopMessage { get; set; }

        public DayNightCalendarExpectedData(string CommonName, TimeRange[] TimeRange, string[] labelText, string PopMessage)
        {
            this.CommonName = CommonName;
            this.TimeRange = TimeRange;
            this.LabelText = labelText;
            this.PopMessage = PopMessage;

        }
    }
}
