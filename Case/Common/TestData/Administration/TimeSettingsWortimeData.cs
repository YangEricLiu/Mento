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
        
        public WorktimeCalendarInputData(string name)
        {
            this.Name = name;
        }
    }

    public class WorktimeCalendarExpectedData : ExpectedTestDataBase
    {
        public string Name { get; set; }
        
        public WorktimeCalendarExpectedData(string name)
        {
            this.Name = name;
        }
    }
}
