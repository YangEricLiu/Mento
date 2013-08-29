using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;
using Mento.ScriptCommon.TestData.Common;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class WorktimeCalendarData : TestDataBase<WorktimeCalendarInputData, WorktimeCalendarExpectedData>
    {
    }
    public class WorktimeCalendarInputData : InputTestDataBase
    {
        public string CommonName { get; set; }
        public TimeRange[] TimeRange { get; set; }

        public WorktimeCalendarInputData(string CommonName, TimeRange[] TimeRange)
        {
            this.CommonName = CommonName;
            this.TimeRange = TimeRange;
        }
    }

    public class WorktimeCalendarExpectedData : ExpectedTestDataBase
    {
        public string CommonName { get; set; }
        public TimeRange[] TimeRange { get; set; }
        public string[] LabelText { get; set; }
        public string PopMessage { get; set; }

        public WorktimeCalendarExpectedData(string CommonName, TimeRange[] TimeRange, string[] labelText, string PopMessage)
        {
            this.CommonName = CommonName;
            this.TimeRange = TimeRange;
            this.LabelText = labelText;
            this.PopMessage = PopMessage;
        }
    }
}
