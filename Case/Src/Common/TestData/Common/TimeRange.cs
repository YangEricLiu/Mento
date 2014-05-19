using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.ScriptCommon.TestData.Common
{
    public class TimeRange
    {
        //'Type' is used for workday calendar special date type and HeatingCooling calendar type.
        public string Type { get; set; }
        public string StartMonth { get; set; }
        public string EndMonth { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
