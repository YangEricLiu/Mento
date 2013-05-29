using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class PtagData : TestDataBase<PtagInputData, PtagExpectedData>
    {
    }
    public class PtagInputData : InputTestDataBase
    {
        public string Name { get; set; }
        public string code { get; set; }
        public string Metercode { get; set; }
        public string ChannelId { get; set; }
        public string Commodity { get; set; }
        public string Uom { get; set; }
        public string CalculationType { get; set; }
        public string Comment { get; set; }

        public PtagInputData(string name, string code, string metercode, string channelId, string commodity, string uom, string calculationType, string comment)
        {
            this.Name = name;
            this.code = code;
            this.Metercode = metercode;
            this.ChannelId = channelId;
            this.Commodity = commodity;
            this.Uom = uom;
            this.CalculationType = calculationType;
            this.Comment = comment;
        }
    }

    public class PtagExpectedData : ExpectedTestDataBase
    {
        public string Name { get; set; }
        public string code { get; set; }
        public string Metercode { get; set; }
        public string ChannelId { get; set; }
        public string Commodity { get; set; }
        public string Uom { get; set; }
        public string CalculationType { get; set; }
        public string Comment { get; set; }

        public PtagExpectedData(string name, string code, string metercode, string channelId, string commodity, string uom, string calculationType, string comment)
        {
            this.Name = name;
            this.code = code;
            this.Metercode = metercode;
            this.ChannelId = channelId;
            this.Commodity = commodity;
            this.Uom = uom;
            this.CalculationType = calculationType;
            this.Comment = comment;
        }
    }
}
