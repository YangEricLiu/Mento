using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;
using Mento.ScriptCommon.TestData.Common;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class TOUPulsePeakTariffData : TestDataBase<TOUPulsePeakTariffInputData, TOUPulsePeakTariffExpectedData>
    {
    }
    public class TOUPulsePeakTariffInputData : InputTestDataBase
    {
        public string CommonName { get; set; }
        public string Price { get; set; }
        public TimeRange[] PulsePeakRange { get; set; }

        public TOUPulsePeakTariffInputData(string CommonName, string price, TimeRange[] PulsePeakRange)
        {
            this.CommonName = CommonName;
            this.Price = price;
            this.PulsePeakRange = PulsePeakRange;
        }
    }

    public class TOUPulsePeakTariffExpectedData : ExpectedTestDataBase
    {
        public string CommonName { get; set; }
        public string Price { get; set; }
        public TimeRange[] PulsePeakRange { get; set; }

        public TOUPulsePeakTariffExpectedData(string CommonName, string price, TimeRange[] PulsePeakRange)
        {
            this.CommonName = CommonName;
            this.Price = price;
            this.PulsePeakRange = PulsePeakRange;
        }
    }
}
