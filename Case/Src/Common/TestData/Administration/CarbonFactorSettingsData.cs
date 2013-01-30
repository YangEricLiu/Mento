using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class CarbonFactorData : TestDataBase<CarbonFactorInputData, CarbonFactorExpectedData>
    {
    }
    public class CarbonFactorInputData : InputTestDataBase
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public int RecordNumber { get; set; }
        public string[] EffectiveYear { get; set; }
        public string[] FactorValue { get; set; }

        public CarbonFactorInputData(string source, string destination, int recordNumber, string[] effectiveYear, string[] factorValue)
        {
            this.Source = source;
            this.Destination = destination;
            this.RecordNumber = recordNumber;
            this.EffectiveYear = effectiveYear;
            this.FactorValue = factorValue;
        }
    }

    public class CarbonFactorExpectedData : ExpectedTestDataBase
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public int RecordNumber { get; set; }
        public string[] EffectiveYear { get; set; }
        public string[] FactorValue { get; set; }

        public CarbonFactorExpectedData(string source, string destination, int recordNumber, string[] effectiveYear, string[] factorValue)
        {
            this.Source = source;
            this.Destination = destination;
            this.RecordNumber = recordNumber;
            this.EffectiveYear = effectiveYear;
            this.FactorValue = factorValue;
        }
    }
}
