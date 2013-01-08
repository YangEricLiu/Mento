using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class WorktimeCalendarData : TestDataBase<WorktimeCalendarInputData, WorktimeCalendarExpectedData>
    {
    }
    public class WorktimeCalendarInputData : InputTestDataBase
    {
        public string Name { get; set; }
        public int[] RecordGroupPosition { get; set; }
        public string[] StartTime { get; set; }
        public string[] EndTime { get; set; }
        
        public WorktimeCalendarInputData(string name, int[] recordGroupPosition, string[] startTime, string[] endTime)
        {
            this.Name = name;
            this.RecordGroupPosition = recordGroupPosition;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }

    public class WorktimeCalendarExpectedData : ExpectedTestDataBase
    {
        public string Name { get; set; }
        public int[] RecordGroupPosition { get; set; }
        public string[] StartTime { get; set; }
        public string[] EndTime { get; set; }
        
        public WorktimeCalendarExpectedData(string name, int[] recordGroupPosition, string[] startTime, string[] endTime)
        {
            this.Name = name;
            this.RecordGroupPosition = recordGroupPosition;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }
}
