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

        public VtagInputData(string name, string code, string Commodity, string UOM, string Step, string CalculationType, string Comment)
        {
            this.Name = name;
            this.Code = code;
            this.Commodity = Commodity;
            this.UOM = UOM;
            this.Step = Step;
            this.CalculationType = CalculationType;
            this.Comment = Comment;

        }
    }
}
