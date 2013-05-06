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
        public int RecordNumber { get; set; }
        public string[] SpecialDateType { get; set; }
        public string[] StartMonth { get; set; }
        public string[] StartDate { get; set; }
        public string[] EndMonth { get; set; }
        public string[] EndDate { get; set; }

        public WorkdayCalendarInputData(string name, int recordNumber, string[] specialDateType, string[] startMonth, string[] startDate, string[] endMonth, string[] endDate)
        {
            this.Name = name;
            this.RecordNumber = recordNumber;
            this.SpecialDateType = specialDateType;
            this.StartMonth = startMonth;
            this.StartDate = startDate;
            this.EndMonth = endMonth;
            this.EndDate = endDate;
        }
    }

    public class WorkdayCalendarExpectedData : ExpectedTestDataBase
    {
        public string Name { get; set; }
        public string[] LabelText { get; set; }

        public WorkdayCalendarExpectedData(string name, string[] labelText)
        {
            this.Name = name;
            this.LabelText = labelText;
        }
    }
}
