using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class TOUBasicTariffData : TestDataBase<TOUBasicTariffInputData, TOUBasicTariffExpectedData>
    {
    }
    public class TOUBasicTariffInputData : InputTestDataBase
    {
        public string Name { get; set; }
        public string PlainPrice { get; set; }
        public string PeakPrice { get; set; }
        public string ValleyPrice { get; set; }
        public int PeakRecordNumber { get; set; }
        public int ValleyRecordNumber { get; set; }
        public string[] PeakStartTime { get; set; }
        public string[] PeakEndTime { get; set; }
        public string[] ValleyStartTime { get; set; }
        public string[] ValleyEndTime { get; set; }


        public TOUBasicTariffInputData(string name, string plainPrice, string peakPrice, string valleyPrice, int peakRecordNumber, int valleyRecordNumber, string[] peakStartTime, string[] peakEndTime, string[] valleyStartTime, string[] valleyEndTime)
        {
            this.Name = name;
            this.PlainPrice = plainPrice;
            this.PeakPrice = peakPrice;
            this.ValleyPrice = valleyPrice;
            this.PeakRecordNumber = peakRecordNumber;
            this.ValleyRecordNumber = valleyRecordNumber;
            this.PeakStartTime = peakStartTime;
            this.PeakEndTime = peakEndTime;
            this.ValleyStartTime = valleyStartTime;
            this.ValleyEndTime = valleyEndTime;
        }
    }

    public class TOUBasicTariffExpectedData : ExpectedTestDataBase
    {
        public string Price { get; set; }

        public TOUBasicTariffExpectedData(string price)
        {
            this.Price = price;
        }
    }
}
