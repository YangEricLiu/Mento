using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class AddKPIData : TestDataBase<KPIInputData, KPIExpectedData>
    {
    }
    public class KPIInputData : InputTestDataBase
    {
        public string Name { get; set; }
        public string code { get; set; }
        public string Uom { get; set; }
        public string Steps { get; set; }
        public string CalculationType { get; set; }
        public string Comment { get; set; }

        public KPIInputData(string name, string code, string uom, string steps, string calculationType, string comment)
        {
            this.Name = name;
            this.code = code;
            this.Steps = steps;
            this.Uom = uom;
            this.CalculationType = calculationType;
            this.Comment = comment;
        }
    }

    public class KPIExpectedData : VtagOuputData
    {
        public string Name { get; set; }
        public string code { get; set; }
        public string Uom { get; set; }
        public string Steps { get; set; }
        public string CalculationType { get; set; }
        public string Comment { get; set; }

        public KPIExpectedData(string name, string code, string uom, string steps, string calculationType, string comment)
        {
            this.Name = name;
            this.code = code;
            this.Steps = steps;
            this.Uom = uom;
            this.CalculationType = calculationType;
            this.Comment = comment;
        }
    }
}
