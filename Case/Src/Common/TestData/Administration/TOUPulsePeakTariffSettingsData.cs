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
        public string Price { get; set; }
        public TimeRange[] PulsePeakRange { get; set; }

        public TOUPulsePeakTariffInputData(string price, TimeRange[] PulsePeakRange)
        {
            this.Price = price;
            this.PulsePeakRange = PulsePeakRange;
        }
    }

    public class TOUPulsePeakTariffExpectedData : ExpectedTestDataBase
    {
        public string Price { get; set; }
        public TimeRange[] PulsePeakRange { get; set; }

        public TOUPulsePeakTariffExpectedData(string price, TimeRange[] PulsePeakRange)
        {
            this.Price = price;
            this.PulsePeakRange = PulsePeakRange;
        }
    }
}
