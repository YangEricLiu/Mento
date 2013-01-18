using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class TOUPulsePeakTariffData : TestDataBase<TOUPulsePeakTariffInputData, TOUPulsePeakTariffExpectedData>
    {
    }
    public class TOUPulsePeakTariffInputData : InputTestDataBase
    {
        public string Price { get; set; }
        public int RecordNumber { get; set; }
        public string[] StartMonth { get; set; }
        public string[] StartDate { get; set; }
        public string[] EndMonth { get; set; }
        public string[] EndDate { get; set; }
        public string[] StartTime { get; set; }
        public string[] EndTime { get; set; }      

        public TOUPulsePeakTariffInputData(string price, int recordNumber, string[] startMonth, string[] startDate, string[] endMonth, string[] endDate, string[] startTime, string[] endTime)
        {
            this.Price = price;
            this.RecordNumber = recordNumber;
            this.StartMonth = startMonth;
            this.StartDate = StartDate;
            this.EndMonth = endMonth;
            this.EndDate = endDate;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }

    public class TOUPulsePeakTariffExpectedData : ExpectedTestDataBase
    {
        public string Price { get; set; }

        public TOUPulsePeakTariffExpectedData(string price)
        {
            this.Price = price;
        }
    }
}
