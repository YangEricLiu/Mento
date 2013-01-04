using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class WorkdayCalendarData : TestDataBase<WorkdayCalendarInputData, WorkdayCalendarExpectedData>
    {
    }
    public class WorkdayCalendarInputData : InputTestDataBase
    {
        public string Name { get; set; }
        public string SpecialDateType { get; set; }

        public WorkdayCalendarInputData(string name, string specialDateType)
        {
            this.Name = name;
        }
    }

    public class WorkdayCalendarExpectedData : ExpectedTestDataBase
    {
        public string Name { get; set; }
        public string SpecialDateType { get; set; }

        public WorkdayCalendarExpectedData(string name, string specialDateType)
        {
            this.Name = name;
        }
    }
}
