using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration.Tag.VtagManagement
{
    public class AddVtagData : TestDataBase<VtagInputData, ExpectedTestDataBase>
    {
    }

    public class VtagInputData : InputTestDataBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Commodity { get; set; }
        public string UOM { get; set; }
        public string Step { get; set; }
        public string CalculationType { get; set; }
        public string Comment { get; set; }

        public VtagInputData(string name, string code, string commodity, string uom, string step, string calculationtype, string comment)
        {
            this.Name = name;
            this.Code = code;
            this.Commodity = commodity;
            this.UOM = uom;
            this.Step = step;
            this.CalculationType = calculationtype;
            this.Comment = comment;

        }
    }
}
