using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;
using Mento.ScriptCommon.TestData.Common;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class WorkdayCalendarData : TestDataBase<WorkdayCalendarInputData, WorkdayCalendarExpectedData>
    {
    }
    public class WorkdayCalendarInputData : InputTestDataBase
    {
        public string CommonName { get; set; }
        public TimeRange[] SpecialDate { get; set; }

        public WorkdayCalendarInputData(string CommonName, TimeRange[] SpecialDate)
        {
            this.CommonName = CommonName;
            this.SpecialDate = SpecialDate;
        }
    }

    public class WorkdayCalendarExpectedData : ExpectedTestDataBase
    {
        public string CommonName { get; set; }
        public TimeRange[] SpecialDate { get; set; }
        public string[] LabelText { get; set; }
        public string[] PopMessage { get; set; }

        public WorkdayCalendarExpectedData(string CommonName, TimeRange[] SpecialDate, string[] labelText, string[] PopMessage)
        {
            this.CommonName = CommonName;            
            this.SpecialDate = SpecialDate;
            this.LabelText = labelText;
            this.PopMessage = PopMessage;
        }
    }
}
