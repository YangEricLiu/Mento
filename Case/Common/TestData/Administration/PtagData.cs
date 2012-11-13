using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration.Tag.PtagConfiguration
{
    public class PtagData : TestDataBase<PtagInputData, PtagExpectedData>
    {
    }
    public class PtagInputData : InputTestDataBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string MeterCode { get; set; }
        public string ChannelId { get; set; }
        public string CommodityId { get; set; }
        public string UomId { get; set; }
        public string CalculationType { get; set; }
        public string Comment { get; set; }

        public PtagInputData(string name, string code, string meterCode, string channelId, string commodityId, string uomId, string calculationType, string comment)
        {
            this.Name = name;
            this.Code = code;
            this.MeterCode = meterCode;
            this.ChannelId = channelId;
            this.CommodityId = commodityId;
            this.UomId = uomId;
            this.CalculationType = calculationType;
            this.Comment = comment;
        }
    }

    public class PtagExpectedData : ExpectedTestDataBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string MeterCode { get; set; }
        public string ChannelId { get; set; }
        public string CommodityId { get; set; }
        public string UomId { get; set; }
        public string CalculationType { get; set; }
        public string Comment { get; set; }

        public PtagExpectedData(string name, string code, string meterCode, string channelId, string commodityId, string uomId, string calculationType, string comment)
        {
            this.Name = name;
            this.Code = code;
            this.MeterCode = meterCode;
            this.ChannelId = channelId;
            this.CommodityId = commodityId;
            this.UomId = uomId;
            this.CalculationType = calculationType;
            this.Comment = comment;
        }
    }
}
