using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class DayNightCalendarData : TestDataBase<DayNightCalendarInputData, DayNightCalendarExpectedData>
    {
    }
    public class DayNightCalendarInputData : InputTestDataBase
    {
        public string Name { get; set; }
        public int RecordNumber { get; set; }
        public string[] StartTime { get; set; }
        public string[] EndTime { get; set; }

        public DayNightCalendarInputData(string name, int recordNumber, string[] startTime, string[] endTime)
        {
            this.Name = name;
            this.RecordNumber = recordNumber;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }

    public class DayNightCalendarExpectedData : ExpectedTestDataBase
    {
        public string Name { get; set; }
        public string[] LabelText { get; set; }

        public DayNightCalendarExpectedData(string name, string[] labelText)
        {
            this.Name = name;
            this.LabelText = labelText;
        }
    }
}
