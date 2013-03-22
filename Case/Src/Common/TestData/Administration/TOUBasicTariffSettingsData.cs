using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;
using Mento.ScriptCommon.TestData.Common;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class TOUBasicTariffData : TestDataBase<TOUBasicTariffInputData, TOUBasicTariffExpectedData>
    {
    }
    public class TOUBasicTariffInputData : InputTestDataBase
    {
        public string CommonName { get; set; }
        public string PlainPrice { get; set; }
        public string PeakPrice { get; set; }
        public string ValleyPrice { get; set; }
        public TimeRange[] PeakRange { get; set; }
        public TimeRange[] ValleyRange { get; set; }

        public TOUBasicTariffInputData(string CommonName, string PlainPrice, string PeakPrice, string ValleyPrice, TimeRange[] PeakRange, TimeRange[] ValleyRange)
        {
            this.CommonName = CommonName;
            this.PlainPrice = PlainPrice;
            this.PeakPrice = PeakPrice;
            this.ValleyPrice = ValleyPrice;
            this.PeakRange = PeakRange;
            this.ValleyRange = ValleyRange;
        }
    }

    public class TOUBasicTariffExpectedData : ExpectedTestDataBase
    {
        public string CommonName { get; set; }
        public string PlainPrice { get; set; }
        public string PeakPrice { get; set; }
        public string ValleyPrice { get; set; }
        public TimeRange[] PeakRange { get; set; }
        public TimeRange[] ValleyRange { get; set; }
        public string PopMessage { get; set; }

        public TOUBasicTariffExpectedData(string CommonName, string PlainPrice, string PeakPrice, string ValleyPrice, TimeRange[] PeakRange, TimeRange[] ValleyRange, string PopMessage)
        {
            this.CommonName = CommonName;
            this.PlainPrice = PlainPrice;
            this.PeakPrice = PeakPrice;
            this.ValleyPrice = ValleyPrice;
            this.PeakRange = PeakRange;
            this.ValleyRange = ValleyRange;
            this.PopMessage = PopMessage;
        }
    }
}
